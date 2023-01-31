// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> The audio timing information. </summary>
    public partial class AudioTiming
    {
        /// <summary> Initializes a new instance of AudioTiming. </summary>
        public AudioTiming()
        {
        }

        /// <summary> Initializes a new instance of AudioTiming. </summary>
        /// <param name="offset"> Offset from start of speech audio, in ticks. 1 tick = 100 ns. </param>
        /// <param name="duration"> Duration of word articulation, in ticks. 1 tick = 100 ns. </param>
        internal AudioTiming(long? offset, long? duration)
        {
            Offset = offset;
            Duration = duration;
        }

        /// <summary> Offset from start of speech audio, in ticks. 1 tick = 100 ns. </summary>
        public long? Offset { get; set; }
        /// <summary> Duration of word articulation, in ticks. 1 tick = 100 ns. </summary>
        public long? Duration { get; set; }
    }
}
