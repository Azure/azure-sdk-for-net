// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance.Models
{
    // Rename ImpactType to MaintenanceImpactType to maintain backward compatibility
    [CodeGenType("ImpactType")]
    public readonly partial struct MaintenanceImpactType
    {
    }
}
