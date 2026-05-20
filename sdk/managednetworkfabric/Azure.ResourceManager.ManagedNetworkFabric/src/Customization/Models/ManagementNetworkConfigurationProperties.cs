// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> Configuration to be used to setup the management network. </summary>
    public partial class ManagementNetworkConfigurationProperties : ManagementNetworkConfigurationPatchableProperties
    {
        /// <summary> Initializes a new instance of <see cref="ManagementNetworkConfigurationProperties"/>. </summary>
        /// <param name="infrastructureVpnConfiguration"> VPN Configuration properties. </param>
        /// <param name="workloadVpnConfiguration"> VPN Configuration properties. </param>
        public ManagementNetworkConfigurationProperties(VpnConfigurationPatchableProperties infrastructureVpnConfiguration, VpnConfigurationPatchableProperties workloadVpnConfiguration)
            : base(infrastructureVpnConfiguration, workloadVpnConfiguration)
        {
        }
    }
}
