// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.DesktopVirtualization
{
    /// <summary>
    /// A Class representing a HostPool along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="HostPoolResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetHostPoolResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetHostPool method.
    /// </summary>
    public partial class HostPoolResource : ArmResource
    {
        /// <summary>
        /// List scaling plan associated with hostpool.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/scalingPlans</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScalingPlans_ListByHostPool</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ScalingPlanResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ScalingPlanResource> GetScalingPlansAsync(CancellationToken cancellationToken) => GetScalingPlansAsync(null, null, null, cancellationToken);

        /// <summary>
        /// List scaling plan associated with hostpool.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/scalingPlans</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScalingPlans_ListByHostPool</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ScalingPlanResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ScalingPlanResource> GetScalingPlans(CancellationToken cancellationToken) => GetScalingPlans(null, null, null, cancellationToken);

        /// <summary>
        /// List userSessions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/userSessions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UserSessions_ListByHostPool</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> OData filter expression. Valid properties for filtering are userprincipalname and sessionstate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="UserSessionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<UserSessionResource> GetUserSessionsAsync(string filter, CancellationToken cancellationToken) => GetUserSessionsAsync(filter, null, null, null, cancellationToken);

        /// <summary>
        /// List userSessions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/userSessions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UserSessions_ListByHostPool</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> OData filter expression. Valid properties for filtering are userprincipalname and sessionstate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="UserSessionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<UserSessionResource> GetUserSessions(string filter, CancellationToken cancellationToken) => GetUserSessions(filter, null, null, null, cancellationToken);
    }
}
