<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
Observable Event Data Batch
This sample demonstrates how to write an ObservableEventDataBatch class that wraps an EventDataBatch in order to allow an application to read events that have been added to a batch. This is unlike the standard EventDataBatch class which restricts the application from accessing EventData instances once they have been accepted into the batch. EventDataBatch has this limitation to ensure that the state of the batch remains consistent and valid as events are added, and that it can successfully be published.

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
Considerations
While the ObservableDataBatch may seem desirable, there are several nuances that should be considered before using it in your application. In order to make sure that once an event is successfully added to the batch it will be sent, the EventDataBatch creates a hidden copy of the events which it uses to publish to the Event Hub. Without this, the application could make changes to them, and potentially invalidate the batch size calculations, making it too large to publish. If EventDataBatch held onto the original event after copying and made them accessible, applications altering the events would not be altering the event that was published, and the events that it sees as belonging to the batch would no longer match the actual batch content that will be published.
=======
=======
>>>>>>> 258f9da135 (Update sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample09_ObservableEventBatch.md)
=======
>>>>>>> 7cd2dc7c59 (Updating sample markdown file)
<<<<<<< HEAD
This sample demonstrates how to write an `ObservableEventDataBatch` class that wraps an `EventDataBatch` in order to allow an application to read events that have been added to a batch. This is unlike the standard `EventDataBatch` class which restricts the application from accessing `EventData` instances once they have been accepted into the batch. `EventDataBatch` has this limitation to ensure that the state of the batch remains consistent and valid as events are added, and that it can successfully be published.
>>>>>>> 1b7d8c7eff (Created Sample 9: ObservableEventDataBatch)
=======
# Observable Event Data Batch

This sample demonstrates how to write an `ObservableEventDataBatch` class that wraps an `EventDataBatch` in order to allow an application to read events that have been added to a batch. This is unlike the standard `EventDataBatch` class which restricts the application from accessing `EventData` instances once they have been accepted into the batch. `EventDataBatch` has this limitation to ensure that the state of the batch remains consistent and valid as events are added, and that it can successfully be published.
>>>>>>> 9437b09136 (aligning)

## Considerations

<<<<<<< HEAD
<<<<<<< HEAD
Using this approach does not protect from the inherent risks as discussed above, and is not recommended unless the appplication is willing to assume those risks. If the EventData objects exposed through the Events property are altered, these changes will not be reflected in the events held in the actual Batch.
=======
While the `ObservableDataBatch` may seem desirable, there are several nuances that should be considered before using it in your application. In order to make sure that once an event is successfully added to the batch it will be sent, the `EventDataBatch` creates a hidden copy of the events which it uses to publish to the Event Hub. Without this, the application could make changes to them, and potentially invalidate the batch size calculations,  making it too large to publish. If `EventDataBatch` held onto the original event after copying and made them accessible, applications altering the events would not be altering the event that was published, and the events that it sees as belonging to the batch would no longer match the actual batch content that will be published. 
<<<<<<< HEAD
>>>>>>> 9d1923cfc7 (Finazlied markdown and tests.)
=======
Observable Event Data Batch
This sample demonstrates how to write an ObservableEventDataBatch class that wraps an EventDataBatch in order to allow an application to read events that have been added to a batch. This is unlike the standard EventDataBatch class which restricts the application from accessing EventData instances once they have been accepted into the batch. EventDataBatch has this limitation to ensure that the state of the batch remains consistent and valid as events are added, and that it can successfully be published.

Considerations
While the ObservableDataBatch may seem desirable, there are several nuances that should be considered before using it in your application. In order to make sure that once an event is successfully added to the batch it will be sent, the EventDataBatch creates a hidden copy of the events which it uses to publish to the Event Hub. Without this, the application could make changes to them, and potentially invalidate the batch size calculations, making it too large to publish. If EventDataBatch held onto the original event after copying and made them accessible, applications altering the events would not be altering the event that was published, and the events that it sees as belonging to the batch would no longer match the actual batch content that will be published.

Another issue is with equality. EventData objects do not have a strong and deterministic way to define equality, since the meaning of two events being equal can be different depending on the application. This creates confusion and can cause unnecessary issues in some applications.

Using this approach does not protect from the inherent risks as discussed above, and is not recommended unless the appplication is willing to assume those risks. If the EventData objects exposed through the Events property are altered, these changes will not be reflected in the events held in the actual Batch.
>>>>>>> e32a1e522b (realigning with main)
=======
While the `ObservableDataBatch` may seem desirable, there are several nuances that should be considered before using it in your application. In order to make sure that once an event is successfully added to the batch it will be sent, the `EventDataBatch` creates a hidden copy of the events which it uses to publish to the Event Hub. Without this, the application could make changes to them, and potentially invalidate the batch size calculations,  making it too large to publish. If `EventDataBatch` held onto the original event after copying and made them accessible, applications altering the events would not be altering the event that was published, and the events that it sees as belonging to the batch would no longer match the actual batch content that will be published. 
>>>>>>> 9437b09136 (aligning)

Another issue is with equality. `EventData` objects do not have a strong and deterministic way to define equality, since the meaning of two events being equal can be different depending on the application. This creates confusion and can cause unnecessary issues in some applications.

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> 9437b09136 (aligning)
Using this approach **does not** protect from the inherent risks as discussed above, and is not recommended unless the appplication is willing to assume those risks. If the `EventData` objects exposed through the `Events` property are altered, these changes will **not** be reflected in the events held in the actual Batch. 

## Approach

The most straightforward way to implement this functionality is by creating a class that wraps a normal `EventDataBatch` instance, as well as a read-only list of the events that have been successfully added to the batch. Even though the list itself is read-only, the `EventData` objects are mutable, and if they are changed after the object has been added to the batch, this will **not** be reflected in the actual data stored by the `EventDataBatch` itself. 
<<<<<<< HEAD
=======
This sample demonstrates how to write an `ObservableEventDataBatch` wrapper class that allows an application to read events that have been added to a batch. This is unlike the standard `EventDataBatch` class which restricts the application from accessing `EventData` instances once they have been added successfully. There are two main reasons for this. The first being due to the goal of the `EventDataBatch` class, which is to verify that a batch of events does not exceed the size limits set by the `EventHub`. The second reason for this stems from the mutable nature of  `EventData` objects. 
=======
This sample demonstrates how to write an `ObservableEventDataBatch` class wraps an `EventDataBatch` to allow an application to read events that have been added to a batch. This is unlike the standard `EventDataBatch` class which restricts the application from accessing `EventData` instances once they have been accepted into the batch. `EventDataBatch` has this limitation to ensure that the state of the batch remains consistent and valid as events are added, and that it can successfully be published.
>>>>>>> 5f6270b5b2 (Update sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample09_ObservableEventBatch.md)
=======
This sample demonstrates how to write an `ObservableEventDataBatch` class that wraps an `EventDataBatch` in order to allow an application to read events that have been added to a batch. This is unlike the standard `EventDataBatch` class which restricts the application from accessing `EventData` instances once they have been accepted into the batch. `EventDataBatch` has this limitation to ensure that the state of the batch remains consistent and valid as events are added, and that it can successfully be published.
>>>>>>> ddf3954aa8 (Updating sample markdown file)

## Considerations

While the `ObservableDataBatch` may seem desirable, there are several nuances that should be considered before using it in your application.   In order to make sure that once an event is successfully added to the batch it will be sent, the `EventDataBatch` creates a hidden copy of the events which it uses to publish to the Event Hub. Without this, the application could make changes to them, and potentially invalidate the batch size calculations,  making it too large to publish.   If `EventDataBatch` held onto the original event after copying and made them accessible, applications altering the events would not be altering the event that was published, and the events that it sees as belonging to the batch would no longer match the actual batch content that will be published. 
=======
>>>>>>> 6042d466b7 (Finazlied markdown and tests.)

Another issue is with equality. `EventData` objects do not have a strong and deterministic way to define equality, since the meaning of two events being equal can be different depending on the application. This creates confusion and can cause unnecessary issues in some applications.

Using this approach **does not** protect from the inherent risks as discussed above, and is not recommended unless the appplication is willing to assume those risks. If the `EventData` objects exposed through the `Events` property are altered, these changes will **not** be reflected in the events held in the actual Batch. 

## Approach

<<<<<<< HEAD
<<<<<<< HEAD
=======
# Observable Event Data Batch

This sample demonstrates how to write an `ObservableEventDataBatch` class that wraps an `EventDataBatch` in order to allow an application to read events that have been added to a batch. This is unlike the standard `EventDataBatch` class which restricts the application from accessing `EventData` instances once they have been accepted into the batch. `EventDataBatch` has this limitation to ensure that the state of the batch remains consistent and valid as events are added, and that it can successfully be published.

## Considerations

While the `ObservableDataBatch` may seem desirable, there are several nuances that should be considered before using it in your application. In order to make sure that once an event is successfully added to the batch it will be sent, the `EventDataBatch` creates a hidden copy of the events which it uses to publish to the Event Hub. Without this, the application could make changes to them, and potentially invalidate the batch size calculations,  making it too large to publish. If `EventDataBatch` held onto the original event after copying and made them accessible, applications altering the events would not be altering the event that was published, and the events that it sees as belonging to the batch would no longer match the actual batch content that will be published. 

Another issue is with equality. `EventData` objects do not have a strong and deterministic way to define equality, since the meaning of two events being equal can be different depending on the application. This creates confusion and can cause unnecessary issues in some applications.

Using this approach **does not** protect from the inherent risks as discussed above, and is not recommended unless the appplication is willing to assume those risks. If the `EventData` objects exposed through the `Events` property are altered, these changes will **not** be reflected in the events held in the actual Batch. 

## Approach

<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
The most straightforward way to implement this functionality is by creating a class that holds a normal `EventDataBatch` instance, as well as a readonly list of the events that have been successfully added to the batch. Even though the list itself is readonly, the `EventData` objects are not, and if they are changed after the object has been added to the batch, this will NOT be reflected in the actual data stored by the `EventDataBatch` itself. 

#### Benefits

The benefit of this approach is that it utilizes all of the existing methods for sending and publishing events. It takes advantage of the implicit operator functionality in order to return the internal `EventDataBatch` variable, `_batch`, when these methods are called. It also is a straightfoward implementation that achieves the goal of allowing events to be seen by the application.

#### Trade-offs

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
The trade-off of this approach is that as mentioned above it does not prevent issues where the two disntinct set of events (the actual `EventBatch` events and the visible list of events) go out of sync. There are two ways that this could happen, the first is if the events returned by `ObservableDataBatch.Events` are mutated by the application. The second way this could happen is if `TryAdd` is called on the reference to the `EventDataBatch` after it has been casted, this would call `EventDataBatch.TryAdd()` rather than `ObservableEventDataBatch.TryAdd()` leading to the events being in the batch that are not reflected in the visible `ObservableDataBatch.Events` variable.
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
The trade-off of this approach is that as mentioned above it does not prevent issues where the two disntinct set of events (the actual `EventBatch` events and the visible list of events) go out of sync. There are two ways that this could happen, the first is if the events returned by `ObservableDataBatch.Events` are mutated by the application. The second way this could happen is if `TryAdd` is called on the reference to the `EventDataBatch` after it has been casted from an `ObservableEventDataBatch`, this would call `EventDataBatch.TryAdd()` rather than `ObservableEventDataBatch.TryAdd()` leading to added events being in the actual batch to send that are not reflected in the visible `ObservableDataBatch.Events` variable.
>>>>>>> 7ce52fc75e (Sample for ObservableEventDataBatch)
=======
The most straightforward way to implement this functionality is by creating a class that wraps a normal `EventDataBatch` instance, as well as a read-only list of the events that have been successfully added to the batch. Even though the list itself is readonly, the `EventData` objects are not, and if they are changed after the object has been added to the batch, this will NOT be reflected in the actual data stored by the `EventDataBatch` itself. 
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
=======
The most straightforward way to implement this functionality is by creating a class that wraps a normal `EventDataBatch` instance, as well as a read-only list of the events that have been successfully added to the batch. Even though the list itself is read-only, the `EventData` objects are mutable, and if they are changed after the object has been added to the batch, this will **not** be reflected in the actual data stored by the `EventDataBatch` itself. 
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
The trade-off of this approach is that as mentioned above it does not prevent issues where the two disntinct set of events (the actual `EventBatch` events and the visible list of events) go out of sync. There are two ways that this could happen, the first is if the events returned by `ObservableDataBatch.Events` are mutated by the application. The second way this could happen is if `TryAdd` is called on the reference to the `EventDataBatch` after it has been casted from an `ObservableEventDataBatch`, this would call `EventDataBatch.TryAdd()` rather than `ObservableEventDataBatch.TryAdd()` leading to added events being in the actual batch to send that are not reflected in the visible `ObservableDataBatch.Events` variable.
>>>>>>> 7ce52fc75e (Sample for ObservableEventDataBatch)

```C# Snippet:Sample09_ObservableEventBatch
>>>>>>> 1b7d8c7eff (Created Sample 9: ObservableEventDataBatch)
=======
>>>>>>> e32a1e522b (realigning with main)
=======

```C# Snippet:Sample09_ObservableEventBatch
>>>>>>> 9437b09136 (aligning)
public class ObservableEventDataBatch : IDisposable
{
    // The set of events that have been accepted into the batch
    private List<EventData> _events = new List<EventData>();
<<<<<<< HEAD
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
=======
The trade-off of this approach is that as mentioned above it does not prevent issues where the two disntinct set of events (the actual `EventBatch` events and the visible list of events) go out of sync. There are two ways that this could happen, the first is if the events returned by `ObservableDataBatch.Events` are mutated by the application. The second way this could happen is if `TryAdd` is called on the reference to the `EventDataBatch` after it has been casted, this would call `EventDataBatch.TryAdd()` rather than `ObservableEventDataBatch.TryAdd()` leading to the events being in the batch that are not reflected in the visible `ObservableDataBatch.Events` variable.
=======
The most straightforward way to implement this functionality is by creating a class that wraps a normal `EventDataBatch` instance, as well as a read-only list of the events that have been successfully added to the batch. Even though the list itself is readonly, the `EventData` objects are not, and if they are changed after the object has been added to the batch, this will NOT be reflected in the actual data stored by the `EventDataBatch` itself. 
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
=======
The most straightforward way to implement this functionality is by creating a class that wraps a normal `EventDataBatch` instance, as well as a read-only list of the events that have been successfully added to the batch. Even though the list itself is read-only, the `EventData` objects are mutable, and if they are changed after the object has been added to the batch, this will **not** be reflected in the actual data stored by the `EventDataBatch` itself. 
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)

```C# Snippet:Sample09_ObservableEventBatch
public class ObservableEventDataBatch : IDisposable
{
    // The set of events that have been accepted into the batch
<<<<<<< HEAD
    private List<EventData> _events = new();
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
    private List<EventData> _events = new List<EventData>();
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
=======
>>>>>>> e32a1e522b (realigning with main)

    /// The EventDataBatch being observed
    private EventDataBatch _batch;

    // These events are the source of what is held in the batch.  Though
    // these instances are mutable, any changes made will NOT be reflected to
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    // those that had been accepted into the batch
=======
    // those that had been accepted into the batch.
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
    // those that had been accepted into the batch
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
=======
    // those that had been accepted into the batch.
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
    // those that had been accepted into the batch
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
=======
    // those that had been accepted into the batch
>>>>>>> e32a1e522b (realigning with main)
    public IReadOnlyList<EventData> Events { get; }

    public int Count => _batch.Count;
    public long SizeInBytes => _batch.SizeInBytes;
    public long MaximumSizeInBytes => _batch.MaximumSizeInBytes;

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    // The constructor requires that sourceBatch is an empty batch so that it can track the events
    // that are being added
=======
    // The constructor requires that sourceBatch is an empty batch so that it can track the events 
    // that are being added. 
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
=======
>>>>>>> e32a1e522b (realigning with main)
    // The constructor requires that sourceBatch is an empty batch so that it can track the events
    // that are being added
<<<<<<< HEAD
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
=======
    // The constructor requires that sourceBatch is an empty batch so that it can track the events 
    // that are being added. 
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
    // The constructor requires that sourceBatch is an empty batch so that it can track the events
<<<<<<< HEAD
    // that are being added.
>>>>>>> 191049bfb8 (Running Snippet Generator)
=======
    // that are being added
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
=======
>>>>>>> e32a1e522b (realigning with main)
    public ObservableEventDataBatch(EventDataBatch sourceBatch)
    {
        _batch = sourceBatch ?? throw new ArgumentNullException(nameof(sourceBatch));
        if (_batch.Count > 0)
        {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            throw new ArgumentException("The sourceBatch is not empty.", nameof(sourceBatch));
=======
            throw new ArgumentException("sourceBatch is not an empty EventBatch");
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
            throw new ArgumentException("The sourceBatch is not empty.", nameof(sourceBatch));
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
=======
            throw new ArgumentException("sourceBatch is not an empty EventBatch");
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
=======
>>>>>>> e32a1e522b (realigning with main)
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

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> e32a1e522b (realigning with main)
    // Performs the needed translation to allow an ObservableEventDataBatch to be
    // implicitly converted to an EventDataBatch
    public static implicit operator EventDataBatch(ObservableEventDataBatch observable) => observable._batch;
}
<<<<<<< HEAD
Benefits
The benefit of this approach is that it utilizes all of the existing methods for managing and publishing events. It takes advantage of the implicit operator functionality in order to return the internal EventDataBatch variable, _batch, when these methods are called. It also is a straightforward implementation that achieves the goal of allowing events to be seen by the application.
<<<<<<< HEAD
=======
```

### Benefits

The benefit of this approach is that it utilizes all of the existing methods for managing and publishing events. It takes advantage of the implicit operator functionality in order to return the internal `EventDataBatch` variable, `_batch`, when these methods are called. It also is a straightforward implementation that achieves the goal of allowing events to be seen by the application.

### Trade-offs
>>>>>>> 9437b09136 (aligning)

The trade-off of this approach is that as mentioned above it does not prevent issues where the two distinct set of events (the actual events contained in the `EventDataBatch` and the visible list of events) go out of sync. There are two ways that this could happen, the first is if the events returned by `ObservableDataBatch.Events` are mutated by the application. The second way this could happen is if `TryAdd` is called on the reference to the `EventDataBatch` after it has been casted from an `ObservableEventDataBatch`, this would call `EventDataBatch.TryAdd()` rather than `ObservableEventDataBatch.TryAdd()` leading to added events being in the actual batch to send that are not reflected in the visible `ObservableDataBatch.Events` variable.

### Using the Observable Data Batch

An `ObservableEventDataBatch` class is useful for any cases where an application would benefit from being able to access which events are in a batch. For example, it can be used to verify an event was added to a given batch or when dealing with failure cases, since the items in a batch that failed can be viewed and then either logged or forwarded. 

### Note on Client Lifetime

An `EventHubProducerClient` is safe to cache and use for the lifetime of the application. `CloseAsync()` is used here since this is a simple example and the client needs to be cleaned up after being used solely to demonstrate a specific behavior. In a real application, creating a new `EventHubProducerClient` on each iteration is **not** the intended use and is inefficient.  

#### Accessing the EventData Instances

```C# Snippet:Sample09_AccessingEventData
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
=======
    // Performs the needed transation to allow an ObservableEventDataBatch to be
    // implicitly converted to an EventDataBatch
    public static implicit operator EventDataBatch(ObservableEventDataBatch observable) => observable._batch;
}
```

### Benefits

The benefit of this approach is that it utilizes all of the existing methods for managing and publishing events. It takes advantage of the implicit operator functionality in order to return the internal `EventDataBatch` variable, `_batch`, when these methods are called. It also is a straightforward implementation that achieves the goal of allowing events to be seen by the application.

### Trade-offs

The trade-off of this approach is that as mentioned above it does not prevent issues where the two distinct set of events (the actual events contained in the `EventDataBatch` and the visible list of events) go out of sync. There are two ways that this could happen, the first is if the events returned by `ObservableDataBatch.Events` are mutated by the application. The second way this could happen is if `TryAdd` is called on the reference to the `EventDataBatch` after it has been casted from an `ObservableEventDataBatch`, this would call `EventDataBatch.TryAdd()` rather than `ObservableEventDataBatch.TryAdd()` leading to added events being in the actual batch to send that are not reflected in the visible `ObservableDataBatch.Events` variable.

### Using the Observable Data Batch

An `ObservableEventDataBatch` class is useful for any cases where an application would benefit from being able to access which events are in a batch. For example, it can be used to verify an event was added to a given batch or when dealing with failure cases, since the items in a batch that failed can be viewed and then either logged or forwarded. 

### Note on Client Lifetime

An `EventHubProducerClient` is safe to cache and use for the lifetime of the application. `CloseAsync()` is used here since this is a simple example and the client needs to be cleaned up after being used solely to demonstrate a specific behavior. In a real application, creating a new `EventHubProducerClient` on each iteration is **not** the intended use and is inefficient.  

#### Accessing the EventData Instances

```C# Snippet:Sample09_AccessingEventData
<<<<<<< HEAD
<<<<<<< HEAD
var connectionString = "<<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>>";
var eventHubName = "<<< NAME OF THE EVENT HUB >>>";
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
=======
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
>>>>>>> 08f15d3176 (Updating snippet definitions)
var eventHubName = "<< NAME OF THE EVENT HUB >>";
<<<<<<< HEAD
>>>>>>> 191049bfb8 (Running Snippet Generator)

=======
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
    // Performs the needed transation to allow an ObservableEventDataBatch to be
    // implicitly converted to an EventDataBatch
    public static implicit operator EventDataBatch(ObservableEventDataBatch observable) => observable._batch;
}
```

### Benefits
=======
>>>>>>> e32a1e522b (realigning with main)

Trade-offs
The trade-off of this approach is that as mentioned above it does not prevent issues where the two distinct set of events (the actual events contained in the EventDataBatch and the visible list of events) go out of sync. There are two ways that this could happen, the first is if the events returned by ObservableDataBatch.Events are mutated by the application. The second way this could happen is if TryAdd is called on the reference to the EventDataBatch after it has been casted from an ObservableEventDataBatch, this would call EventDataBatch.TryAdd() rather than ObservableEventDataBatch.TryAdd() leading to added events being in the actual batch to send that are not reflected in the visible ObservableDataBatch.Events variable.

Using the Observable Data Batch
An ObservableEventDataBatch class is useful for any cases where an application would benefit from being able to access which events are in a batch. For example, it can be used to verify an event was added to a given batch or when dealing with failure cases, since the items in a batch that failed can be viewed and then either logged or forwarded.

Note on Client Lifetime
An EventHubProducerClient is safe to cache and use for the lifetime of the application. CloseAsync() is used here since this is a simple example and the client needs to be cleaned up after being used solely to demonstrate a specific behavior. In a real application, creating a new EventHubProducerClient on each iteration is not the intended use and is inefficient.

<<<<<<< HEAD
### Using the Observable Data Batch

An `ObservableEventDataBatch` class is useful for any cases where an application would benefit from being able to access which events are in a batch. For example, it can be used to verify an event was added to a given batch or when dealing with failure cases, since the items in a batch that failed can be viewed and then either logged or forwarded. 

### Note on Client Lifetime

An `EventHubProducerClient` is safe to cache and use for the lifetime of the application. `CloseAsync()` is used here since this is a simple example and the client needs to be cleaned up after being used solely to demonstrate a specific behavior. In a real application, creating a new `EventHubProducerClient` on each iteration is **not** the intended use and is inefficient.  

#### Accessing the EventData Instances

```C# Snippet:Sample09_AccessingEventData
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
<<<<<<< HEAD

>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
Accessing the EventData Instances
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

>>>>>>> e32a1e522b (realigning with main)
var producer = new EventHubProducerClient(connectionString, eventHubName);

try
{
    using var eventBatch = await producer.CreateBatchAsync();
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> e32a1e522b (realigning with main)
    var observableBatch = new ObservableEventDataBatch(eventBatch);

    // Attempt to add events to the batch.

    for (var index = 0; index < 5; ++index)
    {
        var eventData = new EventData($"Event #{ index }");

        if (!observableBatch.TryAdd(eventData))
<<<<<<< HEAD
=======
    ObservableEventDataBatch newbatch = new ObservableEventDataBatch(eventBatch);
=======
    var newBatch = new ObservableEventDataBatch(eventBatch);
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)

    // Adding events to the batch
=======
    ObservableEventDataBatch newbatch = new ObservableEventDataBatch(eventBatch);

>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
    var newBatch = new ObservableEventDataBatch(eventBatch);

    // Adding events to the batch
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
    for (var index = 0; index < 5; ++index)
    {
        var eventBody = new BinaryData($"Event #{ index }");
        var eventData = new EventData(eventBody);

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        if (!newbatch.TryAdd(eventData))
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
        if (!newBatch.TryAdd(eventData))
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
        if (!newbatch.TryAdd(eventData))
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
        if (!newBatch.TryAdd(eventData))
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
>>>>>>> e32a1e522b (realigning with main)
        {
            throw new Exception($"The event at { index } could not be added.");
        }
    }

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    // Events in the batch can be inspected using the "Events" collection.

    foreach (var singleEvent in observableBatch.Events)
=======
    foreach (var singleEvent in newbatch.Events)
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
    // Looping through the events to demonstrate how to access them
    foreach (var singleEvent in newBatch.Events)
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
    foreach (var singleEvent in newbatch.Events)
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
    // Looping through the events to demonstrate how to access them
    foreach (var singleEvent in newBatch.Events)
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
    // Events in the batch can be inspected using the "Events" collection.

    foreach (var singleEvent in observableBatch.Events)
>>>>>>> e32a1e522b (realigning with main)
    {
        Debug.WriteLine($"Added event { singleEvent.EventBody } at time { singleEvent.EnqueuedTime }");
    }

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    await producer.SendAsync(observableBatch);
=======
    await producer.SendAsync(newbatch);
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
    await producer.SendAsync(newBatch);
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
    await producer.SendAsync(newbatch);
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
    await producer.SendAsync(newBatch);
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
    await producer.SendAsync(observableBatch);
>>>>>>> e32a1e522b (realigning with main)
}
finally
{
    await producer.CloseAsync();
}
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
Comparing Identity
This sample demonstrates how to add an EventData identification property that can be used to verify that a given event ID was added to the observable batch.

=======
=======
>>>>>>> d00595ab99 (Running Snippet Generator)
<<<<<<< HEAD
=======

>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
>>>>>>> 191049bfb8 (Running Snippet Generator)
=======

>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
>>>>>>> 191049bfb8 (Running Snippet Generator)
```

#### Comparing Identity

This sample demonstrates how to add an `EventData` identification property that can be used to verify that a given event ID was added to the observable batch. 
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)

```C# Snippet:Sample09_CheckingBatch
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 1b7d8c7eff (Created Sample 9: ObservableEventDataBatch)
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
=======
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
>>>>>>> a8de57caec (Updating snippet definitions)
=======
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
>>>>>>> 93a7e9a8a1 (Updating formatting)
var eventHubName = "<< NAME OF THE EVENT HUB >>";
<<<<<<< HEAD

<<<<<<< HEAD
=======
```C# Snippet: Sample09_CheckingBatch
=======
```C# Snippet:Sample09_CheckingBatch
>>>>>>> 294971195d (Fixing Typo in Snippet)
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
>>>>>>> 191049bfb8 (Running Snippet Generator)
=======
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
```C# Snippet: Sample09_CheckingBatch
=======
```C# Snippet:Sample09_CheckingBatch
<<<<<<< HEAD
>>>>>>> 294971195d (Fixing Typo in Snippet)
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
=======
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
>>>>>>> 08f15d3176 (Updating snippet definitions)
var eventHubName = "<< NAME OF THE EVENT HUB >>";
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======

>>>>>>> 191049bfb8 (Running Snippet Generator)
=======
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
Comparing Identity
This sample demonstrates how to add an EventData identification property that can be used to verify that a given event ID was added to the observable batch.
=======
```
>>>>>>> 9437b09136 (aligning)

#### Comparing Identity

This sample demonstrates how to add an `EventData` identification property that can be used to verify that a given event ID was added to the observable batch. 

```C# Snippet:Sample09_CheckingBatch
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

>>>>>>> e32a1e522b (realigning with main)
var producer = new EventHubProducerClient(connectionString, eventHubName);

try
{
    using var eventBatch = await producer.CreateBatchAsync();
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> e32a1e522b (realigning with main)
    var observableBatch = new ObservableEventDataBatch(eventBatch);

    // Attempt to add events to the batch.

    for (var index = 0; index < 5; ++index)
    {
        var eventData = new EventData($"Event #{ index }")
        {
            MessageId = index.ToString()
        };

        if (!observableBatch.TryAdd(eventData))
<<<<<<< HEAD
=======
    ObservableEventDataBatch newbatch = new ObservableEventDataBatch(eventBatch);
=======
    var newBatch = new ObservableEventDataBatch(eventBatch);
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)

    // Adding events to the batch
=======
    ObservableEventDataBatch newbatch = new ObservableEventDataBatch(eventBatch);

>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
    var newBatch = new ObservableEventDataBatch(eventBatch);

    // Adding events to the batch
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
    for (var index = 0; index < 5; ++index)
    {
        var eventBody = new BinaryData($"Event #{ index }");
        var eventData = new EventData(eventBody);
<<<<<<< HEAD
<<<<<<< HEAD
        eventData.Properties.Add("ApplicationId", index);

<<<<<<< HEAD
<<<<<<< HEAD
        if (!newbatch.TryAdd(eventData))
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
        if (!newBatch.TryAdd(eventData))
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
        eventData.Properties.Add("ApplicationID", index);
=======
        eventData.Properties.Add("ApplicationId", index);
>>>>>>> 08f15d3176 (Updating snippet definitions)

        if (!newbatch.TryAdd(eventData))
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
        if (!newBatch.TryAdd(eventData))
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
>>>>>>> e32a1e522b (realigning with main)
        {
            throw new Exception($"The event at { index } could not be added.");
        }
    }

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> e32a1e522b (realigning with main)
    // The "Events" collection can be used to validate that a specific event
    // is in the batch.  In this example, we'll ensure that an event with
    // id "1" was added.

    var contains = observableBatch.Events
        .Any(eventData => eventData.MessageId == "1");
<<<<<<< HEAD
=======
    //check if event 1 is in the batch
<<<<<<< HEAD
=======
    //check if event 1 is in the batch
<<<<<<< HEAD
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
    var contains = false;
    foreach (var singleEvent in newbatch.Events)
    {
        contains = contains || (Int32.TryParse(singleEvent.Properties["ApplicationID"].ToString(), out Int32 id) && id == 1);
    }
<<<<<<< HEAD
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
=======
    // Verify that the expected event is in the batch
<<<<<<< HEAD
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
    var contains = newbatch.Events.Any(eventData => int
    .TryParse(eventData.Properties["ApplicationId"].ToString(), out var id) && id == 1);
>>>>>>> 08a0c24d4f (Cleaning up tests.)
=======
    var contains = newBatch.Events.Any(eventData => int.TryParse(eventData.Properties["ApplicationId"].ToString(), out var id) && id == 1);
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
=======
    // Verify that the expected event is in the batch
<<<<<<< HEAD
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
    var contains = newbatch.Events.Any(eventData => int
    .TryParse(eventData.Properties["ApplicationId"].ToString(), out var id) && id == 1);
>>>>>>> 08a0c24d4f (Cleaning up tests.)
=======
    var contains = newBatch.Events.Any(eventData => int.TryParse(eventData.Properties["ApplicationId"].ToString(), out var id) && id == 1);
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
>>>>>>> e32a1e522b (realigning with main)
}
finally
{
    await producer.CloseAsync();
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
}
=======
}
```
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
}
```
<<<<<<< HEAD
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)

# Extensions Methods 

An alternative method to creating an Observable `EventDataBatch` would be by writing extensions methods to add to the `EventHubProducerClient` that create and publish the `ObservableEventDataBatch`. This avoids the need to have implicit casting and therefore removes one of the sources of out of sync event lists.

This method is effective but is more complex and requires more careful implementation. It also does not fully eliminate the issue of the out of sync `EventData`, therefore it is not included in this sample. 
<<<<<<< HEAD
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
<<<<<<< HEAD
>>>>>>> 1b7d8c7eff (Created Sample 9: ObservableEventDataBatch)
=======
=======
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
>>>>>>> 879e65ff39 (Updated tests and markdown to respond to comments.)
=======
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
=======
}
>>>>>>> e32a1e522b (realigning with main)
=======
}
```
>>>>>>> 9437b09136 (aligning)
