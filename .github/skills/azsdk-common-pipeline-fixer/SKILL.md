---
name: azsdk-common-pipeline-fixer
license: MIT
metadata:
  version: "1.0.0"
  distribution: shared
description: 'Automatically fix Azure SDK CI/CD pipeline failures by applying code changes and verifying locally. USE FOR: "fix pipeline failure", "fix CI", "fix failing tests", "auto-fix and commit the fix", "fix build error", "fix mypy/pylint/type-check/lint errors", "auto-fix pipeline", "resolve pipeline failure". DO NOT USE FOR: pipeline analysis only (use azsdk-common-pipeline-troubleshooting), API design review, SDK publishing. INVOKES: azure-sdk-mcp:azsdk_analyze_pipeline, azure-sdk-mcp:azsdk_package_build_code, azure-sdk-mcp:azsdk_package_run_check, azure-sdk-mcp:azsdk_package_run_tests, azure-sdk-mcp:azsdk_verify_setup.'
compatibility: "azure-sdk-mcp server, local azure-sdk-for-{language} clone, language build tools"
---

# Pipeline Fixer

This skill automatically fixes Azure SDK CI/CD pipeline failures. It analyzes the failure, identifies the root cause, applies code changes, and verifies the fix locally using build, check, and test tools before committing.

## Triggers

USE FOR: fix pipeline failure, fix CI, fix failing tests, auto-fix and commit the fix, fix build error, fix mypy/pylint/type-check/lint errors, auto-fix pipeline, resolve pipeline failure, fix my PR pipeline
WHEN: "fix pipeline", "fix CI", "fix failing tests", "auto-fix ... and commit", "fix build error", "fix mypy/type/lint error", "auto-fix", "resolve pipeline failure", "fix my PR"
DO NOT USE FOR: analysis only (use azsdk-common-pipeline-troubleshooting), API design review, SDK publishing, infrastructure failures that need retry

## Rules

- Requires the `azure-sdk-mcp` server and a local clone of the SDK language repo.
- Work on the PR branch — the failing code is there, not main.
- Analyze first, then apply the minimal code change for the root cause.
- Verify ONLY via the azsdk MCP package tools (build → check → tests); never raw shell build/test commands.
- Never fix infrastructure failures (timeouts, crashes, throttling) — recommend retry. Iterate up to 3 times, then report.

## MCP Tools

| Tool                                     | Purpose                                     |
| ---------------------------------------- | ------------------------------------------- |
| `azure-sdk-mcp:azsdk_analyze_pipeline`   | Analyze pipeline failure to identify issues |
| `azure-sdk-mcp:azsdk_verify_setup`       | Verify local environment is ready           |
| `azure-sdk-mcp:azsdk_package_build_code` | Build the package locally                   |
| `azure-sdk-mcp:azsdk_package_run_check`  | Run validation/lint/typecheck locally       |
| `azure-sdk-mcp:azsdk_package_run_tests`  | Run tests locally                           |

**Prerequisites:** azure-sdk-mcp server required. Local clone of the affected SDK language repo. Language build tools installed.

## Steps

1. **Find analysis** - Reuse an existing analysis from the PR comments; if none, run `azsdk_analyze_pipeline` with the build ID or PR link.
2. **Classify** - Fixable (test, type, lint, import, assertion errors) vs retry (infrastructure) vs escalate (breaking API, credentials).
3. **Locate** - Identify the affected package, its path, and the files/lines to change. See [language notes](references/language-notes.md).
4. **Fix** - Read the failing code at the cited lines and apply the minimal fix.
5. **Verify** - Run `azsdk_package_build_code` → `azsdk_package_run_check` → `azsdk_package_run_tests` on the package; all must pass. If the environment isn't ready, run `azsdk_verify_setup`. Never substitute raw shell build/test commands.
6. **Iterate & commit** - On failure, revise and re-verify (max 3 attempts). Once all pass, commit with a descriptive message.

## Examples

- "Fix the pipeline failure for build 6447834"
- "My Python SDK CI is failing with a type error, fix it"
- "Auto-fix the failing tests in my PR"

## Troubleshooting

- If verify tools fail because the environment isn't ready, run `azsdk_verify_setup` and report its error — don't fall back to shell.
- A recording/playback failure needs credentials + live service to re-record; report it rather than auto-fixing.
- A breaking API change or design decision: stop and escalate. See [language notes](references/language-notes.md) for the full unfixable list.
