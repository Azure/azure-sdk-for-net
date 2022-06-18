// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
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
            RouterClient client = CreateRouterClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"Channel-{IdPrefix}-{nameof(AssignmentScenario)}");
            var distributionPolicyId = GenerateUniqueId($"{IdPrefix}-dist-policy");
            var distributionPolicyResponse = await client.CreateDistributionPolicyAsync(
                distributionPolicyId,
                10 * 60,
                new LongestIdleMode(1, 1),
                new CreateDistributionPolicyOptions()
                {
                    Name = "test",
                });
            AddForCleanup(new Task(async () => await client.DeleteDistributionPolicyAsync(distributionPolicyId)));

            var queueId = GenerateUniqueId($"{IdPrefix}-queue");
            var queueResponse = await client.CreateQueueAsync(
                queueId,
                distributionPolicyResponse.Value.Id,
                new CreateQueueOptions()
                {
                    Name = "test",
                });
            AddForCleanup(new Task(async () => await client.DeleteQueueAsync(queueId)));

            var workerId1 = GenerateUniqueId($"{IdPrefix}-w1");
            var registerWorker = await client.CreateWorkerAsync(
                id: workerId1,
                totalCapacity: 1,
                new CreateWorkerOptions()
                {
                    QueueIds = new Dictionary<string, QueueAssignment>() { [queueResponse.Value.Id] = new QueueAssignment()},
                    ChannelConfigurations = new Dictionary<string, ChannelConfiguration>
                    {
                        [channelResponse] = new ChannelConfiguration(1)
                    },
                    AvailableForOffers = true,
                });
            AddForCleanup(new Task(async () => await client.UpdateWorkerAsync(workerId1, new UpdateWorkerOptions(){ AvailableForOffers = false })));

            var jobId = GenerateUniqueId($"{IdPrefix}-JobId-{nameof(AssignmentScenario)}");
            var createJob = await client.CreateJobAsync(
                id: jobId,
                channelId: channelResponse,
                queueId: queueResponse.Value.Id,
                new CreateJobOptions()
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
            Assert.IsNotNull(offer.OfferTimeUtc);
            Assert.IsNotNull(offer.ExpiryTimeUtc);

            var accept = await client.AcceptJobOfferAsync(worker.Value.Id, offer.Id);
            Assert.AreEqual(createJob.Value.Id, accept.Value.JobId);
            Assert.AreEqual(worker.Value.Id, accept.Value.WorkerId);

            Assert.ThrowsAsync<RequestFailedException>(async () => await client.DeclineJobOfferAsync(worker.Value.Id, offer.Id));

            var complete = await client.CompleteJobAsync(createJob.Value.Id, accept.Value.AssignmentId);
            Assert.AreEqual(200, complete.GetRawResponse().Status);

            var close = await client.CloseJobAsync(createJob.Value.Id, accept.Value.AssignmentId);
            Assert.AreEqual(200, complete.GetRawResponse().Status);

            var finalJobState = await client.GetJobAsync(createJob.Value.Id);
            Assert.IsNotNull(finalJobState.Value.Assignments[accept.Value.AssignmentId].AssignTime);
            Assert.AreEqual(worker.Value.Id, finalJobState.Value.Assignments[accept.Value.AssignmentId].WorkerId);
            Assert.IsNotNull(finalJobState.Value.Assignments[accept.Value.AssignmentId].CompleteTime);
            Assert.IsNotNull(finalJobState.Value.Assignments[accept.Value.AssignmentId].CloseTime);
        }
    }
}
