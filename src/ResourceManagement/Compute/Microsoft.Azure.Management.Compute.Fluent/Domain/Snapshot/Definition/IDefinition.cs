// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition;

    /// <summary>
    /// The stage of the managed disk definition allowing to choose source operating system image.
    /// </summary>
    public interface IWithOsSnapshotFromImage 
    {
        /// <summary>
        /// Specifies id of the image containing operating system.
        /// </summary>
        /// <param name="imageId">Image resource id.</param>
        /// <param name="osType">Operating system type.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate FromImage(string imageId, OperatingSystemTypes osType);

        /// <summary>
        /// Specifies the image containing operating system.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate FromImage(IVirtualMachineImage image);

        /// <summary>
        /// Specifies the custom image containing operating system.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate FromImage(IVirtualMachineCustomImage image);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.Compute.Fluent.ISnapshot>,
        IDefinitionWithTags<Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate>,
        IWithSize,
        IWithSku
    {
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose managed disk containing data.
    /// </summary>
    public interface IWithDataSnapshotFromDisk 
    {
        /// <summary>
        /// Specifies the id of source data managed disk.
        /// </summary>
        /// <param name="managedDiskId">Source managed disk resource id.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithDataFromDisk(string managedDiskId);

        /// <summary>
        /// Specifies the source data managed disk.
        /// </summary>
        /// <param name="managedDisk">Source managed disk.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithDataFromDisk(IDisk managedDisk);
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose account type.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the sku type.
        /// </summary>
        /// <param name="sku">Sku type.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithSku(DiskSkuTypes sku);
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose managed snapshot containing data.
    /// </summary>
    public interface IWithDataSnapshotFromSnapshot 
    {
        /// <summary>
        /// Specifies the source data managed snapshot.
        /// </summary>
        /// <param name="snapshotId">Snapshot resource id.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithDataFromSnapshot(string snapshotId);

        /// <summary>
        /// Specifies the source data managed snapshot.
        /// </summary>
        /// <param name="snapshot">Snapshot resource.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithDataFromSnapshot(ISnapshot snapshot);
    }

    /// <summary>
    /// The stage of the managed snapshot definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithSnapshotSource>
    {
    }

    /// <summary>
    /// The first stage of a managed snapshot definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of the managed snapshot definition allowing to choose data source.
    /// </summary>
    public interface IWithDataSnapshotSource  :
        IWithDataSnapshotFromVhd,
        IWithDataSnapshotFromDisk,
        IWithDataSnapshotFromSnapshot
    {
    }

    /// <summary>
    /// The stage of the managed snapshot definition allowing to choose OS source or data source.
    /// </summary>
    public interface IWithSnapshotSource  :
        IWithWindowsSnapshotSource,
        IWithLinuxSnapshotSource,
        IWithDataSnapshotSource
    {
    }

    /// <summary>
    /// The stage of the managed snapshot allowing to specify the size.
    /// </summary>
    public interface IWithSize 
    {
        /// <summary>
        /// Specifies the disk size.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithSizeInGB(int sizeInGB);
    }

    /// <summary>
    /// The stage of the managed snapshot definition allowing to choose Linux OS source.
    /// </summary>
    public interface IWithLinuxSnapshotSource 
    {
        /// <summary>
        /// Specifies the source specialized or generalized Linux OS vhd.
        /// </summary>
        /// <param name="vhdUrl">The source vhd url.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithLinuxFromVhd(string vhdUrl);

        /// <summary>
        /// Specifies the source Linux OS managed disk.
        /// </summary>
        /// <param name="sourceDiskId">Source managed disk resource id.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithLinuxFromDisk(string sourceDiskId);

        /// <summary>
        /// Specifies the source Linux OS managed disk.
        /// </summary>
        /// <param name="sourceDisk">Source managed disk.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithLinuxFromDisk(IDisk sourceDisk);

        /// <summary>
        /// Specifies the source Linux OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshotId">Snapshot resource id.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithLinuxFromSnapshot(string sourceSnapshotId);

        /// <summary>
        /// Specifies the source Linux OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshot">Source snapshot.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithLinuxFromSnapshot(ISnapshot sourceSnapshot);
    }

    /// <summary>
    /// The entirety of the managed snapshot definition.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithGroup,
        IWithSnapshotSource,
        IWithWindowsSnapshotSource,
        IWithLinuxSnapshotSource,
        IWithDataSnapshotSource,
        IWithDataSnapshotFromVhd,
        IWithDataSnapshotFromDisk,
        IWithDataSnapshotFromSnapshot,
        IWithCreate
    {
    }

    /// <summary>
    /// The stage of the managed snapshot definition allowing to choose Windows OS source.
    /// </summary>
    public interface IWithWindowsSnapshotSource 
    {
        /// <summary>
        /// Specifies the source specialized or generalized Windows OS vhd.
        /// </summary>
        /// <param name="vhdUrl">The source vhd url.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithWindowsFromVhd(string vhdUrl);

        /// <summary>
        /// Specifies the source Windows OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshotId">Snapshot resource id.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithWindowsFromSnapshot(string sourceSnapshotId);

        /// <summary>
        /// Specifies the source Windows OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshot">Source snapshot.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithWindowsFromSnapshot(ISnapshot sourceSnapshot);

        /// <summary>
        /// Specifies the source Windows OS managed disk.
        /// </summary>
        /// <param name="sourceDiskId">Source managed disk resource id.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithWindowsFromDisk(string sourceDiskId);

        /// <summary>
        /// Specifies the source Windows OS managed disk.
        /// </summary>
        /// <param name="sourceDisk">Source managed disk.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithWindowsFromDisk(IDisk sourceDisk);
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose source data disk image.
    /// </summary>
    public interface IWithDataSnapshotFromImage 
    {
        /// <summary>
        /// Specifies id of the image containing source data disk image.
        /// </summary>
        /// <param name="imageId">Image resource id.</param>
        /// <param name="diskLun">Lun of the disk image.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate FromImage(string imageId, int diskLun);

        /// <summary>
        /// Specifies the image containing source data disk image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="diskLun">Lun of the disk image.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate FromImage(IVirtualMachineImage image, int diskLun);

        /// <summary>
        /// Specifies the custom image containing source data disk image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="diskLun">Lun of the disk image.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate FromImage(IVirtualMachineCustomImage image, int diskLun);
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose source data disk vhd.
    /// </summary>
    public interface IWithDataSnapshotFromVhd 
    {
        /// <summary>
        /// Specifies the source data vhd.
        /// </summary>
        /// <param name="vhdUrl">The source vhd url.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithDataFromVhd(string vhdUrl);
    }
}