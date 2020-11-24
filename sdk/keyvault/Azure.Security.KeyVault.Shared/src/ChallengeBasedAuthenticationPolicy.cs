// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault
{
    internal class ChallengeBasedAuthenticationPolicy : HttpPipelinePolicy
    {
        private const string BearerChallengePrefix = "Bearer ";

        private readonly TokenCredential _credential;

        private AuthenticationChallenge _challenge;
        private string _headerValue;
        private DateTimeOffset _refreshOn;

        public ChallengeBasedAuthenticationPolicy(TokenCredential credential)
        {
            _credential = credential;
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessCoreAsync(message, pipeline, false).EnsureCompleted();
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessCoreAsync(message, pipeline, true);
        }

        private async ValueTask ProcessCoreAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            if (message.Request.Uri.Scheme != Uri.UriSchemeHttps)
            {
                throw new InvalidOperationException("Bearer token authentication is not permitted for non TLS protected (https) endpoints.");
            }

            RequestContent originalContent = message.Request.Content;

            // if this policy doesn't have _challenge cached try to get it from the static challenge cache
            AuthenticationChallenge challenge = _challenge ?? AuthenticationChallenge.GetChallenge(message);

            // if we still don't have the challenge for the endpoint
            // remove the content from the request and send without authentication to get the challenge
            if (challenge == null)
            {
                message.Request.Content = null;
            }
            // otherwise if we already know the challenge authenticate the request
            else
            {
                await AuthenticateRequestAsync(message, async, challenge).ConfigureAwait(false);
            }

            if (async)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
            }

            // if we get a 401
            if (message.Response.Status == 401)
            {
                // set the content to the original content in case it was cleared
                message.Request.Content = originalContent;

                // update the cached challenge
                challenge = AuthenticationChallenge.GetChallenge(message);

                if (challenge != null)
                {
                    // update the cached challenge if not yet set or different from the current challenge (e.g. moved tenants)
                    if (_challenge == null || !challenge.Equals(_challenge))
                    {
                        _challenge = challenge;
                    }

                    // authenticate the request and resend
                    await AuthenticateRequestAsync(message, async, challenge).ConfigureAwait(false);

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

        private async Task AuthenticateRequestAsync(HttpMessage message, bool async, AuthenticationChallenge challenge)
        {
            if (_headerValue is null || DateTimeOffset.UtcNow >= _refreshOn)
            {
                AccessToken token = async ?
                        await _credential.GetTokenAsync(new TokenRequestContext(challenge.Scopes, message.Request.ClientRequestId), message.CancellationToken).ConfigureAwait(false) :
                        _credential.GetToken(new TokenRequestContext(challenge.Scopes, message.Request.ClientRequestId), message.CancellationToken);

                _headerValue = BearerChallengePrefix + token.Token;
                _refreshOn = token.ExpiresOn - TimeSpan.FromMinutes(2);
            }

            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, _headerValue);
        }

        internal class AuthenticationChallenge
        {
            private static readonly Dictionary<string, AuthenticationChallenge> s_cache = new Dictionary<string, AuthenticationChallenge>();
            private static readonly object s_cacheLock = new object();
            private static readonly string[] s_challengeDelimiters = new string[] { "," };

            private AuthenticationChallenge(string authority, string scope)
            {
                Authority = authority;
                Scopes = new string[] { scope };
            }

            public string Authority { get; }

            public string[] Scopes { get; }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(this, obj))
                {
                    return true;
                }

                // This assumes that Authority Scopes are always non-null and Scopes has a length of one.
                // This is guaranteed by the way the AuthenticationChallenge cache is constructed.
                if (obj is AuthenticationChallenge other)
                {
                    return string.Equals(Authority, other.Authority, StringComparison.OrdinalIgnoreCase)
                        && string.Equals(Scopes[0], other.Scopes[0], StringComparison.OrdinalIgnoreCase);
                }

                return false;
            }

            public override int GetHashCode()
            {
                // Currently the hash code is simply the hash of the authority and first scope as this is what is used to determine equality.
                // This assumes that Authority Scopes are always non-null and Scopes has a length of one.
                // This is guaranteed by the way the AuthenticationChallenge cache is constructed.
                return HashCodeBuilder.Combine(Authority, Scopes[0]);
            }

            public static AuthenticationChallenge GetChallenge(HttpMessage message)
            {
                AuthenticationChallenge challenge = null;

                if (message.HasResponse)
                {
                    challenge = GetChallengeFromResponse(message.Response);

                    // if the challenge is non-null cache it
                    if (challenge != null)
                    {
                        string authority = GetRequestAuthority(message.Request);
                        lock (s_cacheLock)
                        {
                            s_cache[authority] = challenge;
                        }
                    }
                }
                else
                {
                    // try to get the challenge from the cache
                    string authority = GetRequestAuthority(message.Request);
                    lock (s_cacheLock)
                    {
                        s_cache.TryGetValue(authority, out challenge);
                    }
                }

                return challenge;
            }

            internal static void ClearCache()
            {
                // try to get the challenge from the cache
                lock (s_cacheLock)
                {
                    s_cache.Clear();
                }
            }

            private static AuthenticationChallenge GetChallengeFromResponse(Response response)
            {
                AuthenticationChallenge challenge = null;

                if (response.Headers.TryGetValue("WWW-Authenticate", out string challengeValue) && challengeValue.StartsWith(BearerChallengePrefix, StringComparison.OrdinalIgnoreCase))
                {
                    challenge = ParseBearerChallengeHeaderValue(challengeValue);
                }

                return challenge;
            }

            private static AuthenticationChallenge ParseBearerChallengeHeaderValue(string challengeValue)
            {
                string authority = null;
                string scope = null;

                // remove the bearer challenge prefix
                var trimmedChallenge = challengeValue.Substring(BearerChallengePrefix.Length);

                // Split the trimmed challenge into a set of name=value strings that
                // are comma separated. The value fields are expected to be within
                // quotation characters that are stripped here.
                string[] pairs = trimmedChallenge.Split(s_challengeDelimiters, StringSplitOptions.RemoveEmptyEntries);

                if (pairs.Length > 0)
                {
                    // Process the name=value string
                    for (int i = 0; i < pairs.Length; i++)
                    {
                        string[] pair = pairs[i].Split('=');

                        if (pair.Length == 2)
                        {
                            // We have a key and a value, now need to trim and decode
                            string key = pair[0].AsSpan().Trim().Trim('\"').ToString();
                            string value = pair[1].AsSpan().Trim().Trim('\"').ToString();

                            if (!string.IsNullOrEmpty(key))
                            {
                                // Ordered by current likelihood.
                                if (string.Equals(key, "authorization", StringComparison.OrdinalIgnoreCase))
                                {
                                    authority = value;
                                }
                                else if (string.Equals(key, "resource", StringComparison.OrdinalIgnoreCase))
                                {
                                    scope = value + "/.default";
                                }
                                else if (string.Equals(key, "scope", StringComparison.OrdinalIgnoreCase))
                                {
                                    scope = value;
                                }
                                else if (string.Equals(key, "authorization_uri", StringComparison.OrdinalIgnoreCase))
                                {
                                    authority = value;
                                }
                            }
                        }
                    }
                }

                if (authority != null && scope != null)
                {
                    return new AuthenticationChallenge(authority, scope);
                }

                return null;
            }

            private static string GetRequestAuthority(Request request)
            {
                Uri uri = request.Uri.ToUri();

                string authority = uri.Authority;

                if (!authority.Contains(":") && uri.Port > 0)
                {
                    // Append port for complete authority
                    authority = uri.Authority + ":" + uri.Port.ToString(CultureInfo.InvariantCulture);
                }

                return authority;
            }
        }
    }
}
