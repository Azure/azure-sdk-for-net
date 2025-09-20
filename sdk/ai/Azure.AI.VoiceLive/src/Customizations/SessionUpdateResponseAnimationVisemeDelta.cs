// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.VoiceLive
{
    /// <summary> Represents a viseme ID delta update for animation based on audio. </summary>
    public partial class SessionUpdateResponseAnimationVisemeDelta : SessionUpdate
    {
        /// <summary> Gets the AudioOffsetMs. </summary>
        internal int AudioOffsetMs { get; }

        /// <summary>
        /// Gets the offset in the overall response audio where the viseme occurs.
        /// </summary>
        public TimeSpan AudioOffset => TimeSpan.FromMilliseconds(AudioOffsetMs);
    }
}
