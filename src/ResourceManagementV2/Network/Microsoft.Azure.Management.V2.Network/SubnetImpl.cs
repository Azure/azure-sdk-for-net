/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.Subnet.Update;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update;
    using Microsoft.Azure.Management.V2.Network.Subnet.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Network.Network.Definition;
    using Microsoft.Azure.Management.V2.Network.Network.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition;
    using Resource.Core.ChildResourceActions;
    using System;
    using Rest.Azure;

    /// <summary>
    /// Implementation for {@link Subnet} and its create and update interfaces.
    /// </summary>
    public class SubnetImpl :
        ChildResource<SubnetInner, NetworkImpl>,
        ISubnet,
        IDefinition<IWithCreateAndSubnet>,
        IUpdateDefinition<Network.Update.IUpdate>,
        Microsoft.Azure.Management.V2.Network.Subnet.Update.IUpdate
    {
        internal SubnetImpl(SubnetInner inner, NetworkImpl parent) :
            base(inner.Id, inner, parent)
        {
        }

        public string AddressPrefix
        {
            get
            {
                return this.Inner.AddressPrefix;
            }
        }

        public string Name
        {
            get
            {
                return this.Inner.Name;
            }
        }

        public INetworkSecurityGroup NetworkSecurityGroup()
        {
            Resource nsgResource = this.Inner.NetworkSecurityGroup;
            if (nsgResource == null)
            {
                return null;
            }
            else
            {
                return this.Parent.MyManager.NetworkSecurityGroups.GetById(nsgResource.Id);
            }
        }

        public SubnetImpl WithExistingNetworkSecurityGroup(string resourceId)
        {
            // Workaround for REST API's expectation of an object rather than string ID - should be fixed in Swagger specs or REST
            SubResource reference = new SubResource();
            reference.Id = resourceId;
            //TODO: doesn't work in .NET
            //this.Inner.NetworkSecurityGroup = reference;
            return this;
        }

        public SubnetImpl WithAddressPrefix(string cidr)
        {
            this.Inner.AddressPrefix = cidr;
            return this;
        }

        public NetworkImpl Attach()
        {
            return this.Parent.WithSubnet(this);
        }

        public SubnetImpl WithExistingNetworkSecurityGroup(INetworkSecurityGroup nsg)
        {

            // return withExistingNetworkSecurityGroup(nsg.id());

            return this;
        }

        Network.Update.IUpdate Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update.IInUpdate<Network.Update.IUpdate>.Attach()
        {
            return this.Attach() as Network.Update.IUpdate;
        }

        /// <returns>the name of the child resource</returns>
        string Microsoft.Azure.Management.V2.Resource.Core.IChildResource.Name
        {
            get
            {
                return this.Name as string;
            }
        }

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="resourceId">resourceId the resource ID of the network security group</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.Definition.IWithAttach<IWithCreateAndSubnet> Microsoft.Azure.Management.V2.Network.Subnet.Definition.IWithNetworkSecurityGroup<IWithCreateAndSubnet>.WithExistingNetworkSecurityGroup(string resourceId)
        {
            return this.WithExistingNetworkSecurityGroup(resourceId) as Microsoft.Azure.Management.V2.Network.Subnet.Definition.IWithAttach<IWithCreateAndSubnet>;
        }

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="nsg">nsg the network security group to assign</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.Definition.IWithAttach<IWithCreateAndSubnet> Microsoft.Azure.Management.V2.Network.Subnet.Definition.IWithNetworkSecurityGroup<IWithCreateAndSubnet>.WithExistingNetworkSecurityGroup(INetworkSecurityGroup nsg)
        {
            return this.WithExistingNetworkSecurityGroup(nsg) as Microsoft.Azure.Management.V2.Network.Subnet.Definition.IWithAttach<IWithCreateAndSubnet>;
        }

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="resourceId">resourceId the resource ID of the network security group</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IWithAttach<Network.Update.IUpdate> Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IWithNetworkSecurityGroup<Network.Update.IUpdate>.WithExistingNetworkSecurityGroup(string resourceId)
        {
            return this.WithExistingNetworkSecurityGroup(resourceId) as Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IWithAttach<Network.Update.IUpdate>;
        }

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="nsg">nsg the network security group to assign</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IWithAttach<Network.Update.IUpdate> Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IWithNetworkSecurityGroup<Network.Update.IUpdate>.WithExistingNetworkSecurityGroup(INetworkSecurityGroup nsg)
        {
            return this.WithExistingNetworkSecurityGroup(nsg) as Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IWithAttach<Network.Update.IUpdate>;
        }

        /// <returns>the address space prefix, in CIDR notation, assigned to this subnet</returns>
        string Microsoft.Azure.Management.V2.Network.ISubnet.AddressPrefix
        {
            get
            {
                return this.AddressPrefix as string;
            }
        }
        /// <returns>the network security group associated with this subnet</returns>
        /// <returns><p></returns>
        /// <returns>Note that this method will result in a call to Azure each time it is invoked.</returns>
        Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup Microsoft.Azure.Management.V2.Network.ISubnet.NetworkSecurityGroup
        {
            get
            {
                return this.NetworkSecurityGroup() as Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup;
            }
        }

        /// <summary>
        /// Specifies the IP address space of the subnet, within the address space of the network.
        /// </summary>
        /// <param name="cidr">cidr the IP address space prefix using the CIDR notation</param>
        /// <returns>the next stage</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.Update.IUpdate Microsoft.Azure.Management.V2.Network.Subnet.Update.IWithAddressPrefix.WithAddressPrefix(string cidr)
        {
            return this.WithAddressPrefix(cidr) as Microsoft.Azure.Management.V2.Network.Subnet.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the IP address space of the subnet, within the address space of the network.
        /// </summary>
        /// <param name="cidr">cidr the IP address space prefix using the CIDR notation</param>
        /// <returns>the next stage of the subnet definition</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.Definition.IWithAttach<IWithCreateAndSubnet> Microsoft.Azure.Management.V2.Network.Subnet.Definition.IWithAddressPrefix<IWithCreateAndSubnet>.WithAddressPrefix(string cidr)
        {
            return this.WithAddressPrefix(cidr) as Microsoft.Azure.Management.V2.Network.Subnet.Definition.IWithAttach<IWithCreateAndSubnet>;
        }

        /// <summary>
        /// Specifies the IP address space of the subnet, within the address space of the network.
        /// </summary>
        /// <param name="cidr">cidr the IP address space prefix using the CIDR notation</param>
        /// <returns>the next stage of the subnet definition</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IWithAttach<Network.Update.IUpdate> Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IWithAddressPrefix<Network.Update.IUpdate>.WithAddressPrefix(string cidr)
        {
            return this.WithAddressPrefix(cidr) as Microsoft.Azure.Management.V2.Network.Subnet.UpdateDefinition.IWithAttach<Network.Update.IUpdate>;
        }

        IWithCreateAndSubnet Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition.IInDefinition<IWithCreateAndSubnet>.Attach()
        {
            return this.Attach() as IWithCreateAndSubnet;
        }

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="resourceId">resourceId the resource ID of the network security group</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.Update.IUpdate Microsoft.Azure.Management.V2.Network.Subnet.Update.IWithNetworkSecurityGroup.WithExistingNetworkSecurityGroup(string resourceId)
        {
            return this.WithExistingNetworkSecurityGroup(resourceId) as Microsoft.Azure.Management.V2.Network.Subnet.Update.IUpdate;
        }

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="nsg">nsg the network security group to assign</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Network.Subnet.Update.IUpdate Microsoft.Azure.Management.V2.Network.Subnet.Update.IWithNetworkSecurityGroup.WithExistingNetworkSecurityGroup(INetworkSecurityGroup nsg)
        {
            return this.WithExistingNetworkSecurityGroup(nsg) as Microsoft.Azure.Management.V2.Network.Subnet.Update.IUpdate;
        }

        Network.Update.IUpdate ISettable<Network.Update.IUpdate>.Parent()
        {
            return base.Parent;
        }
    }
}