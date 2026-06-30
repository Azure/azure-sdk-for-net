# Onboarding a New Azure.Provisioning Library

Use this process when introducing a brand-new `Azure.Provisioning.{Service}` package. If the package already exists and you are adding resources, enum values, or API versions, use the regeneration workflow in `SKILL.md` instead.

## 1. Classify the onboarding path

Start from the corresponding management library:

```powershell
Test-Path sdk\{service}\Azure.ResourceManager.{Service}\tsp-location.yaml
```

| Result | Path | Generator |
| --- | --- | --- |
| `False` | Path A | Reflection generator over the management library package |
| `True` | Path B | TypeSpec provisioning emitter |

Common rules for both paths:

- Start the new package at `1.0.0-beta.1`.
- Do not add `ApiCompatVersion` for a new package.
- Do not add the new package itself to `eng\centralpackagemanagement\Directory.Packages.props` unless another in-repo package consumes it.
- Add a basic unit test, a matching live test, README snippets, changelog entry, and CI artifact entry before opening the SDK PR.
- Open PRs in draft mode.

## 2. Path A: reflection-generated provisioning library

Use Path A when the management library is Swagger/AutoRest based and does not have `tsp-location.yaml`.

### 2.1 Scaffold the package

Model the package after a recent reflection-generated provisioning library, such as `sdk\resourcegraph\Azure.Provisioning.ResourceGraph` or `sdk\redisenterprise\Azure.Provisioning.RedisEnterprise`.

Create:

```text
sdk\{service}\Azure.Provisioning.{Service}\
  Azure.Provisioning.{Service}.slnx
  Directory.Build.props
  CHANGELOG.md
  README.md
  src\Azure.Provisioning.{Service}.csproj
  tests\Azure.Provisioning.{Service}.Tests.csproj
```

Do not add `tsp-location.yaml` or `metadata.json`; those are Path B artifacts.

### 2.2 Register the service with the reflection generator

Add a specification class:

```csharp
// sdk/provisioning/Generator/src/Specifications/{Service}Specification.cs
using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.{Service};

namespace Azure.Provisioning.Generator.Specifications;

public class {Service}Specification() :
    Specification("{Service}", typeof({Service}Extensions), serviceDirectory: "{service}")
{
    protected override void Customize() { }
}
```

Then:

1. Register the specification alphabetically in `sdk\provisioning\Generator\src\Program.cs`.
2. Add an alphabetical management library `PackageReference` in `sdk\provisioning\Generator\src\Generator.csproj`.

### 2.3 Run the reflection generator

```powershell
Push-Location sdk\provisioning\Generator\src
dotnet run --framework net10.0 -- --filter {Service}
Pop-Location
```

After generation, verify that only the target provisioning library changed. Revert unrelated generated changes.

```powershell
git status --short -- sdk\provisioning sdk\{service}\Azure.Provisioning.{Service}
```

### 2.4 Check for missing WirePath data

Inspect generated `DefineProperty` calls:

```powershell
Select-String sdk\{service}\Azure.Provisioning.{Service}\src\Generated\*.cs -Pattern 'DefineProperty'
```

If generated paths omit `"properties"` segments, confirm whether the management library lacks `WirePath` attributes:

```powershell
(Select-String -Path sdk\{service}\Azure.ResourceManager.{Service}\src\Generated\Models\*.cs -Pattern 'WirePath' | Measure-Object).Count
```

When the count is `0`, use the temporary workaround from `SKILL.md`: enable bicep serialization in the management library, regenerate it locally, temporarily switch the generator to a `ProjectReference`, rerun the provisioning generator, then revert all management-library changes and restore the `PackageReference`.

## 3. Path B: TypeSpec provisioning emitter library

Use Path B when the management library is TypeSpec based and has `tsp-location.yaml`. This path requires both a spec PR and an SDK PR.

### 3.1 Enable the provisioning emitter in the spec repo

In the service `tspconfig.yaml` in `azure-rest-api-specs`, add the provisioning emitter under `options`, not `emit`:

```yaml
options:
  "@azure-typespec/http-client-csharp-provisioning":
    namespace: "Azure.Provisioning.{Service}"
    emitter-output-dir: "{project-root}/Azure.Provisioning.{Service}"
    api-version: "YYYY-MM-DD"
```

Choose the stable API version that matches the management library's `tsp-location.yaml` and referenced spec. Commit the spec change, push it to your fork, open a draft spec PR, and record the full commit SHA from:

```powershell
git rev-parse HEAD
```

Do not use a short SHA; `tsp-client` requires the full commit.

### 3.2 Scaffold the SDK package

Model the package after `sdk\batch\Azure.Provisioning.Batch` or `sdk\servicenetworking\Azure.Provisioning.ServiceNetworking`.

Create:

```text
sdk\{service}\Azure.Provisioning.{Service}\
  Azure.Provisioning.{Service}.slnx
  Directory.Build.props
  CHANGELOG.md
  README.md
  tsp-location.yaml
  metadata.json
  src\Azure.Provisioning.{Service}.csproj
  tests\Azure.Provisioning.{Service}.Tests.csproj
```

Use a temporary `tsp-location.yaml` that points to the spec PR commit:

```yaml
directory: specification/{service}/{Service}.Management
commit: <full spec PR commit SHA>
repo: <fork>/azure-rest-api-specs
additionalDirectories:
```

Do not register Path B packages in `sdk\provisioning\Generator\src\Program.cs`.

### 3.3 Generate from TypeSpec

Remove stale generated output before regenerating:

```powershell
Remove-Item sdk\{service}\Azure.Provisioning.{Service}\src\Generated -Recurse -Force -ErrorAction SilentlyContinue
Push-Location sdk\{service}\Azure.Provisioning.{Service}\src
dotnet build /t:GenerateCode
Pop-Location
```

### 3.4 Check NUnit baseline requirements

If `eng\centralpackagemanagement\Directory.NUnit3Baseline.Packages.props` still contains `Azure.Provisioning.*.Tests` entries, add the new test project alphabetically. Skip this only if the provisioning tests have completed their NUnit 4 migration.

After the spec PR merges, update `tsp-location.yaml` to point back to `Azure/azure-rest-api-specs` and the merged commit SHA, then regenerate and commit the resulting SDK changes.

## 4. Add package tests and documentation

Add both test files:

- `tests\Basic{Service}Tests.cs`
- `tests\BasicLive{Service}Tests.cs`

Use a simple resource that can be represented as a minimal Bicep template. The unit test should include a `#region Snippet:{Name}` block and validate output with `Trycep.Compare()`. The live test should be `[LiveOnly]` and call the same factory method through:

```csharp
await using Trycep test = await CreateTestAsync();
await test.SetupLiveCalls(this)
    .Lint()
    .ValidateAsync();
```

Update `README.md` with a `Key concepts` section and an `Examples` section that references the snippet:

````markdown
```C# Snippet:{Name}
```
````

Use `dotnet add package Azure.Provisioning.{Service} --prerelease` in installation guidance.

## 5. Add CI and package metadata

Add the package to `sdk\{service}\ci.mgmt.yml` under `Artifacts`:

```yaml
    - name: Azure.Provisioning.{Service}
      safeName: AzureProvisioning{Service}
```

For both paths, confirm the package files contain the expected first-release metadata:

- `CHANGELOG.md` has `1.0.0-beta.1 (Unreleased)`.
- `src\Azure.Provisioning.{Service}.csproj` has version `1.0.0-beta.1`.
- The solution includes both `src` and `tests` projects.

## 6. Validate generated resources against Bicep reference

Use `schema.log` when available:

```text
sdk\{service}\Azure.Provisioning.{Service}\src\Generated\schema.log
```

If `schema.log` is not produced, enumerate generated resource types from generated resource constructors:

```powershell
Select-String sdk\{service}\Azure.Provisioning.{Service}\src\Generated\*.cs -Pattern 'base\(bicepIdentifier,\s*"(Microsoft\.[^"]+)"'
```

For each generated ARM resource type:

1. Build the Bicep reference URL: `https://learn.microsoft.com/en-us/azure/templates/{lowercase-provider}/{lowercase-resource-type}?pivots=deployment-language-bicep`.
2. Compare writable generated properties against the Bicep reference.
3. Treat writable generated properties that do not exist in Bicep as suspicious.
4. Treat Bicep-required writable properties that are generated as output-only as bugs.
5. Always validate `name`; it should be writable and required unless the resource is a singleton with a fixed name.

If discrepancies are found, document the exact resource, property, generated behavior, and Bicep reference URL before deciding whether a generator customization or spec fix is needed.

## 7. Run final checks

Before committing, run the pre-commit validation flow for the `provisioning` service directory. This covers formatting, API export, snippet updates, and regeneration checks.

If spell check fails, add service-specific words to `sdk\provisioning\cspell.yaml`, not `.vscode\cspell.json`.

## 8. Commit and open PRs

Commit the SDK changes with a concise present-tense message, for example:

```text
Onboard Azure.Provisioning.{Service}
```

Open the SDK PR in draft mode. For Path B, keep the SDK PR tied to the spec PR until the spec PR merges, then update `tsp-location.yaml` to the upstream repo and merge commit.
