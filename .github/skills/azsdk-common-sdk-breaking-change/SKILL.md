---
name: azsdk-common-sdk-breaking-change
license: MIT
metadata:
  version: "1.1.0"
  distribution: shared
description: 'Detect and mitigate SDK Breaking changes for a SDK pacakge which is generated from TypeSpec. WHEN: "Detect SDK breaking changes for a service", "Detect SDK breaking changes for an SDK package", "Detect and mitigate SDK breaking changes for a service", "Detect and mitigate SDK breaking changes for an SDK package". INVOKES: azsdk_verify_setup, azsdk_package_generate_code, azsdk_package_build_code, azsdk_customized_code_update, azsdk_package_detect_breaking_change.'
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

2. Follow `azsdk-common-generate-sdk-locally` skill to gererate SDK only.
3. **Detect SDK breaking Changes** - Run `azure-sdk-mcp:azsdk_package_detect_breaking_change`
4. **Display detected breaking changes** — If step 3 detects breaking changes, display a `## Detected Breaking Changes` title followed by a Markdown table. Include exactly one breaking change per row with these columns: `Breaking Change`, `Category`, and `Resolution`. Preserve the category and resolution returned by the detection tool; do not replace them with a summary.
5. **Prompt the user to choose breaking changes to mitigate** — Present the list from step 3 as a multiple-choice selection.
6. **Mitigate SDK breaking changes** - Run `azure-sdk-mcp:azsdk_customized_code_update` with parameters:
- packagePath: The SDk package path
- customizationRequest:  resolve the 'breakingChanges' chosen in step 5, it is an array
- tspProjectPath : the typespec project path
- editScope: 2 if in `azure-rest-api-specs`, 1 if in an SDK language repo

If any SDK breaking changes are mitigated through TypeSpec customization, return to step 2 and repeat the quality assurance workflow.

## Examples

- "Detect and mitigate SDK breaking changes for the service"
- "Detect SDK breaking changes for the service"
- "Detect SDK breaking changes for Go SDK package"
- "Detect and mitigate SDK breaking changes for Go SDK package"

## Troubleshooting

- Run `azure-sdk-mcp:azsdk_verify_setup` to confirm MCP and tools.
- If build fails with type conflicts, breaking changes, analyzer errors, or customization drift, use `azure-sdk-mcp:azsdk_customized_code_update` to apply customizations.
- The customization tool uses a two-phase approach: TypeSpec decorators first (Phase A), then code repairs if needed (Phase B).
- Without MCP, use `npx tsp-client` CLI.
