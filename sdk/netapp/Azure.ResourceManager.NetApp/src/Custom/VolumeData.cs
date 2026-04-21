// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp
{
    public partial class VolumeData
    {
        /// <summary> Compatibility shim for the former property name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? SnapshotDirectoryVisible
        {
            get => IsSnapshotDirectoryVisible;
            set => IsSnapshotDirectoryVisible = value;
        }
    }
}
