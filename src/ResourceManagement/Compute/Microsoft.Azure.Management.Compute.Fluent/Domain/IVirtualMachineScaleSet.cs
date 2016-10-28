// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{

    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine scale set.
    /// </summary>
    public interface IVirtualMachineScaleSet  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>,
        IWrapper<Microsoft.Azure.Management.Compute.Fluent.Models.VirtualMachineScaleSetInner>,
        IUpdatable<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryLoadBalancer>
    {
        /// <returns> available SKUs for the virtual machine scale set, including the minimum and maximum virtual machine instances</returns>
        /// <returns>allowed for a particular SKU</returns>
        Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetSku> ListAvailableSkus();

        /// <summary>
        /// Shuts down the virtual machines in the scale set and releases its compute resources.
        /// </summary>
        void Deallocate();

        /// <summary>
        /// Powers off (stops) the virtual machines in the scale set.
        /// </summary>
        void PowerOff();

        /// <summary>
        /// Restarts the virtual machines in the scale set.
        /// </summary>
        void Restart();

        /// <summary>
        /// Starts the virtual machines in the scale set.
        /// </summary>
        void Start();

        /// <summary>
        /// Re-images (updates the version of the installed operating system) the virtual machines in the scale set.
        /// </summary>
        void Reimage();

        /// <returns>the name prefix of the virtual machines in the scale set</returns>
        string ComputerNamePrefix { get; }

        /// <returns>the operating system of the virtual machines in the scale set</returns>
        Microsoft.Azure.Management.Compute.Fluent.Models.OperatingSystemTypes OsType { get; }

        /// <returns>the operating system disk caching type</returns>
        Microsoft.Azure.Management.Compute.Fluent.Models.CachingTypes OsDiskCachingType { get; }

        /// <returns>the name of the OS disk of virtual machines in the scale set</returns>
        string OsDiskName { get; }

        /// <returns>the upgradeModel</returns>
        Microsoft.Azure.Management.Compute.Fluent.Models.UpgradeMode UpgradeModel { get; }

        /// <returns>true if over provision is enabled for the virtual machines, false otherwise</returns>
        bool OverProvisionEnabled { get; }

        /// <returns>the SKU of the virtual machines in the scale set</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetSkuTypes Sku { get; }

        /// <returns>the number of virtual machine instances in the scale set</returns>
        int Capacity { get; }

        /// <returns>the virtual network associated with the primary network interfaces of the virtual machines</returns>
        /// <returns>in the scale set.</returns>
        /// <returns><p></returns>
        /// <returns>A primary internal load balancer associated with the primary network interfaces of the scale set</returns>
        /// <returns>virtual machine will be also belong to this network</returns>
        /// <returns></p></returns>
        Microsoft.Azure.Management.Network.Fluent.INetwork GetPrimaryNetwork();

        /// <returns>the internet-facing load balancer associated with the primary network interface of</returns>
        /// <returns>the virtual machines in the scale set.</returns>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancer GetPrimaryInternetFacingLoadBalancer();

        /// <returns>the internet-facing load balancer's backends associated with the primary network interface</returns>
        /// <returns>of the virtual machines in the scale set</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> ListPrimaryInternetFacingLoadBalancerBackends();

        /// <returns>the internet-facing load balancer's inbound NAT pool associated with the primary network interface</returns>
        /// <returns>of the virtual machines in the scale set</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> ListPrimaryInternetFacingLoadBalancerInboundNatPools();

        /// <returns>the internal load balancer associated with the primary network interface of</returns>
        /// <returns>the virtual machines in the scale set</returns>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancer GetPrimaryInternalLoadBalancer();

        /// <returns>the internal load balancer's backends associated with the primary network interface</returns>
        /// <returns>of the virtual machines in the scale set</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> ListPrimaryInternalLoadBalancerBackends();

        /// <returns>the inbound NAT pools of the internal load balancer associated with the primary network interface</returns>
        /// <returns>of the virtual machines in the scale set, if any.</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> ListPrimaryInternalLoadBalancerInboundNatPools();

        /// <returns>the list of IDs of the public IP addresses associated with the primary Internet-facing load balancer</returns>
        /// <returns>of the scale set</returns>
        System.Collections.Generic.IList<string> PrimaryPublicIpAddressIds { get; }

        /// <returns>the URL to storage containers that store the VHDs of the virtual machines in the scale set</returns>
        System.Collections.Generic.IList<string> VhdContainers { get; }

        /// <returns>the storage profile</returns>
        Microsoft.Azure.Management.Compute.Fluent.Models.VirtualMachineScaleSetStorageProfile StorageProfile { get; }

        /// <returns>the network profile</returns>
        Microsoft.Azure.Management.Compute.Fluent.Models.VirtualMachineScaleSetNetworkProfile NetworkProfile { get; }

        /// <returns>the extensions attached to the virtual machines in the scale set</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension> Extensions { get; }

    }
}