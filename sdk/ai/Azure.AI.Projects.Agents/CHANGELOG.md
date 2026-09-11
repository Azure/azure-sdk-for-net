# Release History

## 3.0.0-beta.3 (Unreleased)

### Features Added

- Added outbound telephony call-job and campaign APIs, including scheduling, recipient import, and retry-policy models.
- Added `VoiceAgentEndConversationSystemTool` for configuring the typed service-managed end-conversation action.
- Added `ProjectsAgentRecord.ConfigurationState` and prompt-agent harness and skill-reference configuration.
- Added a `digitalWorkerType` parameter to `ProjectsAgentsModelFactory.ProjectsAgentRecord` for mocking the (preview) `DigitalWorkerType` value.
- Added `VoiceAgentDefinition.ConversationEngine` (typed `VoiceConversationEngine`, with `VoiceHostedAgentConversationEngine` as the initial implementation) for fronting a hosted text agent as a voice agent's conversational backend, as an alternative to a directly-configured model.
- Added `VoiceAgentDefinition.SubagentConfig` for configuring sibling Foundry text agents that a voice agent may consult as background specialists.
- Added `AgentAdministrationClient.GetAgentTelephony()` for retrieving the client that manages voice-agent telephony bindings and calls.
- Added preview support for creating voice agents and retrieving their persisted conversations, responses, items, metrics, and audio.
- Added preview real-time voice-agent sessions over WebSockets, including text and binary message exchange.
- Added `GenerateVoiceAgentRequest` for generating editable voice-agent definitions from authoring inputs.
- Added `A2ATool` and `A2AToolboxTool` for agent-to-agent integrations.
- Added preview `WebIQPreviewTool` and `WebIQPreviewToolboxTool` support.
- Added `SessionConfiguration` for configuring hosted-agent session defaults.
- Added `AgentEndpointConversations.GetAgentConversationItem(Async)` for retrieving a single persisted conversation item by id, including its transcript.
- Added `AgentEndpointConversations.GetAgentConversationItemGeneratedAudio(Async)` and `GetAgentConversationItemGeneratedAudioContent(Async)` for retrieving generated-audio metadata and content for a persisted conversation item.
- Added `ContentFilterConfiguration.InvocationsModeration` (typed `RaiInvocationModeration`) for declaring where user/agent text lives in agent-defined invocations request/response bodies, so content-safety guardrails can extract and moderate it.

### Breaking Changes

- Moved persisted response identifiers from `VoiceResponseBase` to `VoiceResponse`; use `VoiceResponse.Id` and `VoiceResponse.ConversationId` for stored response identity.
- Voice system-tool names are now discriminators. Use `VoiceAgentEndConversationSystemTool` for the end-conversation action instead of changing a tool's name.
- Removed the `model` parameter from the public `VoiceAgentDefinition(VoiceModelType, string)` constructor; use the new parameterless `VoiceAgentDefinition()` constructor and set the now-optional `ModelType`/`Model` properties instead (required together for a model-backed voice agent; omit both when using the new `ConversationEngine` property).
- Renamed voice-agent configuration models to the `VoiceAgent*` family (e.g. `VoiceAudioConfig` → `VoiceAgentAudioConfig`, `VoiceSystemTool` → `VoiceAgentSystemTool`, `VoiceTurnDetection` → `VoiceAgentTurnDetectionConfig`) and renamed `VoiceResponse`'s base contract members (e.g. `VoiceResponseOutputModality` → `VoiceResponseBaseOutputModality`).
- Removed the dedicated "message" conversation item models (`VoiceAssistantMessageItem`, `VoiceUserMessageItem`, `VoiceSystemMessageItem`, and the underlying `RealtimeConversationItemMessage*` types); persisted "message" items now round-trip through the `OpenAI.Realtime.RealtimeItem` base type instead of a dedicated typed model.
- Changed voice-agent audio format configuration to use the real `OpenAI.Realtime.RealtimeAudioFormat` family (`RealtimePcmAudioFormat`/`RealtimePcmaAudioFormat`/`RealtimePcmuAudioFormat`) instead of the locally-defined `VoiceAudioFormat`/`RealtimeAudioFormatsAudioPcm*` models. Because `RealtimePcmAudioFormat.Rate` is read-only, set it through `RealtimePcmAudioFormat.Patch` (e.g. `format.Patch.Set("$.rate"u8, 24000)`) instead of an object initializer.
- Persisted voice conversation item list operations and `VoiceResponse.Output` now return `BinaryData`.
- Concrete voice item models now inherit the corresponding OpenAI realtime models instead of `VoiceConversationItem`.
- Changed voice implementation values from strings to `VoiceType` and changed voice duration fields expressed in milliseconds to `TimeSpan`.
- Removed the fixed avatar video codec setting; the service now controls the codec.
- Renamed timestamp properties across several models for `*At` naming consistency: `AgentOptimizationJob.CreatedOn`/`UpdatedOn`, `AgentOptimizationJobListItem.CreatedOn`/`UpdatedOn`, `AgentsSkill.CreatedOn`, `ProjectAgentSession.CreatedOn`/`LastAccessedOn`/`ExpiresOn`, `PromotionInfo.PromotedOn`, `SessionDirectoryEntry.ModifiedOn`, `SkillVersion.CreatedOn`, and `ToolboxVersion.CreatedOn` are now `CreatedAt`, `UpdatedAt`, `LastAccessedAt`, `ExpiresAt`, `PromotedAt`, and `ModifiedAt` respectively.
- Renamed `VoiceAgentSubAgent`/`VoiceAgentSubAgentConfig` to `VoiceAgentSubagent`/`VoiceAgentSubagentConfig` for casing consistency.

### Bugs Fixed

- `VoiceAgentWebSocket` now also sends its SDK identifier as an `x-ms-client-sdk` connection-URL query parameter, so identification survives on platforms that disallow setting `User-Agent` on a WebSocket (e.g. .NET Framework) and through intermediaries that strip non-standard headers.
- Fixed `VoiceResponse.Id`, `VoiceResponse.ConversationId`, and `VoiceResponse.OutputModalities` to correctly reflect the deserialized values instead of always returning `null` or an empty collection.

### Other Changes

- Regenerated the SDK from the unified Foundry v1 Agents and voice data-plane contract at [`feature/foundry-release` commit `47e280efb204`](https://github.com/Azure/azure-rest-api-specs/commit/47e280efb204598c0253488a7538a08327c5548f).

### Sample Updates

- Added a sample demonstrating voice-agent creation, real-time interaction, and persisted conversation retrieval.
- Updated the voice sample to use Azure neural speech, change pitch during a session, capture the persisted conversation ID from `session.created`, and wait for persistence before reading transcripts and audio.
- Voice sample failures now surface service errors, incomplete responses, and premature session closure instead of appearing successful.
- Isolated the voice sample's resources and cleanup from the integration-test fixture so it does not delete unrelated project resources.
- Updated Agent Optimization samples to use the unified `AgentOptimization*` models.

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
