// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.RouteTable.Update
{
    using Microsoft.Azure.Management.Network.Fluent.Route.Update;
    using Microsoft.Azure.Management.Network.Fluent.Route.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of the route table definition allowing to add, remove or modify routes.
    /// </summary>
    public interface IWithRoute 
    {
        /// <summary>
        /// Creates a route via a virtual appliance.
        /// </summary>
        /// <param name="destinationAddressPrefix">The destination address prefix, expressed in the CIDR notation, for the route to apply to.</param>
        /// <param name="ipAddress">The IP address of the virtual appliance to route the traffic through.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.RouteTable.Update.IUpdate WithRouteViaVirtualAppliance(string destinationAddressPrefix, string ipAddress);

        /// <summary>
        /// Begins the definition of a new route to add to the route table.
        /// The definition must be completed with a call to  Route.UpdateDefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the route.</param>
        /// <return>The first stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.Route.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.RouteTable.Update.IUpdate> DefineRoute(string name);

        /// <summary>
        /// Begins the update of an existing route on this route table.
        /// </summary>
        /// <param name="name">The name of an existing route.</param>
        /// <return>The first stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.Route.Update.IUpdate UpdateRoute(string name);

        /// <summary>
        /// Removes the specified route from the route table.
        /// </summary>
        /// <param name="name">The name of an existing route on this route table.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.RouteTable.Update.IUpdate WithoutRoute(string name);

        /// <summary>
        /// Creates a non-virtual appliance route.
        /// The name is generated automatically.
        /// </summary>
        /// <param name="destinationAddressPrefix">The destination address prefix, expressed in the CIDR notation, for the route to apply to.</param>
        /// <param name="nextHop">The next hop type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.RouteTable.Update.IUpdate WithRoute(string destinationAddressPrefix, RouteNextHopType nextHop);
    }

    /// <summary>
    /// The template for a route table update operation, containing all the settings that can be modified.
    /// Call  Update.apply() to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Network.Fluent.IRouteTable>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Network.Fluent.RouteTable.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.RouteTable.Update.IWithRoute
    {
    }
}