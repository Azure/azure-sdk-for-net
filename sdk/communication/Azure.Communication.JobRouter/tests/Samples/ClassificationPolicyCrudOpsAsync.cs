// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Models;
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
            // create a client
            RouterAdministrationClient routerAdministrationClient = new RouterAdministrationClient("<< CONNECTION STRING >>");

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateClassificationPolicy_Async

            string classificationPolicyId = "my-classification-policy";

            Response<ClassificationPolicy> classificationPolicy = await routerAdministrationClient.CreateClassificationPolicyAsync(
                options: new CreateClassificationPolicyOptions(classificationPolicyId)
                {
                    Name = "Sample classification policy",
                    PrioritizationRule = new StaticRule(new LabelValue(10)),
                    QueueSelectors = new List<QueueSelectorAttachment>()
                    {
                        new StaticQueueSelectorAttachment(new QueueSelector("Region", LabelOperator.Equal, new LabelValue("NA"))),
                        new ConditionalQueueSelectorAttachment(
                            condition: new ExpressionRule("If(job.Product = \"O365\", true, false)"),
                            labelSelectors: new List<QueueSelector>()
                            {
                                new QueueSelector("Product", LabelOperator.Equal, new LabelValue("O365")),
                                new QueueSelector("QGroup", LabelOperator.Equal, new LabelValue("NA_O365"))
                            }),
                    },
                    WorkerSelectors = new List<WorkerSelectorAttachment>()
                    {
                        new ConditionalWorkerSelectorAttachment(
                            condition: new ExpressionRule("If(job.Product = \"O365\", true, false)"),
                            labelSelectors: new List<WorkerSelector>()
                            {
                                new WorkerSelector("Skill_O365", LabelOperator.Equal, new LabelValue(true)),
                                new WorkerSelector("Skill_O365_Lvl", LabelOperator.GreaterThanEqual, new LabelValue(1))
                            }),
                        new ConditionalWorkerSelectorAttachment(
                            condition: new ExpressionRule("If(job.HighPriority = \"true\", true, false)"),
                            labelSelectors: new List<WorkerSelector>()
                            {
                                new WorkerSelector("Skill_O365_Lvl", LabelOperator.GreaterThanEqual, new LabelValue(10))
                            })
                    }
                });

            Console.WriteLine($"Classification Policy successfully created with id: {classificationPolicy.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateClassificationPolicy_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetClassificationPolicy_Async

            Response<ClassificationPolicy> queriedClassificationPolicy = await routerAdministrationClient.GetClassificationPolicyAsync(classificationPolicyId);

            Console.WriteLine($"Successfully fetched classification policy with id: {queriedClassificationPolicy.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetClassificationPolicy_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateClassificationPolicy_Async

            Response<ClassificationPolicy> updatedClassificationPolicy = await routerAdministrationClient.UpdateClassificationPolicyAsync(
                new UpdateClassificationPolicyOptions(classificationPolicyId)
                {
                    PrioritizationRule = new ExpressionRule("If(job.HighPriority = \"true\", 50, 10)")
                });

            Console.WriteLine($"Classification policy successfully update with new prioritization rule. RuleType: {updatedClassificationPolicy.Value.PrioritizationRule.Kind}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateClassificationPolicy_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetClassificationPolicies_Async

            AsyncPageable<ClassificationPolicyItem> classificationPolicies = routerAdministrationClient.GetClassificationPoliciesAsync();
            await foreach (Page<ClassificationPolicyItem> asPage in classificationPolicies.AsPages(pageSizeHint: 10))
            {
                foreach (ClassificationPolicyItem? policy in asPage.Values)
                {
                    Console.WriteLine($"Listing classification policy with id: {policy.ClassificationPolicy.Id}");
                }
            }

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetClassificationPolicies_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteClassificationPolicy_Async

            _ = await routerAdministrationClient.DeleteClassificationPolicyAsync(classificationPolicyId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteClassificationPolicy_Async
        }
    }
}
