// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn
{
    public partial class CdnEndpointData
    {
        /// <summary> Initializes a new instance of <see cref="CdnEndpointData"/>. </summary>
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
        /// <param name="defaultOriginGroup"> A reference to the origin group. </param>
        /// <param name="uriSigningKeys"> List of keys used to validate the signed URL hashes. </param>
        /// <param name="deliveryPolicy"> A policy that specifies the delivery rules to be used for an endpoint. </param>
        /// <param name="webApplicationFirewallPolicyLink"> Defines the Web Application Firewall policy for the endpoint (if applicable). </param>
        /// <param name="hostName"> The host name of the endpoint structured as {endpointName}.{DNSZone}, e.g. contoso.azureedge.net. </param>
        /// <param name="origins"> The source of the content being delivered via CDN. </param>
        /// <param name="originGroups"> The origin groups comprising of origins that are used for load balancing the traffic based on availability. </param>
        /// <param name="customDomains"> The custom domains under the endpoint. </param>
        /// <param name="resourceState"> Resource status of the endpoint. </param>
        /// <param name="provisioningState"> Provisioning status of the endpoint. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CdnEndpointData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string originPath, IList<string> contentTypesToCompress, string originHostHeader, bool? isCompressionEnabled, bool? isHttpAllowed, bool? isHttpsAllowed, QueryStringCachingBehavior? queryStringCachingBehavior, OptimizationType? optimizationType, string probePath, IList<GeoFilter> geoFilters, WritableSubResource defaultOriginGroup, IList<UriSigningKey> uriSigningKeys, EndpointDeliveryPolicy deliveryPolicy, EndpointPropertiesUpdateParametersWebApplicationFirewallPolicyLink webApplicationFirewallPolicyLink, string hostName, IList<DeepCreatedOrigin> origins, IList<DeepCreatedOriginGroup> originGroups, IReadOnlyList<CdnCustomDomainData> customDomains, EndpointResourceState? resourceState, CdnEndpointProvisioningState? provisioningState, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData, tags, location)
        {
            OriginPath = originPath;
            ContentTypesToCompress = contentTypesToCompress;
            OriginHostHeader = originHostHeader;
            IsCompressionEnabled = isCompressionEnabled;
            IsHttpAllowed = isHttpAllowed;
            IsHttpsAllowed = isHttpsAllowed;
            QueryStringCachingBehavior = queryStringCachingBehavior;
            OptimizationType = optimizationType;
            ProbePath = probePath;
            GeoFilters = geoFilters;
            DefaultOriginGroup = defaultOriginGroup;
            UriSigningKeys = uriSigningKeys;
            DeliveryPolicy = deliveryPolicy;
            WebApplicationFirewallPolicyLink = webApplicationFirewallPolicyLink;
            HostName = hostName;
            Origins = origins;
            OriginGroups = originGroups;
            CustomDomains = customDomains;
            ResourceState = resourceState;
            ProvisioningState = provisioningState;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The custom domains under the endpoint. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<CdnCustomDomainData> CustomDomains { get; }
    }
}
