// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core;
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
            JobRouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();
            var createQueueResponse = await CreateQueueAsync(nameof(CreateClassificationPolicyTest));

            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}{nameof(CreateClassificationPolicyTest)}");
            var prioritizationRule = new StaticRouterRule(new RouterValue(1));

            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId)
                {
                    QueueSelectorAttachments = { new StaticQueueSelectorAttachment(new RouterQueueSelector("Id", LabelOperator.Equal, new RouterValue(createQueueResponse.Value.Id))) },
                    WorkerSelectorAttachments = { new StaticWorkerSelectorAttachment(new RouterWorkerSelector("key", LabelOperator.Equal, new RouterValue("value"))) },
                    PrioritizationRule = prioritizationRule
                });

            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId)));
            Assert.NotNull(createClassificationPolicyResponse.Value);

            var createClassificationPolicy = createClassificationPolicyResponse.Value;
            Assert.DoesNotThrow(() =>
            {
                var queueSelectors = createClassificationPolicy.QueueSelectorAttachments;
                Assert.AreEqual(queueSelectors.Count, 1);
                var qs = queueSelectors.First();
                Assert.IsTrue(qs.GetType() == typeof(StaticQueueSelectorAttachment));
                var staticQSelector = (StaticQueueSelectorAttachment)qs;
                Assert.AreEqual(staticQSelector.QueueSelector.Key, "Id");
                Assert.AreEqual(staticQSelector.QueueSelector.LabelOperator, LabelOperator.Equal);
                Assert.AreEqual(staticQSelector.QueueSelector.Value.Value, createQueueResponse.Value.Id);
            });
            Assert.AreEqual(1, createClassificationPolicy.WorkerSelectorAttachments.Count);
            Assert.DoesNotThrow(() =>
            {
                var workerSelectors = createClassificationPolicy.WorkerSelectorAttachments;
                Assert.AreEqual(workerSelectors.Count, 1);
                var ws = workerSelectors.First();
                Assert.IsTrue(ws.GetType() == typeof(StaticWorkerSelectorAttachment));
                var staticWSelector = (StaticWorkerSelectorAttachment)ws;
                Assert.AreEqual("key", staticWSelector.WorkerSelector.Key);
                Assert.AreEqual(LabelOperator.Equal, staticWSelector.WorkerSelector.LabelOperator);
                Assert.AreEqual("value", staticWSelector.WorkerSelector.Value.Value);
            });
            Assert.IsTrue(createClassificationPolicy.PrioritizationRule.GetType() == typeof(StaticRouterRule));
            Assert.IsTrue(string.IsNullOrWhiteSpace(createClassificationPolicy.FallbackQueueId));
            Assert.IsTrue(string.IsNullOrWhiteSpace(createClassificationPolicy.Name));

            var classificationPolicyName = $"{classificationPolicyId}-Name";

            var updateClassificationPolicyResponse = await routerClient.UpdateClassificationPolicyAsync(
                new ClassificationPolicy(classificationPolicyId)
                {
                    FallbackQueueId = createQueueResponse.Value.Id,
                    QueueSelectorAttachments = { new StaticQueueSelectorAttachment(new RouterQueueSelector("Id", LabelOperator.Equal, new RouterValue(createQueueResponse.Value.Id))) },
                    WorkerSelectorAttachments = { new StaticWorkerSelectorAttachment(new RouterWorkerSelector("key", LabelOperator.Equal, new RouterValue("value"))) },
                    PrioritizationRule = prioritizationRule,
                    Name = classificationPolicyName,
                });

            Assert.NotNull(updateClassificationPolicyResponse.Value);

            createClassificationPolicy = updateClassificationPolicyResponse.Value;
            Assert.DoesNotThrow(() =>
            {
                var queueSelectors = createClassificationPolicy.QueueSelectorAttachments;
                Assert.AreEqual(queueSelectors.Count, 1);
                var qs = queueSelectors.First();
                Assert.IsTrue(qs.GetType() == typeof(StaticQueueSelectorAttachment));
                var staticQSelector = (StaticQueueSelectorAttachment)qs;
                Assert.AreEqual(staticQSelector.QueueSelector.Key, "Id");
                Assert.AreEqual(staticQSelector.QueueSelector.LabelOperator, LabelOperator.Equal);
                Assert.AreEqual(staticQSelector.QueueSelector.Value.Value, createQueueResponse.Value.Id);
            });
            Assert.AreEqual(1, createClassificationPolicy.WorkerSelectorAttachments.Count);
            Assert.DoesNotThrow(() =>
            {
                var workerSelectors = createClassificationPolicy.WorkerSelectorAttachments;
                Assert.AreEqual(workerSelectors.Count, 1);
                var ws = workerSelectors.First();
                Assert.IsTrue(ws.GetType() == typeof(StaticWorkerSelectorAttachment));
                var staticWSelector = (StaticWorkerSelectorAttachment)ws;
                Assert.AreEqual("key", staticWSelector.WorkerSelector.Key);
                Assert.AreEqual(LabelOperator.Equal, staticWSelector.WorkerSelector.LabelOperator);
                Assert.AreEqual("value", staticWSelector.WorkerSelector.Value.Value);
            });
            Assert.IsTrue(createClassificationPolicy.PrioritizationRule.GetType() == typeof(StaticRouterRule));
            Assert.IsTrue(!string.IsNullOrWhiteSpace(createClassificationPolicy.FallbackQueueId) && createClassificationPolicy.FallbackQueueId == createQueueResponse.Value.Id);
            Assert.IsFalse(string.IsNullOrWhiteSpace(createClassificationPolicy.Name));

            updateClassificationPolicyResponse.Value.FallbackQueueId = null;
            updateClassificationPolicyResponse.Value.PrioritizationRule = null;
            updateClassificationPolicyResponse.Value.QueueSelectorAttachments.Clear();
            updateClassificationPolicyResponse.Value.WorkerSelectorAttachments.Clear();
            updateClassificationPolicyResponse.Value.Name = $"{classificationPolicyName}-updated";

            updateClassificationPolicyResponse = await routerClient.UpdateClassificationPolicyAsync(
                updateClassificationPolicyResponse.Value);

            var updateClassificationPolicy = updateClassificationPolicyResponse.Value;
            Assert.IsFalse(updateClassificationPolicy.QueueSelectorAttachments.Any());
            Assert.IsFalse(updateClassificationPolicy.WorkerSelectorAttachments.Any());
            Assert.AreEqual(updateClassificationPolicy.Name, $"{classificationPolicyName}-updated");
        }

        [Test]
        public async Task CreateEmptyClassificationPolicyTest()
        {
            JobRouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();
            var queue = CreateQueueAsync(nameof(CreateEmptyClassificationPolicyTest));

            var classificationPolicyId = $"{IdPrefix}-CPEmpty";
            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(new CreateClassificationPolicyOptions(classificationPolicyId));
            var getClassificationPolicyResponse =
                await routerClient.GetClassificationPolicyAsync(classificationPolicyId);

            Assert.Null(getClassificationPolicyResponse.Value.FallbackQueueId);
            Assert.Null(getClassificationPolicyResponse.Value.Name);
            Assert.IsEmpty(getClassificationPolicyResponse.Value.QueueSelectorAttachments);
            Assert.Null(getClassificationPolicyResponse.Value.PrioritizationRule);
            Assert.IsEmpty(getClassificationPolicyResponse.Value.WorkerSelectorAttachments);

            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId)));
        }

        [Test]
        public async Task CreatePrioritizationClassificationPolicyTest()
        {
            JobRouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();

            var classificationPolicyId = $"{IdPrefix}-CPPri";
            var classificationPolicyName = $"Priority-ClassificationPolicy";
            var priorityRule = new StaticRouterRule(new RouterValue(10));
            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId)
                {
                    Name = classificationPolicyName,
                    PrioritizationRule = priorityRule,
                });

            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId)));

            var getClassificationPolicyResponse = await routerClient.GetClassificationPolicyAsync(classificationPolicyId);

            Assert.Null(getClassificationPolicyResponse.Value.FallbackQueueId);
            Assert.AreEqual(classificationPolicyName, getClassificationPolicyResponse.Value.Name);
            Assert.IsEmpty(getClassificationPolicyResponse.Value.QueueSelectorAttachments);
            Assert.IsTrue(getClassificationPolicyResponse.Value.PrioritizationRule.GetType() == typeof(StaticRouterRule));
            Assert.IsEmpty(getClassificationPolicyResponse.Value.WorkerSelectorAttachments);
        }

        [Test]
        public async Task CreateQueueSelectionClassificationPolicyTest()
        {
            JobRouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();

            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}-ClassificationPolicY_w_QSelector");
            var classificationPolicyName = $"QueueSelection-ClassificationPolicy";
            var createQueueResponse = await CreateQueueAsync(nameof(CreateQueueSelectionClassificationPolicyTest));

            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId)
                {
                    Name = classificationPolicyName,
                    QueueSelectorAttachments =
                    {
                        new StaticQueueSelectorAttachment(new RouterQueueSelector("Id", LabelOperator.Equal,
                            new RouterValue(createQueueResponse.Value.Id)))
                    }
                });

            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId)));

            var getClassificationPolicyResponse = await routerClient.GetClassificationPolicyAsync(classificationPolicyId);
            Assert.Null(getClassificationPolicyResponse.Value.FallbackQueueId);
            Assert.AreEqual(classificationPolicyName, getClassificationPolicyResponse.Value.Name);
            Assert.AreEqual(1, getClassificationPolicyResponse.Value.QueueSelectorAttachments.Count);
            var staticQSelector = (StaticQueueSelectorAttachment)getClassificationPolicyResponse.Value.QueueSelectorAttachments.First();
            Assert.NotNull(staticQSelector);
            Assert.Null(getClassificationPolicyResponse.Value.PrioritizationRule);
            Assert.AreEqual(0, getClassificationPolicyResponse.Value.WorkerSelectorAttachments.Count);
        }

        [Test]
        public async Task CreateWorkerRequirementsClassificationPolicyTest()
        {
            JobRouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();

            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}-ClassicationPolicy_w_WSelector");
            var classificationPolicyName = $"Priority-ClassificationPolicy";
            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId)
                {
                    Name = classificationPolicyName,
                    WorkerSelectorAttachments = { new StaticWorkerSelectorAttachment(new RouterWorkerSelector("department", LabelOperator.Equal, new RouterValue("sales"))) }
                });

            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId)));

            var getClassificationPolicyResponse =
                await routerClient.GetClassificationPolicyAsync(classificationPolicyId);

            Assert.Null(getClassificationPolicyResponse.Value.FallbackQueueId);
            Assert.AreEqual(classificationPolicyName, getClassificationPolicyResponse.Value.Name);
            Assert.Null(getClassificationPolicyResponse.Value.PrioritizationRule);
            Assert.IsEmpty(getClassificationPolicyResponse.Value.QueueSelectorAttachments);
            Assert.AreEqual(1, getClassificationPolicyResponse.Value.WorkerSelectorAttachments.Count);
        }

        #endregion Classification Policy Tests
    }
}
