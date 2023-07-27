﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Models;
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

            Response<Models.RouterQueue> jobQueue = routerAdministrationClient.CreateQueue(
                options: new CreateQueueOptions(jobQueueId, distributionPolicyId) // this is optional
                {
                    Name = "My job queue"
                });

            Console.WriteLine($"Job queue successfully create with id: {jobQueue.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateJobQueue

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueue

            Response<Models.RouterQueue> queriedJobQueue = routerAdministrationClient.GetQueue(jobQueueId);

            Console.WriteLine($"Successfully fetched queue with id: {queriedJobQueue.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueue

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueueStat

            Response<RouterQueueStatistics> queueStatistics = routerClient.GetQueueStatistics(queueId: jobQueueId);

            Console.WriteLine($"Queue statistics successfully retrieved for queue: {JsonSerializer.Serialize(queueStatistics.Value)}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueueStat

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateQueueRemoveProp

            Response updatedJobQueueWithoutName = routerAdministrationClient.UpdateQueue(jobQueueId,
                RequestContent.Create(new { Name = (string?)null }));

            Response<Models.RouterQueue> queriedJobQueueWithoutName = routerAdministrationClient.GetQueue(jobQueueId);

            Console.WriteLine($"Queue successfully updated: 'Name' has been removed. Status: {string.IsNullOrWhiteSpace(queriedJobQueueWithoutName.Value.Name)}");
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateQueueRemoveProp

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateGetJobQueue

            Response<Models.RouterQueue> updatedJobQueue = routerAdministrationClient.UpdateQueue(
                options: new UpdateQueueOptions(jobQueueId)
                {
                    Labels = { ["Additional-Queue-Label"] = new LabelValue("ChatQueue") }
                });

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateGetJobQueue

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueues

            Pageable<Models.RouterQueueItem> jobQueues = routerAdministrationClient.GetQueues();
            foreach (Page<Models.RouterQueueItem> asPage in jobQueues.AsPages(pageSizeHint: 10))
            {
                foreach (Models.RouterQueueItem? policy in asPage.Values)
                {
                    Console.WriteLine($"Listing job queue with id: {policy.Queue.Id}");
                }
            }

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetJobQueues

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteJobQueue

            _ = routerAdministrationClient.DeleteQueue(jobQueueId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteJobQueue
        }
    }
}
