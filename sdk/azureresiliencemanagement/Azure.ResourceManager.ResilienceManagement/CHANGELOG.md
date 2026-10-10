# Release History

## 1.0.0 (2026-10-12)

### Features Added

- Upgraded API version to `2026-10-01`.

### Breaking Changes

- Renamed public models and enums to include their drill, goal, recovery, or job context, and standardized boolean property and enum names.
- Changed `DrillResourceProperties.ResourceType` and `ResourceFeasibilityReview.ResourceType` from `string` to `ResourceType`.
- `DrillRunReprotectContent` now requires a `ReprotectContent` payload. Set selected resource IDs through `ReprotectProperties.ReprotectRequestSelectedResourceIds`.
- Replaced `ResilienceManagementGoalsInfo.Required` with `ZonalResiliency.IsRequired` to preserve the goal requirement's context.

## 1.0.0-beta.1 (2026-06-11)

### Features Added

This is the initial release of the `Azure.ResourceManager.ResilienceManagement` client library. It provides management plane support for the Microsoft.AzureResilienceManagement resource provider.

For more information, please refer to the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/azureresiliencemanagement/Azure.ResourceManager.ResilienceManagement/README.md).
