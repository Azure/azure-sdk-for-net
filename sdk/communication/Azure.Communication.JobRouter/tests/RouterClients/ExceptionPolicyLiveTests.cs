// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class ExceptionPolicyLiveTests : RouterLiveTestBase
    {
        public ExceptionPolicyLiveTests(bool isAsync) : base(isAsync)
        {
        }

        #region Exception Policy Tests

        [Test]
        public async Task CreateExceptionPolicyTest_QueueLength_Cancel()
        {
            JobRouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();

            var exceptionPolicyId = GenerateUniqueId($"{IdPrefix}{nameof(CreateExceptionPolicyTest_QueueLength_Cancel)}");

            // exception rules
            var exceptionRuleId = GenerateUniqueId($"{IdPrefix}-ExceptionRule");
            var rules = new List<ExceptionRule>()
            {
                new ExceptionRule(id: exceptionRuleId,new QueueLengthExceptionTrigger(1),
                    new List<ExceptionAction>
                    {
                        new CancelExceptionAction
                        {
                            DispositionCode = "CancelledDueToMaxQueueLengthReached"
                        }
                    }
                )
            };

            var createExceptionPolicyResponse = await routerClient.CreateExceptionPolicyAsync(new CreateExceptionPolicyOptions(exceptionPolicyId, rules));
            AddForCleanup(new Task(async () => await routerClient.DeleteExceptionPolicyAsync(exceptionPolicyId)));

            Assert.NotNull(createExceptionPolicyResponse.Value);

            var exceptionPolicy = createExceptionPolicyResponse.Value;

            Assert.That(exceptionPolicy.Id, Is.EqualTo(exceptionPolicyId));
            Assert.That(exceptionPolicy.Id, Is.EqualTo(exceptionPolicyId));
            Assert.DoesNotThrow(() =>
            {
                var exceptionRule = exceptionPolicy.ExceptionRules.First();

                Assert.That(exceptionRule.Id, Is.EqualTo(exceptionRuleId));
                Assert.That(exceptionRule.Trigger.GetType() == typeof(QueueLengthExceptionTrigger), Is.True);
                var trigger = exceptionRule.Trigger as QueueLengthExceptionTrigger;
                Assert.NotNull(trigger);
                Assert.That(trigger!.Threshold, Is.EqualTo(1));

                var actions = exceptionRule.Actions;
                Assert.That(actions.Count, Is.EqualTo(1));
                var cancelAction = actions.FirstOrDefault() as CancelExceptionAction;
                Assert.NotNull(cancelAction);
                Assert.That(cancelAction!.DispositionCode, Is.EqualTo($"CancelledDueToMaxQueueLengthReached"));
            });

            // with name
            var exceptionPolicyName = $"{exceptionPolicyId}-ExceptionPolicyName";
            createExceptionPolicyResponse = await routerClient.UpdateExceptionPolicyAsync(
                new ExceptionPolicy(exceptionPolicyId)
                {
                    Name = exceptionPolicyName
                });

            Assert.NotNull(createExceptionPolicyResponse.Value);

            exceptionPolicy = createExceptionPolicyResponse.Value;

            Assert.That(exceptionPolicy.Id, Is.EqualTo(exceptionPolicyId));
            Assert.That(exceptionPolicy.Name, Is.EqualTo(exceptionPolicyName));
        }

        [Test]
        public async Task CreateExceptionPolicyTest_WaitTime()
        {
            JobRouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();

            var createDistributionPolicyResponse = await CreateDistributionPolicy(nameof(CreateExceptionPolicyTest_WaitTime));
            var queueId = GenerateUniqueId(IdPrefix, nameof(CreateExceptionPolicyTest_WaitTime));
            var createQueueResponse = await routerClient.CreateQueueAsync(new CreateQueueOptions(queueId,
                    createDistributionPolicyResponse.Value.Id));
            AddForCleanup(new Task(async () => await routerClient.DeleteQueueAsync(queueId)));

            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}{nameof(CreateExceptionPolicyTest_WaitTime)}");
            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId)
                {
                    PrioritizationRule = new StaticRouterRule(new RouterValue(1))
                });
            var exceptionPolicyId = GenerateUniqueId($"{IdPrefix}{nameof(CreateExceptionPolicyTest_WaitTime)}");

            var labelsToUpsert = new Dictionary<string, RouterValue>() { ["Label_1"] = new RouterValue("Value_1") };
            // exception rules
            var exceptionRuleId = GenerateUniqueId($"{IdPrefix}-ExceptionRule");
            var rules = new List<ExceptionRule>()
            {
                new(id: exceptionRuleId, new QueueLengthExceptionTrigger(1),
                    new List<ExceptionAction>
                    {
                        new ReclassifyExceptionAction
                        {
                            ClassificationPolicyId = classificationPolicyId,
                            LabelsToUpsert = { ["Label_1"] = new RouterValue("Value_1") }
                        },
                        new ManualReclassifyExceptionAction
                        {
                            QueueId = createQueueResponse.Value.Id,
                            Priority = 1,
                            WorkerSelectors = { new RouterWorkerSelector("abc", LabelOperator.Equal, new RouterValue(1)) }
                        }
                    }
                )
            };

            var createExceptionPolicyResponse = await routerClient.CreateExceptionPolicyAsync(new CreateExceptionPolicyOptions(exceptionPolicyId, rules));

            AddForCleanup(new Task(async () => await routerClient.DeleteExceptionPolicyAsync(exceptionPolicyId)));
            Assert.NotNull(createExceptionPolicyResponse.Value);

            var exceptionPolicy = createExceptionPolicyResponse.Value;

            Assert.That(exceptionPolicy.Id, Is.EqualTo(exceptionPolicyId));
            Assert.DoesNotThrow(() =>
            {
                var exceptionRule = exceptionPolicy.ExceptionRules.First();

                Assert.That(exceptionRule.Id, Is.EqualTo(exceptionRuleId));
                Assert.That(exceptionRule.Trigger.GetType() == typeof(QueueLengthExceptionTrigger), Is.True);
                var trigger = exceptionRule.Trigger as QueueLengthExceptionTrigger;
                Assert.NotNull(trigger);
                Assert.That(trigger!.Threshold, Is.EqualTo(1));

                var actions = exceptionRule.Actions;
                Assert.That(actions.Count, Is.EqualTo(2));
                var reclassifyExceptionAction = actions.FirstOrDefault() as ReclassifyExceptionAction;
                Assert.NotNull(reclassifyExceptionAction);
                Assert.That(reclassifyExceptionAction?.ClassificationPolicyId, Is.EqualTo(classificationPolicyId));
                Assert.That(reclassifyExceptionAction?.LabelsToUpsert.FirstOrDefault().Key, Is.EqualTo(labelsToUpsert.FirstOrDefault().Key));
                Assert.That(reclassifyExceptionAction?.LabelsToUpsert.FirstOrDefault().Value.Value as string, Is.EqualTo(labelsToUpsert.FirstOrDefault().Value.Value as string));
                var manualReclassifyExceptionAction = actions.LastOrDefault() as ManualReclassifyExceptionAction;
                Assert.NotNull(manualReclassifyExceptionAction);
                Assert.That(manualReclassifyExceptionAction?.QueueId, Is.EqualTo(queueId));
                Assert.That(manualReclassifyExceptionAction?.Priority, Is.EqualTo(1));
            });

            // with name
            var exceptionPolicyName = $"{exceptionPolicyId}-ExceptionPolicyName";
            createExceptionPolicyResponse = await routerClient.UpdateExceptionPolicyAsync(
                new ExceptionPolicy(exceptionPolicyId)
                {
                    Name = exceptionPolicyName
                });

            Assert.NotNull(createExceptionPolicyResponse.Value);

            exceptionPolicy = createExceptionPolicyResponse.Value;

            Assert.That(exceptionPolicy.Id, Is.EqualTo(exceptionPolicyId));
            Assert.That(exceptionPolicy.Name, Is.EqualTo(exceptionPolicyName));
        }

        #endregion Exception Policy Tests
    }
}
