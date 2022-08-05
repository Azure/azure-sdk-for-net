# Azure.Communication.JobRouter Samples - Hello World (async)

## Import the namespaces

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements_Async
using Azure.Communication.JobRouter;
```

## Create a client

Create a `RouterClient`.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient_Async
var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
var routerAdministrationClient = new RouterAdministrationClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
```

## Create a Distribution Policy

Use `RouterClient` to create a [Distribution Policy](https://docs.microsoft.com/azure/communication-services/concepts/router/concepts#distribution-policy) to control how jobs are to be distributed to workers with associated queue.

For this example, we are going to create a __Longest Idle__ policy with an offer TTL set to 1 day.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateDistributionPolicyLongestIdleTTL1D_Async
var distributionPolicy = await routerAdministrationClient.CreateDistributionPolicyAsync(
    new CreateDistributionPolicyOptions(
        distributionPolicyId: "distribution-policy-1",
        offerTtl: TimeSpan.FromDays(1),
        mode: new LongestIdleMode())
);
```

## Create a Queue

Use `RouterClient` to create a [Queue](https://docs.microsoft.com/azure/communication-services/concepts/router/concepts#queue).

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateQueue_Async
var queue = await routerAdministrationClient.CreateQueueAsync(
    new CreateQueueOptions(
        queueId: "queue-1",
        distributionPolicyId: distributionPolicy.Value.Id)
);
```

## Create a Job

Use `RouterClient` to create a [Job](https://docs.microsoft.com/azure/communication-services/concepts/router/concepts#job).

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateJobDirectQAssign_Async
var job = await routerClient.CreateJobAsync(
    new CreateJobOptions(
        jobId: "jobId-1",
        channelId: "my-channel",
        queueId: queue.Value.Id)
    {
        ChannelReference = "12345",
        Priority = 1,
        RequestedWorkerSelectors = new List<WorkerSelector>
        {
            new WorkerSelector("Some-Skill", LabelOperator.GreaterThan, new LabelValue(10))
        }
    });
```

## Register a Worker

Register a worker associated with the queue that was just created. We will assign labels to the worker to include all relevant information for example, skills, which will be used to determine whether a job can be offered to a worker or not.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_RegisterWorker_Async
var worker = await routerClient.CreateWorkerAsync(
    new CreateWorkerOptions(
        workerId: "worker-1",
        totalCapacity: 1)
    {
        QueueIds = new Dictionary<string, QueueAssignment>() { [queue.Value.Id] = new QueueAssignment() },
        Labels = new Dictionary<string, LabelValue>()
        {
            ["Some-Skill"] = new LabelValue(11)
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

We should get a [RouterWorkerOfferIssued][offer_issued_event_schema] from our [EventGrid subscription][subscribe_events].

There are several different Azure services that act as a [event handler][event_grid_event_handlers].
For this scenario, we are going to assume Webhooks for event delivery. [Learn more about Webhook event delivery][webhook_event_grid_event_delivery]

Once events are delivered to the event handler, we can deserialize the JSON payload into a list of events.

```C#
// Parse the JSON payload into a list of events
EventGridEvent[] egEvents = EventGridEvent.ParseMany(BinaryData.FromStream(httpContent));
```

```C#
string offerId = null;
foreach (EventGridEvent egEvent in egEvents)
{
    // If the event is a system event, TryGetSystemEventData will return the deserialized system event
    if (egEvent.TryGetSystemEventData(out object systemEvent))
    {
        switch (systemEvent)
        {
            case SubscriptionValidationEventData subscriptionValidated:
                Console.WriteLine(subscriptionValidated.ValidationCode);
                break;
            ...
            ...
            case AcsRouterWorkerOfferIssuedEventData issuedOffer:
                Console.WriteLine($"Received offer with id: {issuedOffer.OfferId}");
                offerId = issuedOffer.OfferId;
                break;
             ...
             ...
             ...
            // Handle any other system event type
            default:
                Console.WriteLine(egEvent.EventType);
                // we can get the raw Json for the event using Data
                Console.WriteLine(egEvent.Data.ToString());
                break;
        }
    }
}
```

However, we could also wait a few seconds and then query the worker directly against the JobRouter API to see if an offer was issued to it.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_QueryWorker_Async
var result = await routerClient.GetWorkerAsync(worker.Value.Id);
foreach (var offer in result.Value.Offers)
{
    Console.WriteLine($"Worker {worker.Value.Id} has an active offer for job {offer.JobId}");
}
```

## Accepting an offer

Once a worker receives an offer, it can take two possible actions: accept or decline. We are going to accept the offer.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_AcceptOffer_Async
// fetching the offer id
var jobOffer = result.Value.Offers.FirstOrDefault(x => x.JobId == job.Value.Id);

var offerId = jobOffer!.Id; // `OfferId` can be retrieved directly from consuming event from Event grid

// accepting the offer sent to `worker-1`
var acceptJobOfferResult = await routerClient.AcceptJobOfferAsync(worker.Value.Id, offerId);

Console.WriteLine($"Offer: {jobOffer.Id} sent to worker: {worker.Value.Id} has been accepted");
Console.WriteLine($"Job has been assigned to worker: {worker.Value.Id} with assignment: {acceptJobOfferResult.Value.AssignmentId}");

// verify job assignment is populated when querying job
var updatedJob = await routerClient.GetJobAsync(job.Value.Id);
Console.WriteLine($"Job assignment has been successful: {updatedJob.Value.JobStatus == RouterJobStatus.Assigned && updatedJob.Value.Assignments.ContainsKey(acceptJobOfferResult.Value.AssignmentId)}");
```

## Completing a job

Once the worker is done with the job, the worker has to mark the job as `completed`.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CompleteJob_Async
var completeJob = await routerClient.CompleteJobAsync(
    options: new CompleteJobOptions(
            jobId: job.Value.Id,
            assignmentId: acceptJobOfferResult.Value.AssignmentId)
    {
        Note = $"Job has been completed by {worker.Value.Id} at {DateTimeOffset.UtcNow}"
    });

Console.WriteLine($"Job has been successfully completed: {completeJob.GetRawResponse().Status == 200}");
```

## Closing a job

After a job has been completed, the worker can perform wrap up actions to the job before closing the job and finally releasing its capacity to accept more incoming jobs

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CloseJob_Async
var closeJob = await routerClient.CloseJobAsync(
    options: new CloseJobOptions(
        jobId: job.Value.Id,
        assignmentId: acceptJobOfferResult.Value.AssignmentId)
    {
        Note = $"Job has been closed by {worker.Value.Id} at {DateTimeOffset.UtcNow}"
    });
Console.WriteLine($"Job has been successfully closed: {closeJob.GetRawResponse().Status == 200}");

/*
// Optionally, a job can also be set up to be marked as closed in the future.
var closeJobInFuture = await routerClient.CloseJobAsync(
    jobId: job.Value.Id,
    assignmentId: acceptJobOfferResult.Value.AssignmentId,
    options: new CloseJobOptions()  // this is optional
    {
        CloseTime = DateTimeOffset.UtcNow.AddSeconds(2), // this will mark the job as closed after 2 seconds
        Note = $"Job has been marked to close in the future by {worker.Value.Id} at {DateTimeOffset.UtcNow}"
    });
Console.WriteLine($"Job has been marked to close: {closeJob.GetRawResponse().Status == 202}"); // You'll received a 202 in that case

await Task.Delay(TimeSpan.FromSeconds(2));
*/

updatedJob = await routerClient.GetJobAsync(job.Value.Id);
Console.WriteLine($"Updated job status: {updatedJob.Value.JobStatus == RouterJobStatus.Closed}");
```

<!-- LINKS -->
[subscribe_events]: https://docs.microsoft.com/azure/communication-services/how-tos/router-sdk/subscribe-events
[offer_issued_event_schema]: https://docs.microsoft.com/azure/communication-services/how-tos/router-sdk/subscribe-events#microsoftcommunicationrouterworkerofferissued
[deserialize_event_grid_event_data]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventgrid/Azure.Messaging.EventGrid#receiving-and-deserializing-events
[event_grid_event_handlers]: https://docs.microsoft.com/azure/event-grid/event-handlers
[webhook_event_grid_event_delivery]: https://docs.microsoft.com/azure/event-grid/webhook-event-delivery
