# Azure.Communication.JobRouter Samples - trigger exception action using WaitTimeExceptionTrigger

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

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Exception_WaitTimeTrigger
// In this scenario, we are going to address how to escalate jobs when it had waited in queue for a threshold period of time
//
// We are going to use the exception policy associated with a queue to perform this task.
// We are going to create an exception policy with a WaitTimeExceptionTrigger, and a ManuallyReclassifyAction to enqueue the job
// to a different queue.
//
// Test setup:
// 1. Create an initial queue (Q1)
// 2. Enqueue job to Q1
// 3. Job waits for 30 seconds before exception policy hits

// Create distribution policy
string distributionPolicyId = "distribution-policy-id-9";

Response<DistributionPolicy> distributionPolicy = await routerAdministrationClient.CreateDistributionPolicyAsync(new CreateDistributionPolicyOptions(distributionPolicyId: distributionPolicyId,
    offerExpiresAfter: TimeSpan.FromSeconds(5),
    mode: new RoundRobinMode()));

// Create fallback queue
string fallbackQueueId = "fallback-q-id";
Response<RouterQueue> fallbackQueue = await routerAdministrationClient.CreateQueueAsync(new CreateQueueOptions(
    queueId: fallbackQueueId,
    distributionPolicyId: distributionPolicyId));

// Create exception policy
// define trigger
WaitTimeExceptionTrigger trigger = new WaitTimeExceptionTrigger(TimeSpan.FromSeconds(30)); // triggered after 5 minutes

// define exception action
ManualReclassifyExceptionAction action = new ManualReclassifyExceptionAction
{
    QueueId = fallbackQueueId,
    Priority = 100,
    WorkerSelectors = { new RouterWorkerSelector("HandleEscalation", LabelOperator.Equal, new RouterValue(true)) }
};

string exceptionPolicyId = "execption-policy-id";
Response<ExceptionPolicy> exceptionPolicy = await routerAdministrationClient.CreateExceptionPolicyAsync(new CreateExceptionPolicyOptions(
    exceptionPolicyId: exceptionPolicyId,
    exceptionRules: new List<ExceptionRule>()
    {
        new ExceptionRule(id: "WaitTimeTriggerExceptionRule",
            trigger: trigger,
            actions: new List<ExceptionAction> { action })
    }));

// Create initial queue
string jobQueueId = "job-queue-id";
Response<RouterQueue> jobQueue = await routerAdministrationClient.CreateQueueAsync(
    options: new CreateQueueOptions(
        queueId: jobQueueId,
        distributionPolicyId: distributionPolicyId)
    {
        ExceptionPolicyId = exceptionPolicyId,
    });

// create job
string jobId = "router-job-id";
Response<RouterJob> job = await routerClient.CreateJobAsync(new CreateJobOptions(
    jobId: jobId,
    channelId: "general",
    queueId: jobQueueId));

Response<RouterJob> queriedJob = await routerClient.GetJobAsync(jobId);

Console.WriteLine($"Job has been enqueued initially to queue with id: {jobQueueId}");

// Since there are no worker associated with the queue, no offers will be created for the job
// This can also happen when all the workers associated with the queue are busy and has no capacity

// We will wait for 30 seconds before the exception trigger kicks in
await Task.Delay(TimeSpan.FromSeconds(30));


queriedJob = await routerClient.GetJobAsync(jobId);

Console.WriteLine($"Exception has been triggered and job has been moved to queue with id: {fallbackQueueId}"); // fallback-q-id
Console.WriteLine($"Job priority has been raised to: {queriedJob.Value.Priority}"); // 100
Console.WriteLine($"Job has extra requirement for workers who can handler escalation now: {queriedJob.Value.RequestedWorkerSelectors.Any(ws => ws.Key == "HandlerEscalation" && ws.LabelOperator == LabelOperator.Equal && (bool)ws.Value.Value)}"); // true
```
