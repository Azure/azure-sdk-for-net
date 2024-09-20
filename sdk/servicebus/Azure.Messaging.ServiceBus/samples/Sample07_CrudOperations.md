# CRUD operations

This sample demonstrates how to use the management client to manage entities within a namespace.

## Create a queue

```C# Snippet:CreateQueue
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string queueName = "<queue_name>";
var client = new ServiceBusAdministrationClient(fullyQualifiedNamespace, new DefaultAzureCredential());
var options = new CreateQueueOptions(queueName)
{
    AutoDeleteOnIdle = TimeSpan.FromDays(7),
    DefaultMessageTimeToLive = TimeSpan.FromDays(2),
    DuplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(1),
    EnableBatchedOperations = true,
    DeadLetteringOnMessageExpiration = true,
    EnablePartitioning = false,
    ForwardDeadLetteredMessagesTo = null,
    ForwardTo = null,
    LockDuration = TimeSpan.FromSeconds(45),
    MaxDeliveryCount = 8,
    MaxSizeInMegabytes = 2048,
    RequiresDuplicateDetection = true,
    RequiresSession = true,
    UserMetadata = "some metadata"
};

options.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
    "allClaims",
    new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen }));

QueueProperties createdQueue = await client.CreateQueueAsync(options);
```

## Get a queue

You can retrieve an already created queue by supplying the queue name.

```C# Snippet:GetQueue
QueueProperties queue = await client.GetQueueAsync(queueName);
```

## Update a queue

In order to update a queue, you will need to pass in the `QueueDescription` after getting it from `GetQueueAsync`.

```C# Snippet:UpdateQueue
queue.LockDuration = TimeSpan.FromSeconds(60);
QueueProperties updatedQueue = await client.UpdateQueueAsync(queue);
```

## Delete a queue

A queue can be deleted using the queue name.

```C# Snippet:DeleteQueue
await client.DeleteQueueAsync(queueName);
```

## Create a topic and subscription

```C# Snippet:CreateTopicAndSubscription
string fullyQualifiedNamespace = "<fully_qualified_namespace>";
string topicName = "<topic_name>";
var client = new ServiceBusAdministrationClient(fullyQualifiedNamespace, new DefaultAzureCredential());
var topicOptions = new CreateTopicOptions(topicName)
{
    AutoDeleteOnIdle = TimeSpan.FromDays(7),
    DefaultMessageTimeToLive = TimeSpan.FromDays(2),
    DuplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(1),
    EnableBatchedOperations = true,
    EnablePartitioning = false,
    MaxSizeInMegabytes = 2048,
    RequiresDuplicateDetection = true,
    UserMetadata = "some metadata"
};

topicOptions.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
    "allClaims",
    new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen }));

TopicProperties createdTopic = await client.CreateTopicAsync(topicOptions);

string subscriptionName = "<subscription_name>";
var subscriptionOptions = new CreateSubscriptionOptions(topicName, subscriptionName)
{
    AutoDeleteOnIdle = TimeSpan.FromDays(7),
    DefaultMessageTimeToLive = TimeSpan.FromDays(2),
    EnableBatchedOperations = true,
    UserMetadata = "some metadata"
};
SubscriptionProperties createdSubscription = await client.CreateSubscriptionAsync(subscriptionOptions);
```

## Get a topic

You can retrieve an already created topic by supplying the topic name.

```C# Snippet:GetTopic
TopicProperties topic = await client.GetTopicAsync(topicName);
```

## Get a subscription

You can retrieve an already created subscription by supplying the topic and subscription names.

```C# Snippet:GetSubscription
SubscriptionProperties subscription = await client.GetSubscriptionAsync(topicName, subscriptionName);
```

## Update a topic

In order to update a topic, you will need to pass in the `TopicDescription` after getting it from `GetTopicAsync`.

```C# Snippet:UpdateTopic
topic.UserMetadata = "some metadata";
TopicProperties updatedTopic = await client.UpdateTopicAsync(topic);
```

## Update a subscription

In order to update a subscription, you will need to pass in the `SubscriptionDescription` after getting it from `GetSubscriptionAsync`.

```C# Snippet:UpdateSubscription
subscription.UserMetadata = "some metadata";
SubscriptionProperties updatedSubscription = await client.UpdateSubscriptionAsync(subscription);
```

## Delete a subscription

A subscription can be deleted using the topic and subscription names.

```C# Snippet:DeleteSubscription
await client.DeleteSubscriptionAsync(topicName, subscriptionName);
```

## Delete a topic

A topic can be deleted using the topic name. Deleting a topic will automatically delete the associated subscriptions.

```C# Snippet:DeleteTopic
await client.DeleteTopicAsync(topicName);
```
