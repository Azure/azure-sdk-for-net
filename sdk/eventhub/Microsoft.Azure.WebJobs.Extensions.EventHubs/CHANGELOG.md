# Release History

## 5.5.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
