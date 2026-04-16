// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
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

        // Remove phantom properties that do not exist in the Bicep reference
        RemoveProperty<IPAllocationResource>("SubnetId");
        RemoveProperty<IPAllocationResource>("VirtualNetworkId");

        // Fix properties that are not settable in Bicep reference (readonly)
        CustomizeProperty<IpamPoolProperties>("ProvisioningState", p => p.IsReadOnly = true);
        CustomizeProperty<StaticCidrProperties>("ProvisioningState", p => p.IsReadOnly = true);
        CustomizeProperty<NetworkVerifierWorkspaceProperties>("ProvisioningState", p => p.IsReadOnly = true);
        CustomizeProperty<ReachabilityAnalysisIntentProperties>("ProvisioningState", p => p.IsReadOnly = true);
        CustomizeProperty<ReachabilityAnalysisRunProperties>("ProvisioningState", p => p.IsReadOnly = true);

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

        // Fix Name readonly for child resources with workaround methods.
        // These resources lack standard createOrUpdate so the generator cannot
        // detect the name parameter and marks Name as output-only.
        CustomizeProperty<FirewallPolicyDraftResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<FrontendIPConfigurationResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<LoadBalancingRuleResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<NetworkInterfaceIPConfigurationResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<OutboundRuleResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ProbeResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });

        // Fix other readonly/writable issues
        CustomizeProperty<PolicySignaturesOverridesForIdpsResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<PolicySignaturesOverridesForIdpsResource>("Signatures", p => p.IsReadOnly = false);

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
