// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Maps.Models
{
    // Backward compat: S0 and S1 were removed in API version 2025-10-01-preview but must
    // be preserved to avoid breaking existing callers of the GA SDK (1.1.0).
    // MapsSkuName is an extensible enum so adding the values back is safe.
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
