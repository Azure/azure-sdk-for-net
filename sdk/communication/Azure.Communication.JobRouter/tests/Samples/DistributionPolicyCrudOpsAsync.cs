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
    public class DistributionPolicyCrudOpsAsync : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public async Task DistributionPolicyCrud()
        {
#if !SNIPPET
            // create a client
            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
#endif

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateDistributionPolicy_Async

            var distributionPolicyId = "my-distribution-policy";

            var distributionPolicy = await routerClient.CreateDistributionPolicyAsync(
                id: distributionPolicyId,
                offerTtlSeconds: 60,
                mode: new LongestIdleMode(),
                new CreateDistributionPolicyOptions() // this is optional
                {
                    Name = "My distribution policy"
                }
            );

            Console.WriteLine($"Distribution Policy successfully created with id: {distributionPolicy.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateDistributionPolicy_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetDistributionPolicy_Async

            var queriedDistributionPolicy = await routerClient.GetDistributionPolicyAsync(distributionPolicyId);

            Console.WriteLine($"Successfully fetched distribution policy with id: {queriedDistributionPolicy.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetDistributionPolicy_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateDistributionPolicy_Async

            var updatedDistributionPolicy = await routerClient.UpdateDistributionPolicyAsync(
                distributionPolicyId,
                new UpdateDistributionPolicyOptions()
                {
                    // you can update one or more properties of distribution policy
                    Mode = new RoundRobinMode(),
                });

            Console.WriteLine($"Distribution policy successfully update with new distribution mode. Mode Type: {updatedDistributionPolicy.Value.Mode.Kind}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateDistributionPolicy_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetDistributionPolicies_Async

            var distributionPolicies = routerClient.GetDistributionPoliciesAsync();
            await foreach (var asPage in distributionPolicies.AsPages(pageSizeHint: 10))
            {
                foreach (var policy in asPage.Values)
                {
                    Console.WriteLine($"Listing distribution policy with id: {policy.Id}");
                }
            }

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetDistributionPolicies_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteDistributionPolicy_Async

            _ = await routerClient.DeleteDistributionPolicyAsync(distributionPolicyId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteDistributionPolicy_Async
        }
    }
}
