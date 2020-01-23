# Release History

## 5.0.0

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Christopher Scott _([GitHub](https://github.com/christothes))_

### Changes

#### General

- A migration guide is now available for those moving from the 4.x version of the `Microsoft.Azure.EventHubs` libraries to the 5.0.0 version under the `Azure.Messaging.EventHubs` namespace.

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
