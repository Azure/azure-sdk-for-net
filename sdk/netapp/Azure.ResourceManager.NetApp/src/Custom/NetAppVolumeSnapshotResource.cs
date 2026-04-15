// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager;

namespace Azure.ResourceManager.NetApp
{
    /// <summary> Backward-compat stubs for NetAppVolumeSnapshotResource. </summary>
    public partial class NetAppVolumeSnapshotResource : ArmResource
    {
        /// <summary> Update a snapshot. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NetAppVolumeSnapshotResource> Update(WaitUntil waitUntil, NetAppVolumeSnapshotData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is not supported. Use Update(WaitUntil, NetAppVolumeSnapshotPatch, CancellationToken) instead.");
        }

        /// <summary> Update a snapshot. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NetAppVolumeSnapshotResource>> UpdateAsync(WaitUntil waitUntil, NetAppVolumeSnapshotData data, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This overload is not supported. Use UpdateAsync(WaitUntil, NetAppVolumeSnapshotPatch, CancellationToken) instead.");
        }
    }
}
