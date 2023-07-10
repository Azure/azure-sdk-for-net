﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
    [Ignore("enable after deployment with matching changes")]
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

            var channelResponse = GenerateUniqueId($"Channel-SQ-{IdPrefix}-{nameof(QueueScenario)}");
            var distributionPolicyResponse = await administrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"), TimeSpan.FromMinutes(10),
                    new LongestIdleMode()) { Name = "Simple-Queue-Distribution" });
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
                x => x.Value.Status == RouterJobStatus.Queued,
                TimeSpan.FromSeconds(10));
            Assert.AreEqual(RouterJobStatus.Queued, job.Value.Status);
        }

        [Test]
        public async Task QueueingWithClassificationPolicyWithStaticLabelSelector()
        {
            JobRouterClient client = CreateRouterClientWithConnectionString();
            JobRouterAdministrationClient administrationClient = CreateRouterAdministrationClientWithConnectionString();

            var channelResponse = GenerateUniqueId($"Channel-StaticLabel-{IdPrefix}-{nameof(QueueScenario)}");
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
                    QueueSelectors = {
                        new StaticQueueSelectorAttachment(new RouterQueueSelector(key: "Id", LabelOperator.Equal, new LabelValue(queueResponse.Value.Id)))
                    }
                });

            var jobId = GenerateUniqueId($"JobId-StaticLabel-{nameof(QueueScenario)}");
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

            var channelResponse = GenerateUniqueId($"Channel-FQ-{IdPrefix}-{nameof(QueueScenario)}");
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
                    QueueSelectors = {
                        new StaticQueueSelectorAttachment(new RouterQueueSelector(key: "Id", LabelOperator.Equal, new LabelValue("QueueIdDoesNotExist")))
                    },
                    FallbackQueueId = fallbackQueueResponse.Value.Id,
                });

            var jobId = GenerateUniqueId($"JobId-default_Q-{nameof(QueueScenario)}");
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

            var channelResponse = GenerateUniqueId($"Channel-CPWithConditionalLabels-{IdPrefix}-{nameof(QueueScenario)}");
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
                    QueueSelectors = {
                        new ConditionalQueueSelectorAttachment(
                            condition: new ExpressionRule("If(job.Product = \"O365\", true, false)"),
                            queueSelectors: new List<RouterQueueSelector>()
                            {
                                new RouterQueueSelector("Id", LabelOperator.Equal, new LabelValue(queueResponse.Value.Id))
                            })
                    },
                    FallbackQueueId = fallbackQueueResponse.Value.Id,
                });

            var createJob = await client.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}"), channelResponse, classificationPolicyResponse.Value.Id)
                {
                    Labels = { ["Product"] = new LabelValue("O365") },
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
                        ["Region"] = new LabelValue($"{uniquePrefix}NA"),
                        ["Language"] = new LabelValue($"{uniquePrefix}EN"),
                        ["Product"] = new LabelValue($"{uniquePrefix}O365")
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
                    QueueSelectors = {
                        new PassThroughQueueSelectorAttachment("Region", LabelOperator.Equal),
                        new PassThroughQueueSelectorAttachment("Language", LabelOperator.Equal),
                        new PassThroughQueueSelectorAttachment("Product", LabelOperator.Equal),
                        new StaticQueueSelectorAttachment(new RouterQueueSelector("Id", LabelOperator.Equal, new LabelValue(uniquePrefix))),
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
                        ["Product"] = new LabelValue($"{uniquePrefix}O365"),
                        ["Region"] = new LabelValue($"{uniquePrefix}NA"),
                        ["Language"] = new LabelValue($"{uniquePrefix}EN")
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
                        ["Region"] = new LabelValue($"{uniquePrefix}NA"),
                        ["Language"] = new LabelValue($"{uniquePrefix}en"),
                        ["Product"] = new LabelValue($"{uniquePrefix}O365"),
                        ["UniquePrefix"] = new LabelValue(uniquePrefix),
                    },
                });

            var queue2Response = await administrationClient.CreateQueueAsync(
                new CreateQueueOptions($"{uniquePrefix}2", distributionPolicyResponse.Value.Id)
                {
                    Name = "test",
                    Labels = {
                        ["Region"] = new LabelValue($"{uniquePrefix}NA"),
                        ["Language"] = new LabelValue($"{uniquePrefix}fr"),
                        ["Product"] = new LabelValue($"{uniquePrefix}O365"),
                        ["UniquePrefix"] = new LabelValue(uniquePrefix),
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
                    QueueSelectors = {
                        new PassThroughQueueSelectorAttachment("Region", LabelOperator.Equal),
                        new PassThroughQueueSelectorAttachment("Product", LabelOperator.Equal),
                        new ConditionalQueueSelectorAttachment(
                            condition: new ExpressionRule($"If(job.Lang = \"{uniquePrefix}EN\", true, false)"),
                            queueSelectors: new List<RouterQueueSelector>()
                            {
                                new RouterQueueSelector("Language", LabelOperator.Equal, new LabelValue($"{uniquePrefix}en"))
                            }),
                        new ConditionalQueueSelectorAttachment(
                            condition: new ExpressionRule($"If(job.Lang = \"{uniquePrefix}FR\", true, false)"),
                            queueSelectors: new List<RouterQueueSelector>()
                            {
                                new RouterQueueSelector("Language", LabelOperator.Equal, new LabelValue($"{uniquePrefix}fr"))
                            }),
                        new StaticQueueSelectorAttachment(new RouterQueueSelector("UniquePrefix", LabelOperator.Equal, new LabelValue(uniquePrefix)))
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
                        ["Product"] = new LabelValue($"{uniquePrefix}O365"),
                        ["Region"] = new LabelValue($"{uniquePrefix}NA"),
                        ["Lang"] = new LabelValue($"{uniquePrefix}EN")
                    }
                });

            var job1 = await Poll(async () => await client.GetJobAsync(createJob1.Value.Id),
                x => x.Value.Status == RouterJobStatus.Queued,
                TimeSpan.FromSeconds(10));

            var job2Labels = new Dictionary<string, LabelValue>()
            ;
            var createJob2 = await client.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(
                    GenerateUniqueId($"{IdPrefix}-{ScenarioPrefix}-{nameof(QueueingWithClassificationPolicyWithCombiningLabelSelectors)}-2"),
                    channelResponse,
                    classificationPolicyResponse.Value.Id)
                {
                    Labels = {
                        ["Product"] = new LabelValue($"{uniquePrefix}O365"),
                        ["Region"] = new LabelValue($"{uniquePrefix}NA"),
                        ["Lang"] = new LabelValue($"{uniquePrefix}FR")
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
