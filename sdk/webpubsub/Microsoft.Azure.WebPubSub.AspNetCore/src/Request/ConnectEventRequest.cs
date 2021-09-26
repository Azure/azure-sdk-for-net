// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Connect event request.
    /// </summary>
    [JsonConverter(typeof(ConnectEventRequestJsonConverter))]
    public sealed class ConnectEventRequest : ServiceRequest
    {
        internal const string ClaimsProperty = "claims";
        internal const string QueryProperty = "query";
        internal const string SubprotocolsProperty = "subprotocols";
        internal const string ClientCertificatesProperty = "clientCertificates";

        /// <summary>
        /// User Claims.
        /// </summary>
        [JsonPropertyName(ClaimsProperty)]
        public IDictionary<string, string[]> Claims { get; }

        /// <summary>
        /// Query.
        /// </summary>
        [JsonPropertyName(QueryProperty)]
        public IDictionary<string, string[]> Query { get; }

        /// <summary>
        /// Supported subprotocols.
        /// </summary>
        [JsonPropertyName(SubprotocolsProperty)]
        public string[] Subprotocols { get; }

        /// <summary>
        /// Client certificates.
        /// </summary>
        [JsonPropertyName(ClientCertificatesProperty)]
        public ClientCertificateInfo[] ClientCertificates { get; }

        internal ConnectEventRequest(
            IDictionary<string, string[]> claims,
            IDictionary<string, string[]> query,
            string[] subprotocols,
            ClientCertificateInfo[] certificates) : base(null)
        {
            Claims = claims;
            Query = query;
            Subprotocols = subprotocols;
            ClientCertificates = certificates;
        }
    }
}
