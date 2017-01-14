// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using System.Collections.Generic;

    /// <summary>
    /// The base network interface shared across regular and virtual machine scale set network interface.
    /// </summary>
    public interface INetworkInterfaceBase 
    {
        /// <summary>
        /// Gets applied DNS servers.
        /// </summary>
        System.Collections.Generic.IList<string> AppliedDnsServers { get; }

        /// <summary>
        /// Gets the MAC Address of the network interface.
        /// </summary>
        string MacAddress { get; }

        /// <summary>
        /// Gets the resource ID of the associated virtual machine, or null if none.
        /// </summary>
        string VirtualMachineId { get; }

        /// <summary>
        /// Gets the Internal DNS name assigned to this network interface.
        /// </summary>
        string InternalDnsNameLabel { get; }

        /// <summary>
        /// Gets <tt>true</tt> if IP forwarding is enabled in this network interface.
        /// </summary>
        bool IsIpForwardingEnabled { get; }

        /// <summary>
        /// Gets the private IP allocation method (Dynamic, Static) of this network interface's
        /// primary IP configuration.
        /// </summary>
        IPAllocationMethod PrimaryPrivateIpAllocationMethod { get; }

        /// <summary>
        /// Gets the internal domain name suffix.
        /// </summary>
        string InternalDomainNameSuffix { get; }

        /// <summary>
        /// Gets Gets the fully qualified domain name of this network interface.
        /// A network interface receives FQDN as a part of assigning it to a virtual machine.
        /// </summary>
        /// <summary>
        /// Gets the qualified domain name.
        /// </summary>
        string InternalFqdn { get; }

        /// <summary>
        /// Gets IP addresses of this network interface's DNS servers.
        /// </summary>
        System.Collections.Generic.IList<string> DnsServers { get; }

        /// <summary>
        /// Gets the network security group associated this network interface.
        /// This method makes a rest API call to fetch the Network Security Group resource.
        /// </summary>
        /// <return>The network security group associated with this network interface.</return>
        Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup GetNetworkSecurityGroup();

        /// <summary>
        /// Gets Gets the private IP address allocated to this network interface's primary IP configuration.
        /// The private IP will be within the virtual network subnet of this network interface.
        /// </summary>
        /// <summary>
        /// Gets the private IP addresses.
        /// </summary>
        string PrimaryPrivateIp { get; }

        /// <summary>
        /// Gets the network security group resource id associated with this network interface.
        /// </summary>
        string NetworkSecurityGroupId { get; }
    }
}