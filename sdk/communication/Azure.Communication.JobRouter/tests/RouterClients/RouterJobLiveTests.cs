﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class RouterJobLiveTests : RouterLiveTestBase
    {
        public RouterJobLiveTests(bool isAsync) : base(isAsync)
        {
        }

        #region Job Tests

        [Test]
        public async Task GetJobsTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();

            var channelId = GenerateUniqueId($"{nameof(GetJobsTest)}-Channel");

            // Setup queue
            var createQueueResponse = await CreateQueueAsync(nameof(GetJobsTest));
            var createQueue = createQueueResponse.Value;

            // Create 2 jobs - Both should be in Queued state
            var jobId1 = GenerateUniqueId($"{IdPrefix}{nameof(GetJobsTest)}1");
            var createJob1Response = await routerClient.CreateJobAsync(
                id: jobId1,
                channelId: channelId,
                queueId: createQueue.Id,
                new CreateJobOptions()
                {
                    Priority = 1
                });
            var createJob1 = createJob1Response.Value;

            // wait for job1 to be in queued state
            var job1Result = await Poll(async () => await routerClient.GetJobAsync(createJob1.Id),
                job => job.Value.JobStatus == JobStatus.Queued,
                TimeSpan.FromSeconds(10));

            Assert.AreEqual(JobStatus.Queued, job1Result.Value.JobStatus);

            // cancel job 1
            var cancelJob1Response = await routerClient.CancelJobAsync(createJob1.Id);

            // Create job 2
            var jobId2 = GenerateUniqueId($"{IdPrefix}{nameof(GetJobsTest)}2");
            var createJob2Response = await routerClient.CreateJobAsync(
                id: jobId2,
                channelId: channelId,
                queueId: createQueue.Id,
                new CreateJobOptions()
                {
                    Priority = 1
                });
            var createJob2 = createJob2Response.Value;

            var job2Result = await Poll(async () => await routerClient.GetJobAsync(createJob2.Id),
                job => job.Value.JobStatus == JobStatus.Queued,
                TimeSpan.FromSeconds(10));

            Assert.AreEqual(JobStatus.Queued, job2Result.Value.JobStatus);

            // test get jobs
            var getJobsResponse = routerClient.GetJobsAsync(new GetJobsOptions()
            {
                ChannelId = channelId,
                QueueId = createQueue.Id,
            });
            var allJobs = new List<string>();

            await foreach (var jobPage in getJobsResponse.AsPages(pageSizeHint: 100))
            {
                foreach (var job in jobPage.Values)
                {
                    allJobs.Add(job.Id);
                }
            }

            Assert.IsTrue(allJobs.Contains(createJob1.Id));
            Assert.IsTrue(allJobs.Contains(createJob2.Id));

            AddForCleanup(new Task(async () => await routerClient.CancelJobAsync(createJob1.Id)));
            AddForCleanup(new Task(async () => await routerClient.CancelJobAsync(createJob2.Id)));
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(createJob1.Id)));
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(createJob2.Id)));
        }

        [Test]
        [Ignore(reason: "Temporarily skipped")]
        public async Task CreateJobWithClassificationPolicy_w_StaticPriority()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();

            // Setup channel
            var channelId = GenerateUniqueId($"{nameof(CreateJobWithClassificationPolicy_w_StaticPriority)}-Channel");

            // Setup queue - to specify on job
            var createQueueResponse = await CreateQueueAsync($"{nameof(CreateJobWithClassificationPolicy_w_StaticPriority)}-Q1_CP_StaticPriority");
            var createQueue = createQueueResponse.Value;

            // Setup Classification Policies
            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}-{nameof(CreateJobWithClassificationPolicy_w_StaticPriority)}-CP_StaticPriority");
            var classificationPolicyName = $"StaticPriority-ClassificationPolicy";
            var priorityRule = new StaticRule(10);
            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(
                classificationPolicyId,
                new CreateClassificationPolicyOptions()
                {
                    Name = classificationPolicyName,
                    PrioritizationRule = priorityRule,
                });
            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId)));

            var createClassificationPolicy = createClassificationPolicyResponse.Value;

            // Create job
            var jobId = GenerateUniqueId(
                $"{IdPrefix}{nameof(CreateJobWithClassificationPolicy_w_StaticPriority)}");

            var createJobResponse = await routerClient.CreateJobWithClassificationPolicyAsync(
                id: jobId,
                channelId: channelId,
                classificationPolicyId: classificationPolicyId,
                new CreateJobWithClassificationPolicyOptions()
                {
                    ChannelReference = "123",
                    QueueId = createQueue.Id
                });
            var createJob = createJobResponse.Value;

            AddForCleanup(new Task(async () => await routerClient.CancelJobAsync(jobId)));
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(jobId)));

            var queuedJob = await Poll(async () => await routerClient.GetJobAsync(createJob.Id),
                job => job.Value.JobStatus == JobStatus.Queued, TimeSpan.FromSeconds(10));

            Assert.AreEqual(JobStatus.Queued, queuedJob.Value.JobStatus);
            Assert.AreEqual(createJob.Id, queuedJob.Value.Id);
            Assert.AreEqual(10, queuedJob.Value.Priority); // from classification policy
            Assert.AreEqual(createQueue.Id, queuedJob.Value.QueueId); // from direct queue assignment
        }

        [Test]
        public async Task CreateJobWithClassificationPolicy_w_StaticQueueSelector()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            // Setup channel
            var channelId = GenerateUniqueId($"Channel-{nameof(CreateJobWithClassificationPolicy_w_StaticQueueSelector)}");

            // Setup queue - to specify on classification default queue id
            var createQueue2Response = await CreateQueueAsync($"Q2_CP_StaticQueue");
            var createQueue2 = createQueue2Response.Value;

            // Setup Classification Policy - no default queue id is specified while creating classification policy - queueId should be evaluated from queueSelector
            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}-CP_StaticQueue");
            var classificationPolicyName = $"StaticQueueSelector-ClassificationPolicy";
            var staticQueueSelector = new List<QueueSelectorAttachment>()
            {
                new StaticQueueSelector(new QueueSelector(key: "Id", LabelOperator.Equal, value: createQueue2.Id))
            };
            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(
                classificationPolicyId,
                new CreateClassificationPolicyOptions()
                {
                    Name = classificationPolicyName,
                    QueueSelectors = staticQueueSelector
                });
            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId)));
            var createClassificationPolicy = createClassificationPolicyResponse.Value;

            // Create job - queue is not specified
            var jobId = GenerateUniqueId($"{IdPrefix}-Job-{nameof(CreateJobWithClassificationPolicy_w_StaticPriority)}");
            var createJobResponse = await routerClient.CreateJobWithClassificationPolicyAsync(
                id: jobId,
                channelId: channelId,
                classificationPolicyId: createClassificationPolicy.Id,
                new CreateJobWithClassificationPolicyOptions()
                {
                    ChannelReference = "123"
                });
            AddForCleanup(new Task(async () => await routerClient.CancelJobAsync(jobId)));
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(jobId)));
            var createJob = createJobResponse.Value;

            var queuedJob = await Poll(async () => await routerClient.GetJobAsync(createJob.Id),
                job => job.Value.JobStatus == JobStatus.Queued, TimeSpan.FromSeconds(10));

            Assert.AreEqual(JobStatus.Queued, queuedJob.Value.JobStatus);
            Assert.AreEqual(createJob.Id, queuedJob.Value.Id);
            Assert.AreEqual(1, queuedJob.Value.Priority); // default value
            Assert.AreEqual(createQueue2.Id, queuedJob.Value.QueueId); // from queue selector in classification policy

            // in-test cleanup
            await routerClient.CancelJobAsync(createJob.Id); // other wise queue deletion will throw error
            await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId); // other wise default queue deletion will throw error
        }

        [Test]
        [Ignore(reason: "Temporarily skipped")]
        public async Task CreateJobWithClassificationPolicy_w_FallbackQueue()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();

            // Setup queue - to specify on classification default queue id
            var createQueue2Response = await CreateQueueAsync($"Q2_CP_FallbackQueue");
            var createQueue2 = createQueue2Response.Value;

            // Setup Classification Policy - created with fallback queue id and no queue selector
            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}-CP_FallbackQueue");
            var classificationPolicyName = $"FallbackQueue-ClassificationPolicy";

            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(
                classificationPolicyId,
                new CreateClassificationPolicyOptions()
                {
                    Name = classificationPolicyName,
                    FallbackQueueId = createQueue2.Id
                });
            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId)));

            var createClassificationPolicy = createClassificationPolicyResponse.Value;

            // Create job - queue is not specified
            var jobId = GenerateUniqueId($"{IdPrefix}-JobWCp");
            var createJobResponse = await routerClient.CreateJobWithClassificationPolicyAsync(
                id: jobId,
                channelId: $"CP_FallbackQueue",
                classificationPolicyId: classificationPolicyId,
                new CreateJobWithClassificationPolicyOptions()
                {
                    ChannelReference = "123",
                    QueueId = null
                });
            AddForCleanup(new Task(async () => await routerClient.CancelJobAsync(jobId)));
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(jobId)));
            var createJob = createJobResponse.Value;

            var queuedJob = await Poll(async () => await routerClient.GetJobAsync(createJob.Id),
                job => job.Value.JobStatus == JobStatus.Queued, TimeSpan.FromSeconds(10));

            Assert.AreEqual(JobStatus.Queued, queuedJob.Value.JobStatus);
            Assert.AreEqual(1, queuedJob.Value.Priority); // default priority value
            Assert.AreEqual(createQueue2.Id, queuedJob.Value.QueueId); // from fallback queue of classification policy
        }

        [Test]
        [Ignore(reason: "Temporarily skipped")]
        public async Task CreateJobWithQueue_And_ClassificationPolicy_w_FallbackQueue()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            // Setup queue - to specify on classification default queue id
            var createQueue1Response = await CreateQueueAsync($"{nameof(CreateJobWithQueue_And_ClassificationPolicy_w_FallbackQueue)}-Q1_CP_JobQVsFallbackQ");
            var createQueue1 = createQueue1Response.Value;
            var createQueue2Response = await CreateQueueAsync($"{nameof(CreateJobWithQueue_And_ClassificationPolicy_w_FallbackQueue)}-Q2_CP_JobQVsFallbackQ");
            var createQueue2 = createQueue2Response.Value;

            // Setup Classification Policy - no default queue id is specified while creating classification policy - queueId should be evaluated from queueSelector
            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}-{nameof(CreateJobWithQueue_And_ClassificationPolicy_w_FallbackQueue)}-CP_JobQVsFallbackQ");
            var classificationPolicyName = $"JobQVsFallbackQ-ClassificationPolicy";

            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(
                classificationPolicyId,
                new CreateClassificationPolicyOptions()
                {
                    Name = classificationPolicyName,
                    FallbackQueueId = createQueue2.Id,
                });
            var createClassificationPolicy = createClassificationPolicyResponse.Value;
            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId)));

            // Create job - queue1 specified - should override default queue of classification policy
            var createJobResponse = await routerClient.CreateJobWithClassificationPolicyAsync(
                id:"JobWCpAndQ",
                channelId: "ChatChannel",
                classificationPolicyId: createClassificationPolicy.Id,
                new CreateJobWithClassificationPolicyOptions()
                {
                    ChannelReference = "123",
                    QueueId = createQueue1.Id,
                });
            var createJob = createJobResponse.Value;
            AddForCleanup( new Task(async () => await routerClient.CancelJobAsync(createJob.Id)));
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(createJob.Id)));

            var queuedJob = await Poll(async () => await routerClient.GetJobAsync(createJob.Id),
                job => job.Value.JobStatus == JobStatus.Queued, TimeSpan.FromSeconds(10));

            Assert.AreEqual(JobStatus.Queued, queuedJob.Value.JobStatus);
            Assert.AreEqual(createJob.Id, queuedJob.Value.Id);
            Assert.AreEqual(1, queuedJob.Value.Priority); // default value
            Assert.AreEqual(createQueue1.Id, queuedJob.Value.QueueId); // from queue selector in classification policy
        }

        #endregion Job Tests

    }
}
