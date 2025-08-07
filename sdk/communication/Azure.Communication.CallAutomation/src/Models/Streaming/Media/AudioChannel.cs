// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Specifies the Audio Channels
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AudioChannel
    {
        /// <summary>
        /// Unknown Audio channel type
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Audio channel type
        /// </summary>F
        Mono = 1,
    }
}
