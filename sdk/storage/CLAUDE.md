# Azure Storage SDK — Coding Conventions

> This file is a pointer to the canonical storage instructions in `/sdk/storage/.instructions.md`.
> Read `/sdk/storage/CONTRIBUTING.md` for testing setup and code generation details.

For Azure Storage SDK coding conventions and patterns, see `/sdk/storage/.instructions.md`.
### Documentation
- XML docs on all public members: `<summary>`, `<param>`, `<returns>`, `<remarks>`, `<see cref="..."/>`
- `[EditorBrowsable(EditorBrowsableState.Never)]` on `object` overrides (ToString, Equals, GetHashCode)

### Generated code
- **Never** edit files in `Generated/` folders directly
- Run `sdk/storage/generate.ps1` to regenerate from swagger definitions
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
dotnet test -f net8.0

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
