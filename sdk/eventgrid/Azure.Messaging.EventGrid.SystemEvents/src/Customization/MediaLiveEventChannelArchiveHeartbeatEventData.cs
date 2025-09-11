// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Globalization;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Channel Archive heartbeat event data. Schema of the data property of an EventGridEvent for a Microsoft.Media.LiveEventChannelArchiveHeartbeat event. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class MediaLiveEventChannelArchiveHeartbeatEventData
    {
        /// <summary> Initializes a new instance of <see cref="MediaLiveEventChannelArchiveHeartbeatEventData"/>. </summary>
        /// <param name="channelLatencyMs"> Gets the channel latency in ms. </param>
        /// <param name="latencyResultCode"> Gets the latency result code. </param>
        internal MediaLiveEventChannelArchiveHeartbeatEventData(string channelLatencyMs, string latencyResultCode)
        {
            ChannelLatency = channelLatencyMs is Constants.MediaEvents.NotApplicable or null ? null : TimeSpan.FromMilliseconds(double.Parse(channelLatencyMs, CultureInfo.InvariantCulture));
            LatencyResultCode = latencyResultCode;
        }
        /// <summary> Gets the latency result code. </summary>
        public string LatencyResultCode { get; }
        /// <summary> Gets the channel latency. </summary>
        public TimeSpan? ChannelLatency { get; }
    }
}
