// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // The generated SKU model nests several values under Properties.
    // These flattened members preserve the shipped SDK names; removing them would drop public properties.
    public partial class NetworkFabricSkuData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricSkuData"/>. </summary>
        public NetworkFabricSkuData()
        {
            Properties = new NetworkFabricSkuProperties();
        }

        /// <summary> Maximum number of compute racks available for this Network Fabric SKU. </summary>
        [CodeGenMember("MaxComputeRacks")]
        public int? MaxComputeRacks { get; set; }

        /// <summary> Maximum number of servers available for this Network Fabric SKU. </summary>
        [CodeGenMember("MaximumServerCount")]
        public int? MaximumServerCount { get; set; }
    }
}
