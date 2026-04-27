// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp
{
    public partial class VolumeData
    {
        // Backward-compat shim: prior SDK exposed this property as `SnapshotDirectoryVisible`.
        /// <summary> If enabled (true) the volume will contain a read-only snapshot directory which provides access to each of the volume's snapshots. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? SnapshotDirectoryVisible
        {
            get => IsSnapshotDirectoryVisible;
            set => IsSnapshotDirectoryVisible = value;
        }
    }
}
