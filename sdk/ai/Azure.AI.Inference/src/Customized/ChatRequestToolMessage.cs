// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Data;

namespace Azure.AI.Inference
{
    public partial class ChatRequestToolMessage
    {
        public ChatRequestToolMessage(string content, string toolCallId)
        {
            Argument.AssertNotNull(toolCallId, nameof(toolCallId));

            Role = ChatRole.Tool;
            Content = content;
            ToolCallId = toolCallId;
        }
    }
}
