// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
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
                new CreateWorkerOptions(workerId: workerId1, capacity: 1)
                {
                    Queues = { queueResponse.Value.Id, },
                    Channels = { new RouterChannel(channelResponse, 1) },
                    AvailableForOffers = true,
                });
            AddForCleanup(new Task(async () => await client.DeleteWorkerAsync(workerId1)));

            var jobId = GenerateUniqueId($"{IdPrefix}-JobId-SQ-{ScenarioPrefix}");
            var timeToEnqueueJob = GetOrSetScheduledTimeUtc(DateTimeOffset.UtcNow.AddSeconds(10));

            var createJob = await client.CreateJobAsync(
                new CreateJobOptions(jobId, channelResponse, queueResponse.Value.Id)
                {
                    Priority = 1,
                    MatchingMode = new ScheduleAndSuspendMode(timeToEnqueueJob)
                });
            AddForCleanup(new Task(async () => await client.DeleteJobAsync(jobId)));

            var job = await Poll(async () => await client.GetJobAsync(createJob.Value.Id),
                x => x.Value.Status == RouterJobStatus.WaitingForActivation,
                TimeSpan.FromSeconds(30));
            Assert.That(job.Value.Status, Is.EqualTo(RouterJobStatus.WaitingForActivation));
            Assert.NotNull(job.Value.ScheduledAt);
            Assert.That(job.Value.ScheduledAt, Is.EqualTo(timeToEnqueueJob).Within(30).Seconds);

            var updateJobToStartMatching =
                await client.UpdateJobAsync(new RouterJob(jobId)
                {
                    MatchingMode = new QueueAndMatchMode()
                });

            Assert.That(updateJobToStartMatching.Value.Status, Is.EqualTo(RouterJobStatus.Queued));
            Assert.NotNull(updateJobToStartMatching.Value.ScheduledAt);
            Assert.That(updateJobToStartMatching.Value.MatchingMode.GetType(), Is.EqualTo(typeof(QueueAndMatchMode)));

            var worker = await Poll(async () => await client.GetWorkerAsync(registerWorker.Value.Id),
                w => w.Value.Offers.Any(x => x.JobId == updateJobToStartMatching.Value.Id),
                TimeSpan.FromSeconds(10));
            Assert.That(worker.Value.Offers.Any(x => x.JobId == updateJobToStartMatching.Value.Id), Is.True, "Offers should be sent to worker");

            var offer = worker.Value.Offers.Single(x => x.JobId == updateJobToStartMatching.Value.Id);
            Assert.That(offer.CapacityCost, Is.EqualTo(1));
            Assert.IsNotNull(offer.OfferedAt);
            Assert.IsNotNull(offer.ExpiresAt);

            var accept = await client.AcceptJobOfferAsync(worker.Value.Id, offer.OfferId);
            Assert.That(accept.Value.JobId, Is.EqualTo(createJob.Value.Id));
            Assert.That(accept.Value.WorkerId, Is.EqualTo(worker.Value.Id));

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
            Assert.That(complete.Status, Is.EqualTo(200));

            var close = await client.CloseJobAsync(new CloseJobOptions(createJob.Value.Id, accept.Value.AssignmentId)
            {
                Note = $"Job closed by {workerId1}"
            });
            Assert.That(complete.Status, Is.EqualTo(200));

            var finalJobState = await client.GetJobAsync(createJob.Value.Id);
            Assert.IsNotNull(finalJobState.Value.Assignments[accept.Value.AssignmentId].AssignedAt);
            Assert.That(finalJobState.Value.Assignments[accept.Value.AssignmentId].WorkerId, Is.EqualTo(worker.Value.Id));
            Assert.IsNotNull(finalJobState.Value.Assignments[accept.Value.AssignmentId].CompletedAt);
            Assert.IsNotNull(finalJobState.Value.Assignments[accept.Value.AssignmentId].ClosedAt);
            Assert.IsNotEmpty(finalJobState.Value.Notes);
            Assert.That(finalJobState.Value.Notes.Count == 2, Is.True);
            Assert.NotNull(finalJobState.Value.ScheduledAt);

            // delete worker for straggling offers if any
            await client.UpdateWorkerAsync(new RouterWorker(workerId1) { AvailableForOffers = false });
            await client.DeleteWorkerAsync(workerId1);
        }
    }
}
