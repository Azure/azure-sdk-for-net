# Release History

## 1.0.0-beta.9 (2026-03-03)

### Other Changes

- Update Microsoft.Agents.AI, Microsoft.Agents.AI.Workflows, Microsoft.Agents.AI.OpenAI packages to 1.0.0-rc1

## 1.0.0-beta.8 (2026-02-11)

### Bugs Fixed

- Fixed Foundry conversation thread hydration to create agent-owned threads for `AIAgent` invocations, preventing "thread is not compatible with the agent" failures on `/responses`.
- Make conversationId Optional

## 1.0.0-beta.7 (2026-02-10)

### Features Added

- Added Foundry conversation history hydration via `FoundryConversationThreadRepository` and Core conversation items API integration.
- Added `RunAIAgentAsync` and `RunWorkflowAgentAsync` overloads accepting `TokenCredential` and optional project endpoint for Foundry-backed thread hydration.
- Enabled automatic Foundry-backed thread repository creation in existing run extension methods when `AZURE_AI_PROJECT_ENDPOINT` is configured.

## 1.0.0-beta.6 (2026-01-20)

### Features Added

- Added ChatClientBuilder.UseFoundryTools for Foundry tool discovery in chat pipelines.
- Added FoundryToolsChatClient to merge resolved tools into chat options.

## 1.0.0-beta.5 (2025-12-05)

### Features Added

- Add support for populating created_by on all ItemResource types in both streaming and non-streaming flows

### Bugs Fixed

- Fixed error response handling in stream and non-stream modes

## 1.0.0-beta.4 (2025-11-11)

### Bugs Fixed

- Id generation issue

## 1.0.0-beta.3 (2025-11-10)

### Features Added

- Fixed AgentId serialization
- Fixed NPE when usage data is missing

## 1.0.0-beta.2 (2025-11-10)

### Features Added

- Fixed minor bugs in the initial release

## 1.0.0-beta.1 (2025-11-07)

### Features Added

- Initial release
