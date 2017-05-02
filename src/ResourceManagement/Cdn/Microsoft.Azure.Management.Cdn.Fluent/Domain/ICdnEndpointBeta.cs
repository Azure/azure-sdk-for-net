// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Cdn.Fluent.Models;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Members of CDN endpoint that are in Beta.
    /// </summary>
    public interface ICdnEndpointBeta  : IBeta
    {
        /// <summary>
        /// Validates a custom domain mapping to ensure it maps to the correct CNAME in DNS for current endpoint asynchronously.
        /// </summary>
        /// <param name="hostName">The host name, which must be a domain name, of the custom domain.</param>
        /// <return>An observable of the result.</return>
        Task<Microsoft.Azure.Management.Cdn.Fluent.CustomDomainValidationResult> ValidateCustomDomainAsync(string hostName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Forcibly preloads the content of the CDN endpoint asynchronously.
        /// Note: this is supported for Verizon profiles only.
        /// </summary>
        /// <param name="contentPaths">The file paths to the content to be loaded.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task LoadContentAsync(IList<string> contentPaths, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Starts the CDN endpoint asynchronously, if it is stopped.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task StartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Stops the CDN endpoint asynchronously, if it is running.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task StopAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets list of content types to be compressed.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> ContentTypesToCompress { get; }

        /// <summary>
        /// Forcibly purges the content of the CDN endpoint asynchronously.
        /// </summary>
        /// <param name="contentPaths">The paths to the content to be purged, which can be file paths or directory wild cards.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task PurgeContentAsync(IList<string> contentPaths, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets list of custom domains associated with this endpoint.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> CustomDomains { get; }

        /// <summary>
        /// Forcibly purges the content of the CDN endpoint.
        /// </summary>
        /// <param name="contentPaths">The paths to the content to be purged, which can be file paths or directory wild cards.</param>
        void PurgeContent(IList<string> contentPaths);

        /// <summary>
        /// Forcibly preloads the content of the CDN endpoint.
        /// Note: this is supported for Verizon profiles only.
        /// </summary>
        /// <param name="contentPaths">The file paths to the content to be loaded.</param>
        void LoadContent(IList<string> contentPaths);
    }
}