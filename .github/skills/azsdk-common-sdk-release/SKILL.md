---
name: azsdk-common-sdk-release
license: MIT
metadata:
  version: "1.0.0"
  distribution: shared
description: 'Check release readiness and trigger the release pipeline for Azure SDK packages. **UTILITY SKILL**. USE FOR: "release SDK", "trigger release", "check release readiness", "release pipeline", "publish package", "ship SDK". DO NOT USE FOR: SDK development, code generation, pipeline debugging, release plan creation. INVOKES: azure-sdk-mcp:azsdk_release_sdk.'
compatibility: "azure-sdk-mcp server, SDK package merged on release branch. Supports .NET, Java, JavaScript, Python, Go"
---

# SDK Release

This skill checks release readiness and triggers the Azure SDK release pipeline for packages that are already prepared, guiding the user through prerequisite validation, readiness review, and the final pipeline launch with required approval steps.

## Triggers

USE FOR: release SDK, trigger release, check release readiness, release pipeline, publish package, ship SDK
WHEN: "release SDK", "trigger release", "check release readiness", "release pipeline", "publish package", "ship SDK"
DO NOT USE FOR: SDK development, code generation, pipeline debugging, release plan creation

## Rules

- Requires the `azure-sdk-mcp` server; there is no CLI fallback for the release workflow.
- Collect `packageName` and `language`, then run the readiness check before attempting to trigger release.
- If release is triggered, show the pipeline link and remind the user that the release stage still requires approval.

## MCP Tools

| Tool                              | Purpose                                                     |
| --------------------------------- | ----------------------------------------------------------- |
| `azure-sdk-mcp:azsdk_release_sdk` | Check release readiness and/or trigger the release pipeline |

## Steps

1. **Collect Info** — Get `packageName` and `language` from the user. Optionally get `branch` (defaults to main).
2. **Determine Intent** — If the user explicitly asks to "check readiness" or "check if ready", run `azure-sdk-mcp:azsdk_release_sdk` with `checkReady: true`. Otherwise, proceed to trigger the release directly.
3. **Trigger Release** — Run `azure-sdk-mcp:azsdk_release_sdk` with `checkReady: false` (the default). Show pipeline link and inform user they must approve the release stage.
4. **Review Results** — If the release fails due to readiness issues, display failing checks and guide user to resolve.

## Examples

- "Check if azure-storage-blob is ready for release"
- "Trigger release for @azure/core-rest-pipeline on JavaScript"

## Troubleshooting

- If readiness check fails, review each failing prerequisite individually before re-triggering.
- Requires `azure-sdk-mcp` server. No CLI fallback — prompt user to configure MCP if unavailable.
