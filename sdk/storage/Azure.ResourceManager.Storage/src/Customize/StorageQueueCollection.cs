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
        /// <summary> Gets a list of all the queues under the specified storage account. </summary>
        /// <param name="maxpagesize"> Optional, a maximum number of queues that should be included in a list queue response. </param>
        /// <param name="filter"> Optional. When specified, only the queues with a name starting with the given filter will be listed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="StorageQueueResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Pageable<StorageQueueResource> GetAll(int? maxpagesize, string filter, CancellationToken cancellationToken)
            => GetAll(maxpagesize?.ToString(), filter, cancellationToken);

        // Backward-compatible overload with int maxpagesize: Lists all queues.
        /// <summary> Gets a list of all the queues under the specified storage account. </summary>
        /// <param name="maxpagesize"> Optional, a maximum number of queues that should be included in a list queue response. </param>
        /// <param name="filter"> Optional. When specified, only the queues with a name starting with the given filter will be listed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="StorageQueueResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual AsyncPageable<StorageQueueResource> GetAllAsync(int? maxpagesize, string filter, CancellationToken cancellationToken)
            => GetAllAsync(maxpagesize?.ToString(), filter, cancellationToken);
    }
}
