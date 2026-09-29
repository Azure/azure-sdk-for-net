// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute.WorkloadManager.Models
{
    public partial class RuntimeLinkPatch
    {
        /// <summary> The mutable capacity policy for the runtime composition. </summary>
        [CodeGenMember("RuntimeLinkUpdateCapacityProfile")]
        public RuntimeLinkCapacityProfileUpdate CapacityProfile { get; set; }
    }
}
