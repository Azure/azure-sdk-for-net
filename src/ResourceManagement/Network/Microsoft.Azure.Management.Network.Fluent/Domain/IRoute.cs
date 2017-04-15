// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of a route of a route table.
    /// </summary>
    public interface IRoute  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.RouteInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.Network.Fluent.IRouteTable>
    {
        /// <summary>
        /// Gets the type of the next hop.
        /// </summary>
        Models.RouteNextHopType NextHopType { get; }

        /// <summary>
        /// Gets the destination address prefix, expressed using the CIDR notation, to which the route applies.
        /// </summary>
        string DestinationAddressPrefix { get; }

        /// <summary>
        /// Gets the IP address of the next hop.
        /// </summary>
        string NextHopIPAddress { get; }
    }
}