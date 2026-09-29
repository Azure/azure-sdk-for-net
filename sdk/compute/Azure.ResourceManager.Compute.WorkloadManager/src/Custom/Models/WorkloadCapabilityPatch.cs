// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute.WorkloadManager.Models
{
    /// <summary> Mutable properties of a capability. </summary>
    [CodeGenType("CapabilityPatch")]
    public partial class WorkloadCapabilityPatch
    {
        /// <summary> The version selection policy for the capability. </summary>
        [CodeGenMember("CapabilityUpdateVersionPolicy")]
        public WorkloadCapabilityVersionPolicy? VersionPolicy { get; set; }
    }
}
