// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition
{

    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.Fluent.Storage;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.Fluent.Resource.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.Fluent.Network;
    using Microsoft.Azure.Management.Fluent.Resource.Core.Resource.Definition;
    using Microsoft.Azure.Management.Fluent.Compute;
    using Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition;
    /// <summary>
    /// The stage of a Windows virtual machine scale set definition which contains all the minimum required
    /// inputs for the resource to be created (via {@link WithCreate#create()}, but also allows for any other
    /// optional settings to be specified.
    /// </summary>
    public interface IWithWindowsCreate  :
        IWithCreate
    {
        /// <summary>
        /// Enables the VM agent.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate WithVmAgent();

        /// <summary>
        /// Disables the VM agent.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate WithoutVmAgent();

        /// <summary>
        /// Enables automatic updates.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate WithAutoUpdate();

        /// <summary>
        /// Disables automatic updates.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate WithoutAutoUpdate();

        /// <summary>
        /// Specifies the time zone for the virtual machines to use.
        /// </summary>
        /// <param name="timeZone">timeZone a time zone</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate WithTimeZone(string timeZone);

        /// <summary>
        /// Specifies the WinRM listener.
        /// <p>
        /// Each call to this method adds the given listener to the list of VM's WinRM listeners.
        /// </summary>
        /// <param name="listener">listener a WinRm listener</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate WithWinRm(WinRMListener listener);

    }
    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify the storage account.
    /// </summary>
    public interface IWithStorageAccount 
    {
        /// <summary>
        /// Specifies a new storage account for the OS and data disk VHDs of the virtual machines
        /// in the scale set.
        /// </summary>
        /// <param name="name">name the name of the storage account</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate WithNewStorageAccount(string name);

        /// <summary>
        /// Specifies a new storage account for the OS and data disk VHDs of the virtual machines
        /// in the scale set.
        /// </summary>
        /// <param name="creatable">creatable the storage account definition in a creatable stage</param>
        /// <returns>the next stage in the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Fluent.Storage.IStorageAccount> creatable);

        /// <summary>
        /// Specifies an existing {@link StorageAccount} for the OS and data disk VHDs of
        /// the virtual machines in the scale set.
        /// </summary>
        /// <param name="storageAccount">storageAccount an existing storage account</param>
        /// <returns>the next stage in the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate WithExistingStorageAccount(IStorageAccount storageAccount);

    }
    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify the upgrade policy.
    /// </summary>
    public interface IWithUpgradePolicy 
    {
        /// <summary>
        /// Specifies the virtual machine scale set upgrade policy mode.
        /// </summary>
        /// <param name="upgradeMode">upgradeMode an upgrade policy mode</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate WithUpgradeMode(UpgradeMode upgradeMode);

    }
    /// <summary>
    /// The entirety of the load balancer definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IBlank,
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithGroup,
        IWithSku,
        IWithNetworkSubnet,
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
    /// The stage of a virtual machine scale set definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.Fluent.Resource.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithSku>
    {
    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify the operating system image.
    /// </summary>
    public interface IWithOS 
    {
        /// <summary>
        /// Specifies a known marketplace Windows image used as the operating system for the virtual machines in the scale set.
        /// </summary>
        /// <param name="knownImage">knownImage a known market-place image</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName WithPopularWindowsImage(KnownWindowsVirtualMachineImage knownImage);

        /// <summary>
        /// Specifies that the latest version of the specified marketplace Windows image should be used.
        /// </summary>
        /// <param name="publisher">publisher specifies the publisher of the image</param>
        /// <param name="offer">offer specifies the offer of the image</param>
        /// <param name="sku">sku specifies the SKU of the image</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName WithLatestWindowsImage(string publisher, string offer, string sku);

        /// <summary>
        /// Specifies the specific version of a marketplace Windows image needs to be used.
        /// </summary>
        /// <param name="imageReference">imageReference describes publisher, offer, SKU and version of the marketplace image</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName WithSpecificWindowsImageVersion(ImageReference imageReference);

        /// <summary>
        /// Specifies the user (custom) Windows image to be used as the operating system for the virtual machines in the
        /// scale set.
        /// </summary>
        /// <param name="imageUrl">imageUrl the URL of the VHD</param>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName WithStoredWindowsImage(string imageUrl);

        /// <summary>
        /// Specifies a known marketplace Linux image used as the virtual machine's operating system.
        /// </summary>
        /// <param name="knownImage">knownImage a known market-place image</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName WithPopularLinuxImage(KnownLinuxVirtualMachineImage knownImage);

        /// <summary>
        /// Specifies that the latest version of a marketplace Linux image should be used.
        /// </summary>
        /// <param name="publisher">publisher the publisher of the image</param>
        /// <param name="offer">offer the offer of the image</param>
        /// <param name="sku">sku the SKU of the image</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName WithLatestLinuxImage(string publisher, string offer, string sku);

        /// <summary>
        /// Specifies the specific version of a market-place Linux image that should be used.
        /// </summary>
        /// <param name="imageReference">imageReference describes the publisher, offer, SKU and version of the market-place image</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName WithSpecificLinuxImageVersion(ImageReference imageReference);

        /// <summary>
        /// Specifies the user (custom) Linux image used as the virtual machine's operating system.
        /// </summary>
        /// <param name="imageUrl">imageUrl the url the the VHD</param>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName WithStoredLinuxImage(string imageUrl);

    }
    /// <summary>
    /// The stage of a Linux virtual machine scale set definition which contains all the minimum required inputs
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
        /// <param name="publicKey">publicKey an SSH public key in the PEM format.</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithLinuxCreate WithSsh(string publicKey);

    }
    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify an internal load balancer for
    /// the primary network interface of the virtual machines in the scale set.
    /// </summary>
    public interface IWithPrimaryInternalLoadBalancer 
    {
        /// <summary>
        /// Specifies the internal load balancer whose backends and/or NAT pools can be assigned to the primary network
        /// interface of the virtual machines in the scale set.
        /// <p>
        /// By default all the backends and inbound NAT pools of the load balancer will be associated with the primary
        /// network interface of the virtual machines in the scale set, unless subset of them is selected in the next stages.
        /// <p>
        /// </summary>
        /// <param name="loadBalancer">loadBalancer an existing internal load balancer</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithInternalLoadBalancerBackendOrNatPool WithPrimaryInternalLoadBalancer(ILoadBalancer loadBalancer);

        /// <summary>
        /// Specifies that no internal load balancer should be associated with the primary network interfaces of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithOS WithoutPrimaryInternalLoadBalancer();

    }
    /// <summary>
    /// The stage of a virtual machine scale set definition containing all the required inputs for the resource
    /// to be created (via {@link WithCreate#create()}), but also allowing for any other optional settings
    /// to be specified.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet>,
        IWithPassword,
        IWithOsDiskSettings,
        IWithComputerNamePrefix,
        IWithCapacity,
        IWithUpgradePolicy,
        IWithOverProvision,
        IWithStorageAccount,
        IWithExtension,
        IDefinitionWithTags<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>
    {
    }
    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to associate a backend pool and/or an inbound NAT pool
    /// of the selected Internet-facing load balancer with the primary network interface of the virtual machines in the scale set.
    /// </summary>
    public interface IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool  :
        IWithPrimaryInternetFacingLoadBalancerNatPool
    {
        /// <summary>
        /// Associates the specified backends of the selected load balancer with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">backendNames the names of existing backends in the selected load balancer</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerNatPool WithPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames);

    }
    /// <summary>
    /// The stage of a Windows virtual machine scale set definition allowing to specify the administrator user name.
    /// </summary>
    public interface IWithAdminUserName 
    {
        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machines in the scale set.
        /// </summary>
        /// <param name="adminUserName">adminUserName a Windows administrator user name, following the required naming convention for Windows user names</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate WithAdminUserName(string adminUserName);

    }
    /// <summary>
    /// The first stage of a virtual machine scale set definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithGroup>
    {
    }
    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to associate backend pools and/or inbound NAT pools
    /// of the selected internal load balancer with the primary network interface of the virtual machines in the scale set.
    /// </summary>
    public interface IWithInternalLoadBalancerBackendOrNatPool  :
        IWithCreate
    {
        /// <summary>
        /// Associates the specified backends of the selected load balancer with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">backendNames names of existing backends in the selected load balancer</param>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithInternalInternalLoadBalancerNatPool WithPrimaryInternalLoadBalancerBackends(params string[] backendNames);

    }
    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to associate an inbound NAT pool of the selected
    /// Internet-facing load balancer with the primary network interface of the virtual machines in the scale set.
    /// </summary>
    public interface IWithPrimaryInternetFacingLoadBalancerNatPool  :
        IWithPrimaryInternalLoadBalancer
    {
        /// <summary>
        /// Associates the specified inbound NAT pools of the selected internal load balancer with the primary network
        /// interface of the virtual machines in the scale set.
        /// </summary>
        /// <param name="natPoolNames">natPoolNames inbound NAT pools names existing on the selected load balancer</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer WithPrimaryInternetFacingLoadBalancerInboundNatPools(params string[] natPoolNames);

    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify number of
    /// virtual machines in the scale set.
    /// </summary>
    public interface IWithCapacity 
    {
        /// <summary>
        /// Specifies the maximum number of virtual machines in the scale set.
        /// </summary>
        /// <param name="capacity">capacity the virtual machine capacity</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate WithCapacity(int capacity);

    }
    /// <summary>
    /// The stage of a virtual machine definition allowing to specify extensions.
    /// </summary>
    public interface IWithExtension 
    {
        /// <summary>
        /// Begins the definition of an extension reference to be attached to the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">name the reference name for the extension</param>
        /// <returns>the first stage of the extension reference definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IBlank<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate> DefineNewExtension(string name);

    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to associate inbound NAT pools of the selected
    /// internal load balancer with the primary network interface of the virtual machines in the scale set.
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
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithOS WithPrimaryInternalLoadBalancerInboundNatPools(params string[] natPoolNames);

    }
    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify the virtual network subnet for the
    /// primary network configuration.
    /// </summary>
    public interface IWithNetworkSubnet 
    {
        /// <summary>
        /// Associate an existing virtual network subnet with the primary network interface of the virtual machines
        /// in the scale set.
        /// </summary>
        /// <param name="network">network an existing virtual network</param>
        /// <param name="subnetName">subnetName the subnet name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancer WithExistingPrimaryNetworkSubnet(INetwork network, string subnetName);

    }
    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify OS disk configurations.
    /// </summary>
    public interface IWithOsDiskSettings 
    {
        /// <summary>
        /// Specifies the caching type for the operating system disk.
        /// </summary>
        /// <param name="cachingType">cachingType the caching type</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate WithOsDiskCaching(CachingTypes cachingType);

        /// <summary>
        /// Specifies the name for the OS disk.
        /// </summary>
        /// <param name="name">name the OS disk name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate WithOsDiskName(string name);

    }
    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify the password.
    /// </summary>
    public interface IWithPassword 
    {
        /// <summary>
        /// Specifies the password for the virtual machines in the scale set.
        /// </summary>
        /// <param name="password">password a password following the requirements for Azure virtual machine passwords</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate WithPassword(string password);

    }
    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify an Internet-facing load balancer for
    /// the primary network interface of the virtual machines in the scale set.
    /// </summary>
    public interface IWithPrimaryInternetFacingLoadBalancer 
    {
        /// <summary>
        /// Specifies an Internet-facing load balancer whose backends and/or NAT pools can be assigned to the primary
        /// network interfaces of the virtual machines in the scale set.
        /// <p>
        /// By default, all the backends and inbound NAT pools of the load balancer will be associated with the primary
        /// network interface of the scale set virtual machines.
        /// <p>
        /// </summary>
        /// <param name="loadBalancer">loadBalancer an existing Internet-facing load balancer</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool WithPrimaryInternetFacingLoadBalancer(ILoadBalancer loadBalancer);

        /// <summary>
        /// Specifies that no public load balancer should be associated with the virtual machine scale set.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer WithoutPrimaryInternetFacingLoadBalancer();

    }
    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify SKU for the virtual machines.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="skuType">skuType the SKU type</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithNetworkSubnet WithSku(VirtualMachineScaleSetSkuTypes skuType);

        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="sku">sku a SKU from the list of available sizes for the virtual machines in this scale set</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithNetworkSubnet WithSku(IVirtualMachineScaleSetSku sku);

    }
    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify whether
    /// or not to over-provision virtual machines in the scale set.
    /// </summary>
    public interface IWithOverProvision 
    {
        /// <summary>
        /// Enables or disables over-provisioning of virtual machines in the scale set.
        /// </summary>
        /// <param name="enabled">enabled true if enabling over-0provisioning of virtual machines in the</param>
        /// <param name="scale">scale set, otherwise false</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate WithOverProvision(bool enabled);

        /// <summary>
        /// Enables over-provisioning of virtual machines.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate WithOverProvisioning();

        /// <summary>
        /// Disables over-provisioning of virtual machines.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate WithoutOverProvisioning();

    }
    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify the computer name prefix.
    /// </summary>
    public interface IWithComputerNamePrefix 
    {
        /// <summary>
        /// Specifies the name prefix to use for auto-generating the names for the virtual machines in the scale set.
        /// </summary>
        /// <param name="namePrefix">namePrefix the prefix for the auto-generated names of the virtual machines in the scale set</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate WithComputerNamePrefix(string namePrefix);

    }
    /// <summary>
    /// The stage of a Linux virtual machine scale set definition allowing to specify the root user name.
    /// </summary>
    public interface IWithRootUserName 
    {
        /// <summary>
        /// Specifies the root user name for the Linux virtual machines in the scale set.
        /// </summary>
        /// <param name="rootUserName">rootUserName a Linux root user name, following the required naming convention for Linux user names</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithLinuxCreate WithRootUserName(string rootUserName);

    }
}