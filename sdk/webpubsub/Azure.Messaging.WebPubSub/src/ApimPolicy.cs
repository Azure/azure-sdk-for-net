// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Messaging.WebPubSub
{
    /// <summary>
    /// API Management Policy
    /// </summary>
    internal partial class ApimPolicy : HttpPipelineSynchronousPolicy
    {
        private Uri _apimEndpoint;

        public ApimPolicy(Uri apimEndpoint) => _apimEndpoint = apimEndpoint;

        /// <inheritdoc/>
        public override void OnSendingRequest(HttpMessage message)
        {
            var originalUri = message.Request.Uri.ToUri();
            var path = originalUri.PathAndQuery;
            message.Request.Uri.Reset(_apimEndpoint);
            message.Request.Uri.AppendPath(path, escape: false);
            WebPubSubAuthenticationPolicy.SetAudience(message, originalUri);
        }
    }
}
