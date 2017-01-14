// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    internal partial class VirtualMachineScaleSetNetworkInterfacesImpl :
        ReadableWrappers<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface,
                Microsoft.Azure.Management.Network.Fluent.VirtualMachineScaleSetNetworkInterfaceImpl,
                NetworkInterfaceInner>,
        IVirtualMachineScaleSetNetworkInterfaces
    {
        private string resourceGroupName;
        private string scaleSetName;
        private INetworkInterfacesOperations client;
        private INetworkManager networkManager;

        internal VirtualMachineScaleSetNetworkInterfacesImpl(string resourceGroupName,
                                                string scaleSetName,
                                                INetworkInterfacesOperations client,
                                                INetworkManager networkManager)
        {
            this.resourceGroupName = resourceGroupName;
            this.scaleSetName = scaleSetName;
            this.client = client;
            this.networkManager = networkManager;
        }

        public IVirtualMachineScaleSetNetworkInterface GetByVirtualMachineInstanceId(string instanceId, string name)
        {
            NetworkInterfaceInner networkInterfaceInner = this.client.GetVirtualMachineScaleSetNetworkInterface(this.resourceGroupName,
                this.scaleSetName,
                instanceId,
                name);
            if (networkInterfaceInner == null)
            {
                return null;
            }
            return this.WrapModel(networkInterfaceInner);
        }

        public PagedList<IVirtualMachineScaleSetNetworkInterface> List()
        {
            var pagedList = new PagedList<NetworkInterfaceInner>(this.client.ListVirtualMachineScaleSetNetworkInterfaces(this.resourceGroupName, this.scaleSetName), (string nextPageLink) =>
            {
                return this.client.ListVirtualMachineScaleSetNetworkInterfacesNext(nextPageLink);
            });
            return WrapList(pagedList);
        }

        public PagedList<IVirtualMachineScaleSetNetworkInterface> ListByVirtualMachineInstanceId(string instanceId)
        {
            var pagedList = new PagedList<NetworkInterfaceInner>(this.client.ListVirtualMachineScaleSetVMNetworkInterfaces(this.resourceGroupName, this.scaleSetName, instanceId), (string nextPageLink) =>
            {
                return this.client.ListVirtualMachineScaleSetVMNetworkInterfacesNext(nextPageLink);
            });
            return WrapList(pagedList);
        }

        protected override IVirtualMachineScaleSetNetworkInterface WrapModel(NetworkInterfaceInner inner)
        {
            return new VirtualMachineScaleSetNetworkInterfaceImpl(inner.Name,
            this.scaleSetName,
            this.resourceGroupName,
            inner,
            this.client,
            this.networkManager);
        }
    }
}
