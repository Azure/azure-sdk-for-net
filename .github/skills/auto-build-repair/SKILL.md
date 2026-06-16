---
name: auto-build-repair
description: "Headless, bounded repair of custom-code build failures in an already-generated Azure SDK PR. Thin wrapper over the shared azure-sdk-mcp:azsdk_customized_code_update engine in custom-code-only (editScope=CustomCode) scope. WHEN: Copilot cloud agent runs on a release-planner Auto SDK PR labeled `auto-sdk-build-fix` that fails to build because of custom (non-generated) code. DO NOT USE FOR: full TypeSpec migrations, spec edits, API design review, manual fixing. INVOKES: azure-sdk-mcp:azsdk_customized_code_update."
---
# Auto Build Repair

Purpose-built, **headless** skill that repairs an **already-generated Azure SDK pull request** whose build fails because of **custom (non-generated) code** that has drifted from the regenerated surface.

This is NOT a migration. The SDK PR already exists, the TypeSpec source is already pinned via `tsp-location.yaml`, and most of the diff is generated code. Your only job is to drive the shared **`azure-sdk-mcp:azsdk_customized_code_update`** engine — in **custom-code-only** scope (`editScope: CustomCode`) — until the package builds, then stop. **Do not hand-edit code and do not use any other fix engine** (e.g. the per-language generator-agent); the cross-language design centralizes the fix loop in this one shared tool.

## When Invoked

The Copilot cloud agent runs this skill on an **Auto SDK PR** created by the release-planner generation flow and labeled `auto-sdk-build-fix`. Trigger phrases: "auto build repair", "repair build", "fix the SDK PR build", "auto-sdk-build-fix", "custom-code build repair".

**This skill runs non-interactively in an ephemeral environment. Never prompt the user for input** (no spec repo path, no confirmations). If you cannot proceed within scope, stop and emit structured guidance (see [Stop Conditions](#stop-conditions)).

## The engine: `azure-sdk-mcp:azsdk_customized_code_update`

This skill is a **thin wrapper**. All classification → fix → regenerate → rebuild logic lives inside the shared `azure-sdk-mcp:azsdk_customized_code_update` tool, which already handles .NET (partial classes / `[CodeGen*]`), Python (`_patch.py`), and Java (`*Customization.java`). Do **not** replicate its behavior by editing files yourself, and do **not** invoke a per-language generator-agent — the design deliberately uses this single shared engine.

Invoke it with **`editScope: CustomCode`** (custom-code-only), which:
- operates against `packagePath` with the TypeSpec source pulled at the **pinned `tsp-location.yaml` commit** (no manual spec checkout);
- **forbids spec-input edits** — never edits `client.tsp` / `tspconfig.yaml` and never moves the pinned commit;
- **allows regeneration**, so a custom-code fix may deterministically change `Generated/`;
- runs **fully non-interactively** (no prompts) and returns a **structured result**;
- if the only viable fix is a spec/decorator change, **stops and returns guidance** rather than attempting it.

### Call shape

```
azure-sdk-mcp:azsdk_customized_code_update(
  editScope:            "CustomCode",    // custom-code-only: forbids spec-input edits, keeps regeneration
  packagePath:          "<failing SDK package dir>",
  customizationRequest: "<the build errors / failure context from the PR>",
  // tspProjectPath resolves from the pinned tsp-location.yaml commit; do not point it at an edited spec.
  maxIterations:        <bound>,         // pass the configured iteration bound (default if absent)
  wallClockBudget:      <bound>          // pass the configured time budget (default if absent)
)
```

Pass the **build error output** as `customizationRequest`. Pass `packagePath` for the single failing package (it is already scoped — do not widen to other packages). Supply `maxIterations` / `wallClockBudget` from the repair flow's bounds; otherwise rely on the tool defaults.

> Some repair-specific inputs (`maxIterations`, `wallClockBudget`, structured result, diff manifest) are additive, backward-compatible changes still proposed for the shared tool in the design (§6); `editScope` ships first. Until the rest land, invoke the closest available form and still honor the scope rules below.

## Scope — read this first

| Allowed | Forbidden |
|---------|-----------|
| Drive `azsdk_customized_code_update` (editScope: CustomCode) to patch the failing package's **custom (non-generated) code**. | Edit any **spec input**: `client.tsp`, `tspconfig.yaml`, `main.tsp`, or any TypeSpec source. |
| Let the tool **regenerate** `Generated/` from the **unchanged pinned** commit, and **commit** the deterministic result. | **Move the pinned spec commit** in `tsp-location.yaml` (the `commit`/`repo`/`directory` fields). |
| Commit the tool's custom-code changes + regenerated output as reviewable commits. | Hand-edit code (custom or generated) to "help" the tool; let the engine own the edits. |
| Re-invoke the tool on an already-partially-repaired branch (it is idempotent). | Touch `.github/`, `eng/`, shared props/targets, pipeline files, package metadata, or secrets. |

**Custom code only.** If the only viable fix is a spec/decorator (Phase-A) change — e.g. a naming fix that must live in `client.tsp` via `@@clientName`, or `@@access` — that belongs in a **separate spec-repo PR** and is **out of scope**. The tool will stop and return guidance; surface it (see [Stop Conditions](#stop-conditions)) and do not attempt it.

**Regeneration is expected, not a violation.** Fixing custom code that carries generator signals legitimately changes `Generated/` as a deterministic downstream effect. The regenerated `Generated/` **must be committed** so the repo's existing generated-code-diff check (.NET: `eng/scripts/CodeChecks.ps1` → `/t:GenerateCode` + `git diff --exit-code`) stays green. The guard is "`Generated/` is *reproducible from unchanged inputs*", not "`Generated/` is frozen".

## Bounds

- Pass the configured `maxIterations` / `wallClockBudget` to the tool; do not loop the tool unbounded yourself.
- If the tool reports it is still failing after exhausting bounds, **commit progress made so far and report** — do not switch to manual fixing.
- Do not expand scope to other packages — `packagePath` already targets the single failing package.

## Workflow

```
1. Identify the failing `packagePath` and collect the build-error output from the PR.
2. Call azure-sdk-mcp:azsdk_customized_code_update with:
      editScope = "CustomCode", packagePath, customizationRequest = <build errors>, plus bounds.
   The tool classifies, patches ONLY custom code, regenerates from the pinned commit, and rebuilds.
3. Inspect the tool's structured result:
      - SUCCESS (build green) → ensure custom-code edits AND regenerated Generated/ are committed. Go to 5.
      - STILL FAILING but progressing and bounds remain → re-invoke (step 2) with the updated error context (idempotent).
      - OUT OF SCOPE / generator bug / bounds exhausted → STOP (see Stop Conditions).
4. Never hand-edit to finish the job; if the tool cannot, it is a stop condition.
5. Summarize the result (see below). Fixes land as reviewable commits — no auto-merge.
```

## Stop Conditions

When the tool returns one of these, **surface its structured guidance** and stop — do not keep retrying or escalate to a human prompt:

- **Out of scope (spec change required)** — the only real fix is a `client.tsp`/`tspconfig.yaml` decorator or spec edit (e.g. `@@clientName`, `@@access`, `AZC0030`/`AZC0012` naming). Report "requires a spec-repo PR" with the offending errors. Leave the PR red for a human to route.
- **Regeneration fails at the pinned commit (spec-side error)** — the tool's regeneration step (e.g. `/t:GenerateCode`) fails because of a spec-side problem at the **unchanged** pinned `tsp-location.yaml` commit: invalid `tspconfig.yaml`, missing/renamed spec files, or a broken TypeSpec source. Because this skill must never move the pinned commit or edit spec inputs, treat this as an **immediate stop** — report "spec-side generation failure at the pinned commit; requires a spec-repo fix" with the generation error. Do **not** attempt to fix the spec or bump the commit.
- **Suspected generator bug** — `Generated/` has structural errors that persist after the tool removes custom-code influence and regenerates from the unchanged pinned commit. Do NOT suppress; report with the minimal repro.
- **Bounds exhausted** — `maxIterations` / `wallClockBudget` reached without a green build. Commit progress and report remaining errors.

On success, summarize from the tool's structured result: errors fixed (deterministic-vs-reasoning split), files changed (generated-vs-custom split), final build status, and confirmation that no spec inputs or the pinned commit were touched.

## Hard Rules (recap)

1. Drive **`azure-sdk-mcp:azsdk_customized_code_update`** with `editScope: CustomCode`; do not hand-edit code and do not use any other fix engine.
2. Never edit `client.tsp`, `tspconfig.yaml`, or any TypeSpec/spec input; never move the pinned spec commit in `tsp-location.yaml`.
3. Commit the tool's regenerated `Generated/` alongside the custom-code edits (the guard is reproducibility, not freezing).
4. Never touch `.github/`, `eng/`, shared props/targets, pipelines, metadata, or secrets.
5. Never prompt the user; run fully headless, honoring the configured bounds.
6. Never auto-merge — fixes land as reviewable commits for human review.
