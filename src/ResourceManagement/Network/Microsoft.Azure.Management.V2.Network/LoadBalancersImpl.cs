// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Threading.Tasks;
    using System.Threading;
    using Microsoft.Azure.Management.V2.Resource;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Management.Network;
    using System;

    /// <summary>
    /// Implementation for LoadBalancers.
    /// </summary>
    public partial class LoadBalancersImpl  :
        GroupableResources<
            Microsoft.Azure.Management.V2.Network.ILoadBalancer,
            Microsoft.Azure.Management.V2.Network.LoadBalancerImpl,
            Microsoft.Azure.Management.Network.Models.LoadBalancerInner,
            ILoadBalancersOperations,
            NetworkManager>,
        ILoadBalancers
    {
        internal LoadBalancersImpl(NetworkManagementClient networkClient, NetworkManager networkManager) 
            : base(networkClient.LoadBalancers, networkManager)
        {

            //$ final NetworkManagementClientImpl networkClient,
            //$ final NetworkManager networkManager) {
            //$ super(networkClient.loadBalancers(), networkManager);
            //$ }

        }

        public PagedList<Microsoft.Azure.Management.V2.Network.ILoadBalancer> List ()
        {

            //$ return wrapList(this.innerCollection.listAll());

            return null;
        }

        public PagedList<Microsoft.Azure.Management.V2.Network.ILoadBalancer> ListByGroup (string groupName)
        {

            //$ return wrapList(this.innerCollection.list(groupName));

            return null;
        }


        public LoadBalancerImpl Define (string name)
        {

            //$ return wrapModel(name);

            return null;
        }

        override protected LoadBalancerImpl WrapModel (string name)
        {

            //$ LoadBalancerInner inner = new LoadBalancerInner();
            //$ return new LoadBalancerImpl(
            //$ name,
            //$ inner,
            //$ this.innerCollection,
            //$ super.myManager);

            return null;
        }

        override protected ILoadBalancer WrapModel (LoadBalancerInner inner) //$TODO: This needs to return LoadBalancerImpl
        {

            //$ return new LoadBalancerImpl(
            //$ inner.name(),
            //$ inner,
            //$ this.innerCollection,
            //$ this.myManager);

            return null;
        }

        Task DeleteAsync(string groupName, string name)
        {
            throw new NotImplementedException();
        }

        public override async Task<ILoadBalancer> GetByGroupAsync(string groupName, string name)
        {
            return this as ILoadBalancer;
        }


        Task<PagedList<ILoadBalancer>> ISupportsListingByGroup<ILoadBalancer>.ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        void ISupportsDeleting.Delete(string id)
        {
            throw new NotImplementedException();
        }

        Task ISupportsDeleting.DeleteAsync(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        void ISupportsDeletingByGroup.Delete(string groupName, string name)
        {
            throw new NotImplementedException();
        }
    }
}