// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// A policy that sends an <see cref="AccessToken"/> provided by a <see cref="TokenCredential"/> as an Authentication header.
    /// </summary>
    public class BearerTokenAuthenticationPolicy : HttpPipelinePolicy
    {
        private readonly TokenCredential _credential;

        private readonly string[] _scopes;

        private string? _headerValue;

        private DateTimeOffset _refreshOn;

        /// <summary>
        /// Creates a new instance of <see cref="BearerTokenAuthenticationPolicy"/> using provided token credential and scope to authenticate for.
        /// </summary>
        /// <param name="credential">The token credential to use for authentication.</param>
        /// <param name="scope">The scope to authenticate for.</param>
        public BearerTokenAuthenticationPolicy(TokenCredential credential, string scope) : this(credential, new[] { scope })
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="BearerTokenAuthenticationPolicy"/> using provided token credential and scopes to authenticate for.
        /// </summary>
        /// <param name="credential">The token credential to use for authentication.</param>
        /// <param name="scopes">Scopes to authenticate for.</param>
        public BearerTokenAuthenticationPolicy(TokenCredential credential, IEnumerable<string> scopes)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(scopes, nameof(scopes));

            _credential = credential;
            _scopes = scopes.ToArray();
        }

        /// <inheritdoc />
        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        /// <inheritdoc />
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        /// <inheritdoc />
        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            if (DateTimeOffset.UtcNow >= _refreshOn)
            {
                AccessToken token = async ?
                        await _credential.GetTokenAsync(new TokenRequestContext(_scopes, message.Request.ClientRequestId), message.CancellationToken).ConfigureAwait(false) :
                        _credential.GetToken(new TokenRequestContext(_scopes, message.Request.ClientRequestId), message.CancellationToken);

                _headerValue = "Bearer " + token.Token;
                _refreshOn = token.ExpiresOn - TimeSpan.FromMinutes(2);
            }

            if (_headerValue != null)
            {
                message.Request.SetHeader(HttpHeader.Names.Authorization, _headerValue);
            }

            if (async)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
            }
        }
    }
}
