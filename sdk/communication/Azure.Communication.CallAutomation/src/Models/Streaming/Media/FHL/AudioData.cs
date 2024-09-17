// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation.FHL
{
    /// <summary>
    /// Streaming Audio.
    /// </summary>
    public class AudioData
    {
        /// <summary>
        /// Audio data constructor
        /// </summary>
        /// <param name="timestamp">Date time offset</param>
        /// <param name="data">audio data bytes</param>
        /// <param name="silent">Indicating the audio buffer is silence buffer</param>
        public AudioData(DateTimeOffset timestamp, byte[] data, bool silent)
        {
            Timestamp = timestamp.ToString("yyyy-MM-ddTHH:mm:ssZ");
            Data = data;
            Silent = silent;
        }

        /// <summary>
        /// Timestamp of when the media content was received by the bot, or if the bot is sending media,
        /// the timestamp of when the media was sourced. In ISO 8601 format (yyyy-mm-ddThh:mm:ssZ)
        /// IsRequired = true
        /// </summary>
        public string Timestamp { get; }

        /// <summary>
        /// Participant Raw ID
        /// IsRequired = false
        /// </summary>
        public string ParticipantRawID { get; set; }

        /// <summary>
        /// Base64 Encoded audio buffer data, the byte[] array type was just added as a convenience since Newtonsoft.Json
        /// serializes it into a base64 encoded string. Over the wire, this should be of type string
        /// IsRequired = true
        /// </summary>
        public byte[] Data { get; }

        /// <summary>
        /// Indicates if the received audio buffer contains only silence.
        /// IsRequired = true
        public bool Silent { get; }
    }
}
