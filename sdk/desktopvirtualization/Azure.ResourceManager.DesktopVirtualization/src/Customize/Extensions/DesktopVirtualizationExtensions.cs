// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.DesktopVirtualization
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.DesktopVirtualization. </summary>
    public static partial class DesktopVirtualizationExtensions
    {
        /// <summary>
        /// List hostPools in subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DesktopVirtualization/hostPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>HostPools_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="HostPoolResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<HostPoolResource> GetHostPoolsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
        {
            return GetMockableDesktopVirtualizationSubscriptionResource(subscriptionResource).GetHostPoolsAsync(cancellationToken);
        }

        /// <summary>
        /// List hostPools in subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DesktopVirtualization/hostPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>HostPools_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="HostPoolResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<HostPoolResource> GetHostPools(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
        {
            return GetMockableDesktopVirtualizationSubscriptionResource(subscriptionResource).GetHostPools(cancellationToken);
        }

        /// <summary>
        /// List scaling plans in subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DesktopVirtualization/scalingPlans</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScalingPlans_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ScalingPlanResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<ScalingPlanResource> GetScalingPlansAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
        {
            return GetMockableDesktopVirtualizationSubscriptionResource(subscriptionResource).GetScalingPlansAsync(cancellationToken);
        }

        /// <summary>
        /// List scaling plans in subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DesktopVirtualization/scalingPlans</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScalingPlans_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ScalingPlanResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<ScalingPlanResource> GetScalingPlans(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
        {
            return GetMockableDesktopVirtualizationSubscriptionResource(subscriptionResource).GetScalingPlans(cancellationToken);
        }
    }
}
