/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update
{

    using Microsoft.Azure.Management.V2.Network;
    using Microsoft.Azure.Management.V2.Compute;
    using Microsoft.Azure.Management.V2.Resource.Core.Resource.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update;
    /// <summary>
    /// The stage of the virtual machine scale set update allowing to associate inbound NAT pool of the internet
    /// facing load balancer selected in the previous state {@link WithPrimaryLoadBalancer} with the
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
        /// <returns>the next stage of the virtual machine scale set update</returns>
        IWithPrimaryInternalLoadBalancer WithPrimaryInternetFacingLoadBalancerInboundNatPools (params string[] natPoolNames);

    }
    /// <summary>
    /// The stage of the virtual machine scale set update allowing to specify load balancers for the primary
    /// network interface of the scale set virtual machines.
    /// </summary>
    public interface IWithPrimaryLoadBalancer  :
        IWithPrimaryInternalLoadBalancer
    {
        /// <summary>
        /// Specifies load balancer to tbe used as the internet facing load balancer for the virtual machines in the
        /// scale set.
        /// <p>
        /// This will replace the current internet facing load balancer associated with the virtual machines in the
        /// scale set (if any).
        /// By default all the backend and inbound NAT pool of the load balancer will be associated with the primary
        /// network interface of the scale set virtual machines unless subset of them is selected in the next stages
        /// {@link WithPrimaryInternetFacingLoadBalancerBackendOrNatPool}.
        /// </p>
        /// </summary>
        /// <param name="loadBalancer">loadBalancer the primary internet facing load balancer</param>
        /// <returns>the next stage of the virtual machine scale set update allowing to choose backends or inbound</returns>
        /// <returns>nat pool from the load balancer.</returns>
        IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool WithPrimaryInternetFacingLoadBalancer (ILoadBalancer loadBalancer);

    }
    /// <summary>
    /// The stage of the virtual machine scale set update allowing to associate backend pool and/or inbound NAT pool
    /// of the internet facing load balancer selected in the previous state {@link WithPrimaryLoadBalancer}
    /// with the primary network interface of the scale set virtual machines.
    /// </summary>
    public interface IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool  :
        IWithPrimaryInternetFacingLoadBalancerNatPool
    {
        /// <summary>
        /// Associate internet facing load balancer backends with the primary network interface of the scale set virtual machines.
        /// </summary>
        /// <param name="backendNames">backendNames the backend names</param>
        /// <returns>the next stage of the virtual machine scale set update allowing to choose inbound nat pool from</returns>
        /// <returns>the load balancer.</returns>
        IWithPrimaryInternetFacingLoadBalancerNatPool WithPrimaryInternetFacingLoadBalancerBackends (params string[] backendNames);

    }
    /// <summary>
    /// The stage of the virtual machine scale set update allowing to change Sku for the virtual machines in the scale set.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies sku for the virtual machines in the scale set.
        /// </summary>
        /// <param name="skuType">skuType the sku type</param>
        /// <returns>the next stage of the virtual machine scale set update</returns>
        IWithApplicable WithSku (VirtualMachineScaleSetSkuTypes skuType);

        /// <summary>
        /// Specifies sku for the virtual machines in the scale set.
        /// </summary>
        /// <param name="sku">sku a sku from the list of available sizes for the virtual machines in this scale set</param>
        /// <returns>the next stage of the virtual machine scale set update</returns>
        IWithApplicable WithSku (IVirtualMachineScaleSetSku sku);

    }
    /// <summary>
    /// The stage of a virtual machine scale set update containing inputs for the resource to be updated
    /// (via {@link WithApplicable#apply()}).
    /// </summary>
    public interface IWithApplicable  :
        IAppliable<IVirtualMachineScaleSet>,
        IUpdateWithTags<IWithApplicable>,
        IWithSku,
        IWithCapacity,
        IWithExtension,
        IWithoutPrimaryLoadBalancer,
        IWithoutPrimaryLoadBalancerBackend,
        IWithoutPrimaryLoadBalancerNatPool
    {
    }
    /// <summary>
    /// The stage of the virtual machine scale set update allowing to associate backend pool and/or inbound NAT pool
    /// of the internal load balancer selected in the previous state {@link WithPrimaryInternalLoadBalancer}
    /// with the primary network interface of the scale set virtual machines.
    /// </summary>
    public interface IWithPrimaryInternalLoadBalancerBackendOrNatPool  :
        IWithPrimaryInternalLoadBalancerNatPool
    {
        /// <summary>
        /// Associate internal load balancer backends with the primary network interface of the scale set virtual machines.
        /// </summary>
        /// <param name="backendNames">backendNames the backend names</param>
        /// <returns>the next stage of the virtual machine scale set update allowing to choose inbound nat pool from</returns>
        /// <returns>the load balancer.</returns>
        IWithPrimaryInternalLoadBalancerNatPool WithPrimaryInternalLoadBalancerBackends (params string[] backendNames);

    }
    /// <summary>
    /// The stage of the virtual machine scale set update allowing to specify an internal load balancer for
    /// the primary network interface of the scale set virtual machines.
    /// </summary>
    public interface IWithPrimaryInternalLoadBalancer  :
        IWithApplicable
    {
        /// <summary>
        /// Specifies load balancer to tbe used as the internal load balancer for the virtual machines in the
        /// scale set.
        /// <p>
        /// This will replace the current internal load balancer associated with the virtual machines in the
        /// scale set (if any).
        /// By default all the backend and inbound NAT pool of the load balancer will be associated with the primary
        /// network interface of the scale set virtual machines unless subset of them is selected in the next stages
        /// {@link WithPrimaryInternalLoadBalancerBackendOrNatPool}.
        /// </p>
        /// </summary>
        /// <param name="loadBalancer">loadBalancer the primary internet facing load balancer</param>
        /// <returns>the next stage of the virtual machine scale set update allowing to choose backends or inbound</returns>
        /// <returns>nat pool from the load balancer.</returns>
        IWithPrimaryInternalLoadBalancerBackendOrNatPool WithPrimaryInternalLoadBalancer (ILoadBalancer loadBalancer);

    }
    /// <summary>
    /// The stage of the virtual machine scale set update allowing to associate inbound NAT pool of the internal
    /// load balancer selected in the previous state {@link WithPrimaryInternalLoadBalancer} with the primary network
    /// interface of the scale set virtual machines.
    /// </summary>
    public interface IWithPrimaryInternalLoadBalancerNatPool  :
        IWithApplicable
    {
        /// <summary>
        /// Associate internet facing load balancer inbound NAT pools with the the primary network interface of the
        /// scale set virtual machines.
        /// </summary>
        /// <param name="natPoolNames">natPoolNames the inbound NAT pool names</param>
        /// <returns>the next stage of the virtual machine scale set update</returns>
        IWithApplicable WithPrimaryInternalLoadBalancerInboundNatPools (params string[] natPoolNames);

    }
    /// <summary>
    /// Stage of the virtual machine scale set update allowing to remove public and internal load balancer
    /// from the primary network interface configuration.
    /// </summary>
    public interface IWithoutPrimaryLoadBalancer 
    {
        /// <summary>
        /// Remove the internet facing load balancer associated to the primary network interface configuration.
        /// <p>
        /// This removes the association between primary network interface configuration and all backend and
        /// inbound NAT pools in the load balancer.
        /// </p>
        /// </summary>
        /// <returns>the next stage of the virtual machine scale set update</returns>
        IWithApplicable WithoutPrimaryInternetFacingLoadBalancer ();

        /// <summary>
        /// Remove the internal load balancer associated to the primary network interface configuration.
        /// <p>
        /// This removes the association between primary network interface configuration and all backend and
        /// inbound NAT pools in the load balancer.
        /// </p>
        /// </summary>
        /// <returns>the next stage of the virtual machine scale set update</returns>
        IWithApplicable WithoutPrimaryInternalLoadBalancer ();

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
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IBlank<IWithApplicable> DefineNewExtension (string name);

        /// <summary>
        /// Begins the description of an update of an existing extension assigned to the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">name the reference name for the extension</param>
        /// <returns>the stage representing updatable extension definition</returns>
        IUpdate UpdateExtension (string name);

        /// <summary>
        /// Detaches an extension with the given name from the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">name the reference name for the extension to be removed/uninstalled</param>
        /// <returns>the stage representing updatable VM scale set definition</returns>
        IWithApplicable WithoutExtension (string name);

    }
    /// <summary>
    /// Stage of the virtual machine scale set update allowing to remove association between the primary network interface
    /// configuration and backend of the load balancer.
    /// </summary>
    public interface IWithoutPrimaryLoadBalancerBackend 
    {
        /// <summary>
        /// Removes association between the primary network interface configuration and backend of the internet facing
        /// load balancer.
        /// </summary>
        /// <param name="backendNames">backendNames the existing backend names to remove</param>
        /// <returns>the next stage of the virtual machine scale set update</returns>
        IWithApplicable WithoutPrimaryInternetFacingLoadBalancerBackends (params string[] backendNames);

        /// <summary>
        /// Removes association between the primary network interface configuration and backend of the internal load balancer.
        /// </summary>
        /// <param name="backendNames">backendNames the existing backend names to remove</param>
        /// <returns>the next stage of the virtual machine scale set update</returns>
        IWithApplicable WithoutPrimaryInternalLoadBalancerBackends (params string[] backendNames);

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
    /// <summary>
    /// Stage of the virtual machine scale set update allowing to remove association between the primary network interface
    /// configuration and inbound NAT pool of the load balancer.
    /// </summary>
    public interface IWithoutPrimaryLoadBalancerNatPool 
    {
        /// <summary>
        /// Removes association between the primary network interface configuration and inbound NAT pool of the
        /// internet facing load balancer.
        /// </summary>
        /// <param name="natPoolNames">natPoolNames the name of an existing inbound NAT pools to remove</param>
        /// <returns>the next stage of the virtual machine scale set update</returns>
        IWithApplicable WithoutPrimaryInternetFacingLoadBalancerNatPools (params string[] natPoolNames);

        /// <summary>
        /// Removes association between the primary network interface configuration and inbound NAT pool of the
        /// internal load balancer.
        /// </summary>
        /// <param name="natPoolNames">natPoolNames the name of an existing inbound NAT pools to remove</param>
        /// <returns>the next stage of the virtual machine scale set update</returns>
        IWithApplicable WithoutPrimaryInternalLoadBalancerNatPools (params string[] natPoolNames);

    }
    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify number of
    /// virtual machines in the scale set.
    /// </summary>
    public interface IWithCapacity 
    {
        /// <summary>
        /// Specifies the new number of virtual machines in the scale set.
        /// </summary>
        /// <param name="capacity">capacity the virtual machine capacity</param>
        /// <returns>the next stage of the virtual machine scale set update</returns>
        IWithApplicable WithCapacity (int capacity);

    }
}