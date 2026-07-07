# Migration Status — Azure.Security.Attestation

**Type:** Data-plane (DPG) migration — AutoRest/Swagger → TypeSpec
**Branch (azure-sdk-for-net):** `dev/ksapathy/attestation-dataplane-2025-06-01`
**Spec repo:** `c:\src\azure-rest-api-specs` (branch `main`, `client.tsp` + `tspconfig.yaml` locally modified — uncommitted)
**Spec directory:** `specification/attestation/data-plane/Attestation`
**Target API version:** `2025-06-01`
**Last Updated:** 2026-07-03

> **▶ RESUME HERE:** **src + tests build clean; ApiCompat passes; unit tests 18/20 pass.** The 2
> failures are `GetCertificates` `[RecordedTest]` **stale-recording** mismatches (playback can't match
> the new pipeline's request; re-record needs live creds — do during PR validation, NOT a code bug).
> **NEXT ACTION:** Phase 7 (changelog), Phase 10 (Export-API.ps1 + Update-Snippets.ps1), then Phase 12
> (push spec `client.tsp`/`tspconfig.yaml` to azure-rest-api-specs, re-pin `tsp-location.yaml` commit,
> final remote-mode regen). Also run `dotnet format` / pre-commit checks before the PR.
>
> **What was done (fix #3 — the 2020→2025 model bump, Path 1 / C-1 modernize):** reintroduced all 25
> custom `Models/*.cs` modernized to the new emitter — `[CodeGenModel]`→`[CodeGenType]`, deleted
> redundant `[CodeGenMember]` renames (generator now emits rich `BinaryData`/`AttestationSigner`/
> `Deprecated*` members), `X5C`→`X5c`, `DataType.Json`→`DataType.JSON`, `byte[]`→`BinaryData`.
> Rewrote convenience clients (`AttestationClient`/`AttestationAdministrationClient`) to the new REST
> protocol **spread overloads** (`AttestSgxEnclave(quote, runtimeData, initTimeData, draftPolicy, …)`,
> `Uri` ctors). Rewrote `AttestationModelFactory` to new ctor shapes. Added serialization for the
> hand-written `AttestationSigner` (`DeserializeAttestationSigner` + `IJsonModel`). Forced emission of
> 4 JWT-token-body models via `client.tsp` `@@access(..., Access.public)` + `@@usage(TpmAttestationRequest,
> Usage.input)`. ApiCompat: re-added **nested** `[JsonConverter]` converters (bridge to `IJsonModel`)
> on `AttestationResult`/`PolicyModificationResult`/`PolicyCertificatesModificationResult`, and restored
> `PolicyCertificatesModificationResult` public ctor + settable props.
>
> **⚠ Uncommitted spec edits (must be pushed in Phase 12):** `client.tsp` now also has 4 `@@access`
> + 1 `@@usage` lines appended (force-emit token-body models); `tspconfig.yaml` emitter block. These
> live in `C:\src\azure-rest-api-specs` and must be committed there, then `tsp-location.yaml` `commit`
> re-pinned.
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
| 6 — Build-fix cycle | ✅ | **DONE.** Full model-bump reconciled (Path 1 / C-1). `src` builds clean across all TFMs. See fix #3 parts 1–4 below. |
| 7 — Changelog | ⏭️ | |
| 8 — Test project build | ✅ | **DONE.** `tests` build clean. Suppressed generated model-factory overloads that clashed with shipped custom signatures; dropped stale `Azure.Security.Attestation.Models` using in samples. |
| 9 — Test execution | ✅ | **18/20 pass.** Fixed `TestGetAttestationResult` (int64 timestamps + decoupled `object Confirmation`). 2 remaining failures = `GetCertificates` stale-recording (needs live re-record; not a code bug). |
| 10 — Finalization (Export-API, snippets) | ⏭️ | |
| 11 — ApiCompat reconciliation | ✅ | **DONE** (with src build). Nested `[JsonConverter]` restored; `PolicyCertificatesModificationResult` ctor/setters restored. GA — no baseline suppression used. |
| 12 — Commit spec `client.tsp` + PRs | ⏭️ | Spec edits (`client.tsp` @@access/@@usage + `tspconfig.yaml`) must be pushed & pinned in tsp-location.yaml |

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

### fix #2 — Group B (CS0618) ✅ DONE (uncommitted, committed in e4fbbccd6a0)
The 117 CS0618 were **entirely inside generated `AttestationResult(.Serialization).cs`** — the
generated ctor/serialization reference the type's own `[Obsolete]` `Deprecated*` claim members
(legitimate generated self-reference). **Fix:** added `CS0618` to `<NoWarn>` in the csproj
(established pattern: Batch, ContainerRegistry). Build 348 → 231 errors.

### fix #3 — Group C (CS0200) 🔄 IN PROGRESS — **PIVOTAL FINDING**
93 CS0200 split: 48 in **generated** `AttestationResult.cs`/`TpmAttestationResponse.cs`, 45 in
**custom** (`AttestationClient.cs` 36, `PolicyCertificateModification.cs` 6, `AttestationModelFactory.cs` 3).

**Root cause:** the **new emitter changes `[CodeGenMember]` rename semantics.** The hand-written
`Models/AttestationResult.cs` uses the old pattern — `[CodeGenMember("EnclaveHeldData")] private
string InternalEnclaveHeldData` to rename the generated backing member and expose a richer public
`BinaryData EnclaveHeldData`. The **old** generator renamed the generated member to `Internal*`; the
**new** generator **ignores the rename**, still emits its own `public BinaryData EnclaveHeldData {get;}`
+ assigns it in the ctor → collides with the custom read-only override → CS0200. The new generator
*already* emits `BinaryData` props + `Deprecated*` `[Obsolete]` members itself, so many old
`[CodeGenMember]` transforms are now **redundant**.

**DECISION (Option C-1 — modernize customizations):** reconcile per model by **deleting now-redundant
`[CodeGenMember]` transforms** and keeping only genuine value-adds (e.g. `AttestationSigner.FromJsonWebKey`),
letting the richer generated members stand. Mostly *deletion*, aligns with the new SDK, avoids brittle
per-member `@@clientName` in the spec (rejected Option C-2). Models to reconcile: `AttestationResult`,
`JsonWebKey`, `PolicyCertificateModification`, `InitTimeData`, `AttestationSigner`,
`PolicyCertificatesResult`, `TpmAttestationResponse`, `AttestationModelFactory`, plus custom call sites
in `AttestationClient.cs`/`AttestationAdministrationClient.cs` (Group D). **START with `AttestationResult`
as the pattern, rebuild, then replicate.**

**DEFINITIVE PROOF it's customization-caused (not a generator bug):** a generated get-only auto-property
`public T Foo { get; }` **is** assignable in the generated ctor (`Foo = foo;`) — legal C#. So the CS0200
inside generated `AttestationResult.cs` cannot come from pure generated code; it occurs only because the
hand-written partial redefines those members as **computed** read-only props (`get => ...`), which are not
assignable. ⇒ the old `[CodeGenMember]` rename (backing member → `Internal*`) is **not applied by the new
emitter**, so the generated ctor binds to the custom computed prop → CS0200. Customization/emitter-semantics
incompatibility → **C-1 (modernize) is correct.**

**Authoritative process (repo `.github/skills/dpg-migration/SKILL.md`):**
- **Hard rule:** never edit files under `Generated/`; never silently `[CodeGenSuppress]` a *generator* bug.
- Prescribed diagnostic before mass edits: move custom `Models/*.cs` **aside** → regen → inspect clean
  generated shapes; then reintroduce only the customizations that still add value, modernized.
- Attestation keeps customizations directly under `src/Models/` (not `Custom/BackwardCompat/`) — preserve
  that existing layout.

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

### fix #3 — diagnostic RESULT (move-aside COMPLETE) ✅
Moved all **25** custom `src/Models/*.cs` that carry codegen transforms to
`sdk/attestation/_migration_custom_backup/Models/` (clean move — verified byte-identical to HEAD),
then regenerated. **Result:** `dotnet build` in `src/` = **252 errors, ALL missing-type**:
| Code | Count | Meaning |
|------|------:|---------|
| CS0246 | 192 | convenience types gone (`AttestationSigner`×138, `PolicyModificationResult`×30, `TpmAttestationRequest`×12, `PolicyCertificateResolution`×6, `JsonWebTokenHeader`×6) |
| CS0234 | 54 | same, as `Azure.Security.Attestation.<T>` (from `Generated/AttestationModelFactory.cs` etc.) |
| CS0051 | 6 | inconsistent accessibility knock-on |

**Conclusions (locks in C-1):**
1. All 25 files are genuinely required — reintroduce every one (modernized), none are pure-dead.
2. Raw generated models are now **rich**: `AttestationResult` emits `BinaryData EnclaveHeldData/PolicyHash`,
   `Attestation.AttestationSigner PolicySigner/DeprecatedPolicySigner`, and all `Deprecated*` `[Obsolete]`
   members itself ⇒ the old `[CodeGenMember("…")] private string Internal…` renames are **redundant** (delete).
3. Generated `AttestationResult(.Serialization).cs` now references `Attestation.AttestationSigner` and calls
   `AttestationSigner.DeserializeAttestationSigner(...)` / `WriteObjectValue<Attestation.AttestationSigner>()`.
   Spec has **no** `AttestationSigner` model (`policySigner?: JsonWebKey`), so `Attestation.AttestationSigner`
   binds to the **hand-written** `Azure.Security.Attestation.AttestationSigner`. ⇒ that custom type must (a)
   exist and (b) provide `DeserializeAttestationSigner` + `IJsonModel`/`WriteObjectValue` support (Group G) —
   the richest single work item.

**25 backed-up files — reintroduction categorization:**
- **Pure accessibility stubs (empty body, just `[CodeGenType]` + accessibility)** — generated type ALREADY
  matches this accessibility ⇒ likely **redundant, drop** (verify each): `AttestationResponse`(int),
  `PolicyResponse`(int), `PolicyCertificatesModifyResponse`(int), `PolicyCertificatesResponse`(int),
  `JsonWebKey`(int), `JsonWebKeySet`(int), `RuntimeData`(int), `DataType`(int),
  `AttestOpenEnclaveRequest`(int), `AttestSevSnpVmRequest`(int), `AttestSgxRequest`→`AttestSgxEnclaveRequest`(int),
  `AttestationType`(pub struct — generated already public), `PolicyCertificatesModificationResult`(pub — matches).
- **Access MISMATCH stub → move to `client.tsp` `@@access`:** `PolicyModification` (generated **internal**
  struct, custom wants **public**). Reintroduce as `client.tsp` `@@access(PolicyModification, Access.public)`
  (or keep a public partial-struct stub if TCGC access can't promote a value type).
- **RENAME stubs → keep as `[CodeGenType("<generatedName>")]` (already the mechanism):**
  `CertificateModification`→`PolicyCertificateResolution` (pub struct),
  `PolicyModificationResult` from `PolicyResult`, `PolicyCertificateModification` from
  `AttestationCertificateManagementBody`.
- **Genuine value-adds (ctors / computed props / helpers) — reintroduce, modernized:**
  `AttestationSigner` (public type + `From*` + **add** `DeserializeAttestationSigner`/serialization),
  `AttestationResult` (drop redundant `[CodeGenMember]`, keep computed `IssuedAt/Expiration/NotBefore/Issuer/UniqueIdentifier/Confirmation`),
  `InitTimeData` (byte[]/object ctors; watch `DataType.Json` removal — Group E),
  `JsonWebTokenHeader` (JWT header props),
  `PolicyCertificatesResult` (`GetPolicyCertificates()`),
  `PolicyModificationResult` (`PolicyResolution/PolicySigner/PolicyTokenHash/PolicyToken`),
  `TpmAttestationRequest`/`TpmAttestationResponse` (`BinaryData Data`),
  `StoredAttestationPolicy` (`AttestationPolicy` + JsonConverter),
  `PolicyCertificateModification` (X509 ctor).

**Modernization rules to apply on reintroduction:**
- `[CodeGenModel("X")]` → `[CodeGenType("X")]`; add `using Microsoft.TypeSpec.Generator.Customizations;`.
- Delete `[CodeGenMember]` renames whose target is now emitted directly (most `Internal*` in `AttestationResult`).
- `key.X5C` → `key.X5c` (generated casing); JsonWebKey writes may need model-factory/`[CodeGenMember]`.
- Prefer `client.tsp` (`@@access`/`@@clientName`) for access/name; C# customization for behavior/shims.

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
