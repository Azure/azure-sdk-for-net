// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            States = states ?? new Dictionary<string, object>();
            Headers = headers ?? new Dictionary<string, string[]>();
        }

        /// <summary>
        /// Method to deserialize state to customized type.
        /// </summary>
        /// <typeparam name="T">Customized type.</typeparam>
        /// <param name="stateKey">State key.</param>
        /// <param name="value">Connection state mapped to the key.</param>
        /// <returns>Returns true if is able to find the key and false means key doesn't exist.</returns>
        public bool TryGetState<T>(string stateKey, out T value)
        {
            value = default(T);
            if (States.TryGetValue(stateKey, out var stateValue))
            {
                if (stateValue != null)
                {
                    // Should ensure in server SDK.
                    if (stateValue is not JsonElement element)
                    {
                        throw new ArgumentException("States value should be inserted with type `JsonElement`.");
                    }
                    value = JsonSerializer.Deserialize<T>(element.GetRawText());
                }
                return true;
            }
            return false;
        }
    }
}
