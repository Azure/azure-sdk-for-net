// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Disconnected event request.
    /// </summary>
    public sealed class DisconnectedEventRequest : WebPubSubEventRequest
    {
        /// <summary>
        /// Reason of the disconnect event.
        /// </summary>
        [JsonPropertyName("reason")]
        public string Reason { get; set; }
    }
}
