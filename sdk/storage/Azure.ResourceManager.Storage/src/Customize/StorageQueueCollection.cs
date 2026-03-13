// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Restores GetAll/GetAllAsync overloads and IEnumerable/IAsyncEnumerable
// implementations matching prior GA surface.
// TODO: Generator should support @@markAsPageable or custom return types for list operations.

using System;
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
        IAsyncEnumerator<StorageQueueResource> IAsyncEnumerable<StorageQueueResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This collection does not support enumerating directly. Use GetAllAsync or GetAll on the parent resource instead.");
        }

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
