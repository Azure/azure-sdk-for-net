// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Client certificate info.
    /// </summary>
    public sealed class WebPubSubClientCertificate
    {
        /// <summary>
        /// Certificate thumbprint.
        /// </summary>
        public string Thumbprint { get; set; }
    }
}
