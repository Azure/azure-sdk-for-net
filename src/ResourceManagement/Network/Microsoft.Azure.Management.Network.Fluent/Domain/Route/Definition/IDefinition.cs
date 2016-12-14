// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.Route.Definition
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;

    /// <summary>
    /// The final stage of a route definition.
    /// At this stage, any remaining optional settings can be specified, or the route definition
    /// can be attached to the parent route table definition using WithAttach.attach().
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        IInDefinition<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a route definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IBlank<ParentT>  :
        IWithDestinationAddressPrefix<ParentT>
    {
    }

    /// <summary>
    /// The entirety of a route definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final DefinitionStages.WithAttach.attach().</typeparam>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        IWithNextHopType<ParentT>,
        IWithDestinationAddressPrefix<ParentT>
    {
    }

    /// <summary>
    /// The stage of a route definition allowing to specify the destination address prefix.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithDestinationAddressPrefix<ParentT> 
    {
        /// <summary>
        /// Specifies the destination address prefix to apply the route to.
        /// </summary>
        /// <param name="cidr">An address prefix expressed in the CIDR notation.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.Route.Definition.IWithNextHopType<ParentT> WithDestinationAddressPrefix(string cidr);
    }

    /// <summary>
    /// The stage of a route definition allowing to specify the next hop type.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithNextHopType<ParentT> 
    {
        /// <summary>
        /// Specifies the IP address of the virtual appliance for the next hop to go to.
        /// </summary>
        /// <param name="ipAddress">An IP address of an existing virtual appliance (virtual machine).</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.Route.Definition.IWithAttach<ParentT> WithNextHopToVirtualAppliance(string ipAddress);

        /// <summary>
        /// Specifies the next hop type.
        /// To use a virtual appliance, use .withNextHopToVirtualAppliance(String) instead and specify its IP address.
        /// </summary>
        /// <param name="nextHopType">A hop type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.Route.Definition.IWithAttach<ParentT> WithNextHop(RouteNextHopType nextHopType);
    }
}