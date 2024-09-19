// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation.FHL
{
    /// <summary>
    /// Messages sent from websocket server
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ServerMessageType
    {
        /// <summary>
        /// Audio data type
        /// </summary>
        AudioData,
        /// <summary>
        /// Mark metadata tyoe
        /// </summary>
        Mark,
        /// <summary>
        /// stop audio data type
        /// </summary>
        StopAudio
    }
}
