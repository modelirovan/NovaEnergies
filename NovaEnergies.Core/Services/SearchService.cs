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

        public SearchService(IEnumerable<IProviderApiClient> apiClients)
        {
            _apiClients = apiClients;
        }
        public async Task<SearchServiceResponse> GetRoutesAsync(SearchServiceRequest request)
        {
            var response = new SearchServiceResponse();

            var resultRoutes = new List<Route>();

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

            resultRoutes = resultRoutes.Where(x => x.StartDate >= request.DateFrom
            && x.EndDate <= request.DateTo
            && x.RoutePrice <= request.RoutePrice
            && x.TimeToLive >= request.TTL).ToList();

            response.Routes = resultRoutes;

            return response;
        }
    }
}
