---
name: azsdk-common-sdk-release
license: MIT
metadata:
  version: "1.1.0"
  distribution: shared
description: "Check release readiness and trigger the release pipeline for Azure SDK packages. **UTILITY SKILL**. USE FOR: \"release SDK\", \"trigger release\", \"check release readiness\", \"release pipeline\", \"publish package\", \"ship SDK\", \"check package readiness\". DO NOT USE FOR: SDK development, code generation, pipeline debugging, release plan creation. INVOKES: azure-sdk-mcp:azsdk_release_sdk."
compatibility:
  requires: "azure-sdk-mcp server, SDK package merged on release branch"
  supports: ".NET, Java, JavaScript, Python, Go"
---

# SDK Release

## MCP Tools

| Tool                | Purpose                                                     |
| ------------------- | ----------------------------------------------------------- |
| `azure-sdk-mcp:azsdk_release_sdk` | Check release readiness and/or trigger the release pipeline |

## Steps

1. **Collect Info** — Ask for exact `packageName` and `language` (case sensitive: Python, Java, JavaScript, .NET, Go). Optionally get `branch` (defaults to main).
2. **Check Readiness** — Run `azure-sdk-mcp:azsdk_release_sdk` with `checkReady: true`. This verifies:
   - API review approval status
   - Changelog status
   - Package name approval (if new package releasing preview)
   - Release date is set in release tracker
   > **Important:** Do not check for existing pull requests or ask the user to create a release plan before running the readiness check.
3. **Review Results** — If ready, highlight and provide the release pipeline link. If not ready, display each failing check and guide user to resolve specific issues.
4. **Trigger Release** — Once ready, run `azure-sdk-mcp:azsdk_release_sdk` with `checkReady: false`. Show pipeline link and inform user they must approve the release stage in the pipeline. Warn that the package will be published to public registries once approved.

## Expected Interaction Flow

1. Ask: "What is the exact name of the package you want to check for release readiness?"
2. Ask: "Please select the programming language: Python, Java, JavaScript, .NET, or Go"
3. Execute the readiness check
4. Display results and next steps

## Examples

- "Check if azure-storage-blob is ready for release"
- "Trigger release for @azure/core-rest-pipeline on JavaScript"
- "Release the Python SDK package"

## Troubleshooting

- If readiness check fails, review each failing prerequisite individually before re-triggering.
- Requires `azure-sdk-mcp` server. No CLI fallback — prompt user to configure MCP if unavailable.
