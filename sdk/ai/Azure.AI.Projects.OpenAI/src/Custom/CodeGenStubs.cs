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

[CodeGenType("MemorySearchToolCallItemResourceStatus")] public readonly partial struct MemorySearchToolCallStatus { }
[CodeGenType("WorkflowActionOutputItemStatus")] public readonly partial struct AgentWorkflowPreviewActionStatus { }
[CodeGenType("OpenApiFunctionDefinitionFunction")] public partial class OpenAPIFunctionEntry { }
[CodeGenType("WebSearchConfiguration")] public partial class ProjectWebSearchConfiguration { }
