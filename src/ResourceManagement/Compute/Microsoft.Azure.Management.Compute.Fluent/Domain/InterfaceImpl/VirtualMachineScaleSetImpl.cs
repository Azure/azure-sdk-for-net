// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using VirtualMachineScaleSet.Update;
    using Models;
    using VirtualMachineScaleSet.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Resource.Fluent;
    using System.Threading;

    internal partial class VirtualMachineScaleSetImpl
    {
        /// <summary>
        /// Specifies the name prefix to use for auto-generating the names for the virtual machines in the scale set.
        /// </summary>
        /// <param name="namePrefix">The prefix for the auto-generated names of the virtual machines in the scale set.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithComputerNamePrefix.WithComputerNamePrefix(string namePrefix)
        {
            return this.WithComputerNamePrefix(namePrefix) as VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specified inbound NAT pools
        /// of an Internet-facing load balancer.
        /// </summary>
        /// <param name="natPoolNames">The names of existing inbound NAT pools.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancerNatPool.WithoutPrimaryInternetFacingLoadBalancerNatPools(params string[] natPoolNames)
        {
            return this.WithoutPrimaryInternetFacingLoadBalancerNatPools(natPoolNames) as VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specified inbound NAT pools
        /// of the internal load balancer.
        /// </summary>
        /// <param name="natPoolNames">The names of existing inbound NAT pools.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancerNatPool.WithoutPrimaryInternalLoadBalancerNatPools(params string[] natPoolNames)
        {
            return this.WithoutPrimaryInternalLoadBalancerNatPools(natPoolNames) as VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Associates the specified internal load balancer inbound NAT pools with the the primary network interface of
        /// the virtual machines in the scale set.
        /// </summary>
        /// <param name="natPoolNames">The names of existing inbound NAT pools in the selected load balancer.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerNatPool.WithPrimaryInternalLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            return this.WithPrimaryInternalLoadBalancerInboundNatPools(natPoolNames) as VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Specifies the SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">The Linux SSH root user name. This must follow the required naming convention for Linux user name.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKey VirtualMachineScaleSet.Definition.IWithLinuxRootUsername.WithRootUsername(string rootUserName)
        {
            return this.WithRootUsername(rootUserName) as VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKey;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet;
        }

        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specfied backends
        /// of the Internet-facing load balancer.
        /// </summary>
        /// <param name="backendNames">Existing backend names.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancerBackend.WithoutPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithoutPrimaryInternetFacingLoadBalancerBackends(backendNames) as VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specified backends
        /// of the internal load balancer.
        /// </summary>
        /// <param name="backendNames">Existing backend names.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancerBackend.WithoutPrimaryInternalLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithoutPrimaryInternalLoadBalancerBackends(backendNames) as VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Associates inbound NAT pools of the selected Internet-facing load balancer with the primary network interface
        /// of the virtual machines in the scale set.
        /// </summary>
        /// <param name="natPoolNames">The names of existing inbound NAT pools on the selected load balancer.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancer VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerNatPool.WithPrimaryInternetFacingLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            return this.WithPrimaryInternetFacingLoadBalancerInboundNatPools(natPoolNames) as VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancer;
        }

        /// <summary>
        /// Associates the specified inbound NAT pools of the selected internal load balancer with the primary network
        /// interface of the virtual machines in the scale set.
        /// </summary>
        /// <param name="natPoolNames">Inbound NAT pools names existing on the selected load balancer.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerNatPool.WithPrimaryInternetFacingLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            return this.WithPrimaryInternetFacingLoadBalancerInboundNatPools(natPoolNames) as VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer;
        }

        /// <summary>
        /// Specifies the SSH public key.
        /// <p>
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">An SSH public key in the PEM format.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxCreate VirtualMachineScaleSet.Definition.IWithLinuxCreate.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey) as VirtualMachineScaleSet.Definition.IWithLinuxCreate;
        }

        /// <summary>
        /// Associates the specified internal load balancer backends with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">The names of existing backends on the selected load balancer.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerNatPool VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerBackendOrNatPool.WithPrimaryInternalLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithPrimaryInternalLoadBalancerBackends(backendNames) as VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerNatPool;
        }

        /// <summary>
        /// Specifies a new storage account for the OS and data disk VHDs of the virtual machines
        /// in the scale set.
        /// </summary>
        /// <param name="name">The name of the storage account.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithStorageAccount.WithNewStorageAccount(string name)
        {
            return this.WithNewStorageAccount(name) as VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies a new storage account for the OS and data disk VHDs of the virtual machines
        /// in the scale set.
        /// </summary>
        /// <param name="creatable">The storage account definition in a creatable stage.</param>
        /// <return>The next stage in the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithStorageAccount.WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable)
        {
            return this.WithNewStorageAccount(creatable) as VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies an existing StorageAccount for the OS and data disk VHDs of
        /// the virtual machines in the scale set.
        /// </summary>
        /// <param name="storageAccount">An existing storage account.</param>
        /// <return>The next stage in the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithStorageAccount.WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            return this.WithExistingStorageAccount(storageAccount) as VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Removes the extension with the specified name from the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">The reference name of the extension to be removed/uninstalled.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithExtension.WithoutExtension(string name)
        {
            return this.WithoutExtension(name) as VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Begins the description of an update of an existing extension assigned to the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">The reference name for the extension.</param>
        /// <return>The first stage of the extension reference update.</return>
        VirtualMachineScaleSetExtension.Update.IUpdate VirtualMachineScaleSet.Update.IWithExtension.UpdateExtension(string name)
        {
            return this.UpdateExtension(name) as VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of an extension reference to be attached to the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">The reference name for an extension.</param>
        /// <return>The first stage of the extension reference definition.</return>
        VirtualMachineScaleSetExtension.UpdateDefinition.IBlank<VirtualMachineScaleSet.Update.IWithApply> VirtualMachineScaleSet.Update.IWithExtension.DefineNewExtension(string name)
        {
            return this.DefineNewExtension(name) as VirtualMachineScaleSetExtension.UpdateDefinition.IBlank<VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Begins the definition of an extension reference to be attached to the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">The reference name for the extension.</param>
        /// <return>The first stage of the extension reference definition.</return>
        VirtualMachineScaleSetExtension.Definition.IBlank<VirtualMachineScaleSet.Definition.IWithCreate> VirtualMachineScaleSet.Definition.IWithExtension.DefineNewExtension(string name)
        {
            return this.DefineNewExtension(name) as VirtualMachineScaleSetExtension.Definition.IBlank<VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the administrator password for the Windows virtual machine.
        /// </summary>
        /// <param name="adminPassword">The administrator password. This must follow the criteria for Azure Windows VM password.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreate VirtualMachineScaleSet.Definition.IWithWindowsAdminPassword.WithAdminPassword(string adminPassword)
        {
            return this.WithAdminPassword(adminPassword) as VirtualMachineScaleSet.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Specifies the load balancer to be used as the Internet-facing load balancer for the virtual machines in the
        /// scale set.
        /// <p>
        /// This will replace the current internet-facing load balancer associated with the virtual machines in the
        /// scale set (if any).
        /// By default all the backend and inbound NAT pool of the load balancer will be associated with the primary
        /// network interface of the virtual machines unless a subset of them is selected in the next stages.
        /// </summary>
        /// <param name="loadBalancer">The primary Internet-facing load balancer.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool VirtualMachineScaleSet.Update.IWithPrimaryLoadBalancer.WithExistingPrimaryInternetFacingLoadBalancer(ILoadBalancer loadBalancer)
        {
            return this.WithExistingPrimaryInternetFacingLoadBalancer(loadBalancer) as VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool;
        }

        /// <summary>
        /// Specifies the SSH public key.
        /// <p>
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxCreate VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKey.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey) as VirtualMachineScaleSet.Definition.IWithLinuxCreate;
        }

        /// <summary>
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">The SSH root password. This must follow the criteria for Azure Linux VM password.</param>
        /// <return>The next stage of the Linux virtual machine definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxCreate VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKey.WithRootPassword(string rootPassword)
        {
            return this.WithRootPassword(rootPassword) as VirtualMachineScaleSet.Definition.IWithLinuxCreate;
        }

        /// <summary>
        /// Associates the specified Internet-facing load balancer backends with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">The backend names.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerNatPool VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool.WithPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithPrimaryInternetFacingLoadBalancerBackends(backendNames) as VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerNatPool;
        }

        /// <summary>
        /// Associates the specified backends of the selected load balancer with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">The names of existing backends in the selected load balancer.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerNatPool VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool.WithPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithPrimaryInternetFacingLoadBalancerBackends(backendNames) as VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerNatPool;
        }

        /// <summary>
        /// Associate an existing virtual network subnet with the primary network interface of the virtual machines
        /// in the scale set.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <param name="subnetName">The subnet name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancer VirtualMachineScaleSet.Definition.IWithNetworkSubnet.WithExistingPrimaryNetworkSubnet(INetwork network, string subnetName)
        {
            return this.WithExistingPrimaryNetworkSubnet(network, subnetName) as VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancer;
        }

        /// <summary>
        /// Associates the specified backends of the selected load balancer with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">Names of existing backends in the selected load balancer.</param>
        /// <return>The next stage of the virtual machine scale set definition.</return>
        VirtualMachineScaleSet.Definition.IWithInternalInternalLoadBalancerNatPool VirtualMachineScaleSet.Definition.IWithInternalLoadBalancerBackendOrNatPool.WithPrimaryInternalLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithPrimaryInternalLoadBalancerBackends(backendNames) as VirtualMachineScaleSet.Definition.IWithInternalInternalLoadBalancerNatPool;
        }

        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">The Windows administrator user name. This must follow the required naming convention for Windows user name.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsAdminPassword VirtualMachineScaleSet.Definition.IWithWindowsAdminUsername.WithAdminUsername(string adminUserName)
        {
            return this.WithAdminUsername(adminUserName) as VirtualMachineScaleSet.Definition.IWithWindowsAdminPassword;
        }

        /// <summary>
        /// Specifies that the latest version of a marketplace Linux image should be used.
        /// </summary>
        /// <param name="publisher">The publisher of the image.</param>
        /// <param name="offer">The offer of the image.</param>
        /// <param name="sku">The SKU of the image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxRootUsername VirtualMachineScaleSet.Definition.IWithOS.WithLatestLinuxImage(string publisher, string offer, string sku)
        {
            return this.WithLatestLinuxImage(publisher, offer, sku) as VirtualMachineScaleSet.Definition.IWithLinuxRootUsername;
        }

        /// <summary>
        /// Specifies the user (custom) Linux image used as the virtual machine's operating system.
        /// </summary>
        /// <param name="imageUrl">The url the the VHD.</param>
        /// <return>The next stage of the virtual machine scale set definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxRootUsername VirtualMachineScaleSet.Definition.IWithOS.WithStoredLinuxImage(string imageUrl)
        {
            return this.WithStoredLinuxImage(imageUrl) as VirtualMachineScaleSet.Definition.IWithLinuxRootUsername;
        }

        /// <summary>
        /// Specifies the specific version of a market-place Linux image that should be used.
        /// </summary>
        /// <param name="imageReference">Describes the publisher, offer, SKU and version of the market-place image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxRootUsername VirtualMachineScaleSet.Definition.IWithOS.WithSpecificLinuxImageVersion(ImageReference imageReference)
        {
            return this.WithSpecificLinuxImageVersion(imageReference) as VirtualMachineScaleSet.Definition.IWithLinuxRootUsername;
        }

        /// <summary>
        /// Specifies that the latest version of the specified marketplace Windows image should be used.
        /// </summary>
        /// <param name="publisher">Specifies the publisher of the image.</param>
        /// <param name="offer">Specifies the offer of the image.</param>
        /// <param name="sku">Specifies the SKU of the image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsAdminUsername VirtualMachineScaleSet.Definition.IWithOS.WithLatestWindowsImage(string publisher, string offer, string sku)
        {
            return this.WithLatestWindowsImage(publisher, offer, sku) as VirtualMachineScaleSet.Definition.IWithWindowsAdminUsername;
        }

        /// <summary>
        /// Specifies a known marketplace Windows image used as the operating system for the virtual machines in the scale set.
        /// </summary>
        /// <param name="knownImage">A known market-place image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsAdminUsername VirtualMachineScaleSet.Definition.IWithOS.WithPopularWindowsImage(KnownWindowsVirtualMachineImage knownImage)
        {
            return this.WithPopularWindowsImage(knownImage) as VirtualMachineScaleSet.Definition.IWithWindowsAdminUsername;
        }

        /// <summary>
        /// Specifies the specific version of a marketplace Windows image needs to be used.
        /// </summary>
        /// <param name="imageReference">Describes publisher, offer, SKU and version of the marketplace image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsAdminUsername VirtualMachineScaleSet.Definition.IWithOS.WithSpecificWindowsImageVersion(ImageReference imageReference)
        {
            return this.WithSpecificWindowsImageVersion(imageReference) as VirtualMachineScaleSet.Definition.IWithWindowsAdminUsername;
        }

        /// <summary>
        /// Specifies a known marketplace Linux image used as the virtual machine's operating system.
        /// </summary>
        /// <param name="knownImage">A known market-place image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxRootUsername VirtualMachineScaleSet.Definition.IWithOS.WithPopularLinuxImage(KnownLinuxVirtualMachineImage knownImage)
        {
            return this.WithPopularLinuxImage(knownImage) as VirtualMachineScaleSet.Definition.IWithLinuxRootUsername;
        }

        /// <summary>
        /// Specifies the user (custom) Windows image to be used as the operating system for the virtual machines in the
        /// scale set.
        /// </summary>
        /// <param name="imageUrl">The URL of the VHD.</param>
        /// <return>The next stage of the virtual machine scale set definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsAdminUsername VirtualMachineScaleSet.Definition.IWithOS.WithStoredWindowsImage(string imageUrl)
        {
            return this.WithStoredWindowsImage(imageUrl) as VirtualMachineScaleSet.Definition.IWithWindowsAdminUsername;
        }

        /// <summary>
        /// Specifies the virtual machine scale set upgrade policy mode.
        /// </summary>
        /// <param name="upgradeMode">An upgrade policy mode.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithUpgradePolicy.WithUpgradeMode(UpgradeMode upgradeMode)
        {
            return this.WithUpgradeMode(upgradeMode) as VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="skuType">The SKU type.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithSku.WithSku(VirtualMachineScaleSetSkuTypes skuType)
        {
            return this.WithSku(skuType) as VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="sku">A SKU from the list of available sizes for the virtual machines in this scale set.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithSku.WithSku(IVirtualMachineScaleSetSku sku)
        {
            return this.WithSku(sku) as VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="skuType">The SKU type.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithNetworkSubnet VirtualMachineScaleSet.Definition.IWithSku.WithSku(VirtualMachineScaleSetSkuTypes skuType)
        {
            return this.WithSku(skuType) as VirtualMachineScaleSet.Definition.IWithNetworkSubnet;
        }

        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="sku">A SKU from the list of available sizes for the virtual machines in this scale set.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithNetworkSubnet VirtualMachineScaleSet.Definition.IWithSku.WithSku(IVirtualMachineScaleSetSku sku)
        {
            return this.WithSku(sku) as VirtualMachineScaleSet.Definition.IWithNetworkSubnet;
        }

        /// <summary>
        /// Enables automatic updates.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreate VirtualMachineScaleSet.Definition.IWithWindowsCreate.WithAutoUpdate()
        {
            return this.WithAutoUpdate() as VirtualMachineScaleSet.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Disables the VM agent.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreate VirtualMachineScaleSet.Definition.IWithWindowsCreate.WithoutVmAgent()
        {
            return this.WithoutVmAgent() as VirtualMachineScaleSet.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Specifies the WinRM listener.
        /// <p>
        /// Each call to this method adds the given listener to the list of VM's WinRM listeners.
        /// </summary>
        /// <param name="listener">A WinRm listener.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreate VirtualMachineScaleSet.Definition.IWithWindowsCreate.WithWinRm(WinRMListener listener)
        {
            return this.WithWinRm(listener) as VirtualMachineScaleSet.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Disables automatic updates.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreate VirtualMachineScaleSet.Definition.IWithWindowsCreate.WithoutAutoUpdate()
        {
            return this.WithoutAutoUpdate() as VirtualMachineScaleSet.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Specifies the time zone for the virtual machines to use.
        /// </summary>
        /// <param name="timeZone">A time zone.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreate VirtualMachineScaleSet.Definition.IWithWindowsCreate.WithTimeZone(string timeZone)
        {
            return this.WithTimeZone(timeZone) as VirtualMachineScaleSet.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Enables the VM agent.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreate VirtualMachineScaleSet.Definition.IWithWindowsCreate.WithVmAgent()
        {
            return this.WithVmAgent() as VirtualMachineScaleSet.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Specifies the custom data for the virtual machine scale set.
        /// </summary>
        /// <param name="base64EncodedCustomData">The base64 encoded custom data.</param>
        /// <return>The next stage in the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithCustomData.WithCustomData(string base64EncodedCustomData)
        {
            return this.WithCustomData(base64EncodedCustomData) as VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the new number of virtual machines in the scale set.
        /// </summary>
        /// <param name="capacity">The virtual machine capacity of the scale set.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithCapacity.WithCapacity(int capacity)
        {
            return this.WithCapacity(capacity) as VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Specifies the maximum number of virtual machines in the scale set.
        /// </summary>
        /// <param name="capacity">The virtual machine capacity.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithCapacity.WithCapacity(int capacity)
        {
            return this.WithCapacity(capacity) as VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <return>The extensions attached to the virtual machines in the scale set.</return>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.Extensions
        {
            get
            {
                return this.Extensions() as System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension>;
            }
        }

        /// <return>
        /// The internet-facing load balancer associated with the primary network interface of
        /// the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancer Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.GetPrimaryInternetFacingLoadBalancer()
        {
            return this.GetPrimaryInternetFacingLoadBalancer() as Microsoft.Azure.Management.Network.Fluent.ILoadBalancer;
        }

        /// <return>The name of the OS disk of virtual machines in the scale set.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.OsDiskName
        {
            get
            {
                return this.OsDiskName() as string;
            }
        }

        /// <return>
        /// The virtual network associated with the primary network interfaces of the virtual machines
        /// in the scale set.
        /// <p>
        /// A primary internal load balancer associated with the primary network interfaces of the scale set
        /// virtual machine will be also belong to this network
        /// </p>.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        Microsoft.Azure.Management.Network.Fluent.INetwork Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.GetPrimaryNetwork()
        {
            return this.GetPrimaryNetwork() as Microsoft.Azure.Management.Network.Fluent.INetwork;
        }

        /// <summary>
        /// Re-images (updates the version of the installed operating system) the virtual machines in the scale set.
        /// </summary>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.Reimage()
        {

            this.Reimage();
        }

        /// <return>The operating system disk caching type.</return>
        Models.CachingTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.OsDiskCachingType
        {
            get
            {
                return this.OsDiskCachingType();
            }
        }

        /// <return>The URL to storage containers that store the VHDs of the virtual machines in the scale set.</return>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.VhdContainers
        {
            get
            {
                return this.VhdContainers() as System.Collections.Generic.IList<string>;
            }
        }

        /// <summary>
        /// Starts the virtual machines in the scale set.
        /// </summary>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.Start()
        {

            this.Start();
        }

        /// <return>
        /// Available SKUs for the virtual machine scale set, including the minimum and maximum virtual machine instances
        /// allowed for a particular SKU.
        /// </return>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetSku> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.ListAvailableSkus()
        {
            return this.ListAvailableSkus() as Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetSku>;
        }

        /// <return>The operating system of the virtual machines in the scale set.</return>
        Models.OperatingSystemTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.OsType
        {
            get
            {
                return this.OsType();
            }
        }

        /// <summary>
        /// Shuts down the virtual machines in the scale set and releases its compute resources.
        /// </summary>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.Deallocate()
        {

            this.Deallocate();
        }

        /// <return>
        /// The internet-facing load balancer's backends associated with the primary network interface
        /// of the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.ListPrimaryInternetFacingLoadBalancerBackends()
        {
            return this.ListPrimaryInternetFacingLoadBalancerBackends() as System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend>;
        }

        /// <return>
        /// The internal load balancer associated with the primary network interface of
        /// the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancer Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.GetPrimaryInternalLoadBalancer()
        {
            return this.GetPrimaryInternalLoadBalancer() as Microsoft.Azure.Management.Network.Fluent.ILoadBalancer;
        }

        /// <return>True if over provision is enabled for the virtual machines, false otherwise.</return>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.OverProvisionEnabled
        {
            get
            {
                return this.OverProvisionEnabled();
            }
        }

        /// <summary>
        /// Powers off (stops) the virtual machines in the scale set.
        /// </summary>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.PowerOff()
        {

            this.PowerOff();
        }

        /// <return>
        /// The internal load balancer's backends associated with the primary network interface
        /// of the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.ListPrimaryInternalLoadBalancerBackends()
        {
            return this.ListPrimaryInternalLoadBalancerBackends() as System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend>;
        }

        /// <return>The SKU of the virtual machines in the scale set.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetSkuTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.Sku
        {
            get
            {
                return this.Sku() as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetSkuTypes;
            }
        }

        /// <return>Entry point to manage virtual machine instances in the scale set.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVMs Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.VirtualMachines
        {
            get
            {
                return this.VirtualMachines() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVMs;
            }
        }

        /// <return>The upgradeModel.</return>
        Models.UpgradeMode Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.UpgradeModel
        {
            get
            {
                return this.UpgradeModel();
            }
        }

        /// <summary>
        /// Restarts the virtual machines in the scale set.
        /// </summary>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.Restart()
        {

            this.Restart();
        }

        /// <return>The name prefix of the virtual machines in the scale set.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.ComputerNamePrefix
        {
            get
            {
                return this.ComputerNamePrefix() as string;
            }
        }

        /// <return>The storage profile.</return>
        Models.VirtualMachineScaleSetStorageProfile Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.StorageProfile
        {
            get
            {
                return this.StorageProfile() as Models.VirtualMachineScaleSetStorageProfile;
            }
        }

        /// <return>
        /// The list of IDs of the public IP addresses associated with the primary Internet-facing load balancer
        /// of the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.PrimaryPublicIpAddressIds
        {
            get
            {
                return this.PrimaryPublicIpAddressIds() as System.Collections.Generic.IList<string>;
            }
        }

        /// <return>
        /// The inbound NAT pools of the internal load balancer associated with the primary network interface
        /// of the virtual machines in the scale set, if any.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.ListPrimaryInternalLoadBalancerInboundNatPools()
        {
            return this.ListPrimaryInternalLoadBalancerInboundNatPools() as System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool>;
        }

        /// <return>The network profile.</return>
        Models.VirtualMachineScaleSetNetworkProfile Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.NetworkProfile
        {
            get
            {
                return this.NetworkProfile() as Models.VirtualMachineScaleSetNetworkProfile;
            }
        }

        /// <return>The number of virtual machine instances in the scale set.</return>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.Capacity
        {
            get
            {
                return this.Capacity();
            }
        }

        /// <return>
        /// The internet-facing load balancer's inbound NAT pool associated with the primary network interface
        /// of the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.ListPrimaryInternetFacingLoadBalancerInboundNatPools()
        {
            return this.ListPrimaryInternetFacingLoadBalancerInboundNatPools() as System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool>;
        }

        /// <summary>
        /// Associate internal load balancer inbound NAT pools with the the primary network interface of the
        /// scale set virtual machine.
        /// </summary>
        /// <param name="natPoolNames">Inbound NAT pool names.</param>
        /// <return>The next stage of the virtual machine scale set definition.</return>
        VirtualMachineScaleSet.Definition.IWithOS VirtualMachineScaleSet.Definition.IWithInternalInternalLoadBalancerNatPool.WithPrimaryInternalLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            return this.WithPrimaryInternalLoadBalancerInboundNatPools(natPoolNames) as VirtualMachineScaleSet.Definition.IWithOS;
        }

        /// <summary>
        /// Specifies the load balancer to be used as the internal load balancer for the virtual machines in the
        /// scale set.
        /// <p>
        /// This will replace the current internal load balancer associated with the virtual machines in the
        /// scale set (if any).
        /// By default all the backends and inbound NAT pools of the load balancer will be associated with the primary
        /// network interface of the virtual machines in the scale set unless subset of them is selected in the next stages.
        /// </p>.
        /// </summary>
        /// <param name="loadBalancer">The primary Internet-facing load balancer.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerBackendOrNatPool VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancer.WithExistingPrimaryInternalLoadBalancer(ILoadBalancer loadBalancer)
        {
            return this.WithExistingPrimaryInternalLoadBalancer(loadBalancer) as VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerBackendOrNatPool;
        }

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
        VirtualMachineScaleSet.Definition.IWithInternalLoadBalancerBackendOrNatPool VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer.WithExistingPrimaryInternalLoadBalancer(ILoadBalancer loadBalancer)
        {
            return this.WithExistingPrimaryInternalLoadBalancer(loadBalancer) as VirtualMachineScaleSet.Definition.IWithInternalLoadBalancerBackendOrNatPool;
        }

        /// <summary>
        /// Specifies that no internal load balancer should be associated with the primary network interfaces of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithOS VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer.WithoutPrimaryInternalLoadBalancer()
        {
            return this.WithoutPrimaryInternalLoadBalancer() as VirtualMachineScaleSet.Definition.IWithOS;
        }

        /// <summary>
        /// Specifies the name for the OS disk.
        /// </summary>
        /// <param name="name">The OS disk name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithOsDiskSettings.WithOsDiskName(string name)
        {
            return this.WithOsDiskName(name) as VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the caching type for the operating system disk.
        /// </summary>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithOsDiskSettings.WithOsDiskCaching(CachingTypes cachingType)
        {
            return this.WithOsDiskCaching(cachingType) as VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that no public load balancer should be associated with the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancer.WithoutPrimaryInternetFacingLoadBalancer()
        {
            return this.WithoutPrimaryInternetFacingLoadBalancer() as VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer;
        }

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
        VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancer.WithExistingPrimaryInternetFacingLoadBalancer(ILoadBalancer loadBalancer)
        {
            return this.WithExistingPrimaryInternetFacingLoadBalancer(loadBalancer) as VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool;
        }

        /// <summary>
        /// Disables over-provisioning of virtual machines.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithOverProvision.WithoutOverProvisioning()
        {
            return this.WithoutOverProvisioning() as VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables or disables over-provisioning of virtual machines in the scale set.
        /// </summary>
        /// <param name="enabled">
        /// True if enabling over-0provisioning of virtual machines in the
        /// scale set, otherwise false.
        /// </param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithOverProvision.WithOverProvision(bool enabled)
        {
            return this.WithOverProvision(enabled) as VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables over-provisioning of virtual machines.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithOverProvision.WithOverProvisioning()
        {
            return this.WithOverProvisioning() as VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Removes the association between the Internet-facing load balancer and the primary network interface configuration.
        /// <p>
        /// This removes the association between primary network interface configuration and all the backends and
        /// inbound NAT pools in the load balancer.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancer.WithoutPrimaryInternetFacingLoadBalancer()
        {
            return this.WithoutPrimaryInternetFacingLoadBalancer() as VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Removes the association between the internal load balancer and the primary network interface configuration.
        /// <p>
        /// This removes the association between primary network interface configuration and all the backends and
        /// inbound NAT pools in the load balancer.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancer.WithoutPrimaryInternalLoadBalancer()
        {
            return this.WithoutPrimaryInternalLoadBalancer() as VirtualMachineScaleSet.Update.IWithApply;
        }
    }
}