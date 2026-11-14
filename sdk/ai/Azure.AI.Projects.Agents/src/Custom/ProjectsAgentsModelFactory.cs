// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Azure.AI.Extensions.OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects.Agents;

public partial class ProjectsAgentsModelFactory
{
    /// <summary> Creates a new instance of <see cref="Agents.ProjectsAgentRecord"/> for mocking. </summary>
    /// <param name="id">The agent identifier.</param>
    /// <param name="name">The agent name.</param>
    /// <param name="state">The agent state.</param>
    public static ProjectsAgentRecord ProjectsAgentRecord(string id = default, string name = default, AgentState state = default)
    {
        return new ProjectsAgentRecord(
            @object: "agent",
            id: id,
            name: name,
            state: state,
            configurationState: default,
            stateSource: default,
            versions: new AgentObjectVersions(),
            agentEndpoint: default,
            digitalWorkerType: default,
            instanceIdentity: default,
            blueprint: default,
            blueprintReference: default,
            agentCard: default,
            additionalBinaryDataProperties: null);
    }

    internal static ProjectsAgentRecord ProjectsAgentRecord(string id = default, string name = default, AgentState state = default, AgentState configurationState = default, AgentStateSource? stateSource = default, AgentObjectVersions versions = default, AgentEndpointConfiguration agentEndpoint = default, DigitalWorkerType? digitalWorkerType = default, AgentIdentity instanceIdentity = default, AgentIdentity blueprint = default, AgentBlueprintReference blueprintReference = default, AgentCard agentCard = default)
    {
        return new ProjectsAgentRecord(
                @object: "agent",
                id: id,
                name: name,
                state: state,
                configurationState: configurationState,
                stateSource: stateSource,
                versions: versions,
                agentEndpoint: agentEndpoint,
                digitalWorkerType: digitalWorkerType,
                instanceIdentity: instanceIdentity,
                blueprint: blueprint,
                blueprintReference: blueprintReference,
                agentCard: agentCard,
                additionalBinaryDataProperties: null);
    }

    #region The next constructors are made to hide the factory methods with binary data.

    /// <summary> A code interpreter tool stored in a toolbox. </summary>
    /// <param name="name"> Optional user-defined name for this tool or configuration. </param>
    /// <param name="description"> Optional user-defined description for this tool or configuration. </param>
    /// <param name="toolConfigs">
    /// Per-tool configuration map. Keys are tool names or `*` (catch-all default).
    /// Resolution order: exact tool name match takes priority over `*`.
    /// Unknown tool names are silently ignored at runtime.
    /// </param>
    /// <param name="allowedCallers"></param>
    /// <param name="internalContainer">
    /// The code interpreter container. Can be a container ID or an object that
    /// specifies uploaded file IDs to make available to your code, along with an
    /// optional `memory_limit` setting.
    /// If not provided, the service assumes auto.
    /// </param>
    /// <returns> A new <see cref="Agents.CodeInterpreterToolboxTool"/> instance for mocking. </returns>
    internal static CodeInterpreterToolboxTool CodeInterpreterToolboxTool(string name = default, string description = default, IDictionary<string, ToolConfig> toolConfigs = default, IEnumerable<CallableToolAllowedCaller> allowedCallers = default, BinaryData internalContainer = default)
    {
        toolConfigs ??= new ChangeTrackingDictionary<string, ToolConfig>();
        allowedCallers ??= new ChangeTrackingList<CallableToolAllowedCaller>();

        return new CodeInterpreterToolboxTool(
            ToolboxToolType.CodeInterpreter,
            name,
            description,
            toolConfigs,
            additionalBinaryDataProperties: null,
            allowedCallers.ToList(),
            internalContainer);
    }

    /// <summary> A code interpreter tool stored in a toolbox. </summary>
    /// <param name="name"> Optional user-defined name for this tool or configuration. </param>
    /// <param name="description"> Optional user-defined description for this tool or configuration. </param>
    /// <param name="toolConfigs">
    /// Per-tool configuration map. Keys are tool names or `*` (catch-all default).
    /// Resolution order: exact tool name match takes priority over `*`.
    /// Unknown tool names are silently ignored at runtime.
    /// </param>
    /// <param name="allowedCallers"></param>
    /// <param name="container">
    /// The code interpreter container. Can be a container ID or an object that
    /// specifies uploaded file IDs to make available to your code, along with an
    /// optional `memory_limit` setting.
    /// If not provided, the service assumes auto.
    /// </param>
    /// <returns> A new <see cref="Agents.CodeInterpreterToolboxTool"/> instance for mocking. </returns>
    public static CodeInterpreterToolboxTool CodeInterpreterToolboxTool(string name = default, string description = default, IDictionary<string, ToolConfig> toolConfigs = default, IEnumerable<CallableToolAllowedCaller> allowedCallers = default, CodeInterpreterToolContainer container = default)
    {
        toolConfigs ??= new ChangeTrackingDictionary<string, ToolConfig>();
        allowedCallers ??= new ChangeTrackingList<CallableToolAllowedCaller>();

        return new CodeInterpreterToolboxTool(
            type: ToolboxToolType.CodeInterpreter,
            name: name,
            description: description,
            toolConfigs: toolConfigs,
            additionalBinaryDataProperties: null,
            allowedCallers: [..allowedCallers],
            internalContainer: ModelReaderWriter.Write(container, ModelSerializationExtensions.WireOptions, AzureAIProjectsAgentsContext.Default));
    }

    /// <summary>
    /// The voice agent definition. Its configuration (model, instructions, audio, tools, and optional avatar) drives a
    /// managed speech-to-speech experience. Establish realtime voice sessions through
    /// `GET /agents/{agent_name}/endpoint/protocols/voice`. Every create or update produces a new immutable version.
    /// </summary>
    /// <param name="contentFilterConfiguration"> Configuration for Responsible AI (RAI) content filtering and safety features. </param>
    /// <param name="modelType"> How the model backing this voice agent is served. Required with `model` for a model-backed voice agent and omitted when `conversation_engine` is provided. This is independent of the architecture (realtime or cascaded), which the service derives from the selected model. </param>
    /// <param name="model"> The model to use for this agent. Required with `model_type` for a model-backed voice agent and omitted when `conversation_engine` is provided. The model must support realtime or cascaded voice. </param>
    /// <param name="conversationEngine"> The engine that owns conversation handling for this voice agent. Exactly one of this property and the model-backed configuration (`model_type` with `model`) must be provided. When this property is provided, `model_type`, `model`, `instructions`, `tools`, and `tool_choice` must be omitted, and `greeting.tool_choice` cannot be `required`, because the engine owns the conversation logic. The initial implementation supports a hosted-agent engine. </param>
    /// <param name="instructions"> A system (or developer) message inserted into the model's context. Supports template substitution via `structured_inputs`, rendered per session before the live session starts. </param>
    /// <param name="greeting"> Optional session-start greeting. Template mode speaks exact rendered text; LLM-generated mode asks the session model to author the opening response and may use configured tools. </param>
    /// <param name="audio">
    /// The audio configuration, including input and output formats, voice, turn detection, noise reduction, and
    /// transcription. These values are session defaults; a client may override supported fields when connecting.
    /// </param>
    /// <param name="soundscape"> Optional background ambience and event cues, stored with the agent version and separate from the audio configuration. Currently rendered only for telephony calls, not browser WebRTC or direct voice WebSocket sessions. Omit this property to disable all auxiliary audio. Persisted conversation recordings do not include the soundscape mix. </param>
    /// <param name="outputModalities">
    /// The output modalities the agent produces. Defaults to `["audio"]`. `animation` and `avatar` are available
    /// when an avatar is configured.
    /// </param>
    /// <param name="internalMaxOutputTokens"> The maximum output-token count for one response. </param>
    /// <param name="include"> Additional fields to include in service outputs. </param>
    /// <param name="interimResponse"> Interim-response settings for latency and tool execution. </param>
    /// <param name="avatar"> Optional avatar configuration. These values are session defaults and may be overridden when connecting. </param>
    /// <param name="tools">
    /// The tools the voice agent may use. Supported tool kinds are `function` (executed by the client), `mcp`,
    /// `system` (service-managed session controls), and `toolbox`. Server-side tools such as `web_search`,
    /// `azure_ai_search`, and `openapi` are provided through a toolbox rather than declared directly.
    /// </param>
    /// <param name="toolChoice">
    /// How the model chooses tools for generated responses. `none` prevents tool calls, `auto` lets the model decide,
    /// `required` requires at least one tool call, and a specific function or MCP tool can be selected with an object.
    /// Defaults to `auto`.
    /// </param>
    /// <param name="parallelToolCalls"> Whether the model may call multiple tools in parallel. </param>
    /// <param name="structuredInputs"> Set of structured inputs that participate in prompt template substitution, rendered per session before the live session starts. </param>
    /// <param name="subagentConfig"> Optional configuration for sibling Foundry text agents that this voice agent may consult as background specialists. </param>
    /// <param name="postCall"> Optional post-call delivery configuration. After each session ends, the service notifies the configured destinations. </param>
    /// <param name="store">
    /// Whether conversations with this agent are persisted. A single, all-or-nothing persistence switch that defaults to
    /// `false` (privacy-safe: off by default). When `true`, Foundry persists the full conversation — the transcript/event
    /// timeline and raw audio. When `false`, nothing is persisted and no conversation is surfaced. There is no separate
    /// audio-logging control; audio is persisted only as part of this switch. Latency/performance telemetry (e.g.
    /// time-to-first-audio, inter-token latency, interruption) is observability-only (customer trace / App Insights) and
    /// is not part of the persisted conversation content.
    /// </param>
    /// <returns> A new <see cref="Agents.VoiceAgentDefinition"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    public static VoiceAgentDefinition VoiceAgentDefinition(ContentFilterConfiguration contentFilterConfiguration = default, VoiceModelType? modelType = default, string model = default, VoiceConversationEngine conversationEngine = default, string instructions = default, VoiceAgentGreetingConfig greeting = default, VoiceAgentAudioConfig audio = default, VoiceAgentSoundscapeConfig soundscape = default, IEnumerable<VoiceOutputModality> outputModalities = default, BinaryData internalMaxOutputTokens = default, IEnumerable<VoiceAgentSessionIncludeOption> include = default, VoiceAgentInterimResponseConfig interimResponse = default, VoiceAgentAvatarConfig avatar = default, IEnumerable<VoiceAgentTool> tools = default, ToolChoiceOption toolChoice = null, bool? parallelToolCalls = default, IDictionary<string, StructuredInputDefinition> structuredInputs = default, VoiceAgentSubagentConfig subagentConfig = default, VoiceAgentPostCallConfig postCall = default, bool? store = default)
    {
        outputModalities ??= new ChangeTrackingList<VoiceOutputModality>();
        include ??= new ChangeTrackingList<VoiceAgentSessionIncludeOption>();
        tools ??= new ChangeTrackingList<VoiceAgentTool>();
        structuredInputs ??= new ChangeTrackingDictionary<string, StructuredInputDefinition>();

        return new VoiceAgentDefinition(
            kind: ProjectsAgentKind.Voice,
            contentFilterConfiguration: contentFilterConfiguration,
            additionalBinaryDataProperties: null,
            modelType: modelType,
            model: model,
            conversationEngine: conversationEngine,
            instructions: instructions,
            greeting: greeting,
            audio: audio,
            soundscape: soundscape,
            outputModalities: [..outputModalities],
            internalMaxOutputTokens: internalMaxOutputTokens,
            include: [..include],
            interimResponse: interimResponse,
            avatar: avatar,
            tools: [..tools],
            internalToolChoice: ModelReaderWriter.Write(toolChoice, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default),
            parallelToolCalls: parallelToolCalls,
            structuredInputs: structuredInputs,
            subagentConfig: subagentConfig,
            postCall: postCall,
            store: store);
    }

    /// <summary>
    /// The voice agent definition. Its configuration (model, instructions, audio, tools, and optional avatar) drives a
    /// managed speech-to-speech experience. Establish realtime voice sessions through
    /// `GET /agents/{agent_name}/endpoint/protocols/voice`. Every create or update produces a new immutable version.
    /// </summary>
    /// <param name="contentFilterConfiguration"> Configuration for Responsible AI (RAI) content filtering and safety features. </param>
    /// <param name="modelType"> How the model backing this voice agent is served. Required with `model` for a model-backed voice agent and omitted when `conversation_engine` is provided. This is independent of the architecture (realtime or cascaded), which the service derives from the selected model. </param>
    /// <param name="model"> The model to use for this agent. Required with `model_type` for a model-backed voice agent and omitted when `conversation_engine` is provided. The model must support realtime or cascaded voice. </param>
    /// <param name="conversationEngine"> The engine that owns conversation handling for this voice agent. Exactly one of this property and the model-backed configuration (`model_type` with `model`) must be provided. When this property is provided, `model_type`, `model`, `instructions`, `tools`, and `tool_choice` must be omitted, and `greeting.tool_choice` cannot be `required`, because the engine owns the conversation logic. The initial implementation supports a hosted-agent engine. </param>
    /// <param name="instructions"> A system (or developer) message inserted into the model's context. Supports template substitution via `structured_inputs`, rendered per session before the live session starts. </param>
    /// <param name="greeting"> Optional session-start greeting. Template mode speaks exact rendered text; LLM-generated mode asks the session model to author the opening response and may use configured tools. </param>
    /// <param name="audio">
    /// The audio configuration, including input and output formats, voice, turn detection, noise reduction, and
    /// transcription. These values are session defaults; a client may override supported fields when connecting.
    /// </param>
    /// <param name="soundscape"> Optional background ambience and event cues, stored with the agent version and separate from the audio configuration. Currently rendered only for telephony calls, not browser WebRTC or direct voice WebSocket sessions. Omit this property to disable all auxiliary audio. Persisted conversation recordings do not include the soundscape mix. </param>
    /// <param name="outputModalities">
    /// The output modalities the agent produces. Defaults to `["audio"]`. `animation` and `avatar` are available
    /// when an avatar is configured.
    /// </param>
    /// <param name="internalMaxOutputTokens"> The maximum output-token count for one response. </param>
    /// <param name="include"> Additional fields to include in service outputs. </param>
    /// <param name="interimResponse"> Interim-response settings for latency and tool execution. </param>
    /// <param name="avatar"> Optional avatar configuration. These values are session defaults and may be overridden when connecting. </param>
    /// <param name="tools">
    /// The tools the voice agent may use. Supported tool kinds are `function` (executed by the client), `mcp`,
    /// `system` (service-managed session controls), and `toolbox`. Server-side tools such as `web_search`,
    /// `azure_ai_search`, and `openapi` are provided through a toolbox rather than declared directly.
    /// </param>
    /// <param name="internalToolChoice">
    /// How the model chooses tools for generated responses. `none` prevents tool calls, `auto` lets the model decide,
    /// `required` requires at least one tool call, and a specific function or MCP tool can be selected with an object.
    /// Defaults to `auto`.
    /// </param>
    /// <param name="parallelToolCalls"> Whether the model may call multiple tools in parallel. </param>
    /// <param name="structuredInputs"> Set of structured inputs that participate in prompt template substitution, rendered per session before the live session starts. </param>
    /// <param name="subagentConfig"> Optional configuration for sibling Foundry text agents that this voice agent may consult as background specialists. </param>
    /// <param name="postCall"> Optional post-call delivery configuration. After each session ends, the service notifies the configured destinations. </param>
    /// <param name="store">
    /// Whether conversations with this agent are persisted. A single, all-or-nothing persistence switch that defaults to
    /// `false` (privacy-safe: off by default). When `true`, Foundry persists the full conversation — the transcript/event
    /// timeline and raw audio. When `false`, nothing is persisted and no conversation is surfaced. There is no separate
    /// audio-logging control; audio is persisted only as part of this switch. Latency/performance telemetry (e.g.
    /// time-to-first-audio, inter-token latency, interruption) is observability-only (customer trace / App Insights) and
    /// is not part of the persisted conversation content.
    /// </param>
    /// <returns> A new <see cref="Agents.VoiceAgentDefinition"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    internal static VoiceAgentDefinition VoiceAgentDefinition(ContentFilterConfiguration contentFilterConfiguration = default, VoiceModelType? modelType = default, string model = default, VoiceConversationEngine conversationEngine = default, string instructions = default, VoiceAgentGreetingConfig greeting = default, VoiceAgentAudioConfig audio = default, VoiceAgentSoundscapeConfig soundscape = default, IEnumerable<VoiceOutputModality> outputModalities = default, BinaryData internalMaxOutputTokens = default, IEnumerable<VoiceAgentSessionIncludeOption> include = default, VoiceAgentInterimResponseConfig interimResponse = default, VoiceAgentAvatarConfig avatar = default, IEnumerable<VoiceAgentTool> tools = default, BinaryData internalToolChoice = default, bool? parallelToolCalls = default, IDictionary<string, StructuredInputDefinition> structuredInputs = default, VoiceAgentSubagentConfig subagentConfig = default, VoiceAgentPostCallConfig postCall = default, bool? store = default)
    {
        outputModalities ??= new ChangeTrackingList<VoiceOutputModality>();
        include ??= new ChangeTrackingList<VoiceAgentSessionIncludeOption>();
        tools ??= new ChangeTrackingList<VoiceAgentTool>();
        structuredInputs ??= new ChangeTrackingDictionary<string, StructuredInputDefinition>();

        return new VoiceAgentDefinition(
            ProjectsAgentKind.Voice,
            contentFilterConfiguration,
            additionalBinaryDataProperties: null,
            modelType,
            model,
            conversationEngine,
            instructions,
            greeting,
            audio,
            soundscape,
            outputModalities.ToList(),
            internalMaxOutputTokens,
            include.ToList(),
            interimResponse,
            avatar,
            tools.ToList(),
            internalToolChoice,
            parallelToolCalls,
            structuredInputs,
            subagentConfig,
            postCall,
            store);
    }

    /// <summary> A greeting authored by the session model from a scoped opening-turn prompt. </summary>
    /// <param name="prompt"> The Handlebars prompt that guides the opening turn. </param>
    /// <param name="internalToolChoice"> The tool-selection policy for the opening response. Defaults to `none`. </param>
    /// <returns> A new <see cref="Agents.VoiceAgentLlmGeneratedGreetingConfig"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    internal static VoiceAgentLlmGeneratedGreetingConfig VoiceAgentLlmGeneratedGreetingConfig(string prompt = default, BinaryData internalToolChoice = default)
    {
        return new VoiceAgentLlmGeneratedGreetingConfig("llm_generated", additionalBinaryDataProperties: null, prompt, internalToolChoice);
    }

    /// <summary> A greeting authored by the session model from a scoped opening-turn prompt. </summary>
    /// <param name="prompt"> The Handlebars prompt that guides the opening turn. </param>
    /// <param name="toolChoice"> The tool-selection policy for the opening response. Defaults to `none`. </param>
    /// <returns> A new <see cref="Agents.VoiceAgentLlmGeneratedGreetingConfig"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    public static VoiceAgentLlmGeneratedGreetingConfig VoiceAgentLlmGeneratedGreetingConfig(string prompt = default, ToolChoiceOption toolChoice = null)
    {
        return new VoiceAgentLlmGeneratedGreetingConfig(
            type: "llm_generated",
            additionalBinaryDataProperties: null,
            prompt: prompt,
            internalToolChoice: ModelReaderWriter.Write(toolChoice, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default));
    }
    #endregion
}
