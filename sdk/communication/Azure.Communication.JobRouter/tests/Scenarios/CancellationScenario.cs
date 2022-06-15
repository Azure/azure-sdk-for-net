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
            var channelResponse = GenerateUniqueId($"Channel-{IdPrefix}-{nameof(CancellationScenario)}");

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

            var queueResponse = await client.CreateQueueAsync(
                $"{IdPrefix}-queue",
                distributionPolicyResponse.Value.Id,
                new CreateQueueOptions()
                {
                    Name = "test",
                });

            var jobId = $"JobId-{IdPrefix}-{nameof(CancellationScenario)}";
            var createJob = await client.CreateJobAsync(
                id: jobId,
                channelId: channelResponse,
                queueId: queueResponse.Value.Id,
                new CreateJobOptions()
                {
                    Priority = 1,
                });
            AddForCleanup(new Task(async () => await client.CancelJobAsync(jobId)));
            AddForCleanup(new Task(async () => await client.DeleteJobAsync(jobId)));

            var job = await Poll(async () => await client.GetJobAsync(createJob.Value.Id),
                x => x.Value.JobStatus == JobStatus.Queued,
                TimeSpan.FromSeconds(10));
            Assert.AreEqual(JobStatus.Queued, job.Value.JobStatus);

            await client.CancelJobAsync(job.Value.Id, new CancelJobOptions()
            {
                DispositionCode = dispositionCode,
            });

            var finalJobState = await client.GetJobAsync(createJob.Value.Id);
            Assert.AreEqual(JobStatus.Cancelled, finalJobState.Value.JobStatus);
            Assert.AreEqual(dispositionCode, finalJobState.Value.DispositionCode);
        }
    }
}
