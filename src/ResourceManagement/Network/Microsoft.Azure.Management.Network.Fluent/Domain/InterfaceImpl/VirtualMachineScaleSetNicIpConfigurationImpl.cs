// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal partial class VirtualMachineScaleSetNicIpConfigurationImpl
    {

        bool INicIpConfigurationBase.IsPrimary
        {
            get
            {
                return this.IsPrimary();
            }
        }

        string IHasSubnet.NetworkId
        {
            get
            {
                return this.NetworkId();
            }
        }

        string IHasPrivateIpAddress.PrivateIpAddress
        {
            get
            {
                return this.PrivateIpAddress();
            }
        }

        IPVersion INicIpConfigurationBase.PrivateIpAddressVersion
        {
            get
            {
                return this.PrivateIpAddressVersion();
            }
        }

        IPAllocationMethod IHasPrivateIpAddress.PrivateIpAllocationMethod
        {
            get
            {
                return this.PrivateIpAllocationMethod();
            }
        }

        string IHasSubnet.SubnetName
        {
            get
            {
                return this.SubnetName();
            }
        }

        INetwork INicIpConfigurationBase.GetNetwork()
        {
            return this.GetNetwork();
        }

        IList<ILoadBalancerBackend> INicIpConfigurationBase.ListAssociatedLoadBalancerBackends()
        {
            return this.ListAssociatedLoadBalancerBackends();
        }

        IList<ILoadBalancerInboundNatRule> INicIpConfigurationBase.ListAssociatedLoadBalancerInboundNatRules()
        {
            return this.ListAssociatedLoadBalancerInboundNatRules();
        }
    }
}
