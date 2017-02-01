// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition
{
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// The stage of the image definition allowing to choose the source of the data disk image.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final CustomImageDataDisk.DefinitionStages.WithAttach.attach().</typeparam>
    public interface IWithImageSource<ParentT> 
    {
        /// <summary>
        /// Specifies the source managed disk for the data disk image.
        /// </summary>
        /// <param name="sourceManagedDiskId">Source managed disk resource id.</param>
        /// <return>The next stage of the data disk image definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithAttach<ParentT> FromManagedDisk(string sourceManagedDiskId);

        /// <summary>
        /// Specifies the source managed disk for the data disk image.
        /// </summary>
        /// <param name="sourceManagedDisk">Source managed disk.</param>
        /// <return>The next stage of the data disk image definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithAttach<ParentT> FromManagedDisk(IDisk sourceManagedDisk);

        /// <summary>
        /// Specifies the source VHD for the data disk image.
        /// </summary>
        /// <param name="sourceVhdUrl">Source virtual hard disk url.</param>
        /// <return>The next stage of the data disk image definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithAttach<ParentT> FromVhd(string sourceVhdUrl);

        /// <summary>
        /// Specifies the source snapshot for the data disk image.
        /// </summary>
        /// <param name="sourceSnapshotId">Source snapshot resource id.</param>
        /// <return>The next stage of the data disk image definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithAttach<ParentT> FromSnapshot(string sourceSnapshotId);
    }

    /// <summary>
    /// The stage of the image definition allowing to specify the lun for the disk image.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final CustomImageDataDisk.DefinitionStages.WithAttach.attach().</typeparam>
    public interface IWithDiskLun<ParentT> 
    {
        /// <summary>
        /// Specifies the lun for the data disk to be created from the disk image.
        /// </summary>
        /// <param name="lun">The unique lun for the data disk.</param>
        /// <return>The next stage of the data disk image definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithImageSource<ParentT> WithLun(int lun);
    }

    /// <summary>
    /// The stage of data disk image definition allowing to specify configurations for the data disk when it
    /// is created from the same data disk image.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final CustomImageDataDisk.DefinitionStages.WithAttach.attach().</typeparam>
    public interface IWithDiskSettings<ParentT> 
    {
        /// <summary>
        /// Specifies the size in GB for data disk.
        /// </summary>
        /// <param name="diskSizeGB">The disk size in GB.</param>
        /// <return>The next stage of the data disk image definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithAttach<ParentT> WithDiskSizeInGB(int diskSizeGB);

        /// <summary>
        /// Specifies the caching type for data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type.</param>
        /// <return>The next stage of the data disk image definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithAttach<ParentT> WithDiskCaching(CachingTypes cachingType);
    }

    /// <summary>
    /// The first stage of the data disk image definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final CustomImageDataDisk.DefinitionStages.WithAttach.attach().</typeparam>
    public interface IBlank<ParentT>  :
        IWithDiskLun<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the data disk image definition.
    /// At this stage, any remaining optional settings can be specified, or the data disk definition
    /// can be attached to the parent image definition using CustomImageDataDisk.DefinitionStages.WithAttach.attach().
    /// </summary>
    /// <typeparam name="Parent">The return type of CustomImageDataDisk.DefinitionStages.WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        IInDefinition<ParentT>,
        IWithDiskSettings<ParentT>
    {
    }

    /// <summary>
    /// The entirety of a data disk image definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final DefinitionStages.WithAttach.attach().</typeparam>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithDiskLun<ParentT>,
        IWithImageSource<ParentT>,
        IWithDiskSettings<ParentT>,
        IWithAttach<ParentT>
    {
    }
}