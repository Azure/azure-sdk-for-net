// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        /// using <see cref="ConnectionStates"/> or <see cref="TryGetConnectionState{T}(string, out T)"/> instead.
        /// </summary>
        [JsonIgnore]
        [JsonPropertyName("states")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyDictionary<string, object> States { get; }

        /// <summary>
        /// The connection states.  You can use the <see cref="TryGetConnectionState{T}(string, out T)"/> method
        /// to get connection state values deserialized as strong types.
        /// </summary>
        [JsonPropertyName("states")]
#pragma warning disable AZC0014 // Avoid using banned types (System.Text.Json) in public APIs
        public IReadOnlyDictionary<string, JsonElement> ConnectionStates { get; }
#pragma warning restore AZC0014 // Avoid using banned types (System.Text.Json) in public APIs

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
        /// <param name="states">Connection states. Value in <see cref="JsonElement"/> type. Use the <see cref="TryGetConnectionState{T}(string, out T)"/> method to try getting the value deserialized as a specific type.</param>
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
                    p => p.Value is JsonElement e ?
                        e :
                        // TODO: Is this safe?  Will all callers of of this .ctor always pass JSON? Can we have version mismatches between Common and Extensions that break this?
                        throw new ArgumentException($"{nameof(states)} values must be of type {nameof(JsonElement)}.", nameof(states))),
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
        /// <param name="connectionStates">Connection states.  Use the <see cref="TryGetConnectionState{T}(string, out T)"/> method to try getting the value deserialized as a specific type.</param>
        /// <param name="headers">Connection request headers.</param>
#pragma warning disable AZC0014 // Avoid using banned types (System.Text.Json) in public APIs
        public WebPubSubConnectionContext(WebPubSubEventType eventType, string eventName, string hub, string connectionId, string userId = null, string signature = null, string origin = null, IReadOnlyDictionary<string, JsonElement> connectionStates = null, IReadOnlyDictionary<string, string[]> headers = null)
#pragma warning restore AZC0014 // Avoid using banned types (System.Text.Json) in public APIs
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
        /// Try to get the value of a connection state deserialized as a specific type.
        /// </summary>
        /// <typeparam name="T">Customized type.</typeparam>
        /// <param name="stateKey">The connection state key.</param>
        /// <param name="value">The connection state value deserialized as <typeparamref name="T"/>.</param>
        /// <returns>Returns true if able to find the key and false if the key doesn't exist or value cannot be deserialized to <typeparamref name="T"/>.</returns>
        public bool TryGetConnectionState<T>(string stateKey, out T value)
        {
            value = default;
            if (States.TryGetValue(stateKey, out var stateValue))
            {
                if (stateValue is T val)
                {
                    value = val;
                    return true;
                }
                // Should ensure in server SDK.
                if (stateValue is JsonElement element)
                {
                    try
                    {
                        value = JsonSerializer.Deserialize<T>(element.GetRawText());
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Dictionary that wraps access to the ConnectionStates dictionary but
        /// returns stringifed JSON instead of JsonElement.  This only exists to
        /// avoid breaking customers using the old <see cref="States"/> property.
        /// </summary>
        private class StringifiedDictionary : IReadOnlyDictionary<string, object>
        {
            /// <summary>
            /// The original dictionary to wrap.
            /// </summary>
            private readonly IReadOnlyDictionary<string, JsonElement> _original;

            /// <summary>
            /// Creates a new instance of the RawJsonWrappingDictionary class.
            /// </summary>
            /// <param name="original">The original dictionary to wrap.</param>
            public StringifiedDictionary(IReadOnlyDictionary<string, JsonElement> original) =>
                _original = original;

            /// <inheritdoc/>
            public int Count => _original.Count;

            /// <inheritdoc/>
            public object this[string key] => _original[key].GetRawText();

            /// <inheritdoc/>
            public IEnumerable<string> Keys => _original.Keys;

            /// <inheritdoc/>
            public IEnumerable<object> Values => _original.Values.Select(v => v.GetRawText());

            /// <inheritdoc/>
            public IEnumerator<KeyValuePair<string, object>> GetEnumerator() =>
                _original.Select(p => new KeyValuePair<string, object>(p.Key, p.Value.GetRawText())).GetEnumerator();

            /// <inheritdoc/>
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            /// <inheritdoc/>
            public bool ContainsKey(string key) => _original.ContainsKey(key);

            /// <inheritdoc/>
            public bool TryGetValue(string key, out object value)
            {
                if (_original.TryGetValue(key, out JsonElement e))
                {
                    value = e.GetRawText();
                    return true;
                }
                else
                {
                    value = default;
                    return false;
                }
            }
        }
    }
}
