/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Network.NetworkInterface.Update;
    /// <summary>
    /// Network interface.
    /// </summary>
    public interface INetworkInterface  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.V2.Network.INetworkInterface>,
        IWrapper<Microsoft.Azure.Management.Network.Models.NetworkInterfaceInner>,
        IUpdatable<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>
    {
        /// <returns><tt>true</tt> if IP forwarding is enabled in this network interface</returns>
        bool? IsIpForwardingEnabled { get; }

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

        /// <returns>IP addresses of this network interface's DNS servers</returns>
        IList<string> DnsServers { get; }

        /// <summary>
        /// Gets the public IP address associated with this network interface.
        /// <p>
        /// This method makes a rest API call to fetch the public IP.
        /// </summary>
        /// <returns>the public IP associated with this network interface</returns>
        IPublicIpAddress PrimaryPublicIpAddress ();

        /// <returns>the resource id of the virtual network subnet associated with this network interface.</returns>
        string PrimarySubnetId { get; }

        /// <summary>
        /// Gets the virtual network associated this network interface's primary IP configuration.
        /// <p>
        /// This method makes a rest API call to fetch the virtual network.
        /// </summary>
        /// <returns>the virtual network associated with this network interface.</returns>
        INetwork PrimaryNetwork ();

        /// <summary>
        /// Gets the private IP address allocated to this network interface's primary IP configuration.
        /// <p>
        /// The private IP will be within the virtual network subnet of this network interface.
        /// </summary>
        /// <returns>the private IP addresses</returns>
        string PrimaryPrivateIp { get; }

        /// <returns>the private IP allocation method (Dynamic, Static) of this network interface's</returns>
        /// <returns>primary IP configuration.</returns>
        string PrimaryPrivateIpAllocationMethod { get; }

        /// <returns>the IP configurations of this network interface</returns>
        IList<Microsoft.Azure.Management.V2.Network.INicIpConfiguration> IpConfigurations ();

        /// <returns>the primary IP configuration of this network interface</returns>
        INicIpConfiguration PrimaryIpConfiguration ();

        /// <returns>the network security group resource id or null if there is no network security group</returns>
        /// <returns>associated with this network interface.</returns>
        string NetworkSecurityGroupId { get; }

        /// <summary>
        /// Gets the network security group associated this network interface.
        /// <p>
        /// This method makes a rest API call to fetch the Network Security Group resource.
        /// </summary>
        /// <returns>the network security group associated with this network interface.</returns>
        INetworkSecurityGroup NetworkSecurityGroup ();

    }
}