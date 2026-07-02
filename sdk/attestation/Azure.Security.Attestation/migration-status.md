# Migration Status — Azure.Security.Attestation

**Type:** Data-plane (DPG) migration — AutoRest/Swagger → TypeSpec
**Branch (azure-sdk-for-net):** `dev/ksapathy/attestation-dataplane-2025-06-01`
**Spec repo:** `c:\src\azure-rest-api-specs` (branch `main`, `client.tsp` locally modified)
**Spec directory:** `specification/attestation/data-plane/Attestation`
**Target API version:** `2025-06-01`
**Last Updated:** 2026-07-02

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

The committed `Generated/` folder does **not** reflect these edits (it was generated from the
remote pinned commit). **Regenerating in local mode is the key unblocking step.**

## Phase Tracker

**Legend:** ✅ Done | 🔄 In Progress | ❌ Blocked | ⏭️ Not Started

| Phase | Status | Notes |
|-------|--------|-------|
| 0 — Discovery | ✅ | `discover_project`: dpg, specs repo at `c:\src\azure-rest-api-specs` |
| 1 — Error analysis | ✅ | 37 errors classified (2 deterministic, 35 reasoning) |
| 2 — tsp-location.yaml | ✅ | Present; emitter path correct |
| 3 — Legacy config | ✅ | No `autorest.md`; `autorest.md.bak` present |
| 4 — client.tsp customizations | ✅ | **Fixed**: `@access` on interfaces is invalid in this TCGC version; rewrote to per-operation `@access(...op, Access.internal)`. Regen now compiles the spec cleanly. Local, uncommitted. |
| 5 — Regenerate (local mode) | ❌ | **ROOT CAUSE FOUND**: generation *does* work and *does* apply `client.tsp` (it produced renamed `AttestationRestClient.cs`, `PolicyRestClient.cs`, etc.), but the emitter writes to the **wrong directory** — `@azure-typespec/http-client-csharp/src/Generated/` at the **repo root** — instead of the attestation package. `emitter-output-dir` for `@azure-typespec/http-client-csharp` is not configured/plumbed. Fix the output dir and regeneration lands in `sdk/.../src/Generated`. |
| 6 — Build-fix cycle | ⏭️ | Blocked on Phase 5. Then reconcile `AttestationClient` / `AttestationClientOptions` partial + `ServiceVersion` |
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

## Next Steps

1. **BLOCKER — fix the emitter output directory so generation lands in `sdk/.../src/Generated`.**
   Root cause confirmed: `dotnet build /t:GenerateCode` runs the emitter and applies
   `client.tsp` correctly, but the output is written to `@azure-typespec/http-client-csharp/src/Generated/`
   at the repo root (clobbering the emitter's own test project). The
   `@azure-typespec/http-client-csharp` folder at the repo root is itself a stray artifact of
   this misdirection. Investigate how `emitter-output-dir` / `package-dir` is passed to
   `@azure-typespec/http-client-csharp` (vs. a known-good migrated DPG library).
2. Once output lands in the package: the renamed internal `*RestClient` clients + internal
   models will resolve CS0246 and CS0050/CS0051.
3. Reconcile `AttestationClient` / `AttestationClientOptions` (Phase 6): make hand-written
   types `partial`, drop duplicate `ServiceVersion`, preserve public API surface.

## Git safety points (revert experiment)

- **`checkpoint-raw-typespec`** (tag) = the original "raw TypeSpec generation (not building)"
  checkpoint commit `d07f9407980`.
- Current HEAD = a `git revert` of that checkpoint → restores the pre-checkpoint **AutoRest**
  state, which **builds cleanly (0 errors, incl. tests)**.
- **Jump back to the checkpoint:** `git reset --hard checkpoint-raw-typespec`
  (or `git revert --no-edit HEAD` to re-apply the checkpoint on top).
