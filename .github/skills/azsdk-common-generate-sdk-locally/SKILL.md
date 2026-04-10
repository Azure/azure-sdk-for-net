---
name: azsdk-common-generate-sdk-locally
license: MIT
metadata:
  version: "1.2.0"
  distribution: shared
description: "Generate, build, and test Azure SDKs locally from TypeSpec, with automatic customization to resolve build errors and apply SDK changes. **UTILITY SKILL**. USE FOR: \"generate SDK locally\", \"build SDK\", \"run SDK tests\", \"update changelog\", \"fix SDK build errors\", \"fix breaking changes\", \"resolve SDK generation errors\", \"customize TypeSpec\", \"apply TypeSpec customization\", \"rename SDK client\", \"rename SDK model\", \"hide operation from SDK\", \"fix analyzer errors\", \"fix compilation errors\", \"resolve customization drift\", \"create subclient\", \"apply client.tsp changes\", \"validate SDK package\", \"run package checks\". DO NOT USE FOR: publishing to package registries, CI pipeline configuration, API design review. INVOKES: azure-sdk-mcp:azsdk_package_generate_code, azure-sdk-mcp:azsdk_package_build_code, azure-sdk-mcp:azsdk_package_run_check, azure-sdk-mcp:azsdk_package_run_tests, azure-sdk-mcp:azsdk_customized_code_update, azure-sdk-mcp:azsdk_package_update_changelog_content, azure-sdk-mcp:azsdk_package_update_metadata, azure-sdk-mcp:azsdk_package_update_version."
compatibility:
  requires: "azure-sdk-mcp server, local azure-sdk-for-{language} clone, language build tools"
---

# Generate SDK Locally

## MCP Tools

| Tool | Purpose |
|------|---------|
| `azure-sdk-mcp:azsdk_verify_setup` | Verify environment setup |
| `azure-sdk-mcp:azsdk_package_generate_code` | Generate SDK from TypeSpec |
| `azure-sdk-mcp:azsdk_package_build_code` | Build package |
| `azure-sdk-mcp:azsdk_package_run_check` | Validate package (supports check types: all, linting, format, etc.) |
| `azure-sdk-mcp:azsdk_package_run_tests` | Run tests |
| `azure-sdk-mcp:azsdk_customized_code_update` | Apply TypeSpec and code customizations to resolve build errors, breaking changes, or SDK modification requests (includes regeneration and build internally) |
| `azure-sdk-mcp:azsdk_package_update_changelog_content` | Update changelog |
| `azure-sdk-mcp:azsdk_package_update_metadata` | Update package metadata |
| `azure-sdk-mcp:azsdk_package_update_version` | Update package version |

**Prerequisites:** azure-sdk-mcp server must be running. Without MCP, use `npx tsp-client` CLI.

**Supported languages:** .NET, Java, JavaScript, Python, Go

## Steps

Present the high-level steps to the user before starting so they understand the overall workflow.

1. **Select Language** — Prompt user to choose from: .NET, Java, JavaScript, Python, Go. Validate input against the allowed list.
2. **Verify SDK Repository** — Prompt user for the path to their locally cloned Azure SDK language repository. The local folder name can be arbitrary, but the remote origin must match the official repo (see [SDK repos](references/sdk-repos.md)). If not cloned, instruct user to clone it.
3. **Identify Configuration** — Determine the path to the TypeSpec configuration file:
   - **From `azure-rest-api-specs` repo:** path to `tspconfig.yaml` (local path or HTTPS URL)
   - **From SDK language repo:** path to `tsp-location.yaml`
4. **Verify Setup** — Run `azure-sdk-mcp:azsdk_verify_setup` to confirm environment.
5. **Generate** — Run `azure-sdk-mcp:azsdk_package_generate_code` with the configuration file path.
6. **Build** — Locate the generated SDK project directory (typical structure: `sdk/{service-name}/{package-name}/`). Run `azure-sdk-mcp:azsdk_package_build_code`. If the build succeeds, proceed to step 8.
7. **Customize** — If build fails, or if the user requests SDK modifications, run `azure-sdk-mcp:azsdk_customized_code_update` with the build errors or user request. The tool handles the full workflow internally: it classifies the issue, applies TypeSpec decorators and/or code patches, regenerates the SDK, and builds — all in one call. See [customization workflow](references/customization-workflow.md).
8. **Commit Checkpoint (Generated Changes)** — Inform user that generation and build are complete. Prompt user to commit changes now. If on `main`, prompt to create a new branch (suggest `sdk/<service-name>/<package-name>`). Stage files with `git add`, prompt for commit message, and run `git commit`. If user skips, proceed.
9. **Validate** — Run `azure-sdk-mcp:azsdk_package_run_check` (prompt for check type and parameter values per the tool schema) and `azure-sdk-mcp:azsdk_package_run_tests`.
10. **Metadata** — Run `azure-sdk-mcp:azsdk_package_update_changelog_content`, `azure-sdk-mcp:azsdk_package_update_metadata`, and `azure-sdk-mcp:azsdk_package_update_version`. _(Note: For .NET data plane, skip this step — metadata, changelog, and version updates are per-commit tasks, not part of the generate/build/test workflow.)_
11. **Commit Checkpoint (Final Changes)** — Inform user that metadata updates are complete. Prompt user to commit. Same branch check as step 8. Stage, prompt for message, commit. If user skips, acknowledge.

[SDK repos](references/sdk-repos.md)
[Customization workflow](references/customization-workflow.md)

## Examples

- "Generate the SDK locally for my TypeSpec service"
- "Build and test the Python SDK package"
- "Fix the SDK build errors on this PR"
- "The SDK generation has breaking changes, resolve them"
- "Rename FooClient to BarClient for .NET"
- "Hide the internal polling operation from the Python SDK"
- "Fix .NET analyzer errors AZC0030 and AZC0012"
- "The build is failing because a customization references a renamed property"
- "Create a subclient architecture for the Python SDK"
- "Apply TypeSpec customizations to fix compilation errors"
- "Run validation checks on the SDK package"

## Troubleshooting

- Run `azure-sdk-mcp:azsdk_verify_setup` to confirm MCP and tools.
- If build fails with type conflicts, breaking changes, analyzer errors, or customization drift, use `azure-sdk-mcp:azsdk_customized_code_update` to apply customizations.
- The customization tool uses a two-phase approach: TypeSpec decorators first (Phase A), then code repairs if needed (Phase B).
- Without MCP, use `npx tsp-client` CLI.
