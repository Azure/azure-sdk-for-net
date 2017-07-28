// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for VirtualMachineScaleSetVMs.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVTY2FsZVNldFZNc0ltcGw=
    internal partial class VirtualMachineScaleSetVMsImpl :
        ReadableWrappers<IVirtualMachineScaleSetVM,
            VirtualMachineScaleSetVMImpl,
            VirtualMachineScaleSetVMInner>,
        IVirtualMachineScaleSetVMs
    {
        private VirtualMachineScaleSetImpl scaleSet;

        public IComputeManager Manager
        {
            get; private set;
        }

        public IVirtualMachineScaleSetVMsOperations Inner
        {
            get
            {
                return Manager.Inner.VirtualMachineScaleSetVMs;
            }
        }

        ///GENMHASH:2F547EF235083E7C24F2AAD75FCE9FFC:C140D4869BF21B82D034CCD0BC161B59
        internal VirtualMachineScaleSetVMsImpl(VirtualMachineScaleSetImpl scaleSet, IComputeManager computeManager)
        {
            this.scaleSet = scaleSet;
            Manager = computeManager;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:1AA7BDC7AB6868AA92F095AC7974525B
        public IEnumerable<IVirtualMachineScaleSetVM> List()
        {
            return WrapList(Extensions.Synchronize(() => Inner.ListAsync(scaleSet.ResourceGroupName,this.scaleSet.Name))
                .AsContinuousCollection(link => Extensions.Synchronize(() => Inner.ListNextAsync(link))));
        }

        ///GENMHASH:3231F2649B87EC1E21076533D17E37D1:3FD352500A8609B35E39BD6C990FFB4D
        protected override IVirtualMachineScaleSetVM WrapModel(VirtualMachineScaleSetVMInner inner)
        {
            return new VirtualMachineScaleSetVMImpl(inner, this.scaleSet);
        }

        public async Task<IPagedCollection<IVirtualMachineScaleSetVM>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IVirtualMachineScaleSetVM, VirtualMachineScaleSetVMInner>.LoadPage(
                async (cancellation) => await Inner.ListAsync(scaleSet.ResourceGroupName, this.scaleSet.Name, cancellationToken: cancellation),
                Inner.ListNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }
    }
}
