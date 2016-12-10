// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.Subnet.Definition
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// The stage of the subnet definition allowing to specify the address space for the subnet.
    /// </summary>
    public interface IWithAddressPrefix<ParentT> 
    {
        /// <summary>
        /// Specifies the IP address space of the subnet, within the address space of the network.
        /// </summary>
        /// <param name="cidr">The IP address space prefix using the CIDR notation.</param>
        Microsoft.Azure.Management.Network.Fluent.Subnet.Definition.IWithAttach<ParentT> WithAddressPrefix(string cidr);
    }

    /// <summary>
    /// The stage of the subnet definition allowing to specify the network security group to assign to the subnet.
    /// </summary>
    public interface IWithNetworkSecurityGroup<ParentT> 
    {
        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="resourceId">The resource ID of the network security group.</param>
        Microsoft.Azure.Management.Network.Fluent.Subnet.Definition.IWithAttach<ParentT> WithExistingNetworkSecurityGroup(string resourceId);

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="nsg">The network security group to assign.</param>
        Microsoft.Azure.Management.Network.Fluent.Subnet.Definition.IWithAttach<ParentT> WithExistingNetworkSecurityGroup(INetworkSecurityGroup nsg);
    }

    /// <summary>
    /// The stage of a subnet definition allowing to specify a route table to associate with the subnet.
    /// </summary>
    public interface IWithRouteTable<ParentT> 
    {
        /// <summary>
        /// Specifies an existing route table to associate with the subnet.
        /// </summary>
        /// <param name="routeTable">An existing route table to associate.</param>
        Microsoft.Azure.Management.Network.Fluent.Subnet.Definition.IWithAttach<ParentT> WithExistingRouteTable(IRouteTable routeTable);

        /// <summary>
        /// Specifies an existing route table to associate with the subnet.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing route table.</param>
        Microsoft.Azure.Management.Network.Fluent.Subnet.Definition.IWithAttach<ParentT> WithExistingRouteTable(string resourceId);
    }

    /// <summary>
    /// The first stage of the subnet definition.
    /// </summary>
    public interface IBlank<ParentT>  :
        IWithAddressPrefix<ParentT>
    {
    }

    /// <summary>
    /// The entirety of a Subnet definition.
    /// </summary>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAddressPrefix<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the subnet definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the subnet definition
    /// can be attached to the parent virtual network definition using WithAttach.attach().
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInDefinition<ParentT>,
        IWithNetworkSecurityGroup<ParentT>,
        IWithRouteTable<ParentT>
    {
    }
}