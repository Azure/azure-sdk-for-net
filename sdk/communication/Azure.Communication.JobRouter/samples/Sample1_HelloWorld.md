# Azure.Communication.JobRouter Samples - Hello World (sync)

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

## Create a Distribution Policy

Use `RouterClient` to create a [Distribution Policy](https://learn.microsoft.com/azure/communication-services/concepts/router/concepts#distribution-policy) to control how jobs are to be distributed to workers with associated queue.

For this example, we are going to create a __Longest Idle__ policy with an offer TTL set to 1 day.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateDistributionPolicyLongestIdleTTL1D
Response<DistributionPolicy> distributionPolicy = routerAdministrationClient.CreateDistributionPolicy(
    new CreateDistributionPolicyOptions(
        distributionPolicyId: "distribution-policy-1",
        offerExpiresAfter: TimeSpan.FromDays(1),
        mode: new LongestIdleMode())
);
```

## Create a Queue

Use `RouterClient` to create a [Queue](https://learn.microsoft.com/azure/communication-services/concepts/router/concepts#queue).

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateQueue
Response<RouterQueue> queue = routerAdministrationClient.CreateQueue(
    new CreateQueueOptions(
        queueId: "queue-1",
        distributionPolicyId: distributionPolicy.Value.Id)
);
```

## Create a Job

Now, we can submit a [Job](https://learn.microsoft.com/azure/communication-services/concepts/router/concepts#job) directly to that queue, with a worker selector the requires the worker to have the label `Some-Skill` greater than 10.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateJobDirectQAssign
Response<RouterJob> job = routerClient.CreateJob(
    new CreateJobOptions(
        jobId: "jobId-2",
        channelId: "my-channel",
        queueId: queue.Value.Id)
    {
        ChannelReference = "12345",
        Priority = 1,
        RequestedWorkerSelectors =
        {
            new RouterWorkerSelector("Some-Skill", LabelOperator.GreaterThan, new RouterValue(10))
        },
    });
```

## Register a Worker

Register a worker associated with the queue that was just created. We will assign labels to the worker to include all relevant information for example, skills, which will be used to determine whether a job can be offered to a worker or not.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_RegisterWorker
Response<RouterWorker> worker = routerClient.CreateWorker(
    new CreateWorkerOptions(workerId: "worker-1", capacity: 1)
    {
        Queues = { queue.Value.Id },
        Labels = { ["Some-Skill"] = new RouterValue(11) },
        Channels = { new RouterChannel("my-channel", 1) },
        AvailableForOffers = true,
    }
);
```

## Check offers to a Worker

Once the worker has been registered, Router will send an offer to the worker if the worker satisfies requirements for a job. See [Offer flow](https://learn.microsoft.com/azure/communication-services/concepts/router/concepts#offer)

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
            AcsRouterWorkerOfferIssuedEventData? deserializedEventData =
                egEvent.Data.ToObjectFromJson<AcsRouterWorkerOfferIssuedEventData>();
            Console.Write(deserializedEventData?.OfferId); // Offer Id
            offerId = deserializedEventData?.OfferId ?? string.Empty;
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

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_QueryWorker
Response<RouterWorker> result = routerClient.GetWorker(worker.Value.Id);
foreach (RouterJobOffer? offer in result.Value.Offers)
{
    Console.WriteLine($"Worker {worker.Value.Id} has an active offer for job {offer.JobId}");
}
```

## Accepting an offer

Once a worker receives an offer, it can take two possible actions: accept or decline. We are going to accept the offer.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_AcceptOffer
// fetching the offer id
RouterJobOffer jobOffer = result.Value.Offers.First<RouterJobOffer>(x => x.JobId == job.Value.Id);

string offerId = jobOffer.OfferId; // `OfferId` can be retrieved directly from consuming event from Event grid

// accepting the offer sent to `worker-1`
Response<AcceptJobOfferResult> acceptJobOfferResult = routerClient.AcceptJobOffer(worker.Value.Id, offerId);

Console.WriteLine($"Offer: {jobOffer.OfferId} sent to worker: {worker.Value.Id} has been accepted");
Console.WriteLine($"Job has been assigned to worker: {worker.Value.Id} with assignment: {acceptJobOfferResult.Value.AssignmentId}");

// verify job assignment is populated when querying job
Response<RouterJob> updatedJob = routerClient.GetJob(job.Value.Id);
Console.WriteLine($"Job assignment has been successful: {updatedJob.Value.Status == RouterJobStatus.Assigned && updatedJob.Value.Assignments.ContainsKey(acceptJobOfferResult.Value.AssignmentId)}");
```

## Completing a job

Once the worker is done with the job, the worker has to mark the job as `completed`.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CompleteJob
Response completeJob = routerClient.CompleteJob(new CompleteJobOptions(job.Value.Id, acceptJobOfferResult.Value.AssignmentId)
    {
        Note = $"Job has been completed by {worker.Value.Id} at {DateTimeOffset.UtcNow}"
    });

Console.WriteLine($"Job has been successfully completed: {completeJob.Status == 200}");
```

## Closing a job

After a job has been completed, the worker can perform wrap up actions to the job before closing the job and finally releasing its capacity to accept more incoming jobs

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CloseJob
Response closeJob = routerClient.CloseJob(new CloseJobOptions(job.Value.Id, acceptJobOfferResult.Value.AssignmentId)
    {
        Note = $"Job has been closed by {worker.Value.Id} at {DateTimeOffset.UtcNow}"
    });
Console.WriteLine($"Job has been successfully closed: {closeJob.Status == 200}");

updatedJob = routerClient.GetJob(job.Value.Id);
Console.WriteLine($"Updated job status: {updatedJob.Value.Status == RouterJobStatus.Closed}");
```

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CloseJobInFuture
// Optionally, a job can also be set up to be marked as closed in the future.
var closeJobInFuture = routerClient.CloseJob(new CloseJobOptions(job.Value.Id,acceptJobOfferResult.Value.AssignmentId)
    {
        CloseAt = DateTimeOffset.UtcNow.AddSeconds(2), // this will mark the job as closed after 2 seconds
        Note = $"Job has been marked to close in the future by {worker.Value.Id} at {DateTimeOffset.UtcNow}"
    });
Console.WriteLine($"Job has been marked to close: {closeJob.Status == 202}"); // You'll received a 202 in that case

Thread.Sleep(TimeSpan.FromSeconds(2));

updatedJob = routerClient.GetJob(job.Value.Id);
Console.WriteLine($"Updated job status: {updatedJob.Value.Status == RouterJobStatus.Closed}");
```

<!-- LINKS -->
[subscribe_events]: https://learn.microsoft.com/azure/communication-services/how-tos/router-sdk/subscribe-events
[offer_issued_event_schema]: https://learn.microsoft.com/azure/communication-services/how-tos/router-sdk/subscribe-events#microsoftcommunicationrouterworkerofferissued
[deserialize_event_grid_event_data]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventgrid/Azure.Messaging.EventGrid#receiving-and-deserializing-events
[event_grid_event_handlers]: https://learn.microsoft.com/azure/event-grid/event-handlers
[webhook_event_grid_event_delivery]: https://learn.microsoft.com/azure/event-grid/webhook-event-delivery
