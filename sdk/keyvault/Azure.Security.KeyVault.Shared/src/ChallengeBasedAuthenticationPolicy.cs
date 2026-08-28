// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault
{
    internal class ChallengeBasedAuthenticationPolicy : BearerTokenAuthenticationPolicy
    {
        private const string KeyVaultStashedContentKey = "KeyVaultContent";
        private const string TokenBoundAuthHeaderName = "x-ms-tokenboundauth";
        private const string PoPTokenTypePrefix = "pop ";
        private const string MtlsPoPTokenTypePrefix = "mtls_pop ";
        private const string TokenBindingFailedMessage =
            "Proof-of-Possession token binding was requested (EnableProofOfPossession = true), but the binding " +
            "certificate could not be applied to the configured transport, so the request would carry a bound " +
            "token the service cannot validate. This happens when the transport cannot be updated in place, such " +
            "as HttpClientTransport.Shared or a transport that does not support updates. Use a transport that " +
            "supports in-place updates (the default), or set EnableProofOfPossession to false.";
        private static readonly Type[] s_updateParameterTypes = [typeof(HttpPipelineTransportOptions)];
        private readonly bool _verifyChallengeResource;
        private readonly bool _enableProofOfPossession;

        // Set when applying the PoP binding certificate to the transport fails; read to suppress the
        // x-ms-tokenboundauth header on that request. Volatile for cross-thread visibility.
        private volatile bool _transportUpdateFailed;

        /// <summary>
        /// Challenges are cached using the Key Vault or Managed HSM endpoint URI authority as the key.
        /// </summary>
        private static readonly ConcurrentDictionary<string, ChallengeParameters> s_challengeCache = new();
        private ChallengeParameters _challenge;

        public ChallengeBasedAuthenticationPolicy(TokenCredential credential, bool disableChallengeResourceVerification, bool enableProofOfPossession = false) : base(credential, Array.Empty<string>())
        {
            _verifyChallengeResource = !disableChallengeResourceVerification;
            _enableProofOfPossession = enableProofOfPossession;
        }

        [UnconditionalSuppressMessage(
            "Trimming",
            "IL2075",
            Justification = "This reflection check only determines whether a public virtual method was overridden; it does not invoke dynamically discovered code.")]
        internal static bool SupportsProofOfPossession(HttpPipelineTransport transport)
            => transport.GetType().GetMethod(nameof(HttpPipelineTransport.Update), s_updateParameterTypes)?.DeclaringType != typeof(HttpPipelineTransport);

        /// <summary>
        /// Applies the Proof-of-Possession binding certificate to the transport. Catches transports that cannot
        /// be updated in place (e.g. HttpClientTransport.Shared) so the request falls back to a plain token
        /// instead of throwing, and records the failure so the token-bound header is suppressed.
        /// </summary>
        [Experimental("AZID0004")]
        protected override void OnTransportOptionsChanged(HttpPipelineTransportOptions options)
        {
            try
            {
                base.OnTransportOptionsChanged(options);
                _transportUpdateFailed = false;
            }
            catch (InvalidOperationException)
            {
                // e.g. HttpClientTransport.Shared cannot be updated in place.
                _transportUpdateFailed = true;
            }
            catch (NotSupportedException)
            {
                // A transport that doesn't support updates at all (base HttpPipelineTransport.Update()).
                _transportUpdateFailed = true;
            }
        }

        /// <inheritdoc cref="BearerTokenAuthenticationPolicy.AuthorizeRequestAsync(Azure.Core.HttpMessage)" />
        protected override ValueTask AuthorizeRequestAsync(HttpMessage message)
            => AuthorizeRequestInternal(message, true);

        /// <inheritdoc cref="BearerTokenAuthenticationPolicy.AuthorizeRequest(Azure.Core.HttpMessage)" />
        protected override void AuthorizeRequest(HttpMessage message)
            => AuthorizeRequestInternal(message, false).EnsureCompleted();

        private async ValueTask AuthorizeRequestInternal(HttpMessage message, bool async)
        {
            if (message.Request.Uri.Scheme != Uri.UriSchemeHttps)
            {
                throw new InvalidOperationException("Bearer token authentication is not permitted for non TLS protected (https) endpoints.");
            }

            // If this policy doesn't have challenge parameters cached try to get it from the static challenge cache.
            if (_challenge == null)
            {
                string authority = GetRequestAuthority(message.Request);
                s_challengeCache.TryGetValue(authority, out _challenge);
            }

            if (_challenge != null)
            {
                // We fetched the challenge from the cache, but we have not initialized the Scopes in the base yet.
                var context = new TokenRequestContext(
                    _challenge.Scopes,
                    parentRequestId: message.Request.ClientRequestId,
                    tenantId: _challenge.TenantId,
                    isCaeEnabled: true,
                    isProofOfPossessionEnabled: _enableProofOfPossession,
                    requestUri: message.Request.Uri.ToUri(),
                    requestMethod: message.Request.Method.ToString());
                if (async)
                {
                    await AuthenticateAndAuthorizeRequestAsync(message, context).ConfigureAwait(false);
                }
                else
                {
                    AuthenticateAndAuthorizeRequest(message, context);
                }

                AddTokenBoundAuthHeaderIfBound(message);
                return;
            }

            // The body is removed from the initial request because Key Vault supports other authentication schemes which also protect the body of the request.
            // As a result, before we know the auth scheme we need to avoid sending an unprotected body to Key Vault.
            // We don't currently support this enhanced auth scheme in the SDK but we still don't want to send any unprotected data to vaults which require it.

            // Do not overwrite previous contents if retrying after initial request failed (e.g. timeout).
            if (!message.TryGetProperty(KeyVaultStashedContentKey, out _))
            {
                message.SetProperty(KeyVaultStashedContentKey, message.Request.Content);
                message.Request.Content = null;
            }
        }

        /// <inheritdoc cref="BearerTokenAuthenticationPolicy.AuthorizeRequestOnChallengeAsync" />
        protected override ValueTask<bool> AuthorizeRequestOnChallengeAsync(HttpMessage message)
            => AuthorizeRequestOnChallengeAsyncInternal(message, true);

        /// <inheritdoc cref="BearerTokenAuthenticationPolicy.AuthorizeRequestOnChallenge" />
        protected override bool AuthorizeRequestOnChallenge(HttpMessage message)
            => AuthorizeRequestOnChallengeAsyncInternal(message, false).EnsureCompleted();

        /// <summary>
        /// Gets the claims parameter from the challenge response.
        /// If there are no claims, returns null.
        /// </summary>
        /// <param name="error">The error message from the service.</param>
        /// <param name="response">The response from the service which contains the headers.</param>
        /// <returns>A string with the decoded claims if present, otherwise null</returns>
        internal static string getDecodedClaimsParameter(string error, Response response)
        {
            // According to docs https://learn.microsoft.com/en-us/entra/identity-platform/claims-challenge?tabs=dotnet#claims-challenge-header-format,
            // the error message must be "insufficient_claims" when a claims challenge should be generated.
            if (error == "insufficient_claims")
            {
                return AuthorizationChallengeParser.GetChallengeParameterFromResponse(response, "Bearer", "claims") switch
                {
                    { Length: 0 } => null,
                    string enc => System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(enc))
                };
            }

            return null;
        }

        private async ValueTask<bool> AuthorizeRequestOnChallengeAsyncInternal(HttpMessage message, bool async)
        {
            if (message.Request.Content == null && message.TryGetProperty(KeyVaultStashedContentKey, out var content))
            {
                message.Request.Content = content as RequestContent;
            }

            string error = AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "Bearer", "error");
            string authority = GetRequestAuthority(message.Request);
            string scope = AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "Bearer", "resource");

            if (scope != null)
            {
                scope += "/.default";
            }
            else
            {
                scope = AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "Bearer", "scope");
            }

            // Handle CAE Challenges
            string claims = getDecodedClaimsParameter(error, message.Response);
            if (claims != null)
            {
                // Reuse the cached scope for this authority when present; on a cache miss keep the scope
                // parsed from this response instead of dereferencing a null challenge.
                if (s_challengeCache.TryGetValue(authority, out _challenge))
                {
                    scope = _challenge.Scopes[0];
                }
            }

            if (scope is null)
            {
                if (s_challengeCache.TryGetValue(authority, out _challenge))
                {
                    return false;
                }
            }
            else
            {
                // Verify the scope domain with leading "." matches the requested host domain.
                if (_verifyChallengeResource)
                {
                    if (!Uri.TryCreate(scope, UriKind.Absolute, out Uri scopeUri))
                    {
                        throw new InvalidOperationException($"The challenge contains invalid scope '{scope}'.");
                    }

                    if (!message.Request.Uri.Host.EndsWith($".{scopeUri.Host}", StringComparison.OrdinalIgnoreCase))
                    {
                        throw new InvalidOperationException($"The challenge resource '{scopeUri.Host}' does not match the requested domain. Set DisableChallengeResourceVerification to true in your client options to disable. See https://aka.ms/azsdk/blog/vault-uri for more information.");
                    }
                }

                string authorization = AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "Bearer", "authorization");
                if (authorization is null)
                {
                    authorization = AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "Bearer", "authorization_uri");
                }

                if (!Uri.TryCreate(authorization, UriKind.Absolute, out Uri authorizationUri))
                {
                    throw new UriFormatException($"The challenge authorization URI '{authorization}' is invalid.");
                }

                _challenge = new ChallengeParameters(authorizationUri, new string[] { scope });
                s_challengeCache[authority] = _challenge;
            }

            if (_challenge is null)
            {
                return false;
            }

            var context = new TokenRequestContext(
                _challenge.Scopes,
                parentRequestId: message.Request.ClientRequestId,
                tenantId: _challenge.TenantId,
                isCaeEnabled: true,
                claims: claims,
                isProofOfPossessionEnabled: _enableProofOfPossession,
                requestUri: message.Request.Uri.ToUri(),
                requestMethod: message.Request.Method.ToString());
            if (async)
            {
                await AuthenticateAndAuthorizeRequestAsync(message, context).ConfigureAwait(false);
            }
            else
            {
                AuthenticateAndAuthorizeRequest(message, context);
            }

            AddTokenBoundAuthHeaderIfBound(message);
            return true;
        }

        // Applies the token-bound auth outcome. The token is Proof-of-Possession bound when the negotiated
        // Authorization scheme is mtls_pop (managed-identity mTLS PoP) or pop - decided from the scheme actually
        // returned, not the requested flag. When it is bound but the binding certificate could not be applied to
        // the transport, fail closed with a clear error rather than sending a request the service cannot
        // authenticate. When it is bound and applied, advertise it with x-ms-tokenboundauth. Otherwise drop any
        // stale header so it cannot outlive its bound token.
        private void AddTokenBoundAuthHeaderIfBound(HttpMessage message)
        {
            bool isProofOfPossessionBound =
                message.Request.Headers.TryGetValue(HttpHeader.Names.Authorization, out string authorizationHeaderValue) &&
                (authorizationHeaderValue.StartsWith(MtlsPoPTokenTypePrefix, StringComparison.OrdinalIgnoreCase) ||
                 authorizationHeaderValue.StartsWith(PoPTokenTypePrefix, StringComparison.OrdinalIgnoreCase));

            if (isProofOfPossessionBound && _transportUpdateFailed)
            {
                throw new InvalidOperationException(TokenBindingFailedMessage);
            }

            if (isProofOfPossessionBound)
            {
                message.Request.Headers.SetValue(TokenBoundAuthHeaderName, "true");
            }
            else
            {
                // Not PoP-bound (e.g. a CAE re-auth returned a plain token) - drop any stale
                // x-ms-tokenboundauth so it cannot outlive its bound token.
                message.Request.Headers.Remove(TokenBoundAuthHeaderName);
            }
        }

        /// <inheritdoc />
        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsyncInternal(message, pipeline, true);
        }

        /// <inheritdoc />
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsyncInternal(message, pipeline, false).EnsureCompleted();
        }

        private async ValueTask ProcessAsyncInternal(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            if (message.Request.Uri.Scheme != Uri.UriSchemeHttps)
            {
                throw new InvalidOperationException("Bearer token authentication is not permitted for non TLS protected (https) endpoints.");
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

                // Handle the scenario in which we get a CAE challenge back.
                if (message.Response.Status == (int)HttpStatusCode.Unauthorized
                    && message.Response.Headers.Contains(HttpHeader.Names.WwwAuthenticate)
                    && AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "Bearer", "claims") != null)
                {
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
                // If we get a second CAE challenge, an unlikely scenario, we do not attempt to re-authenticate.
            }
        }

        internal class ChallengeParameters
        {
            internal ChallengeParameters(Uri authorizationUri, string[] scopes)
            {
                AuthorizationUri = authorizationUri;
                TenantId = authorizationUri.Segments[1].Trim('/');
                if (TenantId.Equals("dstsv2", StringComparison.OrdinalIgnoreCase) && authorizationUri.Segments.Length > 2)
                {
                    TenantId = authorizationUri.Segments[2].Trim('/');
                }
                Scopes = scopes;
            }

            /// <summary>
            /// Gets the "authorization" or "authorization_uri" parameter from the challenge response.
            /// </summary>
            public Uri AuthorizationUri { get; }

            /// <summary>
            /// Gets the "resource" or "scope" parameter from the challenge response. This should end with "/.default".
            /// </summary>
            public string[] Scopes { get; }

            /// <summary>
            /// Gets the tenant ID from <see cref="AuthorizationUri"/>.
            /// </summary>
            public string TenantId { get; }
        }

        internal static void ClearCache()
        {
            s_challengeCache.Clear();
        }

        /// <summary>
        /// Gets the host name and port of the Key Vault or Managed HSM endpoint.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private static string GetRequestAuthority(Request request)
        {
            Uri uri = request.Uri.ToUri();

            string authority = uri.Authority;
            if (!authority.Contains(":") && uri.Port > 0)
            {
                // Append port for complete authority.
                authority = uri.Authority + ":" + uri.Port.ToString(CultureInfo.InvariantCulture);
            }

            return authority;
        }
    }
}
