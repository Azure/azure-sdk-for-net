// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;

namespace Azure.Storage
{
    /// <summary>
    /// Provides the client configuration options for connecting to Azure
    /// Storage
    /// </summary>
    public abstract class StorageConnectionOptions : HttpClientOptions
    {
        public static string AuthenticationPolicy { get; } = "Authentication";

        public static string BufferResponsePolicy { get; } = "BufferResponse";

        /// <summary>
        /// Optional credentials for authenticating requests to the service
        /// </summary>
        public IStorageCredentials Credentials { get; set; }

        /// <summary>
        /// HttpPipelinePolicy for automatically retrying failed requests
        /// </summary>
        // TODO: Decide if these are good default options for an Azure
        public FixedRetryOptions Retry { get; } = new FixedRetryOptions()
        {
            Delay = TimeSpan.Zero,
            MaxRetries = Constants.MaxReliabilityRetries
        };

        /// <summary>
        /// Construct the default options for making service requests that
        /// don't require authentication.
        /// </summary>
        internal StorageConnectionOptions()
        {
            // We're going to use the default ResponseClassifier (for now)
            // to decide which errors are retriable
        }

        /// <summary>
        /// Construct options for making service requests signed with an Azure
        /// Storage shared key.
        /// </summary>
        /// <param name="credentials">
        /// The shared key credentials used to sign requests.
        /// </param>
        internal StorageConnectionOptions(SharedKeyCredentials credentials)
            : this()
            => this.Credentials = credentials;

        /// <summary>
        /// Construct options for making service requests authenticated with
        /// Azure token credentials.
        /// </summary>
        /// <param name="credentials">
        /// The token credentials used to authenticate requests.
        /// </param>
        internal StorageConnectionOptions(TokenCredentials credentials)
            : this()
            => this.Credentials = credentials;

        /// <summary>
        /// Construct an HttpPipeline used to make requests to Azure Storage
        /// </summary>
        /// <returns>
        /// An HttpPipeline used to make requests to Azure Storage
        /// </returns>
        internal virtual HttpPipeline Build()
            => new HttpPipelineBuilder(this)
                .Replace(RetryPolicy, new FixedRetryPolicy(this.Retry))
                // TODO: Disable logging for now
                .Replace(LoggingPolicy, null)
                .InsertAfter(RetryPolicy, AuthenticationPolicy, this.GetAuthenticationPipelinePolicy(this.Credentials))
                // TODO: PageBlob's UploadPagesAsync test currently fails
                // without buffered responses, so I'm leaving this on for now.
                // It'd be a great perf win to remove it soon.
                .InsertBefore(TransportPolicy, BufferResponsePolicy, Core.Pipeline.Policies.BufferResponsePolicy.Singleton)
                .Build();

        /// <summary>
        /// Create an authentication HttpPipelinePolicy to sign requests
        /// corresponding to the user's credentials.
        /// </summary>
        /// <param name="credentials">Optional credentials to use.</param>
        /// <returns>
        /// An HttpPipelinePolicy to sign requests, null if there's no policy
        /// required for anonymous/SAS access, or an ArgumentException if the
        /// type of credentials aren't supported by Azure Storage.
        /// </returns>
        internal virtual HttpPipelinePolicy GetAuthenticationPipelinePolicy(IStorageCredentials credentials = null)
        {
            // Use the credentials to decide on the authentication policy
            switch (credentials)
            {
                case SharedAccessSignatureCredentials _:
                case null:
                    return null; // Anonymous authentication
                case SharedKeyCredentials sharedKey:
                    return new SharedKeyPipelinePolicy(sharedKey);
                case TokenCredentials token:
                    return new TokenPipelinePolicy(token);
                default:
                    throw new ArgumentException(
                        $"Cannot authenticate with ${credentials.GetType().FullName}",
                        nameof(credentials));
            }
        }
    }
}
