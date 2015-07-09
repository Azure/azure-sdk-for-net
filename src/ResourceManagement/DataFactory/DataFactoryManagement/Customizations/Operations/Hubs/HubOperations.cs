// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Management.DataFactories.Common.Models;
using Microsoft.Azure.Management.DataFactories.Models;

namespace Microsoft.Azure.Management.DataFactories
{
    /// <summary>
    /// Operations for managing hubs.
    /// </summary>
    internal partial class HubOperations : IServiceOperations<DataFactoryManagementClient>, IHubOperations
    {
        public DataFactoryManagementClient Client { get; private set; }

        internal HubOperations(DataFactoryManagementClient client)
        {
            this.Client = client;
        }

        public async Task<HubCreateOrUpdateResponse> BeginCreateOrUpdateAsync(string resourceGroupName,
            string dataFactoryName, HubCreateOrUpdateParameters parameters, CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Hubs.BeginCreateOrUpdateAsync(resourceGroupName,
                dataFactoryName,
                parameters,
                cancellationToken);
        }

        public async Task<LongRunningOperationResponse> BeginDeleteAsync(string resourceGroupName,
            string dataFactoryName, string hubName, CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Hubs.BeginDeleteAsync(resourceGroupName,
                dataFactoryName,
                hubName,
                cancellationToken);
        }

        public async Task<HubCreateOrUpdateResponse> CreateOrUpdateAsync(string resourceGroupName,
            string dataFactoryName, HubCreateOrUpdateParameters parameters, CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Hubs.CreateOrUpdateAsync(resourceGroupName,
                dataFactoryName,
                parameters,
                cancellationToken);
        }

        public async Task<HubCreateOrUpdateResponse> CreateOrUpdateWithRawJsonContentAsync(string resourceGroupName,
            string dataFactoryName, string hubName, HubCreateOrUpdateWithRawJsonContentParameters parameters,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Hubs.CreateOrUpdateWithRawJsonContentAsync(resourceGroupName,
                dataFactoryName,
                hubName,
                parameters,
                cancellationToken);
        }

        public async Task<LongRunningOperationResponse> DeleteAsync(string resourceGroupName, string dataFactoryName,
            string hubName, CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Hubs.DeleteAsync(resourceGroupName,
                dataFactoryName,
                hubName, 
                cancellationToken);
        }

        public async Task<HubGetResponse> GetAsync(string resourceGroupName, string dataFactoryName, string hubName,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Hubs.GetAsync(resourceGroupName,
                dataFactoryName,
                hubName,
                cancellationToken);
        }

        public async Task<HubCreateOrUpdateResponse> GetCreateOrUpdateStatusAsync(string operationStatusLink,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Hubs.GetCreateOrUpdateStatusAsync(operationStatusLink,
                cancellationToken);
        }

        public async Task<HubListResponse> ListAsync(string resourceGroupName, string dataFactoryName,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Hubs.ListAsync(resourceGroupName,
                dataFactoryName,
                cancellationToken);
        }

        public async Task<HubListResponse> ListNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Hubs.ListNextAsync(nextLink, cancellationToken);
        }
    }
}
