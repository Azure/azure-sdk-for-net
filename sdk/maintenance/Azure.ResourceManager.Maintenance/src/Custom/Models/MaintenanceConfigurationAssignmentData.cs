// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance.Models
{
    // Move MaintenanceConfigurationAssignmentData to Models namespace for backward compatibility.
    // The old autorest-generated SDK had this type in the Models namespace.
    // The new TypeSpec generator puts resource data classes in the root namespace.
    [CodeGenType("MaintenanceConfigurationAssignmentData")]
    public partial class MaintenanceConfigurationAssignmentData
    {
    }
}
