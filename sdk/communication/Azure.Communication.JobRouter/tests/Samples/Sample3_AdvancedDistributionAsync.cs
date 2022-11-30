// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Models;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Samples
{
    public class Sample3_AdvancedDistributionAsync : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public async Task BestWorkerDistribution_Advanced_ExpressionRule()
        {
            RouterClient routerClient = new RouterClient("<< CONNECTION STRING >>");
            RouterAdministrationClient routerAdministrationClient = new RouterAdministrationClient("<< CONNECTION STRING >>");

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_Advanced_Scoring_ExpressionRule
            // In this scenario, we are going to create a simple PowerFx expression rule to check whether a worker can handler escalation or not
            // If the worker can handler escalation then they are given a score of 100, otherwise a score of 1

            // Create distribution policy
            string distributionPolicyId = "best-worker-dp-2";
            Response<DistributionPolicy> distributionPolicy = await routerAdministrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(
                    distributionPolicyId: distributionPolicyId,
                    offerTtl: TimeSpan.FromMinutes(5),
                    mode: new BestWorkerMode(scoringRule: new ExpressionRule("If(worker.HandleEscalation = true, 100, 1)"))));

            // Create job queue
            string jobQueueId = "job-queue-id-2";
            Response<JobQueue> jobQueue = await routerAdministrationClient.CreateQueueAsync(new CreateQueueOptions(
                queueId: jobQueueId,
                distributionPolicyId: distributionPolicyId));

            string channelId = "general";

            // Create two workers
            string worker1Id = "worker-Id-1";
            string worker2Id = "worker-Id-2";

            // Worker 1 can handle escalation
            Dictionary<string, LabelValue> worker1Labels = new Dictionary<string, LabelValue>()
            {
                ["HandleEscalation"] = new LabelValue(true),
                ["IT_Support"] = new LabelValue(true)
            };

            Response<RouterWorker> worker1 = await routerClient.CreateWorkerAsync(
                options: new CreateWorkerOptions(workerId: worker1Id, totalCapacity: 10)
                {
                    AvailableForOffers = true,
                    ChannelConfigurations =
                        new Dictionary<string, ChannelConfiguration>()
                        {
                            [channelId] = new ChannelConfiguration(10),
                        },
                    Labels = worker1Labels,
                    QueueIds = new Dictionary<string, QueueAssignment>() { [jobQueueId] = new QueueAssignment(), }
                });

            // Worker 2 cannot handle escalation
            Dictionary<string, LabelValue> worker2Labels = new Dictionary<string, LabelValue>()
            {
                ["IT_Support"] = new LabelValue(true),
            };

            Response<RouterWorker> worker2 = await routerClient.CreateWorkerAsync(
                options: new CreateWorkerOptions(workerId: worker2Id, totalCapacity: 10)
                {
                    AvailableForOffers = true,
                    ChannelConfigurations =
                        new Dictionary<string, ChannelConfiguration>() { [channelId] = new ChannelConfiguration(10), },
                    Labels = worker2Labels,
                    QueueIds = new Dictionary<string, QueueAssignment>() { [jobQueueId] = new QueueAssignment(), },
                });

            // Create job
            string jobId = "job-id-2";
            Response<RouterJob> job = await routerClient.CreateJobAsync(
                options: new CreateJobOptions(jobId: jobId, channelId: channelId, queueId: jobQueueId)
                {
                    RequestedWorkerSelectors = new List<WorkerSelector>(){ new WorkerSelector("IT_Support", LabelOperator.Equal, new LabelValue(true))},
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

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_Advanced_Scoring_ExpressionRule
        }

        [Test]
        public async Task BestWorkerDistribution_Advanced_AzureFunctionRule()
        {
            RouterClient routerClient = new RouterClient("<< CONNECTION STRING >>");
            RouterAdministrationClient routerAdministrationClient = new RouterAdministrationClient("<< CONNECTION STRING >>");

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_Advanced_Scoring_AzureFunctionRule

            // Create distribution policy
            string distributionPolicyId = "best-worker-dp-1";
            Response<DistributionPolicy> distributionPolicy = await routerAdministrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(
                    distributionPolicyId: distributionPolicyId,
                    offerTtl: TimeSpan.FromMinutes(5),
                    mode: new BestWorkerMode(scoringRule: new FunctionRule(new Uri("<insert function url>")))));

            // Create job queue
            string queueId = "job-queue-id-1";
            Response<JobQueue> jobQueue = await routerAdministrationClient.CreateQueueAsync(new CreateQueueOptions(
                queueId: queueId,
                distributionPolicyId: distributionPolicyId));

            string channelId = "general";

            // Create workers

            string workerId1 = "worker-Id-1";
            Dictionary<string, LabelValue> worker1Labels = new Dictionary<string, LabelValue>()
            {
                ["HighPrioritySupport"] = new LabelValue(true),
                ["HardwareSupport"] = new LabelValue(true),
                ["Support_XBOX_SERIES_X"] = new LabelValue(true),
                ["English"] = new LabelValue(10),
                ["ChatSupport"] = new LabelValue(true),
                ["XboxSupport"] = new LabelValue(true)
            };

            Response<RouterWorker> worker1 = await routerClient.CreateWorkerAsync(
                options: new CreateWorkerOptions(workerId: workerId1, totalCapacity: 100)
                {
                    QueueIds = new Dictionary<string, QueueAssignment>() { [queueId] = new QueueAssignment(), },
                    Labels = worker1Labels,
                    ChannelConfigurations = new Dictionary<string, ChannelConfiguration>()
                    {
                        [channelId] = new ChannelConfiguration(10),
                    },
                    AvailableForOffers = true,
                });

            string workerId2 = "worker-Id-2";
            Dictionary<string, LabelValue> worker2Labels = new Dictionary<string, LabelValue>()
            {
                ["HighPrioritySupport"] = new LabelValue(true),
                ["HardwareSupport"] = new LabelValue(true),
                ["Support_XBOX_SERIES_X"] = new LabelValue(true),
                ["Support_XBOX_SERIES_S"] = new LabelValue(true),
                ["English"] = new LabelValue(8),
                ["ChatSupport"] = new LabelValue(true),
                ["XboxSupport"] = new LabelValue(true)
            };

            Response<RouterWorker> worker2 = await routerClient.CreateWorkerAsync(
                options: new CreateWorkerOptions(workerId: workerId2, totalCapacity: 100)
                {
                    QueueIds = new Dictionary<string, QueueAssignment>() { [queueId] = new QueueAssignment(), },
                    Labels = worker2Labels,
                    ChannelConfigurations = new Dictionary<string, ChannelConfiguration>()
                    {
                        [channelId] = new ChannelConfiguration(10),
                    },
                    AvailableForOffers = true,
                });

            string workerId3 = "worker-Id-3";
            Dictionary<string, LabelValue> worker3Labels = new Dictionary<string, LabelValue>()
            {
                ["HighPrioritySupport"] = new LabelValue(false),
                ["HardwareSupport"] = new LabelValue(true),
                ["Support_XBOX"] = new LabelValue(true),
                ["English"] = new LabelValue(7),
                ["ChatSupport"] = new LabelValue(true),
                ["XboxSupport"] = new LabelValue(true),
            };

            Response<RouterWorker> worker3 = await routerClient.CreateWorkerAsync(
                options: new CreateWorkerOptions(workerId: workerId3, totalCapacity: 100)
                {
                    QueueIds = new Dictionary<string, QueueAssignment>() { [queueId] = new QueueAssignment(), },
                    Labels = worker3Labels,
                    ChannelConfigurations = new Dictionary<string, ChannelConfiguration>()
                    {
                        [channelId] = new ChannelConfiguration(10),
                    },
                    AvailableForOffers = true,
                });

            // Create job
            Dictionary<string, LabelValue> jobLabels = new Dictionary<string, LabelValue>()
            {
                ["CommunicationType"] = new LabelValue("Chat"),
                ["IssueType"] = new LabelValue("XboxSupport"),
                ["Language"] = new LabelValue("en"),
                ["HighPriority"] = new LabelValue(true),
                ["SubIssueType"] = new LabelValue("ConsoleMalfunction"),
                ["ConsoleType"] = new LabelValue("XBOX_SERIES_X"),
                ["Model"] = new LabelValue("XBOX_SERIES_X_1TB")
            };

            string jobId = "job-id-1";
            List<WorkerSelector> workerSelectors = new List<WorkerSelector>()
            {
                new WorkerSelector("English", LabelOperator.GreaterThanEqual, new LabelValue(7)),
                new WorkerSelector("ChatSupport", LabelOperator.Equal, new LabelValue(true)),
                new WorkerSelector("XboxSupport", LabelOperator.Equal, new LabelValue(true))
            };

            Response<RouterJob> job = await routerClient.CreateJobAsync(
                options: new CreateJobOptions(
                    jobId: jobId,
                    channelId: channelId,
                    queueId: queueId)
                {
                    Labels = jobLabels, RequestedWorkerSelectors = workerSelectors, Priority = 100,
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

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_Advanced_Scoring_AzureFunctionRule
        }

        // TODO: batch workers
    }
}
