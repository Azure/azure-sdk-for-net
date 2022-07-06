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
    public class JobQueueCrudOps : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public void JobQueueCrud()
        {
#if !SNIPPET
            // create a client
            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));

            var distributionPolicyId = "distribution-policy-id";
            var distributionPolicy = routerClient.CreateDistributionPolicy(id: distributionPolicyId,
                offerTtlSeconds: 5 * 60, mode: new LongestIdleMode());
#endif

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateJobQueue

            // set `distributionPolicyId` to an existing distribution policy
            var jobQueueId = "job-queue-id";

            var jobQueue = routerClient.CreateQueue(
                id: jobQueueId,
                distributionPolicyId: distributionPolicyId,
                options: new CreateQueueOptions() // this is optional
                {
                    Name = "My job queue"
                });

            Console.WriteLine($"Job queue successfully create with id: {jobQueue.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateJobQueue

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueue

            var queriedJobQueue = routerClient.GetQueue(jobQueueId);

            Console.WriteLine($"Successfully fetched queue with id: {queriedJobQueue.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueue

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueueStat

            var queueStatistics = routerClient.GetQueueStatistics(id: jobQueueId);

            Console.WriteLine($"Queue statistics successfully retrieved for queue: {JsonSerializer.Serialize(queueStatistics.Value)}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueueStat

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateGetJobQueue

            var updatedJobQueue = routerClient.UpdateQueue(
                id: jobQueueId,
                options: new UpdateQueueOptions()
                {
                    Labels = new LabelCollection()
                    {
                        ["Additional-Queue-Label"] = new LabelValue("ChatQueue")
                    }
                });

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateGetJobQueue

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueues

            var jobQueues = routerClient.GetQueues();
            foreach (var asPage in jobQueues.AsPages(pageSizeHint: 10))
            {
                foreach (var policy in asPage.Values)
                {
                    Console.WriteLine($"Listing job queue with id: {policy.Id}");
                }
            }

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueues

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteJobQueue

            _ = routerClient.DeleteQueue(jobQueueId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteJobQueue
        }
    }
}
