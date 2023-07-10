using NovaEnergies.Core.Clients.Requests;
using NovaEnergies.Core.Types;

namespace NovaEnergies.Core.Clients
{
    public interface IProviderApiClient
    {
        Task<List<Route>> SearchAsync(RequestBase request);

        Task<bool> Ping();
    }
}