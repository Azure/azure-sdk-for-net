// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Samples
{
    public class ExceptionPolicyCrudOpsAsync : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public async Task DistributionPolicyCrud()
        {
            // create a client
            JobRouterAdministrationClient routerClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");
            string ClassificationPolicyId1 = "escalation-on-q-over-flow";
            string ClassificationPolicyId2 = "escalation-on-wait-time-exceeded";

            await routerClient.CreateClassificationPolicyAsync(
               new CreateClassificationPolicyOptions(ClassificationPolicyId1)
               {
                   PrioritizationRule = new StaticRouterRule(new RouterValue(10))
               });

            await routerClient.CreateClassificationPolicyAsync(
               new CreateClassificationPolicyOptions(ClassificationPolicyId2)
               {
                   PrioritizationRule = new StaticRouterRule(new RouterValue(10))
               });
            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateExceptionPolicy_Async

            string exceptionPolicyId = "my-exception-policy";

            // we are going to create 2 rules:
            // 1. EscalateJobOnQueueOverFlowTrigger: triggers when queue has more than 10 jobs already en-queued,
            //                                         then reclassifies job adding additional labels on the job.
            // 2. EscalateJobOnWaitTimeExceededTrigger: triggers when job has waited in the queue for more than 10 minutes,
            //                                            then reclassifies job adding additional labels on the job

            // define exception trigger for queue over flow
            var queueLengthExceptionTrigger = new QueueLengthExceptionTrigger(10);

            // define exception actions that needs to be executed when trigger condition is satisfied
            ReclassifyExceptionAction escalateJobOnQueueOverFlow = new ReclassifyExceptionAction
            {
                ClassificationPolicyId = "escalation-on-q-over-flow",
                LabelsToUpsert =
                {
                    ["EscalateJob"] = new RouterValue(true),
                    ["EscalationReasonCode"] = new RouterValue("QueueOverFlow")
                }
            };

            // define second exception trigger for wait time
            WaitTimeExceptionTrigger waitTimeExceptionTrigger = new WaitTimeExceptionTrigger(TimeSpan.FromMinutes(10));

            // define exception actions that needs to be executed when trigger condition is satisfied

            var escalateJobOnWaitTimeExceeded = new ReclassifyExceptionAction
            {
                ClassificationPolicyId = "escalation-on-wait-time-exceeded",
                LabelsToUpsert =
                {
                    ["EscalateJob"] = new RouterValue(true),
                    ["EscalationReasonCode"] = new RouterValue("WaitTimeExceeded")
                }
            };

            // define exception rule
            List<ExceptionRule> exceptionRule = new()
            {
                new ExceptionRule(id: "EscalateJobOnQueueOverFlowTrigger",
                    trigger: queueLengthExceptionTrigger,
                    actions: new List<ExceptionAction> { escalateJobOnQueueOverFlow }),
                new ExceptionRule(id: "EscalateJobOnWaitTimeExceededTrigger",
                    trigger: waitTimeExceptionTrigger,
                    actions: new List<ExceptionAction> { escalateJobOnWaitTimeExceeded })
            };

            Response<ExceptionPolicy> exceptionPolicy = await routerClient.CreateExceptionPolicyAsync(
                new CreateExceptionPolicyOptions(
                        exceptionPolicyId: exceptionPolicyId,
                        exceptionRules: exceptionRule) // this is optional
                {
                    Name = "My exception policy"
                }
            );

            Console.WriteLine($"Exception Policy successfully created with id: {exceptionPolicy.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateExceptionPolicy_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetExceptionPolicy_Async

            Response<ExceptionPolicy> queriedExceptionPolicy = await routerClient.GetExceptionPolicyAsync(exceptionPolicyId);

            Console.WriteLine($"Successfully fetched exception policy with id: {queriedExceptionPolicy.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetExceptionPolicy_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateExceptionPolicy_Async

            // we are going to
            // 1. Add an exception rule: EscalateJobOnWaitTimeExceededTrigger2Min: triggers when job has waited in the queue for more than 2 minutes,
            //                                                                       then reclassifies job adding additional labels on the job
            // 2. Modify an existing rule: EscalateJobOnQueueOverFlowTrigger: change 'threshold' to 100
            // 3. Delete an exception rule: EscalateJobOnWaitTimeExceededTrigger to be deleted

            // let's define the new rule to be added
            // define exception trigger
            var escalateJobOnWaitTimeExceed2 = new WaitTimeExceptionTrigger(TimeSpan.FromMinutes(2));

            // define exception action
            var escalateJobOnWaitTimeExceeded2 = new ReclassifyExceptionAction
            {
                ClassificationPolicyId = "escalation-on-wait-time-exceeded",
                LabelsToUpsert =
                {
                    ["EscalateJob"] = new RouterValue(true),
                    ["EscalationReasonCode"] = new RouterValue("WaitTimeExceeded2Min")
                }
            };

            Response<ExceptionPolicy> updateExceptionPolicy = await routerClient.UpdateExceptionPolicyAsync(
                new ExceptionPolicy(exceptionPolicyId)
                {
                    // you can update one or more properties of exception policy - here we are adding one additional exception rule
                    Name = "My updated exception policy",
                    ExceptionRules =
                    {
                        // adding new rule
                        new ExceptionRule(id: "EscalateJobOnWaitTimeExceededTrigger2Min",
                            trigger: escalateJobOnWaitTimeExceed2,
                            actions: new List<ExceptionAction> { escalateJobOnWaitTimeExceeded2 }),
                        // modifying existing rule
                        new ExceptionRule(id: "EscalateJobOnQueueOverFlowTrigger",
                            trigger: new QueueLengthExceptionTrigger(100),
                            actions: new List<ExceptionAction> { escalateJobOnQueueOverFlow })
                    }
                });

            Console.WriteLine($"Exception policy successfully updated with id: {updateExceptionPolicy.Value.Id}");
            Console.WriteLine($"Exception policy now has 2 exception rules: {updateExceptionPolicy.Value.ExceptionRules.Count}");
            Console.WriteLine($"`EscalateJobOnWaitTimeExceededTrigger` rule has been successfully deleted: {updateExceptionPolicy.Value.ExceptionRules.All(r => r.Id == "EscalateJobOnWaitTimeExceededTrigger")}");
            Console.WriteLine($"`EscalateJobOnWaitTimeExceededTrigger2Min` rule has been successfully added: {updateExceptionPolicy.Value.ExceptionRules.Any(r => r.Id == "EscalateJobOnWaitTimeExceededTrigger2Min")}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateExceptionPolicy_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetExceptionPolicies_Async

            AsyncPageable<ExceptionPolicy> exceptionPolicies = routerClient.GetExceptionPoliciesAsync(cancellationToken: default);
            await foreach (Page<ExceptionPolicy> asPage in exceptionPolicies.AsPages(pageSizeHint: 10))
            {
                foreach (ExceptionPolicy? policy in asPage.Values)
                {
                    Console.WriteLine($"Listing exception policy with id: {policy.Id}");
                }
            }

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetExceptionPolicies_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteExceptionPolicy_Async

            _ = await routerClient.DeleteExceptionPolicyAsync(exceptionPolicyId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteExceptionPolicy_Async
        }
    }
}
