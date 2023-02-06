// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.DataProtectionBackup.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.DataProtectionBackup
{
    /// <summary>
    /// A Class representing a ResourceGuard along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="ResourceGuardResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetResourceGuardResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetResourceGuard method.
    /// </summary>
    public partial class ResourceGuardResource
    {
        /// <summary>
        /// Updates a ResourceGuard resource belonging to a resource group. For example, updating tags for a resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/resourceGuards/{resourceGuardsName}
        /// Operation Id: ResourceGuards_Patch
        /// </summary>
        /// <param name="patch"> Request body for operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release. Please use UpdateAsync(ResourceGuardPatch patch, CancellationToken cancellationToken = default) instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<ResourceGuardResource>> UpdateAsync(DataProtectionBackupPatch patch, CancellationToken cancellationToken = default)
        {
            ResourceGuardPatch input = new ResourceGuardPatch();
            foreach (var tag in patch.Tags)
            {
                input.Tags.Add(tag);
            }
            return await UpdateAsync(input, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates a ResourceGuard resource belonging to a resource group. For example, updating tags for a resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/resourceGuards/{resourceGuardsName}
        /// Operation Id: ResourceGuards_Patch
        /// </summary>
        /// <param name="patch"> Request body for operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release. Please use Update(ResourceGuardPatch patch, CancellationToken cancellationToken = default) instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<ResourceGuardResource> Update(DataProtectionBackupPatch patch, CancellationToken cancellationToken = default)
        {
            ResourceGuardPatch input = new ResourceGuardPatch();
            foreach (var tag in patch.Tags)
            {
                input.Tags.Add(tag);
            }
            return Update(input, cancellationToken);
        }
    }
}
