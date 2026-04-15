// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Backward-compat shims for NetAppVolumeRevertContent. </summary>
    public partial class NetAppVolumeRevertContent
    {
        /// <summary> Resource identifier used to identify the Snapshot. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SnapshotId
        {
            get => SnapshotResourceId?.ToString();
            set => SnapshotResourceId = value is string s ? new ResourceIdentifier(s) : null;
        }
    }
}
