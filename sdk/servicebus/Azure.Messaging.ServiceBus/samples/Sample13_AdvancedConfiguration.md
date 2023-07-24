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

## Configuring a lock lost handler when using the processor

The processor allows for automatic lock renewal based on the configured 
`MaxAutoLockRenewalDuration` property. However, there are times when the lock may be lost due to 
a transient network issue. The lock can also be considered lost if the processing time exceeds 
the `MaxAutoLockRenewalDuration`. For these cases, the processor allows you to register a
handler for an event that is raised when the lock is lost. In the below examples, we show how 
the overall processing token can be linked to the lock lost event handler so that you can avoid 
expensive processing when you know the processor is shutting down or the message/session lock 
has been lost.

When using the `ServiceBusProcessor`:

```C# Snippet:ServiceBusProcessorLockLostHandler
string connectionString = "<connection_string>";
var client = new ServiceBusClient(connectionString);

// create a processor that we can use to process the messages
await using ServiceBusProcessor processor = client.CreateProcessor("<queue-name>");

// configure the message and error handler to use
processor.ProcessMessageAsync += MessageHandler;
processor.ProcessErrorAsync += ErrorHandler;

async Task MessageHandler(ProcessMessageEventArgs args)
{
    using var cts = CancellationTokenSource.CreateLinkedTokenSource(args.CancellationToken);

    try
    {
        args.MessageLockLostAsync += MessageLockLostHandler;

        // We thread our linked token through to our expensive processing so that we can cancel it in the event of a lock lost exception,
        // or when the processor is being stopped.
        await SomeExpensiveProcessingAsync(args.Message, cts.Token);
    }
    finally
    {
        // Finally, we remove the handler to avoid a memory leak.
        args.MessageLockLostAsync -= MessageLockLostHandler;
    }

    Task MessageLockLostHandler(MessageLockLostEventArgs lockLostArgs)
    {
        // We have access to the exception, if any, that triggered the lock lost event.
        // If no exception was provided, the lock was considered lost by the client based on the lock expiry time.
        Console.WriteLine(lockLostArgs.Exception);
        cts.Cancel();
        return Task.CompletedTask;
    }
}

Task ErrorHandler(ProcessErrorEventArgs args)
{
    // the error source tells me at what point in the processing an error occurred
    Console.WriteLine(args.ErrorSource);
    // the fully qualified namespace is available
    Console.WriteLine(args.FullyQualifiedNamespace);
    // as well as the entity path
    Console.WriteLine(args.EntityPath);
    Console.WriteLine(args.Exception.ToString());
    return Task.CompletedTask;
}

// start processing
await processor.StartProcessingAsync();

// since the processing happens in the background, we add a Console.ReadKey to allow the processing to continue until a key is pressed.
Console.ReadKey();
```

Here is what the code would look like when using the `ServiceBusSessionProcessor`:

```C# Snippet:ServiceBusSessionProcessorLockLostHandler
string connectionString = "<connection_string>";
var client = new ServiceBusClient(connectionString);

// create a processor that we can use to process the messages
await using ServiceBusSessionProcessor processor = client.CreateSessionProcessor("<queue-name>");

// configure the message and error handler to use
processor.ProcessMessageAsync += MessageHandler;
processor.ProcessErrorAsync += ErrorHandler;

async Task MessageHandler(ProcessSessionMessageEventArgs args)
{
    using var cts = CancellationTokenSource.CreateLinkedTokenSource(args.CancellationToken);

    try
    {
        args.SessionLockLostAsync += SessionLockLostHandler;

        // We thread our linked token through to our expensive processing so that we can cancel it in the event of a lock lost exception,
        // or when the processor is being stopped.
        await SomeExpensiveProcessingAsync(args.Message, cts.Token);
    }
    finally
    {
        // Finally, we remove the handler to avoid a memory leak.
        args.SessionLockLostAsync -= SessionLockLostHandler;
    }

    Task SessionLockLostHandler(SessionLockLostEventArgs lockLostArgs)
    {
        // We have access to the exception, if any, that triggered the lock lost event.
        // If no exception was provided, the lock was considered lost by the client based on the lock expiry time.
        Console.WriteLine(lockLostArgs.Exception);
        cts.Cancel();
        return Task.CompletedTask;
    }
}

Task ErrorHandler(ProcessErrorEventArgs args)
{
    // the error source tells me at what point in the processing an error occurred
    Console.WriteLine(args.ErrorSource);
    // the fully qualified namespace is available
    Console.WriteLine(args.FullyQualifiedNamespace);
    // as well as the entity path
    Console.WriteLine(args.EntityPath);
    Console.WriteLine(args.Exception.ToString());
    return Task.CompletedTask;
}

// start processing
await processor.StartProcessingAsync();

// since the processing happens in the background, we add a Console.ReadKey to allow the processing to continue until a key is pressed.
Console.ReadKey();
```
