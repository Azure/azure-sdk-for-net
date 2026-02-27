// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance
{
    // Rename ApplyUpdateCollection to MaintenanceApplyUpdateCollection to maintain backward compatibility
    [CodeGenType("ApplyUpdateCollection")]
    public partial class MaintenanceApplyUpdateCollection
    {
    }
}
