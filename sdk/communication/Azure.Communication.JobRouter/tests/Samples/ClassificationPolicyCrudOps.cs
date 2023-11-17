// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
                    PrioritizationRule = new StaticRouterRule(new RouterValue(10)),
                    QueueSelectorAttachments =
                    {
                        new StaticQueueSelectorAttachment(new RouterQueueSelector("Region", LabelOperator.Equal, new RouterValue("NA"))),
                        new ConditionalQueueSelectorAttachment(
                            condition: new ExpressionRouterRule("If(job.Product = \"O365\", true, false)"),
                            queueSelectors: new List<RouterQueueSelector>()
                            {
                                new RouterQueueSelector("Product", LabelOperator.Equal, new RouterValue("O365")),
                                new RouterQueueSelector("QGroup", LabelOperator.Equal, new RouterValue("NA_O365"))
                            }),
                    },
                    WorkerSelectorAttachments =
                    {
                        new ConditionalWorkerSelectorAttachment(
                            condition: new ExpressionRouterRule("If(job.Product = \"O365\", true, false)"),
                            workerSelectors: new List<RouterWorkerSelector>()
                            {
                                new RouterWorkerSelector("Skill_O365", LabelOperator.Equal, new RouterValue(true)),
                                new RouterWorkerSelector("Skill_O365_Lvl", LabelOperator.GreaterThanOrEqual, new RouterValue(1))
                            }),
                        new ConditionalWorkerSelectorAttachment(
                            condition: new ExpressionRouterRule("If(job.HighPriority = \"true\", true, false)"),
                            workerSelectors: new List<RouterWorkerSelector>()
                            {
                                new RouterWorkerSelector("Skill_O365_Lvl", LabelOperator.GreaterThanOrEqual, new RouterValue(10))
                            })
                    }
                });

            Console.WriteLine($"Classification Policy successfully created with id: {classificationPolicy.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateClassificationPolicy

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetClassificationPolicy

            Response<ClassificationPolicy> queriedClassificationPolicy = routerAdministrationClient.GetClassificationPolicy(classificationPolicyId);

            Console.WriteLine($"Successfully fetched classification policy with id: {queriedClassificationPolicy.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetClassificationPolicy

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateClassificationPolicy

            Response<ClassificationPolicy> updatedClassificationPolicy = routerAdministrationClient.UpdateClassificationPolicy(
                new ClassificationPolicy(classificationPolicyId)
                {
                    PrioritizationRule = new ExpressionRouterRule("If(job.HighPriority = \"true\", 50, 10)")
                });

            Console.WriteLine($"Classification policy successfully update with new prioritization rule. RuleType: {updatedClassificationPolicy.Value.PrioritizationRule.Kind}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateClassificationPolicy

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetClassificationPolicies

            Pageable<ClassificationPolicy> classificationPolicies = routerAdministrationClient.GetClassificationPolicies(cancellationToken: default);
            foreach (Page<ClassificationPolicy> asPage in classificationPolicies.AsPages(pageSizeHint: 10))
            {
                foreach (ClassificationPolicy? policy in asPage.Values)
                {
                    Console.WriteLine($"Listing classification policy with id: {policy.Id}");
                }
            }

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetClassificationPolicies

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteClassificationPolicy

            _ = routerAdministrationClient.DeleteClassificationPolicy(classificationPolicyId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteClassificationPolicy
        }
    }
}
