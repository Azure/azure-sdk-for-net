// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class LoadBalancerHealthPerRulePerBackendAddress
    {
        /// <summary> Resource ID of the Network Interface IP Configuration. </summary>
        [WirePath("networkInterfaceIPConfigurationId")]
        public ResourceIdentifier NetworkInterfaceIPConfigurationResourceId => NetworkInterfaceIPConfigurationId?.Id;
    }
}
