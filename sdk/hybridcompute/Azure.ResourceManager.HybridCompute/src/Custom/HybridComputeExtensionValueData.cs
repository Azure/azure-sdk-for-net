// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.HybridCompute
{
    // Backward-compat justification: the GA extension value data model exposed a public parameterless constructor.
    public partial class HybridComputeExtensionValueData
    {
        /// <summary> Initializes a new instance of <see cref="HybridComputeExtensionValueData"/>. </summary>
        public HybridComputeExtensionValueData()
        {
        }
    }
}
