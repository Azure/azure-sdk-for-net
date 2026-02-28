// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance.Models
{
    // Rename UpdateStatus to MaintenanceUpdateStatus to maintain backward compatibility
    [CodeGenType("UpdateStatus")]
    public readonly partial struct MaintenanceUpdateStatus
    {
    }
}
