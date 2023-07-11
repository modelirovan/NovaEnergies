using NovaEnergies.Core.Types;

namespace NovaEnergies.Core.Services
{
    public interface ICacheService
    {
        Task<List<Route>> GetRoutesAsync(string key);
        bool SetData(string key, List<Route> value, DateTimeOffset expirationTime);
    }
}