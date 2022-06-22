// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
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
#if !SNIPPET
            // create a client
            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));

            var distributionPolicyId = "distribution-policy-id";
            var distributionPolicy = await routerClient.CreateDistributionPolicyAsync(id: distributionPolicyId,
                offerTtlSeconds: 5 * 60, mode: new LongestIdleMode());
#endif

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateJobQueue_Async

            // set `distributionPolicyId` to an existing distribution policy
            var jobQueueId = "job-queue-id";

            var jobQueue = await routerClient.CreateQueueAsync(
                id: jobQueueId,
                distributionPolicyId: distributionPolicyId,
                options: new CreateQueueOptions() // this is optional
                {
                    Name = "My job queue"
                });

            Console.WriteLine($"Job queue successfully create with id: {jobQueue.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateJobQueue_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueue_Async

            var queriedJobQueue = await routerClient.GetQueueAsync(jobQueueId);

            Console.WriteLine($"Successfully fetched queue with id: {queriedJobQueue.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueue_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueueStat_Async

            var queueStatistics = await routerClient.GetQueueStatisticsAsync(id: jobQueueId);

            Console.WriteLine($"Queue statistics successfully retrieved for queue: {JsonSerializer.Serialize(queueStatistics.Value)}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueueStat_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateGetJobQueue_Async

            var updatedJobQueue = await routerClient.UpdateQueueAsync(
                id: jobQueueId,
                options: new UpdateQueueOptions()
                {
                    Labels = new LabelCollection()
                    {
                        ["Additional-Queue-Label"] = "ChatQueue"
                    }
                });

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateGetJobQueue_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueues_Async

            var jobQueues = routerClient.GetQueuesAsync();
            await foreach (var asPage in jobQueues.AsPages(pageSizeHint: 10))
            {
                foreach (var policy in asPage.Values)
                {
                    Console.WriteLine($"Listing job queue with id: {policy.Id}");
                }
            }

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueues_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteJobQueue_Async

            _ = await routerClient.DeleteQueueAsync(jobQueueId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteJobQueue_Async

        }
    }
}
