// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault
{
    internal class ChallengeBasedAuthenticationPolicy : HttpPipelinePolicy
    {
        private const string BearerChallengePrefix = "Bearer ";
        private readonly TokenCredential _credential;

        private AuthenticationChallenge _challenge = null;

        private string _headerValue;

        private DateTimeOffset _refreshOn;

        public ChallengeBasedAuthenticationPolicy(TokenCredential credential)
        {
            _credential = credential;
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessCoreAsync(message, pipeline, false).GetAwaiter().GetResult();
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
            _challenge ??= AuthenticationChallenge.GetChallenge(message);

            // if we still don't have the challenge for the endpoint
            // remove the content from the request and send without authentication to get the challenge
            if (_challenge == null)
            {
                message.Request.Content = null;
            }
            // otherwise if we already know the challenge authenticate the request
            else
            {
                await AuthenticateRequestAsync(message, async).ConfigureAwait(false);
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
                var challenge = AuthenticationChallenge.GetChallenge(message);

                // if a challenge was returned and its different from the cached _challenge
                if (challenge != null && !challenge.Equals(_challenge))
                {
                    // update the cached challenge
                    _challenge = challenge;

                    // authenticate the request and resend
                    await AuthenticateRequestAsync(message, async).ConfigureAwait(false);

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

        private async Task AuthenticateRequestAsync(HttpMessage message, bool async)
        {
            if (DateTimeOffset.UtcNow >= _refreshOn)
            {
                AccessToken token = async ?
                        await _credential.GetTokenAsync(new TokenRequestContext(_challenge.Scopes), message.CancellationToken).ConfigureAwait(false) :
                        _credential.GetToken(new TokenRequestContext(_challenge.Scopes), message.CancellationToken);

                _headerValue = "Bearer " + token.Token;
                _refreshOn = token.ExpiresOn - TimeSpan.FromMinutes(2);
            }

            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, _headerValue);
        }

        internal class AuthenticationChallenge
        {
            private static readonly Dictionary<string, AuthenticationChallenge> _cache = new Dictionary<string, AuthenticationChallenge>();
            private static readonly object _cacheLock = new object();

            private AuthenticationChallenge(string scope)
            {
                Scopes = new string[] { scope };
            }

            public string[] Scopes { get; private set; }

            public override bool Equals(object obj)
            {
                if (base.Equals(obj))
                {
                    return true;
                }

                // This assumes that Scopes is always non-null and of length one.
                // This is guaranteed by the way the AuthenticationChallenge cache is constructed.
                if (obj is AuthenticationChallenge other)
                {
                    return string.Equals(Scopes[0], other.Scopes[0], StringComparison.OrdinalIgnoreCase);
                }

                return false;
            }

            public override int GetHashCode()
            {
                // Currently the hash code is simply the hash of the first scope as this is what is used to determine equality
                // This assumes that Scopes is always non-null and of length one.
                // This is guaranteed by the way the AuthenticationChallenge cache is constructed.
                return Scopes[0].GetHashCode();
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
                        lock (_cacheLock)
                        {
                            _cache[GetRequestAuthority(message.Request)] = challenge;
                        }
                    }
                }
                else
                {
                    // try to get the challenge from the cache
                    lock (_cacheLock)
                    {
                        _cache.TryGetValue(GetRequestAuthority(message.Request), out challenge);
                    }
                }

                return challenge;
            }

            internal static void ClearCache()
            {
                // try to get the challenge from the cache
                lock (_cacheLock)
                {
                    _cache.Clear();
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
                AuthenticationChallenge challenge = null;

                // remove the bearer challenge prefix
                var trimmedChallenge = challengeValue.Substring(BearerChallengePrefix.Length + 1);

                // Split the trimmed challenge into a set of name=value strings that
                // are comma separated. The value fields are expected to be within
                // quotation characters that are stripped here.
                string[] pairs = trimmedChallenge.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                if (pairs.Length > 0)
                {
                    // Process the name=value string
                    for (int i = 0; i < pairs.Length; i++)
                    {
                        string[] pair = pairs[i].Split('=');

                        if (pair.Length == 2)
                        {
                            // We have a key and a value, now need to trim and decode
                            string key = pair[0].Trim().Trim(new char[] { '\"' });
                            string value = pair[1].Trim().Trim(new char[] { '\"' });

                            if (!string.IsNullOrEmpty(key))
                            {
                                if (string.Equals(key, "scope", StringComparison.OrdinalIgnoreCase))
                                {
                                    challenge = new AuthenticationChallenge(value);

                                    break;
                                }
                                else if (string.Equals(key, "resource", StringComparison.OrdinalIgnoreCase))
                                {
                                    challenge = new AuthenticationChallenge(value + "/.default");
                                }
                            }
                        }
                    }
                }

                return challenge;
            }

            private static string GetRequestAuthority(Request request)
            {
                Uri uri = request.Uri.ToUri();

                string authority = uri.Authority;

                if (!authority.Contains(":") && uri.Port > 0)
                {
                    // Append port for complete authority
                    authority = $"{uri.Authority}:{uri.Port}";
                }

                return authority;
            }
        }
    }
}
