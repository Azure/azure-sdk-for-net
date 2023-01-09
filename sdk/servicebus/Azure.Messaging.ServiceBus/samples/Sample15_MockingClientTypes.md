
# Mocking Client Types

Service Bus is built to support unit testing with mocks, as described in the [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking). This is an important feature of the library that allows developers to write tests that are completely focused on their own application logic, though they depend on Service Bus types.

The following examples focus on scenarios likely to occur in applications, and demonstrate how to mock the Service Bus types typically used in each scenario. The code snippets utilize the mock object framework, Moq, in order to provide practical examples. However, many mocking frameworks exist and can be used with the same approach in mind.

## Table of contents

TODO

## Sending messages to a queue

```C# Snippet:ServiceBus_MockingSendToQueue
Mock<ServiceBusClient> mockClient = new();
Mock<ServiceBusSender> mockSender = new();

mockClient
    .Setup(client =>client.CreateSender(It.IsAny<string>()))
    .Returns(mockSender.Object);

mockSender
    .Setup(sender => sender.SendMessageAsync(
        It.IsAny<ServiceBusMessage>(),
        It.IsAny<CancellationToken>()))
    .Returns(Task.CompletedTask);

ServiceBusClient client = mockClient.Object;

// The rest of this snippet illustrates how to send a service bus message using the mocked
// service bus client above, this would be where application methods sending a message would be
// called.

var mockQueueName = "MockQueueName";
ServiceBusSender sender = client.CreateSender(mockQueueName);
ServiceBusMessage message = new ServiceBusMessage("Hello world!");

await sender.SendMessageAsync(message);
```
## Receiving messages from a queue

```C# Snippet:ServiceBus_MockingReceiveFromQueue
Mock<ServiceBusClient> mockClient = new();
Mock<ServiceBusReceiver> mockReceiver = new();

mockClient
    .Setup(client => client.CreateReceiver(
        It.IsAny<string>()))
    .Returns(mockReceiver.Object);

async IAsyncEnumerable<ServiceBusReceivedMessage> mockReturn()
{
    ServiceBusReceivedMessage message1 = ServiceBusModelFactory.ServiceBusReceivedMessage(
        body: new BinaryData("message1"),
        messageId: "messageId1",
        partitionKey: "hellokey",
        correlationId: "correlationId",
        contentType: "contentType",
        replyTo: "replyTo"
        //...
        );

    ServiceBusReceivedMessage message2 = ServiceBusModelFactory.ServiceBusReceivedMessage(
        body: new BinaryData("message2"),
        messageId: "messageId2",
        partitionKey: "hellokey",
        correlationId: "correlationId",
        contentType: "contentType",
        replyTo: "replyTo"
        //...
        );

    // IAsyncEnumerable types can only be returned by async functions, use this no-op await statement to
    // force the method to be async.

    await Task.Yield();

    // Yield statements allow methods to emit multiple outputs. In async methods this can be over time.

    yield return message1;
    yield return message2;
}

mockReceiver
    .Setup(receiver => receiver.ReceiveMessagesAsync(
        It.IsAny<CancellationToken>()))
    .Returns(mockReturn);

ServiceBusClient client = mockClient.Object;

// The rest of this snippet illustrates how to receie messages using the mocked service bus client above,
// this would be where application methods receiving messages would be called.

var mockQueueName = "MockQueueName";
ServiceBusReceiver receiver = client.CreateReceiver(mockQueueName);

var cancellationTokenSource = new CancellationTokenSource();
cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(1));

await foreach (ServiceBusReceivedMessage message in receiver.ReceiveMessagesAsync(cancellationTokenSource.Token))
{
    // application control
}
```


## Sending a batch of messages

```C# Snippet:ServiceBus_MockingSendBatch
Mock<ServiceBusClient> mockClient = new();
Mock<ServiceBusSender> mockSender = new();

mockClient
    .Setup(client => client.CreateSender(It.IsAny<string>()))
    .Returns(mockSender.Object);

List<ServiceBusMessage> backingList = new();

int batchCountThreshold = 5;

ServiceBusMessageBatch mockBatch = ServiceBusModelFactory.ServiceBusMessageBatch(
    batchSizeBytes: 500,
    batchMessageStore: backingList,
    batchOptions: new CreateMessageBatchOptions(),
    tryAddCallback: _=> backingList.Count < batchCountThreshold);

mockSender
    .Setup(sender => sender.CreateMessageBatchAsync(
        It.IsAny<CancellationToken>()))
    .ReturnsAsync(mockBatch);

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

List<ServiceBusMessage> sourceMessages = new();

for (int index = 0; index < batchCountThreshold; index++)
{
    var message = new ServiceBusMessage($"Sample-Message-{index}");
    sourceMessages.Add(message);
}

foreach (var message in sourceMessages)
{
    Assert.True(batch.TryAddMessage(message));
}

await sender.SendMessagesAsync(batch);

mockSender
    .Verify(sender => sender.SendMessagesAsync(
        It.IsAny<ServiceBusMessageBatch>(),
        It.IsAny<CancellationToken>()),
    Times.Once);

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
        TopicProperties mockTopicProperties = ServiceBusModelFactory.TopicProperties(opts);

        mockTopicResponse.Setup(r => r.Value).Returns(mockTopicProperties);
    })
    .ReturnsAsync(mockTopicResponse.Object);

mockAdministrationClient
    .Setup(client => client.CreateSubscriptionAsync(
        It.IsAny<CreateSubscriptionOptions>(),
        It.IsAny<CancellationToken>()))
    .Callback<CreateSubscriptionOptions, CancellationToken>((opts, ct) =>
    {
        SubscriptionProperties mockSubscriptionProperties = ServiceBusModelFactory.SubscriptionProperties(opts);

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
        QueueProperties mockQueueProperties = ServiceBusModelFactory.QueueProperties(opts);

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
        RuleProperties mockRuleProperties = ServiceBusModelFactory.RuleProperties(opts);

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
    cancellationToken: source.Token);

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