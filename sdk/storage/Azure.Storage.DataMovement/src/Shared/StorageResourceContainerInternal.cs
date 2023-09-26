// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace Azure.Storage.DataMovement
{
    internal abstract class StorageResourceContainerInternal : StorageResourceContainer
    {
        internal IAsyncEnumerable<StorageResource> GetStorageResourcesInternalAsync(
            CancellationToken cancellationToken = default)
            => GetStorageResourcesAsync(cancellationToken);

        internal StorageResourceItem GetStorageResourceReferenceInternal(string path)
            => GetStorageResourceReference(path);
    }
}
