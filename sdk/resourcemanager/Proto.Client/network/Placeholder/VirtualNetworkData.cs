using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Core;
using System;
using System.Collections.Generic;

namespace Proto.Network
{
    /// <summary>
    /// A class representing the virtual nerwork data model.
    /// </summary>
    public class VirtualNetworkData : TrackedResource<ResourceGroupResourceIdentifier, Azure.ResourceManager.Network.Models.VirtualNetwork>
    {
        /// <summary>
        /// Gets the resource type definition for a virtual nerwork.
        /// </summary>
        public static ResourceType ResourceType => "Microsoft.Network/virtualNetworks";

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualNetworkData"/> class.
        /// </summary>
        /// <param name="vnet"> The virtual nerwork to initialize. </param>
        public VirtualNetworkData(Azure.ResourceManager.Network.Models.VirtualNetwork vnet) : base(vnet.Id, vnet.Location, vnet)
        {
        }

        /// <inheritdoc/>
        public override IDictionary<string, string> Tags => Model.Tags;

        /// <inheritdoc/>
        public override string Name => Model.Name;

        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag => Model.Etag;

        /// <summary> The AddressSpace that contains an array of IP address ranges that can be used by subnets. </summary>
        public AddressSpace AddressSpace
        {
            get => Model.AddressSpace;
            set => Model.AddressSpace = value;
        }

        /// <summary> The dhcpOptions that contains an array of DNS servers available to VMs deployed in the virtual network. </summary>
        public DhcpOptions DhcpOptions
        {
            get => Model.DhcpOptions;
            set => Model.DhcpOptions = value;
        }

        /// <summary> A list of subnet in a Virtual Network. </summary>
        public IList<Azure.ResourceManager.Network.Models.Subnet> Subnets
        {
            get => Model.Subnets;
        }

        /// <summary> A list of peering in a Virtual Network. </summary>
        public IList<VirtualNetworkPeering> VirtualNetworkPeerings
        {
            get => Model.VirtualNetworkPeerings;
        }

        /// <summary> The resourceGuid property of the Virtual Network resource. </summary>
        public string ResourceGuid => Model.ResourceGuid;

        /// <summary> The provisioning state of the virtual network resource. </summary>
        public ProvisioningState? ProvisioningState => Model.ProvisioningState;

        /// <summary> Indicates if DDoS protection is enabled for all the protected resources in the virtual network. It requires a DDoS protection plan associated with the resource. </summary>
        public bool? EnableDdosProtection
        {
            get => Model.EnableDdosProtection;
            set => Model.EnableDdosProtection = value;
        }

        /// <summary> Indicates if VM protection is enabled for all the subnets in the virtual network. </summary>
        public bool? EnableVmProtection
        {
            get => Model.EnableVmProtection;
            set => Model.EnableVmProtection = value;
        }

        /// <summary> The DDoS protection plan associated with the virtual network. </summary>
        public SubResource DdosProtectionPlan

        {
            get => Model.DdosProtectionPlan;
            set => Model.DdosProtectionPlan = value;
        }

        /// <summary> Bgp Communities sent over ExpressRoute with each route corresponding to a prefix in this VNET. </summary>
        public VirtualNetworkBgpCommunities BgpCommunities
        {
            get => Model.BgpCommunities;
            set => Model.BgpCommunities = value;
        }

        /// <summary> Array of IpAllocation which reference this VNET. </summary>
        public IList<SubResource> IpAllocations
        {
            get => Model.IpAllocations;
        }
    }
}
