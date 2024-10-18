// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Inference
{
    /// <summary>
    /// Represents an update to a single prompt completion when the service is streaming updates
    /// using Server Sent Events (SSE).
    /// Generally, `n` choices are generated per provided prompt with a default value of 1.
    /// Token limits and other settings may limit the number of choices generated.
    /// </summary>
    public partial class StreamingChatChoiceUpdate
    {
        /// <summary> An update to the chat message for a given chat completions prompt. </summary>
        public StreamingChatResponseMessageUpdate Delta { get; } = StreamingChatResponseMessageUpdate.Empty;
    }
}
