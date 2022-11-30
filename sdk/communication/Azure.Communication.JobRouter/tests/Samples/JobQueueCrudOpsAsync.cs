// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Models;
using Azure.Communication.JobRouter.Tests.Infrastructure;
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
            RouterAdministrationClient routerAdministrationClient = new RouterAdministrationClient("<< CONNECTION STRING >>");
            RouterClient routerClient = new RouterClient("<< CONNECTION STRING >>");

            string distributionPolicyId = "distribution-policy-id";
            Response<DistributionPolicy> distributionPolicy = await routerAdministrationClient.CreateDistributionPolicyAsync(
                options: new CreateDistributionPolicyOptions(distributionPolicyId, TimeSpan.FromMinutes(5), new LongestIdleMode()));

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateJobQueue_Async

            // set `distributionPolicyId` to an existing distribution policy
            string jobQueueId = "job-queue-id";

            Response<JobQueue> jobQueue = await routerAdministrationClient.CreateQueueAsync(
                options: new CreateQueueOptions(jobQueueId, distributionPolicyId)
                {
                    Name = "My job queue"
                });

            Console.WriteLine($"Job queue successfully create with id: {jobQueue.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateJobQueue_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueue_Async

            Response<JobQueue> queriedJobQueue = await routerAdministrationClient.GetQueueAsync(jobQueueId);

            Console.WriteLine($"Successfully fetched queue with id: {queriedJobQueue.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueue_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueueStat_Async

            Response<QueueStatistics> queueStatistics = await routerClient.GetQueueStatisticsAsync(queueId: jobQueueId);

            Console.WriteLine($"Queue statistics successfully retrieved for queue: {JsonSerializer.Serialize(queueStatistics.Value)}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueueStat_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateGetJobQueue_Async

            Response<JobQueue> updatedJobQueue = await routerAdministrationClient.UpdateQueueAsync(
                options: new UpdateQueueOptions(jobQueueId)
                {
                    Labels = new Dictionary<string, LabelValue>()
                    {
                        ["Additional-Queue-Label"] = new LabelValue("ChatQueue")
                    }
                });

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateGetJobQueue_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueues_Async

            AsyncPageable<JobQueueItem> jobQueues = routerAdministrationClient.GetQueuesAsync();
            await foreach (Page<JobQueueItem> asPage in jobQueues.AsPages(pageSizeHint: 10))
            {
                foreach (JobQueueItem? policy in asPage.Values)
                {
                    Console.WriteLine($"Listing job queue with id: {policy.JobQueue.Id}");
                }
            }

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueues_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteJobQueue_Async

            _ = await routerAdministrationClient.DeleteQueueAsync(jobQueueId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteJobQueue_Async

        }
    }
}
