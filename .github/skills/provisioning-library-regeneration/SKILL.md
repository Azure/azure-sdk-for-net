---
name: provisioning-library-regeneration
description: Regenerate Azure.Provisioning.* libraries to add new resources or features. Use when adding new resource types, enum values, or API versions to provisioning libraries.
---

# Provisioning Library Regeneration

This skill guides the process of regenerating `Azure.Provisioning.*` libraries to add new resources or features. This is typically needed when:

- New resource types need to be added to provisioning (e.g., NetworkSecurityPerimeter)
- New enum values are added (e.g., new PostgreSQL server versions)
- New API versions bring new properties or types
- The management library has a new release with features needed in provisioning

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

## Writing Provisioning Test Cases

Every provisioning library — whether generated via the reflection-based generator or the TypeSpec-based generator — must include test cases that follow the standard Trycep pattern. This section explains the conventions and structure.

### Test File Structure

Each provisioning library needs these files under `tests/`:

| File | Purpose |
|------|---------|
| `Basic{Service}Tests.cs` | Unit tests with `#region Snippet:` blocks and `Trycep.Compare()` Bicep validation |
| `BasicLive{Service}Tests.cs` | Live integration tests calling the same factory methods |
| `Azure.Provisioning.{Service}.Tests.csproj` | Test project referencing `Azure.Core.TestFramework`, `Azure.Provisioning`, and shared test utilities |

A `.slnx` solution file should also be created at the library root to include both `src` and `tests` projects.

### Basic Tests Pattern

Each test scenario is a **static factory method** returning `Trycep`, with the infrastructure definition wrapped in a `#region Snippet:{SnippetName}` block. The snippet is reused in both the README and the live test.

```csharp
public class BasicBatchTests
{
    internal static Trycep CreateBatchAccountWithPoolTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:BatchAccountBasic
                Infrastructure infra = new();

                BatchAccount account =
                    new(nameof(account), BatchAccount.ResourceVersions.V2025_06_01)
                    {
                        Tags = { ["environment"] = "test" },
                    };
                infra.Add(account);

                // ... add child resources, outputs ...
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.batch/batchaccount-with-storage/main.bicep")]
    public async Task CreateBatchAccountWithPool()
    {
        await using Trycep test = CreateBatchAccountWithPoolTest();
        test.Compare("""
            // Expected Bicep output here
            """);
    }
}
```

**Key conventions:**
- The `[Description]` attribute links to the relevant [Azure quickstart template](https://github.com/Azure/azure-quickstart-templates/tree/master/quickstarts)
- Use `#region Snippet:{Name}` / `#endregion` so the snippet can be extracted into the README
- The factory method is `internal static` so the live test class can reuse it
- Run the test once to see the **actual** Bicep output (printed on failure), then use that as the expected string

### Live Tests Pattern

The live test class calls the same factory methods from the basic tests:

```csharp
public class BasicLiveBatchTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.batch/batchaccount-with-storage/main.bicep")]
    [LiveOnly]
    public async Task CreateBatchAccountWithPool()
    {
        await using Trycep test = BasicBatchTests.CreateBatchAccountWithPoolTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
```

### README Examples Section

The README must include a `Key concepts` section and an `Examples` section. The example code references the `#region Snippet` by name:

````markdown
## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.
You can then use azd to deploy your infrastructure to Azure directly without needing to
write or maintain bicep or arm templates.

## Examples

### Create a Batch Account with Pool and Application

This example demonstrates how to create a Batch account with a pool and application, based
on the [Azure quickstart template](https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.batch/batchaccount-with-storage/main.bicep).

```C# Snippet:BatchAccountBasic
// The snippet content is extracted from BasicBatchTests.cs at build time
```
````

### Tips for Writing Provisioning Tests

1. **Only use public, settable properties.** Many provisioning resource properties are read-only (get-only). Check the generated code for `set` accessors before using a property in tests. For example, `BatchAccount.AutoStorage` and `BatchAccount.PoolAllocationMode` are read-only, while `BatchAccount.Tags` and `BatchAccount.Location` have setters.

2. **Watch for `internal` types.** Some generated model types are `internal` and cannot be used from the test project. For example, `BatchDeploymentConfiguration` is internal in `Azure.Provisioning.Batch`.

3. **Double-wrapped BicepValue types.** Some properties have `BicepValue<BicepValue<T>>` types due to the provisioning type system. You cannot directly assign an enum or value to these — use proper wrapping or avoid them in basic test scenarios.

4. **Get actual Bicep output first.** Write the test with a placeholder expected string, run it to get the actual Bicep output (printed in the failure message), then update the expected string to match. The output often has different ordering or formatting than expected (e.g., `tags` before `location`, no `properties: {}` when empty, different `take()` length limits for child resources).

5. **Child resource name length.** Top-level resources typically use `take(..., 24)` while child resources use `take(..., 64)` for the name. The exact behavior depends on the resource type definition.

6. **Test project references.** The test `.csproj` should reference:
   - `Azure.Core.TestFramework`
   - `Azure.Provisioning` (for `Infrastructure`, `ProvisioningOutput`, `ProvisioningParameter`, etc.)
   - `Azure.Provisioning.Deployment` (for Trycep deployment support)
   - Shared test code: `<Compile Include="$(AzureProvisioningTestSharedSources)ProvisioningTestBase.cs" LinkBase="Shared" />`

## Key Files

| File | Purpose |
|------|---------|
| `eng/centralpackagemanagement/Directory.Packages.props` | Management library version |
| `sdk/provisioning/Generator/src/Specifications/{Service}Specification.cs` | Generator customizations and resource whitelist |
| `sdk/provisioning/Generator/src/Model/Specification.Customize.cs` | Customization API (`OrderEnum`, `CustomizeResource`, etc.) |
| `sdk/provisioning/Azure.Provisioning.{Service}/src/BackwardCompatible/` | Backward-compatible customizations |
| `sdk/provisioning/Azure.Provisioning.{Service}/src/ApiCompatBaseline.txt` | API compatibility suppressions (provisioning only) |
| `sdk/provisioning/cspell.yaml` | Spell check configuration for provisioning |
| `common/ProvisioningTestShared/Trycep.cs` | Test orchestration framework (Compare, Lint, Validate, Deploy) |
| `common/ProvisioningTestShared/ProvisioningTestBase.cs` | Base class for live tests |

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
