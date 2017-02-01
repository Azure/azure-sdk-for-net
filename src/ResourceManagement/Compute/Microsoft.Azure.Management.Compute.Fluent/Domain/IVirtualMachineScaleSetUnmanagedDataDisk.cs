// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// Describes definition and update stages of unmanaged data disk of a scale set.
    /// </summary>
    public interface IVirtualMachineScaleSetUnmanagedDataDisk  :
        IWrapper<Models.VirtualMachineScaleSetDataDisk>,
        IChildResource<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>
    {
    }
}