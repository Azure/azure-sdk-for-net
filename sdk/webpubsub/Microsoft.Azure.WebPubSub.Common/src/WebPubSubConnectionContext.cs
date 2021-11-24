// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text.Json;
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
        /// The connection states.  The values in this dictionary are strings of raw JSON and we recommend
        /// using <see cref="ConnectionStates"/> instead.
        /// </summary>
        [JsonIgnore]
        [JsonPropertyName("states")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyDictionary<string, object> States { get; }

        /// <summary>
        /// The connection states.
        /// </summary>
        [JsonPropertyName("states")]
        [JsonConverter(typeof(ConnectionStatesConverter))]
        public IReadOnlyDictionary<string, BinaryData> ConnectionStates { get; }

        /// <summary>
        /// The headers of request.
        /// </summary>
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
                    p => p.Value is BinaryData data ?
                        data :
                        // TODO: Is this safe?  Will all callers of of this .ctor always pass BinaryData? Can we have version mismatches between Common and Extensions that break this?
                        throw new ArgumentException($"{nameof(states)} values must be of type {nameof(BinaryData)}.", nameof(states))),
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
            ConnectionStates = connectionStates;
            States = connectionStates != null ? new StringifiedDictionary(connectionStates) : null;
            Headers = headers;
        }

        /// <summary>
        /// Dictionary that wraps access to the ConnectionStates dictionary but
        /// returns stringifed JSON instead of BinaryData.  This only exists to
        /// avoid breaking customers using the old <see cref="States"/> property.
        /// </summary>
        private class StringifiedDictionary : IReadOnlyDictionary<string, object>
        {
            /// <summary>
            /// The original dictionary to wrap.
            /// </summary>
            private readonly IReadOnlyDictionary<string, BinaryData> _original;

            /// <summary>
            /// Creates a new instance of the RawJsonWrappingDictionary class.
            /// </summary>
            /// <param name="original">The original dictionary to wrap.</param>
            public StringifiedDictionary(IReadOnlyDictionary<string, BinaryData> original) =>
                _original = original;

            /// <inheritdoc/>
            public int Count => _original.Count;

            /// <inheritdoc/>
            public object this[string key] => _original[key].ToString();

            /// <inheritdoc/>
            public IEnumerable<string> Keys => _original.Keys;

            /// <inheritdoc/>
            public IEnumerable<object> Values => _original.Values.Select(v => v.ToString());

            /// <inheritdoc/>
            public IEnumerator<KeyValuePair<string, object>> GetEnumerator() =>
                _original.Select(p => new KeyValuePair<string, object>(p.Key, p.Value.ToString())).GetEnumerator();

            /// <inheritdoc/>
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            /// <inheritdoc/>
            public bool ContainsKey(string key) => _original.ContainsKey(key);

            /// <inheritdoc/>
            public bool TryGetValue(string key, out object value)
            {
                if (_original.TryGetValue(key, out BinaryData data))
                {
                    value = data.ToString();
                    return true;
                }
                else
                {
                    value = default;
                    return false;
                }
            }
        }

        /// <summary>
        /// Converter to turn the ConnectionStates dictionary into a regular JSON
        /// object.
        /// </summary>
        private class ConnectionStatesConverter : JsonConverter<IReadOnlyDictionary<string, BinaryData>>
        {
            /// <inheritdoc/>
            public override IReadOnlyDictionary<string, BinaryData> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
                throw new NotImplementedException();

            /// <inheritdoc/>
            public override void Write(Utf8JsonWriter writer, IReadOnlyDictionary<string, BinaryData> value, JsonSerializerOptions options)
            {
                writer.WriteStartObject();
                if (value != null)
                {
                    foreach (KeyValuePair<string, BinaryData> pair in value)
                    {
                        writer.WritePropertyName(pair.Key);

                        // Since STJ doesn't allow you to write raw JSON,
                        // we have to hack around it by deserializing to an object
                        // and then serializing it back into our writer
                        object val = pair.Value.ToObjectFromJson<object>(options);
                        JsonSerializer.Serialize(writer, val, options);
                    }
                }
                writer.WriteEndObject();
            }
        }
    }
}
