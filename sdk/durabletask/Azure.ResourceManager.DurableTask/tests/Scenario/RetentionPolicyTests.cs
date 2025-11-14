// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DurableTask.Models;
using Azure.ResourceManager.Resources;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.ResourceManager.DurableTask.Tests.Scenario
{
    public class RetentionPolicyTests : DurableTaskSchedulerManagementTestBase
    {
        public RetentionPolicyTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateGetDeleteRetentionPolicyTest()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg", AzureLocation.NorthCentralUS);
            await TestContext.Error.WriteLineAsync(
                $"subscription: {subscription.Data.SubscriptionId}, resource group {rg.Data.Name}");
            string resourceName = Recording.GenerateAssetName("resource");

            // Create Scheduler
            DurableTaskSchedulerData createSchedulerData = new(AzureLocation.NorthCentralUS)
            {
                Properties = new DurableTaskSchedulerProperties(
                    ipAllowlist: ["0.0.0.0/0"], // all IPs allowed to access the endpoint
                    sku: new DurableTaskSchedulerSku() { Name = DurableTaskSchedulerSkuName.Dedicated, Capacity = 1 }
                )
            };
            ArmOperation<DurableTaskSchedulerResource> longRunningOperation =
                await rg.GetDurableTaskSchedulers().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, createSchedulerData);
            DurableTaskSchedulerResource scheduler = longRunningOperation.Value;

            // This is a singleton resource, but it does not yet exist until we create it
            DurableTaskRetentionPolicyResource singletonRetentionPolicy = scheduler.GetDurableTaskRetentionPolicy();

            // Construct the retention policy with multiple rules
            DurableTaskRetentionPolicyProperties retentionPolicyProperties = new DurableTaskRetentionPolicyProperties();
            retentionPolicyProperties.RetentionPolicies.Add(
                new DurableTaskRetentionPolicyDetails()
                {
                    RetentionPeriodInDays = 3,
                    OrchestrationState = DurableTaskPurgeableOrchestrationState.Completed
                });
            retentionPolicyProperties.RetentionPolicies.Add(
                new DurableTaskRetentionPolicyDetails()
                {
                    RetentionPeriodInDays = 30,
                    OrchestrationState = DurableTaskPurgeableOrchestrationState.Failed
                });
            retentionPolicyProperties.RetentionPolicies.Add(
                new DurableTaskRetentionPolicyDetails()
                {
                     RetentionPeriodInDays = 30,
                    // without OrchestrationState, this policy applies to all states not explicitly mentioned in other policies
                });

            DurableTaskRetentionPolicyData payload = new DurableTaskRetentionPolicyData()
            {
                Properties = retentionPolicyProperties
            };

            await singletonRetentionPolicy.CreateOrUpdateAsync(WaitUntil.Completed, payload);

            // Now fetch the resource details from the service
            singletonRetentionPolicy = await singletonRetentionPolicy.GetAsync();
            Assert.AreEqual(3, singletonRetentionPolicy.Data.Properties.RetentionPolicies.Count);

            // Assert the specific policy for Completed orchestrations has the expected retention period
            DurableTaskRetentionPolicyDetails completedPolicy = singletonRetentionPolicy.Data.Properties.RetentionPolicies
                .SingleOrDefault(p => p.OrchestrationState == DurableTaskPurgeableOrchestrationState.Completed);

            Assert.NotNull(completedPolicy, "Expected a retention policy with OrchestrationState=Completed.");
            Assert.AreEqual(3, completedPolicy.RetentionPeriodInDays, "Unexpected retention days for Completed state.");

            await singletonRetentionPolicy.DeleteAsync(WaitUntil.Completed);

            try
            {
                await singletonRetentionPolicy.GetAsync();
            }
            catch (RequestFailedException ex) when (ex.Status == StatusCodes.Status404NotFound)
            {
                // Expected exception
                Assert.Pass("Retention policy deleted successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception: {ex}");
            }
        }
    }
}
