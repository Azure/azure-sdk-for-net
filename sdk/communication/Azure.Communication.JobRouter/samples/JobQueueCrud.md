# Azure.Communication.JobRouter Samples - Job Queue CRUD operations (sync)

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

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateJobQueue
// set `distributionPolicyId` to an existing distribution policy
string jobQueueId = "job-queue-id";

Response<RouterQueue> jobQueue = routerAdministrationClient.CreateQueue(
    options: new CreateQueueOptions(jobQueueId, distributionPolicyId) // this is optional
    {
        Name = "My job queue"
    });

Console.WriteLine($"Job queue successfully create with id: {jobQueue.Value.Id}");
```

## Get a job queue

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueue
Response<RouterQueue> queriedJobQueue = routerAdministrationClient.GetQueue(jobQueueId);

Console.WriteLine($"Successfully fetched queue with id: {queriedJobQueue.Value.Id}");
```

## Get queue statistics

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueueStat
Response<RouterQueueStatistics> queueStatistics = routerClient.GetQueueStatistics(jobQueueId);

Console.WriteLine($"Queue statistics successfully retrieved for queue: {JsonSerializer.Serialize(queueStatistics.Value)}");
```

## Update a job queue

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateGetJobQueue
Response<RouterQueue> updatedJobQueue = routerAdministrationClient.UpdateQueue(new RouterQueue(jobQueueId)
{
    Labels = { ["Additional-Queue-Label"] = new RouterValue("ChatQueue") }
});
```

## List job queues

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueues
Pageable<RouterQueue> jobQueues = routerAdministrationClient.GetQueues(cancellationToken: default);
foreach (Page<RouterQueue> asPage in jobQueues.AsPages(pageSizeHint: 10))
{
    foreach (RouterQueue? policy in asPage.Values)
    {
        Console.WriteLine($"Listing job queue with id: {policy.Id}");
    }
}
```

## Delete a job queue

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteJobQueue
_ = routerAdministrationClient.DeleteQueue(jobQueueId);
```
