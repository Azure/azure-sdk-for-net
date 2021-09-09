// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using Microsoft.Azure.SignalR.Management;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class Utils
    {
        public async static Task<AzureSignalRClient> GetAzureSignalRClientAsync(string connectionStringKey, string attributeHubName, IServiceManagerStore serviceManagerStore)
        {
            var serviceHubContext = await serviceManagerStore
                .GetOrAddByConnectionStringKey(connectionStringKey)
                .GetAsync(attributeHubName) as ServiceHubContext;
            return new AzureSignalRClient(serviceHubContext);
        }
    }
}