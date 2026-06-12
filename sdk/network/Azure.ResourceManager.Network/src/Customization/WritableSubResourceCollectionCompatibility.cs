// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS0612, CS0618, CS1591

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    internal static class WritableSubResourceCollectionCompatibility
    {
        public static IReadOnlyList<WritableSubResource> AsReadOnlyList(IReadOnlyList<NetworkSubResource> source) => source is null ? default : new ReadOnlyNetworkSubResourceList(source);
        public static IReadOnlyList<WritableSubResource> AsReadOnlyList(IReadOnlyList<WritableSubResource> source) => source;
        public static IList<WritableSubResource> AsList(IList<NetworkSubResource> source) => source is null ? default : new NetworkSubResourceList(source);
        public static IList<WritableSubResource> AsList(IList<WritableSubResource> source) => source;
        public static Guid? ParseGuid(string value) => ResourceGuidCompatibility.Parse(value);
        public static Guid? ParseGuid(Guid? value) => value;
        public static Guid? FormatGuid(Guid? value) => value;
        public static Uri ParseUri(string value) => Uri.TryCreate(value, UriKind.RelativeOrAbsolute, out Uri uri) ? uri : default;
        public static Uri ParseUri(Uri value) => value;
        public static Uri FormatUri(Uri value) => value;
        public static BinaryData ParseBinaryData(string value) => value is null ? default : BinaryData.FromString(value);
        public static BinaryData ParseBinaryData(BinaryData value) => value;
        public static BinaryData FormatBinaryData(BinaryData value) => value;

        private static WritableSubResource ToWritable(NetworkSubResource value) => value is null ? default : new WritableSubResource { Id = value.Id };
        private static NetworkSubResource ToNetwork(WritableSubResource value) => value is null ? default : new NetworkSubResource { Id = value.Id };

        private sealed class ReadOnlyNetworkSubResourceList : IReadOnlyList<WritableSubResource>
        {
            private readonly IReadOnlyList<NetworkSubResource> _source;
            public ReadOnlyNetworkSubResourceList(IReadOnlyList<NetworkSubResource> source) => _source = source;
            public int Count => _source.Count;
            public WritableSubResource this[int index] => ToWritable(_source[index]);
            public IEnumerator<WritableSubResource> GetEnumerator()
            {
                foreach (NetworkSubResource item in _source)
                {
                    yield return ToWritable(item);
                }
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private sealed class NetworkSubResourceList : IList<WritableSubResource>
        {
            private readonly IList<NetworkSubResource> _source;
            public NetworkSubResourceList(IList<NetworkSubResource> source) => _source = source;
            public int Count => _source.Count;
            public bool IsReadOnly => _source.IsReadOnly;
            public WritableSubResource this[int index] { get => ToWritable(_source[index]); set => _source[index] = ToNetwork(value); }
            public void Add(WritableSubResource item) => _source.Add(ToNetwork(item));
            public void Clear() => _source.Clear();
            public bool Contains(WritableSubResource item) => IndexOf(item) >= 0;
            public void CopyTo(WritableSubResource[] array, int arrayIndex)
            {
                foreach (WritableSubResource item in this)
                {
                    array[arrayIndex++] = item;
                }
            }
            public IEnumerator<WritableSubResource> GetEnumerator()
            {
                foreach (NetworkSubResource item in _source)
                {
                    yield return ToWritable(item);
                }
            }
            public int IndexOf(WritableSubResource item)
            {
                for (int i = 0; i < _source.Count; i++)
                {
                    if (Equals(_source[i]?.Id, item?.Id))
                    {
                        return i;
                    }
                }
                return -1;
            }
            public void Insert(int index, WritableSubResource item) => _source.Insert(index, ToNetwork(item));
            public bool Remove(WritableSubResource item)
            {
                int index = IndexOf(item);
                if (index < 0)
                {
                    return false;
                }
                _source.RemoveAt(index);
                return true;
            }
            public void RemoveAt(int index) => _source.RemoveAt(index);
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }

    [CodeGenSuppress("InboundNatRules")]
    [CodeGenSuppress("LoadBalancingRules")]
    [CodeGenSuppress("OutboundRules")]
    public partial class BackendAddressPoolData
    {
        [WirePath("properties.inboundNatRules")] public IReadOnlyList<WritableSubResource> InboundNatRules => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.InboundNatRules);
        [WirePath("properties.loadBalancingRules")] public IReadOnlyList<WritableSubResource> LoadBalancingRules => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.LoadBalancingRules);
        [WirePath("properties.outboundRules")] public IReadOnlyList<WritableSubResource> OutboundRules => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.OutboundRules);
    }

    [CodeGenSuppress("PublicIPAddresses")]
    public partial class DdosCustomPolicyData
    {
        [WirePath("properties.publicIPAddresses")] public IReadOnlyList<WritableSubResource> PublicIPAddresses => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.PublicIPAddresses);
    }

    [CodeGenSuppress("PublicIPAddresses")]
    [CodeGenSuppress("VirtualNetworks")]
    public partial class DdosProtectionPlanData
    {
        [WirePath("properties.publicIPAddresses")] public IReadOnlyList<WritableSubResource> PublicIPAddresses => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.PublicIPAddresses);
        [WirePath("properties.virtualNetworks")] public IReadOnlyList<WritableSubResource> VirtualNetworks => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.VirtualNetworks);
    }

    [CodeGenSuppress("ConnectionResourceUri")]
    public partial class ExpressRouteCircuitAuthorizationData
    {
        [WirePath("properties.connectionResourceUri")] public Uri ConnectionResourceUri => WritableSubResourceCollectionCompatibility.ParseUri(Properties?.ConnectionResourceUri);
    }

    [CodeGenSuppress("CircuitResourceUri")]
    public partial class ExpressRoutePortAuthorizationData
    {
        [WirePath("properties.circuitResourceUri")] public Uri CircuitResourceUri => WritableSubResourceCollectionCompatibility.ParseUri(Properties?.CircuitResourceUri);
    }

    [CodeGenSuppress("Circuits")]
    public partial class ExpressRoutePortData
    {
        [WirePath("properties.circuits")] public IReadOnlyList<WritableSubResource> Circuits => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.Circuits);
    }

    [CodeGenSuppress("ChildPolicies")]
    [CodeGenSuppress("Firewalls")]
    [CodeGenSuppress("RuleCollectionGroups")]
    public partial class FirewallPolicyData
    {
        [WirePath("properties.childPolicies")] public IReadOnlyList<WritableSubResource> ChildPolicies => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.ChildPolicies);
        [WirePath("properties.firewalls")] public IReadOnlyList<WritableSubResource> Firewalls => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.Firewalls);
        [WirePath("properties.ruleCollectionGroups")] public IReadOnlyList<WritableSubResource> RuleCollectionGroups => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.RuleCollectionGroups);
    }

    [CodeGenSuppress("InboundNatPools")]
    [CodeGenSuppress("InboundNatRules")]
    [CodeGenSuppress("LoadBalancingRules")]
    [CodeGenSuppress("OutboundRules")]
    public partial class FrontendIPConfigurationData
    {
        [WirePath("properties.inboundNatPools")] public IReadOnlyList<WritableSubResource> InboundNatPools => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.InboundNatPools);
        [WirePath("properties.inboundNatRules")] public IReadOnlyList<WritableSubResource> InboundNatRules => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.InboundNatRules);
        [WirePath("properties.loadBalancingRules")] public IReadOnlyList<WritableSubResource> LoadBalancingRules => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.LoadBalancingRules);
        [WirePath("properties.outboundRules")] public IReadOnlyList<WritableSubResource> OutboundRules => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.OutboundRules);
    }

    [CodeGenSuppress("FirewallPolicies")]
    [CodeGenSuppress("Firewalls")]
    public partial class IPGroupData
    {
        [WirePath("properties.firewallPolicies")] public IReadOnlyList<WritableSubResource> FirewallPolicies => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.FirewallPolicies);
        [WirePath("properties.firewalls")] public IReadOnlyList<WritableSubResource> Firewalls => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.Firewalls);
    }

    [CodeGenSuppress("Subnets")]
    public partial class NatGatewayData
    {
        [WirePath("properties.subnets")] public IReadOnlyList<WritableSubResource> Subnets => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.Subnets);
    }

    [CodeGenSuppress("Subscriptions")]
    public partial class NetworkSecurityPerimeterAccessRuleData
    {
        [WirePath("properties.subscriptions")] public IList<WritableSubResource> Subscriptions => WritableSubResourceCollectionCompatibility.AsList(Properties?.Subscriptions);
    }

    [CodeGenSuppress("PerimeterGuid")]
    public partial class NetworkSecurityPerimeterData
    {
        [WirePath("properties.perimeterGuid")] public Guid? PerimeterGuid => WritableSubResourceCollectionCompatibility.ParseGuid(Properties?.PerimeterGuid);
    }

    [CodeGenSuppress("RemotePerimeterGuid")]
    public partial class NetworkSecurityPerimeterLinkData
    {
        [WirePath("properties.remotePerimeterGuid")] public Guid? RemotePerimeterGuid => WritableSubResourceCollectionCompatibility.ParseGuid(Properties?.RemotePerimeterGuid);
    }

    [CodeGenSuppress("RemotePerimeterGuid")]
    public partial class NetworkSecurityPerimeterLinkReferenceData
    {
        [WirePath("properties.remotePerimeterGuid")] public Guid? RemotePerimeterGuid => WritableSubResourceCollectionCompatibility.ParseGuid(Properties?.RemotePerimeterGuid);
    }

    [CodeGenSuppress("InboundSecurityRules")]
    [CodeGenSuppress("VirtualApplianceConnections")]
    [CodeGenSuppress("VirtualApplianceSites")]
    public partial class NetworkVirtualApplianceData
    {
        [WirePath("properties.inboundSecurityRules")] public IReadOnlyList<WritableSubResource> InboundSecurityRules => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.InboundSecurityRules);
        [WirePath("properties.virtualApplianceConnections")] public IReadOnlyList<WritableSubResource> VirtualApplianceConnections => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.VirtualApplianceConnections);
        [WirePath("properties.virtualApplianceSites")] public IReadOnlyList<WritableSubResource> VirtualApplianceSites => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.VirtualApplianceSites);
    }

    [CodeGenSuppress("FrontendIPConfigurations")]
    public partial class OutboundRuleData
    {
        [WirePath("properties.frontendIPConfigurations")] public IList<WritableSubResource> FrontendIPConfigurations => WritableSubResourceCollectionCompatibility.AsList(Properties?.FrontendIPConfigurations);
    }

    [CodeGenSuppress("LoadBalancingRules")]
    public partial class ProbeData
    {
        [WirePath("properties.loadBalancingRules")] public IReadOnlyList<WritableSubResource> LoadBalancingRules => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.LoadBalancingRules);
    }

    [CodeGenSuppress("TenantId")]
    public partial class ScopeConnectionData
    {
        [WirePath("properties.tenantId")]
        public Guid? TenantId
        {
            get => WritableSubResourceCollectionCompatibility.ParseGuid(Properties?.TenantId);
            set
            {
                if (Properties is null)
                {
                    Properties = new ScopeConnectionProperties();
                }
                Properties.TenantId = WritableSubResourceCollectionCompatibility.FormatGuid(value);
            }
        }
    }

    [CodeGenSuppress("BgpConnections")]
    [CodeGenSuppress("RouteMaps")]
    public partial class VirtualHubData
    {
        [WirePath("properties.bgpConnections")] public IReadOnlyList<WritableSubResource> BgpConnections => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.BgpConnections);
        [WirePath("properties.routeMaps")] public IReadOnlyList<WritableSubResource> RouteMaps => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.RouteMaps);
    }

    [CodeGenSuppress("EgressNatRules")]
    [CodeGenSuppress("IngressNatRules")]
    public partial class VirtualNetworkGatewayConnectionData
    {
        [WirePath("properties.egressNatRules")] public IList<WritableSubResource> EgressNatRules => WritableSubResourceCollectionCompatibility.AsList(Properties?.EgressNatRules);
        [WirePath("properties.ingressNatRules")] public IList<WritableSubResource> IngressNatRules => WritableSubResourceCollectionCompatibility.AsList(Properties?.IngressNatRules);
    }

    [CodeGenSuppress("Peerings")]
    public partial class VirtualRouterData
    {
        [WirePath("properties.peerings")] public IReadOnlyList<WritableSubResource> Peerings => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.Peerings);
    }

    [CodeGenSuppress("VirtualHubs")]
    [CodeGenSuppress("VpnSites")]
    public partial class VirtualWanData
    {
        [WirePath("properties.virtualHubs")] public IReadOnlyList<WritableSubResource> VirtualHubs => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.VirtualHubs);
        [WirePath("properties.vpnSites")] public IReadOnlyList<WritableSubResource> VpnSites => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.VpnSites);
    }

    [CodeGenSuppress("EgressVpnSiteLinkConnections")]
    [CodeGenSuppress("IngressVpnSiteLinkConnections")]
    public partial class VpnGatewayNatRuleData
    {
        [WirePath("properties.egressVpnSiteLinkConnections")] public IReadOnlyList<WritableSubResource> EgressVpnSiteLinkConnections => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.EgressVpnSiteLinkConnections);
        [WirePath("properties.ingressVpnSiteLinkConnections")] public IReadOnlyList<WritableSubResource> IngressVpnSiteLinkConnections => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.IngressVpnSiteLinkConnections);
    }

    [CodeGenSuppress("P2SConnectionConfigurations")]
    public partial class VpnServerConfigurationPolicyGroupData
    {
        [WirePath("properties.p2SConnectionConfigurations")] public IReadOnlyList<WritableSubResource> P2SConnectionConfigurations => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.P2SConnectionConfigurations);
    }

    [CodeGenSuppress("EgressNatRules")]
    [CodeGenSuppress("IngressNatRules")]
    public partial class VpnSiteLinkConnectionData
    {
        [WirePath("properties.egressNatRules")] public IList<WritableSubResource> EgressNatRules => WritableSubResourceCollectionCompatibility.AsList(Properties?.EgressNatRules);
        [WirePath("properties.ingressNatRules")] public IList<WritableSubResource> IngressNatRules => WritableSubResourceCollectionCompatibility.AsList(Properties?.IngressNatRules);
    }

    [CodeGenSuppress("HttpListeners")]
    [CodeGenSuppress("PathBasedRules")]
    public partial class WebApplicationFirewallPolicyData
    {
        [WirePath("properties.httpListeners")] public IReadOnlyList<WritableSubResource> HttpListeners => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.HttpListeners);
        [WirePath("properties.pathBasedRules")] public IReadOnlyList<WritableSubResource> PathBasedRules => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.PathBasedRules);
    }
}

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenType("SubscriptionId")]
    public partial class SubscriptionId
    {
    }

    [CodeGenSuppress("Data")]
    public partial class ApplicationGatewayAuthenticationCertificate
    {
        [Azure.ResourceManager.Network.WirePath("properties.data")]
        public BinaryData Data
        {
            get => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.ParseBinaryData(Properties?.Data);
            set
            {
                if (Properties is null)
                {
                    Properties = new ApplicationGatewayAuthenticationCertificatePropertiesFormat();
                }
                Properties.Data = Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.FormatBinaryData(value);
            }
        }
    }

    [CodeGenSuppress("AuthenticationCertificates")]
    [CodeGenSuppress("TrustedRootCertificates")]
    public partial class ApplicationGatewayBackendHttpSettings
    {
        [Azure.ResourceManager.Network.WirePath("properties.authenticationCertificates")] public IList<WritableSubResource> AuthenticationCertificates => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.AuthenticationCertificates);
        [Azure.ResourceManager.Network.WirePath("properties.trustedRootCertificates")] public IList<WritableSubResource> TrustedRootCertificates => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.TrustedRootCertificates);
    }

    [CodeGenSuppress("TrustedRootCertificates")]
    public partial class ApplicationGatewayBackendSettings
    {
        [Azure.ResourceManager.Network.WirePath("properties.trustedRootCertificates")] public IList<WritableSubResource> TrustedRootCertificates => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.TrustedRootCertificates);
    }

    [CodeGenSuppress("TenantId")]
    public partial class ApplicationGatewayEntraJwtValidationConfig
    {
        [Azure.ResourceManager.Network.WirePath("properties.tenantId")]
        public Guid? TenantId
        {
            get => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.ParseGuid(Properties?.TenantId);
            set
            {
                if (Properties is null)
                {
                    Properties = new ApplicationGatewayEntraJWTValidationConfigPropertiesFormat();
                }
                Properties.TenantId = Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.FormatGuid(value);
            }
        }
    }

    [CodeGenSuppress("PathRules")]
    [CodeGenSuppress("RequestRoutingRules")]
    [CodeGenSuppress("TargetUri")]
    [CodeGenSuppress("UrlPathMaps")]
    public partial class ApplicationGatewayRedirectConfiguration
    {
        [Azure.ResourceManager.Network.WirePath("properties.pathRules")] public IList<WritableSubResource> PathRules => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.PathRules);
        [Azure.ResourceManager.Network.WirePath("properties.requestRoutingRules")] public IList<WritableSubResource> RequestRoutingRules => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.RequestRoutingRules);
        [Azure.ResourceManager.Network.WirePath("properties.urlPathMaps")] public IList<WritableSubResource> UrlPathMaps => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.UrlPathMaps);
        [Azure.ResourceManager.Network.WirePath("properties.targetUrl")]
        public Uri TargetUri
        {
            get => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.ParseUri(Properties?.TargetUri);
            set
            {
                if (Properties is null)
                {
                    Properties = new ApplicationGatewayRedirectConfigurationPropertiesFormat();
                }
                Properties.TargetUri = Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.FormatUri(value);
            }
        }
    }

    [CodeGenSuppress("Data")]
    [CodeGenSuppress("PublicCertData")]
    public partial class ApplicationGatewaySslCertificate
    {
        [Azure.ResourceManager.Network.WirePath("properties.data")]
        public BinaryData Data
        {
            get => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.ParseBinaryData(Properties?.Data);
            set
            {
                if (Properties is null)
                {
                    Properties = new ApplicationGatewaySslCertificatePropertiesFormat();
                }
                Properties.Data = Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.FormatBinaryData(value);
            }
        }

        [Azure.ResourceManager.Network.WirePath("properties.publicCertData")] public BinaryData PublicCertData => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.ParseBinaryData(Properties?.PublicCertData);
    }

    [CodeGenSuppress("TrustedClientCertificates")]
    public partial class ApplicationGatewaySslProfile
    {
        [Azure.ResourceManager.Network.WirePath("properties.trustedClientCertificates")] public IList<WritableSubResource> TrustedClientCertificates => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.TrustedClientCertificates);
    }

    [CodeGenSuppress("Data")]
    [CodeGenSuppress("ValidatedCertData")]
    public partial class ApplicationGatewayTrustedClientCertificate
    {
        [Azure.ResourceManager.Network.WirePath("properties.data")]
        public BinaryData Data
        {
            get => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.ParseBinaryData(Properties?.Data);
            set
            {
                if (Properties is null)
                {
                    Properties = new ApplicationGatewayTrustedClientCertificatePropertiesFormat();
                }
                Properties.Data = Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.FormatBinaryData(value);
            }
        }

        [Azure.ResourceManager.Network.WirePath("properties.validatedCertData")] public BinaryData ValidatedCertData => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.ParseBinaryData(Properties?.ValidatedCertData);
    }

    [CodeGenSuppress("Data")]
    public partial class ApplicationGatewayTrustedRootCertificate
    {
        [Azure.ResourceManager.Network.WirePath("properties.data")]
        public BinaryData Data
        {
            get => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.ParseBinaryData(Properties?.Data);
            set
            {
                if (Properties is null)
                {
                    Properties = new ApplicationGatewayTrustedRootCertificatePropertiesFormat();
                }
                Properties.Data = Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.FormatBinaryData(value);
            }
        }
    }

    [CodeGenSuppress("ContainerNetworkInterfaces")]
    public partial class ContainerNetworkInterfaceConfiguration
    {
        [Azure.ResourceManager.Network.WirePath("properties.containerNetworkInterfaces")] public IList<WritableSubResource> ContainerNetworkInterfaces => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.ContainerNetworkInterfaces);
    }

    [CodeGenSuppress("VngClientConnectionConfigurations")]
    public partial class VirtualNetworkGatewayPolicyGroup
    {
        [Azure.ResourceManager.Network.WirePath("properties.vngClientConnectionConfigurations")] public IReadOnlyList<WritableSubResource> VngClientConnectionConfigurations => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.VngClientConnectionConfigurations);
    }

    [CodeGenSuppress("VirtualNetworkGatewayPolicyGroups")]
    public partial class VngClientConnectionConfiguration
    {
        [Azure.ResourceManager.Network.WirePath("properties.virtualNetworkGatewayPolicyGroups")] public IList<WritableSubResource> VirtualNetworkGatewayPolicyGroups => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.VirtualNetworkGatewayPolicyGroups);
    }

    [CodeGenSuppress("PublicCertData")]
    public partial class VpnClientRootCertificate
    {
        public VpnClientRootCertificate(BinaryData publicCertData)
        {
            PublicCertData = publicCertData;
        }

        [Azure.ResourceManager.Network.WirePath("properties.publicCertData")]
        public BinaryData PublicCertData
        {
            get => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.ParseBinaryData(Properties?.PublicCertData);
            set
            {
                if (Properties is null)
                {
                    Properties = new VpnClientRootCertificatePropertiesFormat();
                }
                Properties.PublicCertData = Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.FormatBinaryData(value);
            }
        }
    }
}

#pragma warning restore CS0612, CS0618, CS1591
