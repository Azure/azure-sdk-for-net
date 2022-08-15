// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Models;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Samples
{
    public class RouterJobCrudOpsAsync : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public async Task RouterCrudOps()
        {
            // create a client
            RouterClient routerClient = new RouterClient("<< CONNECTION STRING >>");
            RouterAdministrationClient routerAdministrationClient = new RouterAdministrationClient("<< CONNECTION STRING >>");

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateRouterJob_Async
            // We need to create a distribution policy + queue as a pre-requisite to start creating job
            // We are going to create a distribution policy with a simple longest idle distribution mode
            Response<DistributionPolicy> distributionPolicy =
                await routerAdministrationClient.CreateDistributionPolicyAsync(new CreateDistributionPolicyOptions(
                    "distribution-policy-id", TimeSpan.FromMinutes(5), new LongestIdleMode()));

            Response<JobQueue> jobQueue = await routerAdministrationClient.CreateQueueAsync(new CreateQueueOptions("job-queue-id", distributionPolicy.Value.Id));

            string jobId = "router-job-id";

            Response<RouterJob> job = await routerClient.CreateJobAsync(
                options: new CreateJobOptions(
                        jobId: jobId,
                        channelId: "general",
                        queueId: jobQueue.Value.Id) // this is optional
                {
                    Priority = 10,
                    ChannelReference = "12345",
                });

            Console.WriteLine($"Job has been successfully created with status: {job.Value.JobStatus}"); // "Queued"

            // Alternatively, a job can also be created while specifying a classification policy
            // As a pre-requisite, we would need to create a classification policy first
            Response<ClassificationPolicy> classificationPolicy = await routerAdministrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions("classification-policy-id")
                {
                    QueueSelectors = new List<QueueSelectorAttachment>()
                    {
                        new StaticQueueSelectorAttachment(new QueueSelector("Id", LabelOperator.Equal,
                            new LabelValue(jobQueue.Value.Id))),
                    },
                    PrioritizationRule = new StaticRule(new LabelValue(10))
                });

            string jobWithCpId = "job-with-cp-id";

            Response<RouterJob> jobWithCp = await routerClient.CreateJobAsync(
                options: new CreateJobWithClassificationPolicyOptions(
                    jobId: jobWithCpId,
                    channelId: "general",
                    classificationPolicyId: classificationPolicy.Value.Id)
                {
                    ChannelReference = "12345",
                });

            Console.WriteLine($"Job has been successfully created with status: {jobWithCp.Value.JobStatus}"); // "PendingClassification"

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateRouterJob_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterJob_Async

            Response<RouterJob> queriedJob = await routerClient.GetJobAsync(jobId);

            Console.WriteLine($"Successfully retrieved job with id: {queriedJob.Value.Id}"); // "router-job-id"

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterJob_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterJobPosition_Async

            Response<JobPositionDetails> jobPositionDetails = await routerClient.GetQueuePositionAsync(jobId);

            Console.WriteLine($"Job position for id `{jobPositionDetails.Value.JobId}` successfully retrieved. JobPosition: {jobPositionDetails.Value.Position}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterJobPosition_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateRouterJob_Async

            Response<RouterJob> updatedJob = await routerClient.UpdateJobAsync(
                options: new UpdateJobOptions(jobId: jobId)
                {
                    // one or more job properties can be updated
                    ChannelReference = "45678",
                });

            Console.WriteLine($"Job has been successfully updated. Current value of channelReference: {updatedJob.Value.ChannelReference}"); // "45678"

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateRouterJob_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_ReclassifyRouterJob_Async

            Response<ReclassifyJobResult> reclassifyJob = await routerClient.ReclassifyJobAsync(jobWithCpId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_ReclassifyRouterJob_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_AcceptJobOffer_Async

            // in order for the jobs to be router to a worker, we would need to create a worker with the appropriate queue and channel association
            Response<RouterWorker> worker = await routerClient.CreateWorkerAsync(
                options: new CreateWorkerOptions(workerId: "router-worker-id", totalCapacity: 100)
                {
                    AvailableForOffers = true, // if a worker is not registered, no offer will be issued
                    ChannelConfigurations =
                        new Dictionary<string, ChannelConfiguration>()
                        {
                            ["general"] = new ChannelConfiguration(100),
                        },
                    QueueIds = new Dictionary<string, QueueAssignment>()
                    {
                        [jobQueue.Value.Id] = new QueueAssignment(),
                    },
                });

            // now that we have a registered worker, we can expect offer to be sent to the worker
            // this is an asynchronous process, so we might need to wait for a while

            while ((await routerClient.GetWorkerAsync(worker.Value.Id)).Value.Offers.All(offer => offer.JobId != jobId))
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            Response<RouterWorker> queriedWorker = await routerClient.GetWorkerAsync(worker.Value.Id);

            JobOffer? issuedOffer = queriedWorker.Value.Offers.First(offer => offer.JobId == jobId);

            Console.WriteLine($"Worker has been successfully issued to worker with offerId: {issuedOffer.Id} and offer expiry time: {issuedOffer.ExpiryTimeUtc}");

            // now we accept the offer

            Response<AcceptJobOfferResult> acceptedJobOffer = await routerClient.AcceptJobOfferAsync(worker.Value.Id, issuedOffer.Id);

            // job has been assigned to the worker

            queriedJob = await routerClient.GetJobAsync(jobId);

            Console.WriteLine($"Job has been successfully assigned to worker. Current job status: {queriedJob.Value.JobStatus}"); // "Assigned"
            Console.WriteLine($"Job has been successfully assigned with a worker with assignment id: {acceptedJobOffer.Value.AssignmentId}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_AcceptJobOffer_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeclineJobOffer_Async

            // A worker can also choose to decline an offer

            Response<DeclineJobOfferResult> declineOffer = await routerClient.DeclineJobOfferAsync(worker.Value.Id, issuedOffer.Id);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeclineJobOffer_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CompleteRouterJob_Async

            // Once a worker completes the job, it needs to mark the job as completed

            Response<CompleteJobResult> completedJobResult = await routerClient.CompleteJobAsync(new CompleteJobOptions(jobId, acceptedJobOffer.Value.AssignmentId));

            queriedJob = await routerClient.GetJobAsync(jobId);
            Console.WriteLine($"Job has been successfully completed. Current status: {queriedJob.Value.JobStatus}"); // "Completed"

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CompleteRouterJob_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CloseRouterJob_Async

            Response<CloseJobResult> closeJobResult = await routerClient.CloseJobAsync(new CloseJobOptions(jobId, acceptedJobOffer.Value.AssignmentId));

            queriedJob = await routerClient.GetJobAsync(jobId);
            Console.WriteLine($"Job has been successfully closed. Current status: {queriedJob.Value.JobStatus}"); // "Closed"

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CloseRouterJob_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterJobs_Async

            AsyncPageable<RouterJobItem> routerJobs = routerClient.GetJobsAsync();
            await foreach (Page<RouterJobItem> asPage in routerJobs.AsPages(pageSizeHint: 10))
            {
                foreach (RouterJobItem? _job in asPage.Values)
                {
                    Console.WriteLine($"Listing router job with id: {_job.RouterJob.Id}");
                }
            }

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterJobs_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteRouterJob_Async

            _ = await routerClient.DeleteJobAsync(jobId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteRouterJob_Async
        }
    }
}
