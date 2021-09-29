// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Disconnected event request.
    /// </summary>
    [JsonConverter(typeof(DisconnectedEventRequestJsonConverter))]
    public sealed class DisconnectedEventRequest : WebPubSubRequest
    {
        internal const string ReasonProperty = "reason";

        /// <summary>
        /// Reason of the disconnect event.
        /// </summary>
        [JsonPropertyName(ReasonProperty)]
        public string Reason { get; }

        internal DisconnectedEventRequest(string reason) : base(null)
        {
            Reason = reason;
        }
    }
}
