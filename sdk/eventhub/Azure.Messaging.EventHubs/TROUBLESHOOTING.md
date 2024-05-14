# Troubleshoot Event Hubs issues

This troubleshooting guide covers failure investigation techniques, errors encountered while using the Azure Event Hubs .NET client library, and mitigation steps to resolve these errors.

- [Handle Event Hubs exceptions](#handle-event-hubs-exceptions)
  - [Find information about an EventHubsException](#find-information-about-an-eventhubsexception)
  - [Other common exceptions](#other-common-exceptions)
- [Permission issues](#permission-issues)
- [Connectivity issues](#connectivity-issues)
  - [Timeout when connecting to service](#timeout-when-connecting-to-service)
  - [SSL handshake failures](#ssl-handshake-failures)
  - [Socket exhaustion errors](#socket-exhaustion-errors)
  - [Adding components to the connection string does not work](#adding-components-to-the-connection-string-does-not-work)
    - ["TransportType=AmqpWebSockets" Alternative](#transporttypeamqpwebsockets-alternative)
    - ["Authentication=Managed Identity" Alternative](#authenticationmanaged-identity-alternative)
  - [Connect using an IoT connection string](#connect-using-an-iot-connection-string)
- [Logging and Diagnostics](#logging-and-diagnostics)
- [Troubleshoot producer client issues](#troubleshoot-producer-client-issues)
  - [Cannot set multiple partition keys for events in EventDataBatch](#cannot-set-multiple-partition-keys-for-events-in-eventdatabatch)
  - [Setting partition key on EventData is not set in Kafka consumer](#setting-partition-key-on-eventdata-is-not-set-in-kafka-consumer)
- [Troubleshoot event processor issues](#troubleshoot-event-processor-issues)
  - [Logs reflect intermittent HTTP 412 and HTTP 409 responses from storage](#logs-reflect-intermittent-http-412-and-http-409-responses-from-azure-storage)
  - [Partitions close and initialize intermittently or during scaling](#partitions-close-and-initialize-intermittently-or-during-scaling)
  - [Partitions close and initialize frequently](#partitions-close-and-initialize-frequently)
  - [Warnings being raised to the error handler that start with "A load balancing cycle has taken too long to complete."](#warnings-being-raised-to-the-error-handler-that-start-with--a-load-balancing-cycle-has-taken-too-long-to-complete-)
  - ["Frequent errors for "...current receiver '< RECEIVER_NAME >' with epoch '0' is getting disconnected""](#frequent-errors-for-current-receiver--receiver_name--with-epoch-0-is-getting-disconnected)
  - [Warnings being raised to the error handler that start with "The 'PartitionOwnershipExpirationInterval' and 'LoadBalancingUpdateInterval' are configured using intervals that may cause stability issues"](#warnings-being-raised-to-the-error-handler-that-start-with-the-partitionownershipexpirationinterval-and-loadbalancingupdateinterval-are-configured-using-intervals-that-may-cause-stability-issues)
  - [High CPU usage](#high-cpu-usage)
  - [A partition is not being processed](#a-partition-is-not-being-processed)
  - [Duplicate events are being processed](#duplicate-events-are-being-processed)
- [Troubleshoot Azure Function issues](#troubleshoot-azure-function-issues)
  - [Trigger is unable to bind to Event Hubs types after upgrading to v5.0+ of the extensions](#trigger-is-unable-to-bind-to-event-hubs-types-after-upgrading-to-v50-of-the-extensions)
  - [Logging is too verbose](#logging-is-too-verbose)
  - [Socket exhaustion errors](#socket-exhaustion-errors)
- [Migrate from legacy to new client library](#migrate-from-legacy-to-new-client-library)
- [Filing GitHub issues](#filing-github-issues)
- [Get additional help](#get-additional-help)

## Handle Event Hubs exceptions

The Event Hubs client library will surface exceptions when an error is encountered by a service operation or within the client.  When possible, standard .NET exception types are used to convey error information.  For scenarios specific to Event Hubs, an [EventHubsException][EventHubsException] is thrown; this is the most common exception type that applications will encounter.

The Event Hubs clients will implicitly retry exceptions that are considered transient, following the configured [retry options][EventHubsRetryOptions].  When an exception is surfaced to the application, either all retries were applied unsuccessfully, or the exception was considered non-transient.  More information on configuring retry options can be found in the [Configuring the client retry thresholds][ConfigureRetrySample] sample.

For more information on Event Hubs error scenarios and recommended ways to resolve them, please see the
[Event Hubs Messaging Exceptions][EventHubsMessagingExceptions] guidance.

### Find information about an EventHubsException

The exception includes some contextual information to assist in understanding the context of the error and its relative severity.  These are:

- `EventHubName` : Identifies the name of the Event Hub associated with the error.

- `IsTransient` : Indicates whether or not the exception is considered recoverable.  In the case where it was deemed transient, the appropriate retry policy has already been applied and all retries were unsuccessful.

- `Message` : Provides a description of the error that occurred and relevant context.

- `StackTrace` : Represents the immediate frames of the call stack, highlighting the location in the code where the error occurred.

- `InnerException` : When an exception was the result of a service operation, this will often be a `Microsoft.Azure.Amqp.AmqpException` instance describing the error, following the [OASIS AMQP 1.0 spec][AmqpSpec].

- `Reason` : Provides a set of well-known reasons for the failure that help to categorize and clarify the root cause.  These are intended to allow for applying exception filtering and other logic where inspecting the text of an exception message wouldn't be ideal.   Some key failure reasons are:

  - **Client Closed** : This occurs when an operation has been requested on an Event Hub client that has already been closed or disposed of.  It is recommended to check the application code and ensure that objects from the Event Hubs client library are created and closed/disposed in the intended scope.

  - **Service Timeout** : This indicates that the Event Hubs service did not respond to an operation within the expected amount of time.  This may have been caused by a transient network issue or service problem.  The Event Hubs service may or may not have successfully completed the request; the status is not known.  It is recommended to attempt to verify the current state and retry if necessary.

  - **Quota Exceeded** : This typically indicates that there are too many active read operations for a single consumer group.  This limit depends on the tier of the Event Hubs namespace, and moving to a higher tier may be desired.  An alternative would be to create additional consumer groups and ensure that the number of consumer client reads for any group is within the limit.  Please see [Azure Event Hubs quotas and limits][EventHubsQuotas] for more information.

  - **Message Size Exceeded** : Event data as a maximum size allowed for both an individual event and a batch of events.  This includes the data of the event, as well as any associated metadata and system overhead.  The best approach for resolving this error is to reduce the number of events being sent in a batch or the size of data included in the message.  Because size limits are subject to change, please refer to [Azure Event Hubs quotas and limits][EventHubsQuotas] for specifics.

  - **Consumer Disconnected** : A consumer client was disconnected by the Event Hub service from the Event Hub instance.  This typically occurs when a consumer with a higher owner level asserts ownership over a partition and consumer group pairing.

  - **Resource Not Found**: An Event Hubs resource, such as an Event Hub, consumer group, or partition, could not be found by the Event Hubs service.  This may indicate that it has been disabled, is still in the process of being created, was deleted from the service, or that there is an issue with the Event Hubs service itself.

Reacting to a specific failure reason for the [EventHubsException][EventHubsException] can be accomplished in several ways, the most common of which is by applying an exception filter clause as part of the `catch` block:

```C# Snippet:EventHubs_ReadMe_ExceptionFilter
try
{
    // Read events using the consumer client
}
catch (EventHubsException ex) when
    (ex.Reason == EventHubsException.FailureReason.ConsumerDisconnected)
{
    // Take action based on a consumer being disconnected
}
```

### Other common exceptions

- **ArgumentException** : An exception deriving from `ArgumentException` is thrown by clients when a parameter provided when interacting with the client is invalid.  Information about the specific parameter and the nature of the problem can be found in the `Message`.

- **InvalidOperationException** : Occurs when attempting to perform an operation that isn't valid for its current configuration.  This typically occurs when a client was not configured to support the operation.  Often, it can be mitigated by adjusting the options passed to the client.

- **NotSupportedException** : Occurs when a requested operation is valid for the client, but not supported by its current state.  Information about the scenario can be found in the `Message`.

- **AggregateException** : Occurs when an operation may encounter multiple exceptions and is surfacing them as a single failure.  This is most commonly encountered when starting or stopping an event processor.

## Permission issues

An [UnauthorizedAccessException][UnauthorizedAccessException] indicates that the provided credentials do not allow for requested action to be performed.  The `Message` property contains details about the failure.

The following verification steps are recommended, depending on the type of authorization provided when constructing the Event Hubs client:

- [Verify the connection string is correct][GetConnectionString]
- [Verify the SAS token was generated correctly][AuthorizeSAS]
- [Verify the correct RBAC roles were granted][RBAC]

For more possible solutions, see: [Troubleshoot authentication and authorization issues with Event Hubs][TroubleshootAuthenticationAuthorization].

## Connectivity issues

### Timeout when connecting to service

Depending on the host environment and network, this may present to applications as a `TimeoutException`, `OperationCanceledException`, or an `EventHubsException` with `Reason` of `ServiceTimeout` and most often occurs the client cannot find a network path to the service.

To troubleshoot:

- Verify that the connection string or fully qualified domain name specified when creating the client is correct.  For information on how to acquire a connection string, see: [Get an Event Hubs connection string][GetConnectionString].

- Check the firewall and port permissions in your hosting environment and that the AMQP ports 5671 and 5672 are open and that the endpoint is allowed through the firewall.

- Try using the Web Socket transport option, which connects using port 443.  For details, see: [configure web sockets][ConfigureWebSocketsSample].

- See if your network is blocking specific IP addresses.  For details, see: [What IP addresses do I need to allow?][EventHubsIPAddresses].

- If applicable, verify the proxy configuration. For details, see: [configure proxy][ConfigureProxySample].

- For more information about troubleshooting network connectivity, see: [Event Hubs troubleshooting][EventHubsTroubleshooting].

### SSL handshake failures

This error can occur when an intercepting proxy is used. To verify, it is recommended that the application be tested in the host environment with the proxy disabled.

### Socket exhaustion errors

Applications should prefer treating the Event Hubs clients as a singleton, creating and using a single instance through the lifetime of their application.  This is important as each client type manages its own connection; each new Event Hub client created results in a new AMQP connection, which uses a socket.  If desired, it is possible to share the same AMQP connection across multiple clients.  To do so, an instance of `EventHubConnection` should be created and be passed to the constructor for any new client intended to share it.

The clients are safe to cache when idle; they will ensure efficient management of network, CPU, and memory use, minimizing their impact during periods of inactivity.  It is also important that either `CloseAsync` or `DisposeAsync` be called when a client is no longer needed to ensure that network resources are properly cleaned up.

### Adding components to the connection string does not work

The current generation of the Event Hubs client library supports connection strings only in the form published by the Azure portal.  These are intended to provide basic location and shared key information only; configuring behavior of the clients is done through its options.

Previous generations of the Event Hub clients allowed for some behavior to be configured by adding key/value components to a connection string.  These components are no longer recognized and have no effect on client behavior.

#### "TransportType=AmqpWebSockets" Alternative

To configure web socket use, see: [configure web sockets][ConfigureWebSocketsSample].

#### "Authentication=Managed Identity" Alternative

To authenticate with Managed Identity, see: [Identity and Shared Access Credentials][IdentitySample].

For more information about the `Azure.Identity` library, see: [Authentication and the Azure SDK][AuthenticationAndTheAzureSDK].

### Connect using an IoT connection string

The endpoint in an IoT Hub query string specifies an IoT Hub, not an Event Hubs namespace.  Because of this, it cannot be used with the Event Hubs client library.  Each IoT Hub instance provisions an Event Hub that it associates with that specific IoT Hub.  The [IoT Hub documentation][IoTHubDocs] refers to this as the "built-in Event Hub-compatible endpoint".

Using that "built-in Event Hub-compatible endpoint" requires obtaining its connection string from IoT Hub.  The recommended approach is to copy the connection string from the Azure portal, as discussed in the [IoT Hub documentation][IoTHubDocs].

For applications that are unable to do so, see the following for an illustration of querying IoT Hub in real-time to obtain it: [How to request the IoT Hub built-in Event Hubs-compatible endpoint connection string][IoTConnectionStringSample].

Further reading:
* [Control access to IoT Hub using Shared Access Signatures][IoTHubSAS]
* [Read device-to-cloud messages from the built-in endpoint][IoTEventHubEndpoint]

## Logging and diagnostics

The Event Hubs client library is fully instrumented for logging information at various levels of detail using the .NET `EventSource` to emit information.  Logging is performed for each operation and follows the pattern of marking the starting point of the operation, it's completion, and any exceptions encountered.  Additional information that may offer insight is also logged in the context of the associated operation.

The Event Hubs client logs are available to any `EventListener` by opting into the sources starting with "Azure-Messaging-EventHubs" or by opting into all sources that have the trait "AzureEventSource".  To make capturing logs from the Azure client libraries easier, the `Azure.Core` library used by Event Hubs offers an `AzureEventSourceListener`.

For more information, see: [Capturing Event Hubs logs using the AzureEventSourceListener][EventSourceListenerSample].

## Troubleshoot producer client issues

### Cannot set multiple partition keys for events in EventDataBatch

When publishing messages, the Event Hubs service requires that all messages in a single EventDataBatch have the same partition key.  To use multiple partition keys for events with the `EventHubProducerClient`, applications will need to manage multiple batches.

For this scenario, taking advantage of the implicit batching performed by the `EventHubBufferedProducerClient` may be a more natural fit, as each individual event can be enqueued with an associated partition key.  For more information, see: [Publishing events with a partition key][BufferedProducerPartitionKeySample].

### Setting partition key on EventData is not set in Kafka consumer

The partition key specified when publishing an Event Hubs event is available in the Kafka record headers, using the protocol-specific key "x-opt-partition-key".

By design, Event Hubs does not directly reflect a Kafka message key as an Event Hubs partition key, nor vice-versa, because the same key would likely be mapped to different partitions by Kafka and Event Hubs.  This behavior may cause confusion when working with cross-protocol scenarios.

## Troubleshoot event processor issues

### Logs reflect intermittent HTTP 412 and HTTP 409 responses from Azure Storage

This is normal and does not indicate an issue with the processor nor with the associated checkpoint store.

An HTTP 412 precondition response occurs when the event processor requests ownership of a partition, but that partition was recently claimed by another processor.  An HTTP 409 occurs when the processor issues a "create if not exists" call when creating data and the item already exists.

Though these are expected scenarios, because the HTTP response code falls into the 400-499 range, Application Insights and other logging platforms are likely to surface them as errors.

### Partitions close and initialize intermittently or during scaling

This is usually normal and most often does not indicate an issue with the processor.

Event processors configured to use the same Event Hub, consumer group, and checkpoint store will coordinate with one another to share the responsibility of processing partitions.  When the number of event processors changes, usually when scaling up/down, ownership of partitions is re-balanced and some may change owners.

During this time, it is normal and expected to see partitions initializing and closing across event processors.  After one or two minutes, ownership should stabilize and the frequency that partitions close and initialize should decrease.  While ownership is stable, some error recovery scenarios may trigger partitions closing and initializing occasionally.

### Partitions close and initialize frequently

If the number of processors configured to us the same Event Hub, consumer group, and checkpoint store are being scaled or if host nodes are being rebooted, partitions closing and initializing frequently for a short time is normal an expected.  If the behavior persists longer than five minutes, it likely indicates a problem.

The most frequent causes of this behavior are:

#### Exceptions being thrown in the event processing handler:

It is very important that an application's handler code guards against exceptions; the event processor does not have enough understanding of the application and its state to know how an exception should be handled.  Any exception thrown in a handler will go uncaught by the processor and will **NOT** be directed to the error handler.

Behavior is not guaranteed but, for most hosts, this will fault the task responsible for processing a partition, causing it to be restarted from the last checkpoint.  As a result, the partition will close and initialize and the application is likely to see duplicate events being processed.

It is strongly recommended that all handlers be wrapped in a `try/catch` block and that exceptions are not permitted to bubble.

#### Too many partitions are owned:

The event processor works in a concurrent and highly asynchronous manner.  Each partition owned by the processor is hosted by a dedicated background task.  The processor infrastructure also relies on a background task to perform health checks, error recovery, and load balancing activities.  Each of these tasks relies on continuations for asynchronous operations being scheduled in a timely manner in order to make forward progress.

When a processor owns too many partitions, it will often experience contention in the thread pool leading to starvation.  During this time, continuations will start to queue while waiting to be scheduled causing stalls in the processor.  Because there is no fairness guarantee in scheduling, some partitions may appear to stop processing or load balancing may not be able to update ownership, causing partitions to "bounce" between owners.

Generally, it is recommended that an event processor own no more than 3 partitions for every 1 CPU core of the host.  Since the ratio will vary for each application, it is often helpful to start with 1.5 partitions for each CPU core and increase the number of owned partitions gradually to determine what works best for your application.

Further reading:
- [Debug ThreadPool Starvation][DebugThreadPoolStarvation]
- [Diagnosing .NET Core ThreadPool Starvation with PerfView (Why my service is not saturating all cores or seems to stall)](https://docs.microsoft.com/archive/blogs/vancem/diagnosing-net-core-threadpool-starvation-with-perfview-why-my-service-is-not-saturating-all-cores-or-seems-to-stall)
- [Diagnosing ThreadPool Exhaustion Issues in .NET Core Apps][DiagnoseThreadPoolExhaustion] _(video)_

#### "Soft Delete" or "Blob versioning" is enabled for a Blob Storage checkpoint store:

To coordinate with other event processors, the checkpoint store ownership records are inspected during each load balancing cycle.  When using an Azure Blob Storage as a checkpoint store, the "soft delete" and "Blob versioning" features can cause large delays when attempting to read the contents of a container.  It is strongly recommended that both be disabled.  For more information, see: [Soft delete for blobs][SoftDeleteBlobStorage] and [Blob versioning][VersioningBlobStorage].

#### The "LoadBalancingUpdateInterval" and "PartitionOwnershipExpirationInterval" options are set too close together:

It is recommended that the `PartitionOwnershipExpirationInterval` be at least 3 times greater than the `LoadBalancingUpdateInterval` and very strongly advised that it should be no less than twice as long.  When these intervals are too close together, ownership may expire before it is renewed during load balancing, which could cause partitions to migrate unintentionally.  Adjustments should be made to the values in the processor options.

### Warnings being raised to the error handler that start with  "A load balancing cycle has taken too long to complete. ..."

The full text of the error message looks something like:

> A load balancing cycle has taken too long to complete.  A slow cycle can cause stability issues with partition ownership.  Consider investigating storage latency and thread pool health.  Common causes are soft delete being enabled for storage and too many partitions owned.  You may also want to consider increasing the 'PartitionOwnershipExpirationInterval' in the processor options.  Cycle Duration: < NUMBER > seconds.  Partition Ownership Interval '< NUMBER >' seconds.

This warning indicates that the processor's load balancing loop is running slowly, which may result in other processors seeing it as unavailable.  This will cause partitions to move between owners, slowing forward progress and causing rewinds/duplication for processing.  If this is seen very occasionally without partition ownership changes, the host may be under a temporary heavy load and it can be ignored.   However, if this warning is triggered regularly, it signals a problem that should be addressed.

The most likely cause is an event processor owning too many partitions.  See: [Too many partitions are owned](#too-many-partitions-are-owned).

Another possible cause is soft delete being enabled on the container being used by the processor.  See: ["Soft Delete" is enabled for a Blob Storage checkpoint store](#soft-delete-is-enabled-for-a-blob-storage-checkpoint-store).

### Frequent errors for "...current receiver '< RECEIVER_NAME >' with epoch '0' is getting disconnected"

The full text of the error message looks something like:

> New receiver '< GUID >' with higher epoch of '0' is created hence current receiver '< GUID >' with epoch '0'
> is getting disconnected. If you are recreating the receiver, make sure a higher epoch is used.
> TrackingId:< GUID >, SystemTracker:< NAMESPACE >:eventhub:< EVENT_HUB_NAME >|< CONSUMER_GROUP >,
> Timestamp:2022-01-01T12:00:00}"}

If the number of processors configured to us the same Event Hub, consumer group, and checkpoint store are being scaled or if host nodes are being rebooted, partitions closing and initializing frequently for a short time is normal an expected.  If the behavior persists longer than five minutes, it likely indicates a problem.

This is often caused by another cluster of processors using the same consumer group but configured to use another checkpoint store instance or location.  This causes the processors to compete against one another for ownership because they cannot coordinate ownership through the checkpoint store.  Other consumers may also compete for exclusive access to a partition if they specify an "owner level" as part of their options.

Another possible cause is an event processor owning too many partitions.  See: [Too many partitions are owned](#too-many-partitions-are-owned).

### Warnings being raised to the error handler that start with "The 'PartitionOwnershipExpirationInterval' and 'LoadBalancingUpdateInterval' are configured using intervals that may cause stability issues..."

The full text of the error message looks something like:

> The 'PartitionOwnershipExpirationInterval' and 'LoadBalancingUpdateInterval' are configured using intervals that may cause stability issues with partition ownership for the processor instance with identifier '< PROCESSOR_CLIENT_ID >' for Event Hub: '< EVENT_HUB_NAME >'.  It is recommended that the 'PartitionOwnershipExpirationInterval' be at least 3 times greater than the 'LoadBalancingUpdateInterval' and very strongly advised that it should be no less than twice as long.  When these intervals are too close together, ownership may expire before it is renewed during load balancing which will cause partitions to migrate.  Consider adjusting the intervals in the processor options if you experience issues.  Load Balancing Interval < NUMBER > seconds.  Partition Ownership Interval < NUMBER > seconds.

This warning indicates that the processor was configured such that the interval controlling partition ownership related to load balancing is close to the length of the interval before which partition ownership must be renewed to be considered owned.  When these intervals are too close together, ownership may expire before it is renewed during load balancing which can cause partitions to migrate unintentionally.

If you are not experiencing problems, it is safe to ignore this warning.  If partitions begin to migrate or are frequently initialized and closed, consider following the configuration guidance in the warning message.

### High CPU usage

High CPU usage is usually because an event processor owns too many partitions.  See: [Too many partitions are owned](#too-many-partitions-are-owned).

### One or more partitions have high latency for processing

When processing for one or more partitions is delayed, it is most often because an event processor owns too many partitions.  See: [Too many partitions are owned](#too-many-partitions-are-owned).

### A partition is not being processed

An event processor runs continually in a host application for a prolonged period.  Sometimes, it may appear that some partitions are uncrowned or are not being processed.  Most often, this presents as [Partitions close and initialize frequently](#partitions-close-and-initialize-frequently) or [Warnings being raised to the error handler that starts with "A load balancing cycle has taken too long to complete."](#warnings-being-raised-to-the-error-handler-that-starts-with--a-load-balancing-cycle-has-taken-too-long-to-complete-) and should follow those troubleshooting steps.

If partitions are not observed closing and initializing frequently and no warning is being raised to the error handler, then a stalled or unowned partition may be part of a larger problem and a GitHub issue should be opened.  Please see: [Filing GitHub issues](#filing-github-issues).

### Duplicate events are being processed

This is usually normal and most often does not indicate an issue unless partitions are frequently closing and initializing.

An important call-out is that Event Hubs has an at-least-once delivery guarantee; it is highly recommended that applications ensure that processing is resilient to event duplication in whatever way is appropriate for their environment and application scenarios.

Event processors configured to use the same Event Hub, consumer group, and checkpoint store will coordinate with one another to share the responsibility of processing partitions. When a processor isn’t able to reach its fair share of the work by claiming unowned partitions, it will attempt to steal ownership from other event processors.  During this time, the new owner will begin reading from the last recorded checkpoint.  At the same time, the old owner may be dispatching the events that it last read to the handler for processing; it will not understand that ownership has changed until it attempts to read the next set of events from the Event Hubs service.

As a result, there will be an amount of duplicate events being processed when event processors are started or stopped which will subside when partition ownership has stabilized.  If frequent partition initialization persists longer than five minutes, it likely indicates a problem.

## Troubleshoot Azure Function issues

### Trigger is unable to bind to Event Hubs types after upgrading to v5.0+ of the extensions

Starting with v5.0, the `Microsoft.Azure.WebJobs.Extensions.EventHubs` package moved to the `Azure.Messaging.EventHubs` package internally.  This means that the types exposed in the Function signature originate in that package.  If the Function had previously been using a lower version of the extensions package or is directly referencing the `Microsoft.Azure.EventHubs` types, there may be compilation errors and type mismatches.

It is recommended that the Function be updated to use `Azure.Messaging.EventHubs` for its bindings and body.  The `Microsoft.Azure.EventHubs` library has been deprecated. For more information, see: [Microsoft.Azure.WebJobs.Extensions.EventHubs ReadMe][FunctionExtensionsReadMe].

If there is an existing investment in `Microsoft.Azure.EventHubs` that makes migrating packages difficult, the most straightforward option would be to use [v4.3.1][LegacyFunctionExtensionsPackage] of the `Microsoft.Azure.WebJobs.Extensions.EventHubs` package, which uses the legacy library internally.

Alternatively, it is possible to use `Azure.Messaging.EventHubs` for the bindings and `Microsoft.Azure.EventHubs` in the Function body by specifying the full namespace for all Event Hubs types to disambiguate.  The primary challenge in that scenario is that, despite sharing some names, the types are different and cannot be used interchangeably.  Data would need to be copied between the current and legacy types.

### Logging is too verbose

By default, v5.0+ of `Microsoft.Azure.WebJobs.Extensions.EventHubs` will respect the global log level configuration.  Each can be tuned individually to allow you to capture the level of detail that an application is interested in.

To change the log detail for Event Hubs, Storage, and other Azure SDK packages, adjust their level in `host.json`.  For example, if an application wanted to capture logs for Azure Storage and other Azure.Core-based libraries with just errors  and capture warnings and errors for Event Hubs, the configuration would be similar to similar to:

```json
"Logging": {
  "LogLevel": {
    "Default": "Information",
    "System": "Information",
    "Microsoft": "Warning"
    "Azure.Core": "Error",
    "Azure.Messaging.EventHubs": "Warning"
  }
}
```

More information on how the Azure SDK logging configuration maps to the Functions logging can be found in the article [Logging with the Azure SDK for .NET][AzureSdkNetLogging].

### Socket exhaustion errors

This often occurs in a Function due to creation of a new Event Hubs client type in the body of the Function and not ensuring that either `CloseAsync` or `DisposeAsync` is called.  This causes the client to live for a single function execution and then go out of scope while still holding active network resources.

Because the Event Hubs connection is effectively abandoned, it remains active until the idle timeout occurs (~60 seconds).   If the incoming request rate for a Function is greater than roughly one per minute, then connections will be opened faster than they're being closed.  This will lead to socket and port exhaustion.

In addition to the network issues, this usage pattern will also perform very poorly because the application is paying the cost to establish a connection/link for every Function invocation.  Applications should prefer treating the Event Hubs clients as a singleton, creating and using a single instance through the lifetime of their application.

Further reading:
  - [Dependency injection with the Azure SDK for .NET][DependencyInjectionAzureSdk]
  - [Use dependency injection in .NET Azure Functions][DependencyInjectionAzureFunctions]

## Migrate from legacy to new client library

Further reading:
- [Migration Guide for Microsoft.Azure.EventHubs][MigrationGuideT1]
- [Migration Guide for WindowsAzure.ServiceBus][MigrationGuideT0]

## Filing GitHub issues

When filing GitHub issues, the following details are requested for all scenarios:

- Instructions on how to reproduce the issue locally.  Ideally, a small self-contained project that can reproduce the error is available.

- Logs for the period of at least +/- 5 minutes from when the issue occurred.  Verbose logs are usually needed, but can be filtered by the type of issue.  _(see below)_

- How many partitions does the Event Hub have?

- What is the traffic pattern like in the Event Hub?  _(# messages/minute, consistent or burst loads, etc)_

### Publishing issues

- What is the average size of each EventData being published?

- How are events being published? _(automatic assignment, using a partition key, to a specific partition)_

- If using the `EventHubBufferedProducerClient`, what activity is the failure handler seeing?

- If using the `EventHubProducerClient`, what exception is being surfaced by `SendAsync`?

- Verbose logs can be filtered to:

  **_Event Source Name: "Azure-Messaging-EventHubs"_**
  - All warnings
  - All errors
  - 3 (Publish Start)
  - 4 (Publish Complete)
  - 5 (Publish Error)
  - 76 (Buffered Producer Background Task Error)
  - 79 (Buffered Producer Background Enqueue Error)
  - 83 (Buffered Producer Publishing Task Error)
  - 88 (Buffered Producer Publish Start)
  - 89 (Buffered Producer Publish Complete)
  - 90 (Buffered Producer Publish Error)
  - 126 (Buffered Producer Idle Start)
  - 127 (Buffered Producer Idle Complete)

### Event processor issues

- How many CPU cores does the host machine have?

- How many event processors are configured to use the same Event Hub, consumer group, and checkpoint store?

- Verbose logs can be filtered to:

  **_Event Source Name: "Azure-Messaging-EventHubs"_**
  - All warnings
  - All errors
  - 6 (Event Receive Start)
  - 7 (Event Receive End)
  - 8 (Event Receive Error)
  - 36 (Event Processor Task Error)
  - 37 (EventProcessorPartitionProcessingStart)
  - 38 (EventProcessorPartitionProcessingStartError)
  - 39 (EventProcessorPartitionProcessingStartComplete)
  - 40 (EventProcessorPartitionProcessingStop)
  - 41 (EventProcessorPartitionProcessingStopError)
  - 42 (EventProcessorPartitionProcessingStopComplete)
  - 43 (EventProcessorPartitionProcessingError)
  - 44 (EventProcessorLoadBalancingError)
  - 45 (EventProcessorClaimOwnershipError)
  - 103 (EventProcessorLoadBalancingCycleSlowWarning)
  - 104 (EventProcessorHighPartitionOwnershipWarning)
  - 123 (EventProcessorProcessingHandlerStart)
  - 124 (EventProcessorProcessingHandlerComplete)
  - 125 (EventProcessorProcessingHandlerError)
  - 129 (EventProcessorPartitionProcessingCycleComplete)

### Consuming issues

- What type is being used to consume? _(EventHubConsumerClient, PartitionReceiver)_

- Verbose logs can be filtered to:

  **_Event Source Name: "Azure-Messaging-EventHubs"_**
  - All warnings
  - All errors
  - 6 (Event Receive Start)
  - 7 (Event Receive End)
  - 8 (Event Receive Error)

## Get additional help

For more information on ways to request support, please see: [Support][SUPPORT].

<!-- repo links -->
[BufferedProducerPartitionKeySample]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample04_PublishingEvents.md#event-hub-buffered-producer-client-1
[ConfigureProxySample]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample02_EventHubsClients.md#using-web-sockets
[ConfigureRetrySample]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample02_EventHubsClients.md#configuring-the-client-retry-thresholds
[ConfigureWebSocketsSample]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample02_EventHubsClients.md#using-web-sockets
[EventSourceListenerSample]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample10_AzureEventSourceListener.md
[FunctionExtensionsReadMe]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Microsoft.Azure.WebJobs.Extensions.EventHubs
[IdentitySample]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample06_IdentityAndSharedAccessCredentials.md#identity-authorization
[IoTConnectionStringSample]: https://github.com/Azure/azure-sdk-for-net/tree/main/samples/iothub-connect-to-eventhubs
[MigrationGuideT0]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/MigrationGuide_WindowsAzureServiceBus.md
[MigrationGuideT1]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/MigrationGuide.md
[SUPPORT]: https://github.com/Azure/azure-sdk-for-net/blob/main/SUPPORT.md

<!-- docs.microsoft.com links -->
[AuthorizeSAS]: https://docs.microsoft.com/azure/event-hubs/authorize-access-shared-access-signature
[AzureSdkNetLogging]: https://docs.microsoft.com/dotnet/azure/sdk/logging#map-to-aspnet-core-logging
[DebugThreadPoolStarvation]: https://docs.microsoft.com/dotnet/core/diagnostics/debug-threadpool-starvation
[DependencyInjectionAzureFunctions]: https://docs.microsoft.com/azure/azure-functions/functions-dotnet-dependency-injection
[DependencyInjectionAzureSdk]: https://docs.microsoft.com/dotnet/azure/sdk/dependency-injection
[DiagnoseThreadPoolExhaustion]: https://docs.microsoft.com/shows/on-net/diagnosing-thread-pool-exhaustion-issues-in-net-core-apps
[EventHubsException]: https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventhubsexception
[EventHubsIPAddresses]: https://docs.microsoft.com/azure/event-hubs/troubleshooting-guide#what-ip-addresses-do-i-need-to-allow
[EventHubsMessagingExceptions]: https://docs.microsoft.com/azure/event-hubs/event-hubs-messaging-exceptions
[EventHubsQuotas]: https://docs.microsoft.com/azure/event-hubs/event-hubs-quotas
[EventHubsRetryOptions]: https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventhubsretryoptions
[EventHubsTroubleshooting]: https://docs.microsoft.com/azure/event-hubs/troubleshooting-guide
[GetConnectionString]: https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string
[IoTHubDocs]: https://docs.microsoft.com/azure/iot-hub/iot-hub-devguide-endpoints
[IoTEventHubEndpoint]: https://docs.microsoft.com/azure/iot-hub/iot-hub-devguide-messages-read-builtin
[IoTHubSAS]: https://docs.microsoft.com/azure/iot-hub/iot-hub-dev-guide-sas#security-tokens
[RBAC]: https://docs.microsoft.com/azure/event-hubs/authorize-access-azure-active-directory
[SoftDeleteBlobStorage]: https://docs.microsoft.com/azure/storage/blobs/soft-delete-blob-overview
[VersioningBlobStorage]: https://docs.microsoft.com/azure/storage/blobs/versioning-overview
[TroubleshootAuthenticationAuthorization]: https://docs.microsoft.com/azure/event-hubs/troubleshoot-authentication-authorization
[UnauthorizedAccessException]: https://docs.microsoft.com/dotnet/api/system.unauthorizedaccessexception

<!-- external links -->
[AmqpSpec]: https://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-types-v1.0-os.html
[AuthenticationAndTheAzureSDK]: https://devblogs.microsoft.com/azure-sdk/authentication-and-the-azure-sdk
[LegacyFunctionExtensionsPackage]: https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.EventHubs/4.3.1
