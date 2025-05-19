// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
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
        /// <param name="originHostHeader"> The host header value sent to the origin with each request. This property at Endpoint is only allowed when endpoint uses single origin and can be overridden by the same property specified at origin.If you leave this blank, the request hostname determines this value. Azure CDN origins, such as Web Apps, Blob Storage, and Cloud Services require this host header value to match the origin hostname by default. </param>
        /// <param name="isCompressionEnabled"> Indicates whether content compression is enabled on CDN. Default value is false. If compression is enabled, content will be served as compressed if user requests for a compressed version. Content won't be compressed on CDN when requested content is smaller than 1 byte or larger than 1 MB. </param>
        /// <param name="isHttpAllowed"> Indicates whether HTTP traffic is allowed on the endpoint. Default value is true. At least one protocol (HTTP or HTTPS) must be allowed. </param>
        /// <param name="isHttpsAllowed"> Indicates whether HTTPS traffic is allowed on the endpoint. Default value is true. At least one protocol (HTTP or HTTPS) must be allowed. </param>
        /// <param name="queryStringCachingBehavior"> Defines how CDN caches requests that include query strings. You can ignore any query strings when caching, bypass caching to prevent requests that contain query strings from being cached, or cache every request with a unique URL. </param>
        /// <param name="optimizationType"> Specifies what scenario the customer wants this CDN endpoint to optimize for, e.g. Download, Media services. With this information, CDN can apply scenario driven optimization. </param>
        /// <param name="probePath"> Path to a file hosted on the origin which helps accelerate delivery of the dynamic content and calculate the most optimal routes for the CDN. This is relative to the origin path. This property is only relevant when using a single origin. </param>
        /// <param name="geoFilters"> List of rules defining the user's geo access within a CDN endpoint. Each geo filter defines an access rule to a specified path or content, e.g. block APAC for path /pictures/. </param>
        /// <param name="defaultOriginGroupId"> A reference to the origin group. </param>
        /// <param name="uriSigningKeys"> List of keys used to validate the signed URL hashes. </param>
        /// <param name="deliveryPolicy"> A policy that specifies the delivery rules to be used for an endpoint. </param>
        /// <param name="webApplicationFirewallPolicyLinkId"> Defines the Web Application Firewall policy for the endpoint (if applicable). </param>
        /// <param name="hostName"> The host name of the endpoint structured as {endpointName}.{DNSZone}, e.g. contoso.azureedge.net. </param>
        /// <param name="origins"> The source of the content being delivered via CDN. </param>
        /// <param name="originGroups"> The origin groups comprising of origins that are used for load balancing the traffic based on availability. </param>
        /// <param name="customDomains"> The custom domains under the endpoint. </param>
        /// <param name="resourceState"> Resource status of the endpoint. </param>
        /// <param name="provisioningState"> Provisioning status of the endpoint. </param>
        /// <returns> A new <see cref="Cdn.CdnEndpointData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CdnEndpointData CdnEndpointData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string originPath = null, IEnumerable<string> contentTypesToCompress = null, string originHostHeader = null, bool? isCompressionEnabled = null, bool? isHttpAllowed = null, bool? isHttpsAllowed = null, QueryStringCachingBehavior? queryStringCachingBehavior = null, OptimizationType? optimizationType = null, string probePath = null, IEnumerable<GeoFilter> geoFilters = null, ResourceIdentifier defaultOriginGroupId = null, IEnumerable<UriSigningKey> uriSigningKeys = null, EndpointDeliveryPolicy deliveryPolicy = null, ResourceIdentifier webApplicationFirewallPolicyLinkId = null, string hostName = null, IEnumerable<DeepCreatedOrigin> origins = null, IEnumerable<DeepCreatedOriginGroup> originGroups = null, IEnumerable<CdnCustomDomainData> customDomains = null, EndpointResourceState? resourceState = null, CdnEndpointProvisioningState? provisioningState = null)
        {
            tags ??= new Dictionary<string, string>();
            contentTypesToCompress ??= new List<string>();
            geoFilters ??= new List<GeoFilter>();
            uriSigningKeys ??= new List<UriSigningKey>();
            origins ??= new List<DeepCreatedOrigin>();
            originGroups ??= new List<DeepCreatedOriginGroup>();
            customDomains ??= new List<CdnCustomDomainData>();

            return new CdnEndpointData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                originPath,
                contentTypesToCompress?.ToList(),
                originHostHeader,
                isCompressionEnabled,
                isHttpAllowed,
                isHttpsAllowed,
                queryStringCachingBehavior,
                optimizationType,
                probePath,
                geoFilters?.ToList(),
                defaultOriginGroupId != null ? ResourceManagerModelFactory.WritableSubResource(defaultOriginGroupId) : null,
                uriSigningKeys?.ToList(),
                deliveryPolicy,
                webApplicationFirewallPolicyLinkId != null ? new EndpointPropertiesUpdateParametersWebApplicationFirewallPolicyLink(webApplicationFirewallPolicyLinkId, serializedAdditionalRawData: null) : null,
                hostName,
                origins?.ToList(),
                originGroups?.ToList(),
                customDomains?.ToList(),
                resourceState,
                provisioningState,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.CanMigrateResult"/>. </summary>
        /// <param name="Id">
        /// Resource ID, String.
        /// Serialized Name: CanMigrateResult.id
        /// </param>
        /// <param name="canMigrateResultType">
        /// Resource type.
        /// Serialized Name: CanMigrateResult.type
        /// </param>
        /// <param name="canMigrate">
        /// Flag that says if the profile can be migrated
        /// Serialized Name: CanMigrateResult.properties.canMigrate
        /// </param>
        /// <param name="defaultSku">
        /// Recommended sku for the migration
        /// Serialized Name: CanMigrateResult.properties.defaultSku
        /// </param>
        /// <param name="errors"> Serialized Name: CanMigrateResult.properties.errors. </param>
        /// <returns> A new <see cref="Models.CanMigrateResult"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CanMigrateResult CanMigrateResult(string Id = null, string canMigrateResultType = null, bool? canMigrate = null, CanMigrateDefaultSku? defaultSku = null, IEnumerable<MigrationErrorType> errors = null)
        {
            var resourceId = Id != null ? new ResourceIdentifier(Id) : null;

            return CanMigrateResult(
                resourceId,
                canMigrateResultType,
                canMigrate,
                defaultSku,
                errors);
        }
        /// <summary> Initializes a new instance of <see cref="Models.MigrateResult"/>. </summary>
        /// <param name="Id">
        /// Resource ID.
        /// Serialized Name: MigrateResult.id
        /// </param>
        /// <param name="migrateResultType">
        /// Resource type.
        /// Serialized Name: MigrateResult.type
        /// </param>
        /// <param name="migratedProfileResourceIdId">
        /// Arm resource id of the migrated profile
        /// Serialized Name: MigrateResult.properties.migratedProfileResourceId
        /// </param>
        /// <returns> A new <see cref="Models.MigrateResult"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MigrateResult MigrateResult(string Id = null, string migrateResultType = null, ResourceIdentifier migratedProfileResourceIdId = null)
        {
            var resourceId = Id != null ? new ResourceIdentifier(Id) : null;
            return MigrateResult(resourceId, migrateResultType, migratedProfileResourceIdId);
        }
    }
}
