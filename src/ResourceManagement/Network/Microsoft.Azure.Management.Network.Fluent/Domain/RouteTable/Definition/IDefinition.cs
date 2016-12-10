// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.RouteTable.Definition
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Route.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of a route table definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Network.Fluent.RouteTable.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The entirety of a route table definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Network.Fluent.RouteTable.Definition.IBlank,
        Microsoft.Azure.Management.Network.Fluent.RouteTable.Definition.IWithGroup,
        IWithCreate
    {
    }

    /// <summary>
    /// The stage of the route table definition allowing to add routes.
    /// </summary>
    public interface IWithRoute 
    {
        /// <summary>
        /// Creates a route via a virtual appliance.
        /// </summary>
        /// <param name="destinationAddressPrefix">The destination address prefix, expressed in the CIDR notation, for the route to apply to.</param>
        /// <param name="ipAddress">The IP address of the virtual appliance to route the traffic through.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.RouteTable.Definition.IWithCreate WithRouteViaVirtualAppliance(string destinationAddressPrefix, string ipAddress);

        /// <summary>
        /// Begins the definition of a new route to add to the route table.
        /// The definition must be completed with a call to Route.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the route.</param>
        /// <return>The first stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.Route.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.RouteTable.Definition.IWithCreate> DefineRoute(string name);

        /// <summary>
        /// Creates a non-virtual appliance route.
        /// The name is generated automatically.
        /// </summary>
        /// <param name="destinationAddressPrefix">The destination address prefix, expressed in the CIDR notation, for the route to apply to.</param>
        /// <param name="nextHop">The next hop type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.RouteTable.Definition.IWithCreate WithRoute(string destinationAddressPrefix, RouteNextHopType nextHop);
    }

    /// <summary>
    /// The stage of a route table definition which contains all the minimum required inputs for
    /// the resource to be created (via WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.Network.Fluent.IRouteTable>,
        IDefinitionWithTags<Microsoft.Azure.Management.Network.Fluent.RouteTable.Definition.IWithCreate>,
        IWithRoute
    {
    }

    /// <summary>
    /// The first stage of a route table definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.Network.Fluent.RouteTable.Definition.IWithGroup>
    {
    }
}