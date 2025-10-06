# Observable Event Data Batch

This sample demonstrates how to write an `ObservableEventDataBatch` class that wraps an `EventDataBatch` in order to allow an application to read events that have been added to a batch. This is unlike the standard `EventDataBatch` class which restricts the application from accessing `EventData` instances once they have been accepted into the batch. `EventDataBatch` has this limitation to ensure that the state of the batch remains consistent and valid as events are added, and that it can successfully be published.

## Table of contents

- [Considerations](#considerations)
- [Approach](#approach)
    - [Benefits](#benefits)
    - [Trade-offs](#trade-offs)
- [Using the Observable Data Batch](#using-the-observable-data-batch)
- [Note on Client Lifetime](#note-on-client-lifetime)
- [Accessing the EventData Instances](#accessing-the-eventdata-instances)
- [Comparing Identity](#comparing-identity)

## Considerations

While the `ObservableDataBatch` may seem desirable, there are several nuances that should be considered before using it in your application. In order to make sure that once an event is successfully added to the batch it will be sent, the `EventDataBatch` creates a hidden copy of the events which it uses to publish to the Event Hub. Without this, the application could make changes to them, and potentially invalidate the batch size calculations,  making it too large to publish. If `EventDataBatch` held onto the original event after copying and made them accessible, applications altering the events would not be altering the event that was published, and the events that it sees as belonging to the batch would no longer match the actual batch content that will be published. 

Another issue is with equality. `EventData` objects do not have a strong and deterministic way to define equality, since the meaning of two events being equal can be different depending on the application. This creates confusion and can cause unnecessary issues in some applications.

Using this approach **does not** protect from the inherent risks as discussed above, and is not recommended unless the application is willing to assume those risks. If the `EventData` objects exposed through the `Events` property are altered, these changes will **not** be reflected in the events held in the actual Batch. 

## Approach

The most straightforward way to implement this functionality is by creating a class that wraps a normal `EventDataBatch` instance, as well as a read-only list of the events that have been successfully added to the batch. Even though the list itself is read-only, the `EventData` objects are mutable, and if they are changed after the object has been added to the batch, this will **not** be reflected in the actual data stored by the `EventDataBatch` itself. 

```C# Snippet:Sample09_ObservableEventBatch
public class ObservableEventDataBatch : IDisposable
{
    // The set of events that have been accepted into the batch
    private List<EventData> _events = new List<EventData>();

    /// The EventDataBatch being observed
    private EventDataBatch _batch;

    // These events are the source of what is held in the batch.  Though
    // these instances are mutable, any changes made will NOT be reflected to
    // those that had been accepted into the batch
    public IReadOnlyList<EventData> Events { get; }

    public int Count => _batch.Count;
    public long SizeInBytes => _batch.SizeInBytes;
    public long MaximumSizeInBytes => _batch.MaximumSizeInBytes;

    // The constructor requires that sourceBatch is an empty batch so that it can track the events
    // that are being added
    public ObservableEventDataBatch(EventDataBatch sourceBatch)
    {
        _batch = sourceBatch ?? throw new ArgumentNullException(nameof(sourceBatch));
        if (_batch.Count > 0)
        {
            throw new ArgumentException("The sourceBatch is not empty.", nameof(sourceBatch));
        }
        Events = _events.AsReadOnly();
    }

    public bool TryAdd(EventData eventData)
    {
        if (_batch.TryAdd(eventData))
        {
            _events.Add(eventData);
            return true;
        }

        return false;
    }

    public void Dispose() => _batch.Dispose();

    // Performs the needed translation to allow an ObservableEventDataBatch to be
    // implicitly converted to an EventDataBatch
    public static implicit operator EventDataBatch(ObservableEventDataBatch observable) => observable._batch;
}
```

### Benefits

The benefit of this approach is that it utilizes all of the existing methods for managing and publishing events. It takes advantage of the implicit operator functionality in order to return the internal `EventDataBatch` variable, `_batch`, when these methods are called. It also is a straightforward implementation that achieves the goal of allowing events to be seen by the application.

### Trade-offs

The trade-off of this approach is that as mentioned above it does not prevent issues where the two distinct set of events (the actual events contained in the `EventDataBatch` and the visible list of events) go out of sync. There are two ways that this could happen, the first is if the events returned by `ObservableDataBatch.Events` are mutated by the application. The second way this could happen is if `TryAdd` is called on the reference to the `EventDataBatch` after it has been casted from an `ObservableEventDataBatch`, this would call `EventDataBatch.TryAdd()` rather than `ObservableEventDataBatch.TryAdd()` leading to added events being in the actual batch to send that are not reflected in the visible `ObservableDataBatch.Events` variable.

## Using the Observable Data Batch

An `ObservableEventDataBatch` class is useful for any cases where an application would benefit from being able to access which events are in a batch. For example, it can be used to verify an event was added to a given batch or when dealing with failure cases, since the items in a batch that failed can be viewed and then either logged or forwarded. 

## Note on Client Lifetime

An `EventHubProducerClient` is safe to cache and use for the lifetime of the application. `CloseAsync()` is used here since this is a simple example and the client needs to be cleaned up after being used solely to demonstrate a specific behavior. In a real application, creating a new `EventHubProducerClient` on each iteration is **not** the intended use and is inefficient.  

## Accessing the EventData Instances

```C# Snippet:Sample09_AccessingEventData
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();

var producer = new EventHubProducerClient(
    fullyQualifiedNamespace,
    eventHubName,
    credential);

try
{
    using var eventBatch = await producer.CreateBatchAsync();
    var observableBatch = new ObservableEventDataBatch(eventBatch);

    // Attempt to add events to the batch.

    for (var index = 0; index < 5; ++index)
    {
        var eventData = new EventData($"Event #{ index }");

        if (!observableBatch.TryAdd(eventData))
        {
            throw new Exception($"The event at { index } could not be added.");
        }
    }

    // Events in the batch can be inspected using the "Events" collection.

    foreach (var singleEvent in observableBatch.Events)
    {
        Debug.WriteLine($"Added event { singleEvent.EventBody } at time { singleEvent.EnqueuedTime }");
    }

    await producer.SendAsync(observableBatch);
}
finally
{
    await producer.CloseAsync();
}
```

## Comparing Identity

This sample demonstrates how to add an `EventData` identification property that can be used to verify that a given event ID was added to the observable batch. 

```C# Snippet:Sample09_CheckingBatch
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();

var producer = new EventHubProducerClient(
    fullyQualifiedNamespace,
    eventHubName,
    credential);

try
{
    using var eventBatch = await producer.CreateBatchAsync();
    var observableBatch = new ObservableEventDataBatch(eventBatch);

    // Attempt to add events to the batch.

    for (var index = 0; index < 5; ++index)
    {
        var eventData = new EventData($"Event #{ index }")
        {
            MessageId = index.ToString()
        };

        if (!observableBatch.TryAdd(eventData))
        {
            throw new Exception($"The event at { index } could not be added.");
        }
    }

    // The "Events" collection can be used to validate that a specific event
    // is in the batch.  In this example, we'll ensure that an event with
    // id "1" was added.

    var contains = observableBatch.Events
        .Any(eventData => eventData.MessageId == "1");
}
finally
{
    await producer.CloseAsync();
}
```
