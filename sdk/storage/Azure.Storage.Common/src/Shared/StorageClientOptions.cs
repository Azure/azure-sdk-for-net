// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.Pipeline;

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
        private const string StorageScope = "https://storage.azure.com/.default";

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
        }

        /// <summary>
        /// Get an authentication policy to sign Storage requests.
        /// </summary>
        /// <param name="credential">Credential to use.</param>
        /// <returns>An authentication policy.</returns>
        public static HttpPipelinePolicy AsPolicy(this StorageSharedKeyCredential credential) =>
            new StorageSharedKeyPipelinePolicy(
                credential ?? throw Errors.ArgumentNull(nameof(credential)));

        /// <summary>
        /// Get an authentication policy to sign Storage requests.
        /// </summary>
        /// <param name="credential">Credential to use.</param>
        /// <param name="resourceUri">Resource Uri. Must not contain shared access signature.</param>
        /// <returns>An authentication policy.</returns>
        public static HttpPipelinePolicy AsPolicy<TUriBuilder>(this AzureSasCredential credential, Uri resourceUri)
        {
            Argument.AssertNotNull(resourceUri, nameof(resourceUri));
            Argument.AssertNotNull(credential, nameof(credential));
            var queryParameters = resourceUri.GetQueryParameters();
            if (queryParameters.ContainsKey("sig"))
            {
                throw Errors.SasCredentialRequiresUriWithoutSas<TUriBuilder>(resourceUri);
            }
            return new AzureSasCredentialSynchronousPolicy(credential);
        }

        /// <summary>
        /// Get an authentication policy to sign Storage requests.
        /// </summary>
        /// <param name="credential">Credential to use.</param>
        /// <returns>An authentication policy.</returns>
        public static HttpPipelinePolicy AsPolicy(this TokenCredential credential) =>
            new BearerTokenAuthenticationPolicy(
                credential ?? throw Errors.ArgumentNull(nameof(credential)),
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
                    throw Errors.InvalidCredentials(credentials.GetType().FullName);
            }
        }

        /// <summary>
        /// Create an HttpPipeline from Storage ClientOptions.
        /// </summary>
        /// <param name="options">The Storage ClientOptions.</param>
        /// <param name="authentication">Optional authentication policy.</param>
        /// <param name="geoRedundantSecondaryStorageUri">The secondary URI to be used for retries on failed read requests</param>
        /// <returns>An HttpPipeline to use for Storage requests.</returns>
        public static HttpPipeline Build(this ClientOptions options, HttpPipelinePolicy authentication = null, Uri geoRedundantSecondaryStorageUri = null)
        {
            List<HttpPipelinePolicy> perRetryClientPolicies = new List<HttpPipelinePolicy>();
            StorageResponseClassifier classifier = new StorageResponseClassifier();
            if (geoRedundantSecondaryStorageUri != null)
            {
                perRetryClientPolicies.Add(new GeoRedundantReadPolicy(geoRedundantSecondaryStorageUri));
                classifier.SecondaryStorageUri = geoRedundantSecondaryStorageUri;
            }

            perRetryClientPolicies.Add(new StorageRequestValidationPipelinePolicy(options));
            perRetryClientPolicies.Add(authentication); // authentication needs to be the last of the perRetry client policies passed in to Build

            return HttpPipelineBuilder.Build(
               options,
               Array.Empty<HttpPipelinePolicy>(),
               perRetryClientPolicies.ToArray(),
               classifier);
        }

        /// <summary>
        /// Create an HttpPipeline from Storage ClientOptions.
        /// </summary>
        /// <param name="options">The Storage ClientOptions.</param>
        /// <param name="credentials">Optional authentication credentials.</param>
        /// <param name="geoRedundantSecondaryStorageUri">The secondary URI to be used for retries on failed read requests</param>
        /// <returns>An HttpPipeline to use for Storage requests.</returns>
        public static HttpPipeline Build(this ClientOptions options, object credentials, Uri geoRedundantSecondaryStorageUri = null) =>
            Build(options, GetAuthenticationPolicy(credentials), geoRedundantSecondaryStorageUri);
    }
}
