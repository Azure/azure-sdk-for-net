# AGENTS.md — Azure.AI.AgentServer.Activity

> This file contains **protocol-specific** rules for the activity protocol library.
> For core principles, build commands, and governance, see the parent [AGENTS.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/AGENTS.md)
> and the project constitution.

---

## 1. What this library is

`Azure.AI.AgentServer.Activity` hosts a Microsoft 365 Agents SDK `AgentApplication`
as an Azure AI Foundry **hosted agent** that speaks the **activity protocol**
(`POST /activity/messages`
and a `/readiness` probe).

The consumer owns an ordinary Microsoft 365 Agents SDK application (the
`AgentApplication` and its activity handlers). This library owns the Foundry-specific
hosting concerns **only**:

- the outbound-auth connection provider (`FoundryConnections`),
- the activity endpoint mapping and request handling,
- session and correlation-id resolution,
- error-source classification (platform vs. user-container faults),
- distributed tracing (`ActivityProtocolActivitySource`).

The library MUST NOT own agent business logic — that belongs to the consumer's
`AgentApplication`.

## 2. Contract compliance (MANDATORY)

The activity protocol has authoritative spec documents; the spec wins over the code.

### Activity-specific spec documents

| Document | Location | Defines |
|----------|----------|---------|
| **Activity Protocol Spec** | `foundry_specs/foundrysdk_specs/specs/hosted-agents/…` (activity protocol) | Wire endpoint (`/activity/messages`), readiness contract, inbound/outbound activity shapes, error envelope |
| **Container / hosting spec** | parent [AGENTS.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/AGENTS.md) §1 | Foundry-injected env vars, hosting-environment contract, agent-endpoint auth schemes |

### Compliance workflow

1. **Before implementing**: read the relevant spec sections for the endpoint / auth
   model being changed.
2. **Key rules to check**:
   - The `/readiness` probe returns 200 when the host is ready; inbound activity
     returns 202 on accepted delivery.
   - Outbound-auth model selection (simple vs. digital worker) MUST match the
     configured `ActivityServerOptions.DigitalWorker` and the resolved connection
     settings — never silently fall back.
   - Error-source classification (platform vs. user container) MUST be preserved on
     the response so the platform can attribute faults correctly.
3. **After implementing**: audit the change against the spec and the outbound-auth
   behaviour. Auth is the highest-risk area — see §5.
4. **Tests**: any change to endpoint logic, the error envelope, status codes,
   response headers, or the auth/connection model MUST include an E2E protocol test
   (see §4). Unit tests alone are insufficient.
5. **If in doubt**: the spec wins over the code. Fix the code, not the spec.

## 3. Key namespaces & public surface

- `Azure.AI.AgentServer.Activity` — the **entire** public API surface.
- `Azure.AI.AgentServer.Activity.Internal` — internal implementation
  (`FoundryConnections`, `ActivityEndpointHandler`, `ActivityErrorSourceFilter`,
  `ConnectionEnvironment`, session/correlation resolvers). MUST stay internal.

### Public surface is intentionally static / extension-based

The public surface is composed of `static` extension-method holders and
configuration POCOs, not instantiable service objects:

- Entry points: `ActivityServer` (`Run` overloads), `ActivityBuilderExtensions`
  (`AddActivity` overloads).
- DI + routing: `FoundryActivityHostingExtensions` (`AddFoundryActivity`),
  `FoundryActivityEndpointRouteBuilderExtensions` (`MapFoundryActivity` /
  `MapActivityServer`).
- Config: `ActivityServerOptions`, `ActivityEnvironment`.
- Tracing helper: `ActivityProtocolActivitySource` (the one instantiable public
  service; its methods are `virtual` for mockability per constitution VIII).

**Constitution VIII note:** the "protected parameterless constructor + all public
methods `virtual`" mandate applies only to instantiable public **service** types.
The static extension holders and POCOs are exempt by design. The only instantiable
public service, `ActivityProtocolActivitySource`, satisfies VIII (virtual methods).
Any *new* instantiable public service type MUST add the protected ctor + virtual
methods.

## 4. Testing requirements

### E2E sample tests (constitution XIII — MANDATORY)

Every shipped sample (`samples/Sample*.md`, surfaced as `tests/Snippets/Sample*Snippets.cs`)
MUST have a matching **end-to-end** test in `tests/SampleEndToEndTests.cs` that drives
the sample handler through the real ASP.NET Core pipeline (via a
`WebApplicationFactory` / test host), not just a compile-only snippet test.

- Compile-only snippet tests (`Sample*Snippets.cs`) satisfy the docs-driven snippet
  rule (constitution XI) but are **not** a substitute for an E2E test (XIII).
- Non-live samples (echo, welcome/commands, custom request handler, injected app,
  hosting-customization) MUST have an **in-process** E2E test that runs in CI.

### Live-test isolation (constitution XIII)

Samples that need a real Foundry backend, real credentials, or a live LLM
(e.g. the digital-worker sample, any Groot-style LLM sample) MUST:

- be marked live (`[LiveOnly]` / `TestCategory == "Live"`) so the CI default
  `--filter TestCategory!=Live` skips them;
- be **runnable locally** using the developer's own credentials and a user-supplied
  Foundry project/endpoint, configured via **environment variables** (never
  hard-coded);
- **fail with a clear, actionable message** when required configuration is absent —
  never silently pass.

CI MUST stay green without any live dependency.

### Deterministic synchronization (constitution IV)

Never use blind `Task.Delay()` to wait for async state. Use `TaskCompletionSource`,
`WaitAsync(TimeSpan)`, or polling loops with explicit timeout assertions.
`Task.Delay` is acceptable only to simulate slow work inside a handler.

## 5. Outbound authentication (highest-risk area)

The outbound-auth / connection model (`FoundryConnections`, `ConnectionEnvironment`,
`ActivityEnvironment`) is the most delicate part of this library. Rules:

- **Never log credentials, tokens, keys, or PII** (constitution IX). Client/tenant
  ids logged for diagnostics MUST be truncated (the existing 8-char + `...` pattern).
- The two auth models (simple Bot Connector token vs. digital-worker federated
  exchange) MUST be selected purely from configuration; there MUST be no silent
  fallback that changes the identity the agent replies as.
- Any change to the connection/auth flow MUST be accompanied by an E2E test and,
  where a real token exchange is involved, a `[LiveOnly]` test.
- Auth behaviour is defined by the platform contract, not by convenience. If the
  M365 Agents SDK provides a native mechanism (e.g. `FederatedCredentials`), prefer
  it over patching SDK internals; do not reintroduce monkey-patches without an
  explicit, documented decision.

## 6. ASP.NET Core integration pattern

Integration follows standard ASP.NET Core conventions:

- `IServiceCollection` extension for registration: `AddFoundryActivity()`.
- `IEndpointRouteBuilder` extension for routing: `MapFoundryActivity()` /
  `MapActivityServer()`.
- Host-builder convenience: `builder.AddActivity(...)` and the `ActivityServer.Run`
  overloads.
- The library owns protocol concerns (endpoints, error shape, connection provider,
  tracing); the consumer owns agent behaviour via their `AgentApplication`.

## 7. Build hygiene notes

- `<DisableEnhancedAnalysis>true</DisableEnhancedAnalysis>` in the src `.csproj` and
  the `HideTransitiveAzureIdentity` MSBuild target (extern-aliasing `Azure.Identity`
  to avoid the `Azure.Core` CS0433 ambiguity) are **deliberate** workarounds. They
  MUST NOT be removed or changed without understanding the credential-type ambiguity
  they resolve, and any change requires re-verifying a clean `dotnet build`. Prefer a
  central-package-management solution if one becomes available; record architect
  sign-off here if the workaround is retained.
- No blanket `<NoWarn>` in the production `.csproj`. The tests project may suppress
  `CS1591` (missing XML docs on test members) only.

## 8. Continuous learning

When the user corrects the agent or establishes a reusable pattern during a session,
the agent MUST **propose** documenting it here at the end of the session — but MUST
NOT update this file automatically. Seek explicit user confirmation first. See the
parent `AGENTS.md` for the full process.
