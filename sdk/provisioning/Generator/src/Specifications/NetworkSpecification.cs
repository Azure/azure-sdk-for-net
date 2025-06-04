// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// TODO: Resolve bicep serialization issue
/*
using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.Network;

namespace Azure.Provisioning.Generator.Specifications;

public class NetworkSpecification() :
    Specification("Network", typeof(NetworkExtensions))
{
    protected override void Customize()
    {
        // Patch models
        CustomizeModel("Route", m => m.Name = "RouteResource");
        CustomizeModel("Subnet", m => m.Name = "SubnetResource");

        // Naming requirements
        AddNameRequirements<ApplicationGatewayResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<ApplicationSecurityGroupResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<AzureFirewallResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);        
        AddNameRequirements<BastionHostResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<VirtualNetworkGatewayConnectionResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<ExpressRouteCircuitResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<FirewallPolicyResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<FirewallPolicyRuleCollectionGroupDraftResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<LoadBalancerResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<InboundNatRuleResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<LocalNetworkGatewayResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<NetworkInterfaceResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<NetworkSecurityGroupResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<SecurityRuleResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<NetworkWatcherResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<PrivateEndpointResource>(min: 2, max: 64, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<PrivateLinkServiceResource>(min: 2, max: 64, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<NetworkPrivateEndpointConnectionResource>(min: 2, max: 64, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<PublicIPAddressResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<PublicIPPrefixResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<RouteFilterResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<RouteFilterRuleResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<RouteTableResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<RouteResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<ServiceEndpointPolicyResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<VirtualNetworkGatewayResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<VirtualNetworkResource>(min: 2, max: 64, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<SubnetResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<VirtualNetworkPeeringResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<VirtualWanResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<VpnGatewayResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<VpnConnectionResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<VpnSiteResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);

        // Assign Roles
        Roles.Add(new Role("ClassicNetworkContributor", "b34d265f-36f7-4a0d-a4d4-e158ca92e90f", "Lets you manage classic networks, but not access to them."));
        Roles.Add(new Role("NetworkContributor", "4d97b98b-1d4f-4787-a291-c67834d212e7", "Lets you manage networks, but not access to them."));
    }
}
*/