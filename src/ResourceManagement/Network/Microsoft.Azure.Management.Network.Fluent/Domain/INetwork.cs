// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using System.Collections.Generic;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Fluent.Network.Network.Update;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
    /// <summary>
    /// Entry point for Virtual Network management API in Azure.
    /// </summary>
    public interface INetwork  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Fluent.Network.INetwork>,
        IWrapper<Microsoft.Azure.Management.Network.Models.VirtualNetworkInner>,
        IUpdatable<Microsoft.Azure.Management.Fluent.Network.Network.Update.IUpdate>
    {
        /// <returns>list of address spaces associated with this virtual network, in the CIDR notation</returns>
        System.Collections.Generic.IList<string> AddressSpaces { get; }

        /// <returns>list of DNS server IP addresses associated with this virtual network</returns>
        System.Collections.Generic.IList<string> DnsServerIps { get; }

        /// <returns>subnets of this virtual network as a map indexed by subnet name</returns>
        /// <returns><p>Note that when a virtual network is created with no subnets explicitly defined, a default subnet is</returns>
        /// <returns>automatically created with the name "subnet1".</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.ISubnet> Subnets { get; }

    }
}