# Event Processor Configuration

The `EventProcessorClient` supports a set of options to configure many aspects of its core functionality including how it communicates with the Event Hubs service.  This sample demonstrates some of these options.  Configuration of processing-related configuration will be discussed in the samples dedicated to that feature.

To begin, please ensure that you're familiar with the items discussed in the [Getting started](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples#getting-started) section of the README, and have the prerequisites and connection string information available.

## Influencing load balancing behavior

To scale event processing, you can run multiple instances of the `EventProcessorClient` and they will coordinate to balance work between them. The responsibility for processing is distributed among each of the active processors configured to read from the same Event Hub and using the same consumer group.  To balance work, each active `EventProcessorClient` instance will assume responsibility for processing a set of Event Hub partitions, referred to as "owning" the partitions.  The processors collaborate on ownership using storage as a central point of coordination.  

While an `EventProcessorClient` is running, it will periodically perform a load balancing cycle in which it audits its own health and inspects the current state of collaboration with other processors. As part of that cycle, it will refresh the timestamp on an ownership record for each partition that it owns.  These ownership records help to ensure that each `EventProcessorClient` understands how to maintain its fair share of partitions.

There are several configuration options that can be used together to influence the behavior of load balancing, allowing you to tune it for the specific needs of your application.

### Load balancing strategy

This controls the approach that the `EventProcessorClient` will use to make decisions about how aggressively to request partition ownership; this is most impactful during the initial startup or when recovering from a crash.  More information on the strategies available can be found in the [documentation](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.processor.loadbalancingstrategy).

```C# Snippet:EventHubs_Processor_Sample02_LoadBalancingStrategy
var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var processorOptions = new EventProcessorClientOptions
{
    LoadBalancingStrategy = LoadBalancingStrategy.Greedy
};

var storageClient = new BlobContainerClient(
    storageConnectionString,
    blobContainerName);

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    eventHubsConnectionString,
    eventHubName,
    processorOptions);
```

### Load balancing intervals

There are two intervals considered during load balancing which can influence its behavior.  The `LoadBalancingInterval` controls how frequently a load balancing cycle is run.  During the load balancing cycle, the `EventProcessorClient` will attempt to refresh its ownership record for each partition that it owns.  The `PartitionOwnershipExpirationInterval` controls how long an ownership record is considered valid.  If the processor does not update an ownership record before this interval elapses, the partition represented by this record is considered unowned and is eligible to be claimed by another processor.  

```C# Snippet:EventHubs_Processor_Sample02_LoadBalancingIntervals
var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var processorOptions = new EventProcessorClientOptions
{
    LoadBalancingUpdateInterval = TimeSpan.FromSeconds(10),
    PartitionOwnershipExpirationInterval = TimeSpan.FromSeconds(30)
};

var storageClient = new BlobContainerClient(
    storageConnectionString,
    blobContainerName);

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    eventHubsConnectionString,
    eventHubName,
    processorOptions);
```

## Using web sockets 

Communication with the Event Hubs service can be configured by adjusting the `EventHubConfigurationOptions` that are exposed by the `ConnectionOptions` member of a client options type.  By default, the `EventProcessorClient` communicates using the AMQP protocol over TCP.  Some application host environments prefer to restrict raw TCP socket use, especially in many enterprise or VPN scenarios.  In these environments, or when a proxy is in use, communication with the Event Hubs service can make use of web sockets by configuring the client's connection settings.

```C# Snippet:EventHubs_Processor_Sample02_TransportFullConnectionOptions
var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var processorOptions = new EventProcessorClientOptions
{
    ConnectionOptions = new EventHubConnectionOptions
    {
        TransportType = EventHubsTransportType.AmqpWebSockets
    }
};

var storageClient = new BlobContainerClient(
    storageConnectionString,
    blobContainerName);

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    eventHubsConnectionString,
    eventHubName,
    processorOptions);
```
The connection options are populated by default; you may set just the desired properties rather than creating a new instance, if you prefer.

```C# Snippet:EventHubs_Processor_Sample02_TransportProperty
var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var processorOptions = new EventProcessorClientOptions();
processorOptions.ConnectionOptions.TransportType = EventHubsTransportType.AmqpWebSockets;

var storageClient = new BlobContainerClient(
    storageConnectionString,
    blobContainerName);

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    eventHubsConnectionString,
    eventHubName,
    processorOptions);
```

## Setting a custom proxy

A common scenario for adjusting the connection options is configuring a proxy.  Proxy support takes the form of the [IWebProxy](https://docs.microsoft.com/dotnet/api/system.net.iwebproxy?view=netcore-3.1) interface, of which [WebProxy](https://docs.microsoft.com/dotnet/api/system.net.webproxy?view=netcore-3.1) is the most common default implementation.  Event Hubs supports a proxy only when using `AmqpWebSockets` as the transport type.

```C# Snippet:EventHubs_Processor_Sample02_ProxyFullConnectionOptions
var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var processorOptions = new EventProcessorClientOptions
{
    ConnectionOptions = new EventHubConnectionOptions
    {
        TransportType = EventHubsTransportType.AmqpWebSockets,
        Proxy = new WebProxy("https://proxyserver:80", true)
    }
};

var storageClient = new BlobContainerClient(
    storageConnectionString,
    blobContainerName);

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    eventHubsConnectionString,
    eventHubName,
    processorOptions);
```

The connection options are populated by default; you may set just the desired properties rather than creating a new instance, if you prefer.

```C# Snippet:EventHubs_Processor_Sample02_ProxyProperty
var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var processorOptions = new EventProcessorClientOptions();
processorOptions.ConnectionOptions.TransportType = EventHubsTransportType.AmqpWebSockets;
processorOptions.ConnectionOptions.Proxy = new WebProxy("https://proxyserver:80", true);

var storageClient = new BlobContainerClient(
    storageConnectionString,
    blobContainerName);

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    eventHubsConnectionString,
    eventHubName,
    processorOptions);
```

### Using the default system proxy

To use the default proxy for your environment, the recommended approach is to make use of [HttpClient.DefaultProxy](https://docs.microsoft.com/dotnet/api/system.net.http.httpclient.defaultproxy?view=netcore-3.1), which will attempt to detect proxy settings from the ambient environment in a manner consistent with expectations for the target platform.  

**Note:** This member was first introduced in .NET Core 3.1 and is not supported for earlier target frameworks.

```C# Snippet:EventHubs_Processor_Sample02_ConnectionOptionsDefaultProxy
var options = new EventHubConnectionOptions
{
    TransportType = EventHubsTransportType.AmqpWebSockets,
    Proxy = HttpClient.DefaultProxy
};
```

### Specifying a custom endpoint address

Connections to the Azure Event Hubs service are made using the fully qualified namespace assigned to the Event Hubs namespace as the connection endpoint address. Because the Event Hubs service uses the endpoint address to locate the corresponding resources, it isn't possible to specify a custom address in the connection string or as the fully qualified namespace.

However, a custom address is required for proper routing by some environments, such as those using unconventional proxy configurations or certain configurations of an Express Route circuit. To support these scenarios, a custom endpoint address may be specified as part of the connection options.  This custom address will take precedence for establishing the connection to the Event Hubs service.

```C# Snippet:EventHubs_Processor_Sample02_ConnectionOptionsCustomEndpoint
var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var processorOptions = new EventProcessorClientOptions();
processorOptions.ConnectionOptions.CustomEndpointAddress = new Uri("amqps://app-gateway.mycompany.com");

var storageClient = new BlobContainerClient(
    storageConnectionString,
    blobContainerName);

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    eventHubsConnectionString,
    eventHubName,
    processorOptions);
```

### Configuring the client retry thresholds

The built-in retry policy offers an implementation for an exponential back-off strategy by default, as this provides a good balance between making forward progress and allowing for transient issues that may take some time to resolve.  The built-in policy also offers a fixed strategy for those cases where your application requires that you have a deterministic understanding of how long an operation may take.

The values used as thresholds for the different aspects of these strategies can be configured by adjusting the `EventHubsRetryOptions` that are exposed by the `RetryOptions` member of a client options type. 

```C# Snippet:EventHubs_Processor_Sample02_RetryWithFullOptions
var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var processorOptions = new EventProcessorClientOptions
{
    RetryOptions = new EventHubsRetryOptions
    {
        Mode = EventHubsRetryMode.Exponential,
        MaximumRetries = 5,
        Delay = TimeSpan.FromMilliseconds(800),
        MaximumDelay = TimeSpan.FromSeconds(10)
    }
};

var storageClient = new BlobContainerClient(
    storageConnectionString,
    blobContainerName);

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    eventHubsConnectionString,
    eventHubName,
    processorOptions);
```

The retry options are populated by default; you may set just the desired properties rather than creating a new instance, if you prefer.

```C# Snippet:EventHubs_Processor_Sample02_RetryByProperty
var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var processorOptions = new EventProcessorClientOptions();
processorOptions.RetryOptions.Mode = EventHubsRetryMode.Fixed;
processorOptions.RetryOptions.MaximumRetries = 5;

var storageClient = new BlobContainerClient(
    storageConnectionString,
    blobContainerName);

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    eventHubsConnectionString,
    eventHubName,
    processorOptions);
```

### Configuring the timeout used for Event Hubs service operations

The `EventHubsRetryOptions` also control the timeout that is used for operations, including those which involve communicating with the Event Hubs service.  The default timeout of 60 seconds can be changed by adjusting the `TryTimeout` value.

**Note:** This value is important to the `EventProcessorClient` when `StopProcessingAsync` is invoked.  Because the processor will allow processing for each owned partition to complete when shutting down, if reading from the Event Hubs service is taking place when the processor attempts to stop, it may take up to the duration of the `TryTimeout` to complete.

```C# Snippet:EventHubs_Processor_Sample02_RetryOptionsTryTimeout
var options = new EventHubsRetryOptions
{
    TryTimeout = TimeSpan.FromMinutes(1)
};
```

### Using a custom retry policy

For those scenarios where your application requires more control over retries, you can provide a custom retry policy.

```C# Snippet:EventHubs_Processor_Sample02_CustomRetryPolicy
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

```C# Snippet:EventHubs_Processor_Sample02_CustomRetryUse
var options = new EventHubsRetryOptions
{
    CustomRetryPolicy = new ExampleRetryPolicy()
};
```