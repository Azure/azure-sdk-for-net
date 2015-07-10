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
using Microsoft.Azure.Management.DataFactories.Registration.Models;

namespace Microsoft.Azure.Management.DataFactories
{
    public interface IComputeTypeOperations
    {
        /// <summary>
        /// Delete a ComputeType instance.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// The name of the data factory.
        /// </param>
        /// <param name='computeTypeName'>
        /// The name of the computeType.
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
            string computeTypeName,
            CancellationToken cancellationToken);

        /// <summary>
        /// Create or update a ComputeType.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// The name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// The parameters required to create or update a ComputeType
        /// definition.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The create or update ComputeType operation response.
        /// </returns>
        Task<ComputeTypeCreateOrUpdateResponse> CreateOrUpdateAsync(
            string resourceGroupName,
            string dataFactoryName,
            ComputeTypeCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken);

        /// <summary>
        /// Create or update a ComputeType.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// The name of the data factory.
        /// </param>
        /// <param name='computeTypeName'>
        /// A ComputeType name.
        /// </param>
        /// <param name='parameters'>
        /// The parameters required to create or update a ComputeType
        /// definition.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The create or update ComputeType operation response.
        /// </returns>
        Task<ComputeTypeCreateOrUpdateResponse> CreateOrUpdateWithRawJsonContentAsync(
            string resourceGroupName,
            string dataFactoryName,
            string computeTypeName,
            ComputeTypeCreateOrUpdateWithRawJsonContentParameters parameters,
            CancellationToken cancellationToken);

        /// <summary>
        /// Delete a ComputeType instance.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// The name of the data factory.
        /// </param>
        /// <param name='computeTypeName'>
        /// The name of the computeType.
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
            string computeTypeName,
            CancellationToken cancellationToken);

        /// <summary>
        /// Gets a ComputeType instance.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// The name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// Parameters specifying how to get a ComputeType definition.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The Get ComputeType operation response.
        /// </returns>
        Task<ComputeTypeGetResponse> GetAsync(
            string resourceGroupName,
            string dataFactoryName,
            ComputeTypeGetParameters parameters,
            CancellationToken cancellationToken);

        /// <summary>
        /// Gets a ComputeType instance.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// The name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// Parameters specifying how to return a list of ComputeType
        /// definitions for a List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The List ComputeType operation response.
        /// </returns>
        Task<ComputeTypeListResponse> ListAsync(
            string resourceGroupName,
            string dataFactoryName,
            ComputeTypeListParameters parameters,
            CancellationToken cancellationToken);

        /// <summary>
        /// Gets the next page of ComputeType instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='nextLink'>
        /// The url to the next ComputeTypes page.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The List ComputeType operation response.
        /// </returns>
        Task<ComputeTypeListResponse> ListNextAsync(string nextLink, CancellationToken cancellationToken);
    }
}
