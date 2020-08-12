# Release History

## 5.2.0-preview.3 (Unreleased)


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

- The `EventProcessorClient` now supports a configurable strategy for load balancing, allowing control over whether it claims ownership of partitions in a balanced manner _(default)_ or more aggressively.  The strategy may be set in the `EventProcessorClientOptions` when creating the processor.  More details about strategies can be found in the associated [documentation](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.processor.loadbalancingstrategy?view=azure-dotnet).

- The `EventProcessorClientOptions` now support setting a `PrefetchCount` and `CacheEventCount` for performance tuning.  More details about each can be found in the associated [documentation](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventprocessorclientoptions?view=azure-dotnet).

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
