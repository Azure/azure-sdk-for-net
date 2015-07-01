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
using Microsoft.Azure.Management.DataFactories.Common.Models;
using Microsoft.Azure.Management.DataFactories.Conversion;
using Microsoft.Azure.Management.DataFactories.Core;
using Microsoft.Azure.Management.DataFactories.Registration.Models;

namespace Microsoft.Azure.Management.DataFactories
{
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
            return await this.Client.InternalClient.ActivityTypes.BeginDeleteAsync(
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

            Core.Registration.Models.ActivityType internalActivityType = this.Converter.ToCoreType(parameters.ActivityType);

            Core.Registration.Models.ActivityTypeCreateOrUpdateResponse response =
                await this.Client.InternalClient.ActivityTypes.CreateOrUpdateAsync(
                    resourceGroupName,
                    dataFactoryName,
                    new Core.Registration.Models.ActivityTypeCreateOrUpdateParameters(internalActivityType));

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
            Ensure.IsNotNull(parameters, "parameters");

            Core.Registration.Models.ActivityTypeCreateOrUpdateWithRawJsonContentParameters internalParameters =
                new Core.Registration.Models.ActivityTypeCreateOrUpdateWithRawJsonContentParameters(parameters.Content);

            Core.Registration.Models.ActivityTypeCreateOrUpdateResponse response = 
                await this.Client.InternalClient.ActivityTypes.CreateOrUpdateWithRawJsonContentAsync(
                    resourceGroupName,
                    dataFactoryName,
                    activityTypeName,
                    internalParameters,
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
            return await this.Client.InternalClient.ActivityTypes.DeleteAsync(
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
            Ensure.IsNotNull(parameters, "parameters");

            Core.Registration.Models.ActivityTypeGetParameters internalParameters =
                new Core.Registration.Models.ActivityTypeGetParameters(parameters.RegistrationScope,
                    parameters.ActivityTypeName) {Resolved = parameters.Resolved};

            Core.Registration.Models.ActivityTypeGetResponse response =
                await this.Client.InternalClient.ActivityTypes.GetAsync(
                    resourceGroupName,
                    dataFactoryName,
                    internalParameters,
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
            Ensure.IsNotNull(parameters, "parameters");

            Core.Registration.Models.ActivityTypeListParameters internalParameters =
                new Core.Registration.Models.ActivityTypeListParameters()
                {
                    RegistrationScope = parameters.RegistrationScope,
                    ActivityTypeName = parameters.ActivityTypeName,
                    Resolved = parameters.Resolved
                };

            Core.Registration.Models.ActivityTypeListResponse response =
                await this.Client.InternalClient.ActivityTypes.ListAsync(
                    resourceGroupName,
                    dataFactoryName,
                    internalParameters,
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

            Core.Registration.Models.ActivityTypeListResponse response =
                await this.Client.InternalClient.ActivityTypes.ListNextAsync(nextLink, cancellationToken);

            return new ActivityTypeListResponse(response, this.Client);
        }
    }
}
