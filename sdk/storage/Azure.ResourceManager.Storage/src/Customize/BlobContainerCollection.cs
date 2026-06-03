// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Restores GetAll/GetAllAsync overloads and IEnumerable/IAsyncEnumerable
// implementations matching the prior GA surface. The new generator moves list operations to
// the parent BlobServiceResource, so these overloads delegate there via PageableWrapper.

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    // The prior GA SDK implemented IEnumerable<BlobContainerResource> on this collection type.
    // The new generator no longer emits that interface. These explicit implementations delegate
    // to the backward-compat GetAll/GetAllAsync overloads below.
    public partial class BlobContainerCollection
    {
        // Backward-compatible overload with int maxpagesize: Lists all containers.
        /// <summary> Lists all containers and does not support a prefix like data plane. Also SRP today does not return continuation token. </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="filter"> Optional. When specified, only container names starting with the filter will be listed. </param>
        /// <param name="include"> Optional, used to include the properties for soft deleted blob containers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="BlobContainerResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Pageable<BlobContainerResource> GetAll(int? maxpagesize, string filter, BlobContainerState? include, CancellationToken cancellationToken)
            => GetAll(maxpagesize?.ToString(), filter, include, cancellationToken);

        // Backward-compatible overload with int maxpagesize: Lists all containers.
        /// <summary> Lists all containers and does not support a prefix like data plane. Also SRP today does not return continuation token. </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="filter"> Optional. When specified, only container names starting with the filter will be listed. </param>
        /// <param name="include"> Optional, used to include the properties for soft deleted blob containers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="BlobContainerResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual AsyncPageable<BlobContainerResource> GetAllAsync(int? maxpagesize, string filter, BlobContainerState? include, CancellationToken cancellationToken)
            => GetAllAsync(maxpagesize?.ToString(), filter, include, cancellationToken);
    }
}
