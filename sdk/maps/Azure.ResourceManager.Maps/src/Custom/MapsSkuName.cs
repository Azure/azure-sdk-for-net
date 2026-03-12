// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Maps.Models
{
    public readonly partial struct MapsSkuName
    {
        /// <summary> S0. </summary>
        public static MapsSkuName S0 { get; } = new MapsSkuName("S0");
        /// <summary> S1. </summary>
        public static MapsSkuName S1 { get; } = new MapsSkuName("S1");
    }
}
