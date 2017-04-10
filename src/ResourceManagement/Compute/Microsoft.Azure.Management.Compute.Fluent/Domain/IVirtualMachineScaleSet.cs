// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using VirtualMachineScaleSet.Update;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Threading;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine scale set.
    /// </summary>
    public interface IVirtualMachineScaleSet  :
        IGroupableResource<IComputeManager, VirtualMachineScaleSetInner>,
        IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>,
        IUpdatable<VirtualMachineScaleSet.Update.IWithPrimaryLoadBalancer>
    {
        /// <summary>
        /// List the network interface associated with a specific virtual machine instance in the scale set.
        /// </summary>
        /// <param name="virtualMachineInstanceId">The instance id.</param>
        /// <return>The network interfaces.</return>
        IEnumerable<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface> ListNetworkInterfacesByInstanceId(string virtualMachineInstanceId);

        /// <summary>
        /// Gets true if managed disk is used for the virtual machine scale set's disks (os, data).
        /// </summary>
        bool IsManagedDiskEnabled { get; }

        /// <summary>
        /// Gets the URL to storage containers that store the VHDs of the virtual machines in the scale set.
        /// </summary>
        System.Collections.Generic.IList<string> VhdContainers { get; }

        /// <summary>
        /// Powers off (stops) the virtual machines in the scale set.
        /// </summary>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void PowerOff();

        /// <summary>
        /// Powers off (stops) the virtual machines in the scale set.
        /// </summary>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        Task PowerOffAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The network interfaces associated with all virtual machine instances in a scale set.</return>
        IEnumerable<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface> ListNetworkInterfaces();

        /// <summary>
        /// Shuts down the virtual machines in the scale set and releases its compute resources.
        /// </summary>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void Deallocate();

        /// <summary>
        /// Shuts down the virtual machines in the scale set and releases its compute resources.
        /// </summary>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        Task DeallocateAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>
        /// The virtual network associated with the primary network interfaces of the virtual machines
        /// in the scale set.
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
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> ListPrimaryInternalLoadBalancerInboundNatPools();

        /// <summary>
        /// Gets entry point to manage virtual machine instances in the scale set.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVMs VirtualMachines { get; }

        /// <summary>
        /// Gets the number of virtual machine instances in the scale set.
        /// </summary>
        long Capacity { get; }

        /// <summary>
        /// Gets true if over provision is enabled for the virtual machines, false otherwise.
        /// </summary>
        bool OverProvisionEnabled { get; }

        /// <return>
        /// The internal load balancer's backends associated with the primary network interface
        /// of the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> ListPrimaryInternalLoadBalancerBackends();

        /// <summary>
        /// Re-images (updates the version of the installed operating system) the virtual machines in the scale set.
        /// </summary>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void Reimage();

        /// <summary>
        /// Re-images (updates the version of the installed operating system) the virtual machines in the scale set.
        /// </summary>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        Task ReimageAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the name of the OS disk of virtual machines in the scale set.
        /// </summary>
        string OsDiskName { get; }

        /// <summary>
        /// Gets the operating system of the virtual machines in the scale set.
        /// </summary>
        Models.OperatingSystemTypes OsType { get; }

        /// <summary>
        /// Gets the operating system disk caching type.
        /// </summary>
        Models.CachingTypes OsDiskCachingType { get; }

        /// <summary>
        /// Gets the network profile.
        /// </summary>
        Models.VirtualMachineScaleSetNetworkProfile NetworkProfile { get; }

        /// <summary>
        /// Gets the SKU of the virtual machines in the scale set.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetSkuTypes Sku { get; }

        /// <return>
        /// The internet-facing load balancer's backends associated with the primary network interface
        /// of the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> ListPrimaryInternetFacingLoadBalancerBackends();

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
        /// Restarts the virtual machines in the scale set.
        /// </summary>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        Task RestartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Starts the virtual machines in the scale set.
        /// </summary>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void Start();

        /// <summary>
        /// Starts the virtual machines in the scale set.
        /// </summary>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        Task StartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>
        /// The internal load balancer associated with the primary network interface of
        /// the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancer GetPrimaryInternalLoadBalancer();

        /// <summary>
        /// Gets the name prefix of the virtual machines in the scale set.
        /// </summary>
        string ComputerNamePrefix { get; }

        /// <return>
        /// Available SKUs for the virtual machine scale set, including the minimum and maximum virtual machine instances
        /// allowed for a particular SKU.
        /// </return>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetSku> ListAvailableSkus();

        /// <summary>
        /// Gets the extensions attached to the virtual machines in the scale set.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension> Extensions { get; }

        /// <return>
        /// Gets the list of IDs of the public IP addresses associated with the primary Internet-facing load balancer
        /// of the scale set.
        /// </return>
        /// <summary>
        /// Gets IOException the IO exception.
        /// </summary>
        System.Collections.Generic.IList<string> PrimaryPublicIPAddressIds { get; }

        /// <summary>
        /// Gets the storage profile.
        /// </summary>
        Models.VirtualMachineScaleSetStorageProfile StorageProfile { get; }

        /// <summary>
        /// Gets a network interface associated with a virtual machine scale set instance.
        /// </summary>
        /// <param name="instanceId">The virtual machine scale set vm instance id.</param>
        /// <param name="name">The network interface name.</param>
        /// <return>The network interface.</return>
        Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface GetNetworkInterfaceByInstanceId(string instanceId, string name);

        /// <return>
        /// The internet-facing load balancer's inbound NAT pool associated with the primary network interface
        /// of the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> ListPrimaryInternetFacingLoadBalancerInboundNatPools();

        /// <summary>
        /// Gets the upgradeModel.
        /// </summary>
        Models.UpgradeMode UpgradeModel { get; }
    }
}