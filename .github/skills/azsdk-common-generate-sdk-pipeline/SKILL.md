---
name: azsdk-common-generate-sdk-pipeline
license: MIT
metadata:
  version: "1.0.0"
  distribution: shared
description: 'Run the Azure SDK generation pipeline for a release plan and create the generated SDK pull requests, for one language or for all languages. **UTILITY SKILL**. USE FOR: "run SDK generation for all languages", "generate SDK for release plan <id>", "generate SDK for release <id>", "pipeline SDK generation", "generate SDK without a local clone", "create SDK pull requests". DO NOT USE FOR: generating a single SDK locally from a local clone (use azsdk-common-generate-sdk-locally), releasing/publishing an already-generated package (use azsdk-common-sdk-release), API design review. INVOKES: azure-sdk-mcp:azsdk_get_release_plan, azure-sdk-mcp:azsdk_run_generate_sdk, azure-sdk-mcp:azsdk_get_sdk_pull_request_link.'
compatibility: "azure-sdk-mcp server, existing release plan work item. Supports .NET, Java, JavaScript, Python, Go"
---

# Generate SDK via Pipeline

This skill runs the Azure SDK generation pipeline for a release plan and produces the generated SDK pull request(s). It is the correct workflow when the user asks to generate SDKs **for all languages**, to generate **for a release plan / release ID**, or to generate **without a local clone** — none of which the local-generation workflow handles.

## Triggers

USE FOR: run SDK generation for all languages, generate SDK for a release plan, generate SDK for a release ID, pipeline SDK generation, generate SDK without a local clone, create SDK pull requests
WHEN: "run SDK generation, run SDK generation for all languages for release plan <id>", "generate SDK for release plan <id>", "generate SDK for release <id>", "pipeline SDK generation", "generate SDK without a local clone"
DO NOT USE FOR: generating a single SDK locally from a local clone (use `azsdk-common-generate-sdk-locally`); releasing or publishing an already-generated package (use `azsdk-common-sdk-release`); API design review

## Rules

- **Always call `azure-sdk-mcp:azsdk_run_generate_sdk`** to generate. Do **not** use `azure-sdk-mcp:azsdk_release_sdk` (that publishes an already-generated package, it does not generate) or `azure-sdk-mcp:azsdk_get_sdk_pull_request_link` / `azure-sdk-mcp:azsdk_get_pull_request` (those only retrieve links) to generate an SDK.
- `azure-sdk-mcp:azsdk_run_generate_sdk` generates **one language per call**. To generate for **all languages**, call it **once per language** the release plan targets.
- A **release plan work item ID (or release plan ID)** is required. `azsdk_run_generate_sdk` **also** requires the **TypeSpec project path** and the **SDK release type** (`beta` or `stable`) as explicit inputs, and it validates them — it does **not** read them from the release plan. First call `azure-sdk-mcp:azsdk_get_release_plan` to obtain the TypeSpec project path, SDK release type, and target languages, then pass those into each generation call along with the work item ID.
- Requires the `azure-sdk-mcp` server; there is no CLI fallback for the pipeline generation workflow.
- Private Preview release plans cannot generate SDKs via the pipeline — only the API spec PR needs to merge. If needed for validation, direct the user to generate locally via `azsdk-common-generate-sdk-locally`.

## MCP Tools

| Tool                                            | Purpose                                                        |
| ----------------------------------------------- | -------------------------------------------------------------- |
| `azure-sdk-mcp:azsdk_get_release_plan`          | Fetch the release plan to determine target languages / details |
| `azure-sdk-mcp:azsdk_run_generate_sdk`          | Run the generation pipeline (once per language)                |
| `azure-sdk-mcp:azsdk_get_sdk_pull_request_link` | Retrieve the generated SDK pull request link after generation  |

## Steps

1. **Collect release plan** — Get the release plan work item ID (or release plan ID) from the user, then call `azure-sdk-mcp:azsdk_get_release_plan` to fetch it.
2. **Determine languages** — If the user asked for "all languages", determine the languages the release plan targets (e.g. via `azure-sdk-mcp:azsdk_get_release_plan`). Otherwise use the single language requested.
3. **Generate per language** — For each target language, run `azure-sdk-mcp:azsdk_run_generate_sdk` passing the **TypeSpec project path**, the **SDK release type** (`beta` or `stable`), and the **language** taken from the release plan, plus the release plan **work item ID**. These inputs are required and validated — an invalid TypeSpec project path, or a release type other than `beta`/`stable`, fails the run.
4. **Report pull requests** — After each run completes, retrieve and show the generated SDK pull request link with `azure-sdk-mcp:azsdk_get_sdk_pull_request_link`.

## Examples

- "Run SDK generation for all languages for release 12345"
- "Generate the SDK for release plan 12345"
- "Generate the Python and .NET SDKs for release 12345 using the pipeline"

## Troubleshooting

- If the agent tries `azsdk_release_sdk`, get-artifact, or get-service-details tools instead of generating, redirect it to `azure-sdk-mcp:azsdk_run_generate_sdk` — that is the only tool that runs the generation pipeline.
- If the correct tool is not yet available in the session, activate/load the `azure-sdk-mcp` TypeSpec SDK toolset first, then call `azure-sdk-mcp:azsdk_run_generate_sdk`.
- If generation fails with a missing SDK details error, ensure the release plan has SDK details populated for the language before re-running.
- Requires the `azure-sdk-mcp` server. No CLI fallback — prompt the user to configure MCP if unavailable.
