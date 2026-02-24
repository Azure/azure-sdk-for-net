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

Edit `eng/Packages.Data.props` to update the management library version:

```xml
<PackageReference Update="Azure.ResourceManager.{ServiceName}" Version="{NewVersion}" />
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

**Important:** The generator reads from NuGet packages, NOT local source code. The version in `eng/Packages.Data.props` determines which package version is used.

### Generator Errors

If the generator fails with errors:

1. **Capture the full error output** including stack traces and error messages
2. **Report the error to the user** with enough context to understand what went wrong
3. **Stop and let the user decide** how to proceed — generator errors often require code changes to the generator itself or the specification files, which may need human judgment

Do NOT attempt to automatically fix generator errors without user guidance.

## Step 4: Handle Breaking Changes (Version Updates Only)

When updating management library versions, compare the generated code with the previous version. Common breaking changes include:

### Type Removed
If a type is removed from the management library:
- Create a backward-compatible stub in `sdk/provisioning/Azure.Provisioning.{Service}/src/BackwardCompatible/Models/`
- Mark it with `[EditorBrowsable(EditorBrowsableState.Never)]` and `[Obsolete]`

### Property Type Changed
If a property type changes:
1. In the specification file, use `CustomizeProperty` to rename the new property:
   ```csharp
   CustomizeProperty("ResourceName", "PropertyName", p => p.PropertyName = "NewPropertyName");
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
If `[DataMember]` attributes are removed from enums:
- Create `ApiCompatBaseline.txt` in the package's `src/` directory to suppress the compatibility errors:
  ```
  CP0002:M:Azure.Provisioning.{Service}.{EnumType}.{Member}.get->System.Runtime.Serialization.DataMemberAttribute
  ```

## Step 5: Fix Spell Check Issues

If CI fails with "Unknown word" errors, add the words to `sdk/provisioning/cspell.yaml`:

```yaml
  - filename: '**/sdk/provisioning/Azure.Provisioning.{Service}/**/*.cs'
    words:
      - newword1
      - newword2
```

**Important:** Use `sdk/provisioning/cspell.yaml`, NOT `.vscode/cspell.json`.

## Step 6: Export API and Update Snippets

```shell
pwsh eng\scripts\Export-API.ps1 provisioning
pwsh eng\scripts\Update-Snippets.ps1 provisioning
```

## Step 7: Run Pre-Commit Checks

Before committing, run:

```shell
pwsh eng\scripts\CodeChecks.ps1 -ServiceDirectory provisioning
```

This runs:
- Code generation verification
- API export
- Snippet updates
- Spell check
- Installation instruction validation

All checks must pass with 0 errors.

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

1. **Updated `eng/Packages.Data.props`**: Changed `Azure.ResourceManager.PostgreSql` from 1.3.1 to 1.4.1
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
| `eng/Packages.Data.props` | Management library version |
| `sdk/provisioning/Generator/src/Specifications/{Service}Specification.cs` | Generator customizations and resource whitelist |
| `sdk/provisioning/Generator/src/Model/Specification.Customize.cs` | Customization API (`OrderEnum`, `CustomizeResource`, etc.) |
| `sdk/provisioning/Azure.Provisioning.{Service}/src/BackwardCompatible/` | Backward-compatible customizations |
| `sdk/provisioning/Azure.Provisioning.{Service}/src/ApiCompatBaseline.txt` | API compatibility suppressions |
| `sdk/provisioning/cspell.yaml` | Spell check configuration |

## Troubleshooting

### Resources not being generated
- Check if the specification uses a whitelist (`_generatedResources`)
- Verify the resource types are added to the whitelist
- Ensure the management library version is correct

### Generator fails to find types
- Ensure the management library version in `eng/Packages.Data.props` is correct and published
- Try running `dotnet restore` before the generator

### API compatibility errors
- Use `ApiCompatBaseline.txt` to suppress expected breaking changes
- Or create backward-compatible stubs/properties

### Enum values in wrong order
- Use `OrderEnum<T>()` in the specification file to control ordering

### Build fails after regeneration
- Check for missing using statements
- Check for type name conflicts
- Review the specification customizations
