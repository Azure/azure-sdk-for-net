// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Models
{
    /// <summary> Describes the frontend configurations for the node type. </summary>
    public partial class NodeTypeFrontendConfiguration
    {
        /// <summary> Initializes a new instance of NodeTypeFrontendConfiguration. </summary>
        public NodeTypeFrontendConfiguration()
        {
        }

        /// <summary> Initializes a new instance of NodeTypeFrontendConfiguration. </summary>
        /// <param name="ipAddressType"> The IP address type of this frontend configuration. If omitted the default value is IPv4. </param>
        /// <param name="loadBalancerBackendAddressPoolId"> The resource Id of the Load Balancer backend address pool that the VM instances of the node type are associated with. The format of the resource Id is '/subscriptions/&lt;subscriptionId&gt;/resourceGroups/&lt;resourceGroupName&gt;/providers/Microsoft.Network/loadBalancers/&lt;loadBalancerName&gt;/backendAddressPools/&lt;backendAddressPoolName&gt;'. </param>
        /// <param name="loadBalancerInboundNatPoolId"> The resource Id of the Load Balancer inbound NAT pool that the VM instances of the node type are associated with. The format of the resource Id is '/subscriptions/&lt;subscriptionId&gt;/resourceGroups/&lt;resourceGroupName&gt;/providers/Microsoft.Network/loadBalancers/&lt;loadBalancerName&gt;/inboundNatPools/&lt;inboundNatPoolName&gt;'. </param>
        internal NodeTypeFrontendConfiguration(NodeTypeFrontendConfigurationIPAddressType? ipAddressType, ResourceIdentifier loadBalancerBackendAddressPoolId, ResourceIdentifier loadBalancerInboundNatPoolId)
        {
            IPAddressType = ipAddressType;
            LoadBalancerBackendAddressPoolId = loadBalancerBackendAddressPoolId;
            LoadBalancerInboundNatPoolId = loadBalancerInboundNatPoolId;
        }

        /// <summary> The IP address type of this frontend configuration. If omitted the default value is IPv4. </summary>
        public NodeTypeFrontendConfigurationIPAddressType? IPAddressType { get; set; }
        /// <summary> The resource Id of the Load Balancer backend address pool that the VM instances of the node type are associated with. The format of the resource Id is '/subscriptions/&lt;subscriptionId&gt;/resourceGroups/&lt;resourceGroupName&gt;/providers/Microsoft.Network/loadBalancers/&lt;loadBalancerName&gt;/backendAddressPools/&lt;backendAddressPoolName&gt;'. </summary>
        public ResourceIdentifier LoadBalancerBackendAddressPoolId { get; set; }
        /// <summary> The resource Id of the Load Balancer inbound NAT pool that the VM instances of the node type are associated with. The format of the resource Id is '/subscriptions/&lt;subscriptionId&gt;/resourceGroups/&lt;resourceGroupName&gt;/providers/Microsoft.Network/loadBalancers/&lt;loadBalancerName&gt;/inboundNatPools/&lt;inboundNatPoolName&gt;'. </summary>
        public ResourceIdentifier LoadBalancerInboundNatPoolId { get; set; }
    }
}
