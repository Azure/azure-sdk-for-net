// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance
{
    // Rename ApplyUpdateData to MaintenanceApplyUpdateData to maintain backward compatibility
    [CodeGenType("ApplyUpdateData")]
    public partial class MaintenanceApplyUpdateData
    {
    }
}
