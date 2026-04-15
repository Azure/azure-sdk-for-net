// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance
{
    // [CodeGenType("ConfigurationAssignmentCollection")] renames the generated ConfigurationAssignmentCollection to
    // MaintenanceConfigurationAssignmentCollection for consistency with all other types in this SDK
    // (e.g., MaintenanceApplyUpdateCollection, MaintenanceConfigurationCollection).
    [CodeGenType("ConfigurationAssignmentCollection")]
    public partial class MaintenanceConfigurationAssignmentCollection
    {
    }
}
