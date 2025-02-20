// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Collections.Generic;
using System.Threading;

namespace Azure.ResourceManager.DesktopVirtualization
{
    /// <summary>
    /// A class representing a collection of <see cref="MsixPackageResource" /> and their operations.
    /// Each <see cref="MsixPackageResource" /> in the collection will belong to the same instance of <see cref="HostPoolResource" />.
    /// To get a <see cref="MsixPackageCollection" /> instance call the GetMsixPackages method from an instance of <see cref="HostPoolResource" />.
    /// </summary>
    public partial class MsixPackageCollection : ArmCollection, IEnumerable<MsixPackageResource>, IAsyncEnumerable<MsixPackageResource>
    {
        /// <summary>
        /// List MSIX packages in hostpool.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/msixPackages</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MSIXPackages_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MsixPackageResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<MsixPackageResource> GetAllAsync(CancellationToken cancellationToken) => GetAllAsync(null, null, null, cancellationToken);

        /// <summary>
        /// List MSIX packages in hostpool.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/msixPackages</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MSIXPackages_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MsixPackageResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<MsixPackageResource> GetAll(CancellationToken cancellationToken) => GetAll(null, null, null, cancellationToken);
    }
}
