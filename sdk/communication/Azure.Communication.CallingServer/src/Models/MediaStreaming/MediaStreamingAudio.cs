// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// Streaming audio.
    /// </summary>
    public class MediaStreamingAudio : MediaStreamingPackageBase
    {
        internal MediaStreamingAudio(byte[] data, DateTime timestamp, string participantId, bool isSilence)
        {
            Data = data;
            Timestamp = timestamp;
            Participant = new CommunicationUserIdentifier(participantId);
            IsSilent = isSilence;
        }

        /// <summary>
        /// The audio data.
        /// </summary>
        public byte[] Data { get; }

        /// <summary>
        /// The timestamp of thwn the media was sourced.
        /// </summary>
        public DateTime Timestamp { get; }
        /// <summary>
        /// Participant ID
        /// </summary>
        public CommunicationIdentifier Participant { get; }
        /// <summary>
        /// Indicates if the received audio buffer contains only silence.
        /// </summary>
        public bool IsSilent { get; }
    }
}
