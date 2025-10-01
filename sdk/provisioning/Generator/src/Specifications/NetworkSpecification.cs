// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager;
using Azure.ResourceManager.Network;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Azure.Provisioning.Generator.Specifications;

public class NetworkSpecification() :
    Specification("Network", typeof(NetworkExtensions), ignorePropertiesWithoutPath: true)
{
    protected override void Customize()
    {
        // Patch models
        CustomizeResource<RouteResource>(r => r.Name = "RouteResource");
        CustomizeResource<SubnetResource>(r => r.Name = "SubnetResource");
        CustomizeResource<ProbeResource>(r => r.Name = "ProbeResource");
        RemoveProperty<VirtualNetworkPeeringResource>("SyncRemoteAddressSpace");

        // Naming requirements
        //AddNameRequirements<ApplicationGatewayResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<ApplicationSecurityGroupResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        //AddNameRequirements<AzureFirewallResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        //AddNameRequirements<BastionHostResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        //AddNameRequirements<VirtualNetworkGatewayConnectionResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        //AddNameRequirements<ExpressRouteCircuitResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<FirewallPolicyResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        //AddNameRequirements<FirewallPolicyRuleCollectionGroupDraftResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<LoadBalancerResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<InboundNatRuleResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        //AddNameRequirements<LocalNetworkGatewayResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<NetworkInterfaceResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<NetworkSecurityGroupResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<SecurityRuleResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<NetworkWatcherResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<PrivateEndpointResource>(min: 2, max: 64, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<PrivateLinkServiceResource>(min: 2, max: 64, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<NetworkPrivateEndpointConnectionResource>(min: 2, max: 64, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<PublicIPAddressResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<PublicIPPrefixResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        //AddNameRequirements<RouteFilterResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        //AddNameRequirements<RouteFilterRuleResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<RouteTableResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<RouteResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<ServiceEndpointPolicyResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        //AddNameRequirements<VirtualNetworkGatewayResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<VirtualNetworkResource>(min: 2, max: 64, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<SubnetResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<VirtualNetworkPeeringResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        //AddNameRequirements<VirtualWanResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        //AddNameRequirements<VpnGatewayResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        //AddNameRequirements<VpnConnectionResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        //AddNameRequirements<VpnSiteResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);

        //// Assign Roles
        //Roles.Add(new Role("ClassicNetworkContributor", "b34d265f-36f7-4a0d-a4d4-e158ca92e90f", "Lets you manage classic networks, but not access to them."));
        //Roles.Add(new Role("NetworkContributor", "4d97b98b-1d4f-4787-a291-c67834d212e7", "Lets you manage networks, but not access to them."));
    }

    // NRP is such a large RP, we are using this hash set to only generate those critical resources for now.
    // More resources could be added later
    private readonly HashSet<Type> _generatedResources = new()
    {
        typeof(VirtualNetworkResource),
        typeof(BackendAddressPoolResource),
        typeof(ApplicationSecurityGroupResource),
        typeof(NetworkInterfaceIPConfigurationResource), // NetworkInterfaceIPConfigurationResource will not be generated because it does not have a createOrUpdate method.
        typeof(NetworkInterfaceTapConfigurationResource),
        typeof(NetworkWatcherCollection),
        typeof(NetworkWatcherResource),
        typeof(FlowLogResource),
        typeof(SubnetResource),
        typeof(FrontendIPConfigurationResource),
        typeof(InboundNatRuleResource),
        typeof(NatGatewayResource),
        typeof(NetworkInterfaceResource),
        typeof(PublicIPAddressResource),
        typeof(PublicIPPrefixResource),
        typeof(NetworkSecurityGroupResource),
        typeof(RouteResource),
        typeof(RouteTableResource),
        typeof(PrivateLinkServiceResource),
        typeof(NetworkPrivateEndpointConnectionResource),
        typeof(VirtualNetworkTapResource),
        typeof(VirtualNetworkPeeringResource),
        typeof(ServiceEndpointPolicyResource),
        typeof(ServiceEndpointPolicyDefinitionResource),
        typeof(SecurityRuleResource),
        typeof(PrivateEndpointResource),
        typeof(FirewallPolicyResource),
        typeof(LoadBalancerResource),
        typeof(LoadBalancingRuleResource),
        typeof(ProbeResource),
        typeof(OutboundRuleResource),
    };

    private protected override Dictionary<Type, MethodInfo> FindConstructibleResources()
    {
        var allResources = base.FindConstructibleResources();

        var resources = new Dictionary<Type, MethodInfo>();
        foreach (var (type, creator) in allResources)
        {
            if (_generatedResources.Contains(type))
            {
                resources.Add(type, creator);
            }
        }

        // NetworkInterfaceIPConfigurationResource does not have a creator method, we need to add it here manually.
        resources.Add(typeof(NetworkInterfaceIPConfigurationResource), typeof(NetworkSpecification).GetMethod(nameof(CreateOrUpdateNetworkInterfaceIPConfiguration), BindingFlags.NonPublic | BindingFlags.Static)!);
        resources.Add(typeof(FrontendIPConfigurationResource), typeof(NetworkSpecification).GetMethod(nameof(CreateOrUpdateFrontendIPConfiguration), BindingFlags.NonPublic | BindingFlags.Static)!);
        resources.Add(typeof(ProbeResource), typeof(NetworkSpecification).GetMethod(nameof(CreateOrUpdateProbeResource), BindingFlags.NonPublic | BindingFlags.Static)!);
        resources.Add(typeof(LoadBalancingRuleResource), typeof(NetworkSpecification).GetMethod(nameof(CreateOrUpdateLoadBalancingRuleResource), BindingFlags.NonPublic | BindingFlags.Static)!);
        resources.Add(typeof(OutboundRuleResource), typeof(NetworkSpecification).GetMethod(nameof(CreateOrUpdateOutboundRuleResource), BindingFlags.NonPublic | BindingFlags.Static)!);

        return resources;
    }

    // These methods are here as a workaround to generate those resources without a createOrUpdate method.
    private static ArmOperation<NetworkInterfaceIPConfigurationResource> CreateOrUpdateNetworkInterfaceIPConfiguration() { return null!; }
    private static ArmOperation<FrontendIPConfigurationResource> CreateOrUpdateFrontendIPConfiguration() { return null!; }
    private static ArmOperation<ProbeResource> CreateOrUpdateProbeResource() { return null!; }
    private static ArmOperation<LoadBalancingRuleResource> CreateOrUpdateLoadBalancingRuleResource() { return null!; }
    private static ArmOperation<OutboundRuleResource> CreateOrUpdateOutboundRuleResource() { return null!; }
}
