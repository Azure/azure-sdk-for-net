// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Encoder connect event data. Schema of the data property of an EventGridEvent for a Microsoft.Media.LiveEventIncomingStreamReceived event. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class MediaLiveEventIncomingStreamReceivedEventData
    {
        /// <summary> Initializes a new instance of <see cref="MediaLiveEventIncomingStreamReceivedEventData"/>. </summary>
        internal MediaLiveEventIncomingStreamReceivedEventData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="MediaLiveEventIncomingStreamReceivedEventData"/>. </summary>
        /// <param name="ingestUrl"> Gets the ingest URL provided by the live event. </param>
        /// <param name="trackType"> Gets the type of the track (Audio / Video). </param>
        /// <param name="trackName"> Gets the track name. </param>
        /// <param name="bitrate"> Gets the bitrate of the track. </param>
        /// <param name="encoderIp"> Gets the remote IP. </param>
        /// <param name="encoderPort"> Gets the remote port. </param>
        /// <param name="timestamp"> Gets the first timestamp of the data chunk received. </param>
        /// <param name="duration"> Gets the duration of the first data chunk. </param>
        /// <param name="timescale"> Gets the timescale in which timestamp is represented. </param>
        internal MediaLiveEventIncomingStreamReceivedEventData(string ingestUrl, string trackType, string trackName, long? bitrate, string encoderIp, string encoderPort, string timestamp, string duration, string timescale)
        {
            IngestUrl = ingestUrl;
            TrackType = trackType;
            TrackName = trackName;
            Bitrate = bitrate;
            EncoderIp = encoderIp;
            EncoderPort = encoderPort;
            Timestamp = timestamp;
            Duration = duration;
            Timescale = timescale;
        }

        /// <summary> Gets the ingest URL provided by the live event. </summary>
        public string IngestUrl { get; }
        /// <summary> Gets the type of the track (Audio / Video). </summary>
        public string TrackType { get; }
        /// <summary> Gets the track name. </summary>
        public string TrackName { get; }
        /// <summary> Gets the bitrate of the track. </summary>
        public long? Bitrate { get; }
        /// <summary> Gets the remote IP. </summary>
        public string EncoderIp { get; }
        /// <summary> Gets the remote port. </summary>
        public string EncoderPort { get; }
        /// <summary> Gets the first timestamp of the data chunk received. </summary>
        public string Timestamp { get; }
        /// <summary> Gets the duration of the first data chunk. </summary>
        public string Duration { get; }
        /// <summary> Gets the timescale in which timestamp is represented. </summary>
        public string Timescale { get; }
    }
}
