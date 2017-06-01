﻿// 
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
using Microsoft.Azure.Management.DataFactories.Common.Models;
using Microsoft.Azure.Management.DataFactories.Models;

namespace Microsoft.Azure.Management.DataFactories
{
    /// <summary>
    /// Operations for managing data factory gateways.
    /// </summary>
    public interface IGatewayOperations
    {
        /// <summary>
        /// Create or update a data factory gateway.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// A unique data factory instance name.
        /// </param>
        /// <param name='parameters'>
        /// The parameters required to create or update a data factory gateway.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The create or update data factory gateway operation response.
        /// </returns>
        Task<GatewayCreateOrUpdateResponse> BeginCreateOrUpdateAsync(
            string resourceGroupName,
            string dataFactoryName,
            GatewayCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken);

        /// <summary>
        /// Delete a data factory gateway.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// A unique data factory instance name.
        /// </param>
        /// <param name='gatewayName'>
        /// Name of the gateway to delete.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        Task<LongRunningOperationResponse> BeginDeleteAsync(
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName,
            CancellationToken cancellationToken);

        /// <summary>
        /// Create or update a data factory gateway.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// A unique data factory instance name.
        /// </param>
        /// <param name='parameters'>
        /// The parameters required to create or update a data factory gateway.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The create or update data factory gateway operation response.
        /// </returns>
        Task<GatewayCreateOrUpdateResponse> CreateOrUpdateAsync(
            string resourceGroupName,
            string dataFactoryName,
            GatewayCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken);

        /// <summary>
        /// Delete a data factory gateway.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// A unique data factory instance name.
        /// </param>
        /// <param name='gatewayName'>
        /// Name of the gateway to delete.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        Task<AzureOperationResponse> DeleteAsync(
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName,
            CancellationToken cancellationToken);

        /// <summary>
        /// Gets a data factory gateway.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// A unique data factory instance name.
        /// </param>
        /// <param name='gatewayName'>
        /// Name of the gateway to get.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The Get data factory gateway operation response.
        /// </returns>
        Task<GatewayGetResponse> GetAsync(
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName,
            CancellationToken cancellationToken);

        /// <summary>
        /// The Get Operation Status operation returns the status of the
        /// specified operation. After calling an asynchronous operation, you
        /// can call Get Operation Status to determine whether the operation
        /// has succeeded, failed, or is still in progress.
        /// </summary>
        /// <param name='operationStatusLink'>
        /// Location value returned by the Begin operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The create or update data factory gateway operation response.
        /// </returns>
        Task<GatewayCreateOrUpdateResponse> GetCreateOrUpdateStatusAsync(
            string operationStatusLink,
            CancellationToken cancellationToken);

        /// <summary>
        /// List all gateways under a data factory.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// A unique data factory instance name.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The List data factory gateways operation response.
        /// </returns>
        Task<GatewayListResponse> ListAsync(
            string resourceGroupName,
            string dataFactoryName,
            CancellationToken cancellationToken);

        /// <summary>
        /// Regenerate gateway auth key.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// A unique data factory instance name.
        /// </param>
        /// <param name='gatewayName'>
        /// The name of the gateway to regenerate auth key.
        /// </param>
        /// <param name='parameters'>
        /// Name of the gateway auth key to be regenerated.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The regenerate gateway auth key operation response.
        /// </returns>
        Task<GatewayRegenerateAuthKeyResponse> RegenerateAuthKeyAsync(
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName,
            GatewayRegenerateAuthKeyParameters parameters,
            CancellationToken cancellationToken);

        /// <summary>
        /// List auth keys of the gateway.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// A unique data factory instance name.
        /// </param>
        /// <param name='gatewayName'>
        /// The name of the gateway to list auth keys.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The List data factory gateway auth keys operation response.
        /// </returns>
        Task<GatewayListAuthKeysResponse> ListAuthKeysAsync(
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName,
            CancellationToken cancellationToken);

        /// <summary>
        /// Regenerate gateway key.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// A unique data factory instance name.
        /// </param>
        /// <param name='gatewayName'>
        /// The name of the gateway to regenerate key.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The regenerate gateway key operation response.
        /// </returns>
        Task<GatewayRegenerateKeyResponse> RegenerateKeyAsync(
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName,
            CancellationToken cancellationToken);

        /// <summary>
        /// Retrieve gateway connection information.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// A unique data factory instance name.
        /// </param>
        /// <param name='gatewayName'>
        /// Name of the gateway.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The retrieve gateway connection information operation response.
        /// </returns>
        Task<GatewayConnectionInfoRetrieveResponse> RetrieveConnectionInfoAsync(
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName,
            CancellationToken cancellationToken);

        /// <summary>
        /// Update a data factory gateway.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// A unique data factory instance name.
        /// </param>
        /// <param name='parameters'>
        /// The parameters required to create or update a data factory gateway.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The create or update data factory gateway operation response.
        /// </returns>
        Task<GatewayCreateOrUpdateResponse> UpdateAsync(
            string resourceGroupName,
            string dataFactoryName,
            GatewayCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken);
    }
}
