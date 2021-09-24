// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Management;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class NegotiationContextAsyncConverter : IAsyncConverter<SignalRNegotiationAttribute, NegotiationContext>
    {
        private readonly IServiceManagerStore _serviceManagerStore;

        public NegotiationContextAsyncConverter
            (IServiceManagerStore serviceManagerStore)
        {
            _serviceManagerStore = serviceManagerStore;
        }

        public async Task<NegotiationContext> ConvertAsync(
            SignalRNegotiationAttribute input, CancellationToken cancellationToken)
        {
            var serviceHubContext = await _serviceManagerStore
                .GetOrAddByConnectionStringKey(input.ConnectionStringSetting)
                .GetAsync(input.HubName) as IInternalServiceHubContext;
            var endpoints = serviceHubContext.GetServiceEndpoints();
            var endpointConnectionInfo = await Task.WhenAll(endpoints.Select(async e =>
            {
                var subHubContext = serviceHubContext.WithEndpoints(new ServiceEndpoint[] { e });
                var azureSignalRClient = new AzureSignalRClient(subHubContext);
                var connectionInfo = await azureSignalRClient.GetClientConnectionInfoAsync(input.UserId, input.IdToken, input.ClaimTypeList, null);
                return new EndpointConnectionInfo(e) { ConnectionInfo = connectionInfo };
            }));
            return new NegotiationContext { Endpoints = endpointConnectionInfo };
        }
    }
}