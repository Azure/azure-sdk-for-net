// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.DnsResolver;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver.Models
{
    // Justification: the TypeSpec migration changed the generated model-factory overload set and
    // parameter ordering compared to the released AutoRest SDK. These forwarding overloads keep the
    // old signatures available so existing customer code continues to compile unchanged.
    public static partial class ArmDnsResolverModelFactory
    {
        // Backward-compatibility shims: preserve the AutoRest model factory overloads
        // whose parameter order changed in the TypeSpec-generated surface.

        /// <summary>
        /// Creates a <see cref="Azure.ResourceManager.DnsResolver.DnsForwardingRuleData"/> instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsForwardingRuleData DnsForwardingRuleData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, string domainName, IEnumerable<TargetDnsServer> targetDnsServers, IDictionary<string, string> metadata, DnsForwardingRuleState? dnsForwardingRuleState, DnsResolverProvisioningState? provisioningState)
        {
            return new DnsForwardingRuleData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                domainName is null && targetDnsServers is null && metadata is null && dnsForwardingRuleState is null && provisioningState is null
                    ? default
                    : new ForwardingRuleProperties(
                        domainName,
                        (targetDnsServers ?? new ChangeTrackingList<TargetDnsServer>()).ToList(),
                        metadata,
                        dnsForwardingRuleState,
                        provisioningState,
                        null),
                etag);
        }

        /// <summary>
        /// Creates a <see cref="Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData"/> instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsForwardingRulesetData DnsForwardingRulesetData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, IEnumerable<WritableSubResource> dnsResolverOutboundEndpoints, DnsResolverProvisioningState? provisioningState, Guid? resourceGuid)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new DnsForwardingRulesetData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                dnsResolverOutboundEndpoints is null && provisioningState is null && resourceGuid is null
                    ? default
                    : new DnsForwardingRulesetProperties(
                        (dnsResolverOutboundEndpoints ?? new ChangeTrackingList<WritableSubResource>()).ToList(),
                        provisioningState,
                        resourceGuid,
                        null),
                name,
                etag);
        }

        /// <summary>
        /// Creates a <see cref="Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData"/> instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsForwardingRulesetVirtualNetworkLinkData DnsForwardingRulesetVirtualNetworkLinkData(WritableSubResource virtualNetwork)
        {
            return new DnsForwardingRulesetVirtualNetworkLinkData(virtualNetwork);
        }

        /// <summary>
        /// Creates a <see cref="Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData"/> instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsForwardingRulesetVirtualNetworkLinkData DnsForwardingRulesetVirtualNetworkLinkData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, ResourceIdentifier virtualNetworkId, IDictionary<string, string> metadata, DnsResolverProvisioningState? provisioningState)
        {
            return new DnsForwardingRulesetVirtualNetworkLinkData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                metadata is null && provisioningState is null && virtualNetworkId is null
                    ? default
                    : new VirtualNetworkLinkProperties(virtualNetworkId is null ? default : new SubResource(virtualNetworkId, null), metadata, provisioningState, null),
                etag);
        }

        /// <summary>
        /// Creates a <see cref="Azure.ResourceManager.DnsResolver.DnsResolverData"/> instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsResolverData DnsResolverData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, DnsResolverState? dnsResolverState = default, DnsResolverProvisioningState? provisioningState = default, Guid? resourceGuid = default, WritableSubResource virtualNetwork = default, ETag? etag = default)
        {
            return DnsResolverData(id, name, resourceType, systemData, tags, location, etag, virtualNetwork?.Id, dnsResolverState, provisioningState, resourceGuid);
        }

        /// <summary>
        /// Creates a <see cref="Azure.ResourceManager.DnsResolver.DnsResolverData"/> instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsResolverData DnsResolverData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, ResourceIdentifier virtualNetworkId, DnsResolverState? dnsResolverState, DnsResolverProvisioningState? provisioningState, Guid? resourceGuid)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new DnsResolverData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                dnsResolverState is null && provisioningState is null && resourceGuid is null && virtualNetworkId is null
                    ? default
                    : new DnsResolverProperties(virtualNetworkId is null ? default : new SubResource(virtualNetworkId, null), dnsResolverState, provisioningState, resourceGuid, null),
                etag);
        }

        /// <summary>
        /// Creates a <see cref="Azure.ResourceManager.DnsResolver.DnsResolverDomainListData"/> instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsResolverDomainListData DnsResolverDomainListData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, IEnumerable<string> domains, Uri domainsUri, DnsResolverProvisioningState? provisioningState, Guid? resourceGuid)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new DnsResolverDomainListData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                domains is null && domainsUri is null && provisioningState is null && resourceGuid is null
                    ? default
                    : new DnsResolverDomainListProperties((domains ?? new ChangeTrackingList<string>()).ToList(), domainsUri, provisioningState, resourceGuid, null),
                etag);
        }

        /// <summary>
        /// Creates a <see cref="Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData"/> instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsResolverInboundEndpointData DnsResolverInboundEndpointData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, IEnumerable<InboundEndpointIPConfiguration> ipConfigurations, DnsResolverProvisioningState? provisioningState, Guid? resourceGuid)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new DnsResolverInboundEndpointData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                ipConfigurations is null && provisioningState is null && resourceGuid is null
                    ? default
                    : new InboundEndpointProperties((ipConfigurations ?? new ChangeTrackingList<InboundEndpointIPConfiguration>()).ToList(), provisioningState, resourceGuid, null),
                etag);
        }

        /// <summary>
        /// Creates a <see cref="Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData"/> instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsResolverOutboundEndpointData DnsResolverOutboundEndpointData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, DnsResolverProvisioningState? provisioningState = default, Guid? resourceGuid = default, WritableSubResource subnet = default, ETag? etag = default)
        {
            return DnsResolverOutboundEndpointData(id, name, resourceType, systemData, tags, location, etag, subnet?.Id, provisioningState, resourceGuid);
        }

        /// <summary>
        /// Creates a <see cref="Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData"/> instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsResolverOutboundEndpointData DnsResolverOutboundEndpointData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, ResourceIdentifier subnetId, DnsResolverProvisioningState? provisioningState, Guid? resourceGuid)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new DnsResolverOutboundEndpointData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                provisioningState is null && resourceGuid is null && subnetId is null
                    ? default
                    : new OutboundEndpointProperties(subnetId is null ? default : new SubResource(subnetId, null), provisioningState, resourceGuid, null),
                etag);
        }

        /// <summary>
        /// Creates a <see cref="Azure.ResourceManager.DnsResolver.DnsResolverPolicyData"/> instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsResolverPolicyData DnsResolverPolicyData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, DnsResolverProvisioningState? provisioningState, Guid? resourceGuid)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new DnsResolverPolicyData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                provisioningState is null && resourceGuid is null ? default : new DnsResolverPolicyProperties(provisioningState, resourceGuid, null),
                etag);
        }

        /// <summary>
        /// Creates a <see cref="Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData"/> instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsResolverPolicyVirtualNetworkLinkData DnsResolverPolicyVirtualNetworkLinkData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, DnsResolverProvisioningState? provisioningState = default, WritableSubResource virtualNetwork = default, ETag? etag = default)
        {
            return DnsResolverPolicyVirtualNetworkLinkData(id, name, resourceType, systemData, tags, location, etag, virtualNetwork?.Id, provisioningState);
        }

        /// <summary>
        /// Creates a <see cref="Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData"/> instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsResolverPolicyVirtualNetworkLinkData DnsResolverPolicyVirtualNetworkLinkData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, ResourceIdentifier virtualNetworkId, DnsResolverProvisioningState? provisioningState)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new DnsResolverPolicyVirtualNetworkLinkData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                provisioningState is null && virtualNetworkId is null ? default : new DnsResolverPolicyVirtualNetworkLinkProperties(virtualNetworkId is null ? default : new SubResource(virtualNetworkId, null), provisioningState, null),
                etag);
        }

        /// <summary>
        /// Creates a <see cref="Azure.ResourceManager.DnsResolver.DnsSecurityRuleData"/> instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsSecurityRuleData DnsSecurityRuleData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, int priority, DnsSecurityRuleActionType? actionType, IEnumerable<WritableSubResource> dnsResolverDomainLists, DnsSecurityRuleState? dnsSecurityRuleState, DnsResolverProvisioningState? provisioningState)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new DnsSecurityRuleData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                new DnsSecurityRuleProperties(
                    priority,
                    new DnsSecurityRuleAction(actionType, null),
                    (dnsResolverDomainLists ?? new ChangeTrackingList<WritableSubResource>()).ToList(),
                    new ChangeTrackingList<ManagedDomainList>().ToList(),
                    dnsSecurityRuleState,
                    provisioningState,
                    null),
                etag);
        }
    }
}
