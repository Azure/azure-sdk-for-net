// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Models;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core;
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
            JobRouterAdministrationClient routerAdministrationClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateClassificationPolicy_Async

            string classificationPolicyId = "my-classification-policy";

            Response<ClassificationPolicy> classificationPolicy = await routerAdministrationClient.CreateClassificationPolicyAsync(
                options: new CreateClassificationPolicyOptions(classificationPolicyId)
                {
                    Name = "Sample classification policy",
                    PrioritizationRule = new StaticRouterRule(new LabelValue(10)),
                    QueueSelectors =
                    {
                        new StaticQueueSelectorAttachment(new RouterQueueSelector("Region", LabelOperator.Equal, new LabelValue("NA"))),
                        new ConditionalQueueSelectorAttachment(
                            condition: new ExpressionRouterRule("If(job.Product = \"O365\", true, false)"),
                            queueSelectors: new List<RouterQueueSelector>()
                            {
                                new RouterQueueSelector("Product", LabelOperator.Equal, new LabelValue("O365")),
                                new RouterQueueSelector("QGroup", LabelOperator.Equal, new LabelValue("NA_O365"))
                            }),
                    },
                    WorkerSelectors =
                    {
                        new ConditionalWorkerSelectorAttachment(
                            condition: new ExpressionRouterRule("If(job.Product = \"O365\", true, false)"),
                            workerSelectors: new List<RouterWorkerSelector>()
                            {
                                new RouterWorkerSelector("Skill_O365", LabelOperator.Equal, new LabelValue(true)),
                                new RouterWorkerSelector("Skill_O365_Lvl", LabelOperator.GreaterThanEqual, new LabelValue(1))
                            }),
                        new ConditionalWorkerSelectorAttachment(
                            condition: new ExpressionRouterRule("If(job.HighPriority = \"true\", true, false)"),
                            workerSelectors: new List<RouterWorkerSelector>()
                            {
                                new RouterWorkerSelector("Skill_O365_Lvl", LabelOperator.GreaterThanEqual, new LabelValue(10))
                            })
                    }
                });

            Console.WriteLine($"Classification Policy successfully created with id: {classificationPolicy.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateClassificationPolicy_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetClassificationPolicy_Async

            Response<ClassificationPolicy> queriedClassificationPolicy = await routerAdministrationClient.GetClassificationPolicyAsync(classificationPolicyId);

            Console.WriteLine($"Successfully fetched classification policy with id: {queriedClassificationPolicy.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetClassificationPolicy_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateClassificationPolicyRemoveProp_Async

            Response updatedClassificationPolicyWithoutName = await routerAdministrationClient.UpdateClassificationPolicyAsync(classificationPolicyId,
                RequestContent.Create(new { Name = (string?)null }));

            Response<ClassificationPolicy> queriedClassificationPolicyWithoutName = await routerAdministrationClient.GetClassificationPolicyAsync(classificationPolicyId);

            Console.WriteLine($"Classification policy successfully updated: 'Name' has been removed. Status: {string.IsNullOrWhiteSpace(queriedClassificationPolicyWithoutName.Value.Name)}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateClassificationPolicyRemoveProp_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateClassificationPolicy_Async

            Response<ClassificationPolicy> updatedClassificationPolicy = await routerAdministrationClient.UpdateClassificationPolicyAsync(
                new UpdateClassificationPolicyOptions(classificationPolicyId)
                {
                    PrioritizationRule = new ExpressionRouterRule("If(job.HighPriority = \"true\", 50, 10)")
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
