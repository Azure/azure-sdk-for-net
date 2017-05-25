// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Cdn.Fluent.Models;

    /// <summary>
    /// An immutable client-side representation of an Azure CDN endpoint.
    /// </summary>
    public interface ICdnEndpoint  :
        ICdnEndpointBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint,Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.EndpointInner>
    {
        /// <summary>
        /// Stops the CDN endpoint, if it is running.
        /// </summary>
        void Stop();

        /// <summary>
        /// Content types to be compressed.
        /// </summary>
        System.Collections.Generic.ISet<string> ContentTypesToCompress { get; }


        /// <summary>
        /// Forcibly purges the content of the CDN endpoint asynchronously.
        /// </summary>
        /// <param name="contentPaths">The paths to the content to be purged, which can be file paths or directory wild cards.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task PurgeContentAsync(ISet<string> contentPaths, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Forcibly purges the content of the CDN endpoint.
        /// </summary>
        /// <param name="contentPaths">The paths to the content to be purged, which can be file paths or directory wild cards.</param>
        void PurgeContent(ISet<string> contentPaths);

        /// <summary>
        /// Forcibly preloads the content of the CDN endpoint.
        /// Note: this is supported for Verizon profiles only.
        /// </summary>
        /// <param name="contentPaths">The file paths to the content to be loaded.</param>
        void LoadContent(ISet<string> contentPaths);

        /// <summary>
        /// Forcibly preloads the content of the CDN endpoint asynchronously.
        /// Note: this is supported for Verizon profiles only.
        /// </summary>
        /// <param name="contentPaths">The file paths to the content to be loaded.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task LoadContentAsync(ISet<string> contentPaths, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Custom domains associated with this endpoint.
        /// </summary>
        System.Collections.Generic.ISet<string> CustomDomains { get; }

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
        /// Gets origin path.
        /// </summary>
        string OriginPath { get; }

        /// <summary>
        /// Gets optimization type.
        /// </summary>
        string OptimizationType { get; }

        /// <summary>
        /// Gets endpoint state.
        /// </summary>
        string ResourceState { get; }

        /// <summary>
        /// Gets list of Geo filters.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.GeoFilter> GeoFilters { get; }

        /// <summary>
        /// Starts the CDN endpoint, if it is stopped.
        /// </summary>
        void Start();

        /// <summary>
        /// Gets query string caching behavior.
        /// </summary>
        Models.QueryStringCachingBehavior QueryStringCachingBehavior { get; }

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
    }
}