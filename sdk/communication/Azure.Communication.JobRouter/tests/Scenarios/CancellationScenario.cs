// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            RouterAdministrationClient administrationClient = CreateRouterAdministrationClientWithConnectionString();

            var dispositionCode = "dispositionCode";
            var channelResponse = GenerateUniqueId($"Channel-{IdPrefix}-{nameof(CancellationScenario)}");

            var distributionPolicyId = GenerateUniqueId($"{IdPrefix}-dist-policy");
            var distributionPolicyResponse = await administrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(distributionPolicyId,
                    TimeSpan.FromMinutes(10),
                    new LongestIdleMode(1, 1))
                {
                    Name = "test",
                });
            AddForCleanup(new Task(async () => await administrationClient.DeleteDistributionPolicyAsync(distributionPolicyId)));

            var queueResponse = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions($"{IdPrefix}-queue",
                    distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                });

            var jobId = $"JobId-{IdPrefix}-{nameof(CancellationScenario)}";
            var createJob = await client.CreateJobAsync(
                new CreateJobOptions(
                    jobId: jobId,
                    channelId: channelResponse,
                    queueId: queueResponse.Value.Id)
                {
                    Priority = 1,
                });
            AddForCleanup(new Task(async () => await client.CancelJobAsync(new CancelJobOptions(jobId))));
            AddForCleanup(new Task(async () => await client.DeleteJobAsync(jobId)));

            var job = await Poll(async () => await client.GetJobAsync(createJob.Value.Id),
                x => x.Value.JobStatus == RouterJobStatus.Queued,
                TimeSpan.FromSeconds(10));
            Assert.AreEqual(RouterJobStatus.Queued, job.Value.JobStatus);

            await client.CancelJobAsync(new CancelJobOptions(job.Value.Id)
            {
                DispositionCode = dispositionCode,
            });

            var finalJobState = await client.GetJobAsync(createJob.Value.Id);
            Assert.AreEqual(RouterJobStatus.Cancelled, finalJobState.Value.JobStatus);
            Assert.AreEqual(dispositionCode, finalJobState.Value.DispositionCode);
        }
    }
}
