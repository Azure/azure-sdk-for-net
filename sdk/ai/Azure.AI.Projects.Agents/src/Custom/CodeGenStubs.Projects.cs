// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.Projects.Agents;

namespace Azure.AI.Projects.Agents;

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
