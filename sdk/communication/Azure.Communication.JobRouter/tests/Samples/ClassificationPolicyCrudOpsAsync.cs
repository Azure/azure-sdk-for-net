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
    public class ClassificationPolicyCrudOpsAsync : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public async Task ClassificationPolicyCrud()
        {
#if !SNIPPET
            // create a client
            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
#endif

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateClassificationPolicy_Async

            var classificationPolicyId = "my-classification-policy";

            var classificationPolicy = await routerClient.CreateClassificationPolicyAsync(
                id: classificationPolicyId,
                options: new CreateClassificationPolicyOptions()
                {
                    Name = "Sample classification policy",
                    PrioritizationRule = new StaticRule(10),
                    QueueSelectors = new List<QueueSelectorAttachment>()
                    {
                        new StaticQueueSelector(new QueueSelector("Region", LabelOperator.Equal, "NA")),
                        new ConditionalQueueSelector(
                            condition: new ExpressionRule("If(job.Product = \"O365\", true, false)"),
                            labelSelectors: new List<QueueSelector>()
                            {
                                new QueueSelector("Product", LabelOperator.Equal, "O365"),
                                new QueueSelector("QGroup", LabelOperator.Equal, "NA_O365")
                            }),
                    },
                    WorkerSelectors = new List<WorkerSelectorAttachment>()
                    {
                        new ConditionalWorkerSelector(
                            condition: new ExpressionRule("If(job.Product = \"O365\", true, false)"),
                            labelSelectors: new List<WorkerSelector>()
                            {
                                new WorkerSelector("Skill_O365", LabelOperator.Equal, true),
                                new WorkerSelector("Skill_O365_Lvl", LabelOperator.GreaterThanEqual, 1)
                            }),
                        new ConditionalWorkerSelector(
                            condition: new ExpressionRule("If(job.HighPriority = \"true\", true, false)"),
                            labelSelectors: new List<WorkerSelector>()
                            {
                                new WorkerSelector("Skill_O365_Lvl", LabelOperator.GreaterThanEqual, 10)
                            })
                    }
                });

            Console.WriteLine($"Classification Policy successfully created with id: {classificationPolicy.Value.Id}");

            /*
            // NOTE: it is not necessary to specify all the properties when creating a classification policy
            // Router provides the flexibility to pick and choose whichever functionality of the classification process someone may use
            // For e.g., it is possible to use the classification policy to assign
            // 1. A priority to the job
            // 2. A specified set of worker selectors
            // In this scenario, the queue selectors are not specified. Therefore, any job using this classification policy will
            // be expected to have a `queueId` pre-assigned to itself.
            var classificationPolicy = await routerClient.CreateClassificationPolicyAsync(
                id: classificationPolicyId,
                options: new CreateClassificationPolicyOptions()
                {
                    PrioritizationRule = new StaticRule(10),
                    WorkerSelectors = new List<WorkerSelectorAttachment>()
                    {
                        new ConditionalWorkerSelector(
                            condition: new ExpressionRule("If(job.Product = \"O365\", true, false)"),
                            labelSelectors: new List<WorkerSelector>()
                            {
                                new WorkerSelector("Skill_O365", LabelOperator.Equal, true),
                                new WorkerSelector("Skill_O365_Lvl", LabelOperator.GreaterThanEqual, 1)
                            }),
                        new ConditionalWorkerSelector(
                            condition: new ExpressionRule("If(job.HighPriority = \"true\", true, false)"),
                            labelSelectors: new List<WorkerSelector>()
                            {
                                new WorkerSelector("Skill_O365_Lvl", LabelOperator.GreaterThanEqual, 10)
                            })
                    }
                });
                */

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateClassificationPolicy_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetClassificationPolicy_Async

            var queriedClassificationPolicy = await routerClient.GetClassificationPolicyAsync(classificationPolicyId);

            Console.WriteLine($"Successfully fetched classification policy with id: {queriedClassificationPolicy.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetClassificationPolicy_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateClassificationPolicy_Async

            var updatedClassificationPolicy = await routerClient.UpdateClassificationPolicyAsync(
                classificationPolicyId,
                new UpdateClassificationPolicyOptions()
                {
                    PrioritizationRule = new ExpressionRule("If(job.HighPriority = \"true\", 50, 10)")
                });

            Console.WriteLine($"Classification policy successfully update with new prioritization rule. RuleType: {updatedClassificationPolicy.Value.PrioritizationRule.Kind}");

            /*
            // NOTE: It is not possible to update a single QueueSelectorAttachment or WorkerSelectorAttachment.
            // For e.g., the following update with result in the classification policy with a single QueueSelectorAttachment.
            // All previous QueueSelectorAttachment(s) which was specified during creating will be removed.

            var updatedClassificationPolicy = await routerClient.UpdateClassificationPolicyAsync(
                classificationPolicyId,
                new UpdateClassificationPolicyOptions()
                {
                    QueueSelectors = new List<QueueSelectorAttachment>()
                    {
                        new StaticQueueSelector(new QueueSelector("Id", LabelOperator.Equal, "NA_O365_EN_1"))
                    }
                });

            // In order to add QueueSelectorAttachment to an already existing set of QueueSelectorAttachment(s), either
            // 1. Specify all the QueueSelectorAttachment(s) again, OR
            // 2. Perform a Get operation first to retrieve the current value of the classification policy (preferred)

            var existingClassificationPolicy = await routerClient.GetClassificationPolicyAsync(classificationPolicyId);
            var existingQueueSelectors = existingClassificationPolicy.Value.QueueSelectors.ToList();

            // Add a new QueueSelectorAttachment
            existingQueueSelectors.Add(new StaticQueueSelector(new QueueSelector("Id", LabelOperator.Equal, "NA_O365_EN_1")));

            var updatedClassificationPolicy = await routerClient.UpdateClassificationPolicyAsync(
                classificationPolicyId,
                new UpdateClassificationPolicyOptions()
                {
                    QueueSelectors = existingQueueSelectors
                });
                */

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateClassificationPolicy_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetClassificationPolicies_Async

            var classificationPolicies = routerClient.GetClassificationPoliciesAsync();
            await foreach (var asPage in classificationPolicies.AsPages(pageSizeHint: 10))
            {
                foreach (var policy in asPage.Values)
                {
                    Console.WriteLine($"Listing classification policy with id: {policy.Id}");
                }
            }

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetClassificationPolicies_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteClassificationPolicy_Async

            _ = await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteClassificationPolicy_Async
        }
    }
}
