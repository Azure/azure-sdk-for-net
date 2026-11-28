# Release History

## 3.1.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed
- Fixed `InvalidOperationException` ("No ModelReaderWriterTypeBuilder found") when serializing or deserializing properties typed as OpenAI string-valued structs: `VoiceResult.Status` and `OutputModalities` (which broke `BetaVoiceAgentsConversations.GetAgentConversationResponses` and `GetAgentConversationResponse`), `VoiceAgentSemanticVadTurnDetection.Eagerness`, `WebSearchToolboxTool.SearchContextSize`, `McpToolboxTool.ConnectorId`, and `ToolboxShellContainerAutoEnvironment.MemoryLimit`.

### Other Changes

## 3.0.0 (2026-11-12)

### Breaking Changes
- `AzureFunctionDefinitionFunction` was removed, please use the same class from `Azure.AI.Extensions.OpenAI`.
- Renamed `GenerateVoiceAgentRequest` to `GenerateVoiceAgentContent` and `UpdateToolboxRequest` to `UpdateToolboxContent`.
- Removed the `AgentCard(string, IEnumerable<AgentCardSkill>)` and `VersionSelector(IEnumerable<VersionSelectionRule>)` constructors. Use the parameterless constructors and set `Version`/`Skills` and `VersionSelectionRules` with initializers.
- `TelephonyTransferTarget` constructor no longer takes `name`; set the `Name` property instead.
- `AgentReference` class was removed, please use class `AgentReference` from `Azure.AI.Extensions.OpenAI` package.
- `MCPToolboxTool` was renamed to `McpToolboxTool`.
- `PSTNTelephonyTransferDestination` was renamed to `PstnTelephonyTransferDestination`.
- The order of `GetAgentVersionsAsync` and `GetAgentVersions` arguments was changed. Now it is `string agentName, bool? includeDrafts, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default`.
- The `DownloadAgentCode` and `DownloadAgentCodeAsync` methods of `AgentAdministrationClient` are now returning `ClientResult<BinaryData>` and `Task<ClientResult<BinaryData>>` respectively.
- The `Download` and `DownloadAsync` methods of `AgentSessionFiles` are now returning  returning `ClientResult<BinaryData>` and `Task<ClientResult<BinaryData>>` respectively.
- Renamed the following models and their `ProjectsAgentsModelFactory` methods:

  | Previous | Replacement |
  | --- | --- |
  | `AgentOptimizationCandidatePromotionInfo` | `AgentOptimizationCandidatePromotion` |
  | `HeaderTelemetryEndpointAuth` | `HeaderTelemetryEndpointAuthentication` |
  | `InlineSkillParam` | `InlineSkill` |
  | `InlineSkillSourceParam` | `InlineSkillSource` |
  | `SkillReference` | `AgentSkillReference` |
  | `SkillReferenceParam` | `SkillReference` |
  | `TelemetryConfig` | `TelemetryConfiguration` |
  | `VersionRefIndicator` | `VersionReferenceIndicator` |
  | `VoiceAgentAudioConfig` | `VoiceAgentAudioConfiguration` |
  | `VoiceAgentAudioInputConfig` | `VoiceAgentAudioInputConfiguration` |
  | `VoiceAgentAudioOutputConfig` | `VoiceAgentAudioOutputConfiguration` |
  | `VoiceAgentAvatarConfig` | `VoiceAgentAvatarConfiguration` |
  | `VoiceAgentAvatarVideoParams` | `VoiceAgentAvatarVideoParameters` |
  | `VoiceAgentGreetingConfig` | `VoiceAgentGreetingConfiguration` |
  | `VoiceAgentInterimResponseConfig` | `VoiceAgentInterimResponseConfiguration` |
  | `VoiceAgentLlmGeneratedGreetingConfig` | `VoiceAgentLlmGeneratedGreetingConfiguration` |
  | `VoiceAgentLlmInterimResponseConfig` | `VoiceAgentLlmInterimResponseConfiguration` |
  | `VoiceAgentPostCallConfig` | `VoiceAgentPostCallConfiguration` |
  | `VoiceAgentSoundscapeConfig` | `VoiceAgentSoundscapeConfiguration` |
  | `VoiceAgentSoundscapeSourceConfig` | `VoiceAgentSoundscapeSourceConfiguration` |
  | `VoiceAgentSoundscapeTrackConfig` | `VoiceAgentSoundscapeTrackConfiguration` |
  | `VoiceAgentSoundscapeWorkingTrackConfig` | `VoiceAgentSoundscapeWorkingTrackConfiguration` |
  | `VoiceAgentStaticInterimResponseConfig` | `VoiceAgentStaticInterimResponseConfiguration` |
  | `VoiceAgentSubagentConfig` | `VoiceAgentSubagentConfiguration` |
  | `VoiceAgentTemplateGreetingConfig` | `VoiceAgentTemplateGreetingConfiguration` |
  | `VoiceAgentTurnDetectionConfig` | `VoiceAgentTurnDetectionConfiguration` |

- `SkillReference` and `ProjectsAgentsModelFactory.SkillReference` now refer to the former `SkillReferenceParam` container skill. Use `AgentSkillReference` and `ProjectsAgentsModelFactory.AgentSkillReference` for the previous agent skill reference.
- Renamed the following properties and their corresponding model-factory parameters where present. Type names in the table reflect the renamed models above.

  | Type | Previous | Replacement |
  | --- | --- | --- |
  | `A2AToolboxTool`, `A2APreviewToolboxTool` | `BaseUrl` | `BaseUri` |
  | `TelephonyBinding`, `TelephonyBindingListItem` | `IncomingCallUrl` | `IncomingCallUri` |
  | `VoiceAgentAudioOutputConfiguration` | `CustomLexiconUrl`, `CustomTextNormalizationUrl` | `CustomLexiconUri`, `CustomTextNormalizationUri` |
  | `VoiceAgentAvatarVideoBackground` | `ImageUrl` | `ImageUri` |
  | `VoiceAgentMcpTool` | `ServerUrl` | `ServerUri` |
  | `TelephonyCallRecord`, `TelephonyCallSummary`, `VoiceAudioItem`, `VoiceGeneratedAudioItem`, `VoiceRecording` | `DurationMs` | `Duration` |
  | `VoiceAudioItem`, `VoiceGeneratedAudioItem` | `StartOffsetMs` | `StartOffset` |
  | `AgentOptimizationJob` | `RunDurationMs` | `RunDuration` |
  | `AgentOptimizationCandidateEvaluation`, `AgentOptimizationJobLatency` | `AvgLatencyMs` | `AvgLatency` |
  | `SessionConfiguration` | `IdleTimeoutSeconds` | `IdleTimeout` |
  | `VoiceAgentEndOfUtteranceDetection` | `TimeoutMs` | `Timeout` |
  | `VoiceAgentInterimResponseConfiguration` | `LatencyThresholdMs` | `LatencyThreshold` |
  | `FileSearchToolboxTool` | `MaxNumResults` | `MaxResultCount` |
  | `UserConversationSimulationConfiguration` | `DesiredNumTurns`, `MaxNumTurns` | `DesiredTurnCount`, `MaxTurnCount` |
  | `ToolboxPolicies` | `RaiConfig` | `ContentFilterConfiguration` |

- On `VoiceAgentServerVadTurnDetection`, `VoiceAgentAzureSemanticVadTurnDetection`, `VoiceAgentAzureSemanticVadEnTurnDetection`, and `VoiceAgentAzureSemanticVadMultilingualTurnDetection`, renamed `PrefixPaddingMs`, `SilenceDurationMs`, and `SpeechDurationMs` to `PrefixPadding`, `SilenceDuration`, and `SpeechDuration`. On `VoiceAgentServerVadTurnDetection`, `IdleTimeoutMs` was also renamed to `IdleTimeout`, and `IdleTimeout`, `PrefixPadding`, and `SilenceDuration` changed from `long?` to `TimeSpan?`. Convert millisecond values with `TimeSpan.FromMilliseconds`. The corresponding model-factory parameters changed as well.
- On those four turn-detection types and `VoiceAgentSemanticVadTurnDetection`, renamed `CreateResponse` and `InterruptResponse` to `CreateResponseEnabled` and `InterruptResponseEnabled`, including the corresponding model-factory parameters.
- `CallableToolAllowedCaller`, `VoiceAgentAudioInputConfigTranscriptionDelay`, `VoiceAgentAudioTimestampType`, `VoiceAgentEchoCancellationReferenceSource`, and `VoiceAgentSessionIncludeOption` changed from enums to extensible structs. Replace enum-specific casts and constant `switch` cases with comparisons against their static values.
- `AllowedCallers` is now get-only on `CodeInterpreterToolboxTool`, `McpToolboxTool`, and `VoiceAgentMcpTool`; add items to the collection instead of replacing it. The `ShellToolboxTool.AllowedCallers` setter was also removed.
- Renamed `AgentAdministrationClient.GetAgentOptimizationJobCandidatesClient` to `GetAgentOptimizationJobCandidates`.
- `AgentAdministrationClient.GetSessionLogStream` and `GetSessionLogStreamAsync` are now experimental and require the `AAIP001` diagnostic to be suppressed on supported target frameworks.
- Renamed the `internalMaxOutputTokens` named parameter of `ProjectsAgentsModelFactory.VoiceAgentDefinition` to `maxOutputTokens`.

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
