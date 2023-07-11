using NovaEnergies.Core.Clients;
using NovaEnergies.Core.Clients.Requests;
using NovaEnergies.Core.Clients.Responses;
using NovaEnergies.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaEnergies.Core.Services
{
    public class SearchService : ISearchService
    {
        private readonly IEnumerable<IProviderApiClient> _apiClients;
        private readonly ICacheService _cacheService;

        public SearchService(
            IEnumerable<IProviderApiClient> apiClients,
            ICacheService cacheService
            )
        {
            _apiClients = apiClients;
            _cacheService = cacheService;
        }
        public async Task<SearchServiceResponse> GetRoutesAsync(SearchServiceRequest request)
        {
            var response = new SearchServiceResponse();

            var resultRoutes = new List<Route>();

            var requestKey = $"dateFrom={request.DateFrom}'dateTo={request.DateTo}'routePrice={request.RoutePrice}'ttl={request.TTL}";

            var routesFromCache = await _cacheService.GetRoutesAsync(requestKey);

            if (request.Filter == Enums.FilterEnum.OnlyCached)
            {
                resultRoutes = routesFromCache;
            }

            else
            {
                if (!routesFromCache.Any())
                {
                    foreach (var apiClient in _apiClients)
                    {
                        try
                        {
                            var resultPingFromFirstProvider = await apiClient.Ping();

                            if (resultPingFromFirstProvider)
                            {
                                if (apiClient.GetType() == typeof(Provider1ApiClient))
                                {
                                    var resultFromProvider = await apiClient.SearchAsync(new Clients.Requests.ProviderOneSearchRequest { });

                                    resultRoutes.AddRange(resultFromProvider);
                                }
                                if (apiClient.GetType() == typeof(Provider2ApiClient))
                                {
                                    var resultFromProvider = await apiClient.SearchAsync(new Clients.Requests.ProviderTwoSearchRequest { });

                                    resultRoutes.AddRange(resultFromProvider);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            //log
                        }
                    }

                    if (resultRoutes.Any())
                    {
                        _cacheService.SetData(requestKey, resultRoutes, DateTimeOffset.Now.AddDays(1));
                    }
                }
            }

            resultRoutes = resultRoutes.Where(x => x.StartDate >= request.DateFrom
            && x.EndDate <= request.DateTo
            && x.RoutePrice <= request.RoutePrice
            && x.TimeToLive >= request.TTL).ToList();

            response.Routes = resultRoutes;

            return response;
        }
    }
}
