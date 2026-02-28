// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance
{
    // [CodeGenType] is REQUIRED: the generator produces "MaintenancePublicConfigurationData" (from the
    // PublicMaintenanceConfigurations interface), but the old API used "MaintenanceConfigurationData".
    // This cannot be done with @@clientName because the model is shared across multiple interfaces.
    // Base type override to TrackedResourceData is handled by @@hierarchyBuilding in spec client.tsp.
    [CodeGenType("MaintenancePublicConfigurationData")]
    public partial class MaintenanceConfigurationData
    {
    }
}
