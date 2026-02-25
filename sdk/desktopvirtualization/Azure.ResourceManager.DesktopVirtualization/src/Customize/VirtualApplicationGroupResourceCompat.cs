// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.DesktopVirtualization.Models;

namespace Azure.ResourceManager.DesktopVirtualization
{
    public partial class VirtualApplicationGroupResource
    {
        /// <summary> List start menu items in the given application group. </summary>
        /// <param name="pageSize"> Number of items per page. </param>
        /// <param name="isDescending"> Indicates whether the collection is descending. </param>
        /// <param name="initialSkip"> Initial number of items to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DesktopVirtualizationStartMenuItem" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DesktopVirtualizationStartMenuItem> GetStartMenuItemsAsync(int? pageSize = default, bool? isDescending = default, int? initialSkip = default, CancellationToken cancellationToken = default)
            => GetAllAsync(pageSize, isDescending, initialSkip, cancellationToken);

        /// <summary> List start menu items in the given application group. </summary>
        /// <param name="pageSize"> Number of items per page. </param>
        /// <param name="isDescending"> Indicates whether the collection is descending. </param>
        /// <param name="initialSkip"> Initial number of items to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DesktopVirtualizationStartMenuItem" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DesktopVirtualizationStartMenuItem> GetStartMenuItems(int? pageSize = default, bool? isDescending = default, int? initialSkip = default, CancellationToken cancellationToken = default)
            => GetAll(pageSize, isDescending, initialSkip, cancellationToken);
    }
}
