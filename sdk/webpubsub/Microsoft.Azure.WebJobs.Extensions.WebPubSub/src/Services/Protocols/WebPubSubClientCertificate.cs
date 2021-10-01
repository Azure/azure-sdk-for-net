// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Messaging.WebPubSub
{
    /// <summary>
    /// Client certificate info.
    /// </summary>
    public sealed class WebPubSubClientCertificate
    {
        /// <summary>
        /// Certificate thumbprint.
        /// </summary>
        [JsonPropertyName("thumbprint")]
        public string Thumbprint { get; }

        public WebPubSubClientCertificate(string thumbprint)
        {
            Thumbprint = thumbprint;
        }
    }
}
