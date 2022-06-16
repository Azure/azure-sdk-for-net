# Azure.Communication.JobRouter Samples - Hello World (async)

## Import the namespaces

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements_Async
using Azure.Communication.JobRouter;
```

## Create a client

Create a `RouterClient`.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient_Async
var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
```

## Create a Distribution Policy

Use `RouterClient` to create a [Distribution Policy](https://docs.microsoft.com/azure/communication-services/concepts/router/concepts#distribution-policy) to control how jobs are to be distributed to workers with associated queue.

For this example, we are going to create a __Longest Idle__ policy with an offer TTL set to 1 day.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateDistributionPolicyLongestIdleTTL1D_Async
var distributionPolicy = await routerClient.CreateDistributionPolicyAsync(
    id: "distribution-policy-1",
    offerTtlSeconds: 24 * 60 * 60,
    mode: new LongestIdleMode()
);
```

## Create a Queue

Use `RouterClient` to create a [Queue](https://docs.microsoft.com/azure/communication-services/concepts/router/concepts#queue).

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateQueue_Async
var queue = await routerClient.CreateQueueAsync(
    id: "queue-1",
    distributionPolicyId: distributionPolicy.Value.Id
);
```

## Create a Job

Use `RouterClient` to create a [Job](https://docs.microsoft.com/azure/communication-services/concepts/router/concepts#job).

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateJobDirectQAssign_Async
var job = await routerClient.CreateJobAsync(
    id: "jobId-1",
    channelId: "my-channel",
    queueId: queue.Value.Id,
    new CreateJobOptions()
    {
        ChannelReference = "12345",
        Priority = 1,
        RequestedWorkerSelectors = new List<WorkerSelector>
        {
            new WorkerSelector("Some-Skill", LabelOperator.GreaterThan, 10)
        }
    });
```

## Register a Worker

Register a worker associated with the queue that was just created. We will assign labels to the worker to include all relevant information for example, skills, which will be used to determine whether a job can be offered to a worker or not.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_RegisterWorker_Async
var worker = await routerClient.CreateWorkerAsync(
    id: "worker-1",
    totalCapacity: 1,
    new CreateWorkerOptions()
    {
        QueueIds = new[] { queue.Value.Id },
        Labels = new LabelCollection()
        {
            ["Some-Skill"] = 11
        },
        ChannelConfigurations = new Dictionary<string, ChannelConfiguration>()
        {
            ["my-channel"] = new ChannelConfiguration(1)
        },
        AvailableForOffers = true,
    }
);
```

## Check offers to a Worker

Once the worker has been registered, Router will send an offer to the worker if the worker satisfies requirements for a job. See [Offer flow](https://docs.microsoft.com/azure/communication-services/concepts/router/concepts#offer)

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_QueryWorker_Async
var result = await routerClient.GetWorkerAsync(worker.Value.Id);
foreach (var offer in result.Value.Offers)
{
    Console.WriteLine($"Worker {worker.Value.Id} has an active offer for job {offer.JobId}");
}
```
