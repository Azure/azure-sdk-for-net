// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    /// <summary>
    /// A Class representing an ApiManagementSubscription along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct an <see cref="ApiManagementSubscriptionResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetApiManagementSubscriptionResource method.
    /// Otherwise you can get one from its parent resource <see cref="ApiManagementServiceResource" /> using the GetApiManagementSubscription method.
    /// </summary>
    public partial class ApiManagementSubscriptionResource : ArmResource
    {
        /// <summary>
        /// Updates the details of a subscription specified by its identifier.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/subscriptions/{sid}
        /// Operation Id: Subscription_Update
        /// </summary>
        /// <param name="ifMatch"> ETag of the Entity. ETag should match the current entity state from the header response of the GET request or it should be * for unconditional update. </param>
        /// <param name="patch"> Update parameters. </param>
        /// <param name="notify">
        /// Notify change in Subscription State.
        ///  - If false, do not send any email notification for change of state of subscription
        ///  - If true, send email notification of change of state of subscription
        /// </param>
        /// <param name="appType"> Determines the type of application which send the create user request. Default is legacy publisher portal. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual async Task<Response<ApiManagementSubscriptionResource>> UpdateAsync(ETag ifMatch, ApiManagementSubscriptionPatch patch, bool? notify = null, AppType? appType = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _apiManagementSubscriptionSubscriptionClientDiagnostics.CreateScope("ApiManagementSubscriptionResource.Update");
            scope.Start();
            try
            {
                var response = await _apiManagementSubscriptionSubscriptionRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ifMatch, patch, notify, appType, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ApiManagementSubscriptionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates the details of a subscription specified by its identifier.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/subscriptions/{sid}
        /// Operation Id: Subscription_Update
        /// </summary>
        /// <param name="ifMatch"> ETag of the Entity. ETag should match the current entity state from the header response of the GET request or it should be * for unconditional update. </param>
        /// <param name="patch"> Update parameters. </param>
        /// <param name="notify">
        /// Notify change in Subscription State.
        ///  - If false, do not send any email notification for change of state of subscription
        ///  - If true, send email notification of change of state of subscription
        /// </param>
        /// <param name="appType"> Determines the type of application which send the create user request. Default is legacy publisher portal. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual Response<ApiManagementSubscriptionResource> Update(ETag ifMatch, ApiManagementSubscriptionPatch patch, bool? notify = null, AppType? appType = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _apiManagementSubscriptionSubscriptionClientDiagnostics.CreateScope("ApiManagementSubscriptionResource.Update");
            scope.Start();
            try
            {
                var response = _apiManagementSubscriptionSubscriptionRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ifMatch, patch, notify, appType, cancellationToken);
                return Response.FromValue(new ApiManagementSubscriptionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
