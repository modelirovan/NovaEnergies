using Newtonsoft.Json;
using NovaEnergies.Core.Types;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaEnergies.Core.Services
{
    public class CacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private IDatabase _casheDb;

        public CacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
            _casheDb = _connectionMultiplexer.GetDatabase();
        }

        public async Task<List<Route>> GetRoutesAsync(string key)
        {
            var result = new List<Route>();

            var routes = await _casheDb.StringGetAsync(key);

            if (!string.IsNullOrEmpty(routes))
            {
                result = JsonConvert.DeserializeObject<List<Route>>(routes);
            }

            return result;
        }

        public bool SetData(string key, List<Route> value, DateTimeOffset expirationTime)
        {
            var expirtyTime = expirationTime.DateTime.Subtract(DateTime.Now);

            var isSet = _casheDb.StringSet(key, JsonConvert.SerializeObject(value), expirtyTime);

            return isSet;
        }
    }
}
