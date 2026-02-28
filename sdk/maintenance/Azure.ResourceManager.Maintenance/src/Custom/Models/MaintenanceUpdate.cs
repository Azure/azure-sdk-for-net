// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance.Models
{
    // Rename Update to MaintenanceUpdate to maintain backward compatibility
    [CodeGenType("Update")]
    public partial class MaintenanceUpdate
    {
    }
}
