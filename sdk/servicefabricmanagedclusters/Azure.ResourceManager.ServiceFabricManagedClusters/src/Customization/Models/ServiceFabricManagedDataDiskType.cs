// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ServiceFabricManagedClusters.Models
{
    public readonly partial struct ServiceFabricManagedDataDiskType
    {
        /// <summary> Premium SSD V2 locally redundant storage. Best for production and performance sensitive workloads that consistently require low latency and high IOPS and throughput. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceFabricManagedDataDiskType PremiumV2LRS { get; } = new ServiceFabricManagedDataDiskType("PremiumV2_LRS");

        /// <summary> Premium SSD zone redundant storage. Best for production workloads that need storage resiliency against zone failures. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceFabricManagedDataDiskType PremiumZRS { get; } = new ServiceFabricManagedDataDiskType("Premium_ZRS");
    }
}