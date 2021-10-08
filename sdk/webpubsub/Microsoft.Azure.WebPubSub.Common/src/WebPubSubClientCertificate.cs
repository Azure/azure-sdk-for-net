// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// Client certificate info.
    /// </summary>
    [JsonConverter(typeof(WebPubSubClientCertificateJsonConverter))]
    public sealed class WebPubSubClientCertificate
    {
        internal const string ThumbprintProperty = "thumbprint";
        /// <summary>
        /// Certificate thumbprint.
        /// </summary>
        [JsonPropertyName(ThumbprintProperty)]
        public string Thumbprint { get; }

        /// <summary>
        /// Create an instance of WebPubSubClientCertificate.
        /// </summary>
        /// <param name="thumbprint">The thumbprint of client cert.</param>
        public WebPubSubClientCertificate(string thumbprint)
        {
            Thumbprint = thumbprint;
        }
    }
}
