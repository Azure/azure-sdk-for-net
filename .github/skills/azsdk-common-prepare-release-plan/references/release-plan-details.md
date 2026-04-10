# Release Plan Detailed Steps

> **CRITICAL**: Do not mention or display Azure DevOps work item links/URLs. Only provide Release Plan Link and Release Plan ID to the user. All manual updates must be made through the [Release Planner Tool](https://aka.ms/sdk-release-planner). If the user doesn't know required details, direct them to: [Release Plan Creation Guide](https://eng.ms/docs/products/azure-developer-experience/plan/release-plan-create).

## Required Information

Collect these details (do not use temporary values — confirm all values with user before creating):

- **Service Tree ID**: GUID format - show to user and confirm it's valid in Service Tree
- **Product Service Tree ID**: GUID format - show to user and confirm it's valid in Service Tree
- **Expected Release Timeline**: "Month YYYY" format
- **API Version**: e.g., "2024-01-01" or "2024-01-01-preview"
- **SDK Release Type**: "beta" (preview) or "stable" (GA)

## SDK Details Update

Identify languages from `tspconfig.yaml` emitter configuration:

### Extracting Package Names per Language

- **Java / Python**: Use `emitter-output-dir` for package name if it exists; otherwise use `package-dir` as fallback
- **.NET**: Use the `namespace` property
- **JavaScript**: Use the `packagedetails:name` property
- **Go**: Use the module name and remove `github.com/Azure/azure-sdk-for-go/` prefix

Map emitter names to languages in Pascal case (except .NET): .NET, Java, Python, JavaScript, Go

Create a JSON array with the following structure:
```json
[
  { "language": "<LanguageName>", "packageName": "<PackageName>" },
  ...
]
```

If no languages are configured, inform user: "No languages configured in TypeSpec project. Please add at least one language emitter in tspconfig.yaml."

### Package Name Validation

**(MANDATORY) Always validate package names before calling any update tool, even if the user provides SDK details directly. Auto-correct and inform the user of invalid package names.**

- **JavaScript**: Must start with `@azure/`
- **Go**: Must start with `sdk/`

| Language | Valid | Invalid |
|----------|-------|---------|
| JavaScript | `@azure/arm-compute` | `arm-compute`, `azure/arm-compute`, `@azure-arm-compute` |
| Go (mgmt) | `sdk/resourcemanager/compute/armcompute` | `sdk/armcompute`, `/sdk/compute`, `github.com/Azure/azure-sdk-for-go/sdk/resourcemanager/compute` |

Run `azsdk_update_sdk_details_in_release_plan` with the validated language/package JSON.

## Namespace Approval (Management Plane Only)

This step is required only for management plane API specs with an existing release plan.

1. Get release plan and check if it is for management plane SDK
2. If not mgmt plane, inform user: "This task is only applicable for management plane SDKs. No action required."
3. Check if release plan already has a namespace approval issue; also prompt user to check if this is the first release of SDK
4. If namespace approval issue exists, inform user and show status; prompt to check if they want to link a different issue
5. If no issue exists or user wants to link a new one:
   - Collect GitHub issue created in the `Azure/azure-sdk` repo (do not use any other repo)
   - Run `azsdk_link_namespace_approval_issue` to link to the release plan work item
   - Confirm successful linking

## Linking SDK Pull Requests

If SDK PRs exist:

1. Ensure GitHub CLI authentication (`gh auth login` / `gh auth status`)
2. Run `azsdk_link_sdk_pull_request_to_release_plan` for each PR
3. Confirm successful linking for each SDK PR
