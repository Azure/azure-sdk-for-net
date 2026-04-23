// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;
using NUnit.Framework.Legacy;

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

            ClassicAssert.NotNull(createExceptionPolicyResponse.Value);

            var exceptionPolicy = createExceptionPolicyResponse.Value;

            ClassicAssert.AreEqual(exceptionPolicyId, exceptionPolicy.Id);
            ClassicAssert.AreEqual(exceptionPolicyId, exceptionPolicy.Id);
            ClassicAssert.DoesNotThrow(() =>
            {
                var exceptionRule = exceptionPolicy.ExceptionRules.First();

                ClassicAssert.AreEqual(exceptionRuleId, exceptionRule.Id);
                ClassicAssert.IsTrue(exceptionRule.Trigger.GetType() == typeof(QueueLengthExceptionTrigger));
                var trigger = exceptionRule.Trigger as QueueLengthExceptionTrigger;
                ClassicAssert.NotNull(trigger);
                ClassicAssert.AreEqual(1, trigger!.Threshold);

                var actions = exceptionRule.Actions;
                ClassicAssert.AreEqual(1, actions.Count);
                var cancelAction = actions.FirstOrDefault() as CancelExceptionAction;
                ClassicAssert.NotNull(cancelAction);
                ClassicAssert.AreEqual($"CancelledDueToMaxQueueLengthReached", cancelAction!.DispositionCode);
            });

            // with name
            var exceptionPolicyName = $"{exceptionPolicyId}-ExceptionPolicyName";
            createExceptionPolicyResponse = await routerClient.UpdateExceptionPolicyAsync(
                new ExceptionPolicy(exceptionPolicyId)
                {
                    Name = exceptionPolicyName
                });

            ClassicAssert.NotNull(createExceptionPolicyResponse.Value);

            exceptionPolicy = createExceptionPolicyResponse.Value;

            ClassicAssert.AreEqual(exceptionPolicyId, exceptionPolicy.Id);
            ClassicAssert.AreEqual(exceptionPolicyName, exceptionPolicy.Name);
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
            ClassicAssert.NotNull(createExceptionPolicyResponse.Value);

            var exceptionPolicy = createExceptionPolicyResponse.Value;

            ClassicAssert.AreEqual(exceptionPolicyId, exceptionPolicy.Id);
            ClassicAssert.DoesNotThrow(() =>
            {
                var exceptionRule = exceptionPolicy.ExceptionRules.First();

                ClassicAssert.AreEqual(exceptionRuleId, exceptionRule.Id);
                ClassicAssert.IsTrue(exceptionRule.Trigger.GetType() == typeof(QueueLengthExceptionTrigger));
                var trigger = exceptionRule.Trigger as QueueLengthExceptionTrigger;
                ClassicAssert.NotNull(trigger);
                ClassicAssert.AreEqual(1, trigger!.Threshold);

                var actions = exceptionRule.Actions;
                ClassicAssert.AreEqual(2, actions.Count);
                var reclassifyExceptionAction = actions.FirstOrDefault() as ReclassifyExceptionAction;
                ClassicAssert.NotNull(reclassifyExceptionAction);
                ClassicAssert.AreEqual(classificationPolicyId, reclassifyExceptionAction?.ClassificationPolicyId);
                ClassicAssert.AreEqual(labelsToUpsert.FirstOrDefault().Key, reclassifyExceptionAction?.LabelsToUpsert.FirstOrDefault().Key);
                ClassicAssert.AreEqual(labelsToUpsert.FirstOrDefault().Value.Value as string, reclassifyExceptionAction?.LabelsToUpsert.FirstOrDefault().Value.Value as string);
                var manualReclassifyExceptionAction = actions.LastOrDefault() as ManualReclassifyExceptionAction;
                ClassicAssert.NotNull(manualReclassifyExceptionAction);
                ClassicAssert.AreEqual(queueId, manualReclassifyExceptionAction?.QueueId);
                ClassicAssert.AreEqual(1, manualReclassifyExceptionAction?.Priority);
            });

            // with name
            var exceptionPolicyName = $"{exceptionPolicyId}-ExceptionPolicyName";
            createExceptionPolicyResponse = await routerClient.UpdateExceptionPolicyAsync(
                new ExceptionPolicy(exceptionPolicyId)
                {
                    Name = exceptionPolicyName
                });

            ClassicAssert.NotNull(createExceptionPolicyResponse.Value);

            exceptionPolicy = createExceptionPolicyResponse.Value;

            ClassicAssert.AreEqual(exceptionPolicyId, exceptionPolicy.Id);
            ClassicAssert.AreEqual(exceptionPolicyName, exceptionPolicy.Name);
        }

        #endregion Exception Policy Tests
    }
}
