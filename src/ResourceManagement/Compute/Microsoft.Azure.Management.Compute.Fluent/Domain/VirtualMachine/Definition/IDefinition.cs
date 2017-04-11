// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;

    /// <summary>
    /// The stages contains OS agnostics settings when virtual machine is created from image.
    /// </summary>
    public interface IWithFromImageCreateOptionsManagedOrUnmanaged  :
        IWithFromImageCreateOptionsManaged
    {
        /// <return>The next stage of a unmanaged disk based virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged WithUnmanagedDisks();
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify VM size.
    /// </summary>
    public interface IWithVMSize 
    {
        /// <summary>
        /// Specifies the virtual machine size.
        /// </summary>
        /// <param name="sizeName">The name of the size for the virtual machine as text.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithSize(string sizeName);

        /// <summary>
        /// Specifies the virtual machine size.
        /// </summary>
        /// <param name="size">A size from the list of available sizes for the virtual machine.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithSize(VirtualMachineSizeTypes size);
    }

    /// <summary>
    /// The stage of the Linux virtual machine definition which contains all the minimum required inputs for
    /// the resource to be created (via WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithLinuxCreateManaged  :
        IWithFromImageCreateOptionsManaged
    {
        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxCreateManaged WithSsh(string publicKey);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify the Operation System image.
    /// </summary>
    public interface IWithOS 
    {
        /// <summary>
        /// Specifies the known marketplace Linux image used for the virtual machine's OS.
        /// </summary>
        /// <param name="knownImage">Enum value indicating known market-place image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootUsernameManagedOrUnmanaged WithPopularLinuxImage(KnownLinuxVirtualMachineImage knownImage);

        /// <summary>
        /// Specifies that the latest version of a marketplace Linux image needs to be used.
        /// </summary>
        /// <param name="publisher">Specifies the publisher of the image.</param>
        /// <param name="offer">Specifies the offer of the image.</param>
        /// <param name="sku">Specifies the SKU of the image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootUsernameManagedOrUnmanaged WithLatestLinuxImage(string publisher, string offer, string sku);

        /// <summary>
        /// Specifies the user (generalized) Linux image used for the virtual machine's OS.
        /// </summary>
        /// <param name="imageUrl">The url the the VHD.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootUsernameUnmanaged WithStoredLinuxImage(string imageUrl);

        /// <summary>
        /// Specifies that the latest version of a marketplace Windows image needs to be used.
        /// </summary>
        /// <param name="publisher">Specifies the publisher of the image.</param>
        /// <param name="offer">Specifies the offer of the image.</param>
        /// <param name="sku">Specifies the SKU of the image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged WithLatestWindowsImage(string publisher, string offer, string sku);

        /// <summary>
        /// Specifies the specialized operating system unmanaged disk to be attached to the virtual machine.
        /// </summary>
        /// <param name="osDiskUrl">OsDiskUrl the url to the OS disk in the Azure Storage account.</param>
        /// <param name="osType">The OS type.</param>
        /// <return>The next stage of the Windows virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithUnmanagedCreate WithSpecializedOSUnmanagedDisk(string osDiskUrl, OperatingSystemTypes osType);

        /// <summary>
        /// Specifies the id of a Linux custom image to be used.
        /// </summary>
        /// <param name="customImageId">The resource id of the custom image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootUsernameManaged WithLinuxCustomImage(string customImageId);

        /// <summary>
        /// Specifies the known marketplace Windows image used for the virtual machine's OS.
        /// </summary>
        /// <param name="knownImage">Enum value indicating known market-place image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged WithPopularWindowsImage(KnownWindowsVirtualMachineImage knownImage);

        /// <summary>
        /// Specifies the version of a marketplace Windows image needs to be used.
        /// </summary>
        /// <param name="imageReference">Describes publisher, offer, sku and version of the market-place image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged WithSpecificWindowsImageVersion(ImageReference imageReference);

        /// <summary>
        /// Specifies the version of a market-place Linux image needs to be used.
        /// </summary>
        /// <param name="imageReference">Describes publisher, offer, sku and version of the market-place image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootUsernameManagedOrUnmanaged WithSpecificLinuxImageVersion(ImageReference imageReference);

        /// <summary>
        /// Specifies the id of a Windows custom image to be used.
        /// </summary>
        /// <param name="customImageId">The resource id of the custom image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminUsernameManaged WithWindowsCustomImage(string customImageId);

        /// <summary>
        /// Specifies the user (generalized) Windows image used for the virtual machine's OS.
        /// </summary>
        /// <param name="imageUrl">The url the the VHD.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminUsernameUnmanaged WithStoredWindowsImage(string imageUrl);

        /// <summary>
        /// Specifies the specialized operating system managed disk to be attached to the virtual machine.
        /// </summary>
        /// <param name="disk">The managed disk to attach.</param>
        /// <param name="osType">The OS type.</param>
        /// <return>The next stage of the Windows virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithSpecializedOSDisk(IDisk disk, OperatingSystemTypes osType);
    }

    /// <summary>
    /// The stages contains OS agnostics settings when virtual machine is created from image.
    /// </summary>
    public interface IWithFromImageCreateOptionsManaged  :
        IWithManagedCreate
    {
        /// <summary>
        /// Specifies the custom data for the virtual machine.
        /// </summary>
        /// <param name="base64EncodedCustomData">The base64 encoded custom data.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithFromImageCreateOptionsManaged WithCustomData(string base64EncodedCustomData);

        /// <summary>
        /// Specifies the computer name for the virtual machine.
        /// </summary>
        /// <param name="computerName">The computer name.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithFromImageCreateOptionsManaged WithComputerName(string computerName);
    }

    /// <summary>
    /// The stage of the Linux virtual machine definition allowing to specify SSH root user name.
    /// </summary>
    public interface IWithLinuxRootUsernameManaged 
    {
        /// <summary>
        /// Specifies the SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">The Linux SSH root user name. This must follow the required naming convention for Linux user name.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManaged WithRootUsername(string rootUserName);
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
        /// <param name="creatable">A creatable definition for a new network interface.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithOS WithNewPrimaryNetworkInterface(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface> creatable);

        /// <summary>
        /// Associate an existing network interface as the virtual machine with as it's primary network interface.
        /// </summary>
        /// <param name="networkInterface">An existing network interface.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithOS WithExistingPrimaryNetworkInterface(INetworkInterface networkInterface);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify private IP address within a virtual network subnet.
    /// </summary>
    public interface IWithPrivateIP 
    {
        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network subnet for
        /// virtual machine's primary network interface.
        /// </summary>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithPublicIPAddress WithPrimaryPrivateIPAddressDynamic();

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network subnet to the
        /// virtual machine's primary network interface.
        /// </summary>
        /// <param name="staticPrivateIPAddress">
        /// The static IP address within the specified subnet to assign to
        /// the network interface.
        /// </param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithPublicIPAddress WithPrimaryPrivateIPAddressStatic(string staticPrivateIPAddress);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify unmanaged data disk.
    /// </summary>
    public interface IWithUnmanagedDataDisk 
    {
        /// <summary>
        /// Specifies an existing unmanaged VHD that needs to be attached to the virtual machine as data disk.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="containerName">The name of the container holding the VHD file.</param>
        /// <param name="vhdName">The name for the VHD file.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithUnmanagedCreate WithExistingUnmanagedDataDisk(string storageAccountName, string containerName, string vhdName);

        /// <summary>
        /// Specifies that a new blank unmanaged data disk needs to be attached to virtual machine.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithUnmanagedCreate WithNewUnmanagedDataDisk(int sizeInGB);

        /// <summary>
        /// Begins definition of a unmanaged data disk to be attached to the virtual machine.
        /// </summary>
        /// <param name="name">The name for the data disk.</param>
        /// <return>The stage representing configuration for the unmanaged data disk.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.Definition.IBlank<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithUnmanagedCreate> DefineUnmanagedDataDisk(string name);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify virtual network for the new primary network
    /// interface or to use a creatable or existing network interface.
    /// </summary>
    public interface IWithNetwork  :
        IWithPrimaryNetworkInterface
    {
        /// <summary>
        /// Associate an existing virtual network with the the virtual machine's primary network interface.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithSubnet WithExistingPrimaryNetwork(INetwork network);

        /// <summary>
        /// Create a new virtual network to associate with the virtual machine's primary network interface, based on
        /// the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new virtual network.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithPrivateIP WithNewPrimaryNetwork(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetwork> creatable);

        /// <summary>
        /// Creates a new virtual network to associate with the virtual machine's primary network interface.
        /// the virtual network will be created in the same resource group and region as of virtual machine, it will be
        /// created with the specified address space and a default subnet covering the entirety of the network IP address space.
        /// </summary>
        /// <param name="addressSpace">The address space for the virtual network.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithPrivateIP WithNewPrimaryNetwork(string addressSpace);
    }

    /// <summary>
    /// The stage of the Windows virtual machine definition which contains all the minimum required inputs for
    /// the resource to be created (via WithCreate.create(), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithWindowsCreateManaged  :
        IWithFromImageCreateOptionsManaged
    {
        /// <summary>
        /// Specifies the WINRM listener.
        /// Each call to this method adds the given listener to the list of VM's WinRM listeners.
        /// </summary>
        /// <param name="listener">The WinRMListener.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateManaged WithWinRM(WinRMListener listener);

        /// <summary>
        /// Specifies that VM Agent should not be provisioned.
        /// </summary>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateManaged WithoutVMAgent();

        /// <summary>
        /// Specifies that automatic updates should be disabled.
        /// </summary>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateManaged WithoutAutoUpdate();

        /// <summary>
        /// Specifies the time-zone.
        /// </summary>
        /// <param name="timeZone">The timezone.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateManaged WithTimeZone(string timeZone);
    }

    /// <summary>
    /// The stage of the Windows virtual machine definition allowing to specify administrator user name.
    /// </summary>
    public interface IWithWindowsAdminPasswordManagedOrUnmanaged 
    {
        /// <summary>
        /// Specifies the administrator password for the Windows virtual machine.
        /// </summary>
        /// <param name="adminPassword">The administrator password. This must follow the criteria for Azure Windows VM password.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateManagedOrUnmanaged WithAdminPassword(string adminPassword);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify extensions.
    /// </summary>
    public interface IWithExtension 
    {
        /// <summary>
        /// Specifies definition of an extension to be attached to the virtual machine.
        /// </summary>
        /// <param name="name">The reference name for the extension.</param>
        /// <return>The stage representing configuration for the extension.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IBlank<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate> DefineNewExtension(string name);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>,
        IDefinitionWithTags<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate>,
        IWithOSDiskSettings,
        IWithVMSize,
        IWithStorageAccount,
        IWithAvailabilitySet,
        IWithSecondaryNetworkInterface,
        IWithExtension,
        IWithPlan
    {
    }

    /// <summary>
    /// The stage of the Windows virtual machine definition which contains all the minimum required inputs for
    /// the resource to be created (via WithCreate.create(), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithWindowsCreateUnmanaged  :
        IWithFromImageCreateOptionsUnmanaged
    {
        /// <summary>
        /// Specifies the WINRM listener.
        /// Each call to this method adds the given listener to the list of VM's WinRM listeners.
        /// </summary>
        /// <param name="listener">The WinRMListener.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateUnmanaged WithWinRM(WinRMListener listener);

        /// <summary>
        /// Specifies that VM Agent should not be provisioned.
        /// </summary>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateUnmanaged WithoutVMAgent();

        /// <summary>
        /// Specifies that automatic updates should be disabled.
        /// </summary>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateUnmanaged WithoutAutoUpdate();

        /// <summary>
        /// Specifies the time-zone.
        /// </summary>
        /// <param name="timeZone">The timezone.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateUnmanaged WithTimeZone(string timeZone);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify availability set.
    /// </summary>
    public interface IWithAvailabilitySet 
    {
        /// <summary>
        /// Specifies an existing AvailabilitySet availability set to to associate the virtual machine with.
        /// Adding virtual machines running your application to an availability set ensures that during
        /// maintenance event at least one virtual machine will be available.
        /// </summary>
        /// <param name="availabilitySet">An existing availability set.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithExistingAvailabilitySet(IAvailabilitySet availabilitySet);

        /// <summary>
        /// Specifies the name of a new availability set to associate the virtual machine with.
        /// Adding virtual machines running your application to an availability set ensures that during
        /// maintenance event at least one virtual machine will be available.
        /// </summary>
        /// <param name="name">The name of the availability set.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithNewAvailabilitySet(string name);

        /// <summary>
        /// Specifies definition of a not-yet-created availability set definition
        /// to associate the virtual machine with.
        /// Adding virtual machines running your application to an availability set ensures that during
        /// maintenance event at least one virtual machine will be available.
        /// </summary>
        /// <param name="creatable">The availability set in creatable stage.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithNewAvailabilitySet(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet> creatable);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the VM to be created and optionally allow unmanaged data disk and settings specific to
    /// unmanaged os disk to be specified.
    /// </summary>
    public interface IWithUnmanagedCreate  :
        IWithUnmanagedDataDisk,
        IWithCreate
    {
        /// <summary>
        /// Specifies the name of the OS Disk Vhd file and it's parent container.
        /// </summary>
        /// <param name="containerName">The name of the container in the selected storage account.</param>
        /// <param name="vhdName">The name for the OS Disk vhd.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithUnmanagedCreate WithOsDiskVhdLocation(string containerName, string vhdName);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to associate public IP address with it's primary network interface.
    /// </summary>
    public interface IWithPublicIPAddress 
    {
        /// <summary>
        /// Create a new public IP address to associate with virtual machine primary network interface, based on the
        /// provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithOS WithNewPrimaryPublicIPAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> creatable);

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associate it with the virtual machine's primary network interface.
        /// the internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">The leaf domain label.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithOS WithNewPrimaryPublicIPAddress(string leafDnsLabel);

        /// <summary>
        /// Specifies that no public IP needs to be associated with virtual machine.
        /// </summary>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithOS WithoutPrimaryPublicIPAddress();

        /// <summary>
        /// Associates an existing public IP address with the virtual machine's primary network interface.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithOS WithExistingPrimaryPublicIPAddress(IPublicIPAddress publicIPAddress);
    }

    /// <summary>
    /// The first stage of a virtual machine definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of the Linux virtual machine definition allowing to specify SSH root user name.
    /// </summary>
    public interface IWithLinuxRootUsernameManagedOrUnmanaged 
    {
        /// <summary>
        /// Specifies the SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">The Linux SSH root user name. This must follow the required naming convention for Linux user name.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManagedOrUnmanaged WithRootUsername(string rootUserName);
    }

    /// <summary>
    /// The stages contains OS agnostics settings when virtual machine is created from image.
    /// </summary>
    public interface IWithFromImageCreateOptionsUnmanaged  :
        IWithUnmanagedCreate
    {
        /// <summary>
        /// Specifies the custom data for the virtual machine.
        /// </summary>
        /// <param name="base64EncodedCustomData">The base64 encoded custom data.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged WithCustomData(string base64EncodedCustomData);

        /// <summary>
        /// Specifies the computer name for the virtual machine.
        /// </summary>
        /// <param name="computerName">The computer name.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged WithComputerName(string computerName);
    }

    /// <summary>
    /// The stage of the Windows virtual machine definition allowing to optionally choose unmanaged disk
    /// or continue definition of vm based on managed disk.
    /// </summary>
    public interface IWithWindowsCreateManagedOrUnmanaged  :
        IWithWindowsCreateManaged
    {
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateUnmanaged WithUnmanagedDisks();
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the VM to be created and optionally allow managed data disks specific settings to
    /// be specified.
    /// </summary>
    public interface IWithManagedCreate  :
        IWithManagedDataDisk,
        IWithCreate
    {
        /// <summary>
        /// Specifies the default caching type for the managed data disks.
        /// </summary>
        /// <param name="storageAccountType">The storage account type.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithDataDiskDefaultStorageAccountType(StorageAccountTypes storageAccountType);

        /// <summary>
        /// Specifies the default caching type for the managed data disks.
        /// </summary>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithDataDiskDefaultCachingType(CachingTypes cachingType);

        /// <summary>
        /// Specifies the storage account type for managed Os disk.
        /// </summary>
        /// <param name="accountType">The storage account type.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithOsDiskStorageAccountType(StorageAccountTypes accountType);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify virtual network subnet for the new primary network interface.
    /// </summary>
    public interface IWithSubnet 
    {
        /// <summary>
        /// Associates a subnet with the virtual machine's primary network interface.
        /// </summary>
        /// <param name="name">The subnet name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithPrivateIP WithSubnet(string name);
    }

    /// <summary>
    /// The stage of the Windows virtual machine definition allowing to specify administrator user name.
    /// </summary>
    public interface IWithWindowsAdminUsernameUnmanaged 
    {
        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">The Windows administrator user name. This must follow the required naming convention for Windows user name.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminPasswordUnmanaged WithAdminUsername(string adminUserName);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify purchase plan.
    /// </summary>
    public interface IWithPlan 
    {
        /// <summary>
        /// Specifies the plan for the virtual machine.
        /// </summary>
        /// <param name="plan">Describes the purchase plan.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithPlan(PurchasePlan plan);

        /// <summary>
        /// Specifies the plan for the virtual machine.
        /// </summary>
        /// <param name="plan">Describes the purchase plan.</param>
        /// <param name="promotionCode">The promotion code.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithPromotionalPlan(PurchasePlan plan, string promotionCode);
    }

    /// <summary>
    /// The stage of the Linux virtual machine definition which contains all the minimum required inputs for
    /// the resource to be created (via WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithLinuxCreateUnmanaged  :
        IWithFromImageCreateOptionsUnmanaged
    {
        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxCreateUnmanaged WithSsh(string publicKey);
    }

    /// <summary>
    /// The stage of the Linux virtual machine definition allowing to specify SSH root password or public key.
    /// </summary>
    public interface IWithLinuxRootPasswordOrPublicKeyManagedOrUnmanaged 
    {
        /// <summary>
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">The SSH root password. This must follow the criteria for Azure Linux VM password.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxCreateManagedOrUnmanaged WithRootPassword(string rootPassword);

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxCreateManagedOrUnmanaged WithSsh(string publicKey);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify managed data disk.
    /// </summary>
    public interface IWithManagedDataDisk 
    {
        /// <summary>
        /// Specifies the data disk to be created from the data disk image in the virtual machine image.
        /// </summary>
        /// <param name="imageLun">The lun of the source data disk image.</param>
        /// <return>The next stage of virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithNewDataDiskFromImage(int imageLun);

        /// <summary>
        /// Specifies the data disk to be created from the data disk image in the virtual machine image.
        /// </summary>
        /// <param name="imageLun">The lun of the source data disk image.</param>
        /// <param name="newSizeInGB">The new size that overrides the default size specified in the data disk image.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The next stage of virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithNewDataDiskFromImage(int imageLun, int newSizeInGB, CachingTypes cachingType);

        /// <summary>
        /// Specifies the data disk to be created from the data disk image in the virtual machine image.
        /// </summary>
        /// <param name="imageLun">The lun of the source data disk image.</param>
        /// <param name="newSizeInGB">The new size that overrides the default size specified in the data disk image.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <param name="storageAccountType">The storage account type.</param>
        /// <return>The next stage of virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithNewDataDiskFromImage(int imageLun, int newSizeInGB, CachingTypes cachingType, StorageAccountTypes storageAccountType);

        /// <summary>
        /// Specifies an existing source managed disk.
        /// </summary>
        /// <param name="disk">The managed disk.</param>
        /// <return>The next stage of virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithExistingDataDisk(IDisk disk);

        /// <summary>
        /// Specifies an existing source managed disk and settings.
        /// </summary>
        /// <param name="disk">The managed disk.</param>
        /// <param name="lun">The disk lun.</param>
        /// <return>The next stage of virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithExistingDataDisk(IDisk disk, int lun, CachingTypes cachingType);

        /// <summary>
        /// Specifies an existing source managed disk and settings.
        /// </summary>
        /// <param name="disk">The managed disk.</param>
        /// <param name="newSizeInGB">The disk resize size in GB.</param>
        /// <param name="lun">The disk lun.</param>
        /// <return>The next stage of virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithExistingDataDisk(IDisk disk, int newSizeInGB, int lun, CachingTypes cachingType);

        /// <summary>
        /// Specifies that a managed disk needs to be created explicitly with the given definition and
        /// attach to the virtual machine as data disk.
        /// </summary>
        /// <param name="creatable">The creatable disk.</param>
        /// <return>The next stage of virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithNewDataDisk(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IDisk> creatable);

        /// <summary>
        /// Specifies that a managed disk needs to be created explicitly with the given definition and
        /// attach to the virtual machine as data disk.
        /// </summary>
        /// <param name="creatable">The creatable disk.</param>
        /// <param name="lun">The data disk lun.</param>
        /// <param name="cachingType">The data disk caching type.</param>
        /// <return>The next stage of virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithNewDataDisk(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IDisk> creatable, int lun, CachingTypes cachingType);

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given size.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <return>The next stage of virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithNewDataDisk(int sizeInGB);

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk lun.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The next stage of virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType);

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk lun.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <param name="storageAccountType">The storage account type.</param>
        /// <return>The next stage of virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType, StorageAccountTypes storageAccountType);
    }

    /// <summary>
    /// The stage of the Windows virtual machine definition allowing to specify administrator user name.
    /// </summary>
    public interface IWithWindowsAdminUsernameManagedOrUnmanaged 
    {
        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">The Windows administrator user name. This must follow the required naming convention for Windows user name.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminPasswordManagedOrUnmanaged WithAdminUsername(string adminUserName);
    }

    /// <summary>
    /// The stage of the Windows virtual machine definition allowing to specify administrator user name.
    /// </summary>
    public interface IWithWindowsAdminUsernameManaged 
    {
        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">The Windows administrator user name. This must follow the required naming convention for Windows user name.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminPasswordManaged WithAdminUsername(string adminUserName);
    }

    /// <summary>
    /// The stage of the Windows virtual machine definition allowing to specify administrator user name.
    /// </summary>
    public interface IWithWindowsAdminPasswordManaged 
    {
        /// <summary>
        /// Specifies the administrator password for the Windows virtual machine.
        /// </summary>
        /// <param name="adminPassword">The administrator password. This must follow the criteria for Azure Windows VM password.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateManaged WithAdminPassword(string adminPassword);
    }

    /// <summary>
    /// The stage of the Linux virtual machine definition which contains all the minimum required inputs for
    /// the resource to be created (via WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithLinuxCreateManagedOrUnmanaged  :
        IWithFromImageCreateOptionsManagedOrUnmanaged
    {
        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxCreateManagedOrUnmanaged WithSsh(string publicKey);
    }

    /// <summary>
    /// The stage of the Windows virtual machine definition allowing to specify administrator user name.
    /// </summary>
    public interface IWithWindowsAdminPasswordUnmanaged 
    {
        /// <summary>
        /// Specifies the administrator password for the Windows virtual machine.
        /// </summary>
        /// <param name="adminPassword">The administrator password. This must follow the criteria for Azure Windows VM password.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateUnmanaged WithAdminPassword(string adminPassword);
    }

    /// <summary>
    /// The stage of the Linux virtual machine definition allowing to specify SSH root user name.
    /// </summary>
    public interface IWithLinuxRootUsernameUnmanaged 
    {
        /// <summary>
        /// Specifies the SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">The Linux SSH root user name. This must follow the required naming convention for Linux user name.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyUnmanaged WithRootUsername(string rootUserName);
    }

    /// <summary>
    /// The stage of virtual machine definition allowing to specify additional network interfaces.
    /// </summary>
    public interface IWithSecondaryNetworkInterface 
    {
        /// <summary>
        /// Associate an existing network interface with the virtual machine.
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="networkInterface">An existing network interface.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithExistingSecondaryNetworkInterface(INetworkInterface networkInterface);

        /// <summary>
        /// Create a new network interface to associate with the virtual machine, based on the
        /// provided definition.
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new network interface.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithNewSecondaryNetworkInterface(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface> creatable);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify storage account.
    /// </summary>
    public interface IWithStorageAccount 
    {
        /// <summary>
        /// Specifies the name of a new storage account to put the VM's OS and data disk VHD in.
        /// Only the OS disk based on marketplace image will be stored in the new storage account,
        /// an OS disk based on user image will be stored in the same storage account as user image.
        /// </summary>
        /// <param name="name">The name of the storage account.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithNewStorageAccount(string name);

        /// <summary>
        /// Specifies definition of a not-yet-created storage account definition
        /// to put the VM's OS and data disk VHDs in.
        /// Only the OS disk based on marketplace image will be stored in the new storage account.
        /// An OS disk based on user image will be stored in the same storage account as user image.
        /// </summary>
        /// <param name="creatable">The storage account in creatable stage.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable);

        /// <summary>
        /// Specifies an existing StorageAccount storage account to put the VM's OS and data disk VHD in.
        /// An OS disk based on marketplace or user image (generalized image) will be stored in this
        /// storage account.
        /// </summary>
        /// <param name="storageAccount">An existing storage account.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithExistingStorageAccount(IStorageAccount storageAccount);
    }

    /// <summary>
    /// The stage of the Linux virtual machine definition allowing to specify SSH root password or public key.
    /// </summary>
    public interface IWithLinuxRootPasswordOrPublicKeyManaged 
    {
        /// <summary>
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">The SSH root password. This must follow the criteria for Azure Linux VM password.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxCreateManaged WithRootPassword(string rootPassword);

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxCreateManaged WithSsh(string publicKey);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithNetwork>
    {
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify OS disk configurations.
    /// </summary>
    public interface IWithOSDiskSettings 
    {
        /// <summary>
        /// Specifies the size of the OSDisk in GB.
        /// </summary>
        /// <param name="size">The VHD size.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithOSDiskSizeInGB(int size);

        /// <summary>
        /// Specifies the caching type for the Operating System disk.
        /// </summary>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithOSDiskCaching(CachingTypes cachingType);

        /// <summary>
        /// Specifies the name for the OS Disk.
        /// </summary>
        /// <param name="name">The OS Disk name.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithOSDiskName(string name);

        /// <summary>
        /// Specifies the encryption settings for the OS Disk.
        /// </summary>
        /// <param name="settings">The encryption settings.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithOSDiskEncryptionSettings(DiskEncryptionSettings settings);
    }

    /// <summary>
    /// The stage of the Linux virtual machine definition allowing to specify SSH root password or public key.
    /// </summary>
    public interface IWithLinuxRootPasswordOrPublicKeyUnmanaged 
    {
        /// <summary>
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">The SSH root password. This must follow the criteria for Azure Linux VM password.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxCreateUnmanaged WithRootPassword(string rootPassword);

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxCreateUnmanaged WithSsh(string publicKey);
    }
}