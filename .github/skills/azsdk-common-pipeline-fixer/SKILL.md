---
name: azsdk-common-pipeline-fixer
license: MIT
metadata:
  version: "1.0.0"
  distribution: shared
description: 'Automatically fix Azure SDK CI/CD pipeline failures by applying code changes and verifying locally. USE FOR: "fix pipeline failure", "fix CI", "fix failing tests", "fix build error", "auto-fix pipeline", "resolve pipeline failure". DO NOT USE FOR: pipeline analysis only (use azsdk-common-pipeline-troubleshooting), API design review, SDK publishing. INVOKES: azure-sdk-mcp:azsdk_analyze_pipeline, azure-sdk-mcp:azsdk_package_build_code, azure-sdk-mcp:azsdk_package_run_check, azure-sdk-mcp:azsdk_package_run_tests, azure-sdk-mcp:azsdk_verify_setup.'
compatibility: "azure-sdk-mcp server, local azure-sdk-for-{language} clone, language build tools"
---

# Pipeline Fixer

This skill automatically fixes Azure SDK CI/CD pipeline failures. It analyzes the failure, identifies the root cause, applies code changes, and verifies the fix locally using build, check, and test tools before committing.

## Triggers

USE FOR: fix pipeline failure, fix CI, fix failing tests, fix build error, auto-fix pipeline, resolve pipeline failure, fix my PR pipeline
WHEN: "fix pipeline", "fix CI", "fix failing tests", "fix build error", "auto-fix", "resolve pipeline failure", "fix my PR"
DO NOT USE FOR: analysis only (use azsdk-common-pipeline-troubleshooting), API design review, SDK publishing, infrastructure failures that need retry

## Rules

- Requires the `azure-sdk-mcp` server and a local clone of the SDK language repository.
- Always analyze the pipeline first before attempting any fix.
- Do NOT attempt to fix infrastructure failures (network timeouts, agent crashes, throttling) - recommend retry instead.
- After applying a fix, ALWAYS verify using the `azure-sdk-mcp` package tools (build, then check, then tests) before committing - never by running raw build/test commands in the shell. See Guardrails.
- If a fix fails verification, iterate (try a different approach) up to 3 times before reporting inability to fix.
- Work on the PR branch - the code that caused the failure is on this branch, not main.
- Identify the package path from the analysis output (e.g. `sdk/ai/azure-ai-projects` for Python, or the .csproj path for .NET).

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

1. **Find the analysis** - The pipeline analysis should already exist. Look for it in:
   - A GitHub PR comment from the pipeline analysis skill (search the current PR's comments)
   - The Azure DevOps pipeline summary markdown
   - If no analysis exists, run `azure-sdk-mcp:azsdk_analyze_pipeline` with the build ID or PR link as a fallback.

2. **Classify the failure** - From the analysis, determine if it's fixable:
   - **Fixable:** test failures, type errors, lint errors, missing imports, assertion errors
   - **Not fixable (retry):** network timeouts, DNS failures, agent crashes, service outages
   - **Needs human input:** breaking API changes, design decisions, credential issues

3. **Identify the package** - From the analysis output, determine:
   - Which SDK package is affected (e.g. `sdk/ai/azure-ai-projects`)
   - The absolute path to the package on disk
   - Which specific files and lines need changes

4. **Read the failing code** - Open the affected file(s) at the cited line numbers. Understand the context around the error.

5. **Apply the fix** - Make the code change that resolves the error. Common fixes:
   - Type errors: fix the type annotation or cast
   - Missing imports: add the import statement
   - Assertion failures: fix the logic bug (not the assertion)
   - Recording issues: note that re-recording is needed (can't auto-fix)

6. **Verify the fix** - Verify ONLY through the `azure-sdk-mcp` package tools. Run these tools in order on the package path (do NOT substitute raw shell build/test commands):
   1. `azure-sdk-mcp:azsdk_package_build_code` - must pass
   2. `azure-sdk-mcp:azsdk_package_run_check` - must pass
   3. `azure-sdk-mcp:azsdk_package_run_tests` - must pass

7. **Iterate if needed** - If verification fails:
   - Read the new error output
   - Apply a revised fix
   - Re-verify
   - Give up after 3 attempts and report what you tried

8. **Commit** - Once all three verification steps pass, commit the fix with a descriptive message.

## Guardrails

- **ALWAYS verify with the `azure-sdk-mcp` package tools** - run `azure-sdk-mcp:azsdk_package_build_code`, then `azure-sdk-mcp:azsdk_package_run_check`, then `azure-sdk-mcp:azsdk_package_run_tests`. These wrap the exact build/check/test steps CI runs, so passing them is what proves the pipeline failure is fixed.
- **NEVER verify by running raw build or test commands in the shell** (e.g. `dotnet build`/`dotnet test`, `pytest`, `mvn`, `gradle`, `npm`/`pnpm`/`rush run build|test`). Shell invocations bypass the CI-equivalent verification the MCP tools provide and do not count as verification.
- If a verification tool fails because the environment is not fully set up, **report the failure returned by that tool** and run `azure-sdk-mcp:azsdk_verify_setup` - do not fall back to manual shell build/test commands.
- Use ordinary shell commands only for non-verification tasks (e.g. `git` operations, reading files). The build → check → tests verification path must go through the MCP tools.

## Language-Specific Notes

See [language-specific notes](references/language-notes.md) for per-language package-path patterns, what each `azsdk_package_run_check` covers, common fixes, and the failure types this skill cannot fix (re-recording, infrastructure, breaking API changes).

## Examples

- "Fix the pipeline failure for build 6447834"
- "My Python SDK CI is failing with a type error, fix it"
- "The tests are failing in my PR, auto-fix them"
- "Fix the mypy errors in my pipeline"

## Troubleshooting

- If `azsdk_package_build_code`/`run_check`/`run_tests` fail because the environment is not ready, run `azure-sdk-mcp:azsdk_verify_setup` and report the tool's error — do not fall back to raw shell build/test commands.
- If a failure is a recording/playback issue, it needs Azure credentials and live service access to re-record; report that re-recording is required rather than auto-fixing.
- If a failure is infrastructure/transient (network, throttling, agent crash), recommend retrying the pipeline instead of changing code.
- If a fix would require a breaking API change or design decision, stop and escalate to a human.
- After 3 failed fix-and-verify attempts, report what you tried and the remaining error. See [language-specific notes](references/language-notes.md) for the full unfixable list.
