// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden IsAutomaticSnapshotPolicyEnabled alias for renamed property.
// Could use @@clientName in spec but would lose the improved name.

using System.ComponentModel;

namespace Azure.ResourceManager.Storage
{
    public partial class BlobServiceData
    {
        /// <summary> Backward-compatible alias for AutomaticSnapshotPolicyEnabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.automaticSnapshotPolicyEnabled")]
        public bool? IsAutomaticSnapshotPolicyEnabled
        {
            get => AutomaticSnapshotPolicyEnabled;
            set => AutomaticSnapshotPolicyEnabled = value;
        }
    }
}
