// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402 // File may only contain a single type - intentional: small marker stubs spanning multiple namespaces

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects.Agents
{
    [Experimental("AAIP001")] internal partial class CreateSkillVersionRequest { }
    [Experimental("AAIP001")] internal partial class ProjectAgentSkillsGetSkillVersionsAsyncCollectionResult { }
    [Experimental("AAIP001")] internal partial class ProjectAgentSkillsGetSkillVersionsCollectionResult { }

    // Voice Agents types emitted without an experimental marker.
    [Experimental("AAIP001")] public partial struct VoiceAgentAudioInputConfigTranscriptionDelay { }
    [Experimental("AAIP001")] public partial class RealtimeFunctionToolParameters { }

    // Retain the existing extensible-enum shape without marking this unrelated toolbox type.
    public partial struct CallableToolAllowedCaller { }

    // The voice response discriminator is also part of the Voice Agents preview.
    [Experimental("AAIP001")] public readonly partial struct VoiceResponseBaseObject { }
    [Experimental("AAIP001")] public partial class AgentEndpointConversations { }

    [Experimental("AAIP001")] public partial class AgentOptimizationCandidate { }
    [Experimental("AAIP001")] public partial class AgentOptimizationJobResult { }

    // Generated collection helpers reference experimental clients and paged models.
    /// <summary> The response data for a requested list of items. </summary>
    [Experimental("AAIP001")] internal partial class AgentsPagedResultAgentOptimizationCandidate { }
    /// <summary> The response data for a requested list of items. </summary>
    [Experimental("AAIP001")] internal partial class AgentsPagedResultAgentOptimizationJob { }
    [Experimental("AAIP001")] internal partial class AgentOptimizationJobsGetAllCollectionResult { }
    [Experimental("AAIP001")] internal partial class AgentOptimizationJobsGetAllAsyncCollectionResult { }
    [Experimental("AAIP001")] internal partial class AgentEndpointConversationsGetAgentConversationsCollectionResult { }
    [Experimental("AAIP001")] internal partial class AgentEndpointConversationsGetAgentConversationsAsyncCollectionResult { }
    [Experimental("AAIP001")] internal partial class AgentEndpointConversationsGetAgentConversationResponsesCollectionResult { }
    [Experimental("AAIP001")] internal partial class AgentEndpointConversationsGetAgentConversationResponsesAsyncCollectionResult { }
    [Experimental("AAIP001")] internal partial class AgentEndpointConversationsGetAgentConversationResponseItemsCollectionResult { }
    [Experimental("AAIP001")] internal partial class AgentEndpointConversationsGetAgentConversationResponseItemsAsyncCollectionResult { }
    [Experimental("AAIP001")] internal partial class AgentEndpointConversationsGetAgentConversationItemsCollectionResult { }
    [Experimental("AAIP001")] internal partial class AgentEndpointConversationsGetAgentConversationItemsAsyncCollectionResult { }
    [Experimental("AAIP001")] internal partial class AgentTelephonyGetTelephonyBindingsCollectionResult { }
    [Experimental("AAIP001")] internal partial class AgentTelephonyGetTelephonyBindingsAsyncCollectionResult { }
    [Experimental("AAIP001")] internal partial class AgentTelephonyGetTelephonyCallsCollectionResult { }
    [Experimental("AAIP001")] internal partial class AgentTelephonyGetTelephonyCallsAsyncCollectionResult { }
}
