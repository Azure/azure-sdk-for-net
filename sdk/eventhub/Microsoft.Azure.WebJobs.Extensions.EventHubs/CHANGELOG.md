# Release History

## 6.5.3 (2025-10-20)

### Bugs Fixed

- Fixed an issue where a legacy ownership record without checkpoint data was interpreted as a valid checkpoint and used to initialize a partition when no current generation checkpoint was present.

### Other Changes

## 6.5.2 (2025-06-16)

### Bugs Fixed

- Fixed a bug where the data types of broker-owned properties were being adjusted when an event was read by the client, causing the underlying AMQP data to be mutated.  This resulted in binary changes when the AMQP message was serialized and unintentionally altered the service contract.  Going forward, the original data types will be preserved on the AMQP representation of the message and type normalization only applied to the .NET `EventData` projection.
### Other Changes

- Updated the `Microsoft.Azure.Amqp` dependency to 2.7.0, which contains several bug fixes and adds support for AOT. _(see: [commits](https://github.com/Azure/azure-amqp/commits/hotfix/))_
 
- Added a compatibility hack to the binding data associated with the trigger to preserve the previous service behavior of `Offset` being a valid numeric value.  As this data is not local to the trigger context and is surfaced upstream, the change in service behavior for GeoDR namespaces caused issues with some custom language workers making invalid assumptions about the string-based offset format.  To work around this, the `Offset` is being populated with `OffsetString` if it can be parsed as a number.  In the case that `OffsetString` is not a valid numeric value, it will default to `-1` which would position readers at the beginning of the stream, causing duplicates but preventing data loss.  A key for `OffsetString` was added that reflects the actual offset returned by the service in all scenarios.

## 6.5.1 (2025-04-09)

### Bugs Fixed

- Fixed a bug which caused the placeholder value used to represent missing offsets in v5.11.3 - v5.11.6 to not be properly detected and incorrectly used as a valid offset when reading from a partition.

## 6.5.0 (2025-04-08)

### Features Added

- Support for the Event Hubs geographic data replication feature has been enabled.  As part of this feature, the type of offset-related data has been changed from `long` to `string` to align with changes to the Event Hubs service API. To preserve backwards compatibility, the existing offset-related members have not been changed, and new members with names similar to `OffsetString` and string-based parameters for method overloads have been introduced.   
  
  The long-based offset members will continue to work for Event Hubs namespaces that do not have GeoDR replication enabled, but are discouraged for use and have been marked as obsolete.

### Bugs Fixed

- Fixed a misspelling of "PartitionId" in the trigger input data passed to the function executor.  This caused function logs and metrics reported by AppInsights and the portal to reflect the wrong label.  To ensure that applications that rely on the misspelling are not impacted, a new member with the correct spelling was added.

### Other Changes

- Updating .NET runtime dependencies to the 6.x line, the Azure extensions to 1.8.0, and the latest dependencies for the Functions host.

## 6.4.0-beta.1 (2025-03-14)

### Bugs Fixed

- Fixed a misspelling of "PartitionId" in the trigger input data passed to the function executor.  This caused function logs and metrics reported by AppInsights and the portal to reflect the wrong label.  To ensure that applications that rely on the misspelling are not impacted, a new member with the correct spelling was added.

### Other Changes

- Updating .NET runtime dependencies to the 6.x line, the Azure extensions to 1.8.0, and the latest dependencies for the Functions host.

## 6.3.5 (2024-08-01)

### Other Changes

- Bump dependency on `Azure.Messaging.EventHubs` to 5.11.5.

## 6.3.4 (2024-07-25)

### Other Changes

- When the trigger's connection property is set to a valid connection string instead of an informational name, the mistake will be detected and sensitive information will be redacted from the error message to avoid accidental capture in logs and similar mechanisms.

## 6.3.3 (2024-06-13)

### Other Changes

- To mitigate a vulnerability, updating the transitive dependency for `Azure.Identity` to v1.11.4 via version bump to `Microsoft.Extensions.Azure`.

## 6.3.2 (2024-04-29)

### Bugs Fixed

- Fixed an issue with scale metrics computation, potentially causing unnecessary scale-up.

## 6.3.1 (2024-04-17)

### Other Changes

- To mitigate a [disclosure vulnerability](https://github.com/advisories/GHSA-wvxc-855f-jvrv), updating the transitive dependency for `Azure.Identity` to v1.11.1 via version bump to `Microsoft.Extensions.Azure`.

## 6.3.0 (2024-04-10)

### Features Added

- Added a new setting to `EventHubOptions` to allow checkpointing to be disabled for applications that always want to use their `initialOffsetOptions` when starting to process a new partition.

## 6.2.0 (2024-03-05)

### Other Changes

- Adjusted checkpointing logic to no longer write a checkpoint when the listener is shutting down.  This was necessary to prevent potential data loss from occurring when shutting down Function retries.  Because the trigger cannot know if the Function host would have retried a failure if it were not shutting down, we cannot assume that it is safe to checkpoint. This change ensures that the batch of events being processed when shut down was requested will be retried by another instance or the next time the Function app is run.

- Updated the `Azure.Messaging.EventHubs`, which includes a new build of the AMQP transport library. The notable bug fix addresses an obscure race condition when a cancellation token is signaled while service operations are being invoked concurrently which caused those operations to hang.

## 6.1.0 (2024-02-13)

### Bugs Fixed

- The `SystemProperties` binding will now return certain item as string values instead of an AMQP structure that requires calling `ToString()` to read.  The affected system properties are:
  - MessageId
  - CorelationId
  - To
  - ReplyTo

- Avoid race condition when determining whether to checkpoint when the host is in the process of shutting down.

### Other Changes

- Updated the `Azure.Messaging.EventHubs` dependency, which includes optimized defaults of the host platform to be used for AMQP buffers.  This offers non-trivial performance increase on Linux-based platforms and a minor improvement on macOS.  This update also enables support for TLS 1.3.

## 6.0.2 (2023-11-13)

### Other Changes

- Bump dependency on `Microsoft.Extensions.Azure` to prevent transitive dependency on deprecated version of `Azure.Identity`.

## 6.0.1 (2023-10-10)

### Bugs Fixed

- Added support for the legacy checkpoint format when making scaling decisions.

## 6.0.0 (2023-09-12)

### Breaking Changes

- The default batch size has changed to 100 events.  Previously, the default batch size was 10.

  This setting represents the maximum number of events from Event Hubs that the function can receive when it's invoked. The decision to change the default was based on developer feedback, testing, and a desire to match the defaults used by the Azure SDK for Event Hubs.  This change will be beneficial to the average scenario by helping to improve performance as well as lower costs due to fewer function executions.

  We recommend testing to ensure no breaking changes are introducing to your function app before updating existing applications to version 6.0.0 or newer of the Event Hubs extension, especially if you have code code that was written to expect 10 as the max event batch size.

### Bugs Fixed

- Fixed an issue where checkpoints were not always written when using a minimum batch size with low throughput.

## 5.5.0 (2023-08-11)

### Bugs Fixed

- When binding to a `CancellationToken`, the token will no longer be signaled when in Drain Mode.
  To detect if the function app is in Drain Mode, use dependency injection to inject the
  `IDrainModeManager`, and check the `IsDrainModeEnabled` property. Additionally, checkpointing
  will now occur when the function app is in Drain Mode.

## 5.4.0 (2023-06-06)

### Features Added

- Added support for binding to `EventData` with the Event Hubs trigger in Functions using the isolated process model.

### Bugs Fixed

- Fixed a race condition when Function instances are scaling that could cause a checkpoint to be written before the Function code was invoked to process events.  This would result in the new owner for the partition skipping those events causing them to go unprocessed.

- Fixed an issue that could cause the trigger to miss that a cancellation token has been signaled, slowing down responsiveness to scaling and shutdown.

## 5.3.0 (2023-04-11)

### Features Added

- It is now possible to configure a desired minimum for the number of events included in each batch that the trigger build and how long the trigger should wait while trying to a batch of that size.  This is intended to help control costs by having the trigger invoke the Function fewer times, but with more events in each batch.

  It is important to note that neither the minimum batch size or maximum wait time are guarantees; the trigger will make its best effort to honor them but you may see partial batches or inaccurate timing.  This scenario is common when a Function is scaling.

### Bugs Fixed

- Changed the approach that the trigger uses to validate permissions on startup to ensure that it does not interrupt other triggers already running by temporarily asserting ownership of a partition.

## 5.2.0 (2023-02-23)

### Features Added

- Added the an overload for `IAsyncCollector<EventData>` allowing a partition key to be specified.  Because `IAsyncCollector<T>` is owned by the Functions runtime, this method could not be directly added.  Instead, this has been implemented as an extension method within the Event Hubs extension package.  Unfortunately, this knowingly makes the overload unable to be mocked.

- Target-based scaling support has been added, allowing instances for Event Hubs-triggered Functions to more accurately calculate their scale needs and adjust more quickly as the number of events waiting to be processed changes. This will also reduce duplicate event processing as the instance count changes.

- A new setting, `UnprocessedEventThreshold`, has been added to help tune target-based scaling.  More details can be found in the [host.json documentation](https://learn.microsoft.com/azure/azure-functions/functions-bindings-event-hubs?tabs=in-process%2Cextensionv5&pivots=programming-language-csharp#hostjson-settings).

### Bugs Fixed

- Fixed a bug with creation of the event processor used by the trigger, where configuring an `eventHubName` that does not match the one that appears as `EntityPath` in the connection string would throw.  The behavior now follows that of other clients and gives precedence to the entity path in the connection string.

## 5.1.2 (2022-08-10)

### Bugs Fixed

- Fixed a bug in the runtime scale controller that could result in a null reference exception when encountering a null checkpoint. Also, correct the assumption that the beginning sequence number for a partition is always 0.

## 5.1.1 (2022-06-20)

### Bugs Fixed

- Fixed a bug in the runtime scale controller that prevented function apps from scaling in.

## 5.1.0 (2022-04-21)

### Features Added

- Adding support for retry policy (SupportsRetryAttribute)

## 5.0.1 (2022-03-09)

### Features Added

- Add listener details

### Bugs Fixed

- Cancel function execution after partition ownership is lost.
- Stop the processor when disposing the listener to avoid having functions execute after the host has already been disposed.

## 5.0.0 (2021-10-21)

### Features Added

- General availability of Microsoft.Azure.WebJobs.Extensions.EventHubs 5.0.0.

## 5.0.0-beta.7 (2021-07-07)

### Breaking Changes

- Renamed `MaxBatchSize` to `MaxEventBatchSize` in `EventHubsOptions`.

## 5.0.0-beta.6 (2021-06-09)

### Changes

#### Key Bug Fixes

- Single dispatch now uses one thread per partition.

## 5.0.0-beta.5 (2021-05-11)

### Changes

#### Key Bug Fixes

- The web proxy specified in configuration is now respected.

#### New Features

- Added support for specifying `accountName` or `blobServiceUri` for the checkpoint connection.

## 5.0.0-beta.4 (2021-04-06)

### Changes

- Single dispatch triggers were disabled.

## 5.0.0-beta.3 (2021-03-11)

### Changes

- Default balancing strategy changed to greedy.

## 5.0.0-beta.2 (2021-03-09)

### Changes

#### Key Bug Fixes

- Fixed an issue where the `PartitionContext` is not injected correctly.
- Fixed an issue where variables were not resolved when used in the `ConsumerGroup` attribute property.

#### New Features

- Added support for TokenCredential-based authentication for Azure Storage connection used for checkpointing.

## 5.0.0-beta.1 (2021-02-09)

- The initial beta release of Microsoft.Azure.WebJobs.Extensions.EventHubs 5.0.0
