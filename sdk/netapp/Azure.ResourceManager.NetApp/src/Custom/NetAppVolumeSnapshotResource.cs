// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetApp
{
    public partial class NetAppVolumeSnapshotResource
    {
        // Backward-compat only: v1.15 exposed Update overloads accepting NetAppVolumeSnapshotData,
        // but the current service PATCH shape has no writable fields for that data type.
        // Keep the signatures for ApiCompat, but fail explicitly instead of sending a no-op PATCH.
        /// <summary> Update a snapshot. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported because NetAppVolumeSnapshotData is not accepted by the snapshot PATCH operation. Use Update(WaitUntil, NetAppVolumeSnapshotPatch, CancellationToken) instead.", false)]
        public virtual ArmOperation<NetAppVolumeSnapshotResource> Update(WaitUntil waitUntil, NetAppVolumeSnapshotData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported because NetAppVolumeSnapshotData is not accepted by the snapshot PATCH operation. Use Update(WaitUntil, NetAppVolumeSnapshotPatch, CancellationToken) instead.");
        }

        /// <summary> Update a snapshot. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported because NetAppVolumeSnapshotData is not accepted by the snapshot PATCH operation. Use UpdateAsync(WaitUntil, NetAppVolumeSnapshotPatch, CancellationToken) instead.", false)]
        public virtual Task<ArmOperation<NetAppVolumeSnapshotResource>> UpdateAsync(WaitUntil waitUntil, NetAppVolumeSnapshotData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported because NetAppVolumeSnapshotData is not accepted by the snapshot PATCH operation. Use UpdateAsync(WaitUntil, NetAppVolumeSnapshotPatch, CancellationToken) instead.");
        }
    }
}
