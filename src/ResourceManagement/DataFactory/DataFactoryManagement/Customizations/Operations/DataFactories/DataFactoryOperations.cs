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
using Microsoft.Azure.Management.DataFactories.Models;

namespace Microsoft.Azure.Management.DataFactories
{
    internal class DataFactoryOperations : IServiceOperations<DataFactoryManagementClient>, IDataFactoryOperations
    {
        public DataFactoryManagementClient Client { get; private set; }

        internal DataFactoryOperations(DataFactoryManagementClient client)
        {
            this.Client = client;
        }

        public async Task<DataFactoryCreateOrUpdateResponse> BeginCreateOrUpdateAsync(
            string resourceGroupName,
            DataFactoryCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken)
        {
            return await
                this.Client.InternalClient.DataFactories.BeginCreateOrUpdateAsync(
                    resourceGroupName,
                    parameters,
                    cancellationToken);
        }

        public async Task<DataFactoryCreateOrUpdateResponse> CreateOrUpdateAsync(
            string resourceGroupName,
            DataFactoryCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken)
        {
            return await
                this.Client.InternalClient.DataFactories.CreateOrUpdateAsync(
                    resourceGroupName,
                    parameters,
                    cancellationToken);
        }

        public async Task<AzureOperationResponse> DeleteAsync(
            string resourceGroupName,
            string dataFactoryName,
            CancellationToken cancellationToken)
        {
            return await
                this.Client.InternalClient.DataFactories.DeleteAsync(
                    resourceGroupName,
                    dataFactoryName,
                    cancellationToken);
        }

        public async Task<DataFactoryGetResponse> GetAsync(
            string resourceGroupName,
            string dataFactoryName,
            CancellationToken cancellationToken)
        {
            return await
                this.Client.InternalClient.DataFactories.GetAsync(resourceGroupName, dataFactoryName, cancellationToken);
        }

        public async Task<DataFactoryCreateOrUpdateResponse> GetCreateOrUpdateStatusAsync(
            string operationStatusLink,
            CancellationToken cancellationToken)
        {
            return await
                this.Client.InternalClient.DataFactories.GetCreateOrUpdateStatusAsync(
                    operationStatusLink,
                    cancellationToken);
        }

        public async Task<DataFactoryListResponse> ListAsync(
            string resourceGroupName,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.DataFactories.ListAsync(resourceGroupName, cancellationToken);
        }

        public async Task<DataFactoryListResponse> ListNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.DataFactories.ListNextAsync(nextLink, cancellationToken);
        }
    }
}
