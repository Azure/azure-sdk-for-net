// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Resource.Fluent;

    /// <summary>
    /// Implementation for RouteTables.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uUm91dGVUYWJsZXNJbXBs
    public partial class RouteTablesImpl :
        GroupableResources<Microsoft.Azure.Management.Network.Fluent.IRouteTable, Microsoft.Azure.Management.Network.Fluent.RouteTableImpl, Models.RouteTableInner, IRouteTablesOperations, INetworkManager>,
        IRouteTables
    {
        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
        public override Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.InnerCollection.DeleteAsync(groupName, name);
        }

        ///GENMHASH:8257BDEA83EA75371BBAD6EFAF87E8AD:27A33792B39BF284AA170EA2D21817BE
        internal RouteTablesImpl(INetworkManagementClient networkClient, INetworkManager networkManager) : base(networkClient.RouteTables, networkManager)
        {
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public RouteTableImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        public override async Task<IRouteTable> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var data = await this.InnerCollection.GetAsync(groupName, name, null, cancellationToken);
            return WrapModel(data);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:36E25639805611CF89054C004B22BB15
        public PagedList<Microsoft.Azure.Management.Network.Fluent.IRouteTable> List()
        {
            var pagedList = new PagedList<RouteTableInner>(InnerCollection.ListAll(), (string nextPageLink) =>
            {
                return InnerCollection.ListAllNext(nextPageLink);
            });
            return WrapList(pagedList);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:3953AC722DFFCDF40E1EEF787AFD1326
        public PagedList<Microsoft.Azure.Management.Network.Fluent.IRouteTable> ListByGroup(string groupName)
        {
            var pagedList = new PagedList<RouteTableInner>(InnerCollection.List(groupName), (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
            });
            return WrapList(pagedList);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:38805A03589651CF73316E5DDCC06E90
        protected override RouteTableImpl WrapModel(string name)
        {
            RouteTableInner inner = new RouteTableInner();
            return new RouteTableImpl(name, inner, this.InnerCollection, this.Manager);
        }

        ///GENMHASH:94F659065F113D561DCD4FF928601AA3:B4753C73FFD737567848B1D8D4A06D23
        protected override IRouteTable WrapModel(RouteTableInner inner)
        {
            return new RouteTableImpl(
                inner.Name,
                inner,
                this.InnerCollection,
                this.Manager);
        }
    }
}