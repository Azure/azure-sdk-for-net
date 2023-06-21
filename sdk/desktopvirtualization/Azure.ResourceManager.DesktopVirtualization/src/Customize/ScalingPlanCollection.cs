// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.DesktopVirtualization
{
    /// <summary>
    /// A class representing a collection of <see cref="ScalingPlanResource" /> and their operations.
    /// Each <see cref="ScalingPlanResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="ScalingPlanCollection" /> instance call the GetScalingPlans method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class ScalingPlanCollection : ArmCollection, IEnumerable<ScalingPlanResource>, IAsyncEnumerable<ScalingPlanResource>
    {
        /// <summary>
        /// List scaling plans.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/scalingPlans</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScalingPlans_ListByResourceGroup</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ScalingPlanResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ScalingPlanResource> GetAllAsync(CancellationToken cancellationToken) => GetAllAsync(null, null, null, cancellationToken);

        /// <summary>
        /// List scaling plans.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/scalingPlans</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScalingPlans_ListByResourceGroup</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ScalingPlanResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ScalingPlanResource> GetAll(CancellationToken cancellationToken) => GetAll(null, null, null, cancellationToken);
    }
}
