// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition;

    /// <summary>
    /// The stage of a Windows virtual machine scale set definition which contains all the minimum required
    /// inputs for the resource to be created (via WithCreate.create(), but also allows for any other
    /// optional settings to be specified.
    /// </summary>
    public interface IWithWindowsCreate  :
        IWithCreate
    {
        /// <summary>
        /// Specifies the WinRM listener.
        /// <p>
        /// Each call to this method adds the given listener to the list of VM's WinRM listeners.
        /// </summary>
        /// <param name="listener">A WinRm listener.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreate WithWinRm(WinRMListener listener);

        /// <summary>
        /// Enables automatic updates.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreate WithAutoUpdate();

        /// <summary>
        /// Disables the VM agent.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreate WithoutVmAgent();

        /// <summary>
        /// Enables the VM agent.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreate WithVmAgent();

        /// <summary>
        /// Disables automatic updates.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreate WithoutAutoUpdate();

        /// <summary>
        /// Specifies the time zone for the virtual machines to use.
        /// </summary>
        /// <param name="timeZone">A time zone.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreate WithTimeZone(string timeZone);
    }

    /// <summary>
    /// The stage of the Linux virtual machine scale set definition allowing to specify SSH root user name.
    /// </summary>
    public interface IWithLinuxRootUsername 
    {
        /// <summary>
        /// Specifies the SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">The Linux SSH root user name. This must follow the required naming convention for Linux user name.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKey WithRootUsername(string rootUserName);
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
        /// <param name="name">The name of the storage account.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithNewStorageAccount(string name);

        /// <summary>
        /// Specifies a new storage account for the OS and data disk VHDs of the virtual machines
        /// in the scale set.
        /// </summary>
        /// <param name="creatable">The storage account definition in a creatable stage.</param>
        /// <return>The next stage in the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable);

        /// <summary>
        /// Specifies an existing StorageAccount for the OS and data disk VHDs of
        /// the virtual machines in the scale set.
        /// </summary>
        /// <param name="storageAccount">An existing storage account.</param>
        /// <return>The next stage in the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithExistingStorageAccount(IStorageAccount storageAccount);
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify the upgrade policy.
    /// </summary>
    public interface IWithUpgradePolicy 
    {
        /// <summary>
        /// Specifies the virtual machine scale set upgrade policy mode.
        /// </summary>
        /// <param name="upgradeMode">An upgrade policy mode.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithUpgradeMode(UpgradeMode upgradeMode);
    }

    /// <summary>
    /// The entirety of the load balancer definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IBlank,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithGroup,
        IWithSku,
        IWithNetworkSubnet,
        IWithPrimaryInternetFacingLoadBalancer,
        IWithPrimaryInternalLoadBalancer,
        IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool,
        IWithInternalLoadBalancerBackendOrNatPool,
        IWithPrimaryInternetFacingLoadBalancerNatPool,
        IWithInternalInternalLoadBalancerNatPool,
        IWithOS,
        IWithLinuxRootUsername,
        IWithLinuxRootPasswordOrPublicKey,
        IWithWindowsAdminUsername,
        IWithWindowsAdminPassword,
        IWithLinuxCreate,
        IWithWindowsCreate,
        IWithCreate
    {
    }

    /// <summary>
    /// The stage of the Windows virtual machine scale set definition allowing to specify administrator user name.
    /// </summary>
    public interface IWithWindowsAdminUsername 
    {
        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">The Windows administrator user name. This must follow the required naming convention for Windows user name.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsAdminPassword WithAdminUsername(string adminUserName);
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithSku>
    {
    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify the operating system image.
    /// </summary>
    public interface IWithOS 
    {
        /// <summary>
        /// Specifies a known marketplace Linux image used as the virtual machine's operating system.
        /// </summary>
        /// <param name="knownImage">A known market-place image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxRootUsername WithPopularLinuxImage(KnownLinuxVirtualMachineImage knownImage);

        /// <summary>
        /// Specifies that the latest version of a marketplace Linux image should be used.
        /// </summary>
        /// <param name="publisher">The publisher of the image.</param>
        /// <param name="offer">The offer of the image.</param>
        /// <param name="sku">The SKU of the image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxRootUsername WithLatestLinuxImage(string publisher, string offer, string sku);

        /// <summary>
        /// Specifies the user (custom) Linux image used as the virtual machine's operating system.
        /// </summary>
        /// <param name="imageUrl">The url the the VHD.</param>
        /// <return>The next stage of the virtual machine scale set definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxRootUsername WithStoredLinuxImage(string imageUrl);

        /// <summary>
        /// Specifies that the latest version of the specified marketplace Windows image should be used.
        /// </summary>
        /// <param name="publisher">Specifies the publisher of the image.</param>
        /// <param name="offer">Specifies the offer of the image.</param>
        /// <param name="sku">Specifies the SKU of the image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsAdminUsername WithLatestWindowsImage(string publisher, string offer, string sku);

        /// <summary>
        /// Specifies a known marketplace Windows image used as the operating system for the virtual machines in the scale set.
        /// </summary>
        /// <param name="knownImage">A known market-place image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsAdminUsername WithPopularWindowsImage(KnownWindowsVirtualMachineImage knownImage);

        /// <summary>
        /// Specifies the specific version of a marketplace Windows image needs to be used.
        /// </summary>
        /// <param name="imageReference">Describes publisher, offer, SKU and version of the marketplace image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsAdminUsername WithSpecificWindowsImageVersion(ImageReference imageReference);

        /// <summary>
        /// Specifies the specific version of a market-place Linux image that should be used.
        /// </summary>
        /// <param name="imageReference">Describes the publisher, offer, SKU and version of the market-place image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxRootUsername WithSpecificLinuxImageVersion(ImageReference imageReference);

        /// <summary>
        /// Specifies the user (custom) Windows image to be used as the operating system for the virtual machines in the
        /// scale set.
        /// </summary>
        /// <param name="imageUrl">The URL of the VHD.</param>
        /// <return>The next stage of the virtual machine scale set definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsAdminUsername WithStoredWindowsImage(string imageUrl);
    }

    /// <summary>
    /// The stage of a Linux virtual machine scale set definition which contains all the minimum required inputs
    /// for the resource to be created (via WithCreate.create()), but also allows for any other optional
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
        /// <param name="publicKey">An SSH public key in the PEM format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxCreate WithSsh(string publicKey);
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
        /// <p>.
        /// </summary>
        /// <param name="loadBalancer">An existing internal load balancer.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithInternalLoadBalancerBackendOrNatPool WithExistingPrimaryInternalLoadBalancer(ILoadBalancer loadBalancer);

        /// <summary>
        /// Specifies that no internal load balancer should be associated with the primary network interfaces of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithOS WithoutPrimaryInternalLoadBalancer();
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition containing all the required inputs for the resource
    /// to be created (via WithCreate.create()), but also allowing for any other optional settings
    /// to be specified.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>,
        IWithOsDiskSettings,
        IWithComputerNamePrefix,
        IWithCapacity,
        IWithUpgradePolicy,
        IWithOverProvision,
        IWithStorageAccount,
        IWithCustomData,
        IWithExtension,
        IDefinitionWithTags<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify the custom data.
    /// </summary>
    public interface IWithCustomData 
    {
        /// <summary>
        /// Specifies the custom data for the virtual machine scale set.
        /// </summary>
        /// <param name="base64EncodedCustomData">The base64 encoded custom data.</param>
        /// <return>The next stage in the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithCustomData(string base64EncodedCustomData);
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
        /// <param name="backendNames">The names of existing backends in the selected load balancer.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerNatPool WithPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames);
    }

    /// <summary>
    /// The stage of the Linux virtual machine scale set definition allowing to specify SSH root password or public key.
    /// </summary>
    public interface IWithLinuxRootPasswordOrPublicKey 
    {
        /// <summary>
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">The SSH root password. This must follow the criteria for Azure Linux VM password.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxCreate WithRootPassword(string rootPassword);

        /// <summary>
        /// Specifies the SSH public key.
        /// <p>
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxCreate WithSsh(string publicKey);
    }

    /// <summary>
    /// The first stage of a virtual machine scale set definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to associate backend pools and/or inbound NAT pools
    /// of the selected internal load balancer with the primary network interface of the virtual machines in the scale set.
    /// </summary>
    public interface IWithInternalLoadBalancerBackendOrNatPool  :
        IWithInternalInternalLoadBalancerNatPool
    {
        /// <summary>
        /// Associates the specified backends of the selected load balancer with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">Names of existing backends in the selected load balancer.</param>
        /// <return>The next stage of the virtual machine scale set definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithInternalInternalLoadBalancerNatPool WithPrimaryInternalLoadBalancerBackends(params string[] backendNames);
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
        /// <param name="natPoolNames">Inbound NAT pools names existing on the selected load balancer.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer WithPrimaryInternetFacingLoadBalancerInboundNatPools(params string[] natPoolNames);
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
        /// <param name="capacity">The virtual machine capacity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithCapacity(int capacity);
    }

    /// <summary>
    /// The stage of a virtual machine definition allowing to specify extensions.
    /// </summary>
    public interface IWithExtension 
    {
        /// <summary>
        /// Begins the definition of an extension reference to be attached to the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">The reference name for the extension.</param>
        /// <return>The first stage of the extension reference definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IBlank<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate> DefineNewExtension(string name);
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
        /// <param name="natPoolNames">Inbound NAT pool names.</param>
        /// <return>The next stage of the virtual machine scale set definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithOS WithPrimaryInternalLoadBalancerInboundNatPools(params string[] natPoolNames);
    }

    /// <summary>
    /// The stage of the Windows virtual machine scale set definition allowing to specify administrator user name.
    /// </summary>
    public interface IWithWindowsAdminPassword 
    {
        /// <summary>
        /// Specifies the administrator password for the Windows virtual machine.
        /// </summary>
        /// <param name="adminPassword">The administrator password. This must follow the criteria for Azure Windows VM password.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreate WithAdminPassword(string adminPassword);
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
        /// <param name="network">An existing virtual network.</param>
        /// <param name="subnetName">The subnet name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancer WithExistingPrimaryNetworkSubnet(INetwork network, string subnetName);
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify OS disk configurations.
    /// </summary>
    public interface IWithOsDiskSettings 
    {
        /// <summary>
        /// Specifies the name for the OS disk.
        /// </summary>
        /// <param name="name">The OS disk name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithOsDiskName(string name);

        /// <summary>
        /// Specifies the caching type for the operating system disk.
        /// </summary>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithOsDiskCaching(CachingTypes cachingType);
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
        /// <p>.
        /// </summary>
        /// <param name="loadBalancer">An existing Internet-facing load balancer.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool WithExistingPrimaryInternetFacingLoadBalancer(ILoadBalancer loadBalancer);

        /// <summary>
        /// Specifies that no public load balancer should be associated with the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer WithoutPrimaryInternetFacingLoadBalancer();
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify SKU for the virtual machines.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="skuType">The SKU type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithNetworkSubnet WithSku(VirtualMachineScaleSetSkuTypes skuType);

        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="sku">A SKU from the list of available sizes for the virtual machines in this scale set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithNetworkSubnet WithSku(IVirtualMachineScaleSetSku sku);
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify whether
    /// or not to over-provision virtual machines in the scale set.
    /// </summary>
    public interface IWithOverProvision 
    {
        /// <summary>
        /// Disables over-provisioning of virtual machines.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithoutOverProvisioning();

        /// <summary>
        /// Enables over-provisioning of virtual machines.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithOverProvisioning();

        /// <summary>
        /// Enables or disables over-provisioning of virtual machines in the scale set.
        /// </summary>
        /// <param name="enabled">
        /// True if enabling over-0provisioning of virtual machines in the
        /// scale set, otherwise false.
        /// </param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithOverProvision(bool enabled);
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify the computer name prefix.
    /// </summary>
    public interface IWithComputerNamePrefix 
    {
        /// <summary>
        /// Specifies the name prefix to use for auto-generating the names for the virtual machines in the scale set.
        /// </summary>
        /// <param name="namePrefix">The prefix for the auto-generated names of the virtual machines in the scale set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithComputerNamePrefix(string namePrefix);
    }
}