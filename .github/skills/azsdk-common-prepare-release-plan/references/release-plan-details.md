# Release Plan Detailed Steps

> **CRITICAL**: Do not mention or display Azure DevOps work item links/URLs. Only provide Release Plan Link and Release Plan ID to the user. All manual updates must be made through the Release Planner Tool (https://aka.ms/sdk-release-planner).

## Release Plan ID vs Work Item ID

A release plan has two distinct identifiers:

- **Release Plan ID**: the value users typically refer to (e.g. in a prompt), shown in the Release Planner.
- **Work Item ID**: the Azure DevOps work item backing the release plan.

The release plan tools (update release plan, update SDK details, run SDK
generation, link SDK PR) accept **either** value — pass whichever the user gives
you. Each tool resolves the supplied number automatically, trying it as a
Release Plan ID first and then as a work item ID, so you do **not** need to run
`azsdk_get_release_plan` first just to translate one ID into the other.

## Required Information

Collect these details (do not use temporary values):

- **Service Tree ID**: GUID format - confirm with user
- **Product Service Tree ID**: GUID format - confirm with user
- **Expected Release Timeline**: "Month YYYY" format
- **API Release Type** (required): One of "Private Preview", "Public Preview", or "GA"
- **SDK Release Type** (optional): "beta" or "stable". Defaults to "beta" for Private Preview and Public Preview, "stable" for GA.

## API Release Type and Spec PR Validation

When creating or updating a release plan with a spec PR:

- **Private Preview**: Spec PR must be in `azure-rest-api-specs-pr` (private repo). A public spec PR in `azure-rest-api-specs` is NOT allowed.
- **Public Preview** or **GA**: Spec PR must be in `azure-rest-api-specs` (public repo). A private spec PR in `azure-rest-api-specs-pr` is NOT allowed.

If user provides an invalid combination, inform them of the correct pairing.

## SDK Details Update

To update SDK details in the release plan:

- Run `azsdk_update_sdk_details_in_release_plan` with the `workItemId` (either the Release Plan ID or the work item ID is accepted) and TypeSpec project path.

## Namespace Approval (Management Plane Only)

For first release of management plane SDK:

1. Check if namespace approval issue already exists
2. If not, collect GitHub issue from Azure/azure-sdk repo
3. Run `azsdk_link_namespace_approval_issue`

## Linking SDK Pull Requests

If SDK PRs exist:

1. Ensure GitHub CLI authentication (`gh auth login`)
2. Run `azsdk_link_sdk_pull_request_to_release_plan` for each PR, passing the Release Plan ID or work item ID as `workItemId` (or as `releasePlanId`) — either value is accepted.