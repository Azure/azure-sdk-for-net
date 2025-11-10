// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Kind of streaming data when websocket receives the data
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StreamingDataKind
    {
        /// <summary>
        /// Audio data type
        /// </summary>
        AudioData,
        /// <summary>
        /// Audio metadata type
        /// </summary>
        AudioMetadata,
        /// <summary>
        /// Transcription data type
        /// </summary>
        TranscriptionData,
        /// <summary>
        /// Transcription metadata type
        /// </summary>
        TranscriptionMetadata,
        /// <summary>
        /// Dtmf data type
        /// </summary>
        DtmfData,
        /// <summary>
        /// Mark data type
        /// </summary>
        MarkData,
    }
}
