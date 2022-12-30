// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    /// <summary>
    /// A class representing a collection of <see cref="ApiManagementSubscriptionResource" /> and their operations.
    /// Each <see cref="ApiManagementSubscriptionResource" /> in the collection will belong to the same instance of <see cref="ApiManagementServiceResource" />.
    /// To get an <see cref="ApiManagementSubscriptionCollection" /> instance call the GetApiManagementSubscriptions method from an instance of <see cref="ApiManagementServiceResource" />.
    /// </summary>
    public partial class ApiManagementSubscriptionCollection : ArmCollection, IEnumerable<ApiManagementSubscriptionResource>, IAsyncEnumerable<ApiManagementSubscriptionResource>
    {
        /// <summary>
        /// Creates or updates the subscription of specified user to the specified product.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/subscriptions/{sid}
        /// Operation Id: Subscription_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="sid"> Subscription entity Identifier. The entity represents the association between a user and a product in API Management. </param>
        /// <param name="content"> Create parameters. </param>
        /// <param name="notify">
        /// Notify change in Subscription State.
        ///  - If false, do not send any email notification for change of state of subscription
        ///  - If true, send email notification of change of state of subscription
        /// </param>
        /// <param name="ifMatch"> ETag of the Entity. Not required when creating an entity, but required when updating an entity. </param>
        /// <param name="appType"> Determines the type of application which send the create user request. Default is legacy publisher portal. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sid"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sid"/> or <paramref name="content"/> is null. </exception>
        public virtual async Task<ArmOperation<ApiManagementSubscriptionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string sid, ApiManagementSubscriptionCreateOrUpdateContent content, bool? notify = null, ETag? ifMatch = null, AppType? appType = null, CancellationToken cancellationToken = default) =>
            await CreateOrUpdateAsync(waitUntil, new ApiManagementSubscriptionCollectionCreateOrUpdateOptions(sid, content)
            {
                Notify = notify,
                IfMatch = ifMatch,
                AppType = appType
            }, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates or updates the subscription of specified user to the specified product.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/subscriptions/{sid}
        /// Operation Id: Subscription_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="sid"> Subscription entity Identifier. The entity represents the association between a user and a product in API Management. </param>
        /// <param name="content"> Create parameters. </param>
        /// <param name="notify">
        /// Notify change in Subscription State.
        ///  - If false, do not send any email notification for change of state of subscription
        ///  - If true, send email notification of change of state of subscription
        /// </param>
        /// <param name="ifMatch"> ETag of the Entity. Not required when creating an entity, but required when updating an entity. </param>
        /// <param name="appType"> Determines the type of application which send the create user request. Default is legacy publisher portal. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sid"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sid"/> or <paramref name="content"/> is null. </exception>
        public virtual ArmOperation<ApiManagementSubscriptionResource> CreateOrUpdate(WaitUntil waitUntil, string sid, ApiManagementSubscriptionCreateOrUpdateContent content, bool? notify = null, ETag? ifMatch = null, AppType? appType = null, CancellationToken cancellationToken = default) =>
            CreateOrUpdate(waitUntil, new ApiManagementSubscriptionCollectionCreateOrUpdateOptions(sid, content)
            {
                Notify = notify,
                IfMatch = ifMatch,
                AppType = appType
            }, cancellationToken);

        /// <summary>
        /// Lists all subscriptions of the API Management service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/subscriptions
        /// Operation Id: Subscription_List
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| stateComment | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| ownerId | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| scope | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| userId | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| productId | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| state | filter | eq |     |&lt;/br&gt;| user | expand |     |     |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementSubscriptionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementSubscriptionResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new ApiManagementSubscriptionCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip
            }, cancellationToken);

        /// <summary>
        /// Lists all subscriptions of the API Management service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/subscriptions
        /// Operation Id: Subscription_List
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| stateComment | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| ownerId | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| scope | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| userId | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| productId | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| state | filter | eq |     |&lt;/br&gt;| user | expand |     |     |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementSubscriptionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementSubscriptionResource> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetAll(new ApiManagementSubscriptionCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip
            }, cancellationToken);
    }
}
