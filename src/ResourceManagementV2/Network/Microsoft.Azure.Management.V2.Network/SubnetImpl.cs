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
    public partial class SubnetImpl :
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

        Network.Update.IUpdate ISettable<Network.Update.IUpdate>.Parent()
        {
            return base.Parent;
        }
    }
}