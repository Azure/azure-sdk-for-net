# Release History

## 3.0.0-beta.2 (Unreleased)

### Features Added

- Added a `digitalWorkerType` parameter to `ProjectsAgentsModelFactory.ProjectsAgentRecord` for mocking the (preview) `DigitalWorkerType` value.
- Added `VoiceAgentDefinition.ConversationEngine` (typed `VoiceConversationEngine`, with `VoiceHostedAgentConversationEngine` as the initial implementation) for fronting a hosted text agent as a voice agent's conversational backend, as an alternative to a directly-configured model.
- Added `VoiceAgentDefinition.SubagentConfig` for configuring sibling Foundry text agents that a voice agent may consult as background specialists.

### Breaking Changes

- Removed the `model` parameter from the public `VoiceAgentDefinition(VoiceModelType, string)` constructor; use the new parameterless `VoiceAgentDefinition()` constructor and set the now-optional `ModelType`/`Model` properties instead (required together for a model-backed voice agent; omit both when using the new `ConversationEngine` property).

### Bugs Fixed

### Other Changes

## 3.0.0-beta.1 (2026-08-24)

### Features Added

- Added distributed tracing support.
- Added preview support for creating voice agents and retrieving their persisted conversations, responses, items, metrics, and audio.
- Added preview real-time voice-agent sessions over WebSockets, including text and binary message exchange.
- Added `GenerateVoiceAgentRequest` for generating editable voice-agent definitions from authoring inputs.
- Added `A2ATool` and `A2AToolboxTool` for agent-to-agent integrations.
- Added preview `WebIQPreviewTool` and `WebIQPreviewToolboxTool` support.
- Added `SessionConfiguration` for configuring hosted-agent session defaults.

### Breaking Changes

- Renamed voice-agent configuration models to the `VoiceAgent*` family (e.g. `VoiceAudioConfig` → `VoiceAgentAudioConfig`, `VoiceSystemTool` → `VoiceAgentSystemTool`, `VoiceTurnDetection` → `VoiceAgentTurnDetectionConfig`) and renamed `VoiceResponse`'s base contract members (e.g. `VoiceResponseOutputModality` → `VoiceResponseBaseOutputModality`).
- Removed the dedicated "message" conversation item models (`VoiceAssistantMessageItem`, `VoiceUserMessageItem`, `VoiceSystemMessageItem`, and the underlying `RealtimeConversationItemMessage*` types); persisted "message" items now round-trip through the `RealtimeConversationItem` base type instead of a dedicated typed model.
- Changed voice-agent audio format configuration to use the shared `RealtimeAudioFormatsAudioPcm`/`RealtimeAudioFormatsAudioPcma`/`RealtimeAudioFormatsAudioPcmu` models instead of `VoiceAudioFormat`.
- Renamed Agent Optimization models to the `AgentOptimization*` family and renamed `OptimizationAgentIdentifier` to `OptimizedAgentIdentifier`.
- Agent Optimization list operations now return complete `AgentOptimizationJob` models instead of `OptimizationJobListItem` models.
- Persisted voice conversation item list operations and `VoiceResponse.Output` now return `BinaryData`.
- Concrete voice item models now inherit the corresponding OpenAI realtime models instead of `VoiceConversationItem`.
- Changed voice implementation values from strings to `VoiceType` and changed voice duration fields expressed in milliseconds to `TimeSpan`.
- Removed the fixed avatar video codec setting; the service now controls the codec.
- Renamed timestamp properties across several models for `*At` naming consistency: `AgentOptimizationJob.CreatedOn`/`UpdatedOn`, `AgentOptimizationJobListItem.CreatedOn`/`UpdatedOn`, `AgentsSkill.CreatedOn`, `ProjectAgentSession.CreatedOn`/`LastAccessedOn`/`ExpiresOn`, `PromotionInfo.PromotedOn`, `SessionDirectoryEntry.ModifiedOn`, `SkillVersion.CreatedOn`, and `ToolboxVersion.CreatedOn` are now `CreatedAt`, `UpdatedAt`, `LastAccessedAt`, `ExpiresAt`, `PromotedAt`, and `ModifiedAt` respectively.

### Bugs Fixed

- Fixed listing of Agent Optimization Jobs.
- Fixed the `StopSession` and `StopSessionAsync` calls.
- Fixed `VoiceResponse.Id`, `VoiceResponse.ConversationId`, and `VoiceResponse.OutputModalities` to correctly reflect the deserialized values instead of always returning `null` or an empty collection.

### Other Changes
- Updated the `OpenAI` package dependency to `2.12.0`.

- Regenerated the SDK from the unified Foundry v1 Agents and voice data-plane contract.

### Sample Updates

- Added sample demonstrating disabling and enabling Hosted Agent.
- Added samples for Agent optimization jobs.
- Added sample for creating Agent version drafts.
- Added a sample demonstrating voice-agent creation, real-time interaction, and persisted conversation retrieval.
- Updated Agent Optimization samples to use the unified `AgentOptimization*` models.

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
- Added `AgentSessionFiles` client to work with the files in the session sandbox.
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
