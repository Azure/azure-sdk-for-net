// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.V2.Resource;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Threading;
    using System.Threading.Tasks;
    using Management.Network;
    using System;

    /// <summary>
    /// Implementation for NetworkInterfaces.
    /// </summary>
    public partial class NetworkInterfacesImpl  :
        GroupableResources<
            Microsoft.Azure.Management.V2.Network.INetworkInterface,
            Microsoft.Azure.Management.V2.Network.NetworkInterfaceImpl,
            Microsoft.Azure.Management.Network.Models.NetworkInterfaceInner,
            Management.Network.INetworkInterfacesOperations,
            NetworkManager>,
        INetworkInterfaces
    {
        internal  NetworkInterfacesImpl(NetworkManagementClient client, NetworkManager networkManager)
            : base(client.NetworkInterfaces, networkManager)
        {

            //$ final NetworkInterfacesInner client,
            //$ final NetworkManager networkManager) {
            //$ super(client, networkManager);
            //$ }

        }

        public PagedList<Microsoft.Azure.Management.V2.Network.INetworkInterface> List ()
        {

            //$ return wrapList(innerCollection.listAll());

            return null;
        }

        public PagedList<Microsoft.Azure.Management.V2.Network.INetworkInterface> ListByGroup (string groupName)
        {

            //$ return wrapList(innerCollection.list(groupName));

            return null;
        }

        public NetworkInterfaceImpl Define (string name)
        {

            //$ return wrapModel(name);

            return null;
        }

        Task DeleteAsync(string groupName, string name)
        {
            throw new NotImplementedException();
        }

        public override async Task<INetworkInterface> GetByGroupAsync(string groupName, string name)
        {
            return this as INetworkInterface;
        }

        override protected NetworkInterfaceImpl WrapModel (string name)
        {

            //$ NetworkInterfaceInner inner = new NetworkInterfaceInner();
            //$ inner.withIpConfigurations(new ArrayList<NetworkInterfaceIPConfigurationInner>());
            //$ inner.withDnsSettings(new NetworkInterfaceDnsSettings());
            //$ return new NetworkInterfaceImpl(name,
            //$ inner,
            //$ this.innerCollection,
            //$ super.myManager);

            return null;
        }

        //$TODO: this should return NetworkInterfaceImpl
        override protected INetworkInterface WrapModel (NetworkInterfaceInner inner)
        {

            //$ return new NetworkInterfaceImpl(inner.name(),
            //$ inner,
            //$ this.innerCollection,
            //$ super.myManager);

            return null;
        }

        Task<PagedList<INetworkInterface>> ISupportsListingByGroup<INetworkInterface>.ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
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