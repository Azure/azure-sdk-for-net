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
    /// <summary> Compatibility declaration for the ArmNetworkModelFactory type. </summary>
    [CodeGenSuppress("ApplicationGatewayAuthenticationCertificate", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(BinaryData), typeof(NetworkProvisioningState?), typeof(ETag?))]
    [CodeGenSuppress("ApplicationGatewayTrustedRootCertificate", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(BinaryData), typeof(string), typeof(NetworkProvisioningState?), typeof(ETag?))]
    [CodeGenSuppress("ApplicationGatewayTrustedClientCertificate", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(BinaryData), typeof(BinaryData), typeof(string), typeof(NetworkProvisioningState?), typeof(ETag?))]
    [CodeGenSuppress("ApplicationGatewaySslCertificate", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(BinaryData), typeof(string), typeof(BinaryData), typeof(string), typeof(ApplicationGatewayManagedHsm), typeof(NetworkProvisioningState?), typeof(ETag?))]
    [CodeGenSuppress("VpnClientRootCertificate", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(BinaryData), typeof(NetworkProvisioningState?), typeof(ETag?))]
    [CodeGenSuppress("EffectiveBaseSecurityAdminRule", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(IEnumerable<NetworkManagerSecurityGroupItem>), typeof(IEnumerable<NetworkConfigurationGroup>), typeof(string))]
    [CodeGenSuppress("PeerRouteList", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(int?))]
    [CodeGenSuppress("EffectiveNetworkSecurityGroup", typeof(ResourceIdentifier), typeof(EffectiveNetworkSecurityGroupAssociation), typeof(IEnumerable<EffectiveNetworkSecurityRule>), typeof(string))]
    // TODO: Remove this suppression when https://github.com/microsoft/typespec/issues/11846 is fixed.
    [CodeGenSuppress("EffectiveNetworkSecurityGroup", typeof(NetworkSubResource), typeof(EffectiveNetworkSecurityGroupAssociation), typeof(IEnumerable<EffectiveNetworkSecurityRule>), typeof(string))]
    // The generated factory signature includes the internal ApplicationGatewayForContainersReferenceDefinition helper type,
    // which would make a public method less accessible than one of its parameters.
    [CodeGenSuppress("WebApplicationFirewallPolicyData", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(AzureLocation?), typeof(IDictionary<string, string>), typeof(PolicySettings), typeof(IEnumerable<WebApplicationFirewallCustomRule>), typeof(IEnumerable<ApplicationGatewayData>), typeof(NetworkProvisioningState?), typeof(WebApplicationFirewallPolicyResourceState?), typeof(ManagedRulesDefinition), typeof(IEnumerable<WritableSubResource>), typeof(IEnumerable<WritableSubResource>), typeof(IEnumerable<ApplicationGatewayForContainersReferenceDefinition>), typeof(ETag?))]
    [CodeGenSuppress("WebApplicationFirewallPolicyData", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(AzureLocation?), typeof(IDictionary<string, string>), typeof(PolicySettings), typeof(IEnumerable<WebApplicationFirewallCustomRule>), typeof(IEnumerable<ApplicationGatewayData>), typeof(NetworkProvisioningState?), typeof(WebApplicationFirewallPolicyResourceState?), typeof(ManagedRulesDefinition), typeof(IEnumerable<WritableSubResource>), typeof(IEnumerable<WritableSubResource>), typeof(IEnumerable<ApplicationGatewayForContainersReferenceDefinition>), typeof(WebApplicationFirewallPolicyTier?), typeof(ETag?))]
    public static partial class ArmNetworkModelFactory
    {
        // Keep these shipped factories visible; serialization hooks otherwise cause the generator to hide them.
        /// <summary> Authentication certificates of an application gateway. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Name of the resource. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="data"> Certificate public data. </param>
        /// <param name="provisioningState"> The provisioning state of the authentication certificate resource. </param>
        /// <param name="eTag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <returns> A new <see cref="Models.ApplicationGatewayAuthenticationCertificate"/> instance for mocking. </returns>
        public static ApplicationGatewayAuthenticationCertificate ApplicationGatewayAuthenticationCertificate(ResourceIdentifier id = default, string name = default, string @type = default, BinaryData data = default, NetworkProvisioningState? provisioningState = default, ETag? eTag = default)
        {
            return new ApplicationGatewayAuthenticationCertificate(
                id,
                default,
                name,
                @type,
                data is null && provisioningState is null ? default : new ApplicationGatewayAuthenticationCertificatePropertiesFormat(data, provisioningState, default),
                eTag);
        }

        /// <summary> Trusted Root certificates of an application gateway. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Name of the resource. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="data"> Certificate public data. </param>
        /// <param name="keyVaultSecretId"> Secret Id of (base-64 encoded unencrypted pfx) 'Secret' or 'Certificate' object stored in KeyVault. </param>
        /// <param name="provisioningState"> The provisioning state of the trusted root certificate resource. </param>
        /// <param name="eTag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <returns> A new <see cref="Models.ApplicationGatewayTrustedRootCertificate"/> instance for mocking. </returns>
        public static ApplicationGatewayTrustedRootCertificate ApplicationGatewayTrustedRootCertificate(ResourceIdentifier id = default, string name = default, string @type = default, BinaryData data = default, string keyVaultSecretId = default, NetworkProvisioningState? provisioningState = default, ETag? eTag = default)
        {
            return new ApplicationGatewayTrustedRootCertificate(
                id,
                default,
                name,
                @type,
                data is null && keyVaultSecretId is null && provisioningState is null ? default : new ApplicationGatewayTrustedRootCertificatePropertiesFormat(data, keyVaultSecretId, provisioningState, default),
                eTag);
        }

        /// <summary> Trusted client certificates of an application gateway. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Name of the resource. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="data"> Certificate public data. </param>
        /// <param name="validatedCertData"> Validated certificate data. </param>
        /// <param name="clientCertIssuerDN"> Distinguished name of client certificate issuer. </param>
        /// <param name="provisioningState"> The provisioning state of the trusted client certificate resource. </param>
        /// <param name="eTag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <returns> A new <see cref="Models.ApplicationGatewayTrustedClientCertificate"/> instance for mocking. </returns>
        public static ApplicationGatewayTrustedClientCertificate ApplicationGatewayTrustedClientCertificate(ResourceIdentifier id = default, string name = default, string @type = default, BinaryData data = default, BinaryData validatedCertData = default, string clientCertIssuerDN = default, NetworkProvisioningState? provisioningState = default, ETag? eTag = default)
        {
            return new ApplicationGatewayTrustedClientCertificate(
                id,
                default,
                name,
                @type,
                data is null && validatedCertData is null && clientCertIssuerDN is null && provisioningState is null ? default : new ApplicationGatewayTrustedClientCertificatePropertiesFormat(data, validatedCertData, clientCertIssuerDN, provisioningState, default),
                eTag);
        }

        /// <summary> SSL certificates of an application gateway. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Name of the resource. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="data"> Base-64 encoded pfx certificate. Only applicable in PUT Request. </param>
        /// <param name="password"> Password for the pfx file specified in data. Only applicable in PUT request. </param>
        /// <param name="publicCertData"> Base-64 encoded Public cert data corresponding to pfx specified in data. Only applicable in GET request. </param>
        /// <param name="keyVaultSecretId"> Secret Id of (base-64 encoded unencrypted pfx) 'Secret' or 'Certificate' object stored in KeyVault. </param>
        /// <param name="hsm"> Managed HSM properties of the Application Gateway resource. </param>
        /// <param name="provisioningState"> The provisioning state of the SSL certificate resource. </param>
        /// <param name="eTag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <returns> A new <see cref="Models.ApplicationGatewaySslCertificate"/> instance for mocking. </returns>
        public static ApplicationGatewaySslCertificate ApplicationGatewaySslCertificate(ResourceIdentifier id = default, string name = default, string @type = default, BinaryData data = default, string password = default, BinaryData publicCertData = default, string keyVaultSecretId = default, ApplicationGatewayManagedHsm hsm = default, NetworkProvisioningState? provisioningState = default, ETag? eTag = default)
        {
            return new ApplicationGatewaySslCertificate(
                id,
                default,
                name,
                @type,
                data is null && password is null && publicCertData is null && keyVaultSecretId is null && hsm is null && provisioningState is null ? default : new ApplicationGatewaySslCertificatePropertiesFormat(
                    data,
                    password,
                    publicCertData,
                    keyVaultSecretId,
                    hsm,
                    provisioningState,
                    default),
                eTag);
        }

        /// <summary> VPN client root certificate of virtual network gateway. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Name of the resource. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="publicCertData"> The certificate public data. </param>
        /// <param name="provisioningState"> The provisioning state of the VPN client root certificate resource. </param>
        /// <param name="eTag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <returns> A new <see cref="Models.VpnClientRootCertificate"/> instance for mocking. </returns>
        public static VpnClientRootCertificate VpnClientRootCertificate(ResourceIdentifier id = default, string name = default, string @type = default, BinaryData publicCertData = default, NetworkProvisioningState? provisioningState = default, ETag? eTag = default)
        {
            return new VpnClientRootCertificate(
                id,
                default,
                name,
                @type,
                publicCertData is null && provisioningState is null ? default : new VpnClientRootCertificatePropertiesFormat(publicCertData, provisioningState, default),
                eTag);
        }

        // Restores the released enum-shaped factory overload and delegates it to the canonical overload that accepts
        // the Boolean IsOnlyIPv6PeeringEnabled value.
        /// <summary> Initializes a new instance of <see cref="Azure.ResourceManager.Network.HubVirtualNetworkConnectionData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is deprecated and is no longer supported by the service.")]
        public static HubVirtualNetworkConnectionData HubVirtualNetworkConnectionData(ResourceIdentifier id = default, string name = default, string @type = default, bool? allowHubToRemoteVnetTransit = default, bool? allowRemoteVnetToUseHubVnetGateways = default, bool? enableInternetSecurity = default, RoutingConfigurationNfv routingConfiguration = default, EnableOnlyIPv6PeeringState? enableOnlyIPv6Peering = default, NetworkProvisioningState? provisioningState = default, ResourceIdentifier remoteVirtualNetworkId = default, ResourceIdentifier connectionPolicyId = default, ETag? eTag = default)
        {
            bool? isOnlyIPv6PeeringEnabled = enableOnlyIPv6Peering.HasValue
                ? enableOnlyIPv6Peering.Value == EnableOnlyIPv6PeeringState.Enabled
                : default;

            return HubVirtualNetworkConnectionData(
                id,
                name,
                @type,
                allowHubToRemoteVnetTransit,
                allowRemoteVnetToUseHubVnetGateways,
                enableInternetSecurity,
                routingConfiguration,
                isOnlyIPv6PeeringEnabled,
                provisioningState,
                remoteVirtualNetworkId,
                connectionPolicyId,
                eTag);
        }

        /// <summary> Initializes a new instance of <see cref="Models.EffectiveBaseSecurityAdminRule"/>. </summary>
        /// <param name="resourceId"> Resource ID. </param>
        /// <param name="configurationDescription"> A description of the security admin configuration. </param>
        /// <param name="ruleCollectionDescription"> A description of the rule collection. </param>
        /// <param name="ruleCollectionAppliesToGroups"> Groups for which the rule collection applies. </param>
        /// <param name="ruleGroups"> Network configuration groups. </param>
        /// <param name="kind"> The effective security admin rule kind. </param>
        /// <returns> A new <see cref="Models.EffectiveBaseSecurityAdminRule"/> instance for mocking. </returns>
        public static EffectiveBaseSecurityAdminRule EffectiveBaseSecurityAdminRule(ResourceIdentifier resourceId = default, string configurationDescription = default, string ruleCollectionDescription = default, IEnumerable<NetworkManagerSecurityGroupItem> ruleCollectionAppliesToGroups = default, IEnumerable<NetworkConfigurationGroup> ruleGroups = default, string kind = default)
        {
            return new UnknownEffectiveBaseSecurityAdminRule(
                resourceId,
                configurationDescription,
                ruleCollectionDescription,
                (ruleCollectionAppliesToGroups ?? new ChangeTrackingList<NetworkManagerSecurityGroupItem>()).ToList(),
                (ruleGroups ?? new ChangeTrackingList<NetworkConfigurationGroup>()).ToList(),
                kind,
                default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ApplicationGatewayAvailableSslOptionsInfo"/>. </summary>
        public static ApplicationGatewayAvailableSslOptionsInfo ApplicationGatewayAvailableSslOptionsInfo(ResourceIdentifier id = default, string name = default, ResourceType? resourceType = default, AzureLocation? location = default, IDictionary<string, string> tags = default, IEnumerable<WritableSubResource> predefinedPolicies = default, ApplicationGatewaySslPolicyName? defaultPolicy = default, IEnumerable<ApplicationGatewaySslCipherSuite> availableCipherSuites = default, IEnumerable<ApplicationGatewaySslProtocol> availableProtocols = default)
        {
            var result = new ApplicationGatewayAvailableSslOptionsInfo();
            foreach (var item in predefinedPolicies ?? Enumerable.Empty<WritableSubResource>())
            {
                result.PredefinedPolicies.Add(item);
            }
            foreach (var item in availableCipherSuites ?? Enumerable.Empty<ApplicationGatewaySslCipherSuite>())
            {
                result.AvailableCipherSuites.Add(item);
            }
            foreach (var item in availableProtocols ?? Enumerable.Empty<ApplicationGatewaySslProtocol>())
            {
                result.AvailableProtocols.Add(item);
            }
            result.DefaultPolicy = defaultPolicy;
            return result;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ConnectionMonitorQueryResult"/>. </summary>
        public static ConnectionMonitorQueryResult ConnectionMonitorQueryResult(ConnectionMonitorSourceStatus? sourceStatus = default, IEnumerable<ConnectionStateSnapshot> states = default)
        {
            return new ConnectionMonitorQueryResult();
        }

        /// <summary> Initializes a new instance of <see cref="Models.ConnectionStateSnapshot"/>. </summary>
        public static ConnectionStateSnapshot ConnectionStateSnapshot(NetworkConnectionState? networkConnectionState = default, DateTimeOffset? startOn = default, DateTimeOffset? endOn = default, EvaluationState? evaluationState = default, long? avgLatencyInMs = default, long? minLatencyInMs = default, long? maxLatencyInMs = default, long? probesSent = default, long? probesFailed = default, IEnumerable<ConnectivityHopInfo> hops = default)
        {
            return new ConnectionStateSnapshot();
        }

        /// <summary> Initializes a new instance of <see cref="Models.InboundSecurityRule"/>. </summary>
        public static InboundSecurityRule InboundSecurityRule(ResourceIdentifier id = default, string name = default, ResourceType? resourceType = default, ETag? etag = default, IEnumerable<InboundSecurityRules> rules = default, NetworkProvisioningState? provisioningState = default)
        {
            return InboundSecurityRule(id, name, resourceType, etag, default, rules, provisioningState);
        }

        /// <summary> Initializes a new instance of <see cref="Models.InboundSecurityRule"/>. </summary>
        public static InboundSecurityRule InboundSecurityRule(ResourceIdentifier id = default, string name = default, ResourceType? resourceType = default, ETag? etag = default, InboundSecurityRuleType? ruleType = default, IEnumerable<InboundSecurityRules> rules = default, NetworkProvisioningState? provisioningState = default)
        {
            var result = new InboundSecurityRule { RuleType = ruleType };
            foreach (var item in rules ?? Enumerable.Empty<InboundSecurityRules>())
            {
                result.Rules.Add(item);
            }
            return result;
        }

        /// <summary> Initializes a new instance of <see cref="Models.PeerRoute"/>. </summary>
        public static PeerRoute PeerRoute(string network = default, string nextHop = default, string sourcePeer = default, string origin = default, string asPath = default, string localAddress = default, int? weight = default)
        {
            return new PeerRoute();
        }

        // Adds the model factory method omitted for the custom canonical shared network manager connection model.
        /// <summary> Initializes a new instance of <see cref="Azure.ResourceManager.Network.NetworkManagerConnectionData"/>. </summary>
        public static NetworkManagerConnectionData NetworkManagerConnectionData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ResourceIdentifier networkManagerId = default, ScopeConnectionState? connectionState = default, string description = default, ETag? etag = default)
        {
            var properties = new NetworkManagerConnectionProperties(networkManagerId, connectionState, description, default);
            return new NetworkManagerConnectionData(id, name, resourceType, systemData, properties, etag, default);
        }

        // Restores the released subscription-specific factory API over the canonical shared connection model.
        /// <summary> Initializes a new instance of <see cref="Azure.ResourceManager.Network.SubscriptionNetworkManagerConnectionData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Please use NetworkManagerConnectionData instead.")]
        public static SubscriptionNetworkManagerConnectionData SubscriptionNetworkManagerConnectionData(ResourceIdentifier id = default, string name = default, string type = default, string eTag = default, ResourceIdentifier networkManagerId = default, ScopeConnectionState? connectionState = default, string description = default, SystemData systemData = default)
        {
            var properties = new NetworkManagerConnectionProperties(networkManagerId, connectionState, description, default);
            return new SubscriptionNetworkManagerConnectionData(id, name, type, eTag, default, properties, systemData);
        }

        /// <summary> Initializes a new instance of <see cref="Models.PeerRouteList"/>. </summary>
        /// <param name="localAddress"> The peer's local address. </param>
        /// <param name="network"> The route's network prefix. </param>
        /// <param name="nextHop"> The route's next hop. </param>
        /// <param name="sourcePeer"> The peer this route was learned from. </param>
        /// <param name="origin"> The source this route was learned from. </param>
        /// <param name="asPath"> The route's AS path sequence. </param>
        /// <param name="weight"> The route's weight. </param>
        /// <returns> A new <see cref="Models.PeerRouteList"/> instance for mocking. </returns>
        [Obsolete("This method is obsolete and will be removed in a future release, please use `ArmNetworkModelFactory.PeerRoute` instead.", false)]
        public static PeerRouteList PeerRouteList(string localAddress = default, string network = default, string nextHop = default, string sourcePeer = default, string origin = default, string asPath = default, int? weight = default)
        {
            return new PeerRouteList(localAddress, network, nextHop, sourcePeer, origin, asPath, weight, default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.EffectiveNetworkSecurityGroup"/>. </summary>
        /// <param name="networkSecurityGroupId"> Resource ID. </param>
        /// <param name="association"> Associated resources. </param>
        /// <param name="effectiveSecurityRules"> A collection of effective security rules. </param>
        /// <param name="tagMap"> Mapping of tags to list of IP Addresses included within the tag. </param>
        /// <returns> A new <see cref="Models.EffectiveNetworkSecurityGroup"/> instance for mocking. </returns>
        public static EffectiveNetworkSecurityGroup EffectiveNetworkSecurityGroup(ResourceIdentifier networkSecurityGroupId = default, EffectiveNetworkSecurityGroupAssociation association = default, IEnumerable<EffectiveNetworkSecurityRule> effectiveSecurityRules = default, string tagMap = default)
        {
            return new EffectiveNetworkSecurityGroup(
                networkSecurityGroupId is null ? default : new NetworkSubResource(networkSecurityGroupId, default),
                association,
                (effectiveSecurityRules ?? new ChangeTrackingList<EffectiveNetworkSecurityRule>()).ToList(),
                tagMap,
                default);
        }
    }
}
