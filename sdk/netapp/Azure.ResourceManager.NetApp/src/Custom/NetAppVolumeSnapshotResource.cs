// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: old API had Update(WaitUntil, NetAppVolumeSnapshotData),
// new generated code uses Update(WaitUntil, NetAppVolumeSnapshotPatch).

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetApp
{
    public partial class NetAppVolumeSnapshotResource
    {
        // Backward-compat: Update accepting NetAppVolumeSnapshotData.
        /// <summary> Update a snapshot. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NetAppVolumeSnapshotResource> Update(WaitUntil waitUntil, NetAppVolumeSnapshotData data, CancellationToken cancellationToken = default)
        {
            var patch = new Models.NetAppVolumeSnapshotPatch();
            return Update(waitUntil, patch, cancellationToken);
        }

        // Backward-compat: UpdateAsync accepting NetAppVolumeSnapshotData.
        /// <summary> Update a snapshot. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NetAppVolumeSnapshotResource>> UpdateAsync(WaitUntil waitUntil, NetAppVolumeSnapshotData data, CancellationToken cancellationToken = default)
        {
            var patch = new Models.NetAppVolumeSnapshotPatch();
            return await UpdateAsync(waitUntil, patch, cancellationToken).ConfigureAwait(false);
        }
    }
}
