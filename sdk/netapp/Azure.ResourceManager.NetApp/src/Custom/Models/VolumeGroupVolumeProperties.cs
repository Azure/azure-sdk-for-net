// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    // Compatibility shim for the former volume group volume model name. Deserialization is
    // handled by the base type NetAppVolumeGroupVolume; this shim is excluded from
    // the IJsonModel/IPersistableModel pattern check via the ExceptionList in
    // tests/ResourceTests/ModelReaderWriterImplementationValidation.Exception.cs because
    // adding IJsonModel<VolumeGroupVolumeProperties> would recurse infinitely through the
    // base type's ModelReaderWriter.Write(this, ...) dispatch (runtime type is the shim).
    /// <summary> Volume group volume properties (legacy alias of <see cref="NetAppVolumeGroupVolume"/>). </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class VolumeGroupVolumeProperties : NetAppVolumeGroupVolume
    {
        // Legacy ctor: subnetId as string.
        /// <summary> Initializes a new instance of <see cref="VolumeGroupVolumeProperties"/>. </summary>
        public VolumeGroupVolumeProperties(string creationToken, long usageThreshold, string subnetId)
            : base(creationToken, usageThreshold, new ResourceIdentifier(subnetId))
        {
        }

        // Legacy ctor: subnetId as ResourceIdentifier.
        /// <summary> Initializes a new instance of <see cref="VolumeGroupVolumeProperties"/>. </summary>
        public VolumeGroupVolumeProperties(string creationToken, long usageThreshold, ResourceIdentifier subnetId)
            : base(creationToken, usageThreshold, subnetId)
        {
        }

        // Formerly ProximityPlacementGroup; renamed to ProximityPlacementGroupId.
        /// <summary> Compatibility alias for <see cref="NetAppVolumeGroupVolume.ProximityPlacementGroupId"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier ProximityPlacementGroup
        {
            get => ProximityPlacementGroupId;
            set => ProximityPlacementGroupId = value;
        }
    }
}
