// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> The scale type applicable to the sku. </summary>
    [CodeGenModel("ComputeResourceSkuCapacityScaleType")]
    public enum ComputeResourceSkuCapacityScaleType
    {
        /// <summary> None. </summary>
        None,
        /// <summary> Automatic. </summary>
        Automatic,
        /// <summary> Manual. </summary>
        Manual
    }
}
