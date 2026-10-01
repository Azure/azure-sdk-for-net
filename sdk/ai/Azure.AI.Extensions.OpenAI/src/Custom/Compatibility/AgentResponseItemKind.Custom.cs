// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Responses;

#pragma warning disable OPENAI001

namespace Azure.AI.Extensions.OpenAI;

public readonly partial struct AgentResponseItemKind
{
    // Customization: manually restore kinds pruned by code generator
    // (due to lack of model grounding in client view)
    private const string MessageValue = "message";
    /// <summary> Gets the message item kind. </summary>
    public static AgentResponseItemKind Message { get; } = new AgentResponseItemKind(MessageValue);

    /// <summary> Converts a legacy kind to the upstream kind with the same wire value. </summary>
    public static implicit operator ResponseItemKind(AgentResponseItemKind kind) => new ResponseItemKind(kind.ToString());

    /// <summary> Converts an upstream kind to the legacy kind with the same wire value. </summary>
    public static implicit operator AgentResponseItemKind(ResponseItemKind kind) => new AgentResponseItemKind(kind.ToString());
}
