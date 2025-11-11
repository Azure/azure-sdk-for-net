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
        /// The audio data, encoded as a base64 string
        /// </summary>
        /// <param name="data"></param>
        public AudioData(byte[] data)
        {
            Data = data;
        }

        internal AudioData(string data, DateTime timestamp, string participantId, bool silent, MarkAudio mark)
        {
            Data = !string.IsNullOrWhiteSpace(data) ? Convert.FromBase64String(data) : default;
            Timestamp = timestamp;
            if (participantId != null)
            {
                Participant = CommunicationIdentifier.FromRawId(participantId);
            }
            IsSilent = silent;
            Mark = mark;
        }

        /// <summary>
        /// The audio data in base64 byte.
        /// </summary>
        public byte[] Data { get; }

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

        /// <summary>
        /// Mark this audio data which signals the player when it reaches the mark position
        /// </summary>
        public MarkAudio Mark { get; }
    }
}
