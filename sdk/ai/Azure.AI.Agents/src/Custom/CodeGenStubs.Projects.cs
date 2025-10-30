// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.Agents;

namespace Azure.AI.Projects;

/// <summary> The ProjectsClient. </summary>
[CodeGenType("ProjectsClient")]
[CodeGenSuppress("GetConversationsClient")]
[CodeGenSuppress("GetAgentsClient")]
[CodeGenSuppress("GetMemoryStoresClient")]
[CodeGenSuppress("_cachedAgentsClient")]
[CodeGenSuppress("_cachedConversations")]
[CodeGenSuppress("_cachedMemoryStores")]
internal partial class InternalProjectsClient
{
}

[CodeGenType("InternalProjectsClientOptions")] internal partial class InternalProjectsClientOptions { }
