---
name: azsdk-common-sdk-quality-assurance
license: MIT
metadata:
  version: "1.1.0"
  distribution: shared
description: 'Ensure high-quality SDKs are generated from TypeSpec. WHEN: "assure the quality of an SDK package", "assure the quality of SDK packages for a service", "Detect and mitigate SDK breaking changes for a service", "Detect and mitigate SDK breaking changes for an SDK package". INVOKES: azsdk_verify_setup, azsdk_package_generate_code, azsdk_package_build_code, azsdk_customized_code_update, azsdk_package_detect_breaking_change.'
compatibility: "azure-sdk-mcp server, local azure-sdk-for-{language} clone, language build tools"
---

# SDK Quality Assurance

## MCP Tools

| Tool                                                   | Purpose                                                |
| ------------------------------------------------------ | ------------------------------------------------------ |
| `azure-sdk-mcp:azsdk_verify_setup`                     | Verify environment                                     |
| `azure-sdk-mcp:azsdk_package_generate_code`            | Generate SDK                                           |
| `azure-sdk-mcp:azsdk_package_build_code`               | Build package                                          |
| `azure-sdk-mcp:azsdk_customized_code_update`           | Apply customizations (includes regeneration and build) |
| `azure-sdk-mcp:azsdk_package_detect_breaking_change`   | Detect SDK breaking changes                            |


Prerequisites: azure-sdk-mcp server must be running. Without MCP, use `npx tsp-client` CLI.

## Steps

1. **Select language** — Confirm one or more target languages. Present them to the user in exactly this order: Go, Java, JavaScript, Python, .NET.
  - For each selected language in step 1, execute steps 2 through 11 **one language at a time** — fully complete all steps for one language before starting the next. Process multiple selected languages in the same order they appear in the list above.

2. **Verify repo** — Ensure the user has a local clone of the correct [SDK repo](../azsdk-common-generate-sdk-locally/references/sdk-repos.md) for the current language. If not cloned, instruct user to clone it.
3. **Identify typespec config file** — Determine the path to the TypeSpec configuration file. See [config file details](../azsdk-common-generate-sdk-locally/references/detailed-workflow.md).
   - From `azure-rest-api-specs` repo: use path to `tspconfig.yaml`.
   - From an SDK language repo: use path to `tsp-location.yaml`.
4. **Verify setup** — Run `azure-sdk-mcp:azsdk_verify_setup` to confirm environment.
5. **Generate** — Run `azure-sdk-mcp:azsdk_package_generate_code` with the typespec config file path.
6. **Build** — Run `azure-sdk-mcp:azsdk_package_build_code`. If build succeeds, proceed to step 8.
7. **Customize** — If build fails, or if user requests SDK modifications, run `azure-sdk-mcp:azsdk_customized_code_update` with the build errors or user request. The tool handles the full workflow internally: it classifies the issue, applies TypeSpec decorators and/or code patches, regenerates the SDK, and builds — all in one call. See [customization workflow](../azsdk-common-generate-sdk-locally/references/customization-workflow.md).
8. **Detect SDK breaking Changes** - Run `azure-sdk-mcp:azsdk_package_detect_breaking_change`
9. **Display the detected Breaking changes** if any breaking change detected in step 8
10. **Prompt the user to choose breaking changes to mitigate** — Present the list from step 8 as a multiple-choice selection.
11. **Mitigate SDK breaking changes** - Run `azure-sdk-mcp:azsdk_customized_code_update` with parameters:
- packagePath: The SDk package path
- customizationRequest:  resolve the 'breakingChanges' chosen in step 10, it is an array
- tspProjectPath : the typespec project path
- editScope: 2 if in `azure-rest-api-specs`, 1 if in an SDK language repo

If any SDK breaking changes are mitigated through TypeSpec customization, return to step 5 and repeat the quality assurance workflow.

[SDK repos](../azsdk-common-generate-sdk-locally/references/sdk-repos.md) | [Customization workflow](../azsdk-common-generate-sdk-locally/references/customization-workflow.md) | [Detailed workflow](../azsdk-common-generate-sdk-locally/references/detailed-workflow.md)

## Examples

- "Detect and mitigate SDK breaking changes for the service"
- "Assure SDK quality for the service project"

## Troubleshooting

- Run `azure-sdk-mcp:azsdk_verify_setup` to confirm MCP and tools.
- If build fails with type conflicts, breaking changes, analyzer errors, or customization drift, use `azure-sdk-mcp:azsdk_customized_code_update` to apply customizations.
- The customization tool uses a two-phase approach: TypeSpec decorators first (Phase A), then code repairs if needed (Phase B).
- Without MCP, use `npx tsp-client` CLI.
