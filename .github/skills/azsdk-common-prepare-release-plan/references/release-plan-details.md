# Release Plan Detailed Steps

> **CRITICAL**: Do not mention or display Azure DevOps work item links/URLs. Only provide Release Plan Link and Release Plan ID to the user. All manual updates must be made through the Release Planner Tool (https://aka.ms/sdk-release-planner).

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

- Run `azsdk_update_sdk_details_in_release_plan` with the release plan work item ID and TypeSpec project path

## Namespace Approval (Management Plane Only)

For first release of management plane SDK:

1. Check if namespace approval issue already exists
2. If not, collect GitHub issue from Azure/azure-sdk repo
3. Run `azsdk_link_namespace_approval_issue`

## Linking SDK Pull Requests

If SDK PRs exist:

1. Ensure GitHub CLI authentication (`gh auth login`)
2. Run `azsdk_link_sdk_pull_request_to_release_plan` for each PR