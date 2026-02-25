// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;

namespace Azure.ResourceManager.DesktopVirtualization.Mocking
{
    public partial class MockableDesktopVirtualizationSubscriptionResource : ArmResource
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="HostPoolResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<HostPoolResource> GetHostPoolsAsync(CancellationToken cancellationToken) => GetHostPoolsAsync(null, null, null, cancellationToken);

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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="HostPoolResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<HostPoolResource> GetHostPools(CancellationToken cancellationToken) => GetHostPools(null, null, null, cancellationToken);

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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ScalingPlanResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ScalingPlanResource> GetScalingPlansAsync(CancellationToken cancellationToken) => GetScalingPlansAsync(null, null, null, cancellationToken);

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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ScalingPlanResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ScalingPlanResource> GetScalingPlans(CancellationToken cancellationToken) => GetScalingPlans(null, null, null, cancellationToken);
    }
}
