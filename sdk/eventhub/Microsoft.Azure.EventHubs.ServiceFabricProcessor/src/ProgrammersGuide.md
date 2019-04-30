# Programmer's Guide to Service Fabric Processor

## Introduction

Service Fabric Processor (SFP) allows a user to easily create a Service
Fabric-based stateful service that processes events from an Event Hub. The
service is required to have exactly as many partitions as the target Event Hub
does, because each Service Fabric partition is permanently associated with a
corresponding Event Hub partition. The user's processing logic for events is
contained in their implementation of the IEventProcessor interface. Each
partition of the service has an instance of that implementation, which is called
by SFP to handle events consumed from the corresponding Event Hub partition.
Only the primary Service Fabric replica for each partition consumes and processes
events. The secondary replicas exist to maintain the reliable dictionary that
Service Fabric Processor uses for checkpointing.

## IEventProcessor

There are four methods that the user is required to implement, and one more
which the user may override if desired.

Most of the methods provide a
CancellationToken as an argument, and it is important for long-running
operations in the user's code to honor that token. Service Fabric cancels it
when a primary replica's state is changing, and that is the code's chance to
clean up and shut down gracefully instead of being forcefully terminated!

All methods provide a PartitionContext as an argument, which contains
various information about the Event Hub and the partition that may be useful
to the user's code. The PartitionContext also has a reference to the
CancellationToken.

### OpenAsync

```csharp
Task OpenAsync(CancellationToken cancellationToken, PartitionContext context)
```

SFP calls this method when a partition replica becomes primary. This is the
opportunity to initialize resources that the event processing logic will
use, such as a database connection, or perform any other startup needed.

### ProcessEventsAsync

```csharp
Task ProcessEventsAsync(CancellationToken cancellationToken, PartitionContext context, IEnumerable<EventData> events)
```

After the Task returned by OpenAsync completes, SFP calls this method repeatedly
as events become available. SFP makes only one call to ProcessEventsAsync at a
time: it waits for the Task returned by the current call to complete before
attempting to consume more events from the Event Hub. By default, this method
is called only when events are available, so if traffic on the associated
Event Hub partition is sparse, it may be some time between calls to this method.

### CloseAsync

```csharp
Task CloseAsync(PartitionContext context, CloseReason reason)
```

SFP calls this method when a primary replica is being shut down, whether due to
an Event Hub failure or because Service Fabric is changing the replica's state.
No cancellation token is provided because the user's code is expected to already
be shutting down as quickly as possible, and in many cases the token will already
be cancelled. The CloseReason indicates whether the shutdown is due to an Event
Hub failure or Service Fabric cancellation.

This method will will not be called until the Task returned by the most recent
ProcessEventsAsync call has completed.

### ProcessErrorAsync

```csharp
Task ProcessErrorAsync(PartitionContext context, Exception error)
```

SFP calls this method when an Event Hubs error has occurred. It is purely
informational. Recovering from the error, if possible, is up to SFP.

### GetLoadMetric

```csharp
Dictionary<string, int> GetLoadMetric(CancellationToken cancellationToken, PartitionContext context)
```

Service Fabric offers sophisticated load balancing of
partition replicas between nodes based on user-provided metrics, and this
method allows SFP users to take advantage of that feature. SFP polls this
method periodically and passes the metrics returned to Service Fabric. The
metrics are represented as a dictionary of string-int pairs, where the string
is the metric name and the int is the metric value. SFP provides a default
implementation of this method, which returns a metric named "CountOfPartitions"
that has a constant value of 1.

It is up to the user to configure Service Fabric to use metrics returned by
this method. Service Fabric ignores any metrics not mentioned in the
configuration, so it is safe to return any metrics that might be interesting
and then decide later which particular ones to use.

## Integrating With Service Fabric

SFP requires a stateful Service Fabric service that is configured to have the
same number of partitions as the Event Hub.

The user's service will have a class derived from the Service Fabric class
StatefulService, which in turn has a RunAsync method that is called on primary
partition replicas. SFP setup and activation occur within that RunAsync method.

### SFP Options

SFP provides a class EventProcessorOptions, which allows setting a wide variety
of options that adjust how SFP operates. To use it, create a new instance, which
is initialized with the default settings, then change the options of interest,
and finally pass the instance to the ServiceFabricProcessor constructor.

```csharp
EventProcessorOptions options = new EventProcessorOptions();
options.MaxBatchSize = 50;
ServiceFabricProcessor processor = new ServiceFabricProcessor(..., options);
```

Available options are:

* int MaxBatchSize: the _maximum_ number of events that will be passed to
ProcessEventsAsync at one time. Default is 10. The actual number of events for
each call is variable and depends on how many events are available in the Event
Hub partition, how fast they can be transferred, how long the previous call to
ProcessEventsAsync took, and other factors. If your system as a whole is
processing events faster than they are generated, then much of the time
ProcessEventsAsync will be called with only one event. This option only
governs the _maximum_ number.

* int PrefetchCount: passed to the underlying Event Hubs client, this option
governs how many events can be prefetched. Default is 300. This generally
comes into play only when there is a backlog of events due to slow processing.
If your system as a whole is processing events faster than they are generated,
then the prefetch buffer will be empty, because every event that becomes
available can be immediately passed to ProcessEventsAsync.

* TimeSpan ReceiveTimeout: passed to the underlying Event Hubs client, this
option governs the timeout duration for the Event Hubs receiver. Default is
60 seconds.

* bool EnableReceiverRuntimeMetric: TODO -- needs client changes before it
can be supported

* bool InvokeProcessorAfterReceiveTimeout: if false, ProcessEventsAsync is
called only when at least one event is available. If true, ProcessEventsAsync
is called with an empty event list when a receive timeout occurs. Default is
false.

* ShutdownNotification OnShutdown: set a delegate which is called just before
the Task returned by ServiceFabricProcessor.RunAsync completes. Depending on
how the code in the service's RunAsync is structured, SFP might shut down due
to an error long before RunAsync awaits the returned Task. This delegate
provides notification of such a shutdown.

* Func<string, EventPosition> InitialPositionProvider: see "Starting Position
and Checkpointing" below

### Instantiating ServiceFabricProcessor

```csharp
IEventProcessor myEventProcessor = new MyEventProcessorClass(...);
ServiceFabricProcessor processor = new ServiceFabricProcessor(
	this.Context.ServiceName,
	this.Context.PartitionId,
	this.StateManager,
	this.Partition,
	myEventProcessor,
	eventHubConnectionString,
	eventHubConsumerGroup,
	options
);
```

* The first four arguments are Service Fabric artifacts that SFP needs to get
information about Service Fabric partitions and to access Service Fabric reliable
dictionaries. They are all available as members of the StatefulService-derived
class.

* The next argument is an instance of the user's implementation of IEventProcessor.

* The next two arguments are the connection string of the Event Hub to consume
from, and the consumer group. The consumer group is optional: if null or omitted,
the default consumer group "$Default" is used.

* The last argument is an optional instance of EventProcessorOptions. If null
or omitted, all options have their default value.

### Start processing events

```csharp
Task processing = processor.RunAsync(cancellationToken);
// do other stuff here if desired
await processing;
```

Note that ServiceFabricProcessor.RunAsync can be called only once. If the await
throws, you can either allow the exception to propagate out to Service Fabric and
let Service Fabric restart the replica, or you can create a new instance of
ServiceFabricProcessor and call RunAsync on the new instance.

## Starting Position and Checkpointing

When ServiceFabricProcessor.RunAsync is called, one of the first things it does
is to create a receiver on the Event Hub partition so it can consume events.
Because Event Hubs do not have a service-side cursor, a receiver must specify
a starting position when it is created.

One of the features of SFP is checkpointing, which provides a client-side
cursor by persisting the offset of the last event processed successfully.
Checkpointing does not happen automatically, because there are scenarios
which do not need it. To use checkpointing, the user's implementation of
IEventProcessor.ProcessEventsAsync calls the CheckpointAsync methods on
the supplied PartitionContext.

### Finding the Starting Position

SFP follows these steps to determine the starting position when creating a
receiver:

* If there is a checkpoint for the partition, start at the next event after
that position.

* Else, call EventProcessorOptions.InitialPositionProvider, if present: when
setting up options, the user can provide a function which takes an Event Hub
partition id and returns an EventPosition.

* Else, start at the oldest available event.

### Checkpointing

PartitionContext provides two methods for setting a checkpoint:

* With no arguments, the checkpoint contains the position of the last event
in the current batch. If once-per-batch is a reasonable checkpoint strategy
for your application, calling PartitionContext.CheckpointAsync just before
returning from IEventProcessor.ProcessEventsAsync is simple and convenient.

* The other overload of CheckpointAsync takes an EventData as an argument
and sets a checkpoint with the position of the given event. This way, your
application can checkpoint at any interval.

It is important to await CheckpointAsync, to be sure that the checkpoint
was actually persisted.

### Special Considerations

A checkpoint is a representation of a position in the event stream of a
particular Event Hub+consumer group+partition combination. All events up to and
including the checkpointed position are assumed to be processed, and any events
after the position are assumed to be unprocessed. The intention is that a
newly-created receiver will pick up where the previous receiver left off, for
example when Service Fabric moves the primary replica of a partition from one
node to another for load balancing.

For performance reasons, it is not always desirable to checkpoint after processing
each event. Checkpointing at larger intervals (for example, every ten events, or
every ten seconds, etc.) can improve performance, but also means that if the
receiver is recreated, the new receiver may consume events that have already
been processed. It is up to the application owner to evaluate the tradeoff between
performance and reprocessing events.

Even if the application checkpoints after every event, that still
does not completely prevent the possibility of reprocessing an already-consumed
event, because there is always a time window between when an event is processed
and when the checkpoint is fully persisted, during which a node could fail. As a
best practice, an application must be able to cope with event reprocessing in some
way that is reasonable for the impact.
