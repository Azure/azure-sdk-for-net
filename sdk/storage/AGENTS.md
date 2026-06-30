# AGENTS.md - Azure Storage SDK (.NET)

## Purpose

This file defines the operating contract for AI agents (Copilot, automation tools, and code generation agents) working in Azure Storage SDK code under `sdk/storage`.

This guidance complements `/.editorconfig`, `/AGENTS.md`, and `/.github/copilot-instructions.md`.
Read `/sdk/storage/CONTRIBUTING.md` for testing setup and code generation details.

## Core Principles

Agents MUST:
- Follow Azure SDK design guidelines and existing Storage SDK patterns.
- Preserve API consistency across Blobs, Queues, Files, DataLake, and DataMovement.
- Keep diffs minimal and focused.
- Prefer existing patterns over introducing new abstractions.

Agents MUST NOT:
- Introduce breaking API changes without explicit instruction.
- Modify generated protocol code directly.
- Bypass Azure Core pipeline behavior.
- Invent new architectural layers when existing ones already solve the problem.

## Repository Structure and Navigation

Primary areas:
- `sdk/storage/Azure.Storage.*` for service-specific libraries.
- `sdk/storage/Azure.Storage.*/tests/` for unit, integration, and recorded tests.
- Generated REST clients and protocol mappings from TypeSpec/Swagger.

Navigation guidance:
- Start with public client classes (`*Client`, `*ContainerClient`, and similar).
- Follow flow from public APIs -> internal helpers -> protocol layer.
- Avoid scanning unrelated repository areas.

## Architecture and SDK Patterns

### Layering

Maintain this layering:
1. Public client API.
2. Convenience SDK logic.
3. Generated REST clients.
4. Azure Core pipeline (`HttpPipeline`, policies).

Do not bypass layers.

### Azure Core Pipeline (Critical)

- All network calls go through the Azure Core pipeline.
- Retry, auth, logging, and diagnostics are centralized policies.
- Do not implement custom retry/auth behavior unless explicitly requested.

### Async Model

- Public operations should support async (`Task`, `AsyncPageable<T>`).
- Sync APIs should be wrappers over shared internal implementation.
- Do not introduce sync-over-async deadlock-prone behavior.

### Client Classes

- Include a protected parameterless constructor for mocking (`protected BlobClient() { }`).
- Keep constructor overload order consistent:
  - Connection string.
  - `Uri`.
  - `Uri` + `StorageSharedKeyCredential`.
  - `Uri` + `AzureSasCredential`.
  - `Uri` + `TokenCredential`.
  - Each with optional `*Options` parameter when applicable.
- Keep public methods and properties `virtual` for testability.
- Organize methods with clear `#region` groupings (for example, `#region ctors`, `#region Upload`).

### Sync and Async Pair Pattern

Every public operation should expose both sync and async variants with a shared internal path:

```csharp
public virtual Response<BlobInfo> Create(..., CancellationToken cancellationToken = default) =>
    CreateInternal(..., async: false, cancellationToken).EnsureCompleted();

public virtual async Task<Response<BlobInfo>> CreateAsync(..., CancellationToken cancellationToken = default) =>
    await CreateInternal(..., async: true, cancellationToken).ConfigureAwait(false);
```

Rules:
- Internal implementation takes `bool async`.
- `CancellationToken cancellationToken = default` is last.

### Models

- Response models: `internal` constructors and `internal set` properties.
- Test model creation should use `*ModelFactory`.
- Options models: public constructor and settable properties.
- Use nullable types for optional values (for example, `long?`).
- Prefer null-coalescing assignment for defaults (for example, `options ??= new BlobClientOptions()`).

### Pagination

- Use `AsyncPageable<T>` and `Pageable<T>`.
- Preserve lazy page retrieval; do not eagerly materialize large results.

### Error Handling

- Use `RequestFailedException` consistently.
- Preserve HTTP status codes and service error codes.
- Do not swallow, over-wrap, or transform errors unnecessarily.

#### No Magic Exceptions

Every newly introduced thrown exception must be defined through the appropriate error catalog helper, not as an ad-hoc inline throw.

- If the throw is client-side validation or argument usage, add/update an entry in `Errors.Client.cs`.
- If the throw maps to service/protocol error behavior, add/update an entry in `Error.cs`.
- If the throw is in DataMovement components, add/update an entry in `DataMovementErrors.cs`.
- Prefer helper-based throws (for example, `throw ErrorsClient.InvalidArgument(...)`) over raw string messages.

Before merging, verify:
- No new `throw new ...("literal message")` was added where an existing error helper should be used.
- New helper messages are consistent with existing phrasing and parameter naming.
- Tests assert expected exception type and (when appropriate) message/parameter name.

### Storage Service Semantics

Do not assume uniform behavior across services.

- Blob specifics:
  - AppendBlob is not overwrite-safe.
  - BlockBlob upload flow includes commit semantics.
- Queue specifics:
  - Visibility timeout drives message lifecycle behavior.
- File share specifics:
  - Hierarchical directory semantics differ from blobs.

### Concurrency and Conditions

Use built-in conditional headers:
- ETag (`If-Match`, `If-None-Match`).
- Last-Modified (`If-Modified-Since`).

Do not implement custom concurrency control that bypasses service semantics.

## C# Coding Conventions

- Use explicit type names rather than `var` when type is not trivially obvious.
- Private fields use `_camelCase`.
- Static fields use `s_camelCase`.
- Constants use `PascalCase`.
- Use Allman braces for all constructs.
- Place `using` statements outside namespace and sort as:
  1. `System.*`
  2. `Azure.*`
  3. Other namespaces
  4. Type aliases last
- Avoid `this.` qualifier unless required for disambiguation.
- Apply modifier ordering:
  `public`, `private`, `protected`, `internal`, `static`, `extern`, `new`, `virtual`, `abstract`, `sealed`, `override`, `readonly`, `unsafe`, `volatile`, `async`.
- Insert logical blank lines between method-body sections.
- For parameter lists longer than 3, place one parameter per line.

Example `using` ordering:

```csharp
using System;
using System.Threading;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
```

## Documentation Conventions

- Add XML docs on all public members (`<summary>`, `<param>`, `<returns>`, `<remarks>`, `<see cref="..."/>`).
- Apply `[EditorBrowsable(EditorBrowsableState.Never)]` to object overrides (`ToString`, `Equals`, `GetHashCode`) where appropriate.

## Generated Code Rules

Generated code is read-only.

- Never edit files under `Generated/` directly.
- Regenerate with per-package `dotnet build /t:GenerateCode` (see package `src/autorest.md`).
- Put customizations in separate files outside generated folders (for example, partial classes and convenience layers).

## Shared Source

Common utilities live under `Azure.Storage.Common/src/Shared/` and are compiled into each library via MSBuild `LinkBase`; these are not project references.

## Testing Conventions

### Framework and Base Classes

- Use NUnit 3 with Azure.Core.TestFramework.
- Inherit from library-specific base test classes (for example, `BlobTestBase`), which chain through `StorageTestBase<TEnvironment>` to `RecordedTestBase<TEnvironment>`.
- Apply the library fixture attribute (for example, `[BlobsClientTestFixture]`) to parameterize by service version.
- Standard constructor shape:

```csharp
public MyTests(bool async, ServiceVersion version) : base(async, version, null)
```

### Test Attributes

- `[RecordedTest]` for HTTP recording/playback tests.
- `[LiveOnly(Reason = "...")]` for tests that cannot be recorded.
- `[Test]` for pure unit tests with no service calls.

### Naming

Use `MethodName_Scenario()` or `MethodName_Scenario_Expected()`.

Examples:

```csharp
CreateAsync_WithMetadata()
Upload_InvalidRequestConditions(string invalidCondition)
Ctor_ConnectionString()
```

### Key Test Patterns

- Use `Recording.Random` for deterministic playback-safe randomness.
- Clean up resources with patterns like:

```csharp
await using DisposingContainer test = await GetTestContainerAsync();
```

- Use NUnit `Assert.*` and established helper utilities (`TestHelper`).
- Author tests with async APIs; sync variants are generated through instrumentation (`InstrumentClient`).
- Prefer recorded/live service tests over mocks for service behavior validation.

### Test Quality Requirements

Agents MUST:
- Add or update tests for functional changes.
- Use existing test helpers and framework patterns.

Agents MUST NOT:
- Introduce flaky or environment-dependent tests.

## Build and Workflow

```bash
# Build storage libraries
dotnet build

# Run tests (skip live tests)
dotnet test --filter TestCategory!=Live

# Run tests for a single framework
dotnet test -f net10.0

# Regenerate REST clients from swagger (run from package src/)
dotnet build /t:GenerateCode

# Export public API after changes (from repo root)
eng/scripts/Export-API.ps1 storage

# Update documentation snippets (from repo root)
eng/scripts/Update-Snippets.ps1 storage
```

### API Surface Files

Public API baselines are tracked in `api/*.netstandard2.0.cs` (and other TFMs).
These are generated artifacts; update via `eng/scripts/Export-API.ps1 storage` rather than manual edits.

### CHANGELOG Format

```markdown
## X.Y.Z (YYYY-MM-DD)
### Features Added
### Breaking Changes
### Bugs Fixed
### Other Changes
```

## Restricted Areas and Safety

Agents MUST NOT:
- Modify CI/CD pipelines unless explicitly requested.
- Change authentication, retry, or idempotency semantics without explicit review.
- Commit secrets, credentials, or sensitive tokens.
- Introduce silent data corruption risks.

## Change and PR Expectations

All agent-generated changes should:
- Stay minimal and scoped.
- Align with existing SDK patterns.
- Include or update relevant tests.
- Preserve public API stability unless a breaking change is explicitly requested.

## Decision Guidance

When uncertain:
1. Follow existing implementation patterns in the same library area.
2. Prefer correctness over optimization.
3. Avoid speculative changes.
4. Ask for clarification instead of guessing.

## Summary

Priorities:
- Consistency across Azure SDKs.
- Correct Storage service semantics.
- Stable public APIs.
- Safe, predictable, minimal changes.
