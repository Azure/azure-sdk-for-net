# AGENTS.md — Azure.AI.AgentServer.Responses

> This file contains **protocol-specific** rules.
> For core principles, build commands, and governance, see the parent [AGENTS.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/AGENTS.md).

---

## 1. Contract Compliance (MANDATORY)

The Responses library has **authoritative contract documents** that define all required behaviour.

### Responses-specific spec documents

| Document | Location | Defines |
|----------|----------|---------|
| **API Behaviour Contract** | `/tmp/foundrysdk_specs/specs/hosted-agents/container-spec/docs/responses-api-behaviour-contract.md` | Observable HTTP behaviour, endpoint matrices, error shapes, SSE contract, behavioural rules (B1–B37) |
| **Library Behaviour Spec** | `/tmp/foundrysdk_specs/specs/hosted-agents/container-spec/docs/responses-library-behaviour-spec.md` | Language-agnostic library rules: handler contract, builder pattern, cancellation, streaming lifecycle |
| **Protocol Spec** | `/tmp/foundrysdk_specs/specs/hosted-agents/container-spec/docs/responses-protocol-spec.md` | Wire-level SSE format, distributed tracing, storage & persistence, content-type negotiation |

Cross-package specs (container image, package architecture, tools integration, handler guide) are in the parent [AGENTS.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/AGENTS.md) §1 "Authoritative spec documents".

### Compliance workflow

1. **Before implementing**: Read the relevant sections of the spec documents for the feature/endpoint being changed.
2. **Key rules to check**: Endpoint behaviour matrices (B1–B39), library processing rules, terminal event authority (S-018–S-022), cancellation categories (S-023–S-026), persistence timing (S-034–S-036).
3. **After implementing**: Audit the change against the contracts. Pay special attention to:
   - **B16**: Non-background in-flight responses are NOT findable (GET/DELETE/Cancel → 404).
   - **B2**: SSE replay requires `background=true` AND `stream=true` AND `store=true`.
   - **S-022**: The library MUST NOT emit `response.incomplete` (handler-driven only).
   - **S-036**: Non-background cancelled responses are ephemeral (not persisted).
   - **S-019**: Cancellation winddown — the library is sole authority on terminal event.
4. **Tests**: Any behavioural change MUST include protocol tests in `tests/Protocol/`. Unit tests alone are insufficient.
5. **If in doubt**: The spec wins over the code. Fix the code, not the spec.

## 2. Key Namespaces

- `Azure.AI.AgentServer.Responses` — public API surface
- `Azure.AI.AgentServer.Responses.Models` — model types (generated from TypeSpec)
- `Azure.AI.AgentServer.Responses.Internal` — internal implementation (e.g., `SeekableReplaySubject`)

## 3. Package Rules

### Dependency isolation

- **Responses** depends on **Core** (project reference), `System.ClientModel`, `Azure.Identity`, plus `Microsoft.AspNetCore.App` (framework reference).
- Test dependencies are managed via central package management (no per-package version overrides needed).

### ASP.NET target framework

`Responses` uses `$(RequiredRunnableTargetFrameworks)` (resolves to `net10.0;net8.0`) because it references `Microsoft.AspNetCore.App`. Standard `$(RequiredTargetFrameworks)` is used for Tests.

### Generated code suppressions

Analyzer suppressions for generated code are scoped to `Azure.AI.AgentServer.Responses/src/Generated/Directory.Build.props` — **not** in the root `Directory.Build.props`. Do not add blanket suppressions at higher levels.

### Generation pipeline

The TypeSpec generation pipeline is in `scripts/Generate-Contracts.ps1`:

1. `npx tsp-client sync` — fetch upstream TypeSpec sources
2. `npx tsp compile .` — compile TypeSpec → C# models + OpenAPI
3. Copy `Models/` and `Internal/` into `Contracts/src/Generated/`
4. `python3 generate-validators.py` — generate validators from OpenAPI spec
5. Clean intermediate `tsp-output/`

The Python validator generator (`scripts/generate-validators.py`) emits copyright-stamped C# files.

## 4. Testing Requirements

### E2E protocol tests

Any API behaviour change **must** include protocol tests in `tests/Protocol/`. These test the full HTTP pipeline via `TestWebApplicationFactory`. Unit tests alone are insufficient.

### Deterministic test synchronization

Never use blind `Task.Delay()` for async synchronization. Use `TaskCompletionSource`, `WaitAsync(TimeSpan)`, or polling loops with explicit timeout assertions. `Task.Delay` is acceptable only to simulate slow work in handlers.

### Model factory

`ResponsesModelFactory` provides static factory methods for constructing model types that have no public constructors, enabling consumer test scenarios.

## 5. TypeSpec Model Governance

### Azure TypeSpec is a superset of OpenAI TypeSpec

The Azure TypeSpec package (`@azure-tools/openai-typespec`) is **intentionally** a superset of the public OpenAI spec. It is natural and expected for Azure to support additional item types, extra properties, and Azure-specific extensions. Do **not** treat every Azure-only type as suspicious.

However, mistakes can occur at the Azure TypeSpec layer that introduce **unintended or incompatible** types. When a generated type produces unexpected discriminators, contradicts the spec description, or causes interop issues with the OpenAI .NET SDK, investigate whether it is an intentional Azure extension or an authoring mistake.

### OpenAI compat conflicts require user confirmation (MANDATORY)

**Any time a conflict or discrepancy is found between the Azure TypeSpec output and the OpenAI SDK/spec, the agent MUST stop and confirm the resolution approach with the user before making changes.** Do not assume the correct fix — it could be an intentional Azure extension, an upstream spec bug, a TypeSpec authoring mistake, or a combination. The user decides whether to internalize, patch, escalate, or accept the type.

This applies to: TypeSpec `client.tsp` changes, `@@access` modifications, discriminator overrides, type consolidations, and any service-layer adjustments that affect OpenAI interop.

### Dealing with unintended TypeSpec types

If investigation reveals an unintended type (not an intentional Azure extension), mark it `internal` via `@@access(... Access.internal)` in `client.tsp` so it does not leak into the public API. To verify, decompile the OpenAI .NET SDK (`ilspycmd`) and compare discriminator switches.

**Known case — `output_message` (authoring mistake, not an extension):**
The Azure TypeSpec model named `OutputMessage` auto-generated discriminator `"output_message"`, but both the OpenAI spec and SDK only recognize `"message"`. The YAML description even said "Always `message`" while the enum said `output_message` — a contradiction. These types were internalized:
- `OutputItemOutputMessage`, `OutputMessageContent`, `OutputMessageContentOutputTextContent`, `OutputMessageContentRefusalContent` (output side)
- `ItemOutputMessage` (input side)

### Internalizing types via `@@access`

Use `@@access(OpenAI.TypeName, Access.internal)` in `client.tsp` to mark generated types as internal. This follows the pattern established by the Foundry SDK in `TempTypeSpecFiles/Foundry/src/sdk-projects-openai/client.tsp`.

When internalizing a type, you must also:
- Create **bridge code** in internal helpers (e.g., `ItemConversion.cs`) to convert the internal type to its public equivalent.
- Ensure the generated deserializer still handles the wire discriminator (the type stays in the serialization switch, just becomes internal).

### Convenience constructors for handler UX

When a public model type requires a parameter that handlers always know (e.g., `MessageRole.Assistant` for output messages), add a **convenience constructor** via a custom partial class in `tsp-output/src/Custom/` that defaults the obvious parameter. This reduces boilerplate for handler developers.

Files in `tsp-output/src/Custom/` survive regeneration — the pipeline preserves this directory.

### Continuous learning

When the user corrects the agent or suggests a reusable pattern during a session, the agent must **propose documenting it** in the appropriate `AGENTS.md` at the end of the session — but **never update automatically**. Seek explicit user confirmation and clarification first. See parent `AGENTS.md` §8.1 for the full process.

### Generation pipeline (strict rule)

**Always run the full pipeline** via `scripts/Generate-Contracts.ps1`. Never run `tsp compile`, `npx tsp-client`, or other individual steps manually. The script handles the correct sequencing (sync → compile → copy → validate → clean) and ensures copyright headers are applied.

After regeneration, verify with `git diff --stat HEAD` that the output matches expectations.

## 6. ASP.NET Core Integration Pattern

Integration follows standard ASP.NET Core conventions:

- `IServiceCollection` extensions for registration: `AddResponsesServer()`
- `IEndpointRouteBuilder` extensions for routing: `MapResponsesServer()`
- The library owns protocol concerns (request/response models, routing, serialization, error shapes)
- The consumer owns business logic (tool implementations, agent behaviour via `ResponseHandler`)
