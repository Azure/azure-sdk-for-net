---
name: azsdk-common-pipeline-analysis
license: MIT
metadata:
  version: "1.0.0"
  distribution: shared
description: 'Analyze Azure SDK CI/CD pipeline failures into a structured diagnosis, and define the required output format. Load this skill before calling azsdk_analyze_pipeline, which returns raw failure data that this skill interprets and formats. USE FOR: "pipeline failed", "build failure", "CI check failing", "tests failing in CI", "analyze pipeline", "debug SDK pipeline". DO NOT USE FOR: local build issues without pipeline context, API design review, SDK publishing, applying code fixes (instead use azsdk-common-pipeline-fixer). INVOKES: azure-sdk-mcp:azsdk_analyze_pipeline, azure-sdk-mcp:azsdk_get_pipeline_llm_artifacts, azure-sdk-mcp:azsdk_get_pr_checks, azure-sdk-mcp:azsdk_get_pipeline_status.'
compatibility: "azure-sdk-mcp server, Azure DevOps pipeline build ID or GitHub PR link"
---

# Pipeline Analysis

This skill analyzes Azure SDK CI/CD pipeline failures and provides a structured diagnosis including root cause, affected files, and concrete instructions for how to fix each issue. It does NOT apply fixes - it tells you exactly what's wrong and how to resolve it.

## Rules

- Load this skill **before** running `azsdk_analyze_pipeline` — the tool returns raw failure data that this skill interprets and formats per [output format](references/output-format.md).
- Requires the `azure-sdk-mcp` server; without it, inspect logs in the Azure DevOps UI.
- Analysis-only: never edit files or apply fixes — use `azsdk-common-pipeline-fixer` for changes.
- Run `azsdk_analyze_pipeline` first, then categorize each failure and cite specific files/lines.
- For infrastructure failures (network timeouts, agent crashes, throttling), recommend retry, not code changes.

## MCP Tools

| Tool                                             | Purpose                                        |
| ------------------------------------------------ | ---------------------------------------------- |
| `azure-sdk-mcp:azsdk_analyze_pipeline`           | Analyze pipeline failure (logs + test results) |
| `azure-sdk-mcp:azsdk_get_pipeline_llm_artifacts` | Download test result artifacts from pipeline   |
| `azure-sdk-mcp:azsdk_get_pr_checks`              | Get pipeline/check results linked to a PR      |
| `azure-sdk-mcp:azsdk_get_pipeline_status`        | Get pipeline run status                        |

## Steps

1. **Identify** - Get the build ID, pipeline URL, or PR link (use the PR link when triggered from a PR comment).
2. **Analyze** - Run `azsdk_analyze_pipeline`. It returns `failed_tasks` (log errors from failed steps) and `failed_test_titles` (failed tests grouped by file).
3. **Categorize** each failure: test, build/compilation, validation/lint, or infrastructure.
4. **Diagnose** - Give each failure's root cause and affected file(s)/line(s), and note if several share one root cause. See [failure patterns](references/failure-patterns.md).
5. **Report** - Use the [output format](references/output-format.md): root cause, affected files, per-failure fix + verify command, and fixable vs infrastructure. Recommend `azsdk-common-pipeline-fixer` to apply fixes.

## Examples

- "My pipeline build 6447834 failed, what went wrong?"
- PR comment: `@copilot Analyze the failed pipeline on this PR`
- "Why is my CI red? Build ID is 6455939"

## Troubleshooting

- If `azsdk_analyze_pipeline` returns no data, verify the build ID is correct and the run has completed.
- If `failed_test_titles` is empty, rely on `failed_tasks` log analysis (test-artifact upload may not be configured).
- For a private/internal pipeline, the user may need to `az login`. See [failure patterns](references/failure-patterns.md).
