# Azure Communication JobRouter client library for .NET

This package contains a C# SDK for Azure Communication Services for JobRouter.

[Source code][source] | [Package (NuGet)][package] | [Product documentation][product_docs]


## Getting started

### Install the package
Install the Azure Communication JobRouter client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Communication.JobRouter 
``` 

### Prerequisites
You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

### Authenticate the client

### Using statements
```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter;
```

### Create a JobRouter Client

This will allow you to interact with the JobRouter Service
```C#
var routerClient new RouterClient("<Communication Service Connection String>");
```


## Key concepts

### Job
A Job represents the unit of work, which needs to be routed to an available Worker. 
A real-world example of this may be an incoming call or chat in the context of a call center.

### Worker
A Worker represents the supply available to handle a Job. Each worker registers with with or more queues to receive jobs.
A real-world example of this may be an agent working in a call center.

### Queue
A Queue represents an ordered list of jobs waiting to be served by a worker.  Workers will register with a queue to receive work from it.
A real-world example of this may be a call queue in a call center.

## Channel
A Channel represents a grouping of jobs by some type.  When a worker registers to receive work, they must also specify for which channels they can handle work, and how much of each can they handle concurrently.
A real-world example of this may be `voice calls` or `chats` in a call center.

### Offer
An Offer is extended by JobRouter to a worker to handle a particular job when it determines a match, this notification is normally delivered via [EventGrid][subscribe_events].  The worker can either accept or decline the offer using th JobRouter API, or it will expire according to the time to live configured on the distribution policy.
A real-world example of this may be the ringing of an agent in a call center.

### Distribution Policy
A Distribution Policy represents a configuration set that governs how jobs in a queue are distributed to workers registered with that queue.
This configuration includes how long an Offer is valid before it expires and the dsitribution mode, which define the order in which workers are picked when there are multiple available.

#### Distribution Mode
The 3 types of modes are
- **Round Robin**: Workers are ordered by `Id` and the next worker after the previous one that got an offer is picked.
- **Longest Idle**: The worker that has not been working on a job for the longest.
- **Best Worker**: You can specify an expression to compare 2 workers to determine which one to pick.

### Labels
You can attach labels to workers, jobs and queues.  These are key value pairs that can be of `string`, `number` or `boolean` data types.
A real-world example of this may be the skill level of a particular worker or the team or geographic location.

### Label Selectors
Label selectors can be attached to a job in order to target a subset of workers serving the queue.
A real-world example of this may be a condition on an incoming call that the agent must have a minimum level of knowledge of a particular product.

### Classification policy
A classification policy can be used to dynamically select a queue, determine job priority and attach worker label selectors to a job by leveraging a rules engine.

### Exception policy
An exception policy controls the behavior of a Job based on a trigger and executes a desired action. The exception policy is attached to a Queue so it can control the behavior of Jobs in the Queue.


## Example

### Distribution Policy
Before we can create a Queue, we need a Distribution Policy.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateDistributionPolicyLongestIdleTTL1D_Async
var distributionPolicy = await routerClient.CreateDistributionPolicyAsync(
    id: "distribution-policy-1",
    offerTtlSeconds: 24 * 60 * 60,
    mode: new LongestIdleMode()
);
```

### Queue
Next, we can create the queue.
```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateQueue_Async
var queue = await routerClient.CreateQueueAsync(
    id: "queue-1",
    distributionPolicyId: distributionPolicy.Value.Id
);
```

### Job
Now, we can submit a job directly to that queue, with a worker selector the requires the worker to have the label `Some-Skill` greater than 10.
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

### Worker
Now, we register a worker to receive work from that queue, with a label of `Some-Skill` equal to 11.
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

### Offer
We should get a [RouterWorkerOfferIssued][offer_issued_event_schema] from our [EventGrid subscription][subscribe_events].
However, we could also wait a few seconds and then query the worker directly against the JobRouter API to see if an offer was issued to it.
```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_QueryWorker_Async
var result = await routerClient.GetWorkerAsync(worker.Value.Id);
foreach (var offer in result.Value.Offers)
{
    Console.WriteLine($"Worker {worker.Value.Id} has an active offer for job {offer.JobId}");
}
```

## Next steps
[Read more about JobRouter in Azure Communication Services][nextsteps]

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[nuget]: https://www.nuget.org/
[netstandars2mappings]:https://github.com/dotnet/standard/blob/master/docs/versions.md
[useraccesstokens]:https://docs.microsoft.com/azure/communication-services/quickstarts/access-tokens?pivots=programming-language-csharp
[communication_resource_docs]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_portal]:  https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://docs.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net
[nextsteps]:https://docs.microsoft.com/azure/communication-services/concepts/router/concepts
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/src
[product_docs]: https://docs.microsoft.com/azure/communication-services/overview
[package]: https://www.nuget.org/packages/Azure.Communication.JobRouter
[classification_concepts]: https://docs.microsoft.com/azure/communication-services/concepts/router/classification-concepts
[subscribe_events]: https://docs.microsoft.com/azure/communication-services/how-tos/router-sdk/subscribe-events
[offer_issued_event_schema]: https://docs.microsoft.com/azure/communication-services/how-tos/router-sdk/subscribe-events#microsoftcommunicationrouterworkerofferissued
