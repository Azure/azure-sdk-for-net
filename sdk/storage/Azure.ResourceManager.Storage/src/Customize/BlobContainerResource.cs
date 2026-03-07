// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Storage
{
    public partial class BlobContainerResource
    {
        /// <summary> EnableVersionLevelImmutability renamed to ObjectLevelWorm. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation EnableVersionLevelImmutability(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => ObjectLevelWorm(waitUntil, cancellationToken);

        /// <summary> EnableVersionLevelImmutabilityAsync renamed to ObjectLevelWormAsync. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation> EnableVersionLevelImmutabilityAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => ObjectLevelWormAsync(waitUntil, cancellationToken);
    }
}
