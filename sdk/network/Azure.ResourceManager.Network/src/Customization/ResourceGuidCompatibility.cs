// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS1591

using System;
using System.Globalization;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    internal static class ResourceGuidCompatibility
    {
        public static Guid? Parse(object value)
        {
            return Guid.TryParse(Convert.ToString(value, CultureInfo.InvariantCulture), out Guid guid) ? guid : default;
        }
    }

    [CodeGenSuppress("ResourceGuid")]
    public partial class AdminRuleGroupData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class ApplicationGatewayData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class ApplicationSecurityGroupData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class ConnectivityConfigurationData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class CustomIPPrefixData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class DdosCustomPolicyData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class DdosProtectionPlanData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class DscpConfigurationData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class ExpressRoutePortData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("TargetResourceGuid")]
    public partial class FlowLogData { [WirePath("properties.targetResourceGuid")] public Guid? TargetResourceGuid => ResourceGuidCompatibility.Parse(Properties?.TargetResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class LoadBalancerData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class LocalNetworkGatewayData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class NatGatewayData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class NetworkGroupData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class NetworkInterfaceData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class NetworkManagerData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class NetworkManagerRoutingConfigurationData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class NetworkManagerRoutingRuleData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class NetworkManagerRoutingRulesData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class NetworkManagerSecurityUserConfigurationData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class NetworkManagerSecurityUserRuleData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class NetworkManagerSecurityUserRulesData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class NetworkProfileData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class NetworkSecurityGroupData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class PublicIPAddressData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class PublicIPPrefixData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class RouteTableData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class SecurityAdminConfigurationData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class ServiceEndpointPolicyData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class ServiceGatewayData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class VirtualNetworkApplianceData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class VirtualNetworkData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class VirtualNetworkGatewayConnectionData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class VirtualNetworkGatewayData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class VirtualNetworkPeeringData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class VirtualNetworkTapData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
}

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSuppress("ResourceGuid")]
    public partial class ActiveDefaultSecurityAdminRule { [Azure.ResourceManager.Network.WirePath("properties.resourceGuid")] public Guid? ResourceGuid => Azure.ResourceManager.Network.ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class ActiveSecurityAdminRule { [Azure.ResourceManager.Network.WirePath("properties.resourceGuid")] public Guid? ResourceGuid => Azure.ResourceManager.Network.ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class EffectiveConnectivityConfiguration { [Azure.ResourceManager.Network.WirePath("properties.resourceGuid")] public Guid? ResourceGuid => Azure.ResourceManager.Network.ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class EffectiveDefaultSecurityAdminRule { [Azure.ResourceManager.Network.WirePath("properties.resourceGuid")] public Guid? ResourceGuid => Azure.ResourceManager.Network.ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class EffectiveSecurityAdminRule { [Azure.ResourceManager.Network.WirePath("properties.resourceGuid")] public Guid? ResourceGuid => Azure.ResourceManager.Network.ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class NetworkAdminRule { [Azure.ResourceManager.Network.WirePath("properties.resourceGuid")] public Guid? ResourceGuid => Azure.ResourceManager.Network.ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class NetworkConfigurationGroup { [Azure.ResourceManager.Network.WirePath("properties.resourceGuid")] public Guid? ResourceGuid => Azure.ResourceManager.Network.ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class NetworkDefaultAdminRule { [Azure.ResourceManager.Network.WirePath("properties.resourceGuid")] public Guid? ResourceGuid => Azure.ResourceManager.Network.ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
    [CodeGenSuppress("ResourceGuid")]
    public partial class VirtualNetworkGatewayConnectionListEntity { [Azure.ResourceManager.Network.WirePath("properties.resourceGuid")] public Guid? ResourceGuid => Azure.ResourceManager.Network.ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
}

#pragma warning restore CS1591
