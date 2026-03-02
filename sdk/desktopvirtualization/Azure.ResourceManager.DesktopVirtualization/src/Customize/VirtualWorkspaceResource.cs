// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: The PrivateLinkResources interface in the TypeSpec defines two
// pageable list operations — listByHostPool (on HostPool) and listByWorkspace (on Workspace).
// Ideally we would use @@clientName to rename both to "GetPrivateLinkResources" so each
// lands on its respective resource client with the original method name. However, the C#
// management emitter derives a shared helper type name from the interface name + client
// method name (e.g. "PrivateLinkResourcesGetPrivateLinkResourcesAsyncCollectionResultOfT").
// When both operations share the same client name, the emitter attempts to register
// duplicate dictionary keys and crashes. Until the emitter learns to disambiguate by
// enclosing resource type, we leave the generated names as-is (GetByWorkspace / GetByHostPool)
// and provide these forwarding overloads to preserve the old GetPrivateLinkResources name
// so existing callers are not broken.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.DesktopVirtualization.Models;

namespace Azure.ResourceManager.DesktopVirtualization
{
    public partial class VirtualWorkspaceResource
    {
        /// <summary> List the private link resources available for this workspace. </summary>
        /// <param name="pageSize"> Number of items per page. </param>
        /// <param name="isDescending"> Indicates whether the collection is descending. </param>
        /// <param name="initialSkip"> Initial number of items to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DesktopVirtualizationPrivateLinkResourceData" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DesktopVirtualizationPrivateLinkResourceData> GetPrivateLinkResourcesAsync(int? pageSize = default, bool? isDescending = default, int? initialSkip = default, CancellationToken cancellationToken = default)
            => GetByWorkspaceAsync(pageSize, isDescending, initialSkip, cancellationToken);

        /// <summary> List the private link resources available for this workspace. </summary>
        /// <param name="pageSize"> Number of items per page. </param>
        /// <param name="isDescending"> Indicates whether the collection is descending. </param>
        /// <param name="initialSkip"> Initial number of items to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DesktopVirtualizationPrivateLinkResourceData" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DesktopVirtualizationPrivateLinkResourceData> GetPrivateLinkResources(int? pageSize = default, bool? isDescending = default, int? initialSkip = default, CancellationToken cancellationToken = default)
            => GetByWorkspace(pageSize, isDescending, initialSkip, cancellationToken);
    }
}
