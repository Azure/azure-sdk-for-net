// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition;
using Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update;
using Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition;
using Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update;
using Microsoft.Azure.Management.V2.Network;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition;
using Microsoft.Azure.Management.V2.Resource.Core.Resource.Definition;
using Microsoft.Azure.Management.V2.Resource.Core.Resource.Update;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using Microsoft.Azure.Management.V2.Storage;
using Microsoft.Azure.Management.Compute;
using Microsoft.Rest.Azure;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Management.V2.Compute
{
    internal partial class VirtualMachineScaleSetImpl
    {
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate
    Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate.WithAutoUpdate()
        {
            return this.WithAutoUpdate() as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate.WithoutAutoUpdate()
        {
            return this.WithoutAutoUpdate() as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate.WithVmAgent()
        {
            return this.WithVmAgent() as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate
    Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate.WithoutVmAgent()
        {
            return this.WithoutVmAgent() as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IBlank<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate> 
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithExtension.DefineNewExtension(string name)
        {
            return this.DefineNewExtension(name) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IBlank<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IBlank<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply>
    Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithExtension.DefineNewExtension(string name)
        {
            return this.DefineNewExtension(name) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IBlank<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply>;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName.WithAdminUserName(string adminUserName)
        {
            return this.WithAdminUserName(adminUserName) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCapacity.WithCapacity(int capacity)
        {
            return this.WithCapacity(capacity) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithComputerNamePrefix.WithComputerNamePrefix(string namePrefix)
        {
            return this.WithComputerNamePrefix(namePrefix) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithSku
            Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition.IWithExistingResourceGroup<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithSku>.WithExistingResourceGroup(IResourceGroup group)
        {
            return this.WithExistingResourceGroup(group) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithSku;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithSku
            Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition.IWithExistingResourceGroup<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithSku>.WithExistingResourceGroup(string groupName)
        {
            return this.WithExistingResourceGroup(groupName) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithSku;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithStorageAccount.WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            return this.WithExistingStorageAccount(storageAccount) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithOS.WithLatestLinuxImage(string publisher, string offer, string sku)
        {
            return this.WithLatestLinuxImage(publisher, offer, sku) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithOS.WithLatestWindowsImage(string publisher, string offer, string sku)
        {
            return this.WithLatestWindowsImage(publisher, offer, sku) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithSku
            Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition.IWithNewResourceGroup<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithSku>.WithNewResourceGroup()
        {
            return this.WithNewResourceGroup() as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithSku;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithSku
            Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition.IWithNewResourceGroup<VirtualMachineScaleSet.Definition.IWithSku>.WithNewResourceGroup(ICreatable<IResourceGroup> groupDefinition)
        {
            return this.WithNewResourceGroup(groupDefinition) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithSku;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithSku
            Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition.IWithNewResourceGroup<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithSku>.WithNewResourceGroup(string name)
        {
            return this.WithNewResourceGroup(name) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithSku;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithStorageAccount.WithNewStorageAccount(ICreatable<IStorageAccount> creatable)
        {
            return this.WithNewStorageAccount(creatable) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithStorageAccount.WithNewStorageAccount(string name)
        {
            return this.WithNewStorageAccount(name) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithOsDiskSettings.WithOsDiskCaching(CachingTypes cachingType)
        {
            return this.WithOsDiskCaching(cachingType) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithOsDiskSettings.WithOsDiskName(string name)
        {
            return this.WithOsDiskName(name) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithOS
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer.WithoutPrimaryInternalLoadBalancer()
        {
            return WithoutPrimaryInternalLoadBalancer() as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithOS;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancer.WithoutPrimaryInternetFacingLoadBalancer()
        {
            return this.WithoutPrimaryInternetFacingLoadBalancer() as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithOverProvision.WithOverProvision(bool enabled)
        {
            return this.WithOverProvision(enabled) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithOverProvision.WithOverProvisioning()
        {
            return this.WithOverProvisioning() as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithOverProvision.WithoutOverProvisioning()
        {
            return this.WithoutOverProvisioning() as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithPassword.WithPassword(string password)
        {
            return this.WithPassword(password) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithOS.WithPopularLinuxImage(KnownLinuxVirtualMachineImage knownImage)
        {
            return this.WithPopularLinuxImage(knownImage) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithOS.WithPopularWindowsImage(KnownWindowsVirtualMachineImage knownImage)
        {
            return this.WithPopularWindowsImage(knownImage) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithInternalLoadBalancerBackendOrNatPool
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer.WithPrimaryInternalLoadBalancer(ILoadBalancer loadBalancer)
        {
            return this.WithPrimaryInternalLoadBalancer(loadBalancer) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithInternalLoadBalancerBackendOrNatPool;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithInternalInternalLoadBalancerNatPool
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithInternalLoadBalancerBackendOrNatPool.WithPrimaryInternalLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithPrimaryInternalLoadBalancerBackends(backendNames) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithInternalInternalLoadBalancerNatPool;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithOS
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithInternalInternalLoadBalancerNatPool.WithPrimaryInternalLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            return this.WithPrimaryInternalLoadBalancerInboundNatPools(natPoolNames) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithOS;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancer.WithPrimaryInternetFacingLoadBalancer(ILoadBalancer loadBalancer)
        {
            return this.WithPrimaryInternetFacingLoadBalancer(loadBalancer) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerNatPool
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool.WithPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithPrimaryInternetFacingLoadBalancerBackends(backendNames) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerNatPool;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerNatPool.WithPrimaryInternetFacingLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            return this.WithPrimaryInternetFacingLoadBalancerInboundNatPools(natPoolNames) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithLinuxCreate
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName.WithRootUserName(string rootUserName)
        {
            return this.WithRootUserName(rootUserName) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithLinuxCreate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithNetworkSubnet
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithSku.WithSku(IVirtualMachineScaleSetSku sku)
        {
            return this.WithSku(sku) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithNetworkSubnet;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithNetworkSubnet
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithSku.WithSku(VirtualMachineScaleSetSkuTypes skuType)
        {
            return this.WithSku(skuType) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithNetworkSubnet;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithOS.WithSpecificLinuxImageVersion(ImageReference imageReference)
        {
            return this.WithSpecificLinuxImageVersion(imageReference) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithOS.WithSpecificWindowsImageVersion(ImageReference imageReference)
        {
            return this.WithSpecificWindowsImageVersion(imageReference) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithLinuxCreate
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithLinuxCreate.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithLinuxCreate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithOS.WithStoredLinuxImage(string imageUrl)
        {
            return this.WithStoredLinuxImage(imageUrl) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithRootUserName;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithOS.WithStoredWindowsImage(string imageUrl)
        {
            return this.WithStoredWindowsImage(imageUrl) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithAdminUserName;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancer
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithNetworkSubnet.WithExistingPrimaryNetworkSubnet(INetwork network, string subnetName)
        {
            return this.WithExistingPrimaryNetworkSubnet(network, subnetName) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancer;
        }


        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate.WithTimeZone(string timeZone)
        {
            return this.WithTimeZone(timeZone) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithUpgradePolicy.WithUpgradeMode(UpgradeMode upgradeMode)
        {
            return this.WithUpgradeMode(upgradeMode) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate.WithWinRm(WinRMListener listener)
        {
            return this.WithWinRm(listener) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithWindowsCreate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IUpdate
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithExtension.UpdateExtension(string name)
        {
            return this.UpdateExtension(name) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IUpdate;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithCapacity.WithCapacity(int capacity)
        {
            return this.WithCapacity(capacity) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithExtension.WithoutExtension(string name)
        {
            return this.WithoutExtension(name) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancer.WithoutPrimaryInternalLoadBalancer()
        {
            return this.WithoutPrimaryInternalLoadBalancer() as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancerBackend.WithoutPrimaryInternalLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithoutPrimaryInternalLoadBalancerBackends(backendNames) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancerNatPool.WithoutPrimaryInternalLoadBalancerNatPools(params string[] natPoolNames)
        {
            return this.WithoutPrimaryInternalLoadBalancerNatPools(natPoolNames) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancer.WithoutPrimaryInternetFacingLoadBalancer()
        {
            return this.WithoutPrimaryInternetFacingLoadBalancer() as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancerBackend.WithoutPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithoutPrimaryInternetFacingLoadBalancerBackends(backendNames) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancerNatPool.WithoutPrimaryInternetFacingLoadBalancerNatPools(params string[] natPoolNames)
        {
            return this.WithoutPrimaryInternetFacingLoadBalancerNatPools(natPoolNames) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerBackendOrNatPool
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancer.WithPrimaryInternalLoadBalancer(ILoadBalancer loadBalancer)
        {
            return this.WithPrimaryInternalLoadBalancer(loadBalancer) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerBackendOrNatPool;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerNatPool
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerBackendOrNatPool.WithPrimaryInternalLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithPrimaryInternalLoadBalancerBackends(backendNames) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerNatPool;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerNatPool.WithPrimaryInternalLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            return this.WithPrimaryInternalLoadBalancerInboundNatPools(natPoolNames) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithPrimaryLoadBalancer.WithPrimaryInternetFacingLoadBalancer(ILoadBalancer loadBalancer)
        {
            return this.WithPrimaryInternetFacingLoadBalancer(loadBalancer) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerNatPool
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool.WithPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithPrimaryInternetFacingLoadBalancerBackends(backendNames) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerNatPool;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancer
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerNatPool.WithPrimaryInternetFacingLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            return this.WithPrimaryInternetFacingLoadBalancerInboundNatPools(natPoolNames) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancer;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithSku.WithSku(IVirtualMachineScaleSetSku sku)
        {
            return this.WithSku(sku) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply
            Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithSku.WithSku(VirtualMachineScaleSetSkuTypes skuType)
        {
            return this.WithSku(skuType) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }
    }
}
