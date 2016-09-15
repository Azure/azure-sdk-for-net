/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition
{

    using Microsoft.Azure.Management.V2.Network;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.V2.Storage;
    using Microsoft.Azure.Management.V2.Compute;
    using Microsoft.Azure.Management.V2.Resource.Core.Resource.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Definition;
    /// <summary>
    /// The stage of the virtual machine definition allowing to associate public IP address with it's primary network interface.
    /// </summary>
    public interface IWithPublicIpAddress 
    {
        /// <summary>
        /// Create a new public IP address to associate with virtual machine primary network interface, based on the
        /// provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new public IP</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        IWithOS WithNewPrimaryPublicIpAddress (ICreatable<IPublicIpAddress> creatable);

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associate it with the virtual machine's primary network interface.
        /// <p>
        /// the internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">leafDnsLabel the leaf domain label</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        IWithOS WithNewPrimaryPublicIpAddress (string leafDnsLabel);

        /// <summary>
        /// Associates an existing public IP address with the virtual machine's primary network interface.
        /// </summary>
        /// <param name="publicIpAddress">publicIpAddress an existing public IP address</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        IWithOS WithExistingPrimaryPublicIpAddress (IPublicIpAddress publicIpAddress);

        /// <summary>
        /// Specifies that no public IP needs to be associated with virtual machine.
        /// </summary>
        /// <returns>the next stage of the virtual machine definition</returns>
        IWithOS WithoutPrimaryPublicIpAddress ();

    }
    /// <summary>
    /// The entirety of the virtual machine definition.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithGroup,
        IWithNetwork,
        IWithSubnet,
        IWithPrivateIp,
        IWithPublicIpAddress,
        IWithPrimaryNetworkInterface,
        IWithOS,
        IWithRootUserName,
        IWithAdminUserName,
        IWithLinuxCreate,
        IWithWindowsCreate,
        IWithCreate
    {
    }
    /// <summary>
    /// The stage of the virtual machine definition allowing to specify the Operation System image.
    /// </summary>
    public interface IWithOS 
    {
        /// <summary>
        /// Specifies the known marketplace Windows image used for the virtual machine's OS.
        /// </summary>
        /// <param name="knownImage">knownImage enum value indicating known market-place image</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        IWithAdminUserName WithPopularWindowsImage (KnownWindowsVirtualMachineImage knownImage);

        /// <summary>
        /// Specifies that the latest version of a marketplace Windows image needs to be used.
        /// </summary>
        /// <param name="publisher">publisher specifies the publisher of the image</param>
        /// <param name="offer">offer specifies the offer of the image</param>
        /// <param name="sku">sku specifies the SKU of the image</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        IWithAdminUserName WithLatestWindowsImage (string publisher, string offer, string sku);

        /// <summary>
        /// Specifies the version of a marketplace Windows image needs to be used.
        /// </summary>
        /// <param name="imageReference">imageReference describes publisher, offer, sku and version of the market-place image</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        IWithAdminUserName WithSpecificWindowsImageVersion (ImageReference imageReference);

        /// <summary>
        /// Specifies the user (generalized) Windows image used for the virtual machine's OS.
        /// </summary>
        /// <param name="imageUrl">imageUrl the url the the VHD</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        IWithAdminUserName WithStoredWindowsImage (string imageUrl);

        /// <summary>
        /// Specifies the known marketplace Linux image used for the virtual machine's OS.
        /// </summary>
        /// <param name="knownImage">knownImage enum value indicating known market-place image</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        IWithRootUserName WithPopularLinuxImage (KnownLinuxVirtualMachineImage knownImage);

        /// <summary>
        /// Specifies that the latest version of a marketplace Linux image needs to be used.
        /// </summary>
        /// <param name="publisher">publisher specifies the publisher of the image</param>
        /// <param name="offer">offer specifies the offer of the image</param>
        /// <param name="sku">sku specifies the SKU of the image</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        IWithRootUserName WithLatestLinuxImage (string publisher, string offer, string sku);

        /// <summary>
        /// Specifies the version of a market-place Linux image needs to be used.
        /// </summary>
        /// <param name="imageReference">imageReference describes publisher, offer, sku and version of the market-place image</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        IWithRootUserName WithSpecificLinuxImageVersion (ImageReference imageReference);

        /// <summary>
        /// Specifies the user (generalized) Linux image used for the virtual machine's OS.
        /// </summary>
        /// <param name="imageUrl">imageUrl the url the the VHD</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        IWithRootUserName WithStoredLinuxImage (string imageUrl);

        /// <summary>
        /// Specifies the specialized operating system disk to be attached to the virtual machine.
        /// </summary>
        /// <param name="osDiskUrl">osDiskUrl osDiskUrl the url to the OS disk in the Azure Storage account</param>
        /// <param name="osType">osType the OS type</param>
        /// <returns>the next stage of the Windows virtual machine definition</returns>
        IWithCreate WithOsDisk (string osDiskUrl, OperatingSystemTypes osType);

    }
    /// <summary>
    /// The stage of the virtual machine definition allowing to specify the primary network interface.
    /// </summary>
    public interface IWithPrimaryNetworkInterface 
    {
        /// <summary>
        /// Create a new network interface to associate the virtual machine with as it's primary network interface,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new network interface</param>
        /// <returns>The next stage of the virtual machine definition</returns>
        IWithOS WithNewPrimaryNetworkInterface (ICreatable<INetworkInterface> creatable);

        /// <summary>
        /// Associate an existing network interface as the virtual machine with as it's primary network interface.
        /// </summary>
        /// <param name="networkInterface">networkInterface an existing network interface</param>
        /// <returns>The next stage of the virtual machine definition</returns>
        IWithOS WithExistingPrimaryNetworkInterface (INetworkInterface networkInterface);

    }
    /// <summary>
    /// The stage of the virtual machine definition allowing to specify virtual network for the new primary network
    /// interface or to use a creatable or existing network interface.
    /// </summary>
    public interface IWithNetwork  :
        IWithPrimaryNetworkInterface
    {
        /// <summary>
        /// Create a new virtual network to associate with the virtual machine's primary network interface, based on
        /// the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new virtual network</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        IWithPrivateIp WithNewPrimaryNetwork (ICreatable<INetwork> creatable);

        /// <summary>
        /// Creates a new virtual network to associate with the virtual machine's primary network interface.
        /// <p>
        /// the virtual network will be created in the same resource group and region as of virtual machine, it will be
        /// created with the specified address space and a default subnet covering the entirety of the network IP address space.
        /// </summary>
        /// <param name="addressSpace">addressSpace the address space for the virtual network</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        IWithPrivateIp WithNewPrimaryNetwork (string addressSpace);

        /// <summary>
        /// Associate an existing virtual network with the the virtual machine's primary network interface.
        /// </summary>
        /// <param name="network">network an existing virtual network</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        IWithSubnet WithExistingPrimaryNetwork (INetwork network);

    }
    /// <summary>
    /// The stage of the Linux virtual machine definition which contains all the minimum required inputs for
    /// the resource to be created (via {@link WithCreate#create()}), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithLinuxCreate  :
        IWithCreate
    {
        /// <summary>
        /// Specifies the SSH public key.
        /// <p>
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">publicKey the SSH public key in PEM format.</param>
        /// <returns>the stage representing creatable Linux VM definition</returns>
        IWithLinuxCreate WithSsh (string publicKey);

    }
    /// <summary>
    /// The stage of the virtual machine definition allowing to specify virtual network subnet for the new primary network interface.
    /// </summary>
    public interface IWithSubnet 
    {
        /// <summary>
        /// Associate a subnet with the virtual machine primary network interface.
        /// </summary>
        /// <param name="name">name the subnet name</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        IWithPrivateIp WithSubnet (string name);

    }
    /// <summary>
    /// The stage of virtual machine definition allowing to specify additional network interfaces.
    /// </summary>
    public interface IWithSecondaryNetworkInterface 
    {
        /// <summary>
        /// Create a new network interface to associate with the virtual machine, based on the
        /// provided definition.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new network interface</param>
        /// <returns>the stage representing creatable VM definition</returns>
        IWithCreate WithNewSecondaryNetworkInterface (ICreatable<INetworkInterface> creatable);

        /// <summary>
        /// Associate an existing network interface with the virtual machine.
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="networkInterface">networkInterface an existing network interface</param>
        /// <returns>the stage representing creatable VM definition</returns>
        IWithCreate WithExistingSecondaryNetworkInterface (INetworkInterface networkInterface);

    }
    /// <summary>
    /// The stage of the Linux virtual machine definition allowing to specify root user name.
    /// </summary>
    public interface IWithRootUserName 
    {
        /// <summary>
        /// Specifies the root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">rootUserName the Linux root user name. This must follow the required naming convention for Linux user name</param>
        /// <returns>the next stage of the Linux virtual machine definition</returns>
        IWithLinuxCreate WithRootUserName (string rootUserName);

    }
    /// <summary>
    /// The stage of the virtual machine definition allowing to specify VM size.
    /// </summary>
    public interface IWithVMSize 
    {
        /// <summary>
        /// Specifies the virtual machine size.
        /// </summary>
        /// <param name="sizeName">sizeName the name of the size for the virtual machine as text</param>
        /// <returns>the stage representing creatable VM definition</returns>
        IWithCreate WithSize (string sizeName);
    }

    /// <summary>
    /// The stage of the Windows virtual machine definition which contains all the minimum required inputs for
    /// the resource to be created (via {@link WithCreate#create()}, but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithWindowsCreate  :
        IWithCreate
    {
        /// <summary>
        /// Specifies that VM Agent should not be provisioned.
        /// </summary>
        /// <returns>the stage representing creatable Windows VM definition</returns>
        IWithWindowsCreate DisableVmAgent();

        /// <summary>
        /// Specifies that automatic updates should be disabled.
        /// </summary>
        /// <returns>the stage representing creatable Windows VM definition</returns>
        IWithWindowsCreate DisableAutoUpdate();

        /// <summary>
        /// Specifies the time-zone.
        /// </summary>
        /// <param name="timeZone">timeZone the timezone</param>
        /// <returns>the stage representing creatable Windows VM definition</returns>
        IWithWindowsCreate WithTimeZone (string timeZone);

        /// <summary>
        /// Specifies the WINRM listener.
        /// <p>
        /// Each call to this method adds the given listener to the list of VM's WinRM listeners.
        /// </summary>
        /// <param name="listener">listener the WinRmListener</param>
        /// <returns>the stage representing creatable Windows VM definition</returns>
        IWithWindowsCreate WithWinRm (WinRMListener listener);

    }
    /// <summary>
    /// The stage of the virtual machine definition allowing to specify OS disk configurations.
    /// </summary>
    public interface IWithOsDiskSettings 
    {
        /// <summary>
        /// Specifies the caching type for the Operating System disk.
        /// </summary>
        /// <param name="cachingType">cachingType the caching type.</param>
        /// <returns>the stage representing creatable VM definition</returns>
        IWithCreate WithOsDiskCaching (CachingTypes cachingType);

        /// <summary>
        /// Specifies the name of the OS Disk Vhd file and it's parent container.
        /// </summary>
        /// <param name="containerName">containerName the name of the container in the selected storage account.</param>
        /// <param name="vhdName">vhdName the name for the OS Disk vhd.</param>
        /// <returns>the stage representing creatable VM definition</returns>
        IWithCreate WithOsDiskVhdLocation (string containerName, string vhdName);

        /// <summary>
        /// Specifies the encryption settings for the OS Disk.
        /// </summary>
        /// <param name="settings">settings the encryption settings.</param>
        /// <returns>the stage representing creatable VM definition</returns>
        IWithCreate WithOsDiskEncryptionSettings (DiskEncryptionSettings settings);

        /// <summary>
        /// Specifies the size of the OSDisk in GB.
        /// </summary>
        /// <param name="size">size the VHD size.</param>
        /// <returns>the stage representing creatable VM definition</returns>
        IWithCreate WithOsDiskSizeInGb (int? size);

        /// <summary>
        /// Specifies the name for the OS Disk.
        /// </summary>
        /// <param name="name">name the OS Disk name.</param>
        /// <returns>the stage representing creatable VM definition</returns>
        IWithCreate WithOsDiskName (string name);

    }
    /// <summary>
    /// The stage of the Windows virtual machine definition allowing to specify administrator user name.
    /// </summary>
    public interface IWithAdminUserName 
    {
        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">adminUserName the Windows administrator user name. This must follow the required naming convention for Windows user name.</param>
        /// <returns>the stage representing creatable Linux VM definition</returns>
        IWithWindowsCreate WithAdminUserName (string adminUserName);

    }
    /// <summary>
    /// The stage of the virtual machine definition allowing to specify storage account.
    /// </summary>
    public interface IWithStorageAccount 
    {
        /// <summary>
        /// Specifies the name of a new storage account to put the VM's OS and data disk VHD in.
        /// <p>
        /// Only the OS disk based on marketplace image will be stored in the new storage account,
        /// an OS disk based on user image will be stored in the same storage account as user image.
        /// </summary>
        /// <param name="name">name the name of the storage account</param>
        /// <returns>the stage representing creatable VM definition</returns>
        IWithCreate WithNewStorageAccount (string name);

        /// <summary>
        /// Specifies definition of a not-yet-created storage account definition
        /// to put the VM's OS and data disk VHDs in.
        /// <p>
        /// Only the OS disk based on marketplace image will be stored in the new storage account.
        /// An OS disk based on user image will be stored in the same storage account as user image.
        /// </summary>
        /// <param name="creatable">creatable the storage account in creatable stage</param>
        /// <returns>the stage representing creatable VM definition</returns>
        IWithCreate WithNewStorageAccount (ICreatable<IStorageAccount> creatable);

        /// <summary>
        /// Specifies an existing {@link StorageAccount} storage account to put the VM's OS and data disk VHD in.
        /// <p>
        /// An OS disk based on marketplace or user image (generalized image) will be stored in this
        /// storage account.
        /// </summary>
        /// <param name="storageAccount">storageAccount an existing storage account</param>
        /// <returns>the stage representing creatable VM definition</returns>
        IWithCreate WithExistingStorageAccount (IStorageAccount storageAccount);

    }
    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via {@link WithCreate#create()}), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<IVirtualMachine>,
        IDefinitionWithTags<IWithCreate>,
        IWithPassword,
        IWithOsDiskSettings,
        IWithVMSize,
        IWithStorageAccount,
        IWithDataDisk,
        IWithAvailabilitySet,
        IWithSecondaryNetworkInterface
    {
    }
    /// <summary>
    /// The stage of the virtual machine definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition.IWithGroup<IWithNetwork>
    {
    }
    /// <summary>
    /// The stage of the virtual machine definition allowing to specify data disk configuration.
    /// </summary>
    public interface IWithDataDisk 
    {
        /// <summary>
        /// Specifies that a new blank data disk needs to be attached to virtual machine.
        /// </summary>
        /// <param name="sizeInGB">sizeInGB the disk size in GB</param>
        /// <returns>the stage representing creatable VM definition</returns>
        IWithCreate WithNewDataDisk (int? sizeInGB);

        /// <summary>
        /// Specifies an existing VHD that needs to be attached to the virtual machine as data disk.
        /// </summary>
        /// <param name="storageAccountName">storageAccountName the storage account name</param>
        /// <param name="containerName">containerName the name of the container holding the VHD file</param>
        /// <param name="vhdName">vhdName the name for the VHD file</param>
        /// <returns>the stage representing creatable VM definition</returns>
        IWithCreate WithExistingDataDisk (string storageAccountName, string containerName, string vhdName);

        /// <summary>
        /// Specifies a new blank data disk to be attached to the virtual machine along with it's configuration.
        /// </summary>
        /// <param name="name">name the name for the data disk</param>
        /// <returns>the stage representing configuration for the data disk</returns>
        IAttachNewDataDisk<IWithCreate> DefineNewDataDisk (string name);

        /// <summary>
        /// Specifies an existing VHD that needs to be attached to the virtual machine as data disk along with
        /// it's configuration.
        /// </summary>
        /// <param name="name">name the name for the data disk</param>
        /// <returns>the stage representing configuration for the data disk</returns>
        IAttachExistingDataDisk<IWithCreate> DefineExistingDataDisk (string name);

    }
    /// <summary>
    /// The stage of the virtual machine definition allowing to specify availability set.
    /// </summary>
    public interface IWithAvailabilitySet 
    {
        /// <summary>
        /// Specifies the name of a new availability set to associate the virtual machine with.
        /// <p>
        /// Adding virtual machines running your application to an availability set ensures that during
        /// maintenance event at least one virtual machine will be available.
        /// </summary>
        /// <param name="name">name the name of the availability set</param>
        /// <returns>the stage representing creatable VM definition</returns>
        IWithCreate WithNewAvailabilitySet (string name);

        /// <summary>
        /// Specifies definition of a not-yet-created availability set definition
        /// to associate the virtual machine with.
        /// <p>
        /// Adding virtual machines running your application to an availability set ensures that during
        /// maintenance event at least one virtual machine will be available.
        /// </summary>
        /// <param name="creatable">creatable the availability set in creatable stage</param>
        /// <returns>the stage representing creatable VM definition</returns>
        IWithCreate WithNewAvailabilitySet (ICreatable<IAvailabilitySet> creatable);

        /// <summary>
        /// Specifies an existing {@link AvailabilitySet} availability set to to associate the virtual machine with.
        /// <p>
        /// Adding virtual machines running your application to an availability set ensures that during
        /// maintenance event at least one virtual machine will be available.
        /// </summary>
        /// <param name="availabilitySet">availabilitySet an existing availability set</param>
        /// <returns>the stage representing creatable VM definition</returns>
        IWithCreate WithExistingAvailabilitySet (IAvailabilitySet availabilitySet);

    }
    /// <summary>
    /// The stage of the virtual machine definition allowing to specify private IP address within a virtual network subnet.
    /// </summary>
    public interface IWithPrivateIp 
    {
        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network subnet for
        /// virtual machine's primary network interface.
        /// </summary>
        /// <returns>the next stage of the virtual machine definition</returns>
        IWithPublicIpAddress WithPrimaryPrivateIpAddressDynamic ();

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network subnet to the
        /// virtual machine's primary network interface.
        /// </summary>
        /// <param name="staticPrivateIpAddress">staticPrivateIpAddress the static IP address within the specified subnet to assign to</param>
        /// <param name="the">the network interface</param>
        /// <returns>the next stage of the virtual machine definition</returns>
        IWithPublicIpAddress WithPrimaryPrivateIpAddressStatic (string staticPrivateIpAddress);

    }
    /// <summary>
    /// The stage of the virtual machine definition allowing to specify password.
    /// </summary>
    public interface IWithPassword 
    {
        /// <summary>
        /// Specifies the password for the virtual machine.
        /// </summary>
        /// <param name="password">password the password. This must follow the criteria for Azure VM password.</param>
        /// <returns>the stage representing creatable VM definition</returns>
        IWithCreate WithPassword (string password);

    }
    /// <summary>
    /// The first stage of a virtual machine definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithGroup>
    {
    }
}