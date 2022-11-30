// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#region Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter;
using Azure.Communication.JobRouter.Models;
#endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Samples
{
    public class Sample1_KeyConcepts : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public void BasicScenario()
        {
            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient

            RouterClient routerClient = new RouterClient("<< CONNECTION STRING >>");
            RouterAdministrationClient routerAdministrationClient = new RouterAdministrationClient("<< CONNECTION STRING >>");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateDistributionPolicyLongestIdleTTL1D
            Response<DistributionPolicy> distributionPolicy = routerAdministrationClient.CreateDistributionPolicy(
                new CreateDistributionPolicyOptions(
                    distributionPolicyId: "distribution-policy-1",
                    offerTtl: TimeSpan.FromDays(1),
                    mode: new LongestIdleMode())
            );
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateDistributionPolicyLongestIdleTTL1D

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateQueue
            Response<JobQueue> queue = routerAdministrationClient.CreateQueue(
                new CreateQueueOptions(
                    queueId: "queue-1",
                    distributionPolicyId: distributionPolicy.Value.Id)
            );
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateQueue

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateJobDirectQAssign
            Response<RouterJob> job = routerClient.CreateJob(
                new CreateJobOptions(
                    jobId: "jobId-2",
                    channelId: "my-channel",
                    queueId: queue.Value.Id)
                {
                    ChannelReference = "12345",
                    Priority = 1,
                    RequestedWorkerSelectors = new List<WorkerSelector>
                    {
                        new WorkerSelector("Some-Skill", LabelOperator.GreaterThan, new LabelValue(10))
                    },
                });
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateJobDirectQAssign

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_RegisterWorker
            Response<RouterWorker> worker = routerClient.CreateWorker(
                new CreateWorkerOptions(
                    workerId: "worker-1",
                    totalCapacity: 1)
                {
                    QueueIds = new Dictionary<string, QueueAssignment>() { [queue.Value.Id] = new QueueAssignment() },
                    Labels = new Dictionary<string, LabelValue>()
                    {
                        ["Some-Skill"] = new LabelValue(11)
                    },
                    ChannelConfigurations = new Dictionary<string, ChannelConfiguration>()
                    {
                        ["my-channel"] = new ChannelConfiguration(1)
                    },
                    AvailableForOffers = true,
                }
            );
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_RegisterWorker

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_QueryWorker
            Response<RouterWorker> result = routerClient.GetWorker(worker.Value.Id);
            foreach (JobOffer? offer in result.Value.Offers)
            {
                Console.WriteLine($"Worker {worker.Value.Id} has an active offer for job {offer.JobId}");
            }
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_QueryWorker

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_AcceptOffer

            // fetching the offer id
            JobOffer jobOffer = result.Value.Offers.First(x => x.JobId == job.Value.Id);

            string offerId = jobOffer.Id; // `OfferId` can be retrieved directly from consuming event from Event grid

            // accepting the offer sent to `worker-1`
            Response<AcceptJobOfferResult> acceptJobOfferResult = routerClient.AcceptJobOffer(worker.Value.Id, offerId);

            Console.WriteLine($"Offer: {jobOffer.Id} sent to worker: {worker.Value.Id} has been accepted");
            Console.WriteLine($"Job has been assigned to worker: {worker.Value.Id} with assignment: {acceptJobOfferResult.Value.AssignmentId}");

            // verify job assignment is populated when querying job
            Response<RouterJob> updatedJob = routerClient.GetJob(job.Value.Id);
            Console.WriteLine($"Job assignment has been successful: {updatedJob.Value.JobStatus == RouterJobStatus.Assigned && updatedJob.Value.Assignments.ContainsKey(acceptJobOfferResult.Value.AssignmentId)}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_AcceptOffer

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CompleteJob

            Response<CompleteJobResult> completeJob = routerClient.CompleteJob(
                options: new CompleteJobOptions(
                        jobId: job.Value.Id,
                        assignmentId: acceptJobOfferResult.Value.AssignmentId)
                {
                    Note = $"Job has been completed by {worker.Value.Id} at {DateTimeOffset.UtcNow}"
                });

            Console.WriteLine($"Job has been successfully completed: {completeJob.GetRawResponse().Status == 200}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CompleteJob

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CloseJob

            Response<CloseJobResult> closeJob = routerClient.CloseJob(
                options: new CloseJobOptions(
                        jobId: job.Value.Id,
                        assignmentId: acceptJobOfferResult.Value.AssignmentId)
                {
                    Note = $"Job has been closed by {worker.Value.Id} at {DateTimeOffset.UtcNow}"
                });
            Console.WriteLine($"Job has been successfully closed: {closeJob.GetRawResponse().Status == 200}");

            updatedJob = routerClient.GetJob(job.Value.Id);
            Console.WriteLine($"Updated job status: {updatedJob.Value.JobStatus == RouterJobStatus.Closed}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CloseJob

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CloseJobInFuture

            // Optionally, a job can also be set up to be marked as closed in the future.
            var closeJobInFuture = routerClient.CloseJob(
                options: new CloseJobOptions(job.Value.Id, acceptJobOfferResult.Value.AssignmentId)
                {
                    CloseTime = DateTimeOffset.UtcNow.AddSeconds(2), // this will mark the job as closed after 2 seconds
                    Note = $"Job has been marked to close in the future by {worker.Value.Id} at {DateTimeOffset.UtcNow}"
                });
            Console.WriteLine($"Job has been marked to close: {closeJob.GetRawResponse().Status == 202}"); // You'll received a 202 in that case

            Thread.Sleep(TimeSpan.FromSeconds(2));

            updatedJob = routerClient.GetJob(job.Value.Id);
            Console.WriteLine($"Updated job status: {updatedJob.Value.JobStatus == RouterJobStatus.Closed}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CloseJobInFuture
        }
    }
}
