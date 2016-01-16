//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.DataFactories.Common.Models;
using Microsoft.Azure.Management.DataFactories.Conversion;
using Microsoft.Azure.Management.DataFactories.Models;

namespace Microsoft.Azure.Management.DataFactories
{
    /// <summary>
    /// Operations for managing data factory linkedServices.
    /// </summary>
    public interface ILinkedServiceOperations : ITypeRegistrationOperations<LinkedService>
    {
        /// <summary>
        /// Create or update a data factory linkedService.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// The name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// The parameters required to create or update a data factory
        /// linkedService.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The create or update data factory linkedService operation response.
        /// </returns>
        Task<LinkedServiceCreateOrUpdateResponse> BeginCreateOrUpdateAsync(
            string resourceGroupName,
            string dataFactoryName,
            LinkedServiceCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken);

        /// <summary>
        /// Create or update a data factory linkedService with raw JSON content.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// The name of the data factory.
        /// </param>
        /// <param name='linkedServiceName'>
        /// The name of the data factory Linked Service to be created or updated.
        /// </param>
        /// <param name='parameters'>
        /// The parameters required to create or update a data factory
        /// linkedService.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The create or update data factory linkedService operation response.
        /// </returns>
        Task<LinkedServiceCreateOrUpdateResponse> BeginCreateOrUpdateWithRawJsonContentAsync(
            string resourceGroupName,
            string dataFactoryName,
            string linkedServiceName,
            LinkedServiceCreateOrUpdateWithRawJsonContentParameters parameters,
            CancellationToken cancellationToken);

        /// <summary>
        /// Delete a data factory linkedService instance.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// A unique data factory instance name.
        /// </param>
        /// <param name='linkedServiceName'>
        /// A unique data factory linkedService name.
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
            string linkedServiceName,
            CancellationToken cancellationToken);

        /// <summary>
        /// Create or update a data factory linkedService.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// The name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// The parameters required to create or update a data factory
        /// linkedService.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The create or update data factory linkedService operation response.
        /// </returns>
        Task<LinkedServiceCreateOrUpdateResponse> CreateOrUpdateAsync(
            string resourceGroupName,
            string dataFactoryName,
            LinkedServiceCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken);

        /// <summary>
        /// Create or update a data factory linkedService with raw JSON content.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// The name of the data factory.
        /// </param>
        /// <param name='linkedServiceName'>
        /// The name of the data factory Linked Service to be created or updated.
        /// </param>
        /// <param name='parameters'>
        /// The parameters required to create or update a data factory
        /// linkedService.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The create or update data factory linkedService operation response.
        /// </returns>
        Task<LinkedServiceCreateOrUpdateResponse> CreateOrUpdateWithRawJsonContentAsync(
            string resourceGroupName,
            string dataFactoryName,
            string linkedServiceName,
            LinkedServiceCreateOrUpdateWithRawJsonContentParameters parameters,
            CancellationToken cancellationToken);

        /// <summary>
        /// Delete a data factory linkedService instance.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// A unique data factory instance name.
        /// </param>
        /// <param name='linkedServiceName'>
        /// A unique data factory linkedService name.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        Task<LongRunningOperationResponse> DeleteAsync(
            string resourceGroupName,
            string dataFactoryName,
            string linkedServiceName,
            CancellationToken cancellationToken);

        /// <summary>
        /// Gets a data factory linkedService instance.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// A unique data factory instance name.
        /// </param>
        /// <param name='linkedServiceName'>
        /// A unique data factory linkedService name.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The Get data factory linkedService operation response.
        /// </returns>
        Task<LinkedServiceGetResponse> GetAsync(
            string resourceGroupName,
            string dataFactoryName,
            string linkedServiceName,
            CancellationToken cancellationToken);

        /// <summary>
        /// Gets the status of a linked service create or update operation.
        /// </summary>
        /// <param name='operationStatusLink'>
        /// Location value returned by the Begin operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The create or update data factory linkedService operation response.
        /// </returns>
        Task<LinkedServiceCreateOrUpdateResponse> GetCreateOrUpdateStatusAsync(
            string operationStatusLink,
            CancellationToken cancellationToken);

        /// <summary>
        /// Gets the first page of linked service instances with the link to
        /// the next page.
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
        /// The List data factory linkedServices operation response.
        /// </returns>
        Task<LinkedServiceListResponse> ListAsync(
            string resourceGroupName,
            string dataFactoryName,
            CancellationToken cancellationToken);

        /// <summary>
        /// Gets the next page of linked service instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='nextLink'>
        /// The url to the next linked services page.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The List data factory linkedServices operation response.
        /// </returns>
        Task<LinkedServiceListResponse> ListNextAsync(string nextLink, CancellationToken cancellationToken);
    }
}