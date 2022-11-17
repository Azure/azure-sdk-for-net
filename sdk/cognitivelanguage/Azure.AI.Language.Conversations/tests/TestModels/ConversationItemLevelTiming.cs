// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> The conversation item level audio timing. </summary>
    public partial class ConversationItemLevelTiming : AudioTiming
    {
        /// <summary> Initializes a new instance of ConversationItemLevelTiming. </summary>
        public ConversationItemLevelTiming()
        {
        }

        /// <summary> Initializes a new instance of ConversationItemLevelTiming. </summary>
        /// <param name="offset"> Offset from start of speech audio, in ticks. 1 tick = 100 ns. </param>
        /// <param name="duration"> Duration of word articulation, in ticks. 1 tick = 100 ns. </param>
        internal ConversationItemLevelTiming(long? offset, long? duration) : base(offset, duration)
        {
        }
    }
}
