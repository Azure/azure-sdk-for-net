// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal abstract partial class NicIPConfigurationBaseImpl<ParentImplT,IParentT> 
    {
        /// <summary>
        /// Gets the name of the subnet associated with this resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasSubnet.SubnetName
        {
            get
            {
                return this.SubnetName();
            }
        }

        /// <summary>
        /// Gets the resource ID of the virtual network whose subnet is associated with this resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasSubnet.NetworkId
        {
            get
            {
                return this.NetworkId();
            }
        }

        /// <summary>
        /// Gets the private IP address associated with this resource.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IHasPrivateIPAddress.PrivateIPAddress
        {
            get
            {
                return this.PrivateIPAddress();
            }
        }

        /// <summary>
        /// Gets the private IP address allocation method within the associated subnet.
        /// </summary>
        Models.IPAllocationMethod Microsoft.Azure.Management.Network.Fluent.IHasPrivateIPAddress.PrivateIPAllocationMethod
        {
            get
            {
                return this.PrivateIPAllocationMethod() as Models.IPAllocationMethod;
            }
        }

        /// <return>The virtual network associated with this IP configuration.</return>
        Microsoft.Azure.Management.Network.Fluent.INetwork Microsoft.Azure.Management.Network.Fluent.INicIPConfigurationBase.GetNetwork()
        {
            return this.GetNetwork() as Microsoft.Azure.Management.Network.Fluent.INetwork;
        }

        /// <summary>
        /// Gets true if this is the primary ip configuration.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.INicIPConfigurationBase.IsPrimary
        {
            get
            {
                return this.IsPrimary();
            }
        }

        /// <return>The load balancer backends associated with this network interface IP configuration.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> Microsoft.Azure.Management.Network.Fluent.INicIPConfigurationBase.ListAssociatedLoadBalancerBackends()
        {
            return this.ListAssociatedLoadBalancerBackends() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend>;
        }

        /// <summary>
        /// Gets private IP address version.
        /// </summary>
        Models.IPVersion Microsoft.Azure.Management.Network.Fluent.INicIPConfigurationBase.PrivateIPAddressVersion
        {
            get
            {
                return this.PrivateIPAddressVersion() as Models.IPVersion;
            }
        }

        /// <return>The load balancer inbound NAT rules associated with this network interface IP configuration.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatRule> Microsoft.Azure.Management.Network.Fluent.INicIPConfigurationBase.ListAssociatedLoadBalancerInboundNatRules()
        {
            return this.ListAssociatedLoadBalancerInboundNatRules() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatRule>;
        }
    }
}