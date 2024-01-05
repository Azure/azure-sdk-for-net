// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Samples
{
    public class JobQueueCrudOps : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public void JobQueueCrud()
        {
            // create a client
            JobRouterAdministrationClient routerAdministrationClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");
            JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");

            string distributionPolicyId = "distribution-policy-id";
            Response<DistributionPolicy> distributionPolicy = routerAdministrationClient.CreateDistributionPolicy(
                options: new CreateDistributionPolicyOptions(distributionPolicyId, TimeSpan.FromMinutes(5), new LongestIdleMode()));

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateJobQueue

            // set `distributionPolicyId` to an existing distribution policy
            string jobQueueId = "job-queue-id";

            Response<RouterQueue> jobQueue = routerAdministrationClient.CreateQueue(
                options: new CreateQueueOptions(jobQueueId, distributionPolicyId) // this is optional
                {
                    Name = "My job queue"
                });

            Console.WriteLine($"Job queue successfully create with id: {jobQueue.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateJobQueue

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueue

            Response<RouterQueue> queriedJobQueue = routerAdministrationClient.GetQueue(jobQueueId);

            Console.WriteLine($"Successfully fetched queue with id: {queriedJobQueue.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueue

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueueStat

            Response<RouterQueueStatistics> queueStatistics = routerClient.GetQueueStatistics(jobQueueId);

            Console.WriteLine($"Queue statistics successfully retrieved for queue: {JsonSerializer.Serialize(queueStatistics.Value)}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueueStat

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateGetJobQueue

            Response<RouterQueue> updatedJobQueue = routerAdministrationClient.UpdateQueue(new RouterQueue(jobQueueId)
            {
                Labels = { ["Additional-Queue-Label"] = new RouterValue("ChatQueue") }
            });

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateGetJobQueue

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueues

            Pageable<RouterQueue> jobQueues = routerAdministrationClient.GetQueues(cancellationToken: default);
            foreach (Page<RouterQueue> asPage in jobQueues.AsPages(pageSizeHint: 10))
            {
                foreach (RouterQueue? policy in asPage.Values)
                {
                    Console.WriteLine($"Listing job queue with id: {policy.Id}");
                }
            }

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueues

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteJobQueue

            _ = routerAdministrationClient.DeleteQueue(jobQueueId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteJobQueue
        }
    }
}
