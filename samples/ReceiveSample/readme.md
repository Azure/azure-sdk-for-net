# Get started receiving from Service Bus queues

In order to run the sample in this directory, replace the following bracketed values in the `Program.cs` file.

```csharp
private const string ServiceBusConnectionString = "{Service Bus connection string}";
private const string QueueName = "{Queue path/name}";
```


Once you replace the above values run the following from a command prompt:
   
```
dotnet restore
dotnet build
dotnet run
```

For further information on how to create this sample on your own, follow the rest of the tutorial.

## What will be accomplished
In this tutorial, we will write a console application to receive messages from a Service Bus queue.

## Prerequisites
1. [.NET Core](https://www.microsoft.com/net/core)
2. An Azure subscription.
3. [A Service Bus namespace](https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-create-namespace-portal) 
4. [A Service Bus queue](https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-dotnet-get-started-with-queues#2-create-a-queue-using-the-azure-portal)

### Create a console application

- Create a new .NET Core application. Check out [this link](https://docs.microsoft.com/en-us/dotnet/articles/core/getting-started) with help to create a new application on your operating system.

### Add the Service Bus client reference

1. Add the following to your project.json, making sure that the solution references the `Microsoft.Azure.ServiceBus` project.

    ```json
    "Microsoft.Azure.ServiceBus": "0.0.2-preview"
    ```

### Write some code to receive messages from a queue
1. Add the following using statement to the top of the Program.cs file.
   
    ```csharp
    using Microsoft.Azure.ServiceBus;
    ```

1. Add the following private variables to the `Program` class, and replace the placeholder values:
    
    ```csharp
    private static QueueClient queueClient;
    private const string ServiceBusConnectionString = "{Service Bus connection string}";
    private const string QueueName = "{Queue path/name}";
    ```

1. Create a new method called `ReceiveMessages` with the following code:

    ```csharp
    try
    {
        // Register a OnMessage callback
        queueClient.RegisterMessageHandler(
            async (message, token) =>
            {
                // Process the message
                Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");

                // Complete the message so that it is not received again.
                // This can be done only if the queueClient is opened in ReceiveMode.PeekLock mode.
                await queueClient.CompleteAsync(message.SystemProperties.LockToken);
            });
    }
    catch (Exception exception)
    {
        Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
    }
    ```

1. Create a new method called `MainAsync` with the following code:
   
    ```csharp
    private static async Task MainAsync(string[] args)
    {
        queueClient = new QueueClient(ServiceBusConnectionString, QueueName, ReceiveMode.PeekLock);
        ReceiveMessages();

        Console.WriteLine("Press any key to stop receiving messages.");
        Console.ReadKey();

        // Close the client after the ReceiveMessages method has exited.
        await queueClient.CloseAsync();
    }
    ```

1. Add the following code to the `Main` method:
    
    ```csharp
    MainAsync(args).GetAwaiter().GetResult();
    ```

1. Run the program, and check the Azure portal. Click the name of your queue in the namespace **Overview** blade. Notice that the **Active message count** value should now be 0.
   
Congratulations! You have now received messages from a Service Bus queue, using .NET Core.
