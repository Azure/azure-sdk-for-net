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
    /// Implementation for LoadBalancers.
    /// </summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTG9hZEJhbGFuY2Vyc0ltcGw=
    internal partial class LoadBalancersImpl  :
        TopLevelModifiableResources<
            ILoadBalancer,
            LoadBalancerImpl,
            LoadBalancerInner,
            ILoadBalancersOperations,
            INetworkManager>,
        ILoadBalancers
    {
        ///GENMHASH:DA82766F865EA6DCF8F9E9790A097788:A675C0208DC150DEB3BB4230F74B14DA
        internal LoadBalancersImpl(INetworkManager networkManager)
            : base(networkManager.Inner.LoadBalancers, networkManager)
        {
        }

        protected async override Task<IPage<LoadBalancerInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAllAsync(cancellationToken);
        }

        protected async override Task<IPage<LoadBalancerInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListAllNextAsync(nextLink, cancellationToken);
        }

        protected async override Task<IPage<LoadBalancerInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(groupName, cancellationToken);
        }

        protected async override Task<IPage<LoadBalancerInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        
        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        internal LoadBalancerImpl Define (string name)
        {
            return WrapModel(name);
        }

        
        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:955ABA32605E2D033D085013B5575701
        override protected LoadBalancerImpl WrapModel (string name)
        {
            LoadBalancerInner inner = new LoadBalancerInner();
            return new LoadBalancerImpl(name, inner, Manager);
        }

        
        ///GENMHASH:2B5A2E3F465A968F1950DAD37181F731:1ADEB39F57BD1687BFE8CBC48B389D64
        override protected ILoadBalancer WrapModel (LoadBalancerInner inner) //$TODO: This needs to return LoadBalancerImpl
        {
            return (inner != null) ? new LoadBalancerImpl(inner.Name, inner, Manager) : null;
        }

        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        protected async override Task<LoadBalancerInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken: cancellationToken);
        }

        internal void Delete(string id)
        {
            Extensions.Synchronize(() => DeleteAsync(id));
        }

        internal async Task DeleteAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            await DeleteByResourceGroupAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id), cancellationToken);
        }
    }
}
