// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Models;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using VirtualMachineScaleSet.Update;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine scale set.
    /// </summary>
    public interface IVirtualMachineScaleSet :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>,
        IWrapper<Models.VirtualMachineScaleSetInner>,
        IUpdatable<VirtualMachineScaleSet.Update.IWithPrimaryLoadBalancer>
    {
        /// <return>The URL to storage containers that store the VHDs of the virtual machines in the scale set.</return>
        System.Collections.Generic.IList<string> VhdContainers { get; }

        /// <summary>
        /// Powers off (stops) the virtual machines in the scale set.
        /// </summary>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void PowerOff();

        /// <summary>
        /// Shuts down the virtual machines in the scale set and releases its compute resources.
        /// </summary>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void Deallocate();

        /// <return>
        /// The virtual network associated with the primary network interfaces of the virtual machines
        /// in the scale set.
        /// <p>
        /// A primary internal load balancer associated with the primary network interfaces of the scale set
        /// virtual machine will be also belong to this network
        /// </p>.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        Microsoft.Azure.Management.Network.Fluent.INetwork GetPrimaryNetwork();

        /// <return>
        /// The inbound NAT pools of the internal load balancer associated with the primary network interface
        /// of the virtual machines in the scale set, if any.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> ListPrimaryInternalLoadBalancerInboundNatPools();

        /// <return>Entry point to manage virtual machine instances in the scale set.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVMs VirtualMachines { get; }

        /// <return>The number of virtual machine instances in the scale set.</return>
        int Capacity { get; }

        /// <return>True if over provision is enabled for the virtual machines, false otherwise.</return>
        bool OverProvisionEnabled { get; }

        /// <return>
        /// The internal load balancer's backends associated with the primary network interface
        /// of the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> ListPrimaryInternalLoadBalancerBackends();

        /// <summary>
        /// Re-images (updates the version of the installed operating system) the virtual machines in the scale set.
        /// </summary>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void Reimage();

        /// <return>The name of the OS disk of virtual machines in the scale set.</return>
        string OsDiskName { get; }

        /// <return>The operating system of the virtual machines in the scale set.</return>
        Models.OperatingSystemTypes OsType { get; }

        /// <return>The operating system disk caching type.</return>
        Models.CachingTypes OsDiskCachingType { get; }

        /// <return>The network profile.</return>
        Models.VirtualMachineScaleSetNetworkProfile NetworkProfile { get; }

        /// <return>The SKU of the virtual machines in the scale set.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetSkuTypes Sku { get; }

        /// <return>
        /// The internet-facing load balancer's backends associated with the primary network interface
        /// of the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> ListPrimaryInternetFacingLoadBalancerBackends();

        /// <return>
        /// The internet-facing load balancer associated with the primary network interface of
        /// the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancer GetPrimaryInternetFacingLoadBalancer();

        /// <summary>
        /// Restarts the virtual machines in the scale set.
        /// </summary>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void Restart();

        /// <summary>
        /// Starts the virtual machines in the scale set.
        /// </summary>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void Start();

        /// <return>
        /// The internal load balancer associated with the primary network interface of
        /// the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancer GetPrimaryInternalLoadBalancer();

        /// <return>The name prefix of the virtual machines in the scale set.</return>
        string ComputerNamePrefix { get; }

        /// <return>
        /// Available SKUs for the virtual machine scale set, including the minimum and maximum virtual machine instances
        /// allowed for a particular SKU.
        /// </return>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetSku> ListAvailableSkus();

        /// <return>The extensions attached to the virtual machines in the scale set.</return>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension> Extensions { get; }

        /// <return>
        /// The list of IDs of the public IP addresses associated with the primary Internet-facing load balancer
        /// of the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        System.Collections.Generic.IList<string> PrimaryPublicIpAddressIds { get; }

        /// <return>The storage profile.</return>
        Models.VirtualMachineScaleSetStorageProfile StorageProfile { get; }

        /// <return>
        /// The internet-facing load balancer's inbound NAT pool associated with the primary network interface
        /// of the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> ListPrimaryInternetFacingLoadBalancerInboundNatPools();

        /// <return>The upgradeModel.</return>
        Models.UpgradeMode UpgradeModel { get; }
    }
}