// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class ApplicationGatewayWafDynamicManifestResource
    {
        /// <summary> Generate the resource identifier for this resource. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, AzureLocation location)
            => CreateResourceIdentifier(subscriptionId, location.ToString());
    }

    public partial class CloudServiceSwapResource
    {
        /// <summary> Generate the resource identifier for this resource. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudServiceName)
            => CreateResourceIdentifier(subscriptionId, resourceGroupName, cloudServiceName, "default");
    }

    public partial class CustomIPPrefixData
    {
        /// <summary> The Parent CustomIpPrefix for IPv6 /64 CustomIpPrefix. </summary>
        [WirePath("properties.customIpPrefixParent")]
        public ResourceIdentifier ParentCustomIPPrefixId
        {
            get => CustomIpPrefixParent;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ExpressRouteCircuitPeeringData
    {
        /// <summary> The ExpressRoute connection. </summary>
        [WirePath("properties.expressRouteConnection")]
        public ResourceIdentifier ExpressRouteConnectionId => ExpressRouteConnection;
    }

    public partial class ExpressRouteConnectionData
    {
        /// <summary> The ExpressRoute circuit peering. </summary>
        [WirePath("properties.expressRouteCircuitPeering")]
        public ResourceIdentifier ExpressRouteCircuitPeeringId
        {
            get => ExpressRouteCircuitPeering;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ExpressRouteCrossConnectionData
    {
        /// <summary> The ExpressRouteCircuit. </summary>
        [WirePath("properties.expressRouteCircuit")]
        public ResourceIdentifier ExpressRouteCircuitId
        {
            get => ExpressRouteCircuit;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ExpressRouteGatewayData
    {
        /// <summary> The Virtual Hub where the ExpressRoute gateway is or will be deployed. </summary>
        [WirePath("properties.virtualHub")]
        public ResourceIdentifier VirtualHubId
        {
            get => VirtualHub;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class PublicIPPrefixData
    {
        /// <summary> Reference to the frontend ip address configuration defined in regional loadbalancer. </summary>
        [WirePath("properties.loadBalancerFrontendIPConfiguration")]
        public ResourceIdentifier LoadBalancerFrontendIPConfigurationId
        {
            get => LoadBalancerFrontendIpConfigurationId;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}

namespace Azure.ResourceManager.Network.Models
{
    public partial class ApplicationGatewayRequestRoutingRule
    {
        /// <summary> Entra JWT validation configuration resource of the application gateway. </summary>
        [WirePath("properties.entraJWTValidationConfig")]
        public ResourceIdentifier EntraJwtValidationConfigId
        {
            get => EntraJWTValidationConfig;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class DisassociateCloudServicePublicIPContent
    {
        /// <summary> ARM ID of the Standalone Public IP to associate. </summary>
        [WirePath("publicIpArmId")]
        public ResourceIdentifier PublicIPArmId => PublicIpArmId;
    }

    public abstract partial class EffectiveBaseSecurityAdminRule
    {
        /// <summary> Resource ID. </summary>
        [WirePath("id")]
        public ResourceIdentifier ResourceId => Id;
    }

    public partial class LoadBalancerBackendAddress
    {
        /// <summary> Reference to the frontend ip address configuration defined in regional loadbalancer. </summary>
        [WirePath("properties.loadBalancerFrontendIPConfiguration")]
        public ResourceIdentifier LoadBalancerFrontendIPConfigurationId
        {
            get => LoadBalancerFrontendIPConfiguration;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class LoadBalancerHealthPerRulePerBackendAddress
    {
        /// <summary> Resource ID of the Network Interface IP Configuration. </summary>
        [WirePath("networkInterfaceIPConfigurationId")]
        public ResourceIdentifier NetworkInterfaceIPConfigurationResourceId => NetworkInterfaceIPConfigurationId?.Id;
    }

    public partial class PublicIPDdosProtectionStatusResult
    {
        /// <summary> Public IP ARM resource ID. </summary>
        [WirePath("publicIpAddressId")]
        public ResourceIdentifier PublicIPAddressId => PublicIpAddressId;
    }

    public partial class QueryInboundNatRulePortMappingContent
    {
        /// <summary> NetworkInterfaceIPConfiguration set in load balancer backend address. </summary>
        [WirePath("ipConfiguration")]
        public ResourceIdentifier IPConfigurationId
        {
            get => IpConfiguration;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
