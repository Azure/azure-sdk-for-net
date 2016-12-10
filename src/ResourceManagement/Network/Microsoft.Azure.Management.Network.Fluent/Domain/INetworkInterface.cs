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
    public interface INetworkInterface :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        IWrapper<Models.NetworkInterfaceInner>,
        IUpdatable<NetworkInterface.Update.IUpdate>
    {
        string VirtualMachineId { get; }

        string InternalDnsNameLabel { get; }

        bool IsIpForwardingEnabled { get; }

        string InternalDomainNameSuffix { get; }

        /// <summary>
        /// Gets the fully qualified domain name of this network interface.
        /// <p>
        /// A network interface receives FQDN as a part of assigning it to a virtual machine.
        /// </summary>
        string InternalFqdn { get; }

        /// <summary>
        /// Gets the private IP address allocated to this network interface's primary IP configuration.
        /// <p>
        /// The private IP will be within the virtual network subnet of this network interface.
        /// </summary>
        string PrimaryPrivateIp { get; }

        System.Collections.Generic.IList<string> AppliedDnsServers { get; }

        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration> IpConfigurations { get; }

        string MacAddress { get; }

        IPAllocationMethod PrimaryPrivateIpAllocationMethod { get; }

        Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration PrimaryIpConfiguration { get; }

        System.Collections.Generic.IList<string> DnsServers { get; }

        /// <summary>
        /// Gets the network security group associated this network interface.
        /// <p>
        /// This method makes a rest API call to fetch the Network Security Group resource.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup GetNetworkSecurityGroup();

        string NetworkSecurityGroupId { get; }
    }
}