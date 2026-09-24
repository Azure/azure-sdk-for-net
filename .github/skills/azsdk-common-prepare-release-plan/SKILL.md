---
name: azsdk-common-prepare-release-plan
license: MIT
metadata:
  version: "1.0.0"
  distribution: shared
description: 'Create, get, update, abandon, and link SDK PRs to release plan work items for Azure SDK releases. **UTILITY SKILL**. USE FOR: "create release plan", "get release plan", "update release plan", "update API spec in release plan", "update SDK details in release plan", "abandon release plan", "link SDK PR to plan", "namespace approval", "check release plan status". DO NOT USE FOR: SDK code generation, pipeline troubleshooting, API review feedback. INVOKES: azure-sdk-mcp:azsdk_create_release_plan, azure-sdk-mcp:azsdk_get_release_plan, azure-sdk-mcp:azsdk_update_release_plan, azure-sdk-mcp:azsdk_update_release_plan_target, azure-sdk-mcp:azsdk_update_api_spec_pull_request_in_release_plan, azure-sdk-mcp:azsdk_update_sdk_details_in_release_plan, azure-sdk-mcp:azsdk_abandon_release_plan, azure-sdk-mcp:azsdk_link_sdk_pull_request_to_release_plan, azure-sdk-mcp:azsdk_link_namespace_approval_issue.'
compatibility: "azure-sdk-mcp server, API spec PR in Azure/azure-rest-api-specs"
---

# Prepare Release Plan

This skill creates, gets, updates, abandons, and links SDK PRs to release plan work items for Azure SDK releases, helping gather required release data, validate spec inputs, and link related approvals or SDK pull requests without exposing internal work item URLs.

## Triggers

USE FOR: create release plan, get release plan, update release plan, update API spec in release plan, update SDK details in release plan, abandon release plan, link SDK PR to plan, namespace approval, check release plan status
WHEN: "create release plan", "get release plan", "update release plan", "abandon release plan", "link SDK PR to plan", "namespace approval", "check release plan status"
DO NOT USE FOR: SDK code generation, pipeline troubleshooting, API review feedback

## Rules

- Do not display Azure DevOps work item URLs; only provide the Release Plan Link and ID.
- Configuring a public SDK target requires a local TypeSpec project path and a public spec PR. Creation before a PR exists is tracking-only; Private Preview remains spec-only and cannot generate SDKs via the pipeline.
- Validate that the spec PR repository matches the requested API release type before creation.
- Release plan tools accept **either** a Release Plan ID or an Azure DevOps work item ID — pass whichever the user provides. Each tool resolves the value automatically (trying it as a Release Plan ID first, then as a work item ID), so you do not need to call `azure-sdk-mcp:azsdk_get_release_plan` first just to translate one ID into the other.
- Always relay schedule-risk `warnings` and `next_steps` returned by release plan tools. For each past-due plan, show its Release Plan ID and dashboard link, then present both choices: update its target release month or abandon it and record the reason in the dashboard.

## Confirm a Public SDK Target

Use this flow for create, update, and spec-PR updates that configure a Public Preview or GA SDK target:

1. **Validate the snapshot** — Supply a local `typeSpecProjectPath` with the project's compiler installed. The clean checkout's `HEAD` must match the selected PR HEAD or merge SHA before and after compilation, and the API version must exist at that SHA. Target validation emits metadata outside the checkout in a temporary directory, not SDK code. Tools do not check out commits or stash user work.
2. **Preview** — Read the existing plan before an update, then call the operation with `confirmTarget: false` (the default). A response with `requires_confirmation: true` and `proposed_spec_target` means **no work items were written**. Show the project, packages, API version, SDK release type, spec PR, SHA and commit URL, `IsSpecMerged`, and available API versions. For updates, retain **`ExpectedTargetRevision`** from the returned target verbatim. Also retain `ExpectedPreviousSpecCommitSHA` (the observed stored SHA or `none` if unpinned) if using the optional previous-pin guard.
3. **Ask for approval** — Ask the user to approve that exact target. Unambiguous snapshot metadata supplies the API version; explicit `apiVersion` is optional. If metadata is missing or ambiguous, the selected version remains empty until the user chooses from compiler-declared `AvailableApiVersions`. Never silently choose the first/latest or invent a freeform version.
4. **Confirm** — Repeat the same operation with the exact approved `specCommitSha` and `confirmTarget: true`, preserving the other approved inputs and any explicit `apiVersion` selection. For public update and update-spec-pr, **require `expectedTargetRevision` copied verbatim from the preview**. Optionally pass `expectedSpecCommitSha` from the preview's **previous pin**, not the proposed new SHA. Create accepts neither update guard. If the PR, target, or either record's revision changes, preview again and obtain fresh approval; never fetch a replacement token at confirmation and silently reuse the old approval. Verify the saved `SpecAPIVersion` and `SpecCommitSHA` match the approval.

`confirmTarget` is a caller-supplied boolean, not an external or cryptographic approval record. An authorized caller can use an explicitly inspected plan's `TargetRevision`, but the agent should follow the preview/approval flow above. Treat the revision as opaque: it covers the parent and API Spec record IDs and revisions, so **any** parent/child revision change requires a new preview and approval, including same-SHA SDK type or metadata changes. Missing `expectedTargetRevision` returns a no-write preview even with SHA and `confirmTarget: true`; a supplied blank or mismatched token rejects before compiler validation or writes. The previous-pin guard remains optional. These guards do not make cross-record writes atomic. Private Preview and tracking-only creation do not require a revision token.

## MCP Tools

| Tool                                                               | Purpose                            |
| ------------------------------------------------------------------ | ---------------------------------- |
| `azure-sdk-mcp:azsdk_create_release_plan`                          | Create a new release plan          |
| `azure-sdk-mcp:azsdk_get_release_plan`                             | Get plan by ID, path, or spec PR   |
| `azure-sdk-mcp:azsdk_update_release_plan`                          | Update release plan metadata       |
| `azure-sdk-mcp:azsdk_update_release_plan_target`                   | Update the target release month    |
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

1. **Get TypeSpec Project Path** — Confirm the local project path for public target validation; use its repository-relative path for lookups (e.g. `specification/contosowidgetmanager/Contoso.WidgetManager`).
2. **Gather Info** — Collect required details from the user. See [details](references/release-plan-details.md):
   - Target release month/year (format: "Month YYYY", e.g. "June 2026"). Do NOT use formats like "2026-06" or "06/2026" — these are invalid.
   - API release type: Value must be one of the following: "Private Preview", "Public Preview", or "GA"
   - Spec PR URL (optional)
   - API version (optional when metadata resolves it; otherwise choose from the preview's declared versions)
   - Service Tree ID (GUID) — optional if previously created
   - Product Tree ID (GUID) — optional if previously created
3. **Preview Target** — With a public spec PR, call `azure-sdk-mcp:azsdk_create_release_plan` with `confirmTarget: false` and review/select the proposed target as above.
4. **Check Existing** — Query `azure-sdk-mcp:azsdk_get_release_plan` with the relative `typeSpecProjectPath`, `apiReleaseType`, and selected `apiVersion` when known. Reuse a plan matching the project, API version, and API release type, not merely the release type. Do not silently choose among multiple targets. Create/get never retarget an existing plan; use the explicit update flow for a same-version follow-up PR.
5. **Create** — For a new public SDK target, repeat creation after approval with the exact SHA and `confirmTarget: true`; `apiVersion` may be omitted when metadata unambiguously resolves the approved version. Creation derives SDK release type from `apiReleaseType` (`Public Preview` → `beta`, `GA` → `stable`); do not pass a `sdkReleaseType` argument or update guards. Without a PR, omit version/SHA inputs to create a tracking-only plan: it has no commit pin and cannot generate SDKs.
6. **Namespace** — For first management plane releases, link namespace approval issue using `azure-sdk-mcp:azsdk_link_namespace_approval_issue`.

> **IMPORTANT**: Use separate plans for different API versions or API release types; do not retarget an existing plan.

**Tool**: `azure-sdk-mcp:azsdk_create_release_plan`

---

### 2. Get Release Plan

**When**: User wants to check the status or details of an existing release plan.

**Steps**:

1. **Identify Plan** — Ask user for one of:
   - Release plan ID or work item ID
   - Relative TypeSpec project path (e.g. `specification/contosowidgetmanager/Contoso.WidgetManager`)
   - Spec PR URL
2. **Query** — Run `azure-sdk-mcp:azsdk_get_release_plan` with the provided identifier. Always use a relative path for `typeSpecProjectPath`; use `specPullRequestUrl` when the user provides only a spec PR URL.
3. **Display** — Show the release plan ID, status, linked PRs, `SpecAPIVersion`, `SpecCommitSHA`, `TargetRevision`, and SDK details. Ask which target the user means if multiple versions match. Always relay schedule-risk warnings and recommended actions from the response.

**Tool**: `azure-sdk-mcp:azsdk_get_release_plan`

---

### 3. Update Release Plan / Update API Spec in Release Plan

**When**: User needs to update release plan metadata (spec PR URL, TypeSpec project path, SDK release type, service/product IDs) or update the API spec PR link.

**Steps**:

1. **Identify Plan** — Identify the intended plan by ID; if resolving by path, distinguish its API version and release type before updating.
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
   - `typeSpecProjectPath` (local path required for public SDK target validation)
4. **Confirm Public Target** — For either operation, use the preview/approval flow above, then repeat with `specCommitSha`, `confirmTarget: true`, and the preview's required `expectedTargetRevision`. `apiVersion` is optional when metadata unambiguously resolves the approved version; `expectedSpecCommitSha` is an optional extra guard. This also applies when the same PR gains commits or merges. Same-version follow-ups require this explicit update; a different API version needs a separate plan.

**Tools**: `azure-sdk-mcp:azsdk_update_release_plan`, `azure-sdk-mcp:azsdk_update_api_spec_pull_request_in_release_plan`

---

### 4. Update SDK/Package Details in Release Plan

**When**: User needs to update SDK language and package name details in the release plan after code generation or configuration changes.

SDK info `apiVersion` identifies the spec API version, not the SDK package's semantic version.

**Steps**:

1. **Identify Plan** — Get the Release Plan ID or work item ID from the user (either is accepted).
2. **Identify TypeSpec Project** — Get or confirm the TypeSpec project path.
3. **Update** — Run `azure-sdk-mcp:azsdk_update_sdk_details_in_release_plan` with:
   - `workItemId` (required — accepts either the Release Plan ID or the work item ID)
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

1. **Identify Plan** — Get the Release Plan ID or work item ID from the user (either is accepted).
2. **Collect PR Info** — Get the SDK pull request URL and language from the user.
3. **Link** — Run `azure-sdk-mcp:azsdk_link_sdk_pull_request_to_release_plan` with:
   - `pullRequestUrl` (required)
   - `language` (required — e.g., ".NET", "Java", "JavaScript", "Python", "Go")
   - `workItemId` or `releasePlanId` (either accepts the Release Plan ID or the work item ID)
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
- If update fails, ensure the Release Plan ID or work item ID is correct and the plan is not already abandoned.
- If linking fails, verify the SDK PR URL is valid and the language matches a supported value.
