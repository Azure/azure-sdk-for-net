// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.UpdateDefinitionWithNewVhd
{
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.UpdateDefinition;

    /// <summary>
    /// The entirety of a unmanaged data disk of a virtual machine scale set update.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final DefinitionStages.WithAttach.attach().</typeparam>
    public interface IUpdateDefinitionWithNewVhd<ParentT>  :
        IBlank<ParentT>,
        IWithDiskSource<ParentT>,
        IWithNewVhdDiskSettings<ParentT>,
        IWithAttach<ParentT>
    {
    }
}