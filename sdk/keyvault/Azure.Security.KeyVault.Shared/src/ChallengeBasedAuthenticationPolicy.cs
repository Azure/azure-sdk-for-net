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
    internal class ChallengeBasedAuthenticationPolicy : BearerTokenChallengeAuthenticationPolicy
    {
        private const string BearerChallengePrefix = "Bearer ";

        private AuthenticationChallenge _challenge;

        public ChallengeBasedAuthenticationPolicy(TokenCredential credential) : base(credential, Array.Empty<string>())
        { }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            PreProcessAsync(message, pipeline, false).EnsureCompleted();
            base.Process(message, pipeline);
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            await PreProcessAsync(message, pipeline, true).ConfigureAwait(false);
            await base.ProcessAsync(message, pipeline).ConfigureAwait(false);
        }

        protected async Task PreProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            if (message.Request.Uri.Scheme != Uri.UriSchemeHttps)
            {
                throw new InvalidOperationException("Bearer token authentication is not permitted for non TLS protected (https) endpoints.");
            }

            // if this policy doesn't have _challenge cached try to get it from the static challenge cache
            AuthenticationChallenge challenge = _challenge ?? AuthenticationChallenge.GetChallenge(message);

            // if we don't have the challenge for the endpoint, remove the content from the request and send without authentication to get the challenge
            if (challenge == null)
            {
                RequestContent originalContent = message.Request.Content;
                message.Request.Content = null;

                if (async)
                {
                    await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                }
                else
                {
                    ProcessNext(message, pipeline);
                }

                // set the content to the original content.
                message.Request.Content = originalContent;
            }
        }

        protected override bool TryGetTokenRequestContextFromChallenge(HttpMessage message, out TokenRequestContext context)
        {
            // if this policy doesn't have _challenge cached try to get it from the static challenge cache
            AuthenticationChallenge challenge = AuthenticationChallenge.GetChallenge(message);

            if (challenge == null)
            {
                return false;
            }

            // update the cached challenge if not yet set or different from the current challenge (e.g. moved tenants)
            if (_challenge == null || !challenge.Equals(_challenge))
            {
                _challenge = challenge;
            }

            context = new TokenRequestContext(_challenge.Scopes, message.Request.ClientRequestId);
            return true;
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
