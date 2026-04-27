// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp
{
    /// <summary> A class representing the SnapshotPolicy data model. </summary>
    public partial class SnapshotPolicyData
    {
        // Backward-compat shim: prior SDK exposed this property as `Enabled`.
        /// <summary> Snapshot policy enabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Enabled
        {
            get => IsEnabled;
            set => IsEnabled = value;
        }
    }
}
