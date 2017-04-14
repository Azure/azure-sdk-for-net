// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Cdn.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;

    /// <summary>
    /// An immutable client-side representation of an Azure CDN endpoint.
    /// </summary>
    public interface ICdnEndpoint  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint,Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.EndpointInner>
    {
        /// <summary>
        /// Validates a custom domain mapping to ensure it maps to the correct CNAME in DNS for current endpoint asynchronously.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="hostName">The host name, which must be a domain name, of the custom domain.</param>
        /// <return>An observable of the result.</return>
        Task<Microsoft.Azure.Management.Cdn.Fluent.CustomDomainValidationResult> ValidateCustomDomainAsync(string hostName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Stops the CDN endpoint, if it is running.
        /// </summary>
        void Stop();

        /// <summary>
        /// Forcibly preloads the content of the CDN endpoint asynchronously.
        /// Note: this is supported for Verizon profiles only.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="contentPaths">The file paths to the content to be loaded.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task LoadContentAsync(IList<string> contentPaths, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Validates a custom domain mapping to ensure it maps to the correct CNAME in DNS for current endpoint.
        /// </summary>
        /// <param name="hostName">The host name, which must be a domain name, of the custom domain.</param>
        /// <return>The result of the action, if successful.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CustomDomainValidationResult ValidateCustomDomain(string hostName);

        /// <summary>
        /// Gets HTTP port value.
        /// </summary>
        int HttpPort { get; }

        /// <summary>
        /// Gets HTTPS port value.
        /// </summary>
        int HttpsPort { get; }

        /// <summary>
        /// Gets true if HTTPS traffic is allowed, otherwise false.
        /// </summary>
        bool IsHttpsAllowed { get; }

        /// <summary>
        /// Starts the CDN endpoint asynchronously, if it is stopped.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <return>A representation of the deferred computation of this call.</return>
        Task StartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets origin host header.
        /// </summary>
        string OriginHostHeader { get; }

        /// <summary>
        /// Gets endpoint host name.
        /// </summary>
        string HostName { get; }

        /// <summary>
        /// Gets true if HTTP traffic is allowed, otherwise false.
        /// </summary>
        bool IsHttpAllowed { get; }

        /// <summary>
        /// Gets origin host name.
        /// </summary>
        string OriginHostName { get; }

        /// <summary>
        /// Stops the CDN endpoint asynchronously, if it is running.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <return>A representation of the deferred computation of this call.</return>
        Task StopAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets origin path.
        /// </summary>
        string OriginPath { get; }

        /// <summary>
        /// Gets optimization type.
        /// </summary>
        string OptimizationType { get; }

        /// <remarks>
        /// Gets (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <summary>
        /// Gets list of content types to be compressed.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> ContentTypesToCompress { get; }

        /// <summary>
        /// Gets endpoint state.
        /// </summary>
        string ResourceState { get; }

        /// <summary>
        /// Gets list of Geo filters.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.GeoFilter> GeoFilters { get; }

        /// <summary>
        /// Forcibly purges the content of the CDN endpoint asynchronously.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="contentPaths">The paths to the content to be purged, which can be file paths or directory wild cards.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task PurgeContentAsync(IList<string> contentPaths, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Starts the CDN endpoint, if it is stopped.
        /// </summary>
        void Start();

        /// <remarks>
        /// Gets (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <summary>
        /// Gets list of custom domains associated with this endpoint.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> CustomDomains { get; }

        /// <summary>
        /// Gets query string caching behavior.
        /// </summary>
        Models.QueryStringCachingBehavior QueryStringCachingBehavior { get; }

        /// <summary>
        /// Forcibly purges the content of the CDN endpoint.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="contentPaths">The paths to the content to be purged, which can be file paths or directory wild cards.</param>
        void PurgeContent(IList<string> contentPaths);

        /// <summary>
        /// Checks the quota and usage of geo filters and custom domains under the current endpoint.
        /// </summary>
        /// <return>List of quotas and usages of geo filters and custom domains under the current endpoint.</return>
        System.Collections.Generic.IEnumerable<ResourceUsage> ListResourceUsage();

        /// <summary>
        /// Gets endpoint provisioning state.
        /// </summary>
        string ProvisioningState { get; }

        /// <summary>
        /// Gets true if content compression is enabled, otherwise false.
        /// </summary>
        bool IsCompressionEnabled { get; }

        /// <summary>
        /// Forcibly preloads the content of the CDN endpoint.
        /// Note: this is supported for Verizon profiles only.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="contentPaths">The file paths to the content to be loaded.</param>
        void LoadContent(IList<string> contentPaths);
    }
}