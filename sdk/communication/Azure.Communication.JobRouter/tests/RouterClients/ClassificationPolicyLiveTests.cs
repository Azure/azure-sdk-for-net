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
        /// <inheritdoc />
        public ClassificationPolicyLiveTests(bool isAsync) : base(isAsync)
        {
        }

        #region Classification Policy Tests
        [Test]
        public async Task CreateClassificationPolicyTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            var createQueueResponse = await CreateQueueAsync(nameof(CreateClassificationPolicyTest));

            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}{nameof(CreateClassificationPolicyTest)}");
            var queueSelector = new List<QueueSelectorAttachment>()
            {
                new StaticQueueSelector(new QueueSelector("Id", LabelOperator.Equal, createQueueResponse.Value.Id))
            };
            var workerSelectors = new List<WorkerSelectorAttachment>()
            {
                new StaticWorkerSelector(new WorkerSelector("key", LabelOperator.Equal, "value"))
            };
            var prioritizationRule = new StaticRule(1);

            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(
                classificationPolicyId,
                new CreateClassificationPolicyOptions()
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
                Assert.IsTrue(qs.GetType() == typeof(StaticQueueSelector));
                var staticqs = (StaticQueueSelector)qs;
                Assert.AreEqual(staticqs.LabelSelector.Key, "Id");
                Assert.AreEqual(staticqs.LabelSelector.LabelOperator, LabelOperator.Equal);
                Assert.AreEqual(staticqs.LabelSelector.Value, createQueueResponse.Value.Id);
            });
            Assert.AreEqual(1, createClassificationPolicy.WorkerSelectors.Count);
            Assert.DoesNotThrow(() =>
            {
                var workerSelectors = createClassificationPolicy.WorkerSelectors;
                Assert.AreEqual(workerSelectors.Count, 1);
                var ws = workerSelectors.First();
                Assert.IsTrue(ws.GetType() == typeof(StaticWorkerSelector));
                var staticws = (StaticWorkerSelector)ws;
                Assert.AreEqual("key", staticws.LabelSelector.Key);
                Assert.AreEqual(LabelOperator.Equal, staticws.LabelSelector.LabelOperator);
                Assert.AreEqual("value", staticws.LabelSelector.Value);
            });
            Assert.IsTrue(createClassificationPolicy.PrioritizationRule.GetType() == typeof(StaticRule));
            Assert.IsTrue(string.IsNullOrWhiteSpace(createClassificationPolicy.FallbackQueueId));
            Assert.IsTrue(string.IsNullOrWhiteSpace(createClassificationPolicy.Name));

            var classificationPolicyName = $"{classificationPolicyId}-Name";

            createClassificationPolicyResponse = await routerClient.UpdateClassificationPolicyAsync(
                classificationPolicyId,
                new UpdateClassificationPolicyOptions()
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
                Assert.IsTrue(qs.GetType() == typeof(StaticQueueSelector));
                var staticqs = (StaticQueueSelector)qs;
                Assert.AreEqual(staticqs.LabelSelector.Key, "Id");
                Assert.AreEqual(staticqs.LabelSelector.LabelOperator, LabelOperator.Equal);
                Assert.AreEqual(staticqs.LabelSelector.Value, createQueueResponse.Value.Id);
            });
            Assert.AreEqual(1, createClassificationPolicy.WorkerSelectors.Count);
            Assert.DoesNotThrow(() =>
            {
                var workerSelectors = createClassificationPolicy.WorkerSelectors;
                Assert.AreEqual(workerSelectors.Count, 1);
                var ws = workerSelectors.First();
                Assert.IsTrue(ws.GetType() == typeof(StaticWorkerSelector));
                var staticws = (StaticWorkerSelector)ws;
                Assert.AreEqual("key", staticws.LabelSelector.Key);
                Assert.AreEqual(LabelOperator.Equal, staticws.LabelSelector.LabelOperator);
                Assert.AreEqual("value", staticws.LabelSelector.Value);
            });
            Assert.IsTrue(createClassificationPolicy.PrioritizationRule.GetType() == typeof(StaticRule));
            Assert.IsTrue(!string.IsNullOrWhiteSpace(createClassificationPolicy.FallbackQueueId) && createClassificationPolicy.FallbackQueueId == createQueueResponse.Value.Id);
            Assert.IsFalse(string.IsNullOrWhiteSpace(createClassificationPolicy.Name));

            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId)));
        }

        [Test]
        public async Task CreateEmptyClassificationPolicyTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            var queue = CreateQueueAsync(nameof(CreateEmptyClassificationPolicyTest));

            var classificationPolicyId = $"{IdPrefix}-CPEmpty";
            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(classificationPolicyId, new CreateClassificationPolicyOptions());
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
            RouterClient routerClient = CreateRouterClientWithConnectionString();

            var classificationPolicyId = $"{IdPrefix}-CPPri";
            var classificationPolicyName = $"Priority-ClassificationPolicy";
            var priorityRule = new StaticRule(10);
            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(
                classificationPolicyId, new CreateClassificationPolicyOptions()
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
            RouterClient routerClient = CreateRouterClientWithConnectionString();

            var classificationPolicyId = $"{IdPrefix}-CPQS";
            var classificationPolicyName = $"QueueSelection-ClassificationPolicy";
            var createQueueResponse = await CreateQueueAsync(nameof(CreateQueueSelectionClassificationPolicyTest));
            var queueIdStaticRule = new StaticRule(createQueueResponse.Value.Id);
            var queueSelectionRule = new List<QueueSelectorAttachment>()
            {
                new StaticQueueSelector(new QueueSelector("Id", LabelOperator.Equal, createQueueResponse.Value.Id))
            };
            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(
                classificationPolicyId,
                new CreateClassificationPolicyOptions()
                {
                    Name = classificationPolicyName,
                    QueueSelectors = queueSelectionRule,
                });
            var getClassificationPolicyResponse =
                await routerClient.GetClassificationPolicyAsync(classificationPolicyId);

            Assert.Null(getClassificationPolicyResponse.Value.FallbackQueueId);
            Assert.AreEqual(classificationPolicyName, getClassificationPolicyResponse.Value.Name);
            Assert.AreEqual(1, getClassificationPolicyResponse.Value.QueueSelectors.Count);
            var staticqs = (StaticQueueSelector)getClassificationPolicyResponse.Value.QueueSelectors.First();
            Assert.NotNull(staticqs);
            Assert.Null(getClassificationPolicyResponse.Value.PrioritizationRule);
            Assert.AreEqual(0, getClassificationPolicyResponse.Value.WorkerSelectors.Count);

            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId)));
        }

        [Test]
        public async Task CreateWorkerRequirementsClassificationPolicyTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();

            var classificationPolicyId = $"{IdPrefix}-CPWR";
            var classificationPolicyName = $"Priority-ClassificationPolicy";
            var workerSelectors = new List<WorkerSelectorAttachment>();
            var labelSelectorAttachment = new StaticWorkerSelector(new WorkerSelector("department", LabelOperator.Equal, "sales"));
            workerSelectors.Add(labelSelectorAttachment);
            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(
                classificationPolicyId,
                new CreateClassificationPolicyOptions()
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
