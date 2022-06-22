# Azure.Communication.JobRouter Samples - Job Queue CRUD operations (sync)

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

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateJobQueue
// set `distributionPolicyId` to an existing distribution policy
var jobQueueId = "job-queue-id";

var jobQueue = routerClient.CreateQueue(
    id: jobQueueId,
    distributionPolicyId: distributionPolicyId,
    options: new CreateQueueOptions() // this is optional
    {
        Name = "My job queue"
    });

Console.WriteLine($"Job queue successfully create with id: {jobQueue.Value.Id}");
```

## Get a job queue

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueue
var queriedJobQueue = routerClient.GetQueue(jobQueueId);

Console.WriteLine($"Successfully fetched queue with id: {queriedJobQueue.Value.Id}");
```

## Get queue statistics

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueueStat
var queueStatistics = routerClient.GetQueueStatistics(id: jobQueueId);

Console.WriteLine($"Queue statistics successfully retrieved for queue: {JsonSerializer.Serialize(queueStatistics.Value)}");
```

## Update a job queue

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateGetJobQueue
var updatedJobQueue = routerClient.UpdateQueue(
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

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueues
var jobQueues = routerClient.GetQueues();
foreach (var asPage in jobQueues.AsPages(pageSizeHint: 10))
{
    foreach (var policy in asPage.Values)
    {
        Console.WriteLine($"Listing job queue with id: {policy.Id}");
    }
}
```

## Delete a job queue

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteJobQueue
_ = routerClient.DeleteQueue(jobQueueId);
```
