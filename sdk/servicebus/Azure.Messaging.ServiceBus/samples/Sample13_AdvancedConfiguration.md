# Advanced configuration

This sample demonstrates how to use some of the advanced configuration options available in the Service Bus client library.

## Configuring the transport

By default, the Service Bus client library communicates with the service using the AMQP protocol over TCP. Some application host environments prefer to restrict raw TCP socket use, especially in many enterprise or VPN scenarios. In these environments, or when a proxy is in use, communication with the Service Bus service can make use of web sockets by configuring the client's connection settings.

In the example shown below, the transport is configured to use web sockets and a proxy is specified. You can also use websockets without specifying a proxy, but the proxy should only be used when using websockets.

```C# Snippet:ServiceBusConfigureTransport
string connectionString = "<connection_string>";
var client = new ServiceBusClient(connectionString, new ServiceBusClientOptions
{
    TransportType = ServiceBusTransportType.AmqpWebSockets,
    WebProxy = new WebProxy("https://myproxyserver:80")
});
```

## Initiating the connection with a custom endpoint

If an alternative host name is needed to establish the connection to the service, a custom endpoint address can be provided through the `ServiceBusClientOptions`. The client will use this endpoint to open the initial connection, and then will use the default endpoint provided by the Service Bus service for all following operations and validation.

```C# Snippet:ServiceBusCustomEndpoint
// Connect to the service using a custom endpoint
string connectionString = "<connection_string>";
string customEndpoint = "<custom_endpoint>";

var options = new ServiceBusClientOptions
{
    CustomEndpointAddress = new Uri(customEndpoint)
};

ServiceBusClient client = new ServiceBusClient(connectionString, options);
```

## Customizing the retry options

The retry options are used to configure the retry policy for all operations when communicating with the service. The default values are shown below, but they can be customized to fit your scenario.

```C# Snippet:ServiceBusConfigureRetryOptions
string connectionString = "<connection_string>";
var client = new ServiceBusClient(connectionString, new ServiceBusClientOptions
{
    RetryOptions = new ServiceBusRetryOptions
    {
        TryTimeout = TimeSpan.FromSeconds(60),
        MaxRetries = 3,
        Delay = TimeSpan.FromSeconds(.8)
    }
});
```

## Using prefetch

The [prefetch feature](https://docs.microsoft.com/azure/service-bus-messaging/service-bus-prefetch?tabs=dotnet) allows the receiver and processor to request messages in the background before an actual receive operation is initiated. This can potentially increase the throughput of your application, but it comes with several large drawbacks that are outlined in this [document](https://docs.microsoft.com/azure/service-bus-messaging/service-bus-prefetch?tabs=dotnet#why-is-prefetch-not-the-default-option). If you determine that prefetch makes sense for your application, here is how you would enable it:

```C# Snippet:ServiceBusConfigurePrefetchReceiver
string connectionString = "<connection_string>";
var client = new ServiceBusClient(connectionString);
ServiceBusReceiver receiver = client.CreateReceiver("<queue-name>", new ServiceBusReceiverOptions
{
    PrefetchCount = 10
});
```

And when using the processor:

```C# Snippet:ServiceBusConfigurePrefetchProcessor
string connectionString = "<connection_string>";
var client = new ServiceBusClient(connectionString);
ServiceBusProcessor processor = client.CreateProcessor("<queue-name>", new ServiceBusProcessorOptions
{
    PrefetchCount = 10
});
```
