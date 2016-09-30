// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{
    using Management.Network.Models;
    using Resource.Core;
    using Resource.Core.ChildResourceActions;
    using Rest.Azure;
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
        internal SubnetImpl (SubnetInner inner, NetworkImpl parent) : base(inner.Name, inner, parent)
        {
        }

        public string AddressPrefix
        {
            get
            {
                return Inner.AddressPrefix;
            }
        }

        override public string Name()
        {
            return Inner.Name;
        }

        public INetworkSecurityGroup GetNetworkSecurityGroup ()
        {
            var nsgResource = Inner.NetworkSecurityGroup;
            return (nsgResource != null) ? Parent.Manager.NetworkSecurityGroups.GetById(nsgResource.Id) : null;
        }

        public SubnetImpl WithExistingNetworkSecurityGroup (string resourceId)
        {
            NetworkSecurityGroupInner reference = new NetworkSecurityGroupInner(id: resourceId);
            Inner.NetworkSecurityGroup = reference;
            return this;
        }

        public SubnetImpl WithAddressPrefix (string cidr)
        {
            Inner.AddressPrefix = cidr;
            return this;
        }

        public NetworkImpl Attach ()
        {
            return Parent.WithSubnet(this);
        }

        public SubnetImpl WithExistingNetworkSecurityGroup (INetworkSecurityGroup nsg)
        {
            return WithExistingNetworkSecurityGroup(nsg.Id);
        }

        Network.Update.IUpdate ISettable<Network.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}