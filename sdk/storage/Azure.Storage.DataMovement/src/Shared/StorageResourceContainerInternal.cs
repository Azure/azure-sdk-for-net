// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Middle class between the public type and implementation class.
    /// Gives internal hook methods to protected methods of
    /// <see cref="StorageResourceContainer"/>, allowing for internal
    /// package use as well as testing access.
    /// </summary>
    internal abstract class StorageResourceContainerInternal : StorageResourceContainer
    {
        internal IAsyncEnumerable<StorageResource> GetStorageResourcesInternalAsync(
            CancellationToken cancellationToken = default)
            => GetStorageResourcesAsync(cancellationToken);

        internal StorageResourceItem GetStorageResourceReferenceInternal(string path)
            => GetStorageResourceReference(path);

        internal Task CreateIfNotExistsInternalAsync(CancellationToken cancellationToken = default)
            => CreateIfNotExistsAsync(cancellationToken);

        internal StorageResourceContainer GetChildStorageResourceContainerInternal(string path)
            => GetChildStorageResourceContainer(path);
    }
}
