// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.OpenAI;

public partial class ChatCompletionsFunctionToolDefinition : ChatCompletionsToolDefinition
{
    /// <summary> Initializes a new instance of <see cref="ChatCompletionsFunctionToolDefinition"/>. </summary>
    public ChatCompletionsFunctionToolDefinition()
        : this(type: "function", new FunctionDefinition())
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
