// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    /// <summary>
    /// Pipeline policy that, when an ideal endpoint has been set on the
    /// <see cref="HttpMessage"/> properties under <see cref="LayoutEndpointKey"/>,
    /// rewrites the outgoing request URI to that endpoint while preserving the
    /// original host on the Host header.
    /// </summary>
    /// <remarks>
    /// This policy is currently used only by the Blob and Data Lake parallel
    /// download paths. It is a no-op for any request that does not opt in by
    /// setting the <see cref="LayoutEndpointKey"/> property on the message.
    /// </remarks>
    internal class DataLocalityPolicy : HttpPipelineSynchronousPolicy
    {
        internal const string LayoutEndpointKey = "Azure.Storage.LayoutEndpoint";

        public static DataLocalityPolicy Shared { get; } = new DataLocalityPolicy();

        private DataLocalityPolicy()
        {
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            if (message.TryGetProperty(LayoutEndpointKey, out var value)
                && value is string endpoint
                && !string.IsNullOrEmpty(endpoint))
            {
                string originalHostHeader = message.Request.Uri.ToUri().Authority;

                var uri = new Uri(endpoint);
                message.Request.Uri.Host = uri.Host;
                message.Request.Uri.Port = uri.Port;

                message.Request.Headers.SetValue("Host", originalHostHeader);
            }
        }
    }
}
