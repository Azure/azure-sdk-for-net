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
using Microsoft.Azure.Management.DataFactories.Models;

namespace Microsoft.Azure.Management.DataFactories
{
    public static class DataSliceOperationsExtensions
    {
        /// <summary>
        /// Gets the first page of data slice instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IDataSliceOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='tableName'>
        /// Required. A unique table instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. Parameters specifying how to list data slices of the table.
        /// </param>
        /// <returns>
        /// The List data slices operation response.
        /// </returns>
        public static DataSliceListResponse List(
            this IDataSliceOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string tableName,
            DataSliceListParameters parameters)
        {
            return Task.Factory.StartNew(
                s => ((IDataSliceOperations)s).ListAsync(
                    resourceGroupName,
                    dataFactoryName,
                    tableName,
                    parameters),
                operations,
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the first page of data slice instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IDataSliceOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='tableName'>
        /// Required. A unique table instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. Parameters specifying how to list data slices of the table.
        /// </param>
        /// <returns>
        /// The List data slices operation response.
        /// </returns>
        public static Task<DataSliceListResponse> ListAsync(
            this IDataSliceOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string tableName,
            DataSliceListParameters parameters)
        {
            return operations.ListAsync(
                resourceGroupName,
                dataFactoryName,
                tableName,
                parameters,
                CancellationToken.None);
        }

        /// <summary>
        /// Gets the next page of data slice instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IDataSliceOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The url to the next data slices page.
        /// </param>
        /// <returns>
        /// The List data slices operation response.
        /// </returns>
        public static DataSliceListResponse ListNext(this IDataSliceOperations operations, string nextLink)
        {
            return Task.Factory.StartNew(
                s => ((IDataSliceOperations)s).ListNextAsync(nextLink),
                operations,
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the next page of data slice instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IDataSliceOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The url to the next data slices page.
        /// </param>
        /// <returns>
        /// The List data slices operation response.
        /// </returns>
        public static Task<DataSliceListResponse> ListNextAsync(this IDataSliceOperations operations, string nextLink)
        {
            return operations.ListNextAsync(nextLink, CancellationToken.None);
        }

        /// <summary>
        /// Sets status of data slices over a time range for a specific table.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IDataSliceOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='tableName'>
        /// Required. A unique table instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to set status of data slices.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static AzureOperationResponse SetStatus(
            this IDataSliceOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string tableName,
            DataSliceSetStatusParameters parameters)
        {
            return Task.Factory.StartNew(
                s => ((IDataSliceOperations)s).SetStatusAsync(
                    resourceGroupName,
                    dataFactoryName,
                    tableName,
                    parameters),
                operations,
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Sets status of data slices over a time range for a specific table.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IDataSliceOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='tableName'>
        /// Required. A unique table instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to set status of data slices.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static Task<AzureOperationResponse> SetStatusAsync(
            this IDataSliceOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string tableName,
            DataSliceSetStatusParameters parameters)
        {
            return operations.SetStatusAsync(
                resourceGroupName,
                dataFactoryName,
                tableName,
                parameters,
                CancellationToken.None);
        }
    }
}
