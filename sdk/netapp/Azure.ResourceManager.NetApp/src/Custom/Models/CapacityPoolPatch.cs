// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward-compat: GA shipped CustomThroughputMibps as float?, but the spec models it as
    // int (see NetApp.Management.tsp). The generated property is renamed via @@clientName to
    // CustomThroughputMibpsInt, and this float?-typed shim restores the v1.15 surface.
    // A spec change can't fix this — TypeSpec has no way to declare two properties (int +
    // float?) bound to the same wire field, so the type-bridging must live in C#.
    public partial class CapacityPoolPatch
    {
        /// <summary> Maximum throughput in MiB/s (legacy float? alias for <see cref="CustomThroughputMibpsInt"/>). </summary>
        public float? CustomThroughputMibps
        {
            get => CustomThroughputMibpsInt;
            set => CustomThroughputMibpsInt = value.HasValue ? (int?)value.Value : null;
        }
    }
}
