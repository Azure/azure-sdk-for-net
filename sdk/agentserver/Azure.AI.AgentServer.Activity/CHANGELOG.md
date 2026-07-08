# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

- Initial release of `Azure.AI.AgentServer.Activity` — a .NET library for building ASP.NET Core
  servers that implement the Azure AI **activity protocol** (`POST /activity/messages`) for
  Microsoft 365 / Teams hosted agents.
- `ActivityServer.Run<THandler>()` one-liner startup that wires Kestrel, health probes,
  OpenTelemetry, and the activity endpoint.
- Three handler-authoring styles:
  - Subclass `ActivityHandler` and override `OnMessageAsync` / `OnConversationUpdateAsync` /
    `OnInvokeAsync` / `OnUnhandledActivityAsync` / `OnErrorAsync`.
  - Lambda registration via `ActivityHandlerBuilder` (`OnMessage`, `OnActivity`, `OnError`, ...).
  - Factory registration via `Func<IServiceProvider, ActivityHandler>`.
- `ActivityContext` with `SendActivityAsync` reply delivery, `ExpectReplies` (synchronous)
  mode, forwarded client headers, query parameters, and platform isolation keys.
- `ProactiveMessenger` for sending messages to a conversation after the originating turn
  completes.
- Microsoft 365 Agents SDK bridge (`AgentApplication` hosting), `MsalAuthPatcher`, and the
  Foundry connections / token-exchange plumbing for both the **simple** and **digital worker**
  outbound-auth models.
- `x-platform-error-source` error classification (`user` / `platform` / `upstream`) and
  distributed tracing via `ActivityProtocolActivitySource`.
