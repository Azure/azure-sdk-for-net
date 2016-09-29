// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{
    using Management.Network.Models;
    using Resource.Core;
    using Resource.Core.ChildResourceActions;
    using System;

    /// <summary>
    /// Implementation for Subnet and its create and update interfaces.
    /// </summary>
    public partial class SubnetImpl  :
        ChildResource<SubnetInner, NetworkImpl, INetwork>,
        ISubnet,
        Subnet.Definition.IDefinition<Network.Definition.IWithCreateAndSubnet>,
        Subnet.UpdateDefinition.IUpdateDefinition<Network.Update.IUpdate>,
        Subnet.Update.IUpdate
    {
        protected  SubnetImpl (SubnetInner inner, NetworkImpl parent) : base(inner.Name, inner, parent)
        {
        }

        public string AddressPrefix
        {
            get
            {
            //$ return this.inner().addressPrefix();


                return null;
            }
        }
        override public string Name
        {
            get
            {
            //$ return this.inner().name();


                return null;
            }
        }
        public INetworkSecurityGroup NetworkSecurityGroup ()
        {

            //$ SubResource nsgResource = this.inner().networkSecurityGroup();
            //$ if (nsgResource == null) {
            //$ return null;
            //$ } else {
            //$ return this.parent().manager().networkSecurityGroups().getById(nsgResource.id());
            //$ }

            return null;
        }

        public SubnetImpl WithExistingNetworkSecurityGroup (string resourceId)
        {

            //$ // Workaround for REST API's expectation of an object rather than string ID - should be fixed in Swagger specs or REST
            //$ SubResource reference = new SubResource();
            //$ reference.withId(resourceId);
            //$ 
            //$ this.inner().withNetworkSecurityGroup(reference);
            //$ return this;

            return this;
        }

        public SubnetImpl WithAddressPrefix (string cidr)
        {

            //$ this.inner().withAddressPrefix(cidr);
            //$ return this;

            return this;
        }

        public NetworkImpl Attach ()
        {

            //$ return this.parent().withSubnet(this);

            return null;
        }

        public SubnetImpl WithExistingNetworkSecurityGroup (INetworkSecurityGroup nsg)
        {

            //$ return withExistingNetworkSecurityGroup(nsg.id());

            return this;
        }

        Network.Update.IUpdate ISettable<Network.Update.IUpdate>.Parent()
        {
            throw new NotImplementedException();
        }
    }
}