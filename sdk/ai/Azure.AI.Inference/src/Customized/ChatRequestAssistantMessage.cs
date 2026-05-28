// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using System.Collections.Generic;

namespace Azure.AI.Inference
{
    public partial class ChatRequestAssistantMessage : ChatRequestMessage
    {
        /// <summary>
        /// Creates a new instance of <see cref="ChatRequestAssistantMessage"/> that represents ordinary text content and
        /// does not feature tool or function calls.
        /// </summary>
        /// <param name="content"> The text content of the message. </param>
        public ChatRequestAssistantMessage(string content)
        {
            Argument.AssertNotNull(content, nameof(content));

            Role = ChatRole.Assistant;
            Content = content;
        }

        /// <summary>
        /// Creates a new instance of <see cref="ChatRequestAssistantMessage"/> that represents <c>tool_calls</c> that
        /// were provided by the model.
        /// </summary>
        /// <param name="toolCalls"> The <c>tool_calls</c> made by the model. </param>
        /// <param name="content"> Optional text content associated with the message. </param>
        public ChatRequestAssistantMessage(IEnumerable<ChatCompletionsToolCall> toolCalls, string content = null)
        {
            Argument.AssertNotNull(toolCalls, nameof(toolCalls));

            Role = ChatRole.Assistant;
            Content = content;

            foreach (ChatCompletionsToolCall toolCall in toolCalls)
            {
                ToolCalls.Add(toolCall);
            }
        }

        /// <summary>
        /// Creates a new instance of <see cref="ChatRequestAssistantMessage"/> from a <see cref="ChatCompletions"/> with
        /// an <c>assistant</c> role response.
        /// </summary>
        /// <remarks>
        ///     This constructor will copy the <c>content</c>, <c>tool_calls</c>, and <c>function_call</c> from a chat
        ///     completion response into a new <c>assistant</c> role request message.
        /// </remarks>
        /// <param name="chatCompletions">
        ///     The <see cref="ChatCompletions"/> from which the conversation history request message should be created.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     The <c>role</c> of the provided chat completion response was not <see cref="ChatRole.Assistant"/>.
        /// </exception>
        public ChatRequestAssistantMessage(ChatCompletions chatCompletions)
        {
            Argument.AssertNotNull(chatCompletions, nameof(chatCompletions));

            if (chatCompletions.Role != ChatRole.Assistant)
            {
                throw new NotSupportedException($"Cannot instantiate an {nameof(ChatRequestAssistantMessage)} from a {nameof(ChatCompletions)} with role: {chatCompletions.Role}.");
            }

            Role = ChatRole.Assistant;
            Content = chatCompletions.Content;

            if (chatCompletions.ToolCalls != null)
            {
                foreach (ChatCompletionsToolCall toolCall in chatCompletions.ToolCalls)
                {
                    ToolCalls.Add(toolCall);
                }
            }
        }

        // CUSTOM: Renamed.
        /// <summary>
        /// An optional <c>name</c> associated with the assistant message. This is typically defined with a <c>system</c>
        /// message and is used to differentiate between multiple participants of the same role.
        /// </summary>
        [CodeGenMember("Name")]
        public string ParticipantName { get; set; }

        // CUSTOM: Common initialization for input model collection property.
        [CodeGenMember("ToolCalls")]
        public IList<ChatCompletionsToolCall> ToolCalls { get; } = new ChangeTrackingList<ChatCompletionsToolCall>();

        // CUSTOM: Made internal.
        internal ChatRequestAssistantMessage() { }
    }
}
