// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects.Agents;

/// <summary> The ProjectsClient. </summary>
[CodeGenType("ProjectsClient")]
[CodeGenSuppress("GetConversationsClient")]
[CodeGenSuppress("GetAgentClient")]
[CodeGenSuppress("GetMemoryStoresClient")]
[CodeGenSuppress("GetProjectAgentSkillsClient")]
[CodeGenSuppress("GetAgentOptimizationJobsClient")]
[CodeGenSuppress("GetBetaVoiceAgentsConversationsClient")]
[CodeGenSuppress("GetBetaVoiceAgentsTelephonyClient")]
[CodeGenSuppress("GetInternalBetaClient")]
[CodeGenSuppress("_cachedAgentClient")]
[CodeGenSuppress("_cachedConversations")]
[CodeGenSuppress("_cachedMemoryStores")]
[CodeGenSuppress("_cachedProjectAgentSkills")]
[CodeGenSuppress("_cachedAgentOptimizationJobs")]
[CodeGenSuppress("_cachedBetaVoiceAgentsConversations")]
[CodeGenSuppress("_cachedBetaVoiceAgentsTelephony")]
// _cachedBeta is typed as the [Experimental] Beta sub-client, but the generator doesn't mark
// the field itself [Experimental] (unlike the analogous fields it generates directly in
// AgentAdministrationClient's customization). Suppress and re-declare it below with the
// attribute instead of marking the whole class [Experimental], which would otherwise cascade
// into the public, non-experimental AgentAdministrationClient.
[CodeGenSuppress("_cachedBeta")]
internal partial class InternalProjectsClient
{
    [Experimental("AAIP001")]
    private Azure.AI.Projects.Agents._Beta.Beta _cachedBeta;
}

[CodeGenType("InternalProjectsClientOptions")] public partial class AgentAdministrationClientOptions { }
