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
    /// <summary>
    /// Operations for managing data slices.
    /// </summary>
    public interface IDataSliceOperations
    {
        /// <summary>
        /// Gets the first page of data slice instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// A unique data factory instance name.
        /// </param>
        /// <param name='tableName'>
        /// A unique table instance name.
        /// </param>
        /// <param name='parameters'>
        /// Parameters specifying how to list data slices of the table.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The List data slices operation response.
        /// </returns>
        Task<DataSliceListResponse> ListAsync(
            string resourceGroupName,
            string dataFactoryName,
            string tableName,
            DataSliceListParameters parameters,
            CancellationToken cancellationToken);

        /// <summary>
        /// Gets the next page of data slice instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='nextLink'>
        /// The url to the next data slices page.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The List data slices operation response.
        /// </returns>
        Task<DataSliceListResponse> ListNextAsync(string nextLink, CancellationToken cancellationToken);

        /// <summary>
        /// Sets status of data slices over a time range for a specific table.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// A unique data factory instance name.
        /// </param>
        /// <param name='tableName'>
        /// A unique table instance name.
        /// </param>
        /// <param name='parameters'>
        /// The parameters required to set status of data slices.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        Task<AzureOperationResponse> SetStatusAsync(
            string resourceGroupName,
            string dataFactoryName,
            string tableName,
            DataSliceSetStatusParameters parameters,
            CancellationToken cancellationToken);
    }
}
