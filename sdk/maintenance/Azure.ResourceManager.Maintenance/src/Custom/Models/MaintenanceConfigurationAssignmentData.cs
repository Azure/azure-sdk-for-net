// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance.Models
{
    // The old Swagger-based SDK (1.1.3) had this type in the Models namespace.
    // The mgmt generator's ResourceVisitor forces all ResourceData types to the root namespace,
    // overriding @@clientNamespace. Use [CodeGenType] to keep backward compatibility.
    //[CodeGenType("MaintenanceConfigurationAssignmentData")]
    //public partial class MaintenanceConfigurationAssignmentData
    //{
    //}
}
