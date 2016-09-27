// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.V2.Network
{
    using Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using PublicIpAddress.Definition;
    using Resource.Core.CollectionActions;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for {@link PublicIpAddresses}.
    /// </summary>
    public partial class PublicIpAddressesImpl :
        GroupableResources<
            IPublicIpAddress,
            PublicIpAddressImpl,
            PublicIPAddressInner,
            IPublicIPAddressesOperations,
            INetworkManager>,
        IPublicIpAddresses
    {
        internal PublicIpAddressesImpl(IPublicIPAddressesOperations client, INetworkManager networkManager) :
            base(client, networkManager)
        {
        }

        public void Delete(string id)
        {
            this.Delete(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        public void Delete(string groupName, string name)
        {
            this.InnerCollection.Delete(groupName, name);
        }

        protected override PublicIpAddressImpl WrapModel(string name)
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

        protected override IPublicIpAddress WrapModel(PublicIPAddressInner inner)
        {
            return new PublicIpAddressImpl(
                inner.Id,
                inner,
                this.InnerCollection,
                this.MyManager);
        }

        private PagedList<IPublicIpAddress> List()
        {
            var firstPage = InnerCollection.ListAll();
            var pagedList = new PagedList<PublicIPAddressInner>(firstPage, (string nextPageLink) =>
            {
                return InnerCollection.ListAllNext(nextPageLink);
            });
            return WrapList(pagedList);
        }

        private IBlank Define(string name)
        {
            return WrapModel(name);
        }

        public Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            return ((ISupportsDeletingByGroup)this).DeleteAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        public PagedList<IPublicIpAddress> ListByGroup(string resourceGroupName)
        {
            var data = this.InnerCollection.List(resourceGroupName);
            return WrapList(new PagedList<PublicIPAddressInner>(data, (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
            }));
        }

        public Task<PagedList<IPublicIpAddress>> ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public async Task DeleteAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await this.InnerCollection.DeleteAsync(groupName, name);
        }

        public async override Task<IPublicIpAddress> GetByGroupAsync(string groupName, string name)
        {
            var data = await this.InnerCollection.GetAsync(groupName, name);
            return this.WrapModel(data);
        }
    }
}