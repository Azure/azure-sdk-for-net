// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Describes definition and update stages of unmanaged data disk of a scale set.
    /// </summary>
    public interface IVirtualMachineScaleSetUnmanagedDataDisk  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.VirtualMachineScaleSetDataDisk>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>
    {
    }
}