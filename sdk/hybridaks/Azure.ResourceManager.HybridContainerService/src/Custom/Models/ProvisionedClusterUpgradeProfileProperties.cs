// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridContainerService.Models
{
    internal partial class ProvisionedClusterUpgradeProfileProperties
    {
        // The containing data model retained a public setter in the GA SDK, so the internal
        // properties envelope must remain mutable for that compatibility member.
        [CodeGenMember("ControlPlaneProfile")]
        public ProvisionedClusterPoolUpgradeProfile ControlPlaneProfile { get; set; }
    }
}
