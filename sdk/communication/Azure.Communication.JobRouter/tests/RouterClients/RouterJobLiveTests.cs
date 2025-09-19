// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core;
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
        public async Task UpdateJobWithNotesWorksCorrectly()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();
            var channelId = GenerateUniqueId($"{nameof(UpdateJobWithNotesWorksCorrectly)}-Channel");

            // Setup queue
            var createQueueResponse = await CreateQueueAsync(nameof(UpdateJobWithNotesWorksCorrectly));
            var createQueue = createQueueResponse.Value;

            // Create 1 job
            var jobId1 = GenerateUniqueId($"{IdPrefix}{nameof(UpdateJobWithNotesWorksCorrectly)}1");
            var createJob1Response = await routerClient.CreateJobAsync(
                new CreateJobOptions(jobId1, channelId, createQueue.Id)
                {
                    Priority = 1,
                });
            var createJob1 = createJob1Response.Value;
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(createJob1.Id)));

            RouterJob? updatedJob1Response = null;
            // update job with notes
            DateTimeOffset updateNoteTimeStamp = new DateTimeOffset(2022, 9, 01, 3, 0, 0, new TimeSpan(0, 0, 0));

            try
            {
                updatedJob1Response = await routerClient.UpdateJobAsync(new RouterJob(jobId1)
                {
                    Notes =
                    {
                        new RouterJobNote("Fake notes attached to job with update") { AddedAt = updateNoteTimeStamp }
                    }
                });
            }
            catch (Exception)
            {
                updatedJob1Response = await routerClient.UpdateJobAsync(new RouterJob(jobId1)
                {
                    Notes =
                    {
                        new RouterJobNote("Fake notes attached to job with update") { AddedAt = updateNoteTimeStamp }
                    }
                });
            }

            Assert.IsNotEmpty(updatedJob1Response.Notes);
            Assert.IsTrue(updatedJob1Response.Notes.Count == 1);

            // in-test cleanup
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(TimeSpan.FromSeconds(3));
            }
            await routerClient.CancelJobAsync(new CancelJobOptions(jobId1)); // other wise queue deletion will throw error
        }

        [Test]
        public async Task GetJobsTest()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();

            var channelId = GenerateUniqueId($"{nameof(GetJobsTest)}-Channel");

            // Setup queue
            var createQueueResponse = await CreateQueueAsync(nameof(GetJobsTest));
            var createQueue = createQueueResponse.Value;

            // Create 2 jobs - Both should be in Queued state
            var jobId1 = GenerateUniqueId($"{IdPrefix}{nameof(GetJobsTest)}1");
            var createJob1Response = await routerClient.CreateJobAsync(
                new CreateJobOptions(jobId1, channelId, createQueue.Id)
                {
                    Priority = 1,
                });

            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(jobId1)));
            var createJob1 = createJob1Response.Value;

            // wait for job1 to be in queued state
            var job1Result = await Poll(async () => await routerClient.GetJobAsync(createJob1.Id),
                job => job.Value.Status == RouterJobStatus.Queued,
                TimeSpan.FromSeconds(10));

            Assert.AreEqual(RouterJobStatus.Queued, job1Result.Value.Status);

            // cancel job 1
            var cancelJob1Response = await routerClient.CancelJobAsync(new CancelJobOptions(createJob1.Id));

            // Create job 2
            var jobId2 = GenerateUniqueId($"{IdPrefix}{nameof(GetJobsTest)}2");
            var createJob2Response = await routerClient.CreateJobAsync(
                new CreateJobOptions(jobId2, channelId, createQueue.Id)
                {
                    Priority = 1
                });
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(jobId2)));
            var createJob2 = createJob2Response.Value;

            var job2Result = await Poll(async () => await routerClient.GetJobAsync(createJob2.Id),
                job => job.Value.Status == RouterJobStatus.Queued,
                TimeSpan.FromSeconds(10));

            Assert.AreEqual(RouterJobStatus.Queued, job2Result.Value.Status);

            // test get jobs
            var getJobsResponse = routerClient.GetJobsAsync(channelId: channelId, queueId: createQueue.Id, status: null, classificationPolicyId: null, scheduledBefore: null, scheduledAfter: null, cancellationToken: default);
            var allJobs = new List<string>();

            await foreach (var jobPage in getJobsResponse.AsPages(pageSizeHint: 1))
            {
                foreach (var job in jobPage.Values)
                {
                    allJobs.Add(job.Id);
                }
            }

            Assert.IsTrue(allJobs.Contains(createJob1.Id));
            Assert.IsTrue(allJobs.Contains(createJob2.Id));

            // in-test cleanup
            await routerClient.CancelJobAsync(new CancelJobOptions(jobId2)); // other wise queue deletion will throw error
        }

        [Test]
        public async Task GetJobsWithSchedulingFiltersTest()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();

            var channelId = GenerateUniqueId($"{nameof(GetJobsWithSchedulingFiltersTest)}-Channel");

            // Setup queue
            var createQueueResponse = await CreateQueueAsync(nameof(GetJobsWithSchedulingFiltersTest));
            var createQueue = createQueueResponse.Value;

            // Create 2 jobs - Both should be in Queued state
            var jobId1 = GenerateUniqueId($"{IdPrefix}{nameof(GetJobsWithSchedulingFiltersTest)}1");
            var timeToEnqueueJob = GetOrSetScheduledTimeUtc(DateTimeOffset.UtcNow.AddMinutes(1));
            var createJob1Response = await routerClient.CreateJobAsync(
                new CreateJobOptions(jobId1, channelId, createQueue.Id)
                {
                    Priority = 1,
                    MatchingMode = new ScheduleAndSuspendMode(timeToEnqueueJob),
                });

            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(jobId1)));
            var createJob1 = createJob1Response.Value;
            // test get jobs
            var getJobsResponse = routerClient.GetJobsAsync(channelId: channelId, queueId: createQueue.Id, scheduledAfter: timeToEnqueueJob, status: null, classificationPolicyId: null, scheduledBefore: null, cancellationToken: default);
            var allJobs = new List<string>();

            await foreach (var jobPage in getJobsResponse.AsPages(pageSizeHint: 1))
            {
                foreach (var job in jobPage.Values)
                {
                    allJobs.Add(job.Id);
                }
            }

            Assert.IsTrue(allJobs.Contains(createJob1.Id));

            // in-test cleanup
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(TimeSpan.FromSeconds(3));
            }
            await routerClient.CancelJobAsync(new CancelJobOptions(jobId1)); // other wise queue deletion will throw error
        }

        [Test]
        [Ignore("Ignoring for hotfix")]
        public async Task CreateJobWithClassificationPolicy_w_StaticPriority()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();
            JobRouterAdministrationClient routerAdministrationClient = CreateRouterAdministrationClientWithConnectionString();

            // Setup channel
            var channelId = GenerateUniqueId($"{nameof(CreateJobWithClassificationPolicy_w_StaticPriority)}-Channel");

            // Setup queue - to specify on job
            var createQueueResponse = await CreateQueueAsync($"{nameof(CreateJobWithClassificationPolicy_w_StaticPriority)}-Q1_CP_StaticPriority");
            var createQueue = createQueueResponse.Value;

            // Setup Classification Policies
            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}-{nameof(CreateJobWithClassificationPolicy_w_StaticPriority)}-CP_StaticPriority");
            var classificationPolicyName = $"StaticPriority-ClassificationPolicy";
            var priorityRule = new StaticRouterRule(new RouterValue(10));
            var createClassificationPolicyResponse = await routerAdministrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId)
                {
                    Name = classificationPolicyName,
                    PrioritizationRule = priorityRule,
                });
            AddForCleanup(new Task(async () => await routerAdministrationClient.DeleteClassificationPolicyAsync(classificationPolicyId)));

            var createClassificationPolicy = createClassificationPolicyResponse.Value;

            // Create job
            var jobId = GenerateUniqueId(
                $"{IdPrefix}{nameof(CreateJobWithClassificationPolicy_w_StaticPriority)}");

            var createJobResponse = await routerClient.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(jobId: jobId,
                    channelId: channelId,
                    classificationPolicyId: classificationPolicyId)
                {
                    ChannelReference = "123",
                    QueueId = createQueue.Id
                });
            var createJob = createJobResponse.Value;

            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(jobId)));

            var queuedJob = await Poll(async () => await routerClient.GetJobAsync(createJob.Id),
                job => job.Value.Status == RouterJobStatus.Queued, TimeSpan.FromSeconds(10));

            Assert.AreEqual(RouterJobStatus.Queued, queuedJob.Value.Status);
            Assert.AreEqual(createJob.Id, queuedJob.Value.Id);
            Assert.AreEqual(10, queuedJob.Value.Priority); // from classification policy
            Assert.AreEqual(createQueue.Id, queuedJob.Value.QueueId); // from direct queue assignment

            // in-test cleanup
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
            await routerClient.CancelJobAsync(new CancelJobOptions(createJob.Id)); // other wise queue deletion will throw error
            await routerAdministrationClient.DeleteClassificationPolicyAsync(classificationPolicyId); // other wise default queue deletion will throw error
        }

        [Test]
        [Ignore("Ignoring for hotfix")]
        public async Task CreateJobWithClassificationPolicy_w_StaticQueueSelector()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();
            JobRouterAdministrationClient routerAdministrationClient = CreateRouterAdministrationClientWithConnectionString();
            // Setup channel
            var channelId = GenerateUniqueId($"Channel-{nameof(CreateJobWithClassificationPolicy_w_StaticQueueSelector)}");

            // Setup queue - to specify on classification default queue id
            var createQueue2Response = await CreateQueueAsync($"Q2_CP_StaticQueue");
            var createQueue2 = createQueue2Response.Value;

            // Setup Classification Policy - no default queue id is specified while creating classification policy - queueId should be evaluated from queueSelector
            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}-CP_StaticQueue");
            var classificationPolicyName = $"StaticQueueSelector-ClassificationPolicy";
            var createClassificationPolicyResponse = await routerAdministrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId)
                {
                    Name = classificationPolicyName,
                    QueueSelectorAttachments = { new StaticQueueSelectorAttachment(new RouterQueueSelector(key: "Id", LabelOperator.Equal, value: new RouterValue(createQueue2.Id))) }
                });
            AddForCleanup(new Task(async () => await routerAdministrationClient.DeleteClassificationPolicyAsync(classificationPolicyId)));
            var createClassificationPolicy = createClassificationPolicyResponse.Value;

            // Create job - queue is not specified
            var jobId = GenerateUniqueId($"{IdPrefix}-Job-{nameof(CreateJobWithClassificationPolicy_w_StaticPriority)}");
            var createJobResponse = await routerClient.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(jobId: jobId,
                    channelId: channelId,
                    classificationPolicyId: createClassificationPolicy.Id)
                {
                    ChannelReference = "123"
                });
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(jobId)));
            var createJob = createJobResponse.Value;

            var queuedJob = await Poll(async () => await routerClient.GetJobAsync(createJob.Id),
                job => job.Value.Status == RouterJobStatus.Queued, TimeSpan.FromSeconds(10));

            Assert.AreEqual(RouterJobStatus.Queued, queuedJob.Value.Status);
            Assert.AreEqual(createJob.Id, queuedJob.Value.Id);
            // Assert.AreEqual(1, queuedJob.Value.Priority); // default value TODO: Should be 0 or 1?
            Assert.AreEqual(createQueue2.Id, queuedJob.Value.QueueId); // from queue selector in classification policy

            // in-test cleanup
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
            await routerClient.CancelJobAsync(new CancelJobOptions(createJob.Id)); // other wise queue deletion will throw error
            await routerAdministrationClient.DeleteClassificationPolicyAsync(classificationPolicyId); // other wise default queue deletion will throw error
        }

        [Test]
        public async Task CreateJobWithClassificationPolicy_w_FallbackQueue()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();
            JobRouterAdministrationClient routerAdministrationClient = CreateRouterAdministrationClientWithConnectionString();

            // Setup queue - to specify on classification default queue id
            var createQueue2Response = await CreateQueueAsync($"Q2_CP_FallbackQueue");
            var createQueue2 = createQueue2Response.Value;

            // Setup Classification Policy - created with fallback queue id and no queue selector
            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}-CP_FallbackQueue");
            var classificationPolicyName = $"FallbackQueue-ClassificationPolicy";

            var createClassificationPolicyResponse = await routerAdministrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId)
                {
                    Name = classificationPolicyName,
                    FallbackQueueId = createQueue2.Id
                });
            AddForCleanup(new Task(async () => await routerAdministrationClient.DeleteClassificationPolicyAsync(classificationPolicyId)));

            var createClassificationPolicy = createClassificationPolicyResponse.Value;

            // Create job - queue is not specified
            var jobId = GenerateUniqueId($"{IdPrefix}-JobWCp");
            var createJobResponse = await routerClient.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(jobId: jobId,
                    channelId: $"CP_FallbackQueue",
                    classificationPolicyId: classificationPolicyId)
                {
                    ChannelReference = "123",
                    QueueId = null
                });
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(jobId)));
            var createJob = createJobResponse.Value;

            var queuedJob = await Poll(async () => await routerClient.GetJobAsync(createJob.Id),
                job => job.Value.Status == RouterJobStatus.Queued, TimeSpan.FromSeconds(10));

            Assert.AreEqual(RouterJobStatus.Queued, queuedJob.Value.Status);
            Assert.AreEqual(1, queuedJob.Value.Priority); // default priority value
            Assert.AreEqual(createQueue2.Id, queuedJob.Value.QueueId); // from fallback queue of classification policy

            // in-test cleanup
            await routerClient.CancelJobAsync(new CancelJobOptions(createJob.Id)); // other wise queue deletion will throw error
            await routerAdministrationClient.DeleteClassificationPolicyAsync(classificationPolicyId); // other wise default queue deletion will throw error
        }

        [Test]
        [Ignore("Ignoring for hotfix")]
        public async Task CreateJobWithQueue_And_ClassificationPolicy_w_FallbackQueue()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();
            JobRouterAdministrationClient routerAdministrationClient = CreateRouterAdministrationClientWithConnectionString();
            // Setup queue - to specify on classification default queue id
            var createQueue1Response = await CreateQueueAsync($"{nameof(CreateJobWithQueue_And_ClassificationPolicy_w_FallbackQueue)}-Q1_CP_JobQVsFallbackQ");
            var createQueue1 = createQueue1Response.Value;
            var createQueue2Response = await CreateQueueAsync($"{nameof(CreateJobWithQueue_And_ClassificationPolicy_w_FallbackQueue)}-Q2_CP_JobQVsFallbackQ");
            var createQueue2 = createQueue2Response.Value;

            // Setup Classification Policy - no default queue id is specified while creating classification policy - queueId should be evaluated from queueSelector
            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}-{nameof(CreateJobWithQueue_And_ClassificationPolicy_w_FallbackQueue)}-CP_JobQVsFallbackQ");
            var classificationPolicyName = $"JobQVsFallbackQ-ClassificationPolicy";

            var createClassificationPolicyResponse = await routerAdministrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId)
                {
                    Name = classificationPolicyName,
                    FallbackQueueId = createQueue2.Id,
                });
            var createClassificationPolicy = createClassificationPolicyResponse.Value;
            AddForCleanup(new Task(async () => await routerAdministrationClient.DeleteClassificationPolicyAsync(classificationPolicyId)));

            // Create job - queue1 specified - should override default queue of classification policy
            var createJobResponse = await routerClient.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(jobId: "JobWCpAndQ",
                    channelId: "ChatChannel",
                    classificationPolicyId: createClassificationPolicy.Id)
                {
                    ChannelReference = "123",
                    QueueId = createQueue1.Id,
                });
            var createJob = createJobResponse.Value;
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(createJob.Id)));

            var queuedJob = await Poll(async () => await routerClient.GetJobAsync(createJob.Id),
                job => job.Value.Status == RouterJobStatus.Queued, TimeSpan.FromSeconds(10));

            Assert.AreEqual(RouterJobStatus.Queued, queuedJob.Value.Status);
            Assert.AreEqual(createJob.Id, queuedJob.Value.Id);
            Assert.AreEqual(1, queuedJob.Value.Priority); // default value
            Assert.AreEqual(createQueue1.Id, queuedJob.Value.QueueId); // from queue selector in classification policy

            // in-test cleanup
            await routerClient.CancelJobAsync(new CancelJobOptions(createJob.Id)); // other wise queue deletion will throw error
            await routerAdministrationClient.DeleteClassificationPolicyAsync(classificationPolicyId); // other wise default queue deletion will throw error
        }

        [Test]
        public async Task CreateJobWithQueueAndMatchMode()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();
            var channelId = GenerateUniqueId($"{nameof(CreateJobWithQueueAndMatchMode)}-Channel");

            // Setup queue
            var createQueueResponse = await CreateQueueAsync(nameof(CreateJobWithQueueAndMatchMode));
            var createQueue = createQueueResponse.Value;

            // Create 1 job
            var jobId1 = GenerateUniqueId($"{IdPrefix}{nameof(CreateJobWithQueueAndMatchMode)}1");
            var createJob1Response = await routerClient.CreateJobAsync(
                new CreateJobOptions(jobId1, channelId, createQueue.Id)
                {
                    Priority = 1,
                    ChannelReference = "IncorrectValue",
                    MatchingMode = new QueueAndMatchMode(),
                });
            var createJob1 = createJob1Response.Value;
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(createJob1.Id)));

            Assert.IsTrue(createJob1.MatchingMode.GetType() == typeof(QueueAndMatchMode));

            var queuedJob = await Poll(async () => await routerClient.GetJobAsync(createJob1.Id),
                job => job.Value.Status == RouterJobStatus.Queued, TimeSpan.FromSeconds(10));

            // in-test cleanup
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(TimeSpan.FromSeconds(3));
            }
            await routerClient.CancelJobAsync(new CancelJobOptions(createJob1.Id)); // other wise queue deletion will throw error
        }

        [Test]
        public async Task CreateJobWithSuspendMode()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();
            var channelId = GenerateUniqueId($"{nameof(CreateJobWithSuspendMode)}-Channel");

            // Setup queue
            var createQueueResponse = await CreateQueueAsync(nameof(CreateJobWithSuspendMode));
            var createQueue = createQueueResponse.Value;

            // Create 1 job
            var jobId1 = GenerateUniqueId($"{IdPrefix}{nameof(CreateJobWithSuspendMode)}1");
            var createJob1Response = await routerClient.CreateJobAsync(
                new CreateJobOptions(jobId1, channelId, createQueue.Id)
                {
                    Priority = 1,
                    ChannelReference = "IncorrectValue",
                    MatchingMode = new SuspendMode(),
                });
            var createJob1 = createJob1Response.Value;
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(createJob1.Id)));

            Assert.IsTrue(createJob1.MatchingMode.GetType() == typeof(SuspendMode));

            // in-test cleanup
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(TimeSpan.FromSeconds(3));
            }
            await routerClient.CancelJobAsync(new CancelJobOptions(createJob1.Id)); // other wise queue deletion will throw error
        }

        [Test]
        public async Task CreateJobWithScheduleAndSuspendMode()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();
            var channelId = GenerateUniqueId($"{nameof(CreateJobWithScheduleAndSuspendMode)}-Channel");

            // Setup queue
            var createQueueResponse = await CreateQueueAsync(nameof(CreateJobWithScheduleAndSuspendMode));
            var createQueue = createQueueResponse.Value;

            // Create 1 job
            var jobId1 = GenerateUniqueId($"{IdPrefix}{nameof(CreateJobWithScheduleAndSuspendMode)}1");
            var timeToEnqueueJob = GetOrSetScheduledTimeUtc(new DateTimeOffset(2100, 1, 1, 1, 1, 1, TimeSpan.Zero));
            var createJob1Response = await routerClient.CreateJobAsync(
                new CreateJobOptions(jobId1, channelId, createQueue.Id)
                {
                    Priority = 1,
                    ChannelReference = "IncorrectValue",
                    MatchingMode = new ScheduleAndSuspendMode(timeToEnqueueJob),
                });
            var createJob1 = createJob1Response.Value;
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(createJob1.Id)));

            Assert.IsTrue(createJob1.MatchingMode.GetType() == typeof(ScheduleAndSuspendMode));

            var queuedJob = await Poll(async () => await routerClient.GetJobAsync(createJob1.Id),
                job => job.Value.Status == RouterJobStatus.Scheduled, TimeSpan.FromSeconds(10));

            // in-test cleanup
            await routerClient.CancelJobAsync(new CancelJobOptions(createJob1.Id)); // other wise queue deletion will throw error
        }

        [Test]
        [Ignore("Ignoring for hotfix")]
        public async Task UpdateJobTest()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();
            var channelId = GenerateUniqueId($"{nameof(UpdateJobTest)}-Channel");

            // Setup queue
            var createQueueResponse = await CreateQueueAsync(nameof(UpdateJobTest));
            var createQueue = createQueueResponse.Value;

            // Create 1 job
            var jobId1 = GenerateUniqueId($"{IdPrefix}{nameof(UpdateJobTest)}1");
            var labels = new Dictionary<string, RouterValue?>
            {
                ["Label_1"] = new RouterValue("Value_1"),
                ["Label_2"] = new RouterValue(2),
                ["Label_3"] = new RouterValue(true)
            };
            var tags = new Dictionary<string, RouterValue?>
            {
                ["Tag_1"] = new RouterValue("Value_1"),
                ["Tag_2"] = new RouterValue(2),
                ["Tag_3"] = new RouterValue(true)
            };

            var createJobOptions = new CreateJobOptions(jobId1, channelId, createQueue.Id);
            createJobOptions.Labels.Append(labels);
            createJobOptions.Tags.Append(tags);

            var createJobResponse = await routerClient.CreateJobAsync(createJobOptions);

            var updatedLabels = new Dictionary<string, RouterValue?>
            {
                ["Label_1"] = null,
                ["Label_2"] = new RouterValue(null),
                ["Label_3"] = new RouterValue("Value_Updated_3"),
                ["Label_4"] = new RouterValue("Value_4")
            };
            var updatedTags = new Dictionary<string, RouterValue?>
            {
                ["Tag_1"] = null,
                ["Tag_2"] = new RouterValue(null),
                ["Tag_3"] = new RouterValue("Value_Updated_3"),
                ["Tag_4"] = new RouterValue("Value_4")
            };

            var updateOptions = new RouterJob(jobId1);
            updateOptions.Labels.Append(updatedLabels);
            updateOptions.Tags.Append(updatedTags);

            var updateJobResponse = await routerClient.UpdateJobAsync(updateOptions);

            Assert.AreEqual(updateJobResponse.Value.Labels, new Dictionary<string, RouterValue?>
            {
                ["Label_3"] = new RouterValue("Value_Updated_3"),
                ["Label_4"] = new RouterValue("Value_4")
            });
            Assert.AreEqual(updateJobResponse.Value.Tags, new Dictionary<string, RouterValue?>
            {
                ["Tag_3"] = new RouterValue("Value_Updated_3"),
                ["Tag_4"] = new RouterValue("Value_4")
            });

            // in-test cleanup
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
            await routerClient.CancelJobAsync(new CancelJobOptions(jobId1)); // other wise queue deletion will throw error
            await routerClient.DeleteJobAsync(jobId1); // other wise queue deletion will throw error
        }

        [Test]
        public async Task ReclassifyJob()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();
            JobRouterAdministrationClient routerAdminClient = CreateRouterAdministrationClientWithConnectionString();
            var channelId = GenerateUniqueId($"{nameof(ReclassifyJob)}-Channel");

            // Setup queue
            var createQueueResponse = await CreateQueueAsync(nameof(ReclassifyJob));
            var createQueue = createQueueResponse.Value;

            var classificationPolicy = await routerAdminClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(GenerateUniqueId($"{IdPrefix}{nameof(ReclassifyJob)}-policy"))
                {
                    PrioritizationRule = new StaticRouterRule(new RouterValue(1))
                });
            AddForCleanup(new Task(async () => await routerAdminClient.DeleteClassificationPolicyAsync(classificationPolicy.Value.Id)));

            // Create 1 job
            var jobId1 = GenerateUniqueId($"{IdPrefix}{nameof(ReclassifyJob)}-job");
            var createJob1Response = await routerClient.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(jobId1, channelId, classificationPolicy.Value.Id)
                {
                    QueueId = createQueue.Id
                });
            var createJob1 = createJob1Response.Value;
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(createJob1.Id)));

            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
            }

            await routerClient.ReclassifyJobAsync(jobId1, CancellationToken.None);

            Assert.AreEqual(createJob1.QueueId, createQueue.Id);

            // in-test cleanup
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(TimeSpan.FromSeconds(3));
            }
            await routerClient.CancelJobAsync(new CancelJobOptions(jobId1)); // other wise queue deletion will throw error
        }

        #endregion Job Tests

    }
}
