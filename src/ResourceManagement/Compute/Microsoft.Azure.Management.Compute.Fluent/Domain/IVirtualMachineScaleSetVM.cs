// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Threading;

    /// <summary>
    /// An immutable client-side representation of a virtual machine instance in an Azure virtual machine scale set.
    /// </summary>
    public interface IVirtualMachineScaleSetVM :
        IResource,
        IChildResource<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>,
        IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM>,
        IWrapper<Models.VirtualMachineScaleSetVMInner>
    {
        /// <return>The time zone of the Windows virtual machine.</return>
        string WindowsTimeZone { get; }

        /// <return>True if the latest scale set model changes are applied to the virtual machine instance.</return>
        bool IsLatestScaleSetUpdateApplied { get; }

        /// <return>
        /// Vhd uri of the custom image that the virtual machine instance operating system is based on,
        /// null will be returned if the operating system is based on platform image.
        /// </return>
        string CustomImageVhdUri { get; }

        /// <return>True if the boot diagnostic is enabled, false otherwise.</return>
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

        /// <return>The size of the operating system disk.</return>
        int OsDiskSizeInGB { get; }

        /// <return>The uri to the storage account storing boot diagnostics log.</return>
        string BootDiagnosticStorageAccountUri { get; }

        /// <return>True if this is a Windows virtual machine and Vm agent is provisioned, false otherwise.</return>
        bool IsWindowsVmAgentProvisioned { get; }

        /// <summary>
        /// Updates the version of the installed operating system in the virtual machine instance.
        /// </summary>
        void Reimage();

        /// <summary>
        /// Gets the instance view of the virtual machine instance.
        /// <p>
        /// To get the latest instance view use VirtualMachineScaleSetVM.refreshInstanceView().
        /// </summary>
        /// <return>The instance view.</return>
        Models.VirtualMachineInstanceView InstanceView { get; }

        /// <return>The instance id assigned to this virtual machine instance.</return>
        string InstanceId { get; }

        /// <return>The power state of the virtual machine instance.</return>
        Microsoft.Azure.Management.Compute.Fluent.PowerState PowerState { get; }

        /// <return>
        /// True if the operating system of the virtual machine instance is based on platform image,
        /// false if based on custom image.
        /// </return>
        bool IsOsBasedOnPlatformImage { get; }

        /// <return>The virtual machine instance computer name with prefix VirtualMachineScaleSet.computerNamePrefix().</return>
        string ComputerName { get; }

        /// <return>The name of the operating system disk.</return>
        string OsDiskName { get; }

        /// <return>The caching type of the operating system disk.</return>
        Models.CachingTypes OsDiskCachingType { get; }

        /// <return>The operating system type.</return>
        Models.OperatingSystemTypes OsType { get; }

        /// <return>
        /// Reference to the platform image that the virtual machine instance operating system is based on,
        /// null will be returned if the operating system is based on custom image.
        /// </return>
        Models.ImageReference PlatformImageReference { get; }

        /// <return>The diagnostics profile of the virtual machine instance.</return>
        Models.DiagnosticsProfile DiagnosticsProfile { get; }

        /// <return>
        /// The sku of the virtual machine instance, this will be sku used while creating the parent
        /// virtual machine scale set.
        /// </return>
        Models.Sku Sku { get; }

        /// <return>The list of resource id of network interface associated with the virtual machine instance.</return>
        System.Collections.Generic.IList<string> NetworkInterfaceIds { get; }

        /// <summary>
        /// Stops the virtual machine instance.
        /// </summary>
        /// <return>The observable to the poweroff action.</return>
        Task PowerOffAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The name of the admin user.</return>
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

        /// <return>True if this is a Windows virtual machine and automatic update is turned on, false otherwise.</return>
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

        /// <return>The extensions associated with the virtual machine instance, indexed by name.</return>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVMInstanceExtension> Extensions { get; }

        /// <return>Virtual machine instance size.</return>
        Models.VirtualMachineSizeTypes Size { get; }

        /// <return>The storage profile of the virtual machine instance.</return>
        Models.StorageProfile StorageProfile { get; }

        /// <return>True if this is a Linux virtual machine and password based login is enabled, false otherwise.</return>
        bool IsLinuxPasswordAuthenticationEnabled { get; }

        /// <return>Vhd uri to the operating system disk.</return>
        string OsDiskVhdUri { get; }

        /// <return>Resource id of primary network interface associated with virtual machine instance.</return>
        string PrimaryNetworkInterfaceId { get; }

        /// <return>The resource id of the availability set that this virtual machine instance belongs to.</return>
        string AvailabilitySetId { get; }

        /// <summary>
        /// Shuts down the virtual machine instance and releases the associated compute resources.
        /// </summary>
        /// <return>The observable to the deallocate action.</return>
        Task DeallocateAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The operating system profile of an virtual machine instance.</return>
        Models.OSProfile OsProfile { get; }
    }
}