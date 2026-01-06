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
            Assert.That(createClassificationPolicyResponse.Value, Is.Not.Null);

            var createClassificationPolicy = createClassificationPolicyResponse.Value;
            Assert.DoesNotThrow(() =>
            {
                var queueSelectors = createClassificationPolicy.QueueSelectorAttachments;
                Assert.That(queueSelectors, Has.Count.EqualTo(1));
                var qs = queueSelectors.First();
                Assert.That(qs.GetType(), Is.EqualTo(typeof(StaticQueueSelectorAttachment)));
                var staticQSelector = (StaticQueueSelectorAttachment)qs;
                Assert.Multiple(() =>
                {
                    Assert.That(staticQSelector.QueueSelector.Key, Is.EqualTo("Id"));
                    Assert.That(LabelOperator.Equal, Is.EqualTo(staticQSelector.QueueSelector.LabelOperator));
                    Assert.That(createQueueResponse.Value.Id, Is.EqualTo(staticQSelector.QueueSelector.Value.Value));
                });
            });
            Assert.That(createClassificationPolicy.WorkerSelectorAttachments, Has.Count.EqualTo(1));
            Assert.DoesNotThrow(() =>
            {
                var workerSelectors = createClassificationPolicy.WorkerSelectorAttachments;
                Assert.That(workerSelectors, Has.Count.EqualTo(1));
                var ws = workerSelectors.First();
                Assert.That(ws.GetType(), Is.EqualTo(typeof(StaticWorkerSelectorAttachment)));
                var staticWSelector = (StaticWorkerSelectorAttachment)ws;
                Assert.Multiple(() =>
                {
                    Assert.That(staticWSelector.WorkerSelector.Key, Is.EqualTo("key"));
                    Assert.That(staticWSelector.WorkerSelector.LabelOperator, Is.EqualTo(LabelOperator.Equal));
                    Assert.That(staticWSelector.WorkerSelector.Value.Value, Is.EqualTo("value"));
                });
            });
            Assert.Multiple(() =>
            {
                Assert.That(createClassificationPolicy.PrioritizationRule.GetType(), Is.EqualTo(typeof(StaticRouterRule)));
                Assert.That(string.IsNullOrWhiteSpace(createClassificationPolicy.FallbackQueueId), Is.True);
                Assert.That(string.IsNullOrWhiteSpace(createClassificationPolicy.Name), Is.True);
            });

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

            Assert.That(updateClassificationPolicyResponse.Value, Is.Not.Null);

            createClassificationPolicy = updateClassificationPolicyResponse.Value;
            Assert.DoesNotThrow(() =>
            {
                var queueSelectors = createClassificationPolicy.QueueSelectorAttachments;
                Assert.That(queueSelectors, Has.Count.EqualTo(1));
                var qs = queueSelectors.First();
                Assert.That(qs.GetType(), Is.EqualTo(typeof(StaticQueueSelectorAttachment)));
                var staticQSelector = (StaticQueueSelectorAttachment)qs;
                Assert.Multiple(() =>
                {
                    Assert.That(staticQSelector.QueueSelector.Key, Is.EqualTo("Id"));
                    Assert.That(LabelOperator.Equal, Is.EqualTo(staticQSelector.QueueSelector.LabelOperator));
                    Assert.That(createQueueResponse.Value.Id, Is.EqualTo(staticQSelector.QueueSelector.Value.Value));
                });
            });
            Assert.That(createClassificationPolicy.WorkerSelectorAttachments, Has.Count.EqualTo(1));
            Assert.DoesNotThrow(() =>
            {
                var workerSelectors = createClassificationPolicy.WorkerSelectorAttachments;
                Assert.That(workerSelectors, Has.Count.EqualTo(1));
                var ws = workerSelectors.First();
                Assert.That(ws.GetType(), Is.EqualTo(typeof(StaticWorkerSelectorAttachment)));
                var staticWSelector = (StaticWorkerSelectorAttachment)ws;
                Assert.Multiple(() =>
                {
                    Assert.That(staticWSelector.WorkerSelector.Key, Is.EqualTo("key"));
                    Assert.That(staticWSelector.WorkerSelector.LabelOperator, Is.EqualTo(LabelOperator.Equal));
                    Assert.That(staticWSelector.WorkerSelector.Value.Value, Is.EqualTo("value"));
                });
            });
            Assert.Multiple(() =>
            {
                Assert.That(createClassificationPolicy.PrioritizationRule.GetType(), Is.EqualTo(typeof(StaticRouterRule)));
                Assert.That(!string.IsNullOrWhiteSpace(createClassificationPolicy.FallbackQueueId) && createClassificationPolicy.FallbackQueueId == createQueueResponse.Value.Id, Is.True);
                Assert.That(string.IsNullOrWhiteSpace(createClassificationPolicy.Name), Is.False);
            });

            updateClassificationPolicyResponse.Value.FallbackQueueId = null;
            updateClassificationPolicyResponse.Value.PrioritizationRule = null;
            updateClassificationPolicyResponse.Value.QueueSelectorAttachments.Clear();
            updateClassificationPolicyResponse.Value.WorkerSelectorAttachments.Clear();
            updateClassificationPolicyResponse.Value.Name = $"{classificationPolicyName}-updated";

            updateClassificationPolicyResponse = await routerClient.UpdateClassificationPolicyAsync(
                updateClassificationPolicyResponse.Value);

            var updateClassificationPolicy = updateClassificationPolicyResponse.Value;
            Assert.Multiple(() =>
            {
                Assert.That(updateClassificationPolicy.QueueSelectorAttachments.Any(), Is.False);
                Assert.That(updateClassificationPolicy.WorkerSelectorAttachments.Any(), Is.False);
                Assert.That($"{classificationPolicyName}-updated", Is.EqualTo(updateClassificationPolicy.Name));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(getClassificationPolicyResponse.Value.FallbackQueueId, Is.Null);
                Assert.That(getClassificationPolicyResponse.Value.Name, Is.Null);
                Assert.That(getClassificationPolicyResponse.Value.QueueSelectorAttachments, Is.Empty);
                Assert.That(getClassificationPolicyResponse.Value.PrioritizationRule, Is.Null);
                Assert.That(getClassificationPolicyResponse.Value.WorkerSelectorAttachments, Is.Empty);
            });

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

            Assert.Multiple(() =>
            {
                Assert.That(getClassificationPolicyResponse.Value.FallbackQueueId, Is.Null);
                Assert.That(getClassificationPolicyResponse.Value.Name, Is.EqualTo(classificationPolicyName));
                Assert.That(getClassificationPolicyResponse.Value.QueueSelectorAttachments, Is.Empty);
                Assert.That(getClassificationPolicyResponse.Value.PrioritizationRule.GetType(), Is.EqualTo(typeof(StaticRouterRule)));
                Assert.That(getClassificationPolicyResponse.Value.WorkerSelectorAttachments, Is.Empty);
            });
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
            Assert.Multiple(() =>
            {
                Assert.That(getClassificationPolicyResponse.Value.FallbackQueueId, Is.Null);
                Assert.That(getClassificationPolicyResponse.Value.Name, Is.EqualTo(classificationPolicyName));
                Assert.That(getClassificationPolicyResponse.Value.QueueSelectorAttachments, Has.Count.EqualTo(1));
            });
            var staticQSelector = (StaticQueueSelectorAttachment)getClassificationPolicyResponse.Value.QueueSelectorAttachments.First();
            Assert.Multiple(() =>
            {
                Assert.That(staticQSelector, Is.Not.Null);
                Assert.That(getClassificationPolicyResponse.Value.PrioritizationRule, Is.Null);
                Assert.That(getClassificationPolicyResponse.Value.WorkerSelectorAttachments.Count, Is.EqualTo(0));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(getClassificationPolicyResponse.Value.FallbackQueueId, Is.Null);
                Assert.That(getClassificationPolicyResponse.Value.Name, Is.EqualTo(classificationPolicyName));
                Assert.That(getClassificationPolicyResponse.Value.PrioritizationRule, Is.Null);
                Assert.That(getClassificationPolicyResponse.Value.QueueSelectorAttachments, Is.Empty);
                Assert.That(getClassificationPolicyResponse.Value.WorkerSelectorAttachments, Has.Count.EqualTo(1));
            });
        }

        #endregion Classification Policy Tests
    }
}
