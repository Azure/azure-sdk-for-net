// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Generator strips underscores from @@clientName targets. These members need underscore-containing names to match baseline API.

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    public readonly partial struct DataBoxEdgeSkuName
    {
#pragma warning disable CA1707
        /// <summary> EP2_64_1VPU_W. </summary>
        public static DataBoxEdgeSkuName EP2_64_1VpuW { get; } = new DataBoxEdgeSkuName("EP2_64_1VPU_W");
        /// <summary> EP2_128_1T4_Mx1_W. </summary>
        public static DataBoxEdgeSkuName EP2_128_1T4Mx1W { get; } = new DataBoxEdgeSkuName("EP2_128_1T4_Mx1_W");
        /// <summary> EP2_256_2T4_W. </summary>
        public static DataBoxEdgeSkuName EP2_256_2T4W { get; } = new DataBoxEdgeSkuName("EP2_256_2T4_W");
        /// <summary> EP2_64_Mx1_W. </summary>
        public static DataBoxEdgeSkuName EP2_64_Mx1W { get; } = new DataBoxEdgeSkuName("EP2_64_Mx1_W");
        /// <summary> EP2_128_GPU1_Mx1_W. </summary>
        public static DataBoxEdgeSkuName EP2_128Gpu1Mx1W { get; } = new DataBoxEdgeSkuName("EP2_128_GPU1_Mx1_W");
        /// <summary> EP2_256_GPU2_Mx1. </summary>
        public static DataBoxEdgeSkuName EP2_256Gpu2Mx1 { get; } = new DataBoxEdgeSkuName("EP2_256_GPU2_Mx1");
#pragma warning restore CA1707
    }
}
