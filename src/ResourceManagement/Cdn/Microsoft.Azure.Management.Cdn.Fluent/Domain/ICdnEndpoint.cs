// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An immutable client-side representation of an Azure CDN endpoint.
    /// </summary>
    public interface ICdnEndpoint  :
        IExternalChildResource<Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint,Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>,
        IHasInner<Microsoft.Azure.Management.Cdn.Fluent.Models.EndpointInner>
    {
        /// <summary>
        /// Gets endpoint host name.
        /// </summary>
        string HostName { get; }

        /// <summary>
        /// Gets origin host name.
        /// </summary>
        string OriginHostName { get; }

        /// <summary>
        /// Gets origin path.
        /// </summary>
        string OriginPath { get; }

        /// <summary>
        /// Gets http port value.
        /// </summary>
        int HttpPort { get; }

        /// <summary>
        /// Gets true if Http traffic is allowed, otherwise false.
        /// </summary>
        bool IsHttpAllowed { get; }

        /// <summary>
        /// Starts current stopped CDN endpoint.
        /// </summary>
        void Start();

        /// <summary>
        /// Starts current stopped CDN endpoint.
        /// </summary>
        Task StartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets true if content compression is enabled, otherwise false.
        /// </summary>
        bool IsCompressionEnabled { get; }

        /// <summary>
        /// Gets query string caching behavior.
        /// </summary>
        Microsoft.Azure.Management.Cdn.Fluent.Models.QueryStringCachingBehavior QueryStringCachingBehavior { get; }

        /// <summary>
        /// Gets endpoint provisioning state.
        /// </summary>
        string ProvisioningState { get; }

        /// <summary>
        /// Gets https port value.
        /// </summary>
        int HttpsPort { get; }

        /// <summary>
        /// Forcibly purges current CDN endpoint content.
        /// </summary>
        /// <param name="contentPaths">The path to the content to be purged. Can describe a file path or a wild card directory.</param>
        void PurgeContent(IList<string> contentPaths);

        /// <summary>
        /// Forcibly purges current CDN endpoint content.
        /// </summary>
        /// <param name="contentPaths">The path to the content to be purged. Can describe a file path or a wild card directory.</param>
        Task PurgeContentAsync(IList<string> contentPaths, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets list of content types to be compressed.
        /// </summary>
        System.Collections.Generic.IList<string> ContentTypesToCompress { get; }

        /// <summary>
        /// Stops current running CDN endpoint.
        /// </summary>
        void Stop();

        /// <summary>
        /// Stops current running CDN endpoint.
        /// </summary>
        Task StopAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets list of custom domains associated with current endpoint.
        /// </summary>
        System.Collections.Generic.IList<string> CustomDomains { get; }

        /// <summary>
        /// Forcibly pre-loads current CDN endpoint content. Available for Verizon Profiles.
        /// </summary>
        /// <param name="contentPaths">The path to the content to be loaded. Should describe a file path.</param>
        void LoadContent(IList<string> contentPaths);

        /// <summary>
        /// Forcibly pre-loads current CDN endpoint content. Available for Verizon Profiles.
        /// </summary>
        /// <param name="contentPaths">The path to the content to be loaded. Should describe a file path.</param>
        Task LoadContentAsync(IList<string> contentPaths, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets origin host header.
        /// </summary>
        string OriginHostHeader { get; }

        /// <summary>
        /// Gets true if Https traffic is allowed, otherwise false.
        /// </summary>
        bool IsHttpsAllowed { get; }

        /// <summary>
        /// Gets optimization type value.
        /// </summary>
        string OptimizationType { get; }

        /// <summary>
        /// Gets endpoint state.
        /// </summary>
        string ResourceState { get; }

        /// <summary>
        /// Gets list of Geo filters.
        /// </summary>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Cdn.Fluent.Models.GeoFilter> GeoFilters { get; }

        /// <summary>
        /// Checks the quota and usage of geo filters and custom domains under the current endpoint.
        /// </summary>
        /// <returns>list of quotas and usages of geo filters and custom domains under the current endpoint</returns>
        IEnumerable<ResourceUsage> ListResourceUsage();

        /// <summary>
        /// Validates a custom domain mapping to ensure it maps to the correct CNAME in DNS for current endpoint.
        /// </summary>
        /// <param name="hostName">The host name of the custom domain. Must be a domain name.</param>
        /// <return>The CustomDomainValidationResult object if successful.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CustomDomainValidationResult ValidateCustomDomain(string hostName);

        /// <summary>
        /// Validates a custom domain mapping to ensure it maps to the correct CNAME in DNS for current endpoint.
        /// </summary>
        /// <param name="hostName">The host name of the custom domain. Must be a domain name.</param>
        /// <return>The CustomDomainValidationResult object if successful.</return>
        Task<CustomDomainValidationResult> ValidateCustomDomainAsync(string hostName, CancellationToken cancellationToken = default(CancellationToken));
    }
}