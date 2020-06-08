## CRUD operations
This sample demonstrates how to use the management client to manage entities within a namespace.

### Create a queue
```C# Snippet:CreateQueue
string connectionString = "<connection_string>";
string queueName = "<queue_name>";
var client = new ServiceBusClient(connectionString);
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

### Get queue
```C# Snippet:GetQueue
QueueDescription queueDescription = await client.GetQueueAsync(queueName);
```

### Update queue
```C# Snippet:UpdateQueue
queueDescription.LockDuration = TimeSpan.FromSeconds(60);
QueueDescription updatedQueue = await client.UpdateQueueAsync(queueDescription);
```

### Delete queue
```C# Snippet:DeleteQueue
await client.DeleteQueueAsync(queueName);
```
