// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp
{
    public partial class CapacityPoolData
    {
        // Backward-compat: GA shipped CustomThroughputMibps as float?, but the spec models it as
        // int. The generated property is renamed via @@clientName to CustomThroughputMibpsInt,
        // and this float?-typed shim restores the GA surface.
        /// <summary> Maximum throughput in MiB/s. </summary>
        public float? CustomThroughputMibps
        {
            get => CustomThroughputMibpsInt;
            set => CustomThroughputMibpsInt = value.HasValue ? (int?)value.Value : null;
        }
    }
}
