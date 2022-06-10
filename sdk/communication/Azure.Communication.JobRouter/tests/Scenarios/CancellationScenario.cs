// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
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
            var channelResponse = GenerateUniqueId($"Channel-{IdPrefix}-{nameof(CancellationScenario)}");
            var distributionPolicyResponse = await client.CreateDistributionPolicyAsync(
                $"{IdPrefix}-dist-policy",
                10 * 60,
                new LongestIdleMode(1, 1),
                new CreateDistributionPolicyOptions()
                {
                    Name = "test",
                });
            var queueResponse = await client.CreateQueueAsync(
                $"{IdPrefix}-queue",
                distributionPolicyResponse.Value.Id,
                new CreateQueueOptions()
                {
                    Name = "test",
                });

            var jobId = $"JobId-{nameof(CancellationScenario)}";
            var createJob = await client.CreateJobAsync(
                id: jobId,
                channelId: channelResponse,
                queueId: queueResponse.Value.Id,
                new CreateJobOptions()
                {
                    Priority = 1,
                });

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
