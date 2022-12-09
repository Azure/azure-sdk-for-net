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
    public class ExceptionPolicyLiveTests : RouterLiveTestBase
    {
        public ExceptionPolicyLiveTests(bool isAsync) : base(isAsync)
        {
        }

        #region Exception Policy Tests

        [Test]
        public async Task CreateExceptionPolicyTest()
        {
            RouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();

            var exceptionPolicyId = GenerateUniqueId($"{IdPrefix}{nameof(CreateExceptionPolicyTest)}");

            // exception rules
            var exceptionRuleId = GenerateUniqueId($"{IdPrefix}-ExceptionRule");
            var cancelActionId = GenerateUniqueId($"{IdPrefix}-CancellationExceptionAction");
            var rules = new Dictionary<string, ExceptionRule>()
            {
                [exceptionRuleId] = new ExceptionRule(new QueueLengthExceptionTrigger(1),
                    new Dictionary<string, ExceptionAction?>()
                    {
                        [cancelActionId] = new CancelExceptionAction()
                        {
                            DispositionCode = "CancelledDueToMaxQueueLengthReached"
                        }
                    }
                )
            };

            var createExceptionPolicyResponse = await routerClient.CreateExceptionPolicyAsync(new CreateExceptionPolicyOptions(exceptionPolicyId, rules));

            Assert.NotNull(createExceptionPolicyResponse.Value);

            var exceptionPolicy = createExceptionPolicyResponse.Value;

            Assert.AreEqual(exceptionPolicyId, exceptionPolicy.Id);
            Assert.AreEqual(exceptionPolicyId, exceptionPolicy.Id);
            Assert.DoesNotThrow(() =>
            {
                var exceptionRule = exceptionPolicy.ExceptionRules.First();

                Assert.AreEqual(exceptionRuleId, exceptionRule.Key);
                Assert.IsTrue(exceptionRule.Value.Trigger.GetType() == typeof(QueueLengthExceptionTrigger));
                var trigger = exceptionRule.Value.Trigger as QueueLengthExceptionTrigger;
                Assert.NotNull(trigger);
                Assert.AreEqual(1, trigger!.Threshold);

                var actions = exceptionRule.Value.Actions;
                Assert.AreEqual(1, actions.Count);
                var cancelAction = actions.FirstOrDefault().Value as CancelExceptionAction;
                Assert.NotNull(cancelAction);
                Assert.AreEqual(cancelActionId, actions.FirstOrDefault().Key);
                Assert.AreEqual($"CancelledDueToMaxQueueLengthReached", cancelAction!.DispositionCode);
            });

            // with name
            var exceptionPolicyName = $"{exceptionPolicyId}-ExceptionPolicyName";
            createExceptionPolicyResponse = await routerClient.UpdateExceptionPolicyAsync(
                new UpdateExceptionPolicyOptions(exceptionPolicyId)
                {
                    Name = exceptionPolicyName
                });

            Assert.NotNull(createExceptionPolicyResponse.Value);

            exceptionPolicy = createExceptionPolicyResponse.Value;

            Assert.AreEqual(exceptionPolicyId, exceptionPolicy.Id);
            Assert.AreEqual(exceptionPolicyName, exceptionPolicy.Name);

            AddForCleanup(new Task(async () => await routerClient.DeleteExceptionPolicyAsync(exceptionPolicyId)));
        }

        #endregion Exception Policy Tests
    }
}
