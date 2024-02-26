
# Mocking Client Types

The Service Bus client library is built to support unit testing with mocks, as described in the [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking). This is an important feature of the library that allows developers to write tests that are completely focused on their own application logic, though they depend on Service Bus types.

The following examples focus on scenarios likely to occur in applications, and demonstrate how to mock the Service Bus types typically used in each scenario. The code snippets utilize the mock object framework, Moq, in order to provide practical examples. However, many mocking frameworks exist and can be used with the same approach in mind.

For more general information and examples on mocking with the Azure SDK, please see [Unit testing and mocking with the Azure SDK for .NET](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking).

## Table of contents

- **Sending and receiving messages**
  - [Sending a message to a queue](#sending-messages-to-a-queue)
  - [Receiving messages from a queue](#receiving-messages-from-a-queue)
  - [Sending a batch of messages](#sending-a-batch-of-messages)
  - [Sending and receiving messages using sessions](#session-sending-and-receiving)
  - [Sending using topics and subscriptions](#sending-using-topics-and-subscriptions)
  - [Receiving using topics and subscriptions](#receiving-using-topics-and-subscriptions)
  - [Peeking a message](#peeking-a-message)
- **Message Settlement**
  - [Completing a message](#completing-a-message)
  - [Deferring a message and receiving deferred messages](#deferring-a-message-and-receiving-deferred-messages)
  - [Abandoning a messages](#abandoning-a-message)
  - [Dead lettering a message](#dead-lettering-a-message)
- **Testing the processor**
  - [Testing the `ServiceBusProcessor` handlers](#for-the-servicebusprocessor)
  - [Testing the `ServiceBusSessionProcessor` handlers](#for-the-servicebussessionprocessor)
  - [Simulating the `ServiceBusProcessor` running](#for-the-servicebusprocessor-1)
  - [Simulating the `ServiceBusSessionProcessor` running](#for-the-servicebussessionprocessor-1)
- **CRUD operations**
  - [Getting `NamespaceProperties`](#get-namespace-properties-using-the-servicebusadministrationclient)
  - [Creating topics and subscriptions](#creating-topics-and-subscriptions-using-the-servicebusadministrationclient)
  - [Creating a queue](#creating-a-queue-using-the-servicebusadministrationclient)
  - [Creating a rule](#creating-a-rule-using-the-servicebusadministrationclient)
- **Rule Manager**
  - [Managing rules](#creating-and-deleting-rules-using-the-servicebusrulemanager)

## Sending messages to a queue

When sending messages to a Service Bus queue, the key interaction with the `ServiceBusSender` is calling `SendMessageAsync` and/or `SendMessagesAsync`. Mocking these calls is relatively straightforward. It may also be helpful for your application to mock the `CreateSender` call on the `ServiceBusClient`. This is demonstrated in the snippet below as well.

```C# Snippet:ServiceBus_MockingSendToQueue
Mock<ServiceBusClient> mockClient = new();
Mock<ServiceBusSender> mockSender = new();

// This sets up the mock ServiceBusClient to return the mock of the ServiceBusSender.

mockClient
    .Setup(client =>client.CreateSender(It.IsAny<string>()))
    .Returns(mockSender.Object);

// This sets up the mock sender to successfully return a completed task when any message is passed to
// SendMessageAsync.

mockSender
    .Setup(sender => sender.SendMessageAsync(
        It.IsAny<ServiceBusMessage>(),
        It.IsAny<CancellationToken>()))
    .Returns(Task.CompletedTask);

ServiceBusClient client = mockClient.Object;

// The rest of this snippet illustrates how to send a service bus message using the mocked
// service bus client above, this would be where application methods sending a message would be
// called.

string mockQueueName = "MockQueueName";
ServiceBusSender sender = client.CreateSender(mockQueueName);
ServiceBusMessage message = new("Hello World!");

await sender.SendMessageAsync(message);

// This illustrates how to verify that SendMessageAsync was called the correct number of times
// with the expected message.

mockSender
    .Verify(sender => sender.SendMessageAsync(
        It.Is<ServiceBusMessage>(m => (m.MessageId == message.MessageId)),
        It.IsAny<CancellationToken>()));
```

## Receiving messages from a queue

When testing code that is dependent on the `ServiceBusReceiver`, it may be useful to create a known set of expected messages to verify their application receives them correctly. Tests can mock `ServiceBusReceivedMessage` instances coming from the broker using the `ServiceBusModelFactory`. These can be used within the receiver mock to mock returns from `ReceiveMessageAsync` or `ReceiveMessagesAsync`. It may also be helpful for your application to mock the `CreateReceiver` call on the `ServiceBusClient`. This is demonstrated in the snippet below as well.

```C# Snippet:ServiceBus_MockingReceiveFromQueue
Mock<ServiceBusClient> mockClient = new();
Mock<ServiceBusReceiver> mockReceiver = new();

// This sets up the mock ServiceBusClient to return the mock of the ServiceBusReceiver.

mockClient
    .Setup(client => client.CreateReceiver(
        It.IsAny<string>()))
    .Returns(mockReceiver.Object);

List<ServiceBusReceivedMessage> messagesToReturn = new();
int numMessagesToReturn = 10;

// This creates a list of messages to return from the ServiceBusReceiver mock. See the ServiceBusModelFactory
// for a complete set of properties that can be populated using the ServiceBusModelFactory.ServiceBusReceivedMessage
// method.

for (int i=0; i < numMessagesToReturn; i++)
{
    // This mocks a ServiceBusReceivedMessage instance using the model factory. Different arguments can mock different
    // potential outputs from the broker.

    ServiceBusReceivedMessage message = ServiceBusModelFactory.ServiceBusReceivedMessage(
        body: new BinaryData($"message-{i}"),
        messageId: $"id-{i}",
        partitionKey: "illustrative-partitionKey",
        correlationId: "illustrative-correlationId",
        contentType: "illustrative-contentType",
        replyTo: "illustrative-replyTo"
        // ...
        );
    messagesToReturn.Add(message);
}

// This is a simple local method that returns an IAsyncEnumerable to use as the return for ReceiveMessagesAsync
// below, since IAsyncEnumerables cannot be created directly.

async IAsyncEnumerable<ServiceBusReceivedMessage> mockReturn()
{
    // IAsyncEnumerable types can only be returned by async functions, use this no-op await statement to
    // force the method to be async.

    await Task.Yield();

    foreach (ServiceBusReceivedMessage message in messagesToReturn)
    {
        // Yield statements allow methods to emit multiple outputs. In async methods this can be over time.

        yield return message;
    }
}

// Use the method to mock a return from the ServiceBusReceiver. We are setting up the method to method to return
// the list of messages defined above.

mockReceiver
    .Setup(receiver => receiver.ReceiveMessagesAsync(
        It.IsAny<CancellationToken>()))
    .Returns(mockReturn);

ServiceBusClient client = mockClient.Object;

// The rest of this snippet illustrates how to receive messages using the mocked ServiceBusClient above,
// this would be where application methods receiving messages would be called.

var mockQueueName = "MockQueueName";
ServiceBusReceiver receiver = client.CreateReceiver(mockQueueName);

var cancellationTokenSource = new CancellationTokenSource();
cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(2));

await foreach (ServiceBusReceivedMessage message in receiver.ReceiveMessagesAsync(cancellationTokenSource.Token))
{
    // Application would process received messages here...
}

// This is where applications can verify that the ServiceBusReceivedMessage's output by the ServiceBusReceiver were
// handled as expected.
```

## Sending a batch of messages

When using batches to send messages to a Service Bus queue, the key interactions with the `ServiceBusSender` are calling `CreateMessageBatchAsync` to create the batch, and `SendMessagesAsync` to send it. Mocked batches accept a `List<ServiceBusMessage>` that is used as a backing store and can be inspected to verify that the application is adding events to the batch as expected. The custom `TryAddMessage` callback can be used to control the decision for whether a message is accepted into the batch or rejected. 

This snippet demonstrates mocking the `ServiceBusReceiver` and creating a `ServiceBusMessageBatch` using the `ServiceBusModelFactory`.

```C# Snippet:ServiceBus_MockingSendBatch
Mock<ServiceBusClient> mockClient = new();
Mock<ServiceBusSender> mockSender = new();

// This sets up the mock ServiceBusClient to return the mock of the ServiceBusSender.

mockClient
    .Setup(client => client.CreateSender(It.IsAny<string>()))
    .Returns(mockSender.Object);

// As messages are added to the batch they will be added to this list as well. Altering the
// messages in this list will not change the messages in the batch, since they are stored inside
// the batch.

List<ServiceBusMessage> backingList = new();

// For illustrative purposes, this is the number of messages that the batch will contain, return
// false from TryAddMessage for any additional calls.

int batchCountThreshold = 5;

ServiceBusMessageBatch mockBatch = ServiceBusModelFactory.ServiceBusMessageBatch(
    batchSizeBytes: 500,
    batchMessageStore: backingList,
    batchOptions: new CreateMessageBatchOptions(),
    // The model factory allows a custom TryAddMessage callback, allowing control of
    // what messages the batch accepts.
    tryAddCallback: _=> backingList.Count < batchCountThreshold);

// This sets up a mock of the CreateMessageBatchAsync method, returning the batch that was previously
// mocked.

mockSender
    .Setup(sender => sender.CreateMessageBatchAsync(
        It.IsAny<CancellationToken>()))
    .ReturnsAsync(mockBatch);

// Here we are mocking the SendMessagesAsync method so it will throw an exception if the batch passed
// into it is not the one we are expecting to send.

mockSender
    .Setup(sender => sender.SendMessagesAsync(
        It.Is<ServiceBusMessageBatch>(sendBatch => sendBatch != mockBatch),
        It.IsAny<CancellationToken>()))
    .Returns(Task.CompletedTask);

ServiceBusClient client = mockClient.Object;

// The rest of this snippet illustrates how to send a message batch using the mocked
// service bus client above, this would be where application methods sending a batch would be
// called.

ServiceBusSender sender = client.CreateSender("mockQueueName");

ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync(CancellationToken.None);

// This is creating a list of messages to use in our test.

List<ServiceBusMessage> sourceMessages = new();

for (int index = 0; index < batchCountThreshold; index++)
{
    var message = new ServiceBusMessage($"Sample-Message-{index}");
    sourceMessages.Add(message);
}

// Here we are adding messages to the batch. They should all be accepted.

foreach (var message in sourceMessages)
{
    Assert.True(batch.TryAddMessage(message));
}

// Since there are already batchCountThreshold number of messages in the batch,
// this message will be rejected from the batch.

Assert.IsFalse(batch.TryAddMessage(new ServiceBusMessage("Too Many Messages.")));

// For illustrative purposes we are calling SendMessagesAsync. Application-defined methods
// would be called here instead.

await sender.SendMessagesAsync(batch);

mockSender
    .Verify(sender => sender.SendMessagesAsync(
        It.IsAny<ServiceBusMessageBatch>(),
        It.IsAny<CancellationToken>()),
    Times.Once);

// For illustrative purposes, check that the messages in the batch match what the application expects to have
// added.

foreach (ServiceBusMessage message in backingList)
{
    Assert.IsTrue(sourceMessages.Contains(message));
}
Assert.AreEqual(backingList.Count, sourceMessages.Count);
```

## Session sending and receiving

When sending session messages to a Service Bus queue, the key interaction with the `ServiceBusSender` is calling `SendMessageAsync` and/or `SendMessagesAsync` with a session id added to each `ServiceBusMessage` to send. Mocking these calls is relatively straightforward.

When receiving session messages from a Service Bus queue, the key interaction with the `ServiceBusSessionReceiver` is calling `ReceiveMessageAsync` and/or `ReceiveMessagesAsync`. In some cases, a developer may want to create a known set of expected events to verify that their application receives them correctly. This can be done for the `ServiceBusSessionReceiver` in the same manner as is demonstrated using the `ServiceBusReceiver` in the [Receiving messages from a queue](#receiving-messages-from-a-queue) section above. This snippet illustrates how to receive the same set of events that is passed in through the `SendMessageAsync` call.

It may be helpful for your application to mock the `CreateSender` and `AcceptNextSessionAsync` calls on the `ServiceBusClient` to create the `ServiceBusSender` and `ServiceBusSessionReceiver`. This is demonstrated in the snippet below. 

This snippet also demonstrates how to mock `GetSessionStateAsync` and `SetSessionStateAsync` for the `ServiceBusSessionReceiver`.

```C# Snippet:ServiceBus_MockingSessionReceiver
// This sets up the mock ServiceBusClient to return the mock ServiceBusSender.

Mock<ServiceBusClient> mockClient = new();
Mock<ServiceBusSender> mockSender = new();
Mock<ServiceBusSessionReceiver> mockSessionReceiver = new();

mockClient
    .Setup(client => client.CreateSender(It.IsAny<string>()))
    .Returns(mockSender.Object);

// This sets up the ServiceBusClient to return the mock ServiceBusSessionReceiver when
// AcceptNextSession is called.

mockClient
    .Setup(client => client.AcceptNextSessionAsync(
        It.IsAny<string>(),
        It.IsAny<ServiceBusSessionReceiverOptions>(),
        It.IsAny<CancellationToken>()))
    .ReturnsAsync(mockSessionReceiver.Object);

ServiceBusClient client = mockClient.Object;

// This sets up the session sender to enqueue each message passed into send to the queue of messages to return.

Queue<ServiceBusReceivedMessage> messagesToReturn = new();

mockSender
    .Setup(sender => sender.SendMessageAsync(
        It.IsAny<ServiceBusMessage>(),
        It.IsAny<CancellationToken>()))
    .Callback<ServiceBusMessage, CancellationToken>(
    (m,ct) => messagesToReturn.Enqueue(ServiceBusModelFactory.ServiceBusReceivedMessage(
        body:m.Body,
        messageId:m.MessageId,
        sessionId:m.SessionId)))
    .Returns(Task.CompletedTask);

// This sets up the receiver to return a message off of the queue, or return null if there are no messages waiting to be received.

mockSessionReceiver
    .Setup(receiver => receiver.ReceiveMessageAsync(
        It.IsAny<TimeSpan>(),
        It.IsAny<CancellationToken>()))
    .ReturnsAsync(() => { if (messagesToReturn.Count > 0) { return messagesToReturn.Dequeue(); } else { return null; } });

// This sets up the mocked ServiceBusSessionReceiver to be able to set and get session state.

BinaryData mockSessionState = new("notSet");

mockSessionReceiver
    .Setup(receiver => receiver.SetSessionStateAsync(
        It.IsAny<BinaryData>(),
        It.IsAny<CancellationToken>()))
    .Callback<BinaryData, CancellationToken>((st, ct) => mockSessionState = st)
    .Returns(Task.CompletedTask);

// ReturnsAsync needs to be called with a lambda in order to eagerly access the most up to date session state.

mockSessionReceiver
    .Setup(receiver => receiver.GetSessionStateAsync(
        It.IsAny<CancellationToken>()))
    .ReturnsAsync(() => mockSessionState);

// The rest of this snippet illustrates how to send and receive session messages using the mocked
// service bus client above, this would be where application methods using sessions would be
// called.

var mockQueueName = "MockQueueName";
ServiceBusSender sender = client.CreateSender(mockQueueName);

// This creates a set of messages to use in the test.

List<ServiceBusMessage> testSessionMessages = new();

var mockSessionId = "mySession";
var numMessagesInSession = 5;

for (var i = 0; i < numMessagesInSession; i++)
{
    ServiceBusMessage sentMessage = new($"message{i}")
    {
        SessionId = mockSessionId,
        MessageId = $"messageId{i}"
    };
    testSessionMessages.Add(sentMessage);
}

// This sends all of the messages defined above.

foreach (ServiceBusMessage message in testSessionMessages)
{
    await sender.SendMessageAsync(message);
}

// The last part of the test receives all of the messages sent to this session.

TimeSpan maxWait = TimeSpan.FromSeconds(30);

ServiceBusSessionReceiver sessionReceiver = await client.AcceptNextSessionAsync(mockQueueName, new ServiceBusSessionReceiverOptions(), CancellationToken.None);

ServiceBusReceivedMessage receivedMessage = await sessionReceiver.ReceiveMessageAsync(maxWait, CancellationToken.None);

BinaryData setState = new("MockState");
await sessionReceiver.SetSessionStateAsync(setState, CancellationToken.None);
BinaryData state = await sessionReceiver.GetSessionStateAsync(CancellationToken.None);

// For illustrative purposes, verify that the state of the session is what we expect.

Assert.AreEqual(setState, state);
```

## Sending using topics and subscriptions

This scenario is similar to the snippet above, [receiving messages from a queue](#receiving-messages-from-a-queue), except this one demonstrates how to send a set of messages using a topic and subscription.

```C# Snippet:ServiceBus_MockingTopicSubscriptionSend
Mock<ServiceBusClient> mockClient = new();
Mock<ServiceBusSender> mockSender = new();

// This sets up the mock ServiceBusClient to return the mock of the ServiceBusSender.

mockClient
    .Setup(client => client.CreateSender(It.IsAny<string>()))
    .Returns(mockSender.Object);

// This sets up the mock sender to successfully return a completed task when any message is passed to
// SendMessageAsync.

mockSender
    .Setup(sender => sender.SendMessageAsync(
        It.IsAny<ServiceBusMessage>(),
        It.IsAny<CancellationToken>()))
    .Returns(Task.CompletedTask);

ServiceBusClient client = mockClient.Object;

// The rest of this snippet illustrates how to send a service bus message using the mocked
// service bus client above, this would be where application methods sending a message would be
// called.

string mockTopicName = "MockTopicName";

ServiceBusSender sender = client.CreateSender(mockTopicName);
ServiceBusMessage message = new("Hello World!");

await sender.SendMessageAsync(message);

// This illustrates how to verify that SendMessageAsync was called the correct number of times
// with the expected message.

mockSender
    .Verify(sender => sender.SendMessageAsync(
        It.Is<ServiceBusMessage>(m => (m.MessageId == message.MessageId)),
        It.IsAny<CancellationToken>()));
```

## Receiving using topics and subscriptions

This snippet demonstrates how to receive messages using a topic and subscription with a `ServiceBusReceiver`. It demonstrates how to set up `ReceiveMessagesAsync` to return an `IAsyncEnumerable` with `ServiceBusReceivedMessage`s using the `ServiceBusModelFactory`.

```C# Snippet:ServiceBus_MockingTopicSubscriptionReceive
Mock<ServiceBusClient> mockClient = new();
Mock<ServiceBusReceiver> mockReceiver = new();

// This sets up the mock ServiceBusClient to return the mock of the ServiceBusReceiver.

mockClient
    .Setup(client => client.CreateReceiver(
        It.IsAny<string>(),
        It.IsAny<string>()))
    .Returns(mockReceiver.Object);

List<ServiceBusReceivedMessage> messagesToReturn = new();
int numMessagesToReturn = 10;

// This creates a list of messages to return from the ServiceBusReceiver mock. See the ServiceBusModelFactory
// for a complete set of properties that can be populated using the ServiceBusModelFactory.ServiceBusReceivedMessage
// method.

for (int i = 0; i < numMessagesToReturn; i++)
{
    // This mocks a ServiceBusReceivedMessage instance using the model factory. Different arguments can mock different
    // potential outputs from the broker.

    ServiceBusReceivedMessage message = ServiceBusModelFactory.ServiceBusReceivedMessage(
        body: new BinaryData($"message-{i}"),
        messageId: $"id-{i}",
        partitionKey: "illustrative-partitionKey",
        correlationId: "illustrative-correlationId",
        contentType: "illustrative-contentType",
        replyTo: "illustrative-replyTo"
        // ...
        );
    messagesToReturn.Add(message);
}

// This is a simple local method that returns an IAsyncEnumerable to use as the return for ReceiveMessagesAsync
// below, since IAsyncEnumerables cannot be created directly.

async IAsyncEnumerable<ServiceBusReceivedMessage> mockReturn()
{
    // IAsyncEnumerable types can only be returned by async functions, use this no-op await statement to
    // force the method to be async.

    await Task.Yield();

    foreach (ServiceBusReceivedMessage message in messagesToReturn)
    {
        // Yield statements allow methods to emit multiple outputs. In async methods this can be over time.

        yield return message;
    }
}

// Use the method to mock a return from the ServiceBusReceiver. We are setting up the method to method to return
// the list of messages defined above.

mockReceiver
    .Setup(receiver => receiver.ReceiveMessagesAsync(
        It.IsAny<CancellationToken>()))
    .Returns(mockReturn);

ServiceBusClient client = mockClient.Object;

// The rest of this snippet illustrates how to receive messages using the mocked ServiceBusClient above,
// this would be where application methods receiving messages would be called.

var mockTopicName = "MockTopicName";
var mockSubscriptionName = "MockSubscriptionName";
ServiceBusReceiver receiver = client.CreateReceiver(mockTopicName, mockSubscriptionName);

var cancellationTokenSource = new CancellationTokenSource();
cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(2));

await foreach (ServiceBusReceivedMessage message in receiver.ReceiveMessagesAsync(cancellationTokenSource.Token))
{
    // application control
}

// This is where applications can verify that the ServiceBusReceivedMessage's output by the ServiceBusReceiver were
// handled as expected.
```
## Peeking a message

The snippet below demonstrates how to mock a `ServiceBusReceiver` to return a pre-defined message for each call to `PeekMessageAsync`. It uses the `ServiceBusModelFactory` to mock the `ServiceBusReceivedMessage` to return.

```C# Snippet:ServiceBus_MockPeek
// This sets up the ServiceBusClient mock to return the ServiceBusReceiver mock.

Mock<ServiceBusClient> mockClient = new();
Mock<ServiceBusReceiver> mockReceiver = new();

mockClient
    .Setup(client => client.CreateReceiver(It.IsAny<string>()))
    .Returns(mockReceiver.Object);

ServiceBusClient client = mockClient.Object;

// This creates a list of messages to return from the ServiceBusReceiver mock. See the ServiceBusModelFactory
// for a complete set of properties that can be populated using the ServiceBusModelFactory.ServiceBusReceivedMessage method.

List<ServiceBusReceivedMessage> messagesToReturn = new();
int numMessages = 3;

for (int i = 0; i < numMessages; i++)
{
    string body = $"message-{i}";

    // This mocks a ServiceBusReceivedMessage instance using the model factory. Different arguments can mock different
    // potential outputs from the broker.

    ServiceBusReceivedMessage messageToReturn = ServiceBusModelFactory.ServiceBusReceivedMessage(
        body: new BinaryData(body),
        messageId: $"id-{i}",
        sequenceNumber: i,
        partitionKey: "illustrative-partitionKey",
        correlationId: "illustrative-correlationId",
        contentType: "illustrative-contentType",
        replyTo: "illustrative-replyTo"
        // ...
        );
    messagesToReturn.Add(messageToReturn);
}

// Set up peek to return the next message in the list of messages after each call.

int numCallsPeek = 0;
mockReceiver
    .Setup(receiver => receiver.PeekMessageAsync(
        It.IsAny<long>(),
        It.IsAny<CancellationToken>()))
    .ReturnsAsync(() =>
    {
        ServiceBusReceivedMessage m = messagesToReturn.ElementAtOrDefault(numCallsPeek);
        numCallsPeek++;
        return m;
    });

// The rest of this snippet illustrates how to peek a service bus message using the mocked
// service bus receiver above, this would be where application methods peeking a message would be
// called.

string mockQueueName = "MockQueue";
ServiceBusReceiver receiver = client.CreateReceiver(mockQueueName);

List<ServiceBusReceivedMessage> peekedMessages = new();

for (int i = 0; i < numMessages; i++)
{
    ServiceBusReceivedMessage peekedMessage = await receiver.PeekMessageAsync(0, CancellationToken.None);

    // Application would process the peaked message here ...

    peekedMessages.Add(peekedMessage);
}

mockReceiver
    .Verify(receiver => receiver.PeekMessageAsync(
        It.IsAny<long>(),
        It.IsAny<CancellationToken>()), Times.Exactly(numMessages));
```

## Message settlement

### Completing a message

Message settlement is a key aspect of receiving `ServiceBusReceivedMessages`. The following snippet demonstrates how to mock receiveing a message and then use the mock `ServiceBusReceiver` to complete the message. For illustrative purposes it demonstrates verifying that `ReceiveMessageAsync` and `CompleteMessageAsync` were called the same number of times.

```C# Snippet:ServiceBus_MockingComplete
// The first section sets up the ServiceBusClient to return the mock ServiceBusReceiver when CreateReceiver
// is called.

Mock<ServiceBusClient> mockClient = new();

ServiceBusClient client = mockClient.Object;

Mock<ServiceBusReceiver> mockReceiver = new();

mockClient
    .Setup(client => client.CreateReceiver(It.IsAny<string>()))
    .Returns(mockReceiver.Object);

// This creates a list of messages to return from the ServiceBusReceiver mock. See the ServiceBusModelFactory for a
// complete set of properties that can be populated using the ServiceBusModelFactory.ServiceBusReceivedMessage method.

List<ServiceBusReceivedMessage> messagesToReturn = new();
int numMessages= 3;

for (int i = 0; i < numMessages; i++)
{
    // This mocks a ServiceBusReceivedMessage instance using the model factory. Different arguments can mock different
    // potential outputs from the broker.

    ServiceBusReceivedMessage messageToReturn = ServiceBusModelFactory.ServiceBusReceivedMessage(
        body: new BinaryData($"message-{i}"),
        messageId: $"id-{i}",
        partitionKey: "illustrative-partitionKey",
        correlationId: "illustrative-correlationId",
        contentType: "illustrative-contentType",
        replyTo: "illustrative-replyTo"
        // ...
        );
    messagesToReturn.Add(messageToReturn);
}

// This sets up the mock ServiceBusReceiver to return a different message from the messagesToReturn
// list each time the method is called until there are no more messages.

int numCallsReceiveMessage = 0;
mockReceiver
    .Setup(receiver => receiver.ReceiveMessageAsync(
        It.IsAny<TimeSpan>(),
        It.IsAny<CancellationToken>())).Callback(() => numCallsReceiveMessage++)
    .ReturnsAsync(() => messagesToReturn.ElementAtOrDefault(numCallsReceiveMessage));

// This sets up the mock ServiceBusReceiver to keep track of how many times CompleteMessageAsync
// has been called in the numCallsCompleteMessage counter.

int numCallsCompleteMessage = 0;
mockReceiver
    .Setup(receiver => receiver.CompleteMessageAsync(
        It.IsAny<ServiceBusReceivedMessage>(),
        It.IsAny<CancellationToken>())).Callback(() => numCallsCompleteMessage++)
    .Returns(Task.CompletedTask);

// The rest of this snippet illustrates how to receive and complete a service bus message using the mocked
// service bus client above, this would be where application methods receiving and completing a message would be
// called.

string mockQueueName = "MockQueueName";
ServiceBusReceiver receiver = client.CreateReceiver(mockQueueName);

// ReceiveMessageAsync can be called multiple times.

List<ServiceBusReceivedMessage> receivedMessages = new();

for (int i = 0; i < numMessages; i++)
{
    ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(1), CancellationToken.None);
    receivedMessages.Add(receivedMessage);

    // Application would process received messages here...

    await receiver.CompleteMessageAsync(receivedMessage);
}

// For illustrative purposes, verify that the number of times a message was received is the same number of times
// a message was completed.

mockReceiver
    .Verify(receiver => receiver.CompleteMessageAsync(
        It.IsAny<ServiceBusReceivedMessage>(),
        It.IsAny<CancellationToken>()),
        Times.Exactly(numCallsReceiveMessage));
```

### Deferring a message and receiving deferred messages

When testing code that receives, defers, and then receives a deferred message, it may be useful to use a pre-determined set of messages that can be propagated through each mocked method. The following snippet demonstrates how to mock the call to `ReceiveMessageAsync`, `DeferMessageAsync`, and `ReceiveDeferredMessageAsync`. The pre-determined set of messages are returned through `ReceiveMessageAsync`. `DeferMessageAsync` and `ReceiveDeferredMessageAsync` use a shared dictionary mapping sequence numbers to `ServiceBusReceivedMessage` instances to keep track of deferred messages.

```C# Snippet:ServiceBus_MockDefer
// The first section sets up a mock ServiceBusReceiver.

Mock<ServiceBusClient> mockClient = new();
Mock<ServiceBusReceiver> mockReceiver = new();

mockClient
    .Setup(client => client.CreateReceiver(It.IsAny<string>()))
    .Returns(mockReceiver.Object);

ServiceBusClient client = mockClient.Object;

// This creates a list of messages to return from the ServiceBusReceiver mock. See the ServiceBusModelFactory
// for a complete set of properties that can be populated using the ServiceBusModelFactory.ServiceBusReceivedMessage method.

List<ServiceBusReceivedMessage> messagesToReturn = new();
int numMessages = 3;

for (int i = 0; i < numMessages; i++)
{
    string body = $"message-{i}";

    // This mocks a ServiceBusReceivedMessage instance using the model factory. Different arguments can mock different
    // potential outputs from the broker.

    ServiceBusReceivedMessage messageToReturn = ServiceBusModelFactory.ServiceBusReceivedMessage(
        body: new BinaryData(body),
        messageId: $"id-{i}",
        sequenceNumber: i, // this needs to be populated in order to defer each message
        partitionKey: "illustrative-partitionKey",
        correlationId: "illustrative-correlationId",
        contentType: "illustrative-contentType",
        replyTo: "illustrative-replyTo"
        // ...
        );
    messagesToReturn.Add(messageToReturn);
}

// This sets up the mock ServiceBusReceiver to return a different message from the messagesToReturn
// list each time the method is called until there are no more messages.

int numCallsReceiveMessage = 0;
mockReceiver
    .Setup(receiver => receiver.ReceiveMessageAsync(
        It.IsAny<TimeSpan>(),
        It.IsAny<CancellationToken>()))
    .ReturnsAsync(() =>
    {
        ServiceBusReceivedMessage m = messagesToReturn.ElementAtOrDefault(numCallsReceiveMessage);
        numCallsReceiveMessage++;
        return m;
    });

// This sets up the mock ServiceBusReceiver to keep track of the messages being deferred using each message's
// sequence number.

Dictionary<long, ServiceBusReceivedMessage> deferredMessages = new();

mockReceiver
    .Setup(receiver => receiver.DeferMessageAsync(
        It.IsAny<ServiceBusReceivedMessage>(),
        It.IsAny<Dictionary<string, object>>(),
        It.IsAny<CancellationToken>()))
    .Callback<ServiceBusReceivedMessage, IDictionary<string, object>, CancellationToken>((m, p, ct) =>
    {
        deferredMessages.Add(m.SequenceNumber, m);
    })
    .Returns(Task.CompletedTask);

// This sets up the ServiceBusReceiver mock to retrieve the ServiceBusReceivedMessage that has been deferred.
// If a message has not been deferred with the given sequence number, throw a ServiceBusException (as expected).

mockReceiver
    .Setup(receiver => receiver.ReceiveDeferredMessageAsync(
        It.IsAny<long>(),
        It.IsAny<CancellationToken>()))
    .ReturnsAsync((long s, CancellationToken ct) =>
    {
        if (deferredMessages.ContainsKey(s))
        {
            ServiceBusReceivedMessage message = deferredMessages[s];
            deferredMessages.Remove(s);
            return message;
        }
        else
        {
            throw new ServiceBusException();
        }
    });

// The rest of this snippet illustrates how to defer a service bus message using the mocked
// service bus client above, this would be where application methods deferrring a message would be
// called.

string mockQueueName = "MockQueueName";
ServiceBusReceiver receiver = client.CreateReceiver(mockQueueName);

client.CreateReceiver(mockQueueName);

List<long> deferredMessageSequenceNumbers = new();
for (int i = 0; i < numMessages; i++)
{
    ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(1), CancellationToken.None);
    deferredMessageSequenceNumbers.Add(message.SequenceNumber);
    await receiver.DeferMessageAsync(message);
}

for (int i = 0; i < numMessages; i++)
{
    ServiceBusReceivedMessage message = await receiver.ReceiveDeferredMessageAsync(i, CancellationToken.None);

    // Application message processing...
}

// For illustrative purposes, make sure all deferred messages were received.

Assert.IsEmpty(deferredMessages);
```

### Abandoning a message

This snippet demonstrates how to mock `AbandonMessageAsync` for the `ServiceBusReceiver`. This is done by creating a pre-defined set of messages to return from `ReceiveMessageAsync`. When `AbandonMessageAsync` is called on the message returned from `ReceiveMessageAsync`, the message is re-inserted into the list of messages, and will be received again if `ReceiveMessageAsync` is called again. 

```C# Snippet:ServiceBus_MockingAbandon
// This sets up the ServiceBusClient mock to return the ServiceBusReceiver mock.

Mock<ServiceBusClient> mockClient = new();
Mock<ServiceBusReceiver> mockReceiver = new();

mockClient
    .Setup(client => client.CreateReceiver(It.IsAny<string>()))
    .Returns(mockReceiver.Object);

ServiceBusClient client = mockClient.Object;

// This creates a list of messages to return from the ServiceBusReceiver mock. See the ServiceBusModelFactory
// for a complete set of properties that can be populated using the ServiceBusModelFactory.ServiceBusReceivedMessage method.

List<ServiceBusReceivedMessage> messagesToReturn = new();
int numMessages = 3;

for (int i = 0; i < numMessages; i++)
{
    string body = $"message-{i}";

    // This mocks a ServiceBusReceivedMessage instance using the model factory. Different arguments can mock different
    // potential outputs from the broker.

    ServiceBusReceivedMessage messageToReturn = ServiceBusModelFactory.ServiceBusReceivedMessage(
        body: new BinaryData(body),
        messageId: $"id-{i}",
        sequenceNumber: i,
        partitionKey: "illustrative-partitionKey",
        correlationId: "illustrative-correlationId",
        contentType: "illustrative-contentType",
        replyTo: "illustrative-replyTo"
        // ...
        );
    messagesToReturn.Add(messageToReturn);
}

// Set up receive to return the next message in the list of messages after each call.

mockReceiver
    .Setup(receiver => receiver.ReceiveMessageAsync(
        It.IsAny<TimeSpan>(),
        It.IsAny<CancellationToken>()))
    .ReturnsAsync(() =>
    {
        ServiceBusReceivedMessage m = messagesToReturn.FirstOrDefault();
        if (m!= null)
        {
            messagesToReturn.RemoveAt(0);
        }
        return m;
    });

// Set up abandon to put the received message back at the front of the list to be returned again.

mockReceiver
    .Setup(receiver => receiver.AbandonMessageAsync(
        It.IsAny<ServiceBusReceivedMessage>(),
        It.IsAny<Dictionary<string, object>>(),
        It.IsAny<CancellationToken>()))
    .Callback<ServiceBusReceivedMessage, IDictionary<string, object>, CancellationToken>((m, p, ct) => messagesToReturn.Insert(0, m))
    .Returns(Task.CompletedTask);

// The rest of this snippet illustrates how to abandon a service bus message using the mocked
// service bus receiver above, this would be where application methods peeking a message would be
// called.

string mockQueueName = "MockQueue";
ServiceBusReceiver receiver = client.CreateReceiver(mockQueueName);

List<ServiceBusReceivedMessage> receivedMessages = new();

// The following code receives the pre-defined set of ServiceBusReceivedMessage's and then abandons each of them. This would
// be where application code would receive and abandon messages.

for (int i = 0; i < numMessages; i++)
{
    ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(2), CancellationToken.None);

    receivedMessages.Add(message);
}

foreach (ServiceBusReceivedMessage message in receivedMessages)
{
    await receiver.AbandonMessageAsync(message);
}

// For illustrative purposes, verify that abandon was called on each message that was received.

foreach (ServiceBusReceivedMessage message in receivedMessages)
{
    mockReceiver.Verify(receiver => receiver.AbandonMessageAsync(
        It.Is<ServiceBusReceivedMessage>(m => m.Equals(message)),
        It.IsAny<Dictionary<string, object>>(),
        It.IsAny<CancellationToken>()), Times.Once);
}
```

### Dead lettering a message

This snippet demonstrates how to mock `DeadLetterMessageAsync` using a receiver, and then how to mock receiving from a dead letter queue receiver. In this example, a set of messages is defined in the test to return from `ReceiveMessageAsync` to provide a set of messages. In this snippet, when `DeadLetterMessageAsync` is called on any message, that message is held in a list of dead-lettered messages. These messages are then returned upon calls to `ReceiveMessageAsync` using the dead letter queue receiver.

```C# Snippet:ServiceBus_MockingDeadLetter
// This sets up the ServiceBusClient mock to return the ServiceBusReceiver mock.

Mock<ServiceBusClient> mockClient = new();
Mock<ServiceBusReceiver> mockReceiver = new();
Mock<ServiceBusReceiver> mockDlqReceiver = new();

mockClient
    .Setup(client => client.CreateReceiver(
        It.IsAny<string>()))
    .Returns(mockReceiver.Object);

// This sets up the ServiceBusClient mock to return the dead letter queue receiver if the options specify it.

mockClient
    .Setup(client => client.CreateReceiver(
        It.IsAny<string>(),
        It.Is<ServiceBusReceiverOptions>(opts => opts.SubQueue == SubQueue.DeadLetter)))
    .Returns(mockDlqReceiver.Object);

ServiceBusClient client = mockClient.Object;

// This creates a list of messages to return from the ServiceBusReceiver mock. See the ServiceBusModelFactory
// for a complete set of properties that can be populated using the ServiceBusModelFactory.ServiceBusReceivedMessage method.

List<ServiceBusReceivedMessage> messagesToReturn = new();
int numMessages = 3;

for (int i = 0; i < numMessages; i++)
{
    string body = $"message-{i}";

    // This mocks a ServiceBusReceivedMessage instance using the model factory. Different arguments can mock different
    // potential outputs from the broker.

    ServiceBusReceivedMessage messageToReturn = ServiceBusModelFactory.ServiceBusReceivedMessage(
        body: new BinaryData(body),
        messageId: $"id-{i}",
        sequenceNumber: i,
        partitionKey: "illustrative-partitionKey",
        correlationId: "illustrative-correlationId",
        contentType: "illustrative-contentType",
        replyTo: "illustrative-replyTo"
        // ...
        );
    messagesToReturn.Add(messageToReturn);
}

// Set up receive to return the next message in the list of messages after each call.

mockReceiver
    .Setup(receiver => receiver.ReceiveMessageAsync(
        It.IsAny<TimeSpan>(),
        It.IsAny<CancellationToken>()))
    .ReturnsAsync(() =>
    {
        ServiceBusReceivedMessage m = messagesToReturn.FirstOrDefault();
        if (m != null)
        {
            messagesToReturn.RemoveAt(0);
        }
        return m;
    });

// Set up dead letter to put the received message into the mock dead letter queue.

List<ServiceBusReceivedMessage> deadLetteredMessages = new();

mockReceiver
    .Setup(receiver => receiver.DeadLetterMessageAsync(
        It.IsAny<ServiceBusReceivedMessage>(),
        It.IsAny<string>(),
        It.IsAny<string>(),
        It.IsAny<CancellationToken>()))
    .Callback<ServiceBusReceivedMessage, string, string, CancellationToken>((m, r, d, ct) => deadLetteredMessages.Add(m))
    .Returns(Task.CompletedTask);

// When calling ReceiveMessageAsync on the dead letter queue receiver, pass one of the messages from the dead
// letter queue list or just return null, mirroring the behavior of a dead letter queue receiver.

mockDlqReceiver
    .Setup(receiver => receiver.ReceiveMessageAsync(
        It.IsAny<TimeSpan>(),
        It.IsAny<CancellationToken>()))
    .ReturnsAsync(() =>
    {
        ServiceBusReceivedMessage m = deadLetteredMessages.FirstOrDefault();
        if (m != null)
        {
            deadLetteredMessages.RemoveAt(0);
        }
        return m;
    });

// The rest of this snippet illustrates how to dead letter a service bus message using the mocked
// service bus receiver above, this would be where application methods dead lettering a message would be
// called.

string mockQueueName = "MockQueue";
ServiceBusReceiver receiver = client.CreateReceiver(mockQueueName);

List<ServiceBusReceivedMessage> receivedMessages = new();

for (int i = 0; i < numMessages; i++)
{
    ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(2), CancellationToken.None);
    receivedMessages.Add(message);

    await receiver.DeadLetterMessageAsync(message, "test reason", "test description", CancellationToken.None);
}

// Assert that the application method called Deadletter on the test message.

foreach (ServiceBusReceivedMessage message in receivedMessages)
{
    Assert.That(deadLetteredMessages.Contains(message));
}

mockReceiver
    .Verify(receiver => receiver.DeadLetterMessageAsync(
        It.IsAny<ServiceBusReceivedMessage>(),
        It.IsAny<string>(),
        It.IsAny<string>(),
        It.IsAny<CancellationToken>()), Times.Exactly(numMessages));

// For illustrative purposes, receive a dead-lettered message from the dead letter queue.

string deadLetterQueueName = "DeadLetterQueue";
ServiceBusReceiverOptions options = new()
{
    SubQueue = SubQueue.DeadLetter
};
ServiceBusReceiver deadLetterQueueReceiver = client.CreateReceiver(deadLetterQueueName, options);

for (int i = 0; i < numMessages; i++)
{
    ServiceBusReceivedMessage dlMessage = await deadLetterQueueReceiver.ReceiveMessageAsync(TimeSpan.FromSeconds(2), CancellationToken.None);

    // Application processing of dead lettered messages would be done here...
}

// Assert that ReceiveMessageAsync was called on the mock receiver.

mockDlqReceiver
    .Verify(receiver => receiver.ReceiveMessageAsync(
        It.IsAny<TimeSpan>(),
        It.IsAny<CancellationToken>()), Times.Exactly(numMessages));
```

## Testing processor message handlers

Interacting with a `ServiceBusProcessor` or `ServiceBusSessionProcessor` in an application is done through various handler methods. The Service Bus library guarantees that each of these handlers will be called at the appropriate times while the processor is running. Therefore, it is recommended that handlers be tested by calling them directly, rather than attempting to simulate having the processor invoke them.

The most common of these handlers are the process message and process error handlers. The necessary inputs to these handlers can be mocked either using the `ServiceBusModelFactory` or created directly and then passed into their respective handler definitions, this is demonstrated below.

### For the `ServiceBusProcessor`:

```C# Snippet:ServiceBus_TestProcessorHandlers
Mock<ServiceBusReceiver> mockReceiver = new();

mockReceiver
    .Setup(receiver => receiver.CompleteMessageAsync(
        It.IsAny<ServiceBusReceivedMessage>(),
        It.IsAny<CancellationToken>()))
    .Returns(Task.CompletedTask);

Task MessageHandler(ProcessMessageEventArgs args)
{
    // Sample illustrative processor handler

    // Application message processing code would be here...

    return Task.CompletedTask;
}

Task ErrorHandler(ProcessErrorEventArgs args)
{
    // Sample illustrative processor error handler

    // Application error processing code would be here...

    return Task.CompletedTask;
}

// Here we are mocking the ServiceBusReceivedMessage to process using the ServiceBusModelFactory.

ServiceBusReceivedMessage message = ServiceBusModelFactory.ServiceBusReceivedMessage(
        body: new BinaryData("message"),
        messageId: "messageId",
        partitionKey: "hellokey",
        correlationId: "correlationId",
        contentType: "contentType",
        replyTo: "replyTo"
        //...
        );

// Create a set of ProcessMessageEventArgs to use to test the handler.

ProcessMessageEventArgs processArgs = new(
    message: message,
    receiver: mockReceiver.Object,
    cancellationToken: CancellationToken.None);

// For illustrative purposes, simply test that the message handler does not throw any exceptions.

Assert.DoesNotThrowAsync(async () => await MessageHandler(processArgs));

string fullyQualifiedNamespace = "full-qualified-namespace";
string entityPath = "entity-path";
ServiceBusErrorSource errorSource = new();

// Create a set of ProcessErrorEventArgs to test the handler.

ProcessErrorEventArgs errorArgs = new(
    exception: new Exception("sample exception"),
    errorSource: errorSource,
    fullyQualifiedNamespace: fullyQualifiedNamespace,
    entityPath: entityPath,
    cancellationToken: CancellationToken.None);

// For illustrative purposes, simply test that the error handler does not throw any exceptions.

Assert.DoesNotThrowAsync(async () => await ErrorHandler(errorArgs));
```

### For the `ServiceBusSessionProcessor`:

```C# Snippet:ServiceBus_TestSessionProcessorHandlers
Mock<ServiceBusSessionReceiver> mockSessionReceiver = new();

mockSessionReceiver
    .Setup(receiver => receiver.CompleteMessageAsync(
        It.IsAny<ServiceBusReceivedMessage>(),
        It.IsAny<CancellationToken>()))
    .Returns(Task.CompletedTask);

// The following are sample illustrative message and error handlers. Additional application processing code
// would be defined inside of each.

async Task MessageHandler(ProcessSessionMessageEventArgs args)
{
    var body = args.Message.Body.ToString();

    // we can evaluate application logic and use that to determine how to settle the message.
    await args.CompleteMessageAsync(args.Message);

    // we can also set arbitrary session state using this receiver
    // the state is specific to the session, and not any particular message
    await args.SetSessionStateAsync(new BinaryData("some state"));
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

// Here we are mocking the ServiceBusReceivedMessage to process using the ServiceBusModelFactory.

ServiceBusReceivedMessage message = ServiceBusModelFactory.ServiceBusReceivedMessage(
        body: new BinaryData("message"),
        messageId: "messageId",
        partitionKey: "hellokey",
        correlationId: "correlationId",
        contentType: "contentType",
        replyTo: "replyTo"
        //...
        );

// Create a set of ProcessMessageEventArgs to use to test the handler.

ProcessSessionMessageEventArgs processArgs = new(
    message: message,
    receiver: mockSessionReceiver.Object,
    cancellationToken: CancellationToken.None);

// For illustrative purposes, simply test that the message handler does not throw any exceptions.

Assert.DoesNotThrowAsync(async () => await MessageHandler(processArgs));

string fullyQualifiedNamespace = "full-qualified-namespace";
string entityPath = "entity-path";
ServiceBusErrorSource errorSource = new();

// Create a set of ProcessErrorEventArgs to test the handler.

ProcessErrorEventArgs errorArgs = new(
    exception: new Exception("sample exception"),
    errorSource: errorSource,
    fullyQualifiedNamespace: fullyQualifiedNamespace,
    entityPath: entityPath,
    cancellationToken: CancellationToken.None);

// For illustrative purposes, simply test that the error handler does not throw any exceptions.

Assert.DoesNotThrowAsync(async () => await ErrorHandler(errorArgs));
```

## Simulating the processor running

While calling the handler methods directly is recommended for testing their logic, there may be times where it is desirable to test how an application interacts with the `ServiceBusProcessor` or `ServiceBusSessionProcessor` more generally, such as to start and stop processing. For these scenarios, it may be helpful to mock the `StartProcessingAsync` and `StopProcessingAsync` methods and simulate dispatching messages or exceptions. This allows for testing application logic while simulating normal behavior of the processor.

This can be accomplished by using a timer to call handler methods when the `ServiceBusProcessor` or `ServiceBusSessionProcessor` is started and to cease doing so when the processor is stopped. The necessary inputs to these handlers can be mocked using the `ServiceBusModelFactory`. The example below demonstrates a timer dispatching messages to the handler for processing while the processor is "running".

### For the `ServiceBusProcessor`

```C# Snippet:ServiceBus_SimulateRunningTheProcessor
Mock<ServiceBusClient> mockClient = new();
Mock<ServiceBusReceiver> mockReceiver = new();

// This handler is for illustrative purposes only.

async Task MessageHandler(ProcessMessageEventArgs args)
{
    string body = args.Message.Body.ToString();
    Console.WriteLine(body);

    // we can evaluate application logic and use that to determine how to settle the message.
    await args.CompleteMessageAsync(args.Message);
}

// This function simulates a random message being emitted for processing.

Random rng = new();

TimerCallback dispatchMessage = async _ =>
{
    ServiceBusReceivedMessage message = ServiceBusModelFactory.ServiceBusReceivedMessage(
        body: new BinaryData("message"),
        messageId: "messageId",
        partitionKey: "hellokey",
        correlationId: "correlationId",
        contentType: "contentType",
        replyTo: "replyTo"
        //...
        );

    ProcessMessageEventArgs processArgs = new(
        message: message,
        receiver: mockReceiver.Object,
        cancellationToken: CancellationToken.None);

    await MessageHandler(processArgs);
};

// Create a timer that runs once-a-second when started and, otherwise, sits idle.

Timer messageDispatchTimer = new(
    dispatchMessage,
    null,
    Timeout.Infinite,
    Timeout.Infinite);

void startTimer() =>
    messageDispatchTimer.Change(0, (int)TimeSpan.FromSeconds(1).TotalMilliseconds);

void stopTimer() =>
    messageDispatchTimer.Change(Timeout.Infinite, Timeout.Infinite);

// Create a mock of the processor that dispatches messages when StartProcessingAsync
// is called and does so until StopProcessingAsync is called.

Mock<ServiceBusProcessor> mockProcessor = new();

mockProcessor
    .Setup(processor => processor.StartProcessingAsync(It.IsAny<CancellationToken>()))
    .Returns(Task.CompletedTask)
    .Callback(startTimer);

mockProcessor
    .Setup(processor => processor.StopProcessingAsync(It.IsAny<CancellationToken>()))
    .Returns(Task.CompletedTask)
    .Callback(stopTimer);

mockClient
    .Setup(client => client.CreateProcessor(It.IsAny<string>()))
    .Returns(mockProcessor.Object);

// Start the processor.

await mockProcessor.Object.StartProcessingAsync();

// This is where application code would be called and tested.

// Stop the processor.

await mockProcessor.Object.StopProcessingAsync();
```

### For the `ServiceBusSessionProcessor`

```C# Snippet:ServiceBus_SimulateRunningTheSessionProcessor
Mock<ServiceBusClient> mockClient = new();
Mock<ServiceBusSessionReceiver> mockSessionReceiver = new();

// This handler is for illustrative purposes only.

async Task MessageHandler(ProcessSessionMessageEventArgs args)
{
    string body = args.Message.Body.ToString();
    Console.WriteLine(body);

    // we can evaluate application logic and use that to determine how to settle the message.
    await args.CompleteMessageAsync(args.Message);
}

// This function simulates a random message being emitted for processing.

Random rng = new();

TimerCallback dispatchMessage = async _ =>
{
    ServiceBusReceivedMessage message = ServiceBusModelFactory.ServiceBusReceivedMessage(
        body: new BinaryData("message"),
        messageId: "messageId",
        sessionId: "session",
        partitionKey: "hellokey",
        correlationId: "correlationId",
        contentType: "contentType",
        replyTo: "replyTo"
        //...
        );

    ProcessSessionMessageEventArgs processArgs = new(
        message: message,
        receiver: mockSessionReceiver.Object,
        cancellationToken: CancellationToken.None);

    await MessageHandler(processArgs);
};

// Create a timer that runs once-a-second when started and, otherwise, sits idle.

Timer messageDispatchTimer = new(
    dispatchMessage,
    null,
    Timeout.Infinite,
    Timeout.Infinite);

void startTimer() =>
    messageDispatchTimer.Change(0, (int)TimeSpan.FromSeconds(1).TotalMilliseconds);

void stopTimer() =>
    messageDispatchTimer.Change(Timeout.Infinite, Timeout.Infinite);

// Create a mock of the session processor that dispatches messages when StartProcessingAsync
// is called and does so until StopProcessingAsync is called.

Mock<ServiceBusSessionProcessor> mockProcessor = new();

mockProcessor
    .Setup(processor => processor.StartProcessingAsync(It.IsAny<CancellationToken>()))
    .Returns(Task.CompletedTask)
    .Callback(startTimer);

mockProcessor
    .Setup(processor => processor.StopProcessingAsync(It.IsAny<CancellationToken>()))
    .Returns(Task.CompletedTask)
    .Callback(stopTimer);

mockClient
    .Setup(client => client.CreateSessionProcessor(It.IsAny<string>(), It.IsAny<ServiceBusSessionProcessorOptions>()))
    .Returns(mockProcessor.Object);

// Start the processor.

await mockProcessor.Object.StartProcessingAsync();

// This is where application code would be called and tested.

// Stop the processor.

await mockProcessor.Object.StopProcessingAsync();
```

## Get namespace properties using the `ServiceBusAdministrationClient`
The following snippet demonstrates how to mock `ServiceBusAdministrationClient.GetNamespaceProperties()` using the `ServiceBusModelFactory` to create `NamespaceProperties`.

```C# Snippet:ServiceBus_MockingNamespaceProperties
Mock<Response<NamespaceProperties>> mockResponse = new Mock<Response<NamespaceProperties>>();
Mock<ServiceBusAdministrationClient> mockAdministrationClient = new Mock<ServiceBusAdministrationClient>();

NamespaceProperties mockNamespaceProperties = ServiceBusModelFactory.NamespaceProperties("name", DateTimeOffset.UtcNow, DateTime.UtcNow, MessagingSku.Basic, 100, "alias");

mockResponse
    .SetupGet(response => response.Value)
    .Returns(mockNamespaceProperties);

mockAdministrationClient
    .Setup(client => client.GetNamespacePropertiesAsync(It.IsAny<CancellationToken>()))
    .ReturnsAsync(mockResponse.Object);

ServiceBusAdministrationClient administrationClient = mockAdministrationClient.Object;

// The rest of this snippet illustrates how to access the namespace properties using the mocked service bus
// administration client above, this would be where application methods calling GetNamespaceProperties() would be called.

Response<NamespaceProperties> namespacePropertiesResponse = await administrationClient.GetNamespacePropertiesAsync(CancellationToken.None);
NamespaceProperties namespaceProperties = namespacePropertiesResponse.Value;
```


## Creating topics and subscriptions using the `ServiceBusAdministrationClient`

The following snippet demonstrates how to mock the `ServiceBusAdministrationClient` and `ServiceBusClient` to send messages using topics and subscriptions.

The key interactions with the `ServiceBusAdministrationClient` when using topics and subscriptions are `CreateTopicAsync` and the `CreateSubscriptionAsync`. The outputs from these methods can be mocked using the `ServiceBusModelFactory`.

The key interactions with the `ServiceBusClient` when using topics and subscriptions are `SendMessageAsync` and `ReceiveMessageAsync`. These methods are mocked using very similar methods as the snippets above, where messages are being sent to a Service Bus queue instead.

```C# Snippet:ServiceBus_MockingTopicSubscriptionCrud
Mock<ServiceBusAdministrationClient> mockAdministrationClient = new();
Mock<Response<TopicProperties>> mockTopicResponse = new();
Mock<Response<SubscriptionProperties>> mockSubscriptionResponse= new();

// This sets up the mock administration client to return a mocked topic properties using the
// service bus model factory. It populates each of the arguments using the CreateTopicOptions instance
// passed into the method.

mockAdministrationClient
    .Setup(client => client.CreateTopicAsync(
        It.IsAny<CreateTopicOptions>(),
        It.IsAny<CancellationToken>()))
    .Callback<CreateTopicOptions, CancellationToken>((opts, ct) =>
    {
        TopicProperties mockTopicProperties = ServiceBusModelFactory.TopicProperties(
            name: opts.Name,
            maxSizeInMegabytes: opts.MaxSizeInMegabytes,
            requiresDuplicateDetection: opts.RequiresDuplicateDetection,
            defaultMessageTimeToLive: opts.DefaultMessageTimeToLive,
            autoDeleteOnIdle: opts.AutoDeleteOnIdle,
            duplicateDetectionHistoryTimeWindow: opts.DuplicateDetectionHistoryTimeWindow,
            enableBatchedOperations: opts.EnableBatchedOperations,
            status: opts.Status,
            enablePartitioning: opts.EnablePartitioning,
            maxMessageSizeInKilobytes: opts.MaxMessageSizeInKilobytes.GetValueOrDefault());

        mockTopicResponse.Setup(r => r.Value).Returns(mockTopicProperties);
    })
    .ReturnsAsync(mockTopicResponse.Object);

// This sets up the mock administration client to return a mocked subscription properties using the
// service bus model factory. It populates each of the arguments using the CreateSubscriptionOptions instance
// passed into the method.

mockAdministrationClient
    .Setup(client => client.CreateSubscriptionAsync(
        It.IsAny<CreateSubscriptionOptions>(),
        It.IsAny<CancellationToken>()))
    .Callback<CreateSubscriptionOptions, CancellationToken>((opts, ct) =>
    {
        SubscriptionProperties mockSubscriptionProperties = ServiceBusModelFactory.SubscriptionProperties(
            topicName: opts.TopicName,
            subscriptionName: opts.SubscriptionName,
            lockDuration: opts.LockDuration,
            requiresSession: opts.RequiresSession,
            defaultMessageTimeToLive: opts.DefaultMessageTimeToLive,
            autoDeleteOnIdle: opts.AutoDeleteOnIdle,
            deadLetteringOnMessageExpiration: opts.DeadLetteringOnMessageExpiration,
            maxDeliveryCount: opts.MaxDeliveryCount,
            enableBatchedOperations: opts.EnableBatchedOperations,
            status: opts.Status, forwardTo: opts.ForwardTo,
            forwardDeadLetteredMessagesTo: opts.ForwardDeadLetteredMessagesTo,
            userMetadata: opts.UserMetadata);

        mockSubscriptionResponse.Setup(r => r.Value).Returns(mockSubscriptionProperties);
    })
    .ReturnsAsync(mockSubscriptionResponse.Object);

ServiceBusAdministrationClient adminClient = mockAdministrationClient.Object;

// The rest of this snippet illustrates create topics and subscriptions using the mocked administration client,
// this would be where application methods creating topics and subscriptions would be called.

// Illustrating creating a topic.

string topicName = "topic";

CreateTopicOptions topicOptions = new(topicName);
topicOptions.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
    "allClaims",
    new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen }));

TopicProperties createdTopic = await adminClient.CreateTopicAsync(topicOptions);

// Illustrating creating a subscription.

string subscriptionName = "subscription";
var subscriptionOptions = new CreateSubscriptionOptions(topicName, subscriptionName)
{
    UserMetadata= "some metadata"
};
SubscriptionProperties createdSubscription = await adminClient.CreateSubscriptionAsync(subscriptionOptions);
```

## Creating a queue using the `ServiceBusAdministrationClient`

The following snippet demonstrates how to mock the `ServiceBusAdministrationClient` to create a Service Bus queue. The key interaction in this scenario is mocking `CreateQueueAsync`. The output from this method can be mocked using the `ServiceBusModelFactory`.

```C# Snippet:ServiceBus_MockingQueueCreation
Mock<ServiceBusAdministrationClient> mockAdministrationClient = new();
Mock<Response<QueueProperties>> mockQueueResponse = new();

// This sets up the mock administration client to return a mocked queue properties using the
// service bus model factory. It populates each of the arguments using the CreateQueueOptions instance
// passed into the method.

mockAdministrationClient
    .Setup(client => client.CreateQueueAsync(
        It.IsAny<CreateQueueOptions>(),
        It.IsAny<CancellationToken>()))
    .Callback<CreateQueueOptions, CancellationToken>((opts, ct) =>
    {
        QueueProperties mockQueueProperties = ServiceBusModelFactory.QueueProperties(
            name: opts.Name,
            lockDuration: opts.LockDuration,
            maxSizeInMegabytes: opts.MaxSizeInMegabytes,
            requiresDuplicateDetection: opts.RequiresDuplicateDetection,
            requiresSession: opts.RequiresSession,
            defaultMessageTimeToLive: opts.DefaultMessageTimeToLive,
            autoDeleteOnIdle: opts.AutoDeleteOnIdle,
            deadLetteringOnMessageExpiration: opts.DeadLetteringOnMessageExpiration,
            duplicateDetectionHistoryTimeWindow: opts.DuplicateDetectionHistoryTimeWindow,
            maxDeliveryCount: opts.MaxDeliveryCount,
            enableBatchedOperations: opts.EnableBatchedOperations,
            status: opts.Status, forwardTo: opts.ForwardTo,
            forwardDeadLetteredMessagesTo: opts.ForwardDeadLetteredMessagesTo,
            userMetadata: opts.UserMetadata,
            enablePartitioning: opts.EnablePartitioning);

        mockQueueResponse.Setup(r => r.Value).Returns(mockQueueProperties);
    })
    .ReturnsAsync(mockQueueResponse.Object);

ServiceBusAdministrationClient administrationClient = mockAdministrationClient.Object;

// The rest of this snippet illustrates how to create a queue using the mocked service bus
// administration client above, this would be where application methods creating a queue would be
// called.

string queueName = "queue";
CreateQueueOptions options = new(queueName)
{
    UserMetadata = "some metadata"
};

options.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
    "allClaims",
    new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen }));

QueueProperties createQueue = await administrationClient.CreateQueueAsync(options);
```

## Creating a rule using the `ServiceBusAdministrationClient`

The following snippet demonstrates how to mock the `ServiceBusAdministrationClient` to create a rule. The key interaction in this scenario is mocking `CreateRuleAsync`. The output from this method can be mocked using the `ServiceBusModelFactory`.

```C# Snippet:ServiceBus_MockingRules
Mock<ServiceBusAdministrationClient> mockAdministrationClient = new();
Mock<Response<RuleProperties>> mockRuleResponse = new();

// This sets up the mock administration client to return a mocked rule properties using the
// service bus model factory. It populates each of the arguments using the CreateRuleOptions instance
// passed into the method.

mockAdministrationClient
    .Setup(client => client.CreateRuleAsync(
        It.IsAny<string>(),
        It.IsAny<string>(),
        It.IsAny<CreateRuleOptions>(),
        It.IsAny<CancellationToken>()))
    .Callback<string, string, CreateRuleOptions, CancellationToken>((topic, sub, opts, ct) =>
    {
        RuleProperties mockRuleProperties = ServiceBusModelFactory.RuleProperties(
            name: opts.Name,
            filter: opts.Filter,
            action: opts.Action);

        mockRuleResponse.Setup(r => r.Value).Returns(mockRuleProperties);
    })
    .ReturnsAsync(mockRuleResponse.Object);

ServiceBusAdministrationClient administrationClient = mockAdministrationClient.Object;

// The rest of this snippet illustrates how to create a rule using the mocked service bus
// administration client above, this would be where application methods creating a rule would be
// called.

string ruleName = "rule";
CreateRuleOptions options = new(ruleName)
{
    Filter = new CorrelationRuleFilter { Subject = "subject" }
};

string topic = "topic";
string subscription = "subscription";
RuleProperties createRule = await administrationClient.CreateRuleAsync(topic, subscription, options);
```

## Creating and deleting rules using the `ServiceBusRuleManager`

The following snippet demonstrates how to mock the `ServiceBusRuleManager` to create and delete rules. The key interactions in this scenario are mocking `CreateRuleAsync` and `DeleteRuleAsync`.

```C# Snippet:ServiceBus_MockingRuleManager
Mock<ServiceBusClient> mockClient = new();
Mock<ServiceBusRuleManager> mockRuleManager = new();

// The following calls set up the Rule Manager to simply return Task.CompletedTask
// for each of the RuleManager methods being tested.

mockRuleManager
    .Setup(rm => rm.DeleteRuleAsync(
        It.IsAny<string>(),
        It.IsAny<CancellationToken>()))
    .Returns(Task.CompletedTask);

mockRuleManager
    .Setup(rm => rm.CreateRuleAsync(
        It.IsAny<string>(),
        It.IsAny<RuleFilter>(),
        It.IsAny<CancellationToken>()))
    .Returns(Task.CompletedTask);

mockClient
    .Setup(client => client.CreateRuleManager(
        It.IsAny<string>(),
        It.IsAny<string>()))
    .Returns(mockRuleManager.Object);

ServiceBusClient client = mockClient.Object;

// The rest of this snippet illustrates how to create and use a rule manager using the mocked service
// bus client above, this would be where application methods using a rule manager would be called.

string topic = "topic";
string subscription = "subscription";

ServiceBusRuleManager ruleManager = client.CreateRuleManager(topic, subscription);

await ruleManager.DeleteRuleAsync(RuleProperties.DefaultRuleName);
await ruleManager.CreateRuleAsync("filter", new CorrelationRuleFilter { Subject = "subject" });
```
