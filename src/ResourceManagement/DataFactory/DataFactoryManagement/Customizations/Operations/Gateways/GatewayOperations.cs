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
    /// Operations for managing data factory gateways.
    /// </summary>
    internal class GatewayOperations : IServiceOperations<DataFactoryManagementClient>, IGatewayOperations
    {
        public DataFactoryManagementClient Client { get; private set; }

        internal GatewayOperations(DataFactoryManagementClient client)
        {
            this.Client = client;
        }

        public async Task<GatewayCreateOrUpdateResponse> BeginCreateOrUpdateAsync(
            string resourceGroupName,
            string dataFactoryName,
            GatewayCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Gateways.BeginCreateOrUpdateAsync(
                    resourceGroupName,
                    dataFactoryName,
                    parameters,
                    cancellationToken);
        }

        public async Task<LongRunningOperationResponse> BeginDeleteAsync(
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Gateways.BeginDeleteAsync(
                    resourceGroupName,
                    dataFactoryName,
                    gatewayName,
                    cancellationToken);
        }

        public async Task<GatewayCreateOrUpdateResponse> CreateOrUpdateAsync(
            string resourceGroupName,
            string dataFactoryName,
            GatewayCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Gateways.CreateOrUpdateAsync(
                    resourceGroupName,
                    dataFactoryName,
                    parameters,
                    cancellationToken);
        }

        public async Task<AzureOperationResponse> DeleteAsync(
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Gateways.DeleteAsync(
                    resourceGroupName,
                    dataFactoryName,
                    gatewayName,
                    cancellationToken);
        }

        public async Task<GatewayGetResponse> GetAsync(
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Gateways.GetAsync(
                    resourceGroupName,
                    dataFactoryName,
                    gatewayName,
                    cancellationToken);
        }

        public async Task<GatewayCreateOrUpdateResponse> GetCreateOrUpdateStatusAsync(
            string operationStatusLink,
            CancellationToken cancellationToken)
        {
            return await
                this.Client.InternalClient.Gateways.GetCreateOrUpdateStatusAsync(operationStatusLink, cancellationToken);
        }

        public async Task<GatewayListResponse> ListAsync(
            string resourceGroupName,
            string dataFactoryName,
            CancellationToken cancellationToken)
        {
            return await
                this.Client.InternalClient.Gateways.ListAsync(resourceGroupName, dataFactoryName, cancellationToken);
        }

        public async Task<GatewayRegenerateKeyResponse> RegenerateKeyAsync(
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Gateways.RegenerateKeyAsync(
                    resourceGroupName,
                    dataFactoryName,
                    gatewayName,
                    cancellationToken);
        }

        public async Task<GatewayConnectionInfoRetrieveResponse> RetrieveConnectionInfoAsync(
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Gateways.RetrieveConnectionInfoAsync(
                    resourceGroupName,
                    dataFactoryName,
                    gatewayName,
                    cancellationToken);
        }

        public async Task<GatewayCreateOrUpdateResponse> UpdateAsync(
            string resourceGroupName,
            string dataFactoryName,
            GatewayCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Gateways.UpdateAsync(
                    resourceGroupName,
                    dataFactoryName,
                    parameters,
                    cancellationToken);
        }
    }
}
