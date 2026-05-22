// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class NetworkDeviceSkuData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkDeviceSkuData"/>. </summary>
        /// <param name="model"> Model of the network device. </param>
        public NetworkDeviceSkuData(string model)
        {
            Properties = new NetworkDeviceSkuProperties(model);
            Model = model;
        }

        /// <summary> Model of the network device. </summary>
        [CodeGenMember("Model")]
        public string Model { get; set; }

        /// <summary> Manufacturer of the network device. </summary>
        [CodeGenMember("Manufacturer")]
        public string Manufacturer { get; set; }
    }
}
