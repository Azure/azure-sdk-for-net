## Using the Processor

This sample demonstrates how to use the processor. The processor offers automatic completion of processed messages, automatic message lock renewal, and concurrent execution of user specified event handlers.

### Processing messages

```C# Snippet:ServiceBusProcessMessages
string connectionString = "<connection_string>";
string queueName = "<queue_name>";
// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using var client = new ServiceBusClient(connectionString);

// create the sender
ServiceBusSender sender = client.CreateSender(queueName);

// create a set of messages that we can send
ServiceBusMessage[] messages = new ServiceBusMessage[]
{
    new ServiceBusMessage("First"),
    new ServiceBusMessage("Second")
};

// send the message batch
await sender.SendMessagesAsync(messages);

// create the options to use for configuring the processor
var options = new ServiceBusProcessorOptions
{
    // By default or when AutoCompleteMessages is set to true, the processor will complete the message after executing the message handler
    // Set AutoCompleteMessages to false to [settle messages](https://docs.microsoft.com/en-us/azure/service-bus-messaging/message-transfers-locks-settlement#peeklock) on your own.
    // In both cases, if the message handler throws an exception without settling the message, the processor will abandon the message.
    AutoCompleteMessages = false,

    // I can also allow for multi-threading
    MaxConcurrentCalls = 2
};

// create a processor that we can use to process the messages
await using ServiceBusProcessor processor = client.CreateProcessor(queueName, options);

// configure the message and error handler to use
processor.ProcessMessageAsync += MessageHandler;
processor.ProcessErrorAsync += ErrorHandler;

async Task MessageHandler(ProcessMessageEventArgs args)
{
    string body = args.Message.Body.ToString();
    Console.WriteLine(body);

    // we can evaluate application logic and use that to determine how to settle the message.
    await args.CompleteMessageAsync(args.Message);
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

// since the processing happens in the background, we add a Conole.ReadKey to allow the processing to continue until a key is pressed.
Console.ReadKey();
```

## Source

To see the full example source, see:

* [Sample04_Processor.cs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/tests/Samples/Sample04_Processor.cs)
