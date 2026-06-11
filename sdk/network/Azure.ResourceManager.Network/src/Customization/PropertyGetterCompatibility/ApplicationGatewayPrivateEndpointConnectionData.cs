// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public partial class ApplicationGatewayPrivateEndpointConnectionData
    {
        public global::Azure.ResourceManager.Network.Models.NetworkPrivateLinkServiceConnectionState ConnectionState
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
