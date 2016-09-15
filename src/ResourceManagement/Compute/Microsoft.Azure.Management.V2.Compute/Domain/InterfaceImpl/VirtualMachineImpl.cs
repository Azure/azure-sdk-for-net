/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.V2.Network;
    using Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Rest;
    using Microsoft.Azure.Management.Storage.Models;
    using Microsoft.Azure.Management.V2.Storage;
    using Microsoft.Azure.Management.V2.Resource;
    using System.Threading;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update;
    using Microsoft.Azure.Management.Network.Models;
    public partial class VirtualMachineImpl 
    {
        /// <summary>
        /// Specifies an existing VHD that needs to be attached to the virtual machine as data disk.
        /// </summary>
        /// <param name="storageAccountName">storageAccountName the storage account name</param>
        /// <param name="containerName">containerName the name of the container holding the VHD file</param>
        /// <param name="vhdName">vhdName the name for the VHD file</param>
        /// <returns>the stage representing creatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithDataDisk.WithExistingDataDisk (string storageAccountName, string containerName, string vhdName) {
            return this.WithExistingDataDisk( storageAccountName,  containerName,  vhdName) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies a new blank data disk to be attached to the virtual machine along with it's configuration.
        /// </summary>
        /// <param name="name">name the name for the data disk</param>
        /// <returns>the stage representing configuration for the data disk</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Definition.IAttachNewDataDisk<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithDataDisk.DefineNewDataDisk (string name) {
            return this.DefineNewDataDisk( name) as Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Definition.IAttachNewDataDisk<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies that a new blank data disk needs to be attached to virtual machine.
        /// </summary>
        /// <param name="sizeInGB">sizeInGB the disk size in GB</param>
        /// <returns>the stage representing creatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithDataDisk.WithNewDataDisk (int? sizeInGB) {
            return this.WithNewDataDisk( sizeInGB) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies an existing VHD that needs to be attached to the virtual machine as data disk along with
        /// it's configuration.
        /// </summary>
        /// <param name="name">name the name for the data disk</param>
        /// <returns>the stage representing configuration for the data disk</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Definition.IAttachExistingDataDisk<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithDataDisk.DefineExistingDataDisk (string name) {
            return this.DefineExistingDataDisk( name) as Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Definition.IAttachExistingDataDisk<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies an existing VHD that needs to be attached to the virtual machine as data disk.
        /// </summary>
        /// <param name="storageAccountName">storageAccountName the storage account name</param>
        /// <param name="containerName">containerName the name of the container holding the VHD file</param>
        /// <param name="vhdName">vhdName the name for the VHD file</param>
        /// <returns>the stage representing creatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IWithDataDisk.WithExistingDataDisk (string storageAccountName, string containerName, string vhdName) {
            return this.WithExistingDataDisk( storageAccountName,  containerName,  vhdName) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a new blank data disk to be attached to the virtual machine along with it's configuration.
        /// </summary>
        /// <param name="name">name the name for the data disk</param>
        /// <returns>the stage representing configuration for the data disk</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IAttachNewDataDisk<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate> Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IWithDataDisk.DefineNewDataDisk (string name) {
            return this.DefineNewDataDisk( name) as Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IAttachNewDataDisk<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies that a new blank data disk needs to be attached to virtual machine.
        /// </summary>
        /// <param name="sizeInGB">sizeInGB the disk size in GB</param>
        /// <returns>the stage representing creatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IWithDataDisk.WithNewDataDisk (int? sizeInGB) {
            return this.WithNewDataDisk( sizeInGB) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies an existing VHD that needs to be attached to the virtual machine as data disk along with
        /// it's configuration.
        /// </summary>
        /// <param name="name">name the name for the data disk</param>
        /// <returns>the stage representing configuration for the data disk</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IAttachExistingDataDisk<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate> Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IWithDataDisk.DefineExistingDataDisk (string name) {
            return this.DefineExistingDataDisk( name) as Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IAttachExistingDataDisk<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Detaches a data disk with the given name from the virtual machine.
        /// </summary>
        /// <param name="name">name the name of the data disk to remove</param>
        /// <returns>the stage representing updatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IWithDataDisk.WithoutDataDisk (string name) {
            return this.WithoutDataDisk( name) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Detaches a data disk with the given logical unit number from the virtual machine.
        /// </summary>
        /// <param name="lun">lun the logical unit number of the data disk to remove</param>
        /// <returns>the stage representing updatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IWithDataDisk.WithoutDataDisk (int lun) {
            return this.WithoutDataDisk( lun) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Begins the description of an update of an existing data disk of this virtual machine.
        /// </summary>
        /// <param name="name">name the name of the disk</param>
        /// <returns>the stage representing updating configuration for  data disk</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IWithDataDisk.UpdateDataDisk (string name) {
            return this.UpdateDataDisk( name) as Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IUpdate;
        }

        /// <summary>
        /// Returns id to the availability set this virtual machine associated with.
        /// <p>
        /// Having a set of virtual machines in an availability set ensures that during maintenance
        /// event at least one virtual machine will be available.
        /// </summary>
        /// <returns>the availabilitySet reference id</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachine.AvailabilitySetId
        {
            get
            {
                return this.AvailabilitySetId as string;
            }
        }
        /// <returns>the resources value</returns>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Compute.Models.VirtualMachineExtensionInner> Microsoft.Azure.Management.V2.Compute.IVirtualMachine.Resources
        {
            get
            {
                return this.Resources as System.Collections.Generic.IList<Microsoft.Azure.Management.Compute.Models.VirtualMachineExtensionInner>;
            }
        }
        /// <returns>the operating system disk caching type, valid values are 'None', 'ReadOnly', 'ReadWrite'</returns>
        Microsoft.Azure.Management.Compute.Models.CachingTypes? Microsoft.Azure.Management.V2.Compute.IVirtualMachine.OsDiskCachingType
        {
            get
            {
                return this.OsDiskCachingType;
            }
        }
        /// <summary>
        /// Start the virtual machine.
        /// </summary>
        void Microsoft.Azure.Management.V2.Compute.IVirtualMachine.Start () {
            this.Start();
        }

        /// <returns>the plan value</returns>
        Microsoft.Azure.Management.Compute.Models.Plan Microsoft.Azure.Management.V2.Compute.IVirtualMachine.Plan
        {
            get
            {
                return this.Plan as Microsoft.Azure.Management.Compute.Models.Plan;
            }
        }
        /// <returns>the virtual machine unique id.</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachine.VmId
        {
            get
            {
                return this.VmId as string;
            }
        }
        /// <summary>
        /// List of all available virtual machine sizes this virtual machine can resized to.
        /// </summary>
        /// <returns>the virtual machine sizes</returns>
        Microsoft.Azure.Management.V2.Resource.Core.PagedList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineSize> Microsoft.Azure.Management.V2.Compute.IVirtualMachine.AvailableSizes () {
            return this.AvailableSizes() as Microsoft.Azure.Management.V2.Resource.Core.PagedList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineSize>;
        }

        /// <returns>the operating system of this virtual machine</returns>
        Microsoft.Azure.Management.Compute.Models.OperatingSystemTypes? Microsoft.Azure.Management.V2.Compute.IVirtualMachine.OsType
        {
            get
            {
                return this.OsType;
            }
        }
        /// <summary>
        /// Shuts down the Virtual Machine and releases the compute resources.
        /// <p>
        /// You are not billed for the compute resources that this Virtual Machine uses
        /// </summary>
        void Microsoft.Azure.Management.V2.Compute.IVirtualMachine.Deallocate () {
            this.Deallocate();
        }

        /// <returns>the virtual machine size</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachine.Size
        {
            get
            {
                return this.Size as string;
            }
        }
        /// <summary>
        /// Power off (stop) the virtual machine.
        /// <p>
        /// You will be billed for the compute resources that this Virtual Machine uses.
        /// </summary>
        void Microsoft.Azure.Management.V2.Compute.IVirtualMachine.PowerOff () {
            this.PowerOff();
        }

        /// <summary>
        /// Refreshes the virtual machine instance view to sync with Azure.
        /// <p>
        /// this will caches the instance view which can be later retrieved using {@link VirtualMachine#instanceView()}.
        /// </summary>
        /// <returns>the refreshed instance view</returns>
        Microsoft.Azure.Management.Compute.Models.VirtualMachineInstanceView Microsoft.Azure.Management.V2.Compute.IVirtualMachine.RefreshInstanceView()
        {
            return this.RefreshInstanceView() as Microsoft.Azure.Management.Compute.Models.VirtualMachineInstanceView;
        }

        /// <returns>the provisioningState value</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachine.ProvisioningState
        {
            get
            {
                return this.ProvisioningState as string;
            }
        }
        /// <returns>the uri to the vhd file backing this virtual machine's operating system disk</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachine.OsDiskVhdUri
        {
            get
            {
                return this.OsDiskVhdUri as string;
            }
        }
        /// <returns>the power state of the virtual machine</returns>
        Microsoft.Azure.Management.V2.Compute.PowerState? Microsoft.Azure.Management.V2.Compute.IVirtualMachine.PowerState
        {
            get
            {
                return this.PowerState;
            }
        }
        /// <returns>name of this virtual machine</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachine.ComputerName
        {
            get
            {
                return this.ComputerName as string;
            }
        }
        /// <summary>
        /// Gets the operating system profile of an Azure virtual machine.
        /// </summary>
        /// <returns>the osProfile value</returns>
        Microsoft.Azure.Management.Compute.Models.OSProfile Microsoft.Azure.Management.V2.Compute.IVirtualMachine.OsProfile
        {
            get
            {
                return this.OsProfile as Microsoft.Azure.Management.Compute.Models.OSProfile;
            }
        }
        /// <summary>
        /// Restart the virtual machine.
        /// </summary>
        void Microsoft.Azure.Management.V2.Compute.IVirtualMachine.Restart () {
            this.Restart();
        }

        /// <summary>
        /// Returns the diagnostics profile of an Azure virtual machine.
        /// <p>
        /// Enabling diagnostic features in a virtual machine enable you to easily diagnose and recover
        /// virtual machine from boot failures.
        /// </summary>
        /// <returns>the diagnosticsProfile value</returns>
        Microsoft.Azure.Management.Compute.Models.DiagnosticsProfile Microsoft.Azure.Management.V2.Compute.IVirtualMachine.DiagnosticsProfile
        {
            get
            {
                return this.DiagnosticsProfile as Microsoft.Azure.Management.Compute.Models.DiagnosticsProfile;
            }
        }
        /// <summary>
        /// Redeploy the virtual machine.
        /// </summary>
        void Microsoft.Azure.Management.V2.Compute.IVirtualMachine.Redeploy () {
            this.Redeploy();
        }

        /// <summary>
        /// Captures the virtual machine by copying virtual hard disks of the VM and returns template as json
        /// string that can be used to create similar VMs.
        /// </summary>
        /// <param name="containerName">containerName destination container name to store the captured Vhd</param>
        /// <param name="overwriteVhd">overwriteVhd whether to overwrites destination vhd if it exists</param>
        /// <returns>the template as json string</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachine.Capture (string containerName, bool overwriteVhd) {
            return this.Capture( containerName,  overwriteVhd) as string;
        }

        /// <returns>the licenseType value</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachine.LicenseType
        {
            get
            {
                return this.LicenseType as string;
            }
        }
        /// <summary>
        /// Get the virtual machine instance view.
        /// <p>
        /// this method returns the cached instance view, to refresh the cache call {@link VirtualMachine#refreshInstanceView()}.
        /// </summary>
        /// <returns>the virtual machine instance view</returns>
        Microsoft.Azure.Management.Compute.Models.VirtualMachineInstanceView Microsoft.Azure.Management.V2.Compute.IVirtualMachine.InstanceView
        {
            get
            {
                return this.InstanceView as Microsoft.Azure.Management.Compute.Models.VirtualMachineInstanceView;
            }
        }
        /// <summary>
        /// Gets the public IP address associated with this virtual machine's primary network interface.
        /// <p>
        /// note that this method makes a rest API call to fetch the resource.
        /// </summary>
        /// <returns>the public IP of the primary network interface</returns>
        Microsoft.Azure.Management.V2.Network.IPublicIpAddress Microsoft.Azure.Management.V2.Compute.IVirtualMachine.PrimaryPublicIpAddress () {
            return this.PrimaryPublicIpAddress() as Microsoft.Azure.Management.V2.Network.IPublicIpAddress;
        }

        /// <summary>
        /// Returns the storage profile of an Azure virtual machine.
        /// <p>
        /// The storage profile contains information such as the details of the VM image or user image
        /// from which this virtual machine is created, the Azure storage account where the operating system
        /// disk is stored, details of the data disk attached to the virtual machine.
        /// </summary>
        /// <returns>the storageProfile value</returns>
        Microsoft.Azure.Management.Compute.Models.StorageProfile Microsoft.Azure.Management.V2.Compute.IVirtualMachine.StorageProfile
        {
            get
            {
                return this.StorageProfile as Microsoft.Azure.Management.Compute.Models.StorageProfile;
            }
        }
        /// <summary>
        /// Generalize the Virtual Machine.
        /// </summary>
        void Microsoft.Azure.Management.V2.Compute.IVirtualMachine.Generalize () {
            this.Generalize();
        }

        /// <returns>the size of the operating system disk in GB</returns>
        int? Microsoft.Azure.Management.V2.Compute.IVirtualMachine.OsDiskSize
        {
            get
            {
                return this.OsDiskSize;
            }
        }
        /// <returns>the list of data disks attached to this virtual machine</returns>
        System.Collections.Generic.IList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineDataDisk> Microsoft.Azure.Management.V2.Compute.IVirtualMachine.DataDisks () {
            return this.DataDisks() as System.Collections.Generic.IList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineDataDisk>;
        }

        /// <summary>
        /// Associate an existing network interface with the virtual machine.
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="networkInterface">networkInterface an existing network interface</param>
        /// <returns>the stage representing creatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithSecondaryNetworkInterface.WithExistingSecondaryNetworkInterface (INetworkInterface networkInterface) {
            return this.WithExistingSecondaryNetworkInterface( networkInterface) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Create a new network interface to associate with the virtual machine, based on the
        /// provided definition.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new network interface</param>
        /// <returns>the stage representing creatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithSecondaryNetworkInterface.WithNewSecondaryNetworkInterface (ICreatable<INetworkInterface> creatable) {
            return this.WithNewSecondaryNetworkInterface( creatable) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Removes a network interface associated with virtual machine.
        /// </summary>
        /// <param name="name">name the name of the secondary network interface to remove</param>
        /// <returns>the stage representing updatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IWithSecondaryNetworkInterface.WithoutSecondaryNetworkInterface (string name) {
            return this.WithoutSecondaryNetworkInterface( name) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Associate an existing network interface with the virtual machine.
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="networkInterface">networkInterface an existing network interface</param>
        /// <returns>the stage representing creatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IWithSecondaryNetworkInterface.WithExistingSecondaryNetworkInterface (INetworkInterface networkInterface) {
            return this.WithExistingSecondaryNetworkInterface( networkInterface) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Create a new network interface to associate with the virtual machine, based on the
        /// provided definition.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new network interface</param>
        /// <returns>the stage representing creatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IWithSecondaryNetworkInterface.WithNewSecondaryNetworkInterface (ICreatable<INetworkInterface> creatable) {
            return this.WithNewSecondaryNetworkInterface( creatable) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <returns>the refreshed resource</returns>
        Microsoft.Azure.Management.V2.Compute.IVirtualMachine Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.V2.Compute.IVirtualMachine>.Refresh () {
            return this.Refresh() as Microsoft.Azure.Management.V2.Compute.IVirtualMachine;
        }

        /// <summary>
        /// Specifies the root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">rootUserName the Linux root user name. This must follow the required naming convention for Linux user name</param>
        /// <returns>the next stage of the Linux virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithLinuxCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithRootUserName.WithRootUserName (string rootUserName) {
            return this.WithRootUserName( rootUserName) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithLinuxCreate;
        }

        /// <summary>
        /// Specifies that no public IP needs to be associated with virtual machine.
        /// </summary>
        /// <returns>the next stage of the virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOS Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithPublicIpAddress.WithoutPrimaryPublicIpAddress () {
            return this.WithoutPrimaryPublicIpAddress() as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Create a new public IP address to associate with virtual machine primary network interface, based on the
        /// provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new public IP</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOS Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithPublicIpAddress.WithNewPrimaryPublicIpAddress (ICreatable<IPublicIpAddress> creatable) {
            return this.WithNewPrimaryPublicIpAddress( creatable) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associate it with the virtual machine's primary network interface.
        /// <p>
        /// the internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">leafDnsLabel the leaf domain label</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOS Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithPublicIpAddress.WithNewPrimaryPublicIpAddress (string leafDnsLabel) {
            return this.WithNewPrimaryPublicIpAddress( leafDnsLabel) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Associates an existing public IP address with the virtual machine's primary network interface.
        /// </summary>
        /// <param name="publicIpAddress">publicIpAddress an existing public IP address</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOS Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithPublicIpAddress.WithExistingPrimaryPublicIpAddress (IPublicIpAddress publicIpAddress) {
            return this.WithExistingPrimaryPublicIpAddress( publicIpAddress) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Specifies the SSH public key.
        /// <p>
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">publicKey the SSH public key in PEM format.</param>
        /// <returns>the stage representing creatable Linux VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithLinuxCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithLinuxCreate.WithSsh (string publicKey) {
            return this.WithSsh( publicKey) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithLinuxCreate;
        }

        /// <summary>
        /// Specifies the password for the virtual machine.
        /// </summary>
        /// <param name="password">password the password. This must follow the criteria for Azure VM password.</param>
        /// <returns>the stage representing creatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithPassword.WithPassword (string password) {
            return this.WithPassword( password) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">adminUserName the Windows administrator user name. This must follow the required naming convention for Windows user name.</param>
        /// <returns>the stage representing creatable Linux VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithWindowsCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithAdminUserName.WithAdminUserName (string adminUserName) {
            return this.WithAdminUserName( adminUserName) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Create a new virtual network to associate with the virtual machine's primary network interface, based on
        /// the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new virtual network</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithPrivateIp Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithNetwork.WithNewPrimaryNetwork (ICreatable<INetwork> creatable) {
            return this.WithNewPrimaryNetwork( creatable) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithPrivateIp;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the virtual machine's primary network interface.
        /// <p>
        /// the virtual network will be created in the same resource group and region as of virtual machine, it will be
        /// created with the specified address space and a default subnet covering the entirety of the network IP address space.
        /// </summary>
        /// <param name="addressSpace">addressSpace the address space for the virtual network</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithPrivateIp Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithNetwork.WithNewPrimaryNetwork (string addressSpace) {
            return this.WithNewPrimaryNetwork( addressSpace) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithPrivateIp;
        }

        /// <summary>
        /// Associate an existing virtual network with the the virtual machine's primary network interface.
        /// </summary>
        /// <param name="network">network an existing virtual network</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithSubnet Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithNetwork.WithExistingPrimaryNetwork (INetwork network) {
            return this.WithExistingPrimaryNetwork( network) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithSubnet;
        }

        /// <summary>
        /// Specifies definition of a not-yet-created storage account definition
        /// to put the VM's OS and data disk VHDs in.
        /// <p>
        /// Only the OS disk based on marketplace image will be stored in the new storage account.
        /// An OS disk based on user image will be stored in the same storage account as user image.
        /// </summary>
        /// <param name="creatable">creatable the storage account in creatable stage</param>
        /// <returns>the stage representing creatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithStorageAccount.WithNewStorageAccount (ICreatable<IStorageAccount> creatable) {
            return this.WithNewStorageAccount( creatable) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the name of a new storage account to put the VM's OS and data disk VHD in.
        /// <p>
        /// Only the OS disk based on marketplace image will be stored in the new storage account,
        /// an OS disk based on user image will be stored in the same storage account as user image.
        /// </summary>
        /// <param name="name">name the name of the storage account</param>
        /// <returns>the stage representing creatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithStorageAccount.WithNewStorageAccount (string name) {
            return this.WithNewStorageAccount( name) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies an existing {@link StorageAccount} storage account to put the VM's OS and data disk VHD in.
        /// <p>
        /// An OS disk based on marketplace or user image (generalized image) will be stored in this
        /// storage account.
        /// </summary>
        /// <param name="storageAccount">storageAccount an existing storage account</param>
        /// <returns>the stage representing creatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithStorageAccount.WithExistingStorageAccount (IStorageAccount storageAccount) {
            return this.WithExistingStorageAccount( storageAccount) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network subnet to the
        /// virtual machine's primary network interface.
        /// </summary>
        /// <param name="staticPrivateIpAddress">staticPrivateIpAddress the static IP address within the specified subnet to assign to</param>
        /// <param name="the">the network interface</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithPublicIpAddress Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithPrivateIp.WithPrimaryPrivateIpAddressStatic (string staticPrivateIpAddress) {
            return this.WithPrimaryPrivateIpAddressStatic( staticPrivateIpAddress) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithPublicIpAddress;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network subnet for
        /// virtual machine's primary network interface.
        /// </summary>
        /// <returns>the next stage of the virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithPublicIpAddress Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithPrivateIp.WithPrimaryPrivateIpAddressDynamic () {
            return this.WithPrimaryPrivateIpAddressDynamic() as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithPublicIpAddress;
        }

        /// <summary>
        /// Specifies that the latest version of a marketplace Linux image needs to be used.
        /// </summary>
        /// <param name="publisher">publisher specifies the publisher of the image</param>
        /// <param name="offer">offer specifies the offer of the image</param>
        /// <param name="sku">sku specifies the SKU of the image</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithRootUserName Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOS.WithLatestLinuxImage (string publisher, string offer, string sku) {
            return this.WithLatestLinuxImage( publisher,  offer,  sku) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithRootUserName;
        }

        /// <summary>
        /// Specifies the user (generalized) Linux image used for the virtual machine's OS.
        /// </summary>
        /// <param name="imageUrl">imageUrl the url the the VHD</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithRootUserName Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOS.WithStoredLinuxImage (string imageUrl) {
            return this.WithStoredLinuxImage( imageUrl) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithRootUserName;
        }

        /// <summary>
        /// Specifies the version of a market-place Linux image needs to be used.
        /// </summary>
        /// <param name="imageReference">imageReference describes publisher, offer, sku and version of the market-place image</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithRootUserName Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOS.WithSpecificLinuxImageVersion (ImageReference imageReference) {
            return this.WithSpecificLinuxImageVersion( imageReference) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithRootUserName;
        }

        /// <summary>
        /// Specifies that the latest version of a marketplace Windows image needs to be used.
        /// </summary>
        /// <param name="publisher">publisher specifies the publisher of the image</param>
        /// <param name="offer">offer specifies the offer of the image</param>
        /// <param name="sku">sku specifies the SKU of the image</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithAdminUserName Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOS.WithLatestWindowsImage (string publisher, string offer, string sku) {
            return this.WithLatestWindowsImage( publisher,  offer,  sku) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithAdminUserName;
        }

        /// <summary>
        /// Specifies the known marketplace Windows image used for the virtual machine's OS.
        /// </summary>
        /// <param name="knownImage">knownImage enum value indicating known market-place image</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithAdminUserName Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOS.WithPopularWindowsImage (KnownWindowsVirtualMachineImage knownImage) {
            return this.WithPopularWindowsImage( knownImage) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithAdminUserName;
        }

        /// <summary>
        /// Specifies the specialized operating system disk to be attached to the virtual machine.
        /// </summary>
        /// <param name="osDiskUrl">osDiskUrl osDiskUrl the url to the OS disk in the Azure Storage account</param>
        /// <param name="osType">osType the OS type</param>
        /// <returns>the next stage of the Windows virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOS.WithOsDisk (string osDiskUrl, OperatingSystemTypes osType) {
            return this.WithOsDisk( osDiskUrl,  osType) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the known marketplace Linux image used for the virtual machine's OS.
        /// </summary>
        /// <param name="knownImage">knownImage enum value indicating known market-place image</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithRootUserName Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOS.WithPopularLinuxImage (KnownLinuxVirtualMachineImage knownImage) {
            return this.WithPopularLinuxImage( knownImage) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithRootUserName;
        }

        /// <summary>
        /// Specifies the version of a marketplace Windows image needs to be used.
        /// </summary>
        /// <param name="imageReference">imageReference describes publisher, offer, sku and version of the market-place image</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithAdminUserName Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOS.WithSpecificWindowsImageVersion (ImageReference imageReference) {
            return this.WithSpecificWindowsImageVersion( imageReference) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithAdminUserName;
        }

        /// <summary>
        /// Specifies the user (generalized) Windows image used for the virtual machine's OS.
        /// </summary>
        /// <param name="imageUrl">imageUrl the url the the VHD</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithAdminUserName Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOS.WithStoredWindowsImage (string imageUrl) {
            return this.WithStoredWindowsImage( imageUrl) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithAdminUserName;
        }

        /// <summary>
        /// Specifies the size of the OSDisk in GB.
        /// </summary>
        /// <param name="size">size the VHD size.</param>
        /// <returns>the stage representing updatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate.WithOsDiskSizeInGb (int? size) {
            return this.WithOsDiskSizeInGb( size) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the caching type for the Operating System disk.
        /// </summary>
        /// <param name="cachingType">cachingType the caching type.</param>
        /// <returns>the stage representing updatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate.WithOsDiskCaching (CachingTypes cachingType) {
            return this.WithOsDiskCaching( cachingType) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the new size for the virtual machine.
        /// </summary>
        /// <param name="sizeName">sizeName the name of the size for the virtual machine as text</param>
        /// <returns>the stage representing updatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate.WithSize (string sizeName) {
            return this.WithSize( sizeName) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the WINRM listener.
        /// <p>
        /// Each call to this method adds the given listener to the list of VM's WinRM listeners.
        /// </summary>
        /// <param name="listener">listener the WinRmListener</param>
        /// <returns>the stage representing creatable Windows VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithWindowsCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithWindowsCreate.WithWinRm (WinRMListener listener) {
            return this.WithWinRm( listener) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Specifies that automatic updates should be disabled.
        /// </summary>
        /// <returns>the stage representing creatable Windows VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithWindowsCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithWindowsCreate.DisableAutoUpdate()
        {
                return this.DisableAutoUpdate() as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithWindowsCreate;
        }
        /// <summary>
        /// Specifies that VM Agent should not be provisioned.
        /// </summary>
        /// <returns>the stage representing creatable Windows VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithWindowsCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithWindowsCreate.DisableVmAgent()
        {
                return this.DisableVmAgent() as IWithWindowsCreate;
        }
        /// <summary>
        /// Specifies the time-zone.
        /// </summary>
        /// <param name="timeZone">timeZone the timezone</param>
        /// <returns>the stage representing creatable Windows VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithWindowsCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithWindowsCreate.WithTimeZone (string timeZone) {
            return this.WithTimeZone( timeZone) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Associate a subnet with the virtual machine primary network interface.
        /// </summary>
        /// <param name="name">name the subnet name</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithPrivateIp Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithSubnet.WithSubnet (string name) {
            return this.WithSubnet( name) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithPrivateIp;
        }

        /// <summary>
        /// Execute the update request asynchronously.
        /// </summary>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        /// <returns>the handle to the REST call</returns>
        async Task<IVirtualMachine> Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.V2.Compute.IVirtualMachine>.ApplyAsync (CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true) {
            return await this.ApplyAsync() as IVirtualMachine;
        }

        /// <summary>
        /// Execute the update request.
        /// </summary>
        /// <returns>the updated resource</returns>
        Microsoft.Azure.Management.V2.Compute.IVirtualMachine Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.V2.Compute.IVirtualMachine>.Apply () {
            return this.Apply() as Microsoft.Azure.Management.V2.Compute.IVirtualMachine;
        }

        /// <summary>
        /// Specifies the size of the OSDisk in GB.
        /// </summary>
        /// <param name="size">size the VHD size.</param>
        /// <returns>the stage representing creatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOsDiskSettings.WithOsDiskSizeInGb (int? size) {
            return this.WithOsDiskSizeInGb( size) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the name for the OS Disk.
        /// </summary>
        /// <param name="name">name the OS Disk name.</param>
        /// <returns>the stage representing creatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOsDiskSettings.WithOsDiskName (string name) {
            return this.WithOsDiskName( name) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the name of the OS Disk Vhd file and it's parent container.
        /// </summary>
        /// <param name="containerName">containerName the name of the container in the selected storage account.</param>
        /// <param name="vhdName">vhdName the name for the OS Disk vhd.</param>
        /// <returns>the stage representing creatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOsDiskSettings.WithOsDiskVhdLocation (string containerName, string vhdName) {
            return this.WithOsDiskVhdLocation( containerName,  vhdName) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the caching type for the Operating System disk.
        /// </summary>
        /// <param name="cachingType">cachingType the caching type.</param>
        /// <returns>the stage representing creatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOsDiskSettings.WithOsDiskCaching (CachingTypes cachingType) {
            return this.WithOsDiskCaching( cachingType) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the encryption settings for the OS Disk.
        /// </summary>
        /// <param name="settings">settings the encryption settings.</param>
        /// <returns>the stage representing creatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOsDiskSettings.WithOsDiskEncryptionSettings (DiskEncryptionSettings settings) {
            return this.WithOsDiskEncryptionSettings( settings) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the virtual machine size.
        /// </summary>
        /// <param name="sizeName">sizeName the name of the size for the virtual machine as text</param>
        /// <returns>the stage representing creatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithVMSize.WithSize (string sizeName) {
            return this.WithSize( sizeName) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate;
        }

        /// <returns>the resource id of the primary network interface associated with this resource</returns>
        string Microsoft.Azure.Management.V2.Network.ISupportsNetworkInterfaces.PrimaryNetworkInterfaceId
        {
            get
            {
                return this.PrimaryNetworkInterfaceId as string;
            }
        }
        /// <returns>the list of resource IDs of the network interfaces associated with this resource</returns>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.V2.Network.ISupportsNetworkInterfaces.NetworkInterfaceIds
        {
            get
            {
                return this.NetworkInterfaceIds as System.Collections.Generic.IList<string>;
            }
        }
        /// <summary>
        /// Gets the primary network interface.
        /// <p>
        /// Note that this method can result in a call to the cloud to fetch the network interface information.
        /// </summary>
        /// <returns>the primary network interface associated with this resource</returns>
        Microsoft.Azure.Management.V2.Network.INetworkInterface Microsoft.Azure.Management.V2.Network.ISupportsNetworkInterfaces.PrimaryNetworkInterface () {
            return this.PrimaryNetworkInterface() as Microsoft.Azure.Management.V2.Network.INetworkInterface;
        }

        /// <summary>
        /// Create a new network interface to associate the virtual machine with as it's primary network interface,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new network interface</param>
        /// <returns>The next stage of the virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOS Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithPrimaryNetworkInterface.WithNewPrimaryNetworkInterface (ICreatable<INetworkInterface> creatable) {
            return this.WithNewPrimaryNetworkInterface( creatable) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Associate an existing network interface as the virtual machine with as it's primary network interface.
        /// </summary>
        /// <param name="networkInterface">networkInterface an existing network interface</param>
        /// <returns>The next stage of the virtual machine definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOS Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithPrimaryNetworkInterface.WithExistingPrimaryNetworkInterface (INetworkInterface networkInterface) {
            return this.WithExistingPrimaryNetworkInterface( networkInterface) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Specifies an existing {@link AvailabilitySet} availability set to to associate the virtual machine with.
        /// <p>
        /// Adding virtual machines running your application to an availability set ensures that during
        /// maintenance event at least one virtual machine will be available.
        /// </summary>
        /// <param name="availabilitySet">availabilitySet an existing availability set</param>
        /// <returns>the stage representing creatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithAvailabilitySet.WithExistingAvailabilitySet (IAvailabilitySet availabilitySet) {
            return this.WithExistingAvailabilitySet( availabilitySet) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies definition of a not-yet-created availability set definition
        /// to associate the virtual machine with.
        /// <p>
        /// Adding virtual machines running your application to an availability set ensures that during
        /// maintenance event at least one virtual machine will be available.
        /// </summary>
        /// <param name="creatable">creatable the availability set in creatable stage</param>
        /// <returns>the stage representing creatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithAvailabilitySet.WithNewAvailabilitySet (ICreatable<IAvailabilitySet> creatable) {
            return this.WithNewAvailabilitySet( creatable) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the name of a new availability set to associate the virtual machine with.
        /// <p>
        /// Adding virtual machines running your application to an availability set ensures that during
        /// maintenance event at least one virtual machine will be available.
        /// </summary>
        /// <param name="name">name the name of the availability set</param>
        /// <returns>the stage representing creatable VM definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithAvailabilitySet.WithNewAvailabilitySet (string name) {
            return this.WithNewAvailabilitySet( name) as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate;
        }

    }
}