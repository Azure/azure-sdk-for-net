// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Compute.Skus;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> The type of restrictions. </summary>
    [CodeGenType("ComputeResourceSkuRestrictionsType")]
    public enum ComputeResourceSkuRestrictionsType
    {
        /// <summary> Location. </summary>
        Location,
        /// <summary> Zone. </summary>
        Zone
    }
}
