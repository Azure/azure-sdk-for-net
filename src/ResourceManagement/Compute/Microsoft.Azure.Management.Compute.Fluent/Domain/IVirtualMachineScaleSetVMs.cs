// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to virtual machine scale set instance management API.
    /// </summary>
    public interface IVirtualMachineScaleSetVMs  :
        ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM>,
        IHasManager<IComputeManager>,
        IHasInner<IVirtualMachineScaleSetVMsOperations>
    {
    }
}