// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using System.Collections.Generic;

    internal partial class VirtualMachineScaleSetNetworkInterfaceImpl
    {

        IReadOnlyDictionary<string, IVirtualMachineScaleSetNicIpConfiguration> Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface.IpConfigurations
        {
            get
            {
                return this.IpConfigurations();
            }
        }

        IVirtualMachineScaleSetNicIpConfiguration Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface.PrimaryIpConfiguration
        {
            get
            {
                return this.PrimaryIpConfiguration();
            }
        }

        IList<string> Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.AppliedDnsServers
        {
            get
            {
                return this.AppliedDnsServers();
            }
        }

        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.MacAddress
        {
            get
            {
                return this.MacAddress();
            }
        }

        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.VirtualMachineId
        {
            get
            {
                return this.VirtualMachineId();
            }
        }

        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.InternalDnsNameLabel
        {
            get
            {
                return this.InternalDnsNameLabel();
            }
        }

        bool Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.IsIpForwardingEnabled
        {
            get
            {
                return this.IsIpForwardingEnabled();
            }
        }

        IPAllocationMethod Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.PrimaryPrivateIpAllocationMethod
        {
            get
            {
                return this.PrimaryPrivateIpAllocationMethod();
            }
        }

        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.InternalDomainNameSuffix
        {
            get
            {
                return this.InternalDomainNameSuffix();
            }
        }

        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.InternalFqdn
        {
            get
            {
                return this.InternalFqdn();
            }
        }

        IList<string> Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.DnsServers
        {
            get
            {
                return this.DnsServers();
            }
        }

        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.PrimaryPrivateIp
        {
            get
            {
                return this.PrimaryPrivateIp();
            }
        }

        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.NetworkSecurityGroupId
        {
            get
            {
                return this.NetworkSecurityGroupId();
            }
        }

        Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup INetworkInterfaceBase.GetNetworkSecurityGroup()
        {
            return this.GetNetworkSecurityGroup();
        }
    }
}
