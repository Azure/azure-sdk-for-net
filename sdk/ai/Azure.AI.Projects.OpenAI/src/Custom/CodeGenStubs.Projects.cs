// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.Projects.OpenAI;

namespace Azure.AI.Projects;

/// <summary> The ProjectsClient. </summary>
[CodeGenType("ProjectsClient")]
[CodeGenSuppress("GetConversationsClient")]
[CodeGenSuppress("GetAgentClient")]
[CodeGenSuppress("GetMemoryStoresClient")]
[CodeGenSuppress("_cachedAgentClient")]
[CodeGenSuppress("_cachedConversations")]
[CodeGenSuppress("_cachedMemoryStores")]
internal partial class InternalProjectsClient
{
}

[CodeGenType("InternalProjectsClientOptions")] internal partial class InternalProjectsClientOptions { }

[CodeGenType("AgentsClient")] internal partial class InternalAgentsClient { }
[CodeGenType("MemoryStoreClient")] internal partial class InternalMemoryStoreClient { }
[CodeGenType("MemoryStoreOperationUsageInputTokensDetails")] internal partial class InternalMemoryStoreOperationUsageInputTokensDetails { }
[CodeGenType("MemoryStoreOperationUsageOutputTokensDetails")] internal partial class InternalMemoryStoreOperationUsageOutputTokensDetails { }
[CodeGenType("UserProfileMemoryItem")] internal partial class UserProfileMemoryItem { }
[CodeGenType("MemoryUpdateResultDetails")] internal partial class InternalMemoryUpdateResultDetails { }
[CodeGenType("ConversationList")] internal partial class InternalConversationList { }
