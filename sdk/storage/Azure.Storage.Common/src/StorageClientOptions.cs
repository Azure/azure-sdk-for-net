// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Common;

namespace Azure.Storage
{
    /// <summary>
    /// Defines the client configuration options for connecting to Azure
    /// Storage.
    /// </summary>
    internal static class StorageClientOptions
    {
        /// <summary>
        /// The default scope used for token authentication with Storage.
        /// </summary>
        const string StorageScope = "https://storage.azure.com/.default";

        /// <summary>
        /// Set common ClientOptions defaults for Azure Storage.
        /// </summary>
        /// <param name="options">Storage ClientOptions.</param>
        public static void Initialize(this ClientOptions options)
        {
            // We're going to use the default ResponseClassifier to decide
            // which errors are retriable, but may extend this in the future.

            // We'll use the standard RetryPolicy with a few more retries
            options.Retry.MaxRetries = Constants.MaxReliabilityRetries;

            // Disable logging until we fully support redaction
            options.Diagnostics.IsLoggingEnabled = false;
        }

        /// <summary>
        /// Get an authentication policy to sign Storage requests.
        /// </summary>
        /// <param name="credential">Credential to use.</param>
        /// <returns>An authentication policy.</returns>
        public static HttpPipelinePolicy AsPolicy(this StorageSharedKeyCredential credential) =>
            new StorageSharedKeyPipelinePolicy(
                credential ?? throw new ArgumentNullException(nameof(credential)));

        /// <summary>
        /// Get an authentication policy to sign Storage requests.
        /// </summary>
        /// <param name="credential">Credential to use.</param>
        /// <returns>An authentication policy.</returns>
        public static HttpPipelinePolicy AsPolicy(this TokenCredential credential) =>
            new BearerTokenAuthenticationPolicy(
                credential ?? throw new ArgumentNullException(nameof(credential)),
                StorageScope);

        /// <summary>
        /// Get an optional authentication policy to sign Storage requests.
        /// </summary>
        /// <param name="credentials">Optional credentials to use.</param>
        /// <returns>An optional authentication policy.</returns>
        public static HttpPipelinePolicy GetAuthenticationPolicy(object credentials = null)
        {
            // Use the credentials to decide on the authentication policy
            switch (credentials)
            {
                case SharedAccessSignatureCredentials _:
                case null: // Anonymous authentication
                    return null;
                case StorageSharedKeyCredential sharedKey:
                    return sharedKey.AsPolicy();
                case TokenCredential token:
                    return token.AsPolicy();
                default:
                    throw new ArgumentException(
                        $"Cannot authenticate with ${credentials.GetType().FullName}",
                        nameof(credentials));
            }
        }

        /// <summary>
        /// Create an HttpPipeline from Storage ClientOptions.
        /// </summary>
        /// <param name="options">The Storage ClientOptions.</param>
        /// <param name="authentication">Optional authentication policy.</param>
        /// <returns>An HttpPipeline to use for Storage requests.</returns>
        public static HttpPipeline Build(this ClientOptions options, HttpPipelinePolicy authentication = null) =>
            HttpPipelineBuilder.Build(
                options,
                // TODO: PageBlob's UploadPagesAsync test currently fails
                // without buffered responses, so I'm leaving this on for now.
                // It'd be a great perf win to remove it soon.
                bufferResponse: true,
                authentication);

        /// <summary>
        /// Create an HttpPipeline from Storage ClientOptions.
        /// </summary>
        /// <param name="options">The Storage ClientOptions.</param>
        /// <param name="credentials">Optional authentication credentials.</param>
        /// <returns>An HttpPipeline to use for Storage requests.</returns>
        public static HttpPipeline Build(this ClientOptions options, object credentials) =>
            Build(options, GetAuthenticationPolicy(credentials));
    }
}
