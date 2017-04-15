// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.Disk.Definition
{
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of the managed disk definition allowing to choose Linux OS source.
    /// </summary>
    public interface IWithLinuxDiskSource 
    {
        /// <summary>
        /// Specifies the source specialized or generalized Linux OS VHD.
        /// </summary>
        /// <param name="vhdUrl">The source VHD URL.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithLinuxFromVhd(string vhdUrl);

        /// <summary>
        /// Specifies the source Linux OS managed disk.
        /// </summary>
        /// <param name="sourceDiskId">Source managed disk resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithLinuxFromDisk(string sourceDiskId);

        /// <summary>
        /// Specifies the source Linux OS managed disk.
        /// </summary>
        /// <param name="sourceDisk">Source managed disk.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithLinuxFromDisk(IDisk sourceDisk);

        /// <summary>
        /// Specifies the source Linux OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshotId">Snapshot resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithLinuxFromSnapshot(string sourceSnapshotId);

        /// <summary>
        /// Specifies the source Linux OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshot">Source snapshot.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithLinuxFromSnapshot(ISnapshot sourceSnapshot);
    }

    /// <summary>
    /// The first stage of a managed disk definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose source data disk VHD.
    /// </summary>
    public interface IWithDataDiskFromVhd 
    {
        /// <summary>
        /// Specifies the source data VHD.
        /// </summary>
        /// <param name="vhdUrl">The source VHD URL.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize FromVhd(string vhdUrl);
    }

    /// <summary>
    /// The stage of a managed disk definition allowing to choose a Windows OS source.
    /// </summary>
    public interface IWithWindowsDiskSource 
    {
        /// <summary>
        /// Specifies a source Windows OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshotId">Snapshot resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithWindowsFromSnapshot(string sourceSnapshotId);

        /// <summary>
        /// Specifies a source Windows OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshot">Source snapshot.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithWindowsFromSnapshot(ISnapshot sourceSnapshot);

        /// <summary>
        /// Specifies a source Windows OS managed disk.
        /// </summary>
        /// <param name="sourceDiskId">Source managed disk resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithWindowsFromDisk(string sourceDiskId);

        /// <summary>
        /// Specifies a source Windows OS managed disk.
        /// </summary>
        /// <param name="sourceDisk">Source managed disk.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithWindowsFromDisk(IDisk sourceDisk);

        /// <summary>
        /// Specifies a source specialized or generalized Windows OS VHD.
        /// </summary>
        /// <param name="vhdUrl">The source VHD URL.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithWindowsFromVhd(string vhdUrl);
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose source data disk image.
    /// </summary>
    public interface IWithDataDiskFromImage 
    {
        /// <summary>
        /// Specifies the ID of an image containing source data disk image.
        /// </summary>
        /// <param name="imageId">Image resource ID.</param>
        /// <param name="diskLun">LUN of the disk image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize FromImage(string imageId, int diskLun);

        /// <summary>
        /// Specifies an image containing source data disk image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="diskLun">LUN of the disk image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize FromImage(IVirtualMachineImage image, int diskLun);

        /// <summary>
        /// Specifies a custom image containing a source data disk image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="diskLun">LUN of the disk image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize FromImage(IVirtualMachineCustomImage image, int diskLun);
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose managed disk containing data.
    /// </summary>
    public interface IWithDataDiskFromDisk 
    {
        /// <summary>
        /// Specifies the ID of source data managed disk.
        /// </summary>
        /// <param name="managedDiskId">Source managed disk resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize FromDisk(string managedDiskId);

        /// <summary>
        /// Specifies the source data managed disk.
        /// </summary>
        /// <param name="managedDisk">Source managed disk.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize FromDisk(IDisk managedDisk);
    }

    /// <summary>
    /// The stage of the managed disk definition that specifies it hold data.
    /// </summary>
    public interface IWithData 
    {
        /// <summary>
        /// Begins definition of managed disk containing data.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithDataDiskSource WithData();
    }

    /// <summary>
    /// The stage of a managed disk definition allowing to choose OS source or data source.
    /// </summary>
    public interface IWithDiskSource  :
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithWindowsDiskSource,
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithLinuxDiskSource,
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithData
    {
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to create the disk or optionally specify size.
    /// </summary>
    public interface IWithCreateAndSize  :
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreate
    {
        /// <summary>
        /// Specifies the disk size.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithSizeInGB(int sizeInGB);
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose account type.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the SKU.
        /// </summary>
        /// <param name="sku">The SKU.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreate WithSku(DiskSkuTypes sku);
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose data source.
    /// </summary>
    public interface IWithDataDiskSource  :
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithDataDiskFromVhd,
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithDataDiskFromDisk,
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithDataDiskFromSnapshot
    {
        /// <summary>
        /// Specifies the disk size for an empty disk.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreate WithSizeInGB(int sizeInGB);
    }

    /// <summary>
    /// The stage of a managed disk definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithDiskSource>
    {
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose source operating system image.
    /// </summary>
    public interface IWithOSDiskFromImage 
    {
        /// <summary>
        /// Specifies the ID of an image containing the operating system.
        /// </summary>
        /// <param name="imageId">Image resource ID.</param>
        /// <param name="osType">Operating system type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize FromImage(string imageId, OperatingSystemTypes osType);

        /// <summary>
        /// Specifies an image containing the operating system.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize FromImage(IVirtualMachineImage image);

        /// <summary>
        /// Specifies a custom image containing the operating system.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize FromImage(IVirtualMachineCustomImage image);
    }

    /// <summary>
    /// The entirety of the managed disk definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IBlank,
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithGroup,
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithDiskSource,
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithWindowsDiskSource,
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithLinuxDiskSource,
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithData,
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithDataDiskSource,
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithDataDiskFromVhd,
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithDataDiskFromDisk,
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithDataDiskFromSnapshot,
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize,
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose managed snapshot containing data.
    /// </summary>
    public interface IWithDataDiskFromSnapshot 
    {
        /// <summary>
        /// Specifies the source data managed snapshot.
        /// </summary>
        /// <param name="snapshotId">Snapshot resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize FromSnapshot(string snapshotId);

        /// <summary>
        /// Specifies the source data managed snapshot.
        /// </summary>
        /// <param name="snapshot">Snapshot resource.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize FromSnapshot(ISnapshot snapshot);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created, but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Compute.Fluent.IDisk>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreate>,
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithSku
    {
    }
}