// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridCompute.Models
{
    // Rename the generated common-type LocationData model to the service-specific name used by the AutoRest SDK.
    [CodeGenType("LocationData")]
    public partial class HybridComputeLocation
    {
    }
}
