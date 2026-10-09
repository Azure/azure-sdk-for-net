# Advanced processor mocking

The [mocking client types sample](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.Messaging.ServiceBus/samples/Sample15_MockingClientTypes.md) covers the recommended approach for most tests: call application handlers directly, or use Moq callbacks to simulate starting and stopping a processor.

Some integration-style tests also need to verify which handlers the application registered on a `ServiceBusProcessor` or `ServiceBusSessionProcessor`. Both processor types provide protected methods that derived test types can expose to dispatch events through the registered handlers. This approach does not connect to Service Bus.

## Test a `ServiceBusProcessor`

Define a test-only subclass that exposes the protected message and error dispatch methods:

```C# Snippet:ServiceBus_TestableProcessor
public sealed class TestableServiceBusProcessor : ServiceBusProcessor
{
    public Task RaiseProcessMessageAsync(ProcessMessageEventArgs args) =>
        base.OnProcessMessageAsync(args);

    public Task RaiseProcessErrorAsync(ProcessErrorEventArgs args) =>
        base.OnProcessErrorAsync(args);
}
```

The following test registers handlers on the processor and invokes them through the test shim. `TestableServiceBusProcessor` is defined after the usage example in the compiled sample.

```C# Snippet:ServiceBus_AdvancedProcessorMocking
TestableServiceBusProcessor processor = new();
string processedMessageId = null;
bool errorHandled = false;

Task MessageHandler(ProcessMessageEventArgs args)
{
    processedMessageId = args.Message.MessageId;
    return Task.CompletedTask;
}

Task ErrorHandler(ProcessErrorEventArgs args)
{
    errorHandled = true;
    return Task.CompletedTask;
}

try
{
    processor.ProcessMessageAsync += MessageHandler;
    processor.ProcessErrorAsync += ErrorHandler;

    ServiceBusReceivedMessage message =
        ServiceBusModelFactory.ServiceBusReceivedMessage(messageId: "message-id");
    Mock<ServiceBusReceiver> receiver = new();

    ProcessMessageEventArgs messageArgs = new(
        message,
        receiver.Object,
        CancellationToken.None);

    ProcessErrorEventArgs errorArgs = new(
        new InvalidOperationException("Simulated processor error"),
        ServiceBusErrorSource.Receive,
        "namespace.servicebus.windows.net",
        "queue-name",
        CancellationToken.None);

    await processor.RaiseProcessMessageAsync(messageArgs);
    await processor.RaiseProcessErrorAsync(errorArgs);

    Assert.That(processedMessageId, Is.EqualTo("message-id"));
    Assert.That(errorHandled, Is.True);
}
finally
{
    processor.ProcessMessageAsync -= MessageHandler;
    processor.ProcessErrorAsync -= ErrorHandler;
}
```

## Test a `ServiceBusSessionProcessor`

The parameterless session processor constructor is intended for mocking. Its event accessors delegate to an inner `ServiceBusProcessor`, so the test shim supplies a testable inner processor and exposes the session-specific dispatch methods:

```C# Snippet:ServiceBus_TestableSessionProcessor
public sealed class TestableServiceBusSessionProcessor : ServiceBusSessionProcessor
{
    protected override ServiceBusProcessor InnerProcessor { get; } =
        new TestableServiceBusProcessor();

    public Task RaiseProcessMessageAsync(ProcessSessionMessageEventArgs args) =>
        base.OnProcessSessionMessageAsync(args);

    public Task RaiseProcessErrorAsync(ProcessErrorEventArgs args) =>
        base.OnProcessErrorAsync(args);

    public Task RaiseSessionInitializingAsync(ProcessSessionEventArgs args) =>
        base.OnSessionInitializingAsync(args);

    public Task RaiseSessionClosingAsync(ProcessSessionEventArgs args) =>
        base.OnSessionClosingAsync(args);
}
```

Register the application handlers and invoke each lifecycle event through the shim. `TestableServiceBusSessionProcessor` is defined after the usage example in the compiled sample.

```C# Snippet:ServiceBus_AdvancedSessionProcessorMocking
TestableServiceBusSessionProcessor processor = new();
List<string> invokedHandlers = new();

Task MessageHandler(ProcessSessionMessageEventArgs args)
{
    invokedHandlers.Add($"message:{args.Message.MessageId}");
    return Task.CompletedTask;
}

Task ErrorHandler(ProcessErrorEventArgs args)
{
    invokedHandlers.Add("error");
    return Task.CompletedTask;
}

Task SessionInitializingHandler(ProcessSessionEventArgs args)
{
    invokedHandlers.Add($"opening:{args.SessionId}");
    return Task.CompletedTask;
}

Task SessionClosingHandler(ProcessSessionEventArgs args)
{
    invokedHandlers.Add($"closing:{args.SessionId}");
    return Task.CompletedTask;
}

try
{
    processor.ProcessMessageAsync += MessageHandler;
    processor.ProcessErrorAsync += ErrorHandler;
    processor.SessionInitializingAsync += SessionInitializingHandler;
    processor.SessionClosingAsync += SessionClosingHandler;

    Mock<ServiceBusSessionReceiver> receiver = new();
    receiver.SetupGet(value => value.SessionId).Returns("session-id");

    ServiceBusReceivedMessage message =
        ServiceBusModelFactory.ServiceBusReceivedMessage(
            messageId: "message-id",
            sessionId: "session-id");

    ProcessSessionMessageEventArgs messageArgs = new(
        message,
        receiver.Object,
        CancellationToken.None);

    ProcessErrorEventArgs errorArgs = new(
        new InvalidOperationException("Simulated processor error"),
        ServiceBusErrorSource.Receive,
        "namespace.servicebus.windows.net",
        "queue-name",
        CancellationToken.None);

    ProcessSessionEventArgs sessionArgs = new(
        receiver.Object,
        CancellationToken.None);

    await processor.RaiseSessionInitializingAsync(sessionArgs);
    await processor.RaiseProcessMessageAsync(messageArgs);
    await processor.RaiseProcessErrorAsync(errorArgs);
    await processor.RaiseSessionClosingAsync(sessionArgs);

    Assert.That(
        invokedHandlers,
        Is.EqualTo(new[]
        {
            "opening:session-id",
            "message:message-id",
            "error",
            "closing:session-id"
        }));
}
finally
{
    processor.ProcessMessageAsync -= MessageHandler;
    processor.ProcessErrorAsync -= ErrorHandler;
    processor.SessionInitializingAsync -= SessionInitializingHandler;
    processor.SessionClosingAsync -= SessionClosingHandler;
}
```
