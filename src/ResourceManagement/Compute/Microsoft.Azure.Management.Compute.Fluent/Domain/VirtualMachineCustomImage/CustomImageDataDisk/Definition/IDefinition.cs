// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition
{
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// The stage of the image definition allowing to choose the source of the data disk image.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithImageSource<ParentT> 
    {
        /// <summary>
        /// Specifies the source snapshot for the data disk image.
        /// </summary>
        /// <param name="sourceSnapshotId">Source snapshot resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithAttach<ParentT> FromSnapshot(string sourceSnapshotId);

        /// <summary>
        /// Specifies the source VHD for the data disk image.
        /// </summary>
        /// <param name="sourceVhdUrl">Source virtual hard disk URL.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithAttach<ParentT> FromVhd(string sourceVhdUrl);

        /// <summary>
        /// Specifies the source managed disk for the data disk image.
        /// </summary>
        /// <param name="sourceManagedDiskId">Source managed disk resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithAttach<ParentT> FromManagedDisk(string sourceManagedDiskId);

        /// <summary>
        /// Specifies the source managed disk for the data disk image.
        /// </summary>
        /// <param name="sourceManagedDisk">Source managed disk.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithAttach<ParentT> FromManagedDisk(IDisk sourceManagedDisk);
    }

    /// <summary>
    /// The stage of the image definition allowing to specify the LUN for the disk image.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDiskLun<ParentT> 
    {
        /// <summary>
        /// Specifies the LUN for the data disk to be created from the disk image.
        /// </summary>
        /// <param name="lun">The unique LUN for the data disk.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithImageSource<ParentT> WithLun(int lun);
    }

    /// <summary>
    /// The stage of data disk image definition allowing to specify configurations for the data disk when it
    /// is created from the same data disk image.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDiskSettings<ParentT> 
    {
        /// <summary>
        /// Specifies the caching type for data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithAttach<ParentT> WithDiskCaching(CachingTypes cachingType);

        /// <summary>
        /// Specifies the size in GB for data disk.
        /// </summary>
        /// <param name="diskSizeGB">The disk size in GB.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithAttach<ParentT> WithDiskSizeInGB(int diskSizeGB);
    }

    /// <summary>
    /// The first stage of the data disk image definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithDiskLun<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the data disk image definition.
    /// At this stage, any remaining optional settings can be specified, or the data disk definition
    /// can be attached to the parent image definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithDiskSettings<ParentT>
    {
    }

    /// <summary>
    /// The entirety of a data disk image definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithDiskLun<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithImageSource<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithDiskSettings<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithAttach<ParentT>
    {
    }
}