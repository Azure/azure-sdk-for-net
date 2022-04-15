// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// Request context from headers following CloudEvents.
    /// </summary>
    [DataContract]
    public class WebPubSubConnectionContext
    {
        /// <summary>
        /// The type of the message.
        /// </summary>
        [DataMember(Name = "eventType")]
        [JsonPropertyName("eventType")]
        public WebPubSubEventType EventType { get; }

        /// <summary>
        /// The event name of the message.
        /// </summary>
        [DataMember(Name = "eventName")]
        [JsonPropertyName("eventName")]
        public string EventName { get; }

        /// <summary>
        /// The hub which the connection belongs to.
        /// </summary>
        [DataMember(Name = "hub")]
        [JsonPropertyName("hub")]
        public string Hub { get; }

        /// <summary>
        /// The connection-id of the client.
        /// </summary>
        [DataMember(Name = "connectionId")]
        [JsonPropertyName("connectionId")]
        public string ConnectionId { get; }

        /// <summary>
        /// The user identity of the client.
        /// </summary>
        [DataMember(Name = "userId")]
        [JsonPropertyName("userId")]
        public string UserId { get; }

        /// <summary>
        /// The signature for validation.
        /// </summary>
        [DataMember(Name = "signature")]
        [JsonPropertyName("signature")]
        public string Signature { get; }

        /// <summary>
        /// Upstream origin.
        /// </summary>
        [DataMember(Name = "origin")]
        [JsonPropertyName("origin")]
        public string Origin { get; }

        /// <summary>
        /// The connection states.  The values in this dictionary are strings of raw JSON and we recommend
        /// using <see cref="ConnectionStates"/> instead.
        /// </summary>
        [IgnoreDataMember]
        [JsonIgnore]
        [JsonPropertyName("states")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyDictionary<string, object> States { get; }

        /// <summary>
        /// The connection states.
        /// </summary>
        [DataMember(Name = "states")]
        [JsonPropertyName("states")]
        [JsonConverter(typeof(ConnectionStatesConverter))]
        public IReadOnlyDictionary<string, BinaryData> ConnectionStates { get; }

        /// <summary>
        /// The headers of request.
        /// </summary>
        [DataMember(Name = "headers")]
        [JsonPropertyName("headers")]
        public IReadOnlyDictionary<string, string[]> Headers { get; }

        /// <summary>
        /// The client connection context contains the CloudEvents headers under Web PubSub protocol.
        /// </summary>
        /// <param name="eventType">Event type.</param>
        /// <param name="eventName">Event name.</param>
        /// <param name="hub">Hub name.</param>
        /// <param name="connectionId">Connection Id.</param>
        /// <param name="userId">User Id.</param>
        /// <param name="signature">Signature of the connection.</param>
        /// <param name="origin">Origin of the event.</param>
        /// <param name="states">Connection states. Value in <see cref="BinaryData"/> type.</param>
        /// <param name="headers">Connection request headers.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebPubSubConnectionContext(WebPubSubEventType eventType, string eventName, string hub, string connectionId, string userId, string signature, string origin, IReadOnlyDictionary<string, object> states, IReadOnlyDictionary<string, string[]> headers)
            : this(
                eventType,
                eventName,
                hub,
                connectionId,
                userId,
                signature,
                origin,
                states?.ToDictionary(
                    p => p.Key,
                    p => p.Value as BinaryData ?? BinaryData.FromObjectAsJson(p.Value)),
                headers)
        {
        }

        /// <summary>
        /// The client connection context contains the CloudEvents headers under Web PubSub protocol.
        /// </summary>
        /// <param name="eventType">Event type.</param>
        /// <param name="eventName">Event name.</param>
        /// <param name="hub">Hub name.</param>
        /// <param name="connectionId">Connection Id.</param>
        /// <param name="userId">User Id.</param>
        /// <param name="signature">Signature of the connection.</param>
        /// <param name="origin">Origin of the event.</param>
        /// <param name="connectionStates">Connection states.</param>
        /// <param name="headers">Connection request headers.</param>
        public WebPubSubConnectionContext(WebPubSubEventType eventType, string eventName, string hub, string connectionId, string userId = null, string signature = null, string origin = null, IReadOnlyDictionary<string, BinaryData> connectionStates = null, IReadOnlyDictionary<string, string[]> headers = null)
        {
            EventType = eventType;
            EventName = eventName;
            Hub = hub;
            ConnectionId = connectionId;
            UserId = userId;
            Signature = signature;
            Origin = origin;
            ConnectionStates = connectionStates ?? new Dictionary<string, BinaryData>();
            States = new StringifiedDictionary(ConnectionStates);
            Headers = headers;
        }
    }
}
