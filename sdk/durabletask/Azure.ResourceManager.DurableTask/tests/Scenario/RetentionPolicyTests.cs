// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DurableTask.Models;
using Azure.ResourceManager.Resources;
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
        public async Task CreateDeleteRetentionPolicyTest()
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
                    sku: new DurableTaskSchedulerSku() { Name = SchedulerSkuName.Dedicated, Capacity = 1 }
                )
            };
            ArmOperation<DurableTaskSchedulerResource> longRunningOperation =
                await rg.GetDurableTaskSchedulers().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, createSchedulerData);
            DurableTaskSchedulerResource scheduler = longRunningOperation.Value;

            // This is a singleton resource, so we need to updat the resource directly
            DurableTaskRetentionPolicyResource retentionPolicy = scheduler.GetDurableTaskRetentionPolicy();
            await retentionPolicy.GetAsync();

            retentionPolicy.Data.Properties.RetentionPolicies.Add(new DurableTaskRetentionPolicyDetails()
            {
              RetentionPeriodInDays = 3,
              OrchestrationState = DurableTaskPurgeableOrchestrationState.Completed
            });
            retentionPolicy.Data.Properties.RetentionPolicies.Add(new DurableTaskRetentionPolicyDetails()
            {
                RetentionPeriodInDays = 30,
                OrchestrationState = DurableTaskPurgeableOrchestrationState.Failed
            });
            retentionPolicy.Data.Properties.RetentionPolicies.Add(new DurableTaskRetentionPolicyDetails()
            {
                RetentionPeriodInDays = 30,
                // without OrchestrationState, this policy applies to all states not explicitly mentioned in other policies
            });

            await retentionPolicy.UpdateAsync(WaitUntil.Completed, retentionPolicy.Data);

            await retentionPolicy.GetAsync();
            Assert.AreEqual(3, retentionPolicy.Data.Properties.RetentionPolicies.Count);

            // Assert the specific policy for Completed orchestrations has the expected retention period
            DurableTaskRetentionPolicyDetails completedPolicy = retentionPolicy.Data.Properties.RetentionPolicies
                .SingleOrDefault(p => p.OrchestrationState == DurableTaskPurgeableOrchestrationState.Completed);

            Assert.NotNull(completedPolicy, "Expected a retention policy with OrchestrationState=Completed.");
            Assert.AreEqual(3, completedPolicy.RetentionPeriodInDays, "Unexpected retention days for Completed state.");

            await retentionPolicy.DeleteAsync(WaitUntil.Completed);

            await retentionPolicy.GetAsync().ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    var ex = t.Exception.Flatten().InnerExceptions[0] as RequestFailedException;
                    Assert.AreEqual(404, ex.Status);
                }
                else
                {
                    Assert.Fail("Expected an exception when trying to get a deleted retention policy.");
                }
            });
        }
    }
}
