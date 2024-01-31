// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.DesktopVirtualization.Models;

namespace Azure.ResourceManager.DesktopVirtualization
{
    /// <summary>
    /// A Class representing a SessionHost along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="SessionHostResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetSessionHostResource method.
    /// Otherwise you can get one from its parent resource <see cref="HostPoolResource" /> using the GetSessionHost method.
    /// </summary>
    public partial class SessionHostResource : ArmResource
    {
        /// <summary>
        /// Update a session host.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/sessionHosts/{sessionHostName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SessionHosts_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> Object containing SessionHost definitions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SessionHostResource>> UpdateAsync(SessionHostPatch patch, CancellationToken cancellationToken) => await UpdateAsync(patch, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Update a session host.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/sessionHosts/{sessionHostName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SessionHosts_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> Object containing SessionHost definitions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SessionHostResource> Update(SessionHostPatch patch, CancellationToken cancellationToken) => Update(patch, null, cancellationToken);
    }
}
