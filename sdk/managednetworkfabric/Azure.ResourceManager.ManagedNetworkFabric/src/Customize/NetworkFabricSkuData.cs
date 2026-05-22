// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class NetworkFabricSkuData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricSkuData"/>. </summary>
        public NetworkFabricSkuData()
        {
            Properties = new NetworkFabricSkuProperties();
        }

        /// <summary> Type of Network Fabric SKU. </summary>
        public NetworkFabricSkuType? TypePropertiesType => Type;

        /// <summary> Maximum number of compute racks available for this Network Fabric SKU. </summary>
        [CodeGenMember("MaxComputeRacks")]
        public int? MaxComputeRacks { get; set; }

        /// <summary> Maximum number of servers available for this Network Fabric SKU. </summary>
        [CodeGenMember("MaximumServerCount")]
        public int? MaximumServerCount { get; set; }
    }
}
