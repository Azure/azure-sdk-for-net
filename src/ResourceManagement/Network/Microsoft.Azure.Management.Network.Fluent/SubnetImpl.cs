// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{
    using Management.Network.Models;
    using Resource.Core;
    using Resource.Core.ChildResourceActions;

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
        internal SubnetImpl (SubnetInner inner, NetworkImpl parent) : base(inner, parent)
        {
        }

        internal string AddressPrefix()
        {
            return Inner.AddressPrefix;
        }

        public override string Name()
        {
            return Inner.Name;
        }

        internal INetworkSecurityGroup GetNetworkSecurityGroup ()
        {
            var nsgResource = Inner.NetworkSecurityGroup;
            return (nsgResource != null) ? Parent.Manager.NetworkSecurityGroups.GetById(nsgResource.Id) : null;
        }

        internal SubnetImpl WithExistingNetworkSecurityGroup (string resourceId)
        {
            NetworkSecurityGroupInner reference = new NetworkSecurityGroupInner(id: resourceId);
            Inner.NetworkSecurityGroup = reference;
            return this;
        }

        internal SubnetImpl WithAddressPrefix (string cidr)
        {
            Inner.AddressPrefix = cidr;
            return this;
        }

        internal NetworkImpl Attach ()
        {
            return Parent.WithSubnet(this);
        }

        internal SubnetImpl WithExistingNetworkSecurityGroup (INetworkSecurityGroup nsg)
        {
            return WithExistingNetworkSecurityGroup(nsg.Id);
        }

        Network.Update.IUpdate ISettable<Network.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}