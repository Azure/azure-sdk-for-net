// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using System.Collections.Generic;

    internal partial class VirtualMachineScaleSetNetworkInterfaceImpl
    {

        IReadOnlyDictionary<string, IVirtualMachineScaleSetNicIPConfiguration> Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface.IPConfigurations
        {
            get
            {
                return this.IPConfigurations();
            }
        }

        IVirtualMachineScaleSetNicIPConfiguration Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface.PrimaryIPConfiguration
        {
            get
            {
                return this.PrimaryIPConfiguration();
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

        bool Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.IsIPForwardingEnabled
        {
            get
            {
                return this.IsIPForwardingEnabled();
            }
        }

        IPAllocationMethod Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.PrimaryPrivateIPAllocationMethod
        {
            get
            {
                return this.PrimaryPrivateIPAllocationMethod();
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

        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.PrimaryPrivateIP
        {
            get
            {
                return this.PrimaryPrivateIP();
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
