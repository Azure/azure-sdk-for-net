// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http.Headers;
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
            string accessToken = JwtUtils.GenerateJwtBearer(audience, claims: null, expiresAfter: TimeSpan.FromMinutes(10), _credential);

            var header = new AuthenticationHeaderValue("Bearer", accessToken);
            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, header.ToString());
        }
    }
}
