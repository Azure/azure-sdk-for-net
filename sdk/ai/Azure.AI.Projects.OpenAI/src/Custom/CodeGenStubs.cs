// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.AI.Projects.OpenAI;

// Public type renames

[CodeGenType("ConversationResource")]
public partial class AgentConversation
{
    [CodeGenMember("Object")]
    private string Object { get; } = "conversation";
}

[CodeGenType("AgentId")] public partial class AgentInfo { }
[CodeGenType("AgentObject")] public partial class AgentRecord
{
    [CodeGenMember("Object")]
    private string Object { get; } = "agent";
}

[CodeGenType("AgentProtocol")] public readonly partial struct AgentCommunicationMethod { }
[CodeGenType("CreatedBy")] public partial class AgentResponseItemSource { }
[CodeGenType("ItemType")] public readonly partial struct AgentResponseItemKind { }
[CodeGenType("WorkflowActionOutputItemResourceStatus")] public readonly partial struct AgentWorkflowActionStatus { }
[CodeGenType("ContainerAppAgentDefinition")] public partial class ContainerApplicationAgentDefinition { }

[CodeGenType("MemorySearchToolCallItemResourceStatus")] public readonly partial struct MemorySearchToolCallStatus { }
[CodeGenType("OpenApiFunctionDefinitionFunction")] public partial class OpenAPIFunctionEntry { }
