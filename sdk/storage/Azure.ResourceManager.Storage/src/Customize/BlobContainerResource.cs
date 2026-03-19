// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds method aliases (EnableVersionLevelImmutability -> ObjectLevelWorm)
// to preserve prior GA method names. Could use @@clientName on operation but would lose new name.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Storage
{
    public partial class BlobContainerResource
    {
        // Backward-compatible overload: EnableVersionLevelImmutability renamed to ObjectLevelWorm.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation EnableVersionLevelImmutability(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => ObjectLevelWorm(waitUntil, cancellationToken);

        // Backward-compatible overload: EnableVersionLevelImmutabilityAsync renamed to ObjectLevelWormAsync.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation> EnableVersionLevelImmutabilityAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => ObjectLevelWormAsync(waitUntil, cancellationToken);
    }
}
