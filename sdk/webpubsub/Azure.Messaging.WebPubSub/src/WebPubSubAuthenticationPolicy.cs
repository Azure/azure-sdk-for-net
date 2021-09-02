// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Messaging.WebPubSub
{
    /// <summary>
    /// Web PubSub Authentication Policy.
    /// </summary>
    internal partial class WebPubSubAuthenticationPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly ITokenProvider _tokenProvider;

        /// <summary>
        /// Creates an instance of the authentication policy.
        /// </summary>
        /// <param name="tokenProvider"></param>
        public WebPubSubAuthenticationPolicy(ITokenProvider tokenProvider) => _tokenProvider = tokenProvider;

        /// <inheritdoc/>
        public override void OnSendingRequest(HttpMessage message)
        {
            if (!TryGetAudience(message, out string audience))
            {
                audience = message.Request.Uri.ToUri().AbsoluteUri;
            }
            var token = _tokenProvider.GetServerToken(audience).Token;
            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, $"Bearer {token}");
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
    }
}
