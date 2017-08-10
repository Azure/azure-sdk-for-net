// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal partial class VirtualMachineScaleSetNetworkInterfaceImpl 
    {
        /// <summary>
        /// Gets the IP configurations of this network interface, indexed by their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNicIPConfiguration> Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface.IPConfigurations
        {
            get
            {
                return this.IPConfigurations() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNicIPConfiguration>;
            }
        }

        /// <summary>
        /// Gets the primary IP configuration of this network interface.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNicIPConfiguration Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface.PrimaryIPConfiguration
        {
            get
            {
                return this.PrimaryIPConfiguration() as Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNicIPConfiguration;
            }
        }

        /// <summary>
        /// Gets the network security group associated this network interface.
        /// This method makes a rest API call to fetch the Network Security Group resource.
        /// </summary>
        /// <return>The network security group associated with this network interface.</return>
        Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.GetNetworkSecurityGroup()
        {
            return this.GetNetworkSecurityGroup() as Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup;
        }

        /// <summary>
        /// Gets true if IP forwarding is enabled in this network interface.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.IsIPForwardingEnabled
        {
            get
            {
                return this.IsIPForwardingEnabled();
            }
        }

        /// <summary>
        /// Gets true if accelerated networkin is enabled for this network interface.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBaseBeta.IsAcceleratedNetworkingEnabled
        {
            get
            {
                return this.IsAcceleratedNetworkingEnabled();
            }
        }

        /// <summary>
        /// Gets the fully qualified domain name of this network interface.
        /// A network interface receives FQDN as a part of assigning it to a virtual machine.
        /// </summary>
        /// <summary>
        /// Gets the qualified domain name.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.InternalFqdn
        {
            get
            {
                return this.InternalFqdn();
            }
        }

        /// <summary>
        /// Gets the Internal DNS name assigned to this network interface.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.InternalDnsNameLabel
        {
            get
            {
                return this.InternalDnsNameLabel();
            }
        }

        /// <summary>
        /// Gets the private IP allocation method (Dynamic, Static) of this network interface's
        /// primary IP configuration.
        /// </summary>
        Models.IPAllocationMethod Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.PrimaryPrivateIPAllocationMethod
        {
            get
            {
                return this.PrimaryPrivateIPAllocationMethod() as Models.IPAllocationMethod;
            }
        }

        /// <summary>
        /// Gets the private IP address allocated to this network interface's primary IP configuration.
        /// The private IP will be within the virtual network subnet of this network interface.
        /// </summary>
        /// <summary>
        /// Gets the private IP addresses.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.PrimaryPrivateIP
        {
            get
            {
                return this.PrimaryPrivateIP();
            }
        }

        /// <summary>
        /// Gets the MAC Address of the network interface.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.MacAddress
        {
            get
            {
                return this.MacAddress();
            }
        }

        /// <summary>
        /// Gets the resource ID of the associated virtual machine, or null if none.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.VirtualMachineId
        {
            get
            {
                return this.VirtualMachineId();
            }
        }

        /// <summary>
        /// Gets the network security group resource id associated with this network interface.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.NetworkSecurityGroupId
        {
            get
            {
                return this.NetworkSecurityGroupId();
            }
        }

        /// <summary>
        /// Gets applied DNS servers.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.AppliedDnsServers
        {
            get
            {
                return this.AppliedDnsServers() as System.Collections.Generic.IReadOnlyList<string>;
            }
        }

        /// <summary>
        /// Gets IP addresses of this network interface's DNS servers.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.DnsServers
        {
            get
            {
                return this.DnsServers() as System.Collections.Generic.IReadOnlyList<string>;
            }
        }

        /// <summary>
        /// Gets the internal domain name suffix.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.InternalDomainNameSuffix
        {
            get
            {
                return this.InternalDomainNameSuffix();
            }
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.INetworkManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Network.Fluent.INetworkManager>.Manager
        {
            get
            {
                return this.Manager() as Microsoft.Azure.Management.Network.Fluent.INetworkManager;
            }
        }
    }
}