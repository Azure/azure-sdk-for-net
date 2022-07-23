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

namespace Azure.Communication.JobRouter.Tests.Samples
{
    public class ExceptionPolicyCrudOps : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public void DistributionPolicyCrud()
        {
#if !SNIPPET
            // create a client
            var routerClient = new RouterAdministrationClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
#endif

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateExceptionPolicy

            var exceptionPolicyId = "my-exception-policy";

            // we are going to create 2 rules:
            // 1. `EscalateJobOnQueueOverFlowTrigger`: triggers when queue has more than 10 jobs already en-queued,
            //                                         then reclassifies job adding additional labels on the job.
            // 2. `EscalateJobOnWaitTimeExceededTrigger`: triggers when job has waited in the queue for more than 10 minutes,
            //                                            then reclassifies job adding additional labels on the job

            // define exception trigger for queue over flow
            var queueLengthExceptionTrigger = new QueueLengthExceptionTrigger(10);

            // define exception actions that needs to be executed when trigger condition is satisfied
            var escalateJobOnQueueOverFlow = new ReclassifyExceptionAction(
                classificationPolicyId: "escalation-on-q-over-flow",
                labelsToUpsert: new Dictionary<string, LabelValue>()
                {
                    ["EscalateJob"] = new LabelValue(true),
                    ["EscalationReasonCode"] = new LabelValue("QueueOverFlow")
                });

            // define second exception trigger for wait time
            var waitTimeExceptionTrigger = new WaitTimeExceptionTrigger(TimeSpan.FromMinutes(10));

            // define exception actions that needs to be executed when trigger condition is satisfied

            var escalateJobOnWaitTimeExceeded = new ReclassifyExceptionAction(
                classificationPolicyId: "escalation-on-wait-time-exceeded",
                labelsToUpsert: new Dictionary<string, LabelValue>()
                {
                    ["EscalateJob"] = new LabelValue(true),
                    ["EscalationReasonCode"] = new LabelValue("WaitTimeExceeded")
                });

            // define exception rule
            var exceptionRule = new Dictionary<string, ExceptionRule>()
            {
                ["EscalateJobOnQueueOverFlowTrigger"] = new ExceptionRule(
                    trigger: queueLengthExceptionTrigger,
                    actions: new Dictionary<string, ExceptionAction?>()
                    {
                        ["EscalationJobActionOnQueueOverFlow"] = escalateJobOnQueueOverFlow
                    }),
                ["EscalateJobOnWaitTimeExceededTrigger"] = new ExceptionRule(
                    trigger: waitTimeExceptionTrigger,
                    actions: new Dictionary<string, ExceptionAction?>()
                    {
                        ["EscalationJobActionOnWaitTimeExceed"] = escalateJobOnWaitTimeExceeded
                    })
            };

            var exceptionPolicy = routerClient.CreateExceptionPolicy(
                new CreateExceptionPolicyOptions(
                        exceptionPolicyId: exceptionPolicyId,
                        exceptionRules: exceptionRule)
                {
                    Name = "My exception policy"
                }
            );

            Console.WriteLine($"Exception Policy successfully created with id: {exceptionPolicy.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateExceptionPolicy

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetExceptionPolicy

            var queriedExceptionPolicy = routerClient.GetExceptionPolicy(exceptionPolicyId);

            Console.WriteLine($"Successfully fetched exception policy with id: {queriedExceptionPolicy.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetExceptionPolicy

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateExceptionPolicy

            // we are going to
            // 1. Add an exception rule: `EscalateJobOnWaitTimeExceededTrigger2Min`: triggers when job has waited in the queue for more than 2 minutes,
            //                                                                       then reclassifies job adding additional labels on the job
            // 2. Modify an existing rule: `EscalateJobOnQueueOverFlowTrigger`: change `threshold` to 100
            // 3. Delete an exception rule: `EscalateJobOnWaitTimeExceededTrigger` to be deleted

            // let's define the new rule to be added
            // define exception trigger
            var escalateJobOnWaitTimeExceed2 = new WaitTimeExceptionTrigger(TimeSpan.FromMinutes(2));

            // define exception action
            var escalateJobOnWaitTimeExceeded2 = new ReclassifyExceptionAction(
                classificationPolicyId: "escalation-on-wait-time-exceeded",
                labelsToUpsert: new Dictionary<string, LabelValue>()
                {
                    ["EscalateJob"] = new LabelValue(true),
                    ["EscalationReasonCode"] = new LabelValue("WaitTimeExceeded2Min")
                });

            var updateExceptionPolicy = routerClient.UpdateExceptionPolicy(
                new UpdateExceptionPolicyOptions(exceptionPolicyId)
                {
                    // you can update one or more properties of exception policy - here we are adding one additional exception rule
                    Name = "My updated exception policy",
                    ExceptionRules = new Dictionary<string, ExceptionRule?>()
                    {
                        // adding new rule
                        ["EscalateJobOnWaitTimeExceededTrigger2Min"] = new ExceptionRule(
                            trigger: escalateJobOnWaitTimeExceed2,
                            actions: new Dictionary<string, ExceptionAction?>()
                            {
                                ["EscalationJobActionOnWaitTimeExceed"] = escalateJobOnWaitTimeExceeded2
                            }),
                        // modifying existing rule
                        ["EscalateJobOnQueueOverFlowTrigger"] = new ExceptionRule(
                            trigger: new QueueLengthExceptionTrigger(100),
                            actions: new Dictionary<string, ExceptionAction?>()
                            {
                                ["EscalationJobActionOnQueueOverFlow"] = escalateJobOnQueueOverFlow
                            }),
                        // deleting existing rule
                        ["EscalateJobOnWaitTimeExceededTrigger"] = null
                    }
                });

            Console.WriteLine($"Exception policy successfully updated with id: {updateExceptionPolicy.Value.Id}");
            Console.WriteLine($"Exception policy now has 2 exception rules: {updateExceptionPolicy.Value.ExceptionRules.Count}");
            Console.WriteLine($"`EscalateJobOnWaitTimeExceededTrigger` rule has been successfully deleted: {!updateExceptionPolicy.Value.ExceptionRules.ContainsKey("EscalateJobOnWaitTimeExceededTrigger")}");
            Console.WriteLine($"`EscalateJobOnWaitTimeExceededTrigger2Min` rule has been successfully added: {updateExceptionPolicy.Value.ExceptionRules.ContainsKey("EscalateJobOnWaitTimeExceededTrigger2Min")}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateExceptionPolicy

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetExceptionPolicies

            var exceptionPolicies = routerClient.GetExceptionPolicies();
            foreach (var asPage in exceptionPolicies.AsPages(pageSizeHint: 10))
            {
                foreach (var policy in asPage.Values)
                {
                    Console.WriteLine($"Listing exception policy with id: {policy.ExceptionPolicy.Id}");
                }
            }

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetExceptionPolicies

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteExceptionPolicy

            _ = routerClient.DeleteExceptionPolicy(exceptionPolicyId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteExceptionPolicy
        }
    }
}
