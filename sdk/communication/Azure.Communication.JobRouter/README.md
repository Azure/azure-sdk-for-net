# Azure Communication JobRouter client library for .NET

This package contains a C# SDK for Azure Communication Services for JobRouter.

[Source code][source] | [Package (NuGet)][nuget_link] | [Product documentation][product_docs]


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
```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient
JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");
JobRouterAdministrationClient routerAdministrationClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");
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
This configuration includes how long an Offer is valid before it expires and the distribution mode, which define the order in which workers are picked when there are multiple available.

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

## Examples

### Distribution Policy
Before we can create a Queue, we need a Distribution Policy.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateDistributionPolicyLongestIdleTTL1D_Async
Response<DistributionPolicy> distributionPolicy = await routerAdministrationClient.CreateDistributionPolicyAsync(
    new CreateDistributionPolicyOptions(
        distributionPolicyId: "distribution-policy-1",
        offerExpiresAfter: TimeSpan.FromDays(1),
        mode: new LongestIdleMode())
);
```

### Queue
Next, we can create the queue.
```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateQueue_Async
Response<RouterQueue> queue = await routerAdministrationClient.CreateQueueAsync(
    new CreateQueueOptions(
        queueId: "queue-1",
        distributionPolicyId: distributionPolicy.Value.Id)
);
```

### Job
Now, we can submit a job directly to that queue, with a worker selector the requires the worker to have the label `Some-Skill` greater than 10.
```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateJobDirectQAssign_Async
Response<RouterJob> job = await routerClient.CreateJobAsync(
    new CreateJobOptions(
        jobId: "jobId-1",
        channelId: "my-channel",
        queueId: queue.Value.Id)
    {
        ChannelReference = "12345",
        Priority = 1,
        RequestedWorkerSelectors =
        {
            new RouterWorkerSelector("Some-Skill", LabelOperator.GreaterThan, new RouterValue(10))
        }
    });
```

### Worker
Now, we register a worker to receive work from that queue, with a label of `Some-Skill` equal to 11.
```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_RegisterWorker_Async
Response<RouterWorker> worker = await routerClient.CreateWorkerAsync(
    new CreateWorkerOptions(workerId: "worker-1", capacity: 1)
    {
        Queues = { queue.Value.Id },
        Labels = { ["Some-Skill"] = new RouterValue(11) },
        Channels = { new RouterChannel("my-channel", 1) },
        AvailableForOffers = true,
    }
);
```

### Offer
We should get a [RouterWorkerOfferIssued][offer_issued_event_schema] from our [EventGrid subscription][subscribe_events].

There are several different Azure services that act as a [event handler][event_grid_event_handlers].
For this scenario, we are going to assume Webhooks for event delivery. [Learn more about Webhook event delivery][webhook_event_grid_event_delivery]

Once events are delivered to the event handler, we can deserialize the JSON payload into a list of events.

```C# Snippet:EGEventParseJson
// Parse the JSON payload into a list of events
EventGridEvent[] egEvents = EventGridEvent.ParseMany(BinaryData.FromStream(httpContent));
```

```C# Snippet:DeserializePayloadUsingAsSystemEventData
string offerId;
foreach (EventGridEvent egEvent in egEvents)
{
    // This is a temporary fix before Router events are on-boarded as system events
    switch (egEvent.EventType)
    {
        case "Microsoft.Communication.WorkerOfferIssued":
            AcsRouterWorkerOfferIssuedEventData deserializedEventData =
                egEvent.Data.ToObjectFromJson<AcsRouterWorkerOfferIssuedEventData>();
            Console.Write(deserializedEventData.OfferId); // Offer Id
            offerId = deserializedEventData.OfferId;
            break;
        // Handle any other custom event type
        default:
            Console.Write(egEvent.EventType);
            Console.WriteLine(egEvent.Data.ToString());
            break;
    }
}
```

However, we could also wait a few seconds and then query the worker directly against the JobRouter API to see if an offer was issued to it.
```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_QueryWorker_Async
Response<RouterWorker> result = await routerClient.GetWorkerAsync(worker.Value.Id);
foreach (RouterJobOffer? offer in result.Value.Offers)
{
    Console.WriteLine($"Worker {worker.Value.Id} has an active offer for job {offer.JobId}");
}
```

### Accept an offer
Once a worker receives an offer, it can take two possible actions: accept or decline. We are going to accept the offer.
```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_AcceptOffer_Async
// fetching the offer id
RouterJobOffer jobOffer = result.Value.Offers.First<RouterJobOffer>(x => x.JobId == job.Value.Id);

string offerId = jobOffer.OfferId; // `OfferId` can be retrieved directly from consuming event from Event grid

// accepting the offer sent to `worker-1`
Response<AcceptJobOfferResult> acceptJobOfferResult = await routerClient.AcceptJobOfferAsync(worker.Value.Id, offerId);

Console.WriteLine($"Offer: {jobOffer.OfferId} sent to worker: {worker.Value.Id} has been accepted");
Console.WriteLine($"Job has been assigned to worker: {worker.Value.Id} with assignment: {acceptJobOfferResult.Value.AssignmentId}");

// verify job assignment is populated when querying job
Response<RouterJob> updatedJob = await routerClient.GetJobAsync(job.Value.Id);
Console.WriteLine($"Job assignment has been successful: {updatedJob.Value.Status == RouterJobStatus.Assigned && updatedJob.Value.Assignments.ContainsKey(acceptJobOfferResult.Value.AssignmentId)}");
```

### Completing a job
Once the worker is done with the job, the worker has to mark the job as `completed`.
```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CompleteJob_Async
Response completeJob = await routerClient.CompleteJobAsync(new CompleteJobOptions(job.Value.Id, acceptJobOfferResult.Value.AssignmentId)
    {
        Note = $"Job has been completed by {worker.Value.Id} at {DateTimeOffset.UtcNow}"
    });

Console.WriteLine($"Job has been successfully completed: {completeJob.Status == 200}");
```

### Closing a job
After a job has been completed, the worker can perform wrap up actions to the job before closing the job and finally releasing its capacity to accept more incoming jobs
```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CloseJob_Async
Response closeJob = await routerClient.CloseJobAsync(new CloseJobOptions(job.Value.Id, acceptJobOfferResult.Value.AssignmentId)
    {
        Note = $"Job has been closed by {worker.Value.Id} at {DateTimeOffset.UtcNow}"
    });
Console.WriteLine($"Job has been successfully closed: {closeJob.Status == 200}");

updatedJob = await routerClient.GetJobAsync(job.Value.Id);
Console.WriteLine($"Updated job status: {updatedJob.Value.Status == RouterJobStatus.Closed}");
```

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CloseJobInFuture_Async
// Optionally, a job can also be set up to be marked as closed in the future.
var closeJobInFuture = await routerClient.CloseJobAsync(new CloseJobOptions(job.Value.Id, acceptJobOfferResult.Value.AssignmentId)
    {
        CloseAt = DateTimeOffset.UtcNow.AddSeconds(2), // this will mark the job as closed after 2 seconds
        Note = $"Job has been marked to close in the future by {worker.Value.Id} at {DateTimeOffset.UtcNow}"
    });
Console.WriteLine($"Job has been marked to close: {closeJob.Status == 202}"); // You'll received a 202 in that case

await Task.Delay(TimeSpan.FromSeconds(2));

updatedJob = await routerClient.GetJobAsync(job.Value.Id);
Console.WriteLine($"Updated job status: {updatedJob.Value.Status == RouterJobStatus.Closed}");
```

## Troubleshooting

Running into issues? This section should contain details as to what to do there.

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
[classification_concepts]: https://docs.microsoft.com/azure/communication-services/concepts/router/classification-concepts
[subscribe_events]: https://docs.microsoft.com/azure/communication-services/how-tos/router-sdk/subscribe-events
[offer_issued_event_schema]: https://docs.microsoft.com/azure/communication-services/how-tos/router-sdk/subscribe-events#microsoftcommunicationrouterworkerofferissued
[deserialize_event_grid_event_data]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventgrid/Azure.Messaging.EventGrid#receiving-and-deserializing-events
[event_grid_event_handlers]: https://docs.microsoft.com/azure/event-grid/event-handlers
[webhook_event_grid_event_delivery]: https://docs.microsoft.com/azure/event-grid/webhook-event-delivery
[nuget_link]: https://www.nuget.org
