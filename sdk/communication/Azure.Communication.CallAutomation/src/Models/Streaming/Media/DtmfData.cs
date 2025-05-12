// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Streaming dtmf data.
    /// </summary>
    public class DtmfData : StreamingData
    {
        /// <summary>
        /// The dtmf data, encoded as a base64 string
        /// </summary>
        /// <param name="data"></param>
        public DtmfData(string data)
        {
            Data = data;
        }

        internal DtmfData(string data, DateTime timestamp, string participantId)
        {
            Data = !string.IsNullOrWhiteSpace(data) ? data : default;
            Timestamp = timestamp;
            if (participantId != null)
            {
                Participant = CommunicationIdentifier.FromRawId(participantId);
            }
        }

        /// <summary>
        /// The dtmf data in base64 byte.
        /// </summary>
        public string Data { get; }

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
    }
}
