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
using Microsoft.Azure.Management.DataFactories.Common.Models;
using Microsoft.Azure.Management.DataFactories.Models;

namespace Microsoft.Azure.Management.DataFactories
{
    public static class GatewayOperationsExtensions
    {
        /// <summary>
        /// Create or update a data factory gateway.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IGatewayOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a data
        /// factory gateway.
        /// </param>
        /// <returns>
        /// The create or update data factory gateway operation response.
        /// </returns>
        public static GatewayCreateOrUpdateResponse BeginCreateOrUpdate(
            this IGatewayOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            GatewayCreateOrUpdateParameters parameters)
        {
            return Task.Factory.StartNew(
                s => ((IGatewayOperations)s).BeginCreateOrUpdateAsync(
                    resourceGroupName,
                    dataFactoryName,
                    parameters),
                operations,
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create or update a data factory gateway.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IGatewayOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a data
        /// factory gateway.
        /// </param>
        /// <returns>
        /// The create or update data factory gateway operation response.
        /// </returns>
        public static Task<GatewayCreateOrUpdateResponse> BeginCreateOrUpdateAsync(
            this IGatewayOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            GatewayCreateOrUpdateParameters parameters)
        {
            return operations.BeginCreateOrUpdateAsync(
                resourceGroupName,
                dataFactoryName,
                parameters,
                CancellationToken.None);
        }

        /// <summary>
        /// Delete a data factory gateway.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IGatewayOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='gatewayName'>
        /// Required. Name of the gateway to delete.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static LongRunningOperationResponse BeginDelete(
            this IGatewayOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName)
        {
            return Task.Factory.StartNew(
                s => ((IGatewayOperations)s).BeginDeleteAsync(resourceGroupName, dataFactoryName, gatewayName),
                operations,
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Delete a data factory gateway.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IGatewayOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='gatewayName'>
        /// Required. Name of the gateway to delete.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static Task<LongRunningOperationResponse> BeginDeleteAsync(
            this IGatewayOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName)
        {
            return operations.BeginDeleteAsync(resourceGroupName, dataFactoryName, gatewayName, CancellationToken.None);
        }

        /// <summary>
        /// Create or update a data factory gateway.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IGatewayOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a data
        /// factory gateway.
        /// </param>
        /// <returns>
        /// The create or update data factory gateway operation response.
        /// </returns>
        public static GatewayCreateOrUpdateResponse CreateOrUpdate(
            this IGatewayOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            GatewayCreateOrUpdateParameters parameters)
        {
            return Task.Factory.StartNew(
                s => ((IGatewayOperations)s).CreateOrUpdateAsync(
                    resourceGroupName,
                    dataFactoryName,
                    parameters),
                operations,
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create or update a data factory gateway.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IGatewayOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a data
        /// factory gateway.
        /// </param>
        /// <returns>
        /// The create or update data factory gateway operation response.
        /// </returns>
        public static Task<GatewayCreateOrUpdateResponse> CreateOrUpdateAsync(
            this IGatewayOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            GatewayCreateOrUpdateParameters parameters)
        {
            return operations.CreateOrUpdateAsync(
                resourceGroupName,
                dataFactoryName,
                parameters,
                CancellationToken.None);
        }

        /// <summary>
        /// Delete a data factory gateway.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IGatewayOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='gatewayName'>
        /// Required. Name of the gateway to delete.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static AzureOperationResponse Delete(
            this IGatewayOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName)
        {
            return Task.Factory.StartNew(
                s => ((IGatewayOperations)s).DeleteAsync(resourceGroupName, dataFactoryName, gatewayName),
                operations,
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Delete a data factory gateway.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IGatewayOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='gatewayName'>
        /// Required. Name of the gateway to delete.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static Task<AzureOperationResponse> DeleteAsync(
            this IGatewayOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName)
        {
            return operations.DeleteAsync(resourceGroupName, dataFactoryName, gatewayName, CancellationToken.None);
        }

        /// <summary>
        /// Gets a data factory gateway.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IGatewayOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='gatewayName'>
        /// Required. Name of the gateway to get.
        /// </param>
        /// <returns>
        /// The Get data factory gateway operation response.
        /// </returns>
        public static GatewayGetResponse Get(
            this IGatewayOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName)
        {
            return Task.Factory.StartNew(
                s => ((IGatewayOperations)s).GetAsync(resourceGroupName, dataFactoryName, gatewayName),
                operations,
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets a data factory gateway.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IGatewayOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='gatewayName'>
        /// Required. Name of the gateway to get.
        /// </param>
        /// <returns>
        /// The Get data factory gateway operation response.
        /// </returns>
        public static Task<GatewayGetResponse> GetAsync(
            this IGatewayOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName)
        {
            return operations.GetAsync(resourceGroupName, dataFactoryName, gatewayName, CancellationToken.None);
        }

        /// <summary>
        /// The Get Operation Status operation returns the status of the
        /// specified operation. After calling an asynchronous operation, you
        /// can call Get Operation Status to determine whether the operation
        /// has succeeded, failed, or is still in progress.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IGatewayOperations.
        /// </param>
        /// <param name='operationStatusLink'>
        /// Required. Location value returned by the Begin operation.
        /// </param>
        /// <returns>
        /// The create or update data factory gateway operation response.
        /// </returns>
        public static GatewayCreateOrUpdateResponse GetCreateOrUpdateStatus(
            this IGatewayOperations operations,
            string operationStatusLink)
        {
            return Task.Factory.StartNew(
                s => ((IGatewayOperations)s).GetCreateOrUpdateStatusAsync(operationStatusLink),
                operations,
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// The Get Operation Status operation returns the status of the
        /// specified operation. After calling an asynchronous operation, you
        /// can call Get Operation Status to determine whether the operation
        /// has succeeded, failed, or is still in progress.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IGatewayOperations.
        /// </param>
        /// <param name='operationStatusLink'>
        /// Required. Location value returned by the Begin operation.
        /// </param>
        /// <returns>
        /// The create or update data factory gateway operation response.
        /// </returns>
        public static Task<GatewayCreateOrUpdateResponse> GetCreateOrUpdateStatusAsync(
            this IGatewayOperations operations,
            string operationStatusLink)
        {
            return operations.GetCreateOrUpdateStatusAsync(operationStatusLink, CancellationToken.None);
        }

        /// <summary>
        /// List all gateways under a data factory.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IGatewayOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <returns>
        /// The List data factory gateways operation response.
        /// </returns>
        public static GatewayListResponse List(
            this IGatewayOperations operations,
            string resourceGroupName,
            string dataFactoryName)
        {
            return Task.Factory.StartNew(
                s => ((IGatewayOperations)s).ListAsync(resourceGroupName, dataFactoryName),
                operations,
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// List all gateways under a data factory.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IGatewayOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <returns>
        /// The List data factory gateways operation response.
        /// </returns>
        public static Task<GatewayListResponse> ListAsync(
            this IGatewayOperations operations,
            string resourceGroupName,
            string dataFactoryName)
        {
            return operations.ListAsync(resourceGroupName, dataFactoryName, CancellationToken.None);
        }

        /// <summary>
        /// Regenerate gateway key.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IGatewayOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='gatewayName'>
        /// Required. The name of the gateway to regenerate key.
        /// </param>
        /// <returns>
        /// The regenerate gateway key operation response.
        /// </returns>
        public static GatewayRegenerateKeyResponse RegenerateKey(
            this IGatewayOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName)
        {
            return Task.Factory.StartNew(
                s => ((IGatewayOperations)s).RegenerateKeyAsync(
                    resourceGroupName,
                    dataFactoryName,
                    gatewayName),
                operations,
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Regenerate gateway key.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IGatewayOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='gatewayName'>
        /// Required. The name of the gateway to regenerate key.
        /// </param>
        /// <returns>
        /// The regenerate gateway key operation response.
        /// </returns>
        public static Task<GatewayRegenerateKeyResponse> RegenerateKeyAsync(
            this IGatewayOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName)
        {
            return operations.RegenerateKeyAsync(
                resourceGroupName,
                dataFactoryName,
                gatewayName,
                CancellationToken.None);
        }

        /// <summary>
        /// Retrieve gateway connection information.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IGatewayOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='gatewayName'>
        /// Required. Name of the gateway.
        /// </param>
        /// <returns>
        /// The retrieve gateway connection information operation response.
        /// </returns>
        public static GatewayConnectionInfoRetrieveResponse RetrieveConnectionInfo(
            this IGatewayOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName)
        {
            return Task.Factory.StartNew(
                s => ((IGatewayOperations)s).RetrieveConnectionInfoAsync(
                    resourceGroupName,
                    dataFactoryName,
                    gatewayName),
                operations,
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieve gateway connection information.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IGatewayOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='gatewayName'>
        /// Required. Name of the gateway.
        /// </param>
        /// <returns>
        /// The retrieve gateway connection information operation response.
        /// </returns>
        public static Task<GatewayConnectionInfoRetrieveResponse> RetrieveConnectionInfoAsync(
            this IGatewayOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName)
        {
            return operations.RetrieveConnectionInfoAsync(
                resourceGroupName,
                dataFactoryName,
                gatewayName,
                CancellationToken.None);
        }

        /// <summary>
        /// Update a data factory gateway.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IGatewayOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a data
        /// factory gateway.
        /// </param>
        /// <returns>
        /// The create or update data factory gateway operation response.
        /// </returns>
        public static GatewayCreateOrUpdateResponse Update(
            this IGatewayOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            GatewayCreateOrUpdateParameters parameters)
        {
            return Task.Factory.StartNew(
                s => ((IGatewayOperations)s).UpdateAsync(resourceGroupName, dataFactoryName, parameters),
                operations,
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Update a data factory gateway.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IGatewayOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a data
        /// factory gateway.
        /// </param>
        /// <returns>
        /// The create or update data factory gateway operation response.
        /// </returns>
        public static Task<GatewayCreateOrUpdateResponse> UpdateAsync(
            this IGatewayOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            GatewayCreateOrUpdateParameters parameters)
        {
            return operations.UpdateAsync(resourceGroupName, dataFactoryName, parameters, CancellationToken.None);
        }
    }
}
