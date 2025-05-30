// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Channel Archive heartbeat event data. Schema of the data property of an EventGridEvent for a Microsoft.Media.LiveEventChannelArchiveHeartbeat event. </summary>
    public partial class MediaLiveEventChannelArchiveHeartbeatEventData
    {
        /// <summary> Initializes a new instance of <see cref="MediaLiveEventChannelArchiveHeartbeatEventData"/>. </summary>
        /// <param name="channelLatencyMsInternal"> Gets the channel latency in ms. </param>
        /// <param name="latencyResultCode"> Gets the latency result code. </param>
        internal MediaLiveEventChannelArchiveHeartbeatEventData(string channelLatencyMsInternal, string latencyResultCode)
        {
            ChannelLatencyMsInternal = channelLatencyMsInternal;
            LatencyResultCode = latencyResultCode;
        }
        /// <summary> Gets the latency result code. </summary>
        public string LatencyResultCode { get; }
        internal string ChannelLatencyMsInternal { get; }

        /// <summary>
        /// Gets the channel latency.
        /// </summary>
        public TimeSpan? ChannelLatency
            => _channelLatency ??= ChannelLatencyMsInternal == "n/a"
                ? null
                : TimeSpan.FromMilliseconds(double.Parse(ChannelLatencyMsInternal, CultureInfo.InvariantCulture));

        private TimeSpan? _channelLatency;
    }
}
