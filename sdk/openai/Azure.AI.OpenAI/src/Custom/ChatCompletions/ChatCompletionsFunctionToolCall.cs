// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.OpenAI;

public partial class ChatCompletionsFunctionToolCall : ChatCompletionsToolCall
{
    // CUSTOM CODE NOTE:
    //   This code allows the concrete tool call type to directly pass through use of its underlying function
    //   rather than having a separate layer of indirection.

    /// <inheritdoc cref="FunctionCall.Name"/>
    public string Name
    {
        get => Function.Name;
        set => Function.Name = value;
    }

    /// <inheritdoc cref="FunctionCall.Arguments"/>
    public string Arguments
    {
        get => Function.Arguments;
        set => Function.Arguments = value;
    }

    internal FunctionCall Function { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="ChatCompletionsFunctionToolCall"/>.
    /// </summary>
    /// <param name="id"> The ID of the function tool call. </param>
    /// <param name="name"> The name of the function that is called by the tool. </param>
    /// <param name="arguments"> The arguments to the function that is called by the tool. </param>
    /// <remarks>
    /// This constructor is intended for use with <see cref="ChatRequestAssistantMessage"/> when constructing request
    /// messages for conversation history from accumulated streaming tool call updates.
    /// </remarks>
    public ChatCompletionsFunctionToolCall(string id, string name, string arguments) : base(id)
    {
        Argument.AssertNotNull(name, nameof(name));
        Argument.AssertNotNull(arguments, nameof(arguments));
        Type = "function";
        Function = new(name, arguments);
    }
}
