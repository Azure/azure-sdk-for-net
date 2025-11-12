// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Agents;

// Public type renames

[CodeGenType("ConversationResource")] public partial class AgentConversation { }
[CodeGenType("AgentId")] public partial class AgentInfo { }
[CodeGenType("AgentObject")] public partial class AgentRecord { }
[CodeGenType("AgentProtocol")] public readonly partial struct AgentCommunicationMethod { }
[CodeGenType("CreateAgentVersionFromManifestRequest1")] public partial class AgentManifestOptions { }
[CodeGenType("CreatedBy")] public partial class AgentResponseItemSource { }
[CodeGenType("ItemType")] public readonly partial struct AgentResponseItemKind { }
[CodeGenType("MemoryStoreOperationUsageInputTokensDetails")] public partial class MemoryStoreOperationUsageInputTokensDetails { }
[CodeGenType("MemoryStoreOperationUsageOutputTokensDetails")] public partial class MemoryStoreOperationUsageOutputTokensDetails { }
[CodeGenType("MemoryStoreUpdateResult")] public partial class MemoryUpdateResultDetails { }
[CodeGenType("WorkflowActionOutputItemResourceStatus")] public readonly partial struct AgentWorkflowActionStatus { }

// Made internal
[CodeGenType("DeleteAgentResponse")] internal partial class AgentDeletionResult { }
[CodeGenType("DeletedConversationResource")] internal partial class AgentConversationDeletionResult { }
