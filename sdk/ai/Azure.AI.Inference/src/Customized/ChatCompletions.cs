// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Inference
{
    public partial class ChatCompletions
    {
        // CUSTOM: Made internal. We only get back a single choice, and instead we flatten the structure for usability.
        /// <summary> A list of chat completion choices. Can be more than one if `n` is greater than 1. </summary>
        internal IReadOnlyList<ChatChoice> Choices { get; }

        // CUSTOM: Flattened choice property.
        /// <summary>
        /// The reason the model stopped generating tokens. This will be `stop` if the model hit a natural stop point or a provided stop sequence,
        /// `length` if the maximum number of tokens specified in the request was reached,
        /// `content_filter` if content was omitted due to a flag from our content filters,
        /// `tool_calls` if the model called a tool, or `function_call` (deprecated) if the model called a function.
        /// </summary>
        public CompletionsFinishReason? FinishReason => Choices[0].FinishReason;

        // CUSTOM: Flattened choice message property.
        /// <summary>
        /// The role of the author of this message.
        /// </summary>
        public ChatRole Role => Choices[0].Message.Role;

        // CUSTOM: Flattened choice message property.
        /// <summary>
        /// The contents of the message.
        /// </summary>
        public string Content => Choices[0].Message.Content;

        // CUSTOM: Flattened choice message property.
        /// <summary>
        /// The tool calls.
        /// </summary>
        public IReadOnlyList<ChatCompletionsToolCall> ToolCalls => Choices[0].Message.ToolCalls;

        /// <summary>
        /// Returns text representation of the first part of the first choice.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Content != null ? Content
            : ToolCalls.Count > 0 ? ModelReaderWriter.Write(ToolCalls[0], ModelReaderWriterOptions.Json, AzureAIInferenceContext.Default).ToString()
            : null;
    }
}
