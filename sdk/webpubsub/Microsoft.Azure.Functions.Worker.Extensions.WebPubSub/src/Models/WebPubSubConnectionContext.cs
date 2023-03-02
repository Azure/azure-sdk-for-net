// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.Azure.WebPubSub.Common;

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Request context from headers following CloudEvents.
    /// </summary>
    public sealed class WebPubSubConnectionContext
    {
        /// <summary>
        /// The type of the message.
        /// </summary>
        [JsonPropertyName("eventType")]
        public WebPubSubEventType EventType { get; set; }

        /// <summary>
        /// The event name of the message.
        /// </summary>
        [JsonPropertyName("eventName")]
        public string EventName { get; set; }

        /// <summary>
        /// The hub which the connection belongs to.
        /// </summary>
        [JsonPropertyName("hub")]
        public string Hub { get; set; }

        /// <summary>
        /// The connection-id of the client.
        /// </summary>
        [JsonPropertyName("connectionId")]
        public string ConnectionId { get; set; }

        /// <summary>
        /// The user identity of the client.
        /// </summary>
        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        /// <summary>
        /// The signature for validation.
        /// </summary>
        [JsonPropertyName("signature")]
        public string Signature { get; set; }

        /// <summary>
        /// Upstream origin.
        /// </summary>
        [JsonPropertyName("origin")]
        public string Origin { get; set; }

        /// <summary>
        /// The connection states.
        /// </summary>
        [JsonConverter(typeof(ConnectionStatesConverter))]
        [JsonPropertyName("states")]
        public IReadOnlyDictionary<string, BinaryData> ConnectionStates { get; set; }

        /// <summary>
        /// The headers of request.
        /// </summary>
        [JsonPropertyName("headers")]
        public IReadOnlyDictionary<string, string[]> Headers { get; set; }
    }
}
