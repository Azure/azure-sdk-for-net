// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTmV0d29ya0ludGVyZmFjZXNJbXBs
namespace Microsoft.Azure.Management.Network.Fluent
{

    using Management.Network.Fluent.Models;
    using Resource.Fluent.Core;
    using System.Threading;
    using System.Threading.Tasks;
    using Management.Network;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for NetworkInterfaces.
    /// </summary>
    internal partial class NetworkInterfacesImpl :
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

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:5EB6AEDDDF3C96B5ADB951CBAA0B5837
        override protected NetworkInterfaceImpl WrapModel(string name)
        {
            NetworkInterfaceInner inner = new NetworkInterfaceInner();
            inner.IpConfigurations = new List<NetworkInterfaceIPConfigurationInner>();
            inner.DnsSettings = new NetworkInterfaceDnsSettings();
            return new NetworkInterfaceImpl(name, inner, InnerCollection, Manager);
        }

        //$TODO: this should return NetworkInterfaceImpl
        ///GENMHASH:0FC0465591EF4D86100A2FF1DC557738:E2D7CA78449A9C0229A61B0A54706233
        override protected INetworkInterface WrapModel(NetworkInterfaceInner inner)
        {
            return new NetworkInterfaceImpl(inner.Name, inner, InnerCollection, Manager);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:EA49478191CB500D3891D0EDE475C10E
        internal PagedList<INetworkInterface> List()
        {
            var pagedList = new PagedList<NetworkInterfaceInner>(InnerCollection.ListAll(), (string nextPageLink) =>
            {
                return InnerCollection.ListAllNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:C8F667C9694115E8E2EC05A78BB18EDD
        internal PagedList<INetworkInterface> ListByGroup(string groupName)
        {
            var pagedList = new PagedList<NetworkInterfaceInner>(InnerCollection.List(groupName), (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
            });

            return WrapList(pagedList);
        }


        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        internal NetworkInterfaceImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:3F66CB38737E789E83D4F94D3B9FA876:B9B028D620AC932FDF66D2783E476B0D
        public override Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return InnerCollection.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        public override async Task<INetworkInterface> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var data = await InnerCollection.GetAsync(groupName, name, null, cancellationToken);
            return WrapModel(data);
        }
    }
}
