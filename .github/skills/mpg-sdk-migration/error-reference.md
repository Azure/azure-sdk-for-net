# MPG Migration: Error Reference

Reference for build errors, ApiCompat errors, and common pitfalls encountered during management-plane SDK migration. Each error pattern includes an **autonomous fix recipe** that Copilot can follow without user input.

## Build Error Triage

For each build error, determine the root cause:

| Root Cause | Symptoms | Fix Location |
|-----------|----------|--------------|
| **TypeSpec issue** | Missing/wrong model, property, enum value, or operation in generated code that can be corrected by updating the `.tsp` spec | Spec repo |
| **Naming/accessibility mismatch** | CS0234 (type not found — renamed), CS0051 (internal type used in public Custom code) | `client.tsp` in spec repo (`@@clientName` / `@@access`) or `src/Customization/*.cs` in SDK |
| **Generator bug/gap** | Correct spec but wrong codegen output (e.g., missing serialization, wrong type mapping, incorrect inheritance) | `eng/packages/http-client-csharp-mgmt` in SDK repo |
| **Customization needed** | Breaking change from rename, removed property, or type change that needs a compatibility shim | `src/Customization/*.cs` in SDK package |

## Common Build Error Patterns

### CS0234 — Type or namespace not found (renamed type)

**Detection**: `error CS0234: The type or namespace name 'XxxType' does not exist in the namespace`

**Autonomous Fix**:
1. Extract the missing type name from the error message (e.g., `FooBarModel`)
2. Search old API surface: `grep -r "FooBarModel" api/`
3. Search new generated code for similar names: `ls src/Generated/Models/ | grep -i foobar`
4. IF a match with different name exists (e.g., `FooBarModelInfo`):
   - Determine the spec name by reading the generated file's `[CodeGenSerialization]` or class comments
   - Add to `client.tsp`: `@@clientName(SpecNamespace.NewSpecName, "OldSdkName", "csharp");`
5. IF the type is referenced only in custom code and renaming makes the custom code cleaner:
   - Update the custom code to use the new name instead
6. Regenerate and rebuild

**Example**:
```
error CS0234: The type or namespace name 'ChaosTargetType' does not exist in the namespace 'Azure.ResourceManager.Chaos.Models'
```
→ Generated code has `ChaosTargetTypeInfo`. Add: `@@clientName(Microsoft.Chaos.TargetType, "ChaosTargetType", "csharp");`

### CS0051 / CS0122 — Inaccessible type (internal vs public)

**Detection**: `error CS0051: Inconsistent accessibility` or `error CS0122: is inaccessible due to its protection level`

**Autonomous Fix**:
1. Identify the internal type from the error message
2. Find its spec name by searching `src/Generated/Internal/` for the type
3. **Try spec-side fix first**:
   - Add to `client.tsp`: `@@access(SpecNamespace.SpecTypeName, Access.public, "csharp");`
   - Regenerate and rebuild
4. **If @@access didn't work** (common for nested/wrapper types, types inside `Internal/` folder):
   - Create a custom code file:
   ```csharp
   // src/Customization/Models/TypeName.cs
   using Microsoft.TypeSpec.Generator.Customizations;

   namespace Azure.ResourceManager.<Service>.Models
   {
       [CodeGenType("OriginalSpecTypeName")]
       public partial class TypeName
       {
       }
   }
   ```
   - Rebuild (no regeneration needed)

**How to find OriginalSpecTypeName**: Open the generated internal file under `src/Generated/Internal/` — the class name or `[CodeGenSerialization]` attribute reveals the original spec name.

### CS0246 — Type or namespace could not be found

**Detection**: `error CS0246: The type or namespace name 'Xxx' could not be found`

**Autonomous Fix**:
1. IF the type was in a different namespace that's no longer imported:
   - Add the correct `using` statement to the custom code file
2. IF the type was removed or restructured in the new spec:
   - Check if the type was flattened into a parent model
   - Check if it was merged with another type
   - Check if it was renamed (treat as CS0234)
3. IF the type is defined in custom code that references old generated types:
   - Update custom code references to use new type names
4. Regenerate if spec was changed, rebuild

### CS0111 — Duplicate method or type definition

**Detection**: `error CS0111: Type 'X' already defines a member called 'Y'`

**Autonomous Fix**:
1. Check if both `Generated/` and `Custom/` define the same member
2. IF custom code intentionally overrides a generated member:
   - Add `[CodeGenSuppress("MemberName", typeof(ParamType1), ...)]` to the custom partial class
   - Rebuild
3. IF duplicate arises from extension resource with multiple scope entries:
   - This is a known generator issue with `MockableArmClient` — check for duplicate `GetXxxResource()` methods
   - Add `[CodeGenSuppress]` for the duplicate in custom code
4. Rebuild

### CS1729 / CS0029 / CS1503 — Constructor or type mismatch

**Detection**: `error CS1729: 'X' does not contain a constructor`, `error CS0029: Cannot implicitly convert`, `error CS1503: cannot convert from 'X' to 'Y'`

**Autonomous Fix**:
1. IF error is in a resource collection class referencing wrong REST client:
   - Check if a sub-resource operation uses `Read<>` template in the spec
   - Fix: Change `Read<>` to `ActionSync<>` with `@get` in the spec
   - Regenerate and rebuild
2. IF error is in custom code calling an old constructor:
   - Check the new generated constructor signature
   - Update custom code to match the new signature
   - Rebuild
3. IF error involves collection type mismatch (e.g., `Pageable<X>` vs `Response<XList>`):
   - Check if `@@markAsPageable` is needed (see AZC pageable section)
   - Or add custom code with `[CodeGenSuppress]` + wrapper method

### AZC0030 — Forbidden model suffix

**Detection**: `error AZC0030: The model name 'XxxRequest' ends with a forbidden suffix`

**Autonomous Fix**:
1. Parse the forbidden type name and suffix from the error
2. Look up what the type was called in the old API: `grep "class Xxx" api/*.cs`
3. IF old name exists → use old name via `@@clientName`
4. IF new type (no old name):
   - `*Request` → rename to `*Content`
   - `*Response` → rename to `*Result`
   - `*Parameters` → rename to `*Content`
5. Add to `client.tsp`: `@@clientName(SpecNamespace.SpecTypeName, "NewName", "csharp");`
6. Regenerate and rebuild

### AZC0032 — Forbidden 'Data' suffix

**Detection**: `error AZC0032: The model name 'XxxData' ends with 'Data' but does not inherit from ResourceData`

**Autonomous Fix**:
1. Check old API for the previous name
2. IF old name exists → use old name via `@@clientName`
3. IF new type → rename to `*Info` or another appropriate suffix
4. Add `@@clientName` to `client.tsp`, regenerate and rebuild

### CS0535 — Interface member not implemented

**Detection**: `error CS0535: 'X' does not implement interface member 'Y'`

**Autonomous Fix**:
1. IF the interface is `IJsonModel<T>` or `IPersistableModel<T>`:
   - This usually means a custom type needs serialization
   - Check if the type used to be generated but now needs custom implementation
   - Add the missing interface methods in the custom partial class
2. IF the interface is from a base class change:
   - Update custom code to implement the required members
3. Rebuild

### CS0115 — No suitable method to override

**Detection**: `error CS0115: no suitable method found to override`

**Autonomous Fix**:
1. The custom code overrides a method that no longer exists in the generated base class
2. Check if the method was renamed or removed in the new generated code
3. IF renamed: Update the custom code to override the new method name
4. IF removed: Remove the override from custom code, or add `[CodeGenSuppress]` for the old method and implement fresh
5. Rebuild

## ApiCompat Error Patterns

ApiCompat compares the new generated API against the existing API surface files (`api/*.cs`). ApiCompat errors surface via `dotnet pack` (not `dotnet build`). **Do NOT use `ApiCompatBaseline.txt` to bypass breaking changes** — mitigate them with custom code instead.

### MembersMustExist — Method with different return type

**Detection**: `MembersMustExist : Member 'X.Method(...)' does not exist`

**Autonomous Fix**:
1. Compare the old method signature (from ApiCompat error) with the new generated method
2. IF return type changed (e.g., `Response<ReportList>` → `Pageable<Report>`):
   - Add `[CodeGenSuppress("MethodName", typeof(ParamType1), typeof(ParamType2))]` on the partial class
   - Provide a custom implementation with the old return type that delegates to the new method
3. IF parameter types changed:
   - Add backward-compat overload in custom code with old signature
   - Delegate to the new generated method

**Example**:
```csharp
// src/Customization/MyResource.cs
public partial class MyResource
{
    [CodeGenSuppress("GetReport", typeof(CancellationToken))]
    public virtual Response<ReportData> GetReport(CancellationToken cancellationToken = default)
    {
        // Delegate to new generated method with adapted return type
    }
}
```

### MembersMustExist — Missing extension method

**Detection**: `MembersMustExist : Member 'Extensions.GetXxx(ArmClient, ResourceIdentifier, ...)'`

**Autonomous Fix**:
1. The old API had `GetXxx(ArmClient, ResourceIdentifier scope, string name)` convenience methods
2. New generator may only produce `GetXxxResource(ArmClient, ResourceIdentifier id)`
3. Add custom extension methods that delegate to the collection's Get:
```csharp
// src/Customization/Extensions.cs
public static partial class MyExtensions
{
    public static Response<MyResource> GetXxx(this ArmClient client, ResourceIdentifier scope, string name, CancellationToken cancellationToken = default)
    {
        return client.GetMyResources(scope).Get(name, cancellationToken);
    }
}
```

### MembersMustExist — Missing property setter

**Detection**: `MembersMustExist : Member 'X.Property.set'`

**Autonomous Fix**:
1. The generated property is get-only but old API had a setter
2. Use `[CodeGenSuppress("PropertyName")]` on the partial class
3. Re-declare the property with `{ get; set; }` in custom code
4. Rebuild

### TypesMustExist — Missing type

**Detection**: `TypesMustExist : Type 'Namespace.TypeName' does not exist`

**Autonomous Fix**:
1. Determine why the type no longer exists:
   - **Renamed**: Add `@@clientName` in `client.tsp` to restore old name
   - **Removed from spec**: Create the type in custom code with matching public API
   - **Merged into another type**: Add a type alias or backward-compat wrapper
2. IF the type needs serialization (`IJsonModel<T>`, `IPersistableModel<T>`):
   - Create a minimal implementation that delegates to the replacement type
3. Rebuild

### Handling ApiCompat Errors in the Migration Flow

For each ApiCompat error:

1. **Run `dotnet pack --no-restore`** to surface all ApiCompat errors at once
2. **Collect all errors** into the build_errors SQL table with root_cause='customization'
3. **For each error**, apply the autonomous fix recipe above
4. After fixing all breaking changes, re-export the API surface:
   ```powershell
   pwsh eng/scripts/Export-API.ps1 <SERVICE_NAME>
   ```
   Where `<SERVICE_NAME>` is the service folder name under `sdk/` (e.g., `guestconfiguration`, NOT the full package name).
5. Verify the full build passes: `dotnet build`

## Generator Bug Detection

When build errors don't match any of the patterns above, the issue may be in the generator. Use this checklist to confirm:

### Is it a generator bug?

```
1. The spec is correct:
   - `npx tsp compile .` succeeds in the spec directory
   - The model/operation looks correct in the spec
   - Other language generators produce correct output (if known)

2. The generated code is structurally wrong:
   - Missing serialization methods
   - Wrong inheritance chain
   - Incorrect type mapping (e.g., string instead of enum)
   - Missing or extra properties
   - Wrong REST operation mapping

3. The issue is NOT fixable with spec decorators:
   - @@clientName, @@access, @@markAsPageable won't help
   - The problem is in HOW the code is generated, not WHAT is generated
```

### Generator fix vs workaround decision

```
FIX THE GENERATOR when:
  - The bug is reproducible across multiple SDKs
  - The fix is straightforward (< 50 lines of generator code)
  - Not fixing would require complex workarounds in every affected SDK

WORKAROUND WITH CUSTOM CODE when:
  - The bug only affects this one SDK
  - The generator fix would be complex or risky
  - A simple [CodeGenSuppress] + custom implementation resolves it
  - Time pressure — workaround is faster than understanding the generator

After choosing workaround:
  - Document the issue in a code comment
  - Consider filing a GitHub issue for the generator bug
```

## Common Pitfalls

1. **Do NOT use `tsp-client update` for code generation.** Use `dotnet build /t:GenerateCode`. The former can produce different output and `@@clientName`/`@@access` decorators may not take effect.

2. **Do NOT compare only file names after generation.** The generated file names may be identical between old and new, but **file contents** change significantly (thousands of lines). Always use `git diff --stat` to verify content changes.

3. **Do NOT blindly copy all `rename-mapping` entries from `autorest.md` to `client.tsp`.** The mgmt emitter automatically handles many renames (RP prefix, acronym casing, `Is*` booleans). Compare old vs new generated types to find only the missing renames.

4. **Do NOT hand-author or manually edit `metadata.json`.** It is auto-generated by the tooling during code generation. Always include the auto-generated file in your PR.

5. **`@@access` may not work for all types.** Some types nested inside other models (e.g., `VolumePropertiesExportPolicy`) may not respond to `@@access` decorators. In those cases, update the Custom code instead.

6. **Custom code (`src/Custom/`) often references old type names.** After migration, scan Custom code for references to renamed or removed types. Common fixes: update type references, or add `@@clientName` to preserve the old name.

7. **Build errors cascade.** A single missing rename can cause dozens of errors. Fix one error at a time, rebuild, and re-assess — many errors may resolve together.

8. **Do NOT use `ApiCompatBaseline.txt` to bypass breaking changes.** Always mitigate breaking changes with custom code (`[CodeGenSuppress]`, partial classes, wrapper methods). The baseline should only be used as a last resort for changes that are truly impossible to fix.

9. **Use `dotnet pack` (not just `dotnet build`) to check ApiCompat errors.** API compatibility checks only run during pack. Run `dotnet pack --no-restore` to catch breaking changes early.

10. **Check the custom code folder name.** Different SDKs use different conventions: `Custom/`, `Customized/`, or `Customization/`. Always match the existing convention in the package.

11. **Sub-resource operations must NOT use `Read<>` template.** When a TypeSpec spec defines sub-resource Get operations using `Read<>` or `Extension.Read<>`, the ARM library treats them as lifecycle read operations, causing wrong REST client selection. Use `ActionSync<>` with `@get` instead. See the `mitigate-breaking-changes` skill, Extension Resources section.

12. **Use `@@markAsPageable` instead of custom `SinglePagePageable` wrappers.** When the old SDK returned `Pageable<T>` for a non-pageable list operation, prefer adding `@@markAsPageable(Interface.operation, "csharp")` in `client.tsp` over writing custom `[CodeGenSuppress]` + `SinglePagePageable<T>` wrapper code. This reduces custom code and produces a cleaner generated implementation.

13. **File name casing mismatches between Windows and Linux CI.** The TypeSpec code generator may produce file names with different casing than what git tracks (e.g., `GuestConfigurationHcrpAssignmentsRestOperations.cs` in git vs `GuestConfigurationHCRPAssignmentsRestOperations.cs` on disk). On Windows (case-insensitive) this is invisible, but on Linux CI these are treated as **different files** — CI sees the old lowercase file as "deleted" and the new uppercase file as "untracked", causing the "Generated code is not up to date" error. **Fix**: After code generation, check for casing mismatches with:
    ```powershell
    git ls-files "sdk/<service>/<PACKAGE_NAME>/src/Generated/" | ForEach-Object {
        $filename = Split-Path $_ -Leaf
        $dir = Split-Path $_ -Parent
        $diskFile = Get-ChildItem -LiteralPath (Join-Path (Get-Location) $dir) -Filter $filename -ErrorAction SilentlyContinue
        if ($diskFile -and ($diskFile.Name -cne $filename)) {
            Write-Host "MISMATCH: git='$filename' disk='$($diskFile.Name)' in $dir"
        }
    }
    ```
    Fix each mismatch with `git rm --cached <old-cased-path>` then `git add <new-cased-path>`.

14. **`@@markAsPageable` is ineffective on operations already marked with `@list`.** If a TypeSpec operation is already decorated with `@list` (making it pageable), adding `@@markAsPageable` is redundant and will cause a compile error: `@markAsPageable decorator is ineffective since this operation is already marked as pageable with @list decorator`. Before adding `@@markAsPageable`, check whether the target operation already has `@list` in its spec definition. Only add `@@markAsPageable` for operations that are truly non-pageable in the spec.

15. **Always run `CodeChecks.ps1` locally before pushing.** The CI "Verify Generated Code" step runs `eng\scripts\CodeChecks.ps1 -ServiceDirectory <service>`, which regenerates code, updates snippets, re-exports API, and does `git diff --exit-code`. Run this locally to catch issues before CI:
    ```powershell
    pwsh eng\scripts\CodeChecks.ps1 -ServiceDirectory <service>
    ```
    This is the single most reliable way to verify your changes will pass the "Build Analyze PRBatch" CI check.

16. **Finalize `tsp-location.yaml` before creating the PR.** When using `LocalSpecRepo` for fast iteration, it's easy to forget to update `tsp-location.yaml` with the final commit SHA. Before creating the PR: (a) commit and push all spec changes, (b) get the final commit SHA, (c) update `tsp-location.yaml` with that SHA, and (d) do one final `dotnet build /t:GenerateCode` **without** `LocalSpecRepo` to verify CI-reproducible generation.

17. **Clean up stale custom workarounds after generator fixes.** When a generator bug is fixed and the SDK is regenerated with `RegenSdkLocal.ps1`, any custom code workarounds that were added earlier for the same issue (e.g., `[CodeGenSuppress]` + manual implementations) become stale. These must be removed after regeneration — otherwise they cause `CS0111` (duplicate definition) errors or silently override the now-correct generated code. After each generator fix + regeneration cycle, search custom code for `[CodeGenSuppress]` attributes referencing the fixed member and remove them along with the manual implementation.
