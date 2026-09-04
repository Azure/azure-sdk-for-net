---
# SDK build repair (agentic workflow)
#
# Auto-repairs a release-planner **Auto SDK PR** that fails to build because of
# hand-written customization (custom-code) drift. The release pipeline applies the
# `auto-sdk-build-fix` label (issue #59651) to eligible generated SDK PRs; that label
# is this workflow's primary trigger. A maintainer can also (re)run on demand by
# commenting `/repair-build` on the PR.
#
# This is a GitHub Agentic Workflow (gh-aw): the Copilot CLI agent runs the bounded
# `auto-build-repair` skill directly in GitHub Actions. Per
# https://github.blog/changelog/2026-06-11-agentic-workflows-no-longer-need-a-personal-access-token/
# it runs on the built-in token with `copilot-requests: write` (billed to the org) —
# no user-to-server PAT is needed (supersedes the COPILOT_AGENT_TASKS_TOKEN plan, #59655).
#
# Engine: the shared `azsdk_customized_code_update` engine. gh-aw's MCP Gateway only
# supports containerized-stdio or HTTP MCP servers, and the azsdk MCP server is plain
# stdio, so this workflow installs the `azsdk` CLI in a setup step and the agent drives
# the same engine via its CLI surface (`azsdk tsp client customized-update`).
#
# Safety: the agent job is read-only. All writes go through gh-aw safe-outputs jobs:
#   * `push-to-pull-request-branch` commits a fix only after the final package build is
#     green (forks refused, gated on the `auto-sdk-build-fix` label, protected-files
#     denylist enforced).
#   * `add-comment` posts the audit summary.
# There is NO auto-merge — human review stays mandatory. The independent required
# safety gate (#59654) is the external backstop.

description: "Auto-repair custom-code build failures on release-planner Auto SDK PRs labeled auto-sdk-build-fix, by driving the shared azsdk customized-update engine in custom-code-only scope."

on:
  # Primary, fully-automatic path: the release pipeline labels an eligible Auto SDK PR.
  # We use `pull_request` (not `pull_request_target`): under `pull_request`, fork PRs get
  # NO secrets and a read-only token (and gh-aw blocks forks by default), while the strict
  # eligibility gate below restricts same-repo runs to release-bot-generated `sdkauto/*`
  # branches — so the code that ever executes (incl. ./eng/common/mcp/azure-sdk-mcp.ps1 and
  # the package build) is always trusted, pipeline-generated content. `pull_request_target`
  # was rejected because gh-aw flags it as "extremely insecure" with checkout (the classic
  # pwn-request vector: full write perms + secrets while building untrusted PR code); for a
  # build-repair agent that MUST build the PR's code, the real control is the eligibility
  # gate, not the trigger event.
  pull_request:
    types: [labeled]
    names: [auto-sdk-build-fix]
  # Manual fallback: a maintainer (write+) comments `/repair-build` on the PR.
  slash_command:
    name: repair-build
    events: [pull_request_comment]
  # Only repository maintainers (write+) may trigger; the release bot that applies the
  # label is allow-listed so the automatic path works. This is the prompt-injection /
  # abuse guard (gh-aw default roles are [admin, maintainer, write]).
  roles: [admin, maintainer, write]
  bots: ["azure-sdk", "azure-sdk-automation[bot]"]

# Master kill-switch (fail-safe) + eligibility gate. The workflow stays dormant unless
# the repo Actions variable SDK_BUILD_REPAIR_ENABLED is exactly 'true'. In addition, on
# the automatic (pull_request) path the PR must be a genuine release-planner Auto SDK PR:
# same-repo (no forks), opened by the `azure-sdk` or `azure-sdk-automation[bot]` release bot,
# targeting `main`, on an
# `sdkauto/` branch. This gates *which PRs are eligible* (not just *who* can trigger), so a
# stray label on an unrelated/untrusted PR cannot run the repair agent against its code. The
# label name itself is filtered by `names:` under `on:` above. The manual /repair-build path
# is additionally gated by `roles:` above and by the agent's own eligibility check — see
# "Eligibility" in the prompt below.
if: >-
  ${{ vars.SDK_BUILD_REPAIR_ENABLED == 'true'
      && (github.event_name != 'pull_request'
          || (github.event.pull_request.head.repo.full_name == github.repository
              && github.event.pull_request.base.ref == 'main'
              && (github.event.pull_request.user.login == 'azure-sdk'
                  || github.event.pull_request.user.login == 'azure-sdk-automation[bot]')
              && startsWith(github.event.pull_request.head.ref, 'sdkauto/'))) }}

engine: copilot

# Agent job runs read-only; copilot-requests:write bills Copilot CLI usage to the org.
# The separate safe-outputs jobs receive the write scopes they need (contents/pull-requests).
permissions:
  contents: read
  pull-requests: read
  copilot-requests: write

# Authenticate the nested Copilot SDK used by azsdk with the workflow's Copilot CLI
# and built-in token.
env:
  AZSDK_COPILOT_CLI_PATH: /usr/local/bin/copilot
  AZSDK_COPILOT_GITHUB_TOKEN: ${{ github.token }}

network:
  allowed:
    - defaults
    - dotnet
    - github

# Toolchain: the SDK build + the azsdk engine both require the .NET 10 SDK.
runtimes:
  dotnet:
    version: "10.0.x"

# Install the shared azsdk CLI (the engine) onto PATH before the agent runs. The agent
# then invokes `azsdk tsp client customized-update` from bash. (gh-aw cannot host the
# stdio azsdk MCP server directly; see header.)
steps:
  - name: Install azsdk CLI
    shell: pwsh
    run: |
      # gh-aw exposes tool-cache bin directories inside the agent sandbox.
      $dir = Join-Path $env:RUNNER_TOOL_CACHE 'azsdk/latest/x64/bin'
      ./eng/common/mcp/azure-sdk-mcp.ps1 -InstallDirectory $dir
      Add-Content -Path $env:GITHUB_PATH -Value $dir
      & (Join-Path $dir 'azsdk') --version

tools:
  github:
    toolsets: [context, repos, pull_requests]
  bash: [":*"]
  edit:

safe-outputs:
  steps:
    - name: Disable implicit tag fetching
      run: |
        if git rev-parse --git-dir >/dev/null 2>&1; then
          git config remote.origin.tagOpt --no-tags
        else
          echo "::notice::No checkout yet at this point in the job; skipping tagOpt config."
        fi
  # Commit a successful repair (custom-code edits + regenerated Generated/) to the PR branch.
  # Forks are refused by this safe output; the label is re-checked at apply time; the
  # protected-files denylist blocks .github/, dot-dirs, manifests and instruction files.
  push-to-pull-request-branch:
    target: "triggering"
    required-labels: [auto-sdk-build-fix]
    if-no-changes: "warn"
    protected-files: fallback-to-issue
  # Audit trail: one summary comment per run.
  add-comment:
    max: 1
  # Do not open a tracking issue on agent failure; failures surface on the PR.
  report-failure-as-issue: false

timeout-minutes: 60
concurrency: sdk-build-repair-${{ github.event.pull_request.number || github.event.issue.number }}
---

# SDK Build Repair

<!-- After editing this file, run 'gh aw compile sdk-build-repair' to regenerate the lock file. -->

You are the Azure SDK for .NET **auto-build-repair** agent for `${{ github.repository }}`.

A release-planner **Auto SDK PR** (#${{ github.event.pull_request.number || github.event.issue.number }}) was generated from a pinned TypeSpec spec and **fails to build because of hand-written customization (custom-code) drift**. Your job is to make the failing package build again by repairing **only custom (non-generated) code**. Commit the fix back to the PR for human review only after the final engine result proves that the package build is green.

Follow the checked-in skill **exactly** — it is the source of truth for the procedure, scope, and stop conditions:

- Skill: `.github/skills/auto-build-repair/SKILL.md`
- Per-language bound: `.github/skills/auto-build-repair/repair-config.yml` (`maxIterations`)

## The engine in this environment

The skill drives the shared **`azsdk_customized_code_update`** engine. In this workflow the engine is the **`azsdk` CLI** (installed onto PATH by the setup step), not the MCP server. Invoke it from bash for each repair attempt, and **capture each attempt's structured result as JSON** (the global `-o json` flag serializes the engine's `CustomizedCodeUpdateResponse` to stdout) into an attempt-numbered file under a results directory:

```bash
mkdir -p "$RUNNER_TEMP/repair-results"
azsdk -o json tsp client customized-update \
  --edit-scope CustomCode \
  --package-path "<failing SDK package dir>" \
  --customization-request "<the build errors / failure context>" \
  > "$RUNNER_TEMP/repair-results/result-<n>.json"
```

Use `result-1.json`, `result-2.json`, … one per attempt. These files are the **only** source the summary comment is rendered from (see Step 5) — do not hand-transcribe fields from them.

`--edit-scope CustomCode` is custom-code-only: the engine regenerates from the pinned `tsp-location.yaml` commit, patches only custom (non-generated) code, and surfaces anything that needs a spec change as out of scope (`SpecChangeRequired`) instead of applying it. **Omit `--tsp-project-path`** (only needed for `SpecInputs`/`All` scope). Read the returned structured result (build success/failure + error code) to decide the next step exactly as the skill describes.

## Eligibility (verify before doing any work)

This workflow only repairs genuine **release-planner Auto SDK PRs**. Before building anything, use the read-only GitHub tools to confirm **all** of the following about PR #${{ github.event.pull_request.number || github.event.issue.number }}:

- it is in **this same repository** (the head branch is not from a fork),
- it was **opened by the `azure-sdk` or `azure-sdk-automation[bot]` release bot**,
- its **base branch is `main`**, and
- its **head branch starts with `sdkauto/`**.

The automatic (label) path is already gated on these by the workflow `if:`, but the manual `/repair-build` path is not — so **you must re-check them here**. If any condition fails, **stop immediately**: do not check out, build, or run the PR's code. Render the ineligible summary comment deterministically —

```bash
pwsh .github/skills/auto-build-repair/emit-repair-report.ps1 \
  '-Eligible:$false' -Pr <pr-number> -HeadSha "<pr-head-sha>" \
  -Repo "$GITHUB_REPOSITORY" -OutFile "$RUNNER_TEMP/repair-comment.md"
```

— then post the contents of `$RUNNER_TEMP/repair-comment.md` verbatim via `add-comment`, and end. This prevents running the repair agent against untrusted code.

## Operating constraints (non-negotiable)

0. **Verify eligibility first** (see the Eligibility section above) and bail if it fails — before any checkout/build of PR code.
1. **One engine only.** Drive `azsdk tsp client customized-update` with `--edit-scope CustomCode`. Do **not** hand-edit code, and do **not** use any other fix engine.
2. **Never edit spec inputs.** Do not modify `client.tsp`, `tspconfig.yaml`, `main.tsp`, any TypeSpec source, or move the pinned commit in `tsp-location.yaml`. `--edit-scope CustomCode` enforces this.
3. **Commit the regenerated `Generated/` on a green build only**, alongside the custom-code edits — the guard is reproducibility from unchanged inputs, not a frozen `Generated/`. Never commit custom or generated changes while the final build is red.
4. **Stay out of infra.** Never touch `.github/`, `eng/`, shared props/targets, pipelines, package metadata, or secrets. (The push safe-output additionally enforces a protected-files denylist.)
5. **Fully headless.** Never prompt for input. Honor `maxIterations` from `repair-config.yml`; if it is reached without a green build, do not commit the attempted changes. Report the failure and remaining errors.
6. **No auto-merge.** Successful fixes land as reviewable commits only.
7. **Work only in the existing checkout.** The PR is already checked out at `$GITHUB_WORKSPACE`. **Never `git clone` the repository or create a second working copy** (e.g. under `/tmp` or the agent working dir) — a duplicate clone bloats the run artifacts by hundreds of MB and can stall or cancel the downstream comment-delivery job.

## Steps

> **Before any step, `cd "$GITHUB_WORKSPACE"`.** Your current working directory is *not* the checkout. Run every `git`, build, and script command from `$GITHUB_WORKSPACE` (or address files by absolute `$GITHUB_WORKSPACE/...` paths). Relative paths like `.github/skills/...` or `repair-results/...` will otherwise resolve outside the repo and fail. Keep all scratch output under `$RUNNER_TEMP` (never the agent working dir), so it is not swept into the run artifacts.

1. Identify the single failing SDK package path from the PR diff. **Record the current PR head sha** (`git rev-parse HEAD`) as the pre-repair sha — the summary in Step 5 uses it to diff changed files. Create `$RUNNER_TEMP/repair-results` and collect the package's build errors by building the changed package, **redirecting the raw build output to `$RUNNER_TEMP/repair-results/pre-repair-errors.txt`** — the Step 5 emitter parses this to list the errors it fixed (a first-try success leaves no `buildResult` in the engine result, so this capture is the only source for the "Build Errors Fixed" list). This is a mechanical redirect, not authored content. **If the package already builds cleanly (no errors), there is nothing to repair: skip Steps 2–4, render the already-green summary using the `skipped_already_green` invocation in Step 5, post it, and end.**
2. Apply the `auto-build-repair` skill workflow: call the engine with `--edit-scope CustomCode`, the `--package-path`, and the build errors as `--customization-request`, **redirecting each attempt's `-o json` output to `$RUNNER_TEMP/repair-results/result-<n>.json`**; re-invoke (idempotent) only while the error set keeps shrinking, up to `maxIterations`.
3. Inspect each structured result. Stop on the skill's stop conditions (`SpecChangeRequired`, `RegenerateFailed` at the pinned commit, suspected generator bug, or `maxIterations` reached) — do not retry past them or escalate to a human prompt.
4. **Gate the push on a green build.** Inspect the final `result-<n>.json` and invoke the `push-to-pull-request-branch` safe output (custom-code edits + regenerated `Generated/`) **only when its `success` property is exactly `true`**. That structured success value is the engine's proof that the final package build passed. Do not infer a green build from a successful tool invocation, a smaller error set, applied patches, or exhausted iterations. For every other terminal state — including `SpecChangeRequired`, `RegenerateFailed`, no progress, a suspected generator bug, `maxIterations` reached, a missing/unparseable final result, or any final result whose `success` is not `true` — **do not invoke `push-to-pull-request-branch`**. Render and post the failure report with `add-comment` only; attempted repair changes remain uncommitted in the ephemeral workspace and are discarded when the run ends.
5. **Render the summary comment deterministically and post it verbatim.** Do **not** author the comment yourself — run the checked-in emitter, which builds the entire comment (classified build errors, files changed with a generated-vs-custom split, iterations, final result, and the machine-readable telemetry object) from the result files, `git`, and env only:

   ```bash
   pwsh "$GITHUB_WORKSPACE/.github/skills/auto-build-repair/emit-repair-report.ps1" \
     -ResultsDir "$RUNNER_TEMP/repair-results" \
     -PreRepairErrorsFile "$RUNNER_TEMP/repair-results/pre-repair-errors.txt" \
     -PackagePath "<failing SDK package dir>" \
     -PreRepairSha "<pre-repair sha from Step 1>" \
     -Pr <pr-number> -HeadSha "<pr-head-sha>" -Repo "$GITHUB_REPOSITORY" \
     -MaxIterations <maxIterations> \
     -OutFile "$RUNNER_TEMP/repair-comment.md"
   ```

   Then pass the **exact contents** of `$RUNNER_TEMP/repair-comment.md` as the `add-comment` body — unedited, unsummarized, unreordered. The emitter already appends `--generated by Copilot`. Emit this comment on **every** terminal outcome (repaired, still-failing/stop-condition, already-green) so no run silently degrades.

   **Already-green outcome (from Step 1):** if the package built cleanly and no engine attempt ran, there is no `result-*.json`. Do **not** use the invocation above (with no engine result it would derive a `failed`/`NoEngineResult` status). Instead render the already-green summary explicitly so the status and telemetry are correct:

   ```bash
   pwsh "$GITHUB_WORKSPACE/.github/skills/auto-build-repair/emit-repair-report.ps1" \
     -ForcedStatus skipped_already_green \
     -PackagePath "<failing SDK package dir>" \
     -Pr <pr-number> -HeadSha "<pr-head-sha>" -Repo "$GITHUB_REPOSITORY" \
     -MaxIterations <maxIterations> \
     -OutFile "$RUNNER_TEMP/repair-comment.md"
   ```
