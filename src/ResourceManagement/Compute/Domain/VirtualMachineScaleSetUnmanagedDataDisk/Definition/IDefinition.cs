// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Models;

    /// <summary>
    /// The first stage of a unmanaged data disk definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithDiskSource<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the unmanaged data disk definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>
    {
    }

    /// <summary>
    /// The stage that allows configure the unmanaged disk based on new VHD.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithNewVhdDiskSettings<ParentT>  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithAttach<ParentT>
    {
        /// <summary>
        /// Specifies the logical unit number for the unmanaged data disk.
        /// </summary>
        /// <param name="lun">The logical unit number.</param>
        /// <return>The next stage of unmanaged data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<ParentT> WithLun(int lun);

        /// <summary>
        /// Specifies the caching type for the unmanaged data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'.</param>
        /// <return>The next stage of unmanaged data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<ParentT> WithCaching(CachingTypes cachingType);
    }

    /// <summary>
    /// The stage of the unmanaged data disk definition allowing to choose the source.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDiskSource<ParentT> 
    {
        /// <summary>
        /// Specifies the image LUN identifier of the source disk image.
        /// </summary>
        /// <param name="imageLun">The LUN.</param>
        /// <return>The next stage of unmanaged data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<ParentT> FromImage(int imageLun);

        /// <summary>
        /// Specifies that unmanaged disk needs to be created with a new VHD of given size.
        /// </summary>
        /// <param name="sizeInGB">The initial disk size in GB.</param>
        /// <return>The next stage of unmanaged data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<ParentT> WithNewVhd(int sizeInGB);
    }

    /// <summary>
    /// The stage that allows configure the unmanaged disk based on an image.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithFromImageDiskSettings<ParentT>  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithAttach<ParentT>
    {
        /// <summary>
        /// Specifies the size in GB the unmanaged disk needs to be resized.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of unmanaged data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<ParentT> WithSizeInGB(int sizeInGB);

        /// <summary>
        /// Specifies the caching type for the unmanaged data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'.</param>
        /// <return>The next stage of unmanaged data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<ParentT> WithCaching(CachingTypes cachingType);
    }
}