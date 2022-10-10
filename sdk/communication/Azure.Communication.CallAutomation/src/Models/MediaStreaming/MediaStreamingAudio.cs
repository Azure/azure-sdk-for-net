// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Streaming audio.
    /// </summary>
    public class MediaStreamingAudio : MediaStreamingPackageBase
    {
        internal MediaStreamingAudio(string data, DateTime timestamp, string participantId, bool silent)
        {
            Data = data;
            Timestamp = timestamp;
            Participant = new CommunicationUserIdentifier(participantId);
            IsSilent = silent;
        }

        /// <summary>
        /// The audio data in base64 string.
        /// </summary>
        public string Data { get; }

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
