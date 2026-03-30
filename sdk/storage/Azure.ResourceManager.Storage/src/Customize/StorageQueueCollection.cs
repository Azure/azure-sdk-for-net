// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Restores GetAll/GetAllAsync overloads and IEnumerable/IAsyncEnumerable
// implementations matching the prior GA surface. The new generator moves list operations to
// the parent QueueServiceResource, so these overloads delegate there via PageableWrapper.

using System.ComponentModel;
using System.Threading;
using Azure.Core;

namespace Azure.ResourceManager.Storage
{
    public partial class StorageQueueCollection
    {
        // Backward-compatible overload with int maxpagesize: Lists all queues.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Pageable<StorageQueueResource> GetAll(int? maxpagesize, string filter, CancellationToken cancellationToken)
            => GetAll(maxpagesize?.ToString(), filter, cancellationToken);

        // Backward-compatible overload with int maxpagesize: Lists all queues.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual AsyncPageable<StorageQueueResource> GetAllAsync(int? maxpagesize, string filter, CancellationToken cancellationToken)
            => GetAllAsync(maxpagesize?.ToString(), filter, cancellationToken);
    }
}
