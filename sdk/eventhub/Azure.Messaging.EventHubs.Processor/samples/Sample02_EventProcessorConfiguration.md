# Event Processor Configuration

The `EventProcessorClient` supports a set of options to configure many aspects of its core functionality including how it communicates with the Event Hubs service.  This sample demonstrates some of these options.  Configuration of processing-related configuration will be discussed in the samples dedicated to that feature.

To begin, please ensure that you're familiar with the items discussed in the [Getting started](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples#getting-started) section of the README, and have the prerequisites and connection string information available.

## Table of contents

- [Choosing the number of processors for the consumer group](#choosing-the-number-of-processors-for-the-consumer-group)
- [Configuring the Azure Storage account](#configuring-the-azure-storage-account)
- [Influencing load balancing behavior](#influencing-load-balancing-behavior)
    - [Load balancing strategy](#load-balancing-strategy)
    - [Load balancing intervals](#load-balancing-intervals)
- [Using web sockets](#using-web-sockets)
- [Setting a custom proxy](#setting-a-custom-proxy)
- [Using the default system proxy](#using-the-default-system-proxy)
- [Specifying a custom endpoint address](#specifying-a-custom-endpoint-address)
- [Influencing SSL certificate validation](#influencing-ssl-certificate-validation)
- [Configuring the client retry thresholds](#configuring-the-client-retry-thresholds)
- [Configuring the timeout used for Event Hubs service operations](#configuring-the-timeout-used-for-event-hubs-service-operations)
- [Using a custom retry policy](#using-a-custom-retry-policy)

## Choosing the number of processors for the consumer group

The `EventProcessorClient` will coordinate with other instances using the same consumer group and Blob Storage container to process the Event Hub cooperatively.  The processors will dynamically distribute and share the Event Hub's partitions, ensuring each has a single processor responsible for reading it.  As `EventProcessorClient` instances are added or removed from the group, partition ownership will be re-balanced to ensure the load is shared evenly among them.

When a processor owns too many partitions, it will often experience contention in the thread pool, potentially leading to starvation. During this time, activities will stall causing delays in `EventProcessorClient` operations. Because there is no fairness guarantee in scheduling, some partitions may appear to stop processing or load balancing may not be able to update ownership, causing partitions to "bounce" between owners.

Because of this, it is important to carefully consider how many `EventProcessorClient` instances are needed in the consumer group for your application.  Generally, it is recommended each processor own no more than 3 partitions for every 1 CPU core of the host. Since the ratio will vary for each application, it is often helpful to start with using 1.5 partitions for each CPU core and test increasing the number of owned partitions gradually to measure what works best for your application.

## Configuring the Azure Storage account

As part of its normal operation, an `EventProcessorClient` needs to enumerate the blobs in its container on a recurring basis.  In order to guarantee that this performs well and doesn't interfere with the processor's operation, it is strongly recommended that you disable blob versioning and soft delete on the Azure Storage account used by the `EventProcessorClient`.  It is also recommended that you use a unique blob container for each Event Hub and consumer group; this container should not contain other blobs nor be shared with processors working in a different context.

## Controlling processor identity

When constructing an `EventProcessorClient`, it is recommended that you set a stable unique identifier for the instance.  This can be done by setting the [Identifier](https://learn.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventprocessorclientoptions.identifier?view=azure-dotnet#azure-messaging-eventhubs-eventprocessorclientoptions-identifier) property of  [EventProcessorClientOptions](https://learn.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventprocessorclientoptions) and passing the options to the constructor.

A stable identifier allows the processor to recover partition ownership when an application or host instance is restarted.  It also aids readability in Azure SDK logs and allows for more easily correlating logs to a specific processor instance.

## Influencing load balancing behavior

To scale event processing, you can run multiple instances of the `EventProcessorClient` and they will coordinate to balance work between them. The responsibility for processing is distributed among each of the active processors configured to read from the same Event Hub and using the same consumer group.  To balance work, each active `EventProcessorClient` instance will assume responsibility for processing a set of Event Hub partitions, referred to as "owning" the partitions.  The processors collaborate on ownership using storage as a central point of coordination.

While an `EventProcessorClient` is running, it will periodically perform a load balancing cycle in which it audits its own health and inspects the current state of collaboration with other processors. As part of that cycle, it will refresh the timestamp on an ownership record for each partition that it owns.  These ownership records help to ensure that each `EventProcessorClient` understands how to maintain its fair share of partitions.

There are several configuration options that can be used together to influence the behavior of load balancing, allowing you to tune it for the specific needs of your application.

### Load balancing strategy

This controls the approach that the `EventProcessorClient` will use to make decisions about how aggressively to request partition ownership; this is most impactful during the initial startup or when recovering from a crash.  More information on the strategies available can be found in the [documentation](https://learn.microsoft.com/dotnet/api/azure.messaging.eventhubs.processor.loadbalancingstrategy).

```C# Snippet:EventHubs_Processor_Sample02_LoadBalancingStrategy
var credential = new DefaultAzureCredential();

var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var processorOptions = new EventProcessorClientOptions
{
    LoadBalancingStrategy = LoadBalancingStrategy.Greedy
};

var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
{
    BlobContainerName = blobContainerName
};

var storageClient = new BlobContainerClient(
    blobUriBuilder.ToUri(),
    credential);

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    fullyQualifiedNamespace,
    eventHubName,
    credential,
    processorOptions);
```

### Load balancing intervals

There are two intervals considered during load balancing which can influence its behavior.  The `LoadBalancingUpdateInterval` controls how frequently a load balancing cycle is run.  During the load balancing cycle, the `EventProcessorClient` will attempt to refresh its ownership record for each partition that it owns.  The `PartitionOwnershipExpirationInterval` controls how long an ownership record is considered valid.  If the processor does not update an ownership record before this interval elapses, the partition represented by this record is considered unowned and is eligible to be claimed by another processor.

It is recommended that the `PartitionOwnershipExpirationInterval` be at least 3 times greater than the `LoadBalancingUpdateInterval` and very strongly advised that it should be no less than twice as long.  When these intervals are too close together, ownership may expire before it is renewed during load balancing which will cause partitions to migrate.

```C# Snippet:EventHubs_Processor_Sample02_LoadBalancingIntervals
var credential = new DefaultAzureCredential();

var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var processorOptions = new EventProcessorClientOptions
{
    LoadBalancingUpdateInterval = TimeSpan.FromSeconds(10),
    PartitionOwnershipExpirationInterval = TimeSpan.FromSeconds(30)
};

var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
{
    BlobContainerName = blobContainerName
};

var storageClient = new BlobContainerClient(
    blobUriBuilder.ToUri(),
    credential);

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    fullyQualifiedNamespace,
    eventHubName,
    credential,
    processorOptions);
```

## Using web sockets

Communication with the Event Hubs service can be configured by adjusting the `EventHubConfigurationOptions` that are exposed by the `ConnectionOptions` member of a client options type.  By default, the `EventProcessorClient` communicates using the AMQP protocol over TCP.  Some application host environments prefer to restrict raw TCP socket use, especially in many enterprise or VPN scenarios.  In these environments, or when a proxy is in use, communication with the Event Hubs service can make use of web sockets by configuring the client's connection settings.

```C# Snippet:EventHubs_Processor_Sample02_TransportFullConnectionOptions
var credential = new DefaultAzureCredential();

var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var processorOptions = new EventProcessorClientOptions
{
    ConnectionOptions = new EventHubConnectionOptions
    {
        TransportType = EventHubsTransportType.AmqpWebSockets
    }
};

var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
{
    BlobContainerName = blobContainerName
};

var storageClient = new BlobContainerClient(
    blobUriBuilder.ToUri(),
    credential);

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    fullyQualifiedNamespace,
    eventHubName,
    credential,
    processorOptions);
```
The connection options are populated by default; you may set just the desired properties rather than creating a new instance, if you prefer.

```C# Snippet:EventHubs_Processor_Sample02_TransportProperty
var credential = new DefaultAzureCredential();

var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var processorOptions = new EventProcessorClientOptions();
processorOptions.ConnectionOptions.TransportType = EventHubsTransportType.AmqpWebSockets;

var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
{
    BlobContainerName = blobContainerName
};

var storageClient = new BlobContainerClient(
    blobUriBuilder.ToUri(),
    credential);

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    fullyQualifiedNamespace,
    eventHubName,
    credential,
    processorOptions);
```

## Setting a custom proxy

A common scenario for adjusting the connection options is configuring a proxy.  Proxy support takes the form of the [IWebProxy](https://learn.microsoft.com/dotnet/api/system.net.iwebproxy?view=netcore-3.1) interface, of which [WebProxy](https://learn.microsoft.com/dotnet/api/system.net.webproxy?view=netcore-3.1) is the most common default implementation.  Event Hubs supports a proxy only when using `AmqpWebSockets` as the transport type.

```C# Snippet:EventHubs_Processor_Sample02_ProxyFullConnectionOptions
var credential = new DefaultAzureCredential();

var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
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

var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
{
    BlobContainerName = blobContainerName
};

var storageClient = new BlobContainerClient(
    blobUriBuilder.ToUri(),
    credential);

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    fullyQualifiedNamespace,
    eventHubName,
    credential,
    processorOptions);
```

The connection options are populated by default; you may set just the desired properties rather than creating a new instance, if you prefer.

```C# Snippet:EventHubs_Processor_Sample02_ProxyProperty
var credential = new DefaultAzureCredential();

var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var processorOptions = new EventProcessorClientOptions();
processorOptions.ConnectionOptions.TransportType = EventHubsTransportType.AmqpWebSockets;
processorOptions.ConnectionOptions.Proxy = new WebProxy("https://proxyserver:80", true);

var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
{
    BlobContainerName = blobContainerName
};

var storageClient = new BlobContainerClient(
    blobUriBuilder.ToUri(),
    credential);

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    fullyQualifiedNamespace,
    eventHubName,
    credential,
    processorOptions);
```

## Using the default system proxy

To use the default proxy for your environment, the recommended approach is to make use of [HttpClient.DefaultProxy](https://learn.microsoft.com/dotnet/api/system.net.http.httpclient.defaultproxy?view=netcore-3.1), which will attempt to detect proxy settings from the ambient environment in a manner consistent with expectations for the target platform.

**Note:** This member was first introduced in .NET Core 3.1 and is not supported for earlier target frameworks.

```C# Snippet:EventHubs_Processor_Sample02_ConnectionOptionsDefaultProxy
var options = new EventHubConnectionOptions
{
    TransportType = EventHubsTransportType.AmqpWebSockets,
    Proxy = HttpClient.DefaultProxy
};
```

## Specifying a custom endpoint address

Connections to the Azure Event Hubs service are made using the fully qualified namespace assigned to the Event Hubs namespace as the connection endpoint address. Because the Event Hubs service uses the endpoint address to locate the corresponding resources, it isn't possible to specify a custom address in the connection string or as the fully qualified namespace.

However, a custom address is required for proper routing by some environments, such as those using unconventional proxy configurations or certain configurations of an Express Route circuit. To support these scenarios, a custom endpoint address may be specified as part of the connection options.  This custom address will take precedence for establishing the connection to the Event Hubs service.

```C# Snippet:EventHubs_Processor_Sample02_ConnectionOptionsCustomEndpoint
var credential = new DefaultAzureCredential();

var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var processorOptions = new EventProcessorClientOptions();
processorOptions.ConnectionOptions.CustomEndpointAddress = new Uri("amqps://app-gateway.mycompany.com");

var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
{
    BlobContainerName = blobContainerName
};

var storageClient = new BlobContainerClient(
    blobUriBuilder.ToUri(),
    credential);

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    fullyQualifiedNamespace,
    eventHubName,
    credential,
    processorOptions);
```

## Influencing SSL certificate validation

For some environments using a proxy or custom gateway for routing traffic to Event Hubs, a certificate not trusted by the root certificate authorities may be issued.  This can often be a self-signed certificate from the gateway or one issued by a company's internal certificate authority.

By default, these certificates are not trusted by the Event Hubs client library and the connection will be refused.  To enable these scenarios, a [RemoteCertificateValidationCallback](https://learn.microsoft.com/dotnet/api/system.net.security.remotecertificatevalidationcallback) can be registered to provide custom validation logic for remote certificates.  This allows an application to override the default trust decision and assert responsibility for accepting or rejecting the certificate.

```C# Snippet:EventHubs_Processor_Sample02_RemoteCertificateValidationCallback
var credential = new DefaultAzureCredential();

var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

static bool ValidateServerCertificate(
      object sender,
      X509Certificate certificate,
      X509Chain chain,
      SslPolicyErrors sslPolicyErrors)
{
    if ((sslPolicyErrors == SslPolicyErrors.None)
        || (certificate.Issuer == "My Company CA"))
    {
         return true;
    }

    // Do not allow communication with unauthorized servers.

    return false;
}

var processorOptions = new EventProcessorClientOptions();
processorOptions.ConnectionOptions.CertificateValidationCallback = ValidateServerCertificate;

var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
{
    BlobContainerName = blobContainerName
};

var storageClient = new BlobContainerClient(
    blobUriBuilder.ToUri(),
    credential);

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    fullyQualifiedNamespace,
    eventHubName,
    credential,
    processorOptions);
```

## Configuring the client retry thresholds

The built-in retry policy offers an implementation for an exponential back-off strategy by default, as this provides a good balance between making forward progress and allowing for transient issues that may take some time to resolve.  The built-in policy also offers a fixed strategy for those cases where your application requires that you have a deterministic understanding of how long an operation may take.

The values used as thresholds for the different aspects of these strategies can be configured by adjusting the `EventHubsRetryOptions` that are exposed by the `RetryOptions` member of a client options type.

```C# Snippet:EventHubs_Processor_Sample02_RetryWithFullOptions
var credential = new DefaultAzureCredential();

var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
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

var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
{
    BlobContainerName = blobContainerName
};

var storageClient = new BlobContainerClient(
    blobUriBuilder.ToUri(),
    credential);

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    fullyQualifiedNamespace,
    eventHubName,
    credential,
    processorOptions);
```

The retry options are populated by default; you may set just the desired properties rather than creating a new instance, if you prefer.

```C# Snippet:EventHubs_Processor_Sample02_RetryByProperty
var credential = new DefaultAzureCredential();

var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var processorOptions = new EventProcessorClientOptions();
processorOptions.RetryOptions.Mode = EventHubsRetryMode.Fixed;
processorOptions.RetryOptions.MaximumRetries = 5;

var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
{
    BlobContainerName = blobContainerName
};

var storageClient = new BlobContainerClient(
    blobUriBuilder.ToUri(),
    credential);

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    fullyQualifiedNamespace,
    eventHubName,
    credential,
    processorOptions);
```

## Configuring the timeout used for Event Hubs service operations

The `EventHubsRetryOptions` also control the timeout that is used for operations, including those which involve communicating with the Event Hubs service.  The default timeout of 60 seconds can be changed by adjusting the `TryTimeout` value.

**Note:** This value is important to the `EventProcessorClient` when `StopProcessingAsync` is invoked.  Because the processor will allow processing for each owned partition to complete when shutting down, if reading from the Event Hubs service is taking place when the processor attempts to stop, it may take up to the duration of the `TryTimeout` to complete.

```C# Snippet:EventHubs_Processor_Sample02_RetryOptionsTryTimeout
var options = new EventHubsRetryOptions
{
    TryTimeout = TimeSpan.FromMinutes(1)
};
```

## Using a custom retry policy

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
