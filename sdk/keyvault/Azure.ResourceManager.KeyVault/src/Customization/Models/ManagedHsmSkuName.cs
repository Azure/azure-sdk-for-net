// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.KeyVault.Models
{
    // Kept as a closed enum for backward compatibility with previous stable releases.
    // Existing members must keep their order; new SKUs are appended.
    /// <summary> SKU of the managed HSM Pool. </summary>
    [CodeGenType("ManagedHsmSkuNameV2")]
    public enum ManagedHsmSkuName
    {
        /// <summary> Standard_B1 SKU. </summary>
        StandardB1,
        /// <summary> Custom_B32 SKU. </summary>
        CustomB32,
        /// <summary> Custom_B6 SKU. </summary>
        CustomB6,
        /// <summary> Custom_C42 SKU. </summary>
        CustomC42,
        /// <summary> Custom_C10 SKU. </summary>
        CustomC10,
        /// <summary> Standard_B1v2 SKU. </summary>
        StandardB1v2,
        /// <summary> Standard_B5v2 SKU. </summary>
        StandardB5v2,
        /// <summary> Standard_B10v2 SKU. </summary>
        StandardB10v2,
        /// <summary> Standard_B15v2 SKU. </summary>
        StandardB15v2,
        /// <summary> Standard_B20v2 SKU. </summary>
        StandardB20v2
    }
}
