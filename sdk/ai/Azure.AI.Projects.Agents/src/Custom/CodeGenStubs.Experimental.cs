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
    // Closed enums are converted to extensible enums (empty partial struct with the same name)
    // rather than redeclared as closed enums: a closed enum's generated Serialization.cs is a
    // separate top-level extension-methods class that wouldn't inherit [Experimental] from a
    // partial enum redeclaration, so referencing the enum's own (de)serialization helpers would
    // still error. An extensible enum keeps every generated member (constants, conversions,
    // equality) inside this same partial struct, so [Experimental] applies to all of them.
    //
    // All 13 types moved by the namespace-leak fix are marked here. 8 of them (below) are also
    // referenced by pre-existing Toolbox tool types (ShellToolboxTool, MCPToolboxTool,
    // WebSearchToolboxTool, CodeInterpreterToolboxTool, ToolboxShellContainerAutoEnvironment),
    // which cascades [Experimental] onto those types too. This is intentional: those Toolbox
    // types first shipped in 3.0.0-beta.3, the whole 3.0.0 line is still pre-GA (ApiCompatVersion
    // is 2.0.0), and this package's changelog already has precedent for breaking changes between
    // beta releases (see 3.0.0-beta.1). Marking these types now - while the surface is still
    // beta and adoption is low - avoids a harder, larger break later if OpenAI ships real
    // equivalents with different shapes after Toolboxes reaches GA. The one affected sample
    // (Sample_ToolboxesCRUD.cs) is updated with an AAIP001 suppression alongside this change.
    [Experimental("AAIP001")] public partial struct VoiceResponseBaseStatus { }
    [Experimental("AAIP001")] public partial struct VoiceResponseBaseOutputModality { }
    [Experimental("AAIP001")] public partial struct VoiceAgentAudioInputConfigTranscriptionDelay { }
    [Experimental("AAIP001")] public partial struct VoiceAgentSemanticVadTurnDetectionEagerness { }
    [Experimental("AAIP001")] public partial class RealtimeFunctionToolParameters { }

    // Cascades onto ShellToolboxTool, MCPToolboxTool, CodeInterpreterToolboxTool.
    [Experimental("AAIP001")] public partial struct CallableToolAllowedCaller { }
    // Cascades onto ToolboxShellContainerAutoEnvironment (via ShellToolboxTool).
    [Experimental("AAIP001")] public partial struct ContainerMemoryLimit { }
    [Experimental("AAIP001")] public abstract partial class ContainerSkill { }
    [Experimental("AAIP001")] public partial class InlineSkillParam { }
    [Experimental("AAIP001")] public partial class InlineSkillSourceParam { }
    [Experimental("AAIP001")] public partial class SkillReferenceParam { }
    // Cascades onto MCPToolboxTool.
    [Experimental("AAIP001")] public partial struct MCPToolboxToolConnectorId { }
    // Cascades onto WebSearchToolboxTool.
    [Experimental("AAIP001")] public partial struct WebSearchToolSearchContextSize { }

    // These 3 Toolbox tool types have no other Custom-file customization, so their
    // [Experimental] marker (cascaded from the types above) is declared here instead of in a
    // dedicated Custom file. CodeInterpreterToolboxTool and MCPToolboxTool are marked in their
    // own existing Custom files since they already have other customizations there.
    [Experimental("AAIP001")] public partial class ShellToolboxTool { }
    [Experimental("AAIP001")] public partial class ToolboxShellContainerAutoEnvironment { }
    [Experimental("AAIP001")] public partial class WebSearchToolboxTool { }

    // ShellToolboxTool's only public constructor requires a ToolboxShellEnvironment instance
    // (the abstract base for ToolboxShellContainerAutoEnvironment and its sibling
    // ToolboxShellContainerReferenceEnvironment), and the base's own generated discriminator
    // switch (DeserializeToolboxShellEnvironment) references the experimental
    // ToolboxShellContainerAutoEnvironment directly. So ShellToolboxTool can't be used at all
    // without also touching this hierarchy; the whole cluster is marked experimental together.
    [Experimental("AAIP001")] public abstract partial class ToolboxShellEnvironment { }
    [Experimental("AAIP001")] public partial class ToolboxShellContainerReferenceEnvironment { }
    // Internal "unknown discriminator value" fallback types for the ContainerSkill and
    // ToolboxShellEnvironment polymorphic hierarchies; not part of the public API surface, but
    // their generated (de)serialization code references the experimental base/sibling types.
    [Experimental("AAIP001")] internal partial class UnknownContainerSkill { }
    [Experimental("AAIP001")] internal partial class UnknownToolboxShellEnvironment { }
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
