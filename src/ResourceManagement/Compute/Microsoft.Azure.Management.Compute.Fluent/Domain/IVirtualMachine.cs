// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Threading;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine.
    /// </summary>
    public interface IVirtualMachine  :
        IGroupableResource<IComputeManager, VirtualMachineInner>,
        IRefreshable<IVirtualMachine>,
        IUpdatable<VirtualMachine.Update.IUpdate>,
        IHasNetworkInterfaces
    {
        /// <summary>
        /// Gets true if managed disk is used for the virtual machine's disks (os, data).
        /// </summary>
        bool IsManagedDiskEnabled { get; }

        /// <summary>
        /// Gets the virtual machine unique id.
        /// </summary>
        string VMId { get; }

        /// <summary>
        /// Power off (stop) the virtual machine.
        /// You will be billed for the compute resources that this Virtual Machine uses.
        /// </summary>
        void PowerOff();

        /// <summary>
        /// Shuts down the Virtual Machine and releases the compute resources.
        /// You are not billed for the compute resources that this Virtual Machine uses.
        /// </summary>
        void Deallocate();

        /// <summary>
        /// Gets entry point to enabling, disabling and querying disk encryption.
        /// </summary>
        IVirtualMachineEncryption DiskEncryption { get; }

        /// <summary>
        /// Refreshes the virtual machine instance view to sync with Azure.
        /// this will caches the instance view which can be later retrieved using VirtualMachine.instanceView().
        /// </summary>
        /// <return>The refreshed instance view.</return>
        Models.VirtualMachineInstanceView RefreshInstanceView();

        /// <summary>
        /// Gets Refreshes the virtual machine instance view to sync with Azure.
        /// </summary>
        /// <summary>
        /// A task that emits the instance view of the virtual machine.
        /// </summary>
        Task<Models.VirtualMachineInstanceView> RefreshInstanceViewAsync(CancellationToken cancellationToken= default(CancellationToken));

        /// <summary>
        /// Convert (migrate) the virtual machine with un-managed disks to use managed disk.
        /// </summary>
        void ConvertToManaged();

        /// <summary>
        /// Gets resource id of the managed disk backing OS disk.
        /// </summary>
        string OsDiskId { get; }

        /// <summary>
        /// Gets the licenseType value.
        /// </summary>
        string LicenseType { get; }

        /// <summary>
        /// Gets Get the virtual machine instance view.
        /// this method returns the cached instance view, to refresh the cache call VirtualMachine.refreshInstanceView().
        /// </summary>
        /// <summary>
        /// Gets the virtual machine instance view.
        /// </summary>
        Models.VirtualMachineInstanceView InstanceView { get; }

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
        Models.OperatingSystemTypes OsType { get; }

        /// <summary>
        /// Gets the operating system disk caching type, valid values are 'None', 'ReadOnly', 'ReadWrite'.
        /// </summary>
        Models.CachingTypes OsDiskCachingType { get; }

        /// <summary>
        /// Generalize the Virtual Machine.
        /// </summary>
        void Generalize();

        /// <summary>
        /// Redeploy the virtual machine.
        /// </summary>
        void Redeploy();

        /// <summary>
        /// Gets Returns the diagnostics profile of an Azure virtual machine.
        /// Enabling diagnostic features in a virtual machine enable you to easily diagnose and recover
        /// virtual machine from boot failures.
        /// </summary>
        /// <summary>
        /// Gets the diagnosticsProfile value.
        /// </summary>
        Models.DiagnosticsProfile DiagnosticsProfile { get; }

        /// <summary>
        /// Gets the plan value.
        /// </summary>
        Models.Plan Plan { get; }

        /// <summary>
        /// Gets the size of the operating system disk in GB.
        /// </summary>
        int OsDiskSize { get; }

        /// <summary>
        /// Gets the unmanaged data disks associated with this virtual machine, indexed by lun.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<int,Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineUnmanagedDataDisk> UnmanagedDataDisks { get; }

        /// <summary>
        /// Restart the virtual machine.
        /// </summary>
        void Restart();

        /// <summary>
        /// Start the virtual machine.
        /// </summary>
        void Start();

        /// <summary>
        /// Captures the virtual machine by copying virtual hard disks of the VM and returns template as json
        /// string that can be used to create similar VMs.
        /// </summary>
        /// <param name="containerName">Destination container name to store the captured Vhd.</param>
        /// <param name="vhdPrefix">The prefix for the vhd holding captured image.</param>
        /// <param name="overwriteVhd">Whether to overwrites destination vhd if it exists.</param>
        /// <return>The template as json string.</return>
        string Capture(string containerName, string vhdPrefix, bool overwriteVhd);

        /// <summary>
        /// Gets the uri to the vhd file backing this virtual machine's operating system disk.
        /// </summary>
        string OsUnmanagedDiskVhdUri { get; }

        /// <summary>
        /// Gets the provisioningState value.
        /// </summary>
        string ProvisioningState { get; }

        /// <summary>
        /// List of all available virtual machine sizes this virtual machine can resized to.
        /// </summary>
        /// <return>The virtual machine sizes.</return>
        IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize> AvailableSizes();

        /// <return>The resource ID of the public IP address associated with this virtual machine's primary network interface.</return>
        string GetPrimaryPublicIPAddressId();

        /// <summary>
        /// Gets the storage account type of the managed disk backing Os disk.
        /// </summary>
        Models.StorageAccountTypes? OsDiskStorageAccountType { get; }

        /// <return>An observable that emits extensions attached to the virtual machine.</return>
        Task<IReadOnlyList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension>> GetExtensionsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The extensions attached to the Virtual Machine.</return>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension> GetExtensions();

        /// <summary>
        /// Gets the public IP address associated with this virtual machine's primary network interface.
        /// note that this method makes a rest API call to fetch the resource.
        /// </summary>
        /// <return>The public IP of the primary network interface.</return>
        Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress GetPrimaryPublicIPAddress();

        /// <summary>
        /// Gets the virtual machine size.
        /// </summary>
        Models.VirtualMachineSizeTypes Size { get; }

        /// <summary>
        /// Gets Returns the storage profile of an Azure virtual machine.
        /// The storage profile contains information such as the details of the VM image or user image
        /// from which this virtual machine is created, the Azure storage account where the operating system
        /// disk is stored, details of the data disk attached to the virtual machine.
        /// </summary>
        /// <summary>
        /// Gets the storageProfile value.
        /// </summary>
        Models.StorageProfile StorageProfile { get; }

        /// <summary>
        /// Gets the managed data disks associated with this virtual machine, indexed by lun.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<int,Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk> DataDisks { get; }

        /// <summary>
        /// Gets Returns id to the availability set this virtual machine associated with.
        /// Having a set of virtual machines in an availability set ensures that during maintenance
        /// event at least one virtual machine will be available.
        /// </summary>
        /// <summary>
        /// Gets the availabilitySet reference id.
        /// </summary>
        string AvailabilitySetId { get; }

        /// <summary>
        /// Gets Gets the operating system profile of an Azure virtual machine.
        /// </summary>
        /// <summary>
        /// Gets the osProfile value.
        /// </summary>
        Models.OSProfile OsProfile { get; }
    }
}