// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402 // File may only contain a single type - intentional: small marker stubs

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects.Agents
{
    // References Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions, which is itself
    // [Experimental]. Marking this type with the same diagnostic id keeps it consistent with
    // the rest of the Beta Voice Agents preview surface.
    [Experimental("AAIP001")]
    public partial class BrowserAutomationToolboxTool { }
}

namespace Azure.AI.Projects.Agents._Beta
{
    [Experimental("AAIP001")]
    public partial class Beta { }
}

namespace Azure.AI.Projects.Agents
{
    // InternalProjectsClient's generated _cachedBeta field is typed as the [Experimental]
    // Beta sub-client, but the generator doesn't mark the field itself [Experimental] (unlike
    // the analogous fields it generates directly in AgentAdministrationClient's customization).
    // Re-declare the field here with the attribute instead of marking the whole class
    // [Experimental], which would otherwise cascade into the public, non-experimental
    // AgentAdministrationClient.
    [CodeGenSuppress("_cachedBeta")]
    internal partial class InternalProjectsClient
    {
        [Experimental("AAIP001")]
        private Azure.AI.Projects.Agents._Beta.Beta _cachedBeta;
    }
}

namespace Azure.AI.Projects.Agents._Beta.VoiceAgents
{
    // These internal collection-result helper types construct instances of experimental
    // paged-result wrapper types (e.g. AgentsPagedResultVoiceConversation) as part of their
    // own implementation. Marking them [Experimental] too (matching the same diagnostic id)
    // lets them reference those types without requiring external callers to opt in, since
    // these types are purely internal plumbing and not part of the public API surface.
    [Experimental("AAIP001")]
    internal partial class BetaVoiceAgentsConversationsGetAgentConversationsCollectionResult { }

    [Experimental("AAIP001")]
    internal partial class BetaVoiceAgentsConversationsGetAgentConversationsAsyncCollectionResult { }

    [Experimental("AAIP001")]
    internal partial class BetaVoiceAgentsConversationsGetAgentConversationResponsesCollectionResult { }

    [Experimental("AAIP001")]
    internal partial class BetaVoiceAgentsConversationsGetAgentConversationResponsesAsyncCollectionResult { }

    [Experimental("AAIP001")]
    internal partial class BetaVoiceAgentsConversationsGetAgentConversationResponseItemsCollectionResult { }

    [Experimental("AAIP001")]
    internal partial class BetaVoiceAgentsConversationsGetAgentConversationResponseItemsAsyncCollectionResult { }

    [Experimental("AAIP001")]
    internal partial class BetaVoiceAgentsConversationsGetAgentConversationItemsCollectionResult { }

    [Experimental("AAIP001")]
    internal partial class BetaVoiceAgentsConversationsGetAgentConversationItemsAsyncCollectionResult { }

    [Experimental("AAIP001")]
    internal partial class BetaVoiceAgentsTelephonyGetTelephonyBindingsCollectionResult { }

    [Experimental("AAIP001")]
    internal partial class BetaVoiceAgentsTelephonyGetTelephonyBindingsAsyncCollectionResult { }

    [Experimental("AAIP001")]
    internal partial class BetaVoiceAgentsTelephonyGetTelephonyCallsCollectionResult { }

    [Experimental("AAIP001")]
    public partial class BetaVoiceAgentsConversations { }

    [Experimental("AAIP001")]
    public partial class BetaVoiceAgentsTelephony { }

    [Experimental("AAIP001")]
    public partial class BetaVoiceAgents { }

    [Experimental("AAIP001")]
    internal partial class BetaVoiceAgentsTelephonyGetTelephonyCallsAsyncCollectionResult { }
}
