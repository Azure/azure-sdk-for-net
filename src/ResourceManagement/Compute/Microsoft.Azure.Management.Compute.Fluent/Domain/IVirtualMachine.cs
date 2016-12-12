// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Network.Fluent;
    using VirtualMachine.Update;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine.
    /// </summary>
    public interface IVirtualMachine :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>,
        IWrapper<Models.VirtualMachineInner>,
        IUpdatable<VirtualMachine.Update.IUpdate>,
        IHasNetworkInterfaces
    {
        /// <return>The virtual machine unique id.</return>
        string VmId { get; }

        /// <summary>
        /// Power off (stop) the virtual machine.
        /// <p>
        /// You will be billed for the compute resources that this Virtual Machine uses.
        /// </summary>
        void PowerOff();

        /// <summary>
        /// Shuts down the Virtual Machine and releases the compute resources.
        /// <p>
        /// You are not billed for the compute resources that this Virtual Machine uses.
        /// </summary>
        void Deallocate();

        /// <summary>
        /// Refreshes the virtual machine instance view to sync with Azure.
        /// <p>
        /// this will caches the instance view which can be later retrieved using VirtualMachine.instanceView().
        /// </summary>
        /// <return>The refreshed instance view.</return>
        Models.VirtualMachineInstanceView RefreshInstanceView();

        /// <return>The licenseType value.</return>
        string LicenseType { get; }

        /// <summary>
        /// Get the virtual machine instance view.
        /// <p>
        /// this method returns the cached instance view, to refresh the cache call VirtualMachine.refreshInstanceView().
        /// </summary>
        /// <return>The virtual machine instance view.</return>
        Models.VirtualMachineInstanceView InstanceView { get; }

        /// <return>The power state of the virtual machine.</return>
        Microsoft.Azure.Management.Compute.Fluent.PowerState PowerState { get; }

        /// <return>Name of this virtual machine.</return>
        string ComputerName { get; }

        /// <return>The operating system of this virtual machine.</return>
        Models.OperatingSystemTypes OsType { get; }

        /// <return>The operating system disk caching type, valid values are 'None', 'ReadOnly', 'ReadWrite'.</return>
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
        /// Returns the diagnostics profile of an Azure virtual machine.
        /// <p>
        /// Enabling diagnostic features in a virtual machine enable you to easily diagnose and recover
        /// virtual machine from boot failures.
        /// </summary>
        /// <return>The diagnosticsProfile value.</return>
        Models.DiagnosticsProfile DiagnosticsProfile { get; }

        /// <return>The plan value.</return>
        Models.Plan Plan { get; }

        /// <return>The size of the operating system disk in GB.</return>
        int OsDiskSize { get; }

        /// <summary>
        /// Restart the virtual machine.
        /// =.
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

        /// <return>The provisioningState value.</return>
        string ProvisioningState { get; }

        /// <summary>
        /// List of all available virtual machine sizes this virtual machine can resized to.
        /// </summary>
        /// <return>The virtual machine sizes.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize> AvailableSizes();

        /// <return>The resource ID of the public IP address associated with this virtual machine's primary network interface.</return>
        string GetPrimaryPublicIpAddressId();

        /// <return>The extensions attached to the Azure Virtual Machine.</return>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension> Extensions { get; }

        /// <summary>
        /// Gets the public IP address associated with this virtual machine's primary network interface.
        /// <p>
        /// note that this method makes a rest API call to fetch the resource.
        /// </summary>
        /// <return>The public IP of the primary network interface.</return>
        Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress GetPrimaryPublicIpAddress();

        /// <return>The virtual machine size.</return>
        Models.VirtualMachineSizeTypes Size { get; }

        /// <summary>
        /// Returns the storage profile of an Azure virtual machine.
        /// <p>
        /// The storage profile contains information such as the details of the VM image or user image
        /// from which this virtual machine is created, the Azure storage account where the operating system
        /// disk is stored, details of the data disk attached to the virtual machine.
        /// </summary>
        /// <return>The storageProfile value.</return>
        Models.StorageProfile StorageProfile { get; }

        /// <return>The uri to the vhd file backing this virtual machine's operating system disk.</return>
        string OsDiskVhdUri { get; }

        /// <return>The list of data disks attached to this virtual machine.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk> DataDisks { get; }

        /// <summary>
        /// Returns id to the availability set this virtual machine associated with.
        /// <p>
        /// Having a set of virtual machines in an availability set ensures that during maintenance
        /// event at least one virtual machine will be available.
        /// </summary>
        /// <return>The availabilitySet reference id.</return>
        string AvailabilitySetId { get; }

        /// <summary>
        /// Gets the operating system profile of an Azure virtual machine.
        /// </summary>
        /// <return>The osProfile value.</return>
        Models.OSProfile OsProfile { get; }
    }
}