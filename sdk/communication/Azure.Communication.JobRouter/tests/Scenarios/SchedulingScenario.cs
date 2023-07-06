// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Models;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Scenarios
{
    public class SchedulingScenario : RouterLiveTestBase
    {
        private static string ScenarioPrefix = nameof(SchedulingScenario);

        /// <inheritdoc />
        public SchedulingScenario(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task SimpleSchedulingScenario()
        {
            JobRouterClient client = CreateRouterClientWithConnectionString();
            JobRouterAdministrationClient administrationClient = CreateRouterAdministrationClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"Channel-SQ-{IdPrefix}-{ScenarioPrefix}");
            var distributionPolicyResponse = await administrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"), TimeSpan.FromMinutes(10),
                        new LongestIdleMode())
                    { Name = "Simple-Queue-Distribution" });
            var queueResponse = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                    distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                });

            var workerId1 = GenerateUniqueId($"{IdPrefix}-w1");
            var registerWorker = await client.CreateWorkerAsync(
                new CreateWorkerOptions(workerId: workerId1, totalCapacity: 1)
                {
                    QueueIds = { [queueResponse.Value.Id] = new RouterQueueAssignment() },
                    ChannelConfigurations = { [channelResponse] = new ChannelConfiguration(1) },
                    AvailableForOffers = true,
                });
            AddForCleanup(new Task(async () => await client.UpdateWorkerAsync(new UpdateWorkerOptions(workerId1) { AvailableForOffers = false })));
            AddForCleanup(new Task(async () => await client.DeleteWorkerAsync(workerId1)));

            var jobId = GenerateUniqueId($"JobId-SQ-{ScenarioPrefix}");
            var timeToEnqueueJob = GetOrSetScheduledTimeUtc(DateTimeOffset.UtcNow.AddSeconds(10));

            var createJob = await client.CreateJobAsync(
                new CreateJobOptions(jobId, channelResponse, queueResponse.Value.Id)
                {
                    Priority = 1,
                    MatchingMode = new JobMatchingMode(new ScheduleAndSuspendMode(timeToEnqueueJob))
                });
            AddForCleanup(new Task(async () => await client.DeleteJobAsync(jobId)));

            var job = await Poll(async () => await client.GetJobAsync(createJob.Value.Id),
                x => x.Value.Status == RouterJobStatus.WaitingForActivation,
                TimeSpan.FromSeconds(30));
            Assert.AreEqual(RouterJobStatus.WaitingForActivation, job.Value.Status);
            Assert.NotNull(job.Value.ScheduledAt);
            Assert.That(job.Value.ScheduledAt, Is.EqualTo(timeToEnqueueJob).Within(30).Seconds);

            var updateJobToStartMatching =
                await client.UpdateJobAsync(new UpdateJobOptions(jobId)
                {
                    MatchingMode = new JobMatchingMode(new QueueAndMatchMode())
                });

            Assert.AreEqual(RouterJobStatus.Queued, updateJobToStartMatching.Value.Status);
            Assert.NotNull(updateJobToStartMatching.Value.ScheduledAt);
            Assert.AreEqual(JobMatchModeType.QueueAndMatchMode, updateJobToStartMatching.Value.MatchingMode.ModeType);

            var worker = await Poll(async () => await client.GetWorkerAsync(registerWorker.Value.Id),
                w => w.Value.Offers.Any(x => x.JobId == updateJobToStartMatching.Value.Id),
                TimeSpan.FromSeconds(10));
            Assert.IsTrue(worker.Value.Offers.Any(x => x.JobId == updateJobToStartMatching.Value.Id), "Offers should be sent to worker");

            var offer = worker.Value.Offers.Single(x => x.JobId == updateJobToStartMatching.Value.Id);
            Assert.AreEqual(1, offer.CapacityCost);
            Assert.IsNotNull(offer.OfferedAt);
            Assert.IsNotNull(offer.ExpiresAt);

            var accept = await client.AcceptJobOfferAsync(worker.Value.Id, offer.OfferId);
            Assert.AreEqual(createJob.Value.Id, accept.Value.JobId);
            Assert.AreEqual(worker.Value.Id, accept.Value.WorkerId);

            Assert.ThrowsAsync<RequestFailedException>(async () => await client.DeclineJobOfferAsync(
                new DeclineJobOfferOptions(worker.Value.Id, offer.OfferId) { RetryOfferAt = DateTimeOffset.MinValue }));

            var complete = await client.CompleteJobAsync(new CompleteJobOptions(createJob.Value.Id, accept.Value.AssignmentId)
            {
                Note = $"Job completed by {workerId1}"
            });
            Assert.AreEqual(200, complete.GetRawResponse().Status);

            var close = await client.CloseJobAsync(new CloseJobOptions(createJob.Value.Id, accept.Value.AssignmentId)
            {
                Note = $"Job closed by {workerId1}"
            });
            Assert.AreEqual(200, complete.GetRawResponse().Status);

            var finalJobState = await client.GetJobAsync(createJob.Value.Id);
            Assert.IsNotNull(finalJobState.Value.Assignments[accept.Value.AssignmentId].AssignedAt);
            Assert.AreEqual(worker.Value.Id, finalJobState.Value.Assignments[accept.Value.AssignmentId].WorkerId);
            Assert.IsNotNull(finalJobState.Value.Assignments[accept.Value.AssignmentId].CompletedAt);
            Assert.IsNotNull(finalJobState.Value.Assignments[accept.Value.AssignmentId].ClosedAt);
            Assert.IsNotEmpty(finalJobState.Value.Notes);
            Assert.IsTrue(finalJobState.Value.Notes.Count == 2);
            Assert.NotNull(finalJobState.Value.ScheduledAt);

            // delete worker for straggling offers if any
            await client.DeleteWorkerAsync(workerId1);
        }
    }
}
