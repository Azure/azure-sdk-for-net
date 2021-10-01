// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json.Serialization;

namespace Azure.Messaging.WebPubSub
{
    /// <summary>
    /// Connect event request.
    /// </summary>
    [JsonConverter(typeof(ConnectEventRequestJsonConverter))]
    public sealed class ConnectEventRequest : WebPubSubEventRequest
    {
        internal const string ClaimsProperty = "claims";
        internal const string QueryProperty = "query";
        internal const string SubprotocolsProperty = "subprotocols";
        internal const string ClientCertificatesProperty = "clientCertificates";

        /// <summary>
        /// User Claims.
        /// </summary>
        [JsonPropertyName(ClaimsProperty)]
        public ReadOnlyDictionary<string, string[]> Claims { get; }

        /// <summary>
        /// Query.
        /// </summary>
        [JsonPropertyName(QueryProperty)]
        public ReadOnlyDictionary<string, string[]> Query { get; }

        /// <summary>
        /// Supported subprotocols.
        /// </summary>
        [JsonPropertyName(SubprotocolsProperty)]
        public string[] Subprotocols { get; }

        /// <summary>
        /// Client certificates.
        /// </summary>
        [JsonPropertyName(ClientCertificatesProperty)]
        public WebPubSubClientCertificate[] ClientCertificates { get; }

        /// <summary>
        /// Create <see cref="ConnectEventResponse"/>.
        /// </summary>
        /// <param name="userId">Caller userId for current connection.</param>
        /// <param name="subprotocol">Subprotocol applied to current connection.</param>
        /// <param name="roles">User roles applied to current connection.</param>
        /// <param name="groups">Groups applied to current connection.</param>
        /// <returns>A connect response to return service.</returns>
#pragma warning disable CA1822 // Mark members as static
        public WebPubSubEventResponse CreateResponse(string userId, string subprotocol, IEnumerable<string> roles, IEnumerable<string> groups)
#pragma warning restore CA1822 // Mark members as static
        {
            return new ConnectEventResponse
            {
                UserId = userId,
                Subprotocol = subprotocol,
                Roles = roles.ToArray(),
                Groups = groups.ToArray()
            };
        }

        /// <summary>
        /// Create <see cref="EventErrorResponse"/>.
        /// </summary>
        /// <param name="code"><see cref="WebPubSubErrorCode"/>.</param>
        /// <param name="message">Detail error message.</param>
        /// <returns>A error response to return caller and will drop connection.</returns>
#pragma warning disable CA1822 // Mark members as static
        public WebPubSubEventResponse CreateErrorResponse(WebPubSubErrorCode code, string message)
#pragma warning restore CA1822 // Mark members as static
        {
            return new EventErrorResponse(code, message);
        }

        internal ConnectEventRequest(
            IDictionary<string, string[]> claims,
            IDictionary<string, string[]> query,
            IEnumerable<string> subprotocols,
            IEnumerable<WebPubSubClientCertificate> certificates) : this(null, claims, query, subprotocols, certificates)
        {
        }

        internal ConnectEventRequest(
            WebPubSubConnectionContext context,
            IDictionary<string, string[]> claims,
            IDictionary<string, string[]> query,
            IEnumerable<string> subprotocols,
            IEnumerable<WebPubSubClientCertificate> certificates) : base(context)
        {
            Claims = new ReadOnlyDictionary<string, string[]>(claims);
            Query = new ReadOnlyDictionary<string, string[]>(query);
            Subprotocols = subprotocols.ToArray();
            ClientCertificates = certificates.ToArray();
        }
    }
}
