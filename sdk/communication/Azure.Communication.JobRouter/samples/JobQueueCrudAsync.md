# Azure.Communication.JobRouter Samples - Job Queue CRUD operations (async)

## Import the namespaces

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter;
```

## Create a client

Create a `RouterClient`.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient
var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
```

## Create a job queue

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateJobQueue_Async
// set `distributionPolicyId` to an existing distribution policy
var jobQueueId = "job-queue-id";

var jobQueue = await routerClient.CreateQueueAsync(
    id: jobQueueId,
    distributionPolicyId: distributionPolicyId,
    options: new CreateQueueOptions() // this is optional
    {
        Name = "My job queue"
    });

Console.WriteLine($"Job queue successfully create with id: {jobQueue.Value.Id}");
```

## Get a job queue

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueue_Async
var queriedJobQueue = await routerClient.GetQueueAsync(jobQueueId);

Console.WriteLine($"Successfully fetched queue with id: {queriedJobQueue.Value.Id}");
```

## Get queue statistics

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueueStat_Async
var queueStatistics = await routerClient.GetQueueStatisticsAsync(id: jobQueueId);

Console.WriteLine($"Queue statistics successfully retrieved for queue: {JsonSerializer.Serialize(queueStatistics.Value)}");
```


## Update a job queue

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateGetJobQueue_Async
var updatedJobQueue = await routerClient.UpdateQueueAsync(
    id: jobQueueId,
    options: new UpdateQueueOptions()
    {
        Labels = new LabelCollection()
        {
            ["Additional-Queue-Label"] = "ChatQueue"
        }
    });
```

## List job queues

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueues_Async
var jobQueues = routerClient.GetQueuesAsync();
await foreach (var asPage in jobQueues.AsPages(pageSizeHint: 10))
{
    foreach (var policy in asPage.Values)
    {
        Console.WriteLine($"Listing job queue with id: {policy.Id}");
    }
}
```

## Delete a job queue

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteJobQueue_Async
_ = await routerClient.DeleteQueueAsync(jobQueueId);
```
