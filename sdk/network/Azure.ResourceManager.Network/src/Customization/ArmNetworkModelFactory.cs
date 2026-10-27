// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    // The generated 1.15.0 object-valued health factory adapter otherwise discards the supplied configuration ID.
    [CodeGenSuppress("LoadBalancerHealthPerRulePerBackendAddress", typeof(string), typeof(NetworkInterfaceIPConfigurationData), typeof(string), typeof(string))]
    // The renamed numeric wire property must not consume or discard the legacy string input.
    // Preserve this overload and store its values only in the independent Rules collection.
    [CodeGenSuppress("ManagedRuleSetRuleGroup", typeof(string), typeof(IEnumerable<string>))]
    // The compatibility generator otherwise drops the released active argument after the IsActive rename.
    [CodeGenSuppress("VirtualNetworkGatewayData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType?), typeof(AzureLocation?), typeof(IDictionary<string, string>), typeof(ExtendedLocation), typeof(ETag?), typeof(IEnumerable<VirtualNetworkGatewayIPConfiguration>), typeof(VirtualNetworkGatewayType?), typeof(VpnType?), typeof(VpnGatewayGeneration?), typeof(bool?), typeof(bool?), typeof(bool?), typeof(bool?), typeof(ResourceIdentifier), typeof(VirtualNetworkGatewaySku), typeof(VpnClientConfiguration), typeof(IEnumerable<VirtualNetworkGatewayPolicyGroup>), typeof(BgpSettings), typeof(IEnumerable<string>), typeof(Guid?), typeof(NetworkProvisioningState?), typeof(bool?), typeof(string), typeof(ResourceIdentifier), typeof(IEnumerable<VirtualNetworkGatewayNatRuleData>), typeof(bool?), typeof(bool?), typeof(bool?), typeof(ExpressRouteGatewayAdminState?))]
    [CodeGenSuppress("VirtualNetworkGatewayData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType?), typeof(AzureLocation?), typeof(IDictionary<string, string>), typeof(ExtendedLocation), typeof(ETag?), typeof(ManagedServiceIdentity), typeof(VirtualNetworkGatewayAutoScaleBounds), typeof(IEnumerable<VirtualNetworkGatewayIPConfiguration>), typeof(VirtualNetworkGatewayType?), typeof(VpnType?), typeof(VpnGatewayGeneration?), typeof(bool?), typeof(bool?), typeof(bool?), typeof(bool?), typeof(ResourceIdentifier), typeof(VirtualNetworkGatewaySku), typeof(VpnClientConfiguration), typeof(IEnumerable<VirtualNetworkGatewayPolicyGroup>), typeof(BgpSettings), typeof(IEnumerable<string>), typeof(Guid?), typeof(NetworkProvisioningState?), typeof(bool?), typeof(string), typeof(ResourceIdentifier), typeof(IEnumerable<VirtualNetworkGatewayNatRuleData>), typeof(bool?), typeof(bool?), typeof(bool?), typeof(ExpressRouteGatewayAdminState?), typeof(ExpressRouteGatewayResiliencyModel?))]
    [CodeGenSuppress("VirtualNetworkGatewayData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType?), typeof(AzureLocation?), typeof(IDictionary<string, string>), typeof(ExtendedLocation), typeof(ETag?), typeof(VirtualNetworkGatewayAutoScaleBounds), typeof(IEnumerable<VirtualNetworkGatewayIPConfiguration>), typeof(VirtualNetworkGatewayType?), typeof(VpnType?), typeof(VpnGatewayGeneration?), typeof(bool?), typeof(bool?), typeof(bool?), typeof(bool?), typeof(ResourceIdentifier), typeof(VirtualNetworkGatewaySku), typeof(VpnClientConfiguration), typeof(IEnumerable<VirtualNetworkGatewayPolicyGroup>), typeof(BgpSettings), typeof(IEnumerable<string>), typeof(Guid?), typeof(NetworkProvisioningState?), typeof(bool?), typeof(string), typeof(ResourceIdentifier), typeof(IEnumerable<VirtualNetworkGatewayNatRuleData>), typeof(bool?), typeof(bool?), typeof(bool?), typeof(ExpressRouteGatewayAdminState?))]
    [CodeGenSuppress("VirtualNetworkGatewayData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType?), typeof(AzureLocation?), typeof(IDictionary<string, string>), typeof(ExtendedLocation), typeof(ETag?), typeof(ManagedServiceIdentity), typeof(VirtualNetworkGatewayAutoScaleBounds), typeof(IEnumerable<VirtualNetworkGatewayIPConfiguration>), typeof(VirtualNetworkGatewayType?), typeof(VpnType?), typeof(VpnGatewayGeneration?), typeof(bool?), typeof(bool?), typeof(VirtualNetworkGatewayMigrationStatus), typeof(bool?), typeof(bool?), typeof(bool?), typeof(ResourceIdentifier), typeof(VirtualNetworkGatewaySku), typeof(VpnClientConfiguration), typeof(IEnumerable<VirtualNetworkGatewayPolicyGroup>), typeof(BgpSettings), typeof(VirtualNetworkAddressSpace), typeof(Guid?), typeof(NetworkProvisioningState?), typeof(bool?), typeof(string), typeof(ResourceIdentifier), typeof(IEnumerable<VirtualNetworkGatewayNatRuleData>), typeof(bool?), typeof(bool?), typeof(bool?), typeof(ExpressRouteGatewayAdminState?), typeof(ExpressRouteGatewayResiliencyModel?))]
    [CodeGenSuppress("VirtualNetworkGatewayData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType?), typeof(AzureLocation?), typeof(IDictionary<string, string>), typeof(ExtendedLocation), typeof(ETag?), typeof(ManagedServiceIdentity), typeof(VirtualNetworkGatewayAutoScaleBounds), typeof(IEnumerable<VirtualNetworkGatewayIPConfiguration>), typeof(VirtualNetworkGatewayType?), typeof(VpnType?), typeof(VpnGatewayGeneration?), typeof(bool?), typeof(bool?), typeof(bool?), typeof(bool?), typeof(ResourceIdentifier), typeof(VirtualNetworkGatewaySku), typeof(VpnClientConfiguration), typeof(IEnumerable<VirtualNetworkGatewayPolicyGroup>), typeof(BgpSettings), typeof(VirtualNetworkAddressSpace), typeof(Guid?), typeof(NetworkProvisioningState?), typeof(bool?), typeof(string), typeof(ResourceIdentifier), typeof(IEnumerable<VirtualNetworkGatewayNatRuleData>), typeof(bool?), typeof(bool?), typeof(bool?), typeof(ExpressRouteGatewayAdminState?), typeof(ExpressRouteGatewayResiliencyModel?))]
    public static partial class ArmNetworkModelFactory
    {
        /// <summary> Initializes a virtual network gateway using the released flattened factory signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualNetworkGatewayData VirtualNetworkGatewayData(ResourceIdentifier id, string name, ResourceType? resourceType, AzureLocation? location, IDictionary<string, string> tags, ExtendedLocation extendedLocation, ETag? etag, IEnumerable<VirtualNetworkGatewayIPConfiguration> ipConfigurations, VirtualNetworkGatewayType? gatewayType, VpnType? vpnType, VpnGatewayGeneration? vpnGatewayGeneration, bool? enableBgp, bool? enablePrivateIPAddress, bool? active, bool? disableIPSecReplayProtection, ResourceIdentifier gatewayDefaultSiteId, VirtualNetworkGatewaySku sku, VpnClientConfiguration vpnClientConfiguration, IEnumerable<VirtualNetworkGatewayPolicyGroup> virtualNetworkGatewayPolicyGroups, BgpSettings bgpSettings, IEnumerable<string> customRoutesAddressPrefixes, Guid? resourceGuid, NetworkProvisioningState? provisioningState, bool? enableDnsForwarding, string inboundDnsForwardingEndpoint, ResourceIdentifier vNetExtendedLocationResourceId, IEnumerable<VirtualNetworkGatewayNatRuleData> natRules, bool? enableBgpRouteTranslationForNat, bool? allowVirtualWanTraffic, bool? allowRemoteVnetTraffic, ExpressRouteGatewayAdminState? adminState)
            => VirtualNetworkGatewayData(id, name, resourceType, location, tags, extendedLocation, etag, identity: default, autoScaleBounds: default,
                ipConfigurations, gatewayType, vpnType, vpnGatewayGeneration, enableBgp, enablePrivateIPAddress,
                virtualNetworkGatewayMigrationStatus: default, active, enableHighBandwidthVpnGateway: default, disableIPSecReplayProtection,
                gatewayDefaultSiteId, sku, vpnClientConfiguration, virtualNetworkGatewayPolicyGroups, bgpSettings,
                customRoutesAddressPrefixes is null ? default : new VirtualNetworkAddressSpace(customRoutesAddressPrefixes.ToList(), default, default),
                resourceGuid, provisioningState, enableDnsForwarding, inboundDnsForwardingEndpoint, vNetExtendedLocationResourceId,
                natRules, enableBgpRouteTranslationForNat, allowVirtualWanTraffic, allowRemoteVnetTraffic, adminState, resiliencyModel: default);

        /// <summary> Initializes a virtual network gateway using the legacy address-prefix factory signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualNetworkGatewayData VirtualNetworkGatewayData(ResourceIdentifier id, string name, ResourceType? resourceType, AzureLocation? location, IDictionary<string, string> tags, ExtendedLocation extendedLocation, ETag? etag, ManagedServiceIdentity identity, VirtualNetworkGatewayAutoScaleBounds autoScaleBounds, IEnumerable<VirtualNetworkGatewayIPConfiguration> ipConfigurations, VirtualNetworkGatewayType? gatewayType, VpnType? vpnType, VpnGatewayGeneration? vpnGatewayGeneration, bool? enableBgp, bool? enablePrivateIPAddress, bool? active, bool? disableIPSecReplayProtection, ResourceIdentifier gatewayDefaultSiteId, VirtualNetworkGatewaySku sku, VpnClientConfiguration vpnClientConfiguration, IEnumerable<VirtualNetworkGatewayPolicyGroup> virtualNetworkGatewayPolicyGroups, BgpSettings bgpSettings, IEnumerable<string> customRoutesAddressPrefixes, Guid? resourceGuid, NetworkProvisioningState? provisioningState, bool? enableDnsForwarding, string inboundDnsForwardingEndpoint, ResourceIdentifier vNetExtendedLocationResourceId, IEnumerable<VirtualNetworkGatewayNatRuleData> natRules, bool? enableBgpRouteTranslationForNat, bool? allowVirtualWanTraffic, bool? allowRemoteVnetTraffic, ExpressRouteGatewayAdminState? adminState, ExpressRouteGatewayResiliencyModel? resiliencyModel)
            => VirtualNetworkGatewayData(id, name, resourceType, location, tags, extendedLocation, etag, identity, autoScaleBounds,
                ipConfigurations, gatewayType, vpnType, vpnGatewayGeneration, enableBgp, enablePrivateIPAddress,
                virtualNetworkGatewayMigrationStatus: default, active, enableHighBandwidthVpnGateway: default, disableIPSecReplayProtection,
                gatewayDefaultSiteId, sku, vpnClientConfiguration, virtualNetworkGatewayPolicyGroups, bgpSettings,
                customRoutesAddressPrefixes is null ? default : new VirtualNetworkAddressSpace(customRoutesAddressPrefixes.ToList(), default, default),
                resourceGuid, provisioningState, enableDnsForwarding, inboundDnsForwardingEndpoint, vNetExtendedLocationResourceId,
                natRules, enableBgpRouteTranslationForNat, allowVirtualWanTraffic, allowRemoteVnetTraffic, adminState, resiliencyModel);

        /// <summary> Initializes a virtual network gateway using the legacy autoscale factory signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualNetworkGatewayData VirtualNetworkGatewayData(ResourceIdentifier id, string name, ResourceType? resourceType, AzureLocation? location, IDictionary<string, string> tags, ExtendedLocation extendedLocation, ETag? etag, VirtualNetworkGatewayAutoScaleBounds autoScaleBounds, IEnumerable<VirtualNetworkGatewayIPConfiguration> ipConfigurations, VirtualNetworkGatewayType? gatewayType, VpnType? vpnType, VpnGatewayGeneration? vpnGatewayGeneration, bool? enableBgp, bool? enablePrivateIPAddress, bool? active, bool? disableIPSecReplayProtection, ResourceIdentifier gatewayDefaultSiteId, VirtualNetworkGatewaySku sku, VpnClientConfiguration vpnClientConfiguration, IEnumerable<VirtualNetworkGatewayPolicyGroup> virtualNetworkGatewayPolicyGroups, BgpSettings bgpSettings, IEnumerable<string> customRoutesAddressPrefixes, Guid? resourceGuid, NetworkProvisioningState? provisioningState, bool? enableDnsForwarding, string inboundDnsForwardingEndpoint, ResourceIdentifier vNetExtendedLocationResourceId, IEnumerable<VirtualNetworkGatewayNatRuleData> natRules, bool? enableBgpRouteTranslationForNat, bool? allowVirtualWanTraffic, bool? allowRemoteVnetTraffic, ExpressRouteGatewayAdminState? adminState)
            => VirtualNetworkGatewayData(id, name, resourceType, location, tags, extendedLocation, etag, identity: default, autoScaleBounds,
                ipConfigurations, gatewayType, vpnType, vpnGatewayGeneration, enableBgp, enablePrivateIPAddress,
                virtualNetworkGatewayMigrationStatus: default, active, enableHighBandwidthVpnGateway: default, disableIPSecReplayProtection,
                gatewayDefaultSiteId, sku, vpnClientConfiguration, virtualNetworkGatewayPolicyGroups, bgpSettings,
                customRoutesAddressPrefixes is null ? default : new VirtualNetworkAddressSpace(customRoutesAddressPrefixes.ToList(), default, default),
                resourceGuid, provisioningState, enableDnsForwarding, inboundDnsForwardingEndpoint, vNetExtendedLocationResourceId,
                natRules, enableBgpRouteTranslationForNat, allowVirtualWanTraffic, allowRemoteVnetTraffic, adminState, resiliencyModel: default);

        /// <summary> Initializes a virtual network gateway using the legacy address-space factory signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualNetworkGatewayData VirtualNetworkGatewayData(ResourceIdentifier id, string name, ResourceType? resourceType, AzureLocation? location, IDictionary<string, string> tags, ExtendedLocation extendedLocation, ETag? etag, ManagedServiceIdentity identity, VirtualNetworkGatewayAutoScaleBounds autoScaleBounds, IEnumerable<VirtualNetworkGatewayIPConfiguration> ipConfigurations, VirtualNetworkGatewayType? gatewayType, VpnType? vpnType, VpnGatewayGeneration? vpnGatewayGeneration, bool? enableBgp, bool? enablePrivateIPAddress, bool? active, bool? disableIPSecReplayProtection, ResourceIdentifier gatewayDefaultSiteId, VirtualNetworkGatewaySku sku, VpnClientConfiguration vpnClientConfiguration, IEnumerable<VirtualNetworkGatewayPolicyGroup> virtualNetworkGatewayPolicyGroups, BgpSettings bgpSettings, VirtualNetworkAddressSpace customRoutes, Guid? resourceGuid, NetworkProvisioningState? provisioningState, bool? enableDnsForwarding, string inboundDnsForwardingEndpoint, ResourceIdentifier vNetExtendedLocationResourceId, IEnumerable<VirtualNetworkGatewayNatRuleData> natRules, bool? enableBgpRouteTranslationForNat, bool? allowVirtualWanTraffic, bool? allowRemoteVnetTraffic, ExpressRouteGatewayAdminState? adminState, ExpressRouteGatewayResiliencyModel? resiliencyModel)
            => VirtualNetworkGatewayData(id, name, resourceType, location, tags, extendedLocation, etag, identity, autoScaleBounds,
                ipConfigurations, gatewayType, vpnType, vpnGatewayGeneration, enableBgp, enablePrivateIPAddress,
                virtualNetworkGatewayMigrationStatus: default, active, enableHighBandwidthVpnGateway: default, disableIPSecReplayProtection,
                gatewayDefaultSiteId, sku, vpnClientConfiguration, virtualNetworkGatewayPolicyGroups, bgpSettings, customRoutes,
                resourceGuid, provisioningState, enableDnsForwarding, inboundDnsForwardingEndpoint, vNetExtendedLocationResourceId,
                natRules, enableBgpRouteTranslationForNat, allowVirtualWanTraffic, allowRemoteVnetTraffic, adminState, resiliencyModel);

        // Keep the prior generated mapping, but connect active to the renamed native constructor slot.
        /// <summary> Initializes a new instance of <see cref="Network.VirtualNetworkGatewayData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualNetworkGatewayData VirtualNetworkGatewayData(ResourceIdentifier id = default, string name = default, ResourceType? resourceType = default, AzureLocation? location = default, IDictionary<string, string> tags = default, ExtendedLocation extendedLocation = default, ETag? etag = default, ManagedServiceIdentity identity = default, VirtualNetworkGatewayAutoScaleBounds autoScaleBounds = default, IEnumerable<VirtualNetworkGatewayIPConfiguration> ipConfigurations = default, VirtualNetworkGatewayType? gatewayType = default, VpnType? vpnType = default, VpnGatewayGeneration? vpnGatewayGeneration = default, bool? enableBgp = default, bool? enablePrivateIPAddress = default, VirtualNetworkGatewayMigrationStatus virtualNetworkGatewayMigrationStatus = default, bool? active = default, bool? enableHighBandwidthVpnGateway = default, bool? disableIPSecReplayProtection = default, ResourceIdentifier gatewayDefaultSiteId = default, VirtualNetworkGatewaySku sku = default, VpnClientConfiguration vpnClientConfiguration = default, IEnumerable<VirtualNetworkGatewayPolicyGroup> virtualNetworkGatewayPolicyGroups = default, BgpSettings bgpSettings = default, VirtualNetworkAddressSpace customRoutes = default, Guid? resourceGuid = default, NetworkProvisioningState? provisioningState = default, bool? enableDnsForwarding = default, string inboundDnsForwardingEndpoint = default, ResourceIdentifier vNetExtendedLocationResourceId = default, IEnumerable<VirtualNetworkGatewayNatRuleData> natRules = default, bool? enableBgpRouteTranslationForNat = default, bool? allowVirtualWanTraffic = default, bool? allowRemoteVnetTraffic = default, ExpressRouteGatewayAdminState? adminState = default, ExpressRouteGatewayResiliencyModel? resiliencyModel = default)
        {
            return new VirtualNetworkGatewayData(
                id,
                name,
                resourceType,
                location,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                default,
                autoScaleBounds is null && ipConfigurations is null && gatewayType is null && vpnType is null && vpnGatewayGeneration is null && enableBgp is null && enablePrivateIPAddress is null && virtualNetworkGatewayMigrationStatus is null && active is null && enableHighBandwidthVpnGateway is null && disableIPSecReplayProtection is null && sku is null && vpnClientConfiguration is null && virtualNetworkGatewayPolicyGroups is null && bgpSettings is null && customRoutes is null && resourceGuid is null && provisioningState is null && enableDnsForwarding is null && inboundDnsForwardingEndpoint is null && vNetExtendedLocationResourceId is null && natRules is null && enableBgpRouteTranslationForNat is null && allowVirtualWanTraffic is null && allowRemoteVnetTraffic is null && adminState is null && resiliencyModel is null ? default : new VirtualNetworkGatewayPropertiesFormat(
                    autoScaleBounds is null ? default : new VirtualNetworkGatewayAutoScaleConfiguration(autoScaleBounds, default),
                    (ipConfigurations ?? new ChangeTrackingList<VirtualNetworkGatewayIPConfiguration>()).ToList(),
                    gatewayType,
                    vpnType,
                    vpnGatewayGeneration,
                    enableBgp,
                    enablePrivateIPAddress,
                    virtualNetworkGatewayMigrationStatus,
                    active,
                    enableHighBandwidthVpnGateway,
                    disableIPSecReplayProtection,
                    default,
                    sku,
                    vpnClientConfiguration,
                    (virtualNetworkGatewayPolicyGroups ?? new ChangeTrackingList<VirtualNetworkGatewayPolicyGroup>()).ToList(),
                    bgpSettings,
                    customRoutes,
                    resourceGuid,
                    provisioningState,
                    enableDnsForwarding,
                    inboundDnsForwardingEndpoint,
                    vNetExtendedLocationResourceId,
                    (natRules ?? new ChangeTrackingList<VirtualNetworkGatewayNatRuleData>()).ToList(),
                    enableBgpRouteTranslationForNat,
                    allowVirtualWanTraffic,
                    allowRemoteVnetTraffic,
                    adminState,
                    resiliencyModel,
                    default),
                extendedLocation,
                etag,
                identity);
        }

        // Preserve the 1.15.0 object-valued factory overload by projecting its ID to the canonical string-ID factory.
        /// <summary> Initializes load-balancer backend health using the referenced IP configuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static LoadBalancerHealthPerRulePerBackendAddress LoadBalancerHealthPerRulePerBackendAddress(string ipAddress, NetworkInterfaceIPConfigurationData networkInterfaceIPConfigurationId, string state, string reason)
            => LoadBalancerHealthPerRulePerBackendAddress(ipAddress, networkInterfaceIPConfigurationId?.Id, state, reason);

        /// <summary> Defines a managed rule set rule group with legacy string rules. </summary>
        /// <param name="ruleGroupName"> Name of the rule group. </param>
        /// <param name="rules"> Legacy string rules retained for compatibility; these values are not serialized. </param>
        /// <returns> A new <see cref="Models.ManagedRuleSetRuleGroup"/> instance for mocking. </returns>
        /// <remarks> Populate the returned model's <see cref="Models.ManagedRuleSetRuleGroup.RuleIds"/> collection to mock numeric rule identifiers. </remarks>
        public static ManagedRuleSetRuleGroup ManagedRuleSetRuleGroup(string ruleGroupName = default, IEnumerable<string> rules = default)
            => new ManagedRuleSetRuleGroup(ruleGroupName, (rules ?? new ChangeTrackingList<string>()).ToList());

        // This released legacy model has no generated factory; its constructor preserves metadata and legacy collections.
        /// <summary> Initializes a new instance of <see cref="Models.ApplicationGatewayAvailableSslOptionsInfo"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use ApplicationGatewayAvailableSslOptionsInfoData instead.")]
        public static ApplicationGatewayAvailableSslOptionsInfo ApplicationGatewayAvailableSslOptionsInfo(ResourceIdentifier id = default, string name = default, ResourceType? resourceType = default, AzureLocation? location = default, IDictionary<string, string> tags = default, IEnumerable<WritableSubResource> predefinedPolicies = default, ApplicationGatewaySslPolicyName? defaultPolicy = default, IEnumerable<ApplicationGatewaySslCipherSuite> availableCipherSuites = default, IEnumerable<ApplicationGatewaySslProtocol> availableProtocols = default)
            => new ApplicationGatewayAvailableSslOptionsInfo(id, name, resourceType, location, tags,
                predefinedPolicies, defaultPolicy, availableCipherSuites, availableProtocols);

        /// <summary> Initializes a new instance of <see cref="Models.ConnectionMonitorQueryResult"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This legacy query result is not supported by the current connection monitor API.")]
        public static ConnectionMonitorQueryResult ConnectionMonitorQueryResult(ConnectionMonitorSourceStatus? sourceStatus = default, IEnumerable<ConnectionStateSnapshot> states = default)
        {
            return new ConnectionMonitorQueryResult(sourceStatus, (states ?? Array.Empty<ConnectionStateSnapshot>()).ToList(), default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ConnectionStateSnapshot"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This legacy query snapshot is not supported by the current connection monitor API.")]
        public static ConnectionStateSnapshot ConnectionStateSnapshot(NetworkConnectionState? networkConnectionState = default, DateTimeOffset? startOn = default, DateTimeOffset? endOn = default, EvaluationState? evaluationState = default, long? avgLatencyInMs = default, long? minLatencyInMs = default, long? maxLatencyInMs = default, long? probesSent = default, long? probesFailed = default, IEnumerable<ConnectivityHopInfo> hops = default)
        {
            return new ConnectionStateSnapshot(networkConnectionState, startOn, endOn, evaluationState, avgLatencyInMs, minLatencyInMs, maxLatencyInMs, probesSent, probesFailed, (hops ?? Array.Empty<ConnectivityHopInfo>()).ToList(), default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.InboundSecurityRule"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Please use InboundSecurityRuleData instead.")]
        public static InboundSecurityRule InboundSecurityRule(ResourceIdentifier id = default, string name = default, ResourceType? resourceType = default, ETag? etag = default, IEnumerable<InboundSecurityRules> rules = default, NetworkProvisioningState? provisioningState = default)
        {
            return InboundSecurityRule(id, name, resourceType, etag, default, rules, provisioningState);
        }

        /// <summary> Initializes a new instance of <see cref="Models.InboundSecurityRule"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Please use InboundSecurityRuleData instead.")]
        public static InboundSecurityRule InboundSecurityRule(ResourceIdentifier id = default, string name = default, ResourceType? resourceType = default, ETag? etag = default, InboundSecurityRuleType? ruleType = default, IEnumerable<InboundSecurityRules> rules = default, NetworkProvisioningState? provisioningState = default)
        {
            var properties = new InboundSecurityRuleProperties(ruleType, (rules ?? Enumerable.Empty<InboundSecurityRules>()).ToList(), provisioningState, default);
            return new InboundSecurityRule(id, name, resourceType, etag, properties, default);
        }
    }
}
