// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    internal partial class VirtualNetworkGatewayPropertiesFormat
    {
        // Replace the internal reference type so the flattened API preserves the released WritableSubResource property.
        /// <summary> The reference to the LocalNetworkGateway resource which represents local network site having default routes. Assign Null value in case of removing existing default site setting. </summary>
        public WritableSubResource GatewayDefaultSite { get; set; }
    }
}
