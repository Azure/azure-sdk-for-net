# Release History

## 5.13.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 5.12.2 (2025-06-12)

### Bugs Fixed

- Fixed a bug where the data types of broker-owned properties were being adjusted when an event was read by the client, causing the underlying AMQP data to be mutated.  This resulted in binary changes when the AMQP message was serialized and unintentionally altered the service contract.  Going forward, the original data types will be preserved on the AMQP representation of the message and type normalization only applied to the .NET `EventData` projection.

### Other Changes

- Updated the `Microsoft.Azure.Amqp` dependency to 2.7.0, which contains several bug fixes and adds support for AOT. _(see: [commits](https://github.com/Azure/azure-amqp/commits/hotfix/))_

## 5.12.1 (2025-04-09)

### Bugs Fixed

- Fixed a bug which caused the placeholder value used to represent missing offsets in v5.11.3 - v5.11.6 to not be properly detected and incorrectly used as a valid offset when reading from a partition.

## 5.12.0 (2025-04-08)

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- tovyhnal _([GitHub](https://github.com/tovyhnal))_

### Features Added

- Support for the Event Hubs geographic data replication feature has been enabled. Checking for whether or not this feature is enabled for your namespace can be done by querying for Event Hub properties using `EventHubProducerClient` or `EventHubConsumerClient` and referencing the the `IsGeoReplicationEnabled` property of the result.

  As part of this feature, the type of offset-related data has been changed from `long` to `string` to align with changes to the Event Hubs service API. To preserve backwards compatibility, the existing offset-related members have not been changed, and new members with names similar to `OffsetString` and string-based parameters for method overloads have been introduced.   
  
  The long-based offset members will continue to work for Event Hubs namespaces that do not have GeoDR replication enabled, but are discouraged for use and have been marked as obsolete.
  
  Obsoleted properties:
  - `EventData.Offset`
  - `LastEnqueuedEventProperties.Offset`
  - `PartitionProperties.LastEnqueuedOffset`

  Obsoleted method overloads:
  - `EventPosition.FromOffset`
  - `EventHubsModelFactory.EventData`
  - `BlobCheckpointStore.UpdateCheckpointAsync`
  - `EventProcessorClient.UpdateCheckpointAsync`

### Bugs Fixed

- Fixed behavior in the `UpdateCheckpointAsync` method of `EventProcessorClient` to properly await the call to the checkpoint store.  Previously, this was not awaited, causing the OTel span to open and close almost immediately and skip reporting any errors observed.

### Other Changes

- Enhanced retry logic to consider additional cases for web socket-based failures.  In many cases, a `WebSocketException` is triggered which wraps a `SocketException` with the details for the specific network conditions.  Retry decisions are now based on the internal exception, if present, to ensure retries are correctly applied.

- Added annotations to make the package compatible with trimming and native AOT compilation.

- Added Event Hub name to processor load balancing logs for additional context.  _(A community contribution, courtesy of [tovyhnal](https://github.com/tovyhnal))_

- Updated the `Microsoft.Azure.Amqp` dependency to 2.6.9, which contains several bug fixes. _(see: [commits](https://github.com/Azure/azure-amqp/commits/hotfix/))_

## 5.12.0-beta.2 (2025-02-11)

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- tovyhnal _([GitHub](https://github.com/tovyhnal))_

### Features Added

- Support for the Event Hubs geographic data replication feature has been enabled. Checking for whether or not this feature is enabled for your namespace can be done by querying for Event Hub properties using `EventHubProducerClient` or `EventHubConsumerClient` and referencing the the `IsGeoReplicationEnabled` property of the result.

  As part of this feature, the type of offset-related data has been changed from `long` to `string` to align with changes to the Event Hubs service API. To preserve backwards compatibility, the existing offset-related members have not been changed, and new members with names similar to `OffsetString` and string-based parameters for method overloads have been introduced.   
  
  The long-based offset members will continue to work for Event Hubs namespaces that do not have GeoDR replication enabled, but are discouraged for use and have been marked as obsolete.
  
  Obsoleted properties:
  - `EventData.Offset`
  - `LastEnqueuedEventProperties.Offset`
  - `PartitionProperties.LastEnqueuedOffset`

  Obsoleted method overloads:
  - EventPosition.FromOffset
  - EventHubsModelFactory.EventData
  - BlobCheckpointStore.UpdateCheckpointAsync
  - EventProcessorClient.UpdateCheckpointAsync
  
### Other Changes

- Added annotations to make the package compatible with trimming and native AOT compilation.

- Added Event Hub name to processor load balancing logs for additional context.  _(A community contribution, courtesy of [tovyhnal](https://github.com/tovyhnal))_

- Updated the `Microsoft.Azure.Amqp` dependency to 2.6.9, which contains several bug fixes. _(see: [commits](https://github.com/Azure/azure-amqp/commits/hotfix/))_

## 5.11.6 (2025-02-11)

### Other Changes

- Bump `Azure.Messaging.EventHubs` dependency to 5.11.6, which includes bumps to several transitive dependencies.

## 5.11.5 (2024-08-14)

### Other Changes

- Bump `Azure.Core.Amqp` dependency to 1.3.1, which includes a fix to serialization of binary application properties.

## 5.11.4 (2024-07-17)

### Bugs Fixed

- Fixed an error that prevented relative URIs from being used with [application properties](https://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-application-properties) in the `EventData.Properties` collection.

- Fixed an error with ETW logs which caused structured arguments for Id 105 (Event Processor position determined) to be out-of-order with the message format.  This also caused the date to render incorrectly for some captures.

### Other Changes

- The processor will now refresh the maximum message size each time a new AMQP link is opened; this is necessary for large message support, where the maximum message size for entities can be reconfigured and adjusted on the fly.  Because the client had cached the value, it would not be aware of the change and would enforce the wrong size for batch creation.

- Adjusted the options used by the processor during startup validation to reduce the amount of data transferred and minimize impact on the outgoing events metric.

## 5.12.0-beta.1 (2024-05-17)

### Features Added

- Preview support for the Event Hubs geographic data replication feature has been enabled. Checking for whether or not this feature is enabled for your namespace can be done by querying for Event Hub properties using `EventHubProducerClient` or `EventHubConsumerClient` and referencing the the `IsGeoReplicationEnabled` property of the result.

### Breaking Changes

  ### Major

  The type of offset-related data has been changed from `long` to `string` to align with changes to the Event Hubs service API.  The default value for any offset-related data has been changed from `long.MinValue` to `null`.

  Impacted properties:
  - EventData.Offset
  - LastEnqueuedEventProperties.Offset
  - PartitionProperties.LastEnqueuedOffset
  - CheckpointPosition.Offset

  Impacted methods:
  - EventPosition.FromOffset
  - EventHubsModelFactory.EventData
  - CheckpointStore.UpdateCheckpointAsync _(deprecated overload)_
  - EventProcessor&lt;T&gt;.UpdateCheckpointAsync _(deprecated overload)_

## 5.11.3 (2024-05-15)

### Bugs Fixed

- Fixed an error that caused connection strings using host names without a scheme to fail parsing and be considered invalid.

### Other Changes

- Removed the restriction that endpoints used with the development emulator had to resolve to a `localhost` variant.

- Updated the `Microsoft.Azure.Amqp` dependency to 2.6.7, which contains several bug fixes, including for an internal `NullReferenceException` that would sometimes impact creating new links. _(see: [#258](https://github.com/azure/azure-amqp/issues/258))_

## 5.11.2 (2024-04-10)

### Bugs Fixed

- The `EventProcessorClient` will now create a unique span for each event emitted to the handler for processing.  Previously a single span was created for all events in a batch.  ([#31922](https://github.com/Azure/azure-sdk-for-net/issues/31922))

- Fixed a parameter ordering error in ETW 22 (EventBatchProcessingError) that caused structured data arguments to be ordered differently than the associated replacement token in the log message.

### Other Changes

- Added option `EnableCheckpointing` to allow automatic checkpointing to be disabled for applications that only wish to read current data rather than tracking the state of processing.

## 5.11.1 (2024-03-05)

### Other Changes

- Updated the `Microsoft.Azure.Amqp` dependency to 2.6.5, which includes several bug fixes.  A notable fix addresses an obscure race condition when a cancellation token is signaled while service operations are being invoked concurrently which caused those operations to hang.

## 5.11.0 (2024-02-13)

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Dave Trainer _([GitHub](https://github.com/davetrainer))_

### Features Added

- Added a `CheckpointPosition` struct to use when updating a checkpoint. The specified position indicates that an event processor should begin reading from the next event. Added new `UpdateCheckpointAsync` overloads to `EventProcessorClient` and `BlobCheckpointStore` that accept the `CheckpointPosition` struct instead of individual values for offset and sequence number.

### Breaking Changes

- The type of several existing values in the `EventData.SystemProperties` collection have been changed so that they are properly represented as .NET string types.  Previously, the underlying AMQP types were unintentionally returned, forcing callers to call `ToString()` to read the value.

  This is a behavioral breaking change that will impacts only those callers who were explicitly casting system property values to `AmqpAddress` or `AmqpMessageId` before calling `ToString()`.   The affected system properties are:
  - MessageId
  - CorelationId
  - To
  - ReplyTo

- The base implementations of both `UpdateCheckpointAsync` method overloads in `PluggableCheckpointStoreEventProcessor<TPartition>` and `EventProcessor<TPartition>` now choose sequence number over offset when writing a checkpoint and both values are provided. Previously, writing a checkpoint prioritized offset over sequence number.  **There is no difference in behavior for normal usage scenarios.**

### Bugs Fixed

- Fixed a race condition that could lead to a synchronization primitive being double-released if `IsRunning` was called concurrently while starting or stopping the processor.

- Fixed a bug in which cancellation honored by the processor was interpreted as an error surfaced by developer code and a warning was inappropriately emitted to the error handler.

- Fixed an issue with event processor validation where an exception for quota exceeded may inappropriately be surfaced when starting the processor.

- In the rare case that an event processor's load balancing and health monitoring task cannot recover from an error, it will now properly surrender ownership when processing stops.

### Other Changes

- A new [sample](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/README.md#common-samples) that demonstrates using the `EventProcessorClient` with an ASP.NET hosted service is now available.  _(A community contribution, courtesy of [davetrainer](https://github.com/davetrainer))_

- Updated the `Microsoft.Azure.Amqp` dependency to 2.6.4, which enables support for TLS 1.3.

- Removed the custom sizes for the AMQP sending and receiving buffers, allowing the optimized defaults of the host platform to be used.  This offers non-trivial performance increase on Linux-based platforms and a minor improvement on macOS.  Windows performance remains unchanged as the default and custom buffer sizes are equivalent.

- Improved efficiency of partition management during load balancing, reducing the number of operations performed and deferring waiting for lost partitions until the processor is stopped or the partition is reclaimed.  Allocations were also non-trivially reduced.

- Improved the approach used by the processor to manage the background tasks for partition processing and load balancing.  These tasks are now marked as long-running and have improved error recovery.

- Initialization of the load balancing task is now performed in the background and will no longer cause delays when starting the processor.

- Loosened validation for the fully qualified namespace name passed to the processor constructor.  A URI is now also accepted as a valid format.  This is intended to improve the experience when using the management library, CLI, Bicep, or ARM template to create the namespace, as they return only an endpoint for the namespace.  Previously, callers were responsible for parsing the endpoint and extracting the host name for use with the processor.

- In the rare case that an event processor's load balancing and health monitoring task cannot recover from an error, the processor now signals the error handler with a wrapped exception that makes clear that processing will terminate.  Previously, the source exception was surfaced to the error handler and the impact was not clear.

## 5.10.0 (2023-11-08)

### Breaking Changes

- Change `ActivitySource` name used to report message activity from `Azure.Messaging.EventHubs.EventHubs` to `Azure.Messaging.EventHubs.Message`
  and message `Activity` name from `EventHubs.Message` to `Message`.
- Updated tracing attributes names to conform to OpenTelemetry semantic conventions version 1.23.0.

### Bugs Fixed

- Fixed a parameter type mismatch in ETW #7 (ReceiveComplete) which caused the duration argument of the operation to be interpreted as a Unicode string and fail to render properly in the formatted message.

### Other Changes

- When an Event Hub is disabled, it will now be detected and result in a terminal `EventHubsException` with its reason set to `FailureReason.ResourceNotFound`.

## 5.9.3 (2023-09-12)

### Other Changes

- Several improvements to logging have been made to capture additional context and fix typos.  Most notable among them is the inclusion of starting and ending sequence numbers when events are read from Event Hubs and dispatched for processing.

- The reference for the AMQP transport library, `Microsoft.Azure.Amqp`, has been bumped to 2.6.3.  This fixes an issue with timeout duration calculations during link creation and includes several efficiency improvements.

## 5.9.2 (2023-06-06)

### Other Changes

- The reference for the AMQP transport library, `Microsoft.Azure.Amqp`, has been bumped to 2.6.2.  This resolves a potential issue opening TLS connections on .NET 6+.

## 5.9.1 (2023-05-09)

### Bugs Fixed

- Removed the 30 second cap applied when opening AMQP links; this allows developers to fully control the timeout for service operations by tuning the `TryTimeout` as appropriate for the application.

## 5.9.0 (2023-04-11)

### Bugs Fixed

- Changed the approach that the event processor uses to validate permissions on startup to ensure that it does not interrupt other processors already running by temporarily asserting ownership of a partition.

### Other Changes

- Enhanced the log emitted when an event processor begins reading from a partition to report whether the offset chosen was based on a checkpoint or default value.

## 5.8.1 (2023-03-09)

### Bugs Fixed

- Fix null reference exception when using the `EventProcessorClient`.

## 5.8.0 (2023-03-07)

### Features Added

- `ActivitySource` activities that are used when using the [experimental OpenTelemetry support](https://devblogs.microsoft.com/azure-sdk/introducing-experimental-opentelemetry-support-in-the-azure-sdk-for-net/) will include the `az.schema_url` tag indicating the OpenTelemetry schema version. They will also include the messaging attribute specified [here](https://github.com/Azure/azure-sdk/blob/main/docs/tracing/distributed-tracing-conventions.yml#L98).

### Bugs Fixed

- Corrected log message issue causing formatting to fail when developer code for processing events leaks an exception.  This obscured the warning that was intended to be emitted to the error handler.

### Other Changes

- Calling `ToString` on an `EventHubsException` now includes details of any inner exception.

## 5.7.5 (2022-11-22)

### Bugs Fixed

- Corrected an indexing issue with the log event source, causing an exception to surface in some publishing scenarios.

## 5.7.4 (2022-11-08)

### Bugs Fixed

- Telemetry will now use a parent activity instead of links when the event processor is configured to use a `CacheEventCount` of 1.

- The reference for the AMQP transport library, `Microsoft.Azure.Amqp`, has been bumped to 2.5.12. This resolves a rare race condition encountered when creating an AMQP link that could cause the link to hang.

### Other Changes

- Adjusted the frequency that a warning is logged when the processor owns more partitions than a basic heuristic believes is ideal.  Warnings will no longer log on each load balancing cycle, only when the number of partitions owned changes.

- Added timing information to logs for AMQP publish and read operations.

## 5.7.3 (2022-10-11)

### Other Changes

- Added additional heuristics for the `EventProcessorClient` configuration to help discover issues that can impact processor performance and stability; these validations will produce warnings at processor start-up should potential concerns be found.

- Exception messages have been updated to include a link to the Event Hubs troubleshooting guide.

## 5.7.2 (2022-08-09)

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Daniel Marbach _([GitHub](https://github.com/danielmarbach))_

### Other Changes

- Miscellaneous performance improvements by reducing memory allocations. _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_

## 5.7.1 (2022-07-07)

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Chad Vidovcich _([GitHub](https://github.com/chadvidovcich))_

### Features Added

- The event processor error handler will now raise warning when an unhandled exception propagated from the event processing handler causing partition processing to fault and restart.

### Bugs Fixed

- Fixed an issue with event processor startup validation where an invalid consumer group was not properly detected.

### Other Changes

- `EventProcessorClient` and `BlobCheckpointStore` will now detect when an ownership blob has been deleted externally while the processor is running and gracefully recover.

- Samples now each have a table of contents to help discover and navigate to the topics discussed for a scenario. _(A community contribution, courtesy of [chadvidovcich](https://github.com/chadvidovcich))_

## 5.7.0 (2022-05-10)

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Daniel Marbach _([GitHub](https://github.com/danielmarbach))_

### Features Added

- The `BlobCheckpointStore` implementation used internally by the processor has been made public and now conforms to the `CheckpointStore` contract, allowing it to be used with custom processor implementations.

### Other Changes

- Based on a new series of profiling and testing in real-world application scenarios, the default values for processor load balancing are being updated to provide better performance and stability.  The default load balancing interval was changed from 10 seconds to 30 seconds.  The default ownership expiration interval was changed from 30 seconds to 2 minutes.  The default load balancing strategy has been changed from balanced to greedy.

- Added additional heuristics for the `EventProcessorClient` load balancing cycle to help discover issues that can impact processor performance and stability; these validations will produce warnings should potential concerns be found.

- `EventProcessorClient` will now log a verbose message indicating what event position was chosen to read from when initializing a partition.

- Removed allocations from Event Source logging by introducing `WriteEvent` overloads to handle cases that would otherwise result in boxing to `object[]` via params array.  _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_

- Enhanced documentation to call attention to the need for the Azure Storage container used with the processor to exist, and highlight that it will not be implicitly created.

## 5.7.0-beta.5 (2022-04-05)

### Features Added

- The `BlobCheckpointStore` implementation used internally by the processor has been made public and now conforms to the `CheckpointStore` contract, allowing it to be used with custom processor implementations.

## 5.7.0-beta.4 (2022-03-11)

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Daniel Marbach _([GitHub](https://github.com/danielmarbach))_

### Other Changes

- Removed allocations from Event Source logging by introducing `WriteEvent` overloads to handle cases that would otherwise result in boxing to `object[]` via params array.  _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_

- Enhanced README documentation to call attention to the need for the Azure Storage container used with the processor to exist, and highlight that it will not be implicitly created.

## 5.7.0-beta.3 (2022-02-09)

### Features Added

- Added `FullyQualifiedNamespace`, `EventHubName`, and `ConsumerGroup` to the partition context associated with events dispatched for processing.

## 5.7.0-beta.2 (2022-01-13)

### Other Changes

- Based on a new series of profiling and testing in real-world application scenarios, the default values for processor load balancing are being updated to provide better performance and stability.  The default load balancing interval was changed from 10 seconds to 30 seconds.  The default ownership expiration interval was changed from 30 seconds to 2 minutes.  The default load balancing strategy has been changed from balanced to greedy.

## 5.7.0-beta.1 (2021-11-09)

### Other Changes

- Added additional heuristics for the `EventProcessorClient` load balancing cycle to help discover issues that can impact processor performance and stability; these validations will produce warnings should potential concerns be found.

- `EventProcessorClient` will now log a verbose message indicating what event position was chosen to read from when initializing a partition.

## 5.6.2 (2021-10-05)

### Bugs Fixed

- Dependencies have been updated to resolve an error when creating `EventSource` instances when used with Xamarin.

## 5.6.1 (2021-09-08)

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Andrey Shihov _([GitHub](https://github.com/andreyshihov))_

### Bugs Fixed

- Fixed an issue with refreshing authorization where redundant requests were made to acquire AAD tokens that were due to expire.  Refreshes will now coordinate to ensure a single AAD token acquisition.

- Fixed an issue with authorization refresh where attempts may have been made to authorize a faulted link.  Links that fail to open are no longer be considered valid for authorization.

### Other Changes

- Documentation has been enhanced to provide additional context for client library types, notably detailing non-obvious validations applied to parameters and options members.

## 5.6.0 (2021-08-10)

### Bugs Fixed

- Fixed an issue where partition processing would ignore cancellation when the processor was shutting down or partition ownership changed and continue dispatching events to the handler until the entire batch was complete.  Cancellation will now be properly respected.

### Other Changes

- Added the ability to adjust the connection idle timeout using the `EventHubConnectionOptions` available within the options for each client type.

## 5.5.0 (2021-07-07)

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Daniel Marbach _([GitHub](https://github.com/danielmarbach))_

### Changes

#### Features Added

-  When stopping, the `EventProcessorClient` will now attempt to force-close the connection to the Event Hubs service to abort in-process read operations blocked on their timeout.  This should significantly help reduce the amount of time the processor takes to stop in many scenarios. _(Based on a community prototype contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_

- When the `EventProcessorClient` detects a partition being stolen outside of a load balancing cycle, it will immediately surrender ownership rather than waiting for a load balancing cycle to confirm the ownership change.  This will help reduce event duplication from overlapping ownership of processors.

- The `ConnectionOptions` available when creating a processor now support registering a callback delegate for participating in the validation of SSL certificates when connections are established.  This delegate may override the built-in validation and allow or deny certificates based on application-specific logic.

- The `ConnectionOptions` available when creating a processor now support setting a custom size for the send and receive buffers of the transport.

#### Key Bugs Fixed

- The `EventProcessorClient` will now properly respect another another consumer stealing ownership of a partition when the service forcibly terminates the active link in the background.  Previously, the client did not observe the error directly and attempted to recover the faulted link which reasserted ownership and caused the partition to "bounce" between owners until a load balancing cycle completed.

- The  `EventProcessorClient` will now be less aggressive when considering whether or not to steal a partition, doing so only when it will correct an imbalance and preferring the status quo when the overall distribution would not change.  This will help reduce event duplication due to partitions moving between owners.

## 5.5.0-beta.1 (2021-06-08)

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Daniel Marbach _([GitHub](https://github.com/danielmarbach))_

### Changes

#### Features Added

-  When stopping, the `EventProcessorClient` will now attempt to force-close the connection to the Event Hubs service to abort in-process read operations blocked on their timeout.  This should significantly help reduce the amount of time the processor takes to stop in many scenarios. _(Based on a community prototype contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_

- When the `EventProcessorClient` detects a partition being stolen outside of a load balancing cycle, it will immediately surrender ownership rather than waiting for a load balancing cycle to confirm the ownership change.  This will help reduce event duplication from overlapping ownership of processors.

- The `ConnectionOptions` available when creating a processor now support registering a callback delegate for participating in the validation of SSL certificates when connections are established.  This delegate may override the built-in validation and allow or deny certificates based on application-specific logic.

- The `ConnectionOptions` available when creating a processor now support setting a custom size for the send and receive buffers of the transport.

#### Key Bugs Fixed

- The `EventProcessorClient` will now properly respect another another consumer stealing ownership of a partition when the service forcibly terminates the active link in the background.  Previously, the client did not observe the error directly and attempted to recover the faulted link which reasserted ownership and caused the partition to "bounce" between owners until a load balancing cycle completed.

- The  `EventProcessorClient` will now be less aggressive when considering whether or not to steal a partition, doing so only when it will correct an imbalance and preferring the status quo when the overall distribution would not change.  This will help reduce event duplication due to partitions moving between owners.

## 5.4.1 (2021-05-11)

### Changes

#### Features Added

- The processor will now perform validation of core configuration and permissions at startup, in order to attempt to detect unrecoverable problems more deterministically.  Validation is non-blocking and will not delay claiming of partitions.  One important note is that validation should be considered point-in-time and best effort; it is not meant to replace monitoring of error handler activity.

- Partition initialization has been moved to a background operation.  This will allow partitions to be more efficiently managed and speed up ownership claims, especially when using the `LoadBalancingStrategy.Greedy` configuration or when the processor is recovering from some error conditions.

#### Key Bugs Fixed

- Dependencies have been updated to resolve security warnings for CVE-2021-26701. _(The Event Hubs client library does not make use of the vulnerable components, directly or indirectly)_

- The processor will no longer inappropriately determine that it should attempt to steal partitions from itself or when the load is balanced but there is an uneven ownership distribution.  Previously, stealing was attempted but no candidates were found, leading to log spam but no interruption in processing.

## 5.4.0 (2021-04-05)

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Daniel Marbach _([GitHub](https://github.com/danielmarbach))_

### Changes

#### Features Added

- The `EventProcessorClient` now supports shared key and shared access signature authentication using the `AzureNamedKeyCredential` and `AzureSasCredential` types in addition to the connection string.  Use of the credential allows the shared key or SAS to be updated without the need to create a new processor.

- Multiple enhancements were made to the AMQP transport paths for reading events to reduce memory allocations and increase performance.  _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_

#### Key Bugs Fixed

- The AMQP library used for transport has been updated, fixing several issues including a potential unobserved   `ObjectDisposedException` that could cause the host process to crash.  _(see: [release notes](https://github.com/Azure/azure-amqp/releases/tag/v2.4.13))_

## 5.4.0-beta.1 (2021-03-17)

### Changes

- Updating package bindings for `Azure.Messaging.EventHubs` to synchronize on v5.4.0-beta.1.

## 5.3.1 (2021-03-09)

### Changes

#### Key Bugs Fixed

- Fixed an issue where long-lived credentials (more than 49 days) were overflowing refresh timer limits and being rejected.

- Added detection and recovery for a race condition that occurred when the Event Hubs service closed a connection or link after the client had validated its state and was performing an operation; this will now be properly retried with a fresh connection/link.

- Extended retry scenarios to include generic I/O exceptions, as they are typically transient network failures.

- Extended retry scenarios to include authorization failures, as the Event Hubs services do not differentiate between authentication and authorization, callers cannot reason about whether an `Unauthorized` return from an operation indicates that the call will never succeed or may trigger a credential renewal that may allow success.

## 5.3.0 (2021-02-09)

### Changes

#### Features Added

- Additional options for tuning load balancing have been added to the `EventProcessorClientOptions`.

- It is now possible to specify a custom endpoint to use for establishing the connection to the Event Hubs service in the `EventHubConnectionOptions` for the processor.

- Interactions with Blob Storage have been tuned for better performance and more efficient resource use.  This will also improve start-up time, especially when using the `Greedy` load balancing strategy.

- Errors occurring in the Event Hubs service or active transport are now preserved in full and propagated as an inner exception; this will provide deeper context for diagnosing and troubleshooting exceptions.

- Documentation used for auto-completion via Intellisense and other tools has been enhanced in many areas, addressing gaps and commonly asked questions.

#### Key Bugs Fixed

- Upgraded the `Microsoft.Azure.Amqp` library to resolve crashes occurring in .NET 5.

- The calculation for authorization token expiration has been fixed, resulting in fewer token refreshes and network requests.

## 5.3.0-beta.4 (2020-11-10)

### Changes

#### Features Added

- Additional options for tuning load balancing have been added to the `EventProcessorClientOptions`.

- Documentation used for auto-completion via Intellisense and other tools has been enhanced in many areas, addressing gaps and commonly asked questions.

#### Key Bugs Fixed

- Upgraded the `Microsoft.Azure.Amqp` library to resolve crashes occurring in .NET 5.

- The calculation for authorization token expiration has been fixed, resulting in fewer token refreshes and network requests.

## 5.3.0-beta.3 (2020-09-30)

### Changes

#### Key Bugs Fixed

- An issue with package publishing which blocked referencing and use has been fixed.

## 5.3.0-beta.2 (2020-09-28)

### Changes

#### Features Added

- The `EventData` representation has been extended with the ability to treat the `Body` as `BinaryData`.  `BinaryData` supports a variety of data transformations and allows the ability to provide serialization logic when sending or receiving events.  Any type that derives from `ObjectSerializer`, such as `JsonObjectSerializer` can be used, with Schema Registry support available via the `SchemaRegistryAvroObjectSerializer`.

- `EventData` has been integrated with the new Schema Registry service, via use of the `ObjectSerializer` with `BinaryData`.

**Note:** Azure Schema Registry is a new hosted schema repository service provided by Azure Event Hubs, and may not yet be available in all regions or Azure clouds.

## 5.3.0-beta.1 (2020-09-15)

### Changes

#### Features Added

- Introduction of an option for the various event consumers allowing the prefetch cache to be filled based on a size-based heuristic rather than a count of events.  This feature is considered a special case, helpful in scenarios where the size of events being read is not able to be known or predicted upfront and limiting resource use is valued over consistent and predictable performance.

## 5.2.0 (2020-09-08)

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Daniel Marbach _([GitHub](https://github.com/danielmarbach))_

### Changes

#### Key Bugs Fixed

- The approach used for creation of checkpoints has been updated to interact with Azure Blob storage more efficiently.  This will yield major performance improvements when soft delete was enabled and minor improvements otherwise.

- The `EventProcessorClient` will now perform an eager validation of connection strings upon creation.  Previously, validation was deferred until a partition was claimed which made debugging difficult.

- Fixed an issue where failure to create an AMQP link would lead to an AMQP session not being explicitly closed, causing connections to the Event Hubs service to remain open until a garbage collection pass was performed.

#### Features Added

- Load balancing will now detect when it has reached a balanced state more accurately; this will allow it to operate more efficiently when `LoadBalancingStrategy.Greedy` is in use.

- The `EventProcessorClient` now supports a configurable strategy for load balancing, allowing control over whether it claims ownership of partitions in a balanced manner _(default)_ or more aggressively.  The strategy may be set in the `EventProcessorClientOptions` when creating the processor.  More details about strategies can be found in the associated [documentation](https://learn.microsoft.com/dotnet/api/azure.messaging.eventhubs.processor.loadbalancingstrategy?view=azure-dotnet).

- The `EventProcessorClientOptions` now support setting a `PrefetchCount` and `CacheEventCount` for performance tuning.  More details about each can be found in the associated [documentation](https://learn.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventprocessorclientoptions?view=azure-dotnet).

- Connection strings for each of the clients now supports a `SharedAccessSignature` token, allowing a pre-generated SAS to be used for authorization.

- Load balancing now has better recognition for being in a recovery state and will aggressively reclaim partitions for which it is the recognized owner, regardless of whether the current instance made the ownership claim.  Previously, those partitions were redistributed on a 1-by-1 basis as part of the standard cycle.

## 5.2.0-preview.3 (2020-08-18)

### Fixed
- Bug in TaskExtensions.EnsureCompleted method that causes it to unconditionally throw an exception in the environments with synchronization context

## 5.2.0-preview.2 (2020-08-10)

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Daniel Marbach _([GitHub](https://github.com/danielmarbach))_

### Changes

#### Processing events

- Load balancing will now detect when it has reached a balanced state more accurately; this will allow it to operate more efficiently when `LoadBalancingStrategy.Greedy` is in use.

- The approach used for creation of checkpoints has been updated to interact with Azure Blob storage more efficiently.  This will yield major performance improvements when soft delete was enabled and minor improvements otherwise.

- Load balancing now has better recognition for being in a recovery state and will aggressively reclaim partitions for which it is the recognized owner, regardless of whether the current instance made the ownership claim.  Previously, those partitions were redistributed on a 1-by-1 basis as part of the standard cycle.

#### Bug fixes and foundation

- The underlying AMQP library has been enhanced for more efficient resource usage, particularly when no events are available; this will result in a noticeable reduction in memory use.  (A community contribution, courtesy of _[danielmarbach](https://github.com/danielmarbach))_

- The `EventProcessorClient` will now perform an eager validation of connection strings upon creation.  Previously, validation was deferred until a partition was claimed which made debugging difficult.

- Fixed an issue where failure to create an AMQP link would lead to an AMQP session not being explicitly closed, causing connections to the Event Hubs service to remain open until a garbage collection pass was performed.

## 5.2.0-preview.1 (2020-07-06)

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Daniel Marbach _([GitHub](https://github.com/danielmarbach))_

### Changes

#### Processing events

- The `EventProcessorClient` now supports a configurable strategy for load balancing, allowing control over whether it claims ownership of partitions in a balanced manner _(default)_ or more aggressively.  The strategy may be set in the `EventProcessorClientOptions` when creating the processor.  More details about strategies can be found in the associated [documentation](https://learn.microsoft.com/dotnet/api/azure.messaging.eventhubs.processor.loadbalancingstrategy?view=azure-dotnet).

- The `EventProcessorClientOptions` now support setting a `PrefetchCount` and `CacheEventCount` for performance tuning.  More details about each can be found in the associated [documentation](https://learn.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventprocessorclientoptions?view=azure-dotnet).

#### Bug fixes and foundation

- Surfacing of exceptions has been fixed to consistently preserve the stack trace in cases where it was previously lost.  (A community contribution, courtesy of _(danielmarbach](https://github.com/danielmarbach))_

- A cleanup sweep was performed to tune small areas to be more efficient and perform fewer allocations.

## 5.1.0

### Changes

#### General availability of preview features

- The set of features from v5.1.0-preview.1 are now generally available.  This includes the `EventProcessor<TPartition>` and `PartitionReceiver` types which focus on advanced application scenarios which require greater low-level control.

#### Bug fixes and foundation

- Minor enhancements to reduce allocations and improve efficiency

## 5.1.0-preview.1

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Christopher Scott _([GitHub](https://github.com/christothes))_
- Roman Marusyk _([GitHub](https://github.com/marusyk))_

#### Consuming events

- The `EventProcessorClient` has been enhanced to derive from the new `EventProcessor<TPartition>` primitive, bringing improvements to stability, resilience, and performance.

#### Publishing events

- Event batches are now protected against modification while publishing is actively taking place.

#### Bug fixes and foundation

- Validation for the Event Hubs fully qualified namespace has been improved, allowing for more deterministic failures when creating clients.

- Exceptions surfaced will now properly remember their context in all scenarios; previously, some deferred cases unintentionally reset the context.

- Logging for the Storage Manager for Azure Blobs now follows the common pattern for other Event Hubs types, as well as providing additional context and information.

- The diagnostic scope for activities will now complete in a more deterministic manner.  (A community contribution, courtesy of [christothes](https://github.com/christothes))

- Diagnostic activities have been extended with additional information about events being processed and with additional environmental context.

- Parsing of connection strings is now more permissive for the `Endpoint` key, allowing additional formats that result from common mistakes when building the string rather than copying the value from the portal.

- The partition manager has been renamed to `StorageManager` to better represent its purpose.  (A community contribution, courtesy of [marusyk](https://github.com/marusyk))

#### Testing

- The tests for load balancing and the Event Processor client have been tuned to remove dependencies on Azure resources and run more efficiently.  (A community contribution, courtesy of [christothes](https://github.com/christothes))

## 5.0.1

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Christopher Scott _([GitHub](https://github.com/christothes))_

### Changes

#### General

- A migration guide is now available for those moving from the 4.x version of the `Microsoft.Azure.EventHubs` libraries to the 5.0.1 version under the `Azure.Messaging.EventHubs` namespace.

#### Organization and naming

- Namespaces have been reorganized to align types to their functional area, reducing the number of types in the root namespace and offering better context for where a type is used.  Cross-functional types have been left in the root while specialized types were moved to the `Producer`, `Consumer`, or `Processor` namespaces.

#### Event processing

- Load balancing has been tuned for better performance and lower resource use.  (A community contribution, courtesy of [christothes](https://github.com/christothes))

- Reduction of reliance on Azure resources for Event Processor tests.  (A community contribution, courtesy of [christothes](https://github.com/christothes))

- Logging has been implemented for Event Processor operations interacting with storage. (A community contribution, courtesy of [christothes](https://github.com/christothes))

- Logging has been implemented for general Event Processing operations, including background execution.

- A bug with resuming from a storage checkpoint was fixed, ensuring that processing resumes from the next available event rather than reprocessing the event from which the checkpoint was created.

- The protected `On[EventName]` members have been marked private to reduce the public surface and reduce confusion.  They provided no benefit over providing a handler and the cognative cost was not justified.

## 5.0.0-preview.6

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Christopher Scott _([GitHub](https://github.com/christothes))_

### Changes

#### Organization and naming

- This version is a reorganization of the Event Hubs client library packages, moving the `EventProcessorClient` into its own package and evolving this version into an opinionated implementation on top of Azure Storage Blobs.  This is intended to offer a more streamlined developer experience for the majority of scenarios and allow developers to more easily take advantage of the processor.

- A large portion of the public API surface, including members and parameters, have had adjustments to their naming in order to improve discoverability, provide better context to developers, and better conform to the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html).

#### Event processing

- The API for the `EventProcessorClient` has been revised, adopting an event-driven model that aligns to many of the .NET base class library types and reduces complexity when constructing the client.

- The handlers for event processing will now process events on an individual basis, allowing developers to control whether or not they wish to handle events as they're available or batch events before processing.

- The mechanism for creating checkpoints has been bundled with the event dispatched for processing; this allows a checkpoint to be created with a clear association with a given event, removing the need for developers to explicitly pass an event to a dedicated checkpoint manager.

#### Storage operations

- The concept of a plug-in model for the durable storage used by the processor has been removed; this package has taken a strong dependency on Azure Storage Blobs and no longer requires developers to manipulate an abstraction on top of storage.

- Checkpoints are now ensuring case-insensitivity for metadata to guard against inadvertent creation of multiple checkpoints for the same Event Hub / Consumer Group / Partition combination due to mixed casing.

#### General

- Removed the concept of explicitly closing or disposing the processor; the lifespan of resources is now managed implicitly within the scope of starting and stopping the processor.

- Synchronous members have been added for starting and stopping the event processor.
