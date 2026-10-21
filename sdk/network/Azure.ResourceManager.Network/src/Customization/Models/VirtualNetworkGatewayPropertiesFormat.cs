// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    internal partial class VirtualNetworkGatewayPropertiesFormat
    {
        // Both this WritableSubResource facade and GatewayDefaultSiteId shipped publicly in 1.17.
        // Keep one mutable reference for the two APIs and generated serialization.
        /// <summary> The reference to the LocalNetworkGateway resource which represents local network site having default routes. Assign Null value in case of removing existing default site setting. </summary>
        [CodeGenMember("GatewayDefaultSite")]
        public WritableSubResource GatewayDefaultSite { get; set; }
    }
}
