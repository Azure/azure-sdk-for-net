// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition;

    /// <summary>
    /// The first stage of a image definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The entirety of the image definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IBlank,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithGroup,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithOSDiskImageSourceAltVirtualMachineSource,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithOSDiskImageSource,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithSourceVirtualMachine,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings
    {
    }

    /// <summary>
    /// The stage of the image definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithOSDiskImageSourceAltVirtualMachineSource>
    {
    }

    /// <summary>
    /// The stage of the image definition that allows choosing between using a virtual machine as
    /// the source for OS and the data disk images or beginning an OS disk image definition.
    /// </summary>
    public interface IWithOSDiskImageSourceAltVirtualMachineSource  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithOSDiskImageSource,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithSourceVirtualMachine
    {
    }

    /// <summary>
    /// The stage of the image definition allowing to choose source virtual machine.
    /// </summary>
    public interface IWithSourceVirtualMachine 
    {
        /// <summary>
        /// Uses the virtual machine's OS disk and data disks as the source for OS disk image and
        /// data disk images of this image.
        /// </summary>
        /// <param name="virtualMachineId">Source virtual machine resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithCreate FromVirtualMachine(string virtualMachineId);

        /// <summary>
        /// Uses the virtual machine's OS and data disks as the sources for OS disk image and data
        /// disk images of this image.
        /// </summary>
        /// <param name="virtualMachine">Source virtual machine.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithCreate FromVirtualMachine(IVirtualMachine virtualMachine);
    }

    /// <summary>
    /// The stage of an image definition containing all the required inputs for
    /// the resource to be created, but also allowing
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineCustomImage>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The stage of the image definition allowing to choose an OS source and an OS state for the OS image.
    /// </summary>
    public interface IWithOSDiskImageSource 
    {
        /// <summary>
        /// Specifies the Windows source native VHD for the OS disk image.
        /// </summary>
        /// <param name="sourceVhdUrl">Source Windows virtual hard disk URL.</param>
        /// <param name="osState">Operating system state.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings WithWindowsFromVhd(string sourceVhdUrl, OperatingSystemStateTypes osState);

        /// <summary>
        /// Specifies the Linux source native VHD for the OS disk image.
        /// </summary>
        /// <param name="sourceVhdUrl">Source Linux virtual hard disk URL.</param>
        /// <param name="osState">Operating system state.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings WithLinuxFromVhd(string sourceVhdUrl, OperatingSystemStateTypes osState);

        /// <summary>
        /// Specifies the Windows source snapshot for the OS disk image.
        /// </summary>
        /// <param name="sourceSnapshot">Source snapshot resource.</param>
        /// <param name="osState">Operating system state.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings WithWindowsFromSnapshot(ISnapshot sourceSnapshot, OperatingSystemStateTypes osState);

        /// <summary>
        /// Specifies the Windows source snapshot for the OS disk image.
        /// </summary>
        /// <param name="sourceSnapshotId">Source snapshot resource ID.</param>
        /// <param name="osState">Operating system state.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings WithWindowsFromSnapshot(string sourceSnapshotId, OperatingSystemStateTypes osState);

        /// <summary>
        /// Specifies the Windows source managed disk for the OS disk image.
        /// </summary>
        /// <param name="sourceManagedDiskId">Source managed disk resource ID.</param>
        /// <param name="osState">Operating system state.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings WithWindowsFromDisk(string sourceManagedDiskId, OperatingSystemStateTypes osState);

        /// <summary>
        /// Specifies the Windows source managed disk for the OS disk image.
        /// </summary>
        /// <param name="sourceManagedDisk">Source managed disk.</param>
        /// <param name="osState">Operating system state.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings WithWindowsFromDisk(IDisk sourceManagedDisk, OperatingSystemStateTypes osState);

        /// <summary>
        /// Specifies the Linux source managed disk for the OS disk image.
        /// </summary>
        /// <param name="sourceManagedDiskId">Source managed disk resource ID.</param>
        /// <param name="osState">Operating system state.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings WithLinuxFromDisk(string sourceManagedDiskId, OperatingSystemStateTypes osState);

        /// <summary>
        /// Specifies the Linux source managed disk for the OS disk image.
        /// </summary>
        /// <param name="sourceManagedDisk">Source managed disk.</param>
        /// <param name="osState">Operating system state.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings WithLinuxFromDisk(IDisk sourceManagedDisk, OperatingSystemStateTypes osState);

        /// <summary>
        /// Specifies the Linux source snapshot for the OS disk image.
        /// </summary>
        /// <param name="sourceSnapshot">Source snapshot resource.</param>
        /// <param name="osState">Operating system state.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings WithLinuxFromSnapshot(ISnapshot sourceSnapshot, OperatingSystemStateTypes osState);

        /// <summary>
        /// Specifies the Linux source snapshot for the OS disk image.
        /// </summary>
        /// <param name="sourceSnapshotId">Source snapshot resource ID.</param>
        /// <param name="osState">Operating system state.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings WithLinuxFromSnapshot(string sourceSnapshotId, OperatingSystemStateTypes osState);
    }

    /// <summary>
    /// The stage of an image definition allowing to add a data disk image.
    /// </summary>
    public interface IWithDataDiskImage 
    {
        /// <summary>
        /// Adds a data disk image with a virtual hard disk as the source.
        /// </summary>
        /// <param name="sourceVhdUrl">Source virtual hard disk URL.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings WithDataDiskImageFromVhd(string sourceVhdUrl);

        /// <summary>
        /// Begins the definition of a new data disk image to add to the image.
        /// </summary>
        /// <return>The first stage of the new data disk image definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.CustomImageDataDisk.Definition.IBlank<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings> DefineDataDiskImage();

        /// <summary>
        /// Adds a data disk image with an existing managed disk as the source.
        /// </summary>
        /// <param name="sourceManagedDiskId">Source managed disk resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings WithDataDiskImageFromManagedDisk(string sourceManagedDiskId);

        /// <summary>
        /// Adds a data disk image with an existing snapshot as the source.
        /// </summary>
        /// <param name="sourceSnapshotId">Source snapshot resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings WithDataDiskImageFromSnapshot(string sourceSnapshotId);
    }

    /// <summary>
    /// The stage of an image definition allowing to specify configurations for the OS disk when it
    /// is created from the image's  OS disk image.
    /// </summary>
    public interface IWithOSDiskSettings 
    {
        /// <summary>
        /// Specifies the size in GB for OS disk.
        /// </summary>
        /// <param name="diskSizeGB">The disk size in GB.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings WithOSDiskSizeInGB(int diskSizeGB);

        /// <summary>
        /// Specifies the caching type for OS disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings WithOSDiskCaching(CachingTypes cachingType);
    }

    /// <summary>
    /// The stage of an image definition allowing to create the image or add optional data disk images
    /// and configure OS disk settings.
    /// </summary>
    public interface IWithCreateAndDataDiskImageOSDiskSettings  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithCreate,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithOSDiskSettings,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage.Definition.IWithDataDiskImage
    {
    }
}