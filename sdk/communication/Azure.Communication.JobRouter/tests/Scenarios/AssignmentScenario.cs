// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Models;
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

            var channelResponse = await client.SetChannelAsync($"{IdPrefix}-channel", "test");
            var distributionPolicyResponse = await client.SetDistributionPolicyAsync($"{IdPrefix}-dist-policy", TimeSpan.FromMinutes(10),new LongestIdleMode(1, 1), "test");
            var queueResponse = await client.SetQueueAsync($"{IdPrefix}-queue", distributionPolicyResponse.Value.Id, "test");

            var registerWorker = await client.RegisterWorkerAsync($"{IdPrefix}-w1", 1, new string[] { queueResponse.Value.Id }, null, new List<ChannelConfiguration>
            {
                new ChannelConfiguration(channelResponse.Value.Id, 1)
            });

            var createJob = await client.CreateJobAsync(channelResponse.Value.Id, queueResponse.Value.Id, 1);

            var worker = await Poll(async () => await client.GetWorkerAsync(registerWorker.Value.Id),
                w => w.Value.Offers.Any(x => x.JobId == createJob.Value.Id),
                TimeSpan.FromSeconds(10));

            Assert.IsTrue(worker.Value.Offers.Any(x => x.JobId == createJob.Value.Id));

            var offer = worker.Value.Offers.Single(x => x.JobId == createJob.Value.Id);
            Assert.AreEqual(1, offer.CapacityCost);
            Assert.IsNotNull(offer.OfferTimeUtc);
            Assert.IsNotNull(offer.ExpiryTimeUtc);

            var accept = await client.AcceptJobAsync(worker.Value.Id, offer.Id);
            Assert.AreEqual(createJob.Value.Id, accept.Value.JobId);
            Assert.AreEqual(worker.Value.Id, accept.Value.WorkerId);

            Assert.ThrowsAsync<RequestFailedException>(async () => await client.DeclineJobAsync(worker.Value.Id, offer.Id));

            var complete = await client.CompleteJobAsync(createJob.Value.Id, accept.Value.AssignmentId);
            Assert.AreEqual(204, complete.Status);

            var close = await client.CloseJobAsync(createJob.Value.Id, accept.Value.AssignmentId);
            Assert.AreEqual(204, complete.Status);

            var finalJobState = await client.GetJobAsync(createJob.Value.Id);
            Assert.IsNotNull(finalJobState.Value.Assignments[accept.Value.AssignmentId].AssignTime);
            // TODO: uncomment after service deployment
            // Assert.AreEqual(worker.Value.Id, finalJobState.Value.Assignments[accept.Value.AssignmentId].WorkerId);
            // Assert.IsNotNull(finalJobState.Value.Assignments[accept.Value.AssignmentId].CompleteTime);
            // Assert.IsNotNull(finalJobState.Value.Assignments[accept.Value.AssignmentId].CloseTime);
        }
    }
}
