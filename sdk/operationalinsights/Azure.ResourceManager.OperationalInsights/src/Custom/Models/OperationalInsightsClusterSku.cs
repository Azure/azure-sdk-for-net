// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.OperationalInsights.Models
{
    /// <summary> The cluster sku definition. </summary>
    public partial class OperationalInsightsClusterSku
    {
        /// <summary> Initializes a new instance of OperationalInsightsClusterSku. </summary>
        public OperationalInsightsClusterSku()
        {
        }

        /// <summary> Initializes a new instance of OperationalInsightsClusterSku. </summary>
        /// <param name="capacity"> The capacity value. </param>
        /// <param name="name"> The name of the SKU. </param>
        internal OperationalInsightsClusterSku(OperationalInsightsClusterCapacity? capacity, OperationalInsightsClusterSkuName? name)
        {
            Capacity = capacity;
            Name = name;
        }

        /// <summary> The capacity value. </summary>
        public OperationalInsightsClusterCapacity? Capacity { get; set; }
        /// <summary> The name of the SKU. </summary>
        public OperationalInsightsClusterSkuName? Name { get; set; }
    }
}
