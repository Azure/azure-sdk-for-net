// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// Disconnected event request.
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(DisconnectedEventRequestJsonConverter))]
    public class DisconnectedEventRequest : WebPubSubEventRequest
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
        /// <param name="context"></param>
        /// <param name="reason"></param>
        public DisconnectedEventRequest(WebPubSubConnectionContext context, string reason) : base(context)
        {
            Reason = reason;
        }
    }
}
