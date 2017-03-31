// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System;
    using Models;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal partial class VirtualMachineScaleSetNetworkInterfacesImpl :
        ReadableWrappers<IVirtualMachineScaleSetNetworkInterface,
                VirtualMachineScaleSetNetworkInterfaceImpl,
                NetworkInterfaceInner>,
        IVirtualMachineScaleSetNetworkInterfaces
    {
        private string resourceGroupName;
        private string scaleSetName;
        private INetworkManager networkManager;

        public INetworkInterfacesOperations Inner
        {
            get
            {
                return networkManager.Inner.NetworkInterfaces;
            }
        }

        public INetworkManager Manager
        {
            get
            {
                return networkManager;
            }
        }

        internal VirtualMachineScaleSetNetworkInterfacesImpl(
            string resourceGroupName,
            string scaleSetName,
            INetworkManager networkManager)
        {
            this.resourceGroupName = resourceGroupName;
            this.scaleSetName = scaleSetName;
            this.networkManager = networkManager;
        }

        public IVirtualMachineScaleSetNetworkInterface GetByVirtualMachineInstanceId(string instanceId, string name)
        {
            NetworkInterfaceInner networkInterfaceInner = Manager.Inner.NetworkInterfaces.GetVirtualMachineScaleSetNetworkInterface(
                resourceGroupName,
                scaleSetName,
                instanceId,
                name);
            if (networkInterfaceInner == null)
            {
                return null;
            }
            return WrapModel(networkInterfaceInner);
        }

        public IEnumerable<IVirtualMachineScaleSetNetworkInterface> List()
        {
            return WrapList(Manager.Inner.NetworkInterfaces
                .ListVirtualMachineScaleSetNetworkInterfaces(resourceGroupName, scaleSetName)
                .AsContinuousCollection(link => Manager.Inner.NetworkInterfaces.ListVirtualMachineScaleSetNetworkInterfacesNext(link)));
        }

        public IEnumerable<IVirtualMachineScaleSetNetworkInterface> ListByVirtualMachineInstanceId(string instanceId)
        {
            return WrapList(Manager.Inner.NetworkInterfaces
                .ListVirtualMachineScaleSetVMNetworkInterfaces(resourceGroupName, scaleSetName, instanceId)
                .AsContinuousCollection(link => Manager.Inner.NetworkInterfaces.ListVirtualMachineScaleSetVMNetworkInterfacesNext(link)));
        }

        protected override IVirtualMachineScaleSetNetworkInterface WrapModel(NetworkInterfaceInner inner)
        {
            return new VirtualMachineScaleSetNetworkInterfaceImpl(
                inner.Name,
                scaleSetName,
                resourceGroupName,
                inner,
                networkManager);
        }
    }
}
