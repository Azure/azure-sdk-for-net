// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Shared;

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
        /// <param name="scope">Scope to use.</param>
        /// <param name="options"> The <see cref="ISupportsTenantIdChallenges"/> to apply to the credential. </param>
        /// <returns>An authentication policy.</returns>
        public static HttpPipelinePolicy AsPolicy(this TokenCredential credential, string scope, ClientOptions options) =>
            new StorageBearerTokenChallengeAuthorizationPolicy(
                credential ?? throw Errors.ArgumentNull(nameof(credential)),
                scope ?? StorageScope,
                options is ISupportsTenantIdChallenges { EnableTenantDiscovery: true });

        /// <summary>
        /// Get an optional authentication policy to sign Storage requests.
        /// </summary>
        /// <param name="credentials">Optional credentials to use.</param>
        /// <param name="scope">Optional scope</param>
        /// <param name="options"> The <see cref="ClientOptions"/> </param>
        /// <returns>An optional authentication policy.</returns>
        public static HttpPipelinePolicy GetAuthenticationPolicy(object credentials = null, string scope = default, ClientOptions options = null)
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
                    return token.AsPolicy(scope, options);
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
        /// <param name="expectContinue">Options for selecting expect continue policy.</param>
        /// <returns>An HttpPipeline to use for Storage requests.</returns>
        public static HttpPipeline Build(
            this ClientOptions options,
            HttpPipelinePolicy authentication = null,
            Uri geoRedundantSecondaryStorageUri = null,
            ExpectContinueOptions expectContinue = null)
        {
            StorageResponseClassifier classifier = new();
            var pipelineOptions = new HttpPipelineOptions(options)
            {
                PerCallPolicies = { StorageServerTimeoutPolicy.Shared },
                // needed *after* core applies the user agent; can't have that without going per-retry
                PerRetryPolicies = { StorageTelemetryPolicy.Shared },
                ResponseClassifier = classifier,
                RequestFailedDetailsParser = new StorageRequestFailedDetailsParser()
            };

            if (geoRedundantSecondaryStorageUri != null)
            {
                pipelineOptions.PerRetryPolicies.Add(new GeoRedundantReadPolicy(geoRedundantSecondaryStorageUri));
                classifier.SecondaryStorageUri = geoRedundantSecondaryStorageUri;
            }

            if (expectContinue != null)
            {
                switch (expectContinue.Mode)
                {
                    case ExpectContinueMode.ApplyOnThrottle:
                        pipelineOptions.PerCallPolicies.Add(new ExpectContinueOnThrottlePolicy()
                        {
                            ThrottleInterval = expectContinue.ThrottleInterval,
                            ContentLengthThreshold = expectContinue.ContentLengthThreshold ?? 0,
                        });
                        break;
                    case ExpectContinueMode.On:
                        pipelineOptions.PerCallPolicies.Add(new ExpectContinuePolicy()
                        {
                            ContentLengthThreshold = expectContinue.ContentLengthThreshold ?? 0,
                        });
                        break;
                    case ExpectContinueMode.Off:
                        break;
                }
            }
            else
            {
                // TODO get env config for whether to disable
                pipelineOptions.PerCallPolicies.Add(new ExpectContinueOnThrottlePolicy() { ThrottleInterval = TimeSpan.FromMinutes(1) });
            }

            pipelineOptions.PerRetryPolicies.Add(new StorageRequestValidationPipelinePolicy());
            pipelineOptions.PerRetryPolicies.Add(authentication); // authentication needs to be the last of the perRetry client policies passed in to Build

            return HttpPipelineBuilder.Build(pipelineOptions);
        }

        /// <summary>
        /// Create an HttpPipeline from Storage ClientOptions.
        /// </summary>
        /// <param name="options">The Storage ClientOptions.</param>
        /// <param name="credentials">Optional authentication credentials.</param>
        /// <param name="geoRedundantSecondaryStorageUri">The secondary URI to be used for retries on failed read requests</param>
        /// <param name="expectContinue">Options for selecting expect continue policy.</param>
        /// <returns>An HttpPipeline to use for Storage requests.</returns>
        public static HttpPipeline Build(
            this ClientOptions options,
            object credentials,
            Uri geoRedundantSecondaryStorageUri = null,
            ExpectContinueOptions expectContinue = null) =>
            Build(options, GetAuthenticationPolicy(credentials), geoRedundantSecondaryStorageUri, expectContinue);
    }
}
