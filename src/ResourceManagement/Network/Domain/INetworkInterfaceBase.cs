// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// The base network interface shared across regular and virtual machine scale set network interface.
    /// </summary>
    public interface INetworkInterfaceBase  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Network.Fluent.INetworkManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.NetworkInterfaceInner>,
        Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBaseBeta
    {
        /// <summary>
        /// Gets the resource ID of the associated virtual machine, or null if none.
        /// </summary>
        string VirtualMachineId { get; }

        /// <summary>
        /// Gets the Internal DNS name assigned to this network interface.
        /// </summary>
        string InternalDnsNameLabel { get; }

        /// <summary>
        /// Gets the internal domain name suffix.
        /// </summary>
        string InternalDomainNameSuffix { get; }

        /// <summary>
        /// Gets the fully qualified domain name of this network interface.
        /// A network interface receives FQDN as a part of assigning it to a virtual machine.
        /// </summary>
        /// <summary>
        /// Gets the qualified domain name.
        /// </summary>
        string InternalFqdn { get; }

        /// <summary>
        /// Gets true if IP forwarding is enabled in this network interface.
        /// </summary>
        bool IsIPForwardingEnabled { get; }

        /// <summary>
        /// Gets the private IP allocation method (Dynamic, Static) of this network interface's
        /// primary IP configuration.
        /// </summary>
        Models.IPAllocationMethod PrimaryPrivateIPAllocationMethod { get; }

        /// <summary>
        /// Gets the private IP address allocated to this network interface's primary IP configuration.
        /// The private IP will be within the virtual network subnet of this network interface.
        /// </summary>
        /// <summary>
        /// Gets the private IP addresses.
        /// </summary>
        string PrimaryPrivateIP { get; }

        /// <summary>
        /// Gets applied DNS servers.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> AppliedDnsServers { get; }

        /// <summary>
        /// Gets the MAC Address of the network interface.
        /// </summary>
        string MacAddress { get; }

        /// <summary>
        /// Gets IP addresses of this network interface's DNS servers.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> DnsServers { get; }

        /// <summary>
        /// Gets the network security group associated this network interface.
        /// This method makes a rest API call to fetch the Network Security Group resource.
        /// </summary>
        /// <return>The network security group associated with this network interface.</return>
        Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup GetNetworkSecurityGroup();

        /// <summary>
        /// Gets the network security group resource id associated with this network interface.
        /// </summary>
        string NetworkSecurityGroupId { get; }
    }
}