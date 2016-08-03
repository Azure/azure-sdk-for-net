/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Network.Network.Update;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    /// <summary>
    /// Entry point for Virtual Network management API in Azure.
    /// </summary>
    public interface INetwork  :
        IGroupableResource,
        IRefreshable<INetwork>,
        IWrapper<VirtualNetworkInner>,
        IUpdatable<IUpdate>
    {
        /// <returns>list of address spaces associated with this virtual network, in the CIDR notation</returns>
        IList<string> AddressSpaces { get; }

        /// <returns>list of DNS server IP addresses associated with this virtual network</returns>
        IList<string> DnsServerIPs { get; }

        /// <returns>subnets of this virtual network as a map indexed by subnet name</returns>
        /// <returns><p>Note that when a virtual network is created with no subnets explicitly defined, a default subnet is</returns>
        /// <returns>automatically created with the name "subnet1".</returns>
        IDictionary<string,ISubnet> Subnets { get; }

    }
}