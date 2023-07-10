using Newtonsoft.Json;
using NovaEnergies.Core.Clients.Requests;
using NovaEnergies.Core.Settings;
using NovaEnergies.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaEnergies.Core.Helpers
{
    public class MessageHelper : IMessageHelper
    {
        protected string Scheme;
        protected string Host;
        protected string Path;

        public HttpRequestMessage CreateMessage<T1, T2>(Method method, T1 _clientSettings, T2 request, string methodUrl) where T1 : ClientSettings where T2 : RequestBase
        {
            Scheme = _clientSettings.Scheme;
            Host = _clientSettings.Host;
            Path = _clientSettings.Path;

            var jsonData = request != null ? JsonConvert.SerializeObject(request) : String.Empty;

            var message = new HttpRequestMessage()
            {
                RequestUri = new Uri($"{Scheme}://{Host}{Path}{methodUrl ?? method.Path}"),
                Method = new HttpMethod(method.HttpMethod.ToUpper()),
                Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
            };

            return message;
        }
    }
}
