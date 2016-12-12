// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using VirtualMachine.Definition;
    using Microsoft.Azure.Management.Storage.Fluent;
    using VirtualMachine.Update;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System.Threading;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition;
    using Microsoft.Azure.Management.Resource.Fluent;
    using Microsoft.Azure.Management.Network.Fluent.Models;

    internal partial class VirtualMachineImpl
    {
        /// <summary>
        /// Specifies an existing VHD that needs to be attached to the virtual machine as data disk.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="containerName">The name of the container holding the VHD file.</param>
        /// <param name="vhdName">The name for the VHD file.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithDataDisk.WithExistingDataDisk(string storageAccountName, string containerName, string vhdName)
        {
            return this.WithExistingDataDisk(storageAccountName, containerName, vhdName) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies a new blank data disk to be attached to the virtual machine along with it's configuration.
        /// </summary>
        /// <param name="name">The name for the data disk.</param>
        /// <return>The stage representing configuration for the data disk.</return>
        VirtualMachineDataDisk.Definition.IAttachNewDataDisk<VirtualMachine.Definition.IWithCreate> VirtualMachine.Definition.IWithDataDisk.DefineNewDataDisk(string name)
        {
            return this.DefineNewDataDisk(name) as VirtualMachineDataDisk.Definition.IAttachNewDataDisk<VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies that a new blank data disk needs to be attached to virtual machine.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithDataDisk.WithNewDataDisk(int sizeInGB)
        {
            return this.WithNewDataDisk(sizeInGB) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies an existing VHD that needs to be attached to the virtual machine as data disk along with
        /// it's configuration.
        /// </summary>
        /// <param name="name">The name for the data disk.</param>
        /// <return>The stage representing configuration for the data disk.</return>
        VirtualMachineDataDisk.Definition.IAttachExistingDataDisk<VirtualMachine.Definition.IWithCreate> VirtualMachine.Definition.IWithDataDisk.DefineExistingDataDisk(string name)
        {
            return this.DefineExistingDataDisk(name) as VirtualMachineDataDisk.Definition.IAttachExistingDataDisk<VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies an existing VHD that needs to be attached to the virtual machine as data disk.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="containerName">The name of the container holding the VHD file.</param>
        /// <param name="vhdName">The name for the VHD file.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithDataDisk.WithExistingDataDisk(string storageAccountName, string containerName, string vhdName)
        {
            return this.WithExistingDataDisk(storageAccountName, containerName, vhdName) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a new blank data disk to be attached to the virtual machine along with it's configuration.
        /// </summary>
        /// <param name="name">The name for the data disk.</param>
        /// <return>The stage representing configuration for the data disk.</return>
        VirtualMachineDataDisk.UpdateDefinition.IAttachNewDataDisk<VirtualMachine.Update.IUpdate> VirtualMachine.Update.IWithDataDisk.DefineNewDataDisk(string name)
        {
            return this.DefineNewDataDisk(name) as VirtualMachineDataDisk.UpdateDefinition.IAttachNewDataDisk<VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies that a new blank data disk needs to be attached to virtual machine.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithDataDisk.WithNewDataDisk(int sizeInGB)
        {
            return this.WithNewDataDisk(sizeInGB) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies an existing VHD that needs to be attached to the virtual machine as data disk along with
        /// it's configuration.
        /// </summary>
        /// <param name="name">The name for the data disk.</param>
        /// <return>The stage representing configuration for the data disk.</return>
        VirtualMachineDataDisk.UpdateDefinition.IAttachExistingDataDisk<VirtualMachine.Update.IUpdate> VirtualMachine.Update.IWithDataDisk.DefineExistingDataDisk(string name)
        {
            return this.DefineExistingDataDisk(name) as VirtualMachineDataDisk.UpdateDefinition.IAttachExistingDataDisk<VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Detaches a data disk with the given name from the virtual machine.
        /// </summary>
        /// <param name="name">The name of the data disk to remove.</param>
        /// <return>The stage representing updatable VM definition.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithDataDisk.WithoutDataDisk(string name)
        {
            return this.WithoutDataDisk(name) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Detaches a data disk with the given logical unit number from the virtual machine.
        /// </summary>
        /// <param name="lun">The logical unit number of the data disk to remove.</param>
        /// <return>The stage representing updatable VM definition.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithDataDisk.WithoutDataDisk(int lun)
        {
            return this.WithoutDataDisk(lun) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Begins the description of an update of an existing data disk of this virtual machine.
        /// </summary>
        /// <param name="name">The name of the disk.</param>
        /// <return>The stage representing updating configuration for  data disk.</return>
        VirtualMachineDataDisk.Update.IUpdate VirtualMachine.Update.IWithDataDisk.UpdateDataDisk(string name)
        {
            return this.UpdateDataDisk(name) as VirtualMachineDataDisk.Update.IUpdate;
        }

        /// <return>The extensions attached to the Azure Virtual Machine.</return>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.Extensions
        {
            get
            {
                return this.Extensions() as System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension>;
            }
        }

        /// <summary>
        /// Returns id to the availability set this virtual machine associated with.
        /// <p>
        /// Having a set of virtual machines in an availability set ensures that during maintenance
        /// event at least one virtual machine will be available.
        /// </summary>
        /// <return>The availabilitySet reference id.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.AvailabilitySetId
        {
            get
            {
                return this.AvailabilitySetId() as string;
            }
        }

        /// <return>The operating system disk caching type, valid values are 'None', 'ReadOnly', 'ReadWrite'.</return>
        Models.CachingTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.OsDiskCachingType
        {
            get
            {
                return this.OsDiskCachingType();
            }
        }

        /// <summary>
        /// Start the virtual machine.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.Start()
        {

            this.Start();
        }

        /// <return>The plan value.</return>
        Models.Plan Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.Plan
        {
            get
            {
                return this.Plan() as Models.Plan;
            }
        }

        /// <return>The virtual machine unique id.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.VmId
        {
            get
            {
                return this.VmId() as string;
            }
        }

        /// <summary>
        /// List of all available virtual machine sizes this virtual machine can resized to.
        /// </summary>
        /// <return>The virtual machine sizes.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.AvailableSizes()
        {
            return this.AvailableSizes() as Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize>;
        }

        /// <return>The operating system of this virtual machine.</return>
        Models.OperatingSystemTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.OsType
        {
            get
            {
                return this.OsType();
            }
        }

        /// <summary>
        /// Shuts down the Virtual Machine and releases the compute resources.
        /// <p>
        /// You are not billed for the compute resources that this Virtual Machine uses.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.Deallocate()
        {

            this.Deallocate();
        }

        /// <return>The virtual machine size.</return>
        Models.VirtualMachineSizeTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.Size
        {
            get
            {
                return this.Size() as Models.VirtualMachineSizeTypes;
            }
        }

        /// <summary>
        /// Power off (stop) the virtual machine.
        /// <p>
        /// You will be billed for the compute resources that this Virtual Machine uses.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.PowerOff()
        {

            this.PowerOff();
        }

        /// <summary>
        /// Refreshes the virtual machine instance view to sync with Azure.
        /// <p>
        /// this will caches the instance view which can be later retrieved using VirtualMachine.instanceView().
        /// </summary>
        /// <return>The refreshed instance view.</return>
        Models.VirtualMachineInstanceView Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.RefreshInstanceView()
        {
            return this.RefreshInstanceView() as Models.VirtualMachineInstanceView;
        }

        /// <return>The provisioningState value.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.ProvisioningState
        {
            get
            {
                return this.ProvisioningState() as string;
            }
        }

        /// <return>The uri to the vhd file backing this virtual machine's operating system disk.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.OsDiskVhdUri
        {
            get
            {
                return this.OsDiskVhdUri() as string;
            }
        }

        /// <return>The power state of the virtual machine.</return>
        Microsoft.Azure.Management.Compute.Fluent.PowerState Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.PowerState
        {
            get
            {
                return this.PowerState() as Microsoft.Azure.Management.Compute.Fluent.PowerState;
            }
        }

        /// <summary>
        /// Gets the public IP address associated with this virtual machine's primary network interface.
        /// <p>
        /// note that this method makes a rest API call to fetch the resource.
        /// </summary>
        /// <return>The public IP of the primary network interface.</return>
        Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.GetPrimaryPublicIpAddress()
        {
            return this.GetPrimaryPublicIpAddress() as Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress;
        }

        /// <return>Name of this virtual machine.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.ComputerName
        {
            get
            {
                return this.ComputerName() as string;
            }
        }

        /// <summary>
        /// Gets the operating system profile of an Azure virtual machine.
        /// </summary>
        /// <return>The osProfile value.</return>
        Models.OSProfile Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.OsProfile
        {
            get
            {
                return this.OsProfile() as Models.OSProfile;
            }
        }

        /// <summary>
        /// Restart the virtual machine.
        /// =.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.Restart()
        {

            this.Restart();
        }

        /// <summary>
        /// Returns the diagnostics profile of an Azure virtual machine.
        /// <p>
        /// Enabling diagnostic features in a virtual machine enable you to easily diagnose and recover
        /// virtual machine from boot failures.
        /// </summary>
        /// <return>The diagnosticsProfile value.</return>
        Models.DiagnosticsProfile Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.DiagnosticsProfile
        {
            get
            {
                return this.DiagnosticsProfile() as Models.DiagnosticsProfile;
            }
        }

        /// <summary>
        /// Redeploy the virtual machine.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.Redeploy()
        {

            this.Redeploy();
        }

        /// <summary>
        /// Captures the virtual machine by copying virtual hard disks of the VM and returns template as json
        /// string that can be used to create similar VMs.
        /// </summary>
        /// <param name="containerName">Destination container name to store the captured Vhd.</param>
        /// <param name="vhdPrefix">The prefix for the vhd holding captured image.</param>
        /// <param name="overwriteVhd">Whether to overwrites destination vhd if it exists.</param>
        /// <return>The template as json string.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.Capture(string containerName, string vhdPrefix, bool overwriteVhd)
        {
            return this.Capture(containerName, vhdPrefix, overwriteVhd) as string;
        }

        /// <return>The licenseType value.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.LicenseType
        {
            get
            {
                return this.LicenseType() as string;
            }
        }

        /// <summary>
        /// Get the virtual machine instance view.
        /// <p>
        /// this method returns the cached instance view, to refresh the cache call VirtualMachine.refreshInstanceView().
        /// </summary>
        /// <return>The virtual machine instance view.</return>
        Models.VirtualMachineInstanceView Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.InstanceView
        {
            get
            {
                return this.InstanceView() as Models.VirtualMachineInstanceView;
            }
        }

        /// <summary>
        /// Returns the storage profile of an Azure virtual machine.
        /// <p>
        /// The storage profile contains information such as the details of the VM image or user image
        /// from which this virtual machine is created, the Azure storage account where the operating system
        /// disk is stored, details of the data disk attached to the virtual machine.
        /// </summary>
        /// <return>The storageProfile value.</return>
        Models.StorageProfile Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.StorageProfile
        {
            get
            {
                return this.StorageProfile() as Models.StorageProfile;
            }
        }

        /// <summary>
        /// Generalize the Virtual Machine.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.Generalize()
        {

            this.Generalize();
        }

        /// <return>The size of the operating system disk in GB.</return>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.OsDiskSize
        {
            get
            {
                return this.OsDiskSize();
            }
        }

        /// <return>The list of data disks attached to this virtual machine.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.DataDisks
        {
            get
            {
                return this.DataDisks() as System.Collections.Generic.IList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk>;
            }
        }

        /// <return>The resource ID of the public IP address associated with this virtual machine's primary network interface.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.GetPrimaryPublicIpAddressId()
        {
            return this.GetPrimaryPublicIpAddressId() as string;
        }

        /// <summary>
        /// Specifies the SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">The Linux SSH root user name. This must follow the required naming convention for Linux user name.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKey VirtualMachine.Definition.IWithLinuxRootUsername.WithRootUsername(string rootUserName)
        {
            return this.WithRootUsername(rootUserName) as VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKey;
        }

        /// <summary>
        /// Associate an existing network interface with the virtual machine.
        /// 
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="networkInterface">An existing network interface.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithSecondaryNetworkInterface.WithExistingSecondaryNetworkInterface(INetworkInterface networkInterface)
        {
            return this.WithExistingSecondaryNetworkInterface(networkInterface) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Create a new network interface to associate with the virtual machine, based on the
        /// provided definition.
        /// 
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new network interface.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithSecondaryNetworkInterface.WithNewSecondaryNetworkInterface(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface> creatable)
        {
            return this.WithNewSecondaryNetworkInterface(creatable) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Removes a network interface associated with virtual machine.
        /// </summary>
        /// <param name="name">The name of the secondary network interface to remove.</param>
        /// <return>The stage representing updatable VM definition.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithSecondaryNetworkInterface.WithoutSecondaryNetworkInterface(string name)
        {
            return this.WithoutSecondaryNetworkInterface(name) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Associate an existing network interface with the virtual machine.
        /// 
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="networkInterface">An existing network interface.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithSecondaryNetworkInterface.WithExistingSecondaryNetworkInterface(INetworkInterface networkInterface)
        {
            return this.WithExistingSecondaryNetworkInterface(networkInterface) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Create a new network interface to associate with the virtual machine, based on the
        /// provided definition.
        /// 
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new network interface.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithSecondaryNetworkInterface.WithNewSecondaryNetworkInterface(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface> creatable)
        {
            return this.WithNewSecondaryNetworkInterface(creatable) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine;
        }

        /// <return>The resource id of the primary network interface associated with this resource.</return>
        string Microsoft.Azure.Management.Network.Fluent.IHasNetworkInterfaces.PrimaryNetworkInterfaceId
        {
            get
            {
                return this.PrimaryNetworkInterfaceId() as string;
            }
        }

        /// <summary>
        /// Gets the primary network interface.
        /// <p>
        /// Note that this method can result in a call to the cloud to fetch the network interface information.
        /// </summary>
        /// <return>The primary network interface associated with this resource.</return>
        Microsoft.Azure.Management.Network.Fluent.INetworkInterface Microsoft.Azure.Management.Network.Fluent.IHasNetworkInterfaces.GetPrimaryNetworkInterface()
        {
            return this.GetPrimaryNetworkInterface() as Microsoft.Azure.Management.Network.Fluent.INetworkInterface;
        }

        /// <return>The list of resource IDs of the network interfaces associated with this resource.</return>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Network.Fluent.IHasNetworkInterfaces.NetworkInterfaceIds
        {
            get
            {
                return this.NetworkInterfaceIds() as System.Collections.Generic.IList<string>;
            }
        }

        /// <summary>
        /// Specifies that no public IP needs to be associated with virtual machine.
        /// </summary>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithOS VirtualMachine.Definition.IWithPublicIpAddress.WithoutPrimaryPublicIpAddress()
        {
            return this.WithoutPrimaryPublicIpAddress() as VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Create a new public IP address to associate with virtual machine primary network interface, based on the
        /// provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithOS VirtualMachine.Definition.IWithPublicIpAddress.WithNewPrimaryPublicIpAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress> creatable)
        {
            return this.WithNewPrimaryPublicIpAddress(creatable) as VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associate it with the virtual machine's primary network interface.
        /// <p>
        /// the internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">The leaf domain label.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithOS VirtualMachine.Definition.IWithPublicIpAddress.WithNewPrimaryPublicIpAddress(string leafDnsLabel)
        {
            return this.WithNewPrimaryPublicIpAddress(leafDnsLabel) as VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Associates an existing public IP address with the virtual machine's primary network interface.
        /// </summary>
        /// <param name="publicIpAddress">An existing public IP address.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithOS VirtualMachine.Definition.IWithPublicIpAddress.WithExistingPrimaryPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            return this.WithExistingPrimaryPublicIpAddress(publicIpAddress) as VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Specifies the SSH public key.
        /// <p>
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        VirtualMachine.Definition.IWithLinuxCreate VirtualMachine.Definition.IWithLinuxCreate.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey) as VirtualMachine.Definition.IWithLinuxCreate;
        }

        /// <summary>
        /// Create a new virtual network to associate with the virtual machine's primary network interface, based on
        /// the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new virtual network.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithPrivateIp VirtualMachine.Definition.IWithNetwork.WithNewPrimaryNetwork(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetwork> creatable)
        {
            return this.WithNewPrimaryNetwork(creatable) as VirtualMachine.Definition.IWithPrivateIp;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the virtual machine's primary network interface.
        /// <p>
        /// the virtual network will be created in the same resource group and region as of virtual machine, it will be
        /// created with the specified address space and a default subnet covering the entirety of the network IP address space.
        /// </summary>
        /// <param name="addressSpace">The address space for the virtual network.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithPrivateIp VirtualMachine.Definition.IWithNetwork.WithNewPrimaryNetwork(string addressSpace)
        {
            return this.WithNewPrimaryNetwork(addressSpace) as VirtualMachine.Definition.IWithPrivateIp;
        }

        /// <summary>
        /// Associate an existing virtual network with the the virtual machine's primary network interface.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithSubnet VirtualMachine.Definition.IWithNetwork.WithExistingPrimaryNetwork(INetwork network)
        {
            return this.WithExistingPrimaryNetwork(network) as VirtualMachine.Definition.IWithSubnet;
        }

        /// <summary>
        /// Specifies definition of a not-yet-created storage account definition
        /// to put the VM's OS and data disk VHDs in.
        /// <p>
        /// Only the OS disk based on marketplace image will be stored in the new storage account.
        /// An OS disk based on user image will be stored in the same storage account as user image.
        /// </summary>
        /// <param name="creatable">The storage account in creatable stage.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithStorageAccount.WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable)
        {
            return this.WithNewStorageAccount(creatable) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the name of a new storage account to put the VM's OS and data disk VHD in.
        /// <p>
        /// Only the OS disk based on marketplace image will be stored in the new storage account,
        /// an OS disk based on user image will be stored in the same storage account as user image.
        /// </summary>
        /// <param name="name">The name of the storage account.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithStorageAccount.WithNewStorageAccount(string name)
        {
            return this.WithNewStorageAccount(name) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies an existing StorageAccount storage account to put the VM's OS and data disk VHD in.
        /// <p>
        /// An OS disk based on marketplace or user image (generalized image) will be stored in this
        /// storage account.
        /// </summary>
        /// <param name="storageAccount">An existing storage account.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithStorageAccount.WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            return this.WithExistingStorageAccount(storageAccount) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the computer name for the virtual machine.
        /// </summary>
        /// <param name="computerName">The computer name.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithFromImageCreateOptions VirtualMachine.Definition.IWithComputerName.WithComputerName(string computerName)
        {
            return this.WithComputerName(computerName) as VirtualMachine.Definition.IWithFromImageCreateOptions;
        }

        /// <summary>
        /// Specifies definition of an extension to be attached to the virtual machine.
        /// </summary>
        /// <param name="name">The reference name for the extension.</param>
        /// <return>The stage representing configuration for the extension.</return>
        VirtualMachineExtension.Definition.IBlank<VirtualMachine.Definition.IWithCreate> VirtualMachine.Definition.IWithExtension.DefineNewExtension(string name)
        {
            return this.DefineNewExtension(name) as VirtualMachineExtension.Definition.IBlank<VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// Detaches an extension with the given name from the virtual machine.
        /// </summary>
        /// <param name="name">The reference name for the extension to be removed/uninstalled.</param>
        /// <return>The stage representing updatable VM definition.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithExtension.WithoutExtension(string name)
        {
            return this.WithoutExtension(name) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Begins the description of an update of an existing extension of this virtual machine.
        /// </summary>
        /// <param name="name">The reference name for the extension.</param>
        /// <return>The stage representing updatable VM definition.</return>
        VirtualMachineExtension.Update.IUpdate VirtualMachine.Update.IWithExtension.UpdateExtension(string name)
        {
            return this.UpdateExtension(name) as VirtualMachineExtension.Update.IUpdate;
        }

        /// <summary>
        /// Specifies definition of an extension to be attached to the virtual machine.
        /// </summary>
        /// <param name="name">The reference name for the extension.</param>
        /// <return>The stage representing configuration for the extension.</return>
        VirtualMachineExtension.UpdateDefinition.IBlank<VirtualMachine.Update.IUpdate> VirtualMachine.Update.IWithExtension.DefineNewExtension(string name)
        {
            return this.DefineNewExtension(name) as VirtualMachineExtension.UpdateDefinition.IBlank<VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the administrator password for the Windows virtual machine.
        /// </summary>
        /// <param name="adminPassword">The administrator password. This must follow the criteria for Azure Windows VM password.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachine.Definition.IWithWindowsCreate VirtualMachine.Definition.IWithWindowsAdminPassword.WithAdminPassword(string adminPassword)
        {
            return this.WithAdminPassword(adminPassword) as VirtualMachine.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Specifies the SSH public key.
        /// <p>
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        VirtualMachine.Definition.IWithLinuxCreate VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKey.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey) as VirtualMachine.Definition.IWithLinuxCreate;
        }

        /// <summary>
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">The SSH root password. This must follow the criteria for Azure Linux VM password.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        VirtualMachine.Definition.IWithLinuxCreate VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKey.WithRootPassword(string rootPassword)
        {
            return this.WithRootPassword(rootPassword) as VirtualMachine.Definition.IWithLinuxCreate;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network subnet to the
        /// virtual machine's primary network interface.
        /// </summary>
        /// <param name="staticPrivateIpAddress">
        /// The static IP address within the specified subnet to assign to
        /// the network interface.
        /// </param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithPublicIpAddress VirtualMachine.Definition.IWithPrivateIp.WithPrimaryPrivateIpAddressStatic(string staticPrivateIpAddress)
        {
            return this.WithPrimaryPrivateIpAddressStatic(staticPrivateIpAddress) as VirtualMachine.Definition.IWithPublicIpAddress;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network subnet for
        /// virtual machine's primary network interface.
        /// </summary>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithPublicIpAddress VirtualMachine.Definition.IWithPrivateIp.WithPrimaryPrivateIpAddressDynamic()
        {
            return this.WithPrimaryPrivateIpAddressDynamic() as VirtualMachine.Definition.IWithPublicIpAddress;
        }

        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">The Windows administrator user name. This must follow the required naming convention for Windows user name.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        VirtualMachine.Definition.IWithWindowsAdminPassword VirtualMachine.Definition.IWithWindowsAdminUsername.WithAdminUsername(string adminUserName)
        {
            return this.WithAdminUsername(adminUserName) as VirtualMachine.Definition.IWithWindowsAdminPassword;
        }

        /// <summary>
        /// Specifies that the latest version of a marketplace Linux image needs to be used.
        /// </summary>
        /// <param name="publisher">Specifies the publisher of the image.</param>
        /// <param name="offer">Specifies the offer of the image.</param>
        /// <param name="sku">Specifies the SKU of the image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithLinuxRootUsername VirtualMachine.Definition.IWithOS.WithLatestLinuxImage(string publisher, string offer, string sku)
        {
            return this.WithLatestLinuxImage(publisher, offer, sku) as VirtualMachine.Definition.IWithLinuxRootUsername;
        }

        /// <summary>
        /// Specifies the user (generalized) Linux image used for the virtual machine's OS.
        /// </summary>
        /// <param name="imageUrl">The url the the VHD.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithLinuxRootUsername VirtualMachine.Definition.IWithOS.WithStoredLinuxImage(string imageUrl)
        {
            return this.WithStoredLinuxImage(imageUrl) as VirtualMachine.Definition.IWithLinuxRootUsername;
        }

        /// <summary>
        /// Specifies the version of a market-place Linux image needs to be used.
        /// </summary>
        /// <param name="imageReference">Describes publisher, offer, sku and version of the market-place image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithLinuxRootUsername VirtualMachine.Definition.IWithOS.WithSpecificLinuxImageVersion(ImageReference imageReference)
        {
            return this.WithSpecificLinuxImageVersion(imageReference) as VirtualMachine.Definition.IWithLinuxRootUsername;
        }

        /// <summary>
        /// Specifies that the latest version of a marketplace Windows image needs to be used.
        /// </summary>
        /// <param name="publisher">Specifies the publisher of the image.</param>
        /// <param name="offer">Specifies the offer of the image.</param>
        /// <param name="sku">Specifies the SKU of the image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithWindowsAdminUsername VirtualMachine.Definition.IWithOS.WithLatestWindowsImage(string publisher, string offer, string sku)
        {
            return this.WithLatestWindowsImage(publisher, offer, sku) as VirtualMachine.Definition.IWithWindowsAdminUsername;
        }

        /// <summary>
        /// Specifies the known marketplace Windows image used for the virtual machine's OS.
        /// </summary>
        /// <param name="knownImage">Enum value indicating known market-place image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithWindowsAdminUsername VirtualMachine.Definition.IWithOS.WithPopularWindowsImage(KnownWindowsVirtualMachineImage knownImage)
        {
            return this.WithPopularWindowsImage(knownImage) as VirtualMachine.Definition.IWithWindowsAdminUsername;
        }

        /// <summary>
        /// Specifies the specialized operating system disk to be attached to the virtual machine.
        /// </summary>
        /// <param name="osDiskUrl">OsDiskUrl the url to the OS disk in the Azure Storage account.</param>
        /// <param name="osType">The OS type.</param>
        /// <return>The next stage of the Windows virtual machine definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithOS.WithOsDisk(string osDiskUrl, OperatingSystemTypes osType)
        {
            return this.WithOsDisk(osDiskUrl, osType) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the version of a marketplace Windows image needs to be used.
        /// </summary>
        /// <param name="imageReference">Describes publisher, offer, sku and version of the market-place image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithWindowsAdminUsername VirtualMachine.Definition.IWithOS.WithSpecificWindowsImageVersion(ImageReference imageReference)
        {
            return this.WithSpecificWindowsImageVersion(imageReference) as VirtualMachine.Definition.IWithWindowsAdminUsername;
        }

        /// <summary>
        /// Specifies the known marketplace Linux image used for the virtual machine's OS.
        /// </summary>
        /// <param name="knownImage">Enum value indicating known market-place image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithLinuxRootUsername VirtualMachine.Definition.IWithOS.WithPopularLinuxImage(KnownLinuxVirtualMachineImage knownImage)
        {
            return this.WithPopularLinuxImage(knownImage) as VirtualMachine.Definition.IWithLinuxRootUsername;
        }

        /// <summary>
        /// Specifies the user (generalized) Windows image used for the virtual machine's OS.
        /// </summary>
        /// <param name="imageUrl">The url the the VHD.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithWindowsAdminUsername VirtualMachine.Definition.IWithOS.WithStoredWindowsImage(string imageUrl)
        {
            return this.WithStoredWindowsImage(imageUrl) as VirtualMachine.Definition.IWithWindowsAdminUsername;
        }

        /// <summary>
        /// Specifies the size of the OSDisk in GB.
        /// </summary>
        /// <param name="size">The VHD size.</param>
        /// <return>The stage representing updatable VM definition.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IUpdate.WithOsDiskSizeInGb(int size)
        {
            return this.WithOsDiskSizeInGb(size) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the caching type for the Operating System disk.
        /// </summary>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The stage representing updatable VM definition.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IUpdate.WithOsDiskCaching(CachingTypes cachingType)
        {
            return this.WithOsDiskCaching(cachingType) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the new size for the virtual machine.
        /// </summary>
        /// <param name="sizeName">The name of the size for the virtual machine as text.</param>
        /// <return>The stage representing updatable VM definition.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IUpdate.WithSize(string sizeName)
        {
            return this.WithSize(sizeName) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the new size for the virtual machine.
        /// </summary>
        /// <param name="size">A size from the list of available sizes for the virtual machine.</param>
        /// <return>The stage representing updatable VM definition.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IUpdate.WithSize(VirtualMachineSizeTypes size)
        {
            return this.WithSize(size) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that VM Agent should not be provisioned.
        /// </summary>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachine.Definition.IWithWindowsCreate VirtualMachine.Definition.IWithWindowsCreate.WithoutVmAgent()
        {
            return this.WithoutVmAgent() as VirtualMachine.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Specifies the WINRM listener.
        /// <p>
        /// Each call to this method adds the given listener to the list of VM's WinRM listeners.
        /// </summary>
        /// <param name="listener">The WinRmListener.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachine.Definition.IWithWindowsCreate VirtualMachine.Definition.IWithWindowsCreate.WithWinRm(WinRMListener listener)
        {
            return this.WithWinRm(listener) as VirtualMachine.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Specifies that automatic updates should be disabled.
        /// </summary>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachine.Definition.IWithWindowsCreate VirtualMachine.Definition.IWithWindowsCreate.WithoutAutoUpdate()
        {
            return this.WithoutAutoUpdate() as VirtualMachine.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Specifies the time-zone.
        /// </summary>
        /// <param name="timeZone">The timezone.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachine.Definition.IWithWindowsCreate VirtualMachine.Definition.IWithWindowsCreate.WithTimeZone(string timeZone)
        {
            return this.WithTimeZone(timeZone) as VirtualMachine.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Specifies the custom data for the virtual machine.
        /// </summary>
        /// <param name="base64EncodedCustomData">The base64 encoded custom data.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachine.Definition.IWithFromImageCreateOptions VirtualMachine.Definition.IWithCustomData.WithCustomData(string base64EncodedCustomData)
        {
            return this.WithCustomData(base64EncodedCustomData) as VirtualMachine.Definition.IWithFromImageCreateOptions;
        }

        /// <summary>
        /// Associates a subnet with the virtual machine's primary network interface.
        /// </summary>
        /// <param name="name">The subnet name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithPrivateIp VirtualMachine.Definition.IWithSubnet.WithSubnet(string name)
        {
            return this.WithSubnet(name) as VirtualMachine.Definition.IWithPrivateIp;
        }

        /// <summary>
        /// Specifies the size of the OSDisk in GB.
        /// </summary>
        /// <param name="size">The VHD size.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithOsDiskSettings.WithOsDiskSizeInGb(int size)
        {
            return this.WithOsDiskSizeInGb(size) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the name for the OS Disk.
        /// </summary>
        /// <param name="name">The OS Disk name.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithOsDiskSettings.WithOsDiskName(string name)
        {
            return this.WithOsDiskName(name) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the name of the OS Disk Vhd file and it's parent container.
        /// </summary>
        /// <param name="containerName">The name of the container in the selected storage account.</param>
        /// <param name="vhdName">The name for the OS Disk vhd.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithOsDiskSettings.WithOsDiskVhdLocation(string containerName, string vhdName)
        {
            return this.WithOsDiskVhdLocation(containerName, vhdName) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the caching type for the Operating System disk.
        /// </summary>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithOsDiskSettings.WithOsDiskCaching(CachingTypes cachingType)
        {
            return this.WithOsDiskCaching(cachingType) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the encryption settings for the OS Disk.
        /// </summary>
        /// <param name="settings">The encryption settings.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithOsDiskSettings.WithOsDiskEncryptionSettings(DiskEncryptionSettings settings)
        {
            return this.WithOsDiskEncryptionSettings(settings) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the virtual machine size.
        /// </summary>
        /// <param name="sizeName">The name of the size for the virtual machine as text.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithVMSize.WithSize(string sizeName)
        {
            return this.WithSize(sizeName) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the virtual machine size.
        /// </summary>
        /// <param name="size">A size from the list of available sizes for the virtual machine.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithVMSize.WithSize(VirtualMachineSizeTypes size)
        {
            return this.WithSize(size) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Create a new network interface to associate the virtual machine with as it's primary network interface,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new network interface.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithOS VirtualMachine.Definition.IWithPrimaryNetworkInterface.WithNewPrimaryNetworkInterface(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface> creatable)
        {
            return this.WithNewPrimaryNetworkInterface(creatable) as VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Associate an existing network interface as the virtual machine with as it's primary network interface.
        /// </summary>
        /// <param name="networkInterface">An existing network interface.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithOS VirtualMachine.Definition.IWithPrimaryNetworkInterface.WithExistingPrimaryNetworkInterface(INetworkInterface networkInterface)
        {
            return this.WithExistingPrimaryNetworkInterface(networkInterface) as VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Specifies an existing AvailabilitySet availability set to to associate the virtual machine with.
        /// <p>
        /// Adding virtual machines running your application to an availability set ensures that during
        /// maintenance event at least one virtual machine will be available.
        /// </summary>
        /// <param name="availabilitySet">An existing availability set.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithAvailabilitySet.WithExistingAvailabilitySet(IAvailabilitySet availabilitySet)
        {
            return this.WithExistingAvailabilitySet(availabilitySet) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies definition of a not-yet-created availability set definition
        /// to associate the virtual machine with.
        /// <p>
        /// Adding virtual machines running your application to an availability set ensures that during
        /// maintenance event at least one virtual machine will be available.
        /// </summary>
        /// <param name="creatable">The availability set in creatable stage.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithAvailabilitySet.WithNewAvailabilitySet(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet> creatable)
        {
            return this.WithNewAvailabilitySet(creatable) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the name of a new availability set to associate the virtual machine with.
        /// <p>
        /// Adding virtual machines running your application to an availability set ensures that during
        /// maintenance event at least one virtual machine will be available.
        /// </summary>
        /// <param name="name">The name of the availability set.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithAvailabilitySet.WithNewAvailabilitySet(string name)
        {
            return this.WithNewAvailabilitySet(name) as VirtualMachine.Definition.IWithCreate;
        }
    }
}