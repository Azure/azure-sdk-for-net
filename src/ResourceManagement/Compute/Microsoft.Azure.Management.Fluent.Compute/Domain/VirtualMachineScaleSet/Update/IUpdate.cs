// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update
{

    using Microsoft.Azure.Management.Fluent.Compute;
    using Microsoft.Azure.Management.Fluent.Resource.Core.Resource.Update;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update;
    using Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network;
    /// <summary>
    /// The stage of a virtual machine scale set update allowing to remove the public and internal load balancer
    /// from the primary network interface configuration.
    /// </summary>
    public interface IWithoutPrimaryLoadBalancer 
    {
        /// <summary>
        /// Removes the association between the Internet-facing load balancer and the primary network interface configuration.
        /// <p>
        /// This removes the association between primary network interface configuration and all the backends and
        /// inbound NAT pools in the load balancer.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply WithoutPrimaryInternetFacingLoadBalancer();

        /// <summary>
        /// Removes the association between the internal load balancer and the primary network interface configuration.
        /// <p>
        /// This removes the association between primary network interface configuration and all the backends and
        /// inbound NAT pools in the load balancer.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply WithoutPrimaryInternalLoadBalancer();

    }
    /// <summary>
    /// The stage of a virtual machine scale set update containing inputs for the resource to be updated
    /// (via {@link WithApply#apply()}).
    /// </summary>
    public interface IWithApply  :
        IAppliable<Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet>,
        IUpdateWithTags<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>,
        IWithSku,
        IWithCapacity,
        IWithExtension,
        IWithoutPrimaryLoadBalancer,
        IWithoutPrimaryLoadBalancerBackend,
        IWithoutPrimaryLoadBalancerNatPool
    {
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
        /// <param name="capacity">capacity the virtual machine capacity of the scale set</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply WithCapacity(int capacity);

    }
    /// <summary>
    /// The stage of a virtual machine scale set update allowing to associate backend pools and/or inbound NAT pools
    /// of the selected internal load balancer with the primary network interface of the scale set virtual machines.
    /// </summary>
    public interface IWithPrimaryInternalLoadBalancerBackendOrNatPool  :
        IWithPrimaryInternalLoadBalancerNatPool
    {
        /// <summary>
        /// Associates the specified internal load balancer backends with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">backendNames the names of existing backends on the selected load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerNatPool WithPrimaryInternalLoadBalancerBackends(params string[] backendNames);

    }
    /// <summary>
    /// The stage of a virtual machine scale set update allowing to remove the association between the primary network
    /// interface configuration and a backend of a load balancer.
    /// </summary>
    public interface IWithoutPrimaryLoadBalancerBackend 
    {
        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specfied backends
        /// of the Internet-facing load balancer.
        /// </summary>
        /// <param name="backendNames">backendNames existing backend names</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply WithoutPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames);

        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specified backends
        /// of the internal load balancer.
        /// </summary>
        /// <param name="backendNames">backendNames existing backend names</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply WithoutPrimaryInternalLoadBalancerBackends(params string[] backendNames);

    }
    /// <summary>
    /// The stage of a virtual machine scale set update allowing to associate inbound NAT pools of the selected internal
    /// load balancer with the primary network interface of the virtual machines in the scale set.
    /// </summary>
    public interface IWithPrimaryInternalLoadBalancerNatPool  :
        IWithApply
    {
        /// <summary>
        /// Associates the specified internal load balancer inbound NAT pools with the the primary network interface of
        /// the virtual machines in the scale set.
        /// </summary>
        /// <param name="natPoolNames">natPoolNames the names of existing inbound NAT pools in the selected load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply WithPrimaryInternalLoadBalancerInboundNatPools(params string[] natPoolNames);

    }
    /// <summary>
    /// The stage of a virtual machine scale set update allowing to associate a backend pool and/or inbound NAT pool
    /// of the selected Internet-facing load balancer with the primary network interface of the virtual machines in
    /// the scale set.
    /// </summary>
    public interface IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool  :
        IWithPrimaryInternetFacingLoadBalancerNatPool
    {
        /// <summary>
        /// Associates the specified Internet-facing load balancer backends with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">backendNames the backend names</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerNatPool WithPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames);

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
        /// <param name="skuType">skuType the SKU type</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply WithSku(VirtualMachineScaleSetSkuTypes skuType);

        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="sku">sku a SKU from the list of available sizes for the virtual machines in this scale set</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply WithSku(IVirtualMachineScaleSetSku sku);

    }
    /// <summary>
    /// The stage of the virtual machine definition allowing to specify extensions.
    /// </summary>
    public interface IWithExtension 
    {
        /// <summary>
        /// Begins the definition of an extension reference to be attached to the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">name the reference name for an extension</param>
        /// <returns>the first stage of the extension reference definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IBlank<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply> DefineNewExtension(string name);

        /// <summary>
        /// Begins the description of an update of an existing extension assigned to the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">name the reference name for the extension</param>
        /// <returns>the first stage of the extension reference update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update.IUpdate UpdateExtension(string name);

        /// <summary>
        /// Removes the extension with the specified name from the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">name the reference name of the extension to be removed/uninstalled</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply WithoutExtension(string name);

    }
    /// <summary>
    /// The stage of a virtual machine scale set update allowing to specify load balancers for the primary
    /// network interface of the scale set virtual machines.
    /// </summary>
    public interface IWithPrimaryLoadBalancer  :
        IWithPrimaryInternalLoadBalancer
    {
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
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool WithPrimaryInternetFacingLoadBalancer(ILoadBalancer loadBalancer);

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
        /// <param name="natPoolNames">natPoolNames the names of existing inbound NAT pools</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply WithoutPrimaryInternetFacingLoadBalancerNatPools(params string[] natPoolNames);

        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specified inbound NAT pools
        /// of the internal load balancer.
        /// </summary>
        /// <param name="natPoolNames">natPoolNames the names of existing inbound NAT pools</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply WithoutPrimaryInternalLoadBalancerNatPools(params string[] natPoolNames);

    }
    /// <summary>
    /// The stage of a virtual machine scale set update allowing to specify an internal load balancer for
    /// the primary network interface of the scale set virtual machines.
    /// </summary>
    public interface IWithPrimaryInternalLoadBalancer  :
        IWithApply
    {
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
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerBackendOrNatPool WithPrimaryInternalLoadBalancer(ILoadBalancer loadBalancer);

    }
    /// <summary>
    /// The stage of a virtual machine scale set update allowing to associate an inbound NAT pool of the selected
    /// Internet-facing load balancer with the primary network interface of the virtual machines in the scale set.
    /// </summary>
    public interface IWithPrimaryInternetFacingLoadBalancerNatPool  :
        IWithPrimaryInternalLoadBalancer
    {
        /// <summary>
        /// Associates inbound NAT pools of the selected Internet-facing load balancer with the primary network interface
        /// of the virtual machines in the scale set.
        /// </summary>
        /// <param name="natPoolNames">natPoolNames the names of existing inbound NAT pools on the selected load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancer WithPrimaryInternetFacingLoadBalancerInboundNatPools(params string[] natPoolNames);

    }
    /// <summary>
    /// The entirety of the load balancer update.
    /// </summary>
    public interface IUpdate  :
        IWithPrimaryLoadBalancer,
        IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool,
        IWithPrimaryInternalLoadBalancerBackendOrNatPool
    {
    }
}