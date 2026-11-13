// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.AgentServer.Core.Storage
{
    /// <summary>
    /// Immutable Foundry storage endpoint configuration.
    /// </summary>
    /// <remarks>
    /// Protocol-neutral: resolves the Foundry project endpoint, derives the
    /// <c>/storage/</c> base URL, and builds versioned request URLs for any storage
    /// resource path (state stores, items, ...).
    /// </remarks>
    internal sealed class FoundryStorageEndpoint
    {
        internal const string DefaultApiVersion = "v1";

        /// <summary>Initializes a new instance of the <see cref="FoundryStorageEndpoint"/> class.</summary>
        /// <param name="storageBaseUrl">Fully-qualified <c>.../storage/</c> base URL.</param>
        /// <param name="apiVersion">Storage API version appended to every request URL.</param>
        internal FoundryStorageEndpoint(string storageBaseUrl, string apiVersion = DefaultApiVersion)
        {
            StorageBaseUrl = storageBaseUrl;
            ApiVersion = apiVersion;
        }

        /// <summary>Gets the fully-qualified <c>.../storage/</c> base URL.</summary>
        public string StorageBaseUrl { get; }

        /// <summary>Gets the storage API version appended to every request URL.</summary>
        public string ApiVersion { get; }

        /// <summary>
        /// Creates an endpoint by reading the <c>FOUNDRY_PROJECT_ENDPOINT</c> environment variable.
        /// </summary>
        /// <param name="apiVersion">Storage API version.</param>
        /// <returns>The resolved endpoint.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the environment variable is not set.</exception>
        public static FoundryStorageEndpoint FromEnvironment(string apiVersion = DefaultApiVersion)
        {
            string? projectEndpoint = FoundryEnvironment.ProjectEndpoint;
            if (string.IsNullOrEmpty(projectEndpoint))
            {
                throw new InvalidOperationException(
                    "The 'FOUNDRY_PROJECT_ENDPOINT' environment variable is required. " +
                    "In hosted environments, the Azure AI Foundry platform must set this variable.");
            }

            return FromEndpoint(projectEndpoint!, apiVersion);
        }

        /// <summary>
        /// Creates an endpoint from an explicit Foundry project endpoint URL.
        /// </summary>
        /// <param name="endpoint">The Foundry project endpoint (or a full <c>.../storage</c> URL).</param>
        /// <param name="apiVersion">Storage API version.</param>
        /// <returns>The resolved endpoint.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="endpoint"/> is empty or not an absolute URL.</exception>
        public static FoundryStorageEndpoint FromEndpoint(string endpoint, string apiVersion = DefaultApiVersion)
        {
            if (string.IsNullOrEmpty(endpoint))
            {
                throw new ArgumentException("endpoint must be a non-empty string.", nameof(endpoint));
            }

            if (!endpoint.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
                && !endpoint.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"endpoint must be a valid absolute URL, got: '{endpoint}'.", nameof(endpoint));
            }

            string normalized = endpoint.TrimEnd('/');
            string storageBaseUrl = normalized.EndsWith("/storage", StringComparison.OrdinalIgnoreCase)
                ? normalized + "/"
                : normalized + "/storage/";

            return new FoundryStorageEndpoint(storageBaseUrl, apiVersion);
        }

        /// <summary>
        /// Builds a full storage API URI for <paramref name="path"/> with <c>api-version</c> appended.
        /// </summary>
        /// <param name="path">The relative storage resource path (already segment-encoded).</param>
        /// <param name="extraParams">Optional additional query parameters, appended (and value-encoded) in order.</param>
        /// <returns>The absolute request URI.</returns>
        public Uri BuildUri(string path, IEnumerable<KeyValuePair<string, string>>? extraParams = null)
        {
            var builder = new StringBuilder();
            builder.Append(StorageBaseUrl).Append(path);
            builder.Append("?api-version=").Append(Uri.EscapeDataString(ApiVersion));
            if (extraParams is not null)
            {
                foreach (KeyValuePair<string, string> pair in extraParams)
                {
                    builder.Append('&')
                        .Append(pair.Key)
                        .Append('=')
                        .Append(Uri.EscapeDataString(pair.Value));
                }
            }

            return new Uri(builder.ToString());
        }
    }
}
