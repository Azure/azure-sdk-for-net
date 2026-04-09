---
name: azsdk-common-pipeline-troubleshooting
license: MIT
metadata:
  version: "1.0.0"
  distribution: shared
description: "Diagnose and resolve failures in Azure SDK CI and generation pipelines. **UTILITY SKILL**. USE FOR: \"pipeline failed\", \"build failure\", \"CI check failing\", \"SDK generation error\", \"reproduce pipeline locally\", \"debug SDK pipeline\". DO NOT USE FOR: local build issues without pipeline context, API design review, SDK publishing. INVOKES: azure-sdk-mcp:azsdk_analyze_pipeline, azure-sdk-mcp:azsdk_package_build_code, azure-sdk-mcp:azsdk_package_run_check."
compatibility:
  requires: "azure-sdk-mcp server, Azure DevOps pipeline build ID"
---

# Pipeline Troubleshooting

## MCP Tools

| Tool                       | Purpose                  |
| -------------------------- | ------------------------ |
| `azure-sdk-mcp:azsdk_analyze_pipeline`   | Analyze pipeline failure |
| `azure-sdk-mcp:azsdk_verify_setup`       | Verify local environment |
| `azure-sdk-mcp:azsdk_package_build_code` | Reproduce build locally  |
| `azure-sdk-mcp:azsdk_package_run_check`  | Run validation checks    |
| `azure-sdk-mcp:azsdk_package_pack`       | Create SDK packages      |

**Prerequisites:** azure-sdk-mcp server required. Without MCP, view pipeline logs in Azure DevOps UI.

## Steps

1. **Identify** — Get build ID, run `azure-sdk-mcp:azsdk_analyze_pipeline`. Categorize failure.
2. **Analyze** — See [failure patterns](references/failure-patterns.md) for common causes.
3. **Reproduce** — Verify setup, then run `azure-sdk-mcp:azsdk_package_build_code` or `azure-sdk-mcp:azsdk_package_run_check`.
4. **Fix** — Apply fixes for code or TypeSpec issues.
5. **Verify** — Confirm fix locally, push, monitor re-run.

## Examples

- "My pipeline build 12345 failed, help debug it"
- "Reproduce CI failure locally"

## Troubleshooting

If `azure-sdk-mcp:azsdk_analyze_pipeline` returns no data, verify build ID and MCP. Without MCP, check pipeline logs in Azure DevOps UI.
