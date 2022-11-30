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

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class ClassificationPolicyLiveTests : RouterLiveTestBase
    {
        public ClassificationPolicyLiveTests(bool isAsync) : base(isAsync)
        {
        }

        #region Classification Policy Tests
        [Test]
        public async Task CreateClassificationPolicyTest()
        {
            RouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();
            var createQueueResponse = await CreateQueueAsync(nameof(CreateClassificationPolicyTest));

            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}{nameof(CreateClassificationPolicyTest)}");
            var queueSelector = new List<QueueSelectorAttachment>()
            {
                new StaticQueueSelectorAttachment(new QueueSelector("Id", LabelOperator.Equal, new LabelValue(createQueueResponse.Value.Id)))
            };
            var workerSelectors = new List<WorkerSelectorAttachment>()
            {
                new StaticWorkerSelectorAttachment(new WorkerSelector("key", LabelOperator.Equal, new LabelValue("value")))
            };
            var prioritizationRule = new StaticRule(new LabelValue(1));

            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId)
                {
                    QueueSelectors = queueSelector,
                    WorkerSelectors = workerSelectors,
                    PrioritizationRule = prioritizationRule
                });

            Assert.NotNull(createClassificationPolicyResponse.Value);

            var createClassificationPolicy = createClassificationPolicyResponse.Value;
            Assert.DoesNotThrow(() =>
            {
                var queueSelectors = createClassificationPolicy.QueueSelectors;
                Assert.AreEqual(queueSelectors.Count, 1);
                var qs = queueSelectors.First();
                Assert.IsTrue(qs.GetType() == typeof(StaticQueueSelectorAttachment));
                var staticQSelector = (StaticQueueSelectorAttachment)qs;
                Assert.AreEqual(staticQSelector.LabelSelector.Key, "Id");
                Assert.AreEqual(staticQSelector.LabelSelector.LabelOperator, LabelOperator.Equal);
                Assert.AreEqual(staticQSelector.LabelSelector.Value.Value, createQueueResponse.Value.Id);
            });
            Assert.AreEqual(1, createClassificationPolicy.WorkerSelectors.Count);
            Assert.DoesNotThrow(() =>
            {
                var workerSelectors = createClassificationPolicy.WorkerSelectors;
                Assert.AreEqual(workerSelectors.Count, 1);
                var ws = workerSelectors.First();
                Assert.IsTrue(ws.GetType() == typeof(StaticWorkerSelectorAttachment));
                var staticWSelector = (StaticWorkerSelectorAttachment)ws;
                Assert.AreEqual("key", staticWSelector.LabelSelector.Key);
                Assert.AreEqual(LabelOperator.Equal, staticWSelector.LabelSelector.LabelOperator);
                Assert.AreEqual("value", staticWSelector.LabelSelector.Value.Value);
            });
            Assert.IsTrue(createClassificationPolicy.PrioritizationRule.GetType() == typeof(StaticRule));
            Assert.IsTrue(string.IsNullOrWhiteSpace(createClassificationPolicy.FallbackQueueId));
            Assert.IsTrue(string.IsNullOrWhiteSpace(createClassificationPolicy.Name));

            var classificationPolicyName = $"{classificationPolicyId}-Name";

            createClassificationPolicyResponse = await routerClient.UpdateClassificationPolicyAsync(
                new UpdateClassificationPolicyOptions(classificationPolicyId)
                {
                    FallbackQueueId = createQueueResponse.Value.Id,
                    QueueSelectors = queueSelector,
                    WorkerSelectors = workerSelectors,
                    PrioritizationRule = prioritizationRule,
                    Name = classificationPolicyName,
                });

            Assert.NotNull(createClassificationPolicyResponse.Value);

            createClassificationPolicy = createClassificationPolicyResponse.Value;
            Assert.DoesNotThrow(() =>
            {
                var queueSelectors = createClassificationPolicy.QueueSelectors;
                Assert.AreEqual(queueSelectors.Count, 1);
                var qs = queueSelectors.First();
                Assert.IsTrue(qs.GetType() == typeof(StaticQueueSelectorAttachment));
                var staticQSelector = (StaticQueueSelectorAttachment)qs;
                Assert.AreEqual(staticQSelector.LabelSelector.Key, "Id");
                Assert.AreEqual(staticQSelector.LabelSelector.LabelOperator, LabelOperator.Equal);
                Assert.AreEqual(staticQSelector.LabelSelector.Value.Value, createQueueResponse.Value.Id);
            });
            Assert.AreEqual(1, createClassificationPolicy.WorkerSelectors.Count);
            Assert.DoesNotThrow(() =>
            {
                var workerSelectors = createClassificationPolicy.WorkerSelectors;
                Assert.AreEqual(workerSelectors.Count, 1);
                var ws = workerSelectors.First();
                Assert.IsTrue(ws.GetType() == typeof(StaticWorkerSelectorAttachment));
                var staticWSelector = (StaticWorkerSelectorAttachment)ws;
                Assert.AreEqual("key", staticWSelector.LabelSelector.Key);
                Assert.AreEqual(LabelOperator.Equal, staticWSelector.LabelSelector.LabelOperator);
                Assert.AreEqual("value", staticWSelector.LabelSelector.Value.Value);
            });
            Assert.IsTrue(createClassificationPolicy.PrioritizationRule.GetType() == typeof(StaticRule));
            Assert.IsTrue(!string.IsNullOrWhiteSpace(createClassificationPolicy.FallbackQueueId) && createClassificationPolicy.FallbackQueueId == createQueueResponse.Value.Id);
            Assert.IsFalse(string.IsNullOrWhiteSpace(createClassificationPolicy.Name));

            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId)));
        }

        [Test]
        public async Task CreateEmptyClassificationPolicyTest()
        {
            RouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();
            var queue = CreateQueueAsync(nameof(CreateEmptyClassificationPolicyTest));

            var classificationPolicyId = $"{IdPrefix}-CPEmpty";
            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(new CreateClassificationPolicyOptions(classificationPolicyId));
            var getClassificationPolicyResponse =
                await routerClient.GetClassificationPolicyAsync(classificationPolicyId);

            Assert.Null(getClassificationPolicyResponse.Value.FallbackQueueId);
            Assert.Null(getClassificationPolicyResponse.Value.Name);
            Assert.IsEmpty(getClassificationPolicyResponse.Value.QueueSelectors);
            Assert.Null(getClassificationPolicyResponse.Value.PrioritizationRule);
            Assert.IsEmpty(getClassificationPolicyResponse.Value.WorkerSelectors);

            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId)));
        }

        [Test]
        public async Task CreatePrioritizationClassificationPolicyTest()
        {
            RouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();

            var classificationPolicyId = $"{IdPrefix}-CPPri";
            var classificationPolicyName = $"Priority-ClassificationPolicy";
            var priorityRule = new StaticRule(new LabelValue(10));
            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId)
                {
                    Name = classificationPolicyName,
                    PrioritizationRule = priorityRule,
                });
            var getClassificationPolicyResponse = await routerClient.GetClassificationPolicyAsync(classificationPolicyId);

            Assert.Null(getClassificationPolicyResponse.Value.FallbackQueueId);
            Assert.AreEqual(classificationPolicyName, getClassificationPolicyResponse.Value.Name);
            Assert.IsEmpty(getClassificationPolicyResponse.Value.QueueSelectors);
            Assert.IsTrue(getClassificationPolicyResponse.Value.PrioritizationRule.GetType() == typeof(StaticRule));
            Assert.IsEmpty(getClassificationPolicyResponse.Value.WorkerSelectors);

            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId)));
        }

        [Test]
        public async Task CreateQueueSelectionClassificationPolicyTest()
        {
            RouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();

            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}-ClassificationPolicY_w_QSelector");
            var classificationPolicyName = $"QueueSelection-ClassificationPolicy";
            var createQueueResponse = await CreateQueueAsync(nameof(CreateQueueSelectionClassificationPolicyTest));
            var queueIdStaticRule = new StaticRule(new LabelValue(createQueueResponse.Value.Id));
            var queueSelectionRule = new List<QueueSelectorAttachment>()
            {
                new StaticQueueSelectorAttachment(new QueueSelector("Id", LabelOperator.Equal, new LabelValue(createQueueResponse.Value.Id)))
            };
            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId)
                {
                    Name = classificationPolicyName,
                    QueueSelectors = queueSelectionRule,
                });
            var getClassificationPolicyResponse =
                await routerClient.GetClassificationPolicyAsync(classificationPolicyId);

            Assert.Null(getClassificationPolicyResponse.Value.FallbackQueueId);
            Assert.AreEqual(classificationPolicyName, getClassificationPolicyResponse.Value.Name);
            Assert.AreEqual(1, getClassificationPolicyResponse.Value.QueueSelectors.Count);
            var staticQSelector = (StaticQueueSelectorAttachment)getClassificationPolicyResponse.Value.QueueSelectors.First();
            Assert.NotNull(staticQSelector);
            Assert.Null(getClassificationPolicyResponse.Value.PrioritizationRule);
            Assert.AreEqual(0, getClassificationPolicyResponse.Value.WorkerSelectors.Count);

            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId)));
        }

        [Test]
        public async Task CreateWorkerRequirementsClassificationPolicyTest()
        {
            RouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();

            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}-ClassicationPolicy_w_WSelector");
            var classificationPolicyName = $"Priority-ClassificationPolicy";
            var workerSelectors = new List<WorkerSelectorAttachment>();
            var labelSelectorAttachment = new StaticWorkerSelectorAttachment(new WorkerSelector("department", LabelOperator.Equal, new LabelValue("sales")));
            workerSelectors.Add(labelSelectorAttachment);
            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId)
                {
                    Name = classificationPolicyName,
                    WorkerSelectors = workerSelectors
                });
            var getClassificationPolicyResponse =
                await routerClient.GetClassificationPolicyAsync(classificationPolicyId);

            Assert.Null(getClassificationPolicyResponse.Value.FallbackQueueId);
            Assert.AreEqual(classificationPolicyName, getClassificationPolicyResponse.Value.Name);
            Assert.Null(getClassificationPolicyResponse.Value.PrioritizationRule);
            Assert.IsEmpty(getClassificationPolicyResponse.Value.QueueSelectors);
            Assert.AreEqual(1, getClassificationPolicyResponse.Value.WorkerSelectors.Count);

            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId)));
        }

        #endregion Classification Policy Tests
    }
}
