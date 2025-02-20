# Extensibility

This sample demonstrates how the key Service Bus types can be extended to provide custom functionality. As an example, we will demonstrate how messages can be intercepted and enriched before sending and after receiving. This mimics the functionality enabled by the `RegisterPlugin` method on client types in `Microsoft.Azure.ServiceBus`.

## Extending the types

In our derived classes, we will allow consumers to specify code that should be run for incoming and outgoing messages.

Here is how we define our `PluginSender`:
```C# Snippet:PluginSender
public class PluginSender : ServiceBusSender
{
    private IEnumerable<Func<ServiceBusMessage, Task>> _plugins;

    internal PluginSender(string queueOrTopicName, ServiceBusClient client, IEnumerable<Func<ServiceBusMessage, Task>> plugins) : base(client, queueOrTopicName)
    {
        _plugins = plugins;
    }

    public override async Task SendMessageAsync(ServiceBusMessage message, CancellationToken cancellationToken = default)
    {
        foreach (var plugin in _plugins)
        {
            await plugin.Invoke(message);
        }
        await base.SendMessageAsync(message, cancellationToken).ConfigureAwait(false);
    }
}
```

and here is our `PluginReceiver`:
```C# Snippet:PluginReceiver
public class PluginReceiver : ServiceBusReceiver
{
    private IEnumerable<Func<ServiceBusReceivedMessage, Task>> _plugins;

    internal PluginReceiver(string queueName, ServiceBusClient client, IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins, ServiceBusReceiverOptions options) :
        base(client, queueName, options)
    {
        _plugins = plugins;
    }

    internal PluginReceiver(string topicName, string subscriptionName, ServiceBusClient client, IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins, ServiceBusReceiverOptions options) :
        base(client, topicName, subscriptionName, options)
    {
        _plugins = plugins;
    }

    public override async Task<ServiceBusReceivedMessage> ReceiveMessageAsync(TimeSpan? maxWaitTime = null, CancellationToken cancellationToken = default)
    {
        ServiceBusReceivedMessage message = await base.ReceiveMessageAsync(maxWaitTime, cancellationToken).ConfigureAwait(false);

        foreach (var plugin in _plugins)
        {
            await plugin.Invoke(message);
        }
        return message;
    }
}
```

For good measure, we will also add in a `PluginProcessor`:
```C# Snippet:PluginProcessor
public class PluginProcessor : ServiceBusProcessor
{
    private IEnumerable<Func<ServiceBusReceivedMessage, Task>> _plugins;

    internal PluginProcessor(string queueName, ServiceBusClient client, IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins, ServiceBusProcessorOptions options) :
        base(client, queueName, options)
    {
        _plugins = plugins;
    }

    internal PluginProcessor(string topicName, string subscriptionName, ServiceBusClient client, IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins, ServiceBusProcessorOptions options) :
        base(client, topicName, subscriptionName, options)
    {
        _plugins = plugins;
    }

    protected override async Task OnProcessMessageAsync(ProcessMessageEventArgs args)
    {
        foreach (var plugin in _plugins)
        {
            await plugin.Invoke(args.Message);
        }

        await base.OnProcessMessageAsync(args);
    }
}
```

And a `PluginSessionProcessor`:
```C# Snippet:PluginSessionProcessor
public class PluginSessionProcessor : ServiceBusSessionProcessor
{
    private IEnumerable<Func<ServiceBusReceivedMessage, Task>> _plugins;

    internal PluginSessionProcessor(string queueName, ServiceBusClient client, IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins, ServiceBusSessionProcessorOptions options) :
        base(client, queueName, options)
    {
        _plugins = plugins;
    }

    internal PluginSessionProcessor(string topicName, string subscriptionName, ServiceBusClient client, IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins, ServiceBusSessionProcessorOptions options) :
        base(client, topicName, subscriptionName, options)
    {
        _plugins = plugins;
    }

    protected override async Task OnProcessSessionMessageAsync(ProcessSessionMessageEventArgs args)
    {
        foreach (var plugin in _plugins)
        {
            await plugin.Invoke(args.Message);
        }

        await base.OnProcessSessionMessageAsync(args);
    }

    protected override Task OnProcessErrorAsync(ProcessErrorEventArgs args)
    {
        return Task.CompletedTask;
    }
}
```

## Defining extension methods
Since the `ServiceBusClient` manages the underlying connection for the senders, receivers, and processors, we will add extension methods to `ServiceBusClient` that will let us create the derived versions of the sender, receiver, and processor.
Here is how we define our extension methods so that these types can be created via the `ServiceBusClient`:

```C# Snippet:ServiceBusExtensions
public static PluginSender CreatePluginSender(
    this ServiceBusClient client,
    string queueOrTopicName,
    IEnumerable<Func<ServiceBusMessage, Task>> plugins)
{
    return new PluginSender(queueOrTopicName, client, plugins);
}

public static PluginReceiver CreatePluginReceiver(
    this ServiceBusClient client,
    string queueName,
    IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins,
    ServiceBusReceiverOptions options = default)
{
    return new PluginReceiver(queueName, client, plugins, options ?? new ServiceBusReceiverOptions());
}

public static PluginReceiver CreatePluginReceiver(
    this ServiceBusClient client,
    string topicName,
    string subscriptionName,
    IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins,
    ServiceBusReceiverOptions options = default)
{
    return new PluginReceiver(topicName, subscriptionName, client, plugins, options ?? new ServiceBusReceiverOptions());
}

public static PluginProcessor CreatePluginProcessor(
    this ServiceBusClient client,
    string queueName,
    IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins,
    ServiceBusProcessorOptions options = default)
{
    return new PluginProcessor(queueName, client, plugins, options ?? new ServiceBusProcessorOptions());
}

public static PluginProcessor CreatePluginProcessor(
    this ServiceBusClient client,
    string topicName,
    string subscriptionName,
    IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins,
    ServiceBusProcessorOptions options = default)
{
    return new PluginProcessor(topicName, subscriptionName, client, plugins, options ?? new ServiceBusProcessorOptions());
}

public static PluginSessionProcessor CreatePluginSessionProcessor(
    this ServiceBusClient client,
    string queueName,
    IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins,
    ServiceBusSessionProcessorOptions options = default)
{
    return new PluginSessionProcessor(queueName, client, plugins, options ?? new ServiceBusSessionProcessorOptions());
}

public static PluginSessionProcessor CreatePluginSessionProcessor(
    this ServiceBusClient client,
    string topicName,
    string subscriptionName,
    IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins,
    ServiceBusSessionProcessorOptions options = default)
{
    return new PluginSessionProcessor(topicName, subscriptionName, client, plugins, options ?? new ServiceBusSessionProcessorOptions());
}
```

Finally, here is how consuming code might use these types. Since we have derived from the library types, the only thing that would need to be updated to use this pattern is the place where the derived types are created. All other usages can be left as is:

```C# Snippet:End2EndPluginReceiver
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";
// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
await using ServiceBusSender sender = client.CreatePluginSender(queueName, new List<Func<ServiceBusMessage, Task>>()
{
    message =>
    {
        message.Subject = "Updated subject";
        Console.WriteLine("First send plugin executed!");
        return Task.CompletedTask;
    },
    message =>
    {
        Console.WriteLine(message.Subject); // prints "Updated subject"
        Console.WriteLine("Second send plugin executed!");
        return Task.CompletedTask;
    },
});

await sender.SendMessageAsync(new ServiceBusMessage(Encoding.UTF8.GetBytes("First")));
await using ServiceBusReceiver receiver = client.CreatePluginReceiver(queueName, new List<Func<ServiceBusReceivedMessage, Task>>()
{
    message =>
    {
        Console.WriteLine("First receive plugin executed!");
        var rawMessage = message.GetRawAmqpMessage();
        rawMessage.Properties.Subject = "Received subject";
        return Task.CompletedTask;
    },
    message =>
    {
        Console.WriteLine(message.Subject); // prints "Received subject"
        var rawMessage = message.GetRawAmqpMessage();
        rawMessage.Properties.Subject = "Last subject";
        Console.WriteLine("Second receive plugin executed!");
        return Task.CompletedTask;
    },
});
ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync();
Console.WriteLine(message.Subject);
```

And using the processor:

```C# Snippet:End2EndPluginProcessor
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";
// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
await using ServiceBusSender sender = client.CreatePluginSender(queueName, new List<Func<ServiceBusMessage, Task>>()
{
    message =>
    {
        message.Subject = "Updated subject";
        Console.WriteLine("First send plugin executed!");
        return Task.CompletedTask;
    },
    message =>
    {
        Console.WriteLine(message.Subject); // prints "Updated subject"
        Console.WriteLine("Second send plugin executed!");
        return Task.CompletedTask;
    },
});

await sender.SendMessageAsync(new ServiceBusMessage(Encoding.UTF8.GetBytes("First")));
await using ServiceBusProcessor processor = client.CreatePluginProcessor(queueName, new List<Func<ServiceBusReceivedMessage, Task>>()
{
    message =>
    {
        Console.WriteLine("First receive plugin executed!");
        Console.WriteLine(message.Subject); // prints "Updated subject"
        var rawMessage = message.GetRawAmqpMessage();
        rawMessage.Properties.Subject = "Received subject";
        return Task.CompletedTask;
    },
    message =>
    {
        Console.WriteLine(message.Subject); // prints "Received subject"
        Console.WriteLine("Second receive plugin executed!");
        var rawMessage = message.GetRawAmqpMessage();
        rawMessage.Properties.Subject = "Last subject";
        return Task.CompletedTask;
    },
});
processor.ProcessMessageAsync += args =>
{
    Console.WriteLine($"Message handler executed. Subject: {args.Message.Subject}");
    return Task.CompletedTask;
};

processor.ProcessErrorAsync += args =>
{
    Console.WriteLine(args.Exception);
    return Task.CompletedTask;
};

await processor.StartProcessingAsync();
Console.ReadKey();
```

And the session processor:
```C# Snippet:End2EndPluginSessionProcessor
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";
// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
await using ServiceBusSender sender = client.CreatePluginSender(queueName, new List<Func<ServiceBusMessage, Task>>()
{
    message =>
    {
        message.Subject = "Updated subject";
        message.SessionId = "sessionId";
        Console.WriteLine("First send plugin executed!");
    return Task.CompletedTask;
    },
    message =>
    {
        Console.WriteLine(message.Subject); // prints "Updated subject"
        Console.WriteLine(message.SessionId); // prints "sessionId"
        Console.WriteLine("Second send plugin executed!");
        return Task.CompletedTask;
    },
});

await sender.SendMessageAsync(new ServiceBusMessage(Encoding.UTF8.GetBytes("First")));

await using ServiceBusSessionProcessor processor = client.CreatePluginSessionProcessor(queueName, new List<Func<ServiceBusReceivedMessage, Task>>()
{
    message =>
    {
        var rawMessage = message.GetRawAmqpMessage();
        rawMessage.Properties.Subject = "Received subject";
        Console.WriteLine("First receive plugin executed!");
        return Task.CompletedTask;
    },
    message =>
    {
        Console.WriteLine(message.Subject); // prints "Received subject"
        var rawMessage = message.GetRawAmqpMessage();
        rawMessage.Properties.Subject = "Last subject";
        Console.WriteLine("Second receive plugin executed!");
        return Task.CompletedTask;
    },
});

processor.ProcessMessageAsync += args =>
{
    Console.WriteLine(args.Message.Subject);
    return Task.CompletedTask;
};

processor.ProcessErrorAsync += args =>
{
    Console.WriteLine(args.Exception);
    return Task.CompletedTask;
};

await processor.StartProcessingAsync();
Console.ReadKey();
```
