// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{

    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update;
    /// <summary>
    /// Network interface.
    /// </summary>
    public interface INetworkInterface  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        IWrapper<Microsoft.Azure.Management.Network.Fluent.Models.NetworkInterfaceInner>,
        IUpdatable<Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate>
    {
        /// <returns><tt>true</tt> if IP forwarding is enabled in this network interface</returns>
        bool IsIpForwardingEnabled { get; }

        /// <returns>the MAC Address of the network interface</returns>
        string MacAddress { get; }

        /// <returns>the Internal DNS name assigned to this network interface</returns>
        string InternalDnsNameLabel { get; }

        /// <summary>
        /// Gets the fully qualified domain name of this network interface.
        /// <p>
        /// A network interface receives FQDN as a part of assigning it to a virtual machine.
        /// </summary>
        /// <returns>the qualified domain name</returns>
        string InternalFqdn { get; }

        /// <returns>the internal domain name suffix</returns>
        string InternalDomainNameSuffix { get; }

        /// <returns>IP addresses of this network interface's DNS servers</returns>
        System.Collections.Generic.IList<string> DnsServers { get; }

        /// <returns>applied DNS servers</returns>
        System.Collections.Generic.IList<string> AppliedDnsServers { get; }

        /// <summary>
        /// Gets the private IP address allocated to this network interface's primary IP configuration.
        /// <p>
        /// The private IP will be within the virtual network subnet of this network interface.
        /// </summary>
        /// <returns>the private IP addresses</returns>
        string PrimaryPrivateIp { get; }

        /// <returns>the private IP allocation method (Dynamic, Static) of this network interface's</returns>
        /// <returns>primary IP configuration.</returns>
        IPAllocationMethod PrimaryPrivateIpAllocationMethod { get; }

        /// <returns>the IP configurations of this network interface, indexed by their names</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration> IpConfigurations { get; }

        /// <returns>the primary IP configuration of this network interface</returns>
        Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration PrimaryIpConfiguration { get; }

        /// <returns>the network security group resource id or null if there is no network security group</returns>
        /// <returns>associated with this network interface.</returns>
        string NetworkSecurityGroupId { get; }

        /// <summary>
        /// Gets the network security group associated this network interface.
        /// <p>
        /// This method makes a rest API call to fetch the Network Security Group resource.
        /// </summary>
        /// <returns>the network security group associated with this network interface.</returns>
        Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup GetNetworkSecurityGroup();

        /// <returns>the resource ID of the associated virtual machine, or null if none.</returns>
        string VirtualMachineId { get; }

    }
}