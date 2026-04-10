---
name: azsdk-common-prepare-release-plan
license: MIT
metadata:
  version: "1.1.0"
  distribution: shared
description: "Create and manage release plan work items for Azure SDK releases across languages. **UTILITY SKILL**. USE FOR: \"create release plan\", \"update release plan\", \"link SDK PR to plan\", \"namespace approval\", \"check release plan status\", \"add SDK details to release plan\", \"verify namespace approval\". DO NOT USE FOR: SDK code generation, pipeline troubleshooting, API review feedback. INVOKES: azure-sdk-mcp:azsdk_create_release_plan, azure-sdk-mcp:azsdk_get_release_plan, azure-sdk-mcp:azsdk_get_release_plan_for_spec_pr, azure-sdk-mcp:azsdk_update_sdk_details_in_release_plan, azure-sdk-mcp:azsdk_link_sdk_pull_request_to_release_plan, azure-sdk-mcp:azsdk_link_namespace_approval_issue."
compatibility:
  requires: "azure-sdk-mcp server, API spec PR in Azure/azure-rest-api-specs"
---

# Prepare Release Plan

> **CRITICAL INSTRUCTIONS:**
> 1. Do **not** mention or display Azure DevOps work item links/URLs. Only provide Release Plan Link and Release Plan ID.
> 2. All manual updates must be made through the [Release Planner Tool](https://aka.ms/sdk-release-planner).
> 3. Always check the `NextSteps` field in tool responses and follow any additional prompts before proceeding.

## MCP Tools

| Tool | Purpose |
|------|---------|
| `azure-sdk-mcp:azsdk_create_release_plan` | Create plan |
| `azure-sdk-mcp:azsdk_get_release_plan` | Get details |
| `azure-sdk-mcp:azsdk_get_release_plan_for_spec_pr` | Find by spec PR |
| `azure-sdk-mcp:azsdk_update_sdk_details_in_release_plan` | Update SDK info |
| `azure-sdk-mcp:azsdk_link_sdk_pull_request_to_release_plan` | Link SDK PR |
| `azure-sdk-mcp:azsdk_link_namespace_approval_issue` | Link namespace |

## Steps

1. **Prerequisites** — Check for API spec PR; prompt if unavailable.
2. **Check Existing** — Ask if user has an existing plan. Query by plan number or spec PR link. Display Release Plan ID, status, associated languages, SDK PRs.
3. **Gather Info** — Collect all required details; do not use temporary values. Confirm values with user before creating. See [details](references/release-plan-details.md).
   - **Service Tree ID**: GUID format — show to user and confirm
   - **Product Service Tree ID**: GUID format — show to user and confirm
   - **Expected Release Timeline**: "Month YYYY" format
   - **API Version**: The version of the API being released
   - **SDK Release Type**: "beta" (preview) or "stable" (GA)
4. **Create** — Run `azure-sdk-mcp:azsdk_create_release_plan`. If user doesn't know required details, direct them to: [Release Plan Creation Guide](https://eng.ms/docs/products/azure-developer-experience/plan/release-plan-create). Display the newly created plan for confirmation.
5. **SDK Details** — Identify languages from `tspconfig.yaml` emitter config. Map emitter names to languages, extract package names, validate format, and update. See [SDK details rules](references/release-plan-details.md#sdk-details-update).
6. **Namespace** — For management plane first releases only: check if namespace approval issue exists; if not, collect GitHub issue from `Azure/azure-sdk` repo and run `azure-sdk-mcp:azsdk_link_namespace_approval_issue`. See [namespace details](references/release-plan-details.md#namespace-approval-management-plane-only).
7. **Link PRs** — If SDK PRs exist, ensure GitHub CLI auth (`gh auth login` / `gh auth status`), then run `azure-sdk-mcp:azsdk_link_sdk_pull_request_to_release_plan` for each PR.
8. **Summary** — Display: release plan status (created or existing), linked SDK PRs, and next steps.

## Examples

- "Create a release plan for my spec PR"
- "Link my SDK PR to release plan"
- "Update SDK details in my release plan"
- "Link namespace approval issue to release plan"

## Troubleshooting

- Requires `azure-sdk-mcp` server; no CLI fallback.
- If creation fails, verify spec PR URL and Service Tree IDs.
