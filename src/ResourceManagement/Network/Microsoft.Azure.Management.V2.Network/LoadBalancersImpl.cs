// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using Resource.Core;
    using System.Threading.Tasks;
    using System.Threading;
    using Management.Network.Models;
    using Resource.Core.CollectionActions;
    using Management.Network;

    /// <summary>
    /// Implementation for ILoadBalancers.
    /// </summary>
    public partial class LoadBalancersImpl  :
        GroupableResources<
            ILoadBalancer,
            LoadBalancerImpl,
            LoadBalancerInner,
            ILoadBalancersOperations,
            NetworkManager>,
        ILoadBalancers
    {
        internal LoadBalancersImpl(NetworkManagementClient networkClient, NetworkManager networkManager) 
            : base(networkClient.LoadBalancers, networkManager)
        {
        }

        public PagedList<ILoadBalancer> List ()
        {
            var pagedList = new PagedList<LoadBalancerInner>(InnerCollection.ListAll(), (string nextPageLink) =>
            {
                return InnerCollection.ListAllNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        public PagedList<ILoadBalancer> ListByGroup (string groupName)
        {
            var pagedList = new PagedList<LoadBalancerInner>(InnerCollection.List(groupName), (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
            });

            return WrapList(pagedList);
        }


        public LoadBalancerImpl Define (string name)
        {
            return WrapModel(name);
        }

        override protected LoadBalancerImpl WrapModel (string name)
        {
            LoadBalancerInner inner = new LoadBalancerInner();
            return new LoadBalancerImpl(name, inner, InnerCollection, Manager);
        }

        override protected ILoadBalancer WrapModel (LoadBalancerInner inner) //$TODO: This needs to return LoadBalancerImpl
        {
            return new LoadBalancerImpl(inner.Name, inner, InnerCollection, Manager);
        }

        Task DeleteAsync(string groupName, string name)
        {
            return InnerCollection.DeleteAsync(groupName, name);
        }

        public override async Task<ILoadBalancer> GetByGroupAsync(string groupName, string name)
        {
            var data = await InnerCollection.GetAsync(groupName, name);
            return WrapModel(data);
        }

        public void Delete(string id)
        {
            DeleteAsync(id).Wait();
        }

        public Task DeleteAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        void ISupportsDeletingByGroup.Delete(string groupName, string name)
        {
            DeleteAsync(groupName, name).Wait();
        }
    }
}