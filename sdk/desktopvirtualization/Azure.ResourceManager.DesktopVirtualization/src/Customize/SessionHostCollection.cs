// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Collections.Generic;
using System.Threading;

namespace Azure.ResourceManager.DesktopVirtualization
{
    /// <summary>
    /// A class representing a collection of <see cref="SessionHostResource" /> and their operations.
    /// Each <see cref="SessionHostResource" /> in the collection will belong to the same instance of <see cref="HostPoolResource" />.
    /// To get a <see cref="SessionHostCollection" /> instance call the GetSessionHosts method from an instance of <see cref="HostPoolResource" />.
    /// </summary>
    public partial class SessionHostCollection : ArmCollection, IEnumerable<SessionHostResource>, IAsyncEnumerable<SessionHostResource>
    {
        /// <summary>
        /// List sessionHosts.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/sessionHosts</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SessionHosts_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SessionHostResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SessionHostResource> GetAllAsync(CancellationToken cancellationToken) => GetAllAsync(null, null, null, cancellationToken);

        /// <summary>
        /// List sessionHosts.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/sessionHosts</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SessionHosts_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SessionHostResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SessionHostResource> GetAll(CancellationToken cancellationToken) => GetAll(null, null, null, cancellationToken);
    }
}
