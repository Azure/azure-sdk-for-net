// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            JobRouterClient client = CreateRouterClientWithConnectionString();
            JobRouterAdministrationClient administrationClient = CreateRouterAdministrationClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"Channel-SQ-{IdPrefix}-{ScenarioPrefix}");
            var distributionPolicyResponse = await administrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"), TimeSpan.FromMinutes(10),
                    new LongestIdleMode()) { Name = "Simple-Queue-Distribution" });
            var queueResponse = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                    distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                });
            var jobId = GenerateUniqueId($"JobId-SQ-{ScenarioPrefix}");
            var createJob = await client.CreateJobAsync(
                new CreateJobOptions(jobId, channelResponse, queueResponse.Value.Id)
                {
                    Priority = 1
                });

            var job = await Poll(async () => await client.GetJobAsync(createJob.Value.Id),
                x => x.Value.Status == RouterJobStatus.Queued,
                TimeSpan.FromSeconds(10));
            Assert.AreEqual(RouterJobStatus.Queued, job.Value.Status);
        }

        [Test]
        public async Task QueueingWithClassificationPolicyWithStaticLabelSelector()
        {
            JobRouterClient client = CreateRouterClientWithConnectionString();
            JobRouterAdministrationClient administrationClient = CreateRouterAdministrationClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"Channel-StaticLabel-{IdPrefix}-{ScenarioPrefix}");
            var distributionPolicyResponse = await administrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"), TimeSpan.FromMinutes(10),
                    new LongestIdleMode()) { Name = "Simple-Queue-Distribution" });
            var queueResponse = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                    distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                });

            var classificationPolicyResponse = await administrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(GenerateUniqueId($"Cp-StaticLabels-{IdPrefix}"))
                {
                    QueueSelectorAttachments = {
                        new StaticQueueSelectorAttachment(new RouterQueueSelector(key: "Id", LabelOperator.Equal, new RouterValue(queueResponse.Value.Id)))
                    }
                });

            var jobId = GenerateUniqueId($"JobId-StaticLabel-{ScenarioPrefix}");
            var createJob = await client.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(jobId, channelResponse, classificationPolicyResponse.Value.Id));

            var job = await Poll(async () => await client.GetJobAsync(createJob.Value.Id),
                x => x.Value.Status == RouterJobStatus.Queued,
                TimeSpan.FromSeconds(10));
            Assert.AreEqual(RouterJobStatus.Queued, job.Value.Status);
            Assert.AreEqual(job.Value.QueueId, queueResponse.Value.Id);
        }

        [Test]
        public async Task QueueingWithClassificationPolicyWithFallbackQueue()
        {
            JobRouterClient client = CreateRouterClientWithConnectionString();
            JobRouterAdministrationClient administrationClient = CreateRouterAdministrationClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"Channel-FQ-{IdPrefix}-{ScenarioPrefix}");
            var distributionPolicyResponse = await administrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"), TimeSpan.FromMinutes(10),
                    new LongestIdleMode()) { Name = "Simple-Queue-Distribution", });
            var fallbackQueueResponse = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-default_Q"),
                    distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                });

            var classificationPolicyResponse = await administrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(GenerateUniqueId($"Cp-default_Q-{IdPrefix}"))
                {
                    QueueSelectorAttachments = {
                        new StaticQueueSelectorAttachment(new RouterQueueSelector(key: "Id", LabelOperator.Equal, new RouterValue("QueueIdDoesNotExist")))
                    },
                    FallbackQueueId = fallbackQueueResponse.Value.Id,
                });

            var jobId = GenerateUniqueId($"JobId-default_Q-{ScenarioPrefix}");
            var createJob = await client.CreateJobWithClassificationPolicyAsync(new CreateJobWithClassificationPolicyOptions(jobId, channelResponse, classificationPolicyResponse.Value.Id));

            var job = await Poll(async () => await client.GetJobAsync(createJob.Value.Id),
                x => x.Value.Status == RouterJobStatus.Queued,
                TimeSpan.FromSeconds(10));
            Assert.AreEqual(RouterJobStatus.Queued, job.Value.Status);
            Assert.AreEqual(job.Value.QueueId, fallbackQueueResponse.Value.Id);
        }

        [Test]
        public async Task QueueingWithClassificationPolicyWithConditionalLabelSelector()
        {
            JobRouterClient client = CreateRouterClientWithConnectionString();
            JobRouterAdministrationClient administrationClient = CreateRouterAdministrationClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"Channel-CPWithConditionalLabels-{IdPrefix}-{ScenarioPrefix}");
            var distributionPolicyResponse = await administrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"), TimeSpan.FromMinutes(10),
                    new LongestIdleMode()) { Name = "Simple-Queue-Distribution" });
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

            var classificationPolicyResponse = await administrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(GenerateUniqueId($"{IdPrefix}-cp-conditional"))
                {
                    QueueSelectorAttachments = {
                        new ConditionalQueueSelectorAttachment(
                            condition: new ExpressionRouterRule("If(job.Product = \"O365\", true, false)"),
                            queueSelectors: new List<RouterQueueSelector>()
                            {
                                new RouterQueueSelector("Id", LabelOperator.Equal, new RouterValue(queueResponse.Value.Id))
                            })
                    },
                    FallbackQueueId = fallbackQueueResponse.Value.Id,
                });

            var createJob = await client.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"), channelResponse, classificationPolicyResponse.Value.Id)
                {
                    Labels = { ["Product"] = new RouterValue("O365") },
                });

            var job = await Poll(async () => await client.GetJobAsync(createJob.Value.Id),
                x => x.Value.Status == RouterJobStatus.Queued,
                TimeSpan.FromSeconds(10));

            Assert.AreEqual(RouterJobStatus.Queued, job.Value.Status);
            Assert.AreEqual(job.Value.QueueId, queueResponse.Value.Id);
        }

        [Test]
        public async Task QueueingWithClassificationPolicyWithPassThroughLabelSelector()
        {
            JobRouterClient client = CreateRouterClientWithConnectionString();
            JobRouterAdministrationClient administrationClient = CreateRouterAdministrationClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-{nameof(QueueingWithClassificationPolicyWithPassThroughLabelSelector)}");
            var distributionPolicyResponse = await administrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                    TimeSpan.FromMinutes(10),
                    new LongestIdleMode()) { Name = "Simple-Queue-Distribution", });

            var uniquePrefix = GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-3");

            var queueResponse = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions(uniquePrefix, distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                    Labels = {
                        ["Region"] = new RouterValue($"{uniquePrefix}NA"),
                        ["Language"] = new RouterValue($"{uniquePrefix}EN"),
                        ["Product"] = new RouterValue($"{uniquePrefix}O365")
                    }
                });
            var fallbackQueueResponse = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-default_Q"),
                    distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                });

            var classificationPolicyResponse = await administrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(GenerateUniqueId($"{IdPrefix}-cp-pass-through-selector"))
                {
                    QueueSelectorAttachments = {
                        new PassThroughQueueSelectorAttachment("Region", LabelOperator.Equal),
                        new PassThroughQueueSelectorAttachment("Language", LabelOperator.Equal),
                        new PassThroughQueueSelectorAttachment("Product", LabelOperator.Equal),
                        new StaticQueueSelectorAttachment(new RouterQueueSelector("Id", LabelOperator.Equal, new RouterValue(uniquePrefix))),
                    },
                    FallbackQueueId = fallbackQueueResponse.Value.Id,
                });

            var createJob = await client.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(
                    GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-{nameof(QueueingWithClassificationPolicyWithPassThroughLabelSelector)}"),
                    channelResponse,
                    classificationPolicyResponse.Value.Id)
                {
                    Labels = {
                        ["Product"] = new RouterValue($"{uniquePrefix}O365"),
                        ["Region"] = new RouterValue($"{uniquePrefix}NA"),
                        ["Language"] = new RouterValue($"{uniquePrefix}EN")
                    },
                });

            var job = await Poll(async () => await client.GetJobAsync(createJob.Value.Id),
                x => x.Value.Status == RouterJobStatus.Queued,
                TimeSpan.FromSeconds(10));
            Assert.AreEqual(RouterJobStatus.Queued, job.Value.Status);
            Assert.AreEqual(job.Value.QueueId, queueResponse.Value.Id);
        }

        [Test]
        public async Task QueueingWithClassificationPolicyWithCombiningLabelSelectors()
        {
            JobRouterClient client = CreateRouterClientWithConnectionString();
            JobRouterAdministrationClient administrationClient = CreateRouterAdministrationClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-{nameof(QueueingWithClassificationPolicyWithCombiningLabelSelectors)}");
            var distributionPolicyResponse = await administrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"),
                    TimeSpan.FromMinutes(10),
                    new LongestIdleMode()) { Name = "Simple-Queue-Distribution" });

            var uniquePrefix = GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}");

            var queue1Response = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions($"{uniquePrefix}1", distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                    Labels = {
                        ["Region"] = new RouterValue($"{uniquePrefix}NA"),
                        ["Language"] = new RouterValue($"{uniquePrefix}en"),
                        ["Product"] = new RouterValue($"{uniquePrefix}O365"),
                        ["UniquePrefix"] = new RouterValue(uniquePrefix),
                    },
                });

            var queue2Response = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions($"{uniquePrefix}2", distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                    Labels = {
                        ["Region"] = new RouterValue($"{uniquePrefix}NA"),
                        ["Language"] = new RouterValue($"{uniquePrefix}fr"),
                        ["Product"] = new RouterValue($"{uniquePrefix}O365"),
                        ["UniquePrefix"] = new RouterValue(uniquePrefix),
                    },
                });

            var fallbackQueueResponse = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-default_Queue"), distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                });

            var classificationPolicyResponse = await administrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(GenerateUniqueId($"{IdPrefix}-combination"))
                {
                    QueueSelectorAttachments = {
                        new PassThroughQueueSelectorAttachment("Region", LabelOperator.Equal),
                        new PassThroughQueueSelectorAttachment("Product", LabelOperator.Equal),
                        new ConditionalQueueSelectorAttachment(
                            condition: new ExpressionRouterRule($"If(job.Lang = \"{uniquePrefix}EN\", true, false)"),
                            queueSelectors: new List<RouterQueueSelector>()
                            {
                                new RouterQueueSelector("Language", LabelOperator.Equal, new RouterValue($"{uniquePrefix}en"))
                            }),
                        new ConditionalQueueSelectorAttachment(
                            condition: new ExpressionRouterRule($"If(job.Lang = \"{uniquePrefix}FR\", true, false)"),
                            queueSelectors: new List<RouterQueueSelector>()
                            {
                                new RouterQueueSelector("Language", LabelOperator.Equal, new RouterValue($"{uniquePrefix}fr"))
                            }),
                        new StaticQueueSelectorAttachment(new RouterQueueSelector("UniquePrefix", LabelOperator.Equal, new RouterValue(uniquePrefix)))
                    },
                    FallbackQueueId = fallbackQueueResponse.Value.Id,
                });

            var createJob1 = await client.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(
                    GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-{nameof(QueueingWithClassificationPolicyWithCombiningLabelSelectors)}-1"),
                    channelResponse,
                    classificationPolicyResponse.Value.Id)
                {
                    Labels = {
                        ["Product"] = new RouterValue($"{uniquePrefix}O365"),
                        ["Region"] = new RouterValue($"{uniquePrefix}NA"),
                        ["Lang"] = new RouterValue($"{uniquePrefix}EN")
                    }
                });

            var job1 = await Poll(async () => await client.GetJobAsync(createJob1.Value.Id),
                x => x.Value.Status == RouterJobStatus.Queued,
                TimeSpan.FromSeconds(10));

            var job2Labels = new Dictionary<string, RouterValue>()
            ;
            var createJob2 = await client.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(
                    GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-{nameof(QueueingWithClassificationPolicyWithCombiningLabelSelectors)}-2"),
                    channelResponse,
                    classificationPolicyResponse.Value.Id)
                {
                    Labels = {
                        ["Product"] = new RouterValue($"{uniquePrefix}O365"),
                        ["Region"] = new RouterValue($"{uniquePrefix}NA"),
                        ["Lang"] = new RouterValue($"{uniquePrefix}FR")
                    }
                });

            var job2 = await Poll(async () => await client.GetJobAsync(createJob2.Value.Id),
                x => x.Value.Status == RouterJobStatus.Queued,
                TimeSpan.FromSeconds(10));

            Assert.AreEqual(RouterJobStatus.Queued, job1.Value.Status);
            Assert.AreEqual(RouterJobStatus.Queued, job2.Value.Status);
            Assert.AreEqual(job1.Value.QueueId, queue1Response.Value.Id);
            Assert.AreEqual(job2.Value.QueueId, queue2Response.Value.Id);
        }
    }
}
