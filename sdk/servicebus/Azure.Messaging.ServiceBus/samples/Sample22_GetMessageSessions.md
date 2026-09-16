# List message sessions

This sample demonstrates how to list session IDs for a session-enabled queue or subscription using `ServiceBusClient.GetMessageSessionsAsync`.
Without a filter, listing returns sessions with active messages or stored session state and excludes sessions with neither.

## Queue

```C# Snippet:ServiceBusGetMessageSessionsFromQueue
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());

await foreach (string sessionId in client.GetMessageSessionsAsync(queueName))
{
    Console.WriteLine(sessionId);
}
```

## Topic subscription

```C# Snippet:ServiceBusGetMessageSessionsFromSubscription
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string topicName = "<topic_name>";
string subscriptionName = "<subscription_name>";

await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());

await foreach (string sessionId in client.GetMessageSessionsAsync(topicName, subscriptionName))
{
    Console.WriteLine(sessionId);
}
```

## Sessions with recently updated state

Pass a real cutoff to list only sessions whose stored session state was set or updated after that time:

```C# Snippet:ServiceBusGetMessageSessionsUpdatedAfter
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";

await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());

DateTimeOffset stateUpdatedAfter = DateTimeOffset.UtcNow.AddDays(-7);

await foreach (string sessionId in client.GetMessageSessionsAsync(queueName, stateUpdatedAfter))
{
    Console.WriteLine(sessionId);
}
```
