/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition
{

    using Microsoft.Azure.Management.V2.Compute;
    using Microsoft.Azure.Management.V2.Network;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Resource.Core.Resource.Definition;
    using Microsoft.Azure.Management.V2.Storage;
    /// <summary>
    /// The stage of the Windows virtual machine scale set definition which contains all the minimum required
    /// inputs for the resource to be created (via {@link WithCreate#create()}, but also allows for any other
    /// optional settings to be specified.
    /// </summary>
    public interface IWithWindowsCreate  :
        IWithCreate
    {
        /// <summary>
        /// Specifies that VM Agent should not be provisioned.
        /// </summary>
        /// <returns>the stage representing creatable Windows VM scale set definition</returns>
        IWithWindowsCreate DisableVmAgent { get; }

        /// <summary>
        /// Specifies that automatic updates should be disabled.
        /// </summary>
        /// <returns>the stage representing creatable Windows VM scale set definition</returns>
        IWithWindowsCreate DisableAutoUpdate { get; }

        /// <summary>
        /// Specifies the time-zone.
        /// </summary>
        /// <param name="timeZone">timeZone the timezone</param>
        /// <returns>the stage representing creatable Windows VM scale set definition</returns>
        IWithWindowsCreate WithTimeZone (string timeZone);

        /// <summary>
        /// Specifies the WINRM listener.
        /// <p>
        /// Each call to this method adds the given listener to the list of VM's WinRM listeners.
        /// </summary>
        /// <param name="listener">listener the WinRmListener</param>
        /// <returns>the stage representing creatable Windows VM scale set definition</returns>
        IWithWindowsCreate WithWinRm (WinRMListener listener);

    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify password.
    /// </summary>
    public interface IWithPassword 
    {
        /// <summary>
        /// Specifies the password for the virtual machines in the scale set.
        /// </summary>
        /// <param name="password">password the password. This must follow the criteria for Azure VM password.</param>
        /// <returns>the stage representing creatable VM scale set definition</returns>
        IWithCreate WithPassword (string password);

    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify upgrade policy.
    /// </summary>
    public interface IWithUpgradePolicy 
    {
        /// <summary>
        /// Specifies virtual machine scale set upgrade policy mode.
        /// </summary>
        /// <param name="upgradeMode">upgradeMode upgrade policy mode</param>
        /// <returns>the stage representing creatable VM scale set definition</returns>
        IWithCreate WithUpgradeMode (UpgradeMode upgradeMode);

    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify a public load balancer for
    /// the primary network interface of the scale set virtual machines.
    /// </summary>
    public interface IWithPrimaryInternetFacingLoadBalancer 
    {
        /// <summary>
        /// Specify the public load balancer where it's backends and/or NAT pools can be assigned to the primary network
        /// interface of the scale set virtual machines.
        /// <p>
        /// By default all the backend and inbound NAT pool of the load balancer will be associated with the primary
        /// network interface of the scale set virtual machines unless subset of them is selected in the next stages
        /// {@link WithPrimaryInternetFacingLoadBalancerBackendOrNatPool}.
        /// <p>
        /// </summary>
        /// <param name="loadBalancer">loadBalancer an existing public load balancer</param>
        /// <returns>the next stage of the definition</returns>
        IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool WithPrimaryInternetFacingLoadBalancer (ILoadBalancer loadBalancer);

        /// <summary>
        /// Specifies that no public load balancer needs to be associated with virtual machine scale set.
        /// </summary>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        IWithPrimaryInternalLoadBalancer WithoutPrimaryInternetFacingLoadBalancer ();

    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify virtual network subnet for the
    /// virtual machine's primary network interface in the scale set.
    /// </summary>
    public interface IWithSubnet 
    {
        /// <summary>
        /// Associates a subnet with the primary network interface of virtual machines in the scale set.
        /// </summary>
        /// <param name="name">name the subnet name</param>
        /// <returns>the next stage of the definition</returns>
        IWithPrimaryInternetFacingLoadBalancer WithSubnet (string name);

    }
    /// <summary>
    /// The stage of the Linux virtual machine scale set definition allowing to specify root user name.
    /// </summary>
    public interface IWithRootUserName 
    {
        /// <summary>
        /// Specifies the root user name for the Linux virtual machines in the scale set.
        /// </summary>
        /// <param name="rootUserName">rootUserName the Linux root user name. This must follow the required naming convention for Linux user name</param>
        /// <returns>the next stage of the Linux virtual machine scale set definition</returns>
        IWithLinuxCreate WithRootUserName (string rootUserName);

    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to associate inbound NAT pool of the internal
    /// load balancer selected in the previous state {@link WithPrimaryInternalLoadBalancer} with the primary network
    /// interface of the scale set virtual machines.
    /// </summary>
    public interface IWithInternalInternalLoadBalancerNatPool  :
        IWithOS
    {
        /// <summary>
        /// Associate internal load balancer inbound NAT pools with the the primary network interface of the
        /// scale set virtual machine.
        /// </summary>
        /// <param name="natPoolNames">natPoolNames inbound NAT pool names</param>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        IWithOS WithPrimaryInternalLoadBalancerInboundNatPools (string natPoolNames);

    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to associate backend pool and/or inbound NAT pool
    /// of the internet facing load balancer selected in the previous state {@link WithPrimaryInternetFacingLoadBalancer}
    /// with the primary network interface of the scale set virtual machines.
    /// </summary>
    public interface IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool  :
        IWithPrimaryInternetFacingLoadBalancerNatPool
    {
        /// <summary>
        /// Associate internet facing load balancer backends with the primary network interface of the scale set virtual machines.
        /// </summary>
        /// <param name="backendNames">backendNames the backend names</param>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        IWithPrimaryInternetFacingLoadBalancerNatPool WithPrimaryInternetFacingLoadBalancerBackends (string backendNames);

    }
    /// <summary>
    /// The stage of the virtual machine definition allowing to specify extensions.
    /// </summary>
    public interface IWithExtension 
    {
        /// <summary>
        /// Specifies definition of an extension to be attached to the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">name the reference name for the extension</param>
        /// <returns>the stage representing configuration for the extension</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IBlank<IWithCreate> DefineNewExtension (string name);

    }
    /// <summary>
    /// The stage of the Windows virtual machine scale set definition allowing to specify administrator user name.
    /// </summary>
    public interface IWithAdminUserName 
    {
        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machines in the scale set.
        /// </summary>
        /// <param name="adminUserName">adminUserName the Windows administrator user name. This must follow the required naming convention for Windows user name.</param>
        /// <returns>the stage representing creatable Windows VM scale set definition</returns>
        IWithWindowsCreate WithAdminUserName (string adminUserName);

    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify virtual network for the  primary
    /// network configuration.
    /// </summary>
    public interface IWithNetwork 
    {
        /// <summary>
        /// Associate an existing virtual network with the primary network interface of the virtual machines
        /// in the scale set.
        /// </summary>
        /// <param name="network">network an existing virtual network</param>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        IWithSubnet WithExistingPrimaryNetwork (INetwork network);

    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition.IWithGroup<IWithSku>
    {
    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify whether
    /// or not over provision virtual machines in the scale set.
    /// </summary>
    public interface IWithOverProvision 
    {
        /// <summary>
        /// Enable or disable over provisioning of virtual machines in the scale set.
        /// </summary>
        /// <param name="enabled">enabled true to enable over provisioning of virtual machines in the</param>
        /// <param name="scale">scale set.</param>
        /// <returns>Enable over provision of virtual machines.</returns>
        IWithCreate WithOverProvision (bool enabled);

        /// <summary>
        /// Enable over provision of virtual machines.
        /// </summary>
        /// <returns>the stage representing creatable VM scale set definition</returns>
        IWithCreate WithOverProvisionEnabled ();

        /// <summary>
        /// Disable over provision of virtual machines.
        /// </summary>
        /// <returns>the stage representing creatable VM scale set definition</returns>
        IWithCreate WithOverProvisionDisabled ();

    }
    /// <summary>
    /// The entirety of the load balancer definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IBlank,
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithGroup,
        IWithSku,
        IWithNetwork,
        IWithSubnet,
        IWithPrimaryInternetFacingLoadBalancer,
        IWithPrimaryInternalLoadBalancer,
        IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool,
        IWithInternalLoadBalancerBackendOrNatPool,
        IWithPrimaryInternetFacingLoadBalancerNatPool,
        IWithInternalInternalLoadBalancerNatPool,
        IWithOS,
        IWithAdminUserName,
        IWithRootUserName,
        IWithLinuxCreate,
        IWithWindowsCreate,
        IWithCreate
    {
    }
    /// <summary>
    /// The stage of a virtual machine scale set definition containing all the required inputs for the resource
    /// to be created (via {@link WithCreate#create()}), but also allowing for any other optional settings
    /// to be specified.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<IVirtualMachineScaleSet>,
        IWithPassword,
        IWithOsDiskSettings,
        IWithComputerNamePrefix,
        IWithCapacity,
        IWithUpgradePolicy,
        IWithOverProvision,
        IWithStorageAccount,
        IWithExtension,
        IDefinitionWithTags<IWithCreate>
    {
    }
    /// <summary>
    /// The stage of the Linux virtual machine scale set definition which contains all the minimum required inputs
    /// for the resource to be created (via {@link WithCreate#create()}), but also allows for any other optional
    /// settings to be specified.
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
        /// <returns>the stage representing creatable Linux VM scale set definition</returns>
        IWithLinuxCreate WithSsh (string publicKey);

    }
    /// <summary>
    /// The first stage of a virtual machine scale set definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithGroup>
    {
    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify Sku for the virtual machines.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies sku for the virtual machines in the scale set.
        /// </summary>
        /// <param name="skuType">skuType the sku type</param>
        /// <returns>the stage representing creatable VM scale set definition</returns>
        IWithNetwork WithSku (VirtualMachineScaleSetSkuTypes skuType);

        /// <summary>
        /// Specifies sku for the virtual machines in the scale set.
        /// </summary>
        /// <param name="sku">sku a sku from the list of available sizes for the virtual machines in this scale set</param>
        /// <returns>the stage representing creatable VM scale set definition</returns>
        IWithNetwork WithSku (IVirtualMachineScaleSetSku sku);

    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify the computer name prefix.
    /// </summary>
    public interface IWithComputerNamePrefix 
    {
        /// <summary>
        /// Specifies the bane prefix for the virtual machines in the scale set.
        /// </summary>
        /// <param name="namePrefix">namePrefix the prefix for the name of virtual machines in the scale set.</param>
        /// <returns>the stage representing creatable VM scale set definition</returns>
        IWithCreate WithComputerNamePrefix (string namePrefix);

    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify OS disk configurations.
    /// </summary>
    public interface IWithOsDiskSettings 
    {
        /// <summary>
        /// Specifies the caching type for the Operating System disk.
        /// </summary>
        /// <param name="cachingType">cachingType the caching type.</param>
        /// <returns>the stage representing creatable VM scale set definition</returns>
        IWithCreate WithOsDiskCaching (CachingTypes cachingType);

        /// <summary>
        /// Specifies the name for the OS Disk.
        /// </summary>
        /// <param name="name">name the OS Disk name.</param>
        /// <returns>the stage representing creatable VM scale set definition</returns>
        IWithCreate WithOsDiskName (string name);

    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify the Operation System image.
    /// </summary>
    public interface IWithOS 
    {
        /// <summary>
        /// Specifies the known marketplace Windows image used as OS for virtual machines in the scale set.
        /// </summary>
        /// <param name="knownImage">knownImage enum value indicating known market-place image</param>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        IWithAdminUserName WithPopularWindowsImage (KnownWindowsVirtualMachineImage knownImage);

        /// <summary>
        /// Specifies that the latest version of a marketplace Windows image needs to be used.
        /// </summary>
        /// <param name="publisher">publisher specifies the publisher of the image</param>
        /// <param name="offer">offer specifies the offer of the image</param>
        /// <param name="sku">sku specifies the SKU of the image</param>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        IWithAdminUserName WithLatestWindowsImage (string publisher, string offer, string sku);

        /// <summary>
        /// Specifies the version of a marketplace Windows image needs to be used.
        /// </summary>
        /// <param name="imageReference">imageReference describes publisher, offer, sku and version of the market-place image</param>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        IWithAdminUserName WithSpecificWindowsImageVersion (ImageReference imageReference);

        /// <summary>
        /// Specifies the user (custom) Windows image used for as the OS for virtual machines in the
        /// scale set.
        /// <p>
        /// Custom images are currently limited to single storage account and the number of virtual machines
        /// in the scale set that can be created using custom image is limited to 40 when over provision
        /// is disabled {@link WithOverProvision} and up to 20 when enabled.
        /// </p>
        /// </summary>
        /// <param name="imageUrl">imageUrl the url the the VHD</param>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        IWithAdminUserName WithStoredWindowsImage (string imageUrl);

        /// <summary>
        /// Specifies the known marketplace Linux image used for the virtual machine's OS.
        /// </summary>
        /// <param name="knownImage">knownImage enum value indicating known market-place image</param>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        IWithRootUserName WithPopularLinuxImage (KnownLinuxVirtualMachineImage knownImage);

        /// <summary>
        /// Specifies that the latest version of a marketplace Linux image needs to be used.
        /// </summary>
        /// <param name="publisher">publisher specifies the publisher of the image</param>
        /// <param name="offer">offer specifies the offer of the image</param>
        /// <param name="sku">sku specifies the SKU of the image</param>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        IWithRootUserName WithLatestLinuxImage (string publisher, string offer, string sku);

        /// <summary>
        /// Specifies the version of a market-place Linux image needs to be used.
        /// </summary>
        /// <param name="imageReference">imageReference describes publisher, offer, sku and version of the market-place image</param>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        IWithRootUserName WithSpecificLinuxImageVersion (ImageReference imageReference);

        /// <summary>
        /// Specifies the user (custom) Linux image used for the virtual machine's OS.
        /// <p>
        /// Custom images are currently limited to single storage account and the number of virtual machines
        /// in the scale set that can be created using custom image is limited to 40 when over provision
        /// is disabled {@link WithOverProvision} and up to 20 when enabled.
        /// </p>
        /// </summary>
        /// <param name="imageUrl">imageUrl the url the the VHD</param>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        IWithRootUserName WithStoredLinuxImage (string imageUrl);

    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify storage account.
    /// </summary>
    public interface IWithStorageAccount 
    {
        /// <summary>
        /// Specifies the name of a new storage account to put the OS and data disk VHD of the virtual machines
        /// in the scale set.
        /// </summary>
        /// <param name="name">name the name of the storage account</param>
        /// <returns>the stage representing creatable VM scale set definition</returns>
        IWithCreate WithNewStorageAccount (string name);

        /// <summary>
        /// Specifies definition of a not-yet-created storage account definition
        /// to put OS and data disk VHDs of virtual machines in the scale set.
        /// </summary>
        /// <param name="creatable">creatable the storage account in creatable stage</param>
        /// <returns>the stage representing creatable VM scale set definition</returns>
        IWithCreate WithNewStorageAccount (ICreatable<IStorageAccount> creatable);

        /// <summary>
        /// Specifies an existing {@link StorageAccount} storage account to put the OS and data disk VHD of
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="storageAccount">storageAccount an existing storage account</param>
        /// <returns>the stage representing creatable VM scale set definition</returns>
        IWithCreate WithExistingStorageAccount (IStorageAccount storageAccount);

    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify number of
    /// virtual machines in the scale set.
    /// </summary>
    public interface IWithCapacity 
    {
        /// <summary>
        /// Specifies the number of virtual machines in the scale set.
        /// </summary>
        /// <param name="capacity">capacity the virtual machine capacity</param>
        /// <returns>the stage representing creatable VM scale set definition</returns>
        IWithCreate WithCapacity (int capacity);

    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify an internal load balancer for
    /// the primary network interface of the scale set virtual machines.
    /// </summary>
    public interface IWithPrimaryInternalLoadBalancer 
    {
        /// <summary>
        /// Specify the internal load balancer where it's backends and/or NAT pools can be assigned to the primary network
        /// interface of the scale set virtual machines.
        /// <p>
        /// By default all the backend and inbound NAT pool of the load balancer will be associated with the primary
        /// network interface of the scale set virtual machines unless subset of them is selected in the next stages
        /// {@link WithInternalLoadBalancerBackendOrNatPool}.
        /// <p>
        /// </summary>
        /// <param name="loadBalancer">loadBalancer an existing internal load balancer</param>
        /// <returns>the next stage of the definition</returns>
        IWithInternalLoadBalancerBackendOrNatPool WithPrimaryInternalLoadBalancer (ILoadBalancer loadBalancer);

        /// <summary>
        /// Specifies that no internal load balancer needs to be associated with primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        IWithOS WithoutPrimaryInternalLoadBalancer ();

    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to associate backend pool and/or inbound NAT pool
    /// of the internal load balancer selected in the previous state {@link WithPrimaryInternalLoadBalancer} with the
    /// primary network interface of the scale set virtual machines.
    /// </summary>
    public interface IWithInternalLoadBalancerBackendOrNatPool  :
        IWithCreate
    {
        /// <summary>
        /// Associate internal load balancer backends with the primary network interface of the scale set virtual machines.
        /// </summary>
        /// <param name="backendNames">backendNames the backend names</param>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        IWithInternalInternalLoadBalancerNatPool WithPrimaryInternalLoadBalancerBackends (string backendNames);

    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to associate inbound NAT pool of the internet
    /// facing load balancer selected in the previous state {@link WithPrimaryInternetFacingLoadBalancer} with the
    /// primary network interface of the scale set virtual machines.
    /// </summary>
    public interface IWithPrimaryInternetFacingLoadBalancerNatPool  :
        IWithPrimaryInternalLoadBalancer
    {
        /// <summary>
        /// Associate internet facing load balancer inbound NAT pools with the the primary network interface of the
        /// scale set virtual machines.
        /// </summary>
        /// <param name="natPoolNames">natPoolNames the inbound NAT pool names</param>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        IWithPrimaryInternalLoadBalancer WithPrimaryInternetFacingLoadBalancerInboundNatPools (string natPoolNames);

    }
}