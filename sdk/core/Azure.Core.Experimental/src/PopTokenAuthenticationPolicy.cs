// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// A policy that supports <see href="https://learn.microsoft.com/entra/msal/dotnet/advanced/proof-of-possession-tokens">Proof of Possession (PoP) tokens</see>.
    /// </summary>
    public class PopTokenAuthenticationPolicy : HttpPipelinePolicy
    {
        private readonly ISupportsProofOfPossession _tokenCredential;
        private string? _popNonce;
        private readonly string[] _scopes;

        /// <summary>
        /// Creates a new instance of <see cref="PopTokenAuthenticationPolicy"/>.
        /// </summary>
        /// <param name="credential">The <see cref="TokenCredential"/> to be used for authorization.</param>
        /// <param name="scope">The scope to be included in acquired tokens.</param>
        public PopTokenAuthenticationPolicy(ISupportsProofOfPossession credential, string scope)
        {
            _tokenCredential = credential;
            _scopes = new[] { scope };
        }

        /// <inheritdoc />
        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline) =>
            ProcessAsync(message, pipeline, true);

        /// <inheritdoc />
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline) =>
            ProcessAsync(message, pipeline, false).EnsureCompleted();

        /// <summary>
        /// Executes before <see cref="HttpPipelinePolicy.Process(HttpMessage, ReadOnlyMemory{HttpPipelinePolicy})"/> <see cref="HttpPipelinePolicy.ProcessAsync(HttpMessage, ReadOnlyMemory{HttpPipelinePolicy})"/> or
        /// <see cref="HttpPipelinePolicy.Process(HttpMessage, ReadOnlyMemory{HttpPipelinePolicy})"/> is called.
        /// Implementers of this method are expected to call <see cref="AuthenticateAndAuthorizeRequest"/> or <see cref="AuthenticateAndAuthorizeRequestAsync"/>
        /// if authorization is required for requests not related to handling a challenge response.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> this policy would be applied to.</param>
        /// <returns>The <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        protected virtual async ValueTask AuthorizeRequestAsync(HttpMessage message)
            => await AuthorizeRequestInternal(message, true).ConfigureAwait(false);

        /// <inheritdoc cref="BearerTokenAuthenticationPolicy.AuthorizeRequest(Azure.Core.HttpMessage)" />
        protected void AuthorizeRequest(HttpMessage message)
            => AuthorizeRequestInternal(message, false).EnsureCompleted();

        /// <summary>
        /// Sets the Authorization header on the <see cref="Request"/> by calling GetToken, or from cache, if possible.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> with the <see cref="Request"/> to be authorized.</param>
        /// <param name="context">The <see cref="TokenRequestContext"/> used to authorize the <see cref="Request"/>.</param>
        protected async ValueTask AuthenticateAndAuthorizeRequestAsync(HttpMessage message, PopTokenRequestContext context) =>
            await AuthenticateAndAuthorizeRequestInternal(message, context, true).ConfigureAwait(false);

        /// <summary>
        /// Sets the Authorization header on the <see cref="Request"/> by calling GetToken, or from cache, if possible.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> with the <see cref="Request"/> to be authorized.</param>
        /// <param name="context">The <see cref="TokenRequestContext"/> used to authorize the <see cref="Request"/>.</param>
        protected void AuthenticateAndAuthorizeRequest(HttpMessage message, PopTokenRequestContext context) =>
            AuthenticateAndAuthorizeRequestInternal(message, context, false).EnsureCompleted();

        /// <summary>
        /// Executed in the event a 401 response with a WWW-Authenticate authentication challenge header is received after the initial request.
        /// </summary>
        /// <remarks>Service client libraries may override this to handle service specific authentication challenges.</remarks>
        /// <param name="message">The <see cref="HttpMessage"/> to be authenticated.</param>
        /// <returns>A boolean indicating whether the request was successfully authenticated and should be sent to the transport.</returns>
        protected virtual async ValueTask<bool> AuthorizeRequestOnChallengeAsync(HttpMessage message) =>
            await AuthorizeRequestOnChallengeAsyncInternal(message, true).ConfigureAwait(false);

        /// <summary>
        /// Executed in the event a 401 response with a WWW-Authenticate authentication challenge header is received after the initial request.
        /// </summary>
        /// <remarks>Service client libraries may override this to handle service specific authentication challenges.</remarks>
        /// <param name="message">The <see cref="HttpMessage"/> to be authenticated.</param>
        /// <returns>A boolean indicating whether the request was successfully authenticated and should be sent to the transport.</returns>
        protected virtual bool AuthorizeRequestOnChallenge(HttpMessage message) =>
            AuthorizeRequestOnChallengeAsyncInternal(message, false).EnsureCompleted();

        private async ValueTask AuthenticateAndAuthorizeRequestInternal(HttpMessage message, PopTokenRequestContext context, bool async)
        {
            _popNonce = context.ProofOfPossessionNonce;
            var token = async ?
                await _tokenCredential.GetTokenAsync(context, message.CancellationToken).ConfigureAwait(false) :
                _tokenCredential.GetToken(context, message.CancellationToken);
            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, "PoP " + token.Token);
        }

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            if (message.Request.Uri.Scheme != Uri.UriSchemeHttps)
            {
                throw new InvalidOperationException("Bearer token authentication is not permitted for non TLS-protected (HTTPS) endpoints.");
            }

            if (async)
            {
                await AuthorizeRequestAsync(message).ConfigureAwait(false);
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                AuthorizeRequest(message);
                ProcessNext(message, pipeline);
            }

            // Check if we have received a challenge or we have not yet issued the first request.
            if (message.Response.Status == (int)HttpStatusCode.Unauthorized && message.Response.Headers.Contains(HttpHeader.Names.WwwAuthenticate))
            {
                // Attempt to get the TokenRequestContext based on the challenge.
                // If we fail to get the context, the challenge was not present or invalid.
                // If we succeed in getting the context, authenticate the request and pass it up the policy chain.
                if (async)
                {
                    if (await AuthorizeRequestOnChallengeAsync(message).ConfigureAwait(false))
                    {
                        await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                    }
                }
                else
                {
                    if (AuthorizeRequestOnChallenge(message))
                    {
                        ProcessNext(message, pipeline);
                    }
                }
            }
            // Handle the PoP token scenario where successful responses will also contain a WWW-Authenticate header containing a nonce.
            else if (!message.Response.IsError && message.Response.Headers.Contains(HttpHeader.Names.WwwAuthenticate))
            {
                var nonce = AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "PoP", "nonce");
                // if nonce is null, the response was not a PoP token response, so null assignment is intended.
                _popNonce = nonce;
            }
        }

        private async ValueTask AuthorizeRequestInternal(HttpMessage message, bool async)
        {
            if (message.Request.Uri.Scheme != Uri.UriSchemeHttps)
            {
                throw new InvalidOperationException("Proof of possession token authentication is not permitted for non TLS-protected (HTTPS) endpoints.");
            }

            if (_popNonce != null)
            {
                // We fetched the challenge from the cache, but we have not initialized the Scopes in the base yet.
                var context = new PopTokenRequestContext(_scopes, parentRequestId: message.Request.ClientRequestId, proofOfPossessionNonce: _popNonce);
                if (async)
                {
                    await AuthenticateAndAuthorizeRequestAsync(message, context).ConfigureAwait(false);
                }
                else
                {
                    AuthenticateAndAuthorizeRequest(message, context);
                }

                return;
            }
        }

        private async ValueTask<bool> AuthorizeRequestOnChallengeAsyncInternal(HttpMessage message, bool async)
        {
            _popNonce = AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "PoP", "nonce");
            if (_popNonce is null)
            {
                return false;
            }
            var context = new PopTokenRequestContext(_scopes, parentRequestId: message.Request.ClientRequestId, proofOfPossessionNonce: _popNonce, request: message.Request);
            if (async)
            {
                await AuthenticateAndAuthorizeRequestAsync(message, context).ConfigureAwait(false);
            }
            else
            {
                AuthenticateAndAuthorizeRequest(message, context);
            }

            return true;
        }
    }
}
