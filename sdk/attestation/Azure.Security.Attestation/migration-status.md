# Migration Status — Azure.Security.Attestation

**Type:** Data-plane (DPG) migration — AutoRest/Swagger → TypeSpec
**Branch (azure-sdk-for-net):** `dev/ksapathy/attestation-dataplane-2025-06-01`
**Spec repo:** `c:\src\azure-rest-api-specs` (branch `main`, `client.tsp` + `tspconfig.yaml` locally modified — uncommitted)
**Spec directory:** `specification/attestation/data-plane/Attestation`
**Target API version:** `2025-06-01`
**Last Updated:** 2026-07-03

> **▶ RESUME HERE:** Phase 5 (regenerate) is **done** — generation lands in `src/Generated`
> correctly. We are in **Phase 6 (build-fix cycle)**, working **Path 1** (preserve the GA public
> API surface). Currently applying **fix #1** (suppress the generated `AttestationClientOptions`
> ctor; decide DI-files keep/exclude). See **## Phase 6 — Build-fix cycle** below for the live
> error inventory and exact next action.
>
> **Working regen command** (local mode — required to pick up the uncommitted spec edits):
> ```powershell
> cd C:\src\azure-sdk-for-net\sdk\attestation\Azure.Security.Attestation\src
> dotnet build /t:GenerateCode /p:LocalSpecRepo="C:\src\azure-rest-api-specs\specification\attestation\data-plane\Attestation"
> ```
> **Note:** re-running GenerateCode restores `src/autorest.md` from git if it was checked out;
> delete it before generating (TypeSpec + autorest.md can't coexist in one project).

## Architecture (why it breaks)

**Old (AutoRest) design** — preserved public API:
- Low-level generated REST clients were **internal**: `AttestationRestClient`,
  `SigningCertificatesRestClient`, `PolicyRestClient`, `PolicyCertificatesRestClient`.
- Hand-written **public** convenience clients wrap them: `AttestationClient`,
  `AttestationAdministrationClient` — expose rich types (`AttestationResponse<T>`, etc.).
- `AttestationClientOptions` was **fully hand-written** (not generated), `ServiceVersion.V2020_10_01`.

**New (TypeSpec) generator output:**
- Emits **public** operation subclients named `Attestation`, `Policy`, `SigningCertificates`,
  `PolicyCertificates`, `TcbBaselines`, `MetadataConfiguration`.
- Emits a root `AttestationClient` (partial) with `GetXxxClient()` factory methods.
- Emits `AttestationClientOptions` (partial) with `ServiceVersion.V2025_06_01`.
- Response models (`PolicyResponse`, `JsonWebKeySet`, `PolicyCertificatesResponse`,
  `PolicyCertificatesModifyResponse`, …) are **internal**.

**The conflict / build failure (37 errors):**
| Errors | Codes | Cause |
|--------|-------|-------|
| Inconsistent accessibility (~31) | CS0050/CS0051 | Public generated subclient methods return internal models |
| Missing `*RestClient` types (4) | CS0246 | Custom code references legacy REST client names the new emitter renamed |
| Duplicate type, missing `partial` (2) | CS0260 | Hand-written `AttestationClient`/`AttestationClientOptions` not `partial`; generator now emits them too |
| Duplicate member `ServiceVersion` (implied) | CS0102 | Both hand-written and generated `AttestationClientOptions` define it |

## Fix strategy — "Option 1": keep generated clients internal

The spec `client.tsp` **already** implements this (local uncommitted edits):
- `@@access(<opClient>, Access.internal)` for all six operation clients.
- `@@clientName(<opClient>, "<Legacy>RestClient")` restores the names custom code uses.

### Phase 5 root cause + fix (RESOLVED)

The spec's **`tspconfig.yaml`** had **no options block** for the new emitter
`@azure-typespec/http-client-csharp`, so it fell back to the default `emitter-output-dir`
(`{output-dir}/@azure-typespec/http-client-csharp`) at the **repo root** and got no `namespace`
(which made it scaffold a generic `AttestationService` project and delete the real csproj/sln).

**Fix (local `tspconfig.yaml`, uncommitted — mirrors AnomalyDetector):** inserted before the
legacy `@azure-tools/typespec-csharp` block:
```yaml
  "@azure-typespec/http-client-csharp":
    emitter-output-dir: "{output-dir}/{service-dir}/{namespace}"
    namespace: "Azure.Security.Attestation"
    model-namespace: false
```
After this, `GenerateCode` in local mode lands output in `sdk/.../src/Generated`, keeps project
files intact, applies `client.tsp` renames, and generates internal methods/models. **This spec
edit must be committed to azure-rest-api-specs and the `commit` in `tsp-location.yaml` re-pinned
before the final PR (Phase 12).**

## Phase Tracker

**Legend:** ✅ Done | 🔄 In Progress | ❌ Blocked | ⏭️ Not Started

| Phase | Status | Notes |
|-------|--------|-------|
| 0 — Discovery | ✅ | `discover_project`: dpg, specs repo at `c:\src\azure-rest-api-specs` |
| 1 — Error analysis | ✅ | 37 errors classified (2 deterministic, 35 reasoning) |
| 2 — tsp-location.yaml | ✅ | Present; emitter path correct |
| 3 — Legacy config | ✅ | No `autorest.md`; `autorest.md.bak` present |
| 4 — client.tsp customizations | ✅ | **Fixed**: `@access` on interfaces is invalid in this TCGC version; rewrote to per-operation `@access(...op, Access.internal)`. Regen now compiles the spec cleanly. Local, uncommitted. |
| 5 — Regenerate (local mode) | ✅ | **FIXED**: added `@azure-typespec/http-client-csharp` block (`emitter-output-dir` + `namespace` + `model-namespace:false`) to the spec's `tspconfig.yaml`. Output now lands in `src/Generated`; project files intact; renames + internal access applied. Committed as `e1793b110ce`. |
| 6 — Build-fix cycle | 🔄 | **IN PROGRESS (Path 1 — preserve GA API).** `partial` added to `AttestationClient`/`AttestationClientOptions`/`AttestationModelFactory` (cleared CS0260, **uncommitted WIP**). Full build now shows **~236 errors / 10 codes** — this is a **2020-10-01 → 2025-06-01 model bump**. See table below. |
| 7 — Changelog | ⏭️ | |
| 8 — Test project build | ⏭️ | |
| 9 — Test execution | ⏭️ | |
| 10 — Finalization (Export-API, snippets) | ⏭️ | |
| 11 — ApiCompat reconciliation | ⏭️ | GA library — no baseline suppression allowed |
| 12 — Commit spec `client.tsp` + PRs | ⏭️ | Spec edits must be pushed & pinned in tsp-location.yaml |

## Known open items after regeneration

1. **`AttestationClientOptions`** — reconcile hand-written (public, `V2020_10_01`) vs generated
   (partial, `ServiceVersion.V2025_06_01`). Likely: make hand-written `partial`, drop duplicate
   `ServiceVersion`, map to the new enum. Preserve public ctor & `TokenOptions` API.
2. **`AttestationClient` root client** — generator emits a partial `AttestationClient` with
   `GetXxxClient()` factories that conflicts with the hand-written public client. Decide: make
   hand-written `partial` and coexist, or suppress the generated root client. Must preserve the
   shipped public surface (ApiCompat).
3. **ApiCompat** — GA library; validate no breaking changes, add shims under `Custom/BackwardCompat/`
   if needed. Never edit a baseline file.
4. **Push spec `client.tsp`** and update `tsp-location.yaml` `commit` to the merged SHA before final PR.

## Phase 6 — Build-fix cycle (LIVE)

**Decision: Path 1** — reshape generated code (via `client.tsp` decorators + C#
`[CodeGenMember]`/`[CodeGenSuppress]` customizations) to **preserve the existing GA public API**.
Do **not** rewrite the hand-written convenience layer to new models (that would be an ApiCompat
break). Custom code folder: `Custom/BackwardCompat/`.

**Live error inventory** (after `partial` fixes; from `dotnet build` in `src/`): **~236 errors**

| # | Root cause | ~Errors | Codes | Fix approach (Path 1) |
|---|-----------|--------:|-------|-----------------------|
| A | `JsonWebKey` props renamed / read-only (`X5C`→`X5c`; `Alg`/`Use`/`X5c` read-only) | ~30 | CS1061, CS0200 | `client.tsp` `@@clientName` to restore casing; `[CodeGenMember]` or writable ctor for setters |
| B | `AttestationResult` old props now `[Obsolete]` (`DeprecatedSvn`/`DeprecatedTee`/…) | ~78 | CS0618 | Update custom refs to new names, or suppress-and-shim; treat as non-breaking rename |
| C | Generated model props read-only (factory/custom setters break) | ~62 | CS0200 | Use generated ctors / model-factory; `[CodeGenMember]` for writable where needed |
| D | REST client sig changes (`CancellationToken`→`RequestContext`; model→`RequestContent`; `string`→`Uri`) | ~40 | CS1503, CS1729, CS7036 | Update internal call sites in convenience clients to new protocol signatures |
| E | `DataType.Json` removed; `InitTimeData` `byte[]`→`BinaryData` | ~22 | CS0117, CS0029 | Map to new `DataType`/`BinaryData`; shim in custom code |
| F | `AttestationClientOptions` ambiguous ctor + DI `ExperimentalAttribute`/`SCME0002` | ~10 | CS0121, CS0122 | **fix #1 (current)**: `[CodeGenSuppress]` generated ctor; keep/exclude DI files |
| G | `AttestationSigner.DeserializeAttestationSigner` missing | 4 | CS0117 | Restore via `[CodeGenMember]` or custom deserialization |

### Immediate next action (fix #1 — COMPLETE)
1. ✅ **fix #1a (uncommitted):** `[Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("AttestationClientOptions", typeof(ServiceVersion))]`
   on the hand-written `AttestationClientOptions` partial (fully-qualified to avoid CS0104 vs
   `Azure.Core.CodeGenSuppressAttribute`). Suppresses generated single-arg ctor (clears 9× CS0121
   on next regen).
2. ✅ **fix #1b — DI files (RESOLVED via compile, defer surface decision):** "Exclude" proved
   entangled — the DI ctors are woven into the core `AttestationClient`/`AttestationClientOptions`
   partials and reference `AttestationClientSettings` (so `[CodeGenSuppress]` is circular), and the
   emitter has no skip-DI option. **Decision:** added `ExperimentalAttribute.cs` Azure.Core shared
   source to the csproj (same as AnomalyDetector) so DI **compiles**. Whether to **exclude the DI
   types from the shipped public surface** is deferred to **Phase 10/11 (ApiCompat)** where it's
   enforced via `api/*.cs` — clean to do once the build is green. (AnomalyDetector *ships* DI as
   `[Experimental]` public, so keeping is also acceptable.)
3. 🔜 **NEXT:** work model-shape groups via `client.tsp`/customizations, **batched**, then regen once.

### Live error counts (after fix #1; `dotnet build` in `src/`) — ~348 total
| Code | Count | Group |
|------|------:|-------|
| CS0618 | 117 | B (obsolete `AttestationResult.Deprecated*` refs) |
| CS0200 | 93 | C (read-only generated props assigned in custom/factory code) |
| CS1503 | 45 | D (arg type: `CancellationToken`→`RequestContext`, model→`RequestContent`, `string`→`Uri`) |
| CS1061 | 27 | A (`JsonWebKey.X5C` etc. missing/renamed) |
| CS0117 | 21 | E/G (`DataType.Json`, `DeserializeAttestationSigner` missing) |
| CS0029 | 18 | E (`byte[]`→`BinaryData`) |
| CS0121 | 9 | F (options ctor ambiguity — **clears on regen** via #1a) |
| CS1729 | 9 | D (ctor arity changes) |
| CS7036 | 9 | D (required param now missing) |

> Counts rose vs. the first look because clearing the DI/attribute errors let the compiler proceed
> and surface previously-masked downstream model errors. Expected.

### Confirmed generated shapes (for Path 1 `@@clientName`/`[CodeGenMember]` work)
- **Group A — `JsonWebKey`** (generated): `Alg {get;}`, `Use {get;}`, `Kid {get;}`, `Kty {get;}`,
  `X5c {get;}` (**was `X5C`** — casing changed), all **read-only**. Custom code uses `key.X5C` +
  writes `Alg`/`Use`/`X5c`. Restore casing via `@@clientName(JsonWebKey.x5c, "X5C", "csharp")`;
  writable props via `[CodeGenMember]` or model-factory paths.
- **Group G — `AttestationSigner`**: custom code calls `AttestationSigner.DeserializeAttestationSigner`
  (no longer generated). Restore via `[CodeGenMember]`/custom deserialization.

### After the build is green
- Phase 7 changelog, Phase 8 test csproj build, Phase 9 tests, Phase 10 Export-API + snippets,
  Phase 11 **ApiCompat** (GA — no baseline suppression), Phase 12 push spec `client.tsp` +
  `tspconfig.yaml` and re-pin `commit`.

## Git safety points (revert experiment)

- **`checkpoint-raw-typespec`** (tag) = the original "raw TypeSpec generation (not building)"
  checkpoint commit `d07f9407980`.
- Current HEAD = a `git revert` of that checkpoint → restores the pre-checkpoint **AutoRest**
  state, which **builds cleanly (0 errors, incl. tests)**.
- **Jump back to the checkpoint:** `git reset --hard checkpoint-raw-typespec`
  (or `git revert --no-edit HEAD` to re-apply the checkpoint on top).
