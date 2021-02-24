using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Core;
using System.Collections.Generic;

namespace Proto.Network
{
    /// <summary> 
    /// A class representing the subnet data model.
    /// </summary>
    public class SubnetData : ProxyResource<Azure.ResourceManager.Network.Models.Subnet>
    {
        /// <summary> 
        /// Initializes a new instance of the <see cref="SubnetData"/> class. 
        /// </summary>
        public SubnetData(Azure.ResourceManager.Network.Models.Subnet sub) : base(sub.Id, sub)
        {
        }

        /// <summary>
        /// Gets the subnet id. 
        ///</summary>
        public override string Name => Model.Name;

        /// <summary> 
        /// The provisioning state of the subnet resource. 
        /// </summary>
        public ProvisioningState? ProvisioningState => Model.ProvisioningState;

        /// <summary> 
        /// A read-only string identifying the intention use for this subnet based on delegations and other user-defined properties.
        /// </summary>
        public string Purpose => Model.Purpose;

        /// <summary> An array of references to the delegations on the subnet. </summary>
        public IList<Delegation> Delegations
        {
            get => Model.Delegations;
            set => Model.Delegations = value;
        }

        /// <summary> An array of references to services injecting into this subnet. </summary>
        public IList<ServiceAssociationLink> ServiceAssociationLinks => Model.ServiceAssociationLinks;

        /// <summary> An array of references to the external resources using subnet. </summary>
        public IList<ResourceNavigationLink> ResourceNavigationLinks => Model.ResourceNavigationLinks;

        /// <summary> Array of IpAllocation which reference this subnet. </summary>
        public IList<SubResource> IpAllocations
        {
            get => Model.IpAllocations;
            set => Model.IpAllocations = value;
        }

        /// <summary> Array of IP configuration profiles which reference this subnet. </summary>
        public IList<IPConfigurationProfile> IpConfigurationProfiles => Model.IpConfigurationProfiles;

        /// <summary> An array of references to the network interface IP configurations using subnet. </summary>
        public IList<IPConfiguration> IpConfigurations => Model.IpConfigurations;

        /// <summary> Enable or Disable apply network policies on private end point in the subnet. </summary>
        public string PrivateEndpointNetworkPolicies
        {
            get => Model.PrivateEndpointNetworkPolicies;
            set => Model.PrivateEndpointNetworkPolicies = value;
        }

        /// <summary> An array of references to private endpoints. </summary>
        public IList<PrivateEndpoint> PrivateEndpoints => Model.PrivateEndpoints;

        /// <summary> An array of service endpoints. </summary>
        public IList<ServiceEndpointPropertiesFormat> ServiceEndpoints
        {
            get => Model.ServiceEndpoints;
            set => Model.ServiceEndpoints = value;
        }
        
        /// <summary> Nat gateway associated with this subnet. </summary>
        public SubResource NatGateway
        {
            get => Model.NatGateway;
            set => Model.NatGateway = value;
        }

        /// <summary> The reference to the RouteTable resource. </summary>
        public RouteTable RouteTable
        {
            get => Model.RouteTable;
            set => Model.RouteTable = value;
        }

        /// <summary> The reference to the NetworkSecurityGroup resource. </summary>
        public Azure.ResourceManager.Network.Models.NetworkSecurityGroup NetworkSecurityGroup
        {
            get => Model.NetworkSecurityGroup;
            set => Model.NetworkSecurityGroup = value;
        }

        /// <summary> List of address prefixes for the subnet. </summary>
        public IList<string> AddressPrefixes
        {
            get => Model.AddressPrefixes;
            set => Model.AddressPrefixes = value;
        }

        /// <summary> The address prefix for the subnet. </summary>
        public string AddressPrefix
        {
            get => Model.AddressPrefix;
            set => Model.AddressPrefix = value;
        }

        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag => Model.Etag;

        /// <summary> An array of service endpoint policies. </summary>
        public IList<ServiceEndpointPolicy> ServiceEndpointPolicies
        {
            get => Model.ServiceEndpointPolicies;
            set => Model.ServiceEndpointPolicies = value;
        }

        /// <summary> Enable or Disable apply network policies on private link service in the subnet. </summary>
        public string PrivateLinkServiceNetworkPolicies
        {
            get => Model.PrivateLinkServiceNetworkPolicies;
            set => Model.PrivateLinkServiceNetworkPolicies = value;
        }
    }
}
