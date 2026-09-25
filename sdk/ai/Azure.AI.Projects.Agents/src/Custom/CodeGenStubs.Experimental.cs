// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402 // File may only contain a single type - intentional: small marker stubs spanning multiple namespaces

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects.Agents
{
    [Experimental("AAIP001")] internal partial class CreateSkillVersionRequest { }
    [Experimental("AAIP001")] internal partial class ProjectAgentSkillsGetSkillVersionsAsyncCollectionResult { }
    [Experimental("AAIP001")] internal partial class ProjectAgentSkillsGetSkillVersionsCollectionResult { }

    // References Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions, which is itself
    // [Experimental]. Marking this type with the same diagnostic id keeps it consistent with
    // the rest of the Beta Voice Agents preview surface.
    [Experimental("AAIP001")] public partial class BrowserAutomationToolboxTool { }

    // These types were generated directly into the OpenAI namespace before the namespace-leak
    // fix moved them here (see CHANGELOG). They represent OpenAI Realtime/Responses features
    // not yet present in the published OpenAI .NET SDK, so they're marked experimental in case
    // their shape needs to change once/if OpenAI ships an equivalent.
    //
    // The 4 enums are converted to extensible enums (empty partial struct with the same name)
    // rather than redeclared as closed enums: a closed enum's generated Serialization.cs is a
    // separate top-level extension-methods class that wouldn't inherit [Experimental] from a
    // partial enum redeclaration, so referencing the enum's own (de)serialization helpers would
    // still error. An extensible enum keeps every generated member (constants, conversions,
    // equality) inside this same partial struct, so [Experimental] applies to all of them.
    // There are no existing usages of these 4 types, so this shape change carries no risk.
    //
    // NOTE: of the 13 types moved by the namespace-leak fix, only these 5 are used exclusively
    // by Voice Agents code. The other 8 (CallableToolAllowedCaller, ContainerMemoryLimit,
    // ContainerSkill, InlineSkillParam, InlineSkillSourceParam, SkillReferenceParam,
    // MCPToolboxToolConnectorId, WebSearchToolSearchContextSize) are also referenced by
    // pre-existing, stable, non-Voice-Agent Toolbox tool types (ShellToolboxTool,
    // MCPToolboxTool, WebSearchToolboxTool, CodeInterpreterToolboxTool,
    // ToolboxShellContainerAutoEnvironment) that already ship on main. Marking those 8
    // experimental would cascade the [Experimental] requirement onto those stable types and
    // break existing (non-Voice-Agent) samples/tests, so they intentionally stay un-marked.
    [Experimental("AAIP001")] public partial struct VoiceResponseBaseStatus { }
    [Experimental("AAIP001")] public partial struct VoiceResponseBaseOutputModality { }
    [Experimental("AAIP001")] public partial struct VoiceAgentAudioInputConfigTranscriptionDelay { }
    [Experimental("AAIP001")] public partial struct VoiceAgentSemanticVadTurnDetectionEagerness { }
    [Experimental("AAIP001")] public partial class RealtimeFunctionToolParameters { }
}

namespace Azure.AI.Projects.Agents._Beta
{
    [Experimental("AAIP001")] public partial class Beta { }
}

namespace Azure.AI.Projects.Agents._Beta.VoiceAgents
{
    [Experimental("AAIP001")] public partial class BetaVoiceAgentsConversations { }
    [Experimental("AAIP001")] public partial class BetaVoiceAgentsTelephony { }
    [Experimental("AAIP001")] public partial class BetaVoiceAgents { }

    // These internal collection-result helper types construct instances of experimental
    // paged-result wrapper types (e.g. AgentsPagedResultVoiceConversation) as part of their own
    // implementation. Marking them [Experimental] too (matching the same diagnostic id) lets
    // them reference those types without requiring external callers to opt in, since these
    // types are purely internal plumbing and not part of the public API surface.
    [Experimental("AAIP001")] internal partial class BetaVoiceAgentsConversationsGetAgentConversationsCollectionResult { }
    [Experimental("AAIP001")] internal partial class BetaVoiceAgentsConversationsGetAgentConversationsAsyncCollectionResult { }
    [Experimental("AAIP001")] internal partial class BetaVoiceAgentsConversationsGetAgentConversationResponsesCollectionResult { }
    [Experimental("AAIP001")] internal partial class BetaVoiceAgentsConversationsGetAgentConversationResponsesAsyncCollectionResult { }
    [Experimental("AAIP001")] internal partial class BetaVoiceAgentsConversationsGetAgentConversationResponseItemsCollectionResult { }
    [Experimental("AAIP001")] internal partial class BetaVoiceAgentsConversationsGetAgentConversationResponseItemsAsyncCollectionResult { }
    [Experimental("AAIP001")] internal partial class BetaVoiceAgentsConversationsGetAgentConversationItemsCollectionResult { }
    [Experimental("AAIP001")] internal partial class BetaVoiceAgentsConversationsGetAgentConversationItemsAsyncCollectionResult { }
    [Experimental("AAIP001")] internal partial class BetaVoiceAgentsTelephonyGetTelephonyBindingsCollectionResult { }
    [Experimental("AAIP001")] internal partial class BetaVoiceAgentsTelephonyGetTelephonyBindingsAsyncCollectionResult { }
    [Experimental("AAIP001")] internal partial class BetaVoiceAgentsTelephonyGetTelephonyCallsCollectionResult { }
    [Experimental("AAIP001")] internal partial class BetaVoiceAgentsTelephonyGetTelephonyCallsAsyncCollectionResult { }
}
