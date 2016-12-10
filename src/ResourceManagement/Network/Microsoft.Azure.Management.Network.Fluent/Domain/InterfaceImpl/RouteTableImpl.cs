// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading.Tasks;
    using Models;
    using RouteTable.Definition;
    using RouteTable.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    internal partial class RouteTableImpl 
    {
        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Network.Fluent.IRouteTable Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.IRouteTable>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Network.Fluent.IRouteTable;
        }

        /// <summary>
        /// Gets the routes of this route table.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IRoute> Microsoft.Azure.Management.Network.Fluent.IRouteTable.Routes
        {
            get
            {
                return this.Routes() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IRoute>;
            }
        }

        /// <return>List of subnets associated with this resource.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Network.Fluent.ISubnet> Microsoft.Azure.Management.Network.Fluent.IHasAssociatedSubnets.ListAssociatedSubnets()
        {
            return this.ListAssociatedSubnets() as System.Collections.Generic.IList<Microsoft.Azure.Management.Network.Fluent.ISubnet>;
        }

        /// <summary>
        /// Creates a non-virtual appliance route.
        /// The name is generated automatically.
        /// </summary>
        /// <param name="destinationAddressPrefix">The destination address prefix, expressed in the CIDR notation, for the route to apply to.</param>
        /// <param name="nextHop">The next hop type.</param>
        /// <return>The next stage of the update.</return>
        RouteTable.Update.IUpdate RouteTable.Update.IWithRoute.WithRoute(string destinationAddressPrefix, RouteNextHopType nextHop)
        {
            return this.WithRoute(destinationAddressPrefix, nextHop) as RouteTable.Update.IUpdate;
        }

        /// <summary>
        /// Creates a route via a virtual appliance.
        /// </summary>
        /// <param name="destinationAddressPrefix">The destination address prefix, expressed in the CIDR notation, for the route to apply to.</param>
        /// <param name="ipAddress">The IP address of the virtual appliance to route the traffic through.</param>
        /// <return>The next stage of the update.</return>
        RouteTable.Update.IUpdate RouteTable.Update.IWithRoute.WithRouteViaVirtualAppliance(string destinationAddressPrefix, string ipAddress)
        {
            return this.WithRouteViaVirtualAppliance(destinationAddressPrefix, ipAddress) as RouteTable.Update.IUpdate;
        }

        /// <summary>
        /// Removes the specified route from the route table.
        /// </summary>
        /// <param name="name">The name of an existing route on this route table.</param>
        /// <return>The next stage of the update.</return>
        RouteTable.Update.IUpdate RouteTable.Update.IWithRoute.WithoutRoute(string name)
        {
            return this.WithoutRoute(name) as RouteTable.Update.IUpdate;
        }

        /// <summary>
        /// Begins the update of an existing route on this route table.
        /// </summary>
        /// <param name="name">The name of an existing route.</param>
        /// <return>The first stage of the update.</return>
        Route.Update.IUpdate RouteTable.Update.IWithRoute.UpdateRoute(string name)
        {
            return this.UpdateRoute(name) as Route.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new route to add to the route table.
        /// The definition must be completed with a call to Route.UpdateDefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the route.</param>
        /// <return>The first stage of the definition.</return>
        Route.UpdateDefinition.IBlank<RouteTable.Update.IUpdate> RouteTable.Update.IWithRoute.DefineRoute(string name)
        {
            return this.DefineRoute(name) as Route.UpdateDefinition.IBlank<RouteTable.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a non-virtual appliance route.
        /// The name is generated automatically.
        /// </summary>
        /// <param name="destinationAddressPrefix">The destination address prefix, expressed in the CIDR notation, for the route to apply to.</param>
        /// <param name="nextHop">The next hop type.</param>
        /// <return>The next stage of the definition.</return>
        RouteTable.Definition.IWithCreate RouteTable.Definition.IWithRoute.WithRoute(string destinationAddressPrefix, RouteNextHopType nextHop)
        {
            return this.WithRoute(destinationAddressPrefix, nextHop) as RouteTable.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a route via a virtual appliance.
        /// </summary>
        /// <param name="destinationAddressPrefix">The destination address prefix, expressed in the CIDR notation, for the route to apply to.</param>
        /// <param name="ipAddress">The IP address of the virtual appliance to route the traffic through.</param>
        /// <return>The next stage of the definition.</return>
        RouteTable.Definition.IWithCreate RouteTable.Definition.IWithRoute.WithRouteViaVirtualAppliance(string destinationAddressPrefix, string ipAddress)
        {
            return this.WithRouteViaVirtualAppliance(destinationAddressPrefix, ipAddress) as RouteTable.Definition.IWithCreate;
        }

        /// <summary>
        /// Begins the definition of a new route to add to the route table.
        /// The definition must be completed with a call to Route.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the route.</param>
        /// <return>The first stage of the definition.</return>
        Route.Definition.IBlank<RouteTable.Definition.IWithCreate> RouteTable.Definition.IWithRoute.DefineRoute(string name)
        {
            return this.DefineRoute(name) as Route.Definition.IBlank<RouteTable.Definition.IWithCreate>;
        }
    }
}