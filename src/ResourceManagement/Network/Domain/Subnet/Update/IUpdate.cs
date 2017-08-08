// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.Subnet.Update
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Network.Fluent.Network.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The stage of the subnet update allowing to change the network security group to assign to the subnet.
    /// </summary>
    public interface IWithNetworkSecurityGroup 
    {
        /// <summary>
        /// Removes the association of this subnet with any network security group.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.Subnet.Update.IUpdate WithoutNetworkSecurityGroup();

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="resourceId">The resource ID of the network security group.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.Subnet.Update.IUpdate WithExistingNetworkSecurityGroup(string resourceId);

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="nsg">The network security group to assign.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.Subnet.Update.IUpdate WithExistingNetworkSecurityGroup(INetworkSecurityGroup nsg);
    }

    /// <summary>
    /// The entirety of a subnet update as part of a network update.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.Network.Fluent.Subnet.Update.IWithAddressPrefix,
        Microsoft.Azure.Management.Network.Fluent.Subnet.Update.IWithNetworkSecurityGroup,
        Microsoft.Azure.Management.Network.Fluent.Subnet.Update.IWithRouteTable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.Network.Fluent.Network.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of the subnet update allowing to change the address space for the subnet.
    /// </summary>
    public interface IWithAddressPrefix 
    {
        /// <summary>
        /// Specifies the IP address space of the subnet, within the address space of the network.
        /// </summary>
        /// <param name="cidr">The IP address space prefix using the CIDR notation.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.Subnet.Update.IUpdate WithAddressPrefix(string cidr);
    }

    /// <summary>
    /// The stage of a subnet update allowing to specify a route table to associate with the subnet, or remove an existing association.
    /// </summary>
    public interface IWithRouteTable 
    {
        /// <summary>
        /// Specifies an existing route table to associate with the subnet.
        /// </summary>
        /// <param name="routeTable">An existing route table to associate.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.Subnet.Update.IUpdate WithExistingRouteTable(IRouteTable routeTable);

        /// <summary>
        /// Specifies an existing route table to associate with the subnet.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing route table.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.Subnet.Update.IUpdate WithExistingRouteTable(string resourceId);

        /// <summary>
        /// Removes the association with a route table, if any.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.Subnet.Update.IUpdate WithoutRouteTable();
    }
}