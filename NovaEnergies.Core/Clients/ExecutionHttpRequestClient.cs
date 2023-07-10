using Newtonsoft.Json;
using NovaEnergies.Core.Settings;
using NovaEnergies.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaEnergies.Core.Clients
{
    public class ExecutionHttpRequestClient : IExecutionHttpRequestClient
    {
        public async Task<HttpResult<TResult>> Execute<TResult>(HttpRequestMessage message, bool deserialize = true) where TResult : new() 
        {
            var result = new TResult();

            using (var httpClient = new HttpClient())
            {
                var httpResponseMessage = await httpClient.SendAsync(message);

                var response = await httpResponseMessage.Content.ReadAsStringAsync();

                var httpStatusCode = httpResponseMessage.StatusCode;

                if (!String.IsNullOrEmpty(response) && deserialize)
                {
                    try
                    {
                        result = JsonConvert.DeserializeObject<TResult>(response);
                    }
                    catch (Exception ex)
                    {
                        result = new TResult();

                        //log ex
                    }
                }

                var httpResult = new HttpResult<TResult>(result, httpStatusCode);

                return httpResult;
            }
        }
    }
}
