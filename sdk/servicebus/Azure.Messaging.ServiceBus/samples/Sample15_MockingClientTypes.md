
# Mocking Client Types

Service Bus is built to support unit testing with mocks, as described in the [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking). This is an important feature of the library that allows developers to write tests that are completely focused on their own application logic, though they depend on Service Bus types.

The following examples focus on scenarios likely to occur in applications, and demonstrate how to mock the Service Bus types typically used in each scenario. The code snippets utilize the mock object framework, Moq, in order to provide practical examples. However, many mocking frameworks exist and can be used with the same approach in mind.

## Table of contents

TODO

## Sending messages to a queue

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

for (int i=0; i<numMessagesToReturn; i++)
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
    // application control
}

// This is where applications can verify that the ServiceBusReceivedMessages output by the ServiceBusReceiver were
// handled as expected.
```


## Sending a batch of messages

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

Assert.IsFalse(batch.TryAddMessage(new ServiceBusMessage("Too Many Events.")));

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

```C# Snippet:ServiceBus_MockingSessionReceiver
Mock<ServiceBusClient> mockClient = new();
Mock<ServiceBusSender> mockSender = new();
Mock<ServiceBusSessionReceiver> mockSessionReceiver = new();

mockClient
    .Setup(client => client.CreateSender(It.IsAny<string>()))
    .Returns(mockSender.Object);

mockClient
    .Setup(client => client.AcceptNextSessionAsync(
        It.IsAny<string>(),
        It.IsAny<ServiceBusSessionReceiverOptions>(),
        It.IsAny<CancellationToken>()))
    .ReturnsAsync(mockSessionReceiver.Object);

mockSender
    .Setup(sender => sender.SendMessageAsync(
        It.IsAny<ServiceBusMessage>(),
        It.IsAny<CancellationToken>()))
    .Returns(Task.CompletedTask);

ServiceBusClient client = mockClient.Object;

List<ServiceBusMessage> testSessionMessages = new();
Queue<ServiceBusReceivedMessage> messagesToReturn = new();

var mockSessionId = "mySession";
var numMessagesInSession = 5;

for (var i=0; i<numMessagesInSession; i++)
{
    var messageBody = $"message{i}";
    var messageId = $"messageId{i}";
    ServiceBusMessage sentMessage = new(messageBody)
    {
        SessionId = mockSessionId,
        MessageId = messageId
    };
    testSessionMessages.Add(sentMessage);

    ServiceBusReceivedMessage messageToReceive = ServiceBusModelFactory.ServiceBusReceivedMessage(
        body: new BinaryData(messageBody),
        messageId: "messageId2",
        sessionId: mockSessionId
        //...
        );
    messagesToReturn.Enqueue(messageToReceive);
}

mockSessionReceiver
    .Setup(receiver => receiver.ReceiveMessageAsync(
        It.IsAny<TimeSpan>(),
        It.IsAny<CancellationToken>()))
    .ReturnsAsync(messagesToReturn.Dequeue());

BinaryData mockSessionState = new("notSet");

mockSessionReceiver
    .Setup(receiver => receiver.SetSessionStateAsync(
        It.IsAny<BinaryData>(),
        It.IsAny<CancellationToken>()))
    .Callback<BinaryData, CancellationToken>((st, ct) => mockSessionState = st)
    .Returns(Task.CompletedTask);

mockSessionReceiver
    .Setup(receiver => receiver.GetSessionStateAsync(
        It.IsAny<CancellationToken>()))
    .ReturnsAsync(() => mockSessionState);

// The rest of this snippet illustrates how to send and receive session messages using the mocked
// service bus client above, this would be where application methods using sessions would be
// called.

var mockQueueName = "MockQueueName";
ServiceBusSender sender = client.CreateSender(mockQueueName);

foreach (ServiceBusMessage message in testSessionMessages)
{
    await sender.SendMessageAsync(message);
}

TimeSpan maxWait = TimeSpan.FromSeconds(30);

ServiceBusSessionReceiver sessionReceiver = await client.AcceptNextSessionAsync(mockQueueName, new ServiceBusSessionReceiverOptions(), CancellationToken.None);

ServiceBusReceivedMessage receivedMessage = await sessionReceiver.ReceiveMessageAsync(maxWait, CancellationToken.None);

BinaryData setState = new("MockState");
await sessionReceiver.SetSessionStateAsync(setState, CancellationToken.None);
BinaryData state = await sessionReceiver.GetSessionStateAsync(CancellationToken.None);

Assert.AreEqual(setState, state);
```

## Message Settlement

```C# Snippet:ServiceBus_MockingComplete
// The first section sets up a mock ServiceBusSender. See the Mocking send to queue TODO sample above
// for a more detailed explanation.

Mock<ServiceBusClient> mockClient = new();
Mock<ServiceBusSender> mockSender = new();

mockClient
    .Setup(client => client.CreateSender(It.IsAny<string>()))
    .Returns(mockSender.Object);

mockSender
    .Setup(sender => sender.SendMessageAsync(
        It.IsAny<ServiceBusMessage>(),
        It.IsAny<CancellationToken>()))
    .Returns(Task.CompletedTask);

ServiceBusClient client = mockClient.Object;

Mock<ServiceBusReceiver> mockReceiver = new();

mockClient
    .Setup(client => client.CreateReceiver(It.IsAny<string>()))
    .Returns(mockReceiver.Object);

// This creates two lists, a list of messages to send and a list of messages to return from the ServiceBusReceiver mock.
// See the ServiceBusModelFactory for a complete set of properties that can be populated using the
// ServiceBusModelFactory.ServiceBusReceivedMessage method.

List<ServiceBusMessage> messagesToSend = new();
List<ServiceBusReceivedMessage> messagesToReturn = new();
int numMessagesToSend = 3;

for (int i = 0; i < numMessagesToSend; i++)
{
    string body = $"message-{i}";

    ServiceBusMessage messageToSend = new(body);
    messagesToSend.Add(messageToSend);

    // This mocks a ServiceBusReceivedMessage instance using the model factory. Different arguments can mock different
    // potential outputs from the broker.

    ServiceBusReceivedMessage messageToReturn = ServiceBusModelFactory.ServiceBusReceivedMessage(
        body: new BinaryData(body),
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

// The rest of this snippet illustrates how to send a service bus message using the mocked
// service bus client above, this would be where application methods sending a message would be
// called.

string mockQueueName = "MockQueueName";
ServiceBusSender sender = client.CreateSender(mockQueueName);
ServiceBusReceiver receiver = client.CreateReceiver(mockQueueName);

foreach (ServiceBusMessage message in messagesToSend)
{
    await sender.SendMessageAsync(message);
}

// ReceiveMessageAsync can be called multiple times.

ServiceBusReceivedMessage receivedMessage1 = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(1), CancellationToken.None);
await receiver.CompleteMessageAsync(receivedMessage1);

ServiceBusReceivedMessage receivedMessage2 = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(1), CancellationToken.None);
await receiver.CompleteMessageAsync(receivedMessage2);

// For illustrative purposes, verify that the number of times a message was received is the same number of times
// a message was completed.

mockReceiver
    .Verify(receiver => receiver.CompleteMessageAsync(
        It.IsAny<ServiceBusReceivedMessage>(),
        It.IsAny<CancellationToken>()),
        Times.Exactly(numCallsReceiveMessage));
```

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
// sequence number. It creates a new ServiceBusReceivedMessage using the model factory in order to update
// application properties.

Dictionary<long, ServiceBusReceivedMessage> deferredMessages = new();

mockReceiver
    .Setup(receiver => receiver.DeferMessageAsync(
        It.IsAny<ServiceBusReceivedMessage>(),
        It.IsAny<Dictionary<string, object>>(),
        It.IsAny<CancellationToken>()))
    .Callback<ServiceBusReceivedMessage, IDictionary<string, object>, CancellationToken>((m, p, ct) =>
    {
        ServiceBusReceivedMessage updatedMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(
            body: m.Body,
            messageId: m.MessageId,
            properties: p,
            sequenceNumber: m.SequenceNumber);
        deferredMessages.Add(m.SequenceNumber, updatedMessage);
    })
    .Returns(Task.CompletedTask);

// This sets up the ServiceBusReceiver mock to retrieve the ServiceBusReceivedMessage that has been deferred.
// If a message has been deferred with the given sequence number, throw a ServiceBusException (as expected).

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

ServiceBusReceivedMessage peekedMessage = await receiver.PeekMessageAsync(0, CancellationToken.None);

mockReceiver
    .Verify(receiver => receiver.PeekMessageAsync(
        It.IsAny<long>(),
        It.IsAny<CancellationToken>()), Times.Once());
```

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

ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync();
await receiver.AbandonMessageAsync(message);
```

## Testing message handlers

For the `ServiceBusProcessor`:

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
    return Task.CompletedTask;
}

Task ErrorHandler(ProcessErrorEventArgs args)
{
    // Sample illustrative processor error handler
    return Task.CompletedTask;
}

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

Assert.DoesNotThrowAsync(async () => await MessageHandler(processArgs));

string fullyQualifiedNamespace = "full-qualified-namespace";
string entityPath = "entity-path";
ServiceBusErrorSource errorSource = new();

ProcessErrorEventArgs errorArgs = new(
    exception: new Exception("sample exception"),
    errorSource: errorSource,
    fullyQualifiedNamespace: fullyQualifiedNamespace,
    entityPath: entityPath,
    cancellationToken: CancellationToken.None);

Assert.DoesNotThrowAsync(async () => await ErrorHandler(errorArgs));
```

For the `ServiceBusSessionProcessor`:

```C# Snippet:ServiceBus_TestSessionProcessorHandlers
Mock<ServiceBusSessionReceiver> mockSessionReceiver = new();

mockSessionReceiver
    .Setup(receiver => receiver.CompleteMessageAsync(
        It.IsAny<ServiceBusReceivedMessage>(),
        It.IsAny<CancellationToken>()))
    .Returns(Task.CompletedTask);

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

ServiceBusReceivedMessage message = ServiceBusModelFactory.ServiceBusReceivedMessage(
        body: new BinaryData("message"),
        messageId: "messageId",
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

Assert.DoesNotThrowAsync(async () => await MessageHandler(processArgs));

string fullyQualifiedNamespace = "full-qualified-namespace";
string entityPath = "entity-path";
ServiceBusErrorSource errorSource = new();

ProcessErrorEventArgs errorArgs = new(
    exception: new Exception("sample exception"),
    errorSource: errorSource,
    fullyQualifiedNamespace: fullyQualifiedNamespace,
    entityPath: entityPath,
    cancellationToken: CancellationToken.None);

Assert.DoesNotThrowAsync(async () => await ErrorHandler(errorArgs));
```

## Simulating the processor running

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

Timer eventDispatchTimer = new(
    dispatchMessage,
    null,
    Timeout.Infinite,
    Timeout.Infinite);

void startTimer() =>
    eventDispatchTimer.Change(0, (int)TimeSpan.FromSeconds(1).TotalMilliseconds);

void stopTimer() =>
    eventDispatchTimer.Change(Timeout.Infinite, Timeout.Infinite);

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

Timer eventDispatchTimer = new(
    dispatchMessage,
    null,
    Timeout.Infinite,
    Timeout.Infinite);

void startTimer() =>
    eventDispatchTimer.Change(0, (int)TimeSpan.FromSeconds(1).TotalMilliseconds);

void stopTimer() =>
    eventDispatchTimer.Change(Timeout.Infinite, Timeout.Infinite);

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


## Sending and Receiving messages using topics and subscriptions

```C# Snippet:ServiceBus_MockingTopicSubscriptionSend
Mock<ServiceBusAdministrationClient> mockAdministrationClient = new();
Mock<Response<TopicProperties>> mockTopicResponse = new();
Mock<Response<SubscriptionProperties>> mockSuscriptionResponse = new();

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

        mockSuscriptionResponse.Setup(r => r.Value).Returns(mockSubscriptionProperties);
    })
    .ReturnsAsync(mockSuscriptionResponse.Object);

var adminClient = mockAdministrationClient.Object;

Mock<ServiceBusClient> mockServiceBusClient = new();
Mock<ServiceBusSender> mockSender = new();
Mock<ServiceBusReceiver> mockReceiver = new();

mockServiceBusClient
    .Setup(client => client.CreateSender(It.IsAny<string>()))
    .Returns(mockSender.Object);

mockSender
    .Setup(sender => sender.SendMessageAsync(
        It.IsAny<ServiceBusMessage>(),
        It.IsAny<CancellationToken>()))
    .Returns(Task.CompletedTask);

mockServiceBusClient
    .Setup(client => client.CreateReceiver(
        It.IsAny<string>(),
        It.IsAny<string>()))
    .Returns(mockReceiver.Object);

async IAsyncEnumerable<ServiceBusReceivedMessage> mockReturn()
{
    ServiceBusReceivedMessage message = ServiceBusModelFactory.ServiceBusReceivedMessage(
        body: new BinaryData("message1"),
        messageId: "messageId1",
        partitionKey: "hellokey",
        correlationId: "correlationId",
        contentType: "contentType",
        replyTo: "replyTo"
        // see the Service Bus Model Factory for more options ...
        );

    // IAsyncEnumerable types can only be returned by async functions, use this no-op await statement to
    // force the method to be async.

    await Task.Yield();

    // yield allows more than one message to be returned, only one is being returned here for brevity

    yield return message;
}

mockReceiver
    .Setup(receiver => receiver.ReceiveMessagesAsync(
        It.IsAny<CancellationToken>()))
    .Returns(mockReturn);

var serviceBusClient = mockServiceBusClient.Object;

// The rest of this snippet illustrates how to send and receive messages using the mocked
// topic and subscription methods above, this would be where application methods sending and
// receiving to topics and subscriptions would be called.

string topicName = "topic";
var topicOptions = new CreateTopicOptions(topicName);
topicOptions.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
    "allClaims",
    new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen }));
TopicProperties createdTopic = await adminClient.CreateTopicAsync(topicOptions);

string subscriptionName = "subscription";
var subscriptionOptions = new CreateSubscriptionOptions(topicName, subscriptionName)
{
    UserMetadata= "some metadata"
};
SubscriptionProperties createdSubscription = await adminClient.CreateSubscriptionAsync(subscriptionOptions);

ServiceBusSender sender = serviceBusClient.CreateSender(topicName);

await sender.SendMessageAsync(new ServiceBusMessage("body"));

ServiceBusReceiver receiver = serviceBusClient.CreateReceiver(topicName, subscriptionName);

ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
```

## Queue Creation Mocking

```C# Snippet:ServiceBus_MockingQueueCreation
Mock<ServiceBusAdministrationClient> mockAdministrationClient = new();
Mock<Response<QueueProperties>> mockQueueResponse = new();

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

## Rule Creation Mocking

```C# Snippet:ServiceBus_MockingRules
Mock<ServiceBusAdministrationClient> mockAdministrationClient = new();
Mock<Response<RuleProperties>> mockRuleResponse = new();

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

## Rule Manager Mocking

```C# Snippet:ServiceBus_MockingRuleManager
Mock<ServiceBusClient> mockClient = new();
Mock<ServiceBusRuleManager> mockRuleManager = new();

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