// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    // The prior GA SDK implemented IEnumerable<BlobContainerResource> on this collection type.
    // The new generator no longer emits that interface. These explicit implementations throw
    // NotSupportedException to preserve compile-compat; callers should use GetAll/GetAllAsync instead.
    public partial class BlobContainerCollection : IEnumerable<BlobContainerResource>, IAsyncEnumerable<BlobContainerResource>
    {
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerator<BlobContainerResource> IEnumerable<BlobContainerResource>.GetEnumerator()
        {
            throw new NotSupportedException("This collection does not support enumerating directly. Use GetAllAsync or GetAll on the parent resource instead.");
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotSupportedException("This collection does not support enumerating directly. Use GetAllAsync or GetAll on the parent resource instead.");
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        IAsyncEnumerator<BlobContainerResource> IAsyncEnumerable<BlobContainerResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This collection does not support enumerating directly. Use GetAllAsync or GetAll on the parent resource instead.");
        }

        /// <summary> Lists all containers. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BlobContainerResource> GetAll(string maxpagesize, string filter, BlobContainerState? include, CancellationToken cancellationToken)
            => new PageableWrapper<ListContainerItem, BlobContainerResource>(
                Client.GetBlobServiceResource(Id).GetAll(maxpagesize, filter, include, cancellationToken),
                item => Client.GetBlobContainerResource(item.Id));

        /// <summary> Lists all containers. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BlobContainerResource> GetAllAsync(string maxpagesize, string filter, BlobContainerState? include, CancellationToken cancellationToken)
            => new AsyncPageableWrapper<ListContainerItem, BlobContainerResource>(
                Client.GetBlobServiceResource(Id).GetAllAsync(maxpagesize, filter, include, cancellationToken),
                item => Client.GetBlobContainerResource(item.Id));

        /// <summary> Lists all containers. Backward-compatible overload with int maxpagesize. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BlobContainerResource> GetAll(int? maxpagesize, string filter, BlobContainerState? include, CancellationToken cancellationToken)
            => GetAll(maxpagesize?.ToString(), filter, include, cancellationToken);

        /// <summary> Lists all containers. Backward-compatible overload with int maxpagesize. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BlobContainerResource> GetAllAsync(int? maxpagesize, string filter, BlobContainerState? include, CancellationToken cancellationToken)
            => GetAllAsync(maxpagesize?.ToString(), filter, include, cancellationToken);
    }
}
