// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Microsoft.Azure.SignalR.Management;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class Utils
    {
        public static async Task<AzureSignalRClient> GetAzureSignalRClientAsync(string connectionStringKey, string attributeHubName, IServiceManagerStore serviceManagerStore)
        {
            var serviceHubContext = await serviceManagerStore
                .GetOrAddByConnectionStringKey(connectionStringKey)
                .GetAsync(attributeHubName).ConfigureAwait(false) as ServiceHubContext;
            return new AzureSignalRClient(serviceHubContext);
        }
    }
}