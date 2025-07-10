// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Streaming Audio.
    /// </summary>
    public class AudioData : StreamingData
    {
        /// <summary>
        /// The audio data, encoded as a ReadOnlyMemory of bytes
        /// </summary>
        /// <param name="data"></param>
        public AudioData(ReadOnlyMemory<byte> data)
        {
            Data = data;
        }

        internal AudioData(string data, DateTime timestamp, string participantId, bool silent)
        {
            Data = !string.IsNullOrWhiteSpace(data) ? Convert.FromBase64String(data).AsMemory() : default;
            Timestamp = timestamp;
            if (participantId != null)
            {
                Participant = CommunicationIdentifier.FromRawId(participantId);
            }
            IsSilent = silent;
        }

        /// <summary>
        /// The audio data in ReadOnlyMemory byte.
        /// </summary>
        public ReadOnlyMemory<byte> Data { get; }

        /// <summary>
        /// The timestamp indicating when the media content was received by the bot,
        /// or if the bot is sending media, the timestamp of when the media was sourced.
        /// The format is ISO 8601 (yyyy-mm-ddThh:mm).
        /// </summary>
        public DateTimeOffset Timestamp { get; }

        /// <summary>
        /// The raw ID of the participant.
        /// </summary>
        public CommunicationIdentifier Participant { get; }

        /// <summary>
        /// Indicates whether the received audio buffer contains only silence.
        /// </summary>
        public bool IsSilent { get; }
    }
}
