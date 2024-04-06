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
    public class Sample3_AdvancedDistributionAsync : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public async Task BestWorkerDistribution_Advanced_ExpressionRouterRule()
        {
            JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");
            JobRouterAdministrationClient routerAdministrationClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_Advanced_Scoring_ExpressionRouterRule
            // In this scenario, we are going to create a simple PowerFx expression rule to check whether a worker can handler escalation or not
            // If the worker can handler escalation then they are given a score of 100, otherwise a score of 1

            // Create distribution policy
            string distributionPolicyId = "best-worker-dp-2";
            var distributionPolicy = await routerAdministrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(
                    distributionPolicyId: distributionPolicyId,
                    offerExpiresAfter: TimeSpan.FromMinutes(5),
                    mode: new BestWorkerMode
                    {
                        ScoringRule = new ExpressionRouterRule("If(worker.HandleEscalation = true, 100, 1)")
                    }));

            // Create job queue
            string jobQueueId = "job-queue-id-2";
            Response<RouterQueue> jobQueue = await routerAdministrationClient.CreateQueueAsync(new CreateQueueOptions(
                queueId: jobQueueId,
                distributionPolicyId: distributionPolicyId));

            string channelId = "general";

            // Create two workers
            string worker1Id = "worker-Id-1";
            string worker2Id = "worker-Id-2";

            // Worker 1 can handle escalation
            Dictionary<string, RouterValue> worker1Labels = new Dictionary<string, RouterValue>()
            ;

            Response<RouterWorker> worker1 = await routerClient.CreateWorkerAsync(
                options: new CreateWorkerOptions(workerId: worker1Id, capacity: 10)
                {
                    AvailableForOffers = true,
                    Channels = { new RouterChannel(channelId, 10), },
                    Labels = { ["HandleEscalation"] = new RouterValue(true), ["IT_Support"] = new RouterValue(true) },
                    Queues = { jobQueueId }
                });

            // Worker 2 cannot handle escalation
            Response<RouterWorker> worker2 = await routerClient.CreateWorkerAsync(
                options: new CreateWorkerOptions(workerId: worker2Id, capacity: 10)
                {
                    AvailableForOffers = true,
                    Channels = { new RouterChannel(channelId, 10), },
                    Labels = { ["IT_Support"] = new RouterValue(true), },
                    Queues = { jobQueueId },
                });

            // Create job
            string jobId = "job-id-2";
            Response<RouterJob> job = await routerClient.CreateJobAsync(
                options: new CreateJobOptions(jobId: jobId, channelId: channelId, queueId: jobQueueId)
                {
                    RequestedWorkerSelectors = { new RouterWorkerSelector("IT_Support", LabelOperator.Equal, new RouterValue(true))},
                    Priority = 100,
                });

#if !SNIPPET
            bool condition = false;
            DateTimeOffset startTime = DateTimeOffset.UtcNow;
            TimeSpan maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                Response<RouterWorker> worker1Dto = await routerClient.GetWorkerAsync(worker1Id);
                condition = worker1Dto.Value.Offers.Any(offer => offer.JobId == jobId);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            Response<RouterWorker> queriedWorker1 = await routerClient.GetWorkerAsync(worker1Id);
            Response<RouterWorker> queriedWorker2 = await routerClient.GetWorkerAsync(worker2Id);

            Console.WriteLine($"Worker 1 has been offered: {queriedWorker1.Value.Offers.Any(offer => offer.JobId == jobId)}");
            Console.WriteLine($"Worker 2 has not been offered: {queriedWorker2.Value.Offers.All(offer => offer.JobId != jobId)}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_Advanced_Scoring_ExpressionRouterRule
        }

        [Test]
        public async Task BestWorkerDistribution_Advanced_AzureFunctionRouterRule()
        {
            JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");
            JobRouterAdministrationClient routerAdministrationClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_Advanced_Scoring_AzureFunctionRouterRule

            // Create distribution policy
            string distributionPolicyId = "best-worker-dp-1";
            var distributionPolicy = await routerAdministrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(
                    distributionPolicyId: distributionPolicyId,
                    offerExpiresAfter: TimeSpan.FromMinutes(5),
                    mode: new BestWorkerMode
                    {
                        ScoringRule = new FunctionRouterRule(new Uri("<insert function url>"))
                    }));

            // Create job queue
            string queueId = "job-queue-id-1";
            Response<RouterQueue> jobQueue = await routerAdministrationClient.CreateQueueAsync(new CreateQueueOptions(
                queueId: queueId,
                distributionPolicyId: distributionPolicyId));

            string channelId = "general";

            // Create workers

            string workerId1 = "worker-Id-1";
            Response<RouterWorker> worker1 = await routerClient.CreateWorkerAsync(
                options: new CreateWorkerOptions(workerId: workerId1, capacity: 100)
                {
                    Queues = { queueId },
                    Labels =
                    {
                        ["HighPrioritySupport"] = new RouterValue(true),
                        ["HardwareSupport"] = new RouterValue(true),
                        ["Support_XBOX_SERIES_X"] = new RouterValue(true),
                        ["English"] = new RouterValue(10),
                        ["ChatSupport"] = new RouterValue(true),
                        ["XboxSupport"] = new RouterValue(true)
                    },
                    Channels = { new RouterChannel(channelId, 10), },
                    AvailableForOffers = true,
                });

            string workerId2 = "worker-Id-2";

            Response<RouterWorker> worker2 = await routerClient.CreateWorkerAsync(
                options: new CreateWorkerOptions(workerId: workerId2, capacity: 100)
                {
                    Queues = { queueId },
                    Labels =
                    {
                        ["HighPrioritySupport"] = new RouterValue(true),
                        ["HardwareSupport"] = new RouterValue(true),
                        ["Support_XBOX_SERIES_X"] = new RouterValue(true),
                        ["Support_XBOX_SERIES_S"] = new RouterValue(true),
                        ["English"] = new RouterValue(8),
                        ["ChatSupport"] = new RouterValue(true),
                        ["XboxSupport"] = new RouterValue(true)
                    },
                    Channels = { new RouterChannel(channelId, 10), },
                    AvailableForOffers = true,
                });

            string workerId3 = "worker-Id-3";
            Dictionary<string, RouterValue> worker3Labels = new Dictionary<string, RouterValue>()
            ;

            Response<RouterWorker> worker3 = await routerClient.CreateWorkerAsync(
                options: new CreateWorkerOptions(workerId: workerId3, capacity: 100)
                {
                    Queues = { queueId },
                    Labels =
                    {
                        ["HighPrioritySupport"] = new RouterValue(false),
                        ["HardwareSupport"] = new RouterValue(true),
                        ["Support_XBOX"] = new RouterValue(true),
                        ["English"] = new RouterValue(7),
                        ["ChatSupport"] = new RouterValue(true),
                        ["XboxSupport"] = new RouterValue(true),
                    },
                    Channels = { new RouterChannel(channelId, 10), },
                    AvailableForOffers = true,
                });

            string jobId = "job-id-1";

            Response<RouterJob> job = await routerClient.CreateJobAsync(
                options: new CreateJobOptions(
                    jobId: jobId,
                    channelId: channelId,
                    queueId: queueId)
                {
                    Labels = {
                        ["CommunicationType"] = new RouterValue("Chat"),
                        ["IssueType"] = new RouterValue("XboxSupport"),
                        ["Language"] = new RouterValue("en"),
                        ["HighPriority"] = new RouterValue(true),
                        ["SubIssueType"] = new RouterValue("ConsoleMalfunction"),
                        ["ConsoleType"] = new RouterValue("XBOX_SERIES_X"),
                        ["Model"] = new RouterValue("XBOX_SERIES_X_1TB")
                    },
                    RequestedWorkerSelectors = {
                        new RouterWorkerSelector("English", LabelOperator.GreaterThanOrEqual, new RouterValue(7)),
                        new RouterWorkerSelector("ChatSupport", LabelOperator.Equal, new RouterValue(true)),
                        new RouterWorkerSelector("XboxSupport", LabelOperator.Equal, new RouterValue(true))
                    },
                    Priority = 100,
                });

#if !SNIPPET
            bool condition = false;
            DateTimeOffset startTime = DateTimeOffset.UtcNow;
            TimeSpan maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                Response<RouterWorker> worker1Dto = await routerClient.GetWorkerAsync(workerId1);
                Response<RouterWorker> worker2Dto = await routerClient.GetWorkerAsync(workerId2);
                condition = worker1Dto.Value.Offers.Any(offer => offer.JobId == jobId) || worker2Dto.Value.Offers.Any(offer => offer.JobId == jobId);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            Response<RouterWorker> queriedWorker1 = await routerClient.GetWorkerAsync(workerId1);
            Response<RouterWorker> queriedWorker2 = await routerClient.GetWorkerAsync(workerId2);
            Response<RouterWorker> queriedWorker3 = await routerClient.GetWorkerAsync(workerId3);

            // Since both workers, Worker_1 and Worker_2, get the same score of 200,
            // the worker who has been idle the longest will get the first offer.
            if (queriedWorker1.Value.Offers.Any(offer => offer.JobId == jobId))
            {
                Console.WriteLine($"Worker 1 has received the offer");
            }
            else if (queriedWorker2.Value.Offers.Any(offer => offer.JobId == jobId))
            {
                Console.WriteLine($"Worker 2 has received the offer");
            }

            Console.WriteLine($"Worker 3 has not received any offer: {queriedWorker3.Value.Offers.All(offer => offer.JobId != jobId)}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_Advanced_Scoring_AzureFunctionRouterRule
        }

        // TODO: batch workers
    }
}
