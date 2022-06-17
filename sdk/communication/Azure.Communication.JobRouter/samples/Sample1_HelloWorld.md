# Azure.Communication.JobRouter Samples - Hello World (sync)

## Import the namespaces

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter;
```

## Create a client

Create a `RouterClient`.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient
var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
```

## Create a Distribution Policy

Use `RouterClient` to create a [Distribution Policy](https://docs.microsoft.com/azure/communication-services/concepts/router/concepts#distribution-policy) to control how jobs are to be distributed to workers with associated queue.

For this example, we are going to create a __Longest Idle__ policy with an offer TTL set to 1 day.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateDistributionPolicyLongestIdleTTL1D
var distributionPolicy = routerClient.CreateDistributionPolicy(
    id: "distribution-policy-1",
    offerTtlSeconds: 24 * 60 * 60,
    mode: new LongestIdleMode()
);
```

## Create a Queue

Use `RouterClient` to create a [Queue](https://docs.microsoft.com/azure/communication-services/concepts/router/concepts#queue).

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateQueue
var queue = routerClient.CreateQueue(
    id: "queue-1",
    distributionPolicyId: distributionPolicy.Value.Id
);
```

## Create a Job

Now, we can submit a [Job](https://docs.microsoft.com/azure/communication-services/concepts/router/concepts#job) directly to that queue, with a worker selector the requires the worker to have the label `Some-Skill` greater than 10.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateJobDirectQAssign
var job = routerClient.CreateJob(
    id: "jobId-2",
    channelId: "my-channel",
    queueId: queue.Value.Id,
    new CreateJobOptions()
    {
        ChannelReference = "12345",
        Priority = 1,
        RequestedWorkerSelectors = new List<WorkerSelector>
        {
            new WorkerSelector("Some-Skill", LabelOperator.GreaterThan, 10)
        },
    });
```

## Register a Worker

Register a worker associated with the queue that was just created. We will assign labels to the worker to include all relevant information for example, skills, which will be used to determine whether a job can be offered to a worker or not.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_RegisterWorker
var worker = routerClient.CreateWorker(
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

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_QueryWorker
var result = routerClient.GetWorker(worker.Value.Id);
foreach (var offer in result.Value.Offers)
{
    Console.WriteLine($"Worker {worker.Value.Id} has an active offer for job {offer.JobId}");
}
```

## Accepting an offer

Once a worker receives an offer, it can take two possible actions: accept or decline. We are going to accept the offer.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_AcceptOffer
// fetching the offer id
var jobOffer = result.Value.Offers.FirstOrDefault(x => x.JobId == job.Value.Id);

// accepting the offer sent to `worker-1`
var acceptJobOfferResult = routerClient.AcceptJobOffer(worker.Value.Id, jobOffer.Id);

Console.WriteLine($"Offer: {jobOffer.Id} sent to worker: {worker.Value.Id} has been accepted");
Console.WriteLine($"Job has been assigned to worker: {worker.Value.Id} with assignment: {acceptJobOfferResult.Value.AssignmentId}");

// verify job assignment is populated when querying job
var updatedJob = routerClient.GetJob(job.Value.Id);
Console.WriteLine($"Job assignment has been successful: {updatedJob.Value.JobStatus == JobStatus.Assigned && updatedJob.Value.Assignments.ContainsKey(acceptJobOfferResult.Value.AssignmentId)}");
```

## Completing a job

Once the worker is done with the job, the worker has to mark the job as `completed`.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CompleteJob
var completeJob = routerClient.CompleteJob(
    jobId: job.Value.Id,
    assignmentId: acceptJobOfferResult.Value.AssignmentId,
    options: new CompleteJobOptions() // this is optional
    {
        Note = $"Job has been completed by {worker.Value.Id} at {DateTimeOffset.UtcNow}"
    });

Console.WriteLine($"Job has been successfully completed: {completeJob.GetRawResponse().Status == 200}");
```

## Closing a job

After a job has been completed, the worker can perform wrap up actions to the job before closing the job and finally releasing its capacity to accept more incoming jobs

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CloseJob
var closeJob = routerClient.CloseJob(
    jobId: job.Value.Id,
    assignmentId: acceptJobOfferResult.Value.AssignmentId,
    options: new CloseJobOptions()  // this is optional
    {
        Note = $"Job has been closed by {worker.Value.Id} at {DateTimeOffset.UtcNow}"
    });
Console.WriteLine($"Job has been successfully closed: {closeJob.GetRawResponse().Status == 200}");

/*
// Optionally, a job can also be set up to be marked as closed in the future.
var closeJobInFuture = routerClient.CloseJob(
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

updatedJob = routerClient.GetJob(job.Value.Id);
Console.WriteLine($"Updated job status: {updatedJob.Value.JobStatus == JobStatus.Closed}");
```
