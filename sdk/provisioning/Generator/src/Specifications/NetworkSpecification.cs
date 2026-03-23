// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using System;
using System.Collections.Generic;
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

        // BaseAdminRule polymorphic types (discriminator: "kind")
        CustomizeResource<NetworkAdminRule>(r =>
        {
            r.BaseType = GetModel<BaseAdminRuleResource>() as TypeModel;
            r.DiscriminatorName = "kind";
            r.DiscriminatorValue = "Custom";
        });
        CustomizeResource<NetworkDefaultAdminRule>(r =>
        {
            r.BaseType = GetModel<BaseAdminRuleResource>() as TypeModel;
            r.DiscriminatorName = "kind";
            r.DiscriminatorValue = "Default";
        });
        RemoveProperties<NetworkAdminRule>("Id", "Name", "SystemData", "ETag");
        RemoveProperties<NetworkDefaultAdminRule>("Id", "Name", "SystemData", "ETag");

        // FirewallPolicyRuleCollectionInfo subtypes (discriminator: "ruleCollectionType")
        CustomizeSimpleModel<FirewallPolicyFilterRuleCollectionInfo>(m => { m.DiscriminatorName = "ruleCollectionType"; m.DiscriminatorValue = "FirewallPolicyFilterRuleCollection"; });
        CustomizeSimpleModel<FirewallPolicyNatRuleCollectionInfo>(m => { m.DiscriminatorName = "ruleCollectionType"; m.DiscriminatorValue = "FirewallPolicyNatRuleCollection"; });

        // FirewallPolicyRule subtypes (discriminator: "ruleType")
        CustomizeSimpleModel<ApplicationRule>(m => { m.DiscriminatorName = "ruleType"; m.DiscriminatorValue = "ApplicationRule"; });
        CustomizeSimpleModel<NatRule>(m => { m.DiscriminatorName = "ruleType"; m.DiscriminatorValue = "NatRule"; });
        CustomizeSimpleModel<NetworkRule>(m => { m.DiscriminatorName = "ruleType"; m.DiscriminatorValue = "NetworkRule"; });

        // Fix readonly properties
        CustomizeProperty<NetworkManagerResource>("Id", p => p.IsReadOnly = true);
        CustomizeProperty<PolicySignaturesOverridesForIdpsResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<PolicySignaturesOverridesForIdpsResource>("Signatures", p => p.IsReadOnly = false);

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

        // Resources without a createOrUpdate method need workaround entries.
        resources.Add(typeof(NetworkInterfaceIPConfigurationResource), typeof(NetworkSpecification).GetMethod(nameof(CreateOrUpdateNetworkInterfaceIPConfiguration), BindingFlags.NonPublic | BindingFlags.Static)!);
        resources.Add(typeof(FrontendIPConfigurationResource), typeof(NetworkSpecification).GetMethod(nameof(CreateOrUpdateFrontendIPConfiguration), BindingFlags.NonPublic | BindingFlags.Static)!);
        resources.Add(typeof(ProbeResource), typeof(NetworkSpecification).GetMethod(nameof(CreateOrUpdateProbeResource), BindingFlags.NonPublic | BindingFlags.Static)!);
        resources.Add(typeof(LoadBalancingRuleResource), typeof(NetworkSpecification).GetMethod(nameof(CreateOrUpdateLoadBalancingRuleResource), BindingFlags.NonPublic | BindingFlags.Static)!);
        resources.Add(typeof(OutboundRuleResource), typeof(NetworkSpecification).GetMethod(nameof(CreateOrUpdateOutboundRuleResource), BindingFlags.NonPublic | BindingFlags.Static)!);

        // Polymorphic resource types (BaseAdminRule discriminated subtypes)
        resources.Add(typeof(NetworkAdminRule), typeof(NetworkSpecification).GetMethod(nameof(CreateOrUpdateNetworkAdminRule), BindingFlags.NonPublic | BindingFlags.Static)!);
        resources.Add(typeof(NetworkDefaultAdminRule), typeof(NetworkSpecification).GetMethod(nameof(CreateOrUpdateNetworkDefaultAdminRule), BindingFlags.NonPublic | BindingFlags.Static)!);

        return resources;
    }

    // Workaround methods for resources without a createOrUpdate method.
    private static ArmOperation<NetworkInterfaceIPConfigurationResource> CreateOrUpdateNetworkInterfaceIPConfiguration() { return null!; }
    private static ArmOperation<FrontendIPConfigurationResource> CreateOrUpdateFrontendIPConfiguration() { return null!; }
    private static ArmOperation<ProbeResource> CreateOrUpdateProbeResource() { return null!; }
    private static ArmOperation<LoadBalancingRuleResource> CreateOrUpdateLoadBalancingRuleResource() { return null!; }
    private static ArmOperation<OutboundRuleResource> CreateOrUpdateOutboundRuleResource() { return null!; }

    // Workaround methods for polymorphic resource subtypes.
    private static ArmOperation<BaseAdminRuleResource> CreateOrUpdateNetworkAdminRule(NetworkAdminRule content) { return null!; }
    private static ArmOperation<BaseAdminRuleResource> CreateOrUpdateNetworkDefaultAdminRule(NetworkDefaultAdminRule content) { return null!; }
}
