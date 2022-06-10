# Azure.Communication.JobRouter Samples - Hello World (async)

## Import the namespaces

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements_Async
using Azure.Communication.JobRouter;
using Azure.Communication.JobRouter.Models;
```

## Create a client

Create a `RouterClient`.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient_Async
var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
```

## Create a Distribution Policy

Use `RouterClient` to create a [Distribution Policy](https://docs.microsoft.com/en-us/azure/communication-services/concepts/router/concepts#distribution-policy) to control how jobs are to be distributed to workers with associated queue.

For this example, we are going to create a __Longest Idle__ policy with an offer TTL set to 1 day.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateDistributionPolicyLongestIdleTTL1D_Async
var distributionPolicy = await routerClient.SetDistributionPolicyAsync(
    id: "distribution-policy-1",
    name: "My Distribution Policy",
    offerTTL: TimeSpan.FromDays(1),
    mode: new LongestIdleMode()
);
```

## Create a Queue

Use `RouterClient` to create a [Queue](https://docs.microsoft.com/en-us/azure/communication-services/concepts/router/concepts#queue).

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateQueue_Async
var queue = await routerClient.SetQueueAsync(
    id: "queue-1",
    name: "My Queue",
    distributionPolicyId: distributionPolicy.Value.Id
);
```

## Create a Job

Use `RouterClient` to create a [Job](https://docs.microsoft.com/en-us/azure/communication-services/concepts/router/concepts#job).

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateJobDirectQAssign_Async
var job = await routerClient.CreateJobAsync(
    channelId: "my-channel",
    channelReference: "12345",
    queueId: queue.Value.Id,
    priority: 1,
    workerSelectors: new List<LabelSelector>
    {
        new LabelSelector("Some-Skill", LabelOperator.GreaterThan, 10)
    });
```

## Register a Worker

Register a worker associated with the queue that was just created. We will assign labels to the worker to include all relevant information for example, skills, which will be used to determine whether a job can be offered to a worker or not.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_RegisterWorker_Async
var worker = await routerClient.RegisterWorkerAsync(
    id: "worker-1",
    queueIds: new[] { queue.Value.Id },
    totalCapacity: 1,
    labels: new LabelCollection()
    {
        ["Some-Skill"] = 11
    },
    channelConfigurations: new List<ChannelConfiguration>
    {
        new ChannelConfiguration("my-channel", 1)
    }
);
```

## Check offers to a Worker

Once the worker has been registered, Router will send an offer to the worker if the worker satisfies requirements for a job. See [Offer flow](https://docs.microsoft.com/en-us/azure/communication-services/concepts/router/concepts#offer-flow)

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_QueryWorker_Async
var result = await routerClient.GetWorkerAsync(worker.Value.Id);
foreach (var offer in result.Value.Offers)
{
    Console.WriteLine($"Worker {worker.Value.Id} has an active offer for job {offer.JobId}");
}
```
