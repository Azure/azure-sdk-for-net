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
    public class ClassificationPolicyCrudOps : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public void ClassificationPolicyCrud()
        {
            // create a client
            JobRouterAdministrationClient routerAdministrationClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateClassificationPolicy

            string classificationPolicyId = "my-classification-policy";

            Response<ClassificationPolicy> classificationPolicy = routerAdministrationClient.CreateClassificationPolicy(
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

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateClassificationPolicy

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetClassificationPolicy

            Response<ClassificationPolicy> queriedClassificationPolicy = routerAdministrationClient.GetClassificationPolicy(classificationPolicyId);

            Console.WriteLine($"Successfully fetched classification policy with id: {queriedClassificationPolicy.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetClassificationPolicy

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateClassificationPolicyRemoveProp

            Response updatedClassificationPolicyWithoutName = routerAdministrationClient.UpdateClassificationPolicy(classificationPolicyId,
                RequestContent.Create(new { Name = (string?)null }));

            Response<ClassificationPolicy> queriedClassificationPolicyWithoutName = routerAdministrationClient.GetClassificationPolicy(classificationPolicyId);

            Console.WriteLine($"Classification policy successfully updated: 'Name' has been removed. Status: {string.IsNullOrWhiteSpace(queriedClassificationPolicyWithoutName.Value.Name)}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateClassificationPolicyRemoveProp

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateClassificationPolicy

            Response<ClassificationPolicy> updatedClassificationPolicy = routerAdministrationClient.UpdateClassificationPolicy(
                new UpdateClassificationPolicyOptions(classificationPolicyId)
                {
                    PrioritizationRule = new ExpressionRouterRule("If(job.HighPriority = \"true\", 50, 10)")
                });

            Console.WriteLine($"Classification policy successfully update with new prioritization rule. RuleType: {updatedClassificationPolicy.Value.PrioritizationRule.Kind}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateClassificationPolicy

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetClassificationPolicies

            Pageable<ClassificationPolicyItem> classificationPolicies = routerAdministrationClient.GetClassificationPolicies();
            foreach (Page<ClassificationPolicyItem> asPage in classificationPolicies.AsPages(pageSizeHint: 10))
            {
                foreach (ClassificationPolicyItem? policy in asPage.Values)
                {
                    Console.WriteLine($"Listing classification policy with id: {policy.ClassificationPolicy.Id}");
                }
            }

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetClassificationPolicies

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteClassificationPolicy

            _ = routerAdministrationClient.DeleteClassificationPolicy(classificationPolicyId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteClassificationPolicy
        }
    }
}
