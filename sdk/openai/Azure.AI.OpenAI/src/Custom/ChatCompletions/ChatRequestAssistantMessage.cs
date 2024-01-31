// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.OpenAI;

public partial class ChatRequestAssistantMessage
{
    /// <summary>
    /// Initializes a new instance of <see cref="ChatRequestAssistantMessage"/> from a prior <see cref="ChatResponseMessage"/>
    /// instance from the Assistant.
    /// </summary>
    /// <param name="responseMessage"> The <see cref="ChatResponseMessage"/> to replicate from. </param>
    /// <exception cref="ArgumentException">
    ///     <paramref name="responseMessage"/> is not a valid response message to use.
    /// </exception>
    public ChatRequestAssistantMessage(ChatResponseMessage responseMessage)
        : this(responseMessage.Content)
    {
        FunctionCall = responseMessage.FunctionCall;
        if (Role != ChatRole.Assistant)
        {
            throw new ArgumentException($"Assistant message request messages may only be instantiated from response "
                + $"message instances of the Assistant role.");
        }
        foreach (ChatCompletionsToolCall chatCompletionsToolCall in responseMessage.ToolCalls)
        {
            ToolCalls.Add(chatCompletionsToolCall);
        }
    }
}
