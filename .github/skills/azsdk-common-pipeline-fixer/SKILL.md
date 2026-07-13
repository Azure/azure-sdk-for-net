---
name: azsdk-common-pipeline-fixer
license: MIT
metadata:
  version: "1.0.0"
  distribution: shared
description: 'Automatically fix Azure SDK CI/CD pipeline failures by applying code changes and verifying locally. USE FOR: "fix pipeline failure", "fix CI", "fix failing tests", "auto-fix and commit the fix", "fix build error", "fix mypy/pylint/type-check/lint errors", "auto-fix pipeline", "resolve pipeline failure". DO NOT USE FOR: pipeline analysis (instead use azsdk-common-pipeline-analysis), API design review, SDK publishing. INVOKES: azure-sdk-mcp:azsdk_package_build_code, azure-sdk-mcp:azsdk_package_run_check, azure-sdk-mcp:azsdk_package_run_tests, azure-sdk-mcp:azsdk_verify_setup.'
compatibility: "azure-sdk-mcp server, local azure-sdk-for-{language} clone, language build tools"
---

# Pipeline Fixer

This skill automatically fixes Azure SDK CI/CD pipeline failures. It analyzes the failure, identifies the root cause, applies code changes, and verifies the fix locally using build, check, and test tools before committing.

## Rules

- Requires the `azure-sdk-mcp` server and a local clone of the SDK language repo.
- Work on the PR branch — the failing code is there, not main.
- Analyze first, then apply the minimal code change for the root cause.
- Verify ONLY via the azsdk MCP package tools (build → check → tests); never raw shell build/test commands.
- Never fix infrastructure failures (timeouts, crashes, throttling) — recommend retry. Iterate up to 3 times, then report.

## MCP Tools

| Tool                                     | Purpose                               |
| ---------------------------------------- | ------------------------------------- |
| `azure-sdk-mcp:azsdk_verify_setup`       | Verify local environment is ready     |
| `azure-sdk-mcp:azsdk_package_build_code` | Build the package locally             |
| `azure-sdk-mcp:azsdk_package_run_check`  | Run validation/lint/typecheck locally |
| `azure-sdk-mcp:azsdk_package_run_tests`  | Run tests locally                     |

**Prerequisites:** azure-sdk-mcp server required. Local clone of the affected SDK language repo. Language build tools installed.

## Steps

1. **Find analysis** - Reuse an existing analysis from the PR comments; if none, view the `azsdk-common-pipeline-analysis` skill.
2. **Classify** - Fixable (test, type, lint, import, assertion errors) vs retry (infrastructure) vs escalate (breaking API, credentials).
3. **Locate** - Identify the affected package, its path, and the files/lines to change.
4. **Fix** - Read the failing code at the cited lines and apply the minimal fix.
5. **Verify** - Run `azsdk_package_build_code` → `azsdk_package_run_check` → `azsdk_package_run_tests` on the package; all must pass. If the environment isn't ready, run `azsdk_verify_setup`. Never substitute raw shell build/test commands.
6. **Iterate & commit** - On failure, revise and re-verify (max 3 attempts). Once all pass, commit with a descriptive message.

## Examples

- "Fix the pipeline failure for build 6447834"
- "My Python SDK CI is failing with a type error, fix it"
- "Auto-fix the failing tests in my PR"

## Troubleshooting

- If the verify tools fail because the environment isn't ready, run `azsdk_verify_setup`, report its error, and stop — don't fall back to raw shell build/test commands.
