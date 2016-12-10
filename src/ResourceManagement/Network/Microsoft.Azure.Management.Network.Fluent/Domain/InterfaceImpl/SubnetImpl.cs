// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Network.Definition;
    using Network.Update;
    using Subnet.Definition;
    using Subnet.Update;
    using Subnet.UpdateDefinition;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;

    internal partial class SubnetImpl 
    {
        /// <summary>
        /// Specifies an existing route table to associate with the subnet.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing route table.</param>
        /// <return>The next stage of the update.</return>
        Subnet.Update.IUpdate Subnet.Update.IWithRouteTable.WithExistingRouteTable(string resourceId)
        {
            return this.WithExistingRouteTable(resourceId) as Subnet.Update.IUpdate;
        }

        /// <summary>
        /// Specifies an existing route table to associate with the subnet.
        /// </summary>
        /// <param name="routeTable">An existing route table to associate.</param>
        /// <return>The next stage of the update.</return>
        Subnet.Update.IUpdate Subnet.Update.IWithRouteTable.WithExistingRouteTable(IRouteTable routeTable)
        {
            return this.WithExistingRouteTable(routeTable) as Subnet.Update.IUpdate;
        }

        /// <summary>
        /// Removes the association with a route table, if any.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Subnet.Update.IUpdate Subnet.Update.IWithRouteTable.WithoutRouteTable()
        {
            return this.WithoutRouteTable() as Subnet.Update.IUpdate;
        }

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="nsg">The network security group to assign.</param>
        /// <return>The next stage of the update.</return>
        Subnet.Update.IUpdate Subnet.Update.IWithNetworkSecurityGroup.WithExistingNetworkSecurityGroup(INetworkSecurityGroup nsg)
        {
            return this.WithExistingNetworkSecurityGroup(nsg) as Subnet.Update.IUpdate;
        }

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="resourceId">The resource ID of the network security group.</param>
        /// <return>The next stage of the update.</return>
        Subnet.Update.IUpdate Subnet.Update.IWithNetworkSecurityGroup.WithExistingNetworkSecurityGroup(string resourceId)
        {
            return this.WithExistingNetworkSecurityGroup(resourceId) as Subnet.Update.IUpdate;
        }

        /// <return>
        /// The route table associated with this subnet, if any
        /// Note that this method will result in a call to Azure each time it is invoked.
        /// </return>
        Microsoft.Azure.Management.Network.Fluent.IRouteTable Microsoft.Azure.Management.Network.Fluent.ISubnet.GetRouteTable()
        {
            return this.GetRouteTable() as Microsoft.Azure.Management.Network.Fluent.IRouteTable;
        }

        /// <summary>
        /// Gets the address space prefix, in CIDR notation, assigned to this subnet.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.ISubnet.AddressPrefix
        {
            get
            {
                return this.AddressPrefix();
            }
        }

        /// <summary>
        /// Gets the resource ID of the network security group associated with this subnet, if any.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.ISubnet.NetworkSecurityGroupId
        {
            get
            {
                return this.NetworkSecurityGroupId();
            }
        }

        /// <return>
        /// The network security group associated with this subnet, if any
        /// Note that this method will result in a call to Azure each time it is invoked.
        /// </return>
        Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup Microsoft.Azure.Management.Network.Fluent.ISubnet.GetNetworkSecurityGroup()
        {
            return this.GetNetworkSecurityGroup() as Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup;
        }

        /// <summary>
        /// Gets the resource ID of the route table associated with this subnet, if any.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.ISubnet.RouteTableId
        {
            get
            {
                return this.RouteTableId();
            }
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Specifies the IP address space of the subnet, within the address space of the network.
        /// </summary>
        /// <param name="cidr">The IP address space prefix using the CIDR notation.</param>
        /// <return>The next stage of the subnet definition.</return>
        Subnet.Definition.IWithAttach<Network.Definition.IWithCreateAndSubnet> Subnet.Definition.IWithAddressPrefix<Network.Definition.IWithCreateAndSubnet>.WithAddressPrefix(string cidr)
        {
            return this.WithAddressPrefix(cidr) as Subnet.Definition.IWithAttach<Network.Definition.IWithCreateAndSubnet>;
        }

        /// <summary>
        /// Specifies the IP address space of the subnet, within the address space of the network.
        /// </summary>
        /// <param name="cidr">The IP address space prefix using the CIDR notation.</param>
        /// <return>The next stage of the subnet definition.</return>
        Subnet.UpdateDefinition.IWithAttach<Network.Update.IUpdate> Subnet.UpdateDefinition.IWithAddressPrefix<Network.Update.IUpdate>.WithAddressPrefix(string cidr)
        {
            return this.WithAddressPrefix(cidr) as Subnet.UpdateDefinition.IWithAttach<Network.Update.IUpdate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        Network.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<Network.Update.IUpdate>.Attach()
        {
            return this.Attach() as Network.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        Network.Definition.IWithCreateAndSubnet Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<Network.Definition.IWithCreateAndSubnet>.Attach()
        {
            return this.Attach() as Network.Definition.IWithCreateAndSubnet;
        }

        /// <summary>
        /// Specifies an existing route table to associate with the subnet.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing route table.</param>
        /// <return>The next stage of the definition.</return>
        Subnet.Definition.IWithAttach<Network.Definition.IWithCreateAndSubnet> Subnet.Definition.IWithRouteTable<Network.Definition.IWithCreateAndSubnet>.WithExistingRouteTable(string resourceId)
        {
            return this.WithExistingRouteTable(resourceId) as Subnet.Definition.IWithAttach<Network.Definition.IWithCreateAndSubnet>;
        }

        /// <summary>
        /// Specifies an existing route table to associate with the subnet.
        /// </summary>
        /// <param name="routeTable">An existing route table to associate.</param>
        /// <return>The next stage of the definition.</return>
        Subnet.Definition.IWithAttach<Network.Definition.IWithCreateAndSubnet> Subnet.Definition.IWithRouteTable<Network.Definition.IWithCreateAndSubnet>.WithExistingRouteTable(IRouteTable routeTable)
        {
            return this.WithExistingRouteTable(routeTable) as Subnet.Definition.IWithAttach<Network.Definition.IWithCreateAndSubnet>;
        }

        /// <summary>
        /// Specifies an existing route table to associate with the subnet.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing route table.</param>
        /// <return>The next stage of the definition.</return>
        Subnet.UpdateDefinition.IWithAttach<Network.Update.IUpdate> Subnet.UpdateDefinition.IWithRouteTable<Network.Update.IUpdate>.WithExistingRouteTable(string resourceId)
        {
            return this.WithExistingRouteTable(resourceId) as Subnet.UpdateDefinition.IWithAttach<Network.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies an existing route table to associate with the subnet.
        /// </summary>
        /// <param name="routeTable">An existing route table to associate.</param>
        /// <return>The next stage of the definition.</return>
        Subnet.UpdateDefinition.IWithAttach<Network.Update.IUpdate> Subnet.UpdateDefinition.IWithRouteTable<Network.Update.IUpdate>.WithExistingRouteTable(IRouteTable routeTable)
        {
            return this.WithExistingRouteTable(routeTable) as Subnet.UpdateDefinition.IWithAttach<Network.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the IP address space of the subnet, within the address space of the network.
        /// </summary>
        /// <param name="cidr">The IP address space prefix using the CIDR notation.</param>
        /// <return>The next stage.</return>
        Subnet.Update.IUpdate Subnet.Update.IWithAddressPrefix.WithAddressPrefix(string cidr)
        {
            return this.WithAddressPrefix(cidr) as Subnet.Update.IUpdate;
        }

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="nsg">The network security group to assign.</param>
        /// <return>The next stage of the definition.</return>
        Subnet.Definition.IWithAttach<Network.Definition.IWithCreateAndSubnet> Subnet.Definition.IWithNetworkSecurityGroup<Network.Definition.IWithCreateAndSubnet>.WithExistingNetworkSecurityGroup(INetworkSecurityGroup nsg)
        {
            return this.WithExistingNetworkSecurityGroup(nsg) as Subnet.Definition.IWithAttach<Network.Definition.IWithCreateAndSubnet>;
        }

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="resourceId">The resource ID of the network security group.</param>
        /// <return>The next stage of the definition.</return>
        Subnet.Definition.IWithAttach<Network.Definition.IWithCreateAndSubnet> Subnet.Definition.IWithNetworkSecurityGroup<Network.Definition.IWithCreateAndSubnet>.WithExistingNetworkSecurityGroup(string resourceId)
        {
            return this.WithExistingNetworkSecurityGroup(resourceId) as Subnet.Definition.IWithAttach<Network.Definition.IWithCreateAndSubnet>;
        }

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="nsg">The network security group to assign.</param>
        /// <return>The next stage of the definition.</return>
        Subnet.UpdateDefinition.IWithAttach<Network.Update.IUpdate> Subnet.UpdateDefinition.IWithNetworkSecurityGroup<Network.Update.IUpdate>.WithExistingNetworkSecurityGroup(INetworkSecurityGroup nsg)
        {
            return this.WithExistingNetworkSecurityGroup(nsg) as Subnet.UpdateDefinition.IWithAttach<Network.Update.IUpdate>;
        }

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="resourceId">The resource ID of the network security group.</param>
        /// <return>The next stage of the definition.</return>
        Subnet.UpdateDefinition.IWithAttach<Network.Update.IUpdate> Subnet.UpdateDefinition.IWithNetworkSecurityGroup<Network.Update.IUpdate>.WithExistingNetworkSecurityGroup(string resourceId)
        {
            return this.WithExistingNetworkSecurityGroup(resourceId) as Subnet.UpdateDefinition.IWithAttach<Network.Update.IUpdate>;
        }
    }
}