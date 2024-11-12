# Using Namespace Topics

Namespace topics allow you to publish and receive events directly from Azure Event Grid
without the need to integrate with another service such as Storage Queues or Service Bus for event delivery. Namespace topics can be
interacted with using the `EventGridSenderClient` and the `EventGridReceiverClient`.

```C# Snippet:CreateNamespaceClient
// Construct the client using an Endpoint for a namespace as well as the shared access key
var senderClient = new EventGridSenderClient(new Uri(namespaceTopicHost), topicName, new AzureKeyCredential(namespaceKey));
```

Publishing CloudEvents is very similar to the experience of publishing to custom topics using the `EventGridPublisherClient`.
One key difference is that the `EventGrid` schema is not supported for publishing to namespace topics.

Publish a single CloudEvent:

```C# Snippet:PublishSingleEvent
var evt = new CloudEvent("employee_source", "type", new TestModel { Name = "Bob", Age = 18 });
await senderClient.SendAsync(evt);
```

Publish a batch of CloudEvents:

```C# Snippet:PublishBatchOfEvents
await senderClient.SendAsync(
    new[] {
        new CloudEvent("employee_source", "type", new TestModel { Name = "Tom", Age = 55 }),
        new CloudEvent("employee_source", "type", new TestModel { Name = "Alice", Age = 25 })
    });
```

Now that our events have been published, we can use our configured [namespace topic event subscription](https://learn.microsoft.com/azure/templates/microsoft.eventgrid/namespaces/topics/eventsubscriptions?pivots=deployment-language-arm-template), to receive
and process the events.
There are three different actions you can take on a received event:
- Acknowledge - this deletes the event from the subscription
- Release - this releases the event back to the subscription to be processed again by this or other consumers
- Reject - this rejects the event and moves it to the dead letter queue, if configured.

```C# Snippet:ReceiveAndProcessEvents
// Construct the client using an Endpoint for a namespace as well as the shared access key
var receiverClient = new EventGridReceiverClient(new Uri(namespaceTopicHost), topicName, subscriptionName, new AzureKeyCredential(namespaceKey));
ReceiveResult result = await receiverClient.ReceiveAsync(maxEvents: 3);

// Iterate through the results and collect the lock tokens for events we want to release/acknowledge/result
var toRelease = new List<string>();
var toAcknowledge = new List<string>();
var toReject = new List<string>();
foreach (ReceiveDetails detail in result.Details)
{
    CloudEvent @event = detail.Event;
    BrokerProperties brokerProperties = detail.BrokerProperties;
    Console.WriteLine(@event.Data.ToString());

    // The lock token is used to acknowledge, reject or release the event
    Console.WriteLine(brokerProperties.LockToken);

    var data = @event.Data.ToObjectFromJson<TestModel>();
    // If the data from the event has Name "Bob", we are not able to acknowledge it yet,
    // so we release it, thereby allowing other consumers to receive it.
    if (data.Name == "Bob")
    {
        toRelease.Add(brokerProperties.LockToken);
    }
    // If the data is for "Tom", we will acknowledge it thereby deleting it from the subscription.
    else if (data.Name == "Tom")
    {
        toAcknowledge.Add(brokerProperties.LockToken);
    }
    // reject all other events which will move the event to the dead letter queue if it is configured
    else
    {
        toReject.Add(brokerProperties.LockToken);
    }
}

if (toRelease.Count > 0)
{
    ReleaseResult releaseResult = await receiverClient.ReleaseAsync(toRelease);

    // Inspect the Release result
    Console.WriteLine($"Failed count for Release: {releaseResult.FailedLockTokens.Count}");
    foreach (FailedLockToken failedLockToken in releaseResult.FailedLockTokens)
    {
        Console.WriteLine($"Lock Token: {failedLockToken.LockToken}");
        Console.WriteLine($"Error Code: {failedLockToken.Error.Code}");
        Console.WriteLine($"Error Description: {failedLockToken.Error.Message}");
    }

    Console.WriteLine($"Success count for Release: {releaseResult.SucceededLockTokens.Count}");
    foreach (string lockToken in releaseResult.SucceededLockTokens)
    {
        Console.WriteLine($"Lock Token: {lockToken}");
    }
}

if (toAcknowledge.Count > 0)
{
    AcknowledgeResult acknowledgeResult = await receiverClient.AcknowledgeAsync(toAcknowledge);

    // Inspect the Acknowledge result
    Console.WriteLine($"Failed count for Acknowledge: {acknowledgeResult.FailedLockTokens.Count}");
    foreach (FailedLockToken failedLockToken in acknowledgeResult.FailedLockTokens)
    {
        Console.WriteLine($"Lock Token: {failedLockToken.LockToken}");
        Console.WriteLine($"Error Code: {failedLockToken.Error.Code}");
        Console.WriteLine($"Error Description: {failedLockToken.Error.Message}");
    }

    Console.WriteLine($"Success count for Acknowledge: {acknowledgeResult.SucceededLockTokens.Count}");
    foreach (string lockToken in acknowledgeResult.SucceededLockTokens)
    {
        Console.WriteLine($"Lock Token: {lockToken}");
    }
}

if (toReject.Count > 0)
{
    RejectResult rejectResult = await receiverClient.RejectAsync(toReject);

    // Inspect the Reject result
    Console.WriteLine($"Failed count for Reject: {rejectResult.FailedLockTokens.Count}");
    foreach (FailedLockToken failedLockToken in rejectResult.FailedLockTokens)
    {
        Console.WriteLine($"Lock Token: {failedLockToken.LockToken}");
        Console.WriteLine($"Error Code: {failedLockToken.Error.Code}");
        Console.WriteLine($"Error Description: {failedLockToken.Error.Message}");
    }

    Console.WriteLine($"Success count for Reject: {rejectResult.SucceededLockTokens.Count}");
    foreach (string lockToken in rejectResult.SucceededLockTokens)
    {
        Console.WriteLine($"Lock Token: {lockToken}");
    }
}
```
