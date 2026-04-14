// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager;
using Azure.ResourceManager.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Azure.Provisioning.Generator.Specifications;

public class NetworkSpecification() :
    Specification("Network", typeof(NetworkExtensions), ignorePropertiesWithoutPath: true, serviceDirectory: "network")
{
    protected override void Customize()
    {
        // Patch models
        CustomizeResource<RouteResource>(r => r.Name = "RouteResource");
        CustomizeResource<SubnetResource>(r => r.Name = "SubnetResource");
        CustomizeResource<ProbeResource>(r => r.Name = "ProbeResource");
        RemoveProperty<VirtualNetworkPeeringResource>("SyncRemoteAddressSpace");

        // Fix Id to be readonly on all resources — NRP ARM SDK base types
        // (NetworkTrackedResourceData, SubResource, etc.) define Id with a public
        // setter, making it writable in the provisioning schema. Id is server-computed.
        foreach (var resource in ModelNameMapping.Values.OfType<Resource>())
        {
            Property? idProp = resource.Properties.FirstOrDefault(p => p.Name == "Id");
            if (idProp != null && !idProp.IsReadOnly)
            {
                idProp.IsReadOnly = true;
            }
        }

        // Backward compatibility: restore writable Id on resources that were
        // already released with a public Id setter (removing it would be a
        // breaking change). New resources get readonly Id from the loop above.
        CustomizeProperty<ApplicationSecurityGroupResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<BackendAddressPoolResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<FirewallPolicyResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<FlowLogResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<InboundNatRuleResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<LoadBalancerResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<NatGatewayResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<NetworkInterfaceResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<NetworkInterfaceTapConfigurationResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<NetworkPrivateEndpointConnectionResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<NetworkSecurityGroupResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<NetworkWatcherResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<PrivateDnsZoneGroupResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<PrivateEndpointResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<PrivateLinkServiceResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<PublicIPAddressResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<PublicIPPrefixResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<RouteResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<RouteTableResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<SecurityRuleResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<ServiceEndpointPolicyResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<ServiceEndpointPolicyDefinitionResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<SubnetResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<VirtualNetworkResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<VirtualNetworkPeeringResource>("Id", p => p.IsReadOnly = false);
        CustomizeProperty<VirtualNetworkTapResource>("Id", p => p.IsReadOnly = false);

        // Fix Name readonly for child resources with workaround methods.
        CustomizeProperty<FrontendIPConfigurationResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<LoadBalancingRuleResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<NetworkInterfaceIPConfigurationResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<OutboundRuleResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ProbeResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });

        // Naming requirements
        AddNameRequirements<ApplicationSecurityGroupResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<FirewallPolicyResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<LoadBalancerResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<InboundNatRuleResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<NetworkInterfaceResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<NetworkSecurityGroupResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<SecurityRuleResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<NetworkWatcherResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<PrivateEndpointResource>(min: 2, max: 64, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<PrivateLinkServiceResource>(min: 2, max: 64, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<NetworkPrivateEndpointConnectionResource>(min: 2, max: 64, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<PublicIPAddressResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<PublicIPPrefixResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<RouteTableResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<RouteResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<ServiceEndpointPolicyResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<VirtualNetworkResource>(min: 2, max: 64, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<SubnetResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<VirtualNetworkPeeringResource>(min: 1, max: 80, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
    }

    private protected override Dictionary<Type, MethodInfo> FindConstructibleResources()
    {
        var resources = base.FindConstructibleResources();

        // For the 1.1.0 stable release, only include the resources that were
        // in 1.1.0-beta.1 (the original 1.0.0 resources + NSP resources).
        // The remaining 83 resources added in beta.2 will be re-added in a
        // future beta release.
        HashSet<Type> stableResources =
        [
            typeof(ApplicationSecurityGroupResource),
            typeof(BackendAddressPoolResource),
            typeof(FirewallPolicyResource),
            typeof(FlowLogResource),
            typeof(FrontendIPConfigurationResource),
            typeof(InboundNatRuleResource),
            typeof(LoadBalancerResource),
            typeof(LoadBalancingRuleResource),
            typeof(NatGatewayResource),
            typeof(NetworkInterfaceResource),
            typeof(NetworkInterfaceIPConfigurationResource),
            typeof(NetworkInterfaceTapConfigurationResource),
            typeof(NetworkPrivateEndpointConnectionResource),
            typeof(NetworkSecurityGroupResource),
            typeof(NetworkSecurityPerimeterResource),
            typeof(NetworkSecurityPerimeterAccessRuleResource),
            typeof(NetworkSecurityPerimeterAssociationResource),
            typeof(NetworkSecurityPerimeterLinkResource),
            typeof(NetworkSecurityPerimeterLoggingConfigurationResource),
            typeof(NetworkSecurityPerimeterProfileResource),
            typeof(NetworkWatcherResource),
            typeof(OutboundRuleResource),
            typeof(PrivateDnsZoneGroupResource),
            typeof(PrivateEndpointResource),
            typeof(PrivateLinkServiceResource),
            typeof(ProbeResource),
            typeof(PublicIPAddressResource),
            typeof(PublicIPPrefixResource),
            typeof(RouteResource),
            typeof(RouteTableResource),
            typeof(SecurityRuleResource),
            typeof(ServiceEndpointPolicyResource),
            typeof(ServiceEndpointPolicyDefinitionResource),
            typeof(SubnetResource),
            typeof(VirtualNetworkResource),
            typeof(VirtualNetworkPeeringResource),
            typeof(VirtualNetworkTapResource),
        ];

        // Filter to only stable resources
        foreach (var key in resources.Keys.ToList())
        {
            if (!stableResources.Contains(key))
            {
                resources.Remove(key);
            }
        }

        // Resources without a createOrUpdate method need workaround entries.
        resources.Add(typeof(NetworkInterfaceIPConfigurationResource), typeof(NetworkSpecification).GetMethod(nameof(CreateOrUpdateNetworkInterfaceIPConfiguration), BindingFlags.NonPublic | BindingFlags.Static)!);
        resources.Add(typeof(FrontendIPConfigurationResource), typeof(NetworkSpecification).GetMethod(nameof(CreateOrUpdateFrontendIPConfiguration), BindingFlags.NonPublic | BindingFlags.Static)!);
        resources.Add(typeof(ProbeResource), typeof(NetworkSpecification).GetMethod(nameof(CreateOrUpdateProbeResource), BindingFlags.NonPublic | BindingFlags.Static)!);
        resources.Add(typeof(LoadBalancingRuleResource), typeof(NetworkSpecification).GetMethod(nameof(CreateOrUpdateLoadBalancingRuleResource), BindingFlags.NonPublic | BindingFlags.Static)!);
        resources.Add(typeof(OutboundRuleResource), typeof(NetworkSpecification).GetMethod(nameof(CreateOrUpdateOutboundRuleResource), BindingFlags.NonPublic | BindingFlags.Static)!);

        return resources;
    }

    // Workaround methods for resources without a createOrUpdate method.
    private static ArmOperation<NetworkInterfaceIPConfigurationResource> CreateOrUpdateNetworkInterfaceIPConfiguration() { return null!; }
    private static ArmOperation<FrontendIPConfigurationResource> CreateOrUpdateFrontendIPConfiguration() { return null!; }
    private static ArmOperation<ProbeResource> CreateOrUpdateProbeResource() { return null!; }
    private static ArmOperation<LoadBalancingRuleResource> CreateOrUpdateLoadBalancingRuleResource() { return null!; }
    private static ArmOperation<OutboundRuleResource> CreateOrUpdateOutboundRuleResource() { return null!; }
}
