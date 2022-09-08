// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Models;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Scenarios
{
    [NonParallelizable]
    public class QueueScenario : RouterLiveTestBase
    {
        private static string ScenarioPrefix = nameof(QueueScenario);
        /// <inheritdoc />
        public QueueScenario(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task SimpleQueueingScenario()
        {
            RouterClient client = CreateRouterClientWithConnectionString();
            RouterAdministrationClient administrationClient = CreateRouterAdministrationClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"Channel-SQ-{IdPrefix}-{nameof(QueueScenario)}");
            var distributionPolicyResponse = await administrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                    TimeSpan.FromMinutes(10),
                    new LongestIdleMode(1,
                        1))
                {
                    Name = "Simple-Queue-Distribution"
                });
            var queueResponse = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                    distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                });
            var jobId = GenerateUniqueId($"JobId-SQ-{nameof(QueueScenario)}");
            var createJob = await client.CreateJobAsync(
                new CreateJobOptions(jobId, channelResponse, queueResponse.Value.Id)
                {
                    Priority = 1
                });

            var job = await Poll(async () => await client.GetJobAsync(createJob.Value.Id),
                x => x.Value.JobStatus == RouterJobStatus.Queued,
                TimeSpan.FromSeconds(10));
            Assert.AreEqual(RouterJobStatus.Queued, job.Value.JobStatus);
        }

        [Test]
        public async Task QueueingWithClassificationPolicyWithStaticLabelSelector()
        {
            RouterClient client = CreateRouterClientWithConnectionString();
            RouterAdministrationClient administrationClient = CreateRouterAdministrationClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"Channel-StaticLabel-{IdPrefix}-{nameof(QueueScenario)}");
            var distributionPolicyResponse = await administrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                    TimeSpan.FromMinutes(10),
                    new LongestIdleMode(1, 1))
                {
                    Name = "Simple-Queue-Distribution"
                });
            var queueResponse = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                    distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                });

            var queueSelector = new List<QueueSelectorAttachment>()
            {
                new StaticQueueSelectorAttachment(new QueueSelector(key: "Id", LabelOperator.Equal, new LabelValue(queueResponse.Value.Id)))
            };

            var classificationPolicyResponse = await administrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(GenerateUniqueId($"Cp-StaticLabels-{IdPrefix}"))
                {
                    QueueSelectors = queueSelector
                });

            var jobId = GenerateUniqueId($"JobId-StaticLabel-{nameof(QueueScenario)}");
            var createJob = await client.CreateJobAsync( new CreateJobWithClassificationPolicyOptions(jobId, channelResponse, classificationPolicyResponse.Value.Id));

            var job = await Poll(async () => await client.GetJobAsync(createJob.Value.Id),
                x => x.Value.JobStatus == RouterJobStatus.Queued,
                TimeSpan.FromSeconds(10));
            Assert.AreEqual(RouterJobStatus.Queued, job.Value.JobStatus);
            Assert.AreEqual(job.Value.QueueId, queueResponse.Value.Id);
        }

        [Test]
        public async Task QueueingWithClassificationPolicyWithFallbackQueue()
        {
            RouterClient client = CreateRouterClientWithConnectionString();
            RouterAdministrationClient administrationClient = CreateRouterAdministrationClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"Channel-FQ-{IdPrefix}-{nameof(QueueScenario)}");
            var distributionPolicyResponse = await administrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                    TimeSpan.FromMinutes(10),
                    new LongestIdleMode(1, 1))
                {
                    Name = "Simple-Queue-Distribution",
                });
            var fallbackQueueResponse = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-default_Q"),
                    distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                });

            var queueSelector = new List<QueueSelectorAttachment>()
            {
                new StaticQueueSelectorAttachment(new QueueSelector(key: "Id", LabelOperator.Equal, new LabelValue("QueueIdDoesNotExist")))
            };

            var classificationPolicyResponse = await administrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(GenerateUniqueId($"Cp-default_Q-{IdPrefix}"))
                {
                    QueueSelectors = queueSelector,
                    FallbackQueueId = fallbackQueueResponse.Value.Id,
                });

            var jobId = GenerateUniqueId($"JobId-default_Q-{nameof(QueueScenario)}");
            var createJob = await client.CreateJobAsync( new CreateJobWithClassificationPolicyOptions(jobId, channelResponse, classificationPolicyResponse.Value.Id));

            var job = await Poll(async () => await client.GetJobAsync(createJob.Value.Id),
                x => x.Value.JobStatus == RouterJobStatus.Queued,
                TimeSpan.FromSeconds(10));
            Assert.AreEqual(RouterJobStatus.Queued, job.Value.JobStatus);
            Assert.AreEqual(job.Value.QueueId, fallbackQueueResponse.Value.Id);
        }

        [Test]
        public async Task QueueingWithClassificationPolicyWithConditionalLabelSelector()
        {
            RouterClient client = CreateRouterClientWithConnectionString();
            RouterAdministrationClient administrationClient = CreateRouterAdministrationClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"Channel-CPWithConditionalLabels-{IdPrefix}-{nameof(QueueScenario)}");
            var distributionPolicyResponse = await administrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                    TimeSpan.FromMinutes(10),
                    new LongestIdleMode(1, 1))
                {
                    Name = "Simple-Queue-Distribution"
                });
            var queueResponse = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                    distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                });
            var fallbackQueueResponse = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-default_Q"),
                    distributionPolicyResponse.Value.Id)
                {
                    Name = "test"
                });

            var queueSelector = new List<QueueSelectorAttachment>()
            {
                new ConditionalQueueSelectorAttachment(
                    condition: new ExpressionRule("If(job.Product = \"O365\", true, false)"),
                    labelSelectors: new List<QueueSelector>()
                    {
                        new QueueSelector("Id", LabelOperator.Equal, new LabelValue(queueResponse.Value.Id))
                    })
            };

            var classificationPolicyResponse = await administrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(GenerateUniqueId($"{IdPrefix}-cp-conditional"))
                {
                    QueueSelectors = queueSelector,
                    FallbackQueueId = fallbackQueueResponse.Value.Id,
                });

            var jobLabels = new Dictionary<string, LabelValue>() {["Product"] = new LabelValue("O365") };
            var createJob = await client.CreateJobAsync(
                new CreateJobWithClassificationPolicyOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"), channelResponse, classificationPolicyResponse.Value.Id)
                {
                    Labels = jobLabels,
                });

            var job = await Poll(async () => await client.GetJobAsync(createJob.Value.Id),
                x => x.Value.JobStatus == RouterJobStatus.Queued,
                TimeSpan.FromSeconds(10));
            Assert.AreEqual(RouterJobStatus.Queued, job.Value.JobStatus);
            Assert.AreEqual(job.Value.QueueId, queueResponse.Value.Id);
        }

        [Test]
        public async Task QueueingWithClassificationPolicyWithPassThroughLabelSelector()
        {
            RouterClient client = CreateRouterClientWithConnectionString();
            RouterAdministrationClient administrationClient = CreateRouterAdministrationClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-{nameof(QueueingWithClassificationPolicyWithPassThroughLabelSelector)}");
            var distributionPolicyResponse = await administrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                    TimeSpan.FromMinutes(10),
                    new LongestIdleMode(1, 1))
                {
                    Name = "Simple-Queue-Distribution",
                });

            var queueLabels = new Dictionary<string, LabelValue>()
            {
                ["Region"] = new LabelValue("NA"),
                ["Language"] = new LabelValue("EN"),
                ["Product"] = new LabelValue("O365"),
                ["UniqueIdentifier"] = new LabelValue(IdPrefix)
            };
            var queueResponse = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-1"), distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                    Labels = queueLabels
                });
            var fallbackQueueResponse = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-default_Q"),
                    distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                });

            var queueSelector = new List<QueueSelectorAttachment>()
            {
                new PassThroughQueueSelectorAttachment("Region", LabelOperator.Equal),
                new PassThroughQueueSelectorAttachment("Language", LabelOperator.Equal),
                new PassThroughQueueSelectorAttachment("Product", LabelOperator.Equal),
                new StaticQueueSelectorAttachment( new QueueSelector("UniqueIdentifier", LabelOperator.Equal, new LabelValue(IdPrefix)))
            };

            var classificationPolicyResponse = await administrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(GenerateUniqueId($"{IdPrefix}-cp-pass-through-selector"))
                {
                    QueueSelectors = queueSelector,
                    FallbackQueueId = fallbackQueueResponse.Value.Id,
                });

            var jobLabels = new Dictionary<string, LabelValue>()
            {
                ["Product"] = new LabelValue("O365"),
                ["Region"] = new LabelValue("NA"),
                ["Language"] = new LabelValue("EN")
            };
            var createJob = await client.CreateJobAsync(
                new CreateJobWithClassificationPolicyOptions(
                    GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-{nameof(QueueingWithClassificationPolicyWithPassThroughLabelSelector)}"),
                    channelResponse,
                    classificationPolicyResponse.Value.Id)
                {
                    Labels = jobLabels,
                });

            var job = await Poll(async () => await client.GetJobAsync(createJob.Value.Id),
                x => x.Value.JobStatus == RouterJobStatus.Queued,
                TimeSpan.FromSeconds(10));
            Assert.AreEqual(RouterJobStatus.Queued, job.Value.JobStatus);
            Assert.AreEqual(job.Value.QueueId, queueResponse.Value.Id);
        }

        [Test]
        public async Task QueueingWithClassificationPolicyWithCombiningLabelSelectors()
        {
            RouterClient client = CreateRouterClientWithConnectionString();
            RouterAdministrationClient administrationClient = CreateRouterAdministrationClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-{nameof(QueueingWithClassificationPolicyWithCombiningLabelSelectors)}");
            var distributionPolicyResponse = await administrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                    TimeSpan.FromMinutes(10),
                    new LongestIdleMode(1, 1))
                {
                    Name = "Simple-Queue-Distribution"
                });

            var queue1Labels = new Dictionary<string, LabelValue>()
            {
                ["Region"] = new LabelValue("NA"),
                ["Language"] = new LabelValue("en"),
                ["Product"] = new LabelValue("O365"),
                ["UniqueIdentifier"] = new LabelValue(IdPrefix)
            };
            var queue1Response = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-1"), distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                    Labels = queue1Labels,
                });

            var queue2Labels = new Dictionary<string, LabelValue>()
            {
                ["Region"] = new LabelValue("NA"),
                ["Language"] = new LabelValue("fr"),
                ["Product"] = new LabelValue("O365"),
                ["UniqueIdentifier"] = new LabelValue(IdPrefix)
            };
            var queue2Response = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-2"), distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                    Labels = queue2Labels,
                });

            var fallbackQueueResponse = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-default_Queue"), distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                });

            var queueSelector = new List<QueueSelectorAttachment>()
            {
                new PassThroughQueueSelectorAttachment("Region", LabelOperator.Equal),
                new PassThroughQueueSelectorAttachment("Product", LabelOperator.Equal),
                new ConditionalQueueSelectorAttachment(
                    condition: new ExpressionRule("If(job.Lang = \"EN\", true, false)"),
                    labelSelectors: new List<QueueSelector>()
                    {
                        new QueueSelector("Language", LabelOperator.Equal, new LabelValue("en"))
                    }),
                new ConditionalQueueSelectorAttachment(
                    condition: new ExpressionRule("If(job.Lang = \"FR\", true, false)"),
                    labelSelectors: new List<QueueSelector>()
                    {
                        new QueueSelector("Language", LabelOperator.Equal, new LabelValue("fr"))
                    }),
                new StaticQueueSelectorAttachment( new QueueSelector("UniqueIdentifier", LabelOperator.Equal, new LabelValue(IdPrefix)))
            };

            var classificationPolicyResponse = await administrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(GenerateUniqueId($"{IdPrefix}-combination"))
                {
                    QueueSelectors = queueSelector,
                    FallbackQueueId = fallbackQueueResponse.Value.Id,
                });

            var job1Labels = new Dictionary<string, LabelValue>()
            {
                ["Product"] = new LabelValue("O365"),
                ["Region"] = new LabelValue("NA"),
                ["Lang"] = new LabelValue("EN")
            };
            var createJob1 = await client.CreateJobAsync(
                new CreateJobWithClassificationPolicyOptions(
                    GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-{nameof(QueueingWithClassificationPolicyWithCombiningLabelSelectors)}-1"),
                    channelResponse,
                    classificationPolicyResponse.Value.Id)
                {
                    Labels = job1Labels
                });

            var job1 = await Poll(async () => await client.GetJobAsync(createJob1.Value.Id),
                x => x.Value.JobStatus == RouterJobStatus.Queued,
                TimeSpan.FromSeconds(10));

            var job2Labels = new Dictionary<string, LabelValue>()
            {
                ["Product"] = new LabelValue("O365"),
                ["Region"] = new LabelValue("NA"),
                ["Lang"] = new LabelValue("FR")
            };
            var createJob2 = await client.CreateJobAsync(
                new CreateJobWithClassificationPolicyOptions(
                    GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-{nameof(QueueingWithClassificationPolicyWithCombiningLabelSelectors)}-2"),
                    channelResponse,
                    classificationPolicyResponse.Value.Id)
                {
                    Labels = job2Labels
                });

            var job2 = await Poll(async () => await client.GetJobAsync(createJob2.Value.Id),
                x => x.Value.JobStatus == RouterJobStatus.Queued,
                TimeSpan.FromSeconds(10));

            Assert.AreEqual(RouterJobStatus.Queued, job1.Value.JobStatus);
            Assert.AreEqual(RouterJobStatus.Queued, job2.Value.JobStatus);
            Assert.AreEqual(job1.Value.QueueId, queue1Response.Value.Id);
            Assert.AreEqual(job2.Value.QueueId, queue2Response.Value.Id);
        }
    }
}
