# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

- Initial release of `Azure.AI.AgentServer.A2A`, a .NET library for hosting native
  A2A v1.0 applications as Microsoft Foundry hosted agents.
- Added `A2AAgentServer.Run<THandler>()` and `Run(card, requestHandler)` for
  starting a server with Core hosting, readiness, telemetry, and graceful shutdown.
- Added `AgentHostBuilder.AddA2A<THandler>()` and `AddA2A(card, requestHandler)`
  for configuring a native agent on the Core host.
- Added `AddFoundryA2A()` and `MapFoundryA2A()` for integrating native A2A services
  with an existing ASP.NET Core application.
- Added JSON-RPC handling at `/a2a` and public Agent Card discovery at
  `/a2a/.well-known/agent-card.json`.
- Added `FoundryTaskStore` for persisting native task snapshots through Core's
  state store. Explicitly registered task stores and existing request handlers
  retain their storage configuration.
- Added request-scoped Foundry context, server-version identification, and
  semantic tracing for A2A operations and hosted agent invocations.

### Bugs Fixed

- Hosted task storage now uses `DefaultAzureCredential` when no credential is
  supplied, restricted by default to environment, workload identity, and managed
  identity. Explicit credentials take precedence, and `AZURE_TOKEN_CREDENTIALS`
  can select a credential source.
- Unexpected native dispatch failures retain their original exception in logs.
- Method-not-allowed responses on A2A routes include error-source classification.
- Request observation uses memory buffering without requiring temporary files.
- Task listing reads lightweight summaries and hydrates only the selected page
  of full snapshots, retaining support for records without listing summaries.
- Task listing filters caller metadata before reading snapshots without sending
  unsupported hyphenated tag filters to hosted storage.
