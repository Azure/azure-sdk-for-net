// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Event type.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WebPubSubEventType
    {
        /// <summary>
        /// system event, including connect, connected, disconnected.
        /// </summary>
        System,
        /// <summary>
        /// user event.
        /// </summary>
        User
    }
}
