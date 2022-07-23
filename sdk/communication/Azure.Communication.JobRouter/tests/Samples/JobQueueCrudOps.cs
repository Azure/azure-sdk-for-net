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
            var routerAdministrationClient = new RouterAdministrationClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));

            var distributionPolicyId = "distribution-policy-id";
            var distributionPolicy = routerAdministrationClient.CreateDistributionPolicy(
                options: new CreateDistributionPolicyOptions(distributionPolicyId, TimeSpan.FromMinutes(5), new LongestIdleMode()));
#endif

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateJobQueue

            // set `distributionPolicyId` to an existing distribution policy
            var jobQueueId = "job-queue-id";

            var jobQueue = routerAdministrationClient.CreateQueue(
                options: new CreateQueueOptions(jobQueueId, distributionPolicyId) // this is optional
                {
                    Name = "My job queue"
                });

            Console.WriteLine($"Job queue successfully create with id: {jobQueue.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateJobQueue

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueue

            var queriedJobQueue = routerAdministrationClient.GetQueue(jobQueueId);

            Console.WriteLine($"Successfully fetched queue with id: {queriedJobQueue.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueue

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueueStat

            var queueStatistics = routerClient.GetQueueStatistics(queueId: jobQueueId);

            Console.WriteLine($"Queue statistics successfully retrieved for queue: {JsonSerializer.Serialize(queueStatistics.Value)}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueueStat

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateGetJobQueue

            var updatedJobQueue = routerAdministrationClient.UpdateQueue(
                options: new UpdateQueueOptions(jobQueueId)
                {
                    Labels = new Dictionary<string, LabelValue>()
                    {
                        ["Additional-Queue-Label"] = new LabelValue("ChatQueue")
                    }
                });

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateGetJobQueue

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueues

            var jobQueues = routerAdministrationClient.GetQueues();
            foreach (var asPage in jobQueues.AsPages(pageSizeHint: 10))
            {
                foreach (var policy in asPage.Values)
                {
                    Console.WriteLine($"Listing job queue with id: {policy.JobQueue.Id}");
                }
            }

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueues

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteJobQueue

            _ = routerAdministrationClient.DeleteQueue(jobQueueId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteJobQueue
        }
    }
}
