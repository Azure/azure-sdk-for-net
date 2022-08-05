﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Samples
{
    public class Sample4_QueueLengthExceptionTriggerAsync : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public async Task QueueLengthTriggerException_SampleScenario()
        {
            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Exception_QueueLengthExceptionTrigger
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

#if !SNIPPET
            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
#endif

            // create a distribution policy (this will be referenced by both primary queue and backup queue)
            var distributionPolicyId = "distribution-policy-id";

            var distributionPolicy = await routerClient.CreateDistributionPolicyAsync(
                id: distributionPolicyId,
                offerTtlSeconds: 5 * 60,
                mode: new LongestIdleMode());

            // create backup queue
            var backupJobQueueId = "job-queue-2";

            var backupJobQueue = await routerClient.CreateQueueAsync(
                id: backupJobQueueId,
                distributionPolicyId: distributionPolicyId);

            // create exception policy with QueueLengthExceptionTrigger (set threshold to 10) with ManuallyReclassifyAction
            var exceptionPolicyId = "exception-policy-id";

            // --- define trigger
            var trigger = new QueueLengthExceptionTrigger(10);

            // --- define action
            var action = new ManualReclassifyExceptionAction(
                queueId: backupJobQueueId,
                priority: 10,
                workerSelectors: new List<WorkerSelector>()
                {
                    new WorkerSelector("ExceptionTriggered", LabelOperator.Equal, true)
                });

            var exceptionPolicy = await routerClient.CreateExceptionPolicyAsync(
                id: exceptionPolicyId,
                exceptionRules: new Dictionary<string, ExceptionRule>()
                {
                    ["QueueLengthExceptionTrigger"] = new ExceptionRule(
                        trigger: trigger,
                        actions: new Dictionary<string, ExceptionAction?>()
                        {
                            ["ManualReclassifyExceptionAction"] = action,
                        })
                });

            // create primary queue

            var activeJobQueueId = "active-job-queue";

            var activeJobQueue = await routerClient.CreateQueueAsync(
                id: activeJobQueueId,
                distributionPolicyId: distributionPolicyId,
                options: new CreateQueueOptions() { ExceptionPolicyId = exceptionPolicyId });

            // create 10 jobs to fill in primary queue

            var listOfJobs = new List<RouterJob>();
            for (int i = 0; i < 10; i++)
            {
                var jobId = $"jobId-{i}";
                var job = await routerClient.CreateJobAsync(id: jobId, channelId: "general", queueId: activeJobQueueId);
                listOfJobs.Add(job);
            }

#if !SNIPPET
            var pollingTasks = new List<Task>();

            foreach (RouterJob routerJob in listOfJobs)
            {
                pollingTasks.Add(Task.Run(async () =>
                {
                    bool condition = false;
                    var startTime = DateTimeOffset.UtcNow;
                    var maxWaitTime = TimeSpan.FromSeconds(10);
                    while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
                    {
                        var jobDto = await routerClient.GetJobAsync(routerJob.Id);
                        condition = jobDto.Value.JobStatus == JobStatus.Queued;
                        await Task.Delay(TimeSpan.FromSeconds(1));
                    }
                }));
            }

            await Task.WhenAll(pollingTasks);
#endif

            // create 11th job
            var job11Id = "jobId-11";
            var job11 = await routerClient.CreateJobAsync(id: job11Id, channelId: "general", queueId: activeJobQueueId);

#if !SNIPPET
            bool condition = false;
            var startTime = DateTimeOffset.UtcNow;
            var maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                var jobDto = await routerClient.GetJobAsync(job11.Value.Id);
                condition = jobDto.Value.JobStatus == JobStatus.Queued && jobDto.Value.QueueId == backupJobQueueId;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            // Job 11 would have triggered the exception policy action, and Job 11 would have been en-queued in backup job queue

            var queriedJob = await routerClient.GetJobAsync(job11Id);

            Console.WriteLine($"Job 11 has been en-queued in the backup queue: {queriedJob.Value.QueueId == backupJobQueueId}"); // true
            Console.WriteLine($"Job 11 has priority of 10: {queriedJob.Value.Priority == 10}"); // true
            Console.WriteLine($"Job 11 has additional label selectors from exception policy: {queriedJob.Value.RequestedWorkerSelectors.Any(ws => ws.Key == "ExceptionTriggered")}"); // true

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Exception_QueueLengthExceptionTrigger
        }
    }
}
