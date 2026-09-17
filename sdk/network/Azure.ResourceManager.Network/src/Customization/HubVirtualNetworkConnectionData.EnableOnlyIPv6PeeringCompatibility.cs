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
        [Obsolete("This property is deprecated. Use EnableOnlyIPv6PeeringValue instead.")]
        public EnableOnlyIPv6PeeringState? EnableOnlyIPv6Peering
        {
            get => EnableOnlyIPv6PeeringValue.HasValue
                ? EnableOnlyIPv6PeeringValue.Value
                    ? EnableOnlyIPv6PeeringState.Enabled
                    : EnableOnlyIPv6PeeringState.Disabled
                : default;
            set => EnableOnlyIPv6PeeringValue = value.HasValue
                ? value.Value == EnableOnlyIPv6PeeringState.Enabled
                : default;
        }
    }
}
