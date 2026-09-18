// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the HubVirtualNetworkConnectionData type. </summary>
    public partial class HubVirtualNetworkConnectionData
    {
        /// <summary> Gets or sets the deprecated IPv6 peering state. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated. Use IsOnlyIPv6PeeringEnabled instead.")]
        public EnableOnlyIPv6PeeringState? EnableOnlyIPv6Peering
        {
            get => IsOnlyIPv6PeeringEnabled.HasValue
                ? IsOnlyIPv6PeeringEnabled.Value
                    ? EnableOnlyIPv6PeeringState.Enabled
                    : EnableOnlyIPv6PeeringState.Disabled
                : default;
            set => IsOnlyIPv6PeeringEnabled = value.HasValue
                ? value.Value == EnableOnlyIPv6PeeringState.Enabled
                : default;
        }
    }
}
