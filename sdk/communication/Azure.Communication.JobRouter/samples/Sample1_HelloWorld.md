# Azure.Communication.JobRouter Samples - Hello World (sync)

## Import the namespaces

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter;
using Azure.Communication.JobRouter.Models;
```

## Create a client

Create a `RouterClient`.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient
var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
```

## Create a Distribution Policy

Use `RouterClient` to create a [Distribution Policy](https://docs.microsoft.com/en-us/azure/communication-services/concepts/router/concepts#distribution-policy) to control how jobs are to be distributed to workers with associated queue.

For this example, we are going to create a __Longest Idle__ policy with an offer TTL set to 1 day.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateDistributionPolicyLongestIdleTTL1D
var distributionPolicy = routerClient.SetDistributionPolicy(
    id: "distribution-policy-1",
    name: "My Distribution Policy",
    offerTTL: TimeSpan.FromDays(1),
    mode: new LongestIdleMode()
);
```

## Create a Queue

Use `RouterClient` to create a [Queue](https://docs.microsoft.com/en-us/azure/communication-services/concepts/router/concepts#queue).

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateQueue
var queue = routerClient.SetQueue(
    id: "queue-1",
    name: "My Queue",
    distributionPolicyId: distributionPolicy.Value.Id
);
```

## Create a Job

Now, we can submit a [Job](https://docs.microsoft.com/en-us/azure/communication-services/concepts/router/concepts#job) directly to that queue, with a worker selector the requires the worker to have the label `Some-Skill` greater than 10.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateJobDirectQAssign
var job = routerClient.CreateJob(
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

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_RegisterWorker
var worker = routerClient.RegisterWorker(
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

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_QueryWorker
var result = routerClient.GetWorker(worker.Value.Id);
foreach (var offer in result.Value.Offers)
{
    Console.WriteLine($"Worker {worker.Value.Id} has an active offer for job {offer.JobId}");
}
```
