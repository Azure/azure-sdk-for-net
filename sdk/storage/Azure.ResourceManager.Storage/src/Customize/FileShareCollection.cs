// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Restores GetAll/GetAllAsync overloads and IEnumerable/IAsyncEnumerable
// implementations matching the prior GA surface. The new generator moves list operations to
// the parent FileServiceResource, so these overloads delegate there via PageableWrapper.

using System.ComponentModel;
using System.Threading;
using Azure.Core;

namespace Azure.ResourceManager.Storage
{
    public partial class FileShareCollection
    {
        // Backward-compatible overload with int maxpagesize: Lists all file shares.
        /// <summary> Lists all shares. </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of shares that can be included in the list. </param>
        /// <param name="filter"> Optional. When specified, only share names starting with the filter will be listed. </param>
        /// <param name="expand"> Optional, used to expand the properties within share's properties. Valid values are: deleted, snapshots. Should be passed as a string with delimiter ','. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FileShareResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Pageable<FileShareResource> GetAll(int? maxpagesize, string filter, string expand, CancellationToken cancellationToken)
            => GetAll(maxpagesize?.ToString(), filter, expand, cancellationToken);

        // Backward-compatible overload with int maxpagesize: Lists all file shares.
        /// <summary> Lists all shares. </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of shares that can be included in the list. </param>
        /// <param name="filter"> Optional. When specified, only share names starting with the filter will be listed. </param>
        /// <param name="expand"> Optional, used to expand the properties within share's properties. Valid values are: deleted, snapshots. Should be passed as a string with delimiter ','. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FileShareResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual AsyncPageable<FileShareResource> GetAllAsync(int? maxpagesize, string filter, string expand, CancellationToken cancellationToken)
            => GetAllAsync(maxpagesize?.ToString(), filter, expand, cancellationToken);
    }
}
