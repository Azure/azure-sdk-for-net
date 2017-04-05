// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using Rest.Azure;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for RouteTables.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uUm91dGVUYWJsZXNJbXBs
    internal partial class RouteTablesImpl :
        TopLevelModifiableResources<IRouteTable, RouteTableImpl, RouteTableInner, IRouteTablesOperations, INetworkManager>,
        IRouteTables
    {

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:8257BDEA83EA75371BBAD6EFAF87E8AD:27A33792B39BF284AA170EA2D21817BE
        internal RouteTablesImpl(INetworkManager networkManager) : base(networkManager.Inner.RouteTables, networkManager)
        {
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public RouteTableImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        protected async override Task<RouteTableInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:36E25639805611CF89054C004B22BB15
        protected async override Task<IPage<RouteTableInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAllAsync(cancellationToken);
        }

        protected async override Task<IPage<RouteTableInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListAllNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:3953AC722DFFCDF40E1EEF787AFD1326
        protected async override Task<IPage<RouteTableInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(groupName, cancellationToken);
        }

        protected async override Task<IPage<RouteTableInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:38805A03589651CF73316E5DDCC06E90
        protected override RouteTableImpl WrapModel(string name)
        {
            RouteTableInner inner = new RouteTableInner();
            return new RouteTableImpl(name, inner, Manager);
        }

        ///GENMHASH:94F659065F113D561DCD4FF928601AA3:B4753C73FFD737567848B1D8D4A06D23
        protected override IRouteTable WrapModel(RouteTableInner inner)
        {
            return new RouteTableImpl(inner.Name, inner, Manager);
        }
    }
}
