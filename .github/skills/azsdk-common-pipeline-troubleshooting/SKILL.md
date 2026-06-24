---
name: azsdk-common-pipeline-troubleshooting
license: MIT
metadata:
  version: "1.0.0"
  distribution: shared
description: 'Analyze Azure SDK CI/CD pipeline failures and provide actionable diagnosis. **UTILITY SKILL**. USE FOR: "pipeline failed", "build failure", "CI check failing", "tests failing in CI", "analyze pipeline", "what went wrong in my pipeline", "debug SDK pipeline". DO NOT USE FOR: local build issues without pipeline context, API design review, SDK publishing, applying code fixes (use azsdk-common-pipeline-fixer for that). INVOKES: azure-sdk-mcp:azsdk_analyze_pipeline, azure-sdk-mcp:azsdk_get_pipeline_llm_artifacts, azure-sdk-mcp:azsdk_get_pr_checks, azure-sdk-mcp:azsdk_get_pipeline_status.'
compatibility: "azure-sdk-mcp server, Azure DevOps pipeline build ID or GitHub PR link"
---

# Pipeline Analysis

This skill analyzes Azure SDK CI/CD pipeline failures and provides a structured diagnosis including root cause, affected files, and concrete instructions for how to fix each issue. It does NOT apply fixes - it tells you exactly what's wrong and how to resolve it.

## Triggers

USE FOR: pipeline failed, build failure, CI check failing, tests failing in CI, analyze pipeline, what went wrong, debug SDK pipeline
WHEN: GitHub PR comment asking Copilot to analyze failed CI; pipeline step after other steps that writes diagnosis to the pipeline summary; "pipeline failed", "build failure", "CI check failing", "tests failing", "analyze pipeline", "what went wrong", "why is CI red", "debug pipeline"
DO NOT USE FOR: applying code fixes (use azsdk-common-pipeline-fixer), local build issues without pipeline context, API design review, SDK publishing

## Rules

- Requires the `azure-sdk-mcp` server; without MCP, inspect logs in the Azure DevOps UI.
- Analysis-only: do not edit files, commit, or apply fixes. Use `azsdk-common-pipeline-fixer` for code changes.
- Always run `azure-sdk-mcp:azsdk_analyze_pipeline` first to get structured failure data.
- Categorize each failure as: test failure, build/compilation error, validation/lint error, or infrastructure issue.
- For infrastructure issues (network timeouts, agent crashes, throttling), recommend retrying the pipeline rather than code changes.
- When multiple tests fail, look for a common root cause (shared fixture, setup failure, missing dependency) before listing individual failures.
- Always cite specific file paths and line numbers from the analysis output.
- Format your response with markdown headers for readability.

## MCP Tools

| Tool                                              | Purpose                                         |
| ------------------------------------------------- | ----------------------------------------------- |
| `azure-sdk-mcp:azsdk_analyze_pipeline`            | Analyze pipeline failure (logs + test results)  |
| `azure-sdk-mcp:azsdk_get_pipeline_llm_artifacts`  | Download test result artifacts from pipeline    |
| `azure-sdk-mcp:azsdk_get_pr_checks`               | Get pipeline/check results linked to a PR       |
| `azure-sdk-mcp:azsdk_get_pipeline_status`          | Get pipeline run status                         |

**Prerequisites:** azure-sdk-mcp server required. Without MCP, view pipeline logs in Azure DevOps UI.

## Steps

1. **Get pipeline identifier** - Obtain the build ID, pipeline URL, or GitHub PR link. If triggered from a PR comment, use the PR link; if triggered as a pipeline step, use the current run and save the report to the pipeline summary.
2. **Analyze** - Run `azure-sdk-mcp:azsdk_analyze_pipeline` with the identifier. This returns:
   - `failed_tasks`: Log errors from failed pipeline steps (build errors, lint failures, type check errors)
   - `failed_test_titles`: Failed test names grouped by test result file
3. **Categorize** each failure:
   - **Test failure** - assertion errors, exceptions, timeouts in test code
   - **Build/compilation error** - type errors, missing imports, syntax errors
   - **Validation error** - lint violations, format errors, changelog issues, API compat breaks
   - **Infrastructure failure** - network timeouts, agent crashes, throttling → recommend retry
4. **Diagnose** - For each failure, provide:
   - The root cause (what's wrong and why)
   - The affected file(s) and line number(s)
   - Whether failures are independent or cascading from one root cause
5. **Prescribe fix** - For each fixable failure, provide:
   - The specific code change needed (what to change, where)
   - The local command to verify the fix (e.g. `python -m mypy --isolate <path>`, `dotnet test --filter <test>`)
   - Any prerequisites (e.g. "update recordings", "install missing dependency")
6. **Report** - Present the diagnosis using [output format](references/output-format.md): root cause, affected package/files, per-failure category/error/fix/verify command, and fixable vs infrastructure summary. End by recommending `azsdk-common-pipeline-fixer` for applying fixable changes.

## Examples

- "My pipeline build 6447834 failed, what went wrong?"
- PR comment: `@copilot Analyze the failed pipeline on this PR`
- Pipeline step: analyze failed run after other steps and save the report to the pipeline summary
- "Why is my pipeline red? Build ID is 6455939"
- "What's failing in https://dev.azure.com/azure-sdk/public/_build/results?buildId=12345"

## Troubleshooting

- If `azsdk_analyze_pipeline` returns no data, verify the build ID is correct and the pipeline has completed.
- If `failed_test_titles` is empty, the repo may not have test result artifact upload configured - rely on `failed_tasks` log analysis instead.
- If the failure is in a private/internal pipeline, the user may need to authenticate with `az login`.
- See [failure patterns](references/failure-patterns.md) for common failure categories and resolutions.
