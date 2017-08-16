// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.DefinitionManaged;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.DefinitionManagedOrUnmanaged;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.DefinitionUnmanaged;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Update;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.UpdateDefinition;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.Update;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Rest;
    using System;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;

    internal partial class VirtualMachineImpl
    {
        /// <summary>
        /// Specifies an SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">A user name following the required naming convention for Linux user names.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyUnmanaged VirtualMachine.Definition.IWithLinuxRootUsernameUnmanaged.WithRootUsername(string rootUserName)
        {
            return this.WithRootUsername(rootUserName) as VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyUnmanaged;
        }

        /// <summary>
        /// Specifies an SSH public key.
        /// </summary>
        /// <param name="publicKey">An SSH public key in the PEM format.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithLinuxCreateUnmanaged VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyUnmanaged.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey) as VirtualMachine.Definition.IWithLinuxCreateUnmanaged;
        }

        /// <summary>
        /// Specifies an SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">A password following the complexity criteria for Azure Linux VM passwords.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithLinuxCreateUnmanaged VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyUnmanaged.WithRootPassword(string rootPassword)
        {
            return this.WithRootPassword(rootPassword) as VirtualMachine.Definition.IWithLinuxCreateUnmanaged;
        }

        /// <summary>
        /// Specifies that unmanaged disks will be used.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged VirtualMachine.Definition.IWithFromImageCreateOptionsManagedOrUnmanaged.WithUnmanagedDisks()
        {
            return this.WithUnmanagedDisks() as VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged;
        }

        /// <summary>
        /// Specifies the purchase plan for the virtual machine.
        /// </summary>
        /// <param name="plan">A purchase plan.</param>
        /// <param name="promotionCode">A promotion code.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithPlan.WithPromotionalPlan(PurchasePlan plan, string promotionCode)
        {
            return this.WithPromotionalPlan(plan, promotionCode) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the purchase plan for the virtual machine.
        /// </summary>
        /// <param name="plan">A purchase plan.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithPlan.WithPlan(PurchasePlan plan)
        {
            return this.WithPlan(plan) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Associates a subnet with the virtual machine's primary network interface.
        /// </summary>
        /// <param name="name">The subnet name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithPrivateIP VirtualMachine.Definition.IWithSubnet.WithSubnet(string name)
        {
            return this.WithSubnet(name) as VirtualMachine.Definition.IWithPrivateIP;
        }

        /// <summary>
        /// Creates a new public IP address to associate with the VM's primary network interface.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithOS VirtualMachine.Definition.IWithPublicIPAddress.WithNewPrimaryPublicIPAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> creatable)
        {
            return this.WithNewPrimaryPublicIPAddress(creatable) as VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and resource group as the resource, with the specified DNS label
        /// and associates it with the VM's primary network interface.
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">A leaf domain label.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithOS VirtualMachine.Definition.IWithPublicIPAddress.WithNewPrimaryPublicIPAddress(string leafDnsLabel)
        {
            return this.WithNewPrimaryPublicIPAddress(leafDnsLabel) as VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Specifies that the VM should not have a public IP address.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithOS VirtualMachine.Definition.IWithPublicIPAddress.WithoutPrimaryPublicIPAddress()
        {
            return this.WithoutPrimaryPublicIPAddress() as VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Associates an existing public IP address with the VM's primary network interface.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithOS VirtualMachine.Definition.IWithPublicIPAddress.WithExistingPrimaryPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return this.WithExistingPrimaryPublicIPAddress(publicIPAddress) as VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Specifies an SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">A user name following the required naming convention for Linux user names.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManagedOrUnmanaged VirtualMachine.Definition.IWithLinuxRootUsernameManagedOrUnmanaged.WithRootUsername(string rootUserName)
        {
            return this.WithRootUsername(rootUserName) as VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies that a managed disk should be created explicitly with the given definition and
        /// attached to the virtual machine as a data disk.
        /// </summary>
        /// <param name="creatable">A creatable disk definition.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithNewDataDisk(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IDisk> creatable)
        {
            return this.WithNewDataDisk(creatable) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created explicitly with the given definition and
        /// attach to the virtual machine as data disk.
        /// </summary>
        /// <param name="creatable">A creatable disk.</param>
        /// <param name="lun">The data disk LUN.</param>
        /// <param name="cachingType">A data disk caching type.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithNewDataDisk(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IDisk> creatable, int lun, CachingTypes cachingType)
        {
            return this.WithNewDataDisk(creatable, lun, cachingType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given size.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk in GB.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithNewDataDisk(int sizeInGB)
        {
            return this.WithNewDataDisk(sizeInGB) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk in GB.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType)
        {
            return this.WithNewDataDisk(sizeInGB, lun, cachingType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk in GB.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <param name="storageAccountType">The storage account type.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType, StorageAccountTypes storageAccountType)
        {
            return this.WithNewDataDisk(sizeInGB, lun, cachingType, storageAccountType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Associates an existing source managed disk with the virtual machine.
        /// </summary>
        /// <param name="disk">An existing managed disk.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithExistingDataDisk(IDisk disk)
        {
            return this.WithExistingDataDisk(disk) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Associates an existing source managed disk with the virtual machine and specifies additional settings.
        /// </summary>
        /// <param name="disk">A managed disk.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithExistingDataDisk(IDisk disk, int lun, CachingTypes cachingType)
        {
            return this.WithExistingDataDisk(disk, lun, cachingType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Associates an existing source managed disk with the virtual machine and specifies additional settings.
        /// </summary>
        /// <param name="disk">A managed disk.</param>
        /// <param name="newSizeInGB">The disk resize size in GB.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithExistingDataDisk(IDisk disk, int newSizeInGB, int lun, CachingTypes cachingType)
        {
            return this.WithExistingDataDisk(disk, newSizeInGB, lun, cachingType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies the data disk to be created from the data disk image in the virtual machine image.
        /// </summary>
        /// <param name="imageLun">The LUN of the source data disk image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithNewDataDiskFromImage(int imageLun)
        {
            return this.WithNewDataDiskFromImage(imageLun) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies the data disk to be created from the data disk image in the virtual machine image.
        /// </summary>
        /// <param name="imageLun">The LUN of the source data disk image.</param>
        /// <param name="newSizeInGB">The new size that overrides the default size specified in the data disk image.</param>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithNewDataDiskFromImage(int imageLun, int newSizeInGB, CachingTypes cachingType)
        {
            return this.WithNewDataDiskFromImage(imageLun, newSizeInGB, cachingType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies the data disk to be created from the data disk image in the virtual machine image.
        /// </summary>
        /// <param name="imageLun">The LUN of the source data disk image.</param>
        /// <param name="newSizeInGB">The new size that overrides the default size specified in the data disk image.</param>
        /// <param name="cachingType">A caching type.</param>
        /// <param name="storageAccountType">A storage account type.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithNewDataDiskFromImage(int imageLun, int newSizeInGB, CachingTypes cachingType, StorageAccountTypes storageAccountType)
        {
            return this.WithNewDataDiskFromImage(imageLun, newSizeInGB, cachingType, storageAccountType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created explicitly with the given definition and
        /// attached to the virtual machine as a data disk.
        /// </summary>
        /// <param name="creatable">A creatable disk definition.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithManagedDataDisk.WithNewDataDisk(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IDisk> creatable)
        {
            return this.WithNewDataDisk(creatable) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created explicitly with the given definition and
        /// attached to the virtual machine as a data disk.
        /// </summary>
        /// <param name="creatable">A creatable disk definition.</param>
        /// <param name="lun">The data disk LUN.</param>
        /// <param name="cachingType">A data disk caching type.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithManagedDataDisk.WithNewDataDisk(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IDisk> creatable, int lun, CachingTypes cachingType)
        {
            return this.WithNewDataDisk(creatable, lun, cachingType) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given size.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithManagedDataDisk.WithNewDataDisk(int sizeInGB)
        {
            return this.WithNewDataDisk(sizeInGB) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithManagedDataDisk.WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType)
        {
            return this.WithNewDataDisk(sizeInGB, lun, cachingType) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">A caching type.</param>
        /// <param name="storageAccountType">A storage account type.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithManagedDataDisk.WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType, StorageAccountTypes storageAccountType)
        {
            return this.WithNewDataDisk(sizeInGB, lun, cachingType, storageAccountType) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Detaches a managed data disk with the given LUN from the virtual machine.
        /// </summary>
        /// <param name="lun">The disk LUN.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithManagedDataDisk.WithoutDataDisk(int lun)
        {
            return this.WithoutDataDisk(lun) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing source managed disk with the VM.
        /// </summary>
        /// <param name="disk">A managed disk.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithManagedDataDisk.WithExistingDataDisk(IDisk disk)
        {
            return this.WithExistingDataDisk(disk) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies an existing source managed disk and settings.
        /// </summary>
        /// <param name="disk">The managed disk.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithManagedDataDisk.WithExistingDataDisk(IDisk disk, int lun, CachingTypes cachingType)
        {
            return this.WithExistingDataDisk(disk, lun, cachingType) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies an existing source managed disk and settings.
        /// </summary>
        /// <param name="disk">A managed disk.</param>
        /// <param name="newSizeInGB">The disk resize size in GB.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithManagedDataDisk.WithExistingDataDisk(IDisk disk, int newSizeInGB, int lun, CachingTypes cachingType)
        {
            return this.WithExistingDataDisk(disk, newSizeInGB, lun, cachingType) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Gets the list of resource IDs of the network interfaces associated with this resource.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Network.Fluent.IHasNetworkInterfaces.NetworkInterfaceIds
        {
            get
            {
                return this.NetworkInterfaceIds() as System.Collections.Generic.IReadOnlyList<string>;
            }
        }

        /// <summary>
        /// Gets the primary network interface.
        /// Note that this method can result in a call to the cloud to fetch the network interface information.
        /// </summary>
        /// <return>The primary network interface associated with this resource.</return>
        Microsoft.Azure.Management.Network.Fluent.INetworkInterface Microsoft.Azure.Management.Network.Fluent.IHasNetworkInterfaces.GetPrimaryNetworkInterface()
        {
            return this.GetPrimaryNetworkInterface() as Microsoft.Azure.Management.Network.Fluent.INetworkInterface;
        }

        /// <summary>
        /// Gets the resource id of the primary network interface associated with this resource.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IHasNetworkInterfaces.PrimaryNetworkInterfaceId
        {
            get
            {
                return this.PrimaryNetworkInterfaceId();
            }
        }

        /// <summary>
        /// Specifies the name of an OS disk VHD file and its parent container.
        /// </summary>
        /// <param name="containerName">The name of the container in the selected storage account.</param>
        /// <param name="vhdName">The name for the OS disk VHD.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithUnmanagedCreate VirtualMachine.Definition.IWithUnmanagedCreate.WithOSDiskVhdLocation(string containerName, string vhdName)
        {
            return this.WithOSDiskVhdLocation(containerName, vhdName) as VirtualMachine.Definition.IWithUnmanagedCreate;
        }

        /// <summary>
        /// Specifies the name for the OS Disk.
        /// </summary>
        /// <param name="name">An OS disk name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithOSDiskSettings.WithOSDiskName(string name)
        {
            return this.WithOSDiskName(name) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the size of the OSDisk in GB.
        /// </summary>
        /// <param name="size">The VHD size.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithOSDiskSettings.WithOSDiskSizeInGB(int size)
        {
            return this.WithOSDiskSizeInGB(size) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the caching type for the OS disk.
        /// </summary>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithOSDiskSettings.WithOSDiskCaching(CachingTypes cachingType)
        {
            return this.WithOSDiskCaching(cachingType) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the encryption settings for the OS Disk.
        /// </summary>
        /// <param name="settings">The encryption settings.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithOSDiskSettings.WithOSDiskEncryptionSettings(DiskEncryptionSettings settings)
        {
            return this.WithOSDiskEncryptionSettings(settings) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that the latest version of a marketplace Linux image is to be used as the virtual machine's OS.
        /// </summary>
        /// <param name="publisher">Specifies the publisher of an image.</param>
        /// <param name="offer">Specifies an offer of the image.</param>
        /// <param name="sku">Specifies a SKU of the image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithLinuxRootUsernameManagedOrUnmanaged VirtualMachine.Definition.IWithOS.WithLatestLinuxImage(string publisher, string offer, string sku)
        {
            return this.WithLatestLinuxImage(publisher, offer, sku) as VirtualMachine.Definition.IWithLinuxRootUsernameManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies that the latest version of a marketplace Windows image should to be used as the virtual machine's OS.
        /// </summary>
        /// <param name="publisher">Specifies the publisher of the image.</param>
        /// <param name="offer">Specifies the offer of the image.</param>
        /// <param name="sku">Specifies the SKU of the image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged VirtualMachine.Definition.IWithOS.WithLatestWindowsImage(string publisher, string offer, string sku)
        {
            return this.WithLatestWindowsImage(publisher, offer, sku) as VirtualMachine.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies the user (generalized) Windows image to be used for the virtual machine's OS.
        /// </summary>
        /// <param name="imageUrl">The URL of a VHD.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithWindowsAdminUsernameUnmanaged VirtualMachine.Definition.IWithOS.WithStoredWindowsImage(string imageUrl)
        {
            return this.WithStoredWindowsImage(imageUrl) as VirtualMachine.Definition.IWithWindowsAdminUsernameUnmanaged;
        }

        /// <summary>
        /// Specifies a version of a marketplace Windows image to be used as the virtual machine's OS.
        /// </summary>
        /// <param name="imageReference">Describes publisher, offer, SKU and version of the market-place image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged VirtualMachine.Definition.IWithOS.WithSpecificWindowsImageVersion(ImageReference imageReference)
        {
            return this.WithSpecificWindowsImageVersion(imageReference) as VirtualMachine.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies a user (generalized) Linux image to be used for the virtual machine's OS.
        /// </summary>
        /// <param name="imageUrl">The URL of a VHD.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithLinuxRootUsernameUnmanaged VirtualMachine.Definition.IWithOS.WithStoredLinuxImage(string imageUrl)
        {
            return this.WithStoredLinuxImage(imageUrl) as VirtualMachine.Definition.IWithLinuxRootUsernameUnmanaged;
        }

        /// <summary>
        /// Specifies a specialized operating system unmanaged disk to be attached to the virtual machine.
        /// </summary>
        /// <param name="osDiskUrl">OsDiskUrl the URL to the OS disk in the Azure Storage account.</param>
        /// <param name="osType">The OS type.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithUnmanagedCreate VirtualMachine.Definition.IWithOS.WithSpecializedOSUnmanagedDisk(string osDiskUrl, OperatingSystemTypes osType)
        {
            return this.WithSpecializedOSUnmanagedDisk(osDiskUrl, osType) as VirtualMachine.Definition.IWithUnmanagedCreate;
        }

        /// <summary>
        /// Specifies a known marketplace Windows image to be used for the virtual machine's OS.
        /// </summary>
        /// <param name="knownImage">A known market-place image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged VirtualMachine.Definition.IWithOS.WithPopularWindowsImage(KnownWindowsVirtualMachineImage knownImage)
        {
            return this.WithPopularWindowsImage(knownImage) as VirtualMachine.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies a known marketplace Linux image to be used for the virtual machine's OS.
        /// </summary>
        /// <param name="knownImage">A known market-place image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithLinuxRootUsernameManagedOrUnmanaged VirtualMachine.Definition.IWithOS.WithPopularLinuxImage(KnownLinuxVirtualMachineImage knownImage)
        {
            return this.WithPopularLinuxImage(knownImage) as VirtualMachine.Definition.IWithLinuxRootUsernameManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies a version of a market-place Linux image to be used as the virtual machine's OS.
        /// </summary>
        /// <param name="imageReference">Describes the publisher, offer, SKU and version of the market-place image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithLinuxRootUsernameManagedOrUnmanaged VirtualMachine.Definition.IWithOS.WithSpecificLinuxImageVersion(ImageReference imageReference)
        {
            return this.WithSpecificLinuxImageVersion(imageReference) as VirtualMachine.Definition.IWithLinuxRootUsernameManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies the resource ID of a Windows custom image to be used as the virtual machine's OS.
        /// </summary>
        /// <param name="customImageId">The resource ID of the custom image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithWindowsAdminUsernameManaged VirtualMachine.Definition.IWithOS.WithWindowsCustomImage(string customImageId)
        {
            return this.WithWindowsCustomImage(customImageId) as VirtualMachine.Definition.IWithWindowsAdminUsernameManaged;
        }

        /// <summary>
        /// Specifies the resource ID of a Linux custom image to be used as the virtual machines' OS.
        /// </summary>
        /// <param name="customImageId">The resource ID of a custom image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithLinuxRootUsernameManaged VirtualMachine.Definition.IWithOS.WithLinuxCustomImage(string customImageId)
        {
            return this.WithLinuxCustomImage(customImageId) as VirtualMachine.Definition.IWithLinuxRootUsernameManaged;
        }

        /// <summary>
        /// Specifies a specialized operating system managed disk to be attached to the virtual machine.
        /// </summary>
        /// <param name="disk">The managed disk to attach.</param>
        /// <param name="osType">The OS type.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithOS.WithSpecializedOSDisk(IDisk disk, OperatingSystemTypes osType)
        {
            return this.WithSpecializedOSDisk(disk, osType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies the size of the OS disk in GB.
        /// Only unmanaged disks may be resized as part of a VM update. Managed disks must be resized separately, using managed disk API.
        /// </summary>
        /// <param name="size">A disk size.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IUpdate.WithOSDiskSizeInGB(int size)
        {
            return this.WithOSDiskSizeInGB(size) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the default caching type for the managed data disks.
        /// </summary>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IUpdate.WithDataDiskDefaultCachingType(CachingTypes cachingType)
        {
            return this.WithDataDiskDefaultCachingType(cachingType) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a new size for the virtual machine.
        /// </summary>
        /// <param name="sizeName">The name of a size for the virtual machine as text.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IUpdate.WithSize(string sizeName)
        {
            return this.WithSize(sizeName) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a new size for the virtual machine.
        /// </summary>
        /// <param name="size">A size from the list of available sizes for the virtual machine.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IUpdate.WithSize(VirtualMachineSizeTypes size)
        {
            return this.WithSize(size) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the caching type for the OS disk.
        /// </summary>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IUpdate.WithOSDiskCaching(CachingTypes cachingType)
        {
            return this.WithOSDiskCaching(cachingType) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a storage account type.
        /// </summary>
        /// <param name="storageAccountType">A storage account type.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IUpdate.WithDataDiskDefaultStorageAccountType(StorageAccountTypes storageAccountType)
        {
            return this.WithDataDiskDefaultStorageAccountType(storageAccountType) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the encryption settings for the OS Disk.
        /// </summary>
        /// <param name="settings">The encryption settings.</param>
        /// <return>The stage representing creatable VM update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IUpdate.WithOSDiskEncryptionSettings(DiskEncryptionSettings settings)
        {
            return this.WithOSDiskEncryptionSettings(settings) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Selects the size of the virtual machine.
        /// </summary>
        /// <param name="sizeName">The name of a size for the virtual machine as text.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithVMSize.WithSize(string sizeName)
        {
            return this.WithSize(sizeName) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the size of the virtual machine.
        /// </summary>
        /// <param name="size">A size from the list of available sizes for the virtual machine.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithVMSize.WithSize(VirtualMachineSizeTypes size)
        {
            return this.WithSize(size) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">A user name following the required naming convention for Windows user names.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithWindowsAdminPasswordManagedOrUnmanaged VirtualMachine.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged.WithAdminUsername(string adminUserName)
        {
            return this.WithAdminUsername(adminUserName) as VirtualMachine.Definition.IWithWindowsAdminPasswordManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies an SSH public key.
        /// </summary>
        /// <param name="publicKey">An SSH public key in the PEM format.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithLinuxCreateManagedOrUnmanaged VirtualMachine.Definition.IWithLinuxCreateManagedOrUnmanaged.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey) as VirtualMachine.Definition.IWithLinuxCreateManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies the time-zone.
        /// </summary>
        /// <param name="timeZone">The timezone.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachine.Definition.IWithWindowsCreateUnmanaged VirtualMachine.Definition.IWithWindowsCreateUnmanaged.WithTimeZone(string timeZone)
        {
            return this.WithTimeZone(timeZone) as VirtualMachine.Definition.IWithWindowsCreateUnmanaged;
        }

        /// <summary>
        /// Specifies that VM Agent should not be provisioned.
        /// </summary>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachine.Definition.IWithWindowsCreateUnmanaged VirtualMachine.Definition.IWithWindowsCreateUnmanaged.WithoutVMAgent()
        {
            return this.WithoutVMAgent() as VirtualMachine.Definition.IWithWindowsCreateUnmanaged;
        }

        /// <summary>
        /// Specifies the WINRM listener.
        /// Each call to this method adds the given listener to the list of VM's WinRM listeners.
        /// </summary>
        /// <param name="listener">The WinRMListener.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachine.Definition.IWithWindowsCreateUnmanaged VirtualMachine.Definition.IWithWindowsCreateUnmanaged.WithWinRM(WinRMListener listener)
        {
            return this.WithWinRM(listener) as VirtualMachine.Definition.IWithWindowsCreateUnmanaged;
        }

        /// <summary>
        /// Specifies that automatic updates should be disabled.
        /// </summary>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachine.Definition.IWithWindowsCreateUnmanaged VirtualMachine.Definition.IWithWindowsCreateUnmanaged.WithoutAutoUpdate()
        {
            return this.WithoutAutoUpdate() as VirtualMachine.Definition.IWithWindowsCreateUnmanaged;
        }

        /// <summary>
        /// Specifies the default caching type for the managed data disks.
        /// </summary>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of teh definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedCreate.WithDataDiskDefaultCachingType(CachingTypes cachingType)
        {
            return this.WithDataDiskDefaultCachingType(cachingType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies the default caching type for managed data disks.
        /// </summary>
        /// <param name="storageAccountType">A storage account type.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedCreate.WithDataDiskDefaultStorageAccountType(StorageAccountTypes storageAccountType)
        {
            return this.WithDataDiskDefaultStorageAccountType(storageAccountType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies the storage account type for the managed OS disk.
        /// </summary>
        /// <param name="accountType">Storage account type.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedCreate.WithOSDiskStorageAccountType(StorageAccountTypes accountType)
        {
            return this.WithOSDiskStorageAccountType(accountType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Associates an existing network interface with the virtual machine.
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="networkInterface">An existing network interface.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithSecondaryNetworkInterface.WithExistingSecondaryNetworkInterface(INetworkInterface networkInterface)
        {
            return this.WithExistingSecondaryNetworkInterface(networkInterface) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a new network interface to associate with the virtual machine, based on the
        /// provided definition.
        /// Note this method's effect is additive, i.e. each time it is used, a new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new network interface.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithSecondaryNetworkInterface.WithNewSecondaryNetworkInterface(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface> creatable)
        {
            return this.WithNewSecondaryNetworkInterface(creatable) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Associates an existing network interface with the virtual machine.
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="networkInterface">An existing network interface.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithSecondaryNetworkInterface.WithExistingSecondaryNetworkInterface(INetworkInterface networkInterface)
        {
            return this.WithExistingSecondaryNetworkInterface(networkInterface) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new network interface to associate with the virtual machine.
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new network interface.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithSecondaryNetworkInterface.WithNewSecondaryNetworkInterface(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface> creatable)
        {
            return this.WithNewSecondaryNetworkInterface(creatable) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Removes a secondary network interface from the virtual machine.
        /// </summary>
        /// <param name="name">The name of a secondary network interface to remove.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithSecondaryNetworkInterface.WithoutSecondaryNetworkInterface(string name)
        {
            return this.WithoutSecondaryNetworkInterface(name) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies an SSH public key.
        /// </summary>
        /// <param name="publicKey">An SSH public key in the PEM format.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithLinuxCreateManaged VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManaged.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey) as VirtualMachine.Definition.IWithLinuxCreateManaged;
        }

        /// <summary>
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">A password, following the complexity criteria for Azure Linux VM passwords.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithLinuxCreateManaged VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManaged.WithRootPassword(string rootPassword)
        {
            return this.WithRootPassword(rootPassword) as VirtualMachine.Definition.IWithLinuxCreateManaged;
        }

        /// <summary>
        /// Specifies the time-zone.
        /// </summary>
        /// <param name="timeZone">A time zone.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithWindowsCreateManaged VirtualMachine.Definition.IWithWindowsCreateManaged.WithTimeZone(string timeZone)
        {
            return this.WithTimeZone(timeZone) as VirtualMachine.Definition.IWithWindowsCreateManaged;
        }

        /// <summary>
        /// Prevents the provisioning of a VM agent.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithWindowsCreateManaged VirtualMachine.Definition.IWithWindowsCreateManaged.WithoutVMAgent()
        {
            return this.WithoutVMAgent() as VirtualMachine.Definition.IWithWindowsCreateManaged;
        }

        /// <summary>
        /// Specifies  WinRM listener.
        /// Each call to this method adds the given listener to the list of the VM's WinRM listeners.
        /// </summary>
        /// <param name="listener">A WinRM listener.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithWindowsCreateManaged VirtualMachine.Definition.IWithWindowsCreateManaged.WithWinRM(WinRMListener listener)
        {
            return this.WithWinRM(listener) as VirtualMachine.Definition.IWithWindowsCreateManaged;
        }

        /// <summary>
        /// Disables automatic updates.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithWindowsCreateManaged VirtualMachine.Definition.IWithWindowsCreateManaged.WithoutAutoUpdate()
        {
            return this.WithoutAutoUpdate() as VirtualMachine.Definition.IWithWindowsCreateManaged;
        }

        /// <summary>
        /// Begins definition of an unmanaged data disk to be attached to the virtual machine.
        /// </summary>
        /// <param name="name">The name for the data disk.</param>
        /// <return>The first stage of an unmanaged data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.Definition.IBlank<VirtualMachine.Definition.IWithUnmanagedCreate> VirtualMachine.Definition.IWithUnmanagedDataDisk.DefineUnmanagedDataDisk(string name)
        {
            return this.DefineUnmanagedDataDisk(name) as VirtualMachineUnmanagedDataDisk.Definition.IBlank<VirtualMachine.Definition.IWithUnmanagedCreate>;
        }

        /// <summary>
        /// Attaches a new blank unmanaged data disk to the virtual machine.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithUnmanagedCreate VirtualMachine.Definition.IWithUnmanagedDataDisk.WithNewUnmanagedDataDisk(int sizeInGB)
        {
            return this.WithNewUnmanagedDataDisk(sizeInGB) as VirtualMachine.Definition.IWithUnmanagedCreate;
        }

        /// <summary>
        /// Attaches an existing unmanaged VHD as a data disk to the virtual machine.
        /// </summary>
        /// <param name="storageAccountName">A storage account name.</param>
        /// <param name="containerName">The name of the container holding the VHD file.</param>
        /// <param name="vhdName">The name for the VHD file.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithUnmanagedCreate VirtualMachine.Definition.IWithUnmanagedDataDisk.WithExistingUnmanagedDataDisk(string storageAccountName, string containerName, string vhdName)
        {
            return this.WithExistingUnmanagedDataDisk(storageAccountName, containerName, vhdName) as VirtualMachine.Definition.IWithUnmanagedCreate;
        }

        /// <summary>
        /// Begins the definition of a blank unmanaged data disk to be attached to the virtual machine along with its configuration.
        /// </summary>
        /// <param name="name">The name for the data disk.</param>
        /// <return>The first stage of the data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.UpdateDefinition.IBlank<VirtualMachine.Update.IUpdate> VirtualMachine.Update.IWithUnmanagedDataDisk.DefineUnmanagedDataDisk(string name)
        {
            return this.DefineUnmanagedDataDisk(name) as VirtualMachineUnmanagedDataDisk.UpdateDefinition.IBlank<VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update of an existing unmanaged data disk of this virtual machine.
        /// </summary>
        /// <param name="name">The name of an existing disk.</param>
        /// <return>The first stage of the data disk update.</return>
        VirtualMachineUnmanagedDataDisk.Update.IUpdate VirtualMachine.Update.IWithUnmanagedDataDisk.UpdateUnmanagedDataDisk(string name)
        {
            return this.UpdateUnmanagedDataDisk(name) as VirtualMachineUnmanagedDataDisk.Update.IUpdate;
        }

        /// <summary>
        /// Detaches an unmanaged data disk from the virtual machine.
        /// </summary>
        /// <param name="name">The name of an existing data disk to remove.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithUnmanagedDataDisk.WithoutUnmanagedDataDisk(string name)
        {
            return this.WithoutUnmanagedDataDisk(name) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Detaches a unmanaged data disk from the virtual machine.
        /// </summary>
        /// <param name="lun">The logical unit number of the data disk to remove.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithUnmanagedDataDisk.WithoutUnmanagedDataDisk(int lun)
        {
            return this.WithoutUnmanagedDataDisk(lun) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that a new blank unmanaged data disk needs to be attached to virtual machine.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithUnmanagedDataDisk.WithNewUnmanagedDataDisk(int sizeInGB)
        {
            return this.WithNewUnmanagedDataDisk(sizeInGB) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies an existing VHD that needs to be attached to the virtual machine as data disk.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="containerName">The name of the container holding the VHD file.</param>
        /// <param name="vhdName">The name for the VHD file.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithUnmanagedDataDisk.WithExistingUnmanagedDataDisk(string storageAccountName, string containerName, string vhdName)
        {
            return this.WithExistingUnmanagedDataDisk(storageAccountName, containerName, vhdName) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the administrator password for the Windows virtual machine.
        /// </summary>
        /// <param name="adminPassword">A password following the criteria for Azure Windows VM passwords.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithWindowsCreateUnmanaged VirtualMachine.Definition.IWithWindowsAdminPasswordUnmanaged.WithAdminPassword(string adminPassword)
        {
            return this.WithAdminPassword(adminPassword) as VirtualMachine.Definition.IWithWindowsCreateUnmanaged;
        }

        /// <summary>
        /// Specifies the definition of a not-yet-created storage account
        /// to put the VM's OS and data disk VHDs into.
        /// Only the OS disk based on a marketplace image will be stored in the new storage account.
        /// An OS disk based on a user image will be stored in the same storage account as the user image.
        /// </summary>
        /// <param name="creatable">A creatable storage account definition.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithStorageAccount.WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable)
        {
            return this.WithNewStorageAccount(creatable) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the name of a new storage account to put the VM's OS and data disk VHD into.
        /// Only an OS disk based on a marketplace image will be stored in the new storage account.
        /// An OS disk based on a user image will be stored in the same storage account as the user image.
        /// </summary>
        /// <param name="name">The name for a new storage account.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithStorageAccount.WithNewStorageAccount(string name)
        {
            return this.WithNewStorageAccount(name) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies an existing storage account to put the VM's OS and data disk VHD in.
        /// An OS disk based on a marketplace or a user image (generalized image) will be stored in this
        /// storage account.
        /// </summary>
        /// <param name="storageAccount">An existing storage account.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithStorageAccount.WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            return this.WithExistingStorageAccount(storageAccount) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a new network interface to associate with the virtual machine as its primary network interface,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new network interface.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithOS VirtualMachine.Definition.IWithPrimaryNetworkInterface.WithNewPrimaryNetworkInterface(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface> creatable)
        {
            return this.WithNewPrimaryNetworkInterface(creatable) as VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Associates an existing network interface with the virtual machine as its primary network interface.
        /// </summary>
        /// <param name="networkInterface">An existing network interface.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithOS VirtualMachine.Definition.IWithPrimaryNetworkInterface.WithExistingPrimaryNetworkInterface(INetworkInterface networkInterface)
        {
            return this.WithExistingPrimaryNetworkInterface(networkInterface) as VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Enables unmanaged disk support on this virtual machine.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithWindowsCreateUnmanaged VirtualMachine.Definition.IWithWindowsCreateManagedOrUnmanaged.WithUnmanagedDisks()
        {
            return this.WithUnmanagedDisks() as VirtualMachine.Definition.IWithWindowsCreateUnmanaged;
        }

        /// <summary>
        /// Specifies the SSH public key.
        /// </summary>
        /// <param name="publicKey">An SSH public key in the PEM format.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithLinuxCreateManagedOrUnmanaged VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManagedOrUnmanaged.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey) as VirtualMachine.Definition.IWithLinuxCreateManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">A password following the complexity criteria for Azure Linux VM passwords.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithLinuxCreateManagedOrUnmanaged VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManagedOrUnmanaged.WithRootPassword(string rootPassword)
        {
            return this.WithRootPassword(rootPassword) as VirtualMachine.Definition.IWithLinuxCreateManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">A user name following the required naming convention for Windows user names.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithWindowsAdminPasswordUnmanaged VirtualMachine.Definition.IWithWindowsAdminUsernameUnmanaged.WithAdminUsername(string adminUserName)
        {
            return this.WithAdminUsername(adminUserName) as VirtualMachine.Definition.IWithWindowsAdminPasswordUnmanaged;
        }

        /// <summary>
        /// Specifies the computer name for the virtual machine.
        /// </summary>
        /// <param name="computerName">A computer name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged.WithComputerName(string computerName)
        {
            return this.WithComputerName(computerName) as VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged;
        }

        /// <summary>
        /// Specifies the custom data for the virtual machine.
        /// </summary>
        /// <param name="base64EncodedCustomData">Base64 encoded custom data.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged.WithCustomData(string base64EncodedCustomData)
        {
            return this.WithCustomData(base64EncodedCustomData) as VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged;
        }

        /// <summary>
        /// Specifies definition of a not-yet-created availability set definition
        /// to associate the virtual machine with.
        /// </summary>
        /// <param name="creatable">A creatable availability set definition.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithAvailabilitySet.WithNewAvailabilitySet(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet> creatable)
        {
            return this.WithNewAvailabilitySet(creatable) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the name of a new availability set to associate with the virtual machine.
        /// </summary>
        /// <param name="name">The name of an availability set.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithAvailabilitySet.WithNewAvailabilitySet(string name)
        {
            return this.WithNewAvailabilitySet(name) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies an existing availability set to associate with the virtual machine.
        /// </summary>
        /// <param name="availabilitySet">An existing availability set.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithAvailabilitySet.WithExistingAvailabilitySet(IAvailabilitySet availabilitySet)
        {
            return this.WithExistingAvailabilitySet(availabilitySet) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the administrator password for the Windows virtual machine.
        /// </summary>
        /// <param name="adminPassword">A password following the complexity criteria for Azure Windows VM passwords.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithWindowsCreateManagedOrUnmanaged VirtualMachine.Definition.IWithWindowsAdminPasswordManagedOrUnmanaged.WithAdminPassword(string adminPassword)
        {
            return this.WithAdminPassword(adminPassword) as VirtualMachine.Definition.IWithWindowsCreateManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">A user name followinmg the required naming convention for Windows user names.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithWindowsAdminPasswordManaged VirtualMachine.Definition.IWithWindowsAdminUsernameManaged.WithAdminUsername(string adminUserName)
        {
            return this.WithAdminUsername(adminUserName) as VirtualMachine.Definition.IWithWindowsAdminPasswordManaged;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken) as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine;
        }

        /// <summary>
        /// Specifies an SSH public key.
        /// </summary>
        /// <param name="publicKey">An SSH public key in the PEM format.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithLinuxCreateUnmanaged VirtualMachine.Definition.IWithLinuxCreateUnmanaged.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey) as VirtualMachine.Definition.IWithLinuxCreateUnmanaged;
        }

        /// <summary>
        /// Specifies the computer name for the virtual machine.
        /// </summary>
        /// <param name="computerName">A name for the computer.</param>
        /// <return>The next stage stage of the definition.</return>
        VirtualMachine.Definition.IWithFromImageCreateOptionsManaged VirtualMachine.Definition.IWithFromImageCreateOptionsManaged.WithComputerName(string computerName)
        {
            return this.WithComputerName(computerName) as VirtualMachine.Definition.IWithFromImageCreateOptionsManaged;
        }

        /// <summary>
        /// Specifies the custom data for the virtual machine.
        /// </summary>
        /// <param name="base64EncodedCustomData">The base64 encoded custom data.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithFromImageCreateOptionsManaged VirtualMachine.Definition.IWithFromImageCreateOptionsManaged.WithCustomData(string base64EncodedCustomData)
        {
            return this.WithCustomData(base64EncodedCustomData) as VirtualMachine.Definition.IWithFromImageCreateOptionsManaged;
        }

        /// <summary>
        /// Starts the definition of an extension to be attached to the virtual machine.
        /// </summary>
        /// <param name="name">The reference name for the extension.</param>
        /// <return>The first stage stage of an extension definition.</return>
        VirtualMachineExtension.Definition.IBlank<VirtualMachine.Definition.IWithCreate> VirtualMachine.Definition.IWithExtension.DefineNewExtension(string name)
        {
            return this.DefineNewExtension(name) as VirtualMachineExtension.Definition.IBlank<VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// Begins the definition of an extension to be attached to the virtual machine.
        /// </summary>
        /// <param name="name">A reference name for the extension.</param>
        /// <return>The first stage of an extension definition.</return>
        VirtualMachineExtension.UpdateDefinition.IBlank<VirtualMachine.Update.IUpdate> VirtualMachine.Update.IWithExtension.DefineNewExtension(string name)
        {
            return this.DefineNewExtension(name) as VirtualMachineExtension.UpdateDefinition.IBlank<VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Detaches an extension from the virtual machine.
        /// </summary>
        /// <param name="name">The reference name of the extension to be removed/uninstalled.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithExtension.WithoutExtension(string name)
        {
            return this.WithoutExtension(name) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Begins the description of an update of an existing extension of this virtual machine.
        /// </summary>
        /// <param name="name">The reference name of an existing extension.</param>
        /// <return>The first stage of an extension update.</return>
        VirtualMachineExtension.Update.IUpdate VirtualMachine.Update.IWithExtension.UpdateExtension(string name)
        {
            return this.UpdateExtension(name) as VirtualMachineExtension.Update.IUpdate;
        }

        /// <summary>
        /// Gets resource ID of the managed disk backing the OS disk.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.OSDiskId
        {
            get
            {
                return this.OSDiskId();
            }
        }

        /// <summary>
        /// Gets name of this virtual machine.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.ComputerName
        {
            get
            {
                return this.ComputerName();
            }
        }

        /// <summary>
        /// Gets the storage blob endpoint uri if boot diagnostics is enabled for the virtual machine.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineBeta.BootDiagnosticsStorageUri
        {
            get
            {
                return this.BootDiagnosticsStorageUri();
            }
        }

        /// <summary>
        /// Powers off (stops) the virtual machine asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.PowerOffAsync(CancellationToken cancellationToken)
        {

            await this.PowerOffAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the provisioningState value.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets Returns the storage profile of an Azure virtual machine.
        /// </summary>
        /// <summary>
        /// Gets the storageProfile value.
        /// </summary>
        Models.StorageProfile Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.StorageProfile
        {
            get
            {
                return this.StorageProfile() as Models.StorageProfile;
            }
        }

        /// <summary>
        /// Gets the plan value.
        /// </summary>
        Models.Plan Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.Plan
        {
            get
            {
                return this.Plan() as Models.Plan;
            }
        }

        /// <summary>
        /// Captures the virtual machine by copying virtual hard disks of the VM asynchronously.
        /// </summary>
        /// <param name="containerName">Destination container name to store the captured VHD.</param>
        /// <param name="vhdPrefix">The prefix for the VHD holding captured image.</param>
        /// <param name="overwriteVhd">Whether to overwrites destination VHD if it exists.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<string> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineBeta.CaptureAsync(string containerName, string vhdPrefix, bool overwriteVhd, CancellationToken cancellationToken)
        {
            return await this.CaptureAsync(containerName, vhdPrefix, overwriteVhd, cancellationToken);
        }

        /// <summary>
        /// Gets the unmanaged data disks associated with this virtual machine, indexed by LUN number.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<int, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineUnmanagedDataDisk> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.UnmanagedDataDisks
        {
            get
            {
                return this.UnmanagedDataDisks() as System.Collections.Generic.IReadOnlyDictionary<int, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineUnmanagedDataDisk>;
            }
        }

        /// <summary>
        /// Gets true if boot diagnostics is enabled for the virtual machine.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineBeta.IsBootDiagnosticsEnabled
        {
            get
            {
                return this.IsBootDiagnosticsEnabled();
            }
        }

        /// <summary>
        /// Gets the managed data disks associated with this virtual machine, indexed by LUN.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<int, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.DataDisks
        {
            get
            {
                return this.DataDisks() as System.Collections.Generic.IReadOnlyDictionary<int, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk>;
            }
        }

        /// <summary>
        /// Captures the virtual machine by copying virtual hard disks of the VM.
        /// </summary>
        /// <param name="containerName">Destination container name to store the captured VHD.</param>
        /// <param name="vhdPrefix">The prefix for the VHD holding captured image.</param>
        /// <param name="overwriteVhd">Whether to overwrites destination VHD if it exists.</param>
        /// <return>The JSON template for creating more such virtual machines.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.Capture(string containerName, string vhdPrefix, bool overwriteVhd)
        {
            return this.Capture(containerName, vhdPrefix, overwriteVhd);
        }

        /// <summary>
        /// Restarts the virtual machine.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.Restart()
        {

            this.Restart();
        }

        /// <summary>
        /// Converts (migrates) the virtual machine with un-managed disks to use managed disk asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.ConvertToManagedAsync(CancellationToken cancellationToken)
        {

            await this.ConvertToManagedAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the operating system disk caching type.
        /// </summary>
        Models.CachingTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.OSDiskCachingType
        {
            get
            {
                return this.OSDiskCachingType();
            }
        }

        /// <summary>
        /// Redeploys the virtual machine.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.Redeploy()
        {

            this.Redeploy();
        }

        /// <summary>
        /// Powers off (stops) the virtual machine.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.PowerOff()
        {

            this.PowerOff();
        }

        /// <summary>
        /// Gets the virtual machine size.
        /// </summary>
        Models.VirtualMachineSizeTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.Size
        {
            get
            {
                return this.Size() as Models.VirtualMachineSizeTypes;
            }
        }

        /// <summary>
        /// Gets the storage account type of the managed disk backing OS disk.
        /// </summary>
        Models.StorageAccountTypes? Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.OSDiskStorageAccountType
        {
            get
            {
                return this.OSDiskStorageAccountType();
            }
        }

        /// <summary>
        /// Refreshes the virtual machine instance view to sync with Azure.
        /// The instance view will be cached for later retrieval using <code>instanceView</code>.
        /// </summary>
        /// <return>The refreshed instance view.</return>
        Models.VirtualMachineInstanceView Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.RefreshInstanceView()
        {
            return this.RefreshInstanceView() as Models.VirtualMachineInstanceView;
        }

        /// <summary>
        /// Lists all available virtual machine sizes this virtual machine can resized to.
        /// </summary>
        /// <return>The virtual machine sizes.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.AvailableSizes()
        {
            return this.AvailableSizes() as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize>;
        }

        /// <summary>
        /// Gets the licenseType value.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.LicenseType
        {
            get
            {
                return this.LicenseType();
            }
        }

        /// <return>The resource ID of the public IP address associated with this virtual machine's primary network interface.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.GetPrimaryPublicIPAddressId()
        {
            return this.GetPrimaryPublicIPAddressId();
        }

        /// <summary>
        /// Gets the size of the operating system disk in GB.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.OSDiskSize
        {
            get
            {
                return this.OSDiskSize();
            }
        }

        /// <summary>
        /// Gets the operating system of this virtual machine.
        /// </summary>
        Models.OperatingSystemTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.OSType
        {
            get
            {
                return this.OSType();
            }
        }

        /// <summary>
        /// Gets the URI to the VHD file backing this virtual machine's operating system disk.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.OSUnmanagedDiskVhdUri
        {
            get
            {
                return this.OSUnmanagedDiskVhdUri();
            }
        }

        /// <return>Extensions attached to the virtual machine.</return>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.ListExtensions()
        {
            return this.ListExtensions() as System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension>;
        }

        /// <summary>
        /// Gets the Managed Service Identity specific Active Directory service principal ID assigned
        /// to the virtual machine.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineBeta.ManagedServiceIdentityPrincipalId
        {
            get
            {
                return this.ManagedServiceIdentityPrincipalId();
            }
        }

        /// <summary>
        /// Gets true if Managed Service Identity is enabled for the virtual machine.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineBeta.IsManagedServiceIdentityEnabled
        {
            get
            {
                return this.IsManagedServiceIdentityEnabled();
            }
        }

        /// <summary>
        /// Gets the Managed Service Identity specific Active Directory tenant ID assigned to the
        /// virtual machine.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineBeta.ManagedServiceIdentityTenantId
        {
            get
            {
                return this.ManagedServiceIdentityTenantId();
            }
        }

        /// <summary>
        /// Starts the virtual machine asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.StartAsync(CancellationToken cancellationToken)
        {

            await this.StartAsync(cancellationToken);
        }

        /// <summary>
        /// Converts (migrates) the virtual machine with un-managed disks to use managed disk.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.ConvertToManaged()
        {

            this.ConvertToManaged();
        }

        /// <summary>
        /// Shuts down the virtual machine and releases the compute resources asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.DeallocateAsync(CancellationToken cancellationToken)
        {

            await this.DeallocateAsync(cancellationToken);
        }

        /// <summary>
        /// Shuts down the virtual machine and releases the compute resources.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.Deallocate()
        {

            this.Deallocate();
        }

        /// <summary>
        /// Gets the diagnostics profile.
        /// </summary>
        Models.DiagnosticsProfile Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.DiagnosticsProfile
        {
            get
            {
                return this.DiagnosticsProfile() as Models.DiagnosticsProfile;
            }
        }

        /// <summary>
        /// Restarts the virtual machine asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.RestartAsync(CancellationToken cancellationToken)
        {

            await this.RestartAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the resource ID of the availability set associated with this virtual machine.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.AvailabilitySetId
        {
            get
            {
                return this.AvailabilitySetId();
            }
        }

        /// <summary>
        /// Gets the operating system profile.
        /// </summary>
        Models.OSProfile Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.OSProfile
        {
            get
            {
                return this.OSProfile() as Models.OSProfile;
            }
        }

        /// <summary>
        /// Generalizes the virtual machine.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.Generalize()
        {

            this.Generalize();
        }

        /// <summary>
        /// Starts the virtual machine.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.Start()
        {

            this.Start();
        }

        /// <summary>
        /// Gets entry point to enabling, disabling and querying disk encryption.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineEncryption Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.DiskEncryption
        {
            get
            {
                return this.DiskEncryption() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineEncryption;
            }
        }

        /// <summary>
        /// Gets the virtual machine instance view.
        /// The instance view will be cached for later retrieval using <code>instanceView</code>.
        /// </summary>
        /// <summary>
        /// Gets the virtual machine's instance view.
        /// </summary>
        Models.VirtualMachineInstanceView Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.InstanceView
        {
            get
            {
                return this.InstanceView() as Models.VirtualMachineInstanceView;
            }
        }

        /// <summary>
        /// Gets the power state of the virtual machine.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.PowerState Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.PowerState
        {
            get
            {
                return this.PowerState() as Microsoft.Azure.Management.Compute.Fluent.PowerState;
            }
        }

        /// <summary>
        /// Gets the virtual machine unique ID.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.VMId
        {
            get
            {
                return this.VMId();
            }
        }

        /// <summary>
        /// Gets true if managed disks are used for the virtual machine's disks (OS, data).
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.IsManagedDiskEnabled
        {
            get
            {
                return this.IsManagedDiskEnabled();
            }
        }

        /// <summary>
        /// Refreshes the virtual machine instance view to sync with Azure.
        /// </summary>
        /// <return>An observable that emits the instance view of the virtual machine.</return>
        async Task<Models.VirtualMachineInstanceView> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.RefreshInstanceViewAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshInstanceViewAsync(cancellationToken) as Models.VirtualMachineInstanceView;
        }

        /// <summary>
        /// Gets the public IP address associated with this virtual machine's primary network interface.
        /// Note that this method makes a rest API call to fetch the resource.
        /// </summary>
        /// <return>The public IP of the primary network interface.</return>
        Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.GetPrimaryPublicIPAddress()
        {
            return this.GetPrimaryPublicIPAddress() as Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress;
        }

        /// <return>A representation of the deferred computation of this call, returning extensions attached to the virtual machine.</return>
        async Task<IReadOnlyList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension>> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.ListExtensionsAsync(CancellationToken cancellationToken)
        {
            return await this.ListExtensionsAsync(cancellationToken) as IReadOnlyList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension>;
        }

        /// <summary>
        /// Generalizes the virtual machine asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.GeneralizeAsync(CancellationToken cancellationToken)
        {
            await this.GeneralizeAsync(cancellationToken);
        }

        /// <summary>
        /// Redeploys the virtual machine asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.RedeployAsync(CancellationToken cancellationToken)
        {

            await this.RedeployAsync(cancellationToken);
        }

        /// <summary>
        /// Specifies the administrator password for the Windows virtual machine.
        /// </summary>
        /// <param name="adminPassword">A password following the complexity criteria for Azure Windows VM passwords.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithWindowsCreateManaged VirtualMachine.Definition.IWithWindowsAdminPasswordManaged.WithAdminPassword(string adminPassword)
        {
            return this.WithAdminPassword(adminPassword) as VirtualMachine.Definition.IWithWindowsCreateManaged;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network subnet to the
        /// VM's primary network interface.
        /// </summary>
        /// <param name="staticPrivateIPAddress">A static IP address within the specified subnet.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithPublicIPAddress VirtualMachine.Definition.IWithPrivateIP.WithPrimaryPrivateIPAddressStatic(string staticPrivateIPAddress)
        {
            return this.WithPrimaryPrivateIPAddressStatic(staticPrivateIPAddress) as VirtualMachine.Definition.IWithPublicIPAddress;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network subnet for
        /// the VM's primary network interface.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithPublicIPAddress VirtualMachine.Definition.IWithPrivateIP.WithPrimaryPrivateIPAddressDynamic()
        {
            return this.WithPrimaryPrivateIPAddressDynamic() as VirtualMachine.Definition.IWithPublicIPAddress;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the virtual machine's primary network interface, based on
        /// the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new virtual network.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithPrivateIP VirtualMachine.Definition.IWithNetwork.WithNewPrimaryNetwork(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetwork> creatable)
        {
            return this.WithNewPrimaryNetwork(creatable) as VirtualMachine.Definition.IWithPrivateIP;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the virtual machine's primary network interface.
        /// The virtual network will be created in the same resource group and region as of virtual machine, it will be
        /// created with the specified address space and a default subnet covering the entirety of the network IP address space.
        /// </summary>
        /// <param name="addressSpace">The address space for the virtual network.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithPrivateIP VirtualMachine.Definition.IWithNetwork.WithNewPrimaryNetwork(string addressSpace)
        {
            return this.WithNewPrimaryNetwork(addressSpace) as VirtualMachine.Definition.IWithPrivateIP;
        }

        /// <summary>
        /// Associates an existing virtual network with the virtual machine's primary network interface.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithSubnet VirtualMachine.Definition.IWithNetwork.WithExistingPrimaryNetwork(INetwork network)
        {
            return this.WithExistingPrimaryNetwork(network) as VirtualMachine.Definition.IWithSubnet;
        }

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        VirtualMachine.Definition.IWithLinuxCreateManaged VirtualMachine.Definition.IWithLinuxCreateManaged.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey) as VirtualMachine.Definition.IWithLinuxCreateManaged;
        }

        /// <summary>
        /// Specifies an SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">A user name following the required naming convention for Linux user names.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManaged VirtualMachine.Definition.IWithLinuxRootUsernameManaged.WithRootUsername(string rootUserName)
        {
            return this.WithRootUsername(rootUserName) as VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManaged;
        }

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithBootDiagnostics.WithBootDiagnostics()
        {
            return this.WithBootDiagnostics() as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine.
        /// </summary>
        /// <param name="creatable">The storage account to be created and used for store the boot diagnostics.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithBootDiagnostics.WithBootDiagnostics(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable)
        {
            return this.WithBootDiagnostics(creatable) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine.
        /// </summary>
        /// <param name="storageAccountBlobEndpointUri">A storage account blob endpoint to store the boot diagnostics.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithBootDiagnostics.WithBootDiagnostics(string storageAccountBlobEndpointUri)
        {
            return this.WithBootDiagnostics(storageAccountBlobEndpointUri) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be uses to store the boot diagnostics.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithBootDiagnostics.WithBootDiagnostics(IStorageAccount storageAccount)
        {
            return this.WithBootDiagnostics(storageAccount) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that Managed Service Identity needs to be enabled in the virtual machine.
        /// </summary>
        /// <returns>The next stage of the definition.</returns>
        VirtualMachine.Definition.IWithRoleAndScopeOrCreate VirtualMachine.Definition.IWithManagedServiceIdentity.WithManagedServiceIdentity()
        {
            return this.WithManagedServiceIdentity() as VirtualMachine.Definition.IWithRoleAndScopeOrCreate;
        }

        /// <summary>
        /// Specifies that Managed Service Identity needs to be enabled in the virtual machine.
        /// </summary>
        /// <param name="tokenPort">the port on the virtual machine where access token is available</param>
        /// <returns>The next stage of the definition.</returns>
        VirtualMachine.Definition.IWithRoleAndScopeOrCreate VirtualMachine.Definition.IWithManagedServiceIdentity.WithManagedServiceIdentity(int tokenPort)
        {
            return this.WithManagedServiceIdentity(tokenPort) as VirtualMachine.Definition.IWithRoleAndScopeOrCreate;
        }

        /// <summary>
        /// Specifies that applications running on the virtual machine requires the access described in the given role definition with 
        /// scope of access limited to the ARM resource identified by the resource ID specified in the scope parameter.
        /// </summary>
        /// <param name="scope">scope of the access represented in ARM resource ID format</param>
        /// <param name="roleDefinitionId">access role definition to assigned to the virtual machine</param>
        /// <returns>The next stage of the definition.</returns>
        VirtualMachine.Definition.IWithRoleAndScopeOrCreate VirtualMachine.Definition.IWithRoleAndScopeOrCreate.WithRoleDefinitionBasedAccessTo(string scope, string roleDefinitionId)
        {
            return this.WithRoleDefinitionBasedAccessTo(scope, roleDefinitionId) as VirtualMachine.Definition.IWithRoleAndScopeOrCreate;
        }

        /// <summary>
        /// Specifies that applications running on the virtual machine requires the given access role
        /// with scope of access limited to the current resource group that the virtual machine
        /// resides.
        /// </summary>
        /// <param name="asRole">access role to assigned to the virtual machine</param>
        /// <returns>the next stage of the definition</returns>
        VirtualMachine.Definition.IWithRoleAndScopeOrCreate VirtualMachine.Definition.IWithRoleAndScopeOrCreate.WithRoleBasedAccessToCurrentResourceGroup(BuiltInRole asRole)
        {
            return this.WithRoleBasedAccessToCurrentResourceGroup(asRole) as VirtualMachine.Definition.IWithRoleAndScopeOrCreate;
        }

        /// <summary>
        /// Specifies that applications running on the virtual machine requires the given access role
        /// with scope of access limited to the ARM resource identified by the resource ID specified
        /// in the scope parameter.
        /// </summary>
        /// <param name="scope">scope of the access represented in ARM resource ID format</param>
        /// <param name="asRole">access role to assigned to the virtual machine</param>
        /// <returns>the next stage of the definition</returns>
        VirtualMachine.Definition.IWithRoleAndScopeOrCreate VirtualMachine.Definition.IWithRoleAndScopeOrCreate.WithRoleBasedAccessTo(string scope, BuiltInRole asRole)
        {
            return this.WithRoleBasedAccessTo(scope, asRole) as VirtualMachine.Definition.IWithRoleAndScopeOrCreate;
        }

        /// <summary>
        /// Specifies that applications running on the virtual machine requires the access described
        /// in the given role definition with scope of access limited to the current resource group that
        /// the virtual machine resides.
        /// </summary>
        /// <param name="roleDefinitionId">access role definition to assigned to the virtual machine</param>
        /// <returns>the next stage of the definition</returns>
        VirtualMachine.Definition.IWithRoleAndScopeOrCreate VirtualMachine.Definition.IWithRoleAndScopeOrCreate.WithRoleDefinitionBasedAccessToCurrentResourceGroup(string roleDefinitionId)
        {
            return this.WithRoleDefinitionBasedAccessToCurrentResourceGroup(roleDefinitionId) as VirtualMachine.Definition.IWithRoleAndScopeOrCreate;
        }

        /// <summary>
        /// Specifies that Managed Service Identity needs to be enabled in the virtual machine.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        VirtualMachine.Update.IWithRoleAndScopeOrUpdate VirtualMachine.Update.IWithManagedServiceIdentity.WithManagedServiceIdentity()
        {
            return this.WithManagedServiceIdentity() as VirtualMachine.Update.IWithRoleAndScopeOrUpdate;
        }

        /// <summary>
        /// Specifies that Managed Service Identity needs to be enabled in the virtual machine.
        /// </summary>
        /// <param name="tokenPort">the port on the virtual machine where access token is available</param>
        /// <returns>The next stage of the update.</returns>
        VirtualMachine.Update.IWithRoleAndScopeOrUpdate VirtualMachine.Update.IWithManagedServiceIdentity.WithManagedServiceIdentity(int tokenPort)
        {
            return this.WithManagedServiceIdentity(tokenPort) as VirtualMachine.Update.IWithRoleAndScopeOrUpdate;
        }

        /// <summary>
        /// Specifies that applications running on the virtual machine requires the access described
        /// in the given role definition with scope of access limited to the current resource group that
        /// the virtual machine resides.
        /// </summary>
        /// <param name="roleDefinitionId">access role definition to assigned to the virtual machine</param>
        /// <returns>the next stage of the definition</returns>
        VirtualMachine.Update.IWithRoleAndScopeOrUpdate VirtualMachine.Update.IWithRoleAndScopeOrUpdate.WithRoleDefinitionBasedAccessTo(string scope, string roleDefinitionId)
        {
            return this.WithRoleDefinitionBasedAccessTo(scope, roleDefinitionId) as VirtualMachine.Update.IWithRoleAndScopeOrUpdate;
        }

        /// <summary>
        /// Specifies that applications running on the virtual machine requires the given access role
        /// with scope of access limited to the current resource group that the virtual machine
        /// resides.
        /// </summary>
        /// <param name="asRole">access role to assigned to the virtual machine</param>
        /// <returns>the next stage of the update</returns>
        VirtualMachine.Update.IWithRoleAndScopeOrUpdate VirtualMachine.Update.IWithRoleAndScopeOrUpdate.WithRoleBasedAccessToCurrentResourceGroup(BuiltInRole asRole)
        {
            return this.WithRoleBasedAccessToCurrentResourceGroup(asRole) as VirtualMachine.Update.IWithRoleAndScopeOrUpdate;
        }

        /// <summary>
        /// Specifies that applications running on the virtual machine requires the given access role
        /// with scope of access limited to the ARM resource identified by the resource ID specified
        /// in the scope parameter.
        /// </summary>
        /// <param name="scope">scope of the access represented in ARM resource ID format</param>
        /// <param name="asRole">access role to assigned to the virtual machine</param>
        /// <returns>the next stage of the update</returns>
        VirtualMachine.Update.IWithRoleAndScopeOrUpdate VirtualMachine.Update.IWithRoleAndScopeOrUpdate.WithRoleBasedAccessTo(string scope, BuiltInRole asRole)
        {
            return this.WithRoleBasedAccessTo(scope, asRole) as VirtualMachine.Update.IWithRoleAndScopeOrUpdate;
        }

        /// <summary>
        /// Specifies that applications running on the virtual machine requires the access described
        /// in the given role definition with scope of access limited to the current resource group that
        /// the virtual machine resides.
        /// </summary>
        /// <param name="roleDefinitionId">access role definition to assigned to the virtual machine</param>
        /// <returns>the next stage of the update</returns>
        VirtualMachine.Update.IWithRoleAndScopeOrUpdate VirtualMachine.Update.IWithRoleAndScopeOrUpdate.WithRoleDefinitionBasedAccessToCurrentResourceGroup(string roleDefinitionId)
        {
            return this.WithRoleDefinitionBasedAccessToCurrentResourceGroup(roleDefinitionId) as VirtualMachine.Update.IWithRoleAndScopeOrUpdate;
        }
        /// <summary>
        /// Specifies that boot diagnostics needs to be disabled in the virtual machine.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithBootDiagnostics.WithoutBootDiagnostics()
        {
            return this.WithoutBootDiagnostics() as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithBootDiagnostics.WithBootDiagnostics()
        {
            return this.WithBootDiagnostics() as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine.
        /// </summary>
        /// <param name="creatable">The storage account to be created and used for store the boot diagnostics.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithBootDiagnostics.WithBootDiagnostics(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable)
        {
            return this.WithBootDiagnostics(creatable) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine.
        /// </summary>
        /// <param name="storageAccountBlobEndpointUri">A storage account blob endpoint to store the boot diagnostics.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithBootDiagnostics.WithBootDiagnostics(string storageAccountBlobEndpointUri)
        {
            return this.WithBootDiagnostics(storageAccountBlobEndpointUri) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be uses to store the boot diagnostics.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithBootDiagnostics.WithBootDiagnostics(IStorageAccount storageAccount)
        {
            return this.WithBootDiagnostics(storageAccount) as VirtualMachine.Update.IUpdate;
        }
    }
}