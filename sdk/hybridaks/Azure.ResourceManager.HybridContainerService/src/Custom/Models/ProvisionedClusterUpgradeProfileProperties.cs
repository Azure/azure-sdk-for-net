// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridContainerService.Models
{
    // The flattened GA data property was writable, but the TypeSpec output model generates a get-only property.
    [CodeGenSuppress("ControlPlaneProfile")]
    internal partial class ProvisionedClusterUpgradeProfileProperties
    {
        public ProvisionedClusterPoolUpgradeProfile ControlPlaneProfile { get; set; }
    }
}
