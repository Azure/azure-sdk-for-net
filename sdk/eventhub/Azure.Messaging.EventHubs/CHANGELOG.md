# Release History

## 5.0.0-preview.3 (2019-08-06)

### Consuming Events

- The full set of system properties was reintroduced to the `EventData` for events received from the service.  In addition to the well-known properties for identifying an event's place in the partition (`Offset`, `SequenceNumber`, and `EnqueuedTime`), any additional metadata sent as part of an event will appear in the `SystemProperties` dictionary.

- The `EventHubConsumer` can be configured to track information about the last event to be enqueued into its associated partition in order to allow for monitoring the backlog of events to be processed without the need to make explicit calls to request partition properties from the `EventHubClient`.

- Consuming events using `SubscribeToEvents` has been refactored for better performance and lower resource use. 

### Event Processor

- Creation of an `EventProcessor` has been refined with the goal of allowing simpler use for standard scenarios while maintaining flexibility for complex ones.  The `EventProcessor` is now able to manage partition processor instances for implementations with a default constructor.

- The `EventProcessor` will now coordinate with other active `EventProcessor` instances for a given Event Hub and consumer group in order to share partitions and ensure that processing work is balanced between them.  `EventProcessor` instances may be activated or deactivated independently and the remaining processors will redistribute partitions as needed.

- The interface for processing partitions has been changed to a base class, in order to allow developers to make the decision which of the available methods they would like to override, rather than being forced to implement each one.

### General

- The client library for Event Hubs is now emitting diagnostics information for distributed tracing.  _(see: [proposal](https://github.com/w3c/trace-context-amqp/blob/411fdeabea45d36db827b7097235549b30fac8e8/spec/20-AMQP_FORMAT.md))_

- Some public types were scoped in a way that made them difficult to mock for library consumers.  These have been re-scoped to `protected internal` for better testability.  `EventData` and metadata types were the significant instances.

## 5.0.0-preview.2 (2019-08-06)

### General

- Public members of type `DateTime` were converted to `DateTimeOffset` to explicitly represent that they are UTC

- Members of type `DateTimeOffset` have had the `Utc` suffix removed from their names, as the `DateTimeOffset` type removes ambiguity about the time zone

- Members representing a partition offset that were incorrectly exposed as `string` have been converted to `int` to provide a unified type.

- Renamed all instances of `EventHubPath` to `EventHubName` to align with the usage context and unify on the chosen semantics across the client library for different languages.

- Ongoing minor tweaks to formatting, wording, and spelling of documentation and XML document comments.

### Publishing events

- Reintroduced the `EventDataBatch`, allowing for publication of a batch of events with known size constraint.  This is intended to ensure that publishers can build batches without the potential for an error when sending and to allow publishers with bandwidth concerns to control the size of each batch published.

- Enhanced the `EventHubProducer` to allow creation of an `EventDataBatch` and to accept them for publication.

### Consuming events

- Added a means to subscribe to the events exposed by an `EventHubConsumer` in the form of an asynchronous iterator.   Using the iterator, consumers are able to use the familiar `foreach` pattern to enumerate events as they are available and process them.  Optionally, consumers may specify a maximum time to wait for events to arrive which, when exceeded, will emit a null event if none were available, returning control to the loop and allowing cancellation or other processing needs.

- Introduced the initial concept of a new version of the `EventProcessor`, intended as a neutral framework for processing events across all partitions for a given Event Hub and in the context of a specific Consumer Group.  This early preview is intended to allow consumers to test the new design using a single instance that does not persist checkpoints to any durable store.

### Exceptions

- Created an exception hierarchy that incorporates the exceptions exposed by the legacy client library, covering the same set of scenarios with minor changes to naming to better clarify the context.

- Ensured that custom Event Hubs exceptions are properly translated to the new versions, no longer exposing legacy exception types.

### Retries and timeouts

- Removed the exposed retry policies in favor of a set of retry options based on the options found in `Azure.Core` in order to keep the API familiar.

- An abstract `EventHubsRetryPolicy` has been created to serve as the contract for custom retry policy implementations.

- An option for fixed retry has been added to accompany the exponential retry that was in place previously.
Operation timeouts have been moved from the associated client options and incorporated into the retry options and retry policies.

## 5.0.0-preview.1 (2019-07-01)
Version 5.0.0-preview.1 is a preview of our efforts in creating a client library that is developer-friendly, idiomatic to the .NET ecosystem, and as consistent across different languages and platforms as possible.  The principles that guide our efforts can be found in the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html).

For more information, please visit: [https://aka.ms/azure-sdk-preview1-net](https://aka.ms/azure-sdk-preview1-net).