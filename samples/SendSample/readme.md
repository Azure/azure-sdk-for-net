# Get started sending to Service Bus queues

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
In this tutorial, we will write a console application to send messages to a Service Bus queue.

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
    "Microsoft.Azure.ServiceBus": {
        "target": "project"
    }
    ```

### Write some code to send a message to a queue
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

1. Create a new method called `SendMessagesToQueue` with the following code:

    ```csharp
    // Creates a Queue client and sends 10 messages to the queue.
    private static async Task SendMessagesToQueue(int numMessagesToSend)
    {
        for (var i = 0; i < numMessagesToSend; i++)
        {
            try
            {
                // Create a new brokered message to send to the queue
                var message = new Message($"Message {i}");

                // Write the body of the message to the console
                Console.WriteLine($"Sending message: {message.GetBody<string>()}");

                // Send the message to the queue
                await queueClient.SendAsync(message);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
            }

            // Delay by 10 milliseconds so that the console can keep up
            await Task.Delay(10);
        }

        Console.WriteLine($"{numMessagesToSend} messages sent.");
    }
    ```

1. Create a new method called `MainAsync` with the following code:
   
    ```csharp
    private static async Task MainAsync(string[] args)
    {
        queueClient = new QueueClient(ServiceBusConnectionString, QueueName, ReceiveMode.PeekLock);
        await SendMessagesToQueue(10);

        // Close the client after the ReceiveMessages method has exited.
        await queueClient.CloseAsync();

        Console.WriteLine("Press any key to exit.");
        Console.ReadLine();
    }
    ```

1. Add the following code to the `Main` method:
    
    ```csharp
    MainAsync(args).GetAwaiter().GetResult();
    ```

1. Run the program, and check the Azure portal. Click the name of your queue in the namespace **Overview** blade. Notice that the **Active message count** value should now be 10.
   
Congratulations! You have now sent messages to a Service Bus queue, using .NET Core.

## Next steps
  * [Receive messages from a Service Bus queue](../ReceiveSample/readme.md)