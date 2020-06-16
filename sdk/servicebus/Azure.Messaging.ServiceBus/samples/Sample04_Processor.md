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

// create a message batch that we can send
ServiceBusMessageBatch messageBatch = await sender.CreateBatchAsync();
messageBatch.TryAdd(new ServiceBusMessage(Encoding.UTF8.GetBytes("First")));
messageBatch.TryAdd(new ServiceBusMessage(Encoding.UTF8.GetBytes("Second")));

// send the message batch
await sender.SendAsync(messageBatch);

// get the options to use for configuring the processor
var options = new ServiceBusProcessorOptions
{
    // By default after the message handler returns, the processor will complete the message
    // If I want more fine-grained control over settlement, I can set this to false.
    AutoComplete = false,

    // I can also allow for multi-threading
    MaxConcurrentCalls = 2
};

// create a processor that we can use to process the messages
ServiceBusProcessor processor = client.CreateProcessor(queueName, options);

// since the message handler will run in a background thread, in order to prevent
// this sample from terminating immediately, we can use a task completion source that
// we complete from within the message handler.
TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
processor.ProcessMessageAsync += MessageHandler;
processor.ProcessErrorAsync += ErrorHandler;

async Task MessageHandler(ProcessMessageEventArgs args)
{
    string body = args.Message.Body.ToString();
    Console.WriteLine(body);

    // we can evaluate application logic and use that to determine how to settle the message.
    await args.CompleteAsync(args.Message);
    tcs.SetResult(true);
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
await processor.StartProcessingAsync();

// await our task completion source task so that the message handler will be invoked at least once.
await tcs.Task;

// stop processing once the task completion source was completed.
await processor.StopProcessingAsync();
```

### Processing messages from a session-enabled queue

Processing session messages is performed with a `ServiceBusSessionProcessor`. This type
derives from `ServiceBusProcessor` and exposes session-related functionality.

```C# Snippet:ServiceBusProcessSessionMessages
string connectionString = "<connection_string>";
string queueName = "<queue_name>";
// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using var client = new ServiceBusClient(connectionString);

// create the sender
ServiceBusSender sender = client.CreateSender(queueName);

// create a message batch that we can send
ServiceBusMessageBatch messageBatch = await sender.CreateBatchAsync();
messageBatch.TryAdd(
    new ServiceBusMessage(Encoding.UTF8.GetBytes("First"))
    {
        SessionId = "Session1"
    });
messageBatch.TryAdd(
    new ServiceBusMessage(Encoding.UTF8.GetBytes("Second"))
    {
        SessionId = "Session2"
    });

// send the message batch
await sender.SendAsync(messageBatch);

// get the options to use for configuring the processor
var options = new ServiceBusSessionProcessorOptions
{
    // By default after the message handler returns, the processor will complete the message
    // If I want more fine-grained control over settlement, I can set this to false.
    AutoComplete = false,

    // I can also allow for multi-threading
    MaxConcurrentCalls = 2
};

// create a session processor that we can use to process the messages
ServiceBusSessionProcessor processor = client.CreateSessionProcessor(queueName, options);

// since the message handler will run in a background thread, in order to prevent
// this sample from terminating immediately, we can use a task completion source that
// we complete from within the message handler.
TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
processor.ProcessMessageAsync += MessageHandler;
processor.ProcessErrorAsync += ErrorHandler;

async Task MessageHandler(ProcessSessionMessageEventArgs args)
{
    var body = args.Message.Body.ToString();

    // we can evaluate application logic and use that to determine how to settle the message.
    await args.CompleteAsync(args.Message);

    // we can also set arbitrary session state using this receiver
    // the state is specific to the session, and not any particular message
    await args.SetSessionStateAsync(Encoding.Default.GetBytes("some state"));
    tcs.SetResult(true);
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
await processor.StartProcessingAsync();

// await our task completion source task so that the message handler will be invoked at least once.
await tcs.Task;

// stop processing once the task completion source was completed.
await processor.StopProcessingAsync();
```

## Source

To see the full example source, see:

* [Sample04_Processor.cs](../tests/Samples/Sample04_Processor.cs)
