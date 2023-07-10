using NovaEnergies.Core.Clients.Requests;
using NovaEnergies.Core.Clients.Responses;

namespace NovaEnergies.Core.Services
{
    public interface ISearchService
    {
        Task<SearchServiceResponse> GetRoutesAsync(SearchServiceRequest request);
    }
}