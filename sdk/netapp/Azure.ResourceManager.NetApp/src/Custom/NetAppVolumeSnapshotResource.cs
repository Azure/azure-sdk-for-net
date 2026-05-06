// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: old API had Update(WaitUntil, NetAppVolumeSnapshotData),
// new generated code uses Update(WaitUntil, NetAppVolumeSnapshotPatch).
//
// Q: "We are not consuming `data` input — what is this method for?"
// A: NetAppVolumeSnapshotData has no fields users can set on update (it derives from
//    ResourceData; the only mutable surface is tags, which the snapshot PATCH does not
//    accept either — see Generated/Models/NetAppVolumeSnapshotPatch.cs which carries no
//    properties). The legacy v1.15 signature was effectively a no-op update too. We keep
//    the signature so code that called the GA Update(data) overload still compiles, but
//    the `data` argument is intentionally ignored — the body just dispatches an empty
//    PATCH which matches the GA semantics for snapshot update.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetApp
{
    public partial class NetAppVolumeSnapshotResource
    {
        // Backward-compat: Update accepting NetAppVolumeSnapshotData. `data` is intentionally
        // unused — see file-level comment above for why.
        /// <summary> Update a snapshot. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NetAppVolumeSnapshotResource> Update(WaitUntil waitUntil, NetAppVolumeSnapshotData data, CancellationToken cancellationToken = default)
        {
            _ = data;
            var patch = new Models.NetAppVolumeSnapshotPatch();
            return Update(waitUntil, patch, cancellationToken);
        }

        // Backward-compat: UpdateAsync accepting NetAppVolumeSnapshotData. `data` is intentionally
        // unused — see file-level comment above for why.
        /// <summary> Update a snapshot. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NetAppVolumeSnapshotResource>> UpdateAsync(WaitUntil waitUntil, NetAppVolumeSnapshotData data, CancellationToken cancellationToken = default)
        {
            _ = data;
            var patch = new Models.NetAppVolumeSnapshotPatch();
            return await UpdateAsync(waitUntil, patch, cancellationToken).ConfigureAwait(false);
        }
    }
}
