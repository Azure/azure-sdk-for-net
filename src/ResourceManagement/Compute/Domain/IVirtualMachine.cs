// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Rest;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine.
    /// </summary>
    public interface IVirtualMachine :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Compute.Fluent.IComputeManager, Models.VirtualMachineInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<VirtualMachine.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.IHasNetworkInterfaces,
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineBeta
    {
        /// <summary>
        /// Gets true if managed disks are used for the virtual machine's disks (OS, data).
        /// </summary>
        bool IsManagedDiskEnabled { get; }

        /// <summary>
        /// Gets the virtual machine unique ID.
        /// </summary>
        string VMId { get; }

        /// <summary>
        /// Powers off (stops) the virtual machine.
        /// </summary>
        void PowerOff();

        /// <summary>
        /// Shuts down the virtual machine and releases the compute resources.
        /// </summary>
        void Deallocate();

        /// <summary>
        /// Refreshes the virtual machine instance view to sync with Azure.
        /// The instance view will be cached for later retrieval using <code>instanceView</code>.
        /// </summary>
        /// <return>The refreshed instance view.</return>
        Models.VirtualMachineInstanceView RefreshInstanceView();

        /// <summary>
        /// Gets resource ID of the managed disk backing the OS disk.
        /// </summary>
        string OSDiskId { get; }

        /// <summary>
        /// Refreshes the virtual machine instance view to sync with Azure.
        /// </summary>
        /// <return>An observable that emits the instance view of the virtual machine.</return>
        Task<Models.VirtualMachineInstanceView> RefreshInstanceViewAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the licenseType value.
        /// </summary>
        string LicenseType { get; }

        /// <summary>
        /// Gets the virtual machine instance view.
        /// The instance view will be cached for later retrieval using <code>instanceView</code>.
        /// </summary>
        /// <summary>
        /// Gets the virtual machine's instance view.
        /// </summary>
        Models.VirtualMachineInstanceView InstanceView { get; }

        /// <return>A representation of the deferred computation of this call, returning extensions attached to the virtual machine.</return>
        Task<IReadOnlyList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension>> ListExtensionsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the power state of the virtual machine.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.PowerState PowerState { get; }

        /// <summary>
        /// Gets name of this virtual machine.
        /// </summary>
        string ComputerName { get; }

        /// <summary>
        /// Gets the operating system of this virtual machine.
        /// </summary>
        Models.OperatingSystemTypes OSType { get; }

        /// <summary>
        /// Gets the operating system disk caching type.
        /// </summary>
        Models.CachingTypes OSDiskCachingType { get; }

        /// <summary>
        /// Generalizes the virtual machine.
        /// </summary>
        void Generalize();

        /// <summary>
        /// Redeploys the virtual machine.
        /// </summary>
        void Redeploy();

        /// <summary>
        /// Gets the diagnostics profile.
        /// </summary>
        Models.DiagnosticsProfile DiagnosticsProfile { get; }

        /// <summary>
        /// Generalizes the virtual machine asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task GeneralizeAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the plan value.
        /// </summary>
        Models.Plan Plan { get; }

        /// <summary>
        /// Powers off (stops) the virtual machine asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task PowerOffAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the size of the operating system disk in GB.
        /// </summary>
        int OSDiskSize { get; }

        /// <summary>
        /// Gets the unmanaged data disks associated with this virtual machine, indexed by LUN number.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<int, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineUnmanagedDataDisk> UnmanagedDataDisks { get; }

        /// <summary>
        /// Restarts the virtual machine.
        /// </summary>
        void Restart();

        /// <return>Extensions attached to the virtual machine.</return>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension> ListExtensions();

        /// <summary>
        /// Starts the virtual machine.
        /// </summary>
        void Start();

        /// <summary>
        /// Captures the virtual machine by copying virtual hard disks of the VM.
        /// </summary>
        /// <param name="containerName">Destination container name to store the captured VHD.</param>
        /// <param name="vhdPrefix">The prefix for the VHD holding captured image.</param>
        /// <param name="overwriteVhd">Whether to overwrites destination VHD if it exists.</param>
        /// <return>The JSON template for creating more such virtual machines.</return>
        string Capture(string containerName, string vhdPrefix, bool overwriteVhd);

        /// <summary>
        /// Redeploys the virtual machine asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task RedeployAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Restarts the virtual machine asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task RestartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the URI to the VHD file backing this virtual machine's operating system disk.
        /// </summary>
        string OSUnmanagedDiskVhdUri { get; }

        /// <summary>
        /// Gets the provisioningState value.
        /// </summary>
        string ProvisioningState { get; }

        /// <summary>
        /// Lists all available virtual machine sizes this virtual machine can resized to.
        /// </summary>
        /// <return>The virtual machine sizes.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize> AvailableSizes();

        /// <summary>
        /// Gets entry point to enabling, disabling and querying disk encryption.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineEncryption DiskEncryption { get; }

        /// <summary>
        /// Starts the virtual machine asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task StartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the storage account type of the managed disk backing OS disk.
        /// </summary>
        Models.StorageAccountTypes? OSDiskStorageAccountType { get; }

        /// <summary>
        /// Gets the virtual machine size.
        /// </summary>
        Models.VirtualMachineSizeTypes Size { get; }

        /// <summary>
        /// Gets Returns the storage profile of an Azure virtual machine.
        /// </summary>
        /// <summary>
        /// Gets the storageProfile value.
        /// </summary>
        Models.StorageProfile StorageProfile { get; }

        /// <summary>
        /// Converts (migrates) the virtual machine with un-managed disks to use managed disk asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task ConvertToManagedAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Converts (migrates) the virtual machine with un-managed disks to use managed disk.
        /// </summary>
        void ConvertToManaged();

        /// <summary>
        /// Gets the managed data disks associated with this virtual machine, indexed by LUN.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<int, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk> DataDisks { get; }

        /// <summary>
        /// Gets the public IP address associated with this virtual machine's primary network interface.
        /// Note that this method makes a rest API call to fetch the resource.
        /// </summary>
        /// <return>The public IP of the primary network interface.</return>
        Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress GetPrimaryPublicIPAddress();

        /// <return>The resource ID of the public IP address associated with this virtual machine's primary network interface.</return>
        string GetPrimaryPublicIPAddressId();

        /// <summary>
        /// Gets the resource ID of the availability set associated with this virtual machine.
        /// </summary>
        string AvailabilitySetId { get; }

        /// <summary>
        /// Shuts down the virtual machine and releases the compute resources asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task DeallocateAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the operating system profile.
        /// </summary>
        Models.OSProfile OSProfile { get; }
    }
}