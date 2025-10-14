﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
            SchedulerData createSchedulerData = new(AzureLocation.NorthCentralUS)
            {
                Properties = new SchedulerProperties(
                    ipAllowlist: ["0.0.0.0/0"], // all IPs allowed to access the endpoint
                    sku: new SchedulerSku() { Name = SchedulerSkuName.Dedicated, Capacity = 1 }
                )
            };
            ArmOperation<SchedulerResource> longRunningOperation =
                await rg.GetSchedulers().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, createSchedulerData);
            SchedulerResource scheduler = longRunningOperation.Value;

            // This is a singleton resource, but it does not yet exist until we create it
            RetentionPolicyResource singletonRetentionPolicy = scheduler.GetRetentionPolicy();

            // Construct the retention policy with multiple rules
            RetentionPolicyProperties retentionPolicyProperties = new RetentionPolicyProperties();
            retentionPolicyProperties.RetentionPolicies.Add(
                new RetentionPolicyDetails()
                {
                    RetentionPeriodInDays = 3,
                    OrchestrationState = PurgeableOrchestrationState.Completed
                });
            retentionPolicyProperties.RetentionPolicies.Add(
                new RetentionPolicyDetails()
                {
                    RetentionPeriodInDays = 30,
                    OrchestrationState = PurgeableOrchestrationState.Failed
                });
            retentionPolicyProperties.RetentionPolicies.Add(
                new RetentionPolicyDetails()
                {
                     RetentionPeriodInDays = 30,
                    // without OrchestrationState, this policy applies to all states not explicitly mentioned in other policies
                });

            RetentionPolicyData payload = new RetentionPolicyData()
            {
                Properties = retentionPolicyProperties
            };

            await singletonRetentionPolicy.CreateOrUpdateAsync(WaitUntil.Completed, payload);

            // Now fetch the resource details from the service
            singletonRetentionPolicy = await singletonRetentionPolicy.GetAsync();
            Assert.AreEqual(3, singletonRetentionPolicy.Data.Properties.RetentionPolicies.Count);

            // Assert the specific policy for Completed orchestrations has the expected retention period
            RetentionPolicyDetails completedPolicy = singletonRetentionPolicy.Data.Properties.RetentionPolicies
                .SingleOrDefault(p => p.OrchestrationState == PurgeableOrchestrationState.Completed);

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
