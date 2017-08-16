// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update
{
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify extensions.
    /// </summary>
    public interface IWithExtension 
    {
        /// <summary>
        /// Begins the description of an update of an existing extension assigned to the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">The reference name for the extension.</param>
        /// <return>The first stage of the extension reference update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IUpdate UpdateExtension(string name);

        /// <summary>
        /// Begins the definition of an extension reference to be attached to the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">The reference name for an extension.</param>
        /// <return>The first stage of the extension reference definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IBlank<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply> DefineNewExtension(string name);

        /// <summary>
        /// Removes the extension with the specified name from the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">The reference name of the extension to be removed/uninstalled.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutExtension(string name);
    }

    /// <summary>
    /// A stage of the virtual machine scale set update allowing to remove the associations between the primary network
    /// interface configuration and the specified inbound NAT pools of the load balancer.
    /// </summary>
    public interface IWithoutPrimaryLoadBalancerNatPool 
    {
        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specified inbound NAT pools
        /// of an Internet-facing load balancer.
        /// </summary>
        /// <param name="natPoolNames">The names of existing inbound NAT pools.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutPrimaryInternetFacingLoadBalancerNatPools(params string[] natPoolNames);

        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specified inbound NAT pools
        /// of the internal load balancer.
        /// </summary>
        /// <param name="natPoolNames">The names of existing inbound NAT pools.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutPrimaryInternalLoadBalancerNatPools(params string[] natPoolNames);
    }

    /// <summary>
    /// The stage of a virtual machine scale set update allowing to specify an internal load balancer for
    /// the primary network interface of the scale set virtual machines.
    /// </summary>
    public interface IWithPrimaryInternalLoadBalancer  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply
    {
        /// <summary>
        /// Specifies the load balancer to be used as the internal load balancer for the virtual machines in the
        /// scale set.
        /// This will replace the current internal load balancer associated with the virtual machines in the
        /// scale set (if any).
        /// By default all the backends and inbound NAT pools of the load balancer will be associated with the primary
        /// network interface of the virtual machines in the scale set unless subset of them is selected in the next stages.
        /// </p>.
        /// </summary>
        /// <param name="loadBalancer">The primary Internet-facing load balancer.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerBackendOrNatPool WithExistingPrimaryInternalLoadBalancer(ILoadBalancer loadBalancer);
    }

    /// <summary>
    /// The stage of a virtual machine scale set update allowing to remove the association between the primary network
    /// interface configuration and a backend of a load balancer.
    /// </summary>
    public interface IWithoutPrimaryLoadBalancerBackend 
    {
        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specified backends
        /// of the internal load balancer.
        /// </summary>
        /// <param name="backendNames">Existing backend names.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutPrimaryInternalLoadBalancerBackends(params string[] backendNames);

        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specfied backends
        /// of the Internet-facing load balancer.
        /// </summary>
        /// <param name="backendNames">Existing backend names.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames);
    }

    /// <summary>
    /// The stage of a virtual machine scale set update allowing to change the SKU for the virtual machines
    /// in the scale set.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="skuType">The SKU type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithSku(VirtualMachineScaleSetSkuTypes skuType);

        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="sku">A SKU from the list of available sizes for the virtual machines in this scale set.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithSku(IVirtualMachineScaleSetSku sku);
    }

    /// <summary>
    /// The stage of a virtual machine scale set update allowing to remove the public and internal load balancer
    /// from the primary network interface configuration.
    /// </summary>
    public interface IWithoutPrimaryLoadBalancer 
    {
        /// <summary>
        /// Removes the association between the Internet-facing load balancer and the primary network interface configuration.
        /// This removes the association between primary network interface configuration and all the backends and
        /// inbound NAT pools in the load balancer.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutPrimaryInternetFacingLoadBalancer();

        /// <summary>
        /// Removes the association between the internal load balancer and the primary network interface configuration.
        /// This removes the association between primary network interface configuration and all the backends and
        /// inbound NAT pools in the load balancer.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutPrimaryInternalLoadBalancer();
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify the number of
    /// virtual machines in the scale set.
    /// </summary>
    public interface IWithCapacity 
    {
        /// <summary>
        /// Specifies the new number of virtual machines in the scale set.
        /// </summary>
        /// <param name="capacity">The virtual machine capacity of the scale set.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithCapacity(int capacity);
    }

    /// <summary>
    /// The stage of a virtual machine scale set update allowing to specify load balancers for the primary
    /// network interface of the scale set virtual machines.
    /// </summary>
    public interface IWithPrimaryLoadBalancer  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancer
    {
        /// <summary>
        /// Specifies the load balancer to be used as the Internet-facing load balancer for the virtual machines in the
        /// scale set.
        /// This will replace the current Internet-facing load balancer associated with the virtual machines in the
        /// scale set (if any).
        /// By default all the backend and inbound NAT pool of the load balancer will be associated with the primary
        /// network interface of the virtual machines unless a subset of them is selected in the next stages.
        /// </summary>
        /// <param name="loadBalancer">The primary Internet-facing load balancer.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool WithExistingPrimaryInternetFacingLoadBalancer(ILoadBalancer loadBalancer);
    }

    /// <summary>
    /// The stage of a virtual machine scale set update containing inputs for the resource to be updated.
    /// </summary>
    public interface IWithApply  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithManagedDataDisk,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithUnmanagedDataDisk,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithSku,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithCapacity,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithExtension,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancer,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancerBackend,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancerNatPool,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithManagedServiceIdentity
    {
    }

    /// <summary>
    /// The stage of a virtual machine scale set update allowing to associate backend pools and/or inbound NAT pools
    /// of the selected internal load balancer with the primary network interface of the scale set virtual machines.
    /// </summary>
    public interface IWithPrimaryInternalLoadBalancerBackendOrNatPool  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerNatPool
    {
        /// <summary>
        /// Associates the specified internal load balancer backends with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">The names of existing backends on the selected load balancer.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerNatPool WithPrimaryInternalLoadBalancerBackends(params string[] backendNames);
    }

    /// <summary>
    /// The stage of a virtual machine scale set update allowing to associate inbound NAT pools of the selected internal
    /// load balancer with the primary network interface of the virtual machines in the scale set.
    /// </summary>
    public interface IWithPrimaryInternalLoadBalancerNatPool  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply
    {
        /// <summary>
        /// Associates the specified internal load balancer inbound NAT pools with the the primary network interface of
        /// the virtual machines in the scale set.
        /// </summary>
        /// <param name="natPoolNames">The names of existing inbound NAT pools in the selected load balancer.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithPrimaryInternalLoadBalancerInboundNatPools(params string[] natPoolNames);
    }

    /// <summary>
    /// The stage of a virtual machine scale set update allowing to associate a backend pool and/or inbound NAT pool
    /// of the selected Internet-facing load balancer with the primary network interface of the virtual machines in
    /// the scale set.
    /// </summary>
    public interface IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerNatPool
    {
        /// <summary>
        /// Associates the specified Internet-facing load balancer backends with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">The backend names.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerNatPool WithPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames);
    }

    /// <summary>
    /// The entirety of the virtual machine scale set update.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryLoadBalancer,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerBackendOrNatPool
    {
    }

    /// <summary>
    /// The stage of a virtual machine scale set update allowing to specify managed data disks.
    /// </summary>
    public interface IWithManagedDataDisk 
    {
        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given size.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <return>The next stage of virtual machine scale set update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithNewDataDisk(int sizeInGB);

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The next stage of virtual machine scale set update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType);

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <param name="storageAccountType">The storage account type.</param>
        /// <return>The next stage of virtual machine scale set update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType, StorageAccountTypes storageAccountType);

        /// <summary>
        /// Detaches managed data disk with the given LUN from the virtual machine scale set instances.
        /// </summary>
        /// <param name="lun">The disk LUN.</param>
        /// <return>The next stage of virtual machine scale set update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutDataDisk(int lun);
    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify unmanaged data disk.
    /// </summary>
    public interface IWithUnmanagedDataDisk 
    {
    }

    /// <summary>
    /// The stage of a virtual machine scale set update allowing to associate an inbound NAT pool of the selected
    /// Internet-facing load balancer with the primary network interface of the virtual machines in the scale set.
    /// </summary>
    public interface IWithPrimaryInternetFacingLoadBalancerNatPool  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancer
    {
        /// <summary>
        /// Associates inbound NAT pools of the selected Internet-facing load balancer with the primary network interface
        /// of the virtual machines in the scale set.
        /// </summary>
        /// <param name="natPoolNames">The names of existing inbound NAT pools on the selected load balancer.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancer WithPrimaryInternetFacingLoadBalancerInboundNatPools(params string[] natPoolNames);
    }

    /// <summary>
    /// The stage of the virtual machine scale set update allowing to enable Managed Service Identity.
    /// </summary>
    public interface IWithManagedServiceIdentity :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that Managed Service Identity needs to be enabled in the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithRoleAndScopeOrApply WithManagedServiceIdentity();

        /// <summary>
        /// Specifies that Managed Service Identity needs to be enabled in the virtual machine scale set.
        /// </summary>
        /// <param name="tokenPort">The port on the virtual machine scale set instance where access token is available.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithRoleAndScopeOrApply WithManagedServiceIdentity(int tokenPort);
    }

    /// <summary>
    /// The stage of the Managed Service Identity enabled virtual machine allowing to set role
    /// assignment for a scope.
    /// </summary>
    public interface IWithRoleAndScopeOrApply :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply
    {
        /// <summary>
        /// Specifies that applications running on the virtual machine scale set instance requires the access
        /// described in the given role definition with scope of access limited to the ARM resource identified by
        /// the resource ID specified in the scope parameter.
        /// </summary>
        /// <param name="scope">Scope of the access represented in ARM resource ID format.</param>
        /// <param name="roleDefinitionId">Role definition to assigned to the virtual machine scale set.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithRoleAndScopeOrApply WithRoleDefinitionBasedAccessTo(string scope, string roleDefinitionId);

        /// <summary>
        /// Specifies that applications running on the virtual machine scale set instance requires
        /// the given access role with scope of access limited to the current resource group that
        /// the virtual machine scale set resides.
        /// </summary>
        /// <param name="asRole">Access role to assigned to the virtual machine scale set.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithRoleAndScopeOrApply WithRoleBasedAccessToCurrentResourceGroup(BuiltInRole asRole);

        /// <summary>
        /// Specifies that applications running on the virtual machine scale set instance requires
        /// the given access role with scope of access limited to the ARM resource identified by
        /// the resource ID specified in the scope parameter.
        /// </summary>
        /// <param name="scope">Scope of the access represented in ARM resource ID format.</param>
        /// <param name="asRole">Access role to assigned to the virtual machine scale set.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithRoleAndScopeOrApply WithRoleBasedAccessTo(string scope, BuiltInRole asRole);

        /// <summary>
        /// Specifies that applications running on the virtual machine scale set instance requires the access
        /// described in the given role definition with scope of access limited to the current resource group
        /// that the virtual machine scale set resides.
        /// </summary>
        /// <param name="roleDefinitionId">Role definition to assigned to the virtual machine scale set.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithRoleAndScopeOrApply WithRoleDefinitionBasedAccessToCurrentResourceGroup(string roleDefinitionId);
    }

}