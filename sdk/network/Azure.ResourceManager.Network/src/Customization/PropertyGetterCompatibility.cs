// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public partial class AdminRuleGroupData
    {
        public global::System.Nullable<global::Azure.ETag> ETag => default;
    }

    public partial class ApplicationGatewayData
    {
        public global::System.Collections.Generic.IList<global::System.String> AvailabilityZones => default;
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.ApplicationGatewayEntraJwtValidationConfig> EntraJwtValidationConfigs => default;
    }

    public partial class ApplicationGatewayPrivateEndpointConnectionData
    {
        public global::Azure.ResourceManager.Network.Models.NetworkPrivateLinkServiceConnectionState ConnectionState
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ApplicationGatewayWafDynamicManifestData
    {
    }

    public partial class ApplicationSecurityGroupData
    {
    }

    public partial class AzureFirewallData
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.AzureFirewallIPConfiguration> IPConfigurations => default;
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.Models.AzureFirewallIPGroups> IPGroups => default;
        public global::Azure.ResourceManager.Network.Models.AzureFirewallIPConfiguration ManagementIPConfiguration
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class AzureWebCategoryData
    {
        public global::System.Nullable<global::Azure.ETag> ETag => default;
    }

    public partial class BackendAddressPoolData
    {
    }

    public partial class BaseAdminRuleData
    {
        public global::System.Nullable<global::Azure.ETag> ETag => default;
    }

    public partial class BastionHostData
    {
        public global::System.Nullable<global::System.Boolean> EnableIPConnect
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.BastionHostIPConfiguration> IPConfigurations => default;
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.BastionHostIPRule> NetworkAclsIPRules => default;
    }

    public partial class BgpConnectionData
    {
        public global::System.String PeerIP
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class CloudServiceSwapData
    {
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.SwapSlotType> CloudServiceSwapSlotType
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ConnectionMonitorData
    {
        public global::System.Nullable<global::Azure.ETag> ETag => default;
        public global::System.Nullable<global::Azure.Core.AzureLocation> Location => default;
    }

    public partial class ConnectivityConfigurationData
    {
        public global::System.Nullable<global::Azure.ETag> ETag => default;
    }

    public partial class CustomIPPrefixData
    {
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> ChildCustomIPPrefixList => default;
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.CustomIPPrefixData> ChildCustomIPPrefixes => default;
        public global::Azure.ResourceManager.Network.CustomIPPrefixData CustomIPPrefixParent
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> PublicIPPrefixes => default;
    }

    public partial class DdosCustomPolicyData
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> FrontEndIPConfiguration => default;
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.ProtocolCustomSettings> ProtocolCustomSettings => default;
    }

    public partial class DdosProtectionPlanData
    {
    }

    public partial class DscpConfigurationData
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.QosIPRange> DestinationIPRanges => default;
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.QosIPRange> SourceIPRanges => default;
    }

    public partial class ExpressRouteCircuitAuthorizationData
    {
    }

    public partial class ExpressRouteCircuitConnectionData
    {
        public global::Azure.ResourceManager.Network.Models.IPv6CircuitConnectionConfig IPv6CircuitConnectionConfig
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ExpressRouteCircuitData
    {
        public global::System.String GatewayManagerETag
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Nullable<global::System.Int32> STag => default;
    }

    public partial class ExpressRouteCircuitPeeringData
    {
        public global::System.String GatewayManagerETag
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::Azure.ResourceManager.Network.Models.IPv6ExpressRouteCircuitPeeringConfig IPv6PeeringConfig
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ExpressRouteConnectionData
    {
    }

    public partial class ExpressRouteCrossConnectionPeeringData
    {
        public global::System.String GatewayManagerETag
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::Azure.ResourceManager.Network.Models.IPv6ExpressRouteCircuitPeeringConfig IPv6PeeringConfig
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ExpressRouteGatewayData
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.ExpressRouteConnectionData> ExpressRouteConnectionList => default;
    }

    public partial class ExpressRoutePortAuthorizationData
    {
    }

    public partial class ExpressRoutePortData
    {
    }

    public partial class ExpressRouteCircuitPeeringData
    {
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource RouteFilter
        {
            get => RouteFilterId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = RouteFilterId };
            set => RouteFilterId = value?.Id;
        }
    }

    public partial class FirewallPolicyData
    {
        public global::System.Collections.Generic.IList<global::System.String> SnatPrivateRanges => default;
    }

    public partial class FlowLogData
    {
        public global::Azure.ResourceManager.Network.Models.TrafficAnalyticsConfigurationProperties TrafficAnalyticsConfiguration
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class FrontendIPConfigurationData
    {
    }

    public partial class HubVirtualNetworkConnectionData
    {
    }

    public partial class IPGroupData
    {
        public global::System.Collections.Generic.IList<global::System.String> IPAddresses => default;
    }

    public partial class LoadBalancerData
    {
    }

    public partial class LoadBalancingRuleData
    {
    }

    public partial class LocalNetworkGatewayData
    {
        public global::System.String GatewayIPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Collections.Generic.IList<global::System.String> LocalNetworkAddressPrefixes => default;
    }

    public partial class ManagementGroupNetworkManagerConnectionResource
    {
    }

    public partial class NatGatewayData
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> PublicIPAddresses => default;
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> PublicIPAddressesV6 => default;
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> PublicIPPrefixes => default;
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> PublicIPPrefixesV6 => default;
    }

    public partial class NetworkGroupData
    {
        public global::System.Nullable<global::Azure.ETag> ETag => default;
    }

    public partial class NetworkGroupStaticMemberData
    {
        public global::System.Nullable<global::Azure.ETag> ETag => default;
    }

    public partial class NetworkInterfaceData
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.NetworkInterfaceIPConfigurationData> IPConfigurations => default;
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource VirtualMachine
        {
            get => VirtualMachineId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = VirtualMachineId };
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class NetworkManagerData
    {
    }

    public partial class NetworkManagerRoutingConfigurationData
    {
        public global::System.Nullable<global::Azure.ETag> ETag => default;
    }

    public partial class NetworkManagerRoutingRuleData
    {
        public global::System.Nullable<global::Azure.ETag> ETag => default;
    }

    public partial class NetworkManagerRoutingRulesData
    {
        public global::System.Nullable<global::Azure.ETag> ETag => default;
    }

    public partial class NetworkManagerSecurityUserConfigurationData
    {
        public global::System.Nullable<global::Azure.ETag> ETag => default;
    }

    public partial class NetworkManagerSecurityUserRuleData
    {
        public global::System.Nullable<global::Azure.ETag> ETag => default;
    }

    public partial class NetworkManagerSecurityUserRulesData
    {
        public global::System.Nullable<global::Azure.ETag> ETag => default;
    }

    public partial class NetworkPrivateEndpointConnectionData
    {
        public global::Azure.ResourceManager.Network.Models.NetworkPrivateLinkServiceConnectionState ConnectionState
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class NetworkProfileData
    {
    }

    public partial class NetworkSecurityGroupData
    {
    }

    public partial class NetworkSecurityPerimeterAccessRuleData
    {
    }

    public partial class NetworkSecurityPerimeterData
    {
    }

    public partial class NetworkSecurityPerimeterLinkData
    {
    }

    public partial class NetworkSecurityPerimeterLinkReferenceData
    {
    }

    public partial class NetworkVirtualApplianceConnectionData
    {
        public global::Azure.ResourceManager.Network.Models.RoutingConfiguration ConnectionRoutingConfiguration
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class NetworkVirtualApplianceData
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> InternetIngressPublicIPs => default;
        public global::System.Net.IPAddress PrivateIPAddress => default;
    }

    public partial class OutboundRuleData
    {
    }

    public partial class PacketCaptureData
    {
        public global::System.Nullable<global::System.Boolean> IsContinuousCapture => default;
    }

    public partial class PeerExpressRouteCircuitConnectionData
    {
    }

    public partial class PolicySignaturesOverridesForIdpsData
    {
        public global::System.Nullable<global::Azure.Core.ResourceType> ResourceType
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class PrivateEndpointData
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.PrivateEndpointIPConfiguration> IPConfigurations => default;
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.PrivateEndpointIPVersionType> IPVersionType
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class PrivateLinkServiceData
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.PrivateLinkServiceIPConfiguration> IPConfigurations => default;
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.FrontendIPConfigurationData> LoadBalancerFrontendIPConfigurations => default;
    }

    public partial class ProbeData
    {
    }

    public partial class PublicIPAddressData
    {
        public global::System.String IPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::Azure.ResourceManager.Network.Models.NetworkIPConfiguration IPConfiguration => default;
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.IPTag> IPTags => default;
    }

    public partial class PublicIPPrefixData
    {
        public global::System.String IPPrefix => default;
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.IPTag> IPTags => default;
    }

    public partial class RouteData
    {
        public global::System.String NextHopIPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class RouteFilterData
    {
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.ExpressRouteCircuitPeeringData> IPv6Peerings => default;
    }

    public partial class RouteTableData
    {
    }

    public partial class ScopeConnectionData
    {
    }

    public partial class SecurityAdminConfigurationData
    {
        public global::System.Nullable<global::Azure.ETag> ETag => default;
    }

    public partial class ServiceEndpointPolicyData
    {
    }

    public partial class ServiceEndpointPolicyDefinitionData
    {
    }

    public partial class ServiceGatewayData
    {
    }

    public partial class SubnetData
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> IPAllocations => default;
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.Models.NetworkIPConfigurationProfile> IPConfigurationProfiles => default;
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.Models.NetworkIPConfiguration> IPConfigurations => default;
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.VirtualNetworkPrivateEndpointNetworkPolicy> PrivateEndpointNetworkPolicy
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.VirtualNetworkPrivateLinkServiceNetworkPolicy> PrivateLinkServiceNetworkPolicy
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class SubscriptionNetworkManagerConnectionResource
    {
    }

    public partial class VirtualHubData
    {
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> IPConfigurations => default;
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.VirtualHubRoute> Routes => default;
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.VirtualHubRouteTableV2Data> VirtualHubRouteTableV2S => default;
        public global::System.Collections.Generic.IList<global::System.String> VirtualRouterIPs => default;
    }

    public partial class VirtualNetworkApplianceData
    {
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.Models.VirtualNetworkApplianceIPConfiguration> IPConfigurations => default;
    }

    public partial class VirtualNetworkData
    {
        public global::System.Collections.Generic.IList<global::System.String> AddressPrefixes => default;
        internal global::Azure.ResourceManager.Network.Models.DhcpOptions DhcpOptions
        {
            get => new global::Azure.ResourceManager.Network.Models.DhcpOptions(DhcpOptionsDnsServers, default);
            set
            {
                DhcpOptionsDnsServers.Clear();
                if (value is not null)
                {
                    foreach (var dnsServer in value.DnsServers)
                    {
                        DhcpOptionsDnsServers.Add(dnsServer);
                    }
                }
            }
        }
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> IPAllocations => default;
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.PrivateEndpointVnetPolicy> PrivateEndpointVnetPolicy
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class VirtualNetworkGatewayConnectionData
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.GatewayCustomBgpIPAddressIPConfiguration> GatewayCustomBgpIPAddresses => default;
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.IPsecPolicy> IPsecPolicies => default;
        public global::System.Nullable<global::System.Boolean> UseLocalAzureIPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class VirtualNetworkGatewayData
    {
        public global::System.Nullable<global::System.Boolean> Active
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Collections.Generic.IList<global::System.String> CustomRoutesAddressPrefixes => default;
        public global::System.Nullable<global::System.Boolean> EnablePrivateIPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.VirtualNetworkGatewayIPConfiguration> IPConfigurations => default;
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource GatewayDefaultSite
        {
            get => GatewayDefaultSiteId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = GatewayDefaultSiteId };
            set => GatewayDefaultSiteId = value?.Id;
        }
    }

    public partial class VirtualNetworkGatewayNatRuleData
    {
        public global::System.String IPConfigurationId
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class VirtualNetworkPeeringData
    {
        public global::System.Nullable<global::System.Boolean> AreCompleteVnetsPeered
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Collections.Generic.IList<global::System.String> LocalAddressPrefixes => default;
        public global::System.Collections.Generic.IList<global::System.String> LocalVirtualNetworkAddressPrefixes => default;
        public global::System.Collections.Generic.IList<global::System.String> RemoteAddressPrefixes => default;
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource RemoteVirtualNetwork
        {
            get => RemoteVirtualNetworkId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = RemoteVirtualNetworkId };
            set => RemoteVirtualNetworkId = value?.Id;
        }
        public global::System.Collections.Generic.IList<global::System.String> RemoteVirtualNetworkAddressPrefixes => default;
    }

    public partial class VirtualNetworkTapData
    {
    }

    public partial class VirtualRouterData
    {
        public global::System.Collections.Generic.IList<global::System.String> VirtualRouterIPs => default;
    }

    public partial class VirtualRouterPeeringData
    {
        public global::System.String PeerIP
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class VirtualWanData
    {
    }

    public partial class VpnConnectionData
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.IPsecPolicy> IPsecPolicies => default;
        public global::System.Nullable<global::System.Boolean> UseLocalAzureIPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class VpnGatewayData
    {
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.Models.VpnGatewayIPConfiguration> IPConfigurations => default;
    }

    public partial class VpnGatewayNatRuleData
    {
        public global::System.String IPConfigurationId
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class VpnServerConfigurationData
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.IPsecPolicy> VpnClientIPsecPolicies => default;
    }

    public partial class VpnServerConfigurationPolicyGroupData
    {
    }

    public partial class VpnSiteData
    {
        public global::System.Collections.Generic.IList<global::System.String> AddressPrefixes => default;
        public global::System.String IPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class VpnSiteLinkConnectionData
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.IPsecPolicy> IPsecPolicies => default;
        public global::System.Nullable<global::System.Boolean> UseLocalAzureIPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class VpnSiteLinkData
    {
        public global::System.String IPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class WebApplicationFirewallPolicyData
    {
    }
}

namespace Azure.ResourceManager.Network.Models
{
    public partial class ApplicationGatewayBackendHttpSettings
    {
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource Probe
        {
            get => ProbeId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = ProbeId };
            set => ProbeId = value?.Id;
        }
    }

    public partial class ApplicationGatewayFrontendIPConfiguration
    {
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource Subnet
        {
            get => SubnetId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = SubnetId };
            set => SubnetId = value?.Id;
        }
    }

    public partial class ApplicationGatewayHttpListener
    {
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource FrontendIPConfiguration
        {
            get => FrontendIPConfigurationId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = FrontendIPConfigurationId };
            set => FrontendIPConfigurationId = value?.Id;
        }

        public global::Azure.ResourceManager.Resources.Models.WritableSubResource FrontendPort
        {
            get => FrontendPortId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = FrontendPortId };
            set => FrontendPortId = value?.Id;
        }

        public global::Azure.ResourceManager.Resources.Models.WritableSubResource SslCertificate
        {
            get => SslCertificateId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = SslCertificateId };
            set => SslCertificateId = value?.Id;
        }
    }

    public partial class ApplicationGatewayIPConfiguration
    {
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource Subnet
        {
            get => SubnetId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = SubnetId };
            set => SubnetId = value?.Id;
        }
    }

    public partial class ApplicationGatewayPathRule
    {
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource BackendAddressPool
        {
            get => BackendAddressPoolId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = BackendAddressPoolId };
            set => BackendAddressPoolId = value?.Id;
        }

        public global::Azure.ResourceManager.Resources.Models.WritableSubResource BackendHttpSettings
        {
            get => BackendHttpSettingsId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = BackendHttpSettingsId };
            set => BackendHttpSettingsId = value?.Id;
        }
    }

    public partial class ApplicationGatewayRedirectConfiguration
    {
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource TargetListener
        {
            get => TargetListenerId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = TargetListenerId };
            set => TargetListenerId = value?.Id;
        }
    }

    public partial class ApplicationGatewayRequestRoutingRule
    {
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource BackendAddressPool
        {
            get => BackendAddressPoolId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = BackendAddressPoolId };
            set => BackendAddressPoolId = value?.Id;
        }

        public global::Azure.ResourceManager.Resources.Models.WritableSubResource BackendHttpSettings
        {
            get => BackendHttpSettingsId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = BackendHttpSettingsId };
            set => BackendHttpSettingsId = value?.Id;
        }

        public global::Azure.ResourceManager.Resources.Models.WritableSubResource HttpListener
        {
            get => HttpListenerId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = HttpListenerId };
            set => HttpListenerId = value?.Id;
        }

        public global::Azure.ResourceManager.Resources.Models.WritableSubResource RedirectConfiguration
        {
            get => RedirectConfigurationId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = RedirectConfigurationId };
            set => RedirectConfigurationId = value?.Id;
        }

        public global::Azure.ResourceManager.Resources.Models.WritableSubResource UrlPathMap
        {
            get => UrlPathMapId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = UrlPathMapId };
            set => UrlPathMapId = value?.Id;
        }
    }

    public partial class ApplicationGatewayUrlPathMap
    {
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource DefaultRedirectConfiguration
        {
            get => DefaultRedirectConfigurationId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = DefaultRedirectConfigurationId };
            set => DefaultRedirectConfigurationId = value?.Id;
        }
    }

    public partial class AzureFirewallIPConfiguration
    {
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource PublicIPAddress
        {
            get => PublicIPAddressId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = PublicIPAddressId };
            set => PublicIPAddressId = value?.Id;
        }

        public global::Azure.ResourceManager.Resources.Models.WritableSubResource Subnet
        {
            get => SubnetId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = SubnetId };
            set => SubnetId = value?.Id;
        }
    }

    public partial class BastionHostIPConfiguration
    {
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource Subnet
        {
            get => SubnetId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = SubnetId };
            set => SubnetId = value?.Id;
        }

        public global::Azure.ResourceManager.Resources.Models.WritableSubResource PublicIPAddress
        {
            get => PublicIPAddressId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = PublicIPAddressId };
            set => PublicIPAddressId = value?.Id;
        }
    }

    public partial class VirtualNetworkGatewayIPConfiguration
    {
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource PublicIPAddress
        {
            get => PublicIPAddressId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = PublicIPAddressId };
            set => PublicIPAddressId = value?.Id;
        }

        public global::Azure.ResourceManager.Resources.Models.WritableSubResource Subnet
        {
            get => SubnetId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = SubnetId };
            set => SubnetId = value?.Id;
        }
    }
}

namespace Azure.ResourceManager.Network.Models
{
    public partial class ActiveConnectivityConfiguration
    {
        public global::System.Nullable<global::System.DateTimeOffset> CommittedOn => default;
    }

    public partial class ActiveDefaultSecurityAdminRule
    {
    }

    public partial class ActiveSecurityAdminRule
    {
    }

    public partial class AnalysisRunIntentContent
    {
        public global::Azure.ResourceManager.Network.Models.NetworkVerifierIPTraffic IPTraffic
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ApplicationGatewayAuthenticationCertificate
    {
    }

    public partial class ApplicationGatewayBackendAddress
    {
        public global::System.String IPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ApplicationGatewayBackendHealthServer
    {
        public global::Azure.ResourceManager.Network.NetworkInterfaceIPConfigurationData IPConfiguration => default;
    }

    public partial class ApplicationGatewayBackendHttpSettings
    {
    }

    public partial class ApplicationGatewayBackendSettings
    {
        public global::System.Nullable<global::System.Boolean> IsL4ClientIPPreservationEnabled
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Nullable<global::System.Int32> TimeoutInSeconds
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ApplicationGatewayConnectionDraining
    {
        public global::System.Int32 DrainTimeoutInSeconds
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ApplicationGatewayEntraJwtValidationConfig
    {
    }

    public partial class ApplicationGatewayOnDemandProbe
    {
        public global::System.Nullable<global::System.Boolean> IsProbeProxyProtocolHeaderEnabled
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ApplicationGatewayPrivateLinkConfiguration
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.ApplicationGatewayPrivateLinkIPConfiguration> IPConfigurations => default;
    }

    public partial class ApplicationGatewayPrivateLinkIPConfiguration
    {
        public global::System.Nullable<global::System.Boolean> IsPrimary
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ApplicationGatewayProbe
    {
        public global::System.Nullable<global::System.Int32> IntervalInSeconds
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Nullable<global::System.Boolean> IsProbeProxyProtocolHeaderEnabled
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Nullable<global::System.Int32> TimeoutInSeconds
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ApplicationGatewayRedirectConfiguration
    {
    }

    public partial class ApplicationGatewaySslCertificate
    {
    }

    public partial class ApplicationGatewaySslProfile
    {
        public global::System.Nullable<global::System.Boolean> VerifyClientCertIssuerDN
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ApplicationGatewayTrustedClientCertificate
    {
    }

    public partial class ApplicationGatewayTrustedRootCertificate
    {
    }

    public partial class ApplicationRule
    {
        public global::System.Collections.Generic.IList<global::System.String> SourceIPGroups => default;
    }

    public partial class AzureFirewallApplicationRule
    {
        public global::System.Collections.Generic.IList<global::System.String> SourceIPGroups => default;
    }

    public partial class AzureFirewallNatRule
    {
        public global::System.Collections.Generic.IList<global::System.String> SourceIPGroups => default;
    }

    public partial class AzureFirewallNetworkRule
    {
        public global::System.Collections.Generic.IList<global::System.String> DestinationIPGroups => default;
        public global::System.Collections.Generic.IList<global::System.String> SourceIPGroups => default;
    }

    public partial class AzureFirewallPacketCaptureFlags
    {
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.AzureFirewallPacketCaptureFlagsType> FlagsType
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ConnectionMonitorEndpoint
    {
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.ConnectionMonitorEndpointType> EndpointType
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ConnectionMonitorEndpointFilter
    {
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.ConnectionMonitorEndpointFilterType> FilterType
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ConnectionMonitorEndpointFilterItem
    {
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.ConnectionMonitorEndpointFilterItemType> ItemType
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ConnectionMonitorHttpConfiguration
    {
        public global::System.Nullable<global::System.Boolean> PreferHttps
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ConnectionMonitorOutput
    {
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.OutputType> OutputType
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ConnectivityContent
    {
        public global::Azure.ResourceManager.Network.Models.NetworkHttpConfiguration HttpProtocolConfiguration
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ConnectivityHopInfo
    {
        public global::System.String ConnectivityHopType => default;
    }

    public partial class ConnectivityInformation
    {
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.NetworkConnectionStatus> NetworkConnectionStatus => default;
    }

    public partial class ConnectivityIssueInfo
    {
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.ConnectivityIssueType> ConnectivityIssueType => default;
        public global::System.Collections.Generic.IReadOnlyList<global::System.Collections.Generic.IDictionary<global::System.String, global::System.String>> Contexts => default;
    }

    public partial class ContainerNetworkInterface
    {
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.Models.ContainerNetworkInterfaceIPConfiguration> IPConfigurations => default;
    }

    public partial class ContainerNetworkInterfaceConfiguration
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.NetworkIPConfigurationProfile> IPConfigurations => default;
    }

    public partial class ContainerNetworkInterfaceIPConfiguration
    {
        public global::System.String ContainerNetworkInterfaceIpConfigurationType => default;
    }

    public partial class CustomDnsConfigProperties
    {
        public global::System.Collections.Generic.IList<global::System.String> IPAddresses => default;
    }

    public partial class DdosSettings
    {
        public global::System.Nullable<global::System.Boolean> ProtectedIP
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.DdosSettingsProtectionCoverage> ProtectionCoverage
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class DscpQosDefinition
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.QosIPRange> DestinationIPRanges => default;
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.QosIPRange> SourceIPRanges => default;
    }

    public partial class EffectiveConnectivityConfiguration
    {
    }

    public partial class EffectiveDefaultSecurityAdminRule
    {
    }

    public partial class EffectiveNetworkSecurityGroup
    {
        public global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::System.Collections.Generic.IList<global::System.String>> TagToIPAddresses => default;
    }

    public partial class EffectiveRoute
    {
        public global::System.Collections.Generic.IReadOnlyList<global::System.String> NextHopIPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class EffectiveSecurityAdminRule
    {
    }

    public partial class EndpointServiceResult
    {
        public global::System.Nullable<global::Azure.Core.ResourceType> ResourceType
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ExpressRouteCircuitArpTable
    {
        public global::System.String IPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ExpressRouteFailoverConnectionResourceDetails
    {
        public global::System.Nullable<global::System.DateTimeOffset> LastUpdatedOn => default;
    }

    public partial class ExpressRouteFailoverTestDetails
    {
        public global::System.Nullable<global::System.DateTimeOffset> EndOn => default;
        public global::System.Nullable<global::System.DateTimeOffset> StartOn => default;
    }

    public partial class FirewallPolicyIntrusionDetectionBypassTrafficSpecifications
    {
        public global::System.Collections.Generic.IList<global::System.String> DestinationIPGroups => default;
        public global::System.Collections.Generic.IList<global::System.String> SourceIPGroups => default;
    }

    public partial class FirewallPolicyThreatIntelWhitelist
    {
        public global::System.Collections.Generic.IList<global::System.String> IPAddresses => default;
    }

    public partial class FlowLogInformation
    {
        public global::Azure.ResourceManager.Network.Models.TrafficAnalyticsConfigurationProperties TrafficAnalyticsConfiguration
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class GatewayCustomBgpIPAddressIPConfiguration
    {
        public global::System.String CustomBgpIPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.String IPConfigurationId
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class GatewayLoadBalancerTunnelInterface
    {
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.GatewayLoadBalancerTunnelInterfaceType> InterfaceType
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class IPTag
    {
        public global::System.String IPTagType
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class IPsecPolicy
    {
        public global::Azure.ResourceManager.Network.Models.IPsecEncryption IPsecEncryption
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::Azure.ResourceManager.Network.Models.IPsecIntegrity IPsecIntegrity
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class IpamPoolPrefixAllocation
    {
        public global::System.String NumberOfIPAddresses
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class IpamPoolProperties
    {
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.Models.IpamIPType> IPAddressType => default;
    }

    public partial class LearnedIPPrefixesListResult
    {
        public global::System.Collections.Generic.IReadOnlyList<global::System.String> IPPrefixes => default;
    }

    public partial class LoadBalancerBackendAddress
    {
        public global::System.String IPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class LoadBalancerHealthPerRulePerBackendAddress
    {
        public global::System.String IPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class LoadBalancerInboundNatPool
    {
    }

    public partial class NatRule
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.FirewallPolicyRuleNetworkProtocol> IPProtocols => default;
        public global::System.Collections.Generic.IList<global::System.String> SourceIPGroups => default;
    }

    public partial class NetworkAdminRule
    {
    }

    public partial class NetworkConfigurationGroup
    {
    }

    public partial class NetworkDefaultAdminRule
    {
    }

    public partial class NetworkIPConfigurationBgpPeeringAddress
    {
        public global::System.Collections.Generic.IList<global::System.String> CustomBgpIPAddresses => default;
        public global::System.Collections.Generic.IReadOnlyList<global::System.String> DefaultBgpIPAddresses => default;
        public global::System.String IPConfigurationId
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Collections.Generic.IReadOnlyList<global::System.String> TunnelIPAddresses => default;
    }

    public partial class NetworkManagerDeploymentStatus
    {
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.NetworkManagerDeploymentState> DeploymentState => default;
    }

    public partial class NetworkPrivateLinkServiceConnection
    {
        public global::Azure.ResourceManager.Network.Models.NetworkPrivateLinkServiceConnectionState ConnectionState
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class NetworkResourceData
    {
        public global::System.Nullable<global::Azure.Core.ResourceType> ResourceType
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class NetworkRule
    {
        public global::System.Collections.Generic.IList<global::System.String> DestinationIPGroups => default;
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.FirewallPolicyRuleNetworkProtocol> IPProtocols => default;
        public global::System.Collections.Generic.IList<global::System.String> SourceIPGroups => default;
    }

    public partial class NetworkTrackedResourceData
    {
        public global::System.Nullable<global::Azure.Core.ResourceType> ResourceType
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class NetworkVerifierIPTraffic
    {
        public global::System.Collections.Generic.IList<global::System.String> DestinationIPs => default;
        public global::System.Collections.Generic.IList<global::System.String> SourceIPs => default;
    }

    public partial class NextHopResult
    {
        public global::System.String NextHopIPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class NvaInterfaceConfigurationsProperties
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.NvaNicType> PropertiesType => default;
    }

    public partial class P2SConnectionConfiguration
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> ConfigurationPolicyGroups => default;
        public global::System.Collections.Generic.IList<global::System.String> VpnClientAddressPrefixes => default;
    }

    public partial class PeerRouteList
    {
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.Models.PeerRoute> Value => default;
    }

    public partial class PolicySettings
    {
        public global::System.Nullable<global::System.Int32> CaptchaCookieExpirationInMins
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class PrivateEndpointIPConfiguration
    {
        public global::System.String PrivateEndpointIPConfigurationType => default;
    }

    public partial class PublicIPDdosProtectionStatusResult
    {
        public global::System.Net.IPAddress PublicIPAddress => default;
    }

    public partial class QueryInboundNatRulePortMappingContent
    {
        public global::System.String IPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ReachabilityAnalysisIntentProperties
    {
        public global::Azure.ResourceManager.Network.Models.NetworkVerifierIPTraffic IPTraffic
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class RecordSet
    {
        public global::System.Collections.Generic.IReadOnlyList<global::System.String> IPAddresses => default;
    }

    public partial class ResourceNavigationLink
    {
    }

    public partial class RoutingConfiguration
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.StaticRoute> StaticRoutes => default;
    }

    public partial class RoutingConfigurationNfv
    {
        public global::System.Uri AssociatedRouteTableResourceUri
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Uri InboundRouteMapResourceUri
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Uri OutboundRouteMapResourceUri
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class RoutingRuleRouteDestination
    {
        public global::Azure.ResourceManager.Network.Models.RoutingRuleDestinationType DestinationType
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class ServiceAssociationLink
    {
    }

    public partial class StaticRoute
    {
        public global::System.String NextHopIPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class TrafficAnalyticsConfigurationProperties
    {
        public global::System.Nullable<global::System.Int32> TrafficAnalyticsIntervalInMinutes
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class TroubleshootingContent
    {
        public global::System.Uri StorageUri => default;
    }

    public partial class TunnelConnectionHealth
    {
        public global::System.String LastConnectionEstablishedOn => default;
    }

    public partial class VirtualApplianceAdditionalNicProperties
    {
        public global::System.Nullable<global::System.Boolean> HasPublicIP
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class VirtualApplianceIPConfiguration
    {
        public global::System.Nullable<global::System.Boolean> IsPrimary
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class VirtualApplianceNetworkInterfaceConfiguration
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.VirtualApplianceIPConfiguration> VirtualApplianceNetworkInterfaceIPConfigurations => default;
    }

    public partial class VirtualApplianceNicProperties
    {
        public global::System.String PrivateIPAddress => default;
        public global::System.String PublicIPAddress => default;
    }

    public partial class VirtualHubRoute
    {
        public global::System.String NextHopIPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class VirtualNetworkEncryption
    {
        public global::System.Boolean IsEnabled
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class VirtualNetworkGatewayConnectionListEntity
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.GatewayCustomBgpIPAddressIPConfiguration> GatewayCustomBgpIPAddresses => default;
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.IPsecPolicy> IPsecPolicies => default;
    }

    public partial class VirtualNetworkGatewayConnectionTunnelProperties
    {
        public global::System.String TunnelIPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class VirtualNetworkGatewayPolicyGroup
    {
    }

    public partial class VirtualWanSecurityProvider
    {
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.VirtualWanSecurityProviderType> ProviderType => default;
    }

    public partial class VngClientConnectionConfiguration
    {
        public global::System.Collections.Generic.IList<global::System.String> VpnClientAddressPrefixes => default;
    }

    public partial class VpnClientConfiguration
    {
        public global::System.Collections.Generic.IList<global::System.String> VpnClientAddressPrefixes => default;
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.IPsecPolicy> VpnClientIPsecPolicies => default;
    }

    public partial class VpnClientConnectionHealth
    {
        public global::System.Collections.Generic.IReadOnlyList<global::System.String> AllocatedIPAddresses => default;
    }

    public partial class VpnClientConnectionHealthDetail
    {
        public global::System.String PrivateIPAddress => default;
        public global::System.String PublicIPAddress => default;
        public global::System.Nullable<global::System.Int64> VpnConnectionDurationInSeconds => default;
        public global::System.Nullable<global::System.DateTimeOffset> VpnConnectionOn => default;
    }

    public partial class VpnClientIPsecParameters
    {
        public global::Azure.ResourceManager.Network.Models.IPsecEncryption IPsecEncryption
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::Azure.ResourceManager.Network.Models.IPsecIntegrity IPsecIntegrity
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }

    public partial class VpnClientRootCertificate
    {
    }

    public partial class VpnGatewayIPConfiguration
    {
        public global::System.String PrivateIPAddress => default;
        public global::System.String PublicIPAddress => default;
    }
}
