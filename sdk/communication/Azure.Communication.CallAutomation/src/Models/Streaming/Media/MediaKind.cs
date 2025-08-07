// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Messages sent from websocket server
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MediaKind
    {
        /// <summary>
        /// Audio data type
        /// </summary>F
        AudioData,
        /// <summary>
        /// stop audio data type
        /// </summary>
        StopAudio
    }
}
