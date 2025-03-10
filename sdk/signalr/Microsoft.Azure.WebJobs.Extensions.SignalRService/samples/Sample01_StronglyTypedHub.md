# Strongly Typed Serverless Hub

Strongly typed serverless hub is a programming model which allows you to define your SignalR client methods in an interface, and the RPC implementation will be done by SignalR.

This sample demonstrates how to create a strongly typed serverless hub and invoke SignalR client methods in it. To see more details on serverless hub, please go [here](https://learn.microsoft.com/azure/azure-signalr/signalr-concept-serverless-development-config#class-based-model).

## Define a strongly typed serverless hub class

Let's say you want to invoke a SignalR client method `ReceiveMessage` with a string parameter when a HTTP request comes.

Firstly you need to define an interface for the client method.

```C# Snippet:StronglyTypedHub_ClientMethodInterface
public interface IChatClient
{
    Task ReceiveMessage(string message);
}
```

Then you creates a strongly typed hub with the interface:

```C# Snippet:StronglyTypedHub
public class StronglyTypedHub : ServerlessHub<IChatClient>
{
    [FunctionName(nameof(Broadcast))]
    public async Task Broadcast([HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequest _, string message)
    {
        await Clients.All.ReceiveMessage(message);
    }
}
```

## Call client methods

The code snippet above defines a method in the hub, which broadcasts the message to all the clients once triggered by HTTP request.
