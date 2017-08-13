// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVTY2FsZVNldE5ldHdvcmtJbnRlcmZhY2VzSW1wbA==
    internal partial class VirtualMachineScaleSetNetworkInterfacesImpl :
        ReadableWrappers<IVirtualMachineScaleSetNetworkInterface,
                VirtualMachineScaleSetNetworkInterfaceImpl,
                NetworkInterfaceInner>,
        IVirtualMachineScaleSetNetworkInterfaces
    {
        private string resourceGroupName;
        private string scaleSetName;
        private INetworkManager networkManager;

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:F5983E5601CB13B8F8ED414F2C4E9FA9
        public INetworkInterfacesOperations Inner
        {
            get
            {
                return networkManager.Inner.NetworkInterfaces;
            }
        }

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:7F318EC07B9B39F28BFF2277E89C7E0E
        internal INetworkManager Manager()
        {
            return networkManager;
        }

        ///GENMHASH:4A344BF95CCA4AE4CC343DFE4AC1D329:FBF7371CEF5991C3691D16476DF71FB7
        internal VirtualMachineScaleSetNetworkInterfacesImpl(
            string resourceGroupName,
            string scaleSetName,
            INetworkManager networkManager)
        {
            this.resourceGroupName = resourceGroupName;
            this.scaleSetName = scaleSetName;
            this.networkManager = networkManager;
        }

        ///GENMHASH:585FC064CD92EAD763A0EAE9A4656610:0D7F9E988EA1DF8624C80D31171C045E
        public IVirtualMachineScaleSetNetworkInterface GetByVirtualMachineInstanceId(string instanceId, string name)
        {
            NetworkInterfaceInner networkInterfaceInner = Extensions.Synchronize(() => Manager().Inner.NetworkInterfaces.GetVirtualMachineScaleSetNetworkInterfaceAsync(
                resourceGroupName,
                scaleSetName,
                instanceId,
                name));
            if (networkInterfaceInner == null)
            {
                return null;
            }
            return WrapModel(networkInterfaceInner);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:8C9D88F4387EDA0F98AD7CD112123225
        public IEnumerable<IVirtualMachineScaleSetNetworkInterface> List()
        {
            return WrapList(Extensions.Synchronize(() => Manager().Inner.NetworkInterfaces.ListVirtualMachineScaleSetNetworkInterfacesAsync(resourceGroupName, scaleSetName))
                .AsContinuousCollection(link => Extensions.Synchronize(() => Manager().Inner.NetworkInterfaces.ListVirtualMachineScaleSetNetworkInterfacesNextAsync(link))));
        }

        ///GENMHASH:352D38885D2DA216CE4BF174C1609DE4:8ABE5F57A7CFF7927A5A7532828DE581
        public IEnumerable<IVirtualMachineScaleSetNetworkInterface> ListByVirtualMachineInstanceId(string instanceId)
        {
            return WrapList(Extensions.Synchronize(() => Manager().Inner.NetworkInterfaces.ListVirtualMachineScaleSetVMNetworkInterfacesAsync(resourceGroupName, scaleSetName, instanceId))
                .AsContinuousCollection(link => Extensions.Synchronize(() => Manager().Inner.NetworkInterfaces.ListVirtualMachineScaleSetVMNetworkInterfacesNextAsync(link))));
        }

        ///GENMHASH:0FC0465591EF4D86100A2FF1DC557738:AADF28028C9455832043CE24CF2B5871
        protected override IVirtualMachineScaleSetNetworkInterface WrapModel(NetworkInterfaceInner inner)
        {
            return new VirtualMachineScaleSetNetworkInterfaceImpl(
                inner.Name,
                scaleSetName,
                resourceGroupName,
                inner,
                networkManager);
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:11D194372CF16B8AF88A146421D05EAF
        public async Task<IPagedCollection<IVirtualMachineScaleSetNetworkInterface>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IVirtualMachineScaleSetNetworkInterface, NetworkInterfaceInner>.LoadPage(
                async (cancellation) => await Manager().Inner.NetworkInterfaces.ListVirtualMachineScaleSetNetworkInterfacesAsync(resourceGroupName, scaleSetName, cancellation),
                Manager().Inner.NetworkInterfaces.ListVirtualMachineScaleSetNetworkInterfacesNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }
    }
}
