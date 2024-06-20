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

namespace Azure.Communication.JobRouter.Tests.Scenarios
{
    public class LimitConcurrentOffersToWorkerScenario : RouterLiveTestBase
    {
        private static string ScenarioPrefix = nameof(LimitConcurrentOffersToWorkerScenario);

        /// <inheritdoc />
        public LimitConcurrentOffersToWorkerScenario(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task LimitConcurrentOfferToWorkerScenario()
        {
            JobRouterClient client = CreateRouterClientWithConnectionString();
            JobRouterAdministrationClient administrationClient = CreateRouterAdministrationClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"Channel-SQ-{IdPrefix}-{ScenarioPrefix}");
            var distributionPolicyResponse = await administrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"), TimeSpan.FromMinutes(10),
                        new LongestIdleMode())
                    { Name = "Simple-Queue-Distribution" });
            AddForCleanup(new Task(async () => await administrationClient.DeleteDistributionPolicyAsync(distributionPolicyResponse.Value.Id)));
            var queueResponse = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                    distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                });
            AddForCleanup(new Task(async () => await administrationClient.DeleteQueueAsync(queueResponse.Value.Id)));

            var workerId1 = GenerateUniqueId($"{IdPrefix}-w1");
            var registerWorker = await client.CreateWorkerAsync(
                new CreateWorkerOptions(workerId: workerId1, capacity: 10)
                {
                    Queues = { queueResponse.Value.Id, },
                    Channels = { new RouterChannel(channelResponse, 1) },
                    AvailableForOffers = true,
                    MaxConcurrentOffers = 1,
                });
            AddForCleanup(new Task(async () => await client.DeleteWorkerAsync(workerId1)));

            var jobId1 = GenerateUniqueId($"{IdPrefix}-JobId1-SQ-{ScenarioPrefix}");
            var jobId2 = GenerateUniqueId($"{IdPrefix}-JobId2-SQ-{ScenarioPrefix}");

            var createJob1 = await client.CreateJobAsync(
                new CreateJobOptions(jobId1, channelResponse, queueResponse.Value.Id)
                {
                    Priority = 1,
                });
            AddForCleanup(new Task(async () => await client.DeleteJobAsync(jobId1)));

            var createJob2 = await client.CreateJobAsync(
                new CreateJobOptions(jobId2, channelResponse, queueResponse.Value.Id)
                {
                    Priority = 1,
                });
            AddForCleanup(new Task(async () => await client.DeleteJobAsync(jobId2)));

            var queriedWorker = await Poll(async () => await client.GetWorkerAsync(workerId1),
                x => x.Value.Offers.Any(offer => offer.JobId == jobId1 || offer.JobId == jobId2),
                TimeSpan.FromSeconds(30));
            Assert.IsTrue(queriedWorker.Value.Offers.Count == 1);

            var offer1 = queriedWorker.Value.Offers.First(offer => offer.JobId == jobId1 || offer.JobId == jobId2);
            var jobWithOffer = offer1.JobId;
            var jobWithoutOffer = offer1.JobId == jobId1 ? jobId2 : jobId1;

            var acceptJob1Offer = await client.AcceptJobOfferAsync(workerId1, offer1.OfferId);

            queriedWorker = await Poll(async () => await client.GetWorkerAsync(workerId1),
                x => x.Value.Offers.Any(newOffer => newOffer.JobId == jobWithoutOffer),
                TimeSpan.FromSeconds(30));
            Assert.IsTrue(queriedWorker.Value.Offers.Count == 1);

            var offer2 = queriedWorker.Value.Offers.First(newOffer => newOffer.JobId == jobWithoutOffer);

            var acceptJob2Offer = await client.AcceptJobOfferAsync(workerId1, offer2.OfferId);

            _ = await client.CompleteJobAsync(new CompleteJobOptions(acceptJob1Offer.Value.JobId,
                acceptJob1Offer.Value.AssignmentId));

            _ = await client.CompleteJobAsync(new CompleteJobOptions(acceptJob2Offer.Value.JobId,
                acceptJob2Offer.Value.AssignmentId));

            _ = await client.CloseJobAsync(new CloseJobOptions(acceptJob1Offer.Value.JobId,
                acceptJob1Offer.Value.AssignmentId));

            _ = await client.CloseJobAsync(new CloseJobOptions(acceptJob2Offer.Value.JobId,
                acceptJob2Offer.Value.AssignmentId));
        }
    }
}
