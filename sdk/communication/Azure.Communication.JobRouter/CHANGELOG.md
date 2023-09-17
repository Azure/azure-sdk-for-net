# Release History

## 1.0.0-beta.4 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.3 (2023-09-07)

### Bugs Fixed

- Added getter for ScoringParameters in ScoringRuleOptions

## 1.0.0-beta.2 (2023-09-06)

### Bugs Fixed

- Added getters for ScoringRuleOptions, ScoringRule in BestWorkerMode, FunctionUri in FunctionRouterRule, AppKey, ClientId and FunctionKey in FunctionRouterRuleCredential, and ExpiresAfter in PassThroughWorkerSelectorAttachment

## 1.0.0-beta.1 (2023-07-27)

This is the beta release of Azure Communication Job Router .NET SDK. For more information, please see the [README][read_me].

This is a Public Preview version, so breaking changes are possible in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo][issues].

### Features Added
- Using `JobRouterAdministrationClient`
  - Create, update, get, list and delete `DistributionPolicy`.
  - Create, update, get, list and delete `RouterQueue`.
  - Create, update, get, list and delete `ClassificationPolicy`.
  - Create, update, get, list and delete `ExceptionPolicy`.
- Using `JobRouterClient`
  - Create, update, get, list and delete `RouterJob`.
  - `RouterJob` can be created and updated with different matching modes: `QueueAndMatchMode`, `ScheduleAndSuspendMode` and `SuspendMode`.
  - Re-classify a `RouterJob`.
  - Close a `RouterJob`.
  - Complete a `RouterJob`.
  - Cancel a `RouterJob`.
  - Un-assign a `RouterJob`, with option to suspend matching.
  - Get the position of a `RouterJob` in a queue.
  - Create, update, get, list and delete `RouterWorker`.
  - Accept an offer.
  - Decline an offer.
  - Get queue statistics.


<!-- LINKS -->
[read_me]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.JobRouter/README.md
[issues]: https://github.com/Azure/azure-sdk-for-net/issues
