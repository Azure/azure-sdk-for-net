// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

global using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Projects.OpenAI;

// Public type renames

[CodeGenType("AgentRecord")] public partial class AgentRecord
{
    [CodeGenMember("Object")]
    private string Object { get; } = "agent";
}

[CodeGenType("AgentResponseItemKind")] public readonly partial struct AgentResponseItemKind { }
[CodeGenType("MemorySearchToolCallItemResourceStatus")] public readonly partial struct MemorySearchToolCallStatus { }
[CodeGenType("WorkflowActionOutputItemResourceStatus")] public readonly partial struct AgentWorkflowActionStatus { }
[CodeGenType("OpenApiFunctionDefinitionFunction")] public partial class OpenAPIFunctionEntry { }
[CodeGenType("AgentItemSource")] public partial class AgentItemSource { }
[CodeGenType("WebSearchConfiguration")] public partial class ProjectWebSearchConfiguration { }