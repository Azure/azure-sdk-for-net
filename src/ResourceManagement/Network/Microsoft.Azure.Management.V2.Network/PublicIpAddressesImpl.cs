// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Resource;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using System.Threading;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Threading.Tasks;
    using Management.Network;
    using System;

    /// <summary>
    /// Implementation for PublicIpAddresses.
    /// </summary>
    public partial class PublicIpAddressesImpl  :
        GroupableResources<
            Microsoft.Azure.Management.V2.Network.IPublicIpAddress,
            Microsoft.Azure.Management.V2.Network.PublicIpAddressImpl,
            Microsoft.Azure.Management.Network.Models.PublicIPAddressInner,
            IPublicIPAddressesOperations,
            NetworkManager>,
        IPublicIpAddresses
    {
        internal PublicIpAddressesImpl(NetworkManagementClient client, NetworkManager networkManager) 
            : base(client.PublicIPAddresses, networkManager)
        {

            //$ final PublicIPAddressesInner client,
            //$ final NetworkManager networkManager) {
            //$ super(client, networkManager);
            //$ }

        }

        public PagedList<Microsoft.Azure.Management.V2.Network.IPublicIpAddress> List ()
        {

            //$ return wrapList(this.innerCollection.listAll());

            return null;
        }

        public PagedList<Microsoft.Azure.Management.V2.Network.IPublicIpAddress> ListByGroup (string groupName)
        {

            //$ return wrapList(this.innerCollection.list(groupName));

            return null;
        }

        public PublicIpAddressImpl Define (string name)
        {

            //$ return wrapModel(name);

            return null;
        }

        override protected PublicIpAddressImpl WrapModel (string name)
        {

            //$ PublicIPAddressInner inner = new PublicIPAddressInner();
            //$ 
            //$ if (null == inner.dnsSettings()) {
            //$ inner.withDnsSettings(new PublicIPAddressDnsSettings());
            //$ }
            //$ 
            //$ return new PublicIpAddressImpl(
            //$ name,
            //$ inner,
            //$ this.innerCollection,
            //$ this.myManager);

            return null;
        }

        //$TODO: shoudl return PublicIpAddressImpl
        override protected IPublicIpAddress WrapModel (PublicIPAddressInner inner)
        {

            //$ return new PublicIpAddressImpl(
            //$ inner.id(),
            //$ inner,
            //$ this.innerCollection,
            //$ this.myManager);

            return null;
        }

        Task DeleteAsync(string groupName, string name)
        {
            throw new NotImplementedException();
        }

        void ISupportsDeleting.Delete(string id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IPublicIpAddress> GetByGroupAsync(string groupName, string name)
        {
            return this as IPublicIpAddress;
        }

        Task ISupportsDeleting.DeleteAsync(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<PagedList<IPublicIpAddress>> ISupportsListingByGroup<IPublicIpAddress>.ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        void ISupportsDeletingByGroup.Delete(string groupName, string name)
        {
            throw new NotImplementedException();
        }
    }
}