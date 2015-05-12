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
using Hyak.Common;
using Microsoft.Azure.Management.DataFactories.Conversion;
using Microsoft.Azure.Management.DataFactories.Models;
using Microsoft.Azure.Management.DataFactories.Registration.Models;

namespace Microsoft.Azure.Management.DataFactories
{
#if ADF_INTERNAL
    /// <summary>
    /// Operations for managing data factory ActivityTypes.
    /// </summary>
    public class ActivityTypeOperations : IServiceOperations<DataFactoryManagementClient>, 
                                          IActivityTypeOperations
    {
        public DataFactoryManagementClient Client { get; private set; }

        internal ActivityTypeConverter Converter { get; private set; }

        internal ActivityTypeOperations(DataFactoryManagementClient client)
        {
            this.Client = client;
            this.Converter = new ActivityTypeConverter();
        }

        /// <summary>
        /// Delete an ActivityType instance.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='activityTypeName'>
        /// Required. The name of the activityType.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public async Task<LongRunningOperationResponse> BeginDeleteAsync(
            string resourceGroupName,
            string dataFactoryName,
            string activityTypeName,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.InternalActivityTypes.BeginDeleteAsync(
                    resourceGroupName,
                    dataFactoryName,
                    activityTypeName,
                    cancellationToken);
        }

        /// <summary>
        /// Create or update an ActivityType.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update an
        /// ActivityType definition.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The create or update ActivityType operation response.
        /// </returns>
        public async Task<ActivityTypeCreateOrUpdateResponse> CreateOrUpdateAsync(
            string resourceGroupName,
            string dataFactoryName,
            ActivityTypeCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken)
        {
            Ensure.IsNotNull(parameters, "parameters");
            Ensure.IsNotNull(parameters.ActivityType, "parameters.ActivityType");

            InternalActivityType internalActivityType = this.Converter.ToCoreType(parameters.ActivityType);

            InternalActivityTypeCreateOrUpdateResponse response =
                await this.Client.InternalClient.InternalActivityTypes.CreateOrUpdateAsync(
                    resourceGroupName,
                    dataFactoryName,
                    new InternalActivityTypeCreateOrUpdateParameters(internalActivityType));

            return new ActivityTypeCreateOrUpdateResponse(response, this.Client);
        }

        /// <summary>
        /// Create or update an ActivityType.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='activityTypeName'>
        /// Required. An ActivityType name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update an
        /// ActivityType definition.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The create or update ActivityType operation response.
        /// </returns>
        public async Task<ActivityTypeCreateOrUpdateResponse> CreateOrUpdateWithRawJsonContentAsync(
            string resourceGroupName,
            string dataFactoryName,
            string activityTypeName,
            ActivityTypeCreateOrUpdateWithRawJsonContentParameters parameters,
            CancellationToken cancellationToken)
        {
            InternalActivityTypeCreateOrUpdateResponse response = 
                await this.Client.InternalClient.InternalActivityTypes.CreateOrUpdateWithRawJsonContentAsync(
                    resourceGroupName,
                    dataFactoryName,
                    activityTypeName,
                    parameters,
                    cancellationToken);

            return new ActivityTypeCreateOrUpdateResponse(response, this.Client);
        }
        
        /// <summary>
        /// Delete an ActivityType instance.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='activityTypeName'>
        /// Required. The name of the activityType.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public async Task<LongRunningOperationResponse> DeleteAsync(
            string resourceGroupName,
            string dataFactoryName,
            string activityTypeName,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.InternalActivityTypes.DeleteAsync(
                    resourceGroupName,
                    dataFactoryName,
                    activityTypeName,
                    cancellationToken);
        }

        /// <summary>
        /// Gets an ActivityType instance.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// Required. Parameters specifying how to get an ActivityType
        /// definition.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The Get ActivityType operation response.
        /// </returns>
        public async Task<ActivityTypeGetResponse> GetAsync(
            string resourceGroupName,
            string dataFactoryName,
            ActivityTypeGetParameters parameters,
            CancellationToken cancellationToken)
        {
            InternalActivityTypeGetResponse response =
                await this.Client.InternalClient.InternalActivityTypes.GetAsync(
                    resourceGroupName,
                    dataFactoryName,
                    parameters,
                    cancellationToken);

            return new ActivityTypeGetResponse(response, this.Client);
        }

        /// <summary>
        /// Gets the first page of ActivityType instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// Required. Parameters specifying how to return a list of
        /// ActivityType definitions.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The List ActivityType operation response.
        /// </returns>
        public async Task<ActivityTypeListResponse> ListAsync(
            string resourceGroupName,
            string dataFactoryName,
            ActivityTypeListParameters parameters,
            CancellationToken cancellationToken)
        {
            InternalActivityTypeListResponse response =
                await this.Client.InternalClient.InternalActivityTypes.ListAsync(
                    resourceGroupName,
                    dataFactoryName,
                    parameters,
                    cancellationToken);

            return new ActivityTypeListResponse(response, this.Client);
        }

        /// <summary>
        /// Gets the next page of ActivityType instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='nextLink'>
        /// Required. The url to the next ActivityTypes page.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The List ActivityType operation response.
        /// </returns>
        public async Task<ActivityTypeListResponse> ListNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            // Validate
            Ensure.IsNotNull(nextLink, "nextLink");

            InternalActivityTypeListResponse response =
                await this.Client.InternalClient.InternalActivityTypes.ListNextAsync(nextLink, cancellationToken);

            return new ActivityTypeListResponse(response, this.Client);
        }
    }
#endif
}
