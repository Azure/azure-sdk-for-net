# Release History

## 5.2.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
