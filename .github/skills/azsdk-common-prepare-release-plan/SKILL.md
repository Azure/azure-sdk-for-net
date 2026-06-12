---
name: azsdk-common-prepare-release-plan
license: MIT
metadata:
  version: "1.0.0"
  distribution: shared
description: 'Create, get, update, abandon, and link SDK PRs to release plan work items for Azure SDK releases. **UTILITY SKILL**. USE FOR: "create release plan", "get release plan", "update release plan", "update API spec in release plan", "update SDK details in release plan", "abandon release plan", "link SDK PR to plan", "namespace approval", "check release plan status". DO NOT USE FOR: SDK code generation, pipeline troubleshooting, API review feedback. INVOKES: azure-sdk-mcp:azsdk_create_release_plan, azure-sdk-mcp:azsdk_get_release_plan, azure-sdk-mcp:azsdk_get_release_plan_for_spec_pr, azure-sdk-mcp:azsdk_update_release_plan, azure-sdk-mcp:azsdk_update_api_spec_pull_request_in_release_plan, azure-sdk-mcp:azsdk_update_sdk_details_in_release_plan, azure-sdk-mcp:azsdk_abandon_release_plan, azure-sdk-mcp:azsdk_link_sdk_pull_request_to_release_plan, azure-sdk-mcp:azsdk_link_namespace_approval_issue.'
compatibility:
  requires: "azure-sdk-mcp server, API spec PR in Azure/azure-rest-api-specs"
---

# Prepare Release Plan

This skill creates, gets, updates, abandons, and links SDK PRs to release plan work items for Azure SDK releases, helping gather required release data, validate spec inputs, and link related approvals or SDK pull requests without exposing internal work item URLs.

## Triggers

USE FOR: create release plan, get release plan, update release plan, update API spec in release plan, update SDK details in release plan, abandon release plan, link SDK PR to plan, namespace approval, check release plan status
WHEN: "create release plan", "get release plan", "update release plan", "abandon release plan", "link SDK PR to plan", "namespace approval", "check release plan status"
DO NOT USE FOR: SDK code generation, pipeline troubleshooting, API review feedback

## Rules

- Do not display Azure DevOps work item URLs; only provide the Release Plan Link and ID.
- Require an API spec PR link or a TypeSpec project path before creating or updating a plan.
- Validate that the spec PR repository matches the requested API release type before creation.

## MCP Tools

| Tool                                                               | Purpose                            |
| ------------------------------------------------------------------ | ---------------------------------- |
| `azure-sdk-mcp:azsdk_create_release_plan`                          | Create a new release plan          |
| `azure-sdk-mcp:azsdk_get_release_plan`                             | Get release plan details by ID     |
| `azure-sdk-mcp:azsdk_get_release_plan_for_spec_pr`                 | Find release plan by spec PR URL   |
| `azure-sdk-mcp:azsdk_update_release_plan`                          | Update release plan metadata       |
| `azure-sdk-mcp:azsdk_update_api_spec_pull_request_in_release_plan` | Update API spec PR URL in plan     |
| `azure-sdk-mcp:azsdk_update_sdk_details_in_release_plan`           | Update SDK/package details in plan |
| `azure-sdk-mcp:azsdk_abandon_release_plan`                         | Abandon a release plan             |
| `azure-sdk-mcp:azsdk_link_sdk_pull_request_to_release_plan`        | Link SDK PR to release plan        |
| `azure-sdk-mcp:azsdk_link_namespace_approval_issue`                | Link namespace approval issue      |

---

## Use Cases

### 1. Create Release Plan

**When**: User wants to create a release plan for a TypeSpec project.

**Steps**:

1. **Get TypeSpec Project Path** — Ask the user for the relative TypeSpec project path (directory containing `tspconfig.yaml`, e.g. `specification/contosowidgetmanager/Contoso.WidgetManager`). Always use the relative path from the repo root, not an absolute path.
2. **Check Existing** — Run `azure-sdk-mcp:azsdk_get_release_plan` with the relative `typeSpecProjectPath` to check if a release plan already exists.
   - If a release plan exists with the **same API release type** the user requested: inform the user that a release plan already exists, show the Release Plan ID, status, and API release type. Suggest the user use the existing release plan. Do NOT create a new one.
   - If a release plan exists but for a **different API release type**: inform the user about the existing plan and its API release type, then proceed to create a new release plan using `forceCreateReleasePlan: true` for the user's requested API release type. Do NOT attempt to update the existing release plan's API release type.
   - If no release plan exists, proceed to step 3.
3. **Gather Info** — Collect required details from the user. See [details](references/release-plan-details.md):
   - Target release month/year (format: "Month YYYY", e.g. "June 2026"). Do NOT use formats like "2026-06" or "06/2026" — these are invalid.
   - API release type: Value must be one of the following: "Private Preview", "Public Preview", or "GA"
   - SDK release type: Value must be "beta" or "stable" — always ask the user explicitly
   - Spec PR URL (optional)
   - Service Tree ID (GUID) — optional if previously created
   - Product Tree ID (GUID) — optional if previously created
4. **Create** — Run `azure-sdk-mcp:azsdk_create_release_plan` with the collected parameters including `sdkReleaseType`. Use `forceCreateReleasePlan: true` only if an existing release plan was found for a different API release type.
5. **Namespace** — For first management plane releases, link namespace approval issue using `azure-sdk-mcp:azsdk_link_namespace_approval_issue`.

> **IMPORTANT**: Do NOT default the API release type value as the SDK release type. These are separate fields — always ask the user explicitly for the SDK release type.
>
> **IMPORTANT**: Do NOT update an existing release plan to change its API release type. If a release plan exists for a different API release type, force-create a new one instead.

**Tool**: `azure-sdk-mcp:azsdk_create_release_plan`

---

### 2. Get Release Plan

**When**: User wants to check the status or details of an existing release plan.

**Steps**:

1. **Identify Plan** — Ask user for one of:
   - Release plan ID or work item ID
   - Relative TypeSpec project path (e.g. `specification/contosowidgetmanager/Contoso.WidgetManager`)
   - Spec PR URL
2. **Query** — Run `azure-sdk-mcp:azsdk_get_release_plan` with the provided identifier (always use relative path for `typeSpecProjectPath`), OR run `azure-sdk-mcp:azsdk_get_release_plan_for_spec_pr` if only a spec PR URL is available.
3. **Display** — Show the release plan ID, status, linked PRs, and SDK details.

**Tools**: `azure-sdk-mcp:azsdk_get_release_plan`, `azure-sdk-mcp:azsdk_get_release_plan_for_spec_pr`

---

### 3. Update Release Plan / Update API Spec in Release Plan

**When**: User needs to update release plan metadata (spec PR URL, TypeSpec project path, SDK release type, service/product IDs) or update the API spec PR link.

**Steps**:

1. **Identify Plan** — Get the work item ID or TypeSpec project path from the user.
2. **Update Metadata** — Run `azure-sdk-mcp:azsdk_update_release_plan` with:
   - `typeSpecProjectPath` (required)
   - `workItemId` (optional — resolved from TypeSpec path or spec PR if not provided)
   - `specPullRequestUrl` (optional)
   - `sdkReleaseType` (required — do NOT default this from API release type; always ask user explicitly)
   - `serviceTreeId` (optional)
   - `productTreeId` (optional)
3. **Update API Spec PR** — If only the spec PR URL needs updating, run `azure-sdk-mcp:azsdk_update_api_spec_pull_request_in_release_plan` with:
   - `specPullRequestUrl` (required)
   - `workItemId` or `releasePlanId`

**Tools**: `azure-sdk-mcp:azsdk_update_release_plan`, `azure-sdk-mcp:azsdk_update_api_spec_pull_request_in_release_plan`

---

### 4. Update SDK/Package Details in Release Plan

**When**: User needs to update SDK language and package name details in the release plan after code generation or configuration changes.

**Steps**:

1. **Identify Plan** — Get the release plan work item ID from the user.
2. **Identify TypeSpec Project** — Get or confirm the TypeSpec project path.
3. **Update** — Run `azure-sdk-mcp:azsdk_update_sdk_details_in_release_plan` with:
   - `releasePlanWorkItemId` (required)
   - `typeSpecProjectPath` (required)

**Tool**: `azure-sdk-mcp:azsdk_update_sdk_details_in_release_plan`

---

### 5. Abandon a Release Plan

**When**: User decides to cancel or discard a release plan that is no longer needed.

**Steps**:

1. **Identify Plan** — Get the work item ID or release plan ID from the user.
2. **Confirm** — Ask user to confirm abandonment: "Are you sure you want to abandon this release plan? This action updates the status to Abandoned."
3. **Abandon** — Run `azure-sdk-mcp:azsdk_abandon_release_plan` with:
   - `workItemId` or `releasePlanId`

**Tool**: `azure-sdk-mcp:azsdk_abandon_release_plan`

---

### 6. Link SDK Pull Request to Release Plan

**When**: SDK pull requests have been created and need to be associated with the release plan.

**Steps**:

1. **Identify Plan** — Get the work item ID or release plan ID.
2. **Collect PR Info** — Get the SDK pull request URL and language from the user.
3. **Link** — Run `azure-sdk-mcp:azsdk_link_sdk_pull_request_to_release_plan` with:
   - `pullRequestUrl` (required)
   - `language` (required — e.g., ".NET", "Java", "JavaScript", "Python", "Go")
   - `workItemId` or `releasePlanId`
4. **Repeat** — If multiple SDK PRs exist for different languages, repeat for each.

**Tool**: `azure-sdk-mcp:azsdk_link_sdk_pull_request_to_release_plan`

---

## Examples

- "Create a release plan for my spec PR"
- "Get the release plan for work item 12345"
- "What is the status of my release plan?"
- "Update the API spec PR in my release plan"
- "Update SDK details in release plan 67890"
- "Abandon release plan 11111"
- "Link my SDK PR to release plan"
- "Link Python SDK PR #100 to release plan 67890"

## Troubleshooting

- Requires `azure-sdk-mcp` server; no CLI fallback — prompt user to configure MCP if unavailable.
- If creation fails, verify spec PR URL and Service Tree IDs.
- If update fails, ensure the work item ID or release plan ID is correct and the plan is not already abandoned.
- If linking fails, verify the SDK PR URL is valid and the language matches a supported value.
