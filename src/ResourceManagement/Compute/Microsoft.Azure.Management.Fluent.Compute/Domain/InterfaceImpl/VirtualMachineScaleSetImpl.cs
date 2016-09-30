// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Compute
{

    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using Microsoft.Azure.Management.Compute.Models;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition;
    using Microsoft.Azure.Management.Fluent.Network;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update;
    using Microsoft.Azure.Management.Fluent.Storage;
    using Microsoft.Azure.Management.Storage.Models;
    using System.Threading;
    using Microsoft.Azure.Management.Network.Models;
    internal partial class VirtualMachineScaleSetImpl
    {
        /// <summary>
        /// Specifies the name prefix to use for auto-generating the names for the virtual machines in the scale set.
        /// </summary>
        /// <param name="namePrefix">namePrefix the prefix for the auto-generated names of the virtual machines in the scale set</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithComputerNamePrefix.WithComputerNamePrefix(string namePrefix)
        {
            return this.WithComputerNamePrefix(namePrefix) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specified inbound NAT pools
        /// of an Internet-facing load balancer.
        /// </summary>
        /// <param name="natPoolNames">natPoolNames the names of existing inbound NAT pools</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancerNatPool.WithoutPrimaryInternetFacingLoadBalancerNatPools(params string[] natPoolNames)
        {
            return this.WithoutPrimaryInternetFacingLoadBalancerNatPools(natPoolNames) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specified inbound NAT pools
        /// of the internal load balancer.
        /// </summary>
        /// <param name="natPoolNames">natPoolNames the names of existing inbound NAT pools</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancerNatPool.WithoutPrimaryInternalLoadBalancerNatPools(params string[] natPoolNames)
        {
            return this.WithoutPrimaryInternalLoadBalancerNatPools(natPoolNames) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Associates the specified internal load balancer inbound NAT pools with the the primary network interface of
        /// the virtual machines in the scale set.
        /// </summary>
        /// <param name="natPoolNames">natPoolNames the names of existing inbound NAT pools in the selected load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerNatPool.WithPrimaryInternalLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            return this.WithPrimaryInternalLoadBalancerInboundNatPools(natPoolNames) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <returns>the refreshed resource</returns>
        Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet;
        }

        /// <summary>
        /// Specifies the root user name for the Linux virtual machines in the scale set.
        /// </summary>
        /// <param name="rootUserName">rootUserName a Linux root user name, following the required naming convention for Linux user names</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithLinuxCreate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName.WithRootUserName(string rootUserName)
        {
            return this.WithRootUserName(rootUserName) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithLinuxCreate;
        }

        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specfied backends
        /// of the Internet-facing load balancer.
        /// </summary>
        /// <param name="backendNames">backendNames existing backend names</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancerBackend.WithoutPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithoutPrimaryInternetFacingLoadBalancerBackends(backendNames) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specified backends
        /// of the internal load balancer.
        /// </summary>
        /// <param name="backendNames">backendNames existing backend names</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancerBackend.WithoutPrimaryInternalLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithoutPrimaryInternalLoadBalancerBackends(backendNames) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Associates inbound NAT pools of the selected Internet-facing load balancer with the primary network interface
        /// of the virtual machines in the scale set.
        /// </summary>
        /// <param name="natPoolNames">natPoolNames the names of existing inbound NAT pools on the selected load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancer Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerNatPool.WithPrimaryInternetFacingLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            return this.WithPrimaryInternetFacingLoadBalancerInboundNatPools(natPoolNames) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancer;
        }

        /// <summary>
        /// Associates the specified inbound NAT pools of the selected internal load balancer with the primary network
        /// interface of the virtual machines in the scale set.
        /// </summary>
        /// <param name="natPoolNames">natPoolNames inbound NAT pools names existing on the selected load balancer</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerNatPool.WithPrimaryInternetFacingLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            return this.WithPrimaryInternetFacingLoadBalancerInboundNatPools(natPoolNames) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer;
        }

        /// <summary>
        /// Specifies the SSH public key.
        /// <p>
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">publicKey an SSH public key in the PEM format.</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithLinuxCreate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithLinuxCreate.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithLinuxCreate;
        }

        /// <summary>
        /// Specifies the password for the virtual machines in the scale set.
        /// </summary>
        /// <param name="password">password a password following the requirements for Azure virtual machine passwords</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPassword.WithPassword(string password)
        {
            return this.WithPassword(password) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machines in the scale set.
        /// </summary>
        /// <param name="adminUserName">adminUserName a Windows administrator user name, following the required naming convention for Windows user names</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName.WithAdminUserName(string adminUserName)
        {
            return this.WithAdminUserName(adminUserName) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Associates the specified internal load balancer backends with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">backendNames the names of existing backends on the selected load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerNatPool Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerBackendOrNatPool.WithPrimaryInternalLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithPrimaryInternalLoadBalancerBackends(backendNames) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerNatPool;
        }

        /// <summary>
        /// Specifies a new storage account for the OS and data disk VHDs of the virtual machines
        /// in the scale set.
        /// </summary>
        /// <param name="name">name the name of the storage account</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithStorageAccount.WithNewStorageAccount(string name)
        {
            return this.WithNewStorageAccount(name) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies a new storage account for the OS and data disk VHDs of the virtual machines
        /// in the scale set.
        /// </summary>
        /// <param name="creatable">creatable the storage account definition in a creatable stage</param>
        /// <returns>the next stage in the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithStorageAccount.WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Fluent.Storage.IStorageAccount> creatable)
        {
            return this.WithNewStorageAccount(creatable) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies an existing {@link StorageAccount} for the OS and data disk VHDs of
        /// the virtual machines in the scale set.
        /// </summary>
        /// <param name="storageAccount">storageAccount an existing storage account</param>
        /// <returns>the next stage in the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithStorageAccount.WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            return this.WithExistingStorageAccount(storageAccount) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Removes the extension with the specified name from the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">name the reference name of the extension to be removed/uninstalled</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithExtension.WithoutExtension(string name)
        {
            return this.WithoutExtension(name) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Begins the description of an update of an existing extension assigned to the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">name the reference name for the extension</param>
        /// <returns>the first stage of the extension reference update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update.IUpdate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithExtension.UpdateExtension(string name)
        {
            return this.UpdateExtension(name) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of an extension reference to be attached to the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">name the reference name for an extension</param>
        /// <returns>the first stage of the extension reference definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IBlank<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithExtension.DefineNewExtension(string name)
        {
            return this.DefineNewExtension(name) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IBlank<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Begins the definition of an extension reference to be attached to the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">name the reference name for the extension</param>
        /// <returns>the first stage of the extension reference definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IBlank<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithExtension.DefineNewExtension(string name)
        {
            return this.DefineNewExtension(name) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IBlank<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the load balancer to be used as the Internet-facing load balancer for the virtual machines in the
        /// scale set.
        /// <p>
        /// This will replace the current internet-facing load balancer associated with the virtual machines in the
        /// scale set (if any).
        /// By default all the backend and inbound NAT pool of the load balancer will be associated with the primary
        /// network interface of the virtual machines unless a subset of them is selected in the next stages
        /// </summary>
        /// <param name="loadBalancer">loadBalancer the primary Internet-facing load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithPrimaryLoadBalancer.WithPrimaryInternetFacingLoadBalancer(ILoadBalancer loadBalancer)
        {
            return this.WithPrimaryInternetFacingLoadBalancer(loadBalancer) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool;
        }

        /// <summary>
        /// Associates the specified Internet-facing load balancer backends with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">backendNames the backend names</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerNatPool Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool.WithPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithPrimaryInternetFacingLoadBalancerBackends(backendNames) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerNatPool;
        }

        /// <summary>
        /// Associates the specified backends of the selected load balancer with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">backendNames the names of existing backends in the selected load balancer</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerNatPool Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool.WithPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithPrimaryInternetFacingLoadBalancerBackends(backendNames) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerNatPool;
        }

        /// <summary>
        /// Associate an existing virtual network subnet with the primary network interface of the virtual machines
        /// in the scale set.
        /// </summary>
        /// <param name="network">network an existing virtual network</param>
        /// <param name="subnetName">subnetName the subnet name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancer Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithNetworkSubnet.WithExistingPrimaryNetworkSubnet(INetwork network, string subnetName)
        {
            return this.WithExistingPrimaryNetworkSubnet(network, subnetName) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancer;
        }

        /// <summary>
        /// Associates the specified backends of the selected load balancer with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">backendNames names of existing backends in the selected load balancer</param>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithInternalInternalLoadBalancerNatPool Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithInternalLoadBalancerBackendOrNatPool.WithPrimaryInternalLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithPrimaryInternalLoadBalancerBackends(backendNames) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithInternalInternalLoadBalancerNatPool;
        }

        /// <summary>
        /// Specifies that the latest version of a marketplace Linux image should be used.
        /// </summary>
        /// <param name="publisher">publisher the publisher of the image</param>
        /// <param name="offer">offer the offer of the image</param>
        /// <param name="sku">sku the SKU of the image</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithOS.WithLatestLinuxImage(string publisher, string offer, string sku)
        {
            return this.WithLatestLinuxImage(publisher, offer, sku) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName;
        }

        /// <summary>
        /// Specifies the user (custom) Linux image used as the virtual machine's operating system.
        /// </summary>
        /// <param name="imageUrl">imageUrl the url the the VHD</param>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithOS.WithStoredLinuxImage(string imageUrl)
        {
            return this.WithStoredLinuxImage(imageUrl) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName;
        }

        /// <summary>
        /// Specifies the specific version of a market-place Linux image that should be used.
        /// </summary>
        /// <param name="imageReference">imageReference describes the publisher, offer, SKU and version of the market-place image</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithOS.WithSpecificLinuxImageVersion(ImageReference imageReference)
        {
            return this.WithSpecificLinuxImageVersion(imageReference) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName;
        }

        /// <summary>
        /// Specifies that the latest version of the specified marketplace Windows image should be used.
        /// </summary>
        /// <param name="publisher">publisher specifies the publisher of the image</param>
        /// <param name="offer">offer specifies the offer of the image</param>
        /// <param name="sku">sku specifies the SKU of the image</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithOS.WithLatestWindowsImage(string publisher, string offer, string sku)
        {
            return this.WithLatestWindowsImage(publisher, offer, sku) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName;
        }

        /// <summary>
        /// Specifies a known marketplace Windows image used as the operating system for the virtual machines in the scale set.
        /// </summary>
        /// <param name="knownImage">knownImage a known market-place image</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithOS.WithPopularWindowsImage(KnownWindowsVirtualMachineImage knownImage)
        {
            return this.WithPopularWindowsImage(knownImage) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName;
        }

        /// <summary>
        /// Specifies a known marketplace Linux image used as the virtual machine's operating system.
        /// </summary>
        /// <param name="knownImage">knownImage a known market-place image</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithOS.WithPopularLinuxImage(KnownLinuxVirtualMachineImage knownImage)
        {
            return this.WithPopularLinuxImage(knownImage) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName;
        }

        /// <summary>
        /// Specifies the specific version of a marketplace Windows image needs to be used.
        /// </summary>
        /// <param name="imageReference">imageReference describes publisher, offer, SKU and version of the marketplace image</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithOS.WithSpecificWindowsImageVersion(ImageReference imageReference)
        {
            return this.WithSpecificWindowsImageVersion(imageReference) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName;
        }

        /// <summary>
        /// Specifies the user (custom) Windows image to be used as the operating system for the virtual machines in the
        /// scale set.
        /// </summary>
        /// <param name="imageUrl">imageUrl the URL of the VHD</param>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithOS.WithStoredWindowsImage(string imageUrl)
        {
            return this.WithStoredWindowsImage(imageUrl) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName;
        }

        /// <summary>
        /// Specifies the virtual machine scale set upgrade policy mode.
        /// </summary>
        /// <param name="upgradeMode">upgradeMode an upgrade policy mode</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithUpgradePolicy.WithUpgradeMode(UpgradeMode upgradeMode)
        {
            return this.WithUpgradeMode(upgradeMode) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="skuType">skuType the SKU type</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithSku.WithSku(VirtualMachineScaleSetSkuTypes skuType)
        {
            return this.WithSku(skuType) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="sku">sku a SKU from the list of available sizes for the virtual machines in this scale set</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithSku.WithSku(IVirtualMachineScaleSetSku sku)
        {
            return this.WithSku(sku) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="skuType">skuType the SKU type</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithNetworkSubnet Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithSku.WithSku(VirtualMachineScaleSetSkuTypes skuType)
        {
            return this.WithSku(skuType) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithNetworkSubnet;
        }

        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="sku">sku a SKU from the list of available sizes for the virtual machines in this scale set</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithNetworkSubnet Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithSku.WithSku(IVirtualMachineScaleSetSku sku)
        {
            return this.WithSku(sku) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithNetworkSubnet;
        }

        /// <summary>
        /// Enables automatic updates.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate.WithAutoUpdate()
        {
            return this.WithAutoUpdate() as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Disables the VM agent.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate.WithoutVmAgent()
        {
            return this.WithoutVmAgent() as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Specifies the WinRM listener.
        /// <p>
        /// Each call to this method adds the given listener to the list of VM's WinRM listeners.
        /// </summary>
        /// <param name="listener">listener a WinRm listener</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate.WithWinRm(WinRMListener listener)
        {
            return this.WithWinRm(listener) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Disables automatic updates.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate.WithoutAutoUpdate()
        {
            return this.WithoutAutoUpdate() as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Specifies the time zone for the virtual machines to use.
        /// </summary>
        /// <param name="timeZone">timeZone a time zone</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate.WithTimeZone(string timeZone)
        {
            return this.WithTimeZone(timeZone) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Enables the VM agent.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate.WithVmAgent()
        {
            return this.WithVmAgent() as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate;
        }

        /// <summary>
        /// Specifies the new number of virtual machines in the scale set.
        /// </summary>
        /// <param name="capacity">capacity the virtual machine capacity of the scale set</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithCapacity.WithCapacity(int capacity)
        {
            return this.WithCapacity(capacity) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Specifies the maximum number of virtual machines in the scale set.
        /// </summary>
        /// <param name="capacity">capacity the virtual machine capacity</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCapacity.WithCapacity(int capacity)
        {
            return this.WithCapacity(capacity) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <returns>the extensions attached to the virtual machines in the scale set</returns>
        System.Collections.Generic.IDictionary<string, Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSetExtension> Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.Extensions()
        {
            return this.Extensions() as System.Collections.Generic.IDictionary<string, Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSetExtension>;
        }

        /// <returns>the internet-facing load balancer associated with the primary network interface of</returns>
        /// <returns>the virtual machines in the scale set.</returns>
        Microsoft.Azure.Management.Fluent.Network.ILoadBalancer Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.GetPrimaryInternetFacingLoadBalancer()
        {
            return this.GetPrimaryInternetFacingLoadBalancer() as Microsoft.Azure.Management.Fluent.Network.ILoadBalancer;
        }

        /// <returns>the name of the OS disk of virtual machines in the scale set</returns>
        string Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.OsDiskName
        {
            get
            {
                return this.OsDiskName as string;
            }
        }
        /// <returns>the virtual network associated with the primary network interfaces of the virtual machines</returns>
        /// <returns>in the scale set.</returns>
        /// <returns><p></returns>
        /// <returns>A primary internal load balancer associated with the primary network interfaces of the scale set</returns>
        /// <returns>virtual machine will be also belong to this network</returns>
        /// <returns></p></returns>
        Microsoft.Azure.Management.Fluent.Network.INetwork Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.GetPrimaryNetwork()
        {
            return this.GetPrimaryNetwork() as Microsoft.Azure.Management.Fluent.Network.INetwork;
        }

        /// <summary>
        /// Re-images (updates the version of the installed operating system) the virtual machines in the scale set.
        /// </summary>
        void Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.Reimage()
        {
            this.Reimage();
        }

        /// <returns>the operating system disk caching type</returns>
        Microsoft.Azure.Management.Compute.Models.CachingTypes? Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.OsDiskCachingType
        {
            get
            {
                return this.OsDiskCachingType;
            }
        }
        /// <returns>the URL to storage containers that store the VHDs of the virtual machines in the scale set</returns>
        System.Collections.Generic.List<string> Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.VhdContainers
        {
            get
            {
                return this.VhdContainers as System.Collections.Generic.List<string>;
            }
        }
        /// <summary>
        /// Starts the virtual machines in the scale set.
        /// </summary>
        void Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.Start()
        {
            this.Start();
        }

        /// <returns> available SKUs for the virtual machine scale set, including the minimum and maximum virtual machine instances</returns>
        /// <returns>allowed for a particular SKU</returns>
        Microsoft.Azure.Management.Fluent.Resource.Core.PagedList<Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSetSku> Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.ListAvailableSkus()
        {
            return this.ListAvailableSkus() as Microsoft.Azure.Management.Fluent.Resource.Core.PagedList<Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSetSku>;
        }

        /// <returns>the operating system of the virtual machines in the scale set</returns>
        Microsoft.Azure.Management.Compute.Models.OperatingSystemTypes? Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.OsType
        {
            get
            {
                return this.OsType;
            }
        }
        /// <summary>
        /// Shuts down the virtual machines in the scale set and releases its compute resources.
        /// </summary>
        void Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.Deallocate()
        {
            this.Deallocate();
        }

        /// <returns>the internet-facing load balancer's backends associated with the primary network interface</returns>
        /// <returns>of the virtual machines in the scale set</returns>
        System.Collections.Generic.IDictionary<string, Microsoft.Azure.Management.Fluent.Network.IBackend> Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.ListPrimaryInternetFacingLoadBalancerBackends()
        {
            return this.ListPrimaryInternetFacingLoadBalancerBackends() as System.Collections.Generic.IDictionary<string, Microsoft.Azure.Management.Fluent.Network.IBackend>;
        }

        /// <returns>the internal load balancer associated with the primary network interface of</returns>
        /// <returns>the virtual machines in the scale set</returns>
        Microsoft.Azure.Management.Fluent.Network.ILoadBalancer Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.GetPrimaryInternalLoadBalancer()
        {
            return this.GetPrimaryInternalLoadBalancer() as Microsoft.Azure.Management.Fluent.Network.ILoadBalancer;
        }

        /// <returns>true if over provision is enabled for the virtual machines, false otherwise</returns>
        bool? Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.OverProvisionEnabled
        {
            get
            {
                return this.OverProvisionEnabled;
            }
        }
        /// <summary>
        /// Powers off (stops) the virtual machines in the scale set.
        /// </summary>
        void Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.PowerOff()
        {
            this.PowerOff();
        }

        /// <returns>the internal load balancer's backends associated with the primary network interface</returns>
        /// <returns>of the virtual machines in the scale set</returns>
        System.Collections.Generic.IDictionary<string, Microsoft.Azure.Management.Fluent.Network.IBackend> Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.ListPrimaryInternalLoadBalancerBackends()
        {
            return this.ListPrimaryInternalLoadBalancerBackends() as System.Collections.Generic.IDictionary<string, Microsoft.Azure.Management.Fluent.Network.IBackend>;
        }

        /// <returns>the SKU of the virtual machines in the scale set</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetSkuTypes Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.Sku()
        {
            return this.Sku() as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetSkuTypes;
        }

        /// <returns>the upgradeModel</returns>
        Microsoft.Azure.Management.Compute.Models.UpgradeMode? Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.UpgradeModel
        {
            get
            {
                return this.UpgradeModel;
            }
        }
        /// <summary>
        /// Restarts the virtual machines in the scale set.
        /// </summary>
        void Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.Restart()
        {
            this.Restart();
        }

        /// <returns>the name prefix of the virtual machines in the scale set</returns>
        string Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.ComputerNamePrefix
        {
            get
            {
                return this.ComputerNamePrefix as string;
            }
        }
        /// <returns>the storage profile</returns>
        Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetStorageProfile Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.StorageProfile
        {
            get
            {
                return this.StorageProfile as Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetStorageProfile;
            }
        }
        /// <returns>the list of IDs of the public IP addresses associated with the primary Internet-facing load balancer</returns>
        /// <returns>of the scale set</returns>
        System.Collections.Generic.List<string> Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.PrimaryPublicIpAddressIds
        {
            get
            {
                return this.PrimaryPublicIpAddressIds as System.Collections.Generic.List<string>;
            }
        }
        /// <returns>the inbound NAT pools of the internal load balancer associated with the primary network interface</returns>
        /// <returns>of the virtual machines in the scale set, if any.</returns>
        System.Collections.Generic.IDictionary<string, Microsoft.Azure.Management.Fluent.Network.IInboundNatPool> Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.ListPrimaryInternalLoadBalancerInboundNatPools()
        {
            return this.ListPrimaryInternalLoadBalancerInboundNatPools() as System.Collections.Generic.IDictionary<string, Microsoft.Azure.Management.Fluent.Network.IInboundNatPool>;
        }

        /// <returns>the network profile</returns>
        Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetNetworkProfile Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.NetworkProfile
        {
            get
            {
                return this.NetworkProfile as Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetNetworkProfile;
            }
        }
        /// <returns>the number of virtual machine instances in the scale set</returns>
        int? Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.Capacity
        {
            get
            {
                return this.Capacity;
            }
        }
        /// <returns>the internet-facing load balancer's inbound NAT pool associated with the primary network interface</returns>
        /// <returns>of the virtual machines in the scale set</returns>
        System.Collections.Generic.IDictionary<string, Microsoft.Azure.Management.Fluent.Network.IInboundNatPool> Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet.ListPrimaryInternetFacingLoadBalancerInboundNatPools()
        {
            return this.ListPrimaryInternetFacingLoadBalancerInboundNatPools() as System.Collections.Generic.IDictionary<string, Microsoft.Azure.Management.Fluent.Network.IInboundNatPool>;
        }

        /// <summary>
        /// Associate internal load balancer inbound NAT pools with the the primary network interface of the
        /// scale set virtual machine.
        /// </summary>
        /// <param name="natPoolNames">natPoolNames inbound NAT pool names</param>
        /// <returns>the next stage of the virtual machine scale set definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithOS Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithInternalInternalLoadBalancerNatPool.WithPrimaryInternalLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            return this.WithPrimaryInternalLoadBalancerInboundNatPools(natPoolNames) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithOS;
        }

        /// <summary>
        /// Specifies the load balancer to be used as the internal load balancer for the virtual machines in the
        /// scale set.
        /// <p>
        /// This will replace the current internal load balancer associated with the virtual machines in the
        /// scale set (if any).
        /// By default all the backends and inbound NAT pools of the load balancer will be associated with the primary
        /// network interface of the virtual machines in the scale set unless subset of them is selected in the next stages.
        /// </p>
        /// </summary>
        /// <param name="loadBalancer">loadBalancer the primary Internet-facing load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerBackendOrNatPool Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancer.WithPrimaryInternalLoadBalancer(ILoadBalancer loadBalancer)
        {
            return this.WithPrimaryInternalLoadBalancer(loadBalancer) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerBackendOrNatPool;
        }

        /// <summary>
        /// Specifies that no internal load balancer should be associated with the primary network interfaces of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithOS Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer.WithoutPrimaryInternalLoadBalancer()
        {
            return this.WithoutPrimaryInternalLoadBalancer() as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithOS;
        }

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
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithInternalLoadBalancerBackendOrNatPool Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer.WithPrimaryInternalLoadBalancer(ILoadBalancer loadBalancer)
        {
            return this.WithPrimaryInternalLoadBalancer(loadBalancer) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithInternalLoadBalancerBackendOrNatPool;
        }

        /// <summary>
        /// Specifies the name for the OS disk.
        /// </summary>
        /// <param name="name">name the OS disk name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithOsDiskSettings.WithOsDiskName(string name)
        {
            return this.WithOsDiskName(name) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the caching type for the operating system disk.
        /// </summary>
        /// <param name="cachingType">cachingType the caching type</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithOsDiskSettings.WithOsDiskCaching(CachingTypes cachingType)
        {
            return this.WithOsDiskCaching(cachingType) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that no public load balancer should be associated with the virtual machine scale set.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancer.WithoutPrimaryInternetFacingLoadBalancer()
        {
            return this.WithoutPrimaryInternetFacingLoadBalancer() as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer;
        }

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
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancer.WithPrimaryInternetFacingLoadBalancer(ILoadBalancer loadBalancer)
        {
            return this.WithPrimaryInternetFacingLoadBalancer(loadBalancer) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool;
        }

        /// <summary>
        /// Disables over-provisioning of virtual machines.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithOverProvision.WithoutOverProvisioning()
        {
            return this.WithoutOverProvisioning() as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables or disables over-provisioning of virtual machines in the scale set.
        /// </summary>
        /// <param name="enabled">enabled true if enabling over-0provisioning of virtual machines in the</param>
        /// <param name="scale">scale set, otherwise false</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithOverProvision.WithOverProvision(bool enabled)
        {
            return this.WithOverProvision(enabled) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables over-provisioning of virtual machines.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithOverProvision.WithOverProvisioning()
        {
            return this.WithOverProvisioning() as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Removes the association between the Internet-facing load balancer and the primary network interface configuration.
        /// <p>
        /// This removes the association between primary network interface configuration and all the backends and
        /// inbound NAT pools in the load balancer.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancer.WithoutPrimaryInternetFacingLoadBalancer()
        {
            return this.WithoutPrimaryInternetFacingLoadBalancer() as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Removes the association between the internal load balancer and the primary network interface configuration.
        /// <p>
        /// This removes the association between primary network interface configuration and all the backends and
        /// inbound NAT pools in the load balancer.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancer.WithoutPrimaryInternalLoadBalancer()
        {
            return this.WithoutPrimaryInternalLoadBalancer() as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

    }
}