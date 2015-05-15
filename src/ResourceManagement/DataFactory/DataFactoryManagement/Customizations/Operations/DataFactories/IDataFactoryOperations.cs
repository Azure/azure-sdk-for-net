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
    /// Operations for managing data factories.
    /// </summary>
    public interface IDataFactoryOperations
    {
        /// <summary>
        /// Create or update a data factory.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// The parameters required to create or update a data factory.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The create or update data factory operation response.
        /// </returns>
        Task<DataFactoryCreateOrUpdateResponse> BeginCreateOrUpdateAsync(
            string resourceGroupName,
            DataFactoryCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken);

        /// <summary>
        /// Create or update a data factory.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// The parameters required to create or update a data factory.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The create or update data factory operation response.
        /// </returns>
        Task<DataFactoryCreateOrUpdateResponse> CreateOrUpdateAsync(
            string resourceGroupName,
            DataFactoryCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken);

        /// <summary>
        /// Delete a data factory instance.
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
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        Task<AzureOperationResponse> DeleteAsync(
            string resourceGroupName,
            string dataFactoryName,
            CancellationToken cancellationToken);

        /// <summary>
        /// Gets a data factory instance.
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
        /// The Get data factory operation response.
        /// </returns>
        Task<DataFactoryGetResponse> GetAsync(
            string resourceGroupName,
            string dataFactoryName,
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
        /// The create or update data factory operation response.
        /// </returns>
        Task<DataFactoryCreateOrUpdateResponse> GetCreateOrUpdateStatusAsync(
            string operationStatusLink,
            CancellationToken cancellationToken);

        /// <summary>
        /// Gets the first page of data factory instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factories.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The List data factories operation response.
        /// </returns>
        Task<DataFactoryListResponse> ListAsync(string resourceGroupName, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the next page of data factory instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='nextLink'>
        /// The url to the next data factories page.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The List data factories operation response.
        /// </returns>
        Task<DataFactoryListResponse> ListNextAsync(string nextLink, CancellationToken cancellationToken);
    }
}
