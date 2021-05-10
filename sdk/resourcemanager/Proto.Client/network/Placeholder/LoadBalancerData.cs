using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Core;
using System.Collections.Generic;

namespace Proto.Network
{
    /// <summary>
    /// A class representing the LoadBalancer data model.
    /// </summary>
    public class LoadBalancerData : Resource<ResourceGroupResourceIdentifier>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoadBalancerData"/> class.
        /// </summary>
        public LoadBalancerData(Azure.ResourceManager.Network.Models.LoadBalancer loadBalancer) 
            : base(loadBalancer.Id, loadBalancer.Name, LoadBalancerOperations.ResourceType)
        {
            Model = loadBalancer;
        }

        /// <summary>
        /// Gets or sets the Model this resource is based of. 
        ///</summary>
        public virtual Azure.ResourceManager.Network.Models.LoadBalancer Model { get; }

        /// <summary>
        /// Gets the LoadBalancer id. 
        ///</summary>
        public override string Name => Model.Name;

        /// <summary>
        /// The provisioning state of the LoadBalancer resource.
        /// </summary>
        public ProvisioningState? ProvisioningState => Model.ProvisioningState;

        /// <summary> The load balancer SKU. </summary>
        public LoadBalancerSku Sku
        {
            get => Model.Sku;
            set => Model.Sku = value;
        }

        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag => Model.Etag;

        /// <summary> Object representing the frontend IPs to be used for the load balancer. </summary>
        public IList<FrontendIPConfiguration> FrontendIPConfigurations => Model.FrontendIPConfigurations;

        /// <summary> Collection of backend address pools used by a load balancer. </summary>
        public IList<BackendAddressPool> BackendAddressPools => Model.BackendAddressPools;

        /// <summary> Object collection representing the load balancing rules Gets the provisioning. </summary>
        public IList<LoadBalancingRule> LoadBalancingRules => Model.LoadBalancingRules;

        /// <summary> Collection of probe objects used in the load balancer. </summary>
        public IList<Probe> Probes => Model.Probes;

        /// <summary> Collection of inbound NAT Rules used by a load balancer. Defining inbound NAT rules on your load balancer is mutually exclusive with defining an inbound NAT pool. Inbound NAT pools are referenced from virtual machine scale sets. NICs that are associated with individual virtual machines cannot reference an Inbound NAT pool. They have to reference individual inbound NAT rules. </summary>
        public IList<InboundNatRule> InboundNatRules => Model.InboundNatRules;

        /// <summary> Defines an external port range for inbound NAT to a single backend port on NICs associated with a load balancer. Inbound NAT rules are created automatically for each NIC associated with the Load Balancer using an external port from this range. Defining an Inbound NAT pool on your Load Balancer is mutually exclusive with defining inbound Nat rules. Inbound NAT pools are referenced from virtual machine scale sets. NICs that are associated with individual virtual machines cannot reference an inbound NAT pool. They have to reference individual inbound NAT rules. </summary>
        public IList<InboundNatPool> InboundNatPools => Model.InboundNatPools;

        /// <summary> The outbound rules. </summary>
        public IList<OutboundRule> OutboundRules => Model.OutboundRules;

        /// <summary> The resource GUID property of the load balancer resource. </summary>
        public string ResourceGuid => Model.ResourceGuid;
    }
}
