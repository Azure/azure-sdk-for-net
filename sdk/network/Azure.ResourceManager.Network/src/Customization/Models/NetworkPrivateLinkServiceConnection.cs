// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> The network private link service connection. </summary>
    public partial class NetworkPrivateLinkServiceConnection
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
