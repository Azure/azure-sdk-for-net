# Azure.Communication.JobRouter Samples - Router Job CRUD operations (sync)

## Import the namespaces

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter;
using Azure.Communication.JobRouter.Models;
```

## Create a client

Create a `RouterClient`.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient
JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");
JobRouterAdministrationClient routerAdministrationClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");
```

## Create a job

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateRouterJob
// We need to create a distribution policy + queue as a pre-requisite to start creating job
// We are going to create a distribution policy with a simple longest idle distribution mode
Response<DistributionPolicy> distributionPolicy =
    routerAdministrationClient.CreateDistributionPolicy(new CreateDistributionPolicyOptions("distribution-policy-id", TimeSpan.FromMinutes(5), new LongestIdleMode()));

Response<Models.RouterQueue> jobQueue = routerAdministrationClient.CreateQueue(new CreateQueueOptions("job-queue-id", distributionPolicy.Value.Id));

string jobId = "router-job-id";

Response<RouterJob> job = routerClient.CreateJob(
    options: new CreateJobOptions(
        jobId: jobId,
        channelId: "general",
        queueId: jobQueue.Value.Id)
    {
        Priority = 10,
        ChannelReference = "12345",
    });

Console.WriteLine($"Job has been successfully created with status: {job.Value.Status}"); // "Queued"

// Alternatively, a job can also be created while specifying a classification policy
// As a pre-requisite, we would need to create a classification policy first
Response<ClassificationPolicy> classificationPolicy = routerAdministrationClient.CreateClassificationPolicy(
    new CreateClassificationPolicyOptions("classification-policy-id")
    {
        QueueSelectors =
        {
            new StaticQueueSelectorAttachment(new RouterQueueSelector("Id", LabelOperator.Equal,
                new LabelValue(jobQueue.Value.Id))),
        },
        PrioritizationRule = new StaticRouterRule(new LabelValue(10))
    });

string jobWithCpId = "job-with-cp-id";

Response<RouterJob> jobWithCp = routerClient.CreateJobWithClassificationPolicy(
    options: new CreateJobWithClassificationPolicyOptions(
            jobId: jobWithCpId,
            channelId: "general",
            classificationPolicyId: classificationPolicy.Value.Id)  // this is optional
    {
        ChannelReference = "12345",
    });

Console.WriteLine($"Job has been successfully created with status: {jobWithCp.Value.Status}"); // "PendingClassification"
```

## Get a job

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterJob
Response<RouterJob> queriedJob = routerClient.GetJob(jobId);

Console.WriteLine($"Successfully retrieved job with id: {queriedJob.Value.Id}"); // "router-job-id"
```

## Get a job position

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterJobPosition
Response<Models.RouterJobPositionDetails> jobPositionDetails = routerClient.GetQueuePosition(jobId);

Console.WriteLine($"Job position for id `{jobPositionDetails.Value.JobId}` successfully retrieved. JobPosition: {jobPositionDetails.Value.Position}");
```

## Update a job

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateRouterJob
Response<RouterJob> updatedJob = routerClient.UpdateJob(
    options: new UpdateJobOptions(jobId: jobId)
    {
        // one or more job properties can be updated
        ChannelReference = "45678",
    });

Console.WriteLine($"Job has been successfully updated. Current value of channelReference: {updatedJob.Value.ChannelReference}"); // "45678"
```

## Remove from job

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateJobRemoveProp
Response updatedJobWithoutChannelReference = routerClient.UpdateJob(jobId,
    RequestContent.Create(new { ChannelReference = (string?)null }));

Response<RouterJob> queriedJobWithoutChannelReference = routerClient.GetJob(jobId);

Console.WriteLine($"Job has been successfully updated. 'ChannelReference' has been removed: {string.IsNullOrWhiteSpace(queriedJobWithoutChannelReference.Value.ChannelReference)}");
```

## Reclassify a job

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_ReclassifyRouterJob
Response<ReclassifyJobResult> reclassifyJob = routerClient.ReclassifyJob(jobWithCpId);
```

## Accept a job offer

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_AcceptJobOffer
// in order for the jobs to be router to a worker, we would need to create a worker with the appropriate queue and channel association
Response<RouterWorker> worker = routerClient.CreateWorker(
    options: new CreateWorkerOptions(workerId: "router-worker-id", totalCapacity: 100)
    {
        AvailableForOffers = true, // if a worker is not registered, no offer will be issued
        ChannelConfigurations = { ["general"] = new ChannelConfiguration(100), },
        QueueIds = { [jobQueue.Value.Id] = new RouterQueueAssignment(), },
    });

// now that we have a registered worker, we can expect offer to be sent to the worker
// this is an asynchronous process, so we might need to wait for a while

while (routerClient.GetWorker(worker.Value.Id).Value.Offers.All(offer => offer.JobId != jobId))
{
    Task.Delay(TimeSpan.FromSeconds(1));
}

Response<RouterWorker> queriedWorker = routerClient.GetWorker(worker.Value.Id);

Models.RouterJobOffer? issuedOffer = queriedWorker.Value.Offers.First<RouterJobOffer>(offer => offer.JobId == jobId);

Console.WriteLine($"Worker has been successfully issued to worker with offerId: {issuedOffer.OfferId} and offer expiry time: {issuedOffer.ExpiresAt}");

// now we accept the offer

Response<AcceptJobOfferResult> acceptedJobOffer = routerClient.AcceptJobOffer(worker.Value.Id, issuedOffer.OfferId);

// job has been assigned to the worker

queriedJob = routerClient.GetJob(jobId);

Console.WriteLine($"Job has been successfully assigned to worker. Current job status: {queriedJob.Value.Status}"); // "Assigned"
Console.WriteLine($"Job has been successfully assigned with a worker with assignment id: {acceptedJobOffer.Value.AssignmentId}");
```

## Decline a job offer

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeclineJobOffer
// A worker can also choose to decline an offer

Response<DeclineJobOfferResult> declineOffer = routerClient.DeclineJobOffer(new DeclineJobOfferOptions(worker.Value.Id, issuedOffer.OfferId));
```

## Complete a job

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CompleteRouterJob
// Once a worker completes the job, it needs to mark the job as completed

Response<CompleteJobResult> completedJobResult = routerClient.CompleteJob(new CompleteJobOptions(jobId, acceptedJobOffer.Value.AssignmentId));

queriedJob = routerClient.GetJob(jobId);
Console.WriteLine($"Job has been successfully completed. Current status: {queriedJob.Value.Status}"); // "Completed"
```

## Close a job

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CloseRouterJob
Response<CloseJobResult> closeJobResult = routerClient.CloseJob(new CloseJobOptions(jobId, acceptedJobOffer.Value.AssignmentId));

queriedJob = routerClient.GetJob(jobId);
Console.WriteLine($"Job has been successfully closed. Current status: {queriedJob.Value.Status}"); // "Closed"
```

## List jobs

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterJobs
Pageable<RouterJobItem> routerJobs = routerClient.GetJobs();
foreach (Page<RouterJobItem> asPage in routerJobs.AsPages(pageSizeHint: 10))
{
    foreach (RouterJobItem? _job in asPage.Values)
    {
        Console.WriteLine($"Listing router job with id: {_job.Job.Id}");
    }
}
```

## Delete a job

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteRouterJob
_ = routerClient.DeleteJob(jobId);
```
