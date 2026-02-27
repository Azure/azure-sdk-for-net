# MPG Migration: Error Reference

Reference for build errors, ApiCompat errors, and common pitfalls encountered during management-plane SDK migration.

## Build Error Triage

For each build error, determine the root cause:

| Root Cause | Symptoms | Fix Location |
|-----------|----------|--------------|
| **TypeSpec issue** | Missing/wrong model, property, enum value, or operation in generated code that can be corrected by updating the `.tsp` spec | Spec repo |
| **Naming/accessibility mismatch** | CS0234 (type not found — renamed), CS0051 (internal type used in public Custom code) | `client.tsp` in spec repo (`@@clientName` / `@@access`) or `src/Customization/*.cs` in SDK |
| **Generator bug/gap** | Correct spec but wrong codegen output (e.g., missing serialization, wrong type mapping, incorrect inheritance) | `eng/packages/http-client-csharp-mgmt` in SDK repo |
| **Customization needed** | Breaking change from rename, removed property, or type change that needs a compatibility shim | `src/Customization/*.cs` in SDK package |

## Common Build Error Patterns

| Error Code | Typical Cause | Fix |
|-----------|--------------|-----|
| **CS0234** | Type name changed due to missing `@@clientName` rename | Add `@@clientName(SpecType, "OldSdkName", "csharp")` in `client.tsp`, regenerate |
| **CS0051** | Type became `internal` but Custom code references it publicly | First try `@@access(SpecType, Access.public, "csharp")` in `client.tsp`. If that doesn't work (common for nested/wrapper types), use `[CodeGenType("OriginalSpecName")]` in Custom code to override accessibility |
| **CS0246** | Type removed or restructured | Check if type was flattened, merged, or renamed. May need Custom code update |
| **CS0111** | Duplicate method/type definitions | For extension resources with parameterized scopes, check for duplicate resource entries. May need generator dedup fix |
| **CS1729/CS0029/CS1503** | Wrong REST client or type mismatch in collections | Sub-resource ops using `Read<>` template cause lifecycle misclassification. Fix by changing to `ActionSync<>` in spec (see the `mitigate-breaking-changes` skill, Extension Resources section) |
| **AZC0030** | Model name has forbidden suffix (`Request`, `Response`, `Parameters`) | Add `@@clientName` rename. Check old autorest SDK API surface for the **original name** to maintain backward compatibility, rather than inventing a new name |
| **AZC0032** | Model name has forbidden suffix (`Data`) not inheriting `ResourceData` | Add `@@clientName` rename to remove or replace the suffix |

## ApiCompat Error Patterns

ApiCompat compares the new generated API against the existing API surface files (`api/*.cs`). ApiCompat errors surface via `dotnet pack` (not `dotnet build`). **Do NOT use `ApiCompatBaseline.txt` to bypass breaking changes** — mitigate them with custom code instead.

| ApiCompat Error | Cause | Fix |
|----------------|-------|-----|
| **MembersMustExist** (method with different return type) | Generated method has different return type than old API (e.g., `Response<ReportList>` vs `Pageable<Report>`) | Use `[CodeGenSuppress("MethodName", typeof(ParamType))]` on the partial class to suppress the generated method, then provide a custom implementation with the old return type |
| **MembersMustExist** (missing extension method) | Old API had `GetXxx(ArmClient, ResourceIdentifier scope, string name)` but new only has `GetXxxResource(ArmClient, ResourceIdentifier id)` | Add custom extension methods that delegate to collection Get |
| **TypesMustExist** | Old API had a type that no longer exists (e.g., base class removed) | Create the type in Custom code with matching properties and `IJsonModel<>`/`IPersistableModel<>` serialization |
| **MembersMustExist** (property setter missing) | Generated property is get-only but old API had setter | Use `[CodeGenSuppress("PropertyName")]` and re-declare with `{ get; set; }` in custom partial class |

### Handling ApiCompat Errors in the Migration Flow

For each ApiCompat error:

1. **Missing member/type**: The old API had a public member that no longer exists. Determine why:
   - **Renamed**: Add `@@clientName` in `client.tsp` to restore the old name, or add a backward-compat wrapper in Custom code.
   - **Removed from spec**: If the member was removed in a newer API version, it may be acceptable. Document in CHANGELOG.
   - **Changed signature**: Add a Custom code overload with the old signature that delegates to the new one.
   - **Changed accessibility**: Use `@@access` or `[CodeGenType]` to restore public visibility.
2. After fixing all breaking changes, re-export the API surface:
   ```powershell
   pwsh eng/scripts/Export-API.ps1 <SERVICE_NAME>
   ```
   Where `<SERVICE_NAME>` is the service folder name under `sdk/` (e.g., `guestconfiguration`, NOT the full package name).
3. Verify the full build passes: `dotnet build`.

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
