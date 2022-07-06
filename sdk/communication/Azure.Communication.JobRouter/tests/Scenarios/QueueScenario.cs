// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
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

            var channelResponse = GenerateUniqueId($"Channel-SQ-{IdPrefix}-{nameof(QueueScenario)}");
            var distributionPolicyResponse = await client.CreateDistributionPolicyAsync(
                GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                10 * 60,
                new LongestIdleMode(1,
                    1),
                new CreateDistributionPolicyOptions()
                {
                    Name = "Simple-Queue-Distribution"
                });
            var queueResponse = await client.CreateQueueAsync(
                GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                distributionPolicyResponse.Value.Id,
                new CreateQueueOptions()
                {
                    Name = "test",
                });
            var jobId = GenerateUniqueId($"JobId-SQ-{nameof(QueueScenario)}");
            var createJob = await client.CreateJobAsync(
                id: jobId,
                channelId: channelResponse,
                queueId: queueResponse.Value.Id,
                new CreateJobOptions()
                {
                    Priority = 1
                });

            var job = await Poll(async () => await client.GetJobAsync(createJob.Value.Id),
                x => x.Value.JobStatus == JobStatus.Queued,
                TimeSpan.FromSeconds(10));
            Assert.AreEqual(JobStatus.Queued, job.Value.JobStatus);
        }

        [Test]
        public async Task QueueingWithClassificationPolicyWithStaticLabelSelector()
        {
            RouterClient client = CreateRouterClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"Channel-StaticLabel-{IdPrefix}-{nameof(QueueScenario)}");
            var distributionPolicyResponse = await client.CreateDistributionPolicyAsync(
                GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                10 * 60,
                new LongestIdleMode(1, 1),
                new CreateDistributionPolicyOptions()
                {
                    Name = "Simple-Queue-Distribution"
                });
            var queueResponse = await client.CreateQueueAsync(
                GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                distributionPolicyResponse.Value.Id,
                new CreateQueueOptions()
                {
                    Name = "test",
                });

            var queueSelector = new List<QueueSelectorAttachment>()
            {
                new StaticQueueSelector(new QueueSelector(key: "Id", LabelOperator.Equal, new LabelValue(queueResponse.Value.Id)))
            };

            var classificationPolicyResponse = await client.CreateClassificationPolicyAsync(
                id: GenerateUniqueId($"Cp-StaticLabels-{IdPrefix}"),
                new CreateClassificationPolicyOptions()
                {
                    QueueSelectors = queueSelector
                });

            var jobId = GenerateUniqueId($"JobId-StaticLabel-{nameof(QueueScenario)}");
            var createJob = await client.CreateJobWithClassificationPolicyAsync(
                id: jobId,
                channelId: channelResponse,
                classificationPolicyId: classificationPolicyResponse.Value.Id);

            var job = await Poll(async () => await client.GetJobAsync(createJob.Value.Id),
                x => x.Value.JobStatus == JobStatus.Queued,
                TimeSpan.FromSeconds(10));
            Assert.AreEqual(JobStatus.Queued, job.Value.JobStatus);
            Assert.AreEqual(job.Value.QueueId, queueResponse.Value.Id);
        }

        [Test]
        public async Task QueueingWithClassificationPolicyWithFallbackQueue()
        {
            RouterClient client = CreateRouterClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"Channel-FQ-{IdPrefix}-{nameof(QueueScenario)}");
            var distributionPolicyResponse = await client.CreateDistributionPolicyAsync(
                GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                10 * 60,
                new LongestIdleMode(1, 1),
                new CreateDistributionPolicyOptions()
                {
                    Name = "Simple-Queue-Distribution",
                });
            var fallbackQueueResponse = await client.CreateQueueAsync(
                GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-default_Q"),
                distributionPolicyResponse.Value.Id,
                new CreateQueueOptions()
                {
                    Name = "test",
                });

            var queueSelector = new List<QueueSelectorAttachment>()
            {
                new StaticQueueSelector(new QueueSelector(key: "Id", LabelOperator.Equal, new LabelValue("QueueIdDoesNotExist")))
            };

            var classificationPolicyResponse = await client.CreateClassificationPolicyAsync(
                id: GenerateUniqueId($"Cp-default_Q-{IdPrefix}"),
                new CreateClassificationPolicyOptions()
                {
                    QueueSelectors = queueSelector,
                    FallbackQueueId = fallbackQueueResponse.Value.Id,
                });

            var jobId = GenerateUniqueId($"JobId-default_Q-{nameof(QueueScenario)}");
            var createJob = await client.CreateJobWithClassificationPolicyAsync(
                id: jobId,
                channelId: channelResponse,
                classificationPolicyId: classificationPolicyResponse.Value.Id);

            var job = await Poll(async () => await client.GetJobAsync(createJob.Value.Id),
                x => x.Value.JobStatus == JobStatus.Queued,
                TimeSpan.FromSeconds(10));
            Assert.AreEqual(JobStatus.Queued, job.Value.JobStatus);
            Assert.AreEqual(job.Value.QueueId, fallbackQueueResponse.Value.Id);
        }

        [Test]
        public async Task QueueingWithClassificationPolicyWithConditionalLabelSelector()
        {
            RouterClient client = CreateRouterClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"Channel-CPWithConditionalLabels-{IdPrefix}-{nameof(QueueScenario)}");
            var distributionPolicyResponse = await client.CreateDistributionPolicyAsync(
                GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                10 * 60,
                new LongestIdleMode(1, 1),
                new CreateDistributionPolicyOptions()
                {
                    Name = "Simple-Queue-Distribution"
                });
            var queueResponse = await client.CreateQueueAsync(
                GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                distributionPolicyResponse.Value.Id,
                new CreateQueueOptions()
                {
                    Name = "test",
                });
            var fallbackQueueResponse = await client.CreateQueueAsync(
                GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-default_Q"),
                distributionPolicyResponse.Value.Id,
                new CreateQueueOptions()
                {
                    Name = "test"
                });

            var queueSelector = new List<QueueSelectorAttachment>()
            {
                new ConditionalQueueSelector(
                    condition: new ExpressionRule("If(job.Product = \"O365\", true, false)"),
                    labelSelectors: new List<QueueSelector>()
                    {
                        new QueueSelector("Id", LabelOperator.Equal, new LabelValue(queueResponse.Value.Id))
                    })
            };

            var classificationPolicyResponse = await client.CreateClassificationPolicyAsync(
                id: GenerateUniqueId($"{IdPrefix}-cp-conditional"),
                new CreateClassificationPolicyOptions()
                {
                    QueueSelectors = queueSelector,
                    FallbackQueueId = fallbackQueueResponse.Value.Id,
                });

            var jobLabels = new LabelCollection() {["Product"] = new LabelValue("O365") };
            var createJob = await client.CreateJobWithClassificationPolicyAsync(
                id: GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                channelId: channelResponse,
                classificationPolicyId: classificationPolicyResponse.Value.Id,
                new CreateJobWithClassificationPolicyOptions()
                {
                    Labels = jobLabels,
                });

            var job = await Poll(async () => await client.GetJobAsync(createJob.Value.Id),
                x => x.Value.JobStatus == JobStatus.Queued,
                TimeSpan.FromSeconds(10));
            Assert.AreEqual(JobStatus.Queued, job.Value.JobStatus);
            Assert.AreEqual(job.Value.QueueId, queueResponse.Value.Id);
        }

        [Test]
        public async Task QueueingWithClassificationPolicyWithPassThroughLabelSelector()
        {
            RouterClient client = CreateRouterClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-{nameof(QueueingWithClassificationPolicyWithPassThroughLabelSelector)}");
            var distributionPolicyResponse = await client.CreateDistributionPolicyAsync(
                GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                10 * 60,
                new LongestIdleMode(1, 1),
                new CreateDistributionPolicyOptions()
                {
                    Name = "Simple-Queue-Distribution",
                });

            var queueLabels = new LabelCollection()
            {
                ["Region"] = new LabelValue("NA"),
                ["Language"] = new LabelValue("EN"),
                ["Product"] = new LabelValue("O365"),
                ["UniqueIdentifier"] = new LabelValue(IdPrefix)
            };
            var queueResponse = await client.CreateQueueAsync(
                id: GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-1"),
                distributionPolicyId: distributionPolicyResponse.Value.Id,
                new CreateQueueOptions()
                {
                    Name = "test",
                    Labels = queueLabels
                });
            var fallbackQueueResponse = await client.CreateQueueAsync(
                GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-default_Q"),
                distributionPolicyResponse.Value.Id,
                new CreateQueueOptions()
                {
                    Name = "test",
                });

            var queueSelector = new List<QueueSelectorAttachment>()
            {
                new PassThroughQueueSelector("Region", LabelOperator.Equal),
                new PassThroughQueueSelector("Language", LabelOperator.Equal),
                new PassThroughQueueSelector("Product", LabelOperator.Equal),
                new StaticQueueSelector( new QueueSelector("UniqueIdentifier", LabelOperator.Equal, new LabelValue(IdPrefix)))
            };

            var classificationPolicyResponse = await client.CreateClassificationPolicyAsync(
                id: GenerateUniqueId($"{IdPrefix}-cp-pass-through-selector"),
                new CreateClassificationPolicyOptions()
                {
                    QueueSelectors = queueSelector,
                    FallbackQueueId = fallbackQueueResponse.Value.Id,
                });

            var jobLabels = new LabelCollection()
            {
                ["Product"] = new LabelValue("O365"),
                ["Region"] = new LabelValue("NA"),
                ["Language"] = new LabelValue("EN")
            };
            var createJob = await client.CreateJobWithClassificationPolicyAsync(
                id: GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-{nameof(QueueingWithClassificationPolicyWithPassThroughLabelSelector)}"),
                channelId: channelResponse,
                classificationPolicyId: classificationPolicyResponse.Value.Id,
                new CreateJobWithClassificationPolicyOptions()
                {
                    Labels = jobLabels,
                });

            var job = await Poll(async () => await client.GetJobAsync(createJob.Value.Id),
                x => x.Value.JobStatus == JobStatus.Queued,
                TimeSpan.FromSeconds(10));
            Assert.AreEqual(JobStatus.Queued, job.Value.JobStatus);
            Assert.AreEqual(job.Value.QueueId, queueResponse.Value.Id);
        }

        [Test]
        public async Task QueueingWithClassificationPolicyWithCombiningLabelSelectors()
        {
            RouterClient client = CreateRouterClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-{nameof(QueueingWithClassificationPolicyWithCombiningLabelSelectors)}");
            var distributionPolicyResponse = await client.CreateDistributionPolicyAsync(
                GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                10 * 60,
                new LongestIdleMode(1, 1),
                new CreateDistributionPolicyOptions()
                {
                    Name = "Simple-Queue-Distribution"
                });

            var queue1Labels = new LabelCollection()
            {
                ["Region"] = new LabelValue("NA"),
                ["Language"] = new LabelValue("en"),
                ["Product"] = new LabelValue("O365"),
                ["UniqueIdentifier"] = new LabelValue(IdPrefix)
            };
            var queue1Response = await client.CreateQueueAsync(
                id: GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-1"),
                distributionPolicyId: distributionPolicyResponse.Value.Id,
                new CreateQueueOptions()
                {
                    Name = "test",
                    Labels = queue1Labels,
                });

            var queue2Labels = new LabelCollection()
            {
                ["Region"] = new LabelValue("NA"),
                ["Language"] = new LabelValue("fr"),
                ["Product"] = new LabelValue("O365"),
                ["UniqueIdentifier"] = new LabelValue(IdPrefix)
            };
            var queue2Response = await client.CreateQueueAsync(
                id: GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-2"),
                distributionPolicyId: distributionPolicyResponse.Value.Id,
                new CreateQueueOptions()
                {
                    Name = "test",
                    Labels = queue2Labels,
                });

            var fallbackQueueResponse = await client.CreateQueueAsync(
                GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-default_Queue"),
                distributionPolicyResponse.Value.Id,
                new CreateQueueOptions()
                {
                    Name = "test",
                });

            var queueSelector = new List<QueueSelectorAttachment>()
            {
                new PassThroughQueueSelector("Region", LabelOperator.Equal),
                new PassThroughQueueSelector("Product", LabelOperator.Equal),
                new ConditionalQueueSelector(
                    condition: new ExpressionRule("If(job.Lang = \"EN\", true, false)"),
                    labelSelectors: new List<QueueSelector>()
                    {
                        new QueueSelector("Language", LabelOperator.Equal, new LabelValue("en"))
                    }),
                new ConditionalQueueSelector(
                    condition: new ExpressionRule("If(job.Lang = \"FR\", true, false)"),
                    labelSelectors: new List<QueueSelector>()
                    {
                        new QueueSelector("Language", LabelOperator.Equal, new LabelValue("fr"))
                    }),
                new StaticQueueSelector( new QueueSelector("UniqueIdentifier", LabelOperator.Equal, new LabelValue(IdPrefix)))
            };

            var classificationPolicyResponse = await client.CreateClassificationPolicyAsync(
                id: GenerateUniqueId($"{IdPrefix}-combination"),
                new CreateClassificationPolicyOptions()
                {
                    QueueSelectors = queueSelector,
                    FallbackQueueId = fallbackQueueResponse.Value.Id,
                });

            var job1Labels = new LabelCollection()
            {
                ["Product"] = new LabelValue("O365"),
                ["Region"] = new LabelValue("NA"),
                ["Lang"] = new LabelValue("EN")
            };
            var createJob1 = await client.CreateJobWithClassificationPolicyAsync(
                id: GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-{nameof(QueueingWithClassificationPolicyWithCombiningLabelSelectors)}-1"),
                channelId: channelResponse,
                classificationPolicyId: classificationPolicyResponse.Value.Id,
                new CreateJobWithClassificationPolicyOptions()
                {
                    Labels = job1Labels
                });

            var job1 = await Poll(async () => await client.GetJobAsync(createJob1.Value.Id),
                x => x.Value.JobStatus == JobStatus.Queued,
                TimeSpan.FromSeconds(10));

            var job2Labels = new LabelCollection()
            {
                ["Product"] = new LabelValue("O365"),
                ["Region"] = new LabelValue("NA"),
                ["Lang"] = new LabelValue("FR")
            };
            var createJob2 = await client.CreateJobWithClassificationPolicyAsync(
                id: GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-{nameof(QueueingWithClassificationPolicyWithCombiningLabelSelectors)}-2"),
                channelId: channelResponse,
                classificationPolicyId: classificationPolicyResponse.Value.Id,
                new CreateJobWithClassificationPolicyOptions()
                {
                    Labels = job2Labels
                });

            var job2 = await Poll(async () => await client.GetJobAsync(createJob2.Value.Id),
                x => x.Value.JobStatus == JobStatus.Queued,
                TimeSpan.FromSeconds(10));

            Assert.AreEqual(JobStatus.Queued, job1.Value.JobStatus);
            Assert.AreEqual(JobStatus.Queued, job2.Value.JobStatus);
            Assert.AreEqual(job1.Value.QueueId, queue1Response.Value.Id);
            Assert.AreEqual(job2.Value.QueueId, queue2Response.Value.Id);
        }
    }
}
