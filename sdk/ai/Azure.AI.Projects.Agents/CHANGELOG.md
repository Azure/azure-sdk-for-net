# Release History

## 3.0.0-beta.8 (Unreleased)

### Features Added
- Promoted core Realtime/cascaded Voice Agent definitions, persisted conversations/responses/items, heard/generated audio and recordings, audio/voice/avatar/soundscape configuration, tools, delegate subagents, and non-SIP telephony to GA in the service contract. These shared types and core client operations no longer require a blanket `AAIP001` opt-in.
- Added experimental Live voice agent definitions, native client/server event models, and `BetaVoiceAgentsLiveConversations` for stored Live history and recordings.
- Added typed `VoiceAgentLiveSessionResource` snapshots, `VoiceAgentLiveDelegation` configuration, and `VoiceAgentLiveDelegationItem` metadata, including `foundry_managed_agent` ownership with the pinned agent name and resolved version.
- Added typed Realtime/Live definition dispatch and stored Live history pagination.
- Added experimental Live Decision, delegation configuration, and transport event models aligned with OpenAI TypeSpec 1.34.1.
- Live models, enums, value types, and model-factory methods require the `AAIP001` experimental opt-in.
- Added experimental inline voice subagents with handoff conditions, policies, and per-subagent voice configuration.
- Added language-detection, digit-recognition, transfer, SMS, and DTMF system-tool configuration, including execution timeouts.
- Added experimental SIP telephony binding models and allowed-caller configuration.
- Added experimental telephony campaign configuration, schedules, operation-bound completion reads, pagination, and validation-error APIs.
- Added the public `FoundryOpenAIError` data model for typed campaign failure details while keeping exception-formatting helpers internal.
- Restored skill and trace optimization models, including skill references, validation and execution results, trace windows, Application Insights connections, and skill candidate outputs.
- Restored the experimental legacy Skills API, including skill-version operations on the `/skills` routes with the preview `api-version` query, plus MCP toolbox request-header bindings.

### Breaking Changes
- The preview `ProjectsAgentsModelFactory.VoiceAgentDefinition` overload containing `postCall` now requires all arguments to avoid ambiguous calls to the optional GA overload. For named-argument usage, create the GA definition and then set its preview `PostCall` property. The full positional preview signature is retained.
- `VoiceAgentTransferRouting.RingTimeoutSeconds` now uses `TimeSpan?` instead of `int?`; JSON continues to use seconds.
- `AgentOptimizationJob.Status` now uses the shared `AgentsJobStatus`. The `AgentOptimizationJobStatus` type and its named `Skipped` value were removed; existing list filters continue to accept `AgentsJobStatus`.
- Realtime voice definitions now emit the required `sub_protocol` discriminator with the value `realtime`.
- `VoiceAgentSubagentConfig` is now an abstract base class. Use `VoiceAgentDelegateSubagentConfig` for referenced agents or `VoiceAgentInlineSubagentConfig` for inline handoff graphs.
- Telephony binding creation now accepts `TelephonyBinding` provider-specific models instead of the removed create-content models. Binding status fields and the binding-list status filter were removed.
- Telephony transfer and outbound addresses now use the `TelephonyAddress` hierarchy with the `type` discriminator. Use `PhoneNumber`, `TeamsAddress`, or `SipAddress` instead of the removed destination models.
- Outbound call-job creation now accepts `TelephonyCallJobCreate`, including a typed source address, and uses the `telephony_call_jobs` route.
- `VoiceRecordingChannelLayout.Left` and `Right` now use the extensible `VoiceAudioRole` type instead of `string`. Their wire values remain `user` and `agent`.

### Bugs Fixed
- Removed blanket Voice Agents preview headers from GA generation, conversation/audio reads, and non-SIP telephony. Conditional operations now preserve explicit caller opt-ins; native GPT Live history and telephony campaigns retain their required preview header.
- Applied consistent Voice Agents header handling to authenticated and settings-based client pipelines without overwriting caller-supplied feature headers.
- Fixed required-versus-conditional preview metadata handling so GA base types can serialize preview variants without exposing a blanket experimental API. Native GPT Live, inline/handoff, SIP, campaigns, and post-call delivery remain preview; experimental OpenAI dependencies retain member-level `AAIP002` attribution.
- Fixed Live Decision input and stored-message payloads to expose public patch access and preserve message fields during wire serialization.
- Fixed typed persisted Realtime response status and output-modality serialization to use the external OpenAI enum values rather than treating them as ModelReaderWriter models.
- Fixed `PhoneNumber`, `TeamsAddress`, and `SipAddress` serialization so inherited `value` properties are written exactly once.
- Fixed semantic VAD eagerness serialization and deserialization to preserve the external OpenAI string values.
- Fixed the Realtime model factory to preserve newly added fields, including `Soundscape` and `PostCall`, without changing the order of its existing parameters.
- Preserved the audio-output model factory's existing parameter order when introducing shared voice configuration.
- Preserved typed deserialization of existing delegate configurations that omit `subagent_type`.
- Fixed telephony call-history pagination to stop on terminal pages and use the correct cursor when paging backward.

### Sample Updates
- Updated GA Voice Agent administration to omit preview opt-ins and native GPT Live definition creation to request preview explicitly.
- Added Voice Agent REST administration, read-only telephony inspection, and campaign inspection samples, including typed address configuration without dispatching calls.

### Other Changes
- Regenerated from `foundry/snap-20261109` at [`3a17de2b4c2b23eec9e2f0985dbe5f6e2f417e0b`](https://github.com/Azure/azure-rest-api-specs/tree/3a17de2b4c2b23eec9e2f0985dbe5f6e2f417e0b), using OpenAI TypeSpec 1.34.1.

## 3.0.0-beta.7 (2026-11-12)

### Breaking Changes
- `AzureFunctionDefinitionFunction` was removed, please use the same class from `Azure.AI.Extensions.OpenAI`.
- Renamed `GenerateVoiceAgentRequest` to `GenerateVoiceAgentContent` and `UpdateToolboxRequest` to `UpdateToolboxContent`.
- Removed the `AgentCard(string, IEnumerable<AgentCardSkill>)` and `VersionSelector(IEnumerable<VersionSelectionRule>)` constructors. Use the parameterless constructors and set `Version`/`Skills` and `VersionSelectionRules` with initializers.
- `TelephonyTransferTarget` constructor no longer takes `name`; set the `Name` property instead.

### Bugs Fixed
- Fixed the cancellation of `ToolboxRecord` update.

## 3.0.0-beta.6 (2026-10-30)

### Features Added
- Added experimental Voice Agent post-call delivery to Event Grid connections and routines.
- Added experimental Voice Agent soundscapes for telephony ambience and event cues.
- Added Azure Speech streaming transcription and headset/personal noise suppression modes.
- Added `ProjectsAgentProtocol.VoiceConversationEngine` for hosted voice conversation engines.
- Enriched existing Foundry GenAI agent-creation traces with privacy-safe Voice Agent metadata and bounded instruction content under the existing opt-in setting. Other Voice Agent REST operations retain their existing SDK diagnostics.

### Breaking Changes
- Added the `postCall` parameter before `store` in `ProjectsAgentsModelFactory.VoiceAgentDefinition`, affecting positional arguments.
- Added the `soundscape` parameter before `outputModalities` in `ProjectsAgentsModelFactory.VoiceAgentDefinition`, affecting positional arguments.
- `VoiceAgentAvatarVideoCrop.BottomRight` and `VoiceAgentAvatarVideoCrop.TopLeft` types were changed from `IList<object>` to `IList<uint>`.
- `VoiceAgentAzureSemanticVadEnTurnDetection.IdleTimeoutMs` was renamed to `VoiceAgentAzureSemanticVadEnTurnDetection.IdleTimeout`.
- `VoiceAgentAzureSemanticVadMultilingualTurnDetection.IdleTimeoutMs` was renamed to `VoiceAgentAzureSemanticVadMultilingualTurnDetection.IdleTimeout`.
- `VoiceAgentAzureSemanticVadTurnDetection.IdleTimeoutMs` was renamed to `VoiceAgentAzureSemanticVadTurnDetection.IdleTimeout`.
- `VoiceAgentSubagent.InvokeTimeoutSeconds` was renamed to `VoiceAgentSubagent.InvokeTimeout`.
- `OtlpTelemetryEndpoint.Endpoint` type was changed from `string` to `System.Uri`.
- `VoiceAgentMcpTool.AllowedTools` and `MCPToolboxTool.AllowedTools`, along with their model-factory parameters, now use `OpenAI.Responses.McpToolFilter` instead of `BinaryData`. `MCPToolboxTool.AllowedTools` now requires the `AAIP002` experimental opt-in.
- `VoiceResult.Metadata` now uses `IDictionary<string, BinaryData>` instead of `OpenAI.InternalMetadataContainer`. The public `OpenAI.InternalMetadataContainer` type was removed.
- `BrowserAutomationPreviewToolboxTool` is deprecated and hidden from IntelliSense. Please use `BrowserAutomationToolboxTool` instead.
- `VoiceAgentSoundscapeSound` was converted from enumeration to structure allowing extensibility from the service side.
- The `VoiceAgentSoundscapeWorkingTrackConfig` property `DelayMs` was renamed to `Delay`.

## 3.0.0-beta.5 (2026-10-16)

### Breaking Changes
- Changed types of `VoiceAgentAvatarVideoCrop.BottomRight` and `TopLeft` from `IList<object>` to `IList<uint>`. Its constructor and `ProjectsAgentsModelFactory.VoiceAgentAvatarVideoCrop` now accept `IEnumerable<uint>` instead of `IEnumerable<object>`.

## 3.0.0-beta.4 (2026-10-12)

### Features Added
- Expanded Agent Optimization with cost estimation, a dedicated candidate-listing client, and new models for optimization configuration, evaluation sets, candidate mutations, results, token usage, and latency metrics.
- Added toolbox support for browser automation tool, and added external web access configuration for web-search toolbox tools.
- Added language and keyword metadata to voice telephony call records.
- Added support for starting an agent's initiated process from a memory snapshot.

### Breaking Changes
- Redesigned the Agent Optimization API and model hierarchy. Job creation now uses optimization model and configuration objects, job listings return `AgentOptimizationJob`, and the previous dataset input, job input, options, progress, and list-item models were removed.
- Renamed the Teams Phone Extension telephony APIs to Teams Phone Extensibility and renamed `MCPToolboxToolConnectorId` to `McpToolConnectorId`.
- Replaced voice response status, output modality, semantic VAD eagerness, and web-search context-size types with the corresponding shared OpenAI types.
- Moved `CallableToolAllowedCaller`, `VoiceAgentAudioInputConfigTranscriptionDelay`, `RealtimeFunctionToolParameters`, `ContainerSkill`, `InlineSkillParam`, `InlineSkillSourceParam`, and `SkillReferenceParam` from the `OpenAI` namespace to `Azure.AI.Projects.Agents`.

### Other Changes
- Agent Optimization no longer requires the `AAIP001` warning suppression or the `AgentsOptimization=V2Preview` feature opt-in.

### Sample Updates
- Updated the Agent Optimization samples for the redesigned job configuration and candidate APIs.

## 3.0.0-beta.3 (2026-09-16)

### Features Added
- Added the `BetaVoiceAgentsTelephony` client.
- Added the `BetaVoiceAgentsConversations` client.

## 3.0.0-beta.2 (2026-09-03)

### Other Changes
- No user-facing changes

## 3.0.0-beta.1 (2026-08-24)

### Features Added

- Added distributed tracing support.

### Breaking Changes

- The Agent optimization-related classes were renamed

| Old (2.x) | New (3.0.0-beta.1) |
| --- | --- |
| `OptimizationCandidate` | `AgentOptimizationCandidate` |
| `OptimizationDatasetCriterion` | `AgentOptimizationDatasetCriterion` |
| `OptimizationDatasetInput` | `AgentOptimizationDatasetInput` |
| `OptimizationDatasetItem` | `AgentOptimizationDatasetItem` |
| `OptimizationEvaluatorRef` | `AgentOptimizationEvaluatorRef` |
| `OptimizationInlineDatasetInput` | `AgentOptimizationInlineDatasetInput` |
| `OptimizationJob` | `AgentOptimizationJob` |
| `OptimizationJobInputs` | `AgentOptimizationJobInputs` |
| `OptimizationJobListItem` | `AgentOptimizationJobListItem` |
| `OptimizationJobProgress` | `AgentOptimizationJobProgress` |
| `OptimizationJobResult` | `AgentOptimizationJobResult` |
| `OptimizationOptions` | `AgentOptimizationOptions` |
| `OptimizationReferenceDatasetInput` | `AgentOptimizationReferenceDatasetInput` |
| `OptimizationAgentIdentifier` | `OptimizedAgentIdentifier` |

### Bugs Fixed
- Fixed listing of Agent Optimization Jobs.
- Fixed the `StopSession` and `StopSessionAsync` calls.

### Other Changes
- Updated the `OpenAI` package dependency to `2.12.0`.

### Sample Updates
- Added sample demonstrating disabling and enabling Hosted Agent.
- Added samples for Agent optimization jobs.
- Added sample for creating Agent version drafts.

## 2.1.0-beta.4 (2026-06-30)

### Breaking Changes

- Hosted Agents do not need the `Foundry-Features: HostedAgents=V1Preview` header and warning suppression anymore.
- The deployment of hosted Agent using code does not require the `Foundry-Features: CodeAgents=V1Preview` header and warning suppression anymore.
- Using toolboxes does not require the `Foundry-Features: Toolboxes=V1Preview` header and warning suppression anymore.

## 2.1.0-beta.3 (2026-05-29)

### Features Added

- Added client for Agent optimization Jobs.

### Breaking Changes

- `CreateSkillFromPackage` and `CreateSkillFromPackageAsync` methods of `ProjectAgentSkills` client were replaced by `CreateSkillVersionFromFiles` and `CreateSkillVersionFromFilesAsync` respectively.
- `DownloadSkill` and `DownloadSkillAsync`  methods of `ProjectAgentSkills` client were replaced by `GetSkillContent` and `GetSkillContentAsync` respectively.
- `UpdateSkill` and `UpdateSkillAsync`  methods of `ProjectAgentSkills` now can only set the default version of `AgentsSkill`.
- `OptimizationTaskResult.Tokens` was changed from `int` to `long`.

## 2.1.0-beta.2 (2026-05-14)

### Features Added
- Added `FabricIQPreviewTool`.
- Added `ToolboxSearchPreviewTool` for discovering deferred tools via `search_tools` queries at runtime.
- Added `WorkIQPreviewTool`.
- Added `Name` and `Description` properties to tool classes (`A2APreviewTool`, `AzureAISearchTool`, `BingCustomSearchPreviewTool`, `BingGroundingTool`, `BrowserAutomationPreviewTool`, `MemorySearchPreviewTool`, `MicrosoftFabricPreviewTool`, `SharepointPreviewTool`).

### Breaking Changes
- `AgentEndpoint` was renamed to `AgentEndpointConfiguration`.
- `TelemetryEndpointAuth` was renamed to `TelemetryEndpointAuthentication`.
- `TelemetryEndpoint` property `Auth` was renamed to `Authentication`.
- `TelemetryEndpoint` property `Data` was renamed to `ExportedDataTypes`.
- `isolationKey` was removed from `CreateSession` and `DeleteSession` operations.

## 2.1.0-beta.1 (2026-04-21)

### Features Added
- Added `AgentToolboxes` client, which can be retrieved using `GetAgentToolboxes` method of `AgentAdministrationClient`.
- In `AgentAdministrationClient` added CRUD operations for sessions on the hosted Agent.
- Added `AgentSessionFiles` client to work with the files in the session samdbox.
- Added `ProjectAgentSkills` to manage agent skills.
- Added `GetSessionLogStreamAsync` and `GetSessionLogStream` to get the logs from the hosted Agent docker container.

## 2.0.0 (2026-03-31)

### Breaking Changes
- `AgentVersion` was renamed to `ProjectsAgentVersion`.
- `AgentVersionCreationOptions` was renamed to `ProjectsAgentVersionCreationOptions`.
- `AgentDefinition` was renamed to `ProjectsAgentDefinition`.
- `AgentRecord` was renamed to `ProjectsAgentRecord`.
- `ProjectsAgentTool` was renamed to `ProjectsAgentTool`.
- `PromptAgentDefinition` was renamed to `DeclarativeAgentDefinition`.
- `AgentClient` was renamed to `AgentAdministrationClient`.
- `AgentClientOptions` were renamed to `AgentAdministrationClientOptions`.

## 2.0.0-beta.1 (2026-03-12)

### Features Added
This is the first release of the `Azure.AI.Projects.Agents`. It provides the administrative tools for working with Agents.
