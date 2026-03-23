// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.Blobs
{
    internal class DataLocalityPolicy : HttpPipelineSynchronousPolicy
    {
        internal const string IdealEndpointKey = "IdealEndpoint";

        public static DataLocalityPolicy Shared { get; } = new DataLocalityPolicy();

        private DataLocalityPolicy()
        {
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            if (message.TryGetProperty(IdealEndpointKey, out var value)
                && value is string endpoint
                && !string.IsNullOrEmpty(endpoint))
            {
                string originalHost = message.Request.Uri.Host;

                var uri = new Uri(endpoint);
                message.Request.Uri.Host = uri.Host;
                message.Request.Uri.Port = uri.Port;

                message.Request.Headers.SetValue("Host", originalHost);
            }
        }
    }
}
