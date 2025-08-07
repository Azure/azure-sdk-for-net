// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Samples
{
    public class Sample5_LimitConcurrentOffersToWorkers : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public async Task LimitMaxConcurrentOfferToWorkers()
        {
            JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");
            JobRouterAdministrationClient routerAdministrationClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Worker_LimitMaxConcurrentOffers
            // In this scenario, we are going to address to control the number of concurrent offers that are sent to a single worker
            //
            // We are going to create a worker which can only receive 1 offer at a time.
            // We are going to create 2 jobs which the worker would have received offers for.
            // We will observe only a single offer will be sent to the worker.
            // Subsequently, when the worker accepts the offer, a second offer will be sent for the second job.
            //
            // Test setup:
            // 1. Create queue
            // 2. Create worker associated with queue with maxConcurrentOffer set to 1
            // 3. Enqueue 2 jobs to the same queue
            // 4. Wait for worker to receive offers. Only 1 will come through (say Offer 1)
            // 5. Accept Offer 1.
            // 6. Wait for worker to receive offers. Second offer will come through

            // Create distribution policy
            string distributionPolicyId = "distribution-policy-id-10";

            Response<DistributionPolicy> distributionPolicy = await routerAdministrationClient.CreateDistributionPolicyAsync(new CreateDistributionPolicyOptions(distributionPolicyId: distributionPolicyId,
                offerExpiresAfter: TimeSpan.FromSeconds(60),
                mode: new RoundRobinMode()));

            // Create queue
            string jobQueueId = "job-queue-id";
            Response<RouterQueue> jobQueue = await routerAdministrationClient.CreateQueueAsync(
                options: new CreateQueueOptions(
                    queueId: jobQueueId,
                    distributionPolicyId: distributionPolicyId));

            // Create worker
            string routerWorkerId = "worker-id";
            Response<RouterWorker> worker = await routerClient.CreateWorkerAsync(
                new CreateWorkerOptions(workerId: routerWorkerId, capacity: 100)
                {
                    Queues = { jobQueueId },
                    Channels =
                    {
                        // Worker can take upto 100 'WebChat' jobs
                        new RouterChannel("WebChat", 1),
                    },
                    Labels =
                    {
                        ["Location"] = new RouterValue("NA"),
                        ["English"] = new RouterValue(7),
                        ["O365"] = new RouterValue(true),
                        ["Xbox_Support"] = new RouterValue(false)
                    },
                    Tags =
                    {
                        ["Name"] = new RouterValue("John Doe"),
                        ["Department"] = new RouterValue("IT_HelpDesk")
                    },
                    MaxConcurrentOffers = 1,
                }
            );

            Console.WriteLine($"Router worker successfully created with id: {worker.Value.Id}");

            // Create job 1
            string jobId1 = "router-job-id-1";
            Response<RouterJob> job1 = await routerClient.CreateJobAsync(new CreateJobOptions(
                jobId: jobId1,
                channelId: "WebChat",
                queueId: jobQueueId));

            Response<RouterJob> queriedJob1 = await routerClient.GetJobAsync(jobId1);

            Console.WriteLine($"Job 1 has been enqueued initially to queue with id: {jobQueueId}");

            // Create job 2
            string jobId2 = "router-job-id-2";
            Response<RouterJob> job2 = await routerClient.CreateJobAsync(new CreateJobOptions(
                jobId: jobId2,
                channelId: "WebChat",
                queueId: jobQueueId));

            Response<RouterJob> queriedJob = await routerClient.GetJobAsync(jobId2);

            Console.WriteLine($"Job 2 has been enqueued initially to queue with id: {jobQueueId}");

#if !SNIPPET
            bool condition = false;
            DateTimeOffset startTime = DateTimeOffset.UtcNow;
            TimeSpan maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                Response<RouterWorker> workerDto = await routerClient.GetWorkerAsync(routerWorkerId);
                condition = workerDto.HasValue &&
                            workerDto.Value.Offers.Any(offer => offer.JobId == jobId1 || offer.JobId == jobId2);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif
            Response<RouterWorker> queriedWorker = await routerClient.GetWorkerAsync(routerWorkerId);

            Console.WriteLine($"Only a single offer has been issued to worker: {queriedWorker.Value.Offers.Count == 1}");
            string jobWithOffer = queriedWorker.Value.Offers.First().JobId;
            string jobWithNoOffer = jobWithOffer == jobId1 ? jobId2 : jobId1;
            Console.WriteLine($"Worker has received offer for jobId: {jobWithOffer}");

            // Worker accepts offer
            RouterJobOffer jobOffer = queriedWorker.Value.Offers.First(offer => offer.JobId == jobWithOffer);
            string offerId = jobOffer.OfferId;
            Response<AcceptJobOfferResult> acceptJobOfferResult = await routerClient.AcceptJobOfferAsync(worker.Value.Id, offerId);

            Console.WriteLine($"Offer: {jobOffer.OfferId} sent to worker: {worker.Value.Id} has been accepted");
            Console.WriteLine($"Job has been assigned to worker: {worker.Value.Id} with assignment: {acceptJobOfferResult.Value.AssignmentId}");

#if !SNIPPET
            condition = false;
            startTime = DateTimeOffset.UtcNow;
            maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                Response<RouterWorker> workerDto = await routerClient.GetWorkerAsync(routerWorkerId);
                condition = workerDto.HasValue &&
                            workerDto.Value.Offers.Any(offer => offer.JobId == jobWithNoOffer);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif
            // we wait for second offer to be sent to worker
            await Task.Delay(TimeSpan.FromSeconds(10));

            // Query worker again to see new offer
            queriedWorker = await routerClient.GetWorkerAsync(routerWorkerId);
            Console.WriteLine($"Only a single offer has been issued to worker: {queriedWorker.Value.Offers.Count == 1}");
            Console.WriteLine($"Worker has now received offer for jobId: {jobWithNoOffer}: {queriedWorker.Value.Offers.Any(offer => offer.JobId == jobWithNoOffer)}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Worker_LimitMaxConcurrentOffers
        }
    }
}
