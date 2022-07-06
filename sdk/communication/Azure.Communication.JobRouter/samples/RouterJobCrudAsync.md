# Azure.Communication.JobRouter Samples - Router Job CRUD operations (async)

## Import the namespaces

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter;
```

## Create a client

Create a `RouterClient`.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient
var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
```

## Create a job

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateRouterJob_Async
// We need to create a distribution policy + queue as a pre-requisite to start creating job
// We are going to create a distribution policy with a simple longest idle distribution mode
var distributionPolicy =
    await routerClient.CreateDistributionPolicyAsync("distribution-policy-id", 5 * 60, new LongestIdleMode());

var jobQueue = await routerClient.CreateQueueAsync("job-queue-id", distributionPolicy.Value.Id);

var jobId = "router-job-id";

var job = await routerClient.CreateJobAsync(
    id: jobId,
    channelId: "general",
    queueId: jobQueue.Value.Id,
    options: new CreateJobOptions() // this is optional
    {
        Priority = 10,
        ChannelReference = "12345",
    });

Console.WriteLine($"Job has been successfully created with status: {job.Value.JobStatus}"); // "Queued"

// Alternatively, a job can also be created while specifying a classification policy
// As a pre-requisite, we would need to create a classification policy first
var classificationPolicy = await routerClient.CreateClassificationPolicyAsync("classification-policy-id",
    new CreateClassificationPolicyOptions()
    {
        QueueSelectors = new List<QueueSelectorAttachment>()
        {
            new StaticQueueSelector(new QueueSelector("Id", LabelOperator.Equal,
                new LabelValue(jobQueue.Value.Id))),
        },
        PrioritizationRule = new StaticRule(10)
    });

var jobWithCpId = "job-with-cp-id";

var jobWithCp = await routerClient.CreateJobWithClassificationPolicyAsync(
    id: jobWithCpId,
    channelId: "general",
    classificationPolicyId: classificationPolicy.Value.Id,
    options: new CreateJobWithClassificationPolicyOptions()  // this is optional
    {
        ChannelReference = "12345",
    });

Console.WriteLine($"Job has been successfully created with status: {jobWithCp.Value.JobStatus}"); // "PendingClassification"
```

## Get a job

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterJob_Async
var queriedJob = await routerClient.GetJobAsync(jobId);

Console.WriteLine($"Successfully retrieved job with id: {queriedJob.Value.Id}"); // "router-job-id"
```

## Get a job position

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterJobPosition_Async
var jobPositionDetails = await routerClient.GetInQueuePositionAsync(jobId);

Console.WriteLine($"Job position for id `{jobPositionDetails.Value.JobId}` successfully retrieved. JobPosition: {jobPositionDetails.Value.Position}");
```

## Update a job

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateRouterJob_Async
var updatedJob = await routerClient.UpdateJobAsync(
    id: jobId,
    options: new UpdateJobOptions()
    {
        // one or more job properties can be updated
        ChannelReference = "45678",
    });

Console.WriteLine($"Job has been successfully updated. Current value of channelReference: {updatedJob.Value.ChannelReference}"); // "45678"
```

## Reclassify a job

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_ReclassifyRouterJob_Async
var reclassifyJob = await routerClient.ReclassifyJobAsync(jobWithCpId);
```

## Accept a job offer

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_AcceptJobOffer_Async
// in order for the jobs to be router to a worker, we would need to create a worker with the appropriate queue and channel association
var worker = await routerClient.CreateWorkerAsync(
    id: "router-worker-id",
    totalCapacity: 100,
    options: new CreateWorkerOptions()
    {
        AvailableForOffers = true, // if a worker is not registered, no offer will be issued
        ChannelConfigurations =
            new Dictionary<string, ChannelConfiguration>()
            {
                ["general"] = new ChannelConfiguration(100),
            },
        QueueIds = new Dictionary<string, QueueAssignment>()
        {
            [jobQueue.Value.Id] = new QueueAssignment(),
        },
    });

// now that we have a registered worker, we can expect offer to be sent to the worker
// this is an asynchronous process, so we might need to wait for a while

while ((await routerClient.GetWorkerAsync(worker.Value.Id)).Value.Offers.All(offer => offer.JobId != jobId))
{
    await Task.Delay(TimeSpan.FromSeconds(1));
}

var queriedWorker = await routerClient.GetWorkerAsync(worker.Value.Id);

var issuedOffer = queriedWorker.Value.Offers.First(offer => offer.JobId == jobId);

Console.WriteLine($"Worker has been successfully issued to worker with offerId: {issuedOffer.Id} and offer expiry time: {issuedOffer.ExpiryTimeUtc}");

// now we accept the offer

var acceptedJobOffer = await routerClient.AcceptJobOfferAsync(worker.Value.Id, issuedOffer.Id);

// job has been assigned to the worker

queriedJob = await routerClient.GetJobAsync(jobId);

Console.WriteLine($"Job has been successfully assigned to worker. Current job status: {queriedJob.Value.JobStatus}"); // "Assigned"
Console.WriteLine($"Job has been successfully assigned with a worker with assignment id: {acceptedJobOffer.Value.AssignmentId}");
```

## Decline a job offer

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeclineJobOffer_Async
// A worker can also choose to decline an offer

var declineOffer = await routerClient.DeclineJobOfferAsync(worker.Value.Id, issuedOffer.Id);
```

## Complete a job

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CompleteRouterJob_Async
// Once a worker completes the job, it needs to mark the job as completed

var completedJobResult = await routerClient.CompleteJobAsync(jobId, acceptedJobOffer.Value.AssignmentId);

queriedJob = await routerClient.GetJobAsync(jobId);
Console.WriteLine($"Job has been successfully completed. Current status: {queriedJob.Value.JobStatus}"); // "Completed"
```

## Close a job

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CloseRouterJob_Async
var closeJobResult = await routerClient.CloseJobAsync(jobId, acceptedJobOffer.Value.AssignmentId);

queriedJob = await routerClient.GetJobAsync(jobId);
Console.WriteLine($"Job has been successfully closed. Current status: {queriedJob.Value.JobStatus}"); // "Closed"
```

## List jobs

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterJobs_Async
var routerJobs = routerClient.GetJobsAsync();
await foreach (var asPage in routerJobs.AsPages(pageSizeHint: 10))
{
    foreach (var _job in asPage.Values)
    {
        Console.WriteLine($"Listing router job with id: {_job.Id}");
    }
}
```

## Delete a job

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteRouterJob_Async
_ = await routerClient.DeleteJobAsync(jobId);
```
