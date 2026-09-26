// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> A class representing the NetworkPrivateEndpointConnection data model. </summary>
    public partial class NetworkPrivateEndpointConnectionData
    {
        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="PrivateLinkServiceConnectionState"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use PrivateLinkServiceConnectionState instead.")]
        public NetworkPrivateLinkServiceConnectionState ConnectionState
        {
            get => PrivateLinkServiceConnectionState;
            set => PrivateLinkServiceConnectionState = value;
        }
    }
}
