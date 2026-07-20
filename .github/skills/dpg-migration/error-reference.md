# DPG Migration: Error Reference

Concise mapping from build errors to **data-plane migration** root causes and fixes. Copilot already understands C# error codes; this file only covers Azure SDK-specific patterns that commonly appear when moving from AutoRest/Swagger to TypeSpec-based generation.

## Build Error → Root Cause Decision Table

| Error | Migration-Specific Root Cause | Fix |
|-------|------------------------------|-----|
| **CS0234/CS0246** (type not found) | Custom code still references an old generated type name | Update the custom type or its `[CodeGenType]` target to the new generated name. If the public type name must stay stable, restore it with `@@clientName(..., "OldName", "csharp")` in the spec |
| **CS0111** (duplicate member) | Custom code and `Generated/` now both define the same member | Add or update `[CodeGenSuppress("Member", typeof(...))]` on the custom partial class, then regenerate |
| **CS1061/CS0103** (`_pipeline`, `FromCancellationToken`, `Fetch`) | Old helper members no longer exist in migrated code | Replace `_pipeline` with `Pipeline`, `FromCancellationToken(cancellationToken)` with `cancellationToken.ToRequestContext()`, and `Fetch(response)` with `Model.FromLroResponse(response)` |
| **CS0029/CS1503** around `RequestContent` | Input models no longer need `.ToRequestContent()` | Remove `.ToRequestContent()` and pass the model directly |
| **Missing `GeneratorPageableHelpers` / `CollectionResult` usage** | Pageable customization is stale or a required generated helper was suppressed | Use the generated `CollectionResult` type and remove the stale suppression/custom helper before regenerating |
| **CS0535 / CS0115** | A custom partial no longer matches the generated interfaces or override surface | Update the partial implementation to match the current generated members |

## Key Diagnosis Rules

- **Error in `src/Generated/`** → usually a spec issue or stale customization metadata; fix the spec or the customization, then regenerate
- **Error in `src/Custom*/`** → usually update custom code to use the new generated names and signatures
- **ApiCompat error** → fix with spec-side rename (`@@clientName`) when the type still exists under a new name, or with a backward-compat shim in custom code when the API truly changed
- **Structurally wrong generated code despite correct spec** → generator bug

## ApiCompat Error → Fix Table

ApiCompat errors surface via `dotnet pack --no-restore` or package validation. **Never use `ApiCompatBaseline.txt`** — always mitigate with spec changes or custom code.

| ApiCompat Error | Fix |
|----------------|-----|
| **MembersMustExist** (changed return type) | Add a forwarding overload or shim in custom code that preserves the old signature and delegates to the new one |
| **MembersMustExist** (missing setter) | `[CodeGenSuppress("Property")]` + re-declare the property with `{ get; set; }` in custom code |
| **TypesMustExist** (missing type) | `@@clientName` to restore the old name, or create a compatibility type in custom code with the matching public API |

After fixing all ApiCompat errors: `pwsh eng/scripts/Export-API.ps1 <SERVICE_NAME>`

## Generator Bug Detection

If an error does not match the table above, check if it is a generator bug:
1. Spec is correct and compiles cleanly
2. Generated code is structurally wrong, not just renamed
3. The issue is not fixable with ordinary spec customizations or SDK partial-class shims

After a generator fix: rebuild the emitter, regenerate the affected SDK with `dotnet build /t:GenerateCode`, then **clean up stale custom workarounds** that are now redundant.

## Common Pitfalls

1. **Use `dotnet build /t:GenerateCode`**, not `tsp-client update`.
2. **Don't blindly preserve every old customization** — many migration errors come from stale `CodeGenType` / `CodeGenSuppress` metadata that no longer matches the generated names.
3. **Don't hand-edit `metadata.json`** — it's auto-generated.
4. **File name casing mismatches** break Linux CI. After generation, check with `git ls-files` vs disk; fix with `git rm --cached` + `git add`.
5. **Match the existing custom code folder** — `Custom/`, `Customization/`, or `Customized/`.
6. **Run `CodeChecks.ps1` before pushing**: `pwsh eng\scripts\CodeChecks.ps1 -ServiceDirectory <service>`
7. **Finalize `tsp-location.yaml`** with the pushed spec commit SHA before creating the SDK PR. Do one final `dotnet build /t:GenerateCode` without `LocalSpecRepo`.
8. **Clean up stale custom workarounds after generator fixes** — remove `[CodeGenSuppress]` + manual implementations that are now redundant after regeneration.
