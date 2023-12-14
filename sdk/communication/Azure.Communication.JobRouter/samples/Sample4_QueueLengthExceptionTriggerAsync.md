# Azure.Communication.JobRouter Samples - trigger exception action using QueueLengthExceptionTrigger

## Import the namespaces

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter;
```

## Create a client

Create a `RouterClient` and send a request.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient
JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");
JobRouterAdministrationClient routerAdministrationClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");
```

## Using WaitTimeExceptionTrigger to trigger job reclassification

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Exception_QueueLengthExceptionTrigger
// In this scenario, we are going to address how to escalate / move jobs when a queue has "too many" jobs already en-queued.
// A real-world example of this would be to implement a maximum capacity on a queue
//
// We are going to use the exception policy associated with a queue to perform this task.
// We are going to create an exception policy with a QueueLengthExceptionTrigger, and a ManualReclassifyExceptionAction to "transfer" the job
// to a different queue
//
// Test set up:
// 1. Create an initial queue (Q1) with the exception policy (we will set the queue capacity threshold to 10)
// 2. Create a secondary back up queue (this will be treated as a backup queue when Q1 'overflows')
// 3. Enqueue 10 jobs - in order to fill in queue's capacity
// 4. Attempt to enqueue Job11 to Q1

// create a distribution policy (this will be referenced by both primary queue and backup queue)
string distributionPolicyId = "distribution-policy-id";

Response<DistributionPolicy> distributionPolicy = await routerAdministrationClient.CreateDistributionPolicyAsync(new CreateDistributionPolicyOptions(
    distributionPolicyId: distributionPolicyId,
    offerExpiresAfter: TimeSpan.FromMinutes(5),
    mode: new LongestIdleMode()));

// create backup queue
string backupJobQueueId = "job-queue-2";

Response<RouterQueue> backupJobQueue = await routerAdministrationClient.CreateQueueAsync(new CreateQueueOptions(
    queueId: backupJobQueueId,
    distributionPolicyId: distributionPolicyId));

// create exception policy with QueueLengthExceptionTrigger (set threshold to 10) with ManuallyReclassifyAction
string exceptionPolicyId = "exception-policy-id";

// --- define trigger
QueueLengthExceptionTrigger trigger = new QueueLengthExceptionTrigger(10);

// --- define action
ManualReclassifyExceptionAction action = new ManualReclassifyExceptionAction
{
    QueueId = backupJobQueueId,
    Priority = 10,
    WorkerSelectors =
    {
        new RouterWorkerSelector("ExceptionTriggered", LabelOperator.Equal, new RouterValue(true))
    }
};

Response<ExceptionPolicy> exceptionPolicy = await routerAdministrationClient.CreateExceptionPolicyAsync(new CreateExceptionPolicyOptions(
    exceptionPolicyId: exceptionPolicyId,
    exceptionRules: new List<ExceptionRule>()
    {
        new ExceptionRule(id: "QueueLengthExceptionTrigger",
            trigger: trigger,
            actions: new List<ExceptionAction> { action })
    }));

// create primary queue

string activeJobQueueId = "active-job-queue";

Response<RouterQueue> activeJobQueue = await routerAdministrationClient.CreateQueueAsync(
    options: new CreateQueueOptions(queueId: activeJobQueueId, distributionPolicyId: distributionPolicyId) { ExceptionPolicyId = exceptionPolicyId });

// create 10 jobs to fill in primary queue

List<RouterJob> listOfJobs = new List<RouterJob>();
for (int i = 0; i < 10; i++)
{
    string jobId = $"jobId-{i}";
    Response<RouterJob> job = await routerClient.CreateJobAsync(new CreateJobOptions(jobId: jobId, channelId: "general", queueId: activeJobQueueId));
    listOfJobs.Add(job);
}


// create 11th job
string job11Id = "jobId-11";
Response<RouterJob> job11 = await routerClient.CreateJobAsync(new CreateJobOptions(jobId: job11Id, channelId: "general", queueId: activeJobQueueId));


// Job 11 would have triggered the exception policy action, and Job 11 would have been en-queued in backup job queue

Response<RouterJob> queriedJob = await routerClient.GetJobAsync(job11Id);

Console.WriteLine($"Job 11 has been en-queued in the backup queue: {queriedJob.Value.QueueId == backupJobQueueId}"); // true
Console.WriteLine($"Job 11 has priority of 10: {queriedJob.Value.Priority == 10}"); // true
Console.WriteLine($"Job 11 has additional label selectors from exception policy: {queriedJob.Value.RequestedWorkerSelectors.Any(ws => ws.Key == "ExceptionTriggered")}"); // true
```
