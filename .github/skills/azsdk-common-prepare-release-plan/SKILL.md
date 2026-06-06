---
name: azsdk-common-prepare-release-plan
license: MIT
metadata:
  version: "1.0.0"
  distribution: shared
description: "Create and manage release plan work items for Azure SDK releases across languages. **UTILITY SKILL**. USE FOR: \"create release plan\", \"update release plan\", \"link SDK PR to plan\", \"namespace approval\", \"check release plan status\". DO NOT USE FOR: SDK code generation, pipeline troubleshooting, API review feedback. INVOKES: azure-sdk-mcp:azsdk_create_release_plan, azure-sdk-mcp:azsdk_get_release_plan, azure-sdk-mcp:azsdk_link_sdk_pull_request_to_release_plan."
compatibility: "azure-sdk-mcp server, API spec PR, or TypeSpec project path"
---

# Prepare Release Plan

> Do not display Azure DevOps work item URLs. Only provide Release Plan Link and ID.

## MCP Tools

| Tool | Purpose |
|------|---------|
| `azure-sdk-mcp:azsdk_create_release_plan` | Create plan |
| `azure-sdk-mcp:azsdk_get_release_plan` | Get details |
| `azure-sdk-mcp:azsdk_get_release_plan_for_spec_pr` | Find by spec PR |
| `azure-sdk-mcp:azsdk_update_release_plan` | Update plan fields |
| `azure-sdk-mcp:azsdk_update_sdk_details_in_release_plan` | Update SDK info |
| `azure-sdk-mcp:azsdk_link_sdk_pull_request_to_release_plan` | Link SDK PR |
| `azure-sdk-mcp:azsdk_link_namespace_approval_issue` | Link namespace |
| `azure-sdk-mcp:azsdk_update_api_spec_pull_request_in_release_plan` | Update spec PR |

## Steps

1. **Prerequisites** — Check for API spec PR link or a TypeSpec project path; prompt if unavailable.
2. **Check Existing** — Query by release plan number or spec PR link (do not query by work item ID).
3. **Gather Info** — Collect Service Tree IDs, timeline, and API release type. See [details](references/release-plan-details.md).
4. **API Release Type** — Ask user for API release type: "Private Preview", "Public Preview", or "GA". This is required.
5. **Validate Spec PR** — If spec PR is provided, validate it matches the API release type:
   - Private Preview → must be in `azure-rest-api-specs-pr`
   - Public Preview / GA → must be in `azure-rest-api-specs`
6. **Create** — Run `azure-sdk-mcp:azsdk_create_release_plan` with `apiReleaseType` parameter. SDK release type defaults automatically (beta for preview, stable for GA).
7. **Namespace** — For mgmt plane first releases, link approval issue.
8. **Link PRs** — Link SDK PRs to plan.

## Examples

- "Create a release plan for my spec PR"
- "Create a release plan for my TypeSpec project"
- "Create a private preview release plan"
- "Create a GA release plan for my spec PR"
- "Link my SDK PR to release plan"

## Troubleshooting

- Requires `azure-sdk-mcp` server; no CLI fallback.
- If creation fails, verify Service Tree IDs and the provided spec PR URL or TypeSpec project path.
- If spec PR validation fails, check that the spec PR repo matches the API release type (private repo for Private Preview, public repo for Public Preview/GA).
