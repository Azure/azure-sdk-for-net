// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridCompute.Models
{
    // Rename the generated HybridComputeLicenseProfileUpdate back to HybridComputeLicenseProfilePatch
    // to preserve backward compatibility with the 1.0.0 GA API surface.
    [CodeGenType("HybridComputeLicenseProfileUpdate")]
    public partial class HybridComputeLicenseProfilePatch
    {
    }
}
