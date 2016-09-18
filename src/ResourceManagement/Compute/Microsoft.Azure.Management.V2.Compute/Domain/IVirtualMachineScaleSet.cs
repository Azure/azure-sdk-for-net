/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Network;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update;
    using Management.Compute.Models;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine scale set.
    /// </summary>
    public interface IVirtualMachineScaleSet  :
        IGroupableResource,
        IRefreshable<IVirtualMachineScaleSet>,
        IWrapper<VirtualMachineScaleSetInner>,
        IUpdatable<IWithPrimaryLoadBalancer>
    {
        /// <returns> available skus for the virtual machine scale set including the minimum and maximum vm instances</returns>
        /// <returns>allowed for a particular sku.</returns>
        PagedList<IVirtualMachineScaleSetSku> AvailableSkus ();

        /// <summary>
        /// Shuts down the Virtual Machine in the scale set and releases the compute resources.
        /// <p>
        /// You are not billed for the compute resources that the Virtual Machines uses
        /// </summary>
        void Deallocate ();

        /// <summary>
        /// Power off (stop) the virtual machines in the scale set.
        /// <p>
        /// You will be billed for the compute resources that the Virtual Machines uses.
        /// </summary>
        void PowerOff ();

        /// <summary>
        /// Restart the virtual machines in the scale set.
        /// </summary>
        void Restart ();

        /// <summary>
        /// Start the virtual machines  in the scale set.
        /// </summary>
        void Start ();

        /// <summary>
        /// Re-image (update the version of the installed operating system) the virtual machines in the scale set.
        /// </summary>
        void Reimage ();

        /// <returns>the name prefix of the virtual machines in the scale set.</returns>
        string ComputerNamePrefix { get; }

        /// <returns>the operating system of the virtual machines in the scale set.</returns>
        OperatingSystemTypes? OsType { get; }

        /// <returns>the operating system disk caching type, valid values are 'None', 'ReadOnly', 'ReadWrite'</returns>
        CachingTypes? OsDiskCachingType { get; }

        /// <returns>gets the name of the OS disk of virtual machines in the scale set.</returns>
        string OsDiskName { get; }

        /// <returns>the upgradeModel</returns>
        UpgradeMode? UpgradeModel { get; }

        /// <returns>true if over provision is enabled for the virtual machines, false otherwise.</returns>
        bool? OverProvisionEnabled { get; }

        /// <returns>the sku of the virtual machines in the scale set.</returns>
        VirtualMachineScaleSetSkuTypes Sku ();

        /// <returns>the number of virtual machine instances in the scale set.</returns>
        int? Capacity { get; }

        /// <returns>the virtual network associated with the primary network interfaces of the virtual machines</returns>
        /// <returns>in the scale set.</returns>
        /// <returns><p></returns>
        /// <returns>A primary internal load balancer associated with the primary network interfaces of the scale set</returns>
        /// <returns>virtual machine will be also belongs to this network.</returns>
        /// <returns></p></returns>
        INetwork PrimaryNetwork ();

        /// <returns>the internet facing load balancer associated with the primary network interface of</returns>
        /// <returns>the virtual machines in the scale set.</returns>
        ILoadBalancer PrimaryInternetFacingLoadBalancer ();

        /// <returns>the internet facing load balancer's backends associated with the primary network interface</returns>
        /// <returns>of the virtual machines in the scale set.</returns>
        IDictionary<string,IBackend> PrimaryInternetFacingLoadBalancerBackEnds { get; }

        /// <returns>the internet facing load balancer's inbound NAT pool associated with the primary network interface</returns>
        /// <returns>of the virtual machines in the scale set.</returns>
        IDictionary<string,IInboundNatPool> PrimaryInternetFacingLoadBalancerInboundNatPools { get; }

        /// <returns>the internal load balancer associated with the primary network interface of</returns>
        /// <returns>the virtual machines in the scale set.</returns>
        ILoadBalancer PrimaryInternalLoadBalancer ();

        /// <returns>the internal load balancer's backends associated with the primary network interface</returns>
        /// <returns>of the virtual machines in the scale set.</returns>
        IDictionary<string,IBackend> PrimaryInternalLoadBalancerBackEnds { get; }

        /// <returns>the internal load balancer's inbound NAT pool associated with the primary network interface</returns>
        /// <returns>of the virtual machines in the scale set.</returns>
        IDictionary<string,IInboundNatPool> PrimaryInternalLoadBalancerInboundNatPools { get; }

        /// <returns>the list of ids of public Ip addresses associated with the primary internet facing load balancer</returns>
        /// <returns>of the scale set.</returns>
        IList<string> PrimaryPublicIpAddressIds { get; }

        /// <returns>the url to storage containers that stores vhds of virtual machines in the scale set.</returns>
        IList<string> VhdContainers { get; }

        /// <returns>the storage profile.</returns>
        VirtualMachineScaleSetStorageProfile StorageProfile { get; }

        /// <returns>the network profile</returns>
        VirtualMachineScaleSetNetworkProfile NetworkProfile { get; }

        /// <returns>the extensions attached to the Virtual Machines in the scale set.</returns>
        IDictionary<string,IVirtualMachineScaleSetExtension> Extensions ();

    }
}