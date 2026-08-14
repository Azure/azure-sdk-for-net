// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.VoiceLive
{
    /// <summary> Base model for VAD-based turn detection. </summary>
    public partial class ServerVadTurnDetection
    {
        /// <summary> Gets or sets the PrefixPaddingMs. </summary>
        internal int? PrefixPaddingMs { get; set; }

        /// <summary> Gets or sets the PrefixPaddingMs. </summary>
        public TimeSpan PrefixPadding
        {
            get => TimeSpan.FromMilliseconds(PrefixPaddingMs ?? 0);
            set => PrefixPaddingMs = (int)value.TotalMilliseconds;
        }

        /// <summary> Gets or sets the SilenceDurationMs. </summary>
        internal int? SilenceDurationMs { get; set; }

        /// <summary> Gets or sets the SilenceDurationMs. </summary>
        public TimeSpan SilenceDuration
        {
            get => TimeSpan.FromMilliseconds(SilenceDurationMs ?? 0);
            set => SilenceDurationMs = (int)value.TotalMilliseconds;
        }
    }
}
