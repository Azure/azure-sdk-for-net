// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumePatch : TrackedResourceData
    {
        /// <summary> DataProtection type volumes include an object containing details of the replication. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppVolumePatchDataProtection DataProtection { get; set; }
        /// <summary> Snapshot Policy ResourceId. </summary>
        public ResourceIdentifier SnapshotPolicyId
        {
            get => DataProtection is null ? default : DataProtection.SnapshotPolicyId;
            set
            {
                if (DataProtection is null)
                    DataProtection = new NetAppVolumePatchDataProtection();
                DataProtection.SnapshotPolicyId = value;
            }
        }
    }
}
