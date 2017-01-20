// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{

    using Management.Network.Fluent.Models;
    using Resource.Fluent.Core;
    using System.Threading;
    using System.Threading.Tasks;
    using Management.Network;
    using System.Collections.Generic;
    using System;
    using Fluent;

    /// <summary>
    /// Implementation for NetworkInterfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTmV0d29ya0ludGVyZmFjZXNJbXBs
    internal partial class NetworkInterfacesImpl :
        GroupableResources<
            INetworkInterface,
            NetworkInterfaceImpl,
            NetworkInterfaceInner,
            INetworkInterfacesOperations,
            NetworkManager>,
        INetworkInterfaces
    {
        ///GENMHASH:29B7EF31B65B0BDDE2C36E88B44BD866:5AC88BA549EC2FB48FFEA9A94BE29B89
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

        ///GENMHASH:0FC0465591EF4D86100A2FF1DC557738:D9F9A024A97F1477B173138B75BCFE13
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

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
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

        ///GENMHASH:CF1C887C1688AB525BA63FD7B4469714:30A2B5D56CBF3A353B0D9EAE1884CE80
        public IVirtualMachineScaleSetNetworkInterface GetByVirtualMachineScaleSetInstanceId(string resourceGroupName, string scaleSetName, string instanceId, string name)
        {
            VirtualMachineScaleSetNetworkInterfacesImpl scaleSetNetworkInterfaces = new VirtualMachineScaleSetNetworkInterfacesImpl(resourceGroupName,
                scaleSetName,
                this.InnerCollection,
                this.Manager);
            return scaleSetNetworkInterfaces.GetByVirtualMachineInstanceId(instanceId, name);
        }

        ///GENMHASH:FB8BAF1D7A241BC666A03354AD1A59B1:350254D9139C5CB1FCAD7F7F992B74F8
        public PagedList<IVirtualMachineScaleSetNetworkInterface> ListByVirtualMachineScaleSet(string resourceGroupName, string scaleSetName)
        {
            VirtualMachineScaleSetNetworkInterfacesImpl scaleSetNetworkInterfaces = new VirtualMachineScaleSetNetworkInterfacesImpl(resourceGroupName,
                scaleSetName,
                this.InnerCollection,
                this.Manager);
            return scaleSetNetworkInterfaces.List();
        }

        ///GENMHASH:BA50DA09E1FC76012780D58EFCE9A237:FCFAC84F49E66F1F4CEB39A2A782719B
        public PagedList<IVirtualMachineScaleSetNetworkInterface> ListByVirtualMachineScaleSetId(string id)
        {
            return this.ListByVirtualMachineScaleSet(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        ///GENMHASH:DD375F4600A4F5AA88A87C271E21CBDB:77581D23FE59229EE53313A9B4816975
        public PagedList<IVirtualMachineScaleSetNetworkInterface> ListByVirtualMachineScaleSetInstanceId(string resourceGroupName, string scaleSetName, string instanceId)
        {
            VirtualMachineScaleSetNetworkInterfacesImpl scaleSetNetworkInterfaces = new VirtualMachineScaleSetNetworkInterfacesImpl(resourceGroupName,
                scaleSetName,
                this.InnerCollection,
                this.Manager);
            return scaleSetNetworkInterfaces.ListByVirtualMachineInstanceId(instanceId);
        }
    }
}
