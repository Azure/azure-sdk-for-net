// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Restores GetAll/GetAllAsync overloads and IEnumerable/IAsyncEnumerable
// implementations matching the prior GA surface. The new generator moves list operations to
// the parent QueueServiceResource, so these overloads delegate there via PageableWrapper.

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class StorageQueueCollection : IEnumerable<StorageQueueResource>, IAsyncEnumerable<StorageQueueResource>
    {
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerator<StorageQueueResource> IEnumerable<StorageQueueResource>.GetEnumerator()
            => GetAll((string)null, null, default).GetEnumerator();

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerator IEnumerable.GetEnumerator()
            => GetAll((string)null, null, default).GetEnumerator();

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        IAsyncEnumerator<StorageQueueResource> IAsyncEnumerable<StorageQueueResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAllAsync((string)null, null, cancellationToken).GetAsyncEnumerator(cancellationToken);

        /// <summary> Lists all queues. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<StorageQueueResource> GetAll(string maxpagesize, string filter, CancellationToken cancellationToken)
            => new PageableWrapper<ListQueue, StorageQueueResource>(
                Client.GetQueueServiceResource(Id).GetAll(maxpagesize, filter, cancellationToken),
                item => Client.GetStorageQueueResource(item.Id));

        /// <summary> Lists all queues. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<StorageQueueResource> GetAllAsync(string maxpagesize, string filter, CancellationToken cancellationToken)
            => new AsyncPageableWrapper<ListQueue, StorageQueueResource>(
                Client.GetQueueServiceResource(Id).GetAllAsync(maxpagesize, filter, cancellationToken),
                item => Client.GetStorageQueueResource(item.Id));

        /// <summary> Lists all queues. Backward-compatible overload with int maxpagesize. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<StorageQueueResource> GetAll(int? maxpagesize, string filter, CancellationToken cancellationToken)
            => GetAll(maxpagesize?.ToString(), filter, cancellationToken);

        /// <summary> Lists all queues. Backward-compatible overload with int maxpagesize. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<StorageQueueResource> GetAllAsync(int? maxpagesize, string filter, CancellationToken cancellationToken)
            => GetAllAsync(maxpagesize?.ToString(), filter, cancellationToken);
    }
}
