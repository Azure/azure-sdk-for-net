# Release History

## 1.0.0-beta.1 (2026-04-22)

### Features Added

- Initial preview release of `Azure.ResourceManager.Monitor.Slis` for managing
  Service Level Indicator (SLI) resources under the `Microsoft.Monitor` namespace.
- Support for SLI resource CRUD operations: create or update, get, delete, and list.
- SLI evaluation with Availability and Latency categories, supporting both
  window-based and request-based evaluation types with configurable signal sources,
  aggregation, and SLO baselines.
- Integration with Azure Monitor Workspace (AMW) accounts for metric emission,
  with managed identity and alert support.