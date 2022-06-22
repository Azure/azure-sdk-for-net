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
    public class Sample3_SimpleDistributionAsync : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public async Task SimpleDistribution_LongestIdle()
        {
            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_LongestIdle
            // In this scenario, we are going to demonstrate how to use the longest idle distribution mode
            // when distributing offers for job to workers
            //
            // We are going to create the following:
            // 1. A single distribution policy with distribution mode set to LongestIdle - we are going to send out only 1 concurrent offer per job
            // 2. A single queue referencing the aforementioned distribution policy
            // 3. Two workers associated with the queue, registering themselves are different timestamps
            // 4. A job created with manual queueing
            //
            // We will observe the following:-
            // Worker1 (who had registered earlier) will get the offer for the job

#if !SNIPPET
            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
#endif
            // Create distribution policy
            var distributionPolicyId = "distribution-policy-id-5";
            var distributionPolicy = await routerClient.CreateDistributionPolicyAsync(
                id: distributionPolicyId,
                offerTtlSeconds: 5 * 60,
                mode: new LongestIdleMode(),
                options: new CreateDistributionPolicyOptions() { Name = "Simple longest idle" });

            // Create queue
            var queueId = "queue-id-1";
            var jobQueue = await routerClient.CreateQueueAsync(
                id: queueId,
                distributionPolicyId: distributionPolicyId);

            // Setting up 2 identical workers
            var worker1Id = "worker-id-1";
            var worker2Id = "worker-id-2";

            var worker1 = await routerClient.CreateWorkerAsync(
                id: worker1Id,
                totalCapacity: 10,
                options: new CreateWorkerOptions()
                {
                    ChannelConfigurations =
                        new Dictionary<string, ChannelConfiguration>()
                        {
                            ["general"] = new ChannelConfiguration(10),
                        },
                    QueueIds = new Dictionary<string, QueueAssignment>() { [queueId] = new QueueAssignment(), },
                });

            var worker2 = await routerClient.CreateWorkerAsync(
                id: worker2Id,
                totalCapacity: 10,
                options: new CreateWorkerOptions()
                {
                    ChannelConfigurations =
                        new Dictionary<string, ChannelConfiguration>() { ["general"] = new ChannelConfiguration(10), },
                    QueueIds = new Dictionary<string, QueueAssignment>() { [queueId] = new QueueAssignment(), },
                });

            // Register worker1
            worker1 = await routerClient.UpdateWorkerAsync(worker1Id,
                new UpdateWorkerOptions() { AvailableForOffers = true });

            // wait for 5 seconds to simulate worker 1 has been idle longer
            await Task.Delay(TimeSpan.FromSeconds(5));

            // Register worker2
            worker2 = await routerClient.UpdateWorkerAsync(worker2Id,
                new UpdateWorkerOptions() { AvailableForOffers = true });

            // Create a job
            var jobId = "job-id-1";
            var job = await routerClient.CreateJobAsync(id: jobId, channelId: "general", queueId: queueId);

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

            // Worker1 would have got the first offer
            Console.WriteLine($"Worker 1 has successfully received offer for job: {queriedWorker1.Value.Offers.Any(offer => offer.JobId == jobId)}"); // true
            Console.WriteLine($"Worker 2 has not been issued an offer for job: {queriedWorker2.Value.Offers.Any(offer => offer.JobId == jobId)}");  // false

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_LongestIdle
        }

        [Test]
        public async Task SimpleDistribution_RoundRobin()
        {
            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_RoundRobin
            // In this scenario, we are going to demonstrate how to use the round robin distribution mode
            // when distributing offers for job to workers
            //
            // We are going to create the following:
            // 1. A single distribution policy with distribution mode set to RoundRobin - we are going to send out only 1 concurrent offer per job
            // 2. A single queue referencing the aforementioned distribution policy
            // 3. Two identical workers associated with the queue
            // 4. Two identical jobs created with manual queueing
            //
            // We will observe the following:-
            // Worker1 will get the offer for job1
            // Worker2 will get the offer for job2
#if !SNIPPET
            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
#endif
            // Create distribution policy
            var distributionPolicyId = "distribution-policy-id-6";
            var distributionPolicy = await routerClient.CreateDistributionPolicyAsync(
                id: distributionPolicyId,
                offerTtlSeconds: 5 * 60,
                mode: new RoundRobinMode(),
                options: new CreateDistributionPolicyOptions() { Name = "Simple round robin" });

            // Create queue
            var queueId = "queue-id-1";
            var jobQueue = await routerClient.CreateQueueAsync(
                id: queueId,
                distributionPolicyId: distributionPolicyId);

            // Setting up 2 identical workers
            var worker1Id = "worker-id-1";
            var worker2Id = "worker-id-2";

            var worker1 = await routerClient.CreateWorkerAsync(
                id: worker1Id,
                totalCapacity: 10,
                options: new CreateWorkerOptions()
                {
                    ChannelConfigurations =
                        new Dictionary<string, ChannelConfiguration>()
                        {
                            ["general"] = new ChannelConfiguration(5),
                        },
                    QueueIds = new Dictionary<string, QueueAssignment>() { [queueId] = new QueueAssignment(), },
                    AvailableForOffers = true,  // register worker upon creation
                });

            var worker2 = await routerClient.CreateWorkerAsync(
                id: worker2Id,
                totalCapacity: 10,
                options: new CreateWorkerOptions()
                {
                    ChannelConfigurations =
                        new Dictionary<string, ChannelConfiguration>() { ["general"] = new ChannelConfiguration(5), },
                    QueueIds = new Dictionary<string, QueueAssignment>() { [queueId] = new QueueAssignment(), },
                    AvailableForOffers = true,  // register worker upon creation
                });

            // Setting up two identical jobs
            var job1Id = "job-id-1";
            var job2Id = "job-id-2";

            var job1 = await routerClient.CreateJobAsync(id: job1Id, channelId: "general", queueId: queueId);
            var job2 = await routerClient.CreateJobAsync(id: job2Id, channelId: "general", queueId: queueId);

#if !SNIPPET
            bool condition = false;
            var startTime = DateTimeOffset.UtcNow;
            var maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                var worker1Dto = await routerClient.GetWorkerAsync(worker1Id);
                var worker2Dto = await routerClient.GetWorkerAsync(worker2Id);
                condition = worker1Dto.Value.Offers.Any(offer => offer.JobId == job1Id)
                            && worker2Dto.Value.Offers.Any(offer => offer.JobId == job2Id);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            var queriedWorker1 = await routerClient.GetWorkerAsync(worker1Id);
            var queriedWorker2 = await routerClient.GetWorkerAsync(worker2Id);

            // Worker1 would have got the first offer
            Console.WriteLine($"Worker 1 has successfully received offer for job1: {queriedWorker1.Value.Offers.Any(offer => offer.JobId == job1Id)}"); // true
            Console.WriteLine($"Worker 2 has successfully received offer for job2: {queriedWorker2.Value.Offers.Any(offer => offer.JobId == job2Id)}");  // true

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_RoundRobin
        }

        [Test]
        public async Task SimpleDistribution_DefaultBestWorker()
        {
            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_DefaultBestWorker
            // In this scenario, we are going to demonstrate how to use the default best worker distribution mode
            // when distributing offers for job to workers
            //
            // The default scoring formula uses the number of job labels that the worker
            // labels match, as well as the number of label selectors the worker labels match and/or exceed
            // using a logistic function (https://en.wikipedia.org/wiki/Logistic_function).
            //
            // A more detailed documentation can be found here:
            // https://docs.microsoft.com/azure/communication-services/concepts/router/distribution-concepts#default-label-matching
            // https://docs.microsoft.com/azure/communication-services/concepts/router/distribution-concepts#default-worker-selector-matching
            //
            // We are going to create the following:
            // 1. A single distribution policy with distribution mode set to BestWorker - we are going to send out only 1 concurrent offer per job
            // 2. A single queue referencing the aforementioned distribution policy
            // 3. Three workers associated with the queue - each with different sets of labels
            // 4. A single job created with manual queueing, with a set of labels and worker selectors
            //
            // We will observe the following:-
            // Worker1 will not get the offer for the job (complete label overlap + partial worker selector matched)
            // Worker2 will get the first offer for the job (complete label overlap + complete worker selector matched)
            // Worker3 will not get the offer for the job (partial label overlap + partial worker selector match)
#if !SNIPPET
            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
#endif
            // Create distribution policy
            var distributionPolicyId = "distribution-policy-id-7";
            var distributionPolicy = await routerClient.CreateDistributionPolicyAsync(
                id: distributionPolicyId,
                offerTtlSeconds: 5 * 60,
                mode: new BestWorkerMode(),
                options: new CreateDistributionPolicyOptions() { Name = "Default best worker mode" });

            // Create queue
            var queueId = "queue-id-1";
            var jobQueue = await routerClient.CreateQueueAsync(
                id: queueId,
                distributionPolicyId: distributionPolicyId);

            // Setting up 3 workers with different labels
            var worker1Id = "worker-id-1";
            var worker2Id = "worker-id-2";
            var worker3Id = "worker-id-3";

            var worker1 = await routerClient.CreateWorkerAsync(
                id: worker1Id,
                totalCapacity: 10,
                options: new CreateWorkerOptions()
                {
                    ChannelConfigurations =
                        new Dictionary<string, ChannelConfiguration>()
                        {
                            ["general"] = new ChannelConfiguration(10),
                        },
                    QueueIds = new Dictionary<string, QueueAssignment>() { [queueId] = new QueueAssignment(), },
                    Labels = new LabelCollection()
                    {
                        ["Location"] = "United States",
                        ["Language"] = "en-us",
                        ["Region"] = "NA",
                        ["Hardware_Support"] = true,
                        ["Hardware_Support_SurfaceLaptop"] = true,
                        ["Language_Skill_Level_EN_US"] = 10,
                    }
                });

            var worker2 = await routerClient.CreateWorkerAsync(
                id: worker2Id,
                totalCapacity: 10,
                options: new CreateWorkerOptions()
                {
                    ChannelConfigurations =
                        new Dictionary<string, ChannelConfiguration>() { ["general"] = new ChannelConfiguration(10), },
                    QueueIds = new Dictionary<string, QueueAssignment>() { [queueId] = new QueueAssignment(), },
                    Labels = new LabelCollection()
                    {
                        ["Location"] = "United States",
                        ["Language"] = "en-us",
                        ["Region"] = "NA",
                        ["Hardware_Support"] = true,
                        ["Hardware_Support_SurfaceLaptop"] = true,
                        ["Language_Skill_Level_EN_US"] = 20,
                    }
                });

            var worker3 = await routerClient.CreateWorkerAsync(
                id: worker3Id,
                totalCapacity: 10,
                options: new CreateWorkerOptions()
                {
                    ChannelConfigurations =
                        new Dictionary<string, ChannelConfiguration>() { ["general"] = new ChannelConfiguration(10), },
                    QueueIds = new Dictionary<string, QueueAssignment>() { [queueId] = new QueueAssignment(), },
                    Labels = new LabelCollection()
                    {
                        ["Location"] = "United States",
                        ["Language"] = "en-us",
                        ["Region"] = "NA",
                        ["Hardware_Support"] = true,
                        ["Hardware_Support_SurfaceLaptop"] = false,
                        ["Language_Skill_Level_EN_US"] = 1,
                    }
                });

            var jobId = "job-id-1";
            var job = await routerClient.CreateJobAsync(
                id: jobId,
                channelId: "general",
                queueId: queueId,
                options: new CreateJobOptions()
                {
                    Labels = new LabelCollection()
                    {
                        ["Location"] = "United States",
                        ["Language"] = "en-us",
                        ["Region"] = "NA",
                        ["Hardware_Support"] = true,
                        ["Hardware_Support_SurfaceLaptop"] = true,
                    },
                    RequestedWorkerSelectors = new List<WorkerSelector>()
                    {
                        new WorkerSelector("Language_Skill_Level_EN_US", LabelOperator.GreaterThanEqual, 0),
                    }
                });

#if !SNIPPET
            bool condition = false;
            var startTime = DateTimeOffset.UtcNow;
            var maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                var worker2Dto = await routerClient.GetWorkerAsync(worker2Id);
                condition = worker2Dto.Value.Offers.Any(offer => offer.JobId == jobId);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            var queriedWorker1 = await routerClient.GetWorkerAsync(worker1Id);
            var queriedWorker2 = await routerClient.GetWorkerAsync(worker2Id);
            var queriedWorker3 = await routerClient.GetWorkerAsync(worker3Id);

            // Worker1 would have got the first offer
            Console.WriteLine($"Worker 1 has not received an offer for job: {queriedWorker1.Value.Offers.All(offer => offer.JobId != jobId)}"); // true
            Console.WriteLine($"Worker 2 has successfully received offer for job: {queriedWorker2.Value.Offers.Any(offer => offer.JobId == jobId)}");  // true
            Console.WriteLine($"Worker 3 has not received an offer for job: {queriedWorker3.Value.Offers.All(offer => offer.JobId != jobId)}"); // true

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_DefaultBestWorker
        }

        [Test]
        public async Task SimpleDistribution_ConcurrentOffers_ModeAgnostic()
        {
            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_ConcurrentOffers_ModeAgnostic
            // In this scenario, we are going to demonstrate how to set up concurrent offers so that multiple workers
            // can received offers for the same job in parallel.
            //
            // We are going to create the following:
            // 1. A single distribution policy with distribution mode set to LongestIdle - we are going to send out only 2 concurrent offers per job
            // 2. A single queue referencing the aforementioned distribution policy
            // 3. Two workers associated with the queue
            // 4. A job created with manual queueing
            //
            // We will observe the following:-
            // Both Worker1 and Worker2 will get offer for the job

#if !SNIPPET
            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
#endif
            // Create distribution policy
            var distributionPolicyId = "distribution-policy-id-8";
            var distributionPolicy = await routerClient.CreateDistributionPolicyAsync(
                id: distributionPolicyId,
                offerTtlSeconds: 5 * 60,
                mode: new LongestIdleMode(minConcurrentOffers: 1, maxConcurrentOffers: 2),
                options: new CreateDistributionPolicyOptions() { Name = "Simple longest idle" });

            // Create queue
            var queueId = "queue-id-1";
            var jobQueue = await routerClient.CreateQueueAsync(
                id: queueId,
                distributionPolicyId: distributionPolicyId);

            // Setting up 2 identical workers
            var worker1Id = "worker-id-1";
            var worker2Id = "worker-id-2";

            var worker1 = await routerClient.CreateWorkerAsync(
                id: worker1Id,
                totalCapacity: 10,
                options: new CreateWorkerOptions()
                {
                    ChannelConfigurations =
                        new Dictionary<string, ChannelConfiguration>()
                        {
                            ["general"] = new ChannelConfiguration(10),
                        },
                    QueueIds = new Dictionary<string, QueueAssignment>() { [queueId] = new QueueAssignment(), },
                    AvailableForOffers = true,
                });

            var worker2 = await routerClient.CreateWorkerAsync(
                id: worker2Id,
                totalCapacity: 10,
                options: new CreateWorkerOptions()
                {
                    ChannelConfigurations =
                        new Dictionary<string, ChannelConfiguration>() { ["general"] = new ChannelConfiguration(10), },
                    QueueIds = new Dictionary<string, QueueAssignment>() { [queueId] = new QueueAssignment(), },
                    AvailableForOffers = true,
                });

            // Create a job
            var jobId = "job-id-1";
            var job = await routerClient.CreateJobAsync(id: jobId, channelId: "general", queueId: queueId);

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

            // Worker1 would have got the first offer
            Console.WriteLine($"Worker 1 has successfully received offer for job: {queriedWorker1.Value.Offers.Any(offer => offer.JobId == jobId)}"); // true
            Console.WriteLine($"Worker 2 has successfully received offer for job: {queriedWorker2.Value.Offers.Any(offer => offer.JobId == jobId)}"); // true
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_ConcurrentOffers_ModeAgnostic
        }
    }
}
