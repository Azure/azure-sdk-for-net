// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.OpenAI;

public partial class ChatCompletionsFunctionToolDefinition : ChatCompletionsToolDefinition
{
    // CUSTOM CODE NOTE:
    //   This code allows the concrete tool type to directly pass through use of its underlying function
    //   definition rather than having a separate layer of indirection.

    /// <summary> Initializes a new instance of <see cref="ChatCompletionsFunctionToolDefinition"/>. </summary>
    public ChatCompletionsFunctionToolDefinition()
        : this(new FunctionDefinition())
    {}

    /// <inheritdoc cref="FunctionDefinition.Name"/>
    public string Name
    {
        get => Function.Name;
        set => Function.Name = value;
    }

    /// <inheritdoc cref="FunctionDefinition.Description"/>
    public string Description
    {
        get => Function.Description;
        set => Function.Description = value;
    }

    /// <inheritdoc cref="FunctionDefinition.Parameters"/>
    public BinaryData Parameters
    {
        get => Function.Parameters;
        set => Function.Parameters = value;
    }
}
