// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Scenarios
{
    public class AssignmentScenario : RouterLiveTestBase
    {
        public AssignmentScenario(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task Scenario()
        {
            JobRouterClient client = CreateRouterClientWithConnectionString();
            JobRouterAdministrationClient routerAdministrationClient = CreateRouterAdministrationClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"Channel-{IdPrefix}-{nameof(AssignmentScenario)}");
            var distributionPolicyId = GenerateUniqueId($"{IdPrefix}-dist-policy");
            var distributionPolicyResponse = await routerAdministrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(distributionPolicyId, TimeSpan.FromMinutes(10), new LongestIdleMode())
                {
                    Name = "test",
                });
            AddForCleanup(new Task(async () => await routerAdministrationClient.DeleteDistributionPolicyAsync(distributionPolicyId)));

            var queueId = GenerateUniqueId($"{IdPrefix}-queue");
            var queueResponse = await routerAdministrationClient.CreateQueueAsync(
                new CreateQueueOptions(queueId, distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                });
            AddForCleanup(new Task(async () => await routerAdministrationClient.DeleteQueueAsync(queueId)));

            var workerId1 = GenerateUniqueId($"{IdPrefix}-w1");
            var registerWorker = await client.CreateWorkerAsync(
                new CreateWorkerOptions(workerId: workerId1, capacity: 1)
                {
                    Queues = { queueResponse.Value.Id, },
                    Channels = { new RouterChannel(channelResponse, 1) },
                    AvailableForOffers = true,
                });
            AddForCleanup(new Task(async () => await client.UpdateWorkerAsync(new RouterWorker(workerId1) { AvailableForOffers = false })));

            var jobId = GenerateUniqueId($"{IdPrefix}-JobId-{nameof(AssignmentScenario)}");
            var createJob = await client.CreateJobAsync(
                new CreateJobOptions(jobId: jobId, channelId: channelResponse, queueId: queueResponse.Value.Id)
                {
                    Priority = 1
                });
            AddForCleanup(new Task(async () => await client.DeleteJobAsync(jobId)));

            var worker = await Poll(async () => await client.GetWorkerAsync(registerWorker.Value.Id),
                w => w.Value.Offers.Any(x => x.JobId == createJob.Value.Id),
                TimeSpan.FromSeconds(10));

            Assert.IsTrue(worker.Value.Offers.Any(x => x.JobId == createJob.Value.Id));

            var offer = worker.Value.Offers.Single(x => x.JobId == createJob.Value.Id);
            Assert.AreEqual(1, offer.CapacityCost);
            Assert.IsNotNull(offer.OfferedAt);
            Assert.IsNotNull(offer.ExpiresAt);

            var accept = await client.AcceptJobOfferAsync(worker.Value.Id, offer.OfferId);
            Assert.AreEqual(createJob.Value.Id, accept.Value.JobId);
            Assert.AreEqual(worker.Value.Id, accept.Value.WorkerId);

            Assert.ThrowsAsync<RequestFailedException>(async () =>
                await client.DeclineJobOfferAsync(
                    new DeclineJobOfferOptions(worker.Value.Id, offer.OfferId)
                    {
                        RetryOfferAt = DateTimeOffset.MinValue
                    }));

            var complete = await client.CompleteJobAsync(new CompleteJobOptions(createJob.Value.Id, accept.Value.AssignmentId)
            {
                Note = $"Job completed by {workerId1}"
            });
            Assert.AreEqual(200, complete.Status);

            var close = await client.CloseJobAsync(new CloseJobOptions(createJob.Value.Id, accept.Value.AssignmentId)
            {
                Note = $"Job closed by {workerId1}"
            });
            Assert.AreEqual(200, complete.Status);

            var finalJobState = await client.GetJobAsync(createJob.Value.Id);
            Assert.IsNotNull(finalJobState.Value.Assignments[accept.Value.AssignmentId].AssignedAt);
            Assert.AreEqual(worker.Value.Id, finalJobState.Value.Assignments[accept.Value.AssignmentId].WorkerId);
            Assert.IsNotNull(finalJobState.Value.Assignments[accept.Value.AssignmentId].CompletedAt);
            Assert.IsNotNull(finalJobState.Value.Assignments[accept.Value.AssignmentId].ClosedAt);
            Assert.IsNotEmpty(finalJobState.Value.Notes);
            Assert.IsTrue(finalJobState.Value.Notes.Count == 2);

            // in-test cleanup
            worker.Value.AvailableForOffers = false;
            await client.UpdateWorkerAsync(worker);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }
    }
}
