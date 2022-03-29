// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Messaging.WebPubSub
{
    /// <summary>
    /// Web PubSub Authentication Policy.
    /// </summary>
    internal partial class WebPubSubAuthenticationPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly AzureKeyCredential _credential;
        private volatile KeyBytesCache _keyCache = new KeyBytesCache(string.Empty); // it's volatile so that the cache update below is not reordered

        /// <summary>
        /// Creates an instance of the authentication policy
        /// </summary>
        /// <param name="credential"></param>
        public WebPubSubAuthenticationPolicy(AzureKeyCredential credential) => _credential = credential;

        /// <inheritdoc/>
        public override void OnSendingRequest(HttpMessage message)
        {
            string audience;
            if (!TryGetAudience(message, out audience)) {
                audience = message.Request.Uri.ToUri().AbsoluteUri;
            }

            var now = DateTimeOffset.UtcNow;
            var expiresAt = now + TimeSpan.FromMinutes(5);

            var key = _credential.Key;
            var cache = _keyCache;
            if (!ReferenceEquals(key, cache.Key))
            {
                cache = new KeyBytesCache(key);
                _keyCache = cache;
            }

            var writer = new JwtBuilder(cache.KeyBytes);
            writer.AddClaim(JwtBuilder.Nbf, now);
            writer.AddClaim(JwtBuilder.Exp, expiresAt);
            writer.AddClaim(JwtBuilder.Iat, now);
            writer.AddClaim(JwtBuilder.Aud, audience);
            int jwtLength = writer.End();

            var prefix = "Bearer ";
            var state = (prefix, writer);
            var headerValue = NS2Bridge.CreateString(jwtLength + prefix.Length, state, (destination, state) => {
                var statePrefix = state.prefix;
                statePrefix.AsSpan().CopyTo(destination);
                state.writer.TryBuildTo(destination.Slice(statePrefix.Length), out _);
            });

            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, headerValue);
        }

        // this is to support API Management Server
        private const string AUDIENCE_SETTING = nameof(WebPubSubAuthenticationPolicy) + ".Audience";
        public static void SetAudience(HttpMessage message, Uri audience)
        {
            message.SetProperty(AUDIENCE_SETTING, audience.AbsoluteUri);
        }

        private static bool TryGetAudience(HttpMessage message, out string audience)
        {
            if (message.TryGetProperty(AUDIENCE_SETTING, out var jwtAudience) &&
            	jwtAudience is string uri)
            {
            	audience = uri;
                return true;
            }
            audience = default;
            return false;
        }

        private sealed class KeyBytesCache
        {
            public KeyBytesCache(string key)
            {
                Key = key;
                KeyBytes = Encoding.UTF8.GetBytes(key);
            }
            public readonly byte[] KeyBytes;
            public readonly string Key;
        }
    }
}
