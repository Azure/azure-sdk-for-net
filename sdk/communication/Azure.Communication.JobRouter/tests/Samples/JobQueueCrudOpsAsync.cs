// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Samples
{
    public class JobQueueCrudOpsAsync : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public async Task JobQueueCrud()
        {
            // create a client
            JobRouterAdministrationClient routerAdministrationClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");
            JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");

            string distributionPolicyId = "distribution-policy-id";
            Response<DistributionPolicy> distributionPolicy = await routerAdministrationClient.CreateDistributionPolicyAsync(
                options: new CreateDistributionPolicyOptions(distributionPolicyId, TimeSpan.FromMinutes(5), new LongestIdleMode()));

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateJobQueue_Async

            // set `distributionPolicyId` to an existing distribution policy
            string jobQueueId = "job-queue-id";

            Response<RouterQueue> jobQueue = await routerAdministrationClient.CreateQueueAsync(
                options: new CreateQueueOptions(jobQueueId, distributionPolicyId)
                {
                    Name = "My job queue"
                });

            Console.WriteLine($"Job queue successfully create with id: {jobQueue.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateJobQueue_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueue_Async

            Response<RouterQueue> queriedJobQueue = await routerAdministrationClient.GetQueueAsync(jobQueueId);

            Console.WriteLine($"Successfully fetched queue with id: {queriedJobQueue.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueue_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueueStat_Async

            Response<RouterQueueStatistics> queueStatistics = await routerClient.GetQueueStatisticsAsync(jobQueueId);

            Console.WriteLine($"Queue statistics successfully retrieved for queue: {JsonSerializer.Serialize(queueStatistics.Value)}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueueStat_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateGetJobQueue_Async

            Response<RouterQueue> updatedJobQueue = await routerAdministrationClient.UpdateQueueAsync(
                new RouterQueue(jobQueueId)
                {
                    Labels = { ["Additional-Queue-Label"] = new RouterValue("ChatQueue") }
                });

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateGetJobQueue_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueues_Async

            AsyncPageable<RouterQueue> jobQueues = routerAdministrationClient.GetQueuesAsync(cancellationToken: default);
            await foreach (Page<RouterQueue> asPage in jobQueues.AsPages(pageSizeHint: 10))
            {
                foreach (RouterQueue? policy in asPage.Values)
                {
                    Console.WriteLine($"Listing job queue with id: {policy.Id}");
                }
            }

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueues_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteJobQueue_Async

            _ = await routerAdministrationClient.DeleteQueueAsync(jobQueueId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteJobQueue_Async

        }
    }
}
