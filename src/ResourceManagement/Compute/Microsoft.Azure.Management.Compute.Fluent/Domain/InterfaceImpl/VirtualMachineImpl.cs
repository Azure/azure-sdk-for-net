// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using VirtualMachine.DefinitionManaged;
    using VirtualMachine.DefinitionManagedOrUnmanaged;
    using VirtualMachine.Definition;
    using VirtualMachine.DefinitionUnmanaged;
    using VirtualMachine.Update;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System.Collections.Generic;

    internal partial class VirtualMachineImpl 
    {
        /// <summary>
        /// Specifies the SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">The Linux SSH root user name. This must follow the required naming convention for Linux user name.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyUnmanaged VirtualMachine.Definition.IWithLinuxRootUsernameUnmanaged.WithRootUsername(string rootUserName)
        {
            return this.WithRootUsername(rootUserName) as VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyUnmanaged;
        }

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        VirtualMachine.Definition.IWithLinuxCreateUnmanaged VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyUnmanaged.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey) as VirtualMachine.Definition.IWithLinuxCreateUnmanaged;
        }

        /// <summary>
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">The SSH root password. This must follow the criteria for Azure Linux VM password.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        VirtualMachine.Definition.IWithLinuxCreateUnmanaged VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyUnmanaged.WithRootPassword(string rootPassword)
        {
            return this.WithRootPassword(rootPassword) as VirtualMachine.Definition.IWithLinuxCreateUnmanaged;
        }

        /// <return>The next stage of a unmanaged disk based virtual machine definition.</return>
        VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged VirtualMachine.Definition.IWithFromImageCreateOptionsManagedOrUnmanaged.WithUnmanagedDisks()
        {
            return this.WithUnmanagedDisks() as VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged;
        }

        /// <summary>
        /// Specifies the plan for the virtual machine.
        /// </summary>
        /// <param name="plan">Describes the purchase plan.</param>
        /// <param name="promotionCode">The promotion code.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithPlan.WithPromotionalPlan(PurchasePlan plan, string promotionCode)
        {
            return this.WithPromotionalPlan(plan, promotionCode) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the plan for the virtual machine.
        /// </summary>
        /// <param name="plan">Describes the purchase plan.</param>
        /// <return>The stage representing creatable VM definition.</return>
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
        /// Specifies the SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">The Linux SSH root user name. This must follow the required naming convention for Linux user name.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManagedOrUnmanaged VirtualMachine.Definition.IWithLinuxRootUsernameManagedOrUnmanaged.WithRootUsername(string rootUserName)
        {
            return this.WithRootUsername(rootUserName) as VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies an existing source managed disk.
        /// </summary>
        /// <param name="disk">The managed disk.</param>
        /// <return>The next stage of virtual machine definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithExistingDataDisk(IDisk disk)
        {
            return this.WithExistingDataDisk(disk) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies an existing source managed disk and settings.
        /// </summary>
        /// <param name="disk">The managed disk.</param>
        /// <param name="lun">The disk lun.</param>
        /// <return>The next stage of virtual machine definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithExistingDataDisk(IDisk disk, int lun, CachingTypes cachingType)
        {
            return this.WithExistingDataDisk(disk, lun, cachingType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies an existing source managed disk and settings.
        /// </summary>
        /// <param name="disk">The managed disk.</param>
        /// <param name="newSizeInGB">The disk resize size in GB.</param>
        /// <param name="lun">The disk lun.</param>
        /// <return>The next stage of virtual machine definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithExistingDataDisk(IDisk disk, int newSizeInGB, int lun, CachingTypes cachingType)
        {
            return this.WithExistingDataDisk(disk, newSizeInGB, lun, cachingType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies the data disk to be created from the data disk image in the virtual machine image.
        /// </summary>
        /// <param name="imageLun">The lun of the source data disk image.</param>
        /// <return>The next stage of virtual machine definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithNewDataDiskFromImage(int imageLun)
        {
            return this.WithNewDataDiskFromImage(imageLun) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies the data disk to be created from the data disk image in the virtual machine image.
        /// </summary>
        /// <param name="imageLun">The lun of the source data disk image.</param>
        /// <param name="newSizeInGB">The new size that overrides the default size specified in the data disk image.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The next stage of virtual machine definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithNewDataDiskFromImage(int imageLun, int newSizeInGB, CachingTypes cachingType)
        {
            return this.WithNewDataDiskFromImage(imageLun, newSizeInGB, cachingType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies the data disk to be created from the data disk image in the virtual machine image.
        /// </summary>
        /// <param name="imageLun">The lun of the source data disk image.</param>
        /// <param name="newSizeInGB">The new size that overrides the default size specified in the data disk image.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <param name="storageAccountType">The storage account type.</param>
        /// <return>The next stage of virtual machine definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithNewDataDiskFromImage(int imageLun, int newSizeInGB, CachingTypes cachingType, StorageAccountTypes storageAccountType)
        {
            return this.WithNewDataDiskFromImage(imageLun, newSizeInGB, cachingType, storageAccountType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created explicitly with the given definition and
        /// attach to the virtual machine as data disk.
        /// </summary>
        /// <param name="creatable">The creatable disk.</param>
        /// <return>The next stage of virtual machine definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithNewDataDisk(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IDisk> creatable)
        {
            return this.WithNewDataDisk(creatable) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created explicitly with the given definition and
        /// attach to the virtual machine as data disk.
        /// </summary>
        /// <param name="creatable">The creatable disk.</param>
        /// <param name="lun">The data disk lun.</param>
        /// <param name="cachingType">The data disk caching type.</param>
        /// <return>The next stage of virtual machine definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithNewDataDisk(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IDisk> creatable, int lun, CachingTypes cachingType)
        {
            return this.WithNewDataDisk(creatable, lun, cachingType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given size.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <return>The next stage of virtual machine definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithNewDataDisk(int sizeInGB)
        {
            return this.WithNewDataDisk(sizeInGB) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk lun.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The next stage of virtual machine definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType)
        {
            return this.WithNewDataDisk(sizeInGB, lun, cachingType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk lun.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <param name="storageAccountType">The storage account type.</param>
        /// <return>The next stage of virtual machine definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedDataDisk.WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType, StorageAccountTypes storageAccountType)
        {
            return this.WithNewDataDisk(sizeInGB, lun, cachingType, storageAccountType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies an existing source managed disk.
        /// </summary>
        /// <param name="disk">The managed disk.</param>
        /// <return>The next stage of virtual machine update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithManagedDataDisk.WithExistingDataDisk(IDisk disk)
        {
            return this.WithExistingDataDisk(disk) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies an existing source managed disk and settings.
        /// </summary>
        /// <param name="disk">The managed disk.</param>
        /// <param name="lun">The disk lun.</param>
        /// <return>The next stage of virtual machine update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithManagedDataDisk.WithExistingDataDisk(IDisk disk, int lun, CachingTypes cachingType)
        {
            return this.WithExistingDataDisk(disk, lun, cachingType) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies an existing source managed disk and settings.
        /// </summary>
        /// <param name="disk">The managed disk.</param>
        /// <param name="newSizeInGB">The disk resize size in GB.</param>
        /// <param name="lun">The disk lun.</param>
        /// <return>The next stage of virtual machine update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithManagedDataDisk.WithExistingDataDisk(IDisk disk, int newSizeInGB, int lun, CachingTypes cachingType)
        {
            return this.WithExistingDataDisk(disk, newSizeInGB, lun, cachingType) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Updates the size of a managed data disk with the given lun.
        /// </summary>
        /// <param name="lun">The disk lun.</param>
        /// <param name="newSizeInGB">The new size of the disk.</param>
        /// <return>The next stage of virtual machine update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithManagedDataDisk.WithDataDiskUpdated(int lun, int newSizeInGB)
        {
            return this.WithDataDiskUpdated(lun, newSizeInGB) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Updates the size and caching type of a managed data disk with the given lun.
        /// </summary>
        /// <param name="lun">The disk lun.</param>
        /// <param name="newSizeInGB">The new size of the disk.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The next stage of virtual machine update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithManagedDataDisk.WithDataDiskUpdated(int lun, int newSizeInGB, CachingTypes cachingType)
        {
            return this.WithDataDiskUpdated(lun, newSizeInGB, cachingType) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Updates the size, caching type and storage account type of a managed data disk with the given lun.
        /// </summary>
        /// <param name="lun">The disk lun.</param>
        /// <param name="newSizeInGB">The new size of the disk.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <param name="storageAccountType">The storage account type.</param>
        /// <return>The next stage of virtual machine update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithManagedDataDisk.WithDataDiskUpdated(int lun, int newSizeInGB, CachingTypes cachingType, StorageAccountTypes storageAccountType)
        {
            return this.WithDataDiskUpdated(lun, newSizeInGB, cachingType, storageAccountType) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created explicitly with the given definition and
        /// attach to the virtual machine as data disk.
        /// </summary>
        /// <param name="creatable">The creatable disk.</param>
        /// <return>The next stage of virtual machine update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithManagedDataDisk.WithNewDataDisk(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IDisk> creatable)
        {
            return this.WithNewDataDisk(creatable) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created explicitly with the given definition and
        /// attach to the virtual machine as data disk.
        /// </summary>
        /// <param name="creatable">The creatable disk.</param>
        /// <param name="lun">The data disk lun.</param>
        /// <param name="cachingType">The data disk caching type.</param>
        /// <return>The next stage of virtual machine update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithManagedDataDisk.WithNewDataDisk(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IDisk> creatable, int lun, CachingTypes cachingType)
        {
            return this.WithNewDataDisk(creatable, lun, cachingType) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given size.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <return>The next stage of virtual machine update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithManagedDataDisk.WithNewDataDisk(int sizeInGB)
        {
            return this.WithNewDataDisk(sizeInGB) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Pecifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk lun.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The next stage of virtual machine update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithManagedDataDisk.WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType)
        {
            return this.WithNewDataDisk(sizeInGB, lun, cachingType) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk lun.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <param name="storageAccountType">The storage account type.</param>
        /// <return>The next stage of virtual machine update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithManagedDataDisk.WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType, StorageAccountTypes storageAccountType)
        {
            return this.WithNewDataDisk(sizeInGB, lun, cachingType, storageAccountType) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Detaches managed data disk with the given lun from the virtual machine.
        /// </summary>
        /// <param name="lun">The disk lun.</param>
        /// <return>The next stage of virtual machine update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithManagedDataDisk.WithoutDataDisk(int lun)
        {
            return this.WithoutDataDisk(lun) as VirtualMachine.Update.IUpdate;
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
        /// Gets the primary network interface.
        /// Note that this method can result in a call to the cloud to fetch the network interface information.
        /// </summary>
        /// <return>The primary network interface associated with this resource.</return>
        Microsoft.Azure.Management.Network.Fluent.INetworkInterface Microsoft.Azure.Management.Network.Fluent.IHasNetworkInterfaces.GetPrimaryNetworkInterface()
        {
            return this.GetPrimaryNetworkInterface() as Microsoft.Azure.Management.Network.Fluent.INetworkInterface;
        }

        /// <summary>
        /// Gets the list of resource IDs of the network interfaces associated with this resource.
        /// </summary>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Network.Fluent.IHasNetworkInterfaces.NetworkInterfaceIds
        {
            get
            {
                return this.NetworkInterfaceIds() as System.Collections.Generic.IList<string>;
            }
        }

        /// <summary>
        /// Specifies the name of the OS Disk Vhd file and it's parent container.
        /// </summary>
        /// <param name="containerName">The name of the container in the selected storage account.</param>
        /// <param name="vhdName">The name for the OS Disk vhd.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithUnmanagedCreate VirtualMachine.Definition.IWithUnmanagedCreate.WithOsDiskVhdLocation(string containerName, string vhdName)
        {
            return this.WithOsDiskVhdLocation(containerName, vhdName) as VirtualMachine.Definition.IWithUnmanagedCreate;
        }

        /// <summary>
        /// Specifies that the latest version of a marketplace Linux image needs to be used.
        /// </summary>
        /// <param name="publisher">Specifies the publisher of the image.</param>
        /// <param name="offer">Specifies the offer of the image.</param>
        /// <param name="sku">Specifies the SKU of the image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithLinuxRootUsernameManagedOrUnmanaged VirtualMachine.Definition.IWithOS.WithLatestLinuxImage(string publisher, string offer, string sku)
        {
            return this.WithLatestLinuxImage(publisher, offer, sku) as VirtualMachine.Definition.IWithLinuxRootUsernameManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies the user (generalized) Linux image used for the virtual machine's OS.
        /// </summary>
        /// <param name="imageUrl">The url the the VHD.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithLinuxRootUsernameUnmanaged VirtualMachine.Definition.IWithOS.WithStoredLinuxImage(string imageUrl)
        {
            return this.WithStoredLinuxImage(imageUrl) as VirtualMachine.Definition.IWithLinuxRootUsernameUnmanaged;
        }

        /// <summary>
        /// Specifies the version of a market-place Linux image needs to be used.
        /// </summary>
        /// <param name="imageReference">Describes publisher, offer, sku and version of the market-place image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithLinuxRootUsernameManagedOrUnmanaged VirtualMachine.Definition.IWithOS.WithSpecificLinuxImageVersion(ImageReference imageReference)
        {
            return this.WithSpecificLinuxImageVersion(imageReference) as VirtualMachine.Definition.IWithLinuxRootUsernameManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies the specialized operating system unmanaged disk to be attached to the virtual machine.
        /// </summary>
        /// <param name="osDiskUrl">OsDiskUrl the url to the OS disk in the Azure Storage account.</param>
        /// <param name="osType">The OS type.</param>
        /// <return>The next stage of the Windows virtual machine definition.</return>
        VirtualMachine.Definition.IWithUnmanagedCreate VirtualMachine.Definition.IWithOS.WithSpecializedOsUnmanagedDisk(string osDiskUrl, OperatingSystemTypes osType)
        {
            return this.WithSpecializedOsUnmanagedDisk(osDiskUrl, osType) as VirtualMachine.Definition.IWithUnmanagedCreate;
        }

        /// <summary>
        /// Specifies the id of a Linux custom image to be used.
        /// </summary>
        /// <param name="customImageId">The resource id of the custom image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithLinuxRootUsernameManaged VirtualMachine.Definition.IWithOS.WithLinuxCustomImage(string customImageId)
        {
            return this.WithLinuxCustomImage(customImageId) as VirtualMachine.Definition.IWithLinuxRootUsernameManaged;
        }

        /// <summary>
        /// Specifies that the latest version of a marketplace Windows image needs to be used.
        /// </summary>
        /// <param name="publisher">Specifies the publisher of the image.</param>
        /// <param name="offer">Specifies the offer of the image.</param>
        /// <param name="sku">Specifies the SKU of the image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged VirtualMachine.Definition.IWithOS.WithLatestWindowsImage(string publisher, string offer, string sku)
        {
            return this.WithLatestWindowsImage(publisher, offer, sku) as VirtualMachine.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies the id of a Windows custom image to be used.
        /// </summary>
        /// <param name="customImageId">The resource id of the custom image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithWindowsAdminUsernameManaged VirtualMachine.Definition.IWithOS.WithWindowsCustomImage(string customImageId)
        {
            return this.WithWindowsCustomImage(customImageId) as VirtualMachine.Definition.IWithWindowsAdminUsernameManaged;
        }

        /// <summary>
        /// Specifies the known marketplace Windows image used for the virtual machine's OS.
        /// </summary>
        /// <param name="knownImage">Enum value indicating known market-place image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged VirtualMachine.Definition.IWithOS.WithPopularWindowsImage(KnownWindowsVirtualMachineImage knownImage)
        {
            return this.WithPopularWindowsImage(knownImage) as VirtualMachine.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies the specialized operating system managed disk to be attached to the virtual machine.
        /// </summary>
        /// <param name="disk">The managed disk to attach.</param>
        /// <param name="osType">The OS type.</param>
        /// <return>The next stage of the Windows virtual machine definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithOS.WithSpecializedOsDisk(IDisk disk, OperatingSystemTypes osType)
        {
            return this.WithSpecializedOsDisk(disk, osType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies the version of a marketplace Windows image needs to be used.
        /// </summary>
        /// <param name="imageReference">Describes publisher, offer, sku and version of the market-place image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged VirtualMachine.Definition.IWithOS.WithSpecificWindowsImageVersion(ImageReference imageReference)
        {
            return this.WithSpecificWindowsImageVersion(imageReference) as VirtualMachine.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies the known marketplace Linux image used for the virtual machine's OS.
        /// </summary>
        /// <param name="knownImage">Enum value indicating known market-place image.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithLinuxRootUsernameManagedOrUnmanaged VirtualMachine.Definition.IWithOS.WithPopularLinuxImage(KnownLinuxVirtualMachineImage knownImage)
        {
            return this.WithPopularLinuxImage(knownImage) as VirtualMachine.Definition.IWithLinuxRootUsernameManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies the user (generalized) Windows image used for the virtual machine's OS.
        /// </summary>
        /// <param name="imageUrl">The url the the VHD.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithWindowsAdminUsernameUnmanaged VirtualMachine.Definition.IWithOS.WithStoredWindowsImage(string imageUrl)
        {
            return this.WithStoredWindowsImage(imageUrl) as VirtualMachine.Definition.IWithWindowsAdminUsernameUnmanaged;
        }

        /// <summary>
        /// Specifies the caching type for the Operating System disk.
        /// </summary>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The stage representing updatable VM definition.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IUpdate.WithOSDiskCaching(CachingTypes cachingType)
        {
            return this.WithOSDiskCaching(cachingType) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the size of the OSDisk in GB.
        /// </summary>
        /// <param name="size">The disk size.</param>
        /// <return>The stage representing updatable VM definition.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IUpdate.WithOSDiskSizeInGB(int size)
        {
            return this.WithOSDiskSizeInGB(size) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the default caching type for the managed data disks.
        /// </summary>
        /// <param name="storageAccountType">The storage account type.</param>
        /// <return>The stage representing updatable VM definition.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IUpdate.WithDataDiskDefaultStorageAccountType(StorageAccountTypes storageAccountType)
        {
            return this.WithDataDiskDefaultStorageAccountType(storageAccountType) as VirtualMachine.Update.IUpdate;
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
        /// Specifies the default caching type for the managed data disks.
        /// </summary>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The stage representing updatable VM definition.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IUpdate.WithDataDiskDefaultCachingType(CachingTypes cachingType)
        {
            return this.WithDataDiskDefaultCachingType(cachingType) as VirtualMachine.Update.IUpdate;
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
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">The Windows administrator user name. This must follow the required naming convention for Windows user name.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        VirtualMachine.Definition.IWithWindowsAdminPasswordManagedOrUnmanaged VirtualMachine.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged.WithAdminUsername(string adminUserName)
        {
            return this.WithAdminUsername(adminUserName) as VirtualMachine.Definition.IWithWindowsAdminPasswordManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        VirtualMachine.Definition.IWithLinuxCreateManagedOrUnmanaged VirtualMachine.Definition.IWithLinuxCreateManagedOrUnmanaged.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey) as VirtualMachine.Definition.IWithLinuxCreateManagedOrUnmanaged;
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
        /// <param name="listener">The WinRmListener.</param>
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
        /// Specifies the time-zone.
        /// </summary>
        /// <param name="timeZone">The timezone.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachine.Definition.IWithWindowsCreateUnmanaged VirtualMachine.Definition.IWithWindowsCreateUnmanaged.WithTimeZone(string timeZone)
        {
            return this.WithTimeZone(timeZone) as VirtualMachine.Definition.IWithWindowsCreateUnmanaged;
        }

        /// <summary>
        /// Specifies the storage account type for managed Os disk.
        /// </summary>
        /// <param name="accountType">The storage account type.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedCreate.WithOsDiskStorageAccountType(StorageAccountTypes accountType)
        {
            return this.WithOsDiskStorageAccountType(accountType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies the default caching type for the managed data disks.
        /// </summary>
        /// <param name="storageAccountType">The storage account type.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedCreate.WithDataDiskDefaultStorageAccountType(StorageAccountTypes storageAccountType)
        {
            return this.WithDataDiskDefaultStorageAccountType(storageAccountType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Specifies the default caching type for the managed data disks.
        /// </summary>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithManagedCreate VirtualMachine.Definition.IWithManagedCreate.WithDataDiskDefaultCachingType(CachingTypes cachingType)
        {
            return this.WithDataDiskDefaultCachingType(cachingType) as VirtualMachine.Definition.IWithManagedCreate;
        }

        /// <summary>
        /// Associate an existing network interface with the virtual machine.
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
        /// Specifies that VM Agent should not be provisioned.
        /// </summary>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachine.Definition.IWithWindowsCreateManaged VirtualMachine.Definition.IWithWindowsCreateManaged.WithoutVMAgent()
        {
            return this.WithoutVMAgent() as VirtualMachine.Definition.IWithWindowsCreateManaged;
        }

        /// <summary>
        /// Specifies the WINRM listener.
        /// Each call to this method adds the given listener to the list of VM's WinRM listeners.
        /// </summary>
        /// <param name="listener">The WinRMListener.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachine.Definition.IWithWindowsCreateManaged VirtualMachine.Definition.IWithWindowsCreateManaged.WithWinRM(WinRMListener listener)
        {
            return this.WithWinRM(listener) as VirtualMachine.Definition.IWithWindowsCreateManaged;
        }

        /// <summary>
        /// Specifies that automatic updates should be disabled.
        /// </summary>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachine.Definition.IWithWindowsCreateManaged VirtualMachine.Definition.IWithWindowsCreateManaged.WithoutAutoUpdate()
        {
            return this.WithoutAutoUpdate() as VirtualMachine.Definition.IWithWindowsCreateManaged;
        }

        /// <summary>
        /// Specifies the time-zone.
        /// </summary>
        /// <param name="timeZone">The timezone.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachine.Definition.IWithWindowsCreateManaged VirtualMachine.Definition.IWithWindowsCreateManaged.WithTimeZone(string timeZone)
        {
            return this.WithTimeZone(timeZone) as VirtualMachine.Definition.IWithWindowsCreateManaged;
        }

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        VirtualMachine.Definition.IWithLinuxCreateManaged VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManaged.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey) as VirtualMachine.Definition.IWithLinuxCreateManaged;
        }

        /// <summary>
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">The SSH root password. This must follow the criteria for Azure Linux VM password.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        VirtualMachine.Definition.IWithLinuxCreateManaged VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManaged.WithRootPassword(string rootPassword)
        {
            return this.WithRootPassword(rootPassword) as VirtualMachine.Definition.IWithLinuxCreateManaged;
        }

        /// <summary>
        /// Begins definition of a unmanaged data disk to be attached to the virtual machine.
        /// </summary>
        /// <param name="name">The name for the data disk.</param>
        /// <return>The stage representing configuration for the unmanaged data disk.</return>
        VirtualMachineUnmanagedDataDisk.Definition.IBlank<VirtualMachine.Definition.IWithUnmanagedCreate> VirtualMachine.Definition.IWithUnmanagedDataDisk.DefineUnmanagedDataDisk(string name)
        {
            return this.DefineUnmanagedDataDisk(name) as VirtualMachineUnmanagedDataDisk.Definition.IBlank<VirtualMachine.Definition.IWithUnmanagedCreate>;
        }

        /// <summary>
        /// Specifies that a new blank unmanaged data disk needs to be attached to virtual machine.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithUnmanagedCreate VirtualMachine.Definition.IWithUnmanagedDataDisk.WithNewUnmanagedDataDisk(int sizeInGB)
        {
            return this.WithNewUnmanagedDataDisk(sizeInGB) as VirtualMachine.Definition.IWithUnmanagedCreate;
        }

        /// <summary>
        /// Specifies an existing unmanaged VHD that needs to be attached to the virtual machine as data disk.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="containerName">The name of the container holding the VHD file.</param>
        /// <param name="vhdName">The name for the VHD file.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithUnmanagedCreate VirtualMachine.Definition.IWithUnmanagedDataDisk.WithExistingUnmanagedDataDisk(string storageAccountName, string containerName, string vhdName)
        {
            return this.WithExistingUnmanagedDataDisk(storageAccountName, containerName, vhdName) as VirtualMachine.Definition.IWithUnmanagedCreate;
        }

        /// <summary>
        /// Begins the description of an update of an existing unmanaged data disk of this virtual machine.
        /// </summary>
        /// <param name="name">The name of the disk.</param>
        /// <return>The stage representing updating configuration for  data disk.</return>
        VirtualMachineUnmanagedDataDisk.Update.IUpdate VirtualMachine.Update.IWithUnmanagedDataDisk.UpdateUnmanagedDataDisk(string name)
        {
            return this.UpdateUnmanagedDataDisk(name) as VirtualMachineUnmanagedDataDisk.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a new blank unmanaged data disk to be attached to the virtual machine along with it's configuration.
        /// </summary>
        /// <param name="name">The name for the data disk.</param>
        /// <return>The stage representing configuration for the data disk.</return>
        VirtualMachineUnmanagedDataDisk.UpdateDefinition.IBlank<VirtualMachine.Update.IUpdate> VirtualMachine.Update.IWithUnmanagedDataDisk.DefineUnmanagedDataDisk(string name)
        {
            return this.DefineUnmanagedDataDisk(name) as VirtualMachineUnmanagedDataDisk.UpdateDefinition.IBlank<VirtualMachine.Update.IUpdate>;
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
        /// Detaches a unmanaged data disk with the given name from the virtual machine.
        /// </summary>
        /// <param name="name">The name of the data disk to remove.</param>
        /// <return>The stage representing updatable VM definition.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithUnmanagedDataDisk.WithoutUnmanagedDataDisk(string name)
        {
            return this.WithoutUnmanagedDataDisk(name) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Detaches a unmanaged data disk with the given logical unit number from the virtual machine.
        /// </summary>
        /// <param name="lun">The logical unit number of the data disk to remove.</param>
        /// <return>The stage representing updatable VM definition.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IWithUnmanagedDataDisk.WithoutUnmanagedDataDisk(int lun)
        {
            return this.WithoutUnmanagedDataDisk(lun) as VirtualMachine.Update.IUpdate;
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
        /// <param name="adminPassword">The administrator password. This must follow the criteria for Azure Windows VM password.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachine.Definition.IWithWindowsCreateUnmanaged VirtualMachine.Definition.IWithWindowsAdminPasswordUnmanaged.WithAdminPassword(string adminPassword)
        {
            return this.WithAdminPassword(adminPassword) as VirtualMachine.Definition.IWithWindowsCreateUnmanaged;
        }

        /// <summary>
        /// Specifies definition of a not-yet-created storage account definition
        /// to put the VM's OS and data disk VHDs in.
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
        /// Assigns the specified static private IP address within the specified existing virtual network subnet to the
        /// virtual machine's primary network interface.
        /// </summary>
        /// <param name="staticPrivateIPAddress">
        /// The static IP address within the specified subnet to assign to
        /// the network interface.
        /// </param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithPublicIPAddress VirtualMachine.Definition.IWithPrivateIP.WithPrimaryPrivateIPAddressStatic(string staticPrivateIPAddress)
        {
            return this.WithPrimaryPrivateIPAddressStatic(staticPrivateIPAddress) as VirtualMachine.Definition.IWithPublicIPAddress;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network subnet for
        /// virtual machine's primary network interface.
        /// </summary>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithPublicIPAddress VirtualMachine.Definition.IWithPrivateIP.WithPrimaryPrivateIPAddressDynamic()
        {
            return this.WithPrimaryPrivateIPAddressDynamic() as VirtualMachine.Definition.IWithPublicIPAddress;
        }

        VirtualMachine.Definition.IWithWindowsCreateUnmanaged VirtualMachine.Definition.IWithWindowsCreateManagedOrUnmanaged.WithUnmanagedDisks()
        {
            return this.WithUnmanagedDisks() as VirtualMachine.Definition.IWithWindowsCreateUnmanaged;
        }

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        VirtualMachine.Definition.IWithLinuxCreateManagedOrUnmanaged VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManagedOrUnmanaged.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey) as VirtualMachine.Definition.IWithLinuxCreateManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">The SSH root password. This must follow the criteria for Azure Linux VM password.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        VirtualMachine.Definition.IWithLinuxCreateManagedOrUnmanaged VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManagedOrUnmanaged.WithRootPassword(string rootPassword)
        {
            return this.WithRootPassword(rootPassword) as VirtualMachine.Definition.IWithLinuxCreateManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">The Windows administrator user name. This must follow the required naming convention for Windows user name.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        VirtualMachine.Definition.IWithWindowsAdminPasswordUnmanaged VirtualMachine.Definition.IWithWindowsAdminUsernameUnmanaged.WithAdminUsername(string adminUserName)
        {
            return this.WithAdminUsername(adminUserName) as VirtualMachine.Definition.IWithWindowsAdminPasswordUnmanaged;
        }

        /// <summary>
        /// Specifies that no public IP needs to be associated with virtual machine.
        /// </summary>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithOS VirtualMachine.Definition.IWithPublicIPAddress.WithoutPrimaryPublicIPAddress()
        {
            return this.WithoutPrimaryPublicIPAddress() as VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Create a new public IP address to associate with virtual machine primary network interface, based on the
        /// provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithOS VirtualMachine.Definition.IWithPublicIPAddress.WithNewPrimaryPublicIPAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> creatable)
        {
            return this.WithNewPrimaryPublicIPAddress(creatable) as VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associate it with the virtual machine's primary network interface.
        /// the internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">The leaf domain label.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithOS VirtualMachine.Definition.IWithPublicIPAddress.WithNewPrimaryPublicIPAddress(string leafDnsLabel)
        {
            return this.WithNewPrimaryPublicIPAddress(leafDnsLabel) as VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Associates an existing public IP address with the virtual machine's primary network interface.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithOS VirtualMachine.Definition.IWithPublicIPAddress.WithExistingPrimaryPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return this.WithExistingPrimaryPublicIPAddress(publicIPAddress) as VirtualMachine.Definition.IWithOS;
        }

        /// <summary>
        /// Specifies the computer name for the virtual machine.
        /// </summary>
        /// <param name="computerName">The computer name.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged.WithComputerName(string computerName)
        {
            return this.WithComputerName(computerName) as VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged;
        }

        /// <summary>
        /// Specifies the custom data for the virtual machine.
        /// </summary>
        /// <param name="base64EncodedCustomData">The base64 encoded custom data.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged.WithCustomData(string base64EncodedCustomData)
        {
            return this.WithCustomData(base64EncodedCustomData) as VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged;
        }

        /// <summary>
        /// Specifies the caching type for the Operating System disk.
        /// </summary>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithOsDiskSettings.WithOSDiskCaching(CachingTypes cachingType)
        {
            return this.WithOSDiskCaching(cachingType) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the size of the OSDisk in GB.
        /// </summary>
        /// <param name="size">The VHD size.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithOsDiskSettings.WithOSDiskSizeInGB(int size)
        {
            return this.WithOSDiskSizeInGB(size) as VirtualMachine.Definition.IWithCreate;
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
        /// Specifies the encryption settings for the OS Disk.
        /// </summary>
        /// <param name="settings">The encryption settings.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithOsDiskSettings.WithOsDiskEncryptionSettings(DiskEncryptionSettings settings)
        {
            return this.WithOsDiskEncryptionSettings(settings) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the encryption settings for the OS Disk.
        /// </summary>
        /// <param name="settings">The encryption settings.</param>
        /// <return>The stage representing creatable VM update.</return>
        VirtualMachine.Update.IUpdate VirtualMachine.Update.IUpdate.WithOsDiskEncryptionSettings(DiskEncryptionSettings settings)
        {
            return this.WithOsDiskEncryptionSettings(settings) as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies an existing AvailabilitySet availability set to to associate the virtual machine with.
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
        /// Adding virtual machines running your application to an availability set ensures that during
        /// maintenance event at least one virtual machine will be available.
        /// </summary>
        /// <param name="name">The name of the availability set.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithCreate VirtualMachine.Definition.IWithAvailabilitySet.WithNewAvailabilitySet(string name)
        {
            return this.WithNewAvailabilitySet(name) as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the administrator password for the Windows virtual machine.
        /// </summary>
        /// <param name="adminPassword">The administrator password. This must follow the criteria for Azure Windows VM password.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachine.Definition.IWithWindowsCreateManagedOrUnmanaged VirtualMachine.Definition.IWithWindowsAdminPasswordManagedOrUnmanaged.WithAdminPassword(string adminPassword)
        {
            return this.WithAdminPassword(adminPassword) as VirtualMachine.Definition.IWithWindowsCreateManagedOrUnmanaged;
        }

        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">The Windows administrator user name. This must follow the required naming convention for Windows user name.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        VirtualMachine.Definition.IWithWindowsAdminPasswordManaged VirtualMachine.Definition.IWithWindowsAdminUsernameManaged.WithAdminUsername(string adminUserName)
        {
            return this.WithAdminUsername(adminUserName) as VirtualMachine.Definition.IWithWindowsAdminPasswordManaged;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine;
        }

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        VirtualMachine.Definition.IWithLinuxCreateUnmanaged VirtualMachine.Definition.IWithLinuxCreateUnmanaged.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey) as VirtualMachine.Definition.IWithLinuxCreateUnmanaged;
        }

        /// <summary>
        /// Specifies the computer name for the virtual machine.
        /// </summary>
        /// <param name="computerName">The computer name.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachine.Definition.IWithFromImageCreateOptionsManaged VirtualMachine.Definition.IWithFromImageCreateOptionsManaged.WithComputerName(string computerName)
        {
            return this.WithComputerName(computerName) as VirtualMachine.Definition.IWithFromImageCreateOptionsManaged;
        }

        /// <summary>
        /// Specifies the custom data for the virtual machine.
        /// </summary>
        /// <param name="base64EncodedCustomData">The base64 encoded custom data.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachine.Definition.IWithFromImageCreateOptionsManaged VirtualMachine.Definition.IWithFromImageCreateOptionsManaged.WithCustomData(string base64EncodedCustomData)
        {
            return this.WithCustomData(base64EncodedCustomData) as VirtualMachine.Definition.IWithFromImageCreateOptionsManaged;
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

        /// <return>An observable that emits extensions attached to the virtual machine.</return>
        async Task<IReadOnlyList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension>> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.GetExtensionsAsync(CancellationToken cancellationToken)
        {
            return await this.GetExtensionsAsync(cancellationToken);
        }

        /// <return>The extensions attached to the Virtual Machine.</return>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.GetExtensions()
        {
            return this.GetExtensions() as System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension>;
        }

        /// <summary>
        /// Gets the unmanaged data disks associated with this virtual machine, indexed by lun.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<int,Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineUnmanagedDataDisk> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.UnmanagedDataDisks
        {
            get
            {
                return this.UnmanagedDataDisks() as System.Collections.Generic.IReadOnlyDictionary<int,Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineUnmanagedDataDisk>;
            }
        }

        /// <summary>
        /// Gets Returns id to the availability set this virtual machine associated with.
        /// Having a set of virtual machines in an availability set ensures that during maintenance
        /// event at least one virtual machine will be available.
        /// </summary>
        /// <summary>
        /// Gets the availabilitySet reference id.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.AvailabilitySetId
        {
            get
            {
                return this.AvailabilitySetId();
            }
        }

        /// <summary>
        /// Gets the operating system disk caching type, valid values are 'None', 'ReadOnly', 'ReadWrite'.
        /// </summary>
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
        /// Gets the virtual machine unique id.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.VMId
        {
            get
            {
                return this.VMId();
            }
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
        /// List of all available virtual machine sizes this virtual machine can resized to.
        /// </summary>
        /// <return>The virtual machine sizes.</return>
        IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.AvailableSizes()
        {
            return this.AvailableSizes();
        }

        /// <summary>
        /// Gets the operating system of this virtual machine.
        /// </summary>
        Models.OperatingSystemTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.OsType
        {
            get
            {
                return this.OsType();
            }
        }

        /// <summary>
        /// Shuts down the Virtual Machine and releases the compute resources.
        /// You are not billed for the compute resources that this Virtual Machine uses.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.Deallocate()
        {
 
            this.Deallocate();
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
        /// Power off (stop) the virtual machine.
        /// You will be billed for the compute resources that this Virtual Machine uses.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.PowerOff()
        {
 
            this.PowerOff();
        }

        /// <summary>
        /// Gets resource id of the managed disk backing OS disk.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.OsDiskId
        {
            get
            {
                return this.OsDiskId();
            }
        }

        /// <summary>
        /// Refreshes the virtual machine instance view to sync with Azure.
        /// this will caches the instance view which can be later retrieved using VirtualMachine.instanceView().
        /// </summary>
        /// <return>The refreshed instance view.</return>
        Models.VirtualMachineInstanceView Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.RefreshInstanceView()
        {
            return this.RefreshInstanceView() as Models.VirtualMachineInstanceView;
        }

        /// <summary>
        /// Gets Refreshes the virtual machine instance view to sync with Azure.
        /// </summary>
        /// <summary>
        /// Gets an observable that emits the instance view of the virtual machine.
        /// </summary>
        async Task<Models.VirtualMachineInstanceView> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.RefreshInstanceViewAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshInstanceViewAsync(cancellationToken);
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
        /// Gets the public IP address associated with this virtual machine's primary network interface.
        /// note that this method makes a rest API call to fetch the resource.
        /// </summary>
        /// <return>The public IP of the primary network interface.</return>
        Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.GetPrimaryPublicIPAddress()
        {
            return this.GetPrimaryPublicIPAddress() as Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress;
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
        /// Gets the storage account type of the managed disk backing Os disk.
        /// </summary>
        Models.StorageAccountTypes? Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.OsDiskStorageAccountType
        {
            get
            {
                return this.OsDiskStorageAccountType();
            }
        }

        /// <summary>
        /// Gets Gets the operating system profile of an Azure virtual machine.
        /// </summary>
        /// <summary>
        /// Gets the osProfile value.
        /// </summary>
        Models.OSProfile Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.OsProfile
        {
            get
            {
                return this.OsProfile() as Models.OSProfile;
            }
        }

        /// <summary>
        /// Gets the uri to the vhd file backing this virtual machine's operating system disk.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.OsUnmanagedDiskVhdUri
        {
            get
            {
                return this.OsUnmanagedDiskVhdUri();
            }
        }

        /// <summary>
        /// Restart the virtual machine.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.Restart()
        {
 
            this.Restart();
        }

        /// <summary>
        /// Gets Returns the diagnostics profile of an Azure virtual machine.
        /// Enabling diagnostic features in a virtual machine enable you to easily diagnose and recover
        /// virtual machine from boot failures.
        /// </summary>
        /// <summary>
        /// Gets the diagnosticsProfile value.
        /// </summary>
        Models.DiagnosticsProfile Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.DiagnosticsProfile
        {
            get
            {
                return this.DiagnosticsProfile() as Models.DiagnosticsProfile;
            }
        }

        /// <summary>
        /// Gets true if managed disk is used for the virtual machine's disks (os, data).
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.IsManagedDiskEnabled
        {
            get
            {
                return this.IsManagedDiskEnabled();
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
            return this.Capture(containerName, vhdPrefix, overwriteVhd);
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

        /// <summary>
        /// Gets Get the virtual machine instance view.
        /// this method returns the cached instance view, to refresh the cache call VirtualMachine.refreshInstanceView().
        /// </summary>
        /// <summary>
        /// Gets the virtual machine instance view.
        /// </summary>
        Models.VirtualMachineInstanceView Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.InstanceView
        {
            get
            {
                return this.InstanceView() as Models.VirtualMachineInstanceView;
            }
        }

        /// <summary>
        /// Gets Returns the storage profile of an Azure virtual machine.
        /// The storage profile contains information such as the details of the VM image or user image
        /// from which this virtual machine is created, the Azure storage account where the operating system
        /// disk is stored, details of the data disk attached to the virtual machine.
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
        /// Generalize the Virtual Machine.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.Generalize()
        {
 
            this.Generalize();
        }

        /// <summary>
        /// Gets the size of the operating system disk in GB.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.OsDiskSize
        {
            get
            {
                return this.OsDiskSize();
            }
        }

        /// <summary>
        /// Gets the managed data disks associated with this virtual machine, indexed by lun.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<int,Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.DataDisks
        {
            get
            {
                return this.DataDisks() as System.Collections.Generic.IReadOnlyDictionary<int,Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk>;
            }
        }

        /// <return>The resource ID of the public IP address associated with this virtual machine's primary network interface.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.GetPrimaryPublicIPAddressId()
        {
            return this.GetPrimaryPublicIPAddressId();
        }

        /// <summary>
        /// Convert (migrate) the virtual machine with un-managed disks to use managed disk.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine.ConvertToManaged()
        {
 
            this.ConvertToManaged();
        }

        /// <summary>
        /// Specifies the administrator password for the Windows virtual machine.
        /// </summary>
        /// <param name="adminPassword">The administrator password. This must follow the criteria for Azure Windows VM password.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachine.Definition.IWithWindowsCreateManaged VirtualMachine.Definition.IWithWindowsAdminPasswordManaged.WithAdminPassword(string adminPassword)
        {
            return this.WithAdminPassword(adminPassword) as VirtualMachine.Definition.IWithWindowsCreateManaged;
        }

        /// <summary>
        /// Create a new virtual network to associate with the virtual machine's primary network interface, based on
        /// the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new virtual network.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithPrivateIP VirtualMachine.Definition.IWithNetwork.WithNewPrimaryNetwork(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetwork> creatable)
        {
            return this.WithNewPrimaryNetwork(creatable) as VirtualMachine.Definition.IWithPrivateIP;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the virtual machine's primary network interface.
        /// the virtual network will be created in the same resource group and region as of virtual machine, it will be
        /// created with the specified address space and a default subnet covering the entirety of the network IP address space.
        /// </summary>
        /// <param name="addressSpace">The address space for the virtual network.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        VirtualMachine.Definition.IWithPrivateIP VirtualMachine.Definition.IWithNetwork.WithNewPrimaryNetwork(string addressSpace)
        {
            return this.WithNewPrimaryNetwork(addressSpace) as VirtualMachine.Definition.IWithPrivateIP;
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
        /// Specifies the SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">The Linux SSH root user name. This must follow the required naming convention for Linux user name.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManaged VirtualMachine.Definition.IWithLinuxRootUsernameManaged.WithRootUsername(string rootUserName)
        {
            return this.WithRootUsername(rootUserName) as VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManaged;
        }
    }

    internal partial class ManagedDataDiskCollection 
    {
    }
}