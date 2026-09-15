---
name: auto-build-repair
description: "Headless, bounded repair of custom-code build failures in an already-generated Azure SDK PR. Thin wrapper over the shared azure-sdk-mcp:azsdk_customized_code_update engine in custom-code-only scope (editScope: CustomCode); the skill owns the iterate-until-green loop, capped by a per-language `maxIterations` read from repair-config.yml. WHEN: Copilot cloud agent runs on a release-planner Auto SDK PR labeled `auto-sdk-build-fix` that fails to build because of custom (non-generated) code. DO NOT USE FOR: full TypeSpec migrations, spec edits, API design review, manual fixing. INVOKES: azure-sdk-mcp:azsdk_customized_code_update."
---
# Auto Build Repair

Purpose-built, **headless** skill that repairs an **already-generated Azure SDK pull request** whose build fails because of **custom (non-generated) code** that has drifted from the regenerated surface.

This is NOT a migration. The SDK PR already exists, the TypeSpec source is already pinned via `tsp-location.yaml`, and most of the diff is generated code. Your only job is to drive the shared **`azure-sdk-mcp:azsdk_customized_code_update`** engine — in **custom-code-only** scope (`editScope: CustomCode`) — re-invoking it up to **`maxIterations`** times (a cross-language repair bound; its per-language value is read from [`repair-config.yml`](#configuration), see [Bounds](#bounds)) until the package builds, then stop. **Do not hand-edit code and do not use any other fix engine** (e.g. the per-language generator-agent); the cross-language design centralizes the fix logic in this one shared tool.

## When Invoked

The Copilot cloud agent runs this skill on an **Auto SDK PR** created by the release-planner generation flow and labeled `auto-sdk-build-fix`. Trigger phrases: "auto build repair", "repair build", "fix the SDK PR build", "auto-sdk-build-fix", "custom-code build repair".

**This skill runs non-interactively in an ephemeral environment. Never prompt the user for input** (no spec repo path, no confirmations). If you cannot proceed within scope, stop and emit structured guidance (see [Stop Conditions](#stop-conditions)).

## The engine: `azure-sdk-mcp:azsdk_customized_code_update`

This skill is a **thin wrapper**. All classification → fix → regenerate → rebuild logic lives inside the shared `azure-sdk-mcp:azsdk_customized_code_update` tool, which already handles .NET (partial classes / `[CodeGen*]`), Python (`_patch.py`), and Java (`*Customization.java`). Do **not** replicate its behavior by editing files yourself, and do **not** invoke a per-language generator-agent — the design deliberately uses this single shared engine.

> **Requires azsdk ≥ 0.6.22** — the `editScope` parameter (and optional `tspProjectPath`) used below shipped in azsdk-cli `0.6.22`. The cloud agent installs the MCP tool via `eng/common/mcp/azure-sdk-mcp.ps1`, which defaults to the latest release, so this is satisfied automatically; no version pin needs bumping.

Given the failing package and the **build errors** (passed as `customizationRequest`), invoked with **`editScope: CustomCode`**, the tool:
- **regenerates** the client from the **pinned `tsp-location.yaml` commit** (omit `tspProjectPath` — it resolves from the pinned commit, so no manual spec checkout);
- in `CustomCode` scope, **only patches custom (non-generated) code** and reports anything that would need a spec change as out of scope (`SpecChangeRequired`) instead of applying it;
- **allows regeneration**, so reconciling a custom-code fix may deterministically change `Generated/`;
- runs **fully non-interactively** (no prompts) and returns a structured `CustomizedCodeUpdateResponse` (build success/failure + `BuildResult`, plus `ResponseError` / `ErrorCode`).

### Call shape

```
azure-sdk-mcp:azsdk_customized_code_update(
  editScope:            "CustomCode",   // custom-code-only: never edits spec inputs / the pinned commit
  packagePath:          "<failing SDK package dir>",   // the single failing package; do not widen
  customizationRequest: "<the build errors / failure context from the PR>"
  // tspProjectPath: OMIT for CustomCode — regeneration resolves the spec from the pinned tsp-location.yaml commit.
)
```

Pass the **build error output** as `customizationRequest`. Pass `packagePath` for the single failing package — it is already scoped; do not widen. Use **`editScope: CustomCode`** so the tool never edits `client.tsp` / `tspconfig.yaml` and never moves the pinned commit. **Omit `tspProjectPath`** (required only for `SpecInputs`/`All` scope).

> Each call performs **one repair attempt** (regenerate → classify → build → a second classifier pass enriched with the build error → build) and returns a terminal build result. The **iterate-until-green loop lives in this skill** (see [Bounds](#bounds)): re-invoke the idempotent tool while it makes progress, up to **`maxIterations`** attempts. A richer structured result / diff manifest is additive and still proposed in the design (§6); until it lands, drive the call above and read `BuildResult` / `ResponseError`.

## Scope — read this first

| Allowed | Forbidden |
|---------|-----------|
| Drive `azsdk_customized_code_update` (editScope: CustomCode) to patch the failing package's **custom (non-generated) code**. | Edit any **spec input**: `client.tsp`, `tspconfig.yaml`, `main.tsp`, or any TypeSpec source. |
| Let the tool **regenerate** `Generated/` from the **unchanged pinned** commit, and commit the deterministic result **only after the final build is green**. | **Move the pinned spec commit** in `tsp-location.yaml` (the `commit`/`repo`/`directory` fields), or commit partial progress while the final build is red. |
| After a green final build, commit the tool's custom-code changes + regenerated output as a reviewable commit. | Hand-edit code (custom or generated) to "help" the tool; let the engine own the edits. |
| Re-invoke the tool on an already-partially-repaired branch (it is idempotent). | Touch `.github/`, `eng/`, shared props/targets, pipeline files, package metadata, or secrets. |

**Custom code only.** If the only viable fix is a spec/decorator (Phase-A) change — e.g. a naming fix that must live in `client.tsp` via `@@clientName`, or `@@access` — that belongs in a **separate spec-repo PR** and is **out of scope**. The tool will stop and return guidance; surface it (see [Stop Conditions](#stop-conditions)) and do not attempt it.

**Regeneration is expected, not a violation.** Fixing custom code that carries generator signals legitimately changes `Generated/` as a deterministic downstream effect. After the final build is green, the regenerated `Generated/` **must be committed** so the repo's existing generated-code-diff check (.NET: `eng/scripts/CodeChecks.ps1` → `/t:GenerateCode` + `git diff --exit-code`) stays green. If the final build is red, commit nothing. The guard is "`Generated/` is *reproducible from unchanged inputs*", not "`Generated/` is frozen".

## Configuration

`maxIterations` is a **cross-language repair concept**: every language repo's auto-build-repair skill bounds its repair loop by the same `maxIterations` key, but the **value is tunable per language** (build + regeneration cost differs across .NET / Python / Java). This skill reads it from the co-located per-language config file:

- File: [`repair-config.yml`](repair-config.yml) (next to this `SKILL.md`).
- Key: `maxIterations` — max number of times the skill re-invokes `azsdk_customized_code_update` before stopping and reporting. Reaching the limit without a green build never permits a commit.
- If the file or key is absent, fall back to the cross-language default **3**.

To tune this repo, edit `maxIterations` in `repair-config.yml`; do not hardcode a different number in the skill body. Other language repos carry their own `repair-config.yml` with their own value.

## Bounds

Each call performs **one repair attempt**; the skill owns the iterate-until-green loop and caps it at **`maxIterations`** attempts (read from [`repair-config.yml`](#configuration); default 3):

- Re-invoke the tool at most `maxIterations` times (it is idempotent on an already-partially-repaired branch); do not loop it unbounded. Re-invoke only while the build error set is still shrinking — stop early if an attempt makes no progress.
- If `maxIterations` attempts are reached without a green build, **do not commit any attempted changes; report the remaining errors** — do not switch to manual fixing.
- Do not expand scope to other packages — `packagePath` already targets the single failing package.

## Workflow

```
0. Read `maxIterations` from repair-config.yml (next to this SKILL.md); default to 3 if absent.
1. Identify the failing `packagePath` and collect the build-error output from the PR, capturing the raw build output to a file (e.g. `pre-repair-errors.txt` in the results directory) so the renderer can list the errors it fixed.
2. Call azure-sdk-mcp:azsdk_customized_code_update with:
      editScope = "CustomCode", packagePath, customizationRequest = <build errors>  (omit tspProjectPath).
   The tool regenerates from the pinned commit, patches ONLY custom code, rebuilds, and returns a build result.
3. Inspect the structured result (build success/failure + BuildResult, plus ResponseError / ErrorCode):
      - Build green (`success: true` in the final structured result) → ensure custom-code edits AND regenerated Generated/ are included in the workflow's success-only commit. Go to 5.
      - Still failing but the error set shrank and attempts remain (< `maxIterations`) → re-invoke (step 2) with the updated build errors; it is idempotent.
      - SpecChangeRequired / RegenerateFailed at the pinned commit / no further progress → STOP (see Stop Conditions).
4. Never hand-edit to finish the job; if the tool cannot, it is a stop condition.
5. Emit the deterministic PR summary comment (see the "Reporting" section below): capture each attempt's `result-<n>.json`, run `emit-repair-report.ps1`, and post its output verbatim via `add_comment`. Successful, green fixes land as reviewable commits; failed attempts remain uncommitted — no auto-merge.
```

## Reporting (deterministic — do NOT author the comment yourself)

Every terminal state must leave **one structured PR summary comment**, and its structure must be **deterministic**. You do **not** write the comment prose or the metrics — a checked-in renderer does, from code-accessible sources only (the engine's structured results, `git`, and `$GITHUB_*` env). Your only reporting job is to **capture each attempt's structured result** and **run the renderer**, then post its output verbatim.

1. **Capture structured results.** Invoke the engine so each attempt's `CustomizedCodeUpdateResponse` is written to `result-<n>.json` (attempt-numbered) in a results directory. From the CLI this is `azsdk -o json … > result-<n>.json` (see the workflow file); from the MCP tool, persist the returned JSON the same way. Also redirect the initial (pre-repair) build output to `pre-repair-errors.txt` in that directory — a first-try success leaves no `buildResult`, so this is the only source for the "Build Errors Fixed" list. Never hand-transcribe fields.
2. **Render.** Run [`emit-repair-report.ps1`](emit-repair-report.ps1) (co-located) pointing at the results directory (`-ResultsDir`) and the captured pre-repair output (`-PreRepairErrorsFile`). It renders a Summary table, a Build Errors Fixed/Remaining table (code + file:line parsed from the build output), a Files Changed table (generated-vs-custom via `git diff`, with per-file change descriptions from the engine's `appliedPatches`), an Invariants section, and the telemetry object — writing the full comment markdown to a file.
3. **Post verbatim.** Pass the rendered file's contents **unchanged** as the `add_comment` body. Do not edit, summarize, or re-order it.

**The telemetry object** is a small, versioned JSON embedded in a collapsed `<details>` block, defined by [`telemetry-schema.v1.json`](telemetry-schema.v1.json) — the canonical contract, mirrored by CloudMine from the GitHub issues/comments stream. It carries only the fields needed to compute (or key the joins for) the success metrics:

| Field | Source (never the model) |
|-------|--------------------------|
| `status`, `repaired_at` | engine `success` of the final `result-<n>.json` + wall clock on green |
| classified errors (human section) | regex over the captured pre-repair build output + engine `buildResult` |
| files changed (human section) | `git diff --name-status` + `Generated/` path split |
| iterations (human section) | count of `result-<n>.json` files |
| `pr`, `head_sha`, `repo`, `run_id`, `eligible` | `$GITHUB_*` env + the eligibility gate |

The object itself carries only the 8 primitives in [`telemetry-schema.v1.json`](telemetry-schema.v1.json) (`additionalProperties: false`); classified errors, files changed, and iteration count are rendered into the **human** section only.

**Emit on every terminal state** — `repaired`, `failed`, `ineligible`, `skipped_already_green` — using the same renderer (only the data differs). Never skip the comment; a missing record corrupts the metrics denominator.

## Stop Conditions

When the tool returns one of these, **surface its guidance (`ResponseError` / `BuildResult`)** and stop — do not keep retrying or escalate to a human prompt:

- **Out of scope (spec change required)** — the tool reports `SpecChangeRequired`: the only real fix is a `client.tsp`/`tspconfig.yaml` decorator or spec edit (e.g. `@@clientName`, `@@access`, `AZC0030`/`AZC0012` naming). Because the call uses `editScope: CustomCode`, the tool reports these instead of applying them. Report "requires a spec-repo PR" with the offending errors. Leave the PR red for a human to route.
- **Regeneration fails at the pinned commit (spec-side error)** — the tool returns `ErrorCode: RegenerateFailed` because of a spec-side problem at the **unchanged** pinned `tsp-location.yaml` commit: invalid `tspconfig.yaml`, missing/renamed spec files, or a broken TypeSpec source. Because this skill must never move the pinned commit or edit spec inputs, treat this as an **immediate stop** — report "spec-side generation failure at the pinned commit; requires a spec-repo fix" with the generation error. Do **not** attempt to fix the spec or bump the commit.
- **Suspected generator bug** — `Generated/` has structural errors that persist after the tool reconciles customizations and regenerates from the unchanged pinned commit. Do NOT suppress; report with the minimal repro.
- **`maxIterations` reached** — the skill's re-invocation cap is reached without a green build. Do not commit attempted changes; report the remaining errors.

On success, summarize: errors fixed, files changed (generated-vs-custom split), final build status, and confirmation that no spec inputs or the pinned commit were touched.

## Hard Rules (recap)

1. Drive **`azure-sdk-mcp:azsdk_customized_code_update`** with `editScope: CustomCode` (+ the failing `packagePath` and the build errors as `customizationRequest`); do not hand-edit code and do not use any other fix engine.
2. Never edit `client.tsp`, `tspconfig.yaml`, or any TypeSpec/spec input; never move the pinned spec commit in `tsp-location.yaml` (`editScope: CustomCode` enforces this — and omit `tspProjectPath`).
3. Commit the tool's regenerated `Generated/` alongside the custom-code edits only when the final structured result has `success: true` (the guard is reproducibility, not freezing). If the build remains red for any reason, commit nothing.
4. Never touch `.github/`, `eng/`, shared props/targets, pipelines, metadata, or secrets.
5. Never prompt the user; run fully headless, honoring `maxIterations`.
6. Never auto-merge — fixes land as reviewable commits for human review.
7. Work only in the existing checkout at `$GITHUB_WORKSPACE` (the PR is already checked out there); `cd "$GITHUB_WORKSPACE"` before running `git`/build/renderer commands and keep scratch under `$RUNNER_TEMP`. Never `git clone` the repo or make a second working copy — a duplicate clone bloats the run artifacts and can stall comment delivery.
