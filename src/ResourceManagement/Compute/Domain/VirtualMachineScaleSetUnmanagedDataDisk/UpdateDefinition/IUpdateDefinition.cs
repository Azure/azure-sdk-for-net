// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.UpdateDefinition
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The stage that allows configure the unmanaged disk based on new VHD.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this definition.</typeparam>
    public interface IWithNewVhdDiskSettings<ParentT>  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.UpdateDefinition.IWithAttach<ParentT>
    {
        /// <summary>
        /// Specifies the logical unit number for the unmanaged data disk.
        /// </summary>
        /// <param name="lun">The logical unit number.</param>
        /// <return>The next stage of unmanaged data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<ParentT> WithLun(int lun);

        /// <summary>
        /// Specifies the caching type for the unmanaged data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'.</param>
        /// <return>The next stage of unmanaged data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<ParentT> WithCaching(CachingTypes cachingType);
    }

    /// <summary>
    /// The final stage of the unmanaged data disk definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a unmanaged data disk definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.UpdateDefinition.IWithDiskSource<ParentT>
    {
    }

    /// <summary>
    /// The entirety of a unmanaged data disk of a virtual machine scale set definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this definition.</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.UpdateDefinition.IBlank<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.UpdateDefinition.IWithDiskSource<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.UpdateDefinition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of the unmanaged data disk definition allowing to choose the source.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this definition.</typeparam>
    public interface IWithDiskSource<ParentT> 
    {
        /// <summary>
        /// Specifies that unmanaged disk needs to be created with a new VHD of given size.
        /// </summary>
        /// <param name="sizeInGB">The initial disk size in GB.</param>
        /// <return>The next stage of unmanaged data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<ParentT> WithNewVhd(int sizeInGB);
    }
}