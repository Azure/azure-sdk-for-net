// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    /// <summary>
    /// Implementation for VirtualMachineScaleSetVMs.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVTY2FsZVNldFZNc0ltcGw=
    internal partial class VirtualMachineScaleSetVMsImpl :
        ReadableWrappers<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM,
            Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetVMImpl,
            Models.VirtualMachineScaleSetVMInner>,
        IVirtualMachineScaleSetVMs
    {
        private VirtualMachineScaleSetImpl scaleSet;
        private IVirtualMachineScaleSetVMsOperations client;
        private ComputeManager computeManager;
        ///GENMHASH:2F547EF235083E7C24F2AAD75FCE9FFC:C140D4869BF21B82D034CCD0BC161B59
        internal VirtualMachineScaleSetVMsImpl(VirtualMachineScaleSetImpl scaleSet,
            IVirtualMachineScaleSetVMsOperations client,
            ComputeManager computeManager)
        {
            this.scaleSet = scaleSet;
            this.client = client;
            this.computeManager = computeManager;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:1AA7BDC7AB6868AA92F095AC7974525B
        public PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM> List()
        {
            var pagedList = new PagedList<VirtualMachineScaleSetVMInner>(this.client.List(this.scaleSet.ResourceGroupName, 
                this.scaleSet.Name), (string nextPageLink) =>
                    {
                        return this.client.ListNext(nextPageLink);
                    });
            return WrapList(pagedList);
        }

        ///GENMHASH:3231F2649B87EC1E21076533D17E37D1:3FD352500A8609B35E39BD6C990FFB4D
        protected override IVirtualMachineScaleSetVM WrapModel(VirtualMachineScaleSetVMInner inner)
        {
            return new VirtualMachineScaleSetVMImpl(inner, this.scaleSet, this.client, this.computeManager);
        }
    }
}