// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class QueryInboundNatRulePortMappingContent
    {
        /// <summary> NetworkInterfaceIPConfiguration set in load balancer backend address. </summary>
        [WirePath("ipConfiguration")]
        public ResourceIdentifier IPConfigurationId
        {
            get => IpConfiguration;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
