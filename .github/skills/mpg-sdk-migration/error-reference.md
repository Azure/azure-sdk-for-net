# MPG Migration: Error Reference

Concise mapping from build errors to **mgmt-migration-specific** root causes and fixes. Copilot already understands C# error codes — this file only covers the Azure SDK-specific diagnosis and fix patterns.

## Build Error → Root Cause Decision Table

| Error | Migration-Specific Root Cause | Fix |
|-------|------------------------------|-----|
| **CS0234/CS0246** (type not found) | Type was renamed by new generator. Compare old name in `api/*.cs` with new names in `src/Generated/` | `@@clientName(SpecNamespace.NewName, "OldName", "csharp")` in `client.tsp`. OR update custom code to use new name |
| **CS0051/CS0122** (inaccessible type) | Type generated as `internal` but custom code uses it publicly | Try `@@access(SpecNamespace.Type, Access.public, "csharp")` in `client.tsp` first. If ineffective (common for nested types), use `[CodeGenType("SpecName")]` in custom code |
| **CS0111** (duplicate member) | Custom code and Generated/ both define same member; or extension resource with duplicate scope entries | Add `[CodeGenSuppress("Member", typeof(...))]` to custom partial class |
| **CS1729/CS0029/CS1503** (type mismatch) | Property uses wrong type (e.g., `string` instead of `ResourceIdentifier`), or sub-resource using `Read<>` template causes wrong REST client | `@@alternateType(SpecNamespace.Model.property, "ArmType", "csharp")` for type mapping overrides. For wrong REST client: change `Read<>` to `ActionSync<>` with `@get` in spec. OR update custom code constructor calls to match new signature |
| **CS0535** (interface not implemented) | Custom type needs `IJsonModel<T>`/`IPersistableModel<T>` after migration | Add missing interface methods in custom partial class |
| **CS0115** (no method to override) | Custom code overrides a method that was renamed/removed in new generated code | Update override to match new method name, or remove override |
| **AZC0030** (forbidden suffix: Request/Response/Parameters) | Azure SDK naming analyzer rejects generated name | `@@clientName` to old name from `api/*.cs`, or rename per convention: Request→Content, Response→Result, Parameters→Content |
| **AZC0032** (forbidden 'Data' suffix) | Type ends with `Data` but doesn't inherit `ResourceData` | `@@clientName` to old name, or rename to `*Info` |

### Key Diagnosis Rules

- **Error in `src/Generated/`** → almost always a spec fix (`@@clientName` or `@@access` in `client.tsp`)
- **Error in `src/Custom*/`** → either update custom code to use new names, or add `@@clientName` to preserve old names
- **ApiCompat error** → fix via spec-side rename (`@@clientName`) when the type still exists under a new name, or via custom code shim when the API truly changed (never use `ApiCompatBaseline.txt`)
- **Structurally wrong generated code despite correct spec** → generator bug

## ApiCompat Error → Fix Table

ApiCompat errors surface via `dotnet pack --no-restore` (not `dotnet build`). **Never use `ApiCompatBaseline.txt`** — always mitigate with custom code.

| ApiCompat Error | Fix |
|----------------|-----|
| **MembersMustExist** (changed return type) | `[CodeGenSuppress("Method", typeof(...))]` + custom implementation with old return type delegating to new method |
| **MembersMustExist** (missing extension method) | Add custom extension method delegating to collection Get |
| **MembersMustExist** (missing setter) | `[CodeGenSuppress("Property")]` + re-declare with `{ get; set; }` in custom code |
| **TypesMustExist** (missing type) | `@@clientName` to restore old name, or create type in custom code with matching public API |

After fixing all ApiCompat errors: `pwsh eng/scripts/Export-API.ps1 <SERVICE_NAME>`

## Generator Bug Detection

If an error doesn't match the table above, check if it's a generator bug:
1. Spec is correct (`npx tsp compile .` succeeds, models look right)
2. Generated code is structurally wrong (not just naming)
3. Not fixable with `@@clientName`/`@@access`/`@@markAsPageable`/`@@alternateType`

**Fix generator** when: bug affects multiple SDKs, fix is straightforward.
**Workaround with custom code** when: one-off issue, complex generator fix, time pressure. Use `[CodeGenSuppress]` + custom implementation, document the workaround.

After generator fix: regenerate with `RegenSdkLocal.ps1`, then **clean up stale custom workarounds** that are now redundant.

## Common Pitfalls

1. **Use `dotnet build /t:GenerateCode`**, not `tsp-client update`. The latter may ignore `@@clientName`/`@@access` decorators.
2. **Don't blindly copy all `rename-mapping` from `autorest.md`** — only add `@@clientName` for names that actually cause build errors after generation. The emitter auto-handles these transforms: `Url`→`Uri`, `Etag`→`ETag`, DateTimeOffset suffixes (`Time`/`Date`/`DateTime`/`At`→`On`, plus `Creation`→`Created`, `Deletion`→`Deleted`, `Expiration`→`Expire`, `Modification`→`Modified`), RP prefix for `Sku`/`SkuName`/`SkuTier`/`SkuFamily`/`SkuInformation`/`Plan`/`Usage`/`Kind`/`PrivateEndpointConnection`/`PrivateLinkResource`/related types, and resource update model naming (`Patch`/`CreateOrUpdateContent`).
3. **Don't hand-edit `metadata.json`** — it's auto-generated.
4. **`@@access` may not work for nested types** — fall back to `[CodeGenType]` in custom code.
5. **`@@markAsPageable` fails on `@list` operations** — check spec before adding; only use for truly non-pageable operations.
6. **Use `@@markAsPageable` instead of custom `SinglePagePageable` wrappers** — cleaner, less custom code.
7. **Sub-resource operations must NOT use `Read<>`** — use `ActionSync<>` with `@get` to avoid lifecycle misclassification.
8. **File name casing mismatches** break Linux CI. After generation, check with `git ls-files` vs disk; fix with `git rm --cached` + `git add`.
9. **Match existing custom code folder** — `Custom/`, `Customization/`, or `Customized/`.
10. **Run `CodeChecks.ps1` before pushing**: `pwsh eng\scripts\CodeChecks.ps1 -ServiceDirectory <service>`
11. **Finalize `tsp-location.yaml`** with pushed spec commit SHA before creating PR. Do one final `dotnet build /t:GenerateCode` without `LocalSpecRepo`.
12. **Clean up stale custom workarounds after generator fixes** — remove `[CodeGenSuppress]` + manual implementations that are now redundant after regeneration.
