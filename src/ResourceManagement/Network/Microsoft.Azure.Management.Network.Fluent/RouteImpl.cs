// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Route.Definition;
    using Route.Update;
    using Route.UpdateDefinition;
    using Models;
    using RouteTable.Definition;
    using RouteTable.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Implementation of Route.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uUm91dGVJbXBs
    internal partial class RouteImpl :
        ChildResource<Models.RouteInner, Microsoft.Azure.Management.Network.Fluent.RouteTableImpl, Microsoft.Azure.Management.Network.Fluent.IRouteTable>,
        IRoute,
        IDefinition<RouteTable.Definition.IWithCreate>,
        IUpdateDefinition<RouteTable.Update.IUpdate>,
        Route.Update.IUpdate
    {
        ///GENMHASH:DA055B08DA468C4A0FDC8D28BC654F0A:8F0C59692A7F0EEB231DF5A0F980E52E
        public string DestinationAddressPrefix()
        {
            return this.Inner.AddressPrefix;
        }

        ///GENMHASH:1AE50C561DDB7EC1CBF9E9D75A7B7164:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal RouteImpl(RouteInner inner, RouteTableImpl parent) : base(inner, parent)
        {
        }

        ///GENMHASH:1A553C030DC524BC4CB44FE760C17EDC:FE030A8DB000669434FF6335D5D2136F
        public RouteImpl WithDestinationAddressPrefix(string cidr)
        {
            this.Inner.AddressPrefix = cidr;
            return this;
        }

        ///GENMHASH:41D73337A94BA1CFBD7B6D9FBD76CDA8:3FBB22911E1E512603F245E0624E5230
        public RouteNextHopType NextHopType()
        {
            return new RouteNextHopType(this.Inner.NextHopType);
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return this.Inner.Name;
        }

        ///GENMHASH:EFA460D76414989C19313238DD20AA41:CEBC3F1E3A32B8EA1607917FBF09520A
        public RouteImpl WithNextHopToVirtualAppliance(string ipAddress)
        {
            this.Inner.NextHopType = RouteNextHopType.VIRTUAL_APPLIANCE.ToString();
            this.Inner.NextHopIpAddress = ipAddress;
            return this;
        }

        ///GENMHASH:C735AF0BF8BEB3EB5BC91A83ED36EC28:C4C5BAB467876CDE1C62F1319F9D3626
        public string NextHopIpAddress()
        {
            return this.Inner.NextHopIpAddress;
        }

        ///GENMHASH:8250561E62A0930DA1780FF8F83EA1AE:F0C4F9C231DA6D3EC53103DC8186BB72
        public RouteImpl WithNextHop(RouteNextHopType nextHopType)
        {
            this.Inner.NextHopType = nextHopType.ToString();
            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:BC3BEFD624F09CE7F6690B5322A7BDBD
        public RouteTableImpl Attach()
        {
            return this.Parent.WithRoute(this);
        }

        RouteTable.Update.IUpdate ISettable<RouteTable.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}