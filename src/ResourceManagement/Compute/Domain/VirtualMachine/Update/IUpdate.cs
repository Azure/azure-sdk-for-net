// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.Update;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.UpdateDefinition;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Update;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;

    /// <summary>
    /// The template for an update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithUnmanagedDataDisk,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithManagedDataDisk,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithSecondaryNetworkInterface,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithExtension,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithBootDiagnostics,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithManagedServiceIdentity
    {
        /// <summary>
        /// Specifies the encryption settings for the OS Disk.
        /// </summary>
        /// <param name="settings">The encryption settings.</param>
        /// <return>The stage representing creatable VM update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithOSDiskEncryptionSettings(DiskEncryptionSettings settings);

        /// <summary>
        /// Specifies a storage account type.
        /// </summary>
        /// <param name="storageAccountType">A storage account type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithDataDiskDefaultStorageAccountType(StorageAccountTypes storageAccountType);

        /// <summary>
        /// Specifies the size of the OS disk in GB.
        /// Only unmanaged disks may be resized as part of a VM update. Managed disks must be resized separately, using managed disk API.
        /// </summary>
        /// <param name="size">A disk size.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithOSDiskSizeInGB(int size);

        /// <summary>
        /// Specifies the default caching type for the managed data disks.
        /// </summary>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithDataDiskDefaultCachingType(CachingTypes cachingType);

        /// <summary>
        /// Specifies the caching type for the OS disk.
        /// </summary>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithOSDiskCaching(CachingTypes cachingType);

        /// <summary>
        /// Specifies a new size for the virtual machine.
        /// </summary>
        /// <param name="sizeName">The name of a size for the virtual machine as text.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithSize(string sizeName);

        /// <summary>
        /// Specifies a new size for the virtual machine.
        /// </summary>
        /// <param name="size">A size from the list of available sizes for the virtual machine.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithSize(VirtualMachineSizeTypes size);
    }

    /// <summary>
    /// The stage of a virtual machine update allowing to specify a managed data disk.
    /// </summary>
    public interface IWithManagedDataDisk 
    {
        /// <summary>
        /// Associates an existing source managed disk with the VM.
        /// </summary>
        /// <param name="disk">A managed disk.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithExistingDataDisk(IDisk disk);

        /// <summary>
        /// Specifies an existing source managed disk and settings.
        /// </summary>
        /// <param name="disk">The managed disk.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithExistingDataDisk(IDisk disk, int lun, CachingTypes cachingType);

        /// <summary>
        /// Specifies an existing source managed disk and settings.
        /// </summary>
        /// <param name="disk">A managed disk.</param>
        /// <param name="newSizeInGB">The disk resize size in GB.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithExistingDataDisk(IDisk disk, int newSizeInGB, int lun, CachingTypes cachingType);

        /// <summary>
        /// Specifies that a managed disk needs to be created explicitly with the given definition and
        /// attached to the virtual machine as a data disk.
        /// </summary>
        /// <param name="creatable">A creatable disk definition.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithNewDataDisk(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IDisk> creatable);

        /// <summary>
        /// Specifies that a managed disk needs to be created explicitly with the given definition and
        /// attached to the virtual machine as a data disk.
        /// </summary>
        /// <param name="creatable">A creatable disk definition.</param>
        /// <param name="lun">The data disk LUN.</param>
        /// <param name="cachingType">A data disk caching type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithNewDataDisk(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IDisk> creatable, int lun, CachingTypes cachingType);

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given size.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithNewDataDisk(int sizeInGB);

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType);

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">A caching type.</param>
        /// <param name="storageAccountType">A storage account type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType, StorageAccountTypes storageAccountType);

        /// <summary>
        /// Detaches a managed data disk with the given LUN from the virtual machine.
        /// </summary>
        /// <param name="lun">The disk LUN.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithoutDataDisk(int lun);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to enable boot diagnostics.
    /// </summary>
    public interface IWithBootDiagnostics  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that boot diagnostics needs to be disabled in the virtual machine.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithoutBootDiagnostics();

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithBootDiagnostics();

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine.
        /// </summary>
        /// <param name="creatable">The storage account to be created and used for store the boot diagnostics.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithBootDiagnostics(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable);

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be uses to store the boot diagnostics.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithBootDiagnostics(IStorageAccount storageAccount);

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine.
        /// </summary>
        /// <param name="storageAccountBlobEndpointUri">A storage account blob endpoint to store the boot diagnostics.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithBootDiagnostics(string storageAccountBlobEndpointUri);
    }

    /// <summary>
    /// The stage of a virtual machine definition allowing to specify unmanaged data disk configuration.
    /// </summary>
    public interface IWithUnmanagedDataDisk 
    {
        /// <summary>
        /// Specifies an existing VHD that needs to be attached to the virtual machine as data disk.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="containerName">The name of the container holding the VHD file.</param>
        /// <param name="vhdName">The name for the VHD file.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithExistingUnmanagedDataDisk(string storageAccountName, string containerName, string vhdName);

        /// <summary>
        /// Begins the description of an update of an existing unmanaged data disk of this virtual machine.
        /// </summary>
        /// <param name="name">The name of an existing disk.</param>
        /// <return>The first stage of the data disk update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.Update.IUpdate UpdateUnmanagedDataDisk(string name);

        /// <summary>
        /// Detaches an unmanaged data disk from the virtual machine.
        /// </summary>
        /// <param name="name">The name of an existing data disk to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithoutUnmanagedDataDisk(string name);

        /// <summary>
        /// Detaches a unmanaged data disk from the virtual machine.
        /// </summary>
        /// <param name="lun">The logical unit number of the data disk to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithoutUnmanagedDataDisk(int lun);

        /// <summary>
        /// Specifies that a new blank unmanaged data disk needs to be attached to virtual machine.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithNewUnmanagedDataDisk(int sizeInGB);

        /// <summary>
        /// Begins the definition of a blank unmanaged data disk to be attached to the virtual machine along with its configuration.
        /// </summary>
        /// <param name="name">The name for the data disk.</param>
        /// <return>The first stage of the data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.UpdateDefinition.IBlank<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate> DefineUnmanagedDataDisk(string name);
    }

    /// <summary>
    /// The stage of a virtual machine update allowing to specify extensions.
    /// </summary>
    public interface IWithExtension 
    {
        /// <summary>
        /// Begins the description of an update of an existing extension of this virtual machine.
        /// </summary>
        /// <param name="name">The reference name of an existing extension.</param>
        /// <return>The first stage of an extension update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Update.IUpdate UpdateExtension(string name);

        /// <summary>
        /// Begins the definition of an extension to be attached to the virtual machine.
        /// </summary>
        /// <param name="name">A reference name for the extension.</param>
        /// <return>The first stage of an extension definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.UpdateDefinition.IBlank<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate> DefineNewExtension(string name);

        /// <summary>
        /// Detaches an extension from the virtual machine.
        /// </summary>
        /// <param name="name">The reference name of the extension to be removed/uninstalled.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithoutExtension(string name);
    }

    /// <summary>
    /// The stage of a virtual machine update allowing to specify additional network interfaces.
    /// </summary>
    public interface IWithSecondaryNetworkInterface 
    {
        /// <summary>
        /// Removes a secondary network interface from the virtual machine.
        /// </summary>
        /// <param name="name">The name of a secondary network interface to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithoutSecondaryNetworkInterface(string name);

        /// <summary>
        /// Associates an existing network interface with the virtual machine.
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="networkInterface">An existing network interface.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithExistingSecondaryNetworkInterface(INetworkInterface networkInterface);

        /// <summary>
        /// Creates a new network interface to associate with the virtual machine.
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new network interface.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithNewSecondaryNetworkInterface(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface> creatable);
    }

    /// <summary>
    /// The stage of the virtual machine update allowing to enable Managed Service Identity.
    /// </summary>
    public interface IWithManagedServiceIdentity :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that Managed Service Identity needs to be enabled in the virtual machine.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithRoleAndScopeOrUpdate WithManagedServiceIdentity();

        /// <summary>
        /// Specifies that Managed Service Identity needs to be enabled in the virtual machine.
        /// </summary>
        /// <param name="tokenPort">The port on the virtual machine where access token is available.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithRoleAndScopeOrUpdate WithManagedServiceIdentity(int tokenPort);
    }

    /// <summary>
    /// The stage of the Managed Service Identity enabled virtual machine allowing to set role
    /// assignment for a scope.
    /// </summary>
    public interface IWithRoleAndScopeOrUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate
    {
        /// <summary>
        /// Specifies that applications running on the virtual machine requires the given access role
        /// definition with scope of access limited to the ARM resource identified by the resource id
        /// specified in the scope parameter.
        /// </summary>
        /// <param name="scope">Scope of the access represented in ARM resource ID format.</param>
        /// <param name="roleDefinitionId">Access role definition to assigned to the virtual machine.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithRoleAndScopeOrUpdate WithRoleDefinitionBasedAccessTo(string scope, string roleDefinitionId);

        /// <summary>
        /// Specifies that applications running on the virtual machine requires the given access role
        /// with scope of access limited to the current resource group that the virtual machine
        /// resides.
        /// </summary>
        /// <param name="asRole">Access role to assigned to the virtual machine.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithRoleAndScopeOrUpdate WithRoleBasedAccessToCurrentResourceGroup(BuiltInRole asRole);

        /// <summary>
        /// Specifies that applications running on the virtual machine requires the given access role
        /// with scope of access limited to the ARM resource identified by the resource ID specified
        /// in the scope parameter.
        /// </summary>
        /// <param name="scope">Scope of the access represented in ARM resource ID format.</param>
        /// <param name="asRole">Access role to assigned to the virtual machine.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithRoleAndScopeOrUpdate WithRoleBasedAccessTo(string scope, BuiltInRole asRole);

        /// <summary>
        /// Specifies that applications running on the virtual machine requires the given access role
        /// definition with scope of access limited to the current resource group that the virtual
        /// machine resides.
        /// </summary>
        /// <param name="roleDefinitionId">Access role definition to assigned to the virtual machine.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithRoleAndScopeOrUpdate WithRoleDefinitionBasedAccessToCurrentResourceGroup(string roleDefinitionId);
    }
}