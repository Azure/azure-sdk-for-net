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
    internal partial class ApimPolicy : HttpPipelineSynchronousPolicy
    {
        private Uri _apimEndpoint;

        public ApimPolicy(Uri apimEndpoint) => _apimEndpoint = apimEndpoint;

        /// <inheritdoc/>
        public override void OnSendingRequest(HttpMessage message)
        {
            var originalUri = message.Request.Uri.ToUri();
            message.Request.Uri.Reset(_apimEndpoint);
            message.SetProperty("JWT_AUDIENCE", originalUri);
        }
    }
}
