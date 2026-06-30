# Onboarding a New Azure.Provisioning Library

Use this process when introducing a brand-new `Azure.Provisioning.{Service}` package. If the package already exists and you are adding resources, enum values, or API versions, use the regeneration workflow in `SKILL.md` instead.

## 1. Confirm the management library is TypeSpec-based

New provisioning libraries are onboarded through the TypeSpec provisioning emitter. Start from the corresponding TypeSpec-based management library:

```powershell
Test-Path sdk\{service}\Azure.ResourceManager.{Service}\tsp-location.yaml
```

The result must be `True`. The management library's `tsp-location.yaml` identifies the TypeSpec project and API version that the new provisioning library should follow.

Common rules:

- Start the new package at `1.0.0-beta.1`.
- Do not add `ApiCompatVersion` for a new package.
- Do not add the new package itself to `eng\centralpackagemanagement\Directory.Packages.props` unless another in-repo package consumes it.
- Add a basic unit test, a matching live test, README snippets, changelog entry, and CI artifact entry before opening the SDK PR.
- Open PRs in draft mode.

## 2. Enable the provisioning emitter in the spec repo

This onboarding flow requires both a spec PR and an SDK PR. In the service `tspconfig.yaml` in `azure-rest-api-specs`, add the provisioning emitter under `options`, not `emit`:

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

## 3. Scaffold the SDK package

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

## 4. Generate from TypeSpec

Remove stale generated output before regenerating:

```powershell
Remove-Item sdk\{service}\Azure.Provisioning.{Service}\src\Generated -Recurse -Force -ErrorAction SilentlyContinue
Push-Location sdk\{service}\Azure.Provisioning.{Service}\src
dotnet build /t:GenerateCode
Pop-Location
```

## 5. Check NUnit baseline requirements

If `eng\centralpackagemanagement\Directory.NUnit3Baseline.Packages.props` still contains `Azure.Provisioning.*.Tests` entries, add the new test project alphabetically. Skip this only if the provisioning tests have completed their NUnit 4 migration.

After the spec PR merges, update `tsp-location.yaml` to point back to `Azure/azure-rest-api-specs` and the merged commit SHA, then regenerate and commit the resulting SDK changes.

## 6. Add package tests and documentation

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

## 7. Add CI and package metadata

Add the package to `sdk\{service}\ci.mgmt.yml` under `Artifacts`:

```yaml
    - name: Azure.Provisioning.{Service}
      safeName: AzureProvisioning{Service}
```

Confirm the package files contain the expected first-release metadata:

- `CHANGELOG.md` has `1.0.0-beta.1 (Unreleased)`.
- `src\Azure.Provisioning.{Service}.csproj` has version `1.0.0-beta.1`.
- The solution includes both `src` and `tests` projects.

## 8. Validate generated resources against Bicep reference

Enumerate generated ARM resource types from generated resource constructors:

```powershell
Select-String sdk\{service}\Azure.Provisioning.{Service}\src\Generated\*.cs -Pattern 'base\(bicepIdentifier,\s*"(Microsoft\.[^"]+)"'
```

For each generated ARM resource type:

1. Build the Bicep reference URL: `https://learn.microsoft.com/en-us/azure/templates/{lowercase-provider}/{lowercase-resource-type}?pivots=deployment-language-bicep`.
2. Compare writable generated properties against the Bicep reference.
3. Treat writable generated properties that do not exist in Bicep as suspicious.
4. Treat Bicep-required writable properties that are generated as output-only as bugs.
5. Always validate `Name`; it should be writable and required unless the resource is a singleton with a fixed name.
6. Validate Bicep metadata properties:

| Property | Validation rule |
| --- | --- |
| `Parent` | Must be a metadata property, not a regular generated Bicep property. It should not be generated from a Bicep schema property named `parent`. Its type must be a concrete resource type that inherits `ProvisionableResource`. |
| `Scope` | Must be a metadata property, not a regular generated Bicep property. It should not be generated from a Bicep schema property named `scope`. Its type must be `ProvisionableResource` or a concrete resource type that inherits `ProvisionableResource`. |

If discrepancies are found, document the exact resource, property, generated behavior, expected Bicep/schema behavior, and Bicep reference URL before deciding whether a generator customization or spec fix is needed.

## 9. Run final checks

Before committing, run the pre-commit validation flow for the `provisioning` service directory. This covers formatting, API export, snippet updates, and regeneration checks.

If spell check fails, add service-specific words to `sdk\provisioning\cspell.yaml`, not `.vscode\cspell.json`.

## 10. Commit and open PRs

Commit the SDK changes with a concise present-tense message, for example:

```text
Onboard Azure.Provisioning.{Service}
```

Open the SDK PR in draft mode. Keep the SDK PR tied to the spec PR until the spec PR merges, then update `tsp-location.yaml` to the upstream repo and merge commit.
