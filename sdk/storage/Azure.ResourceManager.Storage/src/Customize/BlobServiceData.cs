// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage
{
    public partial class BlobServiceData
    {
        /// <summary> Backward-compatible alias for AutomaticSnapshotPolicyEnabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsAutomaticSnapshotPolicyEnabled
        {
            get => AutomaticSnapshotPolicyEnabled;
            set => AutomaticSnapshotPolicyEnabled = value;
        }
    }
}
