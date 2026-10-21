// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    public partial class BackendAddressPoolData
    {
        /// <summary> An array of references to inbound NAT rules that use this backend address pool. </summary>
        [CodeGenMember("InboundNatRules")]
        [WirePath("properties.inboundNatRules")]
        public IReadOnlyList<WritableSubResource> InboundNatRules
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new BackendAddressPoolPropertiesFormat();
                }
                return Properties.InboundNatRules;
            }
        }

        /// <summary> An array of references to load balancing rules that use this backend address pool. </summary>
        [CodeGenMember("LoadBalancingRules")]
        [WirePath("properties.loadBalancingRules")]
        public IReadOnlyList<WritableSubResource> LoadBalancingRules
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new BackendAddressPoolPropertiesFormat();
                }
                return Properties.LoadBalancingRules;
            }
        }

        /// <summary> An array of references to outbound rules that use this backend address pool. </summary>
        [CodeGenMember("OutboundRules")]
        [WirePath("properties.outboundRules")]
        public IReadOnlyList<WritableSubResource> OutboundRules
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new BackendAddressPoolPropertiesFormat();
                }
                return Properties.OutboundRules;
            }
        }
    }
}
