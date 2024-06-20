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
        internal AudioData(string data, DateTime timestamp, string participantId, bool silent)
        {
            Data = data;
            Timestamp = timestamp;
            if (participantId != null)
            {
                Participant = CommunicationIdentifier.FromRawId(participantId);;
            }
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
