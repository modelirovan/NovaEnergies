using AutoMapper;
using Newtonsoft.Json;
using NovaEnergies.Core.Clients.Requests;
using NovaEnergies.Core.Clients.Responses;
using NovaEnergies.Core.DTOs;
using NovaEnergies.Core.Helpers;
using NovaEnergies.Core.Settings;
using NovaEnergies.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaEnergies.Core.Clients
{
    public class Provider1ApiClient : ClientBase, IProviderApiClient
    {
        private readonly ProviderOneSettings _clientSettings;
        private readonly IExecutionHttpRequestClient _executionHttpRequestClient;
        private readonly IMessageHelper _messageHelper;
        private readonly IMapper _mapper;

        public Provider1ApiClient(ProviderOneSettings clientSettings,
            IExecutionHttpRequestClient executionHttpRequestClient,
            IMessageHelper messageHelper,
            IMapper mapper) : base(clientSettings)
        {
            _clientSettings = clientSettings;
            _executionHttpRequestClient = executionHttpRequestClient;
            _messageHelper = messageHelper;
            _mapper = mapper;
        }

        public async Task<List<Route>> SearchAsync(RequestBase request)
        {
            var method = Method("Search");

            var message = _messageHelper.CreateMessage(method, _clientSettings, request);

            var response = await _executionHttpRequestClient.Execute<ProviderOneSearchResponse>(message);

            var routes = _mapper.Map<List<RouteDto>, List<Route>>(response.Result.Routes);

            return routes;
        }

        public async Task<bool> Ping()
        {
            var method = Method("Ping");

            RequestBase request = new RequestBase();

            var message = _messageHelper.CreateMessage(method, _clientSettings, request);

            var response = await _executionHttpRequestClient.Execute<ProviderOneSearchResponse>(message, false);

            return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
        }
    }

    public class Provider2ApiClient : ClientBase, IProviderApiClient
    {
        private readonly ProviderTwoSettings _clientSettings;
        private readonly IExecutionHttpRequestClient _executionHttpRequestClient;
        private readonly IMessageHelper _messageHelper;
        private readonly IMapper _mapper;

        public Provider2ApiClient(ProviderTwoSettings clientSettings,
            IExecutionHttpRequestClient executionHttpRequestClient,
            IMessageHelper messageHelper,
            IMapper mapper) : base(clientSettings)
        {
            _clientSettings = clientSettings;
            _executionHttpRequestClient = executionHttpRequestClient;
            _messageHelper = messageHelper;
            _mapper = mapper;
        }

        public async Task<List<Route>> SearchAsync(RequestBase request)
        {
            var method = Method("Search");

            var message = _messageHelper.CreateMessage(method, _clientSettings, request);

            var response = await _executionHttpRequestClient.Execute<ProviderTwoSearchResponse>(message);

            var routes = _mapper.Map<List<RouteDto>, List<Route>>(response.Result.Routes);

            return routes;
        }

        public async Task<bool> Ping()
        {
            var method = Method("Ping");

            RequestBase request = new RequestBase();

            var message = _messageHelper.CreateMessage(method, _clientSettings, request);

            var response = await _executionHttpRequestClient.Execute<ProviderOneSearchResponse>(message, false);

            return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
