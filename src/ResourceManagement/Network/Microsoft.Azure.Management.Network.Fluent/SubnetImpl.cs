// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uU3VibmV0SW1wbA==
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Management.Network.Fluent.Models;
    using Resource.Fluent;
    using Resource.Fluent.Core;
    using Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Implementation for Subnet and its create and update interfaces.
    /// </summary>
    internal partial class SubnetImpl  :
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

        ///GENMHASH:A9777D8010E6AF7B603113E49858FE75:0A1C32015C3FE7888D450702542868EA
        public string NetworkSecurityGroupId()
        {
            return (this.Inner.NetworkSecurityGroup != null) ? this.Inner.NetworkSecurityGroup.Id : null;
        }

        ///GENMHASH:A52B043B03F5F5DD10F6A96CBC569DBC:08C6FC794C26CE7AA9BBF95E8E59293F
        public string RouteTableId()
        {
            return (this.Inner.RouteTable != null) ? this.Inner.RouteTable.Id : null;
        }

        ///GENMHASH:2E4015B29759BBD97527EBAE809B083C:8E698A4D3F26647C89221EE26B291774
        internal INetworkSecurityGroup GetNetworkSecurityGroup ()
        {
            return (this.NetworkSecurityGroupId() != null)
                ? this.Parent.Manager.NetworkSecurityGroups.GetById(this.RouteTableId())
                : null;
        }

        ///GENMHASH:749BD8C1D070A6DAE2D9F29DAE294FAE:9DD0E90F3B1A067185751A1074341EAF
        internal SubnetImpl WithExistingNetworkSecurityGroup(string resourceId)
        {
            // Workaround for REST API's expectation of an object rather than string ID - should be fixed in Swagger specs or REST
            SubResource reference = new SubResource {
                Id = resourceId
            };
            this.Inner.NetworkSecurityGroup = reference;
            return this;
        }

        ///GENMHASH:9BCDEB79AFC04D55B9BC280847723DFC:3BACEC234E558FC90E41F9212B768D2E
        internal SubnetImpl WithExistingNetworkSecurityGroup(INetworkSecurityGroup nsg)
        {
            return WithExistingNetworkSecurityGroup(nsg.Id);
        }

        ///GENMHASH:FCA489D9E7B6963A2EAC736958554ABD:772ECDA870E1C3E00E31EFE045675F09
        public SubnetImpl WithExistingRouteTable(IRouteTable routeTable)
        {
            return this.WithExistingRouteTable(routeTable.Id);
        }

        ///GENMHASH:C142A0234F22048E67709B65DD642261:61C2A1A23D6BCA62D6705980C8D1BECE
        public SubnetImpl WithExistingRouteTable(string resourceId)
        {
            SubResource reference = new SubResource
            {
                Id = resourceId
            };
            this.Inner.RouteTable = reference;
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

        Network.Update.IUpdate ISettable<Network.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}
