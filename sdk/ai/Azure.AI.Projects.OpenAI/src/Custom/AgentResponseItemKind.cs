// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("AgentResponseItemKind")]
public readonly partial struct AgentResponseItemKind
{
    // Customization: manually restore kinds pruned by code generator
    // (due to lack of model grounding in client view)
    private const string MessageValue = "message";
    public static AgentResponseItemKind Message { get; } = new AgentResponseItemKind(MessageValue);
}
