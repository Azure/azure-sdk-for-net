// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Data;

namespace Azure.AI.Inference
{
    public partial class ChatRequestToolMessage
    {
        /// <summary> Initializes a new instance of <see cref="ChatRequestToolMessage"/>. </summary>
        /// <param name="content"> The output of the tool call, to be provided back to the model. </param>
        /// <param name="toolCallId"> The Id of the tool call that this message provides the output for. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="toolCallId"/> is null. </exception>
        public ChatRequestToolMessage(string content, string toolCallId)
        {
            Argument.AssertNotNull(toolCallId, nameof(toolCallId));

            Role = ChatRole.Tool;
            Content = content;
            ToolCallId = toolCallId;
        }
    }
}
