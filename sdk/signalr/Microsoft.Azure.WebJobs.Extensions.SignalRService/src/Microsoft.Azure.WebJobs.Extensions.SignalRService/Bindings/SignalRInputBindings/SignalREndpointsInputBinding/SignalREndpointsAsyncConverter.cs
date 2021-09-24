// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
            var hubContext = await _serviceManagerStore.GetOrAddByConnectionStringKey(input.ConnectionStringSetting).ServiceManager.CreateHubContextAsync(input.HubName, cancellationToken: cancellationToken) as IInternalServiceHubContext;
            return hubContext.GetServiceEndpoints().ToArray();
        }
    }
}