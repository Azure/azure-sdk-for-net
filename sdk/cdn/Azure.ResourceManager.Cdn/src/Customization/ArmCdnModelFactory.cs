// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Cdn.Models
{
    public static partial class ArmCdnModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Cdn.CdnEndpointData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="originPath"> A directory path on the origin that CDN can use to retrieve content from, e.g. contoso.cloudapp.net/originpath. </param>
        /// <param name="contentTypesToCompress"> List of content types on which compression applies. The value should be a valid MIME type. </param>
        /// <param name="originHostHeader"> The host header value sent to the origin with each request. </param>
        /// <param name="isCompressionEnabled"> Indicates whether content compression is enabled on CDN. </param>
        /// <param name="isHttpAllowed"> Indicates whether HTTP traffic is allowed on the endpoint. </param>
        /// <param name="isHttpsAllowed"> Indicates whether HTTPS traffic is allowed on the endpoint. </param>
        /// <param name="queryStringCachingBehavior"> Defines how CDN caches requests that include query strings. </param>
        /// <param name="optimizationType"> Specifies what scenario the customer wants this CDN endpoint to optimize for. </param>
        /// <param name="probePath"> Path to a file hosted on the origin which helps accelerate delivery of the dynamic content. </param>
        /// <param name="geoFilters"> List of rules defining the user's geo access within a CDN endpoint. </param>
        /// <param name="defaultOriginGroupId"> A reference to the origin group. </param>
        /// <param name="uriSigningKeys"> List of keys used to validate the signed URL hashes. </param>
        /// <param name="deliveryPolicy"> A policy that specifies the delivery rules to be used for an endpoint. </param>
        /// <param name="webApplicationFirewallPolicyLinkId"> Defines the Web Application Firewall policy for the endpoint (if applicable). </param>
        /// <param name="hostName"> The host name of the endpoint structured as {endpointName}.{DNSZone}. </param>
        /// <param name="origins"> The source of the content being delivered via CDN. </param>
        /// <param name="originGroups"> The origin groups comprising of origins that are used for load balancing the traffic based on availability. </param>
        /// <param name="customDomains"> The custom domains under the endpoint. </param>
        /// <param name="resourceState"> Resource status of the endpoint. </param>
        /// <param name="provisioningState"> Provisioning status of the endpoint. </param>
        /// <returns> A new <see cref="Cdn.CdnEndpointData"/> instance for mocking. </returns>
        // Backward compatibility: old API exposed CdnCustomDomainData customDomains parameter
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CdnEndpointData CdnEndpointData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string originPath = null, IEnumerable<string> contentTypesToCompress = null, string originHostHeader = null, bool? isCompressionEnabled = null, bool? isHttpAllowed = null, bool? isHttpsAllowed = null, QueryStringCachingBehavior? queryStringCachingBehavior = null, OptimizationType? optimizationType = null, string probePath = null, IEnumerable<GeoFilter> geoFilters = null, ResourceIdentifier defaultOriginGroupId = null, IEnumerable<UriSigningKey> uriSigningKeys = null, EndpointDeliveryPolicy deliveryPolicy = null, ResourceIdentifier webApplicationFirewallPolicyLinkId = null, string hostName = null, IEnumerable<DeepCreatedOrigin> origins = null, IEnumerable<DeepCreatedOriginGroup> originGroups = null, IEnumerable<CdnCustomDomainData> customDomains = null, EndpointResourceState? resourceState = null, CdnEndpointProvisioningState? provisioningState = null)
        {
            return CdnEndpointData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                originPath: originPath,
                contentTypesToCompress: contentTypesToCompress,
                originHostHeader: originHostHeader,
                isCompressionEnabled: isCompressionEnabled,
                isHttpAllowed: isHttpAllowed,
                isHttpsAllowed: isHttpsAllowed,
                queryStringCachingBehavior: queryStringCachingBehavior,
                optimizationType: optimizationType,
                probePath: probePath,
                geoFilters: geoFilters,
                defaultOriginGroupId: defaultOriginGroupId,
                uriSigningKeys: uriSigningKeys,
                deliveryPolicy: deliveryPolicy,
                webApplicationFirewallPolicyLinkId: webApplicationFirewallPolicyLinkId,
                hostName: hostName,
                origins: origins,
                originGroups: originGroups,
                deepCreatedCustomDomains: default,
                resourceState: resourceState,
                provisioningState: provisioningState);
        }

        /// <summary> Initializes a new instance of <see cref="Models.CanMigrateResult"/>. </summary>
        /// <param name="Id"> Resource ID, String. </param>
        /// <param name="canMigrateResultType"> Resource type. </param>
        /// <param name="canMigrate"> Flag that says if the profile can be migrated. </param>
        /// <param name="defaultSku"> Recommended sku for the migration. </param>
        /// <param name="errors"> Errors. </param>
        /// <returns> A new <see cref="Models.CanMigrateResult"/> instance for mocking. </returns>
        // Backward compatibility: old API used string Id parameter
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CanMigrateResult CanMigrateResult(string Id = null, string canMigrateResultType = null, bool? canMigrate = null, CanMigrateDefaultSku? defaultSku = null, IEnumerable<MigrationErrorType> errors = null)
        {
            var resourceId = Id != null ? new ResourceIdentifier(Id) : null;
            return CanMigrateResult(resourceId, canMigrateResultType, canMigrate, defaultSku, errors);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MigrateResult"/>. </summary>
        /// <param name="Id"> Resource ID. </param>
        /// <param name="migrateResultType"> Resource type. </param>
        /// <param name="migratedProfileResourceIdId"> Arm resource id of the migrated profile. </param>
        /// <returns> A new <see cref="Models.MigrateResult"/> instance for mocking. </returns>
        // Backward compatibility: old API used string Id parameter
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MigrateResult MigrateResult(string Id = null, string migrateResultType = null, ResourceIdentifier migratedProfileResourceIdId = null)
        {
            var resourceId = Id != null ? new ResourceIdentifier(Id) : null;
            return MigrateResult(resourceId, migrateResultType, migratedProfileResourceIdId);
        }
    }
}
