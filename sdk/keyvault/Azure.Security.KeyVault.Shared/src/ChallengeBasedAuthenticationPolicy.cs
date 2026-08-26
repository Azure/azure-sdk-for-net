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
        private static readonly Type[] s_updateParameterTypes = [typeof(HttpPipelineTransportOptions)];
        private readonly bool _verifyChallengeResource;
        private readonly bool _enableProofOfPossession;

        /// <summary>
        /// Set when applying a Proof-of-Possession binding certificate to the transport fails; read by
        /// <see cref="AddTokenBoundAuthHeaderIfBound(HttpMessage)"/> to suppress <c>x-ms-tokenboundauth</c> in that
        /// case. See <see cref="OnTransportOptionsChanged(HttpPipelineTransportOptions)"/> for details and known
        /// limitations. Volatile only for cross-thread visibility, matching the base class's own best-effort,
        /// lock-free tracking of <c>_lastBindingCertificate</c> on the same instance.
        /// </summary>
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
        /// Applies a Proof-of-Possession binding certificate to the transport when the credential returns one.
        /// </summary>
        /// <remarks>
        /// <see cref="SupportsProofOfPossession(HttpPipelineTransport)"/> can't always predict whether
        /// <see cref="HttpPipelineTransport.Update"/> will succeed on the actual transport instance: for example
        /// <see cref="HttpClientTransport.Shared"/> throws <see cref="InvalidOperationException"/> because it can
        /// never be updated, and a customer-supplied <see cref="HttpClientTransport"/> without a rebuild factory
        /// silently no-ops. This override catches the former so a request never crashes because of it, and sets
        /// <see cref="_transportUpdateFailed"/> so the token-bound header isn't sent. The no-op case can't be
        /// detected the same way -- <c>Update</c> has no way to report that it declined -- so the header may still
        /// be sent without the certificate actually applied there; that needs a first-class Azure.Core capability
        /// check as a follow-up.
        /// </remarks>
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
                // Get the scope from the cache
                s_challengeCache.TryGetValue(authority, out _challenge);
                scope = _challenge.Scopes[0];
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

        /// <summary>
        /// Adds the token-bound auth header only when the token actually acquired for this request is
        /// Proof-of-Possession (PoP) bound. Requesting PoP via <see cref="TokenRequestContext.IsProofOfPossessionEnabled"/>
        /// does not guarantee the credential honors it — the credential may not support PoP, or the current
        /// environment may not support token binding — in which case a normal Bearer token is returned. The header
        /// must reflect what was actually negotiated, not merely what was requested, so it is set based on the
        /// scheme of the Authorization header written by <see cref="BearerTokenAuthenticationPolicy"/> rather than
        /// on the request's <see cref="TokenRequestContext.IsProofOfPossessionEnabled"/> flag. It also checks
        /// <see cref="_transportUpdateFailed"/> so the header is never sent when the binding certificate could not
        /// actually be applied to the transport (see <see cref="OnTransportOptionsChanged(HttpPipelineTransportOptions)"/>).
        /// </summary>
        private void AddTokenBoundAuthHeaderIfBound(HttpMessage message)
        {
            if (!_transportUpdateFailed &&
                message.Request.Headers.TryGetValue(HttpHeader.Names.Authorization, out string authorizationHeaderValue) &&
                authorizationHeaderValue.StartsWith(PoPTokenTypePrefix, StringComparison.OrdinalIgnoreCase))
            {
                message.Request.Headers.SetValue(TokenBoundAuthHeaderName, "true");
            }
            else
            {
                // The token acquired for this (re-)authorization is not Proof-of-Possession bound - for example a
                // CAE re-authorization on the same message returned a plain bearer token, or the binding
                // certificate could not be applied to the transport. Remove any x-ms-tokenboundauth set on an
                // earlier attempt so the header never outlives the bound token it was meant to signal.
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
