// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Maps.Models
{
    /// <summary> The name of the SKU, in standard format (such as G2). </summary>
    public readonly partial struct MapsSkuName
    {
        /// <summary> S0. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MapsSkuName S0 { get; } = new MapsSkuName("S0");
        /// <summary> S1. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MapsSkuName S1 { get; } = new MapsSkuName("S1");
    }
}
