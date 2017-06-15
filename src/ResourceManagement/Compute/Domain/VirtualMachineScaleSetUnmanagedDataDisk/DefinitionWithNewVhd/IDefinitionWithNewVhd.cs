// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.DefinitionWithNewVhd
{
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Definition;

    /// <summary>
    /// The entirety of a unmanaged data disk of a virtual machine scale set definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinitionWithNewVhd<ParentT>  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithDiskSource<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithAttach<ParentT>
    {
    }
}