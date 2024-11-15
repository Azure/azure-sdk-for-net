// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault
{
    internal class ChallengeBasedAuthenticationPolicy : BearerTokenAuthenticationPolicy
    {
        private const string KeyVaultStashedContentKey = "KeyVaultContent";
        private readonly bool _verifyChallengeResource;

        /// <summary>
        /// Challenges are cached using the Key Vault or Managed HSM endpoint URI authority as the key.
        /// </summary>
        private static readonly ConcurrentDictionary<string, ChallengeParameters> s_challengeCache = new();
        private ChallengeParameters _challenge;

        public ChallengeBasedAuthenticationPolicy(TokenCredential credential, bool disableChallengeResourceVerification) : base(credential, Array.Empty<string>())
        {
            _verifyChallengeResource = !disableChallengeResourceVerification;
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
                var context = new TokenRequestContext(_challenge.Scopes, parentRequestId: message.Request.ClientRequestId, tenantId: _challenge.TenantId, isCaeEnabled: true);
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

            var context = new TokenRequestContext(_challenge.Scopes, parentRequestId: message.Request.ClientRequestId, tenantId: _challenge.TenantId, isCaeEnabled: true, claims: claims);
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
