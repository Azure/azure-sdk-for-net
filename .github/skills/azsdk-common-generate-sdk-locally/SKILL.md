---
name: azsdk-common-generate-sdk-locally
license: MIT
metadata:
  version: "1.1.0"
  distribution: shared
description: "Generate, build, and test Azure SDKs locally from TypeSpec, with automatic customization to resolve build errors and apply SDK changes. **UTILITY SKILL**. USE FOR: \"generate SDK locally\", \"build SDK\", \"run SDK tests\", \"update changelog\", \"fix SDK build errors\", \"fix breaking changes\", \"resolve SDK generation errors\", \"customize TypeSpec\", \"apply TypeSpec customization\", \"rename SDK client\", \"rename SDK model\", \"hide operation from SDK\", \"fix analyzer errors\", \"fix compilation errors\", \"resolve customization drift\", \"create subclient\", \"apply client.tsp changes\". DO NOT USE FOR: publishing to package registries, CI pipeline configuration, API design review. INVOKES: azure-sdk-mcp:azsdk_package_generate_code, azure-sdk-mcp:azsdk_package_build_code, azure-sdk-mcp:azsdk_package_run_tests, azure-sdk-mcp:azsdk_customized_code_update."
compatibility:
  requires: "azure-sdk-mcp server, local azure-sdk-for-{language} clone, language build tools"
---

# Generate SDK Locally

## MCP Tools

| Tool | Purpose |
|------|---------|
| `azure-sdk-mcp:azsdk_package_generate_code` | Generate SDK from TypeSpec |
| `azure-sdk-mcp:azsdk_package_build_code` | Build package |
| `azure-sdk-mcp:azsdk_package_run_check` | Validate package |
| `azure-sdk-mcp:azsdk_package_run_tests` | Run tests |
| `azure-sdk-mcp:azsdk_customized_code_update` | Apply TypeSpec and code customizations to resolve build errors, breaking changes, or SDK modification requests (includes regeneration and build internally) |

**Prerequisites:** azure-sdk-mcp server must be running. Without MCP, use `npx tsp-client` CLI.

## Steps

1. **Verify** — Run `azure-sdk-mcp:azsdk_verify_setup` to confirm environment.
2. **Generate** — Run `azure-sdk-mcp:azsdk_package_generate_code` with `tspconfig.yaml` or `tsp-location.yaml` path.
3. **Build** — Run `azure-sdk-mcp:azsdk_package_build_code`. If the build succeeds, proceed to step 5.
4. **Customize** — If build fails, or if the user requests SDK modifications, run `azure-sdk-mcp:azsdk_customized_code_update` with the build errors or user request. The tool handles the full workflow internally: it classifies the issue, applies TypeSpec decorators and/or code patches, regenerates the SDK, and builds — all in one call. See [customization workflow](references/customization-workflow.md).
5. **Validate** — Run `azure-sdk-mcp:azsdk_package_run_check` and `azure-sdk-mcp:azsdk_package_run_tests`.
6. **Metadata** — Update metadata, changelog, and version. _(Note: For .NET data plane, skip this step — metadata, changelog, and version updates are per-commit tasks, not part of the generate/build/test workflow.)_

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

## Troubleshooting

- Run `azure-sdk-mcp:azsdk_verify_setup` to confirm MCP and tools.
- If build fails with type conflicts, breaking changes, analyzer errors, or customization drift, use `azure-sdk-mcp:azsdk_customized_code_update` to apply customizations.
- The customization tool uses a two-phase approach: TypeSpec decorators first (Phase A), then code repairs if needed (Phase B).
- Without MCP, use `npx tsp-client` CLI.
