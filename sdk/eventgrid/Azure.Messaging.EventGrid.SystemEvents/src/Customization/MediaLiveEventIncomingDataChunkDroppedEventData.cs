// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Ingest fragment dropped event data. Schema of the data property of an EventGridEvent for a Microsoft.Media.LiveEventIncomingDataChunkDropped event. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class MediaLiveEventIncomingDataChunkDroppedEventData
    {
        /// <summary> Initializes a new instance of <see cref="MediaLiveEventIncomingDataChunkDroppedEventData"/>. </summary>
        internal MediaLiveEventIncomingDataChunkDroppedEventData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="MediaLiveEventIncomingDataChunkDroppedEventData"/>. </summary>
        /// <param name="timestamp"> Gets the timestamp of the data chunk dropped. </param>
        /// <param name="trackType"> Gets the type of the track (Audio / Video). </param>
        /// <param name="bitrate"> Gets the bitrate of the track. </param>
        /// <param name="timescale"> Gets the timescale of the Timestamp. </param>
        /// <param name="resultCode"> Gets the result code for fragment drop operation. </param>
        /// <param name="trackName"> Gets the name of the track for which fragment is dropped. </param>
        internal MediaLiveEventIncomingDataChunkDroppedEventData(string timestamp, string trackType, long? bitrate, string timescale, string resultCode, string trackName)
        {
            Timestamp = timestamp;
            TrackType = trackType;
            Bitrate = bitrate;
            Timescale = timescale;
            ResultCode = resultCode;
            TrackName = trackName;
        }

        /// <summary> Gets the timestamp of the data chunk dropped. </summary>
        public string Timestamp { get; }
        /// <summary> Gets the type of the track (Audio / Video). </summary>
        public string TrackType { get; }
        /// <summary> Gets the bitrate of the track. </summary>
        public long? Bitrate { get; }
        /// <summary> Gets the timescale of the Timestamp. </summary>
        public string Timescale { get; }
        /// <summary> Gets the result code for fragment drop operation. </summary>
        public string ResultCode { get; }
        /// <summary> Gets the name of the track for which fragment is dropped. </summary>
        public string TrackName { get; }
    }
}
