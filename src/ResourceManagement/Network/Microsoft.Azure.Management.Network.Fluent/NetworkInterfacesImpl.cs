// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using Management.Network.Models;
    using Resource.Core;
    using System.Threading;
    using System.Threading.Tasks;
    using Management.Network;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for NetworkInterfaces.
    /// </summary>
    public partial class NetworkInterfacesImpl :
        GroupableResources<
            INetworkInterface,
            NetworkInterfaceImpl,
            NetworkInterfaceInner,
            INetworkInterfacesOperations,
            NetworkManager>,
        INetworkInterfaces
    {
        internal NetworkInterfacesImpl(NetworkManagementClient client, NetworkManager networkManager)
            : base(client.NetworkInterfaces, networkManager)
        {
        }

        override protected NetworkInterfaceImpl WrapModel(string name)
        {
            NetworkInterfaceInner inner = new NetworkInterfaceInner();
            inner.IpConfigurations = new List<NetworkInterfaceIPConfigurationInner>();
            inner.DnsSettings = new NetworkInterfaceDnsSettings();
            return new NetworkInterfaceImpl(name, inner, InnerCollection, Manager);
        }

        //$TODO: this should return NetworkInterfaceImpl
        override protected INetworkInterface WrapModel(NetworkInterfaceInner inner)
        {
            return new NetworkInterfaceImpl(inner.Name, inner, InnerCollection, Manager);
        }

        internal PagedList<INetworkInterface> List()
        {
            var pagedList = new PagedList<NetworkInterfaceInner>(InnerCollection.ListAll(), (string nextPageLink) =>
            {
                return InnerCollection.ListAllNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        internal PagedList<INetworkInterface> ListByGroup(string groupName)
        {
            var pagedList = new PagedList<NetworkInterfaceInner>(InnerCollection.List(groupName), (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
            });

            return WrapList(pagedList);
        }


        internal NetworkInterfaceImpl Define(string name)
        {
            return WrapModel(name);
        }

        Task DeleteAsync(string groupName, string name)
        {
            return InnerCollection.DeleteAsync(groupName, name);
        }

        public override async Task<INetworkInterface> GetByGroupAsync(string groupName, string name)
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

        public void Delete(string groupName, string name)
        {
            DeleteAsync(groupName, name).Wait();
        }
    }
}