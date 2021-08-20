# Buffered Producer Client: Proposal

Publishing events using the `EventHubProducerClient` is optimized for high and consistent throughput scenarios where an application would like to assert control over collecting events into batches and the decision of when those batches are sent to Event Hubs.  Developers are expected to build and manage batches according to the needs of their application, while taking into account the constraints that Event Hubs places on which events may be batched together.  This allows developers to prioritize trade-offs between ensuring batch density, enforcing strict ordering of events, and publishing on a consistent and predictable schedule.

Feedback from developers has indicated that this approach quickly becomes complicated in real-world applications and demands applications bear the burden of that complexity.  A frequent ask is for the Event Hubs client library to include functionality to abstract that complexity away from applications and manage batching, concurrency, and sending implicitly.  Essentially, developers have let us know that they would like a higher-level type similar to the event processor, but for publishing events rather than consuming them.

With these needs in mind, this has become the primary goal of the proposed `EventHubBufferedProducerClient`. Specifically, it will allow developers to enqueue events to be efficiently published without being burdened by managing batches or needing a deep understanding of Event Hubs partitioning.  The `EventHubBufferedProducerClient` will provide a simplified API for publishing and offer consistent performance regardless of the pattern of events being enqueued.

## Things to know before reading

- The names used in this document are intended for illustration only. Some names are not ideal and will need to be refined during discussions.

- Some details not related to the high-level concept are not illustrated; the scope of this is limited to the high level shape and paradigms for the feature area.

- Fake methods are used to illustrate "something needs to happen, but the details are unimportant."  As a general rule, if an operation is not directly related to one of the Event Hubs types, it can likely be assumed that it is for illustration only.  These methods will most often use ellipses for the parameter list, in order to help differentiate them.

## Why this is needed

When applications publish events to Event Hubs using the `EventHubProducerClient`, they hold responsibility for managing the major aspects of the publishing flow.  For example, to publish efficiently they have to manually build event batches and ensure they’re published at the appropriate time to maintain throughput.  Applications must also understand the semantics of the service if they wish to publish concurrently and maintain ordering of events.  Applications are also responsible for detecting scenarios when back pressure is needed and implementing the logic to apply it.  For many applications, this can lead to unwanted complexity and infrastructure to manage that complexity.

The buffered producer aims to address this by allowing developers to simply enqueue events to be sent.  The producer transparently manages batches, publishing in an efficient manner, concurrency when ordering can be preserved, and applying back pressure when events are being enqueued more quickly than publishing can handle.   It also allows the ability for applications to enqueue a single event and supports implicit batching for efficiency, a frequent customer request.

When looking at available cloud messaging services, all but Event Hubs have a client that provides functionality for implicit batching.  The buffered producer would fill this gap. One such example is Kafka's producer, which provides similar semantics for enqueuing events while implicitly batching and publishing in the background.  To read more about the Kafka producer see their [documentation](https://kafka.apache.org/10/javadoc/org/apache/kafka/clients/producer/KafkaProducer.html).  The final section in this proposal, [the competitive analysis](#competitive-analysis-kafka ), goes into more detail about the Kafka producer as compared to the buffered producer.

## Goals

Allow developers to enqueue events to be efficiently published without being burdened with managing batches or needing a deep understanding of Event Hubs partitioning. Publishing behavior should be understandable and performance consistent regardless of the pattern of events being enqueued.

## High level scenarios

### User telemetry 

A shopping website wants to determine how users interact with their images, suggested products section, and reviews. To do this they gather telemetry data from each user as they are performing actions on the site, such as clicking buttons or using drop-downs. The user behavior data is collected through an Event Hub. The data frequency and volume varies greatly with a user's activity and is not predictable. 

The buffered producer allows this to happen seamlessly. When the user is actively interacting with the website, batches will be filled and sent right away, whereas if the user were to step away from the computer or pause interaction to read on the page for awhile, the batch may need to be sent partially empty. This takes advantage of the timeout and batch construction features found in the buffered producer. 

### Online radio station listeners

An online radio application requires an account to use. The account has limited demographic information about each user such as an age range, gender, and general regional location. For the first 15 seconds of every song played the application allows the radio station to observe how many listeners change the song at each second. They also observe the key, genre, artist, and tempo of the song, as well as demographics about which users changed the station. The application publishes all of this data to be aggregated, so that the application can better select songs to cater to their targeted audience. 

Since each person's profile is an individual event that is not dependent on any other person's profile, the application would like to just publish each profile to an Event Hub when they switch away from the song in the first 15 seconds. For the rest of the song the application doesn't publish any events, since it's just trying to analyze user's first reaction to the song, and how it changes over time. In order to maximize throughput the application publishes events by queueing them one at a time, since sometimes there may be many people changing the station and sometimes there are only a few. This takes advantage of the buffered producer since not all batches of events will be full and there are long gaps in between spurts of events being published.

### Processing activity sign-ups 

A large summer community sports club uses an application to process member sign-ups for golfing, swimming, tennis, and other activity slots. Time slots for all of the activities open up at 10:00 am Sunday morning for the upcoming week. Since this club services a large community, all of the slots fill up quickly and there are a lot of people submitting requests as soon as the slots open up. An individual member can submit requests for multiple events on multiple days at once, and if they have a family membership, they can do this for all of the members of their family at once.

Each of these sign-ups are individual, if a member submits requests to play tennis every morning of the week at 9:00 am, it's possible that only some days are accepted if others are processed first. The application uses an Event Hub to publish all of the events from each member and determine if there is space for that member to do the activity at that time. All of the events for a certain activity are sent to a specific partition. The application does this by using the buffered producer to publish each event to its designated partition. This scenario takes advantage of the buffered producer's functionality by queueing events by activity as they arrive. Since many arrive at once, and then very sparsely after that, it's very useful for the application to be able to just queue them as they arrive and when there are a lot of events they will send right away, and then when there are less the batches can be sent on timeout instead.

### Kafka developers working with Event Hubs 

When creating an application that leverages Azure, developers familiar with Kafka may choose to use the Kafka client library with the Event Hubs compatibility layer in order to pursue a familiar development experience and avoid the learning curve of a new service.  Because the publishing models align, a Kafka developer working with the Event Hubs buffered producer is able to leverage their existing knowledge and use familiar patterns for publishing events, reducing the learning curve and helping to deliver their Azure-based application more quickly.  This allows the developer to more fully embrace the Azure ecosystem and take advantage of cross-library concepts, such as `Azure.Identity` integration and a common diagnostics platform.  For applications taking advantage of multiple Azure services, this unlocks greater cohesion across areas of the application and a more consistent experience overall.

## Key concepts

- The producer holds responsibility for implicitly batching events and publishing efficiently.

- Each event queued for publishing is considered individual; there is no support for bundling events and forcing them to be batched together. 

- The buffer functionality should be contained in a dedicated client type; the `EventHubProducerClient` API should not be made more complicated by supporting two significantly different sets of publishing semantics and guarantees.  

## Usage examples

The buffered producer supports the same set of constructors that are allowed by the `EventHubProducerClient`.

### Creating a buffered producer with default options

```csharp
var connectionString = "<< CONNECTION STRING >>";
var eventHubName = "<< EVENT HUB NAME >>";

// Create the buffered producer with default options
var producer = new EventHubBufferedProducerClient(connectionString, eventHubName);
```

### Creating the client with custom options

Like each of the Event Hubs clients, the buffered producer supports a rich set of options for influencing it's behavior to suit application needs.  For example, developers may adjust the interval used to flush when no new events are enqueued, the amount of concurrent sends permitted, and enable idempotent retries in addition to the standard connection and retry options.

```csharp  
var connectionString = "<< CONNECTION STRING >>";
var eventHubName = "<< EVENT HUB NAME >>";

// Create the buffered producer
var producer = new EventHubBufferedProducerClient(connectionString, eventHubName, new EventHubBufferedProducerClientOptions
{
    Identifier = "My Custom buffered producer",
    MaximumConcurrentSendsPerPartition = 5,
    EnableIdempotentRetries = false,
    MaximumWaitTime = TimeSpan.FromMilliseconds(500),
    MaximumBufferedEventCount = 500
    RetryOptions = new EventHubsRetryOptions { MaximumRetries = 25,  TryTimeout = TimeSpan.FromMinutes(5)  }
});    
```

### Creating the client with an Azure.Identity credential

```csharp
var credential = new DefaultAzureCredential();
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.eventhub.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

// Create the buffered producer with default options
var producer = new EventHubBufferedProducerClient(fullyQualifiedNamespace, eventHubName, credential);
```

### Publish events using the buffered producer

```csharp
// Create the buffered producer
var producer = new EventHubBufferedProducerClient("<< CONNECTION STRING >>", "<< EVENT HUB NAME >>");

// Define the Handlers
Task SendSuccessfulHandler(SendEventBatchSuccessEventArgs args) { ... }
Task SendFailedHandler(SendEventBatchFailedEventArgs args) { ... }

// Add the handlers to the producer
producer.SendEventBatchSucceededAsync += SendSuccessfulHandler;
producer.SendEventBatchFailedAsync += SendFailedHandler;

try
{
    // Enqueue events to be sent
    while (TryGetEvent(out var eventData))
    {
        await producer.EnqueueEventAsync(eventData);
    }
}
finally
{
    // By default, close sends all pending queued events and then shuts down the producer
    await producer.CloseAsync();
}
```

### Publish a set of events using the buffered producer

If the application would like to enqueue events as a set, the buffered producer provides an overload for this. An important thing to note, however, is that events queued together will not necessarily be sent in the same batch. This allows the application to enqueue as many events as they want without worrying about the size of a batch. 

```csharp
// Create the buffered producer
var producer = new EventHubBufferedProducerClient("<< CONNECTION STRING >>", "<< EVENT HUB NAME >>");

// Define the Handlers
Task SendSuccessfulHandler(SendEventBatchSuccessEventArgs args) {...}
Task SendFailedHandler(SendEventBatchFailedEventArgs args) {...}

// Add the handlers to the producer
producer.SendEventBatchSucceededAsync += SendSuccessfulHandler;
producer.SendEventBatchFailedAsync += SendFailedHandler;

try
{
    // Enqueue a set of events
    var largeSetOfEvents = GenerateEvents(...);    
    await producer.EnqueueEventAsync(largeSetOfEvents);
}
finally
{
    // By default, close sends all pending queued events and then shuts down the producer
    await producer.CloseAsync();
}
```

### Publish events to a specific partition

```csharp
// Create the buffered producer
var producer = new EventHubBufferedProducerClient("<< CONNECTION STRING >>", "<< EVENT HUB NAME >>");

// Define the Handlers
Task SendSuccessfulHandler(SendEventBatchSuccessEventArgs args) {...}
Task SendFailedHandler(SendEventBatchFailedEventArgs args) {...}

// Add the handlers to the producer
producer.SendEventBatchSucceededAsync += SendSuccessfulHandler;
producer.SendEventBatchFailedAsync += SendFailedHandler;

try
{
    var enqueueOptions = new EnqueueEventOptions
    {
        PartitionId = "0"

        // Alternatively, you could use a partition key:
        // PartitionKey = "SomeKey"
    };

    // Enqueue events to be sent
    while (TryGetEvent(out var eventData))
    {
        await producer.EnqueueEventAsync(eventData, enqueueOptions);
    }
}
finally
{
    // By default, close sends all pending queued events and then shuts down the producer
    await producer.CloseAsync();
}
```

### Failure recovery: when ordering is not important to the application

When publishing to the Event Hub occasionally an error that is not resolved through implicit retires may occur.  If an application does not require events to be in order, adding failed events back into the queue may be desirable for the application.

```csharp
// A method to determine if a given exception means that the batch can be retried or not
bool ShouldRetryException(Exception exception)
{
    switch (exception)
    {
        case EventHubsException ex:
            return ex.IsTransient;

        case TimeoutException:
            return true;

        default:
            return false;
    }
}

// Create the buffered producer
var producer = new EventHubBufferedProducerClient("<< CONNECTION STRING >>", "<< EVENT HUB NAME >>");

// Define the Handlers
Task SendSuccessfulHandler(SendEventBatchSuccessEventArgs args) {...}

async Task SendFailedHandler(SendEventBatchFailedEventArgs args)
{ 
    var exception = args.Exception;
    var wasResent = false;
    
    while ((!wasResent) && (ShouldRetryException(exception)))
    {
        try
        {
            await producer.EnqueueEventAsync(args.EventBatch);    
            wasResent = true;
        }
        catch (Exception ex)
        {
            exception = ex;
            LogFailure(args.EventBatch, wasResent, exception, ...);
        }
    }
    
    LogFailure(args.EventBatch, wasResent, args.Exception, ...);
}

// Add the handlers to the producer
producer.SendEventBatchSucceededAsync += SendSuccessfulHandler;
producer.SendEventBatchFailedAsync += SendFailedHandler;

try
{
    var id = 0;
    while (TryGetNextEvent(out var eventData))
    {
        eventData.MessageId = $"event #{ id }";
        id++;

        await producer.EnqueueEventAsync(eventData);
        Console.WriteLine($"There are { producer.TotalBufferedEventCount } events queued for publishing.");
    }
}
finally
{
    // By default, close sends all pending queued events and then shuts down the producer
    await producer.CloseAsync();
}
```

### Failure recovery: when ordering is important to the application

When publishing to the Event Hub occasionally an error that is not resolved through retires may occur.  While some may be recovered if allowed to continue retrying, others may be terminal.  

```csharp

// Create the buffered producer
var producer = new EventHubBufferedProducerClient("<< CONNECTION STRING >>", "<< EVENT HUB NAME >>");

// Define the Handlers
Task SendSuccessfulHandler(SendEventBatchSuccessEventArgs args) {...}

async Task SendFailedHandler(SendEventBatchFailedEventArgs args)
{
    LogSendFailure(args.EventBatch, args.Exception, ...);
       
    try
    {
        await DeadLetterToDatabase(args.EventBatch, ...);
    }
    catch (Exception ex)
   {
        LogDeadLetterFailure(args.EventBatch, ex);
   }         
}

// Add the handlers to the producer
producer.SendEventBatchSucceededAsync += SendSuccessfulHandler;
producer.SendEventBatchFailedAsync += SendFailedHandler;

try
{
    var id = 0;
    while (TryGetNextEvent(out var eventData))
    {
        eventData.MessageId = $"event #{ id }");
        id++;

        await producer.EnqueueEventAsync(eventData);
        Console.WriteLine($"There are { producer.TotalBufferedEventCount } events queued for publishing.");
    }
}
finally
{
    // By default, close sends all pending queued events and then shuts down the producer
    await producer.CloseAsync();
}
```

### Forcing events to be sent immediately

Even though the buffered producer publishes events in the background, the application may want to force events to publish immediately. Awaiting `FlushAsync` will attempt to publish all events that are waiting to be published in the queue, and upon return it will have attempted to send all events and applied the retry policy when necessary.

```csharp
// Assume that the application is modeled as a state machine where 
// publishing events happens in bursts, according to the current state.
private async Task PublishEvents(EventHubBufferedProducerClient producer)
{
    while (GetCurrentState(...) == ApplicationState.PublishEvents)
    {
        var eventBody = await GetNextEventAsync(...);
        await producer.EnqueueEventAsync(eventBody);
    }
          
    // The application will continue to use the producer, but would
    // like to ensure the enqueued events have been published before
    // transitioning to a new state.
    await producer.FlushAsync();
}
```

### Closing the producer without publishing pending events

If the application would like to shut down the producer quickly without publishing the events that were queued, the `Close` method offers an optional argument to influence the behavior.

```csharp
// Create the buffered producer
var producer = new EventHubBufferedProducerClient("<< CONNECTION STRING >>", "<< EVENT HUB NAME >>");

// Define the Handlers
Task SendSuccessfulHandler(SendEventBatchSuccessEventArgs args) {...}
Task SendFailedHandler(SendEventBatchFailedEventArgs args) {...}

// Add the handlers to the producer
producer.SendEventBatchSucceededAsync += SendSuccessfulHandler;
producer.SendEventBatchFailedAsync += SendFailedHandler;

try
{
    // Enqueue some events
    while (TryGetNextEvent(out var eventData))
    {
        await producer.EnqueueEventAsync(eventData);
    }
}
finally
{
    // Close with the clear flag set to true clears all pending queued events and then shuts down the producer
    await producer.CloseAsync(abandonBufferedEvents: true);
}
```

## API skeleton

### `Azure.Messaging.EventHubs.Producer`

```csharp
public class SendEventBatchSuccessEventArgs : EventArgs
{
    public IEnumerable<EventData> EventBatch { get; init; }
    public string PartitionId {get; init; }
    public SendEventBatchSuccessEventArgs(IEnumerable<EventData> events, string partitionId);
}

public class SendEventBatchFailedEventArgs : EventArgs
{
    public IEnumerable<EventData> EventBatch { get; init; }
    public Exception Exception { get; init; }
    public string PartitionId { get; init; }
    public SendEventBatchFailedEventArgs(IEnumerable<EventData> events, Exception ex, string partitionId);
}

public class EventHubBufferedProducerClientOptions : EventHubProducerClientOptions
{
    public TimeSpan? MaximumWaitTime { get; set; } // default = 250 ms
    public int MaximumBufferedEventCount { get; set; }  // default = 2500
    public boolean EnableIdempotentRetries { get; set; } // default = false
    public int MaximumConcurrentSendsPerPartition { get; set; } // default = 1
}

public class EnqueueEventOptions : SendEventOptions
{
    public EnqueueEventOptions();
}

public class EventHubBufferedProducerClient : IAsyncDisposable
{
    public event Func<SendEventBatchSuccessEventArgs, Task> SendEventBatchSucceededAsync;
    public event Func<SendEventBatchFailedEventArgs, Task> SendEventBatchFailedAsync;

    public string FullyQualifiedNamespace { get; }
    public string EventHubName { get; }
    public string Identifier { get; }
    public virtual int TotalBufferedEventCount { get; }
    public virtual bool IsClosed { get; protected set; }
    
    public EventHubBufferedProducerClient(string connectionString);
    public EventHubBufferedProducerClient(string connectionString, EventHubBufferedProducerClientOptions clientOptions);
    public EventHubBufferedProducerClient(string connectionString, string eventHubName);
    public EventHubBufferedProducerClient(string connectionString, string eventHubName , EventHubBufferedProducerClientOptions clientOptions);
    public EventHubBufferedProducerClient(string fullyQualifiedNamespace, string eventHubName, AzureNamedKeyCredential credential, EventHubBufferedProducerClientOptions clientOptions = default);
    public EventHubBufferedProducerClient(string fullyQualifiedNamespace, string eventHubName, AzureSasCredential credential, EventHubBufferedProducerClientOptions clientOptions = default);
    public EventHubBufferedProducerClient(string fullyQualifiedNamespace, string eventHubName, TokenCredential credential, EventHubBufferedProducerClientOptions clientOptions = default);
    public EventHubBufferedProducerClient(EventHubConnection connection, EventHubProducerClientOptions clientOptions = default);
    protected EventHubBufferedProducerClient() { }   // Mocking constructor
    
    public virtual int GetPartitionBufferedEventCount(string partition);

    public virtual async Task EnqueueEventAsync(EventData eventData, CancellationToken cancellationToken = default);
    public virtual async Task EnqueueEventAsync(EventData eventData, EnqueueEventOptions options, CancellationToken cancellationToken = default);
    
    public virtual async Task EnqueueEventsAsync(IEnumerable<EventData> eventData, CancellationToken cancellationToken = default);
    public virtual async Task EnqueueEventsAsync(IEnumerable<EventData> eventData, EnqueueEventOptions options, CancellationToken cancellationToken = default);

    public virtual Task FlushAsync(CancellationToken cancellationToken = default);
    internal Task ClearAsync(CancellationToken cancellationToken = default);

    public virtual Task CloseAsync(CancellationToken cancellationToken = default);
    public virtual Task CloseAsync(bool abandonBufferedEvents, CancellationToken cancellationToken = default);
    public virtual ValueTask DisposeAsync();

    protected virtual Task OnSendEventBatchSucceededAsync(string partitionId, IEnumerable<EventData> events);
    protected virtual Task OnSendEventBatchFailedAsync(string partitionId, IEnumerable<EventData> events, Exception ex);
}
```

## Competitive Analysis: Kafka 

The buffered producer will offer parity with most of the features provided by Kafka's producer. Both allow events to be added to a queue of events which are implicitly batched and asynchronously published.  Both also support many of the same options for configuring behavior, including  setting the retry policy, limiting the queue size, specifying an auto-flush interval, and enabling idempotent retries.

### Creating and configuring the producer

#### Kafka: Producer configuration options
```java
private Properties kafkaProps = new Properties();
kafkaProperties.put("bootstrap.servers", "broker1:9092,broker2:9092");
kafkaProperties.put("key.serializer", "org.apache.kafka.common.serialization.StringSerializer"); 
kafkaProperties.put("value.serializer", "org.apache.kafka.common.serialization.StringSerializer");

kafkaProperties.put("client.id", "My Custom Kafka Producer");
kafkaProperties.put("max.in.flight.requests.per.connection", 5);
kafkaProperties.put("enable.idempotence", true);
kafkaProperties.put("linger.ms", 500);
kafkaProperties.put("buffer.memory", );
kafkaProperties.put("retries", 25);
kafkaProperties.put("delivery.timeout.ms", 300000);

KafkaProducer producer = new KafkaProducer<String, String>(kafkaProperties);
```

#### Buffered producer: buffered producer options 

```csharp  
var connectionString = "<< CONNECTION STRING >>";
var eventHubName = "<< EVENT HUB NAME >>";

// Create the buffered producer
var producer = new EventHubBufferedProducerClient(connectionString, eventHubName, new EventHubBufferedProducerClientOptions
{
    Identifier = "My Custom buffered producer",
    MaximumConcurrentSendsPerPartition = 5,
    EnableIdempotentRetries = false,
    MaximumWaitTime = TimeSpan.FromMilliseconds(500),
    MaximumBufferedEventCount = 500
    RetryOptions = new EventHubsRetryOptions { MaximumRetries = 25,  TryTimeout = TimeSpan.FromMinutes(5)  }
});    
```

#### Summary

Kafka's producer and the buffered producer both give applications options for customizing the producer. These include things like the retry policy, the amount of time before sending partial batches, and the number of pending events that can be held inside the producer. In this regard, both the Kafka producer and the buffered producer are relatively similar.

### Sending a general series of messages

#### Kafka: Asynchronously adding to the buffer pool

In order to create a producer using Kafka the user needs to define the properties that the producer will use. The producer requires a list of host:port brokers, these are used to create the connection at the beginning. It also requires serializers for both the key and value type, so that the producer can serialize the key or value object to a byte array. The example below uses the built in serializers that Kafka provides. 

```java
// Creating the producer with basic properties
private Properties kafkaProperties = new Properties(); 
kafkaProperties.put("bootstrap.servers", "broker1:9092,broker2:9092");
kafkaProperties.put("key.serializer", "org.apache.kafka.common.serialization.StringSerializer"); 
kafkaProperties.put("value.serializer", "org.apache.kafka.common.serialization.StringSerializer");

KafkaProducer producer = new KafkaProducer<String, String>(kafkaProperties);

// Creating a callback class
// This is called for each record that is sent
private class FakeCallback implements Callback{
    @Override
    public void onCompletion(RecordMetadata recordMetadata, Exception e){
        if (e != null){
            // This is what to do in the case of a failure 
            e.printStackTrace();
        }
        // Anything here would happen upon failure or success
    }
}

while (thereExistsEvents()){
    // A record contains a key value pair
    ProducerRecord<String, String> record = GetEvent();

    producer.send(record, new FakeCallback());
}
```

#### Buffered producer: Asynchronously enqueuing an event

```csharp
// Create the buffered producer
var producer = new EventHubBufferedProducerClient("<< CONNECTION STRING >>", "<< EVENT HUB NAME >>");

// Define the Handlers
Task SendSuccessfulHandler(SendEventBatchSuccessEventArgs args) { ... }
Task SendFailedHandler(SendEventBatchFailedEventArgs args) { ... }

// Add the handlers to the producer
producer.SendEventBatchSucceededAsync += SendSuccessfulHandler;
producer.SendEventBatchFailedAsync += SendFailedHandler;

try
{
    // Enqueue events to be sent
    while (TryGetEvent(out var eventData))
    {
        // Use a key to send similar events to the same partition
        var sendOptions = new EnqueueEventOptions
        {
            PartitionKey = "SomeKey"
        };

    await producer.EnqueueEventAsync(eventData, sendOptions);
    }
}
finally
{
    // By default, close sends all pending queued events and then shuts down the producer
    await producer.CloseAsync();
}
```

#### Summary

All of Kafka's messages are sent in key/value pairs. It is possible to send a body without a key, but this is not the common case. The key is used for additional information about the message, as well as to assign it to a partition. The key is hashed and then used to assign the message to a partition. Without a key, the producer uses a round-robin approach to assign it to a partition, which is the same approach as the buffered producer. 

However, the recommended approach with the buffered producer is to send it without a key or partition id unless events need to be sent to the same partition. This allows the application to take advantage of all the available partitions.

### Handling successes and failures

#### Kafka: callbacks

```java
private Properties kafkaProps = new Properties();
kafkaProperties.put("bootstrap.servers", "broker1:9092,broker2:9092");
kafkaProperties.put("key.serializer", "org.apache.kafka.common.serialization.StringSerializer"); 
kafkaProperties.put("value.serializer", "org.apache.kafka.common.serialization.StringSerializer");

KafkaProducer producer = new KafkaProducer<String, String>(kafkaProperties);

private class ProducerCallback implements Callback {
 @Override
 public void onCompletion(RecordMetadata recordMetadata, Exception e) {
    boolean wasResent = false;

    // An exception was thrown
    if (e != null){
        if (ShouldRetryException(e)){
            producer.send(record, new ProducerCallback());
            wasResent = true;
        }

        LogFailure(recordMetadata, wasResent, e, ...);
    }

    // No exception was thrown
    if (e == null){
        LogSuccess(recordMetadata,...);
    }
 }
}
ProducerRecord<String, String> record = new ProducerRecord<>("Topic", "Key", "Value"); 
producer.send(record, new ProducerCallback()); 
```


#### Buffered producer: handlers
```csharp
// Create the buffered producer
var producer = new EventHubBufferedProducerClient("<< CONNECTION STRING >>", "<< EVENT HUB NAME >>");

// Define the Handlers
Task SendSuccessfulHandler(SendEventBatchSuccessEventArgs args)
{
    LogSuccess(args.EventBatch, ...);
}

async Task SendFailedHandler(SendEventBatchFailedEventArgs args)
{ 
    var wasResent = false;
       
    if (ShouldRetryException(args.Exception))
    {
        await producer.EnqueueEventAsync(args.EventBatch);
        wasResent = true;
    }
    
    LogFailure(args.EventBatch, wasResent, args.Exception, ...);
}

// Add the handlers to the producer
producer.SendEventBatchSucceededAsync += SendSuccessfulHandler;
producer.SendEventBatchFailedAsync += SendFailedHandler;

try
{
    var id = 0;
    while (TryGetNextEvent(out var eventData))
    {
        eventData.MessageId = $"event #{ id }";
        id++;

        await producer.EnqueueEventAsync(eventData);
        Console.WriteLine($"There are { producer.TotalBufferedEventCount } events queued for publishing.");
    }
}
finally
{
    // By default, close sends all pending queued events and then shuts down the producer
    await producer.CloseAsync();
}
```

#### Summary

Kafka's producer and the buffered producer both utilize pre-defined retry policies when dealing with transient or retriable errors. Rather than checking for recoverable errors in the error handler, it is recommended to determine reliability needs prior to creating the producer, and then defining the retry policy accordingly. Both Kafka and Event Hubs allow customizable retry policies, but also have their own default retry policies that can be used.

Kafka prefers users to define retry policies in terms of timeouts, where the producer tries essentially as many times as possible until the timeout is reached, Event Hubs prefers users to define the maximum number of retries the producer will try to send to the service.
