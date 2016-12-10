// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.Route.Update
{
    using Microsoft.Azure.Management.Network.Fluent.RouteTable.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.Models;

    /// <summary>
    /// The entirety of a route update as part of a route table update.
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.Network.Fluent.RouteTable.Update.IUpdate>,
        IWithDestinationAddressPrefix,
        IWithNextHopType
    {
    }

    /// <summary>
    /// The stage of a route update allowing to specify the next hop type.
    /// </summary>
    public interface IWithNextHopType 
    {
        /// <summary>
        /// Specifies the IP address of the virtual appliance for the next hop to go to.
        /// </summary>
        /// <param name="ipAddress">An IP address of an existing virtual appliance (virtual machine).</param>
        Microsoft.Azure.Management.Network.Fluent.Route.Update.IUpdate WithNextHopToVirtualAppliance(string ipAddress);

        /// <summary>
        /// Specifies the next hop type.
        /// <p>
        /// To use a virtual appliance, use .withNextHopToVirtualAppliance(String) instead and specify its IP address.
        /// </summary>
        /// <param name="nextHopType">A hop type.</param>
        Microsoft.Azure.Management.Network.Fluent.Route.Update.IUpdate WithNextHop(RouteNextHopType nextHopType);
    }

    /// <summary>
    /// The stage of a route update allowing to modify the destination address prefix.
    /// </summary>
    public interface IWithDestinationAddressPrefix 
    {
        /// <summary>
        /// Specifies the destination address prefix to apply the route to.
        /// </summary>
        /// <param name="cidr">An address prefix expressed in the CIDR notation.</param>
        Microsoft.Azure.Management.Network.Fluent.Route.Update.IUpdate WithDestinationAddressPrefix(string cidr);
    }
}