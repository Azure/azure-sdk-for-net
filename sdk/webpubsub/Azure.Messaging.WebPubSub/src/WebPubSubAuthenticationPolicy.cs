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
        private static byte[] s_nbf = Encoding.UTF8.GetBytes("nbf");
        private static byte[] s_exp = Encoding.UTF8.GetBytes("exp");
        private static byte[] s_iat = Encoding.UTF8.GetBytes("iat");
        private static byte[] s_aud = Encoding.UTF8.GetBytes("aud");

        private readonly AzureKeyCredential _credential;

        /// <summary>
        /// Creates an instance of the authentication policy
        /// </summary>
        /// <param name="credential"></param>
        public WebPubSubAuthenticationPolicy(AzureKeyCredential credential) => _credential = credential;

        /// <inheritdoc/>
        public override void OnSendingRequest(HttpMessage message)
        {
            string audience = message.Request.Uri.ToUri().AbsoluteUri;
            var now = DateTimeOffset.UtcNow;
            var expiresAt = now + TimeSpan.FromMinutes(10);

            var keyBytes = Convert.FromBase64String(_credential.Key);

            var writer = new JwtBuilder(keyBytes);
            writer.AddClaim(s_nbf, now);
            writer.AddClaim(s_exp, expiresAt);
            writer.AddClaim(s_iat, now);
            writer.AddClaim(s_aud, audience);
            int jwtLength = writer.Build();

            var prefix = "Bearer ";
            var state = (prefix, writer);
            var headerValue = NS2Bridge.CreateString(jwtLength + prefix.Length, state, (destination, state) => {
                var statePrefix = state.prefix;
                statePrefix.AsSpan().CopyTo(destination);
                state.writer.TryWriteTo(destination.Slice(statePrefix.Length), out _);
            });

            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, headerValue);
        }
    }
}
