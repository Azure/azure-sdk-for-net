// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    // TODO: This has been translated from the policy inside TokenCredentials

    /// <summary>
    /// HttpPipelinePolicy to authenticate requests using bearer tokens.
    /// </summary>
    public sealed class TokenPipelinePolicy : HttpPipelinePolicy
    {
        /// <summary>
        /// Token credentials used to authenticate requests.
        /// </summary>
        private readonly TokenCredentials _credentials;

        /// <summary>
        /// Create a new TokenPipelinePolicy.
        /// </summary>
        /// <param name="credentials">
        /// Token credentials used to authenticate requests.
        /// </param>
        public TokenPipelinePolicy(TokenCredentials credentials)
            => this._credentials = credentials;

        /// <summary>
        /// Authenticate the request with the token.
        /// </summary>
        /// <param name="message">The message with the request to authenticate.</param>
        /// <param name="pipeline">The next step in the pipeline.</param>
        public override async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            this.AddAuthorization(message);

            // Continue processing the request
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
        }

        /// <summary>
        /// Authenticate the request with the token.
        /// </summary>
        /// <param name="message">The message with the request to authenticate.</param>
        /// <param name="pipeline">The next step in the pipeline.</param>
        public override void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            this.AddAuthorization(message);

            // Continue processing the request
            ProcessNext(message, pipeline);
        }

        /// <summary>
        /// Add the token as an authorization header.
        /// </summary>
        /// <param name="message">The message with the request to authenticate.</param>
        private void AddAuthorization(HttpPipelineMessage message)
        {
            // Token credentials require HTTPS
            if (!message.Request.UriBuilder.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase))
            {
                throw Errors.TokenCredentialsRequireHttps();
            }

            // Add the Authorization header
            var value = new AuthenticationHeaderValue("Bearer", this._credentials.Token);
            message.Request.Headers.SetValue("Authorization", value.ToString());
        }

    }
}
