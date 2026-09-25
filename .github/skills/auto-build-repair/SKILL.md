---
name: auto-build-repair
description: "Repair custom-code build failures in generated Azure SDK pull requests with one bounded customized-update invocation. WHEN: an eligible release-planner Auto SDK PR labeled auto-sdk-build-fix needs repair, or requests mention auto build repair, custom-code build repair, or fixing the SDK PR build. Not for migrations, TypeSpec authoring, or API review."
---
# Auto Build Repair

Repair an already-generated, eligible Auto SDK PR **headlessly**. Use only the
shared `azsdk tsp client customized-update` engine, also exposed as
`azure-sdk-mcp:azsdk_customized_code_update`. Never hand-edit source, prompt for
input, switch repair engines, or auto-merge.

## Configuration and capability

Read the co-located [repair-config.yml](repair-config.yml). Its `maxIterations`
value is the bound passed into the engine, **not a number of tool invocations**.
Preserve the cross-language default of 3 when the file or key is absent; reject
values outside the engine's integer range 1..10.

The CLI must advertise `--max-attempts` in
`azsdk tsp client customized-update --help`. For MCP, the tool must expose the
typed `maxAttempts` parameter. If unavailable, stop and report the unsupported
capability; do not fall back to an outer retry loop.

This requires the engine change in
[Azure/azure-sdk-tools#17068](https://github.com/Azure/azure-sdk-tools/pull/17068).
Keep the consumer PR draft until that change is merged and released. The
latest-release installer alone does not prove the capability exists; do not
invent a released minimum version.

## Invoke once

Identify the single failing package and collect its build-error output. Preserve
that raw output as `pre-repair-errors.txt` for reporting. If the package is
already green, skip the engine and report `skipped_already_green`.

Invoke **exactly once**, passing the configured bound:

```text
azsdk -o json tsp client customized-update
  --edit-scope CustomCode
  --package-path <single failing SDK package directory>
  --customization-request <build errors and failure context>
  --max-attempts <maxIterations from repair-config.yml>
```

The equivalent MCP arguments are `editScope: "CustomCode"`, `packagePath`,
`customizationRequest`, and `maxAttempts: <configured maxIterations>`.
**Omit `tspProjectPath`** so regeneration uses the pinned `tsp-location.yaml`.
Do not introduce a repair-mode, timeout, or artifact option.

The engine owns patching, regeneration/build validation, and retries. Its
iterations reuse one conversation with validation feedback and retain earlier
source edits. Separate CLI/MCP invocations do not retain that conversation.
**There is no outer retry loop**, even if errors shrink or attempts remain.

Capture the complete final JSON response as `result.json` in the results
directory. Do not manufacture responses, diagnostics, or build evidence. If the
process fails, retain its actual output/error for the failure report; do not
substitute an earlier successful result.

## Scope and stopping

Only the selected package's custom code may be patched. Only the generator may
update `Generated/`, from unchanged pinned inputs. Never change TypeSpec,
`tsp-location.yaml`, package metadata, tests, other packages, `.github`, `eng`,
shared build files, dependencies, or secrets.

Stop when the single invocation finishes. Surface its final build diagnostics
and guidance for spec changes, manual intervention, regeneration/build failure,
exhausted iterations, cancellation, or infrastructure failure. Do not retry the
command or finish the repair manually.

Commit custom-code edits and regenerated output through the workflow's existing
safe output **only after the final package build is green** and the final
response has Boolean `success: true`. Tool completion, applied patches, fewer
errors, or reaching the bound do not establish a green build. Missing,
malformed, or failing final results never authorize a push. Failed changes stay
uncommitted; successful changes still require human review.

## Deterministic reporting

Run [emit-repair-report.ps1](emit-repair-report.ps1), then post its output
verbatim through the existing `add-comment` safe output. Do not author the
comment or telemetry yourself.

- Pass `-ResultsDir` containing the single `result.json`, the captured
  `-PreRepairErrorsFile`, package/PR identity, and configured `-MaxIterations`.
- Iterations come from `attemptsUsed`: completed patch proposals reaching host
  validation, including a no-progress proposal. Baseline/classifier-only builds
  and tool/Exit reminders do not count. Never count JSON files or infer attempts
  from patches or prose; a missing count is unknown, not a fabricated number.
- Explain **why** repair failed using final `buildResult`, `response_error`,
  `errorCode`, and available spec/manual guidance. Include attempted file
  changes, the stop reason/count, next action, and workflow logs—not just exit 1.
- Preserve the existing generated/custom file attribution and eight telemetry
  fields in [telemetry-schema.v1.json](telemetry-schema.v1.json).
- For no-engine outcomes, use the renderer's `-Eligible:$false` or
  `-ForcedStatus skipped_already_green` path as documented by the workflow.

The renderer appends `--generated by Copilot`. Request a report on every terminal
outcome; infrastructure failures that prevent reporting remain visible in
Actions status/logs.

## Existing workflow environment

Work in the existing checkout at `$GITHUB_WORKSPACE`; do not clone or create a
second working copy. Keep scratch under `$RUNNER_TEMP` as prescribed by the
workflow. Preserve its eligibility checks, authentication, network restrictions,
protected-file rules, and existing success-only safe-output publisher.
