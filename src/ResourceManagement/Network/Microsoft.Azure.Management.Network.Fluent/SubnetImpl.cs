// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uU3VibmV0SW1wbA==
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Management.Network.Fluent.Models;
    using Resource.Fluent.Core;
    using Resource.Fluent.Core.ChildResourceActions;

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

        ///GENMHASH:B9CBDB4C51BC9B92E1A239DE256FB5B6:8F0C59692A7F0EEB231DF5A0F980E52E
        internal string AddressPrefix()
        {
            return Inner.AddressPrefix;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:2E4015B29759BBD97527EBAE809B083C:EC0B50489DBC5780794937134CA94137
        internal INetworkSecurityGroup GetNetworkSecurityGroup ()
        {
            var nsgResource = Inner.NetworkSecurityGroup;
            return (nsgResource != null) ? Parent.Manager.NetworkSecurityGroups.GetById(nsgResource.Id) : null;
        }

        ///GENMHASH:749BD8C1D070A6DAE2D9F29DAE294FAE:54591EF54EDDCC34B41F117015F10C98
        internal SubnetImpl WithExistingNetworkSecurityGroup (string resourceId)
        {
            NetworkSecurityGroupInner reference = new NetworkSecurityGroupInner(id: resourceId);
            Inner.NetworkSecurityGroup = reference;
            return this;
        }

        ///GENMHASH:E56906080D3615F5D04C5EFAC903C1FB:FE030A8DB000669434FF6335D5D2136F
        internal SubnetImpl WithAddressPrefix (string cidr)
        {
            Inner.AddressPrefix = cidr;
            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:3EB15D579457E999436D02A2F8EEB291
        internal NetworkImpl Attach ()
        {
            return Parent.WithSubnet(this);
        }

        ///GENMHASH:9BCDEB79AFC04D55B9BC280847723DFC:3BACEC234E558FC90E41F9212B768D2E
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
