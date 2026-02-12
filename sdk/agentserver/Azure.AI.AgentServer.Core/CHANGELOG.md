# Release History

## 1.0.0-beta.8 (2026-02-11)

### Bugs Fixed

- Make conversationId Optional

## 1.0.0-beta.7 (2026-02-10)

### Features Added

- Added `FoundryProjectEndpointResolver` for centralized `AZURE_AI_PROJECT_ENDPOINT` resolution across hosting integrations.
- Added `ConversationItemsClient` in `Responses.Conversations` for retrieving Foundry conversation items used by hydration adapters.

## 1.0.0-beta.6 (2026-01-20)

### Features Added

- Added AgentRunContext with request, user info, and tool metadata.
- Batched Foundry tool detail resolution with cached details.

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
