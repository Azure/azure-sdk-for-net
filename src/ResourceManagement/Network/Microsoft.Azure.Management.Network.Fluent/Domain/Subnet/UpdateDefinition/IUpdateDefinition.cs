// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.Subnet.UpdateDefinition
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Network.Fluent;

    /// <summary>
    /// The final stage of the subnet definition.
    /// At this stage, any remaining optional settings can be specified, or the subnet definition
    /// can be attached to the parent virtual network definition using WithAttach.attach().
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>,
        IWithNetworkSecurityGroup<ParentT>,
        IWithRouteTable<ParentT>
    {
    }

    /// <summary>
    /// The stage of a subnet definition allowing to specify a route table to associate with the subnet.
    /// </summary>
    /// <typeparam name="Parent">The parent type.</typeparam>
    public interface IWithRouteTable<ParentT> 
    {
        /// <summary>
        /// Specifies an existing route table to associate with the subnet.
        /// </summary>
        /// <param name="routeTable">An existing route table to associate.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.Subnet.UpdateDefinition.IWithAttach<ParentT> WithExistingRouteTable(IRouteTable routeTable);

        /// <summary>
        /// Specifies an existing route table to associate with the subnet.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing route table.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.Subnet.UpdateDefinition.IWithAttach<ParentT> WithExistingRouteTable(string resourceId);
    }

    /// <summary>
    /// The stage of the subnet definition allowing to specify the network security group to assign to the subnet.
    /// </summary>
    /// <typeparam name="Parent">The parent type.</typeparam>
    public interface IWithNetworkSecurityGroup<ParentT> 
    {
        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="resourceId">The resource ID of the network security group.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.Subnet.UpdateDefinition.IWithAttach<ParentT> WithExistingNetworkSecurityGroup(string resourceId);

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="nsg">The network security group to assign.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.Subnet.UpdateDefinition.IWithAttach<ParentT> WithExistingNetworkSecurityGroup(INetworkSecurityGroup nsg);
    }

    /// <summary>
    /// The entirety of a subnet definition as part of a virtual network update.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final UpdateDefinitionStages.WithAttach.attach().</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAddressPrefix<ParentT>,
        IWithNetworkSecurityGroup<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The first stage of the subnet definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IBlank<ParentT>  :
        IWithAddressPrefix<ParentT>
    {
    }

    /// <summary>
    /// The stage of the subnet definition allowing to specify the address space for the subnet.
    /// </summary>
    /// <typeparam name="Parent">The parent type.</typeparam>
    public interface IWithAddressPrefix<ParentT> 
    {
        /// <summary>
        /// Specifies the IP address space of the subnet, within the address space of the network.
        /// </summary>
        /// <param name="cidr">The IP address space prefix using the CIDR notation.</param>
        /// <return>The next stage of the subnet definition.</return>
        Microsoft.Azure.Management.Network.Fluent.Subnet.UpdateDefinition.IWithAttach<ParentT> WithAddressPrefix(string cidr);
    }
}