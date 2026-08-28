---
name: azsdk-common-sdk-breaking-change
license: MIT
metadata:
  version: "1.0.0"
  distribution: shared
description: 'Detect and mitigate SDK Breaking changes for an SDK package which is generated from TypeSpec. WHEN: "Detect SDK breaking changes for a service", "Detect SDK breaking changes for an SDK package", "Detect and mitigate SDK breaking changes for a service", "Detect and mitigate SDK breaking changes for an SDK package". INVOKES: skill: azsdk-common-generate-sdk-locally; MCP tools: azure-sdk-mcp:azsdk_customized_code_update, azure-sdk-mcp:azsdk_package_detect_breaking_change.'
compatibility: "azure-sdk-mcp server, local azure-sdk-for-{language} clone, language build tools"
---

# SDK Breaking Change Detection and Mitigation

## MCP Tools

| Tool                                                 | Purpose                     |
| ---------------------------------------------------- | --------------------------- |
| `azure-sdk-mcp:azsdk_customized_code_update`         | Apply customizations        |
| `azure-sdk-mcp:azsdk_package_detect_breaking_change` | Detect SDK breaking changes |

Prerequisites: azure-sdk-mcp server must be running.

## Steps

1. **Select language** — First extract one or more target languages from the user's prompt. If the prompt specifies any target languages, use them without asking the user to confirm. If it does not specify a target language, prompt the user to choose one or more from this list, presented in exactly this order: Go, Java, JavaScript, Python, .NET.

- For each selected language in step 1, execute steps 2 through 6 **one language at a time** — fully complete all steps for one language before starting the next. Process multiple selected languages in the same order they appear in the list above.

2. Follow `azsdk-common-generate-sdk-locally` skill to generate SDK only.
3. **Detect SDK breaking Changes** - Run `azure-sdk-mcp:azsdk_package_detect_breaking_change`
4. **Display detected breaking changes** — If step 3 detects breaking changes, display a `## Detected Breaking Changes` title followed by a Markdown table. Include exactly one breaking change per row with these columns: `Breaking Change`, `Category`, and `Resolution`. Preserve the category and resolution returned by the detection tool; do not replace them with a summary. If no breaking changes are detected, report that result and stop processing the current language.
5. **Prompt the user to choose breaking changes to mitigate** — Present the list from step 3 as a multiple-choice selection.
6. **Mitigate selected SDK breaking changes** — If the user selects no changes in step 5, stop processing the current language. Otherwise, run `azure-sdk-mcp:azsdk_customized_code_update` for the selected changes with these parameters:

- packagePath: The SDK package path
- customizationRequest: resolve the 'breakingChanges' chosen in step 5
- tspProjectPath: the typespec project path
- editScope: 'SpecInputs' if in `azure-rest-api-specs`, 'CustomCode' if in an SDK language repo

After step 6, begin the next iteration. If the customization modified TypeSpec, first repeat step 2 to regenerate the SDK; otherwise, resume at step 3. Then repeat steps 3 through 6. Run at most three detection-and-mitigation iterations per language, stopping earlier if no breaking changes remain or the user declines further mitigation. After the third mitigation, run step 3 once more to identify and report any remaining breaking changes, then stop without offering a fourth mitigation.

## Examples

- "Detect and mitigate SDK breaking changes for the service"
- "Detect SDK breaking changes for the service"
- "Detect SDK breaking changes for Go SDK package"
- "Detect and mitigate SDK breaking changes for Go SDK package"

## Troubleshooting

- Requires `azure-sdk-mcp` server. Prompt user to configure MCP if unavailable.
- Requires a local clone of the target SDK repository. If unavailable, prompt the user to clone it before continuing.
