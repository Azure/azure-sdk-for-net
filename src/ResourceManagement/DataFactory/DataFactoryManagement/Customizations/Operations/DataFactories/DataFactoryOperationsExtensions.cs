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
using Microsoft.Azure.Management.DataFactories.Models;

namespace Microsoft.Azure.Management.DataFactories
{
    public static class DataFactoryOperationsExtensions
    {
        /// <summary>
        /// Create or update a data factory.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IDataFactoryOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a data
        /// factory.
        /// </param>
        /// <returns>
        /// The create or update data factory operation response.
        /// </returns>
        public static DataFactoryCreateOrUpdateResponse BeginCreateOrUpdate(
            this IDataFactoryOperations operations,
            string resourceGroupName,
            DataFactoryCreateOrUpdateParameters parameters)
        {
            return Task.Factory.StartNew(
                s => ((IDataFactoryOperations)s).BeginCreateOrUpdateAsync(resourceGroupName, parameters),
                operations,
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create or update a data factory.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IDataFactoryOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a data
        /// factory.
        /// </param>
        /// <returns>
        /// The create or update data factory operation response.
        /// </returns>
        public static Task<DataFactoryCreateOrUpdateResponse> BeginCreateOrUpdateAsync(
            this IDataFactoryOperations operations,
            string resourceGroupName,
            DataFactoryCreateOrUpdateParameters parameters)
        {
            return operations.BeginCreateOrUpdateAsync(resourceGroupName, parameters, CancellationToken.None);
        }

        /// <summary>
        /// Create or update a data factory.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IDataFactoryOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a data
        /// factory.
        /// </param>
        /// <returns>
        /// The create or update data factory operation response.
        /// </returns>
        public static DataFactoryCreateOrUpdateResponse CreateOrUpdate(
            this IDataFactoryOperations operations,
            string resourceGroupName,
            DataFactoryCreateOrUpdateParameters parameters)
        {
            return Task.Factory.StartNew(
                s => ((IDataFactoryOperations)s).CreateOrUpdateAsync(resourceGroupName, parameters),
                operations,
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create or update a data factory.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IDataFactoryOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a data
        /// factory.
        /// </param>
        /// <returns>
        /// The create or update data factory operation response.
        /// </returns>
        public static Task<DataFactoryCreateOrUpdateResponse> CreateOrUpdateAsync(
            this IDataFactoryOperations operations,
            string resourceGroupName,
            DataFactoryCreateOrUpdateParameters parameters)
        {
            return operations.CreateOrUpdateAsync(resourceGroupName, parameters, CancellationToken.None);
        }

        /// <summary>
        /// Delete a data factory instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IDataFactoryOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static AzureOperationResponse Delete(
            this IDataFactoryOperations operations,
            string resourceGroupName,
            string dataFactoryName)
        {
            return Task.Factory.StartNew(
                s => ((IDataFactoryOperations)s).DeleteAsync(resourceGroupName, dataFactoryName),
                operations,
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Delete a data factory instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IDataFactoryOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static Task<AzureOperationResponse> DeleteAsync(
            this IDataFactoryOperations operations,
            string resourceGroupName,
            string dataFactoryName)
        {
            return operations.DeleteAsync(resourceGroupName, dataFactoryName, CancellationToken.None);
        }

        /// <summary>
        /// Gets a data factory instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IDataFactoryOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <returns>
        /// The Get data factory operation response.
        /// </returns>
        public static DataFactoryGetResponse Get(
            this IDataFactoryOperations operations,
            string resourceGroupName,
            string dataFactoryName)
        {
            return Task.Factory.StartNew(
                s => ((IDataFactoryOperations)s).GetAsync(resourceGroupName, dataFactoryName),
                operations,
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets a data factory instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IDataFactoryOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <returns>
        /// The Get data factory operation response.
        /// </returns>
        public static Task<DataFactoryGetResponse> GetAsync(
            this IDataFactoryOperations operations,
            string resourceGroupName,
            string dataFactoryName)
        {
            return operations.GetAsync(resourceGroupName, dataFactoryName, CancellationToken.None);
        }

        /// <summary>
        /// The Get Operation Status operation returns the status of the
        /// specified operation. After calling an asynchronous operation, you
        /// can call Get Operation Status to determine whether the operation
        /// has succeeded, failed, or is still in progress.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IDataFactoryOperations.
        /// </param>
        /// <param name='operationStatusLink'>
        /// Required. Location value returned by the Begin operation.
        /// </param>
        /// <returns>
        /// The create or update data factory operation response.
        /// </returns>
        public static DataFactoryCreateOrUpdateResponse GetCreateOrUpdateStatus(
            this IDataFactoryOperations operations,
            string operationStatusLink)
        {
            return Task.Factory.StartNew(
                s => ((IDataFactoryOperations)s).GetCreateOrUpdateStatusAsync(operationStatusLink),
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
        /// Microsoft.Azure.Management.DataFactories.Core.IDataFactoryOperations.
        /// </param>
        /// <param name='operationStatusLink'>
        /// Required. Location value returned by the Begin operation.
        /// </param>
        /// <returns>
        /// The create or update data factory operation response.
        /// </returns>
        public static Task<DataFactoryCreateOrUpdateResponse> GetCreateOrUpdateStatusAsync(
            this IDataFactoryOperations operations,
            string operationStatusLink)
        {
            return operations.GetCreateOrUpdateStatusAsync(operationStatusLink, CancellationToken.None);
        }

        /// <summary>
        /// Gets the first page of data factory instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IDataFactoryOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factories.
        /// </param>
        /// <returns>
        /// The List data factories operation response.
        /// </returns>
        public static DataFactoryListResponse List(this IDataFactoryOperations operations, string resourceGroupName)
        {
            return Task.Factory.StartNew(
                s => ((IDataFactoryOperations)s).ListAsync(resourceGroupName),
                operations,
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the first page of data factory instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IDataFactoryOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factories.
        /// </param>
        /// <returns>
        /// The List data factories operation response.
        /// </returns>
        public static Task<DataFactoryListResponse> ListAsync(
            this IDataFactoryOperations operations,
            string resourceGroupName)
        {
            return operations.ListAsync(resourceGroupName, CancellationToken.None);
        }

        /// <summary>
        /// Gets the next page of data factory instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IDataFactoryOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The url to the next data factories page.
        /// </param>
        /// <returns>
        /// The List data factories operation response.
        /// </returns>
        public static DataFactoryListResponse ListNext(this IDataFactoryOperations operations, string nextLink)
        {
            return Task.Factory.StartNew(
                s => ((IDataFactoryOperations)s).ListNextAsync(nextLink),
                operations,
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the next page of data factory instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IDataFactoryOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The url to the next data factories page.
        /// </param>
        /// <returns>
        /// The List data factories operation response.
        /// </returns>
        public static Task<DataFactoryListResponse> ListNextAsync(
            this IDataFactoryOperations operations,
            string nextLink)
        {
            return operations.ListNextAsync(nextLink, CancellationToken.None);
        }
    }
}
