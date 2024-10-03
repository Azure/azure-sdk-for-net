// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Inference
{
    // CUSTOM CODE NOTE:
    //   This entirely custom class provides a merged representation of streaming chat completions server-sent events.

    /// <summary>
    /// Represents an incremental update to a streamed Chat Completions response.
    /// </summary>
    public partial class StreamingChatCompletionsUpdate
    {
        /// <summary>
        /// Gets a unique identifier associated with this streamed Chat Completions response.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Corresponds to $.id in the underlying REST schema.
        /// </para>
        /// When using Azure OpenAI, note that the values of <see cref="Id"/> and <see cref="Created"/> may not be
        /// populated until the first <see cref="StreamingChatCompletionsUpdate"/> containing role, content, or
        /// function information.
        /// </remarks>
        public string Id { get; }

        /// <inheritdoc cref="ChatCompletions.Model"/>
        public string Model { get; }

        /// <summary>
        /// Gets the first timestamp associated with generation activity for this completions response,
        /// represented as seconds since the beginning of the Unix epoch of 00:00 on 1 Jan 1970.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Corresponds to $.created in the underlying REST schema.
        /// </para>
        /// When using Azure OpenAI, note that the values of <see cref="Id"/> and <see cref="Created"/> may not be
        /// populated until the first <see cref="StreamingChatCompletionsUpdate"/> containing role, content, or
        /// function information.
        /// </remarks>
        public DateTimeOffset Created { get; }

        /// <summary>
        /// Gets the <see cref="ChatRole"/> associated with this update.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Corresponds to e.g. $.choices[0].delta.role in the underlying REST schema.
        /// </para>
        /// <see cref="ChatRole"/> assignment typically occurs in a single update across a streamed Chat Completions
        /// choice and the value should be considered to be persist for all subsequent updates without a
        /// <see cref="ChatRole"/> that bear the same index.
        /// </remarks>
        public ChatRole? Role { get; }

        /// <summary>
        /// Gets the content fragment associated with this update.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Corresponds to e.g. $.choices[0].delta.content in the underlying REST schema.
        /// </para>
        /// Each update contains only a small number of tokens. When presenting or reconstituting a full, streamed
        /// response, all <see cref="ContentUpdate"/> values for the same index should be combined.
        /// </remarks>
        public string ContentUpdate { get; }

        /// <summary>
        /// An incremental update payload for a tool call that is part of this response.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Corresponds to e.g. $.choices[0].delta.tool_calls[0] in the REST API schema.
        /// </para>
        /// <para>
        /// To differentiate between parallel streaming tool calls within a single streaming choice, use the value of the
        /// <see cref="StreamingChatResponseToolCallUpdate.Id"/> property.
        /// </para>
        /// </remarks>
        public StreamingChatResponseToolCallUpdate ToolCallUpdate { get; }

        /// <summary>
        /// Gets the <see cref="CompletionsFinishReason"/> associated with this update.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Corresponds to e.g. $.choices[0].finish_reason in the underlying REST schema.
        /// </para>
        /// <para>
        /// <see cref="FinishReason"/> assignment typically appears in the final streamed update message associated
        /// with a choice.
        /// </para>
        /// </remarks>
        public CompletionsFinishReason? FinishReason { get; }

        internal StreamingChatCompletionsUpdate(
            string id,
            string model,
            DateTimeOffset created,
            ChatRole? role = null,
            string contentUpdate = null,
            CompletionsFinishReason? finishReason = null,
            StreamingToolCallUpdate toolCallUpdate = null)
            CompletionsUsage usage = null)
        {
            Id = id;
            Model = model;
            Created = created;
            Role = role;
            ContentUpdate = contentUpdate;
            FinishReason = finishReason;
            ToolCallUpdate = toolCallUpdate;
            Usage = usage;
        }
    }
}
