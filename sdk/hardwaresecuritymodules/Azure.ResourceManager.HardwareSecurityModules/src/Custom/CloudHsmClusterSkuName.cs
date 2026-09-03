// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HardwareSecurityModules.Models
{
    /// <summary> Sku name of the Cloud HSM Cluster. </summary>
    [CodeGenType("CloudHsmClusterSkuName")]
    public enum CloudHsmClusterSkuName
    {
        /// <summary> Standard_B1 SKU. </summary>
        StandardB1,
        /// <summary> Standard B10 SKU. </summary>
        StandardB10,
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
