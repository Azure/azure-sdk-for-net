// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Samples
{
    public class Sample4_WaitTimeExceptionAsync : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public async Task WaitTimeTriggerException_SampleScenario()
        {
            JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");
            JobRouterAdministrationClient routerAdministrationClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Exception_WaitTimeTrigger
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

#if !SNIPPET
            bool condition = false;
            DateTimeOffset startTime = DateTimeOffset.UtcNow;
            TimeSpan maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                Response<RouterJob> jobDto = await routerClient.GetJobAsync(job.Value.Id);
                condition = jobDto.Value.Status == RouterJobStatus.Queued && jobDto.Value.QueueId == fallbackQueueId;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            queriedJob = await routerClient.GetJobAsync(jobId);

            Console.WriteLine($"Exception has been triggered and job has been moved to queue with id: {fallbackQueueId}"); // fallback-q-id
            Console.WriteLine($"Job priority has been raised to: {queriedJob.Value.Priority}"); // 100
            Console.WriteLine($"Job has extra requirement for workers who can handler escalation now: {queriedJob.Value.RequestedWorkerSelectors.Any(ws => ws.Key == "HandlerEscalation" && ws.LabelOperator == LabelOperator.Equal && (bool)ws.Value.Value)}"); // true

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Exception_WaitTimeTrigger
        }
    }
}
