// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridCompute.Models
{
    // Backward-compat justification: the GA SDK exposed the service-specific HybridComputeLocation type name.
    [CodeGenType("LocationData")]
    public partial class HybridComputeLocation
    {
    }
}
