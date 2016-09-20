/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/

namespace Microsoft.Azure.Management.V2.Network
{
    using Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for {@link NetworkInterfaces}.
    /// </summary>
    public partial class NetworkInterfacesImpl :
        GroupableResources<INetworkInterface, NetworkInterfaceImpl, NetworkInterfaceInner, INetworkInterfacesOperations, NetworkManager>,
        INetworkInterfaces
    {
        internal NetworkInterfacesImpl(INetworkInterfacesOperations client, NetworkManager networkManager) :
            base(client, networkManager)
        {
        }

        public PagedList<INetworkInterface> List()
        {
            var firstPage = InnerCollection.ListAll();
            var pagedList = new PagedList<NetworkInterfaceInner>(firstPage, (string nextPageLink) =>
            {
                return InnerCollection.ListAllNext(nextPageLink);
            });
            return WrapList(pagedList);
        }

        public PagedList<INetworkInterface> ListByGroup(string groupName)
        {
            var list = InnerCollection.List(groupName);
            var pagedList = new PagedList<NetworkInterfaceInner>(list, (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
            });
            return WrapList(pagedList);
        }

        public void Delete(string id)
        {
            this.Delete(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        public void Delete(string groupName, string name)
        {
            this.InnerCollection.Delete(groupName, name);
        }

        public NetworkInterface.Definition.IBlank Define(string name)
        {
            return WrapModel(name);
        }

        protected override NetworkInterfaceImpl WrapModel(string name)
        {
            NetworkInterfaceInner inner = new NetworkInterfaceInner();
            inner.IpConfigurations = new List<NetworkInterfaceIPConfigurationInner>();
            inner.DnsSettings = new NetworkInterfaceDnsSettings();
            return new NetworkInterfaceImpl(name,
                inner,
                this.InnerCollection,
                base.MyManager);
        }

        protected override INetworkInterface WrapModel(NetworkInterfaceInner inner)
        {
            return new NetworkInterfaceImpl(inner.Name,
            inner,
            this.InnerCollection,
            base.MyManager);
        }

        async Task<PagedList<INetworkInterface>> ISupportsListingByGroup<INetworkInterface>.ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        async Task ISupportsDeletingByGroup.DeleteAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await this.InnerCollection.DeleteAsync(groupName, name, cancellationToken);
        }

        public async override Task<INetworkInterface> GetByGroupAsync(string groupName, string name)
        {
            var data = await this.InnerCollection.GetAsync(groupName, name);
            return this.WrapModel(data);
        }

        async Task ISupportsDeleting.DeleteAsync(string id, CancellationToken cancellationToken)
        {
            await this.InnerCollection.DeleteAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id), cancellationToken);
        }
    }
}