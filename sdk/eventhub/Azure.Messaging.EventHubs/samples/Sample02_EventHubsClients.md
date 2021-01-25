# Event Hubs Clients

The Event Hubs client library has the goal of providing an approachable onboarding experience for developers new to messaging and/or the Event Hubs service with a focus on enabling a quick initial feedback loop for publishing and consuming events.  As developers shift from exploration to tackling real-world production scenarios, we want to provide a gradual step-up path, building on the onboarding experience with additional robustness and a familiar API surface.  For application scenarios with high-throughput or special needs, we want to be sure that developers are able to work at a low-level and assert more control.

This sample details the client types available for the Event Hubs client library and demonstrates some of the options for customizing their configuration.  To begin, please ensure that you're familiar with the items discussed in the [Getting started](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/samples#getting-started) section of the README, and have the prerequisites and connection string information available.

## Hierarchy

Because each client provides the developer experience for an area of Event Hubs functionality, to provide the best experience, it is important that it offers an API focused on a concrete set of scenarios.  Because applications have different needs, we wanted to offer support for more specialized scenarios without introducing additional complexity to the more common scenarios.  To achieve this, the client hierarchy was designed to align with two general categories, mainstream and specialized.  

The mainstream set of clients provides an approachable onboarding experience for those new to Event Hubs with a clear step-up path to production use for the most common application scenarios.  The specialized set of clients is focused on high-throughput and allowing developers to assert a higher degree of control, at the cost of more complexity in their use.  This section will briefly introduce the clients in both categories, though samples will continue to focus heavily on the mainstream clients.

**Mainstream**

- The [EventHubProducerClient](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.producer?view=azure-dotnet) is responsible for publishing events and supports multiple approaches for selecting the partition to which the event is associated, including automatic routing by the Event Hubs service and specifying an explicit partition.
  
- The [EventHubConsumerClient](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.consumer.eventhubconsumerclient?view=azure-dotnet) supports reading events from a single partition and also offers an easy way to familiarize yourself with Event Hubs by reading from all partitions without the rigor and complexity that you would need in a production application. For reading events from all partitions in a production scenario, we strongly recommend using the [EventProcessorClient](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples) from the [Azure.Messaging.EventHubs.Processor](https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor) package over the `EventHubConsumerClient`.

**Specialized**

- The [PartitionReceiver](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.primitives.partitionreceiver?view=azure-dotnet) is responsible for reading events from a specific partition of an Event Hub, with a greater level of control over communication with the Event Hubs service than is offered by other event consumers.  More detail on the design and philosophy for the `PartitionReceiver` can be found in its [design document](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/design/partition-receiver-proposal.md).

- The [EventProcessor&lt;TPartition&gt;](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.primitives.eventprocessor-1?view=azure-dotnet) provides a base for creating a custom processor for reading and processing events for all partitions of an Event Hub. It fills a role similar to the [EventProcessorClient](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples) from the [Azure.Messaging.EventHubs.Processor](https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor) package, with cooperative load balancing and resiliency as its core features.  However, `EventProcessor<TPartition>` also offers native batch processing, the ability to customize checkpoint storage, a greater level of control over communication with the Event Hubs service, and a less opinionated API.  The caveat is that this comes with additional complexity and exists as an abstract base, which needs to be extended.  More on the design and philosophy behind this type can be found in its [design document](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/design/event-processor%7BT%7D-proposal.md).

## Lifetime

Each of the Event Hubs client types is safe to cache and use for the lifetime of the application, which is best practice when the application publishes or reads events regularly or semi-regularly. The clients are responsible for efficient resource management, working to keep resource usage low during periods of inactivity and manage health during periods of higher use. Calling either the `CloseAsync` or `DisposeAsync` method on a client as the application is shutting down will ensure that network resources and other unmanaged objects are properly cleaned up.

## Configuration

Each of the Event Hubs client types in the library supports a set of options to configure its behavior.  In addition to influencing a client's area of functionality, the options also support configuration common across all areas.  These common options are focused on communication with the Event Hubs service and core functionality; they appear as members of the client options.

### Using web sockets 

Communication with the Event Hubs service can be configured by adjusting the `EventHubConfigurationOptions` that are exposed by the `ConnectionOptions` member of a client options type.  By default, the Event Hubs clients communicate using the AMQP protocol over TCP.  Some application host environments prefer to restrict raw TCP socket use, especially in many enterprise or VPN scenarios.  In these environments, or when a proxy is in use, communication with the Event Hubs service can make use of web sockets by configuring the client's connection settings.

For illustration, the `EventHubProducerClientOptions` are demonstrated, but the concept and form are common across the client options types.

```C# Snippet:EventHubs_Sample02_ProducerTransportFullConnectionOptions
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var producerOptions = new EventHubProducerClientOptions
{
    ConnectionOptions = new EventHubConnectionOptions
    {
        TransportType = EventHubsTransportType.AmqpWebSockets
    }
};

var producer = new EventHubProducerClient(
    connectionString,
    eventHubName,
    producerOptions);
```
The connection options are populated by default; you may set just the desired properties rather than creating a new instance, if you prefer.

```C# Snippet:EventHubs_Sample02_ProducerTransportProperty
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var producerOptions = new EventHubProducerClientOptions();
producerOptions.ConnectionOptions.TransportType = EventHubsTransportType.AmqpWebSockets;

var producer = new EventHubProducerClient(
    connectionString,
    eventHubName,
    producerOptions);
```

### Setting a custom proxy

A common scenario for adjusting the connection options is configuring a proxy.  Proxy support takes the form of the [IWebProxy](https://docs.microsoft.com/dotnet/api/system.net.iwebproxy?view=netcore-3.1) interface, of which [WebProxy](https://docs.microsoft.com/dotnet/api/system.net.webproxy?view=netcore-3.1) is the most common default implementation.  Event Hubs supports a proxy only when using `AmqpWebSockets` as the transport type.

For illustration, the `EventHubProducerClientOptions` are demonstrated, but the concept and form are common across the client options types.

```C# Snippet:EventHubs_Sample02_ProducerProxyFullConnectionOptions
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var producerOptions = new EventHubProducerClientOptions
{
    ConnectionOptions = new EventHubConnectionOptions
    {
        TransportType = EventHubsTransportType.AmqpWebSockets,
        Proxy = new WebProxy("https://proxyserver:80", true)
    }
};

var producer = new EventHubProducerClient(
    connectionString,
    eventHubName,
    producerOptions);
```

The connection options are populated by default; you may set just the desired properties rather than creating a new instance, if you prefer.

```C# Snippet:EventHubs_Sample02_ProducerProxyProperty
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var producerOptions = new EventHubProducerClientOptions();
producerOptions.ConnectionOptions.TransportType = EventHubsTransportType.AmqpWebSockets;
producerOptions.ConnectionOptions.Proxy = new WebProxy("https://proxyserver:80", true);

var producer = new EventHubProducerClient(
    connectionString,
    eventHubName,
    producerOptions);
```

### Using the default system proxy

To use the default proxy for your environment, the recommended approach is to make use of [HttpClient.DefaultProxy](https://docs.microsoft.com/dotnet/api/system.net.http.httpclient.defaultproxy?view=netcore-3.1), which will attempt to detect proxy settings from the ambient environment in a manner consistent with expectations for the target platform.  Unfortunately, this member was added for .NET Core 3.1 and is not supported for earlier target frameworks.

```C# Snippet:EventHubs_Sample02_ConnectionOptionsDefaultProxy
var options = new EventHubConnectionOptions
{
    TransportType = EventHubsTransportType.AmqpWebSockets,
    Proxy = HttpClient.DefaultProxy
};
```

### Configuring the client retry thresholds

The built-in retry policy offers an implementation for an exponential back-off strategy by default, as this provides a good balance between making forward progress and allowing for transient issues that may take some time to resolve.  The built-in policy also offers a fixed strategy for those cases where your application requires that you have a deterministic understanding of how long an operation may take.

The values used as thresholds for the different aspects of these strategies can be configured by adjusting the `EventHubsRetryOptions` that are exposed by the `RetryOptions` member of a client options type. For illustration, the `EventHubConsumerClientOptions` are demonstrated, but the concept and form are common across the client options types.

```C# Snippet:EventHubs_Sample02_ConsumerRetryWithFullOptions
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

var consumerOptions = new EventHubConsumerClientOptions
{
    RetryOptions = new EventHubsRetryOptions
    {
        Mode = EventHubsRetryMode.Exponential,
        MaximumRetries = 5,
        Delay = TimeSpan.FromMilliseconds(800),
        MaximumDelay = TimeSpan.FromSeconds(10)
    }
};

var consumer = new EventHubConsumerClient(
    consumerGroup,
    connectionString,
    eventHubName,
    consumerOptions);
```

The retry options are populated by default; you may set just the desired properties rather than creating a new instance, if you prefer.

```C# Snippet:EventHubs_Sample02_ConsumerRetryByProperty
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

var consumerOptions = new EventHubConsumerClientOptions();
consumerOptions.RetryOptions.Mode = EventHubsRetryMode.Fixed;
consumerOptions.RetryOptions.MaximumRetries = 5;

var consumer = new EventHubConsumerClient(
    consumerGroup,
    connectionString,
    eventHubName,
    consumerOptions);
```

### Configuring the timeout used for Event Hubs service operations

The `EventHubsRetryOptions` also control the timeout that is used for operations, including those which involve communicating with the Event Hubs service.  By default, a 60 second timeout is assumed.  This can be changed by adjusting the `TryTimeout` value.

```C# Snippet:EventHubs_Sample02_RetryOptionsTryTimeout
var options = new EventHubsRetryOptions
{
    TryTimeout = TimeSpan.FromMinutes(1)
};
```

### Using a custom retry policy

For those scenarios where your application requires more control over retries, you can provide a custom retry policy.

```C# Snippet:EventHubs_Sample02_CustomRetryPolicy
public class ExampleRetryPolicy : EventHubsRetryPolicy
{
    public override TimeSpan? CalculateRetryDelay(Exception lastException, int attemptCount)
    {
        // Only allow 5 retries.

        if (attemptCount > 5)
        {
            return null;
        }

        // Only retry EventHubsExceptions that are flagged transient.  Use
        // a fixed delay of 1/4 second per attempt, for simplicity.

        return ((lastException is EventHubsException ex) && (ex.IsTransient))
            ? TimeSpan.FromMilliseconds(250)
            : default(TimeSpan?);
    }

    // Always use a 60 second timeout for operations.

    public override TimeSpan CalculateTryTimeout(int attemptCount) =>
        TimeSpan.FromSeconds(60);
}
```

```C# Snippet:EventHubs_Sample02_CustomRetryUse
var options = new EventHubsRetryOptions
{
    CustomRetryPolicy = new ExampleRetryPolicy()
};
```