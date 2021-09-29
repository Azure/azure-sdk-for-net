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
    public sealed class ConnectEventRequest : WebPubSubRequest
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

        /// <summary>
        /// Create <see cref="ConnectResponse"/>.
        /// </summary>
        /// <param name="userId">Caller userId for current connection.</param>
        /// <param name="subprotocol">Subprotocol applied to current connection.</param>
        /// <param name="roles">User roles applied to current connection.</param>
        /// <param name="groups">Groups applied to current connection.</param>
        /// <returns>A <see cref="ConnectResponse"/> to return caller.</returns>
        public ConnectResponse CreateResponse(string userId, string subprotocol, string[] roles, string[] groups)
        {
            return new ConnectResponse
            {
                UserId = userId,
                Subprotocol = subprotocol,
                Roles = roles,
                Groups = groups
            };
        }

        /// <summary>
        /// Create <see cref="ErrorResponse"/>.
        /// </summary>
        /// <param name="code"><see cref="WebPubSubErrorCode"/>.</param>
        /// <param name="message">Detail error message.</param>
        /// <returns>A <see cref="ErrorResponse"/> to return caller.</returns>
        public ErrorResponse CreateErrorResponse(WebPubSubErrorCode code, string message)
        {
            return new ErrorResponse(code, message);
        }

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
