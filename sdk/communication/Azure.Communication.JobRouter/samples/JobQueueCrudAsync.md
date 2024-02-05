# Azure.Communication.JobRouter Samples - Job Queue CRUD operations (async)

## Import the namespaces

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter;
```

## Create a client

Create a `RouterClient`.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient
JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");
JobRouterAdministrationClient routerAdministrationClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");
```

## Create a job queue

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateJobQueue_Async
// set `distributionPolicyId` to an existing distribution policy
string jobQueueId = "job-queue-id";

Response<RouterQueue> jobQueue = await routerAdministrationClient.CreateQueueAsync(
    options: new CreateQueueOptions(jobQueueId, distributionPolicyId)
    {
        Name = "My job queue"
    });

Console.WriteLine($"Job queue successfully create with id: {jobQueue.Value.Id}");
```

## Get a job queue

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueue_Async
Response<RouterQueue> queriedJobQueue = await routerAdministrationClient.GetQueueAsync(jobQueueId);

Console.WriteLine($"Successfully fetched queue with id: {queriedJobQueue.Value.Id}");
```

## Get queue statistics

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueueStat_Async
Response<RouterQueueStatistics> queueStatistics = await routerClient.GetQueueStatisticsAsync(jobQueueId);

Console.WriteLine($"Queue statistics successfully retrieved for queue: {JsonSerializer.Serialize(queueStatistics.Value)}");
```


## Update a job queue

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateGetJobQueue_Async
Response<RouterQueue> updatedJobQueue = await routerAdministrationClient.UpdateQueueAsync(
    new RouterQueue(jobQueueId)
    {
        Labels = { ["Additional-Queue-Label"] = new RouterValue("ChatQueue") }
    });
```

## List job queues

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueues_Async
AsyncPageable<RouterQueue> jobQueues = routerAdministrationClient.GetQueuesAsync(cancellationToken: default);
await foreach (Page<RouterQueue> asPage in jobQueues.AsPages(pageSizeHint: 10))
{
    foreach (RouterQueue? policy in asPage.Values)
    {
        Console.WriteLine($"Listing job queue with id: {policy.Id}");
    }
}
```

## Delete a job queue

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteJobQueue_Async
_ = await routerAdministrationClient.DeleteQueueAsync(jobQueueId);
```
