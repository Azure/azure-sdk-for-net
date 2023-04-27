// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Connect event request.
    /// </summary>
    public sealed class ConnectEventRequest : WebPubSubEventRequest
    {
        /// <summary>
        /// User Claims.
        /// </summary>
        [JsonPropertyName("claims")]
        public IReadOnlyDictionary<string, string[]> Claims { get; set; }

        /// <summary>
        /// Request query.
        /// </summary>
        [JsonPropertyName("query")]
        public IReadOnlyDictionary<string, string[]> Query { get; set; }

        /// <summary>
        /// Request headers.
        /// </summary>
        [JsonPropertyName("headers")]
        public IReadOnlyDictionary<string, string[]> Headers { get; set; }

        /// <summary>
        /// Supported subprotocols.
        /// </summary>
        [JsonPropertyName("subprotocols")]
        public IReadOnlyList<string> Subprotocols { get; set; }

        /// <summary>
        /// Client certificates.
        /// </summary>
        [JsonPropertyName("clientCertificates")]
        public IReadOnlyList<WebPubSubClientCertificate> ClientCertificates { get; set; }

        /// <summary>
        /// Create <see cref="ConnectEventResponse"/>.
        /// </summary>
        /// <param name="userId">Caller userId for current connection.</param>
        /// <param name="subprotocol">Subprotocol applied to current connection.</param>
        /// <param name="roles">User roles applied to current connection.</param>
        /// <param name="groups">Groups applied to current connection.</param>
        /// <returns>A connect response to return service.</returns>
        public static ConnectEventResponse CreateResponse(string userId, IEnumerable<string> groups, string subprotocol, IEnumerable<string> roles)
        {
            return new ConnectEventResponse(userId, groups, subprotocol, roles);
        }

        /// <summary>
        /// Create <see cref="EventErrorResponse"/>.
        /// Methods works for Function Extensions. And AspNetCore SDK Hub methods can directly throw exception for error cases.
        /// </summary>
        /// <param name="code"><see cref="WebPubSubErrorCode"/>.</param>
        /// <param name="message">Detail error message.</param>
        /// <returns>A error response to return caller and will drop connection.</returns>
        public static EventErrorResponse CreateErrorResponse(WebPubSubErrorCode code, string message)
        {
            return new EventErrorResponse(code, message);
        }
    }
}
