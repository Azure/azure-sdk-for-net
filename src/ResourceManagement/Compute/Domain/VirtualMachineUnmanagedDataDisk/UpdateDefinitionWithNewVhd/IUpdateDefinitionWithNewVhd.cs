// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.UpdateDefinitionWithNewVhd
{
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.UpdateDefinition;

    /// <summary>
    /// The entirety of a unmanaged data disk of a virtual machine scale set update.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this definition.</typeparam>
    public interface IUpdateDefinitionWithNewVhd<ParentT>  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.UpdateDefinition.IBlank<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithDiskSource<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithAttach<ParentT>
    {
    }
}