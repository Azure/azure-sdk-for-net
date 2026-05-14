# Azure Storage SDK — Coding Conventions

> Complements the repo-level `/.editorconfig`, `/AGENTS.md`, and `/.github/copilot-instructions.md`.
> Read `/sdk/storage/CONTRIBUTING.md` for testing setup and code generation details.

## C# Style

- **Explicit types** — use explicit type names, not `var` (e.g., `BlobClient client = ...` not `var client = ...`)
- **Private fields** — `_camelCase` (e.g., `private readonly Uri _uri`)
- **Static fields** — `s_camelCase` (e.g., `private static int s_count`)
- **Constants** — `PascalCase` (e.g., `private const int MaxRetries = 3`)
- **Braces** — Allman style: opening brace on its own line for all constructs
- **Usings** — outside namespace, sorted: `System.*` first, then `Azure.*`, then others. Type aliases last:
  ```csharp
  using System;
  using System.Threading;
  using Azure.Core;
  using Azure.Storage.Blobs.Models;
  using Metadata = System.Collections.Generic.IDictionary<string, string>;
  ```
- **No `this.`** — avoid `this.` qualifier on fields, properties, and methods
- **Modifier order** — `public`, `private`, `protected`, `internal`, `static`, `extern`, `new`, `virtual`, `abstract`, `sealed`, `override`, `readonly`, `unsafe`, `volatile`, `async`
- **Logical blank lines** — add blank lines between logical sections within method bodies
- **Long parameter lists** — when a method has more than 3 parameters, put each on its own line

## Azure SDK Patterns

### Client classes
- Protected parameterless constructor for mocking: `protected BlobClient() { }`
- Constructor overloads in order: connection string, `Uri`, `Uri` + `StorageSharedKeyCredential`, `Uri` + `AzureSasCredential`, `Uri` + `TokenCredential` — each with optional `*Options` parameter
- Public methods and properties are `virtual` for testability
- Organize methods with `#region` directives (e.g., `#region ctors`, `#region Upload`)

### Sync/async pairs
Every public operation exposes both sync and async variants. The implementation pattern:
```csharp
public virtual Response<BlobInfo> Create(..., CancellationToken cancellationToken = default) =>
    CreateInternal(..., async: false, cancellationToken).EnsureCompleted();

public virtual async Task<Response<BlobInfo>> CreateAsync(..., CancellationToken cancellationToken = default) =>
    await CreateInternal(..., async: true, cancellationToken).ConfigureAwait(false);
```
- Internal method takes `bool async` parameter
- `CancellationToken` is always the last parameter, named `cancellationToken`, default `= default`

### Models
- **Response models** — `internal` constructor, properties with `internal set`. Users create test instances via `*ModelFactory`
- **Options models** — public constructor, all properties settable
- **Nullable** — use `?` for optional properties (e.g., `public long? ContentLength { get; internal set; }`)
- **Null-coalescing** — prefer `options ??= new BlobClientOptions()` pattern

### Documentation
- XML docs on all public members: `<summary>`, `<param>`, `<returns>`, `<remarks>`, `<see cref="..."/>`
- `[EditorBrowsable(EditorBrowsableState.Never)]` on `object` overrides (ToString, Equals, GetHashCode)

### Generated code
- **Never** edit files in `Generated/` folders directly
- Regenerate code using the per-package `dotnet build /t:GenerateCode` workflow documented in `src/autorest.md`
- Customizations go in separate files outside `Generated/`

### Shared source
Common utilities live in `Azure.Storage.Common/src/Shared/` and are compiled into each library via MSBuild `LinkBase` — they are not project references.

## Testing Conventions

### Framework and structure
- **NUnit 3** with **Azure.Core.TestFramework**
- Tests inherit from a library-specific base class (e.g., `BlobTestBase`) which extends `StorageTestBase<TEnvironment>` which extends `RecordedTestBase<TEnvironment>`
- Apply the library fixture attribute (e.g., `[BlobsClientTestFixture]`) — it parameterizes tests by service version
- Constructor signature: `public MyTests(bool async, ServiceVersion version) : base(async, version, null)`

### Test attributes
- `[RecordedTest]` — tests with HTTP recording/playback (majority of tests)
- `[LiveOnly]` — tests that cannot be recorded (include reason: `[LiveOnly(Reason = "...")]`)
- `[Test]` — pure unit tests with no service calls

### Test method naming
`MethodName_Scenario()` or `MethodName_Scenario_Expected()`:
```csharp
CreateAsync_WithMetadata()
Upload_InvalidRequestConditions(string invalidCondition)
Ctor_ConnectionString()
```

### Key patterns
- **Random values** — use `Recording.Random` for reproducibility in playback mode
- **Resource cleanup** — use `await using DisposingContainer test = await GetTestContainerAsync()`
- **Assertions** — NUnit `Assert.*` methods; custom helpers in `TestHelper`
- **Sync/async** — write tests with async APIs only; the framework auto-generates sync variants via `InstrumentClient`
- **Recorded tests** — prefer recorded/live tests over mocks for service interactions

## Build and Workflow

```bash
# Build storage libraries
dotnet build

# Run tests (skip live tests)
dotnet test --filter TestCategory!=Live

# Run tests for a single framework
dotnet test -f net10.0

# Regenerate REST clients from swagger (run from the package's src/ directory)
dotnet build /t:GenerateCode

# Export public API after changes (from repo root)
eng/scripts/Export-API.ps1 storage

# Update documentation snippets (from repo root)
eng/scripts/Update-Snippets.ps1 storage
```

### API surface files
Public API is tracked in `api/*.netstandard2.0.cs` (and other TFMs). These are auto-generated — run `Export-API.ps1` to update, do not edit manually.

### CHANGELOG format
```markdown
## X.Y.Z (YYYY-MM-DD)
### Features Added
### Breaking Changes
### Bugs Fixed
### Other Changes
```
