// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Models;
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

            var channelResponse = await client.SetChannelAsync(ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}"), "test");
            var distributionPolicyResponse = await client.SetDistributionPolicyAsync(ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}"), TimeSpan.FromMinutes(10), new LongestIdleMode(1, 1), "Simple-Queue-Distribution");
            var queueResponse = await client.SetQueueAsync(ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}"), distributionPolicyResponse.Value.Id, "test");
            var createJob = await client.CreateJobAsync(channelResponse.Value.Id, queueResponse.Value.Id, 1);

            var job = await Poll(async () => await client.GetJobAsync(createJob.Value.Id),
                x => x.Value.JobStatus == JobStatus.Queued,
                TimeSpan.FromSeconds(10));
            Assert.AreEqual(JobStatus.Queued, job.Value.JobStatus);
        }

        [Test]
        public async Task QueueingWithClassificationPolicyWithStaticLabelSelector()
        {
            RouterClient client = CreateRouterClientWithConnectionString();

            var channelResponse = await client.SetChannelAsync(ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}"), "test");
            var distributionPolicyResponse = await client.SetDistributionPolicyAsync(ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}"), TimeSpan.FromMinutes(10), new LongestIdleMode(1, 1), "Simple-Queue-Distribution");
            var queueResponse = await client.SetQueueAsync(ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}"), distributionPolicyResponse.Value.Id, "test");

            var queueSelector = new List<LabelSelectorAttachment>()
            {
                new StaticLabelSelector(new LabelSelector(key: "Id", LabelOperator.Equal, queueResponse.Value.Id))
            };

            var classificationPolicyResponse = await client.SetClassificationPolicyAsync(
                id: ReduceToFiftyCharacters($"{IdPrefix}-cp-static"),
                queueSelector: new QueueLabelSelector(queueSelector));

            var createJob = await client.CreateJobWithClassificationPolicyAsync(
                channelId: channelResponse.Value.Id,
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

            var channelResponse = await client.SetChannelAsync(ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}"), "test");
            var distributionPolicyResponse = await client.SetDistributionPolicyAsync(ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}"), TimeSpan.FromMinutes(10), new LongestIdleMode(1, 1), "Simple-Queue-Distribution");
            var fallbackQueueResponse = await client.SetQueueAsync(ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}-flbkQ"), distributionPolicyResponse.Value.Id, "test");

            var queueSelector = new List<LabelSelectorAttachment>()
            {
                new StaticLabelSelector(new LabelSelector(key: "Id", LabelOperator.Equal, "QueueIdDoesNotExist"))
            };

            var classificationPolicyResponse = await client.SetClassificationPolicyAsync(
                id: ReduceToFiftyCharacters($"{IdPrefix}-cp-static"),
                queueSelector: new QueueLabelSelector(queueSelector),
                fallbackQueueId: fallbackQueueResponse.Value.Id);

            var createJob = await client.CreateJobWithClassificationPolicyAsync(
                channelId: channelResponse.Value.Id,
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

            var channelResponse = await client.SetChannelAsync(ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}"), "test");
            var distributionPolicyResponse = await client.SetDistributionPolicyAsync(ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}"), TimeSpan.FromMinutes(10), new LongestIdleMode(1, 1), "Simple-Queue-Distribution");
            var queueResponse = await client.SetQueueAsync(ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}"), distributionPolicyResponse.Value.Id, "test");
            var fallbackQueueResponse = await client.SetQueueAsync(ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}-flbkQ"), distributionPolicyResponse.Value.Id, "test");

            var queueSelector = new List<LabelSelectorAttachment>()
            {
                new ConditionalLabelSelector(
                    condition: new ExpressionRule("If(job.Product = \"O365\", true, false)"),
                    labelSelectors: new List<LabelSelector>()
                    {
                        new LabelSelector("Id", LabelOperator.Equal, queueResponse.Value.Id)
                    })
            };

            var classificationPolicyResponse = await client.SetClassificationPolicyAsync(
                id: ReduceToFiftyCharacters($"{IdPrefix}-cp-cond"),
                queueSelector: new QueueLabelSelector(queueSelector),
                fallbackQueueId: fallbackQueueResponse.Value.Id);

            var jobLabels = new LabelCollection() {["Product"] = "O365"};
            var createJob = await client.CreateJobWithClassificationPolicyAsync(
                channelId: channelResponse.Value.Id,
                classificationPolicyId: classificationPolicyResponse.Value.Id,
                labels: jobLabels);

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

            var channelResponse = await client.SetChannelAsync(ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}"), "test");
            var distributionPolicyResponse = await client.SetDistributionPolicyAsync(ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}"), TimeSpan.FromMinutes(10), new LongestIdleMode(1, 1), "Simple-Queue-Distribution");

            var queueLabels = new LabelCollection() {["Region"] = "NA", ["Language"] = "EN", ["Product"] = "O365", ["UniqueIdentifier"] = IdPrefix};
            var queueResponse = await client.SetQueueAsync(
                id: ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}-1"),
                distributionPolicyId: distributionPolicyResponse.Value.Id,
                name: "test",
                labels: queueLabels);
            var fallbackQueueResponse = await client.SetQueueAsync(ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}-flbkQ"), distributionPolicyResponse.Value.Id, "test");

            var queueSelector = new List<LabelSelectorAttachment>()
            {
                new PassThroughLabelSelector("Region", LabelOperator.Equal),
                new PassThroughLabelSelector("Language", LabelOperator.Equal),
                new PassThroughLabelSelector("Product", LabelOperator.Equal),
                new StaticLabelSelector( new LabelSelector("UniqueIdentifier", LabelOperator.Equal, IdPrefix))
            };

            var classificationPolicyResponse = await client.SetClassificationPolicyAsync(
                id: ReduceToFiftyCharacters($"{IdPrefix}-cp-psthr"),
                queueSelector: new QueueLabelSelector(queueSelector),
                fallbackQueueId: fallbackQueueResponse.Value.Id);

            var jobLabels = new LabelCollection() { ["Product"] = "O365", ["Region"] = "NA", ["Language"] = "EN"};
            var createJob = await client.CreateJobWithClassificationPolicyAsync(
                channelId: channelResponse.Value.Id,
                classificationPolicyId: classificationPolicyResponse.Value.Id,
                labels: jobLabels);

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

            var channelResponse = await client.SetChannelAsync(ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}"), "test");
            var distributionPolicyResponse = await client.SetDistributionPolicyAsync(ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}"), TimeSpan.FromMinutes(10), new LongestIdleMode(1, 1), "Simple-Queue-Distribution");

            var queue1Labels = new LabelCollection() { ["Region"] = "NA", ["Language"] = "en", ["Product"] = "O365", ["UniqueIdentifier"] = IdPrefix };
            var queue1Response = await client.SetQueueAsync(
                id: ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}-1"),
                distributionPolicyId: distributionPolicyResponse.Value.Id,
                name: "test",
                labels: queue1Labels);

            var queue2Labels = new LabelCollection() { ["Region"] = "NA", ["Language"] = "fr", ["Product"] = "O365", ["UniqueIdentifier"] = IdPrefix };
            var queue2Response = await client.SetQueueAsync(
                id: ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}-2"),
                distributionPolicyId: distributionPolicyResponse.Value.Id,
                name: "test",
                labels: queue2Labels);

            var fallbackQueueResponse = await client.SetQueueAsync(ReduceToFiftyCharacters($"{IdPrefix}-{ScenarioPrefix}-flbkQueue"), distributionPolicyResponse.Value.Id, "test");

            var queueSelector = new List<LabelSelectorAttachment>()
            {
                new PassThroughLabelSelector("Region", LabelOperator.Equal),
                new PassThroughLabelSelector("Product", LabelOperator.Equal),
                new ConditionalLabelSelector(
                    condition: new ExpressionRule("If(job.Lang = \"EN\", true, false)"),
                    labelSelectors: new List<LabelSelector>()
                    {
                        new LabelSelector("Language", LabelOperator.Equal, "en")
                    }),
                new ConditionalLabelSelector(
                    condition: new ExpressionRule("If(job.Lang = \"FR\", true, false)"),
                    labelSelectors: new List<LabelSelector>()
                    {
                        new LabelSelector("Language", LabelOperator.Equal, "fr")
                    }),
                new StaticLabelSelector( new LabelSelector("UniqueIdentifier", LabelOperator.Equal, IdPrefix))
            };

            var classificationPolicyResponse = await client.SetClassificationPolicyAsync(
                id: ReduceToFiftyCharacters($"{IdPrefix}-cmbo"),
                queueSelector: new QueueLabelSelector(queueSelector),
                fallbackQueueId: fallbackQueueResponse.Value.Id);

            var job1Labels = new LabelCollection() { ["Product"] = "O365", ["Region"] = "NA", ["Lang"] = "EN" };
            var createJob1 = await client.CreateJobWithClassificationPolicyAsync(
                channelId: channelResponse.Value.Id,
                classificationPolicyId: classificationPolicyResponse.Value.Id,
                labels: job1Labels);

            var job1 = await Poll(async () => await client.GetJobAsync(createJob1.Value.Id),
                x => x.Value.JobStatus == JobStatus.Queued,
                TimeSpan.FromSeconds(10));

            var job2Labels = new LabelCollection() { ["Product"] = "O365", ["Region"] = "NA", ["Lang"] = "FR" };
            var createJob2 = await client.CreateJobWithClassificationPolicyAsync(
                channelId: channelResponse.Value.Id,
                classificationPolicyId: classificationPolicyResponse.Value.Id,
                labels: job2Labels);

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
