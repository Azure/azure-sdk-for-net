// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ResourceManager.Fluent.Core;
    using System.Threading.Tasks;
    using System.Threading;
    using Models;

    /// <summary>
    /// Implementation for LoadBalancers.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTG9hZEJhbGFuY2Vyc0ltcGw=
    internal partial class LoadBalancersImpl  :
        GroupableResources<
            ILoadBalancer,
            LoadBalancerImpl,
            LoadBalancerInner,
            ILoadBalancersOperations,
            INetworkManager>,
        ILoadBalancers
    {
        ///GENMHASH:DC62D974883C70D83DDB9D5F4637868C:C8672EF40558C709D72F2EABF261037D
        internal LoadBalancersImpl(INetworkManager networkManager)
            : base(networkManager.Inner.LoadBalancers, networkManager)
        {
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:36E25639805611CF89054C004B22BB15
        internal PagedList<ILoadBalancer> List ()
        {
            var pagedList = new PagedList<LoadBalancerInner>(Inner.ListAll(), (string nextPageLink) =>
            {
                return Inner.ListAllNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:3953AC722DFFCDF40E1EEF787AFD1326
        internal PagedList<ILoadBalancer> ListByGroup (string groupName)
        {
            var pagedList = new PagedList<LoadBalancerInner>(Inner.List(groupName), (string nextPageLink) =>
            {
                return Inner.ListNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        internal LoadBalancerImpl Define (string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:B14D568C7C14C41A51FD32AE82AC8312
        override protected LoadBalancerImpl WrapModel (string name)
        {
            LoadBalancerInner inner = new LoadBalancerInner();
            return new LoadBalancerImpl(name, inner, Manager);
        }

        ///GENMHASH:2B5A2E3F465A968F1950DAD37181F731:F150C6361EF462F597E93FAB337DC91B
        override protected ILoadBalancer WrapModel (LoadBalancerInner inner) //$TODO: This needs to return LoadBalancerImpl
        {
            return new LoadBalancerImpl(inner.Name, inner, Manager);
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
        public override Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Inner.DeleteAsync(groupName, name);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        public override async Task<ILoadBalancer> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var data = await Inner.GetAsync(groupName, name, null, cancellationToken);
            return WrapModel(data);
        }

        public void Delete(string id)
        {
            DeleteAsync(id).Wait();
        }

        public Task DeleteAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteByGroupAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }
    }
}
