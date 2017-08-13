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

        
        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        
        ///GENMHASH:735252EE41BE65F02E0EDCE02BD36D0B:57D3EF4D39E9E57A092917227EA8CFA6
        internal RouteTablesImpl(INetworkManager networkManager) : base(networkManager.Inner.RouteTables, networkManager)
        {
        }

        
        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public RouteTableImpl Define(string name)
        {
            return WrapModel(name);
        }

        
        protected async override Task<RouteTableInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken: cancellationToken);
        }

        
        protected async override Task<IPage<RouteTableInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAllAsync(cancellationToken);
        }

        protected async override Task<IPage<RouteTableInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListAllNextAsync(nextLink, cancellationToken);
        }

        
        protected async override Task<IPage<RouteTableInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(groupName, cancellationToken);
        }

        protected async override Task<IPage<RouteTableInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        
        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:E3C9246A7C00088B093045C43802BAF8
        protected override RouteTableImpl WrapModel(string name)
        {
            RouteTableInner inner = new RouteTableInner();
            return new RouteTableImpl(name, inner, Manager);
        }

        
        ///GENMHASH:94F659065F113D561DCD4FF928601AA3:01916A6C10F86D33284D0E71B50D493D
        protected override IRouteTable WrapModel(RouteTableInner inner)
        {
            return new RouteTableImpl(inner.Name, inner, Manager);
        }
    }
}
