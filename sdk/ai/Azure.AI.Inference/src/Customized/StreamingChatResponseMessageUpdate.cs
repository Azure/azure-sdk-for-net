// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using static Azure.AI.Inference.StreamingChatCompletionsUpdate;

namespace Azure.AI.Inference
{
    /// <summary> A representation of a chat message update as received in a streaming response. </summary>
    public partial class StreamingChatResponseMessageUpdate
    {
        /// <summary>
        /// The tool calls that must be resolved and have their outputs appended to subsequent input messages for the chat
        /// completions request to resolve as configured.
        /// </summary>
        public IReadOnlyList<StreamingChatResponseToolCallUpdate> ToolCalls { get; set; } = new List<StreamingChatResponseToolCallUpdate>();

        internal static StreamingChatResponseMessageUpdate Empty { get; } = new()
        {
            ToolCalls = new List<StreamingChatResponseToolCallUpdate>() { null },
        };
    }
}
