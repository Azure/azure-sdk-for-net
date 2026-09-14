// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects.Agents;

/// <summary> The ProjectsClient. </summary>
[CodeGenType("ProjectsClient")]
[CodeGenSuppress("GetConversationsClient")]
[CodeGenSuppress("GetAgentClient")]
[CodeGenSuppress("GetMemoryStoresClient")]
[CodeGenSuppress("GetProjectAgentSkillsClient")]
[CodeGenSuppress("GetAgentOptimizationJobsClient")]
[CodeGenSuppress("GetAgentEndpointConversationsClient")]
[CodeGenSuppress("_cachedAgentClient")]
[CodeGenSuppress("_cachedConversations")]
[CodeGenSuppress("_cachedMemoryStores")]
[CodeGenSuppress("_cachedProjectAgentSkills")]
[CodeGenSuppress("_cachedAgentOptimizationJobs")]
[CodeGenSuppress("_cachedAgentEndpointConversations")]
internal partial class InternalProjectsClient
{
}

[CodeGenType("InternalProjectsClientOptions")] public partial class AgentAdministrationClientOptions { }
