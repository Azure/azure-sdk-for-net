// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Samples
{
    public class DistributionPolicyCrudOps : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public void DistributionPolicyCrud()
        {
            // create a client
            JobRouterAdministrationClient routerAdministrationClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateDistributionPolicy

            string distributionPolicyId = "my-distribution-policy";

            Response<DistributionPolicy> distributionPolicy = routerAdministrationClient.CreateDistributionPolicy(
                new CreateDistributionPolicyOptions(
                    distributionPolicyId: distributionPolicyId,
                    offerExpiresAfter: TimeSpan.FromMinutes(1),
                    mode: new LongestIdleMode())
                {
                    Name = "My distribution policy"
                }
            );

            Console.WriteLine($"Distribution Policy successfully created with id: {distributionPolicy.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateDistributionPolicy

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetDistributionPolicy

            Response<DistributionPolicy> queriedDistributionPolicy = routerAdministrationClient.GetDistributionPolicy(distributionPolicyId);

            Console.WriteLine($"Successfully fetched distribution policy with id: {queriedDistributionPolicy.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetDistributionPolicy

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateDistributionPolicy

            Response<DistributionPolicy> updatedDistributionPolicy = routerAdministrationClient.UpdateDistributionPolicy(
                new DistributionPolicy(distributionPolicyId)
                {
                    // you can update one or more properties of distribution policy
                    Mode = new RoundRobinMode(),
                });

            Console.WriteLine($"Distribution policy successfully update with new distribution mode. Mode Type: {updatedDistributionPolicy.Value.Mode.Kind}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateDistributionPolicy

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetDistributionPolicies

            Pageable<DistributionPolicy> distributionPolicies = routerAdministrationClient.GetDistributionPolicies(cancellationToken: default);
            foreach (Page<DistributionPolicy> asPage in distributionPolicies.AsPages(pageSizeHint: 10))
            {
                foreach (DistributionPolicy? policy in asPage.Values)
                {
                    Console.WriteLine($"Listing distribution policy with id: {policy.Id}");
                }
            }

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetDistributionPolicies

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteDistributionPolicy

            _ = routerAdministrationClient.DeleteDistributionPolicy(distributionPolicyId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteDistributionPolicy
        }
    }
}
