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
    public static class ActivityTypeOperationsExtensions
    {
        /// <summary>
        /// Delete an ActivityType instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IActivityTypeOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='activityTypeName'>
        /// Required. The name of the activityType.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static LongRunningOperationResponse BeginDelete(
            this IActivityTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string activityTypeName)
        {
            return Task.Factory.StartNew(
                s =>
                    ((IActivityTypeOperations)s).BeginDeleteAsync(resourceGroupName, dataFactoryName, activityTypeName),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Delete an ActivityType instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IActivityTypeOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='activityTypeName'>
        /// Required. The name of the activityType.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static Task<LongRunningOperationResponse> BeginDeleteAsync(
            this IActivityTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string activityTypeName)
        {
            return operations.BeginDeleteAsync(
                resourceGroupName,
                dataFactoryName,
                activityTypeName,
                CancellationToken.None);
        }

        /// <summary>
        /// Create or update an ActivityType.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IActivityTypeOperations.
        /// </param>
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
        /// <returns>
        /// The create or update ActivityType operation response.
        /// </returns>
        public static ActivityTypeCreateOrUpdateResponse CreateOrUpdate(
            this IActivityTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            ActivityTypeCreateOrUpdateParameters parameters)
        {
            return Task.Factory.StartNew(
                s =>
                    ((IActivityTypeOperations)s).CreateOrUpdateAsync(resourceGroupName, dataFactoryName, parameters),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create or update an ActivityType.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IActivityTypeOperations.
        /// </param>
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
        /// <returns>
        /// The create or update ActivityType operation response.
        /// </returns>
        public static Task<ActivityTypeCreateOrUpdateResponse> CreateOrUpdateAsync(
            this IActivityTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            ActivityTypeCreateOrUpdateParameters parameters)
        {
            return operations.CreateOrUpdateAsync(
                resourceGroupName,
                dataFactoryName,
                parameters,
                CancellationToken.None);
        }

        /// <summary>
        /// Create or update an ActivityType.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IActivityTypeOperations.
        /// </param>
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
        /// <returns>
        /// The create or update ActivityType operation response.
        /// </returns>
        public static ActivityTypeCreateOrUpdateResponse CreateOrUpdateWithRawJsonContent(
            this IActivityTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string activityTypeName,
            ActivityTypeCreateOrUpdateWithRawJsonContentParameters parameters)
        {
            return Task.Factory.StartNew(
                s =>
                    ((IActivityTypeOperations)s).CreateOrUpdateWithRawJsonContentAsync(
                        resourceGroupName,
                        dataFactoryName,
                        activityTypeName,
                        parameters),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create or update an ActivityType.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IActivityTypeOperations.
        /// </param>
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
        /// <returns>
        /// The create or update ActivityType operation response.
        /// </returns>
        public static Task<ActivityTypeCreateOrUpdateResponse> CreateOrUpdateWithRawJsonContentAsync(
            this IActivityTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string activityTypeName,
            ActivityTypeCreateOrUpdateWithRawJsonContentParameters parameters)
        {
            return operations.CreateOrUpdateWithRawJsonContentAsync(
                resourceGroupName,
                dataFactoryName,
                activityTypeName,
                parameters,
                CancellationToken.None);
        }

        /// <summary>
        /// Delete an ActivityType instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IActivityTypeOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='activityTypeName'>
        /// Required. The name of the activityType.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static LongRunningOperationResponse Delete(
            this IActivityTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string activityTypeName)
        {
            return Task.Factory.StartNew(
                s => ((IActivityTypeOperations)s).DeleteAsync(resourceGroupName, dataFactoryName, activityTypeName),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Delete an ActivityType instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IActivityTypeOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='activityTypeName'>
        /// Required. The name of the activityType.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static Task<LongRunningOperationResponse> DeleteAsync(
            this IActivityTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string activityTypeName)
        {
            return operations.DeleteAsync(resourceGroupName, dataFactoryName, activityTypeName, CancellationToken.None);
        }

        /// <summary>
        /// Gets an ActivityType instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IActivityTypeOperations.
        /// </param>
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
        /// <returns>
        /// The Get ActivityType operation response.
        /// </returns>
        public static ActivityTypeGetResponse Get(
            this IActivityTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            ActivityTypeGetParameters parameters)
        {
            return Task.Factory.StartNew(
                s => ((IActivityTypeOperations)s).GetAsync(resourceGroupName, dataFactoryName, parameters),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets an ActivityType instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IActivityTypeOperations.
        /// </param>
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
        /// <returns>
        /// The Get ActivityType operation response.
        /// </returns>
        public static Task<ActivityTypeGetResponse> GetAsync(
            this IActivityTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            ActivityTypeGetParameters parameters)
        {
            return operations.GetAsync(resourceGroupName, dataFactoryName, parameters, CancellationToken.None);
        }

        /// <summary>
        /// Gets the first page of ActivityType instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IActivityTypeOperations.
        /// </param>
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
        /// <returns>
        /// The List ActivityType operation response.
        /// </returns>
        public static ActivityTypeListResponse List(
            this IActivityTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            ActivityTypeListParameters parameters)
        {
            return Task.Factory.StartNew(
                s => ((IActivityTypeOperations)s).ListAsync(resourceGroupName, dataFactoryName, parameters),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the first page of ActivityType instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IActivityTypeOperations.
        /// </param>
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
        /// <returns>
        /// The List ActivityType operation response.
        /// </returns>
        public static Task<ActivityTypeListResponse> ListAsync(
            this IActivityTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            ActivityTypeListParameters parameters)
        {
            return operations.ListAsync(resourceGroupName, dataFactoryName, parameters, CancellationToken.None);
        }

        /// <summary>
        /// Gets the next page of ActivityType instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IActivityTypeOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The url to the next ActivityTypes page.
        /// </param>
        /// <returns>
        /// The List ActivityType operation response.
        /// </returns>
        public static ActivityTypeListResponse ListNext(this IActivityTypeOperations operations, string nextLink)
        {
            return Task.Factory.StartNew(
                s => ((IActivityTypeOperations)s).ListNextAsync(nextLink),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the next page of ActivityType instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IActivityTypeOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The url to the next ActivityTypes page.
        /// </param>
        /// <returns>
        /// The List ActivityType operation response.
        /// </returns>
        public static Task<ActivityTypeListResponse> ListNextAsync(
            this IActivityTypeOperations operations,
            string nextLink)
        {
            return operations.ListNextAsync(nextLink, CancellationToken.None);
        }
    }
}
