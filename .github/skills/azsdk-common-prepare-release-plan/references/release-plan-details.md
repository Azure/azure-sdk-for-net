# Release Plan Detailed Steps

> **CRITICAL**: Do not mention or display Azure DevOps work item links/URLs. Only provide Release Plan Link and Release Plan ID to the user. All manual updates must be made through the Release Planner Tool (https://aka.ms/sdk-release-planner).

## Required Information

Collect these details (do not use temporary values):

- **Service Tree ID**: GUID format - confirm with user
- **Product Service Tree ID**: GUID format - confirm with user
- **Expected Release Timeline**: "Month YYYY" format
- **API Version**: e.g., "2024-01-01" or "2024-01-01-preview"
- **SDK Release Type**: "beta" (preview) or "stable" (GA)

## SDK Details Update

Identify languages from `tspconfig.yaml` emitter configuration:

- Map emitter names to languages (.NET, Java, Python, JavaScript, Go)
- Extract package names per language
- **Validate package names:**
  - JavaScript: Must start with `@azure/`
  - Go: Must start with `sdk/`
- Run `azsdk_update_sdk_details_in_release_plan` with language/package JSON

## Namespace Approval (Management Plane Only)

For first release of management plane SDK:

1. Check if namespace approval issue already exists
2. If not, collect GitHub issue from Azure/azure-sdk repo
3. Run `azsdk_link_namespace_approval_issue`

## Linking SDK Pull Requests

If SDK PRs exist:

1. Ensure GitHub CLI authentication (`gh auth login`)
2. Run `azsdk_link_sdk_pull_request_to_release_plan` for each PR
