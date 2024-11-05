// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model
{
    /// <summary>
    /// Connect event
    /// </summary>
    [DataContract]
    public class SocketIOMessageRequest : SocketIOEventHandlerRequest
    {
        internal const string PayloadProperty = "payload";
        internal const string EventNameProperty = "eventName";
        internal const string ParametersProperty = "parameters";

        /// <summary>
        /// The payload of message
        /// </summary>
        [DataMember(Name = PayloadProperty)]
        [JsonPropertyName(PayloadProperty)]
        public string Payload { get; }

        /// <summary>
        /// The event name of the message.
        /// </summary>
        [DataMember(Name = EventNameProperty)]
        [JsonPropertyName(EventNameProperty)]
        public string EventName { get; }

        /// <summary>
        /// The parameters of message
        /// </summary>
        [DataMember(Name = ParametersProperty)]
        [JsonPropertyName(ParametersProperty)]
        public IList<object> Parameters { get; }

        /// <summary>
        /// The disconnected event request
        /// </summary>
        public SocketIOMessageRequest(string @namespace, string socketId, string payload, string eventName, IList<object> arguments) : base(@namespace, socketId)
        {
            Payload = payload;
            EventName = eventName;
            Parameters = arguments;
        }
    }
}
