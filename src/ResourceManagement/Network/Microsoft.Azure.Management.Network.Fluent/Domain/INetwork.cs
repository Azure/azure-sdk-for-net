// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{

    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.Network.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    /// <summary>
    /// Entry point for Virtual Network management API in Azure.
    /// </summary>
    public interface INetwork  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Network.Fluent.INetwork>,
        IWrapper<Microsoft.Azure.Management.Network.Fluent.Models.VirtualNetworkInner>,
        IUpdatable<Microsoft.Azure.Management.Network.Fluent.Network.Update.IUpdate>
    {
        /// <returns>list of address spaces associated with this virtual network, in the CIDR notation</returns>
        System.Collections.Generic.IList<string> AddressSpaces { get; }

        /// <returns>list of DNS server IP addresses associated with this virtual network</returns>
        System.Collections.Generic.IList<string> DnsServerIps { get; }

        /// <returns>subnets of this virtual network as a map indexed by subnet name</returns>
        /// <returns><p>Note that when a virtual network is created with no subnets explicitly defined, a default subnet is</returns>
        /// <returns>automatically created with the name "subnet1".</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Network.Fluent.ISubnet> Subnets { get; }

    }
}