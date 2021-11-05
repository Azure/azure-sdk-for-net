// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Management;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SignalREndpointsAsyncConverter : IAsyncConverter<SignalREndpointsAttribute, ServiceEndpoint[]>
    {
        private readonly IServiceManagerStore _serviceManagerStore;

        public SignalREndpointsAsyncConverter(IServiceManagerStore serviceManagerStore)
        {
            _serviceManagerStore = serviceManagerStore;
        }

        public async Task<ServiceEndpoint[]> ConvertAsync(SignalREndpointsAttribute input, CancellationToken cancellationToken)
        {
            var hubContext = await _serviceManagerStore.GetOrAddByConnectionStringKey(input.ConnectionStringSetting).ServiceManager.CreateHubContextAsync(input.HubName, cancellationToken: cancellationToken).ConfigureAwait(false) as IInternalServiceHubContext;
            return hubContext.GetServiceEndpoints().ToArray();
        }
    }
}