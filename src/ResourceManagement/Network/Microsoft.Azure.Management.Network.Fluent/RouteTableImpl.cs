// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading.Tasks;
    using Models;
    using RouteTable.Definition;
    using RouteTable.Update;
    using Resource.Fluent.Core;
    using System.Collections.Generic;
    using Resource.Fluent;

    /// <summary>
    /// Implementation for RouteTable.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uUm91dGVUYWJsZUltcGw=
    internal partial class RouteTableImpl :
        GroupableParentResource<IRouteTable,
            RouteTableInner,
            RouteTableImpl,
            INetworkManager,
            IWithGroup,
            IWithCreate,
            IWithCreate,
            IUpdate>,
        IRouteTable,
        IDefinition,
        IUpdate
    {
        private IRouteTablesOperations innerCollection;
        private IDictionary<string, IRoute> routes;

        ///GENMHASH:359B78C1848B4A526D723F29D8C8C558:7501824DEE4570F3E78F9698BA2828B0
        override protected Task<RouteTableInner> CreateInnerAsync()
        {
            return innerCollection.CreateOrUpdateAsync(ResourceGroupName, Name, Inner);
        }

        ///GENMHASH:71D5B4DBFB32B4FF553CCD0A78B871EC:16C831421CFC3F51EA84222302D9DFFE
        public RouteTableImpl WithRouteViaVirtualAppliance(string destinationAddressPrefix, string ipAddress)
        {
            return DefineRoute(SharedSettings.RandomResourceName("route_" + Name, 20))
                .WithDestinationAddressPrefix(destinationAddressPrefix)
                .WithNextHopToVirtualAppliance(ipAddress)
                .Attach();
        }

        ///GENMHASH:AC21A10EE2E745A89E94E447800452C1:4C83A0857E35E9D9125E99A535D6794D
        protected override void BeforeCreating()
        {
            // Reset and update routes
            Inner.Routes = InnersFromWrappers<RouteInner, IRoute>(routes.Values);
        }

        ///GENMHASH:3B1D4D2EFBD5C45DE94FCFE767ABF5CA:1D7FCAA2D6FAECB86AD425172AFE9F3B
        public RouteImpl DefineRoute(string name)
        {
            RouteInner inner = new RouteInner
            {
                Name = name
            };
            return new RouteImpl(inner, this);
        }

        ///GENMHASH:6D9F740D6D73C56877B02D9F1C96F6E7:D75982055CC5C26B8FFA947E77CA3625
        protected override void InitializeChildrenFromInner()
        {
            routes = new Dictionary<string, IRoute>();
            if (Inner.Routes != null)
            {
                foreach (var innerRoutes in this.Inner.Routes)
                {
                    routes.Add(Inner.Name, new RouteImpl(innerRoutes, this));
                }
            }
        }

        ///GENMHASH:F91F57741BB7E185BF012523964DEED0:B855D73B977281A4DC1F154F5A7D4DC5
        protected override void AfterCreating()
        {
            InitializeChildrenFromInner();
        }

        internal RouteTableImpl(string name, RouteTableInner innerModel, IRouteTablesOperations innerCollection, INetworkManager networkManager) : base(name, innerModel, networkManager)
        {
            this.innerCollection = innerCollection;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:3C24CB44825C9FD8973A23CA91FB4FD1
        public override IRouteTable Refresh()
        {
            RouteTableInner inner = innerCollection.Get(ResourceGroupName, Name);
            SetInner(inner);
            InitializeChildrenFromInner();
            return this;
        }

        ///GENMHASH:8200D5EDD19C5D72B80F6841AD9D0FF0:F58B9D6D280E3F1581C12EFC5360F4C9
        public RouteTableImpl WithRoute(string destinationAddressPrefix, RouteNextHopType nextHop)
        {
            return DefineRoute(SharedSettings.RandomResourceName("route_" + Name, 20))
                .WithDestinationAddressPrefix(destinationAddressPrefix)
                .WithNextHop(nextHop)
                .Attach();
        }

        ///GENMHASH:D8AE7CC0DB930E5BDA50AC123948A402:AF91F09FC589F933217F1041582375CB
        internal RouteTableImpl WithRoute(RouteImpl route)
        {
            if (!routes.ContainsKey(route.Name()))
            {
                routes.Add(route.Name(), route);
            }
            return this;
        }

        ///GENMHASH:F9626EDD83A5083970F3624D111D5F9A:7C77591C832F84A949CE9BF6525CCF9B
        public IReadOnlyDictionary<string, IRoute> Routes()
        {
            return routes as IReadOnlyDictionary<string, IRoute>;
        }

        ///GENMHASH:E78D7ACAEEE05A0117BC7B6E41B0D53B:062BFEFE0393BE2C1D9F8B1A963FDE23
        public IList<ISubnet> ListAssociatedSubnets()
        {
            return this.Manager.ListAssociatedSubnets(Inner.Subnets);
        }

        ///GENMHASH:89F59CCCF3B6B14229530994A0DA5942:19D9729552F6E7123B2248B0E7B19823
        public RouteImpl UpdateRoute(string name)
        {
            IRoute value = null;
            if (routes.TryGetValue(name, out value))
            {
                return (RouteImpl)value;
            }
            return null;
        }

        ///GENMHASH:7E8C2CF692FADDB1CA4FDD208175D2BD:DA4ECB14ABD20F728F32A3B6D3951691
        public IUpdate WithoutRoute(string name)
        {
            routes.Remove(name);
            return this;
        }
    }
}
