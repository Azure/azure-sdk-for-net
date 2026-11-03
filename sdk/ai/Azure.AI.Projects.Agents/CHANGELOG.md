# Release History

## 3.0.0-beta.6 (Unreleased)

### Features Added
- Added experimental Live voice agent definitions, native client/server event models, and `BetaVoiceAgentsLiveConversations` for stored Live history and recordings.
- Added Foundry-aware Live session snapshots and delegation trigger metadata, including `foundry_managed_agent` ownership with the pinned agent name and resolved version.
- Live definitions preserve typed Realtime/Live dispatch and existing Realtime model-factory parameter order. Stored Live history pagination honors `has_more` even when a terminal page retains `last_id`.
- Enriched existing Foundry GenAI agent-creation traces with privacy-safe Voice Agent metadata and bounded instruction content under the existing opt-in setting. Other Voice Agent REST operations retain their existing SDK diagnostics.
- Added experimental soundscape configuration for voice-agent telephony calls. Soundscapes are not rendered over direct WebSocket or browser WebRTC connections.

### Breaking Changes
- Live lifecycle events now expose `VoiceAgentLiveSessionResource`, and delegation-created events expose `VoiceAgentLiveDelegationItem` with `VoiceAgentLiveDelegationTarget`, replacing the corresponding native-only snapshot and trigger types.
- Renamed the experimental `LiveTransportRinging`, `LiveTransportAnswered`, and `LiveTransportFailed` models to `LiveServerEventLiveTransportRinging`, `LiveServerEventLiveTransportAnswered`, and `LiveServerEventLiveTransportFailed`. Their wire event names are unchanged.
- `VoiceAgentAvatarVideoCrop.BottomRight` and `VoiceAgentAvatarVideoCrop.TopLeft` types were changed from `IList<object>` to `IList<uint>`.
- `VoiceAgentAzureSemanticVadEnTurnDetection.IdleTimeoutMs` was renamed to `VoiceAgentAzureSemanticVadEnTurnDetection.IdleTimeout`.
- `VoiceAgentAzureSemanticVadMultilingualTurnDetection.IdleTimeoutMs` was renamed to `VoiceAgentAzureSemanticVadMultilingualTurnDetection.IdleTimeout`.
- `VoiceAgentAzureSemanticVadTurnDetection.IdleTimeoutMs` was renamed to `VoiceAgentAzureSemanticVadTurnDetection.IdleTimeout`.
- `VoiceAgentSubagent.InvokeTimeoutSeconds` was renamed to `VoiceAgentSubagent.InvokeTimeout`.
- `OtlpTelemetryEndpoint.Endpoint` type was changed from `string` to `System.Uri`.
- `VoiceAgentMcpTool.AllowedTools` and `MCPToolboxTool.AllowedTools`, along with their model-factory parameters, now use `OpenAI.Responses.McpToolFilter` instead of `BinaryData`. `MCPToolboxTool.AllowedTools` now requires the `AAIP002` experimental opt-in.
- `VoiceResult.Metadata` now uses `IDictionary<string, BinaryData>` instead of `OpenAI.InternalMetadataContainer`. The public `OpenAI.InternalMetadataContainer` type was removed.
- `BrowserAutomationPreviewToolboxTool` is deprecated and hidden from IntelliSense. Please use `BrowserAutomationToolboxTool` instead.

### Bugs Fixed
- Fixed typed persisted Realtime response status and output-modality serialization to use the external OpenAI enum values rather than treating them as ModelReaderWriter models.
- Fixed semantic VAD eagerness serialization and deserialization to preserve the external OpenAI string values.
- Fixed the Realtime model factory to preserve newly added fields, including `Soundscape`, without changing the order of its existing parameters.
- Kept Live-only decision helper models and their model-factory methods behind the `AAIP001` experimental opt-in without changing shared stable models.

### Other Changes
- Regenerated from the latest Foundry definitions in [Azure/azure-rest-api-specs#47196](https://github.com/Azure/azure-rest-api-specs/pull/47196), using OpenAI TypeSpec 1.32.0.

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
