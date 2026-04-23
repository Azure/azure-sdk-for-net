// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;
using NUnit.Framework.Legacy;

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
            ClassicAssert.NotNull(createClassificationPolicyResponse.Value);

            var createClassificationPolicy = createClassificationPolicyResponse.Value;
            ClassicAssert.DoesNotThrow(() =>
            {
                var queueSelectors = createClassificationPolicy.QueueSelectorAttachments;
                ClassicAssert.AreEqual(queueSelectors.Count, 1);
                var qs = queueSelectors.First();
                ClassicAssert.IsTrue(qs.GetType() == typeof(StaticQueueSelectorAttachment));
                var staticQSelector = (StaticQueueSelectorAttachment)qs;
                ClassicAssert.AreEqual(staticQSelector.QueueSelector.Key, "Id");
                ClassicAssert.AreEqual(staticQSelector.QueueSelector.LabelOperator, LabelOperator.Equal);
                ClassicAssert.AreEqual(staticQSelector.QueueSelector.Value.Value, createQueueResponse.Value.Id);
            });
            ClassicAssert.AreEqual(1, createClassificationPolicy.WorkerSelectorAttachments.Count);
            ClassicAssert.DoesNotThrow(() =>
            {
                var workerSelectors = createClassificationPolicy.WorkerSelectorAttachments;
                ClassicAssert.AreEqual(workerSelectors.Count, 1);
                var ws = workerSelectors.First();
                ClassicAssert.IsTrue(ws.GetType() == typeof(StaticWorkerSelectorAttachment));
                var staticWSelector = (StaticWorkerSelectorAttachment)ws;
                ClassicAssert.AreEqual("key", staticWSelector.WorkerSelector.Key);
                ClassicAssert.AreEqual(LabelOperator.Equal, staticWSelector.WorkerSelector.LabelOperator);
                ClassicAssert.AreEqual("value", staticWSelector.WorkerSelector.Value.Value);
            });
            ClassicAssert.IsTrue(createClassificationPolicy.PrioritizationRule.GetType() == typeof(StaticRouterRule));
            ClassicAssert.IsTrue(string.IsNullOrWhiteSpace(createClassificationPolicy.FallbackQueueId));
            ClassicAssert.IsTrue(string.IsNullOrWhiteSpace(createClassificationPolicy.Name));

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

            ClassicAssert.NotNull(updateClassificationPolicyResponse.Value);

            createClassificationPolicy = updateClassificationPolicyResponse.Value;
            ClassicAssert.DoesNotThrow(() =>
            {
                var queueSelectors = createClassificationPolicy.QueueSelectorAttachments;
                ClassicAssert.AreEqual(queueSelectors.Count, 1);
                var qs = queueSelectors.First();
                ClassicAssert.IsTrue(qs.GetType() == typeof(StaticQueueSelectorAttachment));
                var staticQSelector = (StaticQueueSelectorAttachment)qs;
                ClassicAssert.AreEqual(staticQSelector.QueueSelector.Key, "Id");
                ClassicAssert.AreEqual(staticQSelector.QueueSelector.LabelOperator, LabelOperator.Equal);
                ClassicAssert.AreEqual(staticQSelector.QueueSelector.Value.Value, createQueueResponse.Value.Id);
            });
            ClassicAssert.AreEqual(1, createClassificationPolicy.WorkerSelectorAttachments.Count);
            ClassicAssert.DoesNotThrow(() =>
            {
                var workerSelectors = createClassificationPolicy.WorkerSelectorAttachments;
                ClassicAssert.AreEqual(workerSelectors.Count, 1);
                var ws = workerSelectors.First();
                ClassicAssert.IsTrue(ws.GetType() == typeof(StaticWorkerSelectorAttachment));
                var staticWSelector = (StaticWorkerSelectorAttachment)ws;
                ClassicAssert.AreEqual("key", staticWSelector.WorkerSelector.Key);
                ClassicAssert.AreEqual(LabelOperator.Equal, staticWSelector.WorkerSelector.LabelOperator);
                ClassicAssert.AreEqual("value", staticWSelector.WorkerSelector.Value.Value);
            });
            ClassicAssert.IsTrue(createClassificationPolicy.PrioritizationRule.GetType() == typeof(StaticRouterRule));
            ClassicAssert.IsTrue(!string.IsNullOrWhiteSpace(createClassificationPolicy.FallbackQueueId) && createClassificationPolicy.FallbackQueueId == createQueueResponse.Value.Id);
            ClassicAssert.IsFalse(string.IsNullOrWhiteSpace(createClassificationPolicy.Name));

            updateClassificationPolicyResponse.Value.FallbackQueueId = null;
            updateClassificationPolicyResponse.Value.PrioritizationRule = null;
            updateClassificationPolicyResponse.Value.QueueSelectorAttachments.Clear();
            updateClassificationPolicyResponse.Value.WorkerSelectorAttachments.Clear();
            updateClassificationPolicyResponse.Value.Name = $"{classificationPolicyName}-updated";

            updateClassificationPolicyResponse = await routerClient.UpdateClassificationPolicyAsync(
                updateClassificationPolicyResponse.Value);

            var updateClassificationPolicy = updateClassificationPolicyResponse.Value;
            ClassicAssert.IsFalse(updateClassificationPolicy.QueueSelectorAttachments.Any());
            ClassicAssert.IsFalse(updateClassificationPolicy.WorkerSelectorAttachments.Any());
            ClassicAssert.AreEqual(updateClassificationPolicy.Name, $"{classificationPolicyName}-updated");
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

            ClassicAssert.Null(getClassificationPolicyResponse.Value.FallbackQueueId);
            ClassicAssert.Null(getClassificationPolicyResponse.Value.Name);
            ClassicAssert.IsEmpty(getClassificationPolicyResponse.Value.QueueSelectorAttachments);
            ClassicAssert.Null(getClassificationPolicyResponse.Value.PrioritizationRule);
            ClassicAssert.IsEmpty(getClassificationPolicyResponse.Value.WorkerSelectorAttachments);

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

            ClassicAssert.Null(getClassificationPolicyResponse.Value.FallbackQueueId);
            ClassicAssert.AreEqual(classificationPolicyName, getClassificationPolicyResponse.Value.Name);
            ClassicAssert.IsEmpty(getClassificationPolicyResponse.Value.QueueSelectorAttachments);
            ClassicAssert.IsTrue(getClassificationPolicyResponse.Value.PrioritizationRule.GetType() == typeof(StaticRouterRule));
            ClassicAssert.IsEmpty(getClassificationPolicyResponse.Value.WorkerSelectorAttachments);
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
            ClassicAssert.Null(getClassificationPolicyResponse.Value.FallbackQueueId);
            ClassicAssert.AreEqual(classificationPolicyName, getClassificationPolicyResponse.Value.Name);
            ClassicAssert.AreEqual(1, getClassificationPolicyResponse.Value.QueueSelectorAttachments.Count);
            var staticQSelector = (StaticQueueSelectorAttachment)getClassificationPolicyResponse.Value.QueueSelectorAttachments.First();
            ClassicAssert.NotNull(staticQSelector);
            ClassicAssert.Null(getClassificationPolicyResponse.Value.PrioritizationRule);
            ClassicAssert.AreEqual(0, getClassificationPolicyResponse.Value.WorkerSelectorAttachments.Count);
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

            ClassicAssert.Null(getClassificationPolicyResponse.Value.FallbackQueueId);
            ClassicAssert.AreEqual(classificationPolicyName, getClassificationPolicyResponse.Value.Name);
            ClassicAssert.Null(getClassificationPolicyResponse.Value.PrioritizationRule);
            ClassicAssert.IsEmpty(getClassificationPolicyResponse.Value.QueueSelectorAttachments);
            ClassicAssert.AreEqual(1, getClassificationPolicyResponse.Value.WorkerSelectorAttachments.Count);
        }

        #endregion Classification Policy Tests
    }
}
