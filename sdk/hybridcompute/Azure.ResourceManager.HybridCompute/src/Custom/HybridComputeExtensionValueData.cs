// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridCompute
{
    // Preserve the public parameterless constructor from the previous GA SDK.
    [CodeGenSuppress("HybridComputeExtensionValueData")]
    public partial class HybridComputeExtensionValueData
    {
        /// <summary> Initializes a new instance of <see cref="HybridComputeExtensionValueData"/>. </summary>
        public HybridComputeExtensionValueData()
        {
        }
    }
}