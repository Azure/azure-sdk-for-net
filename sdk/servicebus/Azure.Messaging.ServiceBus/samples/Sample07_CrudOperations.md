## CRUD operations

This sample demonstrates how to use the management client to manage entities within a namespace.

### Create a queue

```C# Snippet:CreateQueue
string connectionString = "<connection_string>";
string queueName = "<queue_name>";
var client = new ServiceBusManagementClient(connectionString);
var queueDescription = new QueueDescription(queueName)
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

queueDescription.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
    "allClaims",
    new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen }));

// The CreateQueueAsync method will return the created queue
// which would include values for all of the
// QueueDescription properties (the service will supply
// default values for properties not included in the creation).
QueueDescription createdQueue = await client.CreateQueueAsync(queueDescription);
```

### Get a queue
You can retrieve an already created queue by supplying the queue name.

```C# Snippet:GetQueue
QueueDescription queueDescription = await client.GetQueueAsync(queueName);
```

### Update a queue

In order to update a queue, you will need to pass in the `QueueDescription` after 
getting it from `GetQueueAsync`.

```C# Snippet:UpdateQueue
queueDescription.LockDuration = TimeSpan.FromSeconds(60);
QueueDescription updatedQueue = await client.UpdateQueueAsync(queueDescription);
```

### Delete a queue

A queue can be deleted using the queue name.

```C# Snippet:DeleteQueue
await client.DeleteQueueAsync(queueName);
```

### Create a topic and subscription

```C# Snippet:CreateTopicAndSubscription
string connectionString = "<connection_string>";
string topicName = "<topic_name>";
var client = new ServiceBusManagementClient(connectionString);
var topicDescription = new TopicDescription(topicName)
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

topicDescription.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
    "allClaims",
    new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen }));

TopicDescription createdTopic = await client.CreateTopicAsync(topicDescription);

string subscriptionName = "<subscription_name>";
var subscriptionDescription = new SubscriptionDescription(topicName, subscriptionName)
{
    AutoDeleteOnIdle = TimeSpan.FromDays(7),
    DefaultMessageTimeToLive = TimeSpan.FromDays(2),
    EnableBatchedOperations = true,
    UserMetadata = "some metadata"
};
SubscriptionDescription createdSubscription = await client.CreateSubscriptionAsync(subscriptionDescription);
```

### Get a topic

You can retrieve an already created topic by supplying the topic name.

```C# Snippet:GetTopic
TopicDescription topicDescription = await client.GetTopicAsync(topicName);
```

### Get a subscription

You can retrieve an already created subscription by supplying the topic and subscription names.

```C# Snippet:GetSubscription
SubscriptionDescription subscriptionDescription = await client.GetSubscriptionAsync(topicName, subscriptionName);
```

### Update a topic

In order to update a topic, you will need to pass in the `TopicDescription` after 
getting it from `GetTopicAsync`.

```C# Snippet:UpdateTopic
topicDescription.UserMetadata = "some metadata";
TopicDescription updatedTopic = await client.UpdateTopicAsync(topicDescription);
```

### Update a subscription

In order to update a subscription, you will need to pass in the 
`SubscriptionDescription` after getting it from `GetSubscriptionAsync`.

```C# Snippet:UpdateSubscription
subscriptionDescription.UserMetadata = "some metadata";
SubscriptionDescription updatedSubscription = await client.UpdateSubscriptionAsync(subscriptionDescription);
```

### Delete a subscription

A subscription can be deleted using the topic and subscription names.

```C# Snippet:DeleteSubscription
await client.DeleteSubscriptionAsync(topicName, subscriptionName);
```

### Delete a topic

A topic can be deleted using the topic name. Deleting a topic will automatically delete the 
associated subscriptions.

```C# Snippet:DeleteTopic
await client.DeleteTopicAsync(topicName);
```

## Source

To see the full example source, see:

* [Sample07_CrudOperations.cs](../tests/Samples/Sample07_CrudOperations.cs)
