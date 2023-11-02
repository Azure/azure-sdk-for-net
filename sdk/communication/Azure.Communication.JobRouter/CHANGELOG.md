# Release History

## 1.0.0

### Features Added

#### RouterAdministrationClient
- Added `RequestContext` to all methods which can override default behaviors of the client pipeline on a per-call basis.
- Added `RequestConditions` to all `Update` methods which can specify HTTP options for conditional requests based on modification time.

#### RouterClient
- Added `RequestContext` to all methods which can override default behaviors of the client pipeline on a per-call basis.
- Added `RequestConditions` to all `Update` methods which can specify HTTP options for conditional requests based on modification time.

### Breaking Changes

#### RouterAdministrationClient
- `GetQueues` returns `AsyncPageable<RouterQueue>` rather than `Pageable<RouterQueueItem>`
- `GetDistributionPolicies` returns `AsyncPageable<DistributionPolicy>` rather than `Pageable<DistributionPolicyItem>`
- `GetClassificationPolicies` returns `AsyncPageable<ClassificationPolicy>` rather than `Pageable<ClassificationPolicyItem>`
- `GetExceptionPolicies` returns `AsyncPageable<ExceptionPolicy>` rather than `Pageable<ExceptionPolicyItem>`
- `UpdateQueue(UpdateQueueOptions options, CancellationToken cancellationToken)` changed to `UpdateQueue(RouterQueue queue, CancellationToken cancellationToken)`
- `UpdateDistributionPolicy(UpdateDistributionPolicyOptions options, CancellationToken cancellationToken)` changed to `UpdateDistributionPolicy(DistributionPolicy distributionPolicy, CancellationToken cancellationToken)`
- `UpdateClassificationPolicy(UpdateClassificationPolicyOptions options, CancellationToken cancellationToken)` changed to `UpdateClassificationPolicy(ClassificationPolicy classificationPolicy, CancellationToken cancellationToken)`
- `UpdateExceptionPolicy(UpdateExceptionPolicyOptions options, CancellationToken cancellationToken)` changed to `UpdateExceptionPolicy(ExceptionPolicy exceptionPolicy, CancellationToken cancellationToken)`

#### RouterClient
- `GetJobs` returns `AsyncPageable<RouterJob>` rather than `AsyncPageable<RouterJobItem>`
- `GetWorkers` returns `AsyncPageable<RouterWorker>` rather than `AsyncPageable<RouterJobWorker>`
- `UpdateJob(UpdateJobOptions options, CancellationToken cancellationToken)` changed to `UpdateJob(RouterJob job, CancellationToken cancellationToken)`
- `UpdateWorker(UpdateWorkerOptions options, CancellationToken cancellationToken)` changed to `UpdateWorker(RouterWorker worker, CancellationToken cancellationToken)`
- `CancelJob(CancelJobOptions options, CancellationToken cancellationToken = default)` changed to `CancelJob(string jobId, CancelJobOptions cancelJobOptions = null, CancellationToken cancellationToken = default)`
- `CompleteJob(CompleteJobOptions options, CancellationToken cancellationToken = default)` changed to `CompleteJob(string jobId, CompleteJobOptions completeJobOptions = null, CancellationToken cancellationToken = default)`
- `CloseJob(CloseJobOptions options, CancellationToken cancellationToken = default)` changed to `CloseJob(string jobId, CloseJobOptions closeJobOptions = null, CancellationToken cancellationToken = default)`
- `DeclineJobOffer(DeclineJobOfferOptions options, CancellationToken cancellationToken = default)` changed to `DeclineJobOffer(string workerId, string offerId, DeclineJobOfferOptions declineJobOfferOptions = null, CancellationToken cancellationToken = default)`
- `UnassignJob(UnassignJobOptions options, CancellationToken cancellationToken = default)` changed to `UnassignJob(string jobId, string assignmentId, UnassignJobOptions unassignJobOptions = null, CancellationToken cancellationToken = default)`

#### CancelJobOptions
- Changed constructor from `CancelJobOptions(string jobId)` to `CancelJobOptions()`

#### CompleteJobOptions
- Changed constructor from `CompleteJobOptions(string jobId, string assignmentId)` to `CompleteJobOptions(string assignmentId)`

#### CloseJobOptions
- Changed constructor from `CloseJobOptions(string jobId, string assignmentId)` to `CloseJobOptions(string assignmentId)`

#### DeclineJobOfferOptions
- Changed constructor from `DeclineJobOfferOptions(string workerId, string offerId)` to `DeclineJobOfferOptions()`

#### UnassignJobOptions
- Changed constructor from `UnassignJobOptions(string jobId, string assignmentId)` to `UnassignJobOptions()`

#### RouterJob && CreateJobOptions && CreateJobWithClassificationOptions
- Property `Notes` - Changed from `List<RouterJobNote>` to `IList<RouterJobNote>`
- Property `RequestedWorkerSelectors` - Changed from `List<RouterWorkerSelector>`to `IList<RouterWorkerSelector>`
- Property `Labels` - Changed from `Dictionary<string, LabelValue>` to `IDictionary<string, LabelValue>`
- Property `Tags` - Changed from `Dictionary<string, LabelValue>` to `IDictionary<string, LabelValue>`

##### RouterJobNote
- Changed constructor from `RouterJobNote()` to `RouterJobNote(string message)`
- Removed setter from `Message`

#### RouterWorker && CreateWorkerOptions
- Rename property `QueueAssignments` -> `Queues`
- `Queues` - Changed `Dictionary<string, RouterQueueAssignment>` -> `IList<string>`
- Rename property `TotalCapacity` -> `Capacity`
- Rename property `ChannelConfigurations` -> `Channels`
- `Channels` - Changed `Dictionary<string, ChannelConfiguration>` -> `IList<RouterChannel>`

#### ClassificationPolicy && CreateClassificationPolicyOptions
- Property `List<QueueSelectorAttachment> QueueSelectors` changed to `IList<QueueSelectorAttachment> QueueSelectorAttachments`
- Property `List<WorkerSelectorAttachment> WorkerSelectors` changed to `IList<WorkerSelectorAttachment> WorkerSelectorAttachments`

#### ExceptionPolicy && CreateExceptionPolicyOptions
- Property `ExceptionRules` - Changed from `Dictionary<string, ExceptionRule>` -> `IList<ExceptionRule>`

##### ExceptionRule
- `Actions` - Changed `Dictionary<string, ExceptionAction>` -> `IList<ExceptionAction>`

##### CancelExceptionAction
- Changed constructor from `CancelExceptionAction(string note = null, string dispositionCode = null)` to `CancelExceptionAction()`

##### ReclassifyExceptionAction
- Changed constructor from `ReclassifyExceptionAction(string classificationPolicyId, IDictionary<string, LabelValue> labelsToUpsert = null)` to `ReclassifyExceptionAction()`
- Removed setter from `LabelsToUpsert`

#### BestWorkerMode
- Removed constructor `BestWorkerMode(RouterRule scoringRule = null, IList<ScoringRuleParameterSelector> scoringParameterSelectors = null, bool allowScoringBatchOfWorkers = false, int? batchSize = null, bool descendingOrder = true, bool bypassSelectors = false)`

##### ScoringRuleOptions
- Rename property `AllowScoringBatchOfWorkers` -> `IsBatchScoringEnabled`

#### FunctionRouterRuleCredential
- Removed properties `AppKey` and `FunctionKey`

#### OAuth2WebhookClientCredential
- Removed property `ClientSecret`

#### RouterQueueStatistics
- Changed `IReadOnlyDictionary<string, double> EstimatedWaitTimeMinutes` to `IDictionary<int, TimeSpan> EstimatedWaitTimes`

#### LabelOperator
- Renamed `GreaterThanEqual` to `GreaterThanOrEqual`
- Renamed `LessThanEqual` to `LessThanOrEqual`

#### Renames
- `ChannelConfiguration` -> `RouterChannel`
- `Oauth2ClientCredential` -> `OAuth2WebhookClientCredential`
- `LabelValue` -> `RouterValue`

#### Deletions
- `ClassificationPolicyItem`
- `DistributionPolicyItem`
- `ExceptionPolicyItem`
- `RouterQueueItem`
- `RouterWorkerItem`
- `RouterJobItem`
- `RouterQueueAssignment`
- `UpdateClassificationPolicyOptions`
- `UpdateDistributionPolicyOptions`
- `UpdateExceptionPolicyOptions`
- `UpdateQueueOptions`
- `UpdateWorkerOptions`
- `UpdateJobOptions`

### Other Changes

#### ClassificationPolicy
- Add `ETag`
- Added constructor `ClassificationPolicy(string classificationPolicyId)`
- Added setters to `FallbackQueueId`, `Name`, and `PrioritizationRule`

#### DistributionPolicy
- Add `ETag`
- Added constructor `DistributionPolicy(string distributionPolicyId)`
- Added setters to `Mode` and `Name`

#### ExceptionPolicy
- Added `ETag`
- Added constructor `ExceptionPolicy(string exceptionPolicyId)`
- Added setter to `Name`

##### ExceptionRule
- Added `Id`

##### ExceptionAction
- Added `Id`. Property is read-only. If not provided, it will be generated by the service.

##### ReclassifyExceptionAction
- Added setter to `ClassificationPolicyId`

#### RouterChannel
- Added `ChannelId`

#### RouterJob
- Added `ETag`
- Added constructor `RouterJob(string jobId)`
- Added setters for `ChannelId`, `ChannelReference`, `ClassificationPolicyId`, `DispositionCode`, `MatchingMode`, `Priority`, `QueueId`

#### RouterQueue
- Added `ETag`
- Added constructor `RouterQueue(string queueId)`
- Added setters for `DistributionPolicyId`, `ExceptionPolicyId` and `Name`

#### RouterWorker
- Added `ETag`
- Added constructor `RouterWorker(string workerId)`

#### BestWorkerMode
- Added setters to `ScoringRule` and `ScoringRuleOptions`

#### OAuth2WebhookClientCredential
- Added constructor `OAuth2WebhookClientCredential(string clientId, string clientSecret)`

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
