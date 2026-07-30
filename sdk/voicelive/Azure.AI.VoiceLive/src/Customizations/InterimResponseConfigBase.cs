// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.VoiceLive
{
    public abstract partial class InterimResponseConfigBase
    {
        /// <summary> Gets or sets the LatencyThresholdMs. </summary>
        internal int? LatencyThresholdMs { get; set; }

        /// <summary> Latency threshold before triggering interim response. Default is 2 seconds. </summary>
        public TimeSpan LatencyThreshold
        {
            get => TimeSpan.FromMilliseconds(LatencyThresholdMs ?? 0);
            set => LatencyThresholdMs = (int)value.TotalMilliseconds;
        }
    }
}
