// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model
{
    /// <summary>
    /// Connect event
    /// </summary>
    [DataContract]
    public class SocketIODisconnectedRequest : SocketIOEventHandlerRequest
    {
        internal const string ReasonProperty = "reason";

        /// <summary>
        /// Reason of the disconnect event.
        /// </summary>
        [DataMember(Name = ReasonProperty)]
        [JsonPropertyName(ReasonProperty)]
        public string Reason { get; }

        /// <summary>
        /// The disconnected event request
        /// </summary>
        public SocketIODisconnectedRequest(string @namespace, string socketId, string reason) : base(@namespace, socketId)
        {
            Reason = reason;
        }
    }
}
