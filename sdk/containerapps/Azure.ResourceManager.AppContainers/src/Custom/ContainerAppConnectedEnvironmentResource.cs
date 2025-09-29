// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.AppContainers
{
    public partial class ContainerAppConnectedEnvironmentResource
    {
        /// <summary>
        /// Patches a Managed Environment. Only patching of tags is supported currently
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/connectedEnvironments/{connectedEnvironmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConnectedEnvironments_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-01-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerAppConnectedEnvironmentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerAppConnectedEnvironmentResource> Update(CancellationToken cancellationToken = default)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Patches a Managed Environment. Only patching of tags is supported currently
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/connectedEnvironments/{connectedEnvironmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConnectedEnvironments_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-01-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerAppConnectedEnvironmentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ContainerAppConnectedEnvironmentResource>> UpdateAsync(CancellationToken cancellationToken = default)
        {
            throw new InvalidOperationException();
        }
    }
}
