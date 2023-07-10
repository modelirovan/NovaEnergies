using NovaEnergies.Core.Clients.Requests;
using NovaEnergies.Core.Settings;
using NovaEnergies.Core.Types;

namespace NovaEnergies.Core.Helpers
{
    public interface IMessageHelper
    {
        HttpRequestMessage CreateMessage<T1,T2>(Method method, T1 _clientSettings, T2 request = null, string methodUrl = null) where T1 : ClientSettings where T2: RequestBase;
    }
}