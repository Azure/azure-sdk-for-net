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
    public class CancellationScenario : RouterLiveTestBase
    {
        public CancellationScenario(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task Scenario()
        {
            RouterClient client = CreateRouterClientWithConnectionString();

            var dispositionCode = "dispositionCode";
            var note = "note";
            var channelResponse = await client.SetChannelAsync($"{IdPrefix}-channel", "test");
            var distributionPolicyResponse = await client.SetDistributionPolicyAsync($"{IdPrefix}-dist-policy", TimeSpan.FromMinutes(10), new LongestIdleMode(1, 1), "test");
            var queueResponse = await client.SetQueueAsync($"{IdPrefix}-queue", distributionPolicyResponse.Value.Id, "test");
            var createJob = await client.CreateJobAsync(channelResponse.Value.Id, queueResponse.Value.Id, 1);

            var job = await Poll(async () => await client.GetJobAsync(createJob.Value.Id),
                x => x.Value.JobStatus == JobStatus.Queued,
                TimeSpan.FromSeconds(10));
            Assert.AreEqual(JobStatus.Queued, job.Value.JobStatus);

            await client.CancelJobAsync(job.Value.Id, dispositionCode, note);

            var finalJobState = await client.GetJobAsync(createJob.Value.Id);
            Assert.AreEqual(JobStatus.Cancelled, finalJobState.Value.JobStatus);
            Assert.AreEqual(dispositionCode, finalJobState.Value.DispositionCode);
            Assert.AreEqual(note, finalJobState.Value.Notes.Values.FirstOrDefault());
        }
    }
}
