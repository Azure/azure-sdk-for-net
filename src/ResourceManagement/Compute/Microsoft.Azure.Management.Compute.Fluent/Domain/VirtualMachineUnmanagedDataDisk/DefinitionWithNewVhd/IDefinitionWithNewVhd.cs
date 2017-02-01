// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.DefinitionWithNewVhd
{
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.Definition;

    /// <summary>
    /// The entirety of a unmanaged data disk of a virtual machine scale set definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final DefinitionStages.WithAttach.attach().</typeparam>
    public interface IDefinitionWithNewVhd<ParentT>  :
        IBlank<ParentT>,
        IWithDiskSource<ParentT>,
        IWithNewVhdDiskSettings<ParentT>,
        IWithAttach<ParentT>
    {
    }
}