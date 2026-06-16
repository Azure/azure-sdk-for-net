---
name: auto-build-repair
description: Headless, bounded repair of custom-code build failures in an already-generated Azure SDK for .NET PR. Patches ONLY custom (non-generated) code until the package builds, using the generator-agent MCP build-fix tools. Used by the Copilot cloud agent on release-planner-created "Auto SDK PRs" labeled `auto-sdk-build-fix`. Never edits spec inputs (client.tsp/tspconfig.yaml) and never moves the pinned spec commit.
---
# Auto Build Repair

Purpose-built, **headless** skill that repairs an **already-generated Azure SDK for .NET pull request** whose build fails because of **custom (non-generated) code** that has drifted from the regenerated surface.

This is NOT a migration. The SDK PR already exists, the TypeSpec source is already pinned via `tsp-location.yaml`, and most of the diff is generated code. Your only job is to patch the package's **custom code** (and commit any deterministic regenerated `Generated/` output) until the package builds — then stop.

## When Invoked

The Copilot cloud agent runs this skill on an **Auto SDK PR** created by the release-planner generation flow and labeled `auto-sdk-build-fix`. Trigger phrases: "auto build repair", "repair build", "fix the SDK PR build", "auto-sdk-build-fix", "custom-code build repair".

**This skill runs non-interactively in an ephemeral environment. Never prompt the user for input** (no spec repo path, no confirmations). If you cannot proceed within scope, stop and emit structured guidance (see [Stop Conditions](#stop-conditions)).

## Scope — read this first

| Allowed | Forbidden |
|---------|-----------|
| Edit the failing package's **custom (non-generated) code** (`.cs` partial classes, `[CodeGen*]` attributes, backward-compat shims). | Edit any **spec input**: `client.tsp`, `tspconfig.yaml`, `main.tsp`, or any TypeSpec source. |
| **Regenerate** `Generated/` from the **unchanged pinned** `tsp-location.yaml` commit, and **commit** the deterministic result. | **Move the pinned spec commit** in `tsp-location.yaml` (the `commit`/`repo`/`directory` fields). |
| Add/adjust customization files under the package's `Custom/` (or equivalent) folders. | Hand-edit files under `Generated/`. |
| Add backward-compat shims for ApiCompat breaks. | Touch `.github/`, `eng/`, shared props/targets, pipeline files, package metadata, or secrets. |

**Custom code only.** If the only viable fix is a spec/decorator (Phase-A) change — e.g. a naming fix that must live in `client.tsp` via `@@clientName`, or `@@access` — that belongs in a **separate spec-repo PR** and is **out of scope**. Stop and report (see [Stop Conditions](#stop-conditions)); do not attempt it.

**Regeneration is expected, not a violation.** Fixing custom code that carries generator signals (`[CodeGenType]`, `[CodeGenSuppress]`, `[CodeGenMember]`, `[CodeGenSerialization]`) legitimately changes `Generated/` as a deterministic downstream effect. You **must commit** the regenerated `Generated/` so the repo's existing generated-code-diff check (`eng/scripts/CodeChecks.ps1` → `/t:GenerateCode` + `git diff --exit-code`) stays green. The guard is "`Generated/` is *reproducible from unchanged inputs*", not "`Generated/` is frozen".

## MCP Server (generator-agent)

This skill uses the deterministic build-fix tools from the `generator-agent` MCP server (`sdk/tools/Azure.GeneratorAgent`), already provisioned in the cloud-agent environment. Use **only** the build-fix-loop subset below — do not invoke migration-only tools (`pregen_cleanup`, `migrate_test_samples`, `finalize_migration`, `commit_iteration`, `validate_tsp_config`).

| Tool | When to Use | What It Does |
|------|-------------|--------------|
| `discover_project` | First step — to resolve package paths and `tsp-location.yaml` fields | Returns project context (plane, package/service name, custom code folder, Generated/ paths, pinned commit). Ignore any spec-repo prompt — this flow never needs a local spec checkout. |
| `snapshot_generated` | Immediately after the first regeneration, before the fix loop | SHA-256 snapshot of `Generated/`, enabling auto-verification in later `build_and_classify` calls. |
| `build_and_classify` | First step of **every** iteration | Runs `dotnet build`, classifies each error as deterministic vs requires-reasoning. |
| `classify_errors` | Re-classify after partial fixes | Classifies errors against the deterministic fix registry. |
| `batch_fix` | After deterministic errors are identified | Applies multiple deterministic fixes in one call. |
| `add_using_directive` | `CS0246`/`CS0103` for a known type | Adds a missing `using`. |
| `remove_using_directive` | `CS0246` for stale `*.Rest.*` / `Autorest.*` namespaces | Removes matching `using` directives. |
| `nullable_annotation_fix` | `CS8625`/`CS8600` | Adds `?` nullable annotation. |
| `rename_codegen_type` | `CS0246` for a `[CodeGenType]` that no longer matches the generated name | Updates `[CodeGenType]` to match generated type. |
| `add_codegen_suppress` | `CS0111` (custom + generated member clash) | Adds `[CodeGenSuppress]` to the custom partial. |
| `fetch_to_fromlro` | `CS0103`/`CS1061` for custom LRO `Fetch` calls | Replaces `Fetch(response)` with `Model.FromLroResponse(response)`. |
| `verify_generated_unchanged` | After the fix loop completes | Confirms no `Generated/` files were hand-modified outside regeneration. |

Prefer MCP tools for deterministic fixes; only hand-edit custom code for errors classified as requires-reasoning.

## Bounds

- **Max 10 build-fix iterations.** If the error count is not decreasing after 3 consecutive iterations, stop and report.
- Stay within the cloud-agent wall-clock budget. If exhausted, commit progress made so far and report remaining errors.
- Do not expand scope to other packages — `discover_project` already targets the single failing package.

## Repair Loop

```
SETUP:
  0. Call `discover_project` to resolve the package path, custom-code folder, and pinned tsp-location.yaml fields.
  1. Regenerate once from the PINNED commit:  dotnet build /t:GenerateCode
     (remote mode — uses the commit already in tsp-location.yaml; do NOT pass a local spec repo,
      do NOT change tsp-location.yaml).
  2. Call `snapshot_generated` to lock down Generated/.

LOOP (max 10 iterations):
  3. Call `build_and_classify`.
  4. IF zero errors → EXIT LOOP (go to FINALIZE).
  5. IF error count not decreasing after 3 iterations → STOP and report (see Stop Conditions).
  6. Split errors into deterministic vs requires-reasoning.
  7. Apply ALL deterministic fixes via `batch_fix` / targeted fixers.
  8. For requires-reasoning errors, edit ONLY custom code (see Drift & ApiCompat patterns below).
     IF the only viable fix is a spec/decorator change → STOP and report (out of scope).
  9. IF you changed any `[CodeGen*]` attribute or added/removed/renamed a custom file carrying
     generator signals → regenerate:  dotnet build /t:GenerateCode  (pinned commit, no spec edits).
     Customization-only `.cs` edits with no generator attributes → no regeneration needed.
 10. GOTO 3.

FINALIZE:
 11. Call `verify_generated_unchanged` to confirm no hand edits leaked into Generated/.
 12. Ensure the regenerated Generated/ is committed alongside the custom-code edits.
```

> **Generated/ auto-guard**: once a snapshot exists, every `build_and_classify` verifies that no `Generated/` files were hand-modified; the deterministic fixers also refuse to write inside `Generated/`. Let regeneration (`/t:GenerateCode`) — not manual edits — produce any `Generated/` change.

## Customization-drift patterns (custom code only)

These are the common drift failures. All fixes live in the package's custom code; never edit `Generated/` or the spec.

- **Stale reference to a renamed/removed generated symbol** — custom code references a model/property/method that the new surface renamed or dropped. Update the custom reference to the new name, or delete the custom member if the generated type no longer exists, then regenerate if a `[CodeGen*]` attribute was involved.
- **`[CodeGenType]` name mismatch** — the value must exactly match the generated class name (use `rename_codegen_type`); a mismatch silently breaks partial-class merging and produces spurious "missing member" errors.
- **Duplicate member (`CS0111`)** — custom partial and generated code both define a member; add `[CodeGenSuppress("Member")]` to the custom partial (use `add_codegen_suppress`).
- **Stale `using` / namespace** — add the missing `using` (`add_using_directive`) or remove obsolete `*.Rest.*` / `Autorest.*` usings (`remove_using_directive`).
- **LRO `Fetch`** — replace with `Model.FromLroResponse(response)` (`fetch_to_fromlro`).
- **Stale custom file** — a custom `FooResource.cs` exists but `Generated/FooResource.cs` was renamed/removed: rename the custom file to match, or remove it, then regenerate.

## ApiCompat breaks (GA libraries)

ApiCompat surfaces breaking changes vs the last shipped API. Fix with backward-compat shims in custom code (e.g. `Custom/BackwardCompat/<Type>.cs`), each marked `[EditorBrowsable(EditorBrowsableState.Never)]` with a comment explaining the shim. For async forwarding overloads, always `await ... .ConfigureAwait(false)`.

**Hard rules — no exceptions:**
- ⛔ NEVER create or modify `ApiCompatBaseline.txt` to suppress ApiCompat errors.
- ⛔ NEVER remove or change `ApiCompatVersion` in the `.csproj`.

(For detailed shim recipes, the `dpg-migration` / `mitigate-breaking-changes` skills document the per-rule patterns; reuse those recipes but stay within custom-code scope.)

## Stop Conditions

Stop and emit a **structured, machine-readable summary** (do not keep retrying or escalate to a human prompt) when any of these hold:

- **Out of scope (spec change required)** — the only real fix is a `client.tsp`/`tspconfig.yaml` decorator or spec edit (e.g. `@@clientName`, `@@access`, `AZC0030`/`AZC0012` naming). Report: "requires a spec-repo PR" with the offending errors. Leave the PR red for a human to route.
- **Suspected generator bug** — `Generated/` has structural errors that persist after removing all custom-code influence and regenerating from the unchanged pinned commit. Do NOT suppress; report with the minimal repro.
- **Bounds exhausted** — 10 iterations reached, or error count not decreasing after 3 iterations, or wall-clock budget hit. Commit progress and report remaining errors.

On success, summarize: errors fixed (with deterministic-vs-reasoning split), files changed (generated-vs-custom split), final build status, and confirmation that no spec inputs or the pinned commit were touched.

## Hard Rules (recap)

1. Never edit `client.tsp`, `tspconfig.yaml`, or any TypeSpec/spec input.
2. Never move the pinned spec commit in `tsp-location.yaml`.
3. Never hand-edit `Generated/`; only `/t:GenerateCode` may change it, and you must commit that result.
4. Never touch `.github/`, `eng/`, shared props/targets, pipelines, metadata, or secrets.
5. Never prompt the user; run fully headless.
6. Never auto-merge — fixes land as reviewable commits for human review.
