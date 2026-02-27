// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance
{
    // Rename ApplyUpdateResource to MaintenanceApplyUpdateResource to maintain backward compatibility
    [CodeGenType("ApplyUpdateResource")]
    public partial class MaintenanceApplyUpdateResource
    {
    }
}
