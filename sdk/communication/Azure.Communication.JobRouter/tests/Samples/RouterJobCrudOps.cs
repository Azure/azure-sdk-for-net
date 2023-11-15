// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Samples
{
    public class RouterJobCrudOps : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public void RouterCrudOps()
        {
            // create a client
            JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");
            JobRouterAdministrationClient routerAdministrationClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateRouterJob
            // We need to create a distribution policy + queue as a pre-requisite to start creating job
            // We are going to create a distribution policy with a simple longest idle distribution mode
            Response<DistributionPolicy> distributionPolicy =
                routerAdministrationClient.CreateDistributionPolicy(new CreateDistributionPolicyOptions("distribution-policy-id", TimeSpan.FromMinutes(5), new LongestIdleMode()));

            Response<RouterQueue> jobQueue = routerAdministrationClient.CreateQueue(new CreateQueueOptions("job-queue-id", distributionPolicy.Value.Id));

            string jobId = "router-job-id";

            Response<RouterJob> job = routerClient.CreateJob(
                options: new CreateJobOptions(
                    jobId: jobId,
                    channelId: "general",
                    queueId: jobQueue.Value.Id)
                {
                    Priority = 10,
                    ChannelReference = "12345",
                });

            Console.WriteLine($"Job has been successfully created with status: {job.Value.Status}"); // "Queued"

            // Alternatively, a job can also be created while specifying a classification policy
            // As a pre-requisite, we would need to create a classification policy first
            Response<ClassificationPolicy> classificationPolicy = routerAdministrationClient.CreateClassificationPolicy(
                new CreateClassificationPolicyOptions("classification-policy-id")
                {
                    QueueSelectorAttachments =
                    {
                        new StaticQueueSelectorAttachment(new RouterQueueSelector("Id", LabelOperator.Equal,
                            new RouterValue(jobQueue.Value.Id))),
                    },
                    PrioritizationRule = new StaticRouterRule(new RouterValue(10))
                });

            string jobWithCpId = "job-with-cp-id";

            Response<RouterJob> jobWithCp = routerClient.CreateJobWithClassificationPolicy(
                options: new CreateJobWithClassificationPolicyOptions(
                        jobId: jobWithCpId,
                        channelId: "general",
                        classificationPolicyId: classificationPolicy.Value.Id)  // this is optional
                {
                    ChannelReference = "12345",
                });

            Console.WriteLine($"Job has been successfully created with status: {jobWithCp.Value.Status}"); // "PendingClassification"

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateRouterJob

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterJob

            Response<RouterJob> queriedJob = routerClient.GetJob(jobId);

            Console.WriteLine($"Successfully retrieved job with id: {queriedJob.Value.Id}"); // "router-job-id"

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterJob

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterJobPosition

            Response<RouterJobPositionDetails> jobPositionDetails = routerClient.GetQueuePosition(jobId);

            Console.WriteLine($"Job position for id `{jobPositionDetails.Value.JobId}` successfully retrieved. JobPosition: {jobPositionDetails.Value.Position}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterJobPosition

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateRouterJob

            Response<RouterJob> updatedJob = routerClient.UpdateJob(new RouterJob(jobId)
                {
                    // one or more job properties can be updated
                    ChannelReference = "45678",
                });

            Console.WriteLine($"Job has been successfully updated. Current value of channelReference: {updatedJob.Value.ChannelReference}"); // "45678"

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateRouterJob

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_ReclassifyRouterJob

            Response reclassifyJob = routerClient.ReclassifyJob(jobWithCpId, CancellationToken.None);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_ReclassifyRouterJob

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_AcceptJobOffer

            // in order for the jobs to be router to a worker, we would need to create a worker with the appropriate queue and channel association
            Response<RouterWorker> worker = routerClient.CreateWorker(
                options: new CreateWorkerOptions(workerId: "router-worker-id", capacity: 100)
                {
                    AvailableForOffers = true, // if a worker is not registered, no offer will be issued
                    Channels = { new RouterChannel("general", 100) },
                    Queues = { jobQueue.Value.Id }
                });

            // now that we have a registered worker, we can expect offer to be sent to the worker
            // this is an asynchronous process, so we might need to wait for a while

            while (routerClient.GetWorker(worker.Value.Id).Value.Offers.All(offer => offer.JobId != jobId))
            {
                Task.Delay(TimeSpan.FromSeconds(1));
            }

            Response<RouterWorker> queriedWorker = routerClient.GetWorker(worker.Value.Id);

            RouterJobOffer? issuedOffer = queriedWorker.Value.Offers.First<RouterJobOffer>(offer => offer.JobId == jobId);

            Console.WriteLine($"Worker has been successfully issued to worker with offerId: {issuedOffer.OfferId} and offer expiry time: {issuedOffer.ExpiresAt}");

            // now we accept the offer

            Response<AcceptJobOfferResult> acceptedJobOffer = routerClient.AcceptJobOffer(worker.Value.Id, issuedOffer.OfferId);

            // job has been assigned to the worker

            queriedJob = routerClient.GetJob(jobId);

            Console.WriteLine($"Job has been successfully assigned to worker. Current job status: {queriedJob.Value.Status}"); // "Assigned"
            Console.WriteLine($"Job has been successfully assigned with a worker with assignment id: {acceptedJobOffer.Value.AssignmentId}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_AcceptJobOffer

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeclineJobOffer

            // A worker can also choose to decline an offer

            Response declineOffer = routerClient.DeclineJobOffer(new DeclineJobOfferOptions(worker.Value.Id, issuedOffer.OfferId));

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeclineJobOffer

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CompleteRouterJob

            // Once a worker completes the job, it needs to mark the job as completed

            Response completedJobResult = routerClient.CompleteJob(new CompleteJobOptions(jobId, acceptedJobOffer.Value.AssignmentId));

            queriedJob = routerClient.GetJob(jobId);
            Console.WriteLine($"Job has been successfully completed. Current status: {queriedJob.Value.Status}"); // "Completed"

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CompleteRouterJob

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CloseRouterJob

            Response closeJobResult = routerClient.CloseJob(new CloseJobOptions(jobId, acceptedJobOffer.Value.AssignmentId));

            queriedJob = routerClient.GetJob(jobId);
            Console.WriteLine($"Job has been successfully closed. Current status: {queriedJob.Value.Status}"); // "Closed"

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CloseRouterJob

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterJobs

            Pageable<RouterJob> routerJobs = routerClient.GetJobs(null, null);
            foreach (Page<RouterJob> asPage in routerJobs.AsPages(pageSizeHint: 10))
            {
                foreach (RouterJob? _job in asPage.Values)
                {
                    Console.WriteLine($"Listing router job with id: {_job.Id}");
                }
            }

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterJobs

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteRouterJob

            _ = routerClient.DeleteJob(jobId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteRouterJob
        }
    }
}
