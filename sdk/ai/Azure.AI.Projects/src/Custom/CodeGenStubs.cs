// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects;

// Public type renames

[CodeGenType("CreateAgentVersionFromManifestRequest1")] public partial class AgentManifestOptions { }
[CodeGenType("MemorySearchOptions")] public partial class MemorySearchResultOptions { }
[CodeGenType("MemoryStoreOperationUsageInputTokensDetails")] public partial class MemoryStoreOperationUsageInputTokensDetails { }
[CodeGenType("MemoryStoreOperationUsageOutputTokensDetails")] public partial class MemoryStoreOperationUsageOutputTokensDetails { }
[CodeGenType("MemoryStoreUpdateCompletedResult")] public partial class MemoryUpdateResultDetails { }

// Internal types

[CodeGenType("AgentDefinition")] internal partial class InternalAgentDefinition { }
[CodeGenType("AgentObject")] internal partial class InternalAgentObject { }
[CodeGenType("AgentProtocol")] internal readonly partial struct InternalAgentProtocol { }
[CodeGenType("AgentVersionObject")] internal partial class InternalAgentVersionObject { }
[CodeGenType("CreateMemoryStoreRequest")] internal partial class InternalCreateMemoryStoreRequest { }
[CodeGenType("PromptAgentDefinition")] internal partial class InternalPromptAgentDefinition { }
[CodeGenType("SearchMemoriesRequest")] internal partial class InternalMemorySearchOptions { }
[CodeGenType("Tool")] internal partial class InternalTool { }
[CodeGenType("UpdateMemoriesRequest")] internal partial class InternalMemoryUpdateOptions { }
