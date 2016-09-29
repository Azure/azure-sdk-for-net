// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using Management.Network.Models;
    using Resource.Core.CollectionActions;
    using System.Threading;
    using Resource.Core;
    using System.Threading.Tasks;
    using Management.Network;
    using System;

    /// <summary>
    /// Implementation for PublicIpAddresses.
    /// </summary>
    public partial class PublicIpAddressesImpl  :
        GroupableResources<
            IPublicIpAddress,
            PublicIpAddressImpl,
            PublicIPAddressInner,
            IPublicIPAddressesOperations,
            NetworkManager>,
        IPublicIpAddresses
    {
        internal PublicIpAddressesImpl(NetworkManagementClient client, NetworkManager networkManager) 
            : base(client.PublicIPAddresses, networkManager)
        {
        }

        public PagedList<IPublicIpAddress> List ()
        {

            //$ return wrapList(this.innerCollection.listAll());

            return null;
        }

        public PagedList<IPublicIpAddress> ListByGroup (string groupName)
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

        void ISupportsDeletingByGroup.Delete(string groupName, string name)
        {
            throw new NotImplementedException();
        }
    }
}