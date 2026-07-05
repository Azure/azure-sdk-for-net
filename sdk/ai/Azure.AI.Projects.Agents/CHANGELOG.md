# Release History

## 2.1.0-beta.5 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
