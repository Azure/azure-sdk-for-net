// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Net;
using Azure.Core;
using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable CS1591 // Missing XML comment for publicly visible compatibility members
#pragma warning disable SA1402 // Keep backward-compatible Network members together.

namespace Azure.Provisioning.Network
{
    public partial class ConnectionMonitor
    {
        private BicepValue<ConnectionMonitorType> _compatibilityConnectionMonitorType;
        private SystemData _compatibilitySystemData;

        [CodeGenMember("ConnectionMonitorType")]
        public BicepValue<ConnectionMonitorType> ConnectionMonitorType
        {
            get { Initialize(); return _compatibilityConnectionMonitorType; }
            set { Initialize(); _compatibilityConnectionMonitorType.Assign(value); }
        }

        public SystemData SystemData
        {
            get { Initialize(); return _compatibilitySystemData; }
        }

        partial void DefineAdditionalProperties()
        {
            _compatibilityConnectionMonitorType = DefineProperty<ConnectionMonitorType>(
                nameof(ConnectionMonitorType),
                new string[] { "properties", "connectionMonitorType" });
            _compatibilitySystemData = DefineModelProperty<SystemData>(
                nameof(SystemData),
                new string[] { "systemData" },
                isOutput: true);
        }
    }

    public partial class DdosProtectionPlan
    {
        private SystemData _compatibilitySystemData;

        public SystemData SystemData
        {
            get { Initialize(); return _compatibilitySystemData; }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilitySystemData = DefineModelProperty<SystemData>(
                nameof(SystemData),
                new string[] { "systemData" },
                isOutput: true);
    }

    public partial class PacketCapture
    {
        private SystemData _compatibilitySystemData;

        public SystemData SystemData
        {
            get { Initialize(); return _compatibilitySystemData; }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilitySystemData = DefineModelProperty<SystemData>(
                nameof(SystemData),
                new string[] { "systemData" },
                isOutput: true);
    }

    public partial class RouteMap
    {
        private SystemData _compatibilitySystemData;

        public SystemData SystemData
        {
            get { Initialize(); return _compatibilitySystemData; }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilitySystemData = DefineModelProperty<SystemData>(
                nameof(SystemData),
                new string[] { "systemData" },
                isOutput: true);
    }

    public partial class ConnectionMonitorEndpoint
    {
        private BicepValue<ConnectionMonitorEndpointType> _compatibilityEndpointType;

        public BicepValue<ConnectionMonitorEndpointType> EndpointType
        {
            get { Initialize(); return _compatibilityEndpointType; }
            set { Initialize(); _compatibilityEndpointType.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityEndpointType = DefineProperty<ConnectionMonitorEndpointType>(
                nameof(EndpointType),
                new string[] { "type" });
    }

    public partial class ConnectionMonitorEndpointFilter
    {
        public BicepValue<ConnectionMonitorEndpointFilterType> FilterType
        {
            get { return Type; }
            set { Type = value; }
        }
    }

    public partial class ConnectionMonitorEndpointFilterItem
    {
        public BicepValue<ConnectionMonitorEndpointFilterItemType> ItemType
        {
            get { return Type; }
            set { Type = value; }
        }
    }

    public partial class ConnectionMonitorOutput
    {
        public BicepValue<OutputType> OutputType
        {
            get { return Type; }
            set { Type = value; }
        }
    }

    public partial class DdosSettings
    {
        private BicepValue<DdosSettingsProtectionMode> _compatibilityProtectionMode;

        [CodeGenMember("ProtectionMode")]
        public BicepValue<DdosSettingsProtectionMode> ProtectionMode
        {
            get { Initialize(); return _compatibilityProtectionMode; }
            set { Initialize(); _compatibilityProtectionMode.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityProtectionMode = DefineProperty<DdosSettingsProtectionMode>(
                nameof(ProtectionMode),
                new string[] { "protectionMode" });
    }

    public partial class TrafficDetectionRule
    {
        private BicepValue<DdosTrafficType> _compatibilityTrafficType;

        [CodeGenMember("TrafficType")]
        public BicepValue<DdosTrafficType> TrafficType
        {
            get { Initialize(); return _compatibilityTrafficType; }
            set { Initialize(); _compatibilityTrafficType.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityTrafficType = DefineProperty<DdosTrafficType>(
                nameof(TrafficType),
                new string[] { "trafficType" });
    }

    public partial class FlowLogProperties
    {
        public BicepValue<FlowLogFormatType> FormatType
        {
            get { return Type; }
            set { Type = value; }
        }
    }

    public partial class GatewayLoadBalancerTunnelInterface
    {
        public BicepValue<GatewayLoadBalancerTunnelInterfaceType> InterfaceType
        {
            get { return Type; }
            set { Type = value; }
        }
    }

    public partial class RoutingRuleRouteDestination
    {
        public BicepValue<RoutingRuleDestinationType> DestinationType
        {
            get { return Type; }
            set { Type = value; }
        }
    }

    public partial class VirtualNetwork
    {
        public BicepValue<PrivateEndpointVnetPolicy> PrivateEndpointVnetPolicy
        {
            get { return PrivateEndpointVNetPolicies; }
            set { PrivateEndpointVNetPolicies = value; }
        }
    }

    public partial class VirtualApplianceIPConfiguration
    {
        public BicepValue<bool> IsPrimary
        {
            get { return VirtualApplianceIPPrimary; }
            set { VirtualApplianceIPPrimary = value; }
        }
    }

    public partial class VirtualHub
    {
        public BicepList<VirtualHubRoute> Routes
        {
            get { return RouteTableRoutes; }
            set { RouteTableRoutes = value; }
        }
    }

    public partial class ExpressRouteCircuitPeering
    {
        private BicepList<PeerExpressRouteCircuitConnectionData> _compatibilityPeeredConnections;

        [CodeGenMember("PeeredConnections")]
        public BicepList<PeerExpressRouteCircuitConnectionData> PeeredConnections
        {
            get { Initialize(); return _compatibilityPeeredConnections; }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityPeeredConnections = DefineListProperty<PeerExpressRouteCircuitConnectionData>(
                nameof(PeeredConnections),
                new string[] { "properties", "peeredConnections" },
                isOutput: true);
    }

    public partial class ExpressRoutePort
    {
        private BicepList<ExpressRouteLinkData> _compatibilityLinks;

        [CodeGenMember("Links")]
        public BicepList<ExpressRouteLinkData> Links
        {
            get { Initialize(); return _compatibilityLinks; }
            set { Initialize(); _compatibilityLinks.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityLinks = DefineListProperty<ExpressRouteLinkData>(
                nameof(Links),
                new string[] { "properties", "links" });
    }

    public partial class ExpressRouteConnection
    {
        private RoutingConfiguration _compatibilityRoutingConfiguration;

        [CodeGenMember("RoutingConfiguration")]
        public RoutingConfiguration RoutingConfiguration
        {
            get { Initialize(); return _compatibilityRoutingConfiguration; }
            set { Initialize(); AssignOrReplace(ref _compatibilityRoutingConfiguration, value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityRoutingConfiguration = DefineModelProperty<RoutingConfiguration>(
                nameof(RoutingConfiguration),
                new string[] { "properties", "routingConfiguration" });
    }

    public partial class HubVirtualNetworkConnection
    {
        private RoutingConfiguration _compatibilityRoutingConfiguration;

        [CodeGenMember("RoutingConfiguration")]
        public RoutingConfiguration RoutingConfiguration
        {
            get { Initialize(); return _compatibilityRoutingConfiguration; }
            set { Initialize(); AssignOrReplace(ref _compatibilityRoutingConfiguration, value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityRoutingConfiguration = DefineModelProperty<RoutingConfiguration>(
                nameof(RoutingConfiguration),
                new string[] { "properties", "routingConfiguration" });
    }

    public partial class NetworkVirtualApplianceConnection
    {
        private RoutingConfiguration _compatibilityConnectionRoutingConfiguration;

        [CodeGenMember("RoutingConfiguration")]
        public RoutingConfiguration ConnectionRoutingConfiguration
        {
            get { Initialize(); return _compatibilityConnectionRoutingConfiguration; }
            set { Initialize(); AssignOrReplace(ref _compatibilityConnectionRoutingConfiguration, value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityConnectionRoutingConfiguration = DefineModelProperty<RoutingConfiguration>(
                nameof(ConnectionRoutingConfiguration),
                new string[] { "properties", "routingConfiguration" });
    }

    public partial class P2SConnectionConfiguration
    {
        private RoutingConfiguration _compatibilityRoutingConfiguration;

        [CodeGenMember("RoutingConfiguration")]
        public RoutingConfiguration RoutingConfiguration
        {
            get { Initialize(); return _compatibilityRoutingConfiguration; }
            set { Initialize(); AssignOrReplace(ref _compatibilityRoutingConfiguration, value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityRoutingConfiguration = DefineModelProperty<RoutingConfiguration>(
                nameof(RoutingConfiguration),
                new string[] { "properties", "routingConfiguration" });
    }

    public partial class VpnConnection
    {
        private RoutingConfiguration _compatibilityRoutingConfiguration;
        private BicepList<VpnSiteLinkConnectionData> _compatibilityVpnLinkConnections;

        [CodeGenMember("RoutingConfiguration")]
        public RoutingConfiguration RoutingConfiguration
        {
            get { Initialize(); return _compatibilityRoutingConfiguration; }
            set { Initialize(); AssignOrReplace(ref _compatibilityRoutingConfiguration, value); }
        }

        [CodeGenMember("VpnLinkConnections")]
        public BicepList<VpnSiteLinkConnectionData> VpnLinkConnections
        {
            get { Initialize(); return _compatibilityVpnLinkConnections; }
            set { Initialize(); _compatibilityVpnLinkConnections.Assign(value); }
        }

        partial void DefineAdditionalProperties()
        {
            _compatibilityRoutingConfiguration = DefineModelProperty<RoutingConfiguration>(
                nameof(RoutingConfiguration),
                new string[] { "properties", "routingConfiguration" });
            _compatibilityVpnLinkConnections = DefineListProperty<VpnSiteLinkConnectionData>(
                nameof(VpnLinkConnections),
                new string[] { "properties", "vpnLinkConnections" });
        }
    }

    public partial class VpnSite
    {
        private BicepList<VpnSiteLinkData> _compatibilityVpnSiteLinks;

        [CodeGenMember("VpnSiteLinks")]
        public BicepList<VpnSiteLinkData> VpnSiteLinks
        {
            get { Initialize(); return _compatibilityVpnSiteLinks; }
            set { Initialize(); _compatibilityVpnSiteLinks.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityVpnSiteLinks = DefineListProperty<VpnSiteLinkData>(
                nameof(VpnSiteLinks),
                new string[] { "properties", "vpnSiteLinks" });
    }

    public partial class NetworkVirtualAppliance
    {
        private BicepValue<IPAddress> _compatibilityPrivateIPAddress;

        [CodeGenMember("PrivateIPAddress")]
        public BicepValue<IPAddress> PrivateIPAddress
        {
            get { Initialize(); return _compatibilityPrivateIPAddress; }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityPrivateIPAddress = DefineProperty<IPAddress>(
                nameof(PrivateIPAddress),
                new string[] { "properties", "privateIpAddress" },
                isOutput: true);
    }

    public partial class LoadBalancingRule
    {
        private LoadBalancingRuleProperties _compatibilityProperties;

        [CodeGenMember("Properties")]
        public LoadBalancingRuleProperties Properties
        {
            get { Initialize(); return _compatibilityProperties; }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityProperties = DefineModelProperty<LoadBalancingRuleProperties>(
                nameof(Properties),
                new string[] { "properties" });
    }

    public partial class LoadBalancerInboundNatPool
    {
        private LoadBalancerInboundNatPoolProperties _compatibilityProperties;

        [CodeGenMember("Properties")]
        public LoadBalancerInboundNatPoolProperties Properties
        {
            get { Initialize(); return _compatibilityProperties; }
            set { Initialize(); AssignOrReplace(ref _compatibilityProperties, value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityProperties = DefineModelProperty<LoadBalancerInboundNatPoolProperties>(
                nameof(Properties),
                new string[] { "properties" });
    }

    public partial class LoadBalancingRuleProperties
    {
        private BicepDictionary<BinaryData> _compatibilityAdditionalProperties;

        public BicepDictionary<BinaryData> AdditionalProperties
        {
            get { Initialize(); return _compatibilityAdditionalProperties; }
            set { Initialize(); _compatibilityAdditionalProperties.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityAdditionalProperties = DefineDictionaryProperty<BinaryData>(
                nameof(AdditionalProperties),
                new string[] { });
    }

    public partial class LoadBalancerInboundNatPoolProperties
    {
        private BicepDictionary<BinaryData> _compatibilityAdditionalProperties;

        public BicepDictionary<BinaryData> AdditionalProperties
        {
            get { Initialize(); return _compatibilityAdditionalProperties; }
            set { Initialize(); _compatibilityAdditionalProperties.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityAdditionalProperties = DefineDictionaryProperty<BinaryData>(
                nameof(AdditionalProperties),
                new string[] { });
    }

    public partial class NetworkIPConfiguration
    {
        private BicepValue<string> _compatibilityPrivateIPAddress;
        private BicepValue<NetworkIPAllocationMethod> _compatibilityPrivateIPAllocationMethod;
        private SubnetResource _compatibilitySubnet;
        private PublicIPAddress _compatibilityPublicIPAddress;

        [CodeGenMember("PrivateIPAddress")]
        public BicepValue<string> PrivateIPAddress
        {
            get { Initialize(); return _compatibilityPrivateIPAddress; }
            set { Initialize(); _compatibilityPrivateIPAddress.Assign(value); }
        }

        [CodeGenMember("PrivateIPAllocationMethod")]
        public BicepValue<NetworkIPAllocationMethod> PrivateIPAllocationMethod
        {
            get { Initialize(); return _compatibilityPrivateIPAllocationMethod; }
            set { Initialize(); _compatibilityPrivateIPAllocationMethod.Assign(value); }
        }

        [CodeGenMember("Subnet")]
        public SubnetResource Subnet
        {
            get { Initialize(); return _compatibilitySubnet; }
            set { Initialize(); AssignOrReplace(ref _compatibilitySubnet, value); }
        }

        [CodeGenMember("PublicIPAddress")]
        public PublicIPAddress PublicIPAddress
        {
            get { Initialize(); return _compatibilityPublicIPAddress; }
            set { Initialize(); AssignOrReplace(ref _compatibilityPublicIPAddress, value); }
        }

        partial void DefineAdditionalProperties()
        {
            _compatibilityPrivateIPAddress = DefineProperty<string>(
                nameof(PrivateIPAddress),
                new string[] { "properties", "privateIPAddress" });
            _compatibilityPrivateIPAllocationMethod = DefineProperty<NetworkIPAllocationMethod>(
                nameof(PrivateIPAllocationMethod),
                new string[] { "properties", "privateIPAllocationMethod" });
            _compatibilitySubnet = DefineModelProperty(
                nameof(Subnet),
                new string[] { "properties", "subnet" },
                new SubnetResource("subnet"));
            _compatibilityPublicIPAddress = DefineModelProperty(
                nameof(PublicIPAddress),
                new string[] { "properties", "publicIPAddress" },
                new PublicIPAddress("publicIPAddress"));
        }
    }

    public partial class IPAllocation
    {
        [CodeGenMember("SubnetId")]
        private BicepValue<ResourceIdentifier> CompatibilitySubnetId { get; }

        [CodeGenMember("VirtualNetworkId")]
        private BicepValue<ResourceIdentifier> CompatibilityVirtualNetworkId { get; }
    }

    public partial class RouteResource
    {
        private BicepValue<bool> _compatibilityHasBgpOverride;

        [CodeGenMember("HasBgpOverride")]
        public BicepValue<bool> HasBgpOverride
        {
            get { Initialize(); return _compatibilityHasBgpOverride; }
            set { Initialize(); _compatibilityHasBgpOverride.Assign(value); }
        }
    }
}
