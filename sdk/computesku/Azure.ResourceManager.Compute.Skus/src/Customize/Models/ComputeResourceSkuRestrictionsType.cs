// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> The type of restrictions. </summary>
    [CodeGenModel("ComputeResourceSkuRestrictionsType")]
    public enum ComputeResourceSkuRestrictionsType
    {
        /// <summary> Location. </summary>
        Location,
        /// <summary> Zone. </summary>
        Zone
    }
}
