// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateDistributionPolicyLongestIdleTTL1D_Async
            var distributionPolicy = await routerClient.CreateDistributionPolicyAsync(
                id: "distribution-policy-1",
                offerTtlSeconds: 24 * 60 * 60,
                mode: new LongestIdleMode()
            );
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateDistributionPolicyLongestIdleTTL1D_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateQueue_Async
            var queue = await routerClient.CreateQueueAsync(
                id: "queue-1",
                distributionPolicyId: distributionPolicy.Value.Id
            );
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateQueue_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateJobDirectQAssign_Async
            var job = await routerClient.CreateJobAsync(
                id: "jobId-1",
                channelId: "my-channel",
                queueId: queue.Value.Id,
                new CreateJobOptions()
                {
                    ChannelReference = "12345",
                    Priority = 1,
                    RequestedWorkerSelectors = new List<WorkerSelector>
                    {
                        new WorkerSelector("Some-Skill", LabelOperator.GreaterThan, 10)
                    }
                });
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateJobDirectQAssign_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_RegisterWorker_Async
            var worker = await routerClient.CreateWorkerAsync(
                id: "worker-1",
                totalCapacity: 1,
                new CreateWorkerOptions()
                {
                    QueueIds = new[] { queue.Value.Id },
                    Labels = new LabelCollection()
                    {
                        ["Some-Skill"] = 11
                    },
                    ChannelConfigurations = new Dictionary<string, ChannelConfiguration>()
                    {
                        ["my-channel"] = new ChannelConfiguration(1)
                    },
                    AvailableForOffers = true,
                }
            );
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_RegisterWorker_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_QueryWorker_Async
            var result = await routerClient.GetWorkerAsync(worker.Value.Id);
            foreach (var offer in result.Value.Offers)
            {
                Console.WriteLine($"Worker {worker.Value.Id} has an active offer for job {offer.JobId}");
            }
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_QueryWorker_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_AcceptOffer_Async

            // fetching the offer id
            var jobOffer = result.Value.Offers.FirstOrDefault(x => x.JobId == job.Value.Id);

            // accepting the offer sent to `worker-1`
            var acceptJobOfferResult = await routerClient.AcceptJobOfferAsync(worker.Value.Id, jobOffer!.Id);

            Console.WriteLine($"Offer: {jobOffer.Id} sent to worker: {worker.Value.Id} has been accepted");
            Console.WriteLine($"Job has been assigned to worker: {worker.Value.Id} with assignment: {acceptJobOfferResult.Value.AssignmentId}");

            // verify job assignment is populated when querying job
            var updatedJob = await routerClient.GetJobAsync(job.Value.Id);
            Console.WriteLine($"Job assignment has been successful: {updatedJob.Value.JobStatus == JobStatus.Assigned && updatedJob.Value.Assignments.ContainsKey(acceptJobOfferResult.Value.AssignmentId)}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_AcceptOffer_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CompleteJob_Async

            var completeJob = await routerClient.CompleteJobAsync(
                jobId: job.Value.Id,
                assignmentId: acceptJobOfferResult.Value.AssignmentId,
                options: new CompleteJobOptions() // this is optional
                {
                    Note = $"Job has been completed by {worker.Value.Id} at {DateTimeOffset.UtcNow}"
                });

            Console.WriteLine($"Job has been successfully completed: {completeJob.GetRawResponse().Status == 200}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CompleteJob_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CloseJob_Async

            var closeJob = await routerClient.CloseJobAsync(
                jobId: job.Value.Id,
                assignmentId: acceptJobOfferResult.Value.AssignmentId,
                options: new CloseJobOptions()  // this is optional
                {
                    Note = $"Job has been closed by {worker.Value.Id} at {DateTimeOffset.UtcNow}"
                });
            Console.WriteLine($"Job has been successfully closed: {closeJob.GetRawResponse().Status == 200}");

            /*
            // Optionally, a job can also be set up to be marked as closed in the future.
            var closeJobInFuture = await routerClient.CloseJobAsync(
                jobId: job.Value.Id,
                assignmentId: acceptJobOfferResult.Value.AssignmentId,
                options: new CloseJobOptions()  // this is optional
                {
                    CloseTime = DateTimeOffset.UtcNow.AddSeconds(2), // this will mark the job as closed after 2 seconds
                    Note = $"Job has been marked to close in the future by {worker.Value.Id} at {DateTimeOffset.UtcNow}"
                });
            Console.WriteLine($"Job has been marked to close: {closeJob.GetRawResponse().Status == 202}"); // You'll received a 202 in that case

            await Task.Delay(TimeSpan.FromSeconds(2));
            */

            updatedJob = await routerClient.GetJobAsync(job.Value.Id);
            Console.WriteLine($"Updated job status: {updatedJob.Value.JobStatus == JobStatus.Closed}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CloseJob_Async
        }
    }
}
