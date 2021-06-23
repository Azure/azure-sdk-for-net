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
            var expiresAt = now + TimeSpan.FromMinutes(5);

            // TODO: is this a bug in the service?
            // The service accepts ASCII of the portal key, but not Base64 decoded.
            //
            //var keyBytes = Convert.FromBase64String(_credential.Key);
            var keyBytes = Encoding.UTF8.GetBytes(_credential.Key);

            var writer = new JwtBuilder(keyBytes);
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
                state.writer.TryWriteTo(destination.Slice(statePrefix.Length), out _);
            });

            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, headerValue);
        }
    }
}
