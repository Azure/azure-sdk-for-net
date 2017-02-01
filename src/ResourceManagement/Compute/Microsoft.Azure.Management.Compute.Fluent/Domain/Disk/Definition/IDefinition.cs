// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.Disk.Definition
{
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of the managed disk definition allowing to choose Linux OS source.
    /// </summary>
    public interface IWithLinuxDiskSource 
    {
        /// <summary>
        /// Specifies the source specialized or generalized Linux OS vhd.
        /// </summary>
        /// <param name="vhdUrl">The source vhd url.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithLinuxFromVhd(string vhdUrl);

        /// <summary>
        /// Specifies the source Linux OS managed disk.
        /// </summary>
        /// <param name="sourceDiskId">Source managed disk resource id.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithLinuxFromDisk(string sourceDiskId);

        /// <summary>
        /// Specifies the source Linux OS managed disk.
        /// </summary>
        /// <param name="sourceDisk">Source managed disk.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithLinuxFromDisk(IDisk sourceDisk);

        /// <summary>
        /// Specifies the source Linux OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshotId">Snapshot resource id.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithLinuxFromSnapshot(string sourceSnapshotId);

        /// <summary>
        /// Specifies the source Linux OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshot">Source snapshot.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithLinuxFromSnapshot(ISnapshot sourceSnapshot);
    }

    /// <summary>
    /// The first stage of a managed disk definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose source data disk vhd.
    /// </summary>
    public interface IWithDataDiskFromVhd 
    {
        /// <summary>
        /// Specifies the source data vhd.
        /// </summary>
        /// <param name="vhdUrl">The source vhd url.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize FromVhd(string vhdUrl);
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose Windows OS source.
    /// </summary>
    public interface IWithWindowsDiskSource 
    {
        /// <summary>
        /// Specifies the source specialized or generalized Windows OS vhd.
        /// </summary>
        /// <param name="vhdUrl">The source vhd url.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithWindowsFromVhd(string vhdUrl);

        /// <summary>
        /// Specifies the source Windows OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshotId">Snapshot resource id.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithWindowsFromSnapshot(string sourceSnapshotId);

        /// <summary>
        /// Specifies the source Windows OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshot">Source snapshot.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithWindowsFromSnapshot(ISnapshot sourceSnapshot);

        /// <summary>
        /// Specifies the source Windows OS managed disk.
        /// </summary>
        /// <param name="sourceDiskId">Source managed disk resource id.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithWindowsFromDisk(string sourceDiskId);

        /// <summary>
        /// Specifies the source Windows OS managed disk.
        /// </summary>
        /// <param name="sourceDisk">Source managed disk.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithWindowsFromDisk(IDisk sourceDisk);
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose source data disk image.
    /// </summary>
    public interface IWithDataDiskFromImage 
    {
        /// <summary>
        /// Specifies id of the image containing source data disk image.
        /// </summary>
        /// <param name="imageId">Image resource id.</param>
        /// <param name="diskLun">Lun of the disk image.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize FromImage(string imageId, int diskLun);

        /// <summary>
        /// Specifies the image containing source data disk image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="diskLun">Lun of the disk image.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize FromImage(IVirtualMachineImage image, int diskLun);

        /// <summary>
        /// Specifies the custom image containing source data disk image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="diskLun">Lun of the disk image.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize FromImage(IVirtualMachineCustomImage image, int diskLun);
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose managed disk containing data.
    /// </summary>
    public interface IWithDataDiskFromDisk 
    {
        /// <summary>
        /// Specifies the id of source data managed disk.
        /// </summary>
        /// <param name="managedDiskId">Source managed disk resource id.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize FromDisk(string managedDiskId);

        /// <summary>
        /// Specifies the source data managed disk.
        /// </summary>
        /// <param name="managedDisk">Source managed disk.</param>
        /// <return>The next stage of the managed disk definition.</return>
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
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithDataDiskSource WithData();
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose OS source or data source.
    /// </summary>
    public interface IWithDiskSource  :
        IWithWindowsDiskSource,
        IWithLinuxDiskSource,
        IWithData
    {
    }

    /// <summary>
    /// The stage of the managed disk definition that allowing to create or optionally specify size.
    /// </summary>
    public interface IWithCreateAndSize  :
        IWithCreate
    {
        /// <summary>
        /// Specifies the disk size.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize WithSizeInGB(int sizeInGB);
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose account type.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the sku.
        /// </summary>
        /// <param name="sku">The sku.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreate WithSku(DiskSkuTypes sku);
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose data source.
    /// </summary>
    public interface IWithDataDiskSource  :
        IWithDataDiskFromVhd,
        IWithDataDiskFromDisk,
        IWithDataDiskFromSnapshot
    {
        /// <summary>
        /// Specifies the disk size for an empty disk.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreate WithSizeInGB(int sizeInGB);
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithDiskSource>
    {
    }

    /// <summary>
    /// The entirety of the managed disk definition.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithGroup,
        IWithDiskSource,
        IWithWindowsDiskSource,
        IWithLinuxDiskSource,
        IWithData,
        IWithDataDiskSource,
        IWithDataDiskFromVhd,
        IWithDataDiskFromDisk,
        IWithDataDiskFromSnapshot,
        IWithCreateAndSize,
        IWithCreate
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
        /// <param name="snapshotId">Snapshot resource id.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize FromSnapshot(string snapshotId);

        /// <summary>
        /// Specifies the source data managed snapshot.
        /// </summary>
        /// <param name="snapshot">Snapshot resource.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize FromSnapshot(ISnapshot snapshot);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.Compute.Fluent.IDisk>,
        IDefinitionWithTags<Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreate>,
        IWithSku
    {
    }

    /// <summary>
    /// The stage of the managed disk definition allowing to choose source operating system image.
    /// </summary>
    public interface IWithOsDiskFromImage 
    {
        /// <summary>
        /// Specifies id of the image containing operating system.
        /// </summary>
        /// <param name="imageId">Image resource id.</param>
        /// <param name="osType">Operating system type.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize FromImage(string imageId, OperatingSystemTypes osType);

        /// <summary>
        /// Specifies the image containing operating system.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize FromImage(IVirtualMachineImage image);

        /// <summary>
        /// Specifies the custom image containing operating system.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize FromImage(IVirtualMachineCustomImage image);
    }
}