// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ServiceFabricManagedClusters.Models
{
    public readonly partial struct ServiceFabricManagedDataDiskType
    {
        // The generated members use normalized acronym casing, but earlier versions exposed
        // all-caps LRS/ZRS aliases. Keep these hidden aliases for API compatibility.
        /// <summary> Premium SSD V2 locally redundant storage. Best for production and performance sensitive workloads that consistently require low latency and high IOPS and throughput. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceFabricManagedDataDiskType PremiumV2LRS { get; } = ServiceFabricManagedDataDiskType.PremiumV2Lrs;

        /// <summary> Premium SSD zone redundant storage. Best for production workloads that need storage resiliency against zone failures. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceFabricManagedDataDiskType PremiumZRS { get; } = ServiceFabricManagedDataDiskType.PremiumZrs;
    }
}
