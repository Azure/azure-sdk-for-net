// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;

#region Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements_Async
using Azure.Communication.JobRouter;
#endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements_Async
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Samples
{
    public class Sample1_KeyConceptsAsync : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public async Task BasicScenario()
        {
            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient_Async

            JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");
            JobRouterAdministrationClient routerAdministrationClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateDistributionPolicyLongestIdleTTL1D_Async
            Response<DistributionPolicy> distributionPolicy = await routerAdministrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(
                    distributionPolicyId: "distribution-policy-1",
                    offerExpiresAfter: TimeSpan.FromDays(1),
                    mode: new LongestIdleMode())
            );
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateDistributionPolicyLongestIdleTTL1D_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateQueue_Async
            Response<RouterQueue> queue = await routerAdministrationClient.CreateQueueAsync(
                new CreateQueueOptions(
                    queueId: "queue-1",
                    distributionPolicyId: distributionPolicy.Value.Id)
            );
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateQueue_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateJobDirectQAssign_Async
            Response<RouterJob> job = await routerClient.CreateJobAsync(
                new CreateJobOptions(
                    jobId: "jobId-1",
                    channelId: "my-channel",
                    queueId: queue.Value.Id)
                {
                    ChannelReference = "12345",
                    Priority = 1,
                    RequestedWorkerSelectors =
                    {
                        new RouterWorkerSelector("Some-Skill", LabelOperator.GreaterThan, new RouterValue(10))
                    }
                });
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateJobDirectQAssign_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_RegisterWorker_Async

            Response<RouterWorker> worker = await routerClient.CreateWorkerAsync(
                new CreateWorkerOptions(workerId: "worker-1", capacity: 1)
                {
                    Queues = { queue.Value.Id },
                    Labels = { ["Some-Skill"] = new RouterValue(11) },
                    Channels = { new RouterChannel("my-channel", 1) },
                    AvailableForOffers = true,
                }
            );
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_RegisterWorker_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_QueryWorker_Async
            Response<RouterWorker> result = await routerClient.GetWorkerAsync(worker.Value.Id);
            foreach (RouterJobOffer? offer in result.Value.Offers)
            {
                Console.WriteLine($"Worker {worker.Value.Id} has an active offer for job {offer.JobId}");
            }
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_QueryWorker_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_AcceptOffer_Async

            // fetching the offer id
            RouterJobOffer jobOffer = result.Value.Offers.First<RouterJobOffer>(x => x.JobId == job.Value.Id);

            string offerId = jobOffer.OfferId; // `OfferId` can be retrieved directly from consuming event from Event grid

            // accepting the offer sent to `worker-1`
            Response<AcceptJobOfferResult> acceptJobOfferResult = await routerClient.AcceptJobOfferAsync(worker.Value.Id, offerId);

            Console.WriteLine($"Offer: {jobOffer.OfferId} sent to worker: {worker.Value.Id} has been accepted");
            Console.WriteLine($"Job has been assigned to worker: {worker.Value.Id} with assignment: {acceptJobOfferResult.Value.AssignmentId}");

            // verify job assignment is populated when querying job
            Response<RouterJob> updatedJob = await routerClient.GetJobAsync(job.Value.Id);
            Console.WriteLine($"Job assignment has been successful: {updatedJob.Value.Status == RouterJobStatus.Assigned && updatedJob.Value.Assignments.ContainsKey(acceptJobOfferResult.Value.AssignmentId)}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_AcceptOffer_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CompleteJob_Async

            Response completeJob = await routerClient.CompleteJobAsync(new CompleteJobOptions(job.Value.Id, acceptJobOfferResult.Value.AssignmentId)
                {
                    Note = $"Job has been completed by {worker.Value.Id} at {DateTimeOffset.UtcNow}"
                });

            Console.WriteLine($"Job has been successfully completed: {completeJob.Status == 200}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CompleteJob_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CloseJob_Async

            Response closeJob = await routerClient.CloseJobAsync(new CloseJobOptions(job.Value.Id, acceptJobOfferResult.Value.AssignmentId)
                {
                    Note = $"Job has been closed by {worker.Value.Id} at {DateTimeOffset.UtcNow}"
                });
            Console.WriteLine($"Job has been successfully closed: {closeJob.Status == 200}");

            updatedJob = await routerClient.GetJobAsync(job.Value.Id);
            Console.WriteLine($"Updated job status: {updatedJob.Value.Status == RouterJobStatus.Closed}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CloseJob_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CloseJobInFuture_Async
            // Optionally, a job can also be set up to be marked as closed in the future.
            var closeJobInFuture = await routerClient.CloseJobAsync(new CloseJobOptions(job.Value.Id, acceptJobOfferResult.Value.AssignmentId)
                {
                    CloseAt = DateTimeOffset.UtcNow.AddSeconds(2), // this will mark the job as closed after 2 seconds
                    Note = $"Job has been marked to close in the future by {worker.Value.Id} at {DateTimeOffset.UtcNow}"
                });
            Console.WriteLine($"Job has been marked to close: {closeJob.Status == 202}"); // You'll received a 202 in that case

            await Task.Delay(TimeSpan.FromSeconds(2));

            updatedJob = await routerClient.GetJobAsync(job.Value.Id);
            Console.WriteLine($"Updated job status: {updatedJob.Value.Status == RouterJobStatus.Closed}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CloseJobInFuture_Async
        }
    }
}
