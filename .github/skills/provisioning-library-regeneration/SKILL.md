---
name: provisioning-library-regeneration
description: Onboard new Azure.Provisioning.* libraries OR regenerate existing ones. Use when introducing a brand-new provisioning library, adding new resource types, enum values, or API versions.
---

# Provisioning Library Onboarding & Regeneration

This skill covers two related workflows for `Azure.Provisioning.*` libraries:

- **Onboarding** — introducing a brand new `Azure.Provisioning.{Service}` package.
- **Regeneration** — updating an existing package to add new resources, enum values, or API versions.

> **Start here:** Read **Workflow Selection** below to choose the correct path before doing anything else.

---

## Workflow Selection

### Is this onboarding or regeneration?

- If `sdk/{service}/Azure.Provisioning.{Service}/` already exists → **Regeneration**. Jump to [Regeneration Workflow](#regeneration-workflow).
- If it does NOT exist → **Onboarding**. Continue below to pick the correct onboarding path.

### Onboarding: Path A vs Path B

The onboarding workflow depends on how the corresponding management library (`Azure.ResourceManager.{Service}`) is generated:

```shell
# Inspect the mgmt library to choose the path
ls sdk/{service}/Azure.ResourceManager.{Service}/tsp-location.yaml
```

| Path | Trigger | Onboarding flow |
|---|---|---|
| **Path A** — reflection generator | Mgmt library has **NO** `tsp-location.yaml` (Swagger/AutoRest based; has `src/autorest.md`) | [Path A: Onboard via the reflection generator](#path-a-onboard-via-the-reflection-generator) |
| **Path B** — TypeSpec emitter | Mgmt library **has** `tsp-location.yaml` (TypeSpec based) | [Path B: Onboard via the TypeSpec provisioning emitter](#path-b-onboard-via-the-typespec-provisioning-emitter) |

**Key structural difference**:
- Path A packages live alongside other reflection-generated provisioning libs and are registered in `sdk/provisioning/Generator/src/Program.cs`.
- Path B packages live next to their mgmt counterpart at `sdk/{service}/Azure.Provisioning.{Service}/`, have their own `tsp-location.yaml` + `metadata.json`, and are NEVER registered in `Program.cs`.

> **Common to both paths**: New packages start at version `1.0.0-beta.1`, do NOT add `ApiCompatVersion`, and do NOT add the new package itself to `eng/centralpackagemanagement/Directory.Packages.props` unless explicitly required (CPM is for *consumed* packages; in-repo packages reference each other via `ProjectReference` in tests / `PackageReference` only when consumed by another in-repo package). Confirm by checking how a recent equivalent onboarding PR handled it.

---

## Path A: Onboard via the reflection generator

Use when the mgmt library is Swagger/AutoRest based (no `tsp-location.yaml`).

### A1. Scaffold the new package directory

Model after a recent simple Path A package (e.g., `sdk/resourcegraph/Azure.Provisioning.ResourceGraph/` or `sdk/redisenterprise/Azure.Provisioning.RedisEnterprise/`). Create:

```
sdk/{service}/Azure.Provisioning.{Service}/
├── Azure.Provisioning.{Service}.slnx          # references src and tests csprojs
├── Directory.Build.props                       # standard provisioning props
├── CHANGELOG.md                                # 1.0.0-beta.1 (Unreleased) entry
├── README.md                                   # use `dotnet add package ... --prerelease`
├── src/
│   └── Azure.Provisioning.{Service}.csproj    # Version 1.0.0-beta.1, references Azure.Provisioning
└── tests/
    └── Azure.Provisioning.{Service}.Tests.csproj
```

> **Path A packages do NOT have `tsp-location.yaml` or `metadata.json`** — those are Path B artifacts.

### A2. Register the specification

Add a new specification class file:

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

Register it alphabetically in `sdk/provisioning/Generator/src/Program.cs` `rpSpecs` list.

Add the mgmt PackageReference to `sdk/provisioning/Generator/src/Generator.csproj` (alphabetical):

```xml
<PackageReference Include="Azure.ResourceManager.{Service}" />
```

### A3. Run the generator

```shell
cd sdk/provisioning/Generator/src
dotnet run --framework net10.0 -- --filter {Service}
```

Then jump to [Verify Only Target Library Changed](#verify-only-target-library-changed) (under the regeneration section).

### A4. WirePath workaround (if generated paths are wrong)

After running the generator, peek at `DefineProperty` calls in a generated resource (e.g., `LogicWorkflow.cs`):

```shell
Select-String sdk/{service}/Azure.Provisioning.{Service}/src/Generated/{Resource}.cs -Pattern 'DefineProperty'
```

If you see paths like `["Definition"]` or `["State"]` instead of `["properties", "definition"]` / `["properties", "state"]`, the mgmt library is missing `WirePath` attributes (it lacks `enable-bicep-serialization: true` in its `autorest.md`).

**Confirm**:
```shell
(Select-String -Path sdk/{service}/Azure.ResourceManager.{Service}/src/Generated/Models/*.cs -Pattern 'WirePath' | Measure).Count
# 0 → workaround required
```

**Workaround** (verified via `Logic` and `ContainerInstance` PRs):

1. Add `enable-bicep-serialization: true` under `use-model-reader-writer: true` in `sdk/{service}/Azure.ResourceManager.{Service}/src/autorest.md`.
2. Regenerate the mgmt library locally:
   ```shell
   cd sdk/{service}/Azure.ResourceManager.{Service}/src
   dotnet build /t:GenerateCode
   ```
   This produces `WirePath` attrs and `Internal/{BicepSerializationHelpers,WirePathAttribute}.cs`.
3. Switch `Generator.csproj` from `PackageReference` to `ProjectReference` for this mgmt lib only:
   ```xml
   <ProjectReference Include="..\..\..\{service}\Azure.ResourceManager.{Service}\src\Azure.ResourceManager.{Service}.csproj" />
   ```
4. Re-run the provisioning generator (step A3). Confirm `DefineProperty` paths now include `"properties"`.
5. **Revert all mgmt-side changes** — the workaround is generator-side only; the mgmt library must NOT ship with these changes:
   ```shell
   git checkout -- sdk/{service}/Azure.ResourceManager.{Service}/
   Remove-Item sdk/{service}/Azure.ResourceManager.{Service}/src/Generated/Internal/BicepSerializationHelpers.cs,
                sdk/{service}/Azure.ResourceManager.{Service}/src/Generated/Internal/WirePathAttribute.cs
   ```
6. Switch `Generator.csproj` back to `PackageReference`.

After revert, `git status -- sdk/{service}/Azure.ResourceManager.{Service}/` must be **empty**.

### A5. Validate, test, finalize

Continue with these regeneration steps (they apply to both onboarding and regen):

- [Step 4: Validate Generated Schema Against Bicep Reference](#step-4-validate-generated-schema-against-bicep-reference) — but see the note on [Path A schema validation without schema.log](#schema-validation-without-schemalog) below for new generators.
- [Step 6: Fix Spell Check Issues](#step-6-fix-spell-check-issues)
- [Step 7: Run Pre-Commit Checks](#step-7-run-pre-commit-checks)
- [Step 8: Update CHANGELOG and Commit](#step-8-update-changelog-and-commit)

Additionally for onboarding:

- Add a basic test (`tests/Basic{Service}Tests.cs`) using the simplest resource with a `#region Snippet:{Name}` block; add a `BasicLive{Service}Tests.cs` (`[LiveOnly]`) calling the same factory through `SetupLiveCalls(this).Lint().ValidateAsync()`. Model after `BasicResourceGraphTests.cs`.
- Add the package to `sdk/{service}/ci.mgmt.yml` `Artifacts:`:
  ```yaml
      - name: Azure.Provisioning.{Service}
        safeName: AzureProvisioning{Service}
  ```
- Open a **draft** PR.

---

## Path B: Onboard via the TypeSpec provisioning emitter

Use when the mgmt library has `tsp-location.yaml` (TypeSpec based).

This path requires changes in **two repos**: a spec PR in `azure-rest-api-specs` (to enable the provisioning emitter) and an SDK PR here (to scaffold and generate).

### B1. Open a spec PR enabling the provisioning emitter

In `azure-rest-api-specs`, edit the service's `tspconfig.yaml` to add the `@azure-typespec/http-client-csharp-provisioning` emitter under `options:` (NOT `emit:`). Pin to the same stable api-version the mgmt library uses:

```yaml
options:
  "@azure-typespec/http-client-csharp-provisioning":
    namespace: "Azure.Provisioning.{Service}"
    emitter-output-dir: "{project-root}/Azure.Provisioning.{Service}"
    api-version: "YYYY-MM-DD"   # match the mgmt library's stable version
```

> Find the right api-version by reading the mgmt library's `tsp-location.yaml` and its referenced spec.

Commit, push to your fork, open a draft PR. Use `git rev-parse HEAD` to get the **full** commit SHA (short SHA from `git log --oneline` is truncated and `tsp-client` will fail with "not our ref").

### B2. Scaffold the new package directory

Model after `sdk/batch/Azure.Provisioning.Batch/` or `sdk/servicenetworking/Azure.Provisioning.ServiceNetworking/`. Create:

```
sdk/{service}/Azure.Provisioning.{Service}/
├── Azure.Provisioning.{Service}.slnx
├── Directory.Build.props
├── CHANGELOG.md                 # 1.0.0-beta.1 (Unreleased)
├── README.md                    # use `dotnet add package ... --prerelease`
├── tsp-location.yaml            # points to your spec PR's HEAD commit + fork repo
├── metadata.json
├── src/Azure.Provisioning.{Service}.csproj
└── tests/Azure.Provisioning.{Service}.Tests.csproj
```

> **Path B packages do NOT register anything in `sdk/provisioning/Generator/src/Program.cs`.**

`tsp-location.yaml` example:

```yaml
directory: specification/{service}/{Service}.Management
commit: <FULL SHA from git rev-parse HEAD in spec repo>
repo: <fork>/azure-rest-api-specs   # change to Azure/azure-rest-api-specs after spec PR merges
additionalDirectories:
```

### B3. Generate

```shell
cd sdk/{service}/Azure.Provisioning.{Service}/src
dotnet build /t:GenerateCode
```

This invokes `tsp-client` against the spec at the pinned commit. Always wipe `src/Generated/` before regen for clean output.

### B4. NUnit 3 baseline pinning

The repo default is NUnit 4 but several shared sources still use NUnit 3 classic asserts. New Path B test projects must be added to `eng/centralpackagemanagement/Directory.NUnit3Baseline.Packages.props` (alphabetical, alongside other `Azure.Provisioning.*.Tests`). Skip this step if the NUnit 4 migration has been completed for `Azure.Provisioning.*` (check whether the Provisioning entries are still present in the baseline file).

### B5. Validate, test, finalize

- [Schema validation without schema.log](#schema-validation-without-schemalog) — Path B generator does NOT emit `schema.log`.
- Write basic + live tests with a `#region Snippet:{Name}` block. The shared `Trycep` helper does Bicep snapshot comparison.
- Add the package to `sdk/{service}/ci.mgmt.yml` `Artifacts:`.
- Run [Step 7: Pre-Commit Checks](#step-7-run-pre-commit-checks).
- Commit and open a **draft** SDK PR.
- **Post-merge follow-up**: when the spec PR merges, flip `tsp-location.yaml` `repo:` → `Azure/azure-rest-api-specs` and `commit:` → the merge SHA, regenerate, commit.

---

## Schema validation without schema.log

The new Path B generator does NOT produce `Generated/schema.log`. For Path A with the latest generator version, also confirm whether `schema.log` is emitted; if not, use this approach.

For each generated resource (any class extending `ProvisionableResource`):

```shell
Select-String sdk/{service}/Azure.Provisioning.{Service}/src/Generated/*.cs -Pattern 'base\(bicepIdentifier,\s*"(Microsoft\.[^"]+)"'
```

For each ARM resource type printed:

1. Construct the Bicep ref URL using the lowercased type:
   `https://learn.microsoft.com/en-us/azure/templates/{lowercased-provider}/{lowercased-type}?pivots=deployment-language-bicep`
2. Fetch the page and compare the writable properties listed there against the generated `DefineProperty(...)` calls (those NOT marked `isOutput: true`) in the generated resource file.
3. Apply the same critical/info-level rules described in [Compare and Validate](#compare-and-validate) below — especially the `Name` rule.

Delegate this to a parallel sub-agent (the `explore` agent) when there are many resources — it's faster than serial fetching.

---

## Regeneration Workflow

(For existing packages — adding new resources, enum values, or API versions.)

## Step 1: Determine If Management Library Version Update Is Needed

**Key principle**: Only update the management library version if explicitly requested or if the feature doesn't exist in the current version. Prefer not updating to reduce the amount of changes.

1. **If the requirement explicitly says "update the version"** → Update the version (proceed to Step 2A)

2. **If the requirement does NOT explicitly request a version update**:
   - Check if the feature already exists in the current management library:
     ```shell
     # Search for the resource/feature in the management library
     grep -r "NetworkSecurityPerimeterResource" sdk/{service}/Azure.ResourceManager.{Service}/
     ```
   - If the feature exists → Skip version update, proceed to Step 2B
   - If the feature doesn't exist → You'll need to update the version (proceed to Step 2A)

## Step 2A: Update Management Library Version (If Needed)

Edit `eng/centralpackagemanagement/Directory.Packages.props` to update the management library version:

```xml
<PackageVersion Include="Azure.ResourceManager.{ServiceName}" Version="{NewVersion}" />
```

## Step 2B: Check for Resource Whitelist (If Applicable)

Some specifications (like Network) use a whitelist to limit which resources are generated. Check the specification file:

```shell
cat sdk/provisioning/Generator/src/Specifications/{Service}Specification.cs
```

If you see a `_generatedResources` HashSet, add the new resource types to it:

```csharp
private readonly HashSet<Type> _generatedResources = new()
{
    // ... existing resources ...
    typeof(NetworkSecurityPerimeterResource),
    typeof(NetworkSecurityPerimeterAccessRuleResource),
    // ... add all related resource types ...
};
```

## Step 3: Run the Provisioning Generator

Navigate to the generator directory and run:

```shell
cd sdk/provisioning/Generator/src
dotnet run --framework net10.0 -- --filter {ServiceName}
```

**Important:** The generator reads from NuGet packages, NOT local source code. The version in `eng/centralpackagemanagement/Directory.Packages.props` determines which package version is used.

### Verify Only Target Library Changed

After running the generator, verify that only the target provisioning library was modified:

```shell
git status --short -- sdk/provisioning/
```

The generator may regenerate other libraries (e.g., `Azure.Provisioning`) due to shared dependencies. **Revert any changes to libraries other than the target:**

```shell
# Example: If you're adding features to Azure.Provisioning.Network, revert changes to Azure.Provisioning
git checkout main -- sdk/provisioning/Azure.Provisioning/
```

Only keep changes to `Azure.Provisioning.{TargetService}/`.

### Generator Errors

If the generator fails with errors:

1. **Capture the full error output** including stack traces and error messages
2. **Report the error to the user** with enough context to understand what went wrong
3. **Stop and let the user decide** how to proceed — generator errors often require code changes to the generator itself or the specification files, which may need human judgment

Do NOT attempt to automatically fix generator errors without user guidance.

## Step 4: Validate Generated Schema Against Bicep Reference

After the generator runs successfully, validate the generated resources against the official Azure Bicep documentation.

### Locate the Schema Log

The generator produces a `schema.log` file that contains the generated resource schemas:

```
sdk/provisioning/Azure.Provisioning.{Service}/src/Generated/schema.log
```

Each resource entry looks like:
```
resource NetworkSecurityPerimeter "Microsoft.Network/networkSecurityPerimeters@2025-05-01" = {
  name: 'string'
  location: 'string'
  ...
}
```

### Construct Bicep Reference URLs

For each new resource type in the schema.log, construct the documentation URL:

```
https://learn.microsoft.com/en-us/azure/templates/{provider}/{resource-type}?pivots=deployment-language-bicep
```

**URL Construction Rules:**
- Convert the resource type from the schema to lowercase
- Use the provider and resource path from the `@` prefix (e.g., `Microsoft.Network/networkSecurityPerimeters`)

**Examples:**
| Schema Resource Type | Documentation URL |
|---------------------|-------------------|
| `Microsoft.Network/networkSecurityPerimeters` | `https://learn.microsoft.com/en-us/azure/templates/microsoft.network/networksecurityperimeters?pivots=deployment-language-bicep` |
| `Microsoft.Network/networkSecurityPerimeters/profiles` | `https://learn.microsoft.com/en-us/azure/templates/microsoft.network/networksecurityperimeters/profiles?pivots=deployment-language-bicep` |
| `Microsoft.DBforPostgreSQL/flexibleServers` | `https://learn.microsoft.com/en-us/azure/templates/microsoft.dbforpostgresql/flexibleservers?pivots=deployment-language-bicep` |

### Compare and Validate

For each new resource:
1. **Fetch the Bicep reference** from the constructed URL
2. **Compare property names** between schema.log and the Bicep reference
3. **Check for**:
   - **Incorrect property names**: Properties in schema.log that don't match the Bicep reference
   - **Missing properties**: Properties in the Bicep reference that are not in schema.log
   - **Extra writable properties**: Properties that are NOT marked `readonly` in schema.log but do NOT exist in the Bicep reference — these are potential issues since users could try to set properties that the service doesn't accept
   - **Incorrectly readonly properties**: Properties marked `readonly` in schema.log but listed as writable/required in the Bicep reference — especially the `name` property, which must be settable for provisionable resources
   - **Type mismatches**: Properties with different types

**Note on readonly properties**: Properties marked `readonly` in schema.log (e.g., `provisioningState: readonly 'string'`) are output-only and don't need to match the Bicep reference for input validation. However, you **must also check the reverse**: if a property is writable/required in the Bicep reference but marked `readonly` in schema.log, this is a bug — the generated resource cannot be provisioned correctly.

**Critical: Always validate the `name` property**: The `name` property is the resource identity and should almost always be writable and required (except for singleton resources with fixed names). If schema.log shows `name: readonly 'string'` but the Bicep reference shows `name` as required, this indicates the generator failed to detect the name parameter (e.g., the ARM parameter name doesn't end with "Name", like `addressId` instead of `suppressionListAddressName`). Fix this by adding a `CustomizeProperty` in the specification file:
```csharp
CustomizeProperty<{ResourceType}>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
```

### If Discrepancies Are Found

1. **Report the discrepancies** to the user with:
   - Which resource type has issues
   - Which properties are incorrect/missing
   - Links to the Bicep reference
2. **Stop and let the user decide** how to proceed — discrepancies may indicate:
   - Issues with the management library
   - Need for specification customizations
   - Documentation being out of sync (less common)

Do NOT attempt to automatically fix schema discrepancies without user guidance.

## Step 5: Handle Breaking Changes (Version Updates Only)

When updating management library versions, compare the generated code with the previous version. Common breaking changes include:

### Type Removed
If a type is removed from the management library:
- Create a backward-compatible stub in `sdk/provisioning/Azure.Provisioning.{Service}/src/BackwardCompatible/Models/`
- Mark it with `[EditorBrowsable(EditorBrowsableState.Never)]` and `[Obsolete]`

### Property Type Changed
If a property type changes:
1. In the specification file, use `CustomizeProperty` to rename the new property:
   ```csharp
   CustomizeProperty("ResourceName", "PropertyName", p => p.Name = "NewPropertyName");
   ```
2. Use `CustomizeResource` with `GeneratePartialPropertyDefinition = true`:
   ```csharp
   CustomizeResource("ResourceName", r => r.GeneratePartialPropertyDefinition = true);
   ```
3. Create a partial class in `BackwardCompatible/` that implements `DefineAdditionalProperties()` to add the old property name

### Enum Ordinal Shift
If enum member ordering changes (affecting implicit numeric values):
- Use `OrderEnum<T>()` in the specification file to preserve the original ordering:
  ```csharp
  OrderEnum<PostgreSqlFlexibleServerVersion>("Ver15", "Ver14", "Ver13", "Ver12", "Ver11", "Sixteen");
  ```

### DataMember Attribute Removed
If `[DataMember]` attributes are removed from enums, ApiCompat will report `CP0002` errors.

For provisioning packages, create `ApiCompatBaseline.txt` in the package's `src/` directory to suppress the compatibility errors:
```
CP0002:M:Azure.Provisioning.{Service}.{EnumType}.{Member}.get->System.Runtime.Serialization.DataMemberAttribute
```

> Note: This baseline file approach is specifically supported for provisioning packages and is the only option for suppressing these particular ApiCompat errors.

## Step 6: Fix Spell Check Issues

If CI fails with "Unknown word" errors, add the words to `sdk/provisioning/cspell.yaml`:

```yaml
  - filename: '**/sdk/provisioning/Azure.Provisioning.{Service}/**/*.cs'
    words:
      - newword1
      - newword2
```

**Important:** Use `sdk/provisioning/cspell.yaml`, NOT `.vscode/cspell.json`.

## Step 7: Run Pre-Commit Checks

Before committing, invoke the `pre-commit-checks` skill with the service directory set to `provisioning`. This will handle code formatting, API export, and snippet updates.

## Step 8: Update CHANGELOG and Commit

1. Update the CHANGELOG at `sdk/provisioning/Azure.Provisioning.{Service}/CHANGELOG.md`:
   ```markdown
   ## X.X.X-beta.X (Unreleased)

   ### Features Added

   - Added support for `{NewResource}` resources and related types.
   ```

2. Stage all changes and commit:
   ```shell
   git add -A
   git commit -m "Add {Feature} to Azure.Provisioning.{Service}"
   ```

## Example A: PostgreSQL Server Versions 17 and 18 (Version Update Required)

The requirement was to add PostgreSQL versions 17 and 18, which required updating the management library.

1. **Updated `eng/centralpackagemanagement/Directory.Packages.props`**: Changed `Azure.ResourceManager.PostgreSql` from 1.3.1 to 1.4.1
2. **Ran generator**: `dotnet run --framework net10.0 -- --filter PostgreSql`
3. **Handled breaking changes**: Property renames, obsolete stubs, enum ordering, ApiCompatBaseline
4. **Fixed CI issues**: Added spell check words to `cspell.yaml`
5. **Ran pre-commit checks**: `pwsh eng\scripts\CodeChecks.ps1 -ServiceDirectory provisioning`

## Example B: NetworkSecurityPerimeter Resources (No Version Update Needed)

The requirement was to add NetworkSecurityPerimeter support. The resources already existed in the current management library but weren't being generated due to a whitelist.

1. **Checked management library**: Resources already existed in `Azure.ResourceManager.Network`
2. **Updated `NetworkSpecification.cs`**: Added 7 resource types to `_generatedResources`:
   ```csharp
   typeof(NetworkSecurityPerimeterResource),
   typeof(NetworkSecurityPerimeterAccessRuleResource),
   typeof(NetworkSecurityPerimeterAssociationResource),
   typeof(NetworkSecurityPerimeterLinkResource),
   typeof(NetworkSecurityPerimeterLinkReferenceResource),
   typeof(NetworkSecurityPerimeterLoggingConfigurationResource),
   typeof(NetworkSecurityPerimeterProfileResource),
   ```
3. **Ran generator**: `dotnet run --framework net10.0 -- --filter Network`
4. **Ran pre-commit checks**: No breaking changes (new resources only)
5. **Updated CHANGELOG**: Documented new NetworkSecurityPerimeter support

## Key Files

| File | Purpose |
|------|---------|
| `eng/centralpackagemanagement/Directory.Packages.props` | Management library version |
| `sdk/provisioning/Generator/src/Specifications/{Service}Specification.cs` | Generator customizations and resource whitelist |
| `sdk/provisioning/Generator/src/Model/Specification.Customize.cs` | Customization API (`OrderEnum`, `CustomizeResource`, etc.) |
| `sdk/provisioning/Azure.Provisioning.{Service}/src/BackwardCompatible/` | Backward-compatible customizations |
| `sdk/provisioning/Azure.Provisioning.{Service}/src/ApiCompatBaseline.txt` | API compatibility suppressions (provisioning only) |
| `sdk/provisioning/cspell.yaml` | Spell check configuration for provisioning |

## Troubleshooting

### Resources not being generated
- Check if the specification uses a whitelist (`_generatedResources`)
- Verify the resource types are added to the whitelist
- Ensure the management library version is correct

### Generator fails to find types
- Ensure the management library version in `eng/centralpackagemanagement/Directory.Packages.props` is correct and published
- Try running `dotnet restore` before the generator

### API compatibility errors
- Use customization code to maintain backward compatibility (preferred approach):
  - Create backward-compatible stubs in `BackwardCompatible/Models/`
  - Use `CustomizeProperty` and `CustomizeResource` in specification files
  - Add partial classes with `DefineAdditionalProperties()` for property renames
- Only `[DataMember]` attribute removal errors can be suppressed via `ApiCompatBaseline.txt`

### Enum values in wrong order
- Use `OrderEnum<T>()` in the specification file to control ordering

### Build fails after regeneration
- Check for missing using statements
- Check for type name conflicts
- Review the specification customizations
