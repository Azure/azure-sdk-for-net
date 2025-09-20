// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.VoiceLive
{
    /// <summary> Represents a word-level audio timestamp delta for a response. </summary>
    public partial class SessionUpdateResponseAudioTimestampDelta
    {
        /// <summary> Gets the AudioOffsetMs. </summary>
        internal int AudioOffsetMs { get; }

        /// <summary>
        /// Offset in the overall response audio where the word begins.
        /// </summary>
        public TimeSpan AudioOffset => TimeSpan.FromMilliseconds(AudioOffsetMs);

        /// <summary> Gets the AudioDurationMs. </summary>
        internal int AudioDurationMs { get; }

        /// <summary>
        /// Gets the duration of the audio.
        /// </summary>
        public TimeSpan AudioDuration => TimeSpan.FromMilliseconds(AudioDurationMs);
    }
}
