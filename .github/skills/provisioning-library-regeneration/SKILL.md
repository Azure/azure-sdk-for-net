---
name: provisioning-library-regeneration
description: Regenerate Azure.Provisioning.* libraries when the underlying Azure.ResourceManager.* management library is updated. Use when adding new features (e.g., new enum values, API versions) to provisioning libraries.
---

# Provisioning Library Regeneration

This skill guides the process of regenerating `Azure.Provisioning.*` libraries when the underlying `Azure.ResourceManager.*` management library is updated. This is typically needed when:

- New enum values are added (e.g., new PostgreSQL server versions)
- New API versions bring new properties or types
- The management library has a new release with features needed in provisioning

## Summary of the Process

The provisioning libraries (`sdk/provisioning/Azure.Provisioning.*`) are generated from the management libraries (`sdk/*/Azure.ResourceManager.*`). When a management library is updated, you need to:

1. Update the management library version in `eng/Packages.Data.props`
2. Run the provisioning generator
3. Handle any breaking changes via backward-compatible customizations
4. Fix any spell check, API compatibility, or CI issues
5. Run pre-commit checks

## Prerequisites

- .NET 10 SDK installed
- PowerShell 7+ installed
- The management library update must already be published to NuGet (or the version must be available in `eng/Packages.Data.props`)

## Step 1: Update Management Library Version

Edit `eng/Packages.Data.props` to update the management library version:

```xml
<PackageReference Update="Azure.ResourceManager.{ServiceName}" Version="{NewVersion}" />
```

For example, to update PostgreSql from 1.3.1 to 1.4.1:
```xml
<PackageReference Update="Azure.ResourceManager.PostgreSql" Version="1.4.1" />
```

## Step 2: Run the Provisioning Generator

Navigate to the generator directory and run:

```shell
cd sdk/provisioning/Generator/src
dotnet run --framework net10.0 -- --filter {ServiceName}
```

For example:
```shell
dotnet run --framework net10.0 -- --filter PostgreSql
```

**Important:** The generator reads from NuGet packages, NOT local source code. The version in `eng/Packages.Data.props` determines which package version is used.

### Generator Errors

If the generator fails with errors:

1. **Capture the full error output** including stack traces and error messages
2. **Report the error to the user** with enough context to understand what went wrong
3. **Stop and let the user decide** how to proceed — generator errors often require code changes to the generator itself or the specification files, which may need human judgment

Do NOT attempt to automatically fix generator errors without user guidance.

## Step 3: Handle Breaking Changes

Compare the generated code with the previous version. Common breaking changes include:

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

## Step 4: Fix Spell Check Issues

If CI fails with "Unknown word" errors, add the words to `sdk/provisioning/cspell.yaml`:

```yaml
  - filename: '**/sdk/provisioning/Azure.Provisioning.{Service}/**/*.cs'
    words:
      - newword1
      - newword2
```

**Important:** Use `sdk/provisioning/cspell.yaml`, NOT `.vscode/cspell.json`.

## Step 5: Run Pre-Commit Checks

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

## Step 6: Export API and Update Snippets

```shell
pwsh eng\scripts\Export-API.ps1 provisioning
pwsh eng\scripts\Update-Snippets.ps1 provisioning
```

## Step 7: Commit and Push

Stage all changes and commit with a descriptive message:

```shell
git add -A
git commit -m "Regenerate Azure.Provisioning.{Service} from updated management library"
```

## Example: PostgreSQL Server Versions 17 and 18

Here's what was done to add PostgreSQL versions 17 and 18:

1. **Updated `eng/Packages.Data.props`**: Changed `Azure.ResourceManager.PostgreSql` from 1.3.1 to 1.4.1

2. **Ran generator**: `dotnet run --framework net10.0 -- --filter PostgreSql`

3. **Fixed generator issues**:
   - Added `#pragma warning disable CS0618` for obsolete `ActiveDirectoryAdministratorResource`
   - Fixed schema tree conflict in `Specification.Schema.cs`

4. **Handled breaking changes**:
   - Renamed `PrivateEndpointConnections` property via `CustomizeProperty`
   - Created backward-compatible old property via `DefineAdditionalProperties()`
   - Created obsolete stub for removed `PostgreSqlFlexibleServersPrivateEndpointConnectionData` type
   - Used `OrderEnum<PostgreSqlFlexibleServerVersion>()` to preserve enum ordinal values
   - Created `ApiCompatBaseline.txt` to suppress DataMember removal errors

5. **Fixed CI issues**:
   - Added "apsara", "dbrds", "ssdlrs" to `sdk/provisioning/cspell.yaml`
   - Fixed Kusto README missing `--prerelease` flag

6. **Ran pre-commit checks**: `pwsh eng\scripts\CodeChecks.ps1 -ServiceDirectory provisioning`

## Key Files

| File | Purpose |
|------|---------|
| `eng/Packages.Data.props` | Management library version |
| `sdk/provisioning/Generator/src/Specifications/{Service}Specification.cs` | Generator customizations |
| `sdk/provisioning/Generator/src/Model/Specification.Schema.cs` | Schema tree builder |
| `sdk/provisioning/Generator/src/Model/Specification.Customize.cs` | Customization API (`OrderEnum`, `CustomizeResource`, etc.) |
| `sdk/provisioning/Azure.Provisioning.{Service}/src/BackwardCompatible/` | Backward-compatible customizations |
| `sdk/provisioning/Azure.Provisioning.{Service}/src/ApiCompatBaseline.txt` | API compatibility suppressions |
| `sdk/provisioning/cspell.yaml` | Spell check configuration |

## Troubleshooting

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
