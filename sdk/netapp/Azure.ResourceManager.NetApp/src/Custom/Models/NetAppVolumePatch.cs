// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
using System.ComponentModel;
using Azure.ResourceManager.Models;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Volume patch resource. </summary>
    public partial class NetAppVolumePatch : TrackedResourceData
    {
        /// <summary> DataProtection type volumes include an object containing details of the replication. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VolumePatchPropertiesDataProtection DataProtection { get; set; }

        /// <summary> DataProtection type volumes include an object containing details of the replication. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier SnapshotPolicyId
        {
            get => DataProtection is null ? default : (DataProtection.SnapshotPolicyId != null ? new ResourceIdentifier(DataProtection.SnapshotPolicyId) : null);
            set
            {
                if (DataProtection is null)
                    DataProtection = new VolumePatchPropertiesDataProtection();
                DataProtection.SnapshotPolicyId = value?.ToString();
            }
        }
    }
}
