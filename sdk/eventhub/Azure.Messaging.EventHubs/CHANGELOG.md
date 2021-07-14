# Release History

## 5.6.0-beta.1 (Unreleased)

### Features Added

- Each Event Hubs client type now offers an option to set an Identifier. The identifier is informational and is associated with the AMQP links used, allowing the service to provide additional context in error messages and the SDK logs to provide an additional point of correlation.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 5.5.0 (2021-07-07)

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Daniel Marbach _([GitHub](https://github.com/danielmarbach))_

### Changes

#### Features Added

- The `EventData` type offers a curated set of the information available for messages using the AMQP protocol.  While this results in a simpler and more easily understood API surface for an event, it limits interoperability with other message brokers.  To support heterogeneous environments or those with specialized needs, the full AMQP message is now available using the `GetRawAmqpMessage` method.  _(Based on a community prototype contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_

- `EventData` now supports construction using a `string` to specify the event body; this will be represented as a set of UTF-8 encoded bytes for transport.

- `EventData` has been extended to include properties for applications to assign a `MessageId`, `ContentType`, and `CorrelationId` as well-known members rather than embedding them in the `Properties` dictionary.  It is important to note that these properties are intended for application use and are not recognized by the Event Hubs service.

-  When stopping, the `EventProcessor<TPartition>` will now attempt to force-close the connection to the Event Hubs service to abort in-process read operations blocked on their timeout.  This should significantly help reduce the amount of time the processor takes to stop in many scenarios. _(Based on a community prototype contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_

- When the `EventProcessor<TPartition>` detects a partition being stolen outside of a load balancing cycle, it will immediately surrender ownership rather than waiting for a load balancing cycle to confirm the ownership change.  This will help reduce event duplication from overlapping ownership of processors.

- The `EventProcessor<TPartition>` now exposes the `ListPartitionIdsAsync` method, allowing custom processors to control the set of partitions known to the processor.  This can be used to reduce complexity when a custom processor is directly assigned a set of partitions to process rather than using load balancing to control ownership.

- The `ConnectionOptions` available when creating client types now support registering a callback delegate for participating in the validation of SSL certificates when connections are established.  This delegate may override the built-in validation and allow or deny certificates based on application-specific logic.

- The `ConnectionOptions` available when creating client types now support setting a custom size for the send and receive buffers of the transport.

- Additional verbose logging has been added to allow monitoring of lower-level AMQP operations such as creating links, terminal exceptions that fault a link without an active operation, and when the service force-closes links.

#### Key Bugs Fixed

- The `EventProcessor<TPartition>` will now properly respect another another consumer stealing ownership of a partition when the service forcibly terminates the active link in the background.  Previously, the client did not observe the error directly and attempted to recover the faulted link which reasserted ownership and caused the partition to "bounce" between owners until a load balancing cycle completed.

- The `EventProcessor<TPartition>` will now be less aggressive when considering whether or not to steal a partition, doing so only when it will correct an imbalance and preferring the status quo when the overall distribution would not change.  This will help reduce event duplication due to partitions moving between owners.

- The `EventHubConsumerClient` and `PartitionReceiver` will now properly surface an exception when another another consumer stealing ownership of a partition when the service forcibly terminates the active link in the background.  Previously, the client did not observe the error directly and did not make callers attempted to recover the faulted link which reasserted ownership and caused the partition to "bounce" between owners until a load balancing cycle completed.

- The retry policy used by clients will no longer overflow the `TimeSpan` maximum when using an `Exponential` strategy with a large number of retries and long delay set.

## 5.5.0-beta.1 (2021-06-08)

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Daniel Marbach _([GitHub](https://github.com/danielmarbach))_

### Changes

#### Features Added

-  When stopping, the `EventProcessor<TPartition>` will now attempt to force-close the connection to the Event Hubs service to abort in-process read operations blocked on their timeout.  This should significantly help reduce the amount of time the processor takes to stop in many scenarios. _(Based on a community prototype contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_

- When the `EventProcessor<TPartition>` detects a partition being stolen outside of a load balancing cycle, it will immediately surrender ownership rather than waiting for a load balancing cycle to confirm the ownership change.  This will help reduce event duplication from overlapping ownership of processors.

- The `EventProcessor<TPartition>` now exposes the `ListPartitionIdsAsync` method, allowing custom processors to control the set of partitions known to the processor.  This can be used to reduce complexity when a custom processor is directly assigned a set of partitions to process rather than using load balancing to control ownership.

- The `ConnectionOptions` available when creating client types now support registering a callback delegate for participating in the validation of SSL certificates when connections are established.  This delegate may override the built-in validation and allow or deny certificates based on application-specific logic.

- The `ConnectionOptions` available when creating client types now support setting a custom size for the send and receive buffers of the transport.

- Additional verbose logging has been added to allow monitoring of lower-level AMQP operations such as creating links, terminal exceptions that fault a link without an active operation, and when the service force-closes links.

#### Key Bugs Fixed

- The `EventProcessor<TPartition>` will now properly respect another another consumer stealing ownership of a partition when the service forcibly terminates the active link in the background.  Previously, the client did not observe the error directly and attempted to recover the faulted link which reasserted ownership and caused the partition to "bounce" between owners until a load balancing cycle completed.

- The `EventProcessor<TPartition>` will now be less aggressive when considering whether or not to steal a partition, doing so only when it will correct an imbalance and preferring the status quo when the overall distribution would not change.  This will help reduce event duplication due to partitions moving between owners.

- The `EventHubConsumerClient` and `PartitionReceiver` will now properly surface an exception when another another consumer stealing ownership of a partition when the service forcibly terminates the active link in the background.  Previously, the client did not observe the error directly and did not make callers attempted to recover the faulted link which reasserted ownership and caused the partition to "bounce" between owners until a load balancing cycle completed.

- The retry policy used by clients will no longer overflow the `TimeSpan` maximum when using an `Exponential` strategy with a large number of retries and long delay set.

## 5.4.1 (2021-05-11)

### Changes

#### Features Added

- `EventProcessor<TPartition>` will now perform validation of core configuration and permissions at startup, in order to attempt to detect unrecoverable problems more deterministically.  Validation is non-blocking and will not delay claiming of partitions.  One important note is that validation should be considered point-in-time and best effort; it is not meant to replace monitoring of error handler activity.

- Partition initialization for `EventProcessor<TPartition>` has been moved to a background operation.  This will allow partitions to be more efficiently managed and speed up ownership claims, especially when using the `LoadBalancingStrategy.Greedy` configuration or when the processor is recovering from some error conditions.

#### Key Bugs Fixed

- Dependencies have been updated to resolve security warnings for CVE-2021-26701. _(The Event Hubs client library does not make use of the vulnerable components, directly or indirectly)_

- Event Hubs client types will now consider some additional exception types as transient when they occur in the context of opening an AMQP connection or link; this allows the client to attempt recovery by discarding the faulted connection and attempting to create a new one.

- Event Hubs client types will now react more deterministically when a shared connection was closed while still in use.  Previously, the exception surfaced varied based on internal state.  Now, an `EventHubsException` with `FailureReason.ClientClosed` and an appropriate message will be thrown.

- `EventProcessor<TPartition>` will no longer inappropriately determine that it should attempt to steal partitions from itself or when the load is balanced but there is an uneven ownership distribution.  Previously, stealing was attempted but no candidates were found, leading to log spam but no interruption in processing.

## 5.4.0 (2021-04-05)

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Daniel Marbach _([GitHub](https://github.com/danielmarbach))_

### Changes

#### Features Added

- The Event Hubs clients now support shared key and shared access signature authentication using the `AzureNamedKeyCredential` and `AzureSasCredential` types in addition to the connection string.  Use of the credential allows the shared key or SAS to be updated without the need to create a new Event Hubs client.

- The `Properties` collection used by `EventData` is now lazily allocated, avoiding memory bloat when not used.

- The `SystemProperties` collection used by `EventData` will not use a shared empty set for events that have not been read from the Event Hubs service, reducing memory allocation.

- Multiple enhancements were made to the transport paths for publishing and reading events to reduce memory allocations and increase performance.  _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_

#### Key Bugs Fixed

- The AMQP library used for transport has been updated, fixing several issues including a potential unobserved   `ObjectDisposedException` that could cause the host process to crash.  _(see: [release notes](https://github.com/Azure/azure-amqp/releases/tag/v2.4.13))_

## 5.4.0-beta.1 (2021-03-17)

### Changes

#### Features Added

- Returned the idempotent publishing feature to the public API surface.

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

- Connection strings can now be parsed into their key/value pairs using the `EventHubsConnectionStringProperties` class.

- The body of an event has been moved to the `EventData.EventBody` property and makes use of the new `BinaryData` type.  To preserve backwards compatibility, the existing `EventData.Body` property has been preserved with the current semantics.

- It is now possible to specify a custom endpoint to use for establishing the connection to the Event Hubs service in the `EventHubConnectionOptions` used by each of the clients.

- Errors occurring in the Event Hubs service or active transport are now preserved in full and propagated as an inner exception; this will provide deeper context for diagnosing and troubleshooting exceptions.

- The `EventHubsModelFactory` has been introduced to provide a single point for creation of Event Hubs model types to assist with mocking and testing.

- Documentation used for auto-completion via Intellisense and other tools has been enhanced in many areas, addressing gaps and commonly asked questions.

#### Key Bugs Fixed

- Upgraded the `Microsoft.Azure.Amqp` library to resolve crashes occurring in .NET 5.

- The `EventHubsException.ToString` result will now properly follow the format of other .NET exception output.

- Signaling the cancellation token will no longer cause the `SendAsync` method of the `EventHubProducerClient` to ignore the result of the service operation if publishing has already completed.

- The calculation for authorization token expiration has been fixed, resulting in fewer token refreshes and network requests.

## 5.3.0-beta.4 (2020-11-10)

### Changes

#### Features Added

- Connection strings can now be parsed into their key/value pairs using the `EventHubsConnectionStringProperties` class.

- The body of an event has been moved to the `EventData.EventBody` property and makes use of the new `BinaryData` type.  To preserve backwards compatibility, the existing `EventData.Body` property has been preserved with the current semantics.

- Documentation used for auto-completion via Intellisense and other tools has been enhanced in many areas, addressing gaps and commonly asked questions.

#### Key Bugs Fixed

- The `EventHubsException.ToString` result will now properly follow the format of other .NET exception output.

- Signaling the cancellation token will no longer cause the `SendAsync` method of the `EventHubProducerClient` to ignore the result of the service operation if publishing has already completed.

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

- When publishing events to Event Hubs, timeouts or other transient failures may introduce ambiguity into the understanding of whether a batch of events was received by the service.  To assist in this scenario, the option to publish events idempotently across all retries of a publish operation has been added to the `EventHubProducerClient`. 

**Note:** The idempotent publishing feature is new to the Event Hubs service, and Azure Schema Registry is a new hosted schema repository service provided by Azure Event Hubs.  Both offerings may not yet be available in all regions or Azure clouds.

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

- The underlying AMQP library has been enhanced for more efficient resource usage; this will result in a noticeable reduction in memory use in common consuming scenarios.  (A community contribution, courtesy of _[danielmarbach](https://github.com/danielmarbach))_

- All clients will now perform an eager validation of connection strings upon creation.  Previously, validation was performed just before a service operation in some scenarios which made debugging difficult.

- An additional level of resilience was added to some corner case scenarios where establishing an AMQP link failed with what may be a transient issue.

- Fixed an issue where failure to create an AMQP link would lead to an AMQP session not being explicitly closed, causing connections to the Event Hubs service to remain open until a garbage collection pass was performed.

#### Features Added

- The `EventProcessor<TPartition>` now supports a configurable strategy for load balancing, allowing control over whether it claims ownership of partitions in a balanced manner _(default)_ or more aggressively.  The strategy may be set in the `EventProcessorOptions` when creating the processor.  More details about strategies can be found in the associated [documentation](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.processor.loadbalancingstrategy?view=azure-dotnet).

- The `EventHubConsumerClient` pipeline for reading events from a single partition was reworked to improve efficiency and make use of the new configuration options for `PrefetchCount` and `CacheEventCount`.

- The `ReadEventOptions` used with the `EventHubConsumerClient` now support setting a `PrefetchCount` and `CacheEventCount` for performance tuning.  More details about each can be found in the associated [documentation](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.consumer.readeventoptions?view=azure-dotnet).

- Logging for the core send and receive operations against the Event Hubs service can now be correlated by an `OperationId` in the logs and detail the number of retries attempted for the operation.

- Connection strings for each of the clients now supports a `SharedAccessSignature` token, allowing a pre-generated SAS to be used for authorization.

## 5.2.0-preview.3 (2020-08-18)

### Fixed
- Bug in TaskExtensions.EnsureCompleted method that causes it to unconditionally throw an exception in the environments with synchronization context

## 5.2.0-preview.2 (2020-08-10)

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Daniel Marbach _([GitHub](https://github.com/danielmarbach))_

### Changes

#### Bug fixes and foundation

- The underlying AMQP library has been enhanced for more efficient resource usage; this will result in a noticeable reduction in memory use in common consuming scenarios.  (A community contribution, courtesy of _[danielmarbach](https://github.com/danielmarbach))_

- All clients will now perform an eager validation of connection strings upon creation.  Previously, validation was performed just before a service operation in some scenarios which made debugging difficult.

- Fixed an issue where failure to create an AMQP link would lead to an AMQP session not being explicitly closed, causing connections to the Event Hubs service to remain open until a garbage collection pass was performed.

## 5.2.0-preview.1 (2020-07-06)

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Daniel Marbach _([GitHub](https://github.com/danielmarbach))_

### Changes

#### Consuming events

- The `ReadEventOptions` used with the `EventHubConsumerClient` now support setting a `PrefetchCount` and `CacheEventCount` for performance tuning.  More details about each can be found in the associated [documentation](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.consumer.readeventoptions?view=azure-dotnet).

- The `EventHubConsumerClient` pipeline for reading events from a single partition was reworked to improve efficiency and make use of the new configuration options for `PrefetchCount` and `CacheEventCount`.

#### Processing events

- The `EventProcessor<TPartition>` now supports a configurable strategy for load balancing, allowing control over whether it claims ownership of partitions in a balanced manner _(default)_ or more aggressively.  The strategy may be set in the `EventProcessorOptions` when creating the processor.  More details about strategies can be found in the associated [documentation](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.processor.loadbalancingstrategy?view=azure-dotnet).

- The `EventProcessorClientOptions` now support setting a `PrefetchCount` and `CacheEventCount` for performance tuning.  More details about each can be found in the associated [documentation](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventprocessorclientoptions?view=azure-dotnet).

#### Diagnostics

- Logging for the core send and receive operations against the Event Hubs service can now be correlated by an `OperationId` in the logs and detail the number of retries attempted for the operation.

#### Bug fixes and foundation

- Surfacing of exceptions has been fixed to consistently preserve the stack trace in cases where it was previously lost.  (A community contribution, courtesy of _[danielmarbach](https://github.com/danielmarbach))_

- An additional level of resilience was added to some corner case scenarios where establishing an AMQP link failed with what may be a transient issue.

- A cleanup sweep was performed to tune small areas to be more efficient and perform fewer allocations.

## 5.1.0 

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Alberto De Natale _([GitHub](https://github.com/albertodenatale))_
- Daniel Marbach _([GitHub](https://github.com/danielmarbach))_

### Changes

#### General availability of preview features

- The set of features from v5.1.0-preview.1 are now generally available.  This includes the `EventProcessor<TPartition>` and `PartitionReceiver` types which focus on advanced application scenarios which require greater low-level control. 

#### Publishing events

- A set of events may now be published without an explicit batch; a batched approach will be used when communicating with the Event Hubs service, with an implicit batch created on the sender's behalf.

#### Bug fixes and foundation

- The transport producers used for sending events to a specific partition are now managed by a pool with sliding expiration to enable more efficient resource use and cleanup.  _(A community contribution, courtesy of [albertodenatale](https://github.com/albertodenatale))_
	
- Timing operations have been refactored to make use of a more efficient approach with fewer allocations.  (A community contribution, courtesy of _[danielmarbach](https://github.com/albertodenatale))_

- Fixed a bug with EventDataBatch; it is now thread-safe.

- Minor enhancements to reduce allocations and improve efficiency

## 5.1.0-preview.1 

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Alberto De Natale _([GitHub](https://github.com/albertodenatale))_
- Christopher Scott _([GitHub](https://github.com/christothes))_

### Changes

#### Consuming events

- A new primitive, `EventProcessor<TPartition>`, has been implemented to serve as an extensibility point for creating a custom event processor instance.  It offers built-in fault tolerance, load balancing, and structure while allowing tuning for low-level network configuration, processing of events in batches, and customization for the storage of checkpoints.  More detail can be found in the [design proposal](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/design/proposal-event-processor%7BT%7D.md).

- A new primitive, `PartitionProcessor`, has been implemented to serve as a low-level means of reading batches of events from a single partition with greater control over network configuration.  More detail can be found in the [design proposal](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/design/proposal-partition-receiver.md).

#### Publishing events

- Event batches are now protected against modification while publishing is actively taking place.

#### Bug fixes and foundation

- Exceptions surfaced will now properly remember their context in all scenarios; previously, some deferred cases unintentionally reset the context.

- Validation for the Event Hubs fully qualified namespace has been improved, allowing for more deterministic failures when creating clients.

- The diagnostic scope for activities will now complete in a more deterministic manner.  (A community contribution, courtesy of [christothes](https://github.com/christothes))

- Diagnostic activities have been extended with additional information about events being processed and with additional environmental context.

- Parsing of connection strings is now more permissive for the `Endpoint` key, allowing additional formats that result from common mistakes when building the string rather than copying the value from the portal.

- `LastEnqueuedEventProperties` can now be compared for structural equality.

#### Testing

- For special cases, the live tests may be instructed to use existing Azure resources instead of dynamically creating dedicated resources for the run.  (A community contribution, courtesy of [albertodenatale](https://github.com/albertodenatale))

## 5.0.1 

### Acknowledgements

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Alberto De Natale _([GitHub](https://github.com/albertodenatale))_

### Changes

#### General

- A migration guide is now available for those moving from the 4.x version of the `Microsoft.Azure.EventHubs` libraries to the 5.0.1 version under the `Azure.Messaging.EventHubs` namespace.

- A bug was fixed that would intermittently cause a failure that caused retries to abort, potentially preventing recovery from transient failures.

- Several minor performance and efficiency improvements have been implemented.

#### Organization and naming

- Namespaces have been reorganized to align types to their functional area, reducing the number of types in the root namespace and offering better context for where a type is used.  Cross-functional types have been left in the root while specialized types were moved to the `Producer`, `Consumer`, or `Processor` namespaces.

- The hierarchy of custom exceptions has been flattened, with only the `EventHubsException` remaining.  The well-known failure scenarios that had previously been represented as stand-alone types are now exposed by a new `Reason` property to allow for applying exception filtering and other logic where inspecting the text of an exception message wouldn't be ideal. 

## 5.0.0-preview.6 

### Acknowledgements

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Alberto De Natale _([GitHub](https://github.com/albertodenatale))_

### Changes

#### Bug fixes and foundation

- A bug with the use of Azure.Identity credential scopes has been fixed; Azure identities should now allow for proper authorization with Event Hubs resources.   
_(A community contribution, courtesy of [albertodenatale](https://github.com/albertodenatale))_

- A bug with the renewal of connection string-based credentials has been fixed; clients using a connection string will now properly refresh when necessary instead of experiencing an error.

- Some performance tuning has been done, focusing on reducing allocations associated with frequently used types where possible.

#### Consuming events

- The `EventHubsConsumerClient` is no longer bound to a partition, an owner level, or tracking of last enqueued event properties; these attributes may be specified when requesting to read events, allowing more granular control over behavior without the need to create multiple clients.

- Events may now be read across all partitions of an Event Hub using the `ReadEvents` method of the consumer client.  This is intened for exploring Event Hubs and not recommended for production use; for production scenarios, please consider using the `EventProcessorClient` as a more robust alternative.

- Events read using the consumer client are now accompanied by a `PartitionContext` helping to identify the source partition for an event and allowing for partition-specific operations, such as reading the last enqueued event properties for that partition.

#### Publishing events

- The `EventHubsProducerClient` client is no longer bound to a partition for sending events to a specific partition.  It will now accept a partition identifier as part of the options when creating an event batch.  This option may not be used with a partition key in the same batch; only one or the other may be specified.  This allows for more flexibility when publishing events without the need to create multiple clients.

#### Authorization

- Test and sample infrastructure has been updated to work with Azure.Identity credentials in addition to connection strings.  
_(A community contribution, courtesy of [albertodenatale](https://github.com/albertodenatale))_
  
- A sample demonstrating the use of an Azure Active Identity principal with Event Hubs is now available.  
_(A community contribution, courtesy of [albertodenatale](https://github.com/albertodenatale))_

- The `EventHubsSharedKeyCredential` has been removed from this release for further design and improvements; it is intended to be reintroduced in the future.

#### Organization and naming

- A large portion of the public API surface, including members and parameters, have had adjustments to their naming in order to improve discoverability, provide better context to developers, and better conform to the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html).

- The `EventProcessorClient` has been moved into its own [package](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor) and evolved into an opinionated implementation on top of Azure Storage Blobs.  This is intended to offer a more streamlined developer experience for the majority of scenarios and allow developers to more easily take advantage of the processor.

- A collection of internal supporting types were moved into a new [shared library](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs.Shared) to allow them to be shared as source between the Event Hubs client libraries.  The tests assoociated with these types were also moved to the shared library for locality with the source being tested.

## 5.0.0-preview.5 

### Acknowledgments 

Thank you to our developer community members who helped to make the Azure SDKs better with their contributions to this release:

- Alberto De Natale _([GitHub](https://github.com/albertodenatale))_

### Changes

#### Organization and naming

- The early stages of a large refactoring of the Event Hub client type hierarchy is complete;  Event Hub producers and consumers are now stand-alone clients that can be created independently, and which may or may not share a connection to the Event Hubs service at the discretion of the developer.    

  **_Please Note:_** These changes are part of a larger effort that is currently in process.  The client types have not yet been refactored to remove affinity to a specific partition which leaves some operations feeling somewhat awkward with the new structure.
  
#### Bug fixes and foundation improvements

- Client types using Azure identity for authorization should now be working properly; a bug was fixed to allow the proper authorization scopes to be requested.  
  _(A community contribution, courtesy of [albertodenatale](https://github.com/albertodenatale))_
  
- Service communication is now being performed by an internal communication stack; previously, it had been delegated to an internal copy of the legacy client library.

- Cancellation tokens are now supported throughout the client hierarchy and across operations.

- Telemetry is now emitting a `User-Agent` member, which is standard across other client libraries in the Azure SDK.

- With the new hierarchy allowing clients to be more self-contained, the configuration of retry policies and timeouts have been made more consistent and easier to reason about.  Each may be configured as part of the options for a client and will retain either the value provided by developers or the default.  There is no longer a notion of inherited values from a "parent" client.

#### Consuming events

- The body of an `EventData` instance is now available as a stream, for convenience.

- The information about the last event enqueued to an Event Hub partition is now presented on-demand as an immutable object, if the tracking option was enabled.  This ensures that the properties are stable and consistent when being read, rather than being subject to in-place updates each time a new event is received.

## 5.0.0-preview.4 

### Changes

#### Event Processor

- Included the Event Hubs fully qualified namespace as part of the checkpoint information, ensuring that there is no conflict between Event Hubs instances in different regions using the same Event Hub and consumer group names.

- Distributed tracing support has been added to the Event Processor.

#### Bug fixes and foundation improvements

- Fixed date parsing for time zones ahead of UTC in the Event Hub Consumer when tracking of the last event was disabled.

- Updated dependencies to take advantage of newer client libraries for identity management, blob storage, and .NET Core improvements.

- Improved stability and performance with refactorings around hot paths and areas of technical debt.

## 5.0.0-preview.3 

### Changes

#### Consuming Events

- The full set of system properties was reintroduced to the `EventData` for events received from the service.  In addition to the well-known properties for identifying an event's place in the partition (`Offset`, `SequenceNumber`, and `EnqueuedTime`), any additional metadata sent as part of an event will appear in the `SystemProperties` dictionary.

- The `EventHubConsumer` can be configured to track information about the last event to be enqueued into its associated partition in order to allow for monitoring the backlog of events to be processed without the need to make explicit calls to request partition properties from the `EventHubClient`.

- Consuming events using `SubscribeToEvents` has been refactored for better performance and lower resource use. 

#### Event Processor

- Creation of an `EventProcessor` has been refined with the goal of allowing simpler use for standard scenarios while maintaining flexibility for complex ones.  The `EventProcessor` is now able to manage partition processor instances for implementations with a default constructor.

- The `EventProcessor` will now coordinate with other active `EventProcessor` instances for a given Event Hub and consumer group in order to share partitions and ensure that processing work is balanced between them.  `EventProcessor` instances may be activated or deactivated independently and the remaining processors will redistribute partitions as needed.

- The interface for processing partitions has been changed to a base class, in order to allow developers to make the decision which of the available methods they would like to override, rather than being forced to implement each one.

#### General

- The client library for Event Hubs is now emitting diagnostics information for distributed tracing.  _(see: [proposal](https://github.com/w3c/trace-context-amqp/blob/411fdeabea45d36db827b7097235549b30fac8e8/spec/20-AMQP_FORMAT.md))_

- Some public types were scoped in a way that made them difficult to mock for library consumers.  These have been re-scoped to `protected internal` for better testability.  `EventData` and metadata types were the significant instances.

## 5.0.0-preview.2 

### Changes

#### General

- Public members of type `DateTime` were converted to `DateTimeOffset` to explicitly represent that they are UTC

- Members of type `DateTimeOffset` have had the `Utc` suffix removed from their names, as the `DateTimeOffset` type removes ambiguity about the time zone

- Members representing a partition offset that were incorrectly exposed as `string` have been converted to `int` to provide a unified type.

- Renamed all instances of `EventHubPath` to `EventHubName` to align with the usage context and unify on the chosen semantics across the client library for different languages.

- Ongoing minor tweaks to formatting, wording, and spelling of documentation and XML document comments.

#### Publishing events

- Reintroduced the `EventDataBatch`, allowing for publication of a batch of events with known size constraint.  This is intended to ensure that publishers can build batches without the potential for an error when sending and to allow publishers with bandwidth concerns to control the size of each batch published.

- Enhanced the `EventHubProducer` to allow creation of an `EventDataBatch` and to accept them for publication.

#### Consuming events

- Added a means to subscribe to the events exposed by an `EventHubConsumer` in the form of an asynchronous iterator.   Using the iterator, consumers are able to use the familiar `foreach` pattern to enumerate events as they are available and process them.  Optionally, consumers may specify a maximum time to wait for events to arrive which, when exceeded, will emit a null event if none were available, returning control to the loop and allowing cancellation or other processing needs.

- Introduced the initial concept of a new version of the `EventProcessor`, intended as a neutral framework for processing events across all partitions for a given Event Hub and in the context of a specific Consumer Group.  This early preview is intended to allow consumers to test the new design using a single instance that does not persist checkpoints to any durable store.

#### Exceptions

- Created an exception hierarchy that incorporates the exceptions exposed by the legacy client library, covering the same set of scenarios with minor changes to naming to better clarify the context.

- Ensured that custom Event Hubs exceptions are properly translated to the new versions, no longer exposing legacy exception types.

#### Retries and timeouts

- Removed the exposed retry policies in favor of a set of retry options based on the options found in `Azure.Core` in order to keep the API familiar.

- An abstract `EventHubsRetryPolicy` has been created to serve as the contract for custom retry policy implementations.

- An option for fixed retry has been added to accompany the exponential retry that was in place previously.
Operation timeouts have been moved from the associated client options and incorporated into the retry options and retry policies.

## 5.0.0-preview.1 

Version 5.0.0-preview.1 is a preview of our efforts in creating a client library that is developer-friendly, idiomatic to the .NET ecosystem, and as consistent across different languages and platforms as possible.  The principles that guide our efforts can be found in the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html).

For more information, please visit: [https://aka.ms/azure-sdk-preview1-net](https://aka.ms/azure-sdk-preview1-net).
