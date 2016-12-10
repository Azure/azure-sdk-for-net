// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Route.Definition;
    using Route.Update;
    using Route.UpdateDefinition;
    using Models;
    using RouteTable.Definition;
    using RouteTable.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;

    public partial class RouteImpl
    {
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        RouteTable.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<RouteTable.Update.IUpdate>.Attach()
        {
            return this.Attach() as RouteTable.Update.IUpdate;
        }

        string Microsoft.Azure.Management.Network.Fluent.IRoute.NextHopIpAddress
        {
            get
            {
                return this.NextHopIpAddress();
            }
        }

        Models.RouteNextHopType Microsoft.Azure.Management.Network.Fluent.IRoute.NextHopType
        {
            get
            {
                return this.NextHopType() as Models.RouteNextHopType;
            }
        }

        string Microsoft.Azure.Management.Network.Fluent.IRoute.DestinationAddressPrefix
        {
            get
            {
                return this.DestinationAddressPrefix();
            }
        }

        /// <summary>
        /// Specifies the destination address prefix to apply the route to.
        /// </summary>
        /// <param name="cidr">An address prefix expressed in the CIDR notation.</param>
        Route.Update.IUpdate Route.Update.IWithDestinationAddressPrefix.WithDestinationAddressPrefix(string cidr)
        {
            return this.WithDestinationAddressPrefix(cidr) as Route.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the destination address prefix to apply the route to.
        /// </summary>
        /// <param name="cidr">An address prefix expressed in the CIDR notation.</param>
        Route.Definition.IWithNextHopType<RouteTable.Definition.IWithCreate> Route.Definition.IWithDestinationAddressPrefix<RouteTable.Definition.IWithCreate>.WithDestinationAddressPrefix(string cidr)
        {
            return this.WithDestinationAddressPrefix(cidr) as Route.Definition.IWithNextHopType<RouteTable.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the destination address prefix to apply the route to.
        /// </summary>
        /// <param name="cidr">An address prefix expressed in the CIDR notation.</param>
        Route.UpdateDefinition.IWithNextHopType<RouteTable.Update.IUpdate> Route.UpdateDefinition.IWithDestinationAddressPrefix<RouteTable.Update.IUpdate>.WithDestinationAddressPrefix(string cidr)
        {
            return this.WithDestinationAddressPrefix(cidr) as Route.UpdateDefinition.IWithNextHopType<RouteTable.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the next hop type.
        /// <p>
        /// To use a virtual appliance, use .withNextHopToVirtualAppliance(String) instead and specify its IP address.
        /// </summary>
        /// <param name="nextHopType">A hop type.</param>
        Route.Definition.IWithAttach<RouteTable.Definition.IWithCreate> Route.Definition.IWithNextHopType<RouteTable.Definition.IWithCreate>.WithNextHop(RouteNextHopType nextHopType)
        {
            return this.WithNextHop(nextHopType) as Route.Definition.IWithAttach<RouteTable.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the IP address of the virtual appliance for the next hop to go to.
        /// </summary>
        /// <param name="ipAddress">An IP address of an existing virtual appliance (virtual machine).</param>
        Route.Definition.IWithAttach<RouteTable.Definition.IWithCreate> Route.Definition.IWithNextHopType<RouteTable.Definition.IWithCreate>.WithNextHopToVirtualAppliance(string ipAddress)
        {
            return this.WithNextHopToVirtualAppliance(ipAddress) as Route.Definition.IWithAttach<RouteTable.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the next hop type.
        /// <p>
        /// To use a virtual appliance, use .withNextHopToVirtualAppliance(String) instead and specify its IP address.
        /// </summary>
        /// <param name="nextHopType">A hop type.</param>
        Route.UpdateDefinition.IWithAttach<RouteTable.Update.IUpdate> Route.UpdateDefinition.IWithNextHopType<RouteTable.Update.IUpdate>.WithNextHop(RouteNextHopType nextHopType)
        {
            return this.WithNextHop(nextHopType) as Route.UpdateDefinition.IWithAttach<RouteTable.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the IP address of the virtual appliance for the next hop to go to.
        /// </summary>
        /// <param name="ipAddress">An IP address of an existing virtual appliance (virtual machine).</param>
        Route.UpdateDefinition.IWithAttach<RouteTable.Update.IUpdate> Route.UpdateDefinition.IWithNextHopType<RouteTable.Update.IUpdate>.WithNextHopToVirtualAppliance(string ipAddress)
        {
            return this.WithNextHopToVirtualAppliance(ipAddress) as Route.UpdateDefinition.IWithAttach<RouteTable.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the next hop type.
        /// <p>
        /// To use a virtual appliance, use .withNextHopToVirtualAppliance(String) instead and specify its IP address.
        /// </summary>
        /// <param name="nextHopType">A hop type.</param>
        Route.Update.IUpdate Route.Update.IWithNextHopType.WithNextHop(RouteNextHopType nextHopType)
        {
            return this.WithNextHop(nextHopType) as Route.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the IP address of the virtual appliance for the next hop to go to.
        /// </summary>
        /// <param name="ipAddress">An IP address of an existing virtual appliance (virtual machine).</param>
        Route.Update.IUpdate Route.Update.IWithNextHopType.WithNextHopToVirtualAppliance(string ipAddress)
        {
            return this.WithNextHopToVirtualAppliance(ipAddress) as Route.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        RouteTable.Definition.IWithCreate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<RouteTable.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as RouteTable.Definition.IWithCreate;
        }
    }
}