// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Metadata for Dtmf Streaming.
    /// </summary>
    public class DtmfMetaData : StreamingData
    {
        internal DtmfMetaData(DtmfMetaDataInternal dtmfMetaData)
        {
            Data = dtmfMetaData.Data;
            Timestamp = dtmfMetaData.Timestamp;
            if (dtmfMetaData.Participant != null)
            {
                Participant = CommunicationIdentifier.FromRawId(dtmfMetaData.Participant);
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
