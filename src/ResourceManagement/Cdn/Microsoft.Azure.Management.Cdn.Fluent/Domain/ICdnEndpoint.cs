// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure CDN endpoint.
    /// </summary>
    public interface ICdnEndpoint  :
        IExternalChildResource<ICdnEndpoint,ICdnProfile>,
        IWrapper<EndpointInner>
    {
        /// <return>Endpoint host name.</return>
        string HostName { get; }

        /// <return>Origin host name.</return>
        string OriginHostName { get; }

        /// <return>Origin path.</return>
        string OriginPath { get; }

        /// <return>Http port value.</return>
        int HttpPort { get; }

        /// <return>True if Http traffic is allowed, otherwise false.</return>
        bool IsHttpAllowed { get; }

        /// <summary>
        /// Starts current stopped CDN endpoint.
        /// </summary>
        void Start();

        /// <return>True if content compression is enabled, otherwise false.</return>
        bool IsCompressionEnabled { get; }

        /// <return>Query string caching behavior.</return>
        QueryStringCachingBehavior QueryStringCachingBehavior { get; }

        /// <return>Endpoint provisioning state.</return>
        string ProvisioningState { get; }

        /// <return>Https port value.</return>
        int HttpsPort { get; }

        /// <summary>
        /// Forcibly purges current CDN endpoint content.
        /// </summary>
        /// <param name="contentPaths">The path to the content to be purged. Can describe a file path or a wild card directory.</param>
        void PurgeContent(IList<string> contentPaths);

        /// <return>List of content types to be compressed.</return>
        IList<string> ContentTypesToCompress { get; }

        /// <summary>
        /// Stops current running CDN endpoint.
        /// </summary>
        void Stop();

        /// <return>List of custom domains associated with current endpoint.</return>
        IReadOnlyCollection<string> CustomDomains { get; }

        /// <summary>
        /// Forcibly pre-loads current CDN endpoint content. Available for Verizon Profiles.
        /// </summary>
        /// <param name="contentPaths">The path to the content to be loaded. Should describe a file path.</param>
        void LoadContent(IList<string> contentPaths);

        /// <return>Origin host header.</return>
        string OriginHostHeader { get; }

        /// <return>True if Https traffic is allowed, otherwise false.</return>
        bool IsHttpsAllowed { get; }

        /// <return>Optimization type value.</return>
        string OptimizationType { get; }

        /// <return>Endpoint state.</return>
        string ResourceState { get; }

        /// <return>List of Geo filters.</return>
        System.Collections.Generic.IList<GeoFilter> GeoFilters { get; }

        /// <summary>
        /// Validates a custom domain mapping to ensure it maps to the correct CNAME in DNS for current endpoint.
        /// </summary>
        /// <param name="hostName">The host name of the custom domain. Must be a domain name.</param>
        /// <return>The CustomDomainValidationResult object if successful.</return>
        CustomDomainValidationResult ValidateCustomDomain(string hostName);
    }
}