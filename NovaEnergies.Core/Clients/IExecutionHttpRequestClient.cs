using NovaEnergies.Core.Settings;
using NovaEnergies.Core.Types;

namespace NovaEnergies.Core.Clients
{
    public interface IExecutionHttpRequestClient
    {
        Task<HttpResult<TResult>> Execute<TResult>(HttpRequestMessage message, bool deserialize = true)
            where TResult : new();
    }
}