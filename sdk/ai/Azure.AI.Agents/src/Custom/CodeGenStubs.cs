// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Agents;

// Public type renames

[CodeGenType("AgentContainerObject")] public partial class AgentContainer { }
[CodeGenType("AgentContainerOperationObject")] public partial class AgentContainerOperation { }
[CodeGenType("ConversationResource")] public partial class AgentConversation { }
[CodeGenType("AgentId")] public partial class AgentInfo { }
[CodeGenType("AgentObject")] public partial class AgentRecord { }
[CodeGenType("AgentProtocol")] public readonly partial struct AgentCommunicationMethod { }
[CodeGenType("AgentVersionObject")] public partial class AgentVersion { }
[CodeGenType("CreateAgentVersionFromManifestRequest1")] public partial class AgentManifestOptions { }
[CodeGenType("DeleteAgentResponse")] public partial class AgentDeletionResult { }
[CodeGenType("DeletedConversationResource")] public partial class AgentConversationDeletionResult { }
[CodeGenType("ItemType")] public readonly partial struct AgentResponseItemKind { }
[CodeGenType("ListAgentsRequestOrder")] public readonly partial struct AgentsListOrder { }
[CodeGenType("MemoryStoreUpdateResult")] public partial class MemoryUpdateResultDetails { }
[CodeGenType("WorkflowActionOutputItemResourceStatus")] public readonly partial struct AgentWorkflowActionStatus { }
