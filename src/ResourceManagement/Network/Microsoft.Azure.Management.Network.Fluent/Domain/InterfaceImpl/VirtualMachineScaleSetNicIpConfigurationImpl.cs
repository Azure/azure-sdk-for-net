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

    internal partial class VirtualMachineScaleSetNicIPConfigurationImpl
    {

        bool INicIPConfigurationBase.IsPrimary
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

        string IHasPrivateIPAddress.PrivateIPAddress
        {
            get
            {
                return this.PrivateIPAddress();
            }
        }

        IPVersion INicIPConfigurationBase.PrivateIPAddressVersion
        {
            get
            {
                return this.PrivateIPAddressVersion();
            }
        }

        IPAllocationMethod IHasPrivateIPAddress.PrivateIPAllocationMethod
        {
            get
            {
                return this.PrivateIPAllocationMethod();
            }
        }

        string IHasSubnet.SubnetName
        {
            get
            {
                return this.SubnetName();
            }
        }

        INetwork INicIPConfigurationBase.GetNetwork()
        {
            return this.GetNetwork();
        }

        IList<ILoadBalancerBackend> INicIPConfigurationBase.ListAssociatedLoadBalancerBackends()
        {
            return this.ListAssociatedLoadBalancerBackends();
        }

        IList<ILoadBalancerInboundNatRule> INicIPConfigurationBase.ListAssociatedLoadBalancerInboundNatRules()
        {
            return this.ListAssociatedLoadBalancerInboundNatRules();
        }
    }
}
