// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        public virtual AsyncPageable<DesktopVirtualizationPrivateLinkResourceData> GetPrivateLinkResourcesAsync(int? pageSize, bool? isDescending, int? initialSkip, CancellationToken cancellationToken)
            => GetByWorkspaceAsync(pageSize, isDescending, initialSkip, cancellationToken);

        /// <summary> List the private link resources available for this workspace. </summary>
        /// <param name="pageSize"> Number of items per page. </param>
        /// <param name="isDescending"> Indicates whether the collection is descending. </param>
        /// <param name="initialSkip"> Initial number of items to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DesktopVirtualizationPrivateLinkResourceData" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DesktopVirtualizationPrivateLinkResourceData> GetPrivateLinkResources(int? pageSize, bool? isDescending, int? initialSkip, CancellationToken cancellationToken)
            => GetByWorkspace(pageSize, isDescending, initialSkip, cancellationToken);
    }
}
