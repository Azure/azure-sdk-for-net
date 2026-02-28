// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance
{
    // Rename MaintenancePublicConfigurationData to MaintenanceConfigurationData to maintain backward compatibility.
    // Base type override to TrackedResourceData is handled by @@hierarchyBuilding in spec client.tsp.
    [CodeGenType("MaintenancePublicConfigurationData")]
    public partial class MaintenanceConfigurationData
    {
    }
}
