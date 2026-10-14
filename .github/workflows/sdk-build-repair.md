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

imports:
  - shared/copilot-cli-version-probe-guard.md
  - shared/agent-output-validation.md

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

engine:
  id: copilot
  version: "1.0.80"

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
  AZSDK_REPAIR_RESULTS_DIR: /tmp/gh-aw/sandbox/agent/logs/repair-results

network:
  allowed:
    - defaults
    - dotnet
    - github
    # Pinned TypeSpec regeneration installs tsp-client and emitter dependencies from npm.
    - registry.npmjs.org
    # The nested azsdk Copilot client calls this API directly, unlike the outer managed-proxy agent.
    - api.githubcopilot.com

# Install tools after gh-aw checks out the PR head, so SDK selection and the
# baseline build read the same global.json.
# Install the shared azsdk CLI (the engine) onto PATH before the agent runs. The agent
# then invokes `azsdk tsp client customized-update` from bash. (gh-aw cannot host the
# stdio azsdk MCP server directly; see header.)
pre-agent-steps:
  - name: Configure isolated .NET installation
    shell: pwsh
    run: |
      # gh-aw mounts tool-cache bins in the sandbox. Only this job's approved SDK
      # is installed here; rollForward cannot select a newer hosted SDK.
      $root = Join-Path $env:RUNNER_TOOL_CACHE "repair-dotnet/$env:GITHUB_RUN_ID-$env:GITHUB_RUN_ATTEMPT/bin"
      @(
        "DOTNET_INSTALL_DIR=$root"
        "DOTNET_ROOT=$root"
        "DOTNET_HOST_PATH=$root/dotnet"
        "DOTNET_MULTILEVEL_LOOKUP=0"
      ) | Add-Content -LiteralPath $env:GITHUB_ENV
  - name: Install approved .NET SDK
    uses: actions/setup-dotnet@v6.0.0
    with:
      global-json-file: global.json
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
  # Deterministic report recovery requires the hosted runner's PowerShell.
  runs-on: ubuntu-latest
  # Preserve the exact recorded command's URLs inside its code block.
  urls: allowed-or-code-region
  steps:
    - name: Disable implicit tag fetching
      if: ${{ (!cancelled()) && needs.agent.result != 'skipped' && contains(needs.agent.outputs.output_types, 'push_to_pull_request_branch') }}
      run: git config remote.origin.tagOpt --no-tags
    - name: Checkout reporting helpers
      if: ${{ !contains(needs.agent.outputs.output_types, 'push_to_pull_request_branch') }}
      uses: actions/checkout@v7.0.1
      with:
        persist-credentials: false
    - name: Complete terminal repair report
      shell: pwsh
      env:
        REPAIR_AGENT_OUTPUT: ${{ steps.setup-agent-output-env.outputs.GH_AW_AGENT_OUTPUT }}
        REPAIR_AGENT_OUTCOME: ${{ needs.agent.result }}
        REPAIR_PR: ${{ github.event.pull_request.number || github.event.issue.number }}
        REPAIR_HEAD_SHA: ${{ github.event.pull_request.head.sha || github.sha }}
      run: |
        ./.github/skills/auto-build-repair/complete-repair-report.ps1 `
          -AgentOutputFile $env:REPAIR_AGENT_OUTPUT `
          -ResultsDir /tmp/gh-aw/sandbox/agent/logs/repair-results `
          -Pr $env:REPAIR_PR -HeadSha $env:REPAIR_HEAD_SHA `
          -AgentOutcome $env:REPAIR_AGENT_OUTCOME
    - name: Upload recovered repair report
      if: always()
      uses: actions/upload-artifact@v7.0.1
      with:
        name: repair-report
        path: /tmp/gh-aw/sandbox/agent/logs/repair-results/
        if-no-files-found: ignore
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

The skill drives the shared **`azsdk_customized_code_update`** engine. In this workflow the engine is the **`azsdk` CLI** (installed onto PATH by the setup step), not the MCP server. Read `maxIterations` from `repair-config.yml` and invoke the engine **exactly once**, passing that value as `--max-attempts`. The engine retains one conversation across its validation retries. Capture its single final `CustomizedCodeUpdateResponse` with the global `-o json` flag:

```bash
export PATH="$DOTNET_ROOT:$PATH"
mkdir -p "$AZSDK_REPAIR_RESULTS_DIR"
rm -f "$AZSDK_REPAIR_RESULTS_DIR/engine-command.txt"
if ! azsdk tsp client customized-update --help \
  > "$AZSDK_REPAIR_RESULTS_DIR/capability.txt" \
  2> "$AZSDK_REPAIR_RESULTS_DIR/engine-errors.txt"; then
  exit 1
fi
if ! grep -Fq -- '--max-attempts' "$AZSDK_REPAIR_RESULTS_DIR/capability.txt"; then
  printf '%s\n' 'Installed azsdk does not support --max-attempts; the bounded engine release is required.' \
    > "$AZSDK_REPAIR_RESULTS_DIR/engine-errors.txt"
  exit 1
fi
engine_command=(
  azsdk -o json tsp client customized-update
  --edit-scope CustomCode
  --package-path "<failing SDK package dir>"
  --customization-request "<the build errors / failure context>"
  --max-attempts "<maxIterations from repair-config.yml>"
)
engine_command_text=''
for engine_argument in "${engine_command[@]}"; do
  LC_ALL=C printf -v engine_argument_text '%q' "$engine_argument"
  if [[ "$engine_argument_text" == "\$'"* ]]; then
    engine_argument_text=${engine_argument_text//&/'\x26'}
  fi
  engine_command_text+="$engine_argument_text "
done
printf '%s\n' "${engine_command_text% }" \
  > "$AZSDK_REPAIR_RESULTS_DIR/engine-command.txt" || exit 1
if "${engine_command[@]}" \
  > "$AZSDK_REPAIR_RESULTS_DIR/engine-stdout.txt" \
  2> "$AZSDK_REPAIR_RESULTS_DIR/engine-stderr.txt"; then
  engine_exit=0
else
  engine_exit=$?
fi
printf '%s\n' "$engine_exit" > "$AZSDK_REPAIR_RESULTS_DIR/engine-exit-code.txt"
pwsh "$GITHUB_WORKSPACE/.github/skills/auto-build-repair/capture-engine-result.ps1" \
  -ResultsDir "$AZSDK_REPAIR_RESULTS_DIR" \
  -MaxIterations "<maxIterations from repair-config.yml>"
```

The capture helper handles azsdk's failed JSON responses on stderr after process
diagnostics. It preserves both raw streams, consolidates diagnostics into
`engine-errors.txt`, and writes only the actual final response to `result.json`.
`engine-command.txt` records the same argument array that is executed, with Bash
escaping under the C locale to preserve argument boundaries and Unicode bytes
through comment sanitization. Ampersands within ANSI-C-quoted arguments are
encoded as `\x26` so global HTML-entity decoding cannot change their values.
Ordinary shell-escaped arguments are unchanged. The engine's locale is unchanged.
Do not author or abbreviate this record.
It returns the engine's nonzero exit code on a valid failure, or fails closed when
the response is missing, malformed, ambiguous, or contradicts the process outcome.
Do not merge stderr into JSON or extract a response manually.

Do not re-invoke the command or create per-attempt result files. A capability or process failure still goes to the failure report in Step 5; preserve the captured error, publish no changes, and do not invent an engine response. This requires [Azure/azure-sdk-tools#17068](https://github.com/Azure/azure-sdk-tools/pull/17068) to be released; an older installed CLI must fail closed rather than restore the outer loop.

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
5. **Fully headless.** Never prompt for input. Pass `maxIterations` from `repair-config.yml` as `--max-attempts` in the single engine invocation; the engine owns retries. If it stops without a green build, do not commit attempted changes. Report the failure and remaining errors.
6. **No auto-merge.** Successful fixes land as reviewable commits only.
7. **Work only in the existing checkout.** The PR is already checked out at `$GITHUB_WORKSPACE`. **Never `git clone` the repository or create a second working copy** (e.g. under `/tmp` or the agent working dir) — a duplicate clone bloats the run artifacts by hundreds of MB and can stall or cancel the downstream comment-delivery job.

## Steps

> **Before any step, `cd "$GITHUB_WORKSPACE"`.** Your current working directory is *not* the checkout. Run every `git`, build, and script command from `$GITHUB_WORKSPACE` (or address files by absolute `$GITHUB_WORKSPACE/...` paths). Relative paths like `.github/skills/...` or `repair-results/...` will otherwise resolve outside the repo and fail. Keep repair evidence in `$AZSDK_REPAIR_RESULTS_DIR`, the writable, secret-redacted and uploaded agent log directory. Other scratch output stays under `$RUNNER_TEMP`, never the agent working dir.

1. Identify the single failing SDK package path from the PR diff. Run the deterministic baseline helper once:

   ```bash
   pwsh "$GITHUB_WORKSPACE/.github/skills/auto-build-repair/invoke-repair-baseline.ps1" \
     -PackagePath "<failing SDK package dir>" -ResultsDir "$AZSDK_REPAIR_RESULTS_DIR"
   ```

   It verifies the selected SDK against `global.json`, records the checkout SHA in `context.json`, and captures the raw build output as `pre-repair-errors.txt` and its exit code as `baseline-exit-code.txt`. Read these files; never author them. The captured SHA is the pre-repair SHA for Step 5. **If the package already builds cleanly (no errors), there is nothing to repair: skip Steps 2–4, render the already-green summary using the `skipped_already_green` invocation in Step 5, post it, and end.** If restore, SDK selection, or other infrastructure prevents the baseline build, skip the engine and render the failure report in Step 5. Do not alter feeds, dependencies, or toolchain versions to work around it.
2. Apply the skill once: call the engine with `--edit-scope CustomCode`, `--max-attempts <configured maxIterations>`, the `--package-path`, and build errors as `--customization-request`. Record the executed argument array as `engine-command.txt`, both raw streams, and the process exit code, then run the checked-in capture helper to produce `result.json` and `engine-errors.txt`, as shown above. **Never run an outer retry loop**, even if the error set shrinks.
3. Inspect the final response and process outcome. Stop on success or any failure (`SpecChangeRequired`, failed regeneration/build, no progress, exhausted attempts, cancellation, or infrastructure error). Surface the actual diagnostics and guidance; do not retry or escalate to a human prompt.
4. **Gate the push on a green build.** Inspect `result.json` and invoke the `push-to-pull-request-branch` safe output (custom-code edits + regenerated `Generated/`) **only when the process succeeded and its `success` property is exactly `true`**. In the bounded CustomCode engine this means the final package build passed. Do not infer a green build from tool completion, a smaller error set, applied patches, or exhausted iterations. For every other terminal state, including missing/unparseable JSON or a non-Boolean success value, **do not invoke `push-to-pull-request-branch`**. Render and post the failure report with `add-comment` only; attempted changes remain uncommitted in the ephemeral workspace.
5. **Render the summary comment deterministically and post it verbatim.** Do **not** author the comment yourself — run the checked-in emitter, which uses the recorded command, final response, captured errors, `git`, and env. It displays the exact recorded invocation, reports the engine's `attemptsUsed`, not the number of files, and explains failures using actual diagnostics and guidance:

   ```bash
   pwsh "$GITHUB_WORKSPACE/.github/skills/auto-build-repair/emit-repair-report.ps1" \
     -ResultsDir "$AZSDK_REPAIR_RESULTS_DIR" \
     -PreRepairErrorsFile "$AZSDK_REPAIR_RESULTS_DIR/pre-repair-errors.txt" \
     -EngineErrorsFile "$AZSDK_REPAIR_RESULTS_DIR/engine-errors.txt" \
     -PackagePath "<failing SDK package dir>" \
     -PreRepairSha "<pre-repair sha from Step 1>" \
     -Pr <pr-number> -HeadSha "<pr-head-sha>" -Repo "$GITHUB_REPOSITORY" \
     -MaxIterations <maxIterations> \
     -CommandArtifactDir "/tmp/gh-aw/sandbox/agent/logs" \
     -OutFile "$RUNNER_TEMP/repair-comment.md"
   ```

   Then pass the **exact contents** of `$RUNNER_TEMP/repair-comment.md` as the `add-comment` body — unedited, unsummarized, unreordered. The emitter already appends `--generated by Copilot`. Emit this comment on **every** terminal outcome (repaired, still-failing/stop-condition, already-green) so no run silently degrades.

   If the agent aborts or returns incomplete output, the existing safe-output job
   runs `complete-repair-report.ps1` against the downloaded, secret-redacted evidence
   before the native `add-comment` handler. It produces a deterministic comment
   and removes every push request. It does not invoke the engine or manufacture
   a response. The original artifact is still validated, so infrastructure and
   incomplete-output failures remain visible as failed Actions runs.

   If the report would exceed the safe-output body's 65,000-character limit,
   the emitter saves the full command and report as `engine-command.txt` and
   `repair-report-full.md` in `-CommandArtifactDir` and links to workflow artifacts
   from a compact comment. This is the existing agent log directory, which gh-aw
   secret-redacts and uploads in its `agent` artifact. Never truncate or change the
   executed request to make the command fit, and never skip this artifact parameter.

   **Already-green outcome (from Step 1):** if the package built cleanly and no engine attempt ran, there is no `result.json`. Do **not** use the invocation above (with no engine result it would derive a `failed`/`NoEngineResult` status). Instead render the already-green summary explicitly so the status and telemetry are correct:

   ```bash
   pwsh "$GITHUB_WORKSPACE/.github/skills/auto-build-repair/emit-repair-report.ps1" \
     -ForcedStatus skipped_already_green \
     -PackagePath "<failing SDK package dir>" \
     -Pr <pr-number> -HeadSha "<pr-head-sha>" -Repo "$GITHUB_REPOSITORY" \
     -MaxIterations <maxIterations> \
     -OutFile "$RUNNER_TEMP/repair-comment.md"
   ```
