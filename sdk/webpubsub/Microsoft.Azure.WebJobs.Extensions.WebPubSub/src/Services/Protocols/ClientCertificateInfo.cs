// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Client certificate info.
    /// </summary>
    public sealed class ClientCertificateInfo
    {
        /// <summary>
        /// Certificate thumbprint.
        /// </summary>
        [JsonPropertyName("thumbprint")]
        public string Thumbprint { get; set; }
    }
}
