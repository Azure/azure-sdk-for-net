// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public partial class LoadBalancerHealthPerRulePerBackendAddress
    {
        // Preserve the 1.15.0 convenience wrapper; the native wire property stores a string resource ID.
        /// <summary> Gets the network interface IP configuration identified by the backend address. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkInterfaceIPConfigurationData NetworkInterfaceIPConfigurationId
            => NetworkInterfaceIPConfigurationResourceId is null ? null : new NetworkInterfaceIPConfigurationData { Id = NetworkInterfaceIPConfigurationResourceId };
    }
}
