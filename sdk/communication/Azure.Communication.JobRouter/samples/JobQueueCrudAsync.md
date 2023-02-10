# Azure.Communication.JobRouter Samples - Job Queue CRUD operations (async)

## Import the namespaces

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter;
using Azure.Communication.JobRouter.Models;
```

## Create a client

Create a `RouterClient`.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient
RouterClient routerClient = new RouterClient("<< CONNECTION STRING >>");
RouterAdministrationClient routerAdministrationClient = new RouterAdministrationClient("<< CONNECTION STRING >>");
```

## Create a job queue

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateJobQueue_Async
// set `distributionPolicyId` to an existing distribution policy
string jobQueueId = "job-queue-id";

Response<JobQueue> jobQueue = await routerAdministrationClient.CreateQueueAsync(
    options: new CreateQueueOptions(jobQueueId, distributionPolicyId)
    {
        Name = "My job queue"
    });

Console.WriteLine($"Job queue successfully create with id: {jobQueue.Value.Id}");
```

## Get a job queue

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueue_Async
Response<JobQueue> queriedJobQueue = await routerAdministrationClient.GetQueueAsync(jobQueueId);

Console.WriteLine($"Successfully fetched queue with id: {queriedJobQueue.Value.Id}");
```

## Get queue statistics

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueueStat_Async
Response<QueueStatistics> queueStatistics = await routerClient.GetQueueStatisticsAsync(queueId: jobQueueId);

Console.WriteLine($"Queue statistics successfully retrieved for queue: {JsonSerializer.Serialize(queueStatistics.Value)}");
```


## Update a job queue

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateGetJobQueue_Async
Response<JobQueue> updatedJobQueue = await routerAdministrationClient.UpdateQueueAsync(
    options: new UpdateQueueOptions(jobQueueId)
    {
        Labels = new Dictionary<string, LabelValue>()
        {
            ["Additional-Queue-Label"] = new LabelValue("ChatQueue")
        }
    });
```

## List job queues

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueues_Async
AsyncPageable<JobQueueItem> jobQueues = routerAdministrationClient.GetQueuesAsync();
await foreach (Page<JobQueueItem> asPage in jobQueues.AsPages(pageSizeHint: 10))
{
    foreach (JobQueueItem? policy in asPage.Values)
    {
        Console.WriteLine($"Listing job queue with id: {policy.JobQueue.Id}");
    }
}
```

## Delete a job queue

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteJobQueue_Async
_ = await routerAdministrationClient.DeleteQueueAsync(jobQueueId);
```
