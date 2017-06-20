// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;

    /// <summary>
    /// The stage of the managed disk definition allowing to choose a source operating system image.
    /// </summary>
    public interface IWithOSSnapshotFromImage 
    {
        /// <summary>
        /// Specifies an image containing an operating system.
        /// </summary>
        /// <param name="imageId">Image resource ID.</param>
        /// <param name="osType">Operating system type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate FromImage(string imageId, OperatingSystemTypes osType);

        /// <summary>
        /// Specifies an image containing an operating system.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate FromImage(IVirtualMachineImage image);

        /// <summary>
        /// Specifies a custom image containing an operating system.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate FromImage(IVirtualMachineCustomImage image);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created, but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Compute.Fluent.ISnapshot>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate>,
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithSize,
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithSku
    {
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose managed disk containing data.
    /// </summary>
    public interface IWithDataSnapshotFromDisk 
    {
        /// <summary>
        /// Specifies the ID of source data managed disk.
        /// </summary>
        /// <param name="managedDiskId">Source managed disk resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithDataFromDisk(string managedDiskId);

        /// <summary>
        /// Specifies the source data managed disk.
        /// </summary>
        /// <param name="managedDisk">A source managed disk.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithDataFromDisk(IDisk managedDisk);
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose account type.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the SKU type.
        /// </summary>
        /// <param name="sku">SKU type.</param>
        /// <return>The next stage of the definition.</return>
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
        /// <param name="snapshotId">A snapshot resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithDataFromSnapshot(string snapshotId);

        /// <summary>
        /// Specifies the source data managed snapshot.
        /// </summary>
        /// <param name="snapshot">A snapshot resource.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithDataFromSnapshot(ISnapshot snapshot);
    }

    /// <summary>
    /// The stage of the managed snapshot definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithSnapshotSource>
    {
    }

    /// <summary>
    /// The first stage of a managed snapshot definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of the managed snapshot definition allowing to choose data source.
    /// </summary>
    public interface IWithDataSnapshotSource  :
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithDataSnapshotFromVhd,
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithDataSnapshotFromDisk,
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithDataSnapshotFromSnapshot
    {
    }

    /// <summary>
    /// The stage of the managed snapshot definition allowing to choose OS source or data source.
    /// </summary>
    public interface IWithSnapshotSource  :
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithWindowsSnapshotSource,
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithLinuxSnapshotSource,
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithDataSnapshotSource
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
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithSizeInGB(int sizeInGB);
    }

    /// <summary>
    /// The stage of the managed snapshot definition allowing to choose a Linux OS source.
    /// </summary>
    public interface IWithLinuxSnapshotSource 
    {
        /// <summary>
        /// Specifies the source specialized or generalized Linux OS VHD.
        /// </summary>
        /// <param name="vhdUrl">The source VHD URL.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithLinuxFromVhd(string vhdUrl);

        /// <summary>
        /// Specifies the source Linux OS managed disk.
        /// </summary>
        /// <param name="sourceDiskId">A source managed disk resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithLinuxFromDisk(string sourceDiskId);

        /// <summary>
        /// Specifies the source Linux OS managed disk.
        /// </summary>
        /// <param name="sourceDisk">A source managed disk.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithLinuxFromDisk(IDisk sourceDisk);

        /// <summary>
        /// Specifies the source Linux OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshotId">A snapshot resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithLinuxFromSnapshot(string sourceSnapshotId);

        /// <summary>
        /// Specifies the source Linux OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshot">A source snapshot.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithLinuxFromSnapshot(ISnapshot sourceSnapshot);
    }

    /// <summary>
    /// The entirety of the managed snapshot definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IBlank,
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithGroup,
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithSnapshotSource,
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithWindowsSnapshotSource,
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithLinuxSnapshotSource,
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithDataSnapshotSource,
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithDataSnapshotFromVhd,
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithDataSnapshotFromDisk,
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithDataSnapshotFromSnapshot,
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of the managed snapshot definition allowing to choose Windows OS source.
    /// </summary>
    public interface IWithWindowsSnapshotSource 
    {
        /// <summary>
        /// Specifies the source Windows OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshotId">A snapshot resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithWindowsFromSnapshot(string sourceSnapshotId);

        /// <summary>
        /// Specifies the source Windows OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshot">A source snapshot.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithWindowsFromSnapshot(ISnapshot sourceSnapshot);

        /// <summary>
        /// Specifies the source Windows OS managed disk.
        /// </summary>
        /// <param name="sourceDiskId">A source managed disk resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithWindowsFromDisk(string sourceDiskId);

        /// <summary>
        /// Specifies the source Windows OS managed disk.
        /// </summary>
        /// <param name="sourceDisk">A source managed disk.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithWindowsFromDisk(IDisk sourceDisk);

        /// <summary>
        /// Specifies the source specialized or generalized Windows OS VHD.
        /// </summary>
        /// <param name="vhdUrl">The source VHD URL.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithWindowsFromVhd(string vhdUrl);
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose source data disk image.
    /// </summary>
    public interface IWithDataSnapshotFromImage 
    {
        /// <summary>
        /// Specifies an image containing source data disk image.
        /// </summary>
        /// <param name="imageId">An image resource ID.</param>
        /// <param name="diskLun">LUN of the disk image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate FromImage(string imageId, int diskLun);

        /// <summary>
        /// Specifies an image containing a source data disk image.
        /// </summary>
        /// <param name="image">An image.</param>
        /// <param name="diskLun">LUN of the disk image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate FromImage(IVirtualMachineImage image, int diskLun);

        /// <summary>
        /// Specifies a custom image containing a source data disk image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="diskLun">LUN of the disk image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate FromImage(IVirtualMachineCustomImage image, int diskLun);
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose source data disk VHD.
    /// </summary>
    public interface IWithDataSnapshotFromVhd 
    {
        /// <summary>
        /// Specifies the source data VHD.
        /// </summary>
        /// <param name="vhdUrl">A source VHD URL.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition.IWithCreate WithDataFromVhd(string vhdUrl);
    }
}