// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// Request context from headers following CloudEvents.
    /// </summary>
    public class WebPubSubConnectionContext
    {
        /// <summary>
        /// The type of the message.
        /// </summary>
        [JsonPropertyName("eventType")]
        public WebPubSubEventType EventType { get; }

        /// <summary>
        /// The event name of the message.
        /// </summary>
        [JsonPropertyName("eventName")]
        public string EventName { get; }

        /// <summary>
        /// The hub which the connection belongs to.
        /// </summary>
        [JsonPropertyName("hub")]
        public string Hub { get; }

        /// <summary>
        /// The connection-id of the client.
        /// </summary>
        [JsonPropertyName("connectionId")]
        public string ConnectionId { get; }

        /// <summary>
        /// The user identity of the client.
        /// </summary>
        [JsonPropertyName("userId")]
        public string UserId { get; }

        /// <summary>
        /// The signature for validation.
        /// </summary>
        [JsonPropertyName("signature")]
        public string Signature { get; }

        /// <summary>
        /// Upstream origin.
        /// </summary>
        [JsonPropertyName("origin")]
        public string Origin { get; }

        /// <summary>
        /// The connection states.
        /// </summary>
        [JsonPropertyName("states")]
        public IReadOnlyDictionary<string, object> States { get; }

        /// <summary>
        /// The headers of request.
        /// </summary>
        [JsonPropertyName("headers")]
        public IReadOnlyDictionary<string, string[]> Headers { get; }

        /// <summary>
        /// The client connection context
        /// </summary>
        /// <param name="eventType">Event type</param>
        /// <param name="eventName">Event name</param>
        /// <param name="hub">Hub name</param>
        /// <param name="connectionId">Connection Id</param>
        /// <param name="userId">User Id</param>
        /// <param name="signature">Signature of the connection</param>
        /// <param name="origin">Origin of the event</param>
        /// <param name="states">Connection states</param>
        /// <param name="headers">Connection request headers</param>
        public WebPubSubConnectionContext(WebPubSubEventType eventType, string eventName, string hub, string connectionId, string userId = null, string signature = null, string origin = null, IReadOnlyDictionary<string, object> states = null, IReadOnlyDictionary<string, string[]> headers = null)
        {
            EventType = eventType;
            EventName = eventName;
            Hub = hub;
            ConnectionId = connectionId;
            UserId = userId;
            Signature = signature;
            Origin = origin;
            States = states;
            Headers = headers;
        }
    }
}
