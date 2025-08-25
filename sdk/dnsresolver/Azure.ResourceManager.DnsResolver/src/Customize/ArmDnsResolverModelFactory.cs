// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver.Models
{
    // TO-DO: this is a workaround as TypeSpec changes the order of resource properties, we should remove this file after we move to MPG
    /// <summary> Model factory for models. </summary>
    public static partial class ArmDnsResolverModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="DnsResolver.DnsForwardingRuleData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> "If etag is provided in the response body, it may also be provided as a header per the normal etag convention.  Entity tags are used for comparing two or more entities from the same requested resource. HTTP/1.1 uses entity tags in the etag (section 14.19), If-Match (section 14.24), If-None-Match (section 14.26), and If-Range (section 14.27) header fields."). </param>
        /// <param name="domainName"> The domain name for the forwarding rule. </param>
        /// <param name="targetDnsServers"> DNS servers to forward the DNS query to. </param>
        /// <param name="metadata"> Metadata attached to the forwarding rule. </param>
        /// <param name="dnsForwardingRuleState"> The state of forwarding rule. </param>
        /// <param name="provisioningState"> The current provisioning state of the forwarding rule. This is a read-only property and any attempt to set this value will be ignored. </param>
        /// <returns> A new <see cref="DnsResolver.DnsForwardingRuleData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsForwardingRuleData DnsForwardingRuleData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, string domainName, IEnumerable<TargetDnsServer> targetDnsServers, IDictionary<string, string> metadata, DnsForwardingRuleState? dnsForwardingRuleState, DnsResolverProvisioningState? provisioningState)
        {
            // Forward to the new signature with etag at the end
            return DnsForwardingRuleData(id, name, resourceType, systemData, domainName, targetDnsServers, metadata, dnsForwardingRuleState, provisioningState, etag);
        }

        /// <summary> Initializes a new instance of <see cref="DnsResolver.DnsForwardingRulesetData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> "If etag is provided in the response body, it may also be provided as a header per the normal etag convention.  Entity tags are used for comparing two or more entities from the same requested resource. HTTP/1.1 uses entity tags in the etag (section 14.19), If-Match (section 14.24), If-None-Match (section 14.26), and If-Range (section 14.27) header fields."). </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="dnsResolverOutboundEndpoints"> The reference to the DNS resolver outbound endpoints that are used to route DNS queries matching the forwarding rules in the ruleset to the target DNS servers. </param>
        /// <param name="provisioningState"> The current provisioning state of the DNS forwarding ruleset. This is a read-only property and any attempt to set this value will be ignored. </param>
        /// <param name="resourceGuid"> The resourceGuid for the DNS forwarding ruleset. </param>
        /// <returns> A new <see cref="DnsResolver.DnsForwardingRulesetData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsForwardingRulesetData DnsForwardingRulesetData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, IDictionary<string, string> tags, AzureLocation location, IEnumerable<WritableSubResource> dnsResolverOutboundEndpoints, DnsResolverProvisioningState? provisioningState, Guid? resourceGuid)
        {
            // Forward to the new signature with etag at the end
            return DnsForwardingRulesetData(id, name, resourceType, systemData, tags, location, dnsResolverOutboundEndpoints, provisioningState, resourceGuid, etag);
        }

        /// <summary> Initializes a new instance of <see cref="DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> "If etag is provided in the response body, it may also be provided as a header per the normal etag convention.  Entity tags are used for comparing two or more entities from the same requested resource. HTTP/1.1 uses entity tags in the etag (section 14.19), If-Match (section 14.24), If-None-Match (section 14.26), and If-Range (section 14.27) header fields."). </param>
        /// <param name="virtualNetworkId"> The reference to the virtual network. This cannot be changed after creation. </param>
        /// <param name="metadata"> Metadata attached to the virtual network link. </param>
        /// <param name="provisioningState"> The current provisioning state of the virtual network link. This is a read-only property and any attempt to set this value will be ignored. </param>
        /// <returns> A new <see cref="DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsForwardingRulesetVirtualNetworkLinkData DnsForwardingRulesetVirtualNetworkLinkData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, ResourceIdentifier virtualNetworkId, IDictionary<string, string> metadata, DnsResolverProvisioningState? provisioningState)
        {
            // Forward to the new signature with etag at the end
            return DnsForwardingRulesetVirtualNetworkLinkData(id, name, resourceType, systemData, virtualNetworkId, metadata, provisioningState, etag);
        }

        /// <summary> Initializes a new instance of <see cref="DnsResolver.DnsResolverData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> "If etag is provided in the response body, it may also be provided as a header per the normal etag convention.  Entity tags are used for comparing two or more entities from the same requested resource. HTTP/1.1 uses entity tags in the etag (section 14.19), If-Match (section 14.24), If-None-Match (section 14.26), and If-Range (section 14.27) header fields."). </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="virtualNetworkId"> The reference to the virtual network. This cannot be changed after creation. </param>
        /// <param name="dnsResolverState"> The current status of the DNS resolver. This is a read-only property and any attempt to set this value will be ignored. </param>
        /// <param name="provisioningState"> The current provisioning state of the DNS resolver. This is a read-only property and any attempt to set this value will be ignored. </param>
        /// <param name="resourceGuid"> The resourceGuid property of the DNS resolver resource. </param>
        /// <returns> A new <see cref="DnsResolver.DnsResolverData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsResolverData DnsResolverData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, IDictionary<string, string> tags, AzureLocation location, ResourceIdentifier virtualNetworkId, DnsResolverState? dnsResolverState, DnsResolverProvisioningState? provisioningState, Guid? resourceGuid)
        {
            // Forward to the new signature with etag at the end
            return DnsResolverData(id, name, resourceType, systemData, tags, location, virtualNetworkId, dnsResolverState, provisioningState, resourceGuid, etag);
        }

        /// <summary> Initializes a new instance of <see cref="DnsResolver.DnsResolverDomainListData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> "If etag is provided in the response body, it may also be provided as a header per the normal etag convention.  Entity tags are used for comparing two or more entities from the same requested resource. HTTP/1.1 uses entity tags in the etag (section 14.19), If-Match (section 14.24), If-None-Match (section 14.26), and If-Range (section 14.27) header fields."). </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="domains"> The domains in the domain list. Will be null if user is using large domain list. </param>
        /// <param name="domainsUri"> The URL for bulk upload or download for domain lists containing larger set of domains. This will be populated if domains is empty or null. </param>
        /// <param name="provisioningState"> The current provisioning state of the DNS resolver domain list. This is a read-only property and any attempt to set this value will be ignored. </param>
        /// <param name="resourceGuid"> The resourceGuid property of the DNS resolver domain list resource. </param>
        /// <returns> A new <see cref="DnsResolver.DnsResolverDomainListData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsResolverDomainListData DnsResolverDomainListData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, IDictionary<string, string> tags, AzureLocation location, IEnumerable<string> domains, Uri domainsUri, DnsResolverProvisioningState? provisioningState, Guid? resourceGuid)
        {
            // Forward to the new signature with etag at the end
            return DnsResolverDomainListData(id, name, resourceType, systemData, tags, location, domains, domainsUri, provisioningState, resourceGuid, etag);
        }

        /// <summary> Initializes a new instance of <see cref="DnsResolver.DnsResolverInboundEndpointData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> "If etag is provided in the response body, it may also be provided as a header per the normal etag convention.  Entity tags are used for comparing two or more entities from the same requested resource. HTTP/1.1 uses entity tags in the etag (section 14.19), If-Match (section 14.24), If-None-Match (section 14.26), and If-Range (section 14.27) header fields."). </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="ipConfigurations"> IP configurations for the inbound endpoint. </param>
        /// <param name="provisioningState"> The current provisioning state of the inbound endpoint. This is a read-only property and any attempt to set this value will be ignored. </param>
        /// <param name="resourceGuid"> The resourceGuid property of the inbound endpoint resource. </param>
        /// <returns> A new <see cref="DnsResolver.DnsResolverInboundEndpointData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsResolverInboundEndpointData DnsResolverInboundEndpointData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, IDictionary<string, string> tags, AzureLocation location, IEnumerable<InboundEndpointIPConfiguration> ipConfigurations, DnsResolverProvisioningState? provisioningState, Guid? resourceGuid)
        {
            // Forward to the new signature with etag at the end
            return DnsResolverInboundEndpointData(id, name, resourceType, systemData, tags, location, ipConfigurations, provisioningState, resourceGuid, etag);
        }

        /// <summary> Initializes a new instance of <see cref="DnsResolver.DnsResolverOutboundEndpointData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> "If etag is provided in the response body, it may also be provided as a header per the normal etag convention.  Entity tags are used for comparing two or more entities from the same requested resource. HTTP/1.1 uses entity tags in the etag (section 14.19), If-Match (section 14.24), If-None-Match (section 14.26), and If-Range (section 14.27) header fields."). </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="subnetId"> The reference to the subnet used for the outbound endpoint. </param>
        /// <param name="provisioningState"> The current provisioning state of the outbound endpoint. This is a read-only property and any attempt to set this value will be ignored. </param>
        /// <param name="resourceGuid"> The resourceGuid property of the outbound endpoint resource. </param>
        /// <returns> A new <see cref="DnsResolver.DnsResolverOutboundEndpointData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsResolverOutboundEndpointData DnsResolverOutboundEndpointData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, IDictionary<string, string> tags, AzureLocation location, ResourceIdentifier subnetId, DnsResolverProvisioningState? provisioningState, Guid? resourceGuid)
        {
            // Forward to the new signature with etag at the end
            return DnsResolverOutboundEndpointData(id, name, resourceType, systemData, tags, location, subnetId, provisioningState, resourceGuid, etag);
        }

        /// <summary> Initializes a new instance of <see cref="DnsResolver.DnsResolverPolicyData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> "If etag is provided in the response body, it may also be provided as a header per the normal etag convention.  Entity tags are used for comparing two or more entities from the same requested resource. HTTP/1.1 uses entity tags in the etag (section 14.19), If-Match (section 14.24), If-None-Match (section 14.26), and If-Range (section 14.27) header fields."). </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="provisioningState"> The current provisioning state of the DNS resolver policy. This is a read-only property and any attempt to set this value will be ignored. </param>
        /// <param name="resourceGuid"> The resourceGuid property of the DNS resolver policy resource. </param>
        /// <returns> A new <see cref="DnsResolver.DnsResolverPolicyData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsResolverPolicyData DnsResolverPolicyData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, IDictionary<string, string> tags, AzureLocation location, DnsResolverProvisioningState? provisioningState, Guid? resourceGuid)
        {
            // Forward to the new signature with etag at the end
            return DnsResolverPolicyData(id, name, resourceType, systemData, tags, location, provisioningState, resourceGuid, etag);
        }

        /// <summary> Initializes a new instance of <see cref="DnsResolver.DnsResolverPolicyVirtualNetworkLinkData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> "If etag is provided in the response body, it may also be provided as a header per the normal etag convention.  Entity tags are used for comparing two or more entities from the same requested resource. HTTP/1.1 uses entity tags in the etag (section 14.19), If-Match (section 14.24), If-None-Match (section 14.26), and If-Range (section 14.27) header fields."). </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="virtualNetworkId"> The reference to the virtual network. This cannot be changed after creation. </param>
        /// <param name="provisioningState"> The current provisioning state of the DNS resolver policy virtual network link. This is a read-only property and any attempt to set this value will be ignored. </param>
        /// <returns> A new <see cref="DnsResolver.DnsResolverPolicyVirtualNetworkLinkData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsResolverPolicyVirtualNetworkLinkData DnsResolverPolicyVirtualNetworkLinkData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, IDictionary<string, string> tags, AzureLocation location, ResourceIdentifier virtualNetworkId, DnsResolverProvisioningState? provisioningState)
        {
            // Forward to the new signature with etag at the end
            return DnsResolverPolicyVirtualNetworkLinkData(id, name, resourceType, systemData, tags, location, virtualNetworkId, provisioningState, etag);
        }

        /// <summary> Initializes a new instance of <see cref="DnsResolver.DnsSecurityRuleData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> "If etag is provided in the response body, it may also be provided as a header per the normal etag convention.  Entity tags are used for comparing two or more entities from the same requested resource. HTTP/1.1 uses entity tags in the etag (section 14.19), If-Match (section 14.24), If-None-Match (section 14.26), and If-Range (section 14.27) header fields."). </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="priority"> The priority of the DNS security rule. </param>
        /// <param name="actionType"> The action to take on DNS requests that match the DNS security rule. </param>
        /// <param name="dnsResolverDomainLists"> DNS resolver policy domains lists that the DNS security rule applies to. </param>
        /// <param name="dnsSecurityRuleState"> The state of DNS security rule. </param>
        /// <param name="provisioningState"> The current provisioning state of the DNS security rule. This is a read-only property and any attempt to set this value will be ignored. </param>
        /// <returns> A new <see cref="DnsResolver.DnsSecurityRuleData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DnsSecurityRuleData DnsSecurityRuleData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, IDictionary<string, string> tags, AzureLocation location, int priority, DnsSecurityRuleActionType? actionType, IEnumerable<WritableSubResource> dnsResolverDomainLists, DnsSecurityRuleState? dnsSecurityRuleState, DnsResolverProvisioningState? provisioningState)
        {
            // Forward to the new signature with etag at the end
            return DnsSecurityRuleData(id, name, resourceType, systemData, tags, location, priority, actionType, dnsResolverDomainLists, dnsSecurityRuleState, provisioningState, etag);
        }
    }
}
