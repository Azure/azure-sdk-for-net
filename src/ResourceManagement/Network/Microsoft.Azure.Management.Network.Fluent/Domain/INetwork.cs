// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Network.Update;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point for Virtual Network management API in Azure.
    /// </summary>
    public interface INetwork  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Network.Fluent.INetwork>,
        IWrapper<Models.VirtualNetworkInner>,
        IUpdatable<Network.Update.IUpdate>
    {
        /// <summary>
        /// Gets list of address spaces associated with this virtual network, in the CIDR notation.
        /// </summary>
        System.Collections.Generic.IList<string> AddressSpaces { get; }

        /// <summary>
        /// Gets list of DNS server IP addresses associated with this virtual network.
        /// </summary>
        System.Collections.Generic.IList<string> DnsServerIps { get; }

        /// <summary>
        /// Gets subnets of this virtual network as a map indexed by subnet name
        /// Note that when a virtual network is created with no subnets explicitly defined, a default subnet is
        /// automatically created with the name "subnet1".
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ISubnet> Subnets { get; }
    }
}