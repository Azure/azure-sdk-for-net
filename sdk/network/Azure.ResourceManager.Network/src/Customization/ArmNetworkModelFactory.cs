// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
    [CodeGenSuppress("EffectiveBaseSecurityAdminRule", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(IEnumerable<NetworkManagerSecurityGroupItem>), typeof(IEnumerable<NetworkConfigurationGroup>), typeof(string))]
    [CodeGenSuppress("PeerRouteList", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(int?))]
    [CodeGenSuppress("EffectiveNetworkSecurityGroup", typeof(ResourceIdentifier), typeof(EffectiveNetworkSecurityGroupAssociation), typeof(IEnumerable<EffectiveNetworkSecurityRule>), typeof(string))]
    [CodeGenSuppress("PublicIPPrefixData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType?), typeof(AzureLocation?), typeof(IDictionary<string, string>), typeof(ExtendedLocation), typeof(PublicIPPrefixSku), typeof(ETag?), typeof(IEnumerable<string>), typeof(NetworkIPVersion?), typeof(IEnumerable<IPTag>), typeof(int?), typeof(string), typeof(IEnumerable<SubResource>), typeof(ResourceIdentifier), typeof(ResourceIdentifier), typeof(Guid?), typeof(NetworkProvisioningState?), typeof(NatGatewayData))]
    // The generated factory signature includes the internal ApplicationGatewayForContainersReferenceDefinition helper type,
    // which would make a public method less accessible than one of its parameters.
    [CodeGenSuppress("WebApplicationFirewallPolicyData", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(AzureLocation?), typeof(IDictionary<string, string>), typeof(PolicySettings), typeof(IEnumerable<WebApplicationFirewallCustomRule>), typeof(IEnumerable<ApplicationGatewayData>), typeof(NetworkProvisioningState?), typeof(WebApplicationFirewallPolicyResourceState?), typeof(ManagedRulesDefinition), typeof(IEnumerable<WritableSubResource>), typeof(IEnumerable<WritableSubResource>), typeof(IEnumerable<ApplicationGatewayForContainersReferenceDefinition>), typeof(ETag?))]
    public static partial class ArmNetworkModelFactory
    {
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

        /// <summary> Initializes a new instance of <see cref="Network.PublicIPPrefixData"/>. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="extendedLocation"> The extended location of the public ip address. </param>
        /// <param name="sku"> The public IP prefix SKU. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="zones"> A list of availability zones denoting the IP allocated for the resource needs to come from. </param>
        /// <param name="publicIPAddressVersion"> The public IP address version. </param>
        /// <param name="ipTags"> The list of tags associated with the public IP prefix. </param>
        /// <param name="prefixLength"> The Length of the Public IP Prefix. </param>
        /// <param name="ipPrefix"> The allocated Prefix. </param>
        /// <param name="publicIPAddresses"> The list of all referenced PublicIPAddresses. </param>
        /// <param name="loadBalancerFrontendIPConfigurationId"> The reference to load balancer frontend IP configuration associated with the public IP prefix. </param>
        /// <param name="customIPPrefixId"> The customIpPrefix that this prefix is associated with. </param>
        /// <param name="resourceGuid"> The resource GUID property of the public IP prefix resource. </param>
        /// <param name="provisioningState"> The provisioning state of the public IP prefix resource. </param>
        /// <param name="natGateway"> NatGateway of Public IP Prefix. </param>
        /// <returns> A new <see cref="Network.PublicIPPrefixData"/> instance for mocking. </returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static PublicIPPrefixData PublicIPPrefixData(ResourceIdentifier id = default, string name = default, ResourceType? resourceType = default, AzureLocation? location = default, IDictionary<string, string> tags = default, ExtendedLocation extendedLocation = default, PublicIPPrefixSku sku = default, ETag? etag = default, IEnumerable<string> zones = default, NetworkIPVersion? publicIPAddressVersion = default, IEnumerable<IPTag> ipTags = default, int? prefixLength = default, string ipPrefix = default, IEnumerable<SubResource> publicIPAddresses = default, ResourceIdentifier loadBalancerFrontendIPConfigurationId = default, ResourceIdentifier customIPPrefixId = default, Guid? resourceGuid = default, NetworkProvisioningState? provisioningState = default, NatGatewayData natGateway = default)
        {
            return new PublicIPPrefixData(
                id,
                name,
                default,
                location,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                default,
                publicIPAddressVersion is null && ipTags is null && prefixLength is null && ipPrefix is null && publicIPAddresses is null && loadBalancerFrontendIPConfigurationId is null && customIPPrefixId is null && resourceGuid is null && provisioningState is null && natGateway is null ? default : new PublicIPPrefixPropertiesFormat(
                    publicIPAddressVersion,
                    (ipTags ?? new ChangeTrackingList<IPTag>()).ToList(),
                    prefixLength,
                    ipPrefix,
                    (publicIPAddresses ?? Enumerable.Empty<SubResource>()).Select(item => item is null ? default : new ReferencedPublicIpAddress(item.Id?.ToString(), default)).ToList(),
                    new NetworkSubResource(loadBalancerFrontendIPConfigurationId, default),
                    new NetworkSubResource(customIPPrefixId, default),
                    resourceGuid,
                    provisioningState,
                    natGateway,
                    default,
                    default),
                extendedLocation,
                sku,
                etag,
                (zones ?? new ChangeTrackingList<string>()).ToList());
        }

        /// <summary> Initializes a new instance of <see cref="Models.PeerRoute"/>. </summary>
        public static PeerRoute PeerRoute(string network = default, string nextHop = default, string sourcePeer = default, string origin = default, string asPath = default, string localAddress = default, int? weight = default)
        {
            return new PeerRoute();
        }

        /// <summary> Initializes a new instance of <see cref="Network.NetworkManagerConnectionData"/>. </summary>
        public static NetworkManagerConnectionData NetworkManagerConnectionData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ResourceIdentifier networkManagerId = default, ScopeConnectionState? connectionState = default, string description = default, ETag? etag = default)
        {
            return new NetworkManagerConnectionData
            {
                NetworkManagerId = networkManagerId,
                Description = description
            };
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
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release, please use `ArmNetworkModelFactory.PeerRoute` instead.", false)]
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
