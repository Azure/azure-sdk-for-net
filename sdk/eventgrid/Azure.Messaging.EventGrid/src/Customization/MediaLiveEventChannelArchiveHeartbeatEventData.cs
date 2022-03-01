// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class MediaLiveEventChannelArchiveHeartbeatEventData
    {
        internal string ChannelLatencyMsInternal { get; }

        /// <summary>
        /// Gets the channel latency.
        /// </summary>
        public TimeSpan? ChannelLatency
            => _channelLatency ??= ChannelLatencyMsInternal == Constants.MediaEvents.NotApplicable
                ? null
                : TimeSpan.FromMilliseconds(double.Parse(ChannelLatencyMsInternal, CultureInfo.InvariantCulture));

        private TimeSpan? _channelLatency;
    }
}