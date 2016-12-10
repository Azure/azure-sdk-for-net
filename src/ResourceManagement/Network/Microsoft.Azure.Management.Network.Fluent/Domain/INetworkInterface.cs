// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using NetworkInterface.Update;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Network interface.
    /// </summary>
    public interface INetworkInterface  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        IWrapper<Models.NetworkInterfaceInner>,
        IUpdatable<NetworkInterface.Update.IUpdate>
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
        /// Gets <tt>true</tt> if IP forwarding is enabled in this network interface.
        /// </summary>
        bool IsIpForwardingEnabled { get; }

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
        /// Gets Gets the private IP address allocated to this network interface's primary IP configuration.
        /// The private IP will be within the virtual network subnet of this network interface.
        /// </summary>
        /// <summary>
        /// Gets the private IP addresses.
        /// </summary>
        string PrimaryPrivateIp { get; }

        /// <summary>
        /// Gets applied DNS servers.
        /// </summary>
        System.Collections.Generic.IList<string> AppliedDnsServers { get; }

        /// <summary>
        /// Gets the IP configurations of this network interface, indexed by their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration> IpConfigurations { get; }

        /// <summary>
        /// Gets the MAC Address of the network interface.
        /// </summary>
        string MacAddress { get; }

        /// <summary>
        /// Gets the private IP allocation method (Dynamic, Static) of this network interface's
        /// primary IP configuration.
        /// </summary>
        string PrimaryPrivateIpAllocationMethod { get; }

        /// <summary>
        /// Gets the primary IP configuration of this network interface.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration PrimaryIpConfiguration { get; }

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
        /// Gets the network security group resource id or null if there is no network security group
        /// associated with this network interface.
        /// </summary>
        string NetworkSecurityGroupId { get; }
    }
}