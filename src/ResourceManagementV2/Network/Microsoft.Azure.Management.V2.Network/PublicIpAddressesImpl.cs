/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource;
    using Management.Network;
    using System.Collections.Generic;
    using PublicIpAddress.Definition;
    using Resource.Core.CollectionActions;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for {@link PublicIpAddresses}.
    /// </summary>
    internal class PublicIpAddressesImpl  :
        GroupableResources<
            IPublicIpAddress,
            PublicIpAddressImpl,
            PublicIPAddressInner,
            IPublicIPAddressesOperations, 
            INetworkManager>,
        IPublicIpAddresses
    {
        internal  PublicIpAddressesImpl (IPublicIPAddressesOperations client, INetworkManager networkManager) :
            base (client, networkManager)
        {
        }

        public void Delete (string id)
        {
            this.Delete(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        public void Delete (string groupName, string name)
        {
            this.InnerCollection.Delete(groupName, name);
        }

        protected override PublicIpAddressImpl WrapModel (string name)
        {

            PublicIPAddressInner inner = new PublicIPAddressInner();

            if (inner.DnsSettings == null)
            {
                inner.DnsSettings = new PublicIPAddressDnsSettings();
            }

            return new PublicIpAddressImpl(
                name,
                inner,
                this.InnerCollection,
                this.MyManager);
        }

        protected override IPublicIpAddress WrapModel (PublicIPAddressInner inner)
        {
            return new PublicIpAddressImpl(
                inner.Id,
                inner,
                this.InnerCollection,
                this.MyManager);
        }

        PagedList<IPublicIpAddress> ISupportsListing<IPublicIpAddress>.List()
        {
            IEnumerable<PublicIPAddressInner> storageAccounts = InnerCollection.ListAll();
            var pagedList = new PagedList<PublicIPAddressInner>(storageAccounts);
            return WrapList(pagedList);
        }

        IBlank ISupportsCreating<IBlank>.Define(string name)
        {
            return WrapModel(name);
        }

        void ISupportsDeleting.Delete(string id)
        {
            ((ISupportsDeleting)this).DeleteAsync(id).Wait();
        }

        Task ISupportsDeleting.DeleteAsync(string id, CancellationToken cancellationToken)
        {
            return ((ISupportsDeletingByGroup)this).DeleteAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        PagedList<IPublicIpAddress> ISupportsListingByGroup<IPublicIpAddress>.ListByGroup(string resourceGroupName)
        {
            return ((ISupportsListingByGroup<IPublicIpAddress>)this).ListByGroupAsync(resourceGroupName).Result;
        }

        async Task<PagedList<IPublicIpAddress>> ISupportsListingByGroup<IPublicIpAddress>.ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            var data = await this.InnerCollection.ListAsync(resourceGroupName);
            return WrapList(new PagedList<PublicIPAddressInner>(data));
        }

        void ISupportsDeletingByGroup.Delete(string groupName, string name)
        {
            ((ISupportsDeletingByGroup)this).DeleteAsync(groupName, name);
        }

        async Task ISupportsDeletingByGroup.DeleteAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await this.InnerCollection.DeleteAsync(groupName, name);
        }

        public override Task<IPublicIpAddress> GetByGroupAsync(string groupName, string name)
        {
            throw new NotImplementedException();
        }
    }
}