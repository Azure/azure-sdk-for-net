// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Collections.Generic;
using System.Threading;

namespace Azure.ResourceManager.DesktopVirtualization
{
    /// <summary>
    /// A class representing a collection of <see cref="VirtualDesktopResource" /> and their operations.
    /// Each <see cref="VirtualDesktopResource" /> in the collection will belong to the same instance of <see cref="VirtualApplicationGroupResource" />.
    /// To get a <see cref="VirtualDesktopCollection" /> instance call the GetVirtualDesktops method from an instance of <see cref="VirtualApplicationGroupResource" />.
    /// </summary>
    public partial class VirtualDesktopCollection : ArmCollection, IEnumerable<VirtualDesktopResource>, IAsyncEnumerable<VirtualDesktopResource>
    {
        /// <summary>
        /// List desktops.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}/desktops</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Desktops_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualDesktopResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<VirtualDesktopResource> GetAllAsync(CancellationToken cancellationToken) => GetAllAsync(null, null, null, cancellationToken);

        /// <summary>
        /// List desktops.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}/desktops</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Desktops_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualDesktopResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<VirtualDesktopResource> GetAll(CancellationToken cancellationToken) => GetAll(null, null, null, cancellationToken);
    }
}
