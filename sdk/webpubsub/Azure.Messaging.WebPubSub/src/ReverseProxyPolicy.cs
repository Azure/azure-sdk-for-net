// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Messaging.WebPubSub
{
    /// <summary>
    /// The reverse proxy policy.
    /// </summary>
    internal partial class ReverseProxyPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly Uri _reverseProxyEndpoint;

        public ReverseProxyPolicy(Uri reverseProxyEndpoint) => _reverseProxyEndpoint = reverseProxyEndpoint;

        /// <inheritdoc/>
        public override void OnSendingRequest(HttpMessage message)
        {
            var originalUri = message.Request.Uri.ToUri();
            var path = originalUri.PathAndQuery;
            message.Request.Uri.Reset(_reverseProxyEndpoint);
            message.Request.Uri.AppendPath(path, escape: false);
            WebPubSubAuthenticationPolicy.SetAudience(message, originalUri);
        }
    }
}
