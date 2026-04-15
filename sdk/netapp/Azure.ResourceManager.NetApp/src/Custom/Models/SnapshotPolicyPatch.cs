// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Patch for snapshot policy. </summary>
    public partial class SnapshotPolicyPatch
    {
        /// <summary> Initializes a new instance of <see cref="SnapshotPolicyPatch"/>. </summary>
        /// <param name="location"> The location. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SnapshotPolicyPatch(AzureLocation location) { Location = location.ToString(); }
    }
}
