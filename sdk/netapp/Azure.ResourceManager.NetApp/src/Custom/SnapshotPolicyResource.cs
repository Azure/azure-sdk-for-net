// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetApp
{
    /// <summary> Backward-compat shims for SnapshotPolicyResource. </summary>
    public partial class SnapshotPolicyResource
    {
        /// <summary> Get volumes associated with snapshot policy. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppVolumeResource> GetVolumes(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported. Use GetSnapshotPolicyVolumes() instead.");
        }

        /// <summary> Get volumes associated with snapshot policy. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppVolumeResource> GetVolumesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported. Use GetSnapshotPolicyVolumesAsync() instead.");
        }
    }
}
