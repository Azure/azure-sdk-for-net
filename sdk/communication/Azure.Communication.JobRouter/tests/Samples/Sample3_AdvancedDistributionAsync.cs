// Copyright (c) Microsoft Corporation. All rights reserved.
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
    public class Sample3_AdvancedDistributionAsync : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public async Task BestWorkerDistribution_Advanced_ExpressionRule()
        {
            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_Advanced_Scoring_ExpressionRule
            // In this scenario, we are going to create a simple PowerFx expression rule to check whether a worker can handler escalation or not
            // If the worker can handler escalation then they are given a score of 100, otherwise a score of 1
#if !SNIPPET
            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
#endif
            // Create distribution policy
            var distributionPolicyId = "best-worker-dp-2";
            var distributionPolicy = await routerClient.CreateDistributionPolicyAsync(
                id: distributionPolicyId,
                offerTtlSeconds: 5 * 60,
                mode: new BestWorkerMode(scoringRule: new ExpressionRule("If(worker.HandleEscalation = true, 100, 1)")));

            // Create job queue
            var jobQueueId = "job-queue-id-2";
            var jobQueue = await routerClient.CreateQueueAsync(
                id: jobQueueId,
                distributionPolicyId: distributionPolicyId);

            var channelId = "general";

            // Create two workers
            var worker1Id = "worker-Id-1";
            var worker2Id = "worker-Id-2";

            // Worker 1 can handle escalation
            var worker1Labels = new LabelCollection() { ["HandleEscalation"] = true, ["IT_Support"] = true };

            var worker1 = await routerClient.CreateWorkerAsync(
                id: worker1Id,
                totalCapacity: 10,
                options: new CreateWorkerOptions()
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
            var worker2Labels = new LabelCollection() { ["IT_Support"] = true, };

            var worker2 = await routerClient.CreateWorkerAsync(
                id: worker2Id,
                totalCapacity: 10,
                options: new CreateWorkerOptions()
                {
                    AvailableForOffers = true,
                    ChannelConfigurations =
                        new Dictionary<string, ChannelConfiguration>() { [channelId] = new ChannelConfiguration(10), },
                    Labels = worker2Labels,
                    QueueIds = new Dictionary<string, QueueAssignment>() { [jobQueueId] = new QueueAssignment(), },
                });

            // Create job
            var jobId = "job-id-2";
            var job = await routerClient.CreateJobAsync(
                id: jobId,
                channelId: channelId,
                queueId: jobQueueId,
                options: new CreateJobOptions()
                {
                    RequestedWorkerSelectors = new List<WorkerSelector>(){ new WorkerSelector("IT_Support", LabelOperator.Equal, true)},
                    Priority = 100,
                });

#if !SNIPPET
            bool condition = false;
            var startTime = DateTimeOffset.UtcNow;
            var maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                var worker1Dto = await routerClient.GetWorkerAsync(worker1Id);
                condition = worker1Dto.Value.Offers.Any(offer => offer.JobId == jobId);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            var queriedWorker1 = await routerClient.GetWorkerAsync(worker1Id);
            var queriedWorker2 = await routerClient.GetWorkerAsync(worker2Id);

            Console.WriteLine($"Worker 1 has been offered: {queriedWorker1.Value.Offers.Any(offer => offer.JobId == jobId)}");
            Console.WriteLine($"Worker 2 has not been offered: {queriedWorker2.Value.Offers.All(offer => offer.JobId != jobId)}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_Advanced_Scoring_ExpressionRule
        }

        [Test]
        public async Task BestWorkerDistribution_Advanced_AzureFunctionRule()
        {
            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_Advanced_Scoring_AzureFunctionRule
#if !SNIPPET
            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
#endif

            // Create distribution policy
            var distributionPolicyId = "best-worker-dp-1";
            var distributionPolicy = await routerClient.CreateDistributionPolicyAsync(
                id: distributionPolicyId,
                offerTtlSeconds: 5 * 60,
                mode: new BestWorkerMode(scoringRule: new AzureFunctionRule("<insert function url>")));

            // Create job queue
            var queueId = "job-queue-id-1";
            var jobQueue = await routerClient.CreateQueueAsync(
                id: queueId,
                distributionPolicyId: distributionPolicyId);

            var channelId = "general";

            // Create workers

            var workerId1 = "worker-Id-1";
            var worker1Labels = new LabelCollection()
            {
                ["HighPrioritySupport"] = true,
                ["HardwareSupport"] = true,
                ["Support_XBOX_SERIES_X"] = true,
                ["English"] = 10,
                ["ChatSupport"] = true,
                ["XboxSupport"] = true
            };

            var worker1 = await routerClient.CreateWorkerAsync(
                id: workerId1,
                totalCapacity: 100,
                options: new CreateWorkerOptions()
                {
                    QueueIds = new Dictionary<string, QueueAssignment>() { [queueId] = new QueueAssignment(), },
                    Labels = worker1Labels,
                    ChannelConfigurations = new Dictionary<string, ChannelConfiguration>()
                    {
                        [channelId] = new ChannelConfiguration(10),
                    },
                    AvailableForOffers = true,
                });

            var workerId2 = "worker-Id-2";
            var worker2Labels = new LabelCollection()
            {
                ["HighPrioritySupport"] = true,
                ["HardwareSupport"] = true,
                ["Support_XBOX_SERIES_X"] = true,
                ["Support_XBOX_SERIES_S"] = true,
                ["English"] = 8,
                ["ChatSupport"] = true,
                ["XboxSupport"] = true
            };

            var worker2 = await routerClient.CreateWorkerAsync(
                id: workerId2,
                totalCapacity: 100,
                options: new CreateWorkerOptions()
                {
                    QueueIds = new Dictionary<string, QueueAssignment>() { [queueId] = new QueueAssignment(), },
                    Labels = worker2Labels,
                    ChannelConfigurations = new Dictionary<string, ChannelConfiguration>()
                    {
                        [channelId] = new ChannelConfiguration(10),
                    },
                    AvailableForOffers = true,
                });

            var workerId3 = "worker-Id-3";
            var worker3Labels = new LabelCollection()
            {
                ["HighPrioritySupport"] = false,
                ["HardwareSupport"] = true,
                ["Support_XBOX"] = true,
                ["English"] = 7,
                ["ChatSupport"] = true,
                ["XboxSupport"] = true
            };

            var worker3 = await routerClient.CreateWorkerAsync(
                id: workerId3,
                totalCapacity: 100,
                options: new CreateWorkerOptions()
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
            var jobLabels = new LabelCollection()
            {
                ["CommunicationType"] = "Chat",
                ["IssueType"] = "XboxSupport",
                ["Language"] = "en",
                ["HighPriority"] = true,
                ["SubIssueType"] = "ConsoleMalfunction",
                ["ConsoleType"] = "XBOX_SERIES_X",
                ["Model"] = "XBOX_SERIES_X_1TB"
            };

            var jobId = "job-id-1";
            var workerSelectors = new List<WorkerSelector>()
            {
                new WorkerSelector("English", LabelOperator.GreaterThanEqual, 7),
                new WorkerSelector("ChatSupport", LabelOperator.Equal, true),
                new WorkerSelector("XboxSupport", LabelOperator.Equal, true)
            };

            var job = await routerClient.CreateJobAsync(
                id: jobId,
                channelId: channelId,
                queueId: queueId,
                options: new CreateJobOptions()
                {
                    Labels = jobLabels, RequestedWorkerSelectors = workerSelectors, Priority = 100,
                });

#if !SNIPPET
            bool condition = false;
            var startTime = DateTimeOffset.UtcNow;
            var maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                var worker1Dto = await routerClient.GetWorkerAsync(workerId1);
                var worker2Dto = await routerClient.GetWorkerAsync(workerId2);
                condition = worker1Dto.Value.Offers.Any(offer => offer.JobId == jobId) || worker2Dto.Value.Offers.Any(offer => offer.JobId == jobId);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            var queriedWorker1 = await routerClient.GetWorkerAsync(workerId1);
            var queriedWorker2 = await routerClient.GetWorkerAsync(workerId2);
            var queriedWorker3 = await routerClient.GetWorkerAsync(workerId3);

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
