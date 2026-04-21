// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Compatibility shim for the former volume group volume model name. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class VolumeGroupVolumeProperties : NetAppVolumeGroupVolume
    {
        /// <summary> Initializes a compatibility wrapper for the legacy constructor shape. </summary>
        public VolumeGroupVolumeProperties(string creationToken, long usageThreshold, string subnetId)
            : base(creationToken, usageThreshold, new ResourceIdentifier(subnetId))
        {
        }

        /// <summary> Initializes a compatibility wrapper for the legacy constructor shape. </summary>
        public VolumeGroupVolumeProperties(string creationToken, long usageThreshold, ResourceIdentifier subnetId)
            : base(creationToken, usageThreshold, subnetId)
        {
        }

        /// <summary> Compatibility shim for the former property name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier ProximityPlacementGroup
        {
            get => ProximityPlacementGroupId;
            set => ProximityPlacementGroupId = value;
        }
    }
}
