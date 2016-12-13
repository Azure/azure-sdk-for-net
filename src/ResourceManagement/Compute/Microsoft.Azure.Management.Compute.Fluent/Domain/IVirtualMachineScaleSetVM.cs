// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of a virtual machine instance in an Azure virtual machine scale set.
    /// </summary>
    public interface IVirtualMachineScaleSetVM  :
        IResource,
        IChildResource<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>,
        IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM>,
        IWrapper<Models.VirtualMachineScaleSetVMInner>
    {
        /// <summary>
        /// Gets the time zone of the Windows virtual machine.
        /// </summary>
        string WindowsTimeZone { get; }

        /// <summary>
        /// Gets true if the latest scale set model changes are applied to the virtual machine instance.
        /// </summary>
        bool IsLatestScaleSetUpdateApplied { get; }

        /// <summary>
        /// Gets vhd uri of the custom image that the virtual machine instance operating system is based on,
        /// null will be returned if the operating system is based on platform image.
        /// </summary>
        string CustomImageVhdUri { get; }

        /// <summary>
        /// Gets true if the boot diagnostic is enabled, false otherwise.
        /// </summary>
        bool BootDiagnosticEnabled { get; }

        /// <summary>
        /// Stops the virtual machine instance.
        /// </summary>
        void PowerOff();

        /// <summary>
        /// Shuts down the virtual machine instance and releases the associated compute resources.
        /// </summary>
        void Deallocate();

        /// <summary>
        /// Restarts the virtual machine instance.
        /// </summary>
        /// <return>The observable to the restart action.</return>
        Task RestartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Refreshes the instance view.
        /// </summary>
        /// <return>The instance view.</return>
        Models.VirtualMachineInstanceView RefreshInstanceView();

        /// <return>
        /// The platform image that the virtual machine instance operating system is based on, null be
        /// returned if the operating system is based on custom image.
        /// </return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage GetPlatformImage();

        /// <summary>
        /// Deletes the virtual machine instance.
        /// </summary>
        void Delete();

        /// <summary>
        /// Gets the size of the operating system disk.
        /// </summary>
        int OsDiskSizeInGB { get; }

        /// <summary>
        /// Gets the uri to the storage account storing boot diagnostics log.
        /// </summary>
        string BootDiagnosticStorageAccountUri { get; }

        /// <summary>
        /// Gets true if this is a Windows virtual machine and Vm agent is provisioned, false otherwise.
        /// </summary>
        bool IsWindowsVmAgentProvisioned { get; }

        /// <summary>
        /// Updates the version of the installed operating system in the virtual machine instance.
        /// </summary>
        void Reimage();

        /// <summary>
        /// Gets Gets the instance view of the virtual machine instance.
        /// To get the latest instance view use VirtualMachineScaleSetVM.refreshInstanceView().
        /// </summary>
        /// <summary>
        /// Gets the instance view.
        /// </summary>
        Models.VirtualMachineInstanceView InstanceView { get; }

        /// <summary>
        /// Gets the instance id assigned to this virtual machine instance.
        /// </summary>
        string InstanceId { get; }

        /// <summary>
        /// Gets the power state of the virtual machine instance.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.PowerState PowerState { get; }

        /// <summary>
        /// Gets true if the operating system of the virtual machine instance is based on platform image,
        /// false if based on custom image.
        /// </summary>
        bool IsOsBasedOnPlatformImage { get; }

        /// <summary>
        /// Gets the virtual machine instance computer name with prefix VirtualMachineScaleSet.computerNamePrefix().
        /// </summary>
        string ComputerName { get; }

        /// <summary>
        /// Gets the name of the operating system disk.
        /// </summary>
        string OsDiskName { get; }

        /// <summary>
        /// Gets the caching type of the operating system disk.
        /// </summary>
        Models.CachingTypes OsDiskCachingType { get; }

        /// <summary>
        /// Gets the operating system type.
        /// </summary>
        Models.OperatingSystemTypes OsType { get; }

        /// <summary>
        /// Gets reference to the platform image that the virtual machine instance operating system is based on,
        /// null will be returned if the operating system is based on custom image.
        /// </summary>
        Models.ImageReference PlatformImageReference { get; }

        /// <summary>
        /// Gets the diagnostics profile of the virtual machine instance.
        /// </summary>
        Models.DiagnosticsProfile DiagnosticsProfile { get; }

        /// <summary>
        /// Gets the sku of the virtual machine instance, this will be sku used while creating the parent
        /// virtual machine scale set.
        /// </summary>
        Models.Sku Sku { get; }

        /// <summary>
        /// Gets the list of resource id of network interface associated with the virtual machine instance.
        /// </summary>
        System.Collections.Generic.IList<string> NetworkInterfaceIds { get; }

        /// <summary>
        /// Stops the virtual machine instance.
        /// </summary>
        /// <return>The observable to the poweroff action.</return>
        Task PowerOffAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the name of the admin user.
        /// </summary>
        string AdministratorUserName { get; }

        /// <summary>
        /// Updates the version of the installed operating system in the virtual machine instance.
        /// </summary>
        /// <return>The observable to the reimage action.</return>
        Task ReimageAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Restarts the virtual machine instance.
        /// </summary>
        void Restart();

        /// <summary>
        /// Starts the virtual machine instance.
        /// </summary>
        void Start();

        /// <summary>
        /// Gets true if this is a Windows virtual machine and automatic update is turned on, false otherwise.
        /// </summary>
        bool IsWindowsAutoUpdateEnabled { get; }

        /// <summary>
        /// Deletes the virtual machine instance.
        /// </summary>
        /// <return>The observable to the delete action.</return>
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Starts the virtual machine instance.
        /// </summary>
        /// <return>The observable to the start action.</return>
        Task StartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the extensions associated with the virtual machine instance, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVMInstanceExtension> Extensions { get; }

        /// <summary>
        /// Gets virtual machine instance size.
        /// </summary>
        Models.VirtualMachineSizeTypes Size { get; }

        /// <summary>
        /// Gets the storage profile of the virtual machine instance.
        /// </summary>
        Models.StorageProfile StorageProfile { get; }

        /// <summary>
        /// Gets true if this is a Linux virtual machine and password based login is enabled, false otherwise.
        /// </summary>
        bool IsLinuxPasswordAuthenticationEnabled { get; }

        /// <summary>
        /// Gets vhd uri to the operating system disk.
        /// </summary>
        string OsDiskVhdUri { get; }

        /// <summary>
        /// Gets resource id of primary network interface associated with virtual machine instance.
        /// </summary>
        string PrimaryNetworkInterfaceId { get; }

        /// <summary>
        /// Gets the resource id of the availability set that this virtual machine instance belongs to.
        /// </summary>
        string AvailabilitySetId { get; }

        /// <summary>
        /// Shuts down the virtual machine instance and releases the associated compute resources.
        /// </summary>
        /// <return>The observable to the deallocate action.</return>
        Task DeallocateAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the operating system profile of an virtual machine instance.
        /// </summary>
        Models.OSProfile OsProfile { get; }
    }
}