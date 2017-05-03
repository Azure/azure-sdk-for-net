// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// An immutable client-side representation of a virtual machine instance in an Azure virtual machine scale set.
    /// </summary>
    public interface IVirtualMachineScaleSetVM  :
        IVirtualMachineScaleSetVMBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.VirtualMachineScaleSetVMInner>
    {
        /// <return>
        /// The platform image that the virtual machine instance operating system is based on, null be
        /// returned otherwise.
        /// </return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage GetOSPlatformImage();

        /// <summary>
        /// Gets true if the operating system of the virtual machine instance is based on platform image.
        /// </summary>
        bool IsOSBasedOnPlatformImage { get; }

        /// <summary>
        /// Gets the resource ID of the availability set that this virtual machine instance belongs to.
        /// </summary>
        string AvailabilitySetId { get; }

        /// <summary>
        /// Gets the extensions associated with the virtual machine instance, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVMInstanceExtension> Extensions { get; }

        /// <summary>
        /// Gets VHD URI to the operating system disk.
        /// </summary>
        string OSUnmanagedDiskVhdUri { get; }

        /// <summary>
        /// Updates the version of the installed operating system in the virtual machine instance.
        /// </summary>
        void Reimage();

        /// <return>
        /// The custom image that the virtual machine instance operating system is based on, null be
        /// returned otherwise.
        /// </return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineCustomImage GetOSCustomImage();

        /// <summary>
        /// Gets the unmanaged data disks associated with this virtual machine instance, indexed by LUN.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<int,Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineUnmanagedDataDisk> UnmanagedDataDisks { get; }

        /// <summary>
        /// Gets the time zone of the Windows virtual machine.
        /// </summary>
        string WindowsTimeZone { get; }

        /// <summary>
        /// Stops the virtual machine instance.
        /// </summary>
        void PowerOff();

        /// <summary>
        /// Gets the operating system type.
        /// </summary>
        Models.OperatingSystemTypes OSType { get; }

        /// <summary>
        /// Gets the SKU of the virtual machine instance, this will be SKU used while creating the parent
        /// virtual machine scale set.
        /// </summary>
        Models.Sku Sku { get; }

        /// <summary>
        /// Gets virtual machine instance size.
        /// </summary>
        Models.VirtualMachineSizeTypes Size { get; }

        /// <summary>
        /// Gets the URI to the storage account storing boot diagnostics log.
        /// </summary>
        string BootDiagnosticStorageAccountUri { get; }

        /// <summary>
        /// Gets true if the operating system of the virtual machine instance is based on stored image.
        /// </summary>
        bool IsOSBasedOnStoredImage { get; }

        /// <summary>
        /// Starts the virtual machine instance.
        /// </summary>
        void Start();

        /// <summary>
        /// Gets the managed data disks associated with this virtual machine instance, indexed by LUN.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<int,Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk> DataDisks { get; }

        /// <summary>
        /// Gets true if this is a Windows virtual machine and automatic update is turned on, false otherwise.
        /// </summary>
        bool IsWindowsAutoUpdateEnabled { get; }

        /// <summary>
        /// Gets the virtual machine instance computer name with the VM scale set prefix.
        /// </summary>
        string ComputerName { get; }

        /// <summary>
        /// Gets true if the latest scale set model changes are applied to the virtual machine instance.
        /// </summary>
        bool IsLatestScaleSetUpdateApplied { get; }

        /// <summary>
        /// Gets the instance view of the virtual machine instance.
        /// To get the latest instance view use <code>refreshInstanceView()</code>.
        /// </summary>
        /// <summary>
        /// Gets the instance view.
        /// </summary>
        Models.VirtualMachineInstanceView InstanceView { get; }

        /// <summary>
        /// Gets the name of the admin user.
        /// </summary>
        string AdministratorUserName { get; }

        /// <summary>
        /// Gets resource ID of the managed disk backing OS disk.
        /// </summary>
        string OSDiskId { get; }

        /// <summary>
        /// Gets true if this is a Windows virtual machine and VM agent is provisioned, false otherwise.
        /// </summary>
        bool IsWindowsVMAgentProvisioned { get; }

        /// <summary>
        /// Gets a network interface associated with this virtual machine instance.
        /// </summary>
        /// <param name="name">The name of the network interface.</param>
        /// <return>The network interface.</return>
        Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface GetNetworkInterface(string name);

        /// <summary>
        /// Gets the storage profile of the virtual machine instance.
        /// </summary>
        Models.StorageProfile StorageProfile { get; }

        /// <summary>
        /// Gets the list of resource ID of network interface associated with the virtual machine instance.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> NetworkInterfaceIds { get; }

        /// <summary>
        /// Deletes the virtual machine instance.
        /// </summary>
        void Delete();

        /// <summary>
        /// Gets resource ID of primary network interface associated with virtual machine instance.
        /// </summary>
        string PrimaryNetworkInterfaceId { get; }

        /// <summary>
        /// Gets true if the operating system of the virtual machine instance is based on custom image.
        /// </summary>
        bool IsOSBasedOnCustomImage { get; }

        /// <summary>
        /// Gets true if managed disk is used for the virtual machine's disks (os, data).
        /// </summary>
        bool IsManagedDiskEnabled { get; }

        /// <summary>
        /// Restarts the virtual machine instance.
        /// </summary>
        void Restart();

        /// <summary>
        /// Gets the size of the operating system disk.
        /// </summary>
        int OSDiskSizeInGB { get; }

        /// <summary>
        /// Gets the instance ID assigned to this virtual machine instance.
        /// </summary>
        string InstanceId { get; }

        /// <summary>
        /// Gets true if the boot diagnostic is enabled, false otherwise.
        /// </summary>
        bool BootDiagnosticEnabled { get; }

        /// <summary>
        /// Gets the operating system profile of an virtual machine instance.
        /// </summary>
        Models.OSProfile OSProfile { get; }

        /// <return>The network interfaces associated with this virtual machine instance.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface> ListNetworkInterfaces();

        /// <summary>
        /// Refreshes the instance view.
        /// </summary>
        /// <return>The instance view.</return>
        Models.VirtualMachineInstanceView RefreshInstanceView();

        /// <summary>
        /// Gets the diagnostics profile of the virtual machine instance.
        /// </summary>
        Models.DiagnosticsProfile DiagnosticsProfile { get; }

        /// <summary>
        /// Gets the power state of the virtual machine instance.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.PowerState PowerState { get; }

        /// <summary>
        /// Gets the name of the operating system disk.
        /// </summary>
        string OSDiskName { get; }

        /// <summary>
        /// Gets VHD URI of the custom image that the virtual machine instance operating system is based on,
        /// null will be returned if the operating system is based on platform image.
        /// </summary>
        string StoredImageUnmanagedVhdUri { get; }

        /// <summary>
        /// Gets the caching type of the operating system disk.
        /// </summary>
        Models.CachingTypes OSDiskCachingType { get; }

        /// <summary>
        /// Shuts down the virtual machine instance and releases the associated compute resources.
        /// </summary>
        void Deallocate();

        /// <summary>
        /// Gets true if this is a Linux virtual machine and password based login is enabled, false otherwise.
        /// </summary>
        bool IsLinuxPasswordAuthenticationEnabled { get; }

        /// <summary>
        /// Gets reference to the platform image that the virtual machine instance operating system is based on,
        /// null will be returned if the operating system is based on custom image.
        /// </summary>
        ImageReference PlatformImageReference { get; }
    }
}