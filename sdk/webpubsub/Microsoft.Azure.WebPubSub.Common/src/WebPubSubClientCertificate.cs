// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

#nullable enable

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// Client certificate info.
    /// </summary>
    [JsonConverter(typeof(WebPubSubClientCertificateJsonConverter))]
    [DataContract]
    public sealed class WebPubSubClientCertificate
    {
        internal const string ThumbprintProperty = "thumbprint";
        internal const string ContentProperty = "content";
        /// <summary>
        /// Certificate thumbprint.
        /// </summary>
        [JsonPropertyName(ThumbprintProperty)]
        // As the released version already used PascalCase, we keep it for backward-compatibility.
        [DataMember]
        public string Thumbprint { get; }

        /// <summary>
        /// Certificate content.
        /// </summary>
        [JsonPropertyName(ContentProperty)]
        [DataMember(Name = ContentProperty)]
        public string? Content { get; }

        /// <summary>
        /// Create an instance of WebPubSubClientCertificate.
        /// </summary>
        /// <param name="thumbprint">The thumbprint of client cert.</param>
        public WebPubSubClientCertificate(string thumbprint)
        {
            Thumbprint = thumbprint;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebPubSubClientCertificate"/> class.
        /// </summary>
        /// <param name="thumbprint"></param>
        /// <param name="content"></param>
        public WebPubSubClientCertificate(string thumbprint, string? content)
        {
            Content = content;
            Thumbprint = thumbprint;
        }
    }
}
