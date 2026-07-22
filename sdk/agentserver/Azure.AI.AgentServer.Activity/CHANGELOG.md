# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

- Initial release of `Azure.AI.AgentServer.Activity` — a .NET library for hosting a Microsoft 365
  Agents SDK `AgentApplication` as an Azure AI Foundry hosted agent that speaks the **activity
  protocol** (`POST /activity/messages`).
- `ActivityServer.Run(...)` one-liner startup that wires Kestrel, health probes, OpenTelemetry, and
  the activity endpoint, with overloads for the way your agent is constructed:
  - `Run<TAgent>()` — host an `AgentApplication` subclass by type.
  - `Run(app => ...)` — register handlers inline on the built `AgentApplication` (no agent class).
  - `Run(agentApp)` — host a pre-built `AgentApplication` instance.
  - `Run(Func<IServiceProvider, AgentApplication>)` — factory registration with access to DI.
  - `Run(RequestDelegate)` — own the raw request pipeline (the Microsoft 365 Agents SDK is not
    initialized).
- Composition on the shared Core host builder via `AgentHostBuilder.AddActivity<TAgent>()`,
  `AddActivity(agentApp)`, and `AddActivity(Func<IServiceProvider, AgentApplication>)`.
- Self-hosting on your own `WebApplication` via `AddFoundryActivity()` / `MapFoundryActivity()`
  (aliased as `AddActivityServer()` / `MapActivityServer()`), including a `RequestDelegate` overload
  of `MapFoundryActivity` for owning the request pipeline in a self-hosted app. This is also the
  two-line conversion path for an existing Microsoft 365 Agents SDK application.
- `ActivityServerOptions` for configuring the built stack: outbound-auth model (`DigitalWorker`),
  turn-state `Storage`, the outbound `Connections` provider, the `CONNECTIONS__*`
  `ConnectionConfiguration` mapping, and a `ConfigureServices` hook.
- Foundry outbound-auth: the `FoundryConnections` managed-identity Bot Connector token provider for
  both the **simple** (agent-instance identity) and **digital worker** (blueprint identity + FMI
  token exchange) models; `ActivityEnvironment` derives the M365 connection settings from the
  Foundry-native identity without mutating the process environment.
- Session resolution (`agent_session_id` query / `x-agent-session-id` header / environment /
  generated), sanitized session-id response header, `x-platform-error-source` error classification
  (`user` / `platform` / `upstream`), and distributed tracing via `ActivityProtocolActivitySource`.
