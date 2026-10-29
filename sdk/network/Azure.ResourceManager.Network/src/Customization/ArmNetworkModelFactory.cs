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
    [CodeGenSuppress("VirtualNetworkApplianceData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType?), typeof(AzureLocation?), typeof(IDictionary<string, string>), typeof(ETag?), typeof(string), typeof(IEnumerable<VirtualNetworkApplianceIPConfiguration>), typeof(NetworkProvisioningState?), typeof(Guid?), typeof(SubnetData))]
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
        /// <summary> Initializes a new instance of <see cref="Network.NetworkPrivateEndpointConnectionData"/>. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="privateEndpoint"> The resource of private end point. </param>
        /// <param name="connectionState"> A collection of information about the state of the connection between service consumer and provider. </param>
        /// <param name="provisioningState"> The provisioning state of the private endpoint connection resource. </param>
        /// <param name="linkIdentifier"> The consumer link id. </param>
        /// <param name="privateEndpointLocation"> The location of the private endpoint. </param>
        /// <returns> A new <see cref="Network.NetworkPrivateEndpointConnectionData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Runtime.CompilerServices.OverloadResolutionPriority(-1)]
        public static NetworkPrivateEndpointConnectionData NetworkPrivateEndpointConnectionData(ResourceIdentifier id = null, string name = null, ResourceType? resourceType = null, ETag? etag = null, PrivateEndpointData privateEndpoint = null, NetworkPrivateLinkServiceConnectionState connectionState = null, NetworkProvisioningState? provisioningState = null, string linkIdentifier = null, string privateEndpointLocation = null)
            => NetworkPrivateEndpointConnectionData(
                id: id,
                name: name,
                resourceType: resourceType,
                privateEndpoint: privateEndpoint,
                connectionState: connectionState,
                provisioningState: provisioningState,
                linkIdentifier: linkIdentifier,
                privateEndpointLocation: privateEndpointLocation,
                eTag: etag);

        /// <summary> Initializes a new <see cref="Network.OutboundRuleData"/> instance for mocking. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Name of the resource. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="allocatedOutboundPorts"> The number of outbound ports to be used for NAT. </param>
        /// <param name="frontendIPConfigurations"> The Frontend IP addresses of the load balancer. </param>
        /// <param name="provisioningState"> The provisioning state of the outbound rule resource. </param>
        /// <param name="protocol"> The protocol for the outbound rule in load balancer. </param>
        /// <param name="enableTcpReset"> Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP. </param>
        /// <param name="idleTimeoutInMinutes"> The timeout for the TCP idle connection. </param>
        /// <param name="backendAddressPoolId"> Resource ID. </param>
        /// <param name="eTag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <returns> A new <see cref="Network.OutboundRuleData"/> instance for mocking. </returns>
        public static OutboundRuleData OutboundRuleData(ResourceIdentifier id = default, string name = default, ResourceType? resourceType = default, int? allocatedOutboundPorts = default, IEnumerable<WritableSubResource> frontendIPConfigurations = default, NetworkProvisioningState? provisioningState = default, LoadBalancerOutboundRuleProtocol? protocol = default, bool? enableTcpReset = default, int? idleTimeoutInMinutes = default, ResourceIdentifier backendAddressPoolId = default, ETag? eTag = default)
        {
            return new OutboundRuleData(
                id,
                default,
                name,
                resourceType,
                allocatedOutboundPorts is null && frontendIPConfigurations is null && backendAddressPoolId is null && provisioningState is null && protocol is null && enableTcpReset is null && idleTimeoutInMinutes is null ? default : new OutboundRulePropertiesFormat(
                    allocatedOutboundPorts,
                    (frontendIPConfigurations ?? new ChangeTrackingList<WritableSubResource>()).ToList(),
                    new NetworkSubResource(backendAddressPoolId, default),
                    provisioningState,
                    protocol.GetValueOrDefault(),
                    enableTcpReset,
                    idleTimeoutInMinutes,
                    default),
                eTag);
        }

        /// <summary> Initializes a virtual network appliance using the released string bandwidth factory signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualNetworkApplianceData VirtualNetworkApplianceData(ResourceIdentifier id = default, string name = default, ResourceType? resourceType = default, AzureLocation? location = default, IDictionary<string, string> tags = default, ETag? etag = default, string bandwidthInGbps = default, IEnumerable<VirtualNetworkApplianceIPConfiguration> ipConfigurations = default, NetworkProvisioningState? provisioningState = default, Guid? resourceGuid = default, SubnetData subnet = default)
        {
            VirtualNetworkApplianceData model = VirtualNetworkApplianceData(
                id,
                name,
                resourceType,
                location,
                tags,
                bandwidthGbps: default,
                ipConfigurations: ipConfigurations,
                privateIPAddressVersion: default,
                provisioningState: provisioningState,
                resourceGuid: resourceGuid,
                subnet: subnet,
                eTag: etag);
            model.BandwidthInGbps = bandwidthInGbps;
            return model;
        }

        /// <summary> NetworkVirtualApplianceConnection resource. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Name of the resource. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="namePropertiesName"> The name of the resource. </param>
        /// <param name="provisioningState"> The provisioning state of the NetworkVirtualApplianceConnection resource. </param>
        /// <param name="asn"> Network Virtual Appliance ASN. </param>
        /// <param name="tunnelIdentifier"> Unique identifier for the connection. </param>
        /// <param name="bgpPeerAddress"> List of bgpPeerAddresses for the NVA instances. </param>
        /// <param name="enableInternetSecurity"> Enable internet security. </param>
        /// <param name="routingConfiguration"></param>
        /// <returns> A new <see cref="Network.NetworkVirtualApplianceConnectionData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Please use the overload accepting RoutingConfiguration instead.")]
        public static NetworkVirtualApplianceConnectionData NetworkVirtualApplianceConnectionData(ResourceIdentifier id, string name, ResourceType? resourceType, string namePropertiesName, NetworkProvisioningState? provisioningState, long? asn, long? tunnelIdentifier, IEnumerable<string> bgpPeerAddress, bool? enableInternetSecurity, RoutingConfigurationNfv routingConfiguration)
        {
            return new NetworkVirtualApplianceConnectionData(id, default, name, resourceType, namePropertiesName is null && provisioningState is null && asn is null && tunnelIdentifier is null && bgpPeerAddress is null && enableInternetSecurity is null ? default : new NetworkVirtualApplianceConnectionProperties(
                namePropertiesName,
                provisioningState,
                asn,
                tunnelIdentifier,
                (bgpPeerAddress ?? new ChangeTrackingList<string>()).ToList(),
                enableInternetSecurity,
                default,
                default));
        }

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
